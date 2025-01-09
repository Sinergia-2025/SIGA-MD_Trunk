ALTER TABLE [dbo].[VentasTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_VentasTarjetas_TarjetasCupones] FOREIGN KEY([IdTarjetaCupon])
REFERENCES [dbo].[TarjetasCupones] ([IdTarjetaCupon])
GO