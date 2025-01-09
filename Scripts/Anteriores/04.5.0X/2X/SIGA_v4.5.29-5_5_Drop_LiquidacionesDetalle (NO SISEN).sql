
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LiquidacionesDetalle_Conceptos]') AND parent_object_id = OBJECT_ID(N'[dbo].[LiquidacionesDetalle]'))
ALTER TABLE [dbo].[LiquidacionesDetalle] DROP CONSTRAINT [FK_LiquidacionesDetalle_Conceptos]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LiquidacionesDetalle_Liquidaciones]') AND parent_object_id = OBJECT_ID(N'[dbo].[LiquidacionesDetalle]'))
ALTER TABLE [dbo].[LiquidacionesDetalle] DROP CONSTRAINT [FK_LiquidacionesDetalle_Liquidaciones]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LiquidacionesDetalle_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[LiquidacionesDetalle]'))
ALTER TABLE [dbo].[LiquidacionesDetalle] DROP CONSTRAINT [FK_LiquidacionesDetalle_Proveedores]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LiquidacionesDetalle_RubrosConceptos]') AND parent_object_id = OBJECT_ID(N'[dbo].[LiquidacionesDetalle]'))
ALTER TABLE [dbo].[LiquidacionesDetalle] DROP CONSTRAINT [FK_LiquidacionesDetalle_RubrosConceptos]
GO

/****** Object:  Table [dbo].[LiquidacionesDetalle]    Script Date: 11/03/2016 14:24:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiquidacionesDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[LiquidacionesDetalle]
GO


