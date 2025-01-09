/****** Object:  Table [dbo].[CalidadMetasTiposListas]    Script Date: 27/10/2021 10:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadMetasTiposListas](
	[IdListaControlTipo] [int] NOT NULL,
	[Dia] [date] NOT NULL,
	[MetaCoches] [int] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_CalidadMetasTiposListas] PRIMARY KEY CLUSTERED 
(
	[IdListaControlTipo] ASC,
	[Dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadMetasTiposListas]  WITH CHECK ADD  CONSTRAINT [FK_CalidadMetasTiposListas_CalidadListasControlTipos] FOREIGN KEY([IdListaControlTipo])
REFERENCES [dbo].[CalidadListasControlTipos] ([IdListaControlTipo])
GO

ALTER TABLE [dbo].[CalidadMetasTiposListas] CHECK CONSTRAINT [FK_CalidadMetasTiposListas_CalidadListasControlTipos]
GO

ALTER TABLE [dbo].[CalidadMetasTiposListas]  WITH CHECK ADD  CONSTRAINT [FK_CalidadMetasTiposListas_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadMetasTiposListas] CHECK CONSTRAINT [FK_CalidadMetasTiposListas_Usuarios]
GO



IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
----Inserto la Pantalla Nueva
--    PRINT ''
--    PRINT '1.1. Insertar funcion: Metas Mensuales por Sección'
--	INSERT INTO Funciones
--	   (Id, Nombre, Descripcion
--	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
--	 VALUES
--	   ('TiposListasMetasABM', 'Metas Mensuales por Sección', 'Metas Mensuales por Sección', 
--		'True', 'False', 'True', 'True', 'Calidad',129, 'Eniac.Win', 'TiposListasMetasABM', null, null,'N','S','N','N','True')

		--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Dias Laborables/No Laborables'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('DiasLaborablesNoLaborables', 'Dias Laborables/No Laborables', 'Dias Laborables/No Laborables', 
		'True', 'False', 'True', 'True', 'Calidad',129, 'Eniac.Win', 'DiasLaborablesNoLaborables', null, null,'N','S','N','N','True')

END;


/****** Object:  Table [dbo].[CalidadDiasLaborablesNoLaborables]    Script Date: 1/11/2021 09:09:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadDiasLaborablesNoLaborables](
	[Dia] [date] NOT NULL,
	[Laborable] [bit] NOT NULL,
 CONSTRAINT [PK_CalidadDiasLaborablesNoLaborables] PRIMARY KEY CLUSTERED 
(
	[Dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


