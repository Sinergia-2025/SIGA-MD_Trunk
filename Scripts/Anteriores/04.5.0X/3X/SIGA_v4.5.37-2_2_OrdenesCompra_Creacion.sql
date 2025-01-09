
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompra_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompra]'))
ALTER TABLE [dbo].[OrdenesCompra] DROP CONSTRAINT [FK_OrdenesCompra_Proveedores]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompra_Sucursales]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompra]'))
ALTER TABLE [dbo].[OrdenesCompra] DROP CONSTRAINT [FK_OrdenesCompra_Sucursales]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompra_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompra]'))
ALTER TABLE [dbo].[OrdenesCompra] DROP CONSTRAINT [FK_OrdenesCompra_Usuarios]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesCompra_VentasFormasPago]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesCompra]'))
ALTER TABLE [dbo].[OrdenesCompra] DROP CONSTRAINT [FK_OrdenesCompra_VentasFormasPago]
GO

/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 04/19/2017 09:12:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenesCompra]') AND type in (N'U'))
DROP TABLE [dbo].[OrdenesCompra]
GO

/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 04/19/2017 09:12:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdenesCompra](
	[IdSucursal] [int] NOT NULL,
	[NumeroOrdenCompra] [bigint] NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[IdFormasPago] [int] NOT NULL,
	[FechaPedidos] [datetime] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_OrdenesCompra] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NumeroOrdenCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompra_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO

ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK_OrdenesCompra_Proveedores]
GO

ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompra_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK_OrdenesCompra_Sucursales]
GO

ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompra_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK_OrdenesCompra_Usuarios]
GO

ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompra_VentasFormasPago] FOREIGN KEY([IdFormasPago])
REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago])
GO

ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK_OrdenesCompra_VentasFormasPago]
GO
