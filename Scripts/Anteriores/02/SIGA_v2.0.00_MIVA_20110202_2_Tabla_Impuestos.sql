
/* ------ TABLA ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Impuestos](
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Impuestos] PRIMARY KEY CLUSTERED 
(
	[IdTipoImpuesto] ASC,
	[Alicuota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'•Valor porcentual que se debe aplicar sobre la base imponible de acuerdo al impuesto que corresponde, para determinar el monto del tributo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Impuestos', @level2type=N'COLUMN',@level2name=N'Alicuota'
GO

ALTER TABLE [dbo].[Impuestos]  WITH CHECK ADD  CONSTRAINT [FK_Impuestos_TiposImpuestos] FOREIGN KEY([IdTipoImpuesto])
REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
GO

ALTER TABLE [dbo].[Impuestos] CHECK CONSTRAINT [FK_Impuestos_TiposImpuestos]
GO


/* ------ REGISTROS ------ */

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('IIBB', 3, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('IVA', 0, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('IVA', 10.5, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('IVA', 21, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('IVA', 27, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('PGANA', 0, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('PIIBB', 0, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('PIVA', 0, 'True')
GO

INSERT INTO Impuestos (IdTipoImpuesto, Alicuota, Activo)
     VALUES ('PVAR', 0, 'True')
GO

