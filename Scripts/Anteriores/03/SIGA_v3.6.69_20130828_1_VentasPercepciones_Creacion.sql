
/****** Object:  Table [dbo].[VentasPercepciones]    Script Date: 08/28/2013 15:43:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasPercepciones](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[EmisorPercepcion] [int] NOT NULL,
	[NumeroPercepcion] [bigint] NOT NULL,
 CONSTRAINT [PK_VentasPercepciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorPercepcion] ASC,
	[NumeroPercepcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.TiposImpuestos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasPercepciones ADD CONSTRAINT
	FK_VentasPercepciones_Ventas FOREIGN KEY
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) REFERENCES dbo.Ventas
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.VentasPercepciones ADD CONSTRAINT
	FK_VentasPercepciones_TiposImpuestos FOREIGN KEY
	(
	IdTipoImpuesto
	) REFERENCES dbo.TiposImpuestos
	(
	IdTipoImpuesto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.VentasPercepciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
