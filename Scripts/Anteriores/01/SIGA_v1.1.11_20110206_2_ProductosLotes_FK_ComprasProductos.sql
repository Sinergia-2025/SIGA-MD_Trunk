
ALTER TABLE [dbo].[ProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosLotes_ComprasProductos] FOREIGN KEY([IdSucursal], [IdProducto], [IdLote])
REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto], [IdLote])
GO

ALTER TABLE [dbo].[ProductosLotes] CHECK CONSTRAINT [FK_ProductosLotes_ComprasProductos]
GO
