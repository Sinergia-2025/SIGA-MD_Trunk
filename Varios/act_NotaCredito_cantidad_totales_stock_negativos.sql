select *
from Ventas
where IdTipoComprobante = 'eNCRED'
and NumeroComprobante IN (1189,1190)

--UPDATE Ventas
--SET SubTotal = SubTotal * -1,
--	ImporteTotal = ImporteTotal * -1,
--	ImporteBruto = ImporteBruto * -1,
--	TotalImpuestos = TotalImpuestos * -1,
--	Utilidad = Utilidad * -1,
--	Kilos = Kilos * -1
--where NumeroComprobante = 1189


SELECT *
FROM VentasProductos
where IdTipoComprobante = 'eNCRED'
and NumeroComprobante IN (1189,1190, 1191)

--UPDATE VentasProductos
--SET Cantidad = Cantidad * -1,
--	Utilidad = Utilidad * -1,
--	ImporteTotal = ImporteTotal * -1,
--	ImporteTotalNeto = ImporteTotalNeto * -1,
--	Kilos = Kilos * -1,
--	ImporteImpuesto = ImporteImpuesto * -1,
--	ImporteTotalConImpuestos = ImporteTotalConImpuestos * -1,
--	ImporteTotalNetoConImpuestos = ImporteTotalNetoConImpuestos * -1
--where NumeroComprobante = 1189

select *
from VentasImpuestos
where IdTipoComprobante = 'eNCRED'
and NumeroComprobante IN (1189,1190)

--UPDATE VentasImpuestos
--SET Bruto = Bruto * -1,
--	Neto = Neto * -1,
--	Importe = Importe * -1,
--	Total = Total * -1
--where NumeroComprobante = 1189

select *
from CuentasCorrientes
where IdTipoComprobante = 'eNCRED'
and NumeroComprobante IN (1189,1190)

--UPDATE CuentasCorrientes
--set ImporteTotal = ImporteTotal * -1,
--	Saldo = Saldo * -1
--where NumeroComprobante = 1189

select *
from CuentasCorrientesPagos
where IdTipoComprobante = 'eNCRED'
and NumeroComprobante IN (1189,1190)

--UPDATE CuentasCorrientesPagos
--set	ImporteCapital = ImporteCapital * -1,
--	ImporteInteres = ImporteInteres * -1
--where NumeroComprobante = 1189

select *
from MovimientosVentasProductos
where IdProducto = 716

select *
from VentasProductos
where IdTipoComprobante = 'eNCRED'
and NumeroComprobante in ( 1189, 1190)

--UPDATE MovimientosVentasProductos
--set Cantidad = Cantidad * -1
--WHERE IdProducto = 716
--AND IdTipoMovimiento = 'DEVOLUCION'
--AND Orden = 1
--AND NumeroMovimiento = 118
--AND IdSucursal = 1

SELECT *
FROM MovimientosVentas
WHERE IdTipoMovimiento = 'devolucion'
AND IdTipoComprobante = 'eNCRED'
AND Letra = 'B'
AND CentroEmisor = 3
AND NumeroComprobante IN ( 1189, 1190)

--UPDATE MovimientosVentas
--SET Neto = Neto * -1,
--	Total = Total * -1,
--	TotalImpuestos = TotalImpuestos * -1
--WHERE IdTipoMovimiento = 'devolucion'
--AND IdTipoComprobante = 'eNCRED'
--AND Letra = 'B'
--AND CentroEmisor = 3
--AND NumeroComprobante = 1189
