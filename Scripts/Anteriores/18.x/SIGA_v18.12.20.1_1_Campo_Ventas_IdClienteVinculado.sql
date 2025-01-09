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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD IdClienteVinculado bigint NULL
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_Clientes_Vinculado
    FOREIGN KEY (IdCliente)
    REFERENCES dbo.Clientes (IdCliente)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
UPDATE Ventas
   SET IdClienteVinculado = CC.IdClienteCtaCte
  FROM CuentasCorrientes CC
 INNER JOIN Ventas V ON V.IdSucursal = CC.IdSucursal
                    AND V.IdTipoComprobante = CC.IdTipoComprobante
                    AND V.Letra = CC.Letra
                    AND V.CentroEmisor = CC.CentroEmisor
                    AND V.NumeroComprobante = CC.NumeroComprobante
 WHERE ISNULL(CC.IdClienteCtaCte, 0) > 0
   AND V.IdClienteVinculado IS NULL
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
