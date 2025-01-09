--SELECT IdCliente, NombreCliente, CodigoCliente FROM Clientes
-- WHERE CodigoCliente IN (773, 1151)
--GO


DECLARE @idClienteOriginal bigint
DECLARE @idClienteDestino  bigint

SET @idClienteOriginal = (SELECT IdCliente FROM Clientes WHERE CodigoCliente = 1151);
SET @idClienteDestino  = (SELECT IdCliente FROM Clientes WHERE CodigoCliente = 773);


UPDATE Alquileres
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
 UPDATE AuditoriaClientes
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
 UPDATE AuditoriaClientes
   SET IdClienteGarante = @idClienteDestino
 WHERE IdClienteGarante = @idClienteOriginal;
 
  UPDATE AuditoriaClientes
   SET IdClienteCtaCte = @idClienteDestino
 WHERE IdClienteCtaCte = @idClienteOriginal;
 
 UPDATE CargosClientes
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;

UPDATE CargosClientesObservaciones
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;

UPDATE CartasAClientes
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
 UPDATE CartasAClientes
   SET IdClienteGarante = @idClienteDestino
 WHERE IdClienteGarante = @idClienteOriginal;

UPDATE Cheques
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
 UPDATE ChequesHistorial
   SET idCliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
 UPDATE Clientes
   SET IdClienteGarante = @idClienteDestino
 WHERE IdClienteGarante = @idClienteOriginal;
 
 UPDATE Clientes
   SET IdClienteCtaCte = @idClienteDestino
 WHERE IdClienteCtaCte = @idClienteOriginal;
 
 UPDATE ClientesActividades
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesDescuentosMarcas
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesDescuentosProductos
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesDescuentosRubros
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesDescuentosSubRubros
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesDirecciones
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesMarcasListasDePrecios
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE ClientesSucursales
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE CRMClientesInterlocutores
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE CRMNovedades
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE CuentasCorrientes
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE CuentasCorrientes
   SET IdClienteCtaCte = @idClienteDestino
 WHERE IdClienteCtaCte = @idClienteOriginal;
 
     UPDATE CuentasCorrientesRetenciones
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE Fichas
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE FichasPagos
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE FichasPagosAjustes
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE FichasPagosDetalle
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE FichasProductos
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE LiquidacionesCargos
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE LiquidacionesDetallesClientes
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE LiquidacionesObservaciones
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE MovimientosVentas
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE OrdenesCompraPedidos
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE OrdenesProduccion
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE Pedidos
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE PercepcionVentas
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE RecepcionNotas
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE RecepcionNotasF
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE Retenciones
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE Ventas
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE VentasCajeros
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
     UPDATE VentasColasImpresionComprobantes
   SET Idcliente = @idClienteDestino
 WHERE Idcliente = @idClienteOriginal;
 
 
 DELETE Clientes
 WHERE Idcliente = @idClienteOriginal;

