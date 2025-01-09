--IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
--                AND P.ValorParametro IN ('50000000024', '30714107220', '30714757128'))
BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
	 VALUES
	   ('InfCoeficienteCobranzas', 'Inf. Coeficiente de Cobranzas', 'Inf. Coeficiente de Cobranzas', 
	    'True', 'False', 'True', 'True', 'CuentasCorrientes', 58, 'Eniac.Win', 'InfCoeficienteCobranzas', null)
	;

	INSERT INTO RolesFunciones 
	              (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfCoeficienteCobranzas' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;


ALTER TABLE PeriodosFiscales ALTER COLUMN TotalNetoVentas decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalImpuestosVentas decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalVentas decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalNetoCompras decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalImpuestosCompras decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalCompras decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN Posicion decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalRetenciones decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN TotalPercepciones decimal(14, 2) NOT NULL;
ALTER TABLE PeriodosFiscales ALTER COLUMN PosicionFinal decimal(14, 2) NOT NULL;

ALTER TABLE CajasDetalle ALTER COLUMN ImportePesos decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteDolares decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteEuros decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteCheques decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteTarjetas decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteTickets decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteBancos decimal(14, 2) NOT NULL;
ALTER TABLE CajasDetalle ALTER COLUMN ImporteRetenciones decimal(14, 2) NOT NULL;

ALTER TABLE Compras ALTER COLUMN Neto210 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Neto105 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Neto270 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN NetoNoGravado decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN DescuentoRecargo decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA210 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA105 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA270 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImporteTotal decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PorcentajeIVA decimal(14, 2) NULL;
ALTER TABLE Compras ALTER COLUMN Bruto210 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto105 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN Bruto270 decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN BrutoNoGravado decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionIVA decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionIB decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionGanancias decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN PercepcionVarias decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImportePesos decimal(16, 4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImporteTarjetas decimal(16, 4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImporteCheques decimal(16, 4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN ImporteTransfBancaria decimal(16, 4) NOT NULL;
ALTER TABLE Compras ALTER COLUMN CotizacionDolar decimal(10, 3) NOT NULL;
ALTER TABLE Compras ALTER COLUMN DerechoAduanero decimal(14, 2) NULL;
ALTER TABLE Compras ALTER COLUMN ValorDeclarado decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA105Calculado decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA210Calculado decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN IVA270Calculado decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN TotalBruto decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN TotalNeto decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN TotalIVA decimal(14, 2) NOT NULL;
ALTER TABLE Compras ALTER COLUMN TotalPercepciones decimal(14, 2) NOT NULL;

ALTER TABLE ComprasProductos ALTER COLUMN Cantidad decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN Precio decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN DescRecGeneral decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN DescuentoRecargo decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN ImporteTotal decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN DescuentoRecargoProducto decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN DescRecGeneralProducto decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN PrecioNeto decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN ImporteTotalNeto decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN IVA decimal(14, 2) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN MontoAplicado decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN MontoSaldo decimal(16, 4) NOT NULL;
ALTER TABLE ComprasProductos ALTER COLUMN ProporcionalImp decimal(16, 4) NOT NULL;

ALTER TABLE ComprasImpuestos ALTER COLUMN BaseImponible decimal(14, 2) NOT NULL;
ALTER TABLE ComprasImpuestos ALTER COLUMN Importe decimal(14, 2) NOT NULL;
ALTER TABLE ComprasImpuestos ALTER COLUMN Bruto decimal(14, 2) NOT NULL;

ALTER TABLE MovimientosCompras ALTER COLUMN Neto210 decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN Neto105 decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN Neto270 decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN NetoNoGravado decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN IVA210 decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN IVA105 decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN IVA270 decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN Total decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PorcentajeIVA decimal(14, 2) NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionIVA decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionIB decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionGanancias decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosCompras ALTER COLUMN PercepcionVarias decimal(14, 2) NOT NULL;

ALTER TABLE MovimientosComprasProductos ALTER COLUMN Cantidad decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosComprasProductos ALTER COLUMN Precio decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadReservado decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadDefectuoso decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadFuturo decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadFuturoReservado decimal(14, 2) NOT NULL;

ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTotal decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN Saldo decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImportePesos decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteDolares decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteEuros decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteCheques decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTransfBancaria decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTickets decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteRetenciones decimal(16, 4) NOT NULL;
ALTER TABLE CuentasCorrientesProv ALTER COLUMN ImporteTarjetas decimal(14, 2) NOT NULL;

ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN ImporteCuota decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN SaldoCuota decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesProvPagos ALTER COLUMN DescuentoRecargo decimal(14, 2) NOT NULL;

ALTER TABLE Ventas ALTER COLUMN SubTotal decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN DescuentoRecargo decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTotal decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteBruto decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImportePesos decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTickets decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTarjetas decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteCheques decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ValorDeclarado decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN TotalImpuestos decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN Utilidad decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN CotizacionDolar decimal(10, 3) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ComisionVendedor decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN ImporteTransfBancaria decimal(16, 4) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN TotalImpuestoInterno decimal(14, 2) NOT NULL;
ALTER TABLE Ventas ALTER COLUMN SaldoActualCtaCte decimal(14, 2) NULL;

ALTER TABLE VentasProductos ALTER COLUMN Cantidad decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN Precio decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN Costo decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescRecGeneral decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescuentoRecargo decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioLista decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN Utilidad decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteTotal decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescuentoRecargoProducto decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN DescRecGeneralProducto decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioNeto decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteTotalNeto decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteImpuesto decimal(14, 2) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ComisionVendedor decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteImpuestoInterno decimal(14, 2) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioNetoConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteTotalConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN ImporteTotalNetoConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE VentasProductos ALTER COLUMN PrecioVentaPorTamano decimal(16, 4) NULL;

ALTER TABLE VentasImpuestos ALTER COLUMN Bruto decimal(14, 2) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Neto decimal(14, 2) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Importe decimal(14, 2) NOT NULL;
ALTER TABLE VentasImpuestos ALTER COLUMN Total decimal(14, 2) NOT NULL;

ALTER TABLE MovimientosVentas ALTER COLUMN Neto decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosVentas ALTER COLUMN Total decimal(14, 2) NOT NULL;
ALTER TABLE MovimientosVentas ALTER COLUMN TotalImpuestos decimal(14, 2) NOT NULL;

ALTER TABLE MovimientosVentasProductos ALTER COLUMN Cantidad decimal(16, 4) NOT NULL;
ALTER TABLE MovimientosVentasProductos ALTER COLUMN Precio decimal(16, 4) NOT NULL;

ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTotal decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN Saldo decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImportePesos decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteDolares decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteEuros decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteCheques decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTarjetas decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTickets decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteTransfBancaria decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN ImporteRetenciones decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientes ALTER COLUMN SaldoCtaCte decimal(14, 2) NULL;

ALTER TABLE CuentasCorrientesPagos ALTER COLUMN ImporteCuota decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN SaldoCuota decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN DescuentoRecargo decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN ImporteCapital decimal(14, 2) NOT NULL;
ALTER TABLE CuentasCorrientesPagos ALTER COLUMN ImporteInteres decimal(14, 2) NOT NULL;

ALTER TABLE LibrosBancos ALTER COLUMN Importe decimal(14, 2) NOT NULL;

ALTER TABLE Pedidos ALTER COLUMN DescuentoRecargo decimal(16, 4) NOT NULL;
ALTER TABLE Pedidos ALTER COLUMN CotizacionDolar decimal(10, 3) NULL;
ALTER TABLE Pedidos ALTER COLUMN ImporteBruto decimal(14, 2) NOT NULL;
ALTER TABLE Pedidos ALTER COLUMN SubTotal decimal(14, 2) NOT NULL;
ALTER TABLE Pedidos ALTER COLUMN TotalImpuestos decimal(14, 2) NOT NULL;
ALTER TABLE Pedidos ALTER COLUMN TotalImpuestoInterno decimal(16, 2) NOT NULL;
ALTER TABLE Pedidos ALTER COLUMN ImporteTotal decimal(14, 2) NOT NULL;

ALTER TABLE PedidosProductos ALTER COLUMN Precio decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN Costo decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN ImporteTotal decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN CantEntregada decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN CantEnProceso decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN DescuentoRecargoProducto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN ImporteImpuesto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN PrecioLista decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN ImporteImpuestoInterno decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN PrecioNeto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN ImporteTotalNeto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN DescRecGeneral decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN DescRecGeneralProducto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN PrecioConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN PrecioNetoConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN ImporteTotalConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN ImporteTotalNetoConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductos ALTER COLUMN PrecioVentaPorTamano decimal(16, 4) NULL;

ALTER TABLE PedidosProveedores ALTER COLUMN DescuentoRecargo decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProveedores ALTER COLUMN CotizacionDolar decimal(10, 3) NULL;
ALTER TABLE PedidosProveedores ALTER COLUMN ImporteBruto decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProveedores ALTER COLUMN SubTotal decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProveedores ALTER COLUMN TotalImpuestos decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProveedores ALTER COLUMN TotalImpuestoInterno decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProveedores ALTER COLUMN ImporteTotal decimal(14, 2) NOT NULL;

ALTER TABLE PedidosProductosProveedores ALTER COLUMN CostoLista decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN Costo decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN CostoNeto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN DescuentoRecargoProducto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN DescRecGeneral decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN DescRecGeneralProducto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImporteImpuesto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImpuestoInterno decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImporteImpuestoInterno decimal(14, 2) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImporteTotal decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImporteTotalNeto decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN CostoConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN CostoNetoConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImporteTotalConImpuestos decimal(16, 4) NOT NULL;
ALTER TABLE PedidosProductosProveedores ALTER COLUMN ImporteTotalNetoConImpuestos decimal(16, 4) NOT NULL;
