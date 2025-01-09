
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
ALTER TABLE dbo.Regimenes ADD OrigenBaseImponible varchar(10) NULL
GO
ALTER TABLE dbo.Regimenes SET (LOCK_ESCALATION = TABLE)
GO
UPDATE Regimenes SET OrigenBaseImponible = 'NETO'
GO
ALTER TABLE dbo.Regimenes ALTER COLUMN OrigenBaseImponible varchar(10) NOT NULL
GO

UPDATE TiposImpuestos 
   SET NombreTipoImpuesto = REPLACE(REPLACE(REPLACE(NombreTipoImpuesto, 'Retencion', 'Ret.'), 'Percepcion', 'Perc.'),'de Ingresos Brutos' ,'de IIBB')
GO

--SELECT * FROM TiposImpuestos
--GO
