--PRINT ''
--PRINT '1.- Crear TRIGGET TarjetasCuponesActualizaHistorial'
CREATE TRIGGER [dbo].[TarjetasCuponesActualizaHistorial] 
   ON  [dbo].[TarjetasCupones] 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
   INSERT INTO TarjetasCuponesHistorial
		  (IdTarjetaCupon, 
		   IdSucursal, 
		   IdTarjeta, 
		   IdBanco, 
		   Monto, 
		   Cuotas, 
		   NumeroLote, 
		   NumeroCupon, 
		   FechaEmision, 
		   IdEstadoTarjeta, 
		   IdEstadoTarjetaAnt, 
		   IdCajaIngreso, 
		   NroPlanillaIngreso, 
		   NroMovimientoIngreso, 
           IdCajaEgreso, 
		   NroPlanillaEgreso, 
		   NroMovimientoEgreso, 
		   IdUsuarioActualizacion, 
		   FechaActualizacion, 
		   IdCliente, 
		   IdProveedor)
    SELECT IdTarjetaCupon, 
		   IdSucursal, 
		   IdTarjeta, 
		   IdBanco, 
		   Monto, 
		   Cuotas, 
		   NumeroLote, 
		   NumeroCupon, 
		   FechaEmision, 
		   IdEstadoTarjeta, 
		   IdEstadoTarjetaAnt, 
		   IdCajaIngreso, 
		   NroPlanillaIngreso, 
		   NroMovimientoIngreso, 
           IdCajaEgreso, 
		   NroPlanillaEgreso, 
		   NroMovimientoEgreso, 
		   IdUsuarioActualizacion, 
		   FechaActualizacion, 
		   IdCliente, 
		   IdProveedor
  FROM INSERTED
END

GO