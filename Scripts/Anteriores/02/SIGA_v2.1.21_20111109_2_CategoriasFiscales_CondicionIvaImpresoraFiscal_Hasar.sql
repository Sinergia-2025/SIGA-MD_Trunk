
/* Renombrar Campo y Campo Nuevo */

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
EXECUTE sp_rename N'dbo.CategoriasFiscales.CondicionIvaImpresoraFiscal', N'Tmp_CondicionIvaImpresoraFiscalEpson', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.CategoriasFiscales.Tmp_CondicionIvaImpresoraFiscalEpson', N'CondicionIvaImpresoraFiscalEpson', 'COLUMN' 
GO
ALTER TABLE dbo.CategoriasFiscales ADD
	CondicionIvaImpresoraFiscalHasar char(1) NULL
GO
ALTER TABLE dbo.CategoriasFiscales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* REGISTROS */

   
UPDATE CategoriasFiscales SET
   CondicionIvaImpresoraFiscalHasar = 
   (CASE NombreCategoriaFiscal WHEN 'Consumidor Final' THEN 'C' 
                               WHEN 'Responsable Inscripto' THEN 'I' 
                               WHEN 'Responsable NO Inscripto' THEN 'N' 
                               WHEN 'Exento' THEN 'E'
                               WHEN 'Exento SIN IVA' THEN 'E' 
                               WHEN 'Monotributista' THEN 'M' 
                               WHEN 'Exportacion' THEN 'Z' 
                               ELSE 'Z' END)
  --WHERE IdPadre IS NULL
GO

ALTER TABLE dbo.CategoriasFiscales ALTER COLUMN CondicionIvaImpresoraFiscalHasar char(1) NOT NULL
GO

/* CORRIJO UN SETEO ERRONEO ORIGINALMENTE (se nota cuando la Empresa es RI) */

UPDATE CategoriasFiscales SET LetraFiscalCompra = 'C'
 WHERE NombreCategoriaFiscal IN ('Exento', 'Exento SIN IVA')
GO



