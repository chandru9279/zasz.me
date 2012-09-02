#This function will delete all folders and files recursively, leaving the folders with .gitkeep alone.
function Skip-Delete 
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)] [string]$folder
    )
    Get-ChildItem $folder -Recurse -File | ? { $_.FullName -notmatch ".gitkeep" } | Remove-Item
    Get-ChildItem $folder -Recurse -Directory | ? { $_.GetFiles().Count -eq 0 } | Remove-Item
}

export-modulemember -function Skip-Delete
