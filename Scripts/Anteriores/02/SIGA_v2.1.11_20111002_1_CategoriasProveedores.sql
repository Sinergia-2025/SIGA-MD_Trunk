
/******* Creo la tabla *******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CategoriasProveedores](
	[IdCategoria] [int] NOT NULL,
	[NombreCategoria] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CategoriasProveedores] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/******* Inserto aquellas Categorias que se utilizan *******/

INSERT INTO CategoriasProveedores (IdCategoria, NombreCategoria)
SELECT IdCategoria, NombreCategoria FROM Categorias
 WHERE IdCategoria IN (SELECT DISTINCT IdCategoria FROM Proveedores)
GO


/* Ajusto la FK hacia la nueva tabla .*/

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
ALTER TABLE dbo.CategoriasProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Proveedores
	DROP CONSTRAINT FK_Proveedores_Categorias
GO
ALTER TABLE dbo.Categorias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	FK_Proveedores_CategoriasProveedores FOREIGN KEY
	(
	IdCategoria
	) REFERENCES dbo.CategoriasProveedores
	(
	IdCategoria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
