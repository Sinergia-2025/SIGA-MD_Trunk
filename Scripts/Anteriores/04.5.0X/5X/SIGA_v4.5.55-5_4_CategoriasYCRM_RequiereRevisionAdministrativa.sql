
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
ALTER TABLE dbo.Categorias ADD
	RequiereRevisionAdministrativa bit NULL
GO
update Categorias SET RequiereRevisionAdministrativa = 0;
GO
ALTER TABLE dbo.Categorias ALTER COLUMN
	RequiereRevisionAdministrativa bit NOT NULL
GO
ALTER TABLE dbo.Categorias SET (LOCK_ESCALATION = TABLE)
GO

---crm tipo novedad
ALTER TABLE dbo.CRMTiposNovedades ADD
	VisualizaRevisionAdministrativa bit NULL
GO
update dbo.CRMTiposNovedades SET VisualizaRevisionAdministrativa = 0;
GO
ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN
	VisualizaRevisionAdministrativa bit NOT NULL
GO
ALTER TABLE dbo.CRMTiposNovedades SET (LOCK_ESCALATION = TABLE)
GO

---crm novedad
ALTER TABLE dbo.CRMNovedades ADD
	RevisionAdministrativa bit NULL
GO
update dbo.CRMNovedades SET RevisionAdministrativa = 0;
GO
ALTER TABLE dbo.CRMNovedades ALTER COLUMN
	RevisionAdministrativa bit NOT NULL
GO
ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
