
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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasCajeros ADD CONSTRAINT
	FK_VentasCajeros_Ventas FOREIGN KEY
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) REFERENCES dbo.Ventas
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.VentasCajeros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
