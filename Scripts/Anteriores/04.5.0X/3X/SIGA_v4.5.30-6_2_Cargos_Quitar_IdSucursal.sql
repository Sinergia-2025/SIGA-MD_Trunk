
PRINT '1. Borro FK de LiquidacionesDetallesClientes.IdCargos a Cargos.';

IF EXISTS (SELECT * FROM sys.foreign_keys 
            WHERE object_id = OBJECT_ID(N'[dbo].[FK_LiquidacionesDetallesClientes_Cargos]') 
              AND parent_object_id = OBJECT_ID(N'[dbo].[LiquidacionesDetallesClientes]'))
           
ALTER TABLE [dbo].[LiquidacionesDetallesClientes] 
  DROP CONSTRAINT [FK_LiquidacionesDetallesClientes_Cargos]
GO

PRINT '2. Borro FK de CargosClientes.IdCargos a Cargos.';

IF  EXISTS (SELECT * FROM sys.foreign_keys 
             WHERE object_id = OBJECT_ID(N'[dbo].[FK_CargosClientes_Cargos]') 
               AND parent_object_id = OBJECT_ID(N'[dbo].[CargosClientes]'))
               
ALTER TABLE [dbo].[CargosClientes] DROP CONSTRAINT [FK_CargosClientes_Cargos]
GO

PRINT '3. Borro PK de Cargos.';

IF  EXISTS (SELECT * FROM sys.indexes 
             WHERE object_id = OBJECT_ID(N'[dbo].[Cargos]') 
               AND name = N'PK_Cargos')
               
ALTER TABLE [dbo].[Cargos] DROP CONSTRAINT [PK_Cargos]
GO

PRINT '4. Borro FK Cargos.IdSucursal a Sucursales.';
PRINT '5. Borro Campo IdSucursal.';


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
ALTER TABLE dbo.Cargos DROP CONSTRAINT FK_Cargos_Sucursales
GO
ALTER TABLE dbo.Sucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cargos
	DROP COLUMN IdSucursal
GO
ALTER TABLE dbo.Cargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '6. Creo la PK Cargos.';

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
ALTER TABLE dbo.Cargos ADD CONSTRAINT
	PK_Cargos PRIMARY KEY CLUSTERED 
	(
	IdCargo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Cargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '6. Creo la FK_CargosClientes_Cargos por IdCargo';

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
ALTER TABLE dbo.Cargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CargosClientes ADD CONSTRAINT
	FK_CargosClientes_Cargos FOREIGN KEY
	(
	IdCargo
	) REFERENCES dbo.Cargos
	(
	IdCargo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CargosClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '7. Creo la FK_LiquidacionesDetallesClientes_Cargos por IdCargo';

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
ALTER TABLE dbo.Cargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes ADD CONSTRAINT
	FK_LiquidacionesDetallesClientes_Cargos FOREIGN KEY
	(
	IdCargo
	) REFERENCES dbo.Cargos
	(
	IdCargo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
