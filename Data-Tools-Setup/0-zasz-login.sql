/****** Object:  Login [zasz.me]    Script Date: 05/02/2011 17:33:25 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'zasz.me')
DROP LOGIN [zasz.me]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [zasz.me]    Script Date: 05/02/2011 17:33:25 ******/
CREATE LOGIN [zasz.me] WITH PASSWORD=N'´äEÙÝO%Ï>ÞÃæÃÕuÿ6OÕ3¸p3', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'sysadmin'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'securityadmin'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'serveradmin'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'setupadmin'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'processadmin'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'diskadmin'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'dbcreator'
GO

EXEC sys.sp_addsrvrolemember @loginame = N'zasz.me', @rolename = N'bulkadmin'
GO

ALTER LOGIN [zasz.me] DISABLE
GO

