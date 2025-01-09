ALTER TABLE Alquileres ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL;

ALTER TABLE AlquileresTarifasProductos ALTER COLUMN PrecioAlquiler decimal(14,4) NULL;

ALTER TABLE AsientoCuenta ALTER COLUMN Debe decimal(14,4) NULL;
ALTER TABLE AsientoCuenta ALTER COLUMN Haber decimal(14,4) NULL;

ALTER TABLE ProductosComponentes ALTER COLUMN Cantidad decimal(14,4) NOT NULL;

ALTER TABLE ProductosLotes ALTER COLUMN CantidadInicial decimal(14,4) NOT NULL;
ALTER TABLE ProductosLotes ALTER COLUMN CantidadActual decimal(14,4) NOT NULL;

ALTER TABLE ProductosProveedores ALTER COLUMN UltimoPrecioCompra decimal(14,4) NULL;

ALTER TABLE ProductosSucursales ALTER COLUMN PrecioFabrica decimal(14,4) NOT NULL;
ALTER TABLE ProductosSucursales ALTER COLUMN PrecioCosto decimal(14,4) NOT NULL;
ALTER TABLE ProductosSucursales ALTER COLUMN PrecioVenta decimal(14,4) NOT NULL;
ALTER TABLE ProductosSucursales ALTER COLUMN Stock decimal(14,4) NOT NULL;
ALTER TABLE ProductosSucursales ALTER COLUMN StockInicial decimal(14,4) NOT NULL;
ALTER TABLE ProductosSucursales ALTER COLUMN PuntoDePedido decimal(14,4) NOT NULL;
ALTER TABLE ProductosSucursales ALTER COLUMN StockMinimo decimal(14,4) NOT NULL;

ALTER TABLE ProductosSucursalesPrecios ALTER COLUMN PrecioVenta decimal(14,4) NOT NULL;

ALTER TABLE Ventas ALTER COLUMN SubTotal decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN DescuentoRecargo decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteBruto decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImportePesos decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTickets decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTarjetas decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteCheques decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ValorDeclarado decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN TotalImpuestos decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN Utilidad decimal(14,4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ComisionVendedor decimal(14,4) NOT NULL;

ALTER TABLE VentasImpuestos ALTER COLUMN Bruto decimal(14,4) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Neto decimal(14,4) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Importe decimal(14,4) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Total decimal(14,4) NOT NULL;

ALTER TABLE VentasProductos ALTER COLUMN Cantidad decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN Precio decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN Costo decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescRecGeneral decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescuentoRecargo decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioLista decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN Utilidad decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescuentoRecargoProducto decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescRecGeneralProducto decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioNeto decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteTotalNeto decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteImpuesto decimal(14,4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ComisionVendedor decimal(14,4) NOT NULL;

ALTER TABLE VentasProductosLotes ALTER COLUMN Cantidad decimal(14,4) NOT NULL;

ALTER TABLE Compras ALTER COLUMN Neto210 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Neto105 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Neto270 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN NetoNoGravado decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN DescuentoRecargo decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA210 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA105 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA270 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto210 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto105 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto270 decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN BrutoNoGravado decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionIVA decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionIB decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionGanancias decimal(14,4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionVarias decimal(14,4) NOT NULL;

ALTER TABLE ComprasProductos ALTER COLUMN Cantidad decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN Precio decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN DescRecGeneral decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN DescuentoRecargo decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN DescuentoRecargoProducto decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN DescRecGeneralProducto decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN PrecioNeto decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN ImporteTotalNeto decimal(14,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN IVA decimal(14,4) NOT NULL

ALTER TABLE CuentasBancarias ALTER COLUMN Saldo decimal(14,4) NULL
ALTER TABLE CuentasBancarias ALTER COLUMN SaldoConfirmado decimal(14,4) NULL

ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN Saldo decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImportePesos decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteDolares decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteEuros decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteCheques decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTarjetas decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTickets decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTransfBancaria decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteRetenciones decimal(14,4) NOT NULL

ALTER TABLE CuentasCorrientesPagos ALTER COLUMN ImporteCuota decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN SaldoCuota decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN DescuentoRecargo decimal(14,4) NOT NULL

ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN Saldo decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImportePesos decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteDolares decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteEuros decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteCheques decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTransfBancaria decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTickets decimal(14,4) NOT NULL

ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN ImporteCuota decimal(14,4) NOT NULL
ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN SaldoCuota decimal(14,4) NOT NULL

ALTER TABLE MovimientosCompras ALTER COLUMN Neto210 decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN Neto105 decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN Neto270 decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN NetoNoGravado decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN IVA210 decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN IVA105 decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN IVA270 decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN Total decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionIVA decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionIB decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionGanancias decimal(14,4) NOT NULL
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionVarias decimal(14,4) NOT NULL

ALTER TABLE MovimientosComprasProductos ALTER COLUMN Cantidad decimal(14,4) NOT NULL
ALTER TABLE MovimientosComprasProductos ALTER COLUMN Precio decimal(14,4) NOT NULL

ALTER TABLE MovimientosVentas ALTER COLUMN Neto decimal(14,4) NOT NULL
ALTER TABLE MovimientosVentas ALTER COLUMN Total decimal(14,4) NOT NULL
ALTER TABLE MovimientosVentas ALTER COLUMN TotalImpuestos decimal(14,4) NOT NULL

ALTER TABLE MovimientosVentasProductos ALTER COLUMN Cantidad decimal(14,4) NOT NULL
ALTER TABLE MovimientosVentasProductos ALTER COLUMN Precio decimal(14,4) NOT NULL

ALTER TABLE ProduccionProductos ALTER COLUMN CantidadProducida decimal(14,4) NOT NULL

ALTER TABLE ProduccionProductosComponentes ALTER COLUMN Cantidad decimal(14,4) NOT NULL
ALTER TABLE ProduccionProductosComponentes ALTER COLUMN PrecioCosto decimal(14,4) NOT NULL
ALTER TABLE ProduccionProductosComponentes ALTER COLUMN PrecioVenta decimal(14,4) NOT NULL

ALTER TABLE Retenciones ALTER COLUMN BaseImponible decimal(14,4) NOT NULL
ALTER TABLE Retenciones ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL

ALTER TABLE RetencionesCompras ALTER COLUMN BaseImponible decimal(14,4) NOT NULL
ALTER TABLE RetencionesCompras ALTER COLUMN ImporteTotal decimal(14,4) NOT NULL

