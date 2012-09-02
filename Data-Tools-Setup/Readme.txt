Used this on server to create & add a self signed cert

SelfSSL7.exe /Q /T /I /S "zasz.me" /N cn=zasz.me;cn=chandruon.net;cn=localhost /V 3000

Help on this command.

Self-signed certificate management tool for IIS 7.0 and 7.5. 

USAGE:
SELFSSL7.EXE [/N cn=<name>] [/K <size>] [/V <days>] [/T] [/I] [/S <name>] [/A <IPAddress>] [/P <port>] [/X] [/F <file>] [/W <password>] [/Q] 

CERTIFCATE PARAMETERS:
/N name	Specifies the common name(s) of the certificate. 
	Computer name is used if not specified.
	Example: /N cn=m1.contoso.com or /N cn=m1.contoso.com;cn=m2.contoso.com
/K size	Specifies the key length. Default is 1024.
/V days	Specifies the validity of the certificate in days. 
	Default is 30 days.

TRUST PARAMETERS:
/T	Adds the self-signed certificate to user's "Trusted Certificates" list.

IIS PARAMETERS:
/I	Add SSL binding to IIS. 
	Use with the following parameters:
	/S name	Specifies the name of the site. Default is "Default Web Site".
	/A IP	Specifies the IP address for the IIS binding. Default is *.
	/P port	Specifies the SSL port. Default is 443.

EXPORT PARAMETERS:
/X	Export certificate to PFX file.
	Use with the following parameters:
	/F	PFX file location.
	/W	password for PFX file.

OTHER PARAMETERS:
	/Q	Overwrites existing SSL binding and/or PFX file. 

The default behavior is equivalent with:
	selfssl7.exe /N cn=IP-0A82094F /K 1024 /V 30 
	/I /S "Default Web Site /P443 /A * /T
