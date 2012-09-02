<#
-------------------------------------------------------------------
Defaults
-------------------------------------------------------------------
$config.buildFileName="default.ps1"
$config.framework = "4.0"
$config.taskNameFormat="Executing {0}"
$config.verboseError=$false
$config.coloredOutput = $true
$config.modules=$null

-------------------------------------------------------------------
Use scriptblock for taskNameFormat
-------------------------------------------------------------------
$config.taskNameFormat= { param($taskName) "Executing $taskName at $(get-date)" }
#>

$config.modules=(".\Build\Modules\*.psm1")

