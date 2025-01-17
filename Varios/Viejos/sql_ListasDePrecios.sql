CREATE TABLE [dbo].[ListasDePrecios](
      [IdListaPrecios] [int] NOT NULL,
      [NombreListaPrecios] [varchar](50) NULL,
      [FechaVigencia] [datetime] NULL,
 CONSTRAINT [PK_ListasDePrecios] PRIMARY KEY CLUSTERED 
(
      [IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ProductosSucursalesPrecios](
      [IdProducto] [varchar](20) NOT NULL,
      [IdSucursal] [int] NOT NULL,
      [IdListaPrecios] [int] NOT NULL,
      [PrecioVenta] [decimal](12, 2) NULL,
      [FechaActualizacion] [datetime] NULL,
      [Usuario] [varchar](50) NULL,
 CONSTRAINT [PK_ProductosSucursalesPrecios] PRIMARY KEY CLUSTERED 
(
      [IdProducto] ASC,
      [IdSucursal] ASC,
      [IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios]  WITH CHECK ADD  CONSTRAINT [FK_ProductosSucursalesPrecios_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios] CHECK CONSTRAINT [FK_ProductosSucursalesPrecios_ListasDePrecios]
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios]  WITH CHECK ADD  CONSTRAINT [FK_ProductosSucursalesPrecios_ProductosSucursales] FOREIGN KEY([IdProducto], [IdSucursal])
REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal])
GO
ALTER TABLE [dbo].[ProductosSucursalesPrecios] CHECK CONSTRAINT [FK_ProductosSucursalesPrecios_ProductosSucursales]
GO
