#Zasz.ME
##Revamping ChandruOn.NET
	
####SetupCommon Installation

1. Need [.NET 4] and [MS SQLSERVER 2008] running.
2. Need an account in MS SQLSERVER, that has permission to create and drop databases. 
    Run 0-zasz-login.sql in Data-Tools-Setup folder, which will create the login, and since it is
	disabled by default, go and enable it using Management studio.
3. Create a database ColdStorage and set the zasz.me login as owner.
4. Run the  2 latest sql files on the ColdStorage database.  X-Data.sql & X-Schema.sql.
5. Need With [JRE6] installed and environment variable JRE_HOME set.
                 

####Server Installation

	
1. Go to Data-Tools-Setup folder and run ServerBuild.bat
2. Create an application pool in IIS, create a site (zasz.me), point it to folder zasz.me\
(The next few are Advanced Changes, they are needed for mail and https functionality.)
3. Go to Data-Tools-Setup folder and use the Readme.txt and SelfSSL7.exe to install a SSCert into IIS
4. Changed "binding" settings of the various sites to include a host name. Added HTTPS   
   binding to zasz.me, using the installed SSCert. Allow https in AWS Security group if using AWS.
5. Turned on SMTP and FTP feature. Set SMTP server to accept max two connections only,
   and that too only from localhost.
6. Optionally change the Temp Compilation directory to some suitable directory
7. Start the website.

####Devbox
	
1. Go to Data-Tools-Setup folder and run Packages.bat - This will fetch the Nuget packages
2. Open zasz.me.sln and press F5 xD
3. Note the VisualStudio configurations - holds the different environments, keep this up to date.




