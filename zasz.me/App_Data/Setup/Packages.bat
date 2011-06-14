cd ..\..\..\
mkdir packages
cd packages
nuget update
nuget i ..\zasz.me\packages.config -o .
nuget i ..\zasz.develop\packages.config -o .
nuget i ..\zasz.health\packages.config -o .
pause