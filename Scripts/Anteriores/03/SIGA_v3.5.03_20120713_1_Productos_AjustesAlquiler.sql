
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
EXECUTE sp_rename N'dbo.Productos.Modelo', N'Tmp_EquipoMarca_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Productos.Chasis', N'Tmp_EquipoModelo_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Productos.Tmp_EquipoMarca_1', N'EquipoMarca', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Productos.Tmp_EquipoModelo_2', N'EquipoModelo', 'COLUMN' 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------- */


ALTER TABLE dbo.Productos ALTER COLUMN EquipoMarca [varchar](20) NULL
GO

ALTER TABLE dbo.Productos ALTER COLUMN EquipoModelo [varchar](20) NULL
GO

