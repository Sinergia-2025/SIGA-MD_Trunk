
ALTER TABLE Alquileres ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;

ALTER TABLE AlquileresTarifasProductos ALTER COLUMN PrecioAlquiler decimal(12,2) NULL;

ALTER TABLE ContabilidadAsientosCuentas ALTER COLUMN Debe decimal(12,2) NULL;
ALTER TABLE ContabilidadAsientosCuentas ALTER COLUMN Haber decimal(12,2) NULL;

ALTER TABLE ContabilidadAsientosCuentasTmp ALTER COLUMN Debe decimal(12,2) NULL;
ALTER TABLE ContabilidadAsientosCuentasTmp ALTER COLUMN Haber decimal(12,2) NULL;

ALTER TABLE Ventas ALTER COLUMN SubTotal decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN DescuentoRecargo decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteBruto decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImportePesos decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTickets decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTarjetas decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteCheques decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ValorDeclarado decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN TotalImpuestos decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN Utilidad decimal(12,2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ComisionVendedor decimal(12,2) NOT NULL;

ALTER TABLE VentasImpuestos ALTER COLUMN Bruto decimal(12,2) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Neto decimal(12,2) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Importe decimal(12,2) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Total decimal(12,2) NOT NULL;

ALTER TABLE VentasProductos ALTER COLUMN ImporteImpuesto decimal(12,2) NOT NULL;

ALTER TABLE Compras ALTER COLUMN Neto210 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Neto105 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Neto270 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN NetoNoGravado decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN DescuentoRecargo decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA210 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA105 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA270 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto210 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto105 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto270 decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN BrutoNoGravado decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionIVA decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionIB decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionGanancias decimal(12,2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionVarias decimal(12,2) NOT NULL;

ALTER TABLE ComprasProductos ALTER COLUMN IVA decimal(12,2) NOT NULL;

ALTER TABLE CuentasBancarias ALTER COLUMN Saldo decimal(12,2) NULL;
ALTER TABLE CuentasBancarias ALTER COLUMN SaldoConfirmado decimal(12,2) NULL;

ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN Saldo decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImportePesos decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteDolares decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteEuros decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteCheques decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTarjetas decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTickets decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTransfBancaria decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteRetenciones decimal(12,2) NOT NULL;

ALTER TABLE CuentasCorrientesPagos ALTER COLUMN ImporteCuota decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN SaldoCuota decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN DescuentoRecargo decimal(12,2) NOT NULL;

ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN Saldo decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImportePesos decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteDolares decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteEuros decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteCheques decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTransfBancaria decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTickets decimal(12,2) NOT NULL;

ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN ImporteCuota decimal(12,2) NOT NULL;
ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN SaldoCuota decimal(12,2) NOT NULL;

ALTER TABLE MovimientosCompras ALTER COLUMN Neto210 decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN Neto105 decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN Neto270 decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN NetoNoGravado decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN IVA210 decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN IVA105 decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN IVA270 decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN Total decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionIVA decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionIB decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionGanancias decimal(12,2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionVarias decimal(12,2) NOT NULL;

ALTER TABLE MovimientosComprasProductos ALTER COLUMN Cantidad decimal(12,2) NOT NULL;
ALTER TABLE MovimientosComprasProductos ALTER COLUMN Precio decimal(12,2) NOT NULL;

ALTER TABLE MovimientosVentas ALTER COLUMN Neto decimal(12,2) NOT NULL;
ALTER TABLE MovimientosVentas ALTER COLUMN Total decimal(12,2) NOT NULL;
ALTER TABLE MovimientosVentas ALTER COLUMN TotalImpuestos decimal(12,2) NOT NULL;

ALTER TABLE Retenciones ALTER COLUMN BaseImponible decimal(12,2) NOT NULL;
ALTER TABLE Retenciones ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;

ALTER TABLE RetencionesCompras ALTER COLUMN BaseImponible decimal(12,2) NOT NULL;
ALTER TABLE RetencionesCompras ALTER COLUMN ImporteTotal decimal(12,2) NOT NULL;

