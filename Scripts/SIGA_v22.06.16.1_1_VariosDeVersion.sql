 PRINT ''
 PRINT '1.1. Nueva Tabla: CalidadProgramacionProduccion'

/****** Object:  Table [dbo].[CalidadProgramacionProduccion]    Script Date: 8/6/2022 12:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadProgramacionProduccion](
	[IdListaControlTipo] [int] NOT NULL,
	[Dia] [date] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_CalidadProgramacionProduccion] PRIMARY KEY CLUSTERED 
(
	[IdListaControlTipo] ASC,
	[Dia] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadProgramacionProduccion]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProgramacionProduccion_CalidadProgramacionProduccion] FOREIGN KEY([IdListaControlTipo])
REFERENCES [dbo].[CalidadListasControlTipos] ([IdListaControlTipo])
GO

ALTER TABLE [dbo].[CalidadProgramacionProduccion] CHECK CONSTRAINT [FK_CalidadProgramacionProduccion_CalidadProgramacionProduccion]
GO

ALTER TABLE [dbo].[CalidadProgramacionProduccion]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProgramacionProduccion_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[CalidadProgramacionProduccion] CHECK CONSTRAINT [FK_CalidadProgramacionProduccion_Productos]
GO




IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Ingresar Metas Producción'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('MetasTiposModelosProductos', 'Ingresar Metas Producción', 'Ingresar Metas Producción', 
		'True', 'False', 'True', 'True', 'MPS',53, 'Eniac.Win', 'MetasTiposModelosProductos', null, null,'N','S','N','N','True')

		--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Panel de Programación de Producción'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('PanelProgProduccion', 'Panel de Programación de Producción', 'Panel de Programación de Producción', 
		'True', 'False', 'True', 'True', 'MPS',53, 'Eniac.Win', 'PanelProgProduccion', null, null,'N','S','N','N','True')

END;



PRINT ''
PRINT '1.1. Tabla PedidosProveedores: Agrega columna IdMoneda'

ALTER TABLE PedidosProveedores ADD IdMoneda	int	null
GO

