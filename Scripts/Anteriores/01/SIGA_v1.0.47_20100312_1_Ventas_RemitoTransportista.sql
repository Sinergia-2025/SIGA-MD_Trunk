
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
ALTER TABLE dbo.Transportistas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD
	Bultos int NULL,
	ValorDeclarado decimal(12, 2) NULL,
	IdTransportista int NULL,
	NumeroLote bigint NULL
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_Transportistas FOREIGN KEY
	(
	IdTransportista
	) REFERENCES dbo.Transportistas
	(
	IdTransportista
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*-------------------------*/

UPDATE dbo.Ventas SET
	Bultos = 0,
	ValorDeclarado = 0,
	NumeroLote = 0
GO

/*-------------------------*/

ALTER TABLE dbo.Ventas ALTER COLUMN Bultos int NOT NULL 
GO

ALTER TABLE dbo.Ventas ALTER COLUMN ValorDeclarado decimal(12, 2) NOT NULL 
GO

ALTER TABLE dbo.Ventas ALTER COLUMN NumeroLote bigint NOT NULL 
GO
