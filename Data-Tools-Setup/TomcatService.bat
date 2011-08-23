REM While starting as admin preserve start directory : http://stackoverflow.com/questions/672693/windows-batch-file-starting-directory-when-run-as-admin
echo %~dp0  
REM /D will change drive and directory
cd /D %~dp0..\zasz.vitalize\content\tomcat\bin\
REM Not using call will not return control to this file!
call service.bat uninstall
call service.bat install
REM Will start the newly installed service
net start Tomcat7
pause