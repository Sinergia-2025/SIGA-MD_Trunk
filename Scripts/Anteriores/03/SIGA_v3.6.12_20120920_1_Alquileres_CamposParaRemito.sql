
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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Alquileres ADD
	IdTipoComprobante varchar(15) NULL,
	Letra varchar(1) NULL,
	CentroEmisor int NULL,
	NumeroComprobante bigint NULL
GO
ALTER TABLE dbo.Alquileres ADD CONSTRAINT
	FK_Alquileres_Ventas FOREIGN KEY
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
ALTER TABLE dbo.Alquileres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
