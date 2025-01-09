
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
ALTER TABLE dbo.CRMTiposNovedadesDinamicos ADD Orden int NULL
GO
UPDATE CRMTiposNovedadesDinamicos
   SET Orden = TND2.Orden
  FROM CRMTiposNovedadesDinamicos TND
 INNER JOIN (SELECT IdTipoNovedad
                   ,IdNombreDinamico
                   ,EsRequerido
                   ,ROW_NUMBER() OVER (Partition By IdTipoNovedad Order By IdTipoNovedad, IdNombreDinamico DESC) * 10 As Orden
               FROM CRMTiposNovedadesDinamicos) TND2 ON TND2.IdTipoNovedad = TND.IdTipoNovedad
ALTER TABLE dbo.CRMTiposNovedadesDinamicos ALTER COLUMN Orden int NOT NULL
GO
ALTER TABLE dbo.CRMTiposNovedadesDinamicos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
