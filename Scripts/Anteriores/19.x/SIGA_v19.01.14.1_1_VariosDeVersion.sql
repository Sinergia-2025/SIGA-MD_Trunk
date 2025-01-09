
PRINT '1. Cambiar nombre y agregar en impresoras el Remito Compra Oficial y Remito Compra Transporte'
UPDATE TiposComprobantes
   SET Descripcion = 'Remito Compra Oficial'
 WHERE IdTipoComprobante = 'REMITOCOMOFIC'

UPDATE TiposComprobantes
   SET Descripcion = 'Remito Compra Transporte'
 WHERE IdTipoComprobante = 'REMITOCOMTRANSP'

UPDATE Impresoras
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',REMITOCOMOFIC,REMITOCOMTRANSP'
 WHERE (ComprobantesHabilitados LIKE '%,FACTCOM,%' OR ComprobantesHabilitados LIKE 'FACTCOM,%' OR ComprobantesHabilitados LIKE '%,FACTCOM')


PRINT ''
PRINT '2.- Renombrar Columna Descuento de la tabla CategoriasDescuentosRubros'
EXEC sp_RENAME 'CategoriasDescuentosRubros.Descuento' , 'DescuentoRecargoPorc1', 'COLUMN'
GO

PRINT ''
PRINT '3.- Renombrar Columna Descuento de la tabla CategoriasDescuentosSubRubros'

EXEC sp_RENAME 'CategoriasDescuentosSubRubros.Descuento' , 'DescuentoRecargoPorc1', 'COLUMN'
GO

PRINT ''
PRINT '4.-  Renombrar Columna Descuento de la tablaCategoriasDescuentosSubSubRubros'
EXEC sp_RENAME 'CategoriasDescuentosSubSubRubros.Descuento' , 'DescuentoRecargoPorc1', 'COLUMN'
GO

PRINT ''
PRINT '5.-  Agregar campos de TotalGastosCompra y TotalGastos Caja en Reparto'
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
ALTER TABLE dbo.Repartos ADD TotalGastosCompras decimal(16, 4) NULL
ALTER TABLE dbo.Repartos ADD TotalGastosCaja decimal(16, 4) NULL;
GO
UPDATE Repartos SET TotalGastosCaja = TotalGastos, TotalGastosCompras = 0;

ALTER TABLE dbo.Repartos ALTER COLUMN TotalGastosCompras decimal(16, 4) NOT NULL
ALTER TABLE dbo.Repartos ALTER COLUMN TotalGastosCaja decimal(16, 4) NOT NULL;
ALTER TABLE dbo.Repartos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '6.-  Nueva tabla RepartosGastos'
/****** Object:  Table [dbo].[RepartosGastos]    Script Date: 11/01/2019 10:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RepartosGastos](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[IdGasto] [int] NOT NULL,
	[IdCuentaCaja] [int] NOT NULL,
	[ImportePesos] [decimal](14, 2) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[IdCaja] [int] NOT NULL,
	[NumeroPlanilla] [int] NOT NULL,
	[NumeroMovimiento] [int] NOT NULL,
 CONSTRAINT [PK_RepartosGastos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
	[IdGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RepartosGastos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosGastos_CajasDetalle] FOREIGN KEY([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento])
REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento])
GO
ALTER TABLE [dbo].[RepartosGastos] CHECK CONSTRAINT [FK_RepartosGastos_CajasDetalle]
GO
ALTER TABLE [dbo].[RepartosGastos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosGastos_CuentasDeCajas] FOREIGN KEY([IdCuentaCaja])
REFERENCES [dbo].[CuentasDeCajas] ([IdCuentaCaja])
GO
ALTER TABLE [dbo].[RepartosGastos] CHECK CONSTRAINT [FK_RepartosGastos_CuentasDeCajas]
GO
ALTER TABLE [dbo].[RepartosGastos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosGastos_Repartos] FOREIGN KEY([IdSucursal], [IdReparto])
REFERENCES [dbo].[Repartos] ([IdSucursal], [IdReparto])
GO
ALTER TABLE [dbo].[RepartosGastos] CHECK CONSTRAINT [FK_RepartosGastos_Repartos]
GO

