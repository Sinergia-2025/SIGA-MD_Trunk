
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
ALTER TABLE dbo.Provincias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Retenciones ADD IdProvincia char(2) NULL
GO
ALTER TABLE dbo.Retenciones ADD CONSTRAINT FK_Retenciones_Provincias
    FOREIGN KEY (IdProvincia)
    REFERENCES dbo.Provincias (IdProvincia)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Retenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

--- Actualizo la historia. Asumo que es la provincia del Cliente.

UPDATE Retenciones
   SET IdProvincia = L.IdProvincia
  FROM Retenciones R
 INNER JOIN Clientes C ON C.IdCliente = R.IdCliente
 INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad
 WHERE R.IdTipoImpuesto = 'RIIBB'
   AND R.IdProvincia IS NULL
GO
