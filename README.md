#Zasz.ME
	
####SetupCommon Installation

1. Need [.NET 4] and [MS SQLSERVER 2008] running.
2. Need an account in [MS SQLSERVER], that has permission to create and drop databases.
3. Create a database ColdStorage and set the zasz.me login as owner.
4. Need With [JRE] installed and environment variable JRE_HOME set.
                 

####Server Installation

1. b deploy from command prompt
2. .net 4 Application pool in IIS
3. Site (zasz.me), point it to folder zasz.me\
4. SelfSSL7.exe to install a SSCert into IIS
5. Bindings to include a host name. Added HTTPS binding, using the installed SSCert.
6. Optionally change the Temp Compilation directory to some suitable directory
7. Start the website.

####Devbox
	
1. b packages
2. b solrc
3. b compile




