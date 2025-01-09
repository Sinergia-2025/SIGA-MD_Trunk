
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
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD IdSucursalGenerado int NULL
ALTER TABLE dbo.PedidosEstados ADD IdTipoComprobanteGenerado varchar(15) NULL
ALTER TABLE dbo.PedidosEstados ADD LetraGenerado varchar(1) NULL
ALTER TABLE dbo.PedidosEstados ADD CentroEmisorGenerado int NULL
ALTER TABLE dbo.PedidosEstados ADD NumeroPedidoGenerado int NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_PedidosGenerado
    FOREIGN KEY (IdSucursalGenerado, NumeroPedidoGenerado,
                 IdTipoComprobanteGenerado, LetraGenerado, CentroEmisorGenerado)
    REFERENCES dbo.Pedidos (IdSucursal, NumeroPedido,
                            IdTipoComprobante,  Letra, CentroEmisor)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
