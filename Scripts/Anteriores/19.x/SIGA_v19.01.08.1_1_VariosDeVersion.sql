PRINT ''
PRINT '1.- CREA TABLA CategoriasDescuentosRubros'
CREATE TABLE [dbo].[CategoriasDescuentosRubros](
	[IdCategoria] [int] NOT NULL,
	[IdRubro] [int] NOT NULL,
	[Descuento] [decimal](5, 2) NULL,
 CONSTRAINT [PK_CategoriasComisionesRubros] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdRubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CategoriasDescuentosRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesRubros_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO

ALTER TABLE [dbo].[CategoriasDescuentosRubros] CHECK CONSTRAINT [FK_CategoriasComisionesRubros_Categorias]
GO

ALTER TABLE [dbo].[CategoriasDescuentosRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesRubros_ComisionesRubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([IdRubro])
GO

ALTER TABLE [dbo].[CategoriasDescuentosRubros] CHECK CONSTRAINT [FK_CategoriasComisionesRubros_ComisionesRubros]
GO

PRINT ''
PRINT '2.- CREA TABLA CategoriasDescuentosSubRubros'
CREATE TABLE [dbo].[CategoriasDescuentosSubRubros](
	[IdCategoria] [int] NOT NULL,
	[IdSubRubro] [int] NOT NULL,
	[IdRubro] [int] NOT NULL,
	[Descuento] [decimal](5, 2) NULL,
 CONSTRAINT [PK_CategoriasComisionesSubRubros] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdSubRubro] ASC,
	[IdRubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CategoriasDescuentosSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubRubros_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubRubros_Categorias]
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubRubros_ComisionesSubRubros] FOREIGN KEY([IdSubRubro])
REFERENCES [dbo].[SubRubros] ([IdSubRubro])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubRubros_ComisionesSubRubros]
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubRubros_Rubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([IdRubro])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubRubros_Rubros]
GO

PRINT ''
PRINT '3.- CREA TABLA CategoriasDescuentosSubSubRubros'
CREATE TABLE [dbo].[CategoriasDescuentosSubSubRubros](
	[IdCategoria] [int] NOT NULL,
	[IdSubSubRubro] [int] NOT NULL,
	[IdSubRubro] [int] NOT NULL,
	[IdRubro] [int] NOT NULL,
	[Descuento] [decimal](5, 2) NULL,
 CONSTRAINT [PK_CategoriasComisionesSubSubRubros] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdSubSubRubro] ASC,
	[IdSubRubro] ASC,
	[IdRubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubSubRubros_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubSubRubros_Categorias]
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubSubRubros_Rubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([IdRubro])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubSubRubros_Rubros]
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubSubRubros_SubRubros] FOREIGN KEY([IdSubRubro])
REFERENCES [dbo].[SubRubros] ([IdSubRubro])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubSubRubros_SubRubros]
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasComisionesSubSubRubros_SubSubRubros] FOREIGN KEY([IdSubSubRubro])
REFERENCES [dbo].[SubSubRubros] ([IdSubSubRubro])
GO

ALTER TABLE [dbo].[CategoriasDescuentosSubSubRubros] CHECK CONSTRAINT [FK_CategoriasComisionesSubSubRubros_SubSubRubros]
GO
