
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediosDePago]') AND type in (N'U'))
	DROP TABLE [dbo].[MediosDePago]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContabilidadMediosDePago]') AND type in (N'U'))
	DROP TABLE [dbo].[ContabilidadMediosDePago]
GO

/* -------------------------------- */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MediosDePago](
	[IdMedioDePago] [int] NOT NULL,
	[NombreMedioDePago] [varchar](30) NOT NULL,
	[IdCuenta] [int] NULL,
 CONSTRAINT [PK_MediosDePago] PRIMARY KEY CLUSTERED 
(
	[IdMedioDePago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* ---------------------- */

INSERT INTO MediosDePago 
     VALUES (1, 'Pesos', NULL),
            (2, 'Dolares', NULL),
            (3, 'Cheques', NULL),
            (4, 'Tarjetas', NULL),
            (5, 'Tickets', NULL)
GO


/* ---------------------- */

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
ALTER TABLE dbo.MediosDePago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MediosDePago ADD CONSTRAINT
	FK_MediosDePago_ContabilidadCuentas FOREIGN KEY
	(
	IdCuenta
	) REFERENCES dbo.ContabilidadCuentas
	(
	IdCuenta
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MediosDePago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
