call Packages.bat
cd ..\
set MSB=C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild
"%MSB%" "zasz.me.sln" /p:Configuration=Server /p:Platform="Any CPU" /t:Clean;Build
pause