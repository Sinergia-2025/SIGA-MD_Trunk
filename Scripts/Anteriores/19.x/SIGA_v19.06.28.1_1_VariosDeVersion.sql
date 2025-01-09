
PRINT ''
PRINT '1. Actualiza IdCobrador en Ventas con IdCobrador de Clientes cuando IdCobrador es NULL'
UPDATE V SET IdCobrador = C.idCobrador
FROM Ventas V
INNER JOIN Clientes C ON C.IdCliente = V.IdCliente
where V.IdCobrador is null
GO

PRINT ''
PRINT '1.1. Actualiza IdCobrador en CuentasCorrientes con IdCobrador de Ventas'
UPDATE CuentasCorrientes
   SET IdCobrador = V.IdCobrador
  FROM Ventas V
 INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal
								AND CC.IdTipoComprobante = V.IdTipoComprobante
								AND CC.Letra = V.Letra
								AND CC.CentroEmisor = V.CentroEmisor
								AND CC.NumeroComprobante = V.NumeroComprobante
 WHERE V.IdCobrador IS NOT NULL
   AND CC.IdCobrador IS NULL
   GO

PRINT ''
PRINT '1.2. Tabla Ventas: IdCobrador NOT NULL '
ALTER TABLE dbo.Ventas ALTER COLUMN IdCobrador int not NULL
GO


