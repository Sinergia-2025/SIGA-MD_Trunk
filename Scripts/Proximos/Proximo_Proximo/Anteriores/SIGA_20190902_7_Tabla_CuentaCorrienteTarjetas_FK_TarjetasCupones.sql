ALTER TABLE [dbo].[CuentasCorrientesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesTarjetas_TarjetasCupones] FOREIGN KEY([IdTarjetaCupon])
REFERENCES [dbo].[TarjetasCupones] ([IdTarjetaCupon])
GO