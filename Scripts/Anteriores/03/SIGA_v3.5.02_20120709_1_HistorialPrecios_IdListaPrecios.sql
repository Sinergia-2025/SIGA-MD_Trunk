GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;

GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

--BEGIN TRANSACTION;

ALTER TABLE [dbo].[HistorialPrecios] DROP CONSTRAINT [FK_HistorialPrecios_Productos]
GO

ALTER TABLE [dbo].[HistorialPrecios] DROP CONSTRAINT [FK_HistorialPrecios_Sucursales]
GO

ALTER TABLE [dbo].[HistorialPrecios] DROP CONSTRAINT [FK_HistorialPrecios_Usuarios]
GO

CREATE TABLE [dbo].[tmp_ms_xx_HistorialPrecios](
	[IdProducto] [varchar](15) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdListaPrecios] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[PrecioFabrica] [decimal](14, 4) NOT NULL,
	[PrecioCosto] [decimal](14, 4) NOT NULL,
	[PrecioVenta] [decimal](14, 4) NOT NULL,
	[Usuario] [varchar](10) NOT NULL,
 CONSTRAINT [tmp_ms_xx_PK_HistorialPrecios] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdSucursal] ASC,
	[IdListaPrecios] ASC,
	[FechaHora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[HistorialPrecios])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_HistorialPrecios] ([IdProducto],[IdSucursal],[IdListaPrecios],[FechaHora],[PrecioFabrica],[PrecioCosto],[PrecioVenta],[Usuario])
		SELECT [IdProducto]
			  ,[IdSucursal]
			  ,0 AS ListaDePrecios
			  ,[FechaHora]
			  ,[PrecioFabrica]
			  ,[PrecioCosto]
			  ,[PrecioVenta]
			  ,[Usuario]
		  FROM [dbo].[HistorialPrecios]
    END

SET ANSI_PADDING OFF
GO

DROP TABLE [dbo].[HistorialPrecios];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_HistorialPrecios]', N'HistorialPrecios';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_PK_HistorialPrecios]', N'PK_HistorialPrecios', N'OBJECT';

ALTER TABLE [dbo].[HistorialPrecios]  WITH CHECK ADD  CONSTRAINT [FK_HistorialPrecios_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[HistorialPrecios] CHECK CONSTRAINT [FK_HistorialPrecios_Productos]
GO

ALTER TABLE [dbo].[HistorialPrecios]  WITH CHECK ADD  CONSTRAINT [FK_HistorialPrecios_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[HistorialPrecios] CHECK CONSTRAINT [FK_HistorialPrecios_Sucursales]
GO

ALTER TABLE [dbo].[HistorialPrecios]  WITH CHECK ADD  CONSTRAINT [FK_HistorialPrecios_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[HistorialPrecios] CHECK CONSTRAINT [FK_HistorialPrecios_Usuarios]
GO

--COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

