
INSERT INTO CargosClientes
   (IdSucursal, IdCliente, IdCargo, Monto, Cantidad)
SELECT IdSucursal, IdCliente, IdCargo, PrecioAdicional, CantidadAdicional
  FROM LiquidacionesDetallesClientes
 WHERE IdSucursal = 1
   AND PeriodoLiquidacion = 201611
GO
