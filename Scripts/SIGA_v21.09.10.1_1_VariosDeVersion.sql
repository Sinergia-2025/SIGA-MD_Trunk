IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ventas_Ventas]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ventas]'))
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_Ventas]
GO

