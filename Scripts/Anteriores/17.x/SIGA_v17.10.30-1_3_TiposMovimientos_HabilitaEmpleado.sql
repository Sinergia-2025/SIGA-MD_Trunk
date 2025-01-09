
PRINT '1. Agrego el campo HabilitaEmpleado a la tabla TiposMovimientos y seteo en Falso.'

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
ALTER TABLE dbo.TiposMovimientos ADD HabilitaEmpleado bit NULL
GO
UPDATE TiposMovimientos SET HabilitaEmpleado = 0;
ALTER TABLE dbo.TiposMovimientos ALTER COLUMN HabilitaEmpleado bit NOT NULL
GO
ALTER TABLE dbo.TiposMovimientos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* -------------- */ 
PRINT ''
PRINT '2. Dato de "Bienes de Uso" en tabla TiposMovimientos.'


INSERT INTO dbo.TiposMovimientos
(IdTipoMovimiento,Descripcion,CoeficienteStock,ComprobantesAsociados,AsociaSucursal,
 MuestraCombo,HabilitaDestinatario,HabilitaRubro,Imprime,CargaPrecio,
 IdContraTipoMovimiento,HabilitaEmpleado)
VALUES
(
  'BIENESUSO', 'Bienes de Uso', -1, NULL, 'False',
  'True', 'False', 'False', 'True', 'NO', 
  NULL, 'True')
  ;

