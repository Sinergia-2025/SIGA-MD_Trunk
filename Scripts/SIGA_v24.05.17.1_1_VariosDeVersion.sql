UPDATE PP
   SET CantPendiente = PE.CantPendiente
     , CantEnProceso = PE.CantEnProceso
     , CantEntregada = PE.CantEntregada
     , CantAnulada   = PE.CantAnulada
  FROM (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden
             , SUM(CASE WHEN  EP.IdTipoEstado = 'PENDIENTE' THEN PE.CantEstado ELSE 0 END) CantPendiente 
             , SUM(CASE WHEN  EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) CantEnProceso
             , SUM(CASE WHEN  EP.IdTipoEstado = 'ENTREGADO' THEN PE.CantEstado ELSE 0 END) CantEntregada 
             , SUM(CASE WHEN (EP.IdTipoEstado = 'ANULADO' AND PE.AnulacionPorModificacion = 0)           
                          OR  EP.IdTipoEstado = 'RECHAZADO' THEN PE.CantEstado ELSE 0 END) CantAnulada   
          FROM PedidosEstados PE
         INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido
         GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden) PE
 INNER JOIN PedidosProductos PP ON PP.IdSucursal = PE.IdSucursal
                               AND PP.IdTipoComprobante = PE.IdTipoComprobante
                               AND PP.Letra = PE.Letra
                               AND PP.CentroEmisor = PE.CentroEmisor
                               AND PP.NumeroPedido = PE.NumeroPedido
                               AND PP.IdProducto = PE.IdProducto
                               AND PP.Orden = PE.Orden
 WHERE (PP.CantPendiente <> PE.CantPendiente OR
        PP.CantEnProceso <> PE.CantEnProceso OR
        PP.CantEntregada <> PE.CantEntregada OR
        PP.CantAnulada   <> PE.CantAnulada)

IF dbo.ExisteCampo('Compras', 'NumeroOrdenCompra') = 0
BEGIN
ALTER TABLE Compras ADD NumeroOrdenCompra	bigint	null
END

IF dbo.ExisteCampo('CuentasCorrientesProv', 'NumeroOrdenCompra') = 0
BEGIN
ALTER TABLE CuentasCorrientesProv ADD NumeroOrdenCompra	bigint	null
END


IF dbo.ExisteCampo('Cheques', 'Observacion') = 0
BEGIN

ALTER TABLE Cheques ADD Observacion varchar(60) null

ALTER TABLE ChequesHistorial ADD Observacion varchar(60) null

END
GO

UPDATE Cheques SET Observacion = '' WHERE Observacion IS null
GO
UPDATE ChequesHistorial SET Observacion = '' WHERE Observacion IS null
GO

ALTER TABLE Cheques ALTER COLUMN Observacion varchar(60) not null
GO
ALTER TABLE ChequesHistorial ALTER COLUMN Observacion varchar(60) not null
GO


DROP TRIGGER [dbo].[ChequesActualizaHistorial] 
GO

/****** Object:  Trigger [dbo].[ChequesActualizaHistorial]    Script Date: 10/5/2024 09:08:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Trigger [dbo].[ChequesActualizaHistorial]    Script Date: 09/03/2021 15:17:16 ******/
CREATE TRIGGER [dbo].[ChequesActualizaHistorial] 
   ON  [dbo].[Cheques] 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
   INSERT INTO ChequesHistorial
			(IdSucursal, NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad
           , FechaEmision, FechaCobro, Titular, Importe, IdCajaIngreso
           , NroPlanillaIngreso, NroMovimientoIngreso, IdCajaEgreso, NroPlanillaEgreso, NroMovimientoEgreso
           , EsPropio, IdCuentaBancaria, IdEstadoCheque, IdEstadoChequeAnt, Cuit
           , IdCliente, IdProveedor, IdProveedorPreasignado, IdUsuarioActualizacion, IdTipoCheque
           , NroOperacion, IdCheque, Observacion)
      SELECT IdSucursal, NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad
           , FechaEmision, FechaCobro, Titular, Importe, IdCajaIngreso
           , NroPlanillaIngreso, NroMovimientoIngreso, IdCajaEgreso, NroPlanillaEgreso, NroMovimientoEgreso
           , EsPropio, IdCuentaBancaria, IdEstadoCheque, IdEstadoChequeAnt, Cuit
           , IdCliente, IdProveedor, IdProveedorPreasignado, IdUsuarioActualizacion, IdTipoCheque
           , NroOperacion, IdCheque, Observacion
        FROM INSERTED
END
GO

ALTER TABLE [dbo].[Cheques] ENABLE TRIGGER [ChequesActualizaHistorial]
GO

INSERT INTO CajasDetalle (
      IdSucursal, IdCaja, NumeroPlanilla, NumeroMovimiento, FechaMovimiento, IdCuentaCaja, IdTipoMovimiento
    , ImporteTarjetas, ImportePesos, ImporteDolares, ImporteEuros, ImporteCheques, ImporteBancos, ImporteRetenciones, ImporteTickets, CotizacionDolar
    , Observacion, EsModificable, IdUsuario, GeneraContabilidad, NumeroDeposito, IdTipoComprobante, IdMonedaImporteBancos, IdConceptoCM05, IdPlanCuenta, IdCentroCosto, IdAsiento, IdEjercicio
) 

SELECT C.IdSucursal, C.IdCaja, C.NumeroPlanilla, MAX(CD.NumeroMovimiento) + 1 NumeroMovimiento, GETDATE() FechaMovimiento, P.ValorParametro IdCuentaCaja, CASE WHEN MAX(C.TarjetasSaldoInicial) + SUM(CD.ImporteTarjetas) > 0 THEN 'E' ELSE 'I' END IdTipoMovimiento
     , (MAX(C.TarjetasSaldoInicial) + SUM(CD.ImporteTarjetas)) * -1 ImporteTarjetas, 0 ImportePesos, 0 ImporteDolares, 0 ImporteEuros, 0 ImporteCheques, 0 ImporteBancos, 0 ImporteRetenciones, 0 ImporteTickets, M.FactorConversion CotizacionDolar
    , '' Observacion, 'False' EsModificable, 'admin' IdUsuario, 'False' GeneraContabilidad, NULL NumeroDeposito, NULL IdTipoComprobante, 1 IdMonedaImporteBancos, NULL IdConceptoCM05, NULL IdPlanCuenta, NULL IdCentroCosto, NULL IdAsiento, NULL IdEjercicio
  FROM Cajas C
 INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal
  LEFT JOIN CajasDetalle CD ON CD.IdSucursal = C.IdSucursal AND CD.IdCaja = C.IdCaja AND CD.NumeroPlanilla = C.NumeroPlanilla
  LEFT JOIN Parametros P ON P.IdEmpresa = S.IdEmpresa AND P.IdParametro = 'CTACAJADEPOSITOTARJETAS'
 CROSS JOIN (SELECT * FROM Monedas WHERE IdMoneda = 2) M
 WHERE C.FechaCierrePlanilla IS NULL
 GROUP BY P.ValorParametro, C.IdSucursal, C.IdCaja, C.NumeroPlanilla, M.FactorConversion
 HAVING MAX(C.TarjetasSaldoInicial) + SUM(CD.ImporteTarjetas) <> 0


/*
UPDATE TarjetasCupones
   SET IdEstadoTarjeta = 'ALTA'
     , IdEstadoTarjetaAnt = 'ALTA'
     , IdUsuarioActualizacion = 'admin'
     , FechaActualizacion = GETDATE()
 WHERE IdEstadoTarjeta = 'ENCARTERA'
 */
