
-- Borro las Vinculaciones entre tablas 

PRINT '1. Borro FK: RecepcionNotasF.FK_RecepcionNotasF_Fichas'
GO
ALTER TABLE dbo.RecepcionNotasF DROP CONSTRAINT [FK_RecepcionNotasF_Fichas]
GO

PRINT '2. Borro FK: FichasProductos.FK_FichasProductos_Fichas'
GO
ALTER TABLE dbo.FichasProductos DROP CONSTRAINT [FK_FichasProductos_Fichas]
GO

PRINT '3. Borro FK: FichasPagosDetalle.FK_FichasPagosDetalle_FichasPagos'
GO
ALTER TABLE dbo.FichasPagosDetalle DROP CONSTRAINT [FK_FichasPagosDetalle_FichasPagos]
GO

PRINT '4. Borro FK: FichasPagos.FK_FichasPagos_Fichas'
GO
ALTER TABLE dbo.FichasPagos DROP CONSTRAINT [FK_FichasPagos_Fichas]
GO

PRINT '5. Borro FK: CuentasCorrientesRetenciones.FK_CuentasCorrientesRetenciones_Retenciones'
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones DROP CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones]
GO
