
/* Crear Tabla [SubRubros2] */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SubRubros2](
	[IdSubRubro] [int] NOT NULL,
	[NombreSubRubro] [varchar](50) NOT NULL,
	[DescuentoRecargo] [decimal](5, 2) NOT NULL,
	[IdRubro] [int] NOT NULL,
 CONSTRAINT [PK_SubRubros2] PRIMARY KEY CLUSTERED 
(
	[IdSubRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

 
/* ------------------------------ */

INSERT INTO dbo.SubRubros2
     (IdSubRubro, NombreSubRubro, DescuentoRecargo, IdRubro)
SELECT DISTINCT P.IdRubro*1000+P.IdSubRubro, SR.NombreSubRubro, Sr.DescuentoRecargo, P.IdRubro
  FROM Productos P , SubRubros SR
  WHERE P.IdSubRubro = SR.IdSubRubro
GO

/* ------------------------------ */
-- Siempre deberia existir este objeto
IF EXISTS (SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE
                            WHERE CONSTRAINT_NAME = 'FK_Productos_SubRubros')
    BEGIN
		ALTER TABLE dbo.Productos DROP CONSTRAINT FK_Productos_SubRubros
    END
GO

/****** Object:  Table [dbo].[ClientesDescuentosSubRubros2]    Script Date: 02/06/2013 23:17:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesDescuentosSubRubros2](
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdSubRubro] [int] NOT NULL,
	[DescuentoRecargo] [decimal](5, 2) NULL,
 CONSTRAINT [PK_ClientesDescuentosSubRubros2] PRIMARY KEY CLUSTERED 
(
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdSubRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros2]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosSubRubros2_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros2] CHECK CONSTRAINT [FK_ClientesDescuentosSubRubros2_Clientes]
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros2]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosSubRubros2_SubRubros2] FOREIGN KEY([IdSubRubro])
REFERENCES [dbo].[SubRubros2] ([IdSubRubro])
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros2] CHECK CONSTRAINT [FK_ClientesDescuentosSubRubros2_SubRubros2]
GO


/* ------------------------------ */

INSERT INTO dbo.ClientesDescuentosSubRubros2
     (TipoDocumento, NroDocumento, IdSubRubro, DescuentoRecargo)
SELECT DISTINCT CSR.TipoDocumento, CSR.NroDocumento, P.IdRubro*1000+P.IdSubRubro, CSR.DescuentoRecargo
  FROM ClientesDescuentosSubRubros CSR, Productos P
 WHERE CSR.IdSubRubro = P.IdSubRubro
GO

/* ------------------------------ */

DROP TABLE dbo.ClientesDescuentosSubRubros
GO

DROP TABLE dbo.SubRubros
GO

EXECUTE sp_rename N'[dbo].[ClientesDescuentosSubRubros2]', N'ClientesDescuentosSubRubros'
GO

EXECUTE sp_rename N'[dbo].[PK_ClientesDescuentosSubRubros2]', N'PK_ClientesDescuentosSubRubros', N'OBJECT'
GO

EXECUTE sp_rename N'[dbo].[FK_ClientesDescuentosSubRubros2_Clientes]', N'FK_ClientesDescuentosSubRubros_Clientes', N'OBJECT'
GO

EXECUTE sp_rename N'[dbo].[FK_ClientesDescuentosSubRubros2_SubRubros2]', N'FK_ClientesDescuentosSubRubros_SubRubros', N'OBJECT'
GO

EXECUTE sp_rename N'[dbo].[SubRubros2]', N'SubRubros'
GO

EXECUTE sp_rename N'[dbo].[PK_SubRubros2]', N'PK_SubRubros', N'OBJECT'
GO

/* ------------------------------ */

UPDATE Productos
   SET IdSubRubro = IdRubro*1000+IdSubRubro
 WHERE IdSubRubro IS NOT NULL
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
ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_SubRubros FOREIGN KEY
	(
	IdSubRubro
	) REFERENCES dbo.SubRubros
	(
	IdSubRubro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------ */

IF EXISTS (SELECT ValorParametro FROM Parametros
             WHERE IdParametro = 'PRODUCTOTIENESUBRUBRO' AND ValorParametro = 'True')
    BEGIN
		ALTER TABLE dbo.Productos ALTER COLUMN IdSubRubro int NOT NULL
    END
GO
