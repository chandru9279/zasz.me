#This function will delete all folders and files recursively, leaving the folders with .gitkeep alone.
function Skip-Delete 
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)] [string]$folder
    )
    Get-ChildItem $folder -Recurse -File | ? { $_.FullName -notmatch ".gitkeep" } | Remove-Item -Force
    Get-ChildItem $folder -Recurse -Directory | ? { $_.GetFiles().Count -eq 0 } | Remove-Item -Recurse -Force
}

function Test-Solr
{
    try {
    $response = (New-Object System.Net.WebClient).DownloadString("http://localhost:5000/solr")
    }
    catch [System.Net.WebException] {
    return $false
    }
    return $response -ne $null
}

function create-7zip([String] $aDirectory, [String] $aZipfile){
    [string]$pathToZipExe = "C:\Program Files\7-zip\7z.exe";
    [Array]$arguments = "a", "-tzip", "$aZipfile", "$aDirectory", "-r";
    & $pathToZipExe $arguments;
}

export-modulemember -function Skip-Delete, Test-Solr
