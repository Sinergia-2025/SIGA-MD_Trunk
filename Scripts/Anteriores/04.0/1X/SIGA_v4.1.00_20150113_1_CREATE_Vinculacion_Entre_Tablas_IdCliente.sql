
-- Creo las Vinculaciones entre tablas 

PRINT '1. Creo FK: CuentasCorrientesRetenciones.FK_CuentasCorrientesRetenciones_Retenciones'
GO

ALTER TABLE [dbo].[CuentasCorrientesRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones] FOREIGN KEY([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [IdCliente])
REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [IdCliente])
GO

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones]
GO

/* ------------------------------ */

PRINT '2. Creo FK: FichasPagos.FK_FichasPagos_Fichas'
GO

ALTER TABLE [dbo].[FichasPagos]  WITH CHECK ADD  CONSTRAINT [FK_FichasPagos_Fichas] FOREIGN KEY([IdSucursal], [IdCliente], [NroOperacion])
REFERENCES [dbo].[Fichas] ([IdSucursal], [IdCliente], [NroOperacion])
GO

ALTER TABLE [dbo].[FichasPagos] CHECK CONSTRAINT [FK_FichasPagos_Fichas]
GO

/* ------------------------------ */

PRINT '3. Creo FK: FichasPagosDetalle.FK_FichasPagosDetalle_FichasPagos'
GO

ALTER TABLE [dbo].[FichasPagosDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FichasPagosDetalle_FichasPagos] FOREIGN KEY([IdSucursal], [IdCliente], [NroOperacion], [NroCuota])
REFERENCES [dbo].[FichasPagos] ([IdSucursal], [IdCliente], [NroOperacion], [NroCuota])
GO

ALTER TABLE [dbo].[FichasPagosDetalle] CHECK CONSTRAINT [FK_FichasPagosDetalle_FichasPagos]
GO

/* ------------------------------ */

PRINT '4. Creo FK: FichasProductos.FK_FichasProductos_Fichas'
GO

ALTER TABLE [dbo].[FichasProductos]  WITH CHECK ADD  CONSTRAINT [FK_FichasProductos_Fichas] FOREIGN KEY([IdSucursal], [IdCliente], [NroOperacion])
REFERENCES [dbo].[Fichas] ([IdSucursal], [IdCliente], [NroOperacion])
GO

ALTER TABLE [dbo].[FichasProductos] CHECK CONSTRAINT [FK_FichasProductos_Fichas]
GO

/* ------------------------------ */

PRINT '5. Creo FK: RecepcionNotasF.FK_RecepcionNotasF_Fichas'
GO

ALTER TABLE [dbo].[RecepcionNotasF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasF_Fichas] FOREIGN KEY([IdSucursal], [IdCliente], [NroOperacion])
REFERENCES [dbo].[Fichas] ([IdSucursal], [IdCliente], [NroOperacion])
GO

ALTER TABLE [dbo].[RecepcionNotasF] CHECK CONSTRAINT [FK_RecepcionNotasF_Fichas]
GO

/* ------------------------------ */
