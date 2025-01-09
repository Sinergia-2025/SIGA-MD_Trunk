SELECT CCP.Fecha, p.NombreProveedor, C.*
  FROM Compras C, CuentasCorrientesProv CCP, Proveedores P
   WHERE C.IdSucursal = CCP.IdSucursal
     AND C.IdTipoComprobante = CCP.IdTipoComprobante
    AND C.Letra = CCP.Letra
    AND C.CentroEmisor = CCP.CentroEmisor
    AND C.NumeroComprobante = CCP.NumeroComprobante
    AND C.TipoDocProveedor = CCP.TipoDocProveedor
    AND C.NroDocProveedor = CCP.NroDocProveedor
    AND C.TipoDocProveedor = P.TipoDocProveedor
    AND C.NroDocProveedor = P.NroDocProveedor
    AND  CONVERT(varchar(11), C.Fecha, 120) <>  CONVERT(varchar(11), CCP.Fecha, 120)
GO
 
/*-----------------------*/
    
--UPDATE CuentasCorrientesProv 
--   SET Fecha = 
--(
--SELECT C.Fecha FROM Compras C
--  WHERE C.IdSucursal = CuentasCorrientesProv.IdSucursal
--    AND C.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
--    AND C.Letra = CuentasCorrientesProv.Letra
--    AND C.CentroEmisor = CuentasCorrientesProv.CentroEmisor
--    AND C.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante
--    AND C.TipoDocProveedor = CuentasCorrientesProv.TipoDocProveedor
--    AND C.NroDocProveedor = CuentasCorrientesProv.NroDocProveedor
--)
--  WHERE EXISTS 
--       (SELECT * FROM Compras C
--         WHERE C.IdSucursal = CuentasCorrientesProv.IdSucursal
--           AND C.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
--           AND C.Letra = CuentasCorrientesProv.Letra
--           AND C.CentroEmisor = CuentasCorrientesProv.CentroEmisor
--           AND C.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante
--           AND C.TipoDocProveedor = CuentasCorrientesProv.TipoDocProveedor
--           AND C.NroDocProveedor = CuentasCorrientesProv.NroDocProveedor)
--GO

--UPDATE CuentasCorrientesProv 
--   SET FechaVencimiento = 
--(
--SELECT C.Fecha+VFP.Dias FROM Compras C, VentasFormasPago VFP
--  WHERE C.IdSucursal = CuentasCorrientesProv.IdSucursal
--    AND C.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
--    AND C.Letra = CuentasCorrientesProv.Letra
--    AND C.CentroEmisor = CuentasCorrientesProv.CentroEmisor
--    AND C.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante
--    AND C.TipoDocProveedor = CuentasCorrientesProv.TipoDocProveedor
--    AND C.NroDocProveedor = CuentasCorrientesProv.NroDocProveedor
--    AND C.IdFormasPago = VFP.IdFormasPago
--)
--  WHERE EXISTS 
--       (SELECT * FROM Compras C
--         WHERE C.IdSucursal = CuentasCorrientesProv.IdSucursal
--           AND C.IdTipoComprobante = CuentasCorrientesProv.IdTipoComprobante
--           AND C.Letra = CuentasCorrientesProv.Letra
--           AND C.CentroEmisor = CuentasCorrientesProv.CentroEmisor
--           AND C.NumeroComprobante = CuentasCorrientesProv.NumeroComprobante
--           AND C.TipoDocProveedor = CuentasCorrientesProv.TipoDocProveedor
--           AND C.NroDocProveedor = CuentasCorrientesProv.NroDocProveedor)
--GO

--/* -------------------------- */

