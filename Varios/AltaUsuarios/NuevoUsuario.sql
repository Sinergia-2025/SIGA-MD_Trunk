
--Creo usuario
---------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = N'mblanco')
   DROP LOGIN mblanco
GO

CREATE LOGIN mblanco WITH PASSWORD='m01', DEFAULT_DATABASE=[SIGA], DEFAULT_LANGUAGE=[Español], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN mblanco ENABLE
GO

CREATE USER mblanco FOR LOGIN mblanco WITH DEFAULT_SCHEMA = dbo
GO
