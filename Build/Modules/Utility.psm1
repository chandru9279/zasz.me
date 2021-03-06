[string] $StateFile = '..\Out\State.json'
[string] $SolrUrl = 'http://localhost:5000/solr'
[int] $Expires = 3

function Skip-Delete 
{
	#This function will delete all folders and files recursively, leaving the folders with .gitkeep alone.
	[CmdletBinding()]
	param(
		[Parameter(Position=0,Mandatory=1)] [string] $folder
	)
	if(Test-Path $folder) {
	Get-ChildItem $folder -Recurse -File | ? { $_.FullName -notmatch ".gitkeep" } | Remove-Item -Force
	Get-ChildItem $folder -Recurse -Directory | ? { $_.GetFiles().Count -eq 0 } | Remove-Item -Recurse -Force
	}
}

function Test-Solr
{
	try {
		$response = (New-Object System.Net.WebClient).DownloadString($SolrUrl)        
		Write-Host -ForegroundColor Yellow "Solr is already running";
	}
	catch [System.Net.WebException] { 
		return $false
	}
	return $response -ne $null
}

function Trace-Robocopy
{
    #http://ss64.com/nt/robocopy-exit.html
	[CmdletBinding()]
	param(
		[Parameter(Position=0,Mandatory=1)] [scriptblock] $robocopy
	)
	&$robocopy
	$exit = $LastExitCode
    $nl = [Environment]::NewLine
    $OkCopy = "New files from source copied to destination."
    $NoChange = "Source and destination in sync. No files copied."
    $Xtra = "Some Extra files or directories were detected and removed in destination."
    $Mismatches = "Some Mismatched files or directories were detected.`n
	Housekeeping is probably necessary."
    $Fail = "Some files or directories could not be copied (copy errors occurred and the retry limit was exceeded)."
    $Fatal = "Serious error. robocopy did not copy any files."

	$msg=@{
	"16"  =  " $Fatal"
    "15"  =  " $OkCopy $nl $Fail $nl $Mismatches $nl $Xtra"
    "14"  =  " $Fail $nl $Mismatches $nl $Xtra"
    "13"  =  " $OkCopy $nl $Fail $nl $Mismatches"
    "12"  =  " $Fail $nl $Mismatches"
    "11"  =  " $OkCopy $nl $Fail $nl $Xtra"
    "10"  =  " $Fail $nl $Xtra"
    "9"   =  " $OkCopy $nl $Fail"
	"8"   =  " $Fail"
    "7"   =  " $OkCopy $nl $Mismatches $nl  $Xtra"
    "6"   =  " $Mismatches $nl $Xtra"
    "5"   =  " $OkCopy $nl $Mismatches"
	"4"   =  " $Mismatches"
	"3"   =  " $OkCopy $nl $Xtra"
    "2"   =  " $Xtra"
	"1"   =  " $OkCopy"
	"0"   =  " $NoChange"
	}

	if ($msg."$exit" -gt $null) {
		Write-Host -ForegroundColor Yellow $msg."$exit"
	}
	else {
		Write-Host -ForegroundColor Yellow "Unknown ExitCode : $exit"
	}
}

function Get-URL
{
	[CmdletBinding()]
	param(
		[Parameter(Position=0,Mandatory=1)] [string] $url,
		[Parameter(Position=1,Mandatory=0)] [string] $messageOnFailure = 'Connect to url failed'
	)
	try {
		$response = (New-Object System.Net.WebClient).DownloadString($url)
		return $response
	}
	catch [System.Net.WebException] { 
		Write-Host -ForegroundColor Red $messageOnFailure;
		return $null
	}  
}

function Open-Solr
{
	[CmdletBinding()]
	param(
		[Parameter(Position=0,Mandatory=0)] [string] $solrUrl = $SolrUrl        
	)
	try {    
		Write-Host -ForegroundColor Yellow "Opening solr web console..";
		Start-Process $solrUrl
	}
	catch [System.Exception] { 
		Write-Host -ForegroundColor Yellow "Could not open solr web console. Browse manually to $solrUrl";    
	}
}

function Get-State
{	
	[PSObject] $state = @{}
	if(Test-Path $StateFile) {		
		$json = Get-Content $StateFile
		$stateObject = ConvertFrom-Json "$json"
		$state = @{}
		$stateObject.PSObject.Properties | % { $state[$_.Name] = $_.Value }
		if(((Get-Date) - [DateTime]::Parse($state.Timestamp)).TotalHours -le $Expires) {
			Write-Host -ForegroundColor Yellow "State hasn't expired";
			return $state
		}
		Write-Host -ForegroundColor Yellow "State expired. Set a new state.";
		return @{}
	}
	Write-Host -ForegroundColor Yellow "Starting new state.";
	return @{}
}

function Set-State
{
	[CmdletBinding()]
	param(
		[Parameter(Position=0,Mandatory=1)] [PSObject] $state        
	)
	$state.Timestamp = (Get-Date).DateTime
	$state | ConvertTo-Json | Out-File -Force -FilePath $StateFile	
	Write-Host -ForegroundColor Yellow "State set.";
}

Export-Modulemember `
	-Function Skip-Delete, Test-Solr, Trace-Robocopy, Get-URL, Open-Solr, Get-State, Set-State `
	-Variable StateFile, SolrUrl, Expires
