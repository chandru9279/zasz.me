set Tools=%CD%
cd ..\
mkdir packages
cd packages
"%Tools%\nuget" update -self 
"%Tools%\nuget" i ..\zasz.me\packages.config -o .
"%Tools%\nuget" i ..\zasz.develop\packages.config -o .
"%Tools%\nuget" i ..\zasz.health\packages.config -o .
pause