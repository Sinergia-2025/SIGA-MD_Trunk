BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

PRINT ''
PRINT '1. Renombrar las impresiones de SiLIVE'
PRINT '1.1 ------------EL ABUELO-----------------------'
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_DEA.rdlc', '114_Comprobante.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'Pedido_ElAbuelo.rdlc', '114_Pedido.rdlc', ' '

PRINT '1.2 ------------SERCO SA------------------------'
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_SERCO.rdlc', '087_Comprobante.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_SERCO-A.rdlc', '087_Comprobante-A.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_SERCO-B.rdlc', '087_Comprobante-B.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'EntregaMercaderia_SERCO.rdlc', '087_EntregaMercaderia.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'RemitoTransportista_SERCO.rdlc', '087_RemitoTransportista.rdlc', ' '

PRINT '1.3 ------------GARZON--------------------------'
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_Garzon.rdlc', '096_Comprobante.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'eComprobante_MitadHoja_Garzon.rdlc', '096_eComprobante_MitadHoja.rdlc', ' '

PRINT '1.4 ------------VULLZEIT------------------------'
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_Vullzeit.rdlc', '205_Comprobante.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'ConsolidadoCargaOperacion_Vullzeit.rdlc', '205_ConsolidadoCargaOperacion.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'ListadoConsolidadoCargaMercaderia_Vullzeit.rdlc', '205_ListadoConsolidadoCargaMercaderia.rdlc', ' '

PRINT '1.5 ------------JC DISTRIBUIDORA----------------'
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_DJC.rdlc', '173_Comprobante.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_DJC_PI_A.rdlc', '173_Comprobante_PI_A.rdlc', ' '
EXECUTE [dbo].[RenombrarReporte] 'Comprobante_DJC_PI_B.rdlc', '173_Comprobante_PI_B.rdlc', ' '
GO

PRINT ''
PRINT '2. Tabla ContabilidadCuentas: Agregar campo TipoCuenta.'
ALTER TABLE dbo.ContabilidadCuentas ADD TipoCuenta varchar(10) NULL
PRINT ''
PRINT '4. Tabla ContabilidadCuentas: Agregar campo AjustaPorInflacion.'
ALTER TABLE dbo.ContabilidadCuentas ADD AjustaPorInflacion bit NULL
GO
PRINT ''
PRINT '3.1. Tabla ContabilidadCuentas: Valor por defecto para AjustaPorInflacion'
UPDATE ContabilidadCuentas SET AjustaPorInflacion = 0;
PRINT ''
PRINT '3.2. Tabla ContabilidadCuentas: AjustaPorInflacion NOT NULL'
ALTER TABLE dbo.ContabilidadCuentas ALTER COLUMN AjustaPorInflacion bit NOT NULL
GO

ALTER TABLE dbo.ContabilidadCuentas SET (LOCK_ESCALATION = TABLE)
GO
