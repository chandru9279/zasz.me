#This function will delete all folders and files recursively, leaving the folders with .gitkeep alone.
function Skip-Delete 
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)] [string] $folder
    )
    Get-ChildItem $folder -Recurse -File | ? { $_.FullName -notmatch ".gitkeep" } | Remove-Item -Force
    Get-ChildItem $folder -Recurse -Directory | ? { $_.GetFiles().Count -eq 0 } | Remove-Item -Recurse -Force
}

function Test-Solr
{
    try {
        $response = (New-Object System.Net.WebClient).DownloadString("http://localhost:5000/solr")        
        Write-Host -ForegroundColor Yellow "Solr is already running";
    }
    catch [System.Net.WebException] { 
        return $false
    }
    return $response -ne $null
}

function Trace-Robocopy
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)] [scriptblock] $robocopy
    )
    &$robocopy
    $exit = $LastExitCode

    $msg=@{
    "16"="Serious error. robocopy did not copy any files."
    "8"="Some files or directories could not be copied (copy errors occurred and the retry limit was exceeded)."
    "4"="Some Mismatched files or directories were detected.`n
    Housekeeping is probably necessary."
    "2"="Some Extra files or directories were detected and removed in destination."
    "1"="New files from source copied to destination."
    "0"="source and destination in sync. No files copied."
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

export-modulemember -function Skip-Delete, Test-Solr, Trace-Robocopy, Get-URL
