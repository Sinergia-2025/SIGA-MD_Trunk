
ALTER TABLE Clientes ADD IdTipoDeExension smallint null
GO
ALTER TABLE Clientes ADD AnioExension int null
GO
ALTER TABLE Clientes ADD NroCertExension varchar(6) null
GO
ALTER TABLE Clientes ADD NroCertPropio varchar(12) null
GO

ALTER TABLE AuditoriaClientes ADD IdTipoDeExension smallint null
GO
ALTER TABLE AuditoriaClientes ADD AnioExension int null
GO
ALTER TABLE AuditoriaClientes ADD NroCertExension varchar(6) null
GO
ALTER TABLE AuditoriaClientes ADD NroCertPropio varchar(12) null
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
ALTER TABLE dbo.TiposDeExension SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_TiposDeExension FOREIGN KEY
	(
	IdTipoDeExension
	) REFERENCES dbo.TiposDeExension
	(
	IdTipoDeExension
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* ---------------------------------- */

UPDATE Clientes
 SET IdTipoDeExension = 0	--No Exento
 WHERE InscriptoIBStaFe = 'True'
GO

