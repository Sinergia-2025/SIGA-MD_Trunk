
PRINT ''
PRINT '1. Nuevo tabla: CalidadProductosModelosTipos'
/****** Object:  Table [dbo].[CalidadProductosModelosTipos]    Script Date: 24/11/2021 09:03:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadProductosModelosTipos](
	[IdProductoModeloTipo] [int] NOT NULL,
	[NombreProductoModeloTipo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_CalidadProductosModelosTipos] PRIMARY KEY CLUSTERED 
(
	[IdProductoModeloTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: ABM de Tipos de Modelos de Productos'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ProductosModelosTiposABM', 'ABM de Tipos de Modelos de Productos', 'ABM de Tipos de Modelos de Productos', 
		'True', 'False', 'True', 'True', 'Calidad',127, 'Eniac.Win', 'ProductosModelosTiposABM', null, null,'N','S','N','N','True')

END;

PRINT ''
PRINT '1. Tabla CalidadProductosModelos: Agrega campo IdProductoModeloTipo'
ALTER TABLE CalidadProductosModelos ADD IdProductoModeloTipo int null
GO

ALTER TABLE [dbo].[CalidadProductosModelos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProductosModelos_CalidadProductosModelosTipos] FOREIGN KEY([IdProductoModeloTipo])
REFERENCES [dbo].[CalidadProductosModelosTipos] ([IdProductoModeloTipo])
GO

ALTER TABLE [dbo].[CalidadProductosModelos] CHECK CONSTRAINT [FK_CalidadProductosModelos_CalidadProductosModelosTipos]
GO