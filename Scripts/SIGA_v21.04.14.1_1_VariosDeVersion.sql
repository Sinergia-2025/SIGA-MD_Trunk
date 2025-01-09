
PRINT ''
PRINT '1. Tabla CalidadProductosModelos: Agrego campo CodigoProductoModelo'


ALTER TABLE CalidadProductosModelos ADD CodigoProductoModelo varchar(20) Null
GO

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN


PRINT ''
PRINT '2. Datos por defecto en CalidadProductosModelos'

INSERT INTO [dbo].[CalidadProductosModelos]
           ([IdProductoModelo]
           ,[NombreProductoModelo]
           ,[CodigoProductoModelo])
     VALUES
           (1, 'GENERAL','GENERAL' )

ALTER TABLE CalidadProductosModelos ALTER COLUMN CodigoProductoModelo varchar(20) not Null

PRINT ''
PRINT '3. Actualizacion del campo IdProductoModelo a productos existentes'
	
	UPDATE Productos SET IdProductoModelo = 1 
	
END

PRINT ''
PRINT '4. Tabla CalidadListasControlProductosModelos: Creacion '

/****** Object:  Table [dbo].[CalidadListasControlProductosModelos]    Script Date: 13/04/2021 10:53:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadListasControlProductosModelos](
	[IdProductoModelo] [int] NOT NULL,
	[IdListaControl] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[IdUsuario] [varchar](10) NULL,
 CONSTRAINT [PK_CalidadListasControlProductosModelos] PRIMARY KEY CLUSTERED 
(
	[IdProductoModelo] ASC,
	[IdListaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadListasControlProductosModelos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductosModelos_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO

ALTER TABLE [dbo].[CalidadListasControlProductosModelos] CHECK CONSTRAINT [FK_CalidadListasControlProductosModelos_CalidadListasControl]
GO

ALTER TABLE [dbo].[CalidadListasControlProductosModelos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductosModelos_CalidadProductosModelos] FOREIGN KEY([IdProductoModelo])
REFERENCES [dbo].[CalidadProductosModelos] ([IdProductoModelo])
GO

ALTER TABLE [dbo].[CalidadListasControlProductosModelos] CHECK CONSTRAINT [FK_CalidadListasControlProductosModelos_CalidadProductosModelos]
GO

ALTER TABLE [dbo].[CalidadListasControlProductosModelos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductosModelos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadListasControlProductosModelos] CHECK CONSTRAINT [FK_CalidadListasControlProductosModelos_Usuarios]
GO




IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
PRINT ''
PRINT '6. Renombrar Importar Clientes Bejerman por Importar Tablas Bejerman'

UPDATE Funciones SET Nombre = 'Importar Tablas Bejerman', Descripcion = 'Importar Tablas Bejerman' WHERE Id = 'ImportarClientesCalidad'

END

PRINT ''
PRINT '7. Agrega Funcion Productos: ProdCalidadABM_ModificaModelo'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ProdCalidadABM_ModificaModelo') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('ProdCalidadABM_ModificaModelo', 'Productos Calidad: Modifica Modelo', 'Productos Calidad: Modifica Modelo', 
		'False', 'False', 'True', 'True', 'ProductosCalidadABM',888, 'Eniac.Win', 'ProdCalidadABM_ModificaModelo', null, null,'N','S','N','N')
	END;
	COMMIT
GO