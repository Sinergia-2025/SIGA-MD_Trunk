
PRINT '1. Tabla CuentasCorrientes: agrego campo NumeroOrdenCompra.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientes ADD NumeroOrdenCompra bigint NULL
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla CuentasCorrientes: Actualizo NumeroOrdenCompra con Ventas.NumeroOrdenCompra.'
GO

UPDATE CuentasCorrientes
   SET NumeroOrdenCompra = V.NumeroOrdenCompra
  FROM Ventas V
 INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal
                                AND CC.IdTipoComprobante = V.IdTipoComprobante
                                AND CC.Letra = V.Letra
                                AND CC.CentroEmisor = V.CentroEmisor
                                AND CC.NumeroComprobante = V.NumeroComprobante
 WHERE V.NumeroOrdenCompra IS NOT NULL
   AND CC.NumeroOrdenCompra IS NULL
GO
