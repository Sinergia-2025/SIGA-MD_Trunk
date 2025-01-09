PRINT ''
PRINT '1. Agrega Funcion Productos: ProdCalidadABM_ModificaChasis'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ProdCalidadABM_ModificaChasis') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('ProdCalidadABM_ModificaChasis', 'Productos Calidad: Modifica número de chasis', 'Productos Calidad: Modifica número de chasis', 
		'False', 'False', 'True', 'True', 'ProductosCalidadABM',888, 'Eniac.Win', 'ProdCalidadABM_ModificaChasis', null, null,'N','S','N','N')
	END;
	COMMIT
GO


PRINT ''
PRINT '2. Nueva tabla CalidadProductosModelos'
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadProductosModelos](
	[IdProductoModelo] [int] NOT NULL,
	[NombreProductoModelo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_CalidadProductosModelos] PRIMARY KEY CLUSTERED 
(
	[IdProductoModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


PRINT ''
PRINT '3. Tabla Productos AuditoriaProductos: nuevo campo IdProductoTipoServicio'
ALTER TABLE Productos ADD IdProductoModelo int null
GO
ALTER TABLE AuditoriaProductos ADD IdProductoModelo int null
GO

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN

--PRINT ''
--PRINT '3. Datos por defecto en CalidadProductosModelos'
--INSERT [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio], [NombreProductoTipoServicio]) VALUES (1, N'FABRICACION')
--INSERT [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio], [NombreProductoTipoServicio]) VALUES (2, N'REPARACION')
--INSERT [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio], [NombreProductoTipoServicio]) VALUES (3, N'SANEAMIENTO')



--PRINT ''
--PRINT '3. Actualizacion del campo IdProductoModelo a productos existentes'
	--UPDATE Productos SET IdProductoTipoServicio = 1 
	--UPDATE Productos SET IdProductoTipoServicio = 2 WHERE IdProducto LIKE '%R%'

	PRINT ''
    PRINT '4. Nueva función menú Calidad: ABM de Modelos de Productos'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
	   ('ProductosModelosABM', 'ABM de Modelos de Productos', 'ABM de Modelos de Productos', 'True', 'False', 'True', 'True'
        ,'Calidad', 127, 'Eniac.Win', 'ProductosModelosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
         
    PRINT ''
    PRINT '4.1. Roles menú ABM de Tipos de Servicios de Productos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProductosModelosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END

