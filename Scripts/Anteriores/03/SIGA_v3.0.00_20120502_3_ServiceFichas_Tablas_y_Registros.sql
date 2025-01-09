
/****** Object:  Table [dbo].[RecepcionEstadosF]    Script Date: 06/02/2012 12:08:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionEstadosF](
	[IdEstado] [int] NOT NULL,
	[NombreEstado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReparacionEstadosF] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


-- CREO LOS ESTADOS ESPACIADOS PARA FUTURAS SITUACIONES.

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (0, 'TODOS')
GO

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (10, 'Devuelto')
GO

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (20, 'Service')
GO

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (25, 'Trabajando')
GO

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (30, 'Reparado')
GO

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (40, 'No reparado')
GO

INSERT INTO RecepcionEstadosF (IdEstado, NombreEstado) VALUES (50, 'Entregado')
GO

-------------------------------------------------------------------------------------------------------

/****** Object:  Table [dbo].[RecepcionNotasF]    Script Date: 06/02/2012 12:50:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionNotasF](
	[IdSucursal] [int] NOT NULL,
	[NroNota] [int] NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[NroOperacion] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[FechaNota] [datetime] NULL,
	[CantidadProductos] [decimal](12, 2) NULL,
	[CostoReparacion] [decimal](12, 2) NULL,
	[DefectoProducto] [varchar](250) NULL,
	[Observacion] [varchar](250) NULL,
	[IdProductoPrestado] [varchar](15) NULL,
	[CantidadPrestada] [decimal](12, 2) NULL,
	[ObservacionPrestamo] [varchar](150) NULL,
	[EstaPrestado] [bit] NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecepcionNotasF] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroNota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecepcionNotasF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasF_Clientes] FOREIGN KEY([TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[RecepcionNotasF] CHECK CONSTRAINT [FK_RecepcionNotasF_Clientes]
GO

ALTER TABLE [dbo].[RecepcionNotasF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasF_Fichas] FOREIGN KEY([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento])
REFERENCES [dbo].[Fichas] ([IdSucursal], [NroOperacion], [TipoDocumento], [NroDocumento])
GO

ALTER TABLE [dbo].[RecepcionNotasF] CHECK CONSTRAINT [FK_RecepcionNotasF_Fichas]
GO

ALTER TABLE [dbo].[RecepcionNotasF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasF_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[RecepcionNotasF] CHECK CONSTRAINT [FK_RecepcionNotasF_Productos]
GO

ALTER TABLE [dbo].[RecepcionNotasF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasF_RecepcionNotasF] FOREIGN KEY([IdProductoPrestado])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[RecepcionNotasF] CHECK CONSTRAINT [FK_RecepcionNotasF_RecepcionNotasF]
GO

ALTER TABLE [dbo].[RecepcionNotasF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasF_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[RecepcionNotasF] CHECK CONSTRAINT [FK_RecepcionNotasF_Sucursales]
GO


-- INSERTO LAS NOTAS DE LA TABLA ANTERIOR.

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[RecepcionNotas])
    BEGIN
		INSERT INTO [dbo].[RecepcionNotasF]
				   ([NroOperacion]
				   ,[TipoDocumento]
				   ,[NroDocumento]
				   ,[IdSucursal]
				   ,[IdProducto]
				   ,[NroNota]
				   ,[FechaNota]
				   ,[CantidadProductos]
				   ,[CostoReparacion]
				   ,[DefectoProducto]
				   ,[Observacion]
				   ,[IdProductoPrestado]
				   ,[CantidadPrestada]
				   ,[ObservacionPrestamo]
				   ,[EstaPrestado]
				   ,[Usuario])
		SELECT [NroOperacion]
			  ,[TipoDocumento]
			  ,[NroDocumento]
			  ,[IdSucursal]
			  ,[IdProducto]
			  ,[NroNota]
			  ,[FechaNota]
			  ,[CantidadProductos]
			  ,[CostoReparacion]
			  ,[DefectoProducto]
			  ,[Observacion]
			  ,[IdProductoPrestado]
			  ,[CantidadPrestada]
			  ,[ObservacionPrestamo]
			  ,[EstaPrestado]
			  ,[Usuario]
		  FROM [dbo].[RecepcionNotas]
    END
    

/****** Object:  Table [dbo].[RecepcionNotasEstadosF]    Script Date: 06/02/2012 12:51:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionNotasEstadosF](
	[IdSucursal] [int] NOT NULL,
	[NroNota] [int] NOT NULL,
	[FechaEstado] [datetime] NOT NULL,
	[IdEstado] [int] NULL,
	[Observacion] [varchar](150) NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecepcionNotasFEstado] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroNota] ASC,
	[FechaEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecepcionNotasEstadosF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasEstadosF_RecepcionEstadosF] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[RecepcionEstadosF] ([IdEstado])
GO

ALTER TABLE [dbo].[RecepcionNotasEstadosF] CHECK CONSTRAINT [FK_RecepcionNotasEstadosF_RecepcionEstadosF]
GO

ALTER TABLE [dbo].[RecepcionNotasEstadosF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasEstadosF_RecepcionNotasF] FOREIGN KEY([IdSucursal], [NroNota])
REFERENCES [dbo].[RecepcionNotasF] ([IdSucursal], [NroNota])
GO

ALTER TABLE [dbo].[RecepcionNotasEstadosF] CHECK CONSTRAINT [FK_RecepcionNotasEstadosF_RecepcionNotasF]
GO

-- INSERTO LOS ESTADOS DE LAS NOTAS DE LA TABLA ANTERIOR.

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[RecepcionNotasEstados])
    BEGIN
		INSERT INTO [dbo].[RecepcionNotasEstadosF]
				   ([IdSucursal]
				   ,[NroNota]
				   ,[FechaEstado]
				   ,[IdEstado]
				   ,[Observacion]
				   ,[Usuario])
		SELECT 1 AS IdSucursal
			  ,[NroNota]
			  ,[FechaEstado]
			  ,[IdEstado]
			  ,[Observacion]
			  ,[Usuario]
		  FROM [dbo].[RecepcionNotasEstados]
    END

/****** Object:  Table [dbo].[RecepcionNotasProveedoresF]    Script Date: 06/02/2012 12:11:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecepcionNotasProveedoresF](
	[IdSucursal] [int] NOT NULL,
	[NroNota] [int] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[Observacion] [varchar](150) NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecepcionNotasProveedoresF] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[NroNota] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecepcionNotasProveedoresF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasProveedoresF_Proveedores] FOREIGN KEY([TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[RecepcionNotasProveedoresF] CHECK CONSTRAINT [FK_RecepcionNotasProveedoresF_Proveedores]
GO

ALTER TABLE [dbo].[RecepcionNotasProveedoresF]  WITH CHECK ADD  CONSTRAINT [FK_RecepcionNotasProveedoresF_RecepcionNotasF] FOREIGN KEY([IdSucursal], [NroNota])
REFERENCES [dbo].[RecepcionNotasF] ([IdSucursal], [NroNota])
GO

ALTER TABLE [dbo].[RecepcionNotasProveedoresF] CHECK CONSTRAINT [FK_RecepcionNotasProveedoresF_RecepcionNotasF]
GO


-- INSERTO LOS ENVIO A PROVEEDORES DE LAS NOTAS DE LA TABLA ANTERIOR.

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[RecepcionNotasProveedores])
    BEGIN
		INSERT INTO [dbo].[RecepcionNotasProveedoresF]
				   ([IdSucursal]
				   ,[NroNota]
				   ,[TipoDocProveedor]
				   ,[NroDocProveedor]
				   ,[FechaEntrega]
				   ,[Observacion]
				   ,[Usuario])
		SELECT 1 AS IdSucursal
			  ,[NroNota]
			  ,[TipoDocProveedor]
			  ,[NroDocProveedor]
			  ,[FechaEntrega]
			  ,[Observacion]
			  ,[Usuario]
		  FROM [dbo].[RecepcionNotasProveedores]
    END
    
----------------------------------------------------------------------------------

-- ELIMINO LAS TABLAS ANTERIORES

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].RecepcionEstados)
    BEGIN

		DROP TABLE dbo.RecepcionNotasProveedores;

		DROP TABLE dbo.RecepcionNotasEstados;

		DROP TABLE dbo.RecepcionNotas;

		DROP TABLE dbo.RecepcionEstados;

    END
    
