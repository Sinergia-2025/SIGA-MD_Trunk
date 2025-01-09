
-- Creo las Vinculaciones entre tablas 

PRINT '1. Creo FK: PedidosEstadosProveedores.FK_PedidosEstadosProveedores_Compras'
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosEstadosProveedores_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
GO

ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT [FK_PedidosEstadosProveedores_Compras]
GO


/* ------------------------------ */

PRINT '2. Creo FK: CuentasCorrientesProvRetenciones.FK_CuentasCorrientesProvRetenciones_Retenciones'
GO

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones] FOREIGN KEY([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [IdProveedor])
REFERENCES [dbo].[RetencionesCompras] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [IdProveedor])
GO

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones]
GO

/* ------------------------------ */

PRINT '3. Creo FK: CuentasCorrientesProvRetenciones.FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv'
GO

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv] FOREIGN KEY([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
GO

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv]
GO

/* ------------------------------ */

PRINT '4. Creo FK: CuentasCorrientesProvPagos.FK_CuentasCorrientesProvPagos_CuentasCorrientesProvPagos'
GO

ALTER TABLE [dbo].[CuentasCorrientesProvPagos]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvPagos_CuentasCorrientesProvPagos] FOREIGN KEY([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [CuotaNumero])
REFERENCES [dbo].[CuentasCorrientesProvPagos] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [CuotaNumero])
GO

ALTER TABLE [dbo].[CuentasCorrientesProvPagos] CHECK CONSTRAINT [FK_CuentasCorrientesProvPagos_CuentasCorrientesProvPagos]
GO

/* ------------------------------ */

PRINT '5. Creo FK: CuentasCorrientesProvCheques.FK_CuentasCorrientesProvCheques_CuentasCorrientesProv'
GO

ALTER TABLE [dbo].[CuentasCorrientesProvCheques]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvCheques_CuentasCorrientesProv] FOREIGN KEY([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
GO

ALTER TABLE [dbo].[CuentasCorrientesProvCheques] CHECK CONSTRAINT [FK_CuentasCorrientesProvCheques_CuentasCorrientesProv]
GO

/* ------------------------------ */

PRINT '6. Creo FK: ComprasProductos.FK_ComprasProductos_Compras'
GO

ALTER TABLE [dbo].[ComprasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ComprasProductos_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
GO

ALTER TABLE [dbo].[ComprasProductos] CHECK CONSTRAINT [FK_ComprasProductos_Compras]
GO


/* ------------------------------ */

PRINT '7. Creo FK: ComprasObservaciones.FK_ComprasObservaciones_Compras'
GO

ALTER TABLE [dbo].[ComprasObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_ComprasObservaciones_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
GO

ALTER TABLE [dbo].[ComprasObservaciones] CHECK CONSTRAINT [FK_ComprasObservaciones_Compras]
GO

/* ------------------------------ */

PRINT '8. Creo FK: ComprasCheques.FK_ComprasCheques_Compras'
GO

ALTER TABLE [dbo].[ComprasCheques]  WITH CHECK ADD  CONSTRAINT [FK_ComprasCheques_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
GO

ALTER TABLE [dbo].[ComprasCheques] CHECK CONSTRAINT [FK_ComprasCheques_Compras]
GO


/* ------------------------------ */

PRINT '9. Creo FK: Compras.FK_Compras_Compras'
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
ALTER TABLE dbo.Compras ADD CONSTRAINT
	FK_Compras_Compras FOREIGN KEY
	(
	IdSucursal,
	IdTipoComprobanteFact,
	LetraFact,
	CentroEmisorFact,
	NumeroComprobanteFact,
	IdProveedorFact
	) REFERENCES dbo.Compras
	(
	IdSucursal,
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
