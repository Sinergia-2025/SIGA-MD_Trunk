
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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD IdSucursalRemito int NULL
ALTER TABLE dbo.PedidosEstados ADD IdTipoComprobanteRemito varchar(15) NULL
ALTER TABLE dbo.PedidosEstados ADD LetraRemito varchar(1) NULL
ALTER TABLE dbo.PedidosEstados ADD CentroEmisorRemito int NULL
ALTER TABLE dbo.PedidosEstados ADD NumeroComprobanteRemito bigint NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_VentasRemito
    FOREIGN KEY (IdTipoComprobanteRemito, LetraRemito, CentroEmisorRemito, NumeroComprobanteRemito, IdSucursalRemito)
    REFERENCES dbo.Ventas (IdTipoComprobante,  Letra, CentroEmisor, NumeroComprobante, IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO

UPDATE PedidosEstados
   SET IdSucursalRemito = CASE WHEN NumeroComprobanteRemito IS NULL THEN NULL ELSE IdSucursal END
      ,IdTipoComprobanteRemito = IdTipoComprobanteFact
      ,LetraRemito = LetraFact
      ,CentroEmisorRemito = CentroEmisorFact
      ,NumeroComprobanteRemito = NumeroComprobanteFact
 WHERE NumeroComprobanteRemito IS NULL AND NumeroComprobanteFact IS NOT NULL;

COMMIT
