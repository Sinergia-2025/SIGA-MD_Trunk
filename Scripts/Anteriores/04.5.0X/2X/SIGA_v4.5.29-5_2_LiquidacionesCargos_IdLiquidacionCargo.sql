
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
EXECUTE sp_rename N'dbo.LiquidacionesCargos.IdCargo', N'Tmp_IdLiquidacionCargo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.LiquidacionesCargos.Tmp_IdLiquidacionCargo', N'IdLiquidacionCargo', 'COLUMN' 
GO
ALTER TABLE dbo.LiquidacionesCargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
