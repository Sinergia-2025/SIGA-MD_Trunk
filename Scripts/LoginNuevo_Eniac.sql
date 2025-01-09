
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = N'Eniac')
   DROP LOGIN [Eniac]
GO

CREATE LOGIN [Eniac] WITH PASSWORD='Eniac2010', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

EXEC sys.sp_addsrvrolemember @loginame = N'Eniac', @rolename = N'sysadmin'
GO

ALTER LOGIN [Eniac] ENABLE
GO


