
SELECT * FROM Ventas A
 WHERE IdTipoComprobante IN ('eFACT','eNCRED')
 and IdFormasPago = 1
;

INSERT INTO [CuentasCorrientes]
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteTotal]
           ,[IdFormasPago]
           ,[Observacion]
           ,[Saldo]
           ,[CantidadCuotas]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[ImporteTickets]
           ,[ImporteTransfBancaria]
           ,[IdCuentaBancaria]
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,[ImporteRetenciones]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[IdUsuario]
           ,[IdEstadoComprobante]
           ,[IdCliente]
           ,[FechaActualizacion]
           ,[IdClienteCtaCte]
           ,[IdCategoria]
           ,[SaldoCtaCte]
           ,[IdAsiento]
           ,[IdPlanCuenta]
           ,[MetodoGrabacion]
           ,[IdFuncion])
SELECT [IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[Fecha]
           ,[Fecha]+30 AS xxFechaVencimiento	-- Ver
           ,[ImporteTotal]
           ,3 AS xxIdFormasPago					-- Ver
           ,[Observacion]
           ,ImporteTotal AS xxSaldo
           ,1 AS xxCantidadCuotas
           ,[ImportePesos]
           ,0 AS xxImporteDolares
           ,0 AS xxImporteEuros
           ,0 AS xxImporteCheques
           ,0 AS xxImporteTarjetas
           ,0 AS xxImporteTickets
           ,0 AS xxImporteTransfBancaria
           ,NULL AS xxIdCuentaBancaria
           ,[TipoDocVendedor]
           ,[NroDocVendedor]
           ,0 AS xxImporteRetenciones
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,Usuario AS xxIdUsuario
           ,[IdEstadoComprobante]
           ,[IdCliente]
           ,[FechaActualizacion]
           ,IdCliente AS xxIdClienteCtaCte		-- VER
           ,[IdCategoria]
           ,SaldoActualCtaCte AS xxSaldoCtaCte
           ,[IdAsiento]
           ,[IdPlanCuenta]
           ,[MetodoGrabacion]
           ,[IdFuncion]
 FROM Ventas A
 WHERE IdTipoComprobante IN ('eFACT','eNCRED')
 and IdFormasPago = 1
;

INSERT INTO CuentasCorrientesPagos
           ([IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,[CuotaNumero]
           ,[Fecha]
           ,[FechaVencimiento]
           ,[ImporteCuota]
           ,[SaldoCuota]
           ,[IdFormasPago]
           ,[Observacion]
           ,[IdTipoComprobante2]
           ,[NumeroComprobante2]
           ,[CentroEmisor2]
           ,[CuotaNumero2]
           ,[Letra2]
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc])
SELECT      [IdSucursal]
           ,[IdTipoComprobante]
           ,[Letra]
           ,[CentroEmisor]
           ,[NumeroComprobante]
           ,1 AS xxCuotaNumero
           ,[Fecha]
           ,Fecha+30 AS xxFechaVencimiento
           ,ImporteTotal AS xxImporteCuota
           ,ImporteTotal AS xxSaldoCuota
           ,[IdFormasPago]
           ,[Observacion]
           ,IdTipoComprobante AS xxIdTipoComprobante2
           ,NumeroComprobante AS xxNumeroComprobante2
           ,CentroEmisor AS xxCentroEmisor2
           ,1 AS xxCuotaNumero2
           ,Letra AS xxLetra2
           ,[DescuentoRecargo]
           ,[DescuentoRecargoPorc]
 FROM Ventas A
 WHERE IdTipoComprobante IN ('eFACT','eNCRED')
 and IdFormasPago = 1
;


UPDATE Ventas
   SET IdFormasPago = 3
 WHERE IdTipoComprobante IN ('eFACT','eNCRED')
 and IdFormasPago = 1
;

--- A mano quietar la suma en CAjasDetalle (luego mejorar el SCRIPT!)
SELECT SUM(ImporteTotal) FROM Ventas A
 WHERE IdTipoComprobante IN ('eFACT','eNCRED')
 and IdFormasPago = 3
;
