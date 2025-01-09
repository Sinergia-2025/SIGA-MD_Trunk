
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
ALTER TABLE dbo.VentasProductos ADD PrecioVentaPorTamano decimal(14, 4) NULL
ALTER TABLE dbo.VentasProductos ADD Tamano decimal(7, 3) NULL
ALTER TABLE dbo.VentasProductos ADD IdUnidadDeMedida char(2) NULL
ALTER TABLE dbo.VentasProductos ADD IdMoneda int NULL
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT FK_VentasProductos_UnidadesDeMedidas
    FOREIGN KEY (IdUnidadDeMedida) REFERENCES
    dbo.UnidadesDeMedidas (IdUnidadDeMedida)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT FK_VentasProductos_Monedas
    FOREIGN KEY (IdMoneda)
    REFERENCES dbo.Monedas (IdMoneda)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
