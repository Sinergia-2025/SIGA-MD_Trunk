
PRINT ''
PRINT '1. Tabla CRMTiposNovedades: Configuracion de Campos ReportaCantidad y ReportaAvance.'
GO
UPDATE CRMTiposNovedades
   SET ReportaCantidad = CASE WHEN UnidadDeMedida = 'HS' THEN 1 ELSE 0 END
     , ReportaAvance = CASE WHEN UnidadDeMedida = 'HS' THEN 0 ELSE 1 END

--SELECT IdTipoNovedad, UnidadDeMedida, ReportaCantidad, ReportaAvance
--  FROM CRMTiposNovedades


PRINT ''
PRINT '2. Tabla CRMNovedades: Agregar Campo Cantidad.'
GO
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
ALTER TABLE dbo.CRMNovedades ADD Cantidad Decimal(8,2) Null
GO
UPDATE CRMNovedades
   SET Cantidad = N.Avance
      ,Avance = 0
  FROM CRMNovedades N
 INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = N.IdTipoNovedad
ALTER TABLE CRMNovedades ALTER COLUMN Cantidad Decimal(8,2) Not Null
GO
UPDATE Traducciones
   SET Texto = 'Fec. Prometida'
 WHERE IdFuncion = 'CRMNovedadesABMPENDIENTE'
   AND Pantalla = 'CRMNovedadesDetalle'
   AND IdIdioma = 'es_AR'
   AND Control = 'lblFechaProximoContacto'
COMMIT
