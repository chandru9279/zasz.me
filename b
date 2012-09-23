#!/bin/sh
if [ "$1" = "" ]
then
powershell -NoProfile -ExecutionPolicy Bypass -Command "& 'Build\psake.ps1'";
elif [ "$1" = "/?" -o "$1" = "-help" -o "$1" = "-h" ]
then
powershell -NoProfile -ExecutionPolicy Bypass -Command "& Build\psake.ps1 -help"
else
powershell -NoProfile -ExecutionPolicy Bypass -Command "& Build\psake.ps1 -task $*; if (\$psake.build_success -eq \$false) { exit 1 } else { exit 0 }"
fi


