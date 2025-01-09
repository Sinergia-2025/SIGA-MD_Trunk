/****** Object:  Table [dbo].[AFIPReferenciasTransferencias]    Script Date: 5/4/2021 16:44:22 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

PRINT ''
PRINT '1. Tabla Nueva: AFIPReferenciasTransferencias'
CREATE TABLE [dbo].[AFIPReferenciasTransferencias](
	[IdAFIPReferenciaTransferencia] [varchar](10) NOT NULL,
	[NombreReferenciaTransferencia] [varchar](50) NOT NULL,
	[DescripcionReferenciaTransferencia] [varchar](150) NOT NULL,
 CONSTRAINT [PK_AFIPReferenciasTransferencias] PRIMARY KEY CLUSTERED ([IdAFIPReferenciaTransferencia] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE dbo.AFIPReferenciasTransferencias SET (LOCK_ESCALATION = TABLE)
GO

PRINT ''
PRINT '1.1. Tabla AFIPReferenciasTransferencias: Datos iniciales para tabla'
INSERT INTO [dbo].[AFIPReferenciasTransferencias]
           ([IdAFIPReferenciaTransferencia]
           ,[NombreReferenciaTransferencia]
           ,[DescripcionReferenciaTransferencia])
     VALUES
           ('SCA', 'TRANSFERENCIA AL SISTEMA DE CIRCULACION ABIERTA', ''),
           ('ADC', 'AGENTE DE DEPOSITO COLECTIVO', '')
GO

PRINT ''
PRINT '2. Tabla Ventas: Nueva columna IdAFIPReferenciaTransferencia'
ALTER TABLE dbo.Ventas ADD IdAFIPReferenciaTransferencia varchar(10) NULL
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_AFIPReferenciasTransferencias
    FOREIGN KEY (IdAFIPReferenciaTransferencia)
    REFERENCES dbo.AFIPReferenciasTransferencias (IdAFIPReferenciaTransferencia)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO

PRINT ''
PRINT '3. Tabla TiposComprobantes: Nueva columna AFIPWSRequiereReferenciaTransferencia'
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSRequiereReferenciaTransferencia bit NULL
GO

PRINT ''
PRINT '3.1. Tabla TiposComprobantes: Datos iniciales para AFIPWSRequiereReferenciaTransferencia'
UPDATE TiposComprobantes SET AFIPWSRequiereReferenciaTransferencia = 'False';

PRINT ''
PRINT '3.2. Tabla TiposComprobantes: Datos iniciales para AFIPWSRequiereReferenciaTransferencia (2)'
UPDATE TP SET AFIPWSRequiereReferenciaTransferencia = 'True'
  FROM AFIPTiposComprobantesTiposCbtes Atp
 INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = Atp.IdTipoComprobante
 WHERE Atp.IdAFIPTipoComprobante IN (201, 206, 211)
   AND TP.EsPreElectronico = 'False'

PRINT ''
PRINT '3.3. Tabla TiposComprobantes: NOT NULL para AFIPWSRequiereReferenciaTransferencia'
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AFIPWSRequiereReferenciaTransferencia bit NOT NULL
GO

PRINT ''
PRINT '4. Tabla AFIPTiposComprobantesTiposCbtes: Ajustar seteo para AFIPWSRequiereComprobanteAsociado'
UPDATE TP SET AFIPWSRequiereComprobanteAsociado = 'True'
  FROM AFIPTiposComprobantesTiposCbtes Atp
 INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = Atp.IdTipoComprobante
 WHERE Atp.IdAFIPTipoComprobante IN (2, 3, 7, 8, 12, 13)
   AND TP.EsPreElectronico = 'False'

PRINT ''
PRINT '4.1. Tabla AFIPTiposComprobantesTiposCbtes: Ajustar seteo para AFIPWSRequiereComprobanteAsociado'
UPDATE TP SET AFIPWSRequiereComprobanteAsociado = 'True'
  FROM AFIPTiposComprobantesTiposCbtes Atp
 INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobanteSecundario = Atp.IdTipoComprobante
 WHERE Atp.IdAFIPTipoComprobante IN (2, 3, 7, 8, 12, 13)
   AND TP.EsPreElectronico = 'True'


ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
