
PRINT ''
PRINT '1. Tabla Productos/AuditoriaProductos: nuevo campo NroDeMotor'
ALTER TABLE Productos ADD CalidadNroDeMotor varchar(50) null
GO
ALTER TABLE AuditoriaProductos ADD CalidadNroDeMotor varchar(50) null
GO

--Metalsur
PRINT ''
PRINT '2. Tabla Productos: Actualiza campo NroDeMotor desde la Vista por CalidadNumeroChasis si existe'
IF dbo.BaseConCuit('33631312379') = 1 
BEGIN
UPDATE Productos
SET Productos.CalidadNroDeMotor = VP.stp_Obs
FROM SBDAMETA.dbo.Vista_ArtPartidas VP
WHERE Productos.CalidadNumeroChasis = VP.stp_Partida COLLATE Modern_Spanish_CI_AS
AND stpDep_Cod = 'PCH'
END



PRINT ''
PRINT '1. Nueva tabla CalidadProductosTiposServicios'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalidadProductosTiposServicios](
	[IdProductoTipoServicio] [int] NOT NULL,
	[NombreProductoTipoServicio] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CalidadProductosTiposServicios] PRIMARY KEY CLUSTERED 
(
	[IdProductoTipoServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


PRINT ''
PRINT '2. Tabla Productos AuditoriaProductos: nuevo campo IdProductoTipoServicio'
ALTER TABLE Productos ADD IdProductoTipoServicio int null
GO
ALTER TABLE AuditoriaProductos ADD IdProductoTipoServicio int null
GO

--Metalsur
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN

PRINT ''
PRINT '3. Datos por defecto en CalidadProductosTiposServicios'
INSERT [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio], [NombreProductoTipoServicio]) VALUES (1, N'FABRICACION')
INSERT [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio], [NombreProductoTipoServicio]) VALUES (2, N'REPARACION')
INSERT [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio], [NombreProductoTipoServicio]) VALUES (3, N'SANEAMIENTO')

PRINT ''
PRINT '4. Actualizacion del campo IdProductoTipoServicio a productos existentes'

	UPDATE Productos SET IdProductoTipoServicio = 1 
	UPDATE Productos SET IdProductoTipoServicio = 2 WHERE IdProducto LIKE '%R%'

	PRINT ''
    PRINT '5. Nueva función menú Calidad: ABM de Tipos de Servicios de Productos'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
	   ('ProductosTiposServiciosABM', 'ABM de Tipos de Servicios de Productos', 'ABM de Tipos de Servicios de Productos', 'True', 'False', 'True', 'True'
        ,'Calidad', 126, 'Eniac.Win', 'ProductosTiposServiciosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
         
    PRINT ''
    PRINT '2.3. Roles menú ABM de Tipos de Servicios de Productos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProductosTiposServiciosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END

PRINT ''
PRINT '12. Agrega Funcion Productos: ProdCalidadABM_FechaEntProgramada'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ProdCalidadABM_FechaEntProg') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '12.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('ProdCalidadABM_FechaEntProg', 'Productos Calidad: Fecha Entrega programada', 'Productos Calidad: Fecha Entrega programada', 
		'False', 'False', 'True', 'True', 'ProductosCalidadABM',888, 'Eniac.Win', 'ProdCalidadABM_FechaEntProgr', null, null,'N','S','N','N')
	END;

    PRINT ''
    PRINT '12.2. Asignar Permisos'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ProdCalidadABM_FechaEntProg' FROM RolesFunciones
     WHERE IdFuncion = 'ProductosCalidadABM';
	;
	COMMIT
GO