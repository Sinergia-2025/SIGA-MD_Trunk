


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('SincronizarPanelDeControl') = 0 
--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: SincronizarPanelDeControl'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('SincronizarPanelDeControl', 'Sincronizar Panel de Control', 'Sincronizar Panel de Control', 
		'True', 'False', 'True', 'True', 'Calidad',500, 'Eniac.Win', 'SincronizarPanelDeControl', null, null,'N','S','N','N','True')
END;



IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('ChasisCalidadABM') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '1.2. Insertar funcion: ChasisCalidadABM'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ChasisCalidadABM', 'ABM de Chasis', 'ABM de Chasis', 
		'True', 'False', 'True', 'True', 'Calidad',60, 'Eniac.Win', 'ChasisCalidadABM', null, null,'N','S','N','N','True')
END;


/****** Object:  Table [dbo].[CalidadExcepcionesTipos]    Script Date: 27/9/2021 08:41:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  PRINT ''
    PRINT '2. Creacion Tablas: Excepciones'

CREATE TABLE [dbo].[CalidadExcepcionesTipos](
	[IdExcepcionTipo] [int] NOT NULL,
	[NombreExcepcionTipo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CalidadExcepcionesTipos] PRIMARY KEY CLUSTERED 
(
	[IdExcepcionTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[CalidadExcepciones]    Script Date: 27/9/2021 08:52:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadExcepciones](
	[IdExcepcion] [int] NOT NULL,
	[IdListaControlTipo] [int] NOT NULL,
	[IdExcepcionTipo] [int] NOT NULL,
	[Motivo] [varchar](300) NOT NULL,
	[FechaExcepcion] [datetime] NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[AccionesCorrectivas] [varchar](300) NULL,
	[Item] [varchar](100) NULL,
	[IdUsuario1] [varchar](10) NULL,
	[IdUsuario2] [varchar](10) NULL,
	[IdUsuario3] [varchar](10) NULL,
	[FechaUsuario1] [datetime] NULL,
	[FechaUsuario2] [datetime] NULL,
	[FechaUsuario3] [datetime] NULL,
	[Dpto] [varchar](30) NULL,
 CONSTRAINT [PK_CalidadExcepciones] PRIMARY KEY CLUSTERED 
(
	[IdExcepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadExcepciones_CalidadExcepciones] FOREIGN KEY([IdExcepcionTipo])
REFERENCES [dbo].[CalidadExcepcionesTipos] ([IdExcepcionTipo])
GO

ALTER TABLE [dbo].[CalidadExcepciones] CHECK CONSTRAINT [FK_CalidadExcepciones_CalidadExcepciones]
GO

ALTER TABLE [dbo].[CalidadExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadExcepciones_CalidadListasControlTipos] FOREIGN KEY([IdListaControlTipo])
REFERENCES [dbo].[CalidadListasControlTipos] ([IdListaControlTipo])
GO

ALTER TABLE [dbo].[CalidadExcepciones] CHECK CONSTRAINT [FK_CalidadExcepciones_CalidadListasControlTipos]
GO

ALTER TABLE [dbo].[CalidadExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadExcepciones_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadExcepciones] CHECK CONSTRAINT [FK_CalidadExcepciones_Usuarios]
GO

ALTER TABLE [dbo].[CalidadExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadExcepciones_Usuarios1] FOREIGN KEY([IdUsuario1])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadExcepciones] CHECK CONSTRAINT [FK_CalidadExcepciones_Usuarios1]
GO

ALTER TABLE [dbo].[CalidadExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadExcepciones_Usuarios2] FOREIGN KEY([IdUsuario2])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadExcepciones] CHECK CONSTRAINT [FK_CalidadExcepciones_Usuarios2]
GO

ALTER TABLE [dbo].[CalidadExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadExcepciones_Usuarios3] FOREIGN KEY([IdUsuario3])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadExcepciones] CHECK CONSTRAINT [FK_CalidadExcepciones_Usuarios3]
GO




/****** Object:  Table [dbo].[CalidadProductosExcepciones]    Script Date: 27/9/2021 08:53:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadProductosExcepciones](
	[IdProducto] [varchar](15) NOT NULL,
	[IdExcepcion] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[IdUsuario] [varchar](10) NULL,
 CONSTRAINT [PK_CalidadProductosExcepciones] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdExcepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadProductosExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProductosExcepciones_CalidadExcepciones] FOREIGN KEY([IdExcepcion])
REFERENCES [dbo].[CalidadExcepciones] ([IdExcepcion])
GO

ALTER TABLE [dbo].[CalidadProductosExcepciones] CHECK CONSTRAINT [FK_CalidadProductosExcepciones_CalidadExcepciones]
GO

ALTER TABLE [dbo].[CalidadProductosExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProductosExcepciones_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[CalidadProductosExcepciones] CHECK CONSTRAINT [FK_CalidadProductosExcepciones_Productos]
GO

ALTER TABLE [dbo].[CalidadProductosExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProductosExcepciones_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadProductosExcepciones] CHECK CONSTRAINT [FK_CalidadProductosExcepciones_Usuarios]
GO



IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('ExcepcionesTiposABM') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '3.1. Insertar funcion: ExcepcionesTiposABM'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ExcepcionesTiposABM', 'ABM de Tipos de Desvíos', 'ABM de Tipos de Desvíos', 
		'True', 'False', 'True', 'True', 'Calidad',128, 'Eniac.Win', 'ExcepcionesTiposABM', null, null,'N','S','N','N','True')

		IF dbo.ExisteFuncion('ExcepcionesABM') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1


--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '3.2. Insertar funcion: ExcepcionesABM '
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ExcepcionesABM', 'ABM de Desvíos', 'ABM de Desvíos', 
		'True', 'False', 'True', 'True', 'Calidad',129, 'Eniac.Win', 'ExcepcionesABM', null, null,'N','S','N','N','True')


	IF dbo.ExisteFuncion('ExcepcionesProductos') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '3.3. Insertar funcion: ExcepcionesProductos'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ExcepcionesProductos', 'Asignar Desvíos a Productos', 'Asignar Desvíos a Productos', 
		'True', 'False', 'True', 'True', 'Calidad',53, 'Eniac.Win', 'ExcepcionesProductos', null, null,'N','S','N','N','True')


			IF dbo.ExisteFuncion('InformeProductosExcepciones') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '3.4. Insertar funcion: InformeProductosExcepciones'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('InformeProductosExcepciones', 'Informe de Desvíos de Productos', 'Informe de Desvíos de Productos', 
		'True', 'False', 'True', 'True', 'Calidad',54, 'Eniac.Win', 'InformeProductosExcepciones', null, null,'N','S','N','N','True')


END;

BEGIN TRANSACTION
IF dbo.ExisteFuncion('ExcepProductos_ElimAgregProd') = 0 AND dbo.ExisteFuncion('ExcepcionesProductos') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '3.5. Insertar funcion: ExcepProductos_ElimAgregProd'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ExcepProductos_ElimAgregProd', 'Asignar Productos a Desvíos:Elimina/Agrega Productos', 'Asignar Productos a Desvíos:Elimina/Agrega Productos', 
		'False', 'False', 'True', 'True', 'ProductosListasControl',888, 'Eniac.Win', 'ExcepProductos_ElimAgregProd', null, null,'N','S','N','N', 'True')
	END;
	   	;
	COMMIT
GO

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('InformeDeFaltantesDeMateriales') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '3.6. Insertar funcion: InformeDeFaltantesDeMateriales'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('InformeDeFaltantesDeMateriales', 'Informe de faltantes de Materiales', 'Informe de faltantes de Materiales', 
		'True', 'False', 'True', 'True', 'Calidad',128, 'Eniac.Win', 'InformeDeFaltantesDeMateriales', null, null,'N','S','N','N','True')
END;


