    Zasz.ME  Revamping ChandruOn.NET

Installation :

1) Go to Data-Tools-Setup folder and run Packages.bat - This will fetch the Nuget packages
2) Need an account in MS SQLSERVER, that has permission to create and drop databases. 
    Run 0-zasz-login.sql in Data-Tools-Setup folder, which will create the login, and since it is
	disabled by default, go and enable it using Management studio.
3) Note the VisualStudio configurations - holds the different environments, keep this up to date.
	
Server Installation :
4) Go to Data-Tools-Setup folder and run ServerBuild.bat

If using IIS : 

5) Create an application pool in IIS, create a site (zasz.me), point it to folder zasz.me\
6) Optionally change the Temp Compilation directory to some suitable directory

If VisualStudio ASP.NET development server :

7) Open zasz.me.sln and press F5 xD


IIS Advanced Changes :

1) Changed "binding" settings of the various sites to include a host name. Added HTTPS   
   binding to zasz.me, Similar change in AWS Security group if using AWS.
2) Turned on SMTP and FTP feature. Set SMTP server to accept max two connections only,
   and that too only from localhost.


