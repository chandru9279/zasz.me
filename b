#!/bin/sh
echo $1;
if[ "$1" -eq "/?" || "$1" -eq "-help" || "$1" -eq "-h"]
then
powershell -NoProfile -ExecutionPolicy Bypass -Command "& Build\psake.ps1 -help"
elif [ $1 = "" ]
powershell -NoProfile -ExecutionPolicy Bypass -Command "& Build\psake.ps1; if (\$psake.build_success -eq \$false) { exit 1 } else { exit 0 }"
else
powershell -NoProfile -ExecutionPolicy Bypass -Command "& Build\psake.ps1 -task $*; if (\$psake.build_success -eq \$false) { exit 1 } else { exit 0 }"
fi


