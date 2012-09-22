@echo off

if '%1'=='/?' goto help
if '%1'=='-help' goto help
if '%1'=='-h' goto help

if '%1'=='' goto default

powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\Build\psake.ps1' -task %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
goto :eof

:help
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\Build\psake.ps1' -help"
goto :eof

:default
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\Build\psake.ps1'"
