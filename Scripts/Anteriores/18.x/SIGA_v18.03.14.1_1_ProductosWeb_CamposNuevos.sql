ALTER TABLE ProductosWeb ADD EsParaConstructora bit null
GO
ALTER TABLE ProductosWeb ADD EsParaIndustria bit null
GO
ALTER TABLE ProductosWeb ADD EsParaCooperativaElectrica bit null
GO
ALTER TABLE ProductosWeb ADD EsParaMayorista bit null
GO
ALTER TABLE ProductosWeb ADD EsParaMinorista bit null
GO

Update ProductosWeb SET EsParaConstructora = 'False', EsParaIndustria = 'False', EsParaCooperativaElectrica = 'False',
EsParaMayorista = 'False', EsParaMinorista = 'False' 
GO

ALTER TABLE ProductosWeb ALTER COLUMN EsParaConstructora bit not null
GO
ALTER TABLE ProductosWeb ALTER COLUMN EsParaIndustria bit not null
GO
ALTER TABLE ProductosWeb ALTER COLUMN EsParaCooperativaElectrica bit not null
GO
ALTER TABLE ProductosWeb ALTER COLUMN EsParaMayorista bit not null
GO
ALTER TABLE ProductosWeb ALTER COLUMN EsParaMinorista bit not null
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
ALTER TABLE dbo.ProductosWeb ADD CONSTRAINT
	DF_ProductosWeb_EsParaConstructora DEFAULT 0 FOR EsParaConstructora
GO
ALTER TABLE dbo.ProductosWeb ADD CONSTRAINT
	DF_ProductosWeb_EsParaIndustria DEFAULT 0 FOR EsParaIndustria
GO
ALTER TABLE dbo.ProductosWeb ADD CONSTRAINT
	DF_ProductosWeb_EsParaCooperativaElectrica DEFAULT 0 FOR EsParaCooperativaElectrica
GO
ALTER TABLE dbo.ProductosWeb ADD CONSTRAINT
	DF_ProductosWeb_EsParaMayorista DEFAULT 0 FOR EsParaMayorista
GO
ALTER TABLE dbo.ProductosWeb ADD CONSTRAINT
	DF_ProductosWeb_EsParaMinorista DEFAULT 0 FOR EsParaMinorista
GO
ALTER TABLE dbo.ProductosWeb SET (LOCK_ESCALATION = TABLE)
GO
COMMIT