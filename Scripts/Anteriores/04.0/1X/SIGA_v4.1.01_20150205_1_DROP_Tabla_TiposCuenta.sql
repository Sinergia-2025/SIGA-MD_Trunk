

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.TiposCuenta') )
    DROP TABLE dbo.TiposCuenta
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias') )
    DROP TABLE dbo.t_Referencias
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_2') )
    DROP TABLE dbo.t_Referencias_2
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_3') )
    DROP TABLE dbo.t_Referencias_3
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_4') )
    DROP TABLE dbo.t_Referencias_4
GO
