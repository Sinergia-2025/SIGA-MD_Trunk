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
PRINT '1. DROP de FK de PedidosProveedores'
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosProveedores_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosProveedores]'))
    ALTER TABLE [dbo].[PedidosProveedores] DROP CONSTRAINT [FK_PedidosProveedores_Proveedores]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosProveedores_Sucursales]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosProveedores]'))
    ALTER TABLE [dbo].[PedidosProveedores] DROP CONSTRAINT [FK_PedidosProveedores_Sucursales]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosProveedores_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosProveedores]'))
    ALTER TABLE [dbo].[PedidosProveedores] DROP CONSTRAINT [FK_PedidosProveedores_Usuarios]
GO

PRINT '2. DROP de FK de PedidosProductosProveedores'
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosProductosProveedores_PedidosProveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosProductosProveedores]'))
    ALTER TABLE [dbo].[PedidosProductosProveedores] DROP CONSTRAINT [FK_PedidosProductosProveedores_PedidosProveedores]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosProductosProveedores_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosProductosProveedores]'))
    ALTER TABLE [dbo].[PedidosProductosProveedores] DROP CONSTRAINT [FK_PedidosProductosProveedores_Productos]
GO

PRINT '3. DROP de FK de PedidosEstadosProveedores'
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosEstadosProveedores_Compras]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosEstadosProveedores]'))
    ALTER TABLE [dbo].[PedidosEstadosProveedores] DROP CONSTRAINT [FK_PedidosEstadosProveedores_Compras]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosEstadosProveedores_EstadosPedidosProveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosEstadosProveedores]'))
    ALTER TABLE [dbo].[PedidosEstadosProveedores] DROP CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosEstadosProveedores_PedidosProductosProveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosEstadosProveedores]'))
    ALTER TABLE [dbo].[PedidosEstadosProveedores] DROP CONSTRAINT [FK_PedidosEstadosProveedores_PedidosProductosProveedores]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosEstadosProveedores_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosEstadosProveedores]'))
    ALTER TABLE [dbo].[PedidosEstadosProveedores] DROP CONSTRAINT [FK_PedidosEstadosProveedores_Proveedores]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidosEstadosProveedores_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidosEstadosProveedores]'))
    ALTER TABLE [dbo].[PedidosEstadosProveedores] DROP CONSTRAINT [FK_PedidosEstadosProveedores_Usuarios]
GO

PRINT '4. DROP DE PK de PedidosProveedores'
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosProveedores]') AND name = N'PK_PedidosProveedores')
    ALTER TABLE [dbo].[PedidosProveedores] DROP CONSTRAINT [PK_PedidosProveedores]
GO
PRINT '5. DROP DE PK de PedidosProductosProveedores'
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosProductosProveedores]') AND name = N'PK_PedidosProductosProveedores')
    ALTER TABLE [dbo].[PedidosProductosProveedores] DROP CONSTRAINT [PK_PedidosProductosProveedores]
GO
PRINT '6. DROP DE PK de PedidosEstadosProveedores'
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PedidosEstadosProveedores]') AND name = N'PK_PedidosEstadosProveedores')
    ALTER TABLE [dbo].[PedidosEstadosProveedores] DROP CONSTRAINT [PK_PedidosEstadosProveedores]
GO

PRINT '7. SP_RENAME de PedidosProveedores a _viejo'
EXECUTE sp_rename N'dbo.PedidosProveedores', N'PedidosProveedores_viejo', 'OBJECT' 
GO
PRINT '8. SP_RENAME de PedidosProductosProveedores a _viejo'
EXECUTE sp_rename N'dbo.PedidosProductosProveedores', N'PedidosProductosProveedores_viejo', 'OBJECT' 
GO
PRINT '9. SP_RENAME de PedidosEstadosProveedores a _viejo'
EXECUTE sp_rename N'dbo.PedidosEstadosProveedores', N'PedidosEstadosProveedores_viejo', 'OBJECT' 
GO

ALTER TABLE dbo.PedidosProveedores_viejo SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.PedidosProductosProveedores_viejo SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.PedidosEstadosProveedores_viejo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
