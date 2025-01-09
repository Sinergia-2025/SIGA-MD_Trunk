
CREATE TABLE [dbo].[ProductosFormulas](
	[IdProducto] [varchar](15) NOT NULL,
	[IdFormula] [int] NOT NULL,
	[NombreFormula] [varchar](100) NULL,
 CONSTRAINT [PK_ProductosFromulas] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdFormula] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_ProductosFormulas_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosFormulas] CHECK CONSTRAINT [FK_ProductosFormulas_Productos]
GO

/* ---------- */

INSERT INTO ProductosFormulas SELECT DISTINCT Idproducto, Idformula, 'formula base' from ProductosComponentes

/* ---------- */

ALTER TABLE [dbo].[ProductosFormulas] ALTER COLUMN [NombreFormula] [varchar](100) NOT NULL
GO

