SELECT V.IdSucursal
      ,V.Fecha
      ,V.IdTipoComprobante
      ,V.Letra
      ,V.CentroEmisor
      ,V.NumeroComprobante
      ,V.SubTotal
      ,V.ImporteTotal
      ,V.TipoDocCliente
      ,V.NroDocCliente
      ,C.NombreCliente
      ,V.TipoDocVendedor
      ,V.NroDocVendedor
      ,E1.NombreEmpleado AS NombreVendedor
      ,C.TipoDocVendedor AS TipoDocVendedorClie
      ,C.NroDocVendedor AS NroDocVendedorClie
      ,E2.NombreEmpleado as NombreVendedorClie
 FROM VentasFormasPago VFP, TiposComprobantes TC, Ventas V
  INNER JOIN Empleados E1 ON V.TipoDocVendedor = E1.TipoDocEmpleado
                         AND V.NroDocVendedor = E1.NroDocEmpleado
  INNER JOIN Clientes C ON V.TipoDocCliente = C.TipoDocumento
                       AND V.NroDocCliente = C.NroDocumento
  INNER JOIN Empleados E2 ON C.TipoDocVendedor = E2.TipoDocEmpleado
                         AND C.NroDocVendedor = E2.NroDocEmpleado
 WHERE V.IdFormasPago=VFP.IdFormasPago
   AND V.IdTipoComprobante=TC.IdTipoComprobante
   AND VFP.Dias=0	--Contado
   AND TC.AfectaCaja='True'
   AND TC.EsComercial='True'	---Excluye la NDEB CHeq Rech.
GO


SELECT CCP.IdSucursal
      ,CCP.Fecha
      ,CCP.IdTipoComprobante
      ,CCP.Letra
      ,CCP.CentroEmisor
      ,CCP.NumeroComprobante
      ,CCP.IdTipoComprobante2
      ,CCP.Letra2
      ,CCP.CentroEmisor2
      ,CCP.NumeroComprobante2
      ,CCP.CuotaNumero2
      ,CCP.ImporteCuota
      ,V.PorcentajeIVA
      ,CF.IvaInscripto+CF.IvaNoInscripto AS PorcentajeIVACF
      ,CC.TipoDocCliente
      ,CC.NroDocCliente
      ,C.NombreCliente
      ,CC.TipoDocVendedor
      ,CC.NroDocVendedor
      ,E1.NombreEmpleado AS NombreVendedor
      ,C.TipoDocVendedor AS TipoDocVendedorClie
      ,C.NroDocVendedor AS NroDocVendedorClie
      ,E2.NombreEmpleado as NombreVendedorClie
   FROM CuentasCorrientesPagos CCP
  LEFT JOIN Ventas V ON CCP.IdSucursal = V.IdSucursal 
                              AND CCP.IdTipoComprobante2 = V.IdTipoComprobante
                              AND CCP.Letra2 = V.Letra
                              AND CCP.CentroEmisor2 = V.CentroEmisor
                              AND CCP.NumeroComprobante2 = V.NumeroComprobante
  INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal
                                 AND CCP.IdTipoComprobante = CC.IdTipoComprobante
                                 AND CCP.Letra = CC.Letra 
                                 AND CCP.CentroEmisor = CC.CentroEmisor
                                 AND CCP.NumeroComprobante = CC.NumeroComprobante
  INNER JOIN Empleados E1 ON CC.TipoDocVendedor = E1.TipoDocEmpleado
                         AND CC.NroDocVendedor = E1.NroDocEmpleado
  INNER JOIN Clientes C ON CC.TipoDocCliente = C.TipoDocumento
                       AND CC.NroDocCliente = C.NroDocumento
  INNER JOIN Empleados E2 ON C.TipoDocVendedor = E2.TipoDocEmpleado
                         AND C.NroDocVendedor = E2.NroDocEmpleado
  INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
  WHERE CCP.IdTipoComprobante='RECIBO'
  ORDER BY CCP.Fecha
GO
