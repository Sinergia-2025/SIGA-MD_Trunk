
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
ALTER TABLE dbo.PedidosProductos ADD PrecioVentaPorTamano decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD Tamano decimal(7, 3) NULL
ALTER TABLE dbo.PedidosProductos ADD IdUnidadDeMedida char(2) NULL
ALTER TABLE dbo.PedidosProductos ADD IdMoneda int NULL
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_UnidadesDeMedidas
    FOREIGN KEY (IdUnidadDeMedida) REFERENCES
    dbo.UnidadesDeMedidas (IdUnidadDeMedida)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_Monedas
    FOREIGN KEY (IdMoneda)
    REFERENCES dbo.Monedas (IdMoneda)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
