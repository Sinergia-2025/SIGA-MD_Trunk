PRINT ''
PRINT '1.1 Actualización de registros inconsistentes (por las dudas): CodigoProductoTiendaNube.'
UPDATE P SET P.CodigoProductoTiendaNube = NULL FROM Productos P
  WHERE P.CodigoProductoTiendaNube = ''
GO

PRINT ''
PRINT '1.2 Actualización de registros inconsistentes (por las dudas): CodigoProductoTiendaNube.'
UPDATE P SET P.CodigoProductoMercadoLibre = NULL FROM Productos P
  WHERE P.CodigoProductoMercadoLibre = ''
GO

PRINT ''
PRINT '2.0. Cambiar parametros de Tipo de Documento de proveedor y cliente para que no sea COD'
UPDATE Parametros SET ValorParametro = 'DNI'  WHERE IdParametro = 'TIPODOCUMENTOCLIENTE'   AND ValorParametro = 'COD'
UPDATE Parametros SET ValorParametro = 'CUIT' WHERE IdParametro = 'TIPODOCUMENTOPROVEEDOR' AND ValorParametro = 'COD'

PRINT ''
PRINT '2.1. Cambiar Tipo de Documento cliente para que no sea COD'
UPDATE C
   SET TipoDocCliente = P.ValorParametro
  FROM Clientes C
  LEFT JOIN AFIPTiposDocumentos ATD ON ATD.TipoDocumento = C.TipoDocCliente
 CROSS JOIN (SELECT TOP 1 * FROM Parametros WHERE IdParametro = 'TIPODOCUMENTOCLIENTE' ORDER BY IdEmpresa) P
 WHERE C.TipoDocCliente IS NOT NULL
   AND ATD.TipoDocumento IS NULL

PRINT ''
PRINT '2.2. Cambiar Tipo de Documento proveedor para que no sea COD'
UPDATE C
   SET TipoDocProveedor = P.ValorParametro
  FROM Proveedores C
  LEFT JOIN AFIPTiposDocumentos ATD ON ATD.TipoDocumento = C.TipoDocProveedor
 CROSS JOIN (SELECT TOP 1 * FROM Parametros WHERE IdParametro = 'TIPODOCUMENTOPROVEEDOR' ORDER BY IdEmpresa) P
 WHERE C.TipoDocProveedor IS NOT NULL
   AND ATD.TipoDocumento IS NULL
