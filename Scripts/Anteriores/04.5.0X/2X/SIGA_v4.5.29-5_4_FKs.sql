
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
COMMIT
BEGIN TRANSACTION
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
ALTER TABLE dbo.Liquidaciones SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Cargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Liquidaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LiquidacionesCargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LiquidacionesCargos ADD CONSTRAINT
    FK_LiquidacionesCargos_Liquidaciones FOREIGN KEY (PeriodoLiquidacion, IdSucursal)
    REFERENCES dbo.Liquidaciones (PeriodoLiquidacion, IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.LiquidacionesCargos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.LiquidacionesDetalle ADD CONSTRAINT
    FK_LiquidacionesDetalle_Liquidaciones FOREIGN KEY (PeriodoLiquidacion, IdSucursal)
    REFERENCES dbo.Liquidaciones (PeriodoLiquidacion, IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.LiquidacionesDetalle SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes ADD CONSTRAINT
    FK_LiquidacionesDetallesClientes_LiquidacionesCargos
    FOREIGN KEY (IdLiquidacionCargo, IdSucursal)
    REFERENCES dbo.LiquidacionesCargos (IdLiquidacionCargo, IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes ADD CONSTRAINT
    FK_LiquidacionesDetallesClientes_Cargos
    FOREIGN KEY (IdCargo, IdSucursal)
    REFERENCES dbo.Cargos (IdCargo, IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
