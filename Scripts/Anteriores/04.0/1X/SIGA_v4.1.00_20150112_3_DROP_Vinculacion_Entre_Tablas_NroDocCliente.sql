
-- Borro las Vinculaciones entre tablas 

PRINT '1. Borro FK: ComprasCheques.FK_ComprasCheques_Compras'
GO
ALTER TABLE dbo.ComprasCheques DROP CONSTRAINT [FK_ComprasCheques_Compras]
GO

PRINT '2. Borro FK: ComprasObservaciones.FK_ComprasObservaciones_Compras'
GO
ALTER TABLE dbo.ComprasObservaciones DROP CONSTRAINT [FK_ComprasObservaciones_Compras]
GO

PRINT '3. Borro FK: ComprasProductos.FK_ComprasProductos_Compras'
GO
ALTER TABLE dbo.ComprasProductos DROP CONSTRAINT [FK_ComprasProductos_Compras]
GO

PRINT '4. Borro FK: CuentasCorrientesProvCheques.FK_CuentasCorrientesProvCheques_CuentasCorrientesProv'
GO
ALTER TABLE dbo.CuentasCorrientesProvCheques DROP CONSTRAINT [FK_CuentasCorrientesProvCheques_CuentasCorrientesProv]
GO

PRINT '5. Borro FK: CuentasCorrientesProvPagos.FK_CuentasCorrientesProvPagos_CuentasCorrientesProvPagos'
GO
ALTER TABLE dbo.CuentasCorrientesProvPagos DROP CONSTRAINT [FK_CuentasCorrientesProvPagos_CuentasCorrientesProvPagos]
GO

PRINT '6. Borro FK: CuentasCorrientesProvRetenciones.FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv'
GO
ALTER TABLE dbo.CuentasCorrientesProvRetenciones DROP CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv]
GO

PRINT '7. Borro FK: CuentasCorrientesProvRetenciones.FK_CuentasCorrientesProvRetenciones_Retenciones'
GO
ALTER TABLE dbo.CuentasCorrientesProvRetenciones DROP CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones]
GO

PRINT '8. Borro FK: PedidosEstadosProveedores.FK_PedidosEstadosProveedores_Compras'
GO
ALTER TABLE dbo.PedidosEstadosProveedores DROP CONSTRAINT [FK_PedidosEstadosProveedores_Compras]
GO

PRINT '9. Borro FK: RecepcionNotasF.FK_RecepcionNotasF_Fichas'
GO
ALTER TABLE dbo.RecepcionNotasF DROP CONSTRAINT [FK_RecepcionNotasF_Fichas]
GO

PRINT '10. Borro FK: FichasProductos.FK_FichasProductos_Fichas'
GO
ALTER TABLE dbo.FichasProductos DROP CONSTRAINT [FK_FichasProductos_Fichas]
GO

PRINT '11. Borro FK: FichasPagosDetalle.FK_FichasPagosDetalle_FichasPagos'
GO
ALTER TABLE dbo.FichasPagosDetalle DROP CONSTRAINT [FK_FichasPagosDetalle_FichasPagos]
GO

PRINT '12. Borro FK: FichasPagos.FK_FichasPagos_Fichas'
GO
ALTER TABLE dbo.FichasPagos DROP CONSTRAINT [FK_FichasPagos_Fichas]
GO

PRINT '13. Borro FK: CuentasCorrientesRetenciones.FK_CuentasCorrientesRetenciones_Retenciones'
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones DROP CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones]
GO

--NO se sabe que busca controlar o si es un error.
PRINT '14. Borro FK: FichasProductos.FK_FichasProductos_FichasProductos'
GO
ALTER TABLE dbo.FichasProductos DROP CONSTRAINT [FK_FichasProductos_FichasProductos]
GO
