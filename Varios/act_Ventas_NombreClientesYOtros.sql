--SELECT * FROM Ventas V
-- INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
-- INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
-- WHERE V.IdTipoComprobante like 'ePre%'
--   AND CF.SolicitaCUIT = 'True'
--   AND V.CUIT IS NULL
----   AND CONVERT(varchar(11), V.Fecha, 120) >= '2019-06-30'
--GO

UPDATE Ventas 
   SET Ventas.NombreCliente = C.NombreCliente
      ,Ventas.CUIT = C.CUIT
 FROM Ventas V 
 INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
 INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
 WHERE V.IdTipoComprobante like 'ePre%'
   AND CF.SolicitaCUIT = 'True'
   AND V.CUIT IS NULL
   AND C.CUIT IS NOT NULL
--   AND CONVERT(varchar(11), V.Fecha, 120) >= '2019-06-30'
GO


--SELECT * FROM Ventas V
-- INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
-- INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
-- WHERE V.IdTipoComprobante like 'ePre%'
--   AND CF.SolicitaCUIT = 'False'
--   AND C.EsClienteGenerico = 'False'
--   AND V.NroDocCliente IS NULL
----   AND CONVERT(varchar(11), Fecha, 120) >= '2019-06-30'
--GO

UPDATE Ventas 
   SET Ventas.NombreCliente = C.NombreCliente
      ,Ventas.TipoDocCliente = C.TipoDocCliente
      ,Ventas.NroDocCliente = C.NroDocCliente 
 FROM Ventas V 
 INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
 INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
 WHERE V.IdTipoComprobante like 'ePre%'
   AND CF.SolicitaCUIT = 'False'
   AND C.EsClienteGenerico = 'False'
   AND V.NroDocCliente IS NULL
   AND C.NroDocCliente IS NOT NULL
--   AND CONVERT(varchar(11), Fecha, 120) >= '2019-06-30'
GO
