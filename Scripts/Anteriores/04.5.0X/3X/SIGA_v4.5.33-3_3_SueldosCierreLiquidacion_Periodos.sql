
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
ALTER TABLE dbo.SueldosCierreLiquidacion ADD Periodos int NULL
GO
UPDATE SueldosCierreLiquidacion
   SET Periodos = CASE WHEN SC.Tipo = 'U' THEN 1 ELSE 0 END
  FROM SueldosCierreLiquidacion SCL
 INNER JOIN SueldosConceptos SC ON SC.IdTipoConcepto = SCL.IdTipoConcepto AND SC.IdConcepto = SCL.IdConcepto
GO
ALTER TABLE dbo.SueldosCierreLiquidacion ALTER COLUMN Periodos int NOT NULL
GO
ALTER TABLE dbo.SueldosCierreLiquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
