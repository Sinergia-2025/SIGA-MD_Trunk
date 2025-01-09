
ALTER TABLE ProductosComponentes DROP CONSTRAINT [FK_ProductosComponentes_Productos]
GO

ALTER TABLE [dbo].[ProductosComponentes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosComponentes_ProductosFormulas] FOREIGN KEY([IdProducto],[IdFormula])
REFERENCES [dbo].[ProductosFormulas] ([IdProducto],[IdFormula])
GO

ALTER TABLE [dbo].[ProductosComponentes] CHECK CONSTRAINT [FK_ProductosComponentes_ProductosFormulas]
GO
