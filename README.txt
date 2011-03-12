    Zasz.ME  Revamping ChandruOn.NET

Installation :

1) Go to zasz.me\App_data\Setup and Run Packages.bat
2) After download of all packages, Replace this
   packages\RavenDB.<version>\server\Raven.Server.exe.config
   with this
   zasz.me\App_data\Setup\Raven.Server.exe.config
3) Run Raven.Server.exe if console is needed or "Raven.Server.exe /install" if it needs to be a service

If using IIS : 

4) Create an application pool in IIS, create a site (zasz.me), point it to folder zasz.me\
5) Optionally change the Temp Compilation directory to some suitable directory

If VisualStudio ASP.NET development server :

4) Open zasz.me.sln and press f5 xD


