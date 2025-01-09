--Creación de la tabla ClientesDescuentosSubRubros

CREATE TABLE [dbo].[ClientesDescuentosSubRubros](
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[IdSubRubro] [int] NOT NULL,
	[DescuentoRecargo] [decimal](5, 2) NULL,
 CONSTRAINT [PK_ClientesDescuentosSubRubros1] PRIMARY KEY CLUSTERED 
(
	[TipoDocumento] ASC,
	[NroDocumento] ASC,
	[IdSubRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosSubRubros_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros] CHECK CONSTRAINT [FK_ClientesDescuentosSubRubros_Clientes]
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosSubRubros_SubRubros] FOREIGN KEY([IdSubRubro])
REFERENCES [dbo].[SubRubros] ([IdSubRubro])
GO

ALTER TABLE [dbo].[ClientesDescuentosSubRubros] CHECK CONSTRAINT [FK_ClientesDescuentosSubRubros_SubRubros]
GO


