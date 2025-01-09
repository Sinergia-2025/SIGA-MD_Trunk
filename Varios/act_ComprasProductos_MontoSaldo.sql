
SELECT C.* FROM Compras C
 INNER JOIN ComprasProductos CP ON CP.IdSucursal = C.IdSucursal
                               AND CP.IdTipoComprobante = C.IdTipoComprobante
                               AND CP.Letra = C.Letra
                               AND CP.CentroEmisor = C.CentroEmisor
                               AND CP.NumeroComprobante = C.NumeroComprobante
                               AND CP.IdProveedor = C.IdProveedor
 WHERE C.Fecha <= '20160630'
   AND CP.MontoSaldo <> 0
GO


UPDATE ComprasProductos
   SET MontoAplicado = CP.ImporteTotal + CP.IVA
      ,MontoSaldo    = 0
  FROM Compras C
 INNER JOIN ComprasProductos CP ON CP.IdSucursal = C.IdSucursal
                               AND CP.IdTipoComprobante = C.IdTipoComprobante
                               AND CP.Letra = C.Letra
                               AND CP.CentroEmisor = C.CentroEmisor
                               AND CP.NumeroComprobante = C.NumeroComprobante
                               AND CP.IdProveedor = C.IdProveedor
 WHERE C.Fecha <= '20160630'
   AND CP.MontoSaldo <> 0
GO
