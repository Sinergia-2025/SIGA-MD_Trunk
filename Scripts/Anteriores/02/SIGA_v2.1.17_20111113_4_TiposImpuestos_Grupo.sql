
/* ------ TABLA ------ */

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
ALTER TABLE dbo.TiposImpuestos ADD
	Tipo varchar(15) NULL
GO
ALTER TABLE dbo.TiposImpuestos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------ REGISTROS ------ */

UPDATE TiposImpuestos SET
     Tipo = IdTipoImpuesto
  WHERE IdTipoImpuesto IN ('IVA','IIBB')
GO

UPDATE TiposImpuestos SET
     Tipo = 'PERCEPCION',
     NombreTipoImpuesto = 'Percepcion de Ganancias'
  WHERE IdTipoImpuesto = 'PGANA'
GO

UPDATE TiposImpuestos SET
     Tipo = 'PERCEPCION',
     NombreTipoImpuesto = 'Percepcion de Ingresos Brutos'
  WHERE IdTipoImpuesto = 'PIIBB'
GO

UPDATE TiposImpuestos SET
     Tipo = 'PERCEPCION',
     NombreTipoImpuesto = 'Percepcion de IVA'
  WHERE IdTipoImpuesto = 'PIVA'
GO

UPDATE TiposImpuestos SET
     Tipo = 'PERCEPCION'
  WHERE IdTipoImpuesto = 'PVAR'
GO

UPDATE TiposImpuestos SET
     Tipo = 'RETENCION'
  WHERE IdTipoImpuesto IN ('RGANA','RIIBB','RIVA')
GO

ALTER TABLE dbo.TiposImpuestos ALTER COLUMN Tipo varchar(15) NOT NULL
GO
