
ALTER TABLE Ventas ADD Direccion varchar(100) null
GO
--ALTER TABLE Ventas ADD LocalidadCliente varchar(50) null
--GO
ALTER TABLE Ventas ADD IdLocalidad int null
GO
--ALTER TABLE Ventas ADD ProvinciaCliente varchar(50) null
--GO


--UPDATE Ventas 
--   SET Ventas.DireccionCliente = C.Direccion
--      ,Ventas.LocalidadCliente = L.NombreLocalidad
--      ,Ventas.ProvinciaCliente = P.NombreProvincia
--FROM Ventas V 
--INNER JOIN CLientes C ON V.IdCliente = C.IdCliente
--INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad
--INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia
--GO


UPDATE Ventas 
   SET Ventas.Direccion = C.Direccion
      ,Ventas.IdLocalidad = C.IdLocalidad
 FROM Ventas V 
 INNER JOIN CLientes C ON V.IdCliente = C.IdCliente
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_Localidades FOREIGN KEY
	(
	IdLocalidad
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
