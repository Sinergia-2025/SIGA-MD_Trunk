PRINT ''
PRINT '1. Parametros Expensas: Permitir cargar productos sin Conceptos.'
DECLARE @valor VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('20170521014') = 1
    SET @valor = 'True'
MERGE INTO Parametros AS P
        USING (SELECT 'EXPENSASPERMITIRCARGARPRODUCTOSSINCONCEPTOS' AS IdParametro, @valor ValorParametro, 'Expensas: Permitir cargar productos sin Conceptos' DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
--SELECT *
--  FROM Parametros
-- WHERE IdParametro = 'EXPENSASPERMITIRCARGARPRODUCTOSSINCONCEPTOS'


PRINT ''
PRINT '2. Corregir FK recursiva en CRMNovedades.'
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
ALTER TABLE dbo.CRMNovedades
	DROP CONSTRAINT FK_CRMNovedades_CRMNovedades_Padre
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_CRMNovedades_Padre
    FOREIGN KEY (IdTipoNovedadPadre,LetraPadre,CentroEmisorPadre,IdNovedadPadre)
    REFERENCES dbo.CRMNovedades (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '3. Completar datos de FK de Novedad Padre.'
UPDATE N
   SET LetraPadre = P.Letra
     , CentroEmisorPadre = P.CentroEmisor
  FROM CRMNovedades N
  LEFT JOIN CRMNovedades P ON P.IdTipoNovedad = N.IdTipoNovedadPadre AND P.IdNovedad = N.IdNovedadPadre
 WHERE N.IdTipoNovedadPadre IS NOT NULL
   AND N.LetraPadre IS NULL
   AND P.Letra IS NOT NULL
