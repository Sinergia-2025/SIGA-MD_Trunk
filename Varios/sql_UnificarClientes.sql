
UPDATE Alquileres
   SET TipoDocCliente = 'COD'
      ,NroDocCliente = 'XX'
   WHERE TipoDocCliente = 'COD'
     AND NroDocCliente = 'ZZ'
GO

UPDATE ClientesMarcasListasDePrecios
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE ClientesMarcasListasDePrecios
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE ClientesDescuentosSubRubros
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE ClientesDescuentosMarcas
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE Cheques
   SET TipoDocCliente = 'COD'
      ,NroDocCliente = 'XX'
   WHERE TipoDocCliente = 'COD'
     AND NroDocCliente = 'ZZ'
GO

UPDATE RecepcionNotasF
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE RecepcionNotas
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE Retenciones
   SET TipoDocCliente = 'COD'
      ,NroDocCliente = 'XX'
   WHERE TipoDocCliente = 'COD'
     AND NroDocCliente = 'ZZ'
GO

UPDATE CuentasCorrientes
   SET TipoDocCliente = 'COD'
      ,NroDocCliente = 'XX'
   WHERE TipoDocCliente = 'COD'
     AND NroDocCliente = 'ZZ'
GO

UPDATE MovimientosVentas
   SET TipoDocCliente = 'COD'
      ,NroDocCliente = 'XX'
   WHERE TipoDocCliente = 'COD'
     AND NroDocCliente = 'ZZ'
GO

UPDATE Ventas
   SET TipoDocCliente = 'COD'
      ,NroDocCliente = 'XX'
   WHERE TipoDocCliente = 'COD'
     AND NroDocCliente = 'ZZ'
GO

------------- FICHAS ------------- 

INSERT INTO Fichas
   (NroOperacion, TipoDocumento, NroDocumento, IdSucursal, FechaOperacion, MontoTotalBruto, Anticipo
   ,Cuotas, IdFormasPago, Interes, TotalNeto, Saldo, TipoDocCobrador, NroDocCobrador
   ,IdEstado, NroFactura, Comentario, TipoDocVendedor, NroDocVendedor, Usuario, Revisar)
SELECT NroOperacion, 'COD' AS XXTipoDocumento, 'XX' AS XXNroDocumento, IdSucursal, FechaOperacion, MontoTotalBruto, Anticipo
      ,Cuotas, IdFormasPago, Interes, TotalNeto, Saldo, TipoDocCobrador, NroDocCobrador
      ,IdEstado, NroFactura, Comentario, TipoDocVendedor, NroDocVendedor, Usuario, Revisar
   FROM Fichas
 WHERE TipoDocumento = 'COD'
   AND NroDocumento = 'ZZ'
GO

UPDATE FichasProductos
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE FichasPagos
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE FichasPagosDetalle
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE FichasPagosAjustes
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

DELETE Fichas
 WHERE TipoDocumento = 'COD'
   AND NroDocumento = 'ZZ'
GO

----------------------------------

UPDATE ClientesSucursales
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE CartasAClientes
   SET TipoDocumento = 'COD'
      ,NroDocumento = 'XX'
   WHERE TipoDocumento = 'COD'
     AND NroDocumento = 'ZZ'
GO

UPDATE Clientes
   SET TipoDocumentoGarante = 'COD'
      ,NroDocumentoGarante = 'XX'
   WHERE TipoDocumentoGarante = 'COD'
     AND NroDocumentoGarante = 'ZZ'
GO

DELETE Clientes
 WHERE TipoDocumento = 'COD'
   AND NroDocumento = 'ZZ'
GO
