
SELECT IdSucursal
      ,CC.IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,Fecha
      ,IdUsuario
      ,C.CodigoCliente
      ,C.NombreCliente
      ,ImporteTotal
      ,(CC.ImportePesos + CC.ImporteCheques + CC.ImporteTarjetas + CC.ImporteTickets + CC.ImporteTransfBancaria + CC.ImporteRetenciones) as SUMA
      ,ImportePesos
--      ,ImporteDolares
--      ,ImporteEuros
      ,ImporteCheques
      ,ImporteTarjetas
      ,ImporteTickets
      ,ImporteTransfBancaria
      ,ImporteRetenciones
      ,IdEstadoComprobante
      ,Saldo
  FROM CuentasCorrientes CC
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante AND TC.EsRecibo = 'True'
  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente
  WHERE CC.ImporteTotal*(-1) <> (CC.ImportePesos + CC.ImporteCheques + CC.ImporteTarjetas + CC.ImporteTickets + CC.ImporteTransfBancaria + CC.ImporteRetenciones)
    AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante<>'ANULADO')
  ORDER BY CC.Fecha
  