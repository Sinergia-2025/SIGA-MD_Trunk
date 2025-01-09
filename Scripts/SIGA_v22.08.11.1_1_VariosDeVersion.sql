    PRINT ''
    PRINT '1. Tabla creación: CalidadAuditoriaLoginWebPaneles'
/****** Object:  Table [dbo].[CalidadAuditoriaLoginWebPaneles]    Script Date: 28/7/2022 10:36:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadAuditoriaLoginWebPaneles](
	[Id] [bigint] NOT NULL,
	[sincronizado] [bit] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[nombre_usuario] [varchar](100) NOT NULL,
	[ip] [varchar](50) NOT NULL,
	[pais_code] [varchar](10) NOT NULL,
	[pais] [varchar](100) NOT NULL,
	[login] [datetime] NOT NULL,
	[logout] [datetime] NULL,
	[navegador] [varchar](500) NOT NULL,
	[estado_registro] [bit] NOT NULL,
 CONSTRAINT [PK_CalidadAuditoriaLoginWebPaneles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF  dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 1 
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '2. Insertar funcion: Panel de Fechas de Salida de Sección con detalle por Coche'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('InformeAuditoriaLoginWeb', 'Informe de Auditoría Login Paneles Web', 'Informe de Auditoría Login Paneles Web', 
		'True', 'False', 'True', 'True', 'Seguridad',101, 'Eniac.Win', 'InformeAuditoriaLoginWeb', null, null,'N','S','N','N','True')

END;
