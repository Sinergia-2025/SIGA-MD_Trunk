DECLARE @codigoCliente BIGINT = 87
DECLARE @nombreServidor VARCHAR(MAX) = 'LORENUEVA-PC'
DECLARE @baseDatos VARCHAR(MAX) = 'SILIVE'
SELECT *
  FROM ClientesBackups CB
 INNER JOIN Clientes C ON C.IdCliente = CB.IdCliente
 WHERE C.CodigoCliente = @codigoCliente
   AND CB.NombreServidor = @NombreServidor
   AND CB.BaseDatos = @baseDatos

/*
UPDATE CB
   SET Activo = 0
  FROM ClientesBackups CB
 INNER JOIN Clientes C ON C.IdCliente = CB.IdCliente
 WHERE C.CodigoCliente = @codigoCliente
   AND CB.NombreServidor = @NombreServidor
   AND CB.BaseDatos = @baseDatos
*/