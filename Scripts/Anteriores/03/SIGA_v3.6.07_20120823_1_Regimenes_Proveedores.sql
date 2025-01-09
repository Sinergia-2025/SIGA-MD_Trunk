
CREATE TABLE [Regimenes](
	[IdRegimen] [int] NOT NULL,
	[ConceptoRegimen] [varchar](200) NOT NULL,
	[ARetenerInscripto] [decimal](14, 2) NULL,
	[ARetenerNoInscripto] [decimal](14, 2) NULL,
	[MontoAExceder] [decimal](14, 2) NULL,
	[ImporteMinimoInscripto] [decimal](14, 2) NULL,
	[ImporteMinimoNoInscripto] [decimal](14, 2) NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Regimenes] PRIMARY KEY CLUSTERED 
(
	[IdRegimen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [Regimenes]  WITH CHECK ADD  CONSTRAINT [FK_Regimenes_TiposImpuestos] FOREIGN KEY([IdTipoImpuesto])
REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
GO

ALTER TABLE [Regimenes] CHECK CONSTRAINT [FK_Regimenes_TiposImpuestos]
GO

/* -------------------------- */

INSERT INTO Regimenes
   (IdRegimen, ConceptoRegimen, ARetenerInscripto, ARetenerNoInscripto
   ,MontoAExceder, ImporteMinimoInscripto, ImporteMinimoNoInscripto, IdTipoImpuesto)
 VALUES
   (1, 'A BORRAR', 0, 0, 0, 0, 0, 'RGANA')
GO

/* -------------------------- */

ALTER TABLE Proveedores ADD EsPasibleRetencion bit NULL
GO

UPDATE Proveedores SET EsPasibleRetencion = 'False'
GO

ALTER TABLE Proveedores ALTER COLUMN EsPasibleRetencion bit NOT NULL
GO


ALTER TABLE Proveedores ADD IdRegimen int NULL
GO

ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Regimenes] FOREIGN KEY([IdRegimen])
REFERENCES [dbo].[Regimenes] ([IdRegimen])
GO

ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Regimenes]
GO