--UPDATE CuentasCorrientesProvPagos
--   SET Fecha = 
--(
--SELECT C.Fecha FROM Compras C
--  WHERE C.IdSucursal = CuentasCorrientesProvPagos.IdSucursal
--    AND C.IdTipoComprobante = CuentasCorrientesProvPagos.IdTipoComprobante
--    AND C.Letra = CuentasCorrientesProvPagos.Letra
--    AND C.CentroEmisor = CuentasCorrientesProvPagos.CentroEmisor
--    AND C.NumeroComprobante = CuentasCorrientesProvPagos.NumeroComprobante
--    AND C.TipoDocProveedor = CuentasCorrientesProvPagos.TipoDocProveedor
--    AND C.NroDocProveedor = CuentasCorrientesProvPagos.NroDocProveedor
--)
--  WHERE EXISTS 
--       (SELECT * FROM Compras C
--         WHERE C.IdSucursal = CuentasCorrientesProvPagos.IdSucursal
--           AND C.IdTipoComprobante = CuentasCorrientesProvPagos.IdTipoComprobante
--           AND C.Letra = CuentasCorrientesProvPagos.Letra
--           AND C.CentroEmisor = CuentasCorrientesProvPagos.CentroEmisor
--           AND C.NumeroComprobante = CuentasCorrientesProvPagos.NumeroComprobante
--           AND C.TipoDocProveedor = CuentasCorrientesProvPagos.TipoDocProveedor
--           AND C.NroDocProveedor = CuentasCorrientesProvPagos.NroDocProveedor)
--GO

--UPDATE CuentasCorrientesProvPagos 
--   SET FechaVencimiento = 
--(
--SELECT C.Fecha+VFP.Dias FROM Compras C, VentasFormasPago VFP
--  WHERE C.IdSucursal = CuentasCorrientesProvPagos.IdSucursal
--    AND C.IdTipoComprobante = CuentasCorrientesProvPagos.IdTipoComprobante
--    AND C.Letra = CuentasCorrientesProvPagos.Letra
--    AND C.CentroEmisor = CuentasCorrientesProvPagos.CentroEmisor
--    AND C.NumeroComprobante = CuentasCorrientesProvPagos.NumeroComprobante
--    AND C.TipoDocProveedor = CuentasCorrientesProvPagos.TipoDocProveedor
--    AND C.NroDocProveedor = CuentasCorrientesProvPagos.NroDocProveedor
--    AND C.IdFormasPago = VFP.IdFormasPago
--)
--  WHERE EXISTS 
--       (SELECT * FROM Compras C
--         WHERE C.IdSucursal = CuentasCorrientesProvPagos.IdSucursal
--           AND C.IdTipoComprobante = CuentasCorrientesProvPagos.IdTipoComprobante
--           AND C.Letra = CuentasCorrientesProvPagos.Letra
--           AND C.CentroEmisor = CuentasCorrientesProvPagos.CentroEmisor
--           AND C.NumeroComprobante = CuentasCorrientesProvPagos.NumeroComprobante
--           AND C.TipoDocProveedor = CuentasCorrientesProvPagos.TipoDocProveedor
--           AND C.NroDocProveedor = CuentasCorrientesProvPagos.NroDocProveedor)
--GO

--UPDATE Compras
--   SET Fecha = 
--(
--SELECT CCP.Fecha FROM CuentasCorrientesProv CCP
--  WHERE CCP.IdSucursal = Compras.IdSucursal
--    AND CCP.IdTipoComprobante = Compras.IdTipoComprobante
--    AND CCP.Letra = Compras.Letra
--    AND CCP.CentroEmisor = Compras.CentroEmisor
--    AND CCP.NumeroComprobante = Compras.NumeroComprobante
--    AND CCP.TipoDocProveedor = Compras.TipoDocProveedor
--    AND CCP.NroDocProveedor = Compras.NroDocProveedor
--)
--  WHERE EXISTS 
--       (SELECT * FROM CuentasCorrientesProv CCP
--         WHERE CCP.IdSucursal = Compras.IdSucursal
--           AND CCP.IdTipoComprobante = Compras.IdTipoComprobante
--           AND CCP.Letra = Compras.Letra
--           AND CCP.CentroEmisor = Compras.CentroEmisor
--           AND CCP.NumeroComprobante = Compras.NumeroComprobante
--           AND CCP.TipoDocProveedor = Compras.TipoDocProveedor
--           AND CCP.NroDocProveedor = Compras.NroDocProveedor)
--GO
