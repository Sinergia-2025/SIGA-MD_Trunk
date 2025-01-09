
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
ALTER TABLE dbo.ProduccionFormas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProduccionProcesos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD IdProduccionProceso int NULL
ALTER TABLE dbo.Productos ADD IdProduccionForma int NULL
ALTER TABLE dbo.Productos ADD Espmm decimal(10, 3) NULL
ALTER TABLE dbo.Productos ADD EspPies varchar(30) NULL
ALTER TABLE dbo.Productos ADD CodigoSAE int NULL
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT FK_Productos_ProduccionProcesos
    FOREIGN KEY (IdProduccionProceso)
    REFERENCES dbo.ProduccionProcesos (IdProduccionProceso)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT FK_Productos_ProduccionFormas
    FOREIGN KEY (IdProduccionForma)
    REFERENCES dbo.ProduccionFormas (IdProduccionForma)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.AuditoriaProductos ADD IdProduccionProceso int NULL
ALTER TABLE dbo.AuditoriaProductos ADD IdProduccionForma int NULL
ALTER TABLE dbo.AuditoriaProductos ADD Espmm decimal(10, 3) NULL
ALTER TABLE dbo.AuditoriaProductos ADD EspPies varchar(30) NULL
ALTER TABLE dbo.AuditoriaProductos ADD CodigoSAE int NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.ProduccionFormas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProduccionProcesos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosProductos ADD IdProduccionProceso int NULL
ALTER TABLE dbo.PedidosProductos ADD IdProduccionForma int NULL
ALTER TABLE dbo.PedidosProductos ADD Espmm decimal(10, 3) NULL
ALTER TABLE dbo.PedidosProductos ADD EspPies varchar(30) NULL
ALTER TABLE dbo.PedidosProductos ADD CodigoSAE int NULL
ALTER TABLE dbo.PedidosProductos ADD LargoExtAlto decimal(10, 3) NULL
ALTER TABLE dbo.PedidosProductos ADD AnchoIntBase decimal(10, 3) NULL
ALTER TABLE dbo.PedidosProductos ADD UrlPlano varchar(300) NULL
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_ProduccionProcesos
    FOREIGN KEY (IdProduccionProceso)
    REFERENCES dbo.ProduccionProcesos (IdProduccionProceso)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_ProduccionFormas
    FOREIGN KEY (IdProduccionForma)
    REFERENCES dbo.ProduccionFormas (IdProduccionForma)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
