
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
ALTER TABLE dbo.PeriodosFiscales ADD
	TotalRetenciones decimal(10, 2) NULL,
	TotalPercepciones decimal(10, 2) NULL,
	PosicionFinal decimal(10, 2) NULL
GO
ALTER TABLE dbo.PeriodosFiscales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales SET TotalRetenciones = 0
GO

/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales
 SET PeriodosFiscales.TotalPercepciones =   
       ( SELECT SUM(PercepcionIVA) FROM Compras C
           WHERE PeriodosFiscales.PeriodoFiscal = C.PeriodoFiscal
            AND C.PeriodoFiscal IS NOT NULL
         )
GO

/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales SET TotalPercepciones = 0
 WHERE TotalPercepciones IS NULL
GO

/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales SET
    PosicionFinal = Posicion - TotalRetenciones - TotalPercepciones
GO

/* ------------------------------------------------------------------------------ */

ALTER TABLE dbo.PeriodosFiscales ALTER COLUMN TotalRetenciones decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.PeriodosFiscales ALTER COLUMN TotalPercepciones decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.PeriodosFiscales ALTER COLUMN PosicionFinal decimal(10, 2) NOT NULL
GO
