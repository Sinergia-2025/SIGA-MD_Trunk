
ALTER TABLE Proveedores ADD IdProveedor [bigint] NULL
GO

ALTER TABLE Proveedores ADD IdProveedorTemp [bigint] IDENTITY (1,1)
GO

UPDATE Proveedores SET IdProveedor = IdProveedorTemp
GO

ALTER TABLE Proveedores DROP COLUMN IdProveedorTemp
GO

ALTER TABLE Proveedores ALTER COLUMN IdProveedor [bigint] NOT NULL
GO


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
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_2 UNIQUE NONCLUSTERED 
	(
	IdProveedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

