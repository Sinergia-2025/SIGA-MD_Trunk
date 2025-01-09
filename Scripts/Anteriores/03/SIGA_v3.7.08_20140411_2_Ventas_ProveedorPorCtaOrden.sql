
ALTER TABLE VENTAS ADD TipoDocProveedor	varchar(5) NULL
GO

ALTER TABLE VENTAS ADD NroDocProveedor	bigint NULL
GO

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_Proveedores FOREIGN KEY
	(
	TipoDocProveedor,
	NroDocProveedor
	) REFERENCES dbo.Proveedores
	(
	TipoDocProveedor,
	NroDocProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
