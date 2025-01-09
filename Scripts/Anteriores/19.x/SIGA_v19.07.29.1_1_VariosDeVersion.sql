PRINT ''
PRINT '1. Tabla Clientes: Nuevo Campo CodigoClienteLetras'
ALTER TABLE Clientes ADD CodigoClienteLetras varchar(50) null
GO
PRINT ''
PRINT '1.1. Tabla Clientes: Valor por defecto a CodigoClienteLetras'
UPDATE Clientes SET  CodigoClienteLetras = CodigoCliente 
PRINT ''
PRINT '1.2. Tabla Clientes: NOT NULL para CodigoClienteLetras'
ALTER TABLE Clientes ALTER COLUMN CodigoClienteLetras varchar(50) not null
GO

PRINT ''
PRINT '2. Tabla Prospectos: Nuevo Campo CodigoProspectoLetras'
ALTER TABLE Prospectos ADD CodigoProspectoLetras varchar(50) null
GO
PRINT ''
PRINT '2.1. Tabla Prospectos: Valor por defecto a CodigoProspectoLetras'
UPDATE Prospectos SET  CodigoProspectoLetras = CodigoProspecto 
PRINT ''
PRINT '2.2. Tabla Prospectos: NOT NULL para CodigoProspectoLetras'
ALTER TABLE Prospectos ALTER COLUMN CodigoProspectoLetras varchar(50) not null
GO

PRINT ''
PRINT '3. Tabla AuditoriaClientes: Nuevo Campo CodigoClienteLetras'
ALTER TABLE AuditoriaClientes ADD CodigoClienteLetras varchar(50) null
GO

PRINT ''
PRINT '4. Tabla AuditoriaProspectos: Nuevo Campo CodigoProspectoLetras'
ALTER TABLE AuditoriaProspectos ADD  CodigoProspectoLetras varchar(50) null
GO

PRINT ''
PRINT '5. Tabla CalidadListasControlConfig: FK a CalidadListasControl'
ALTER TABLE [dbo].[CalidadListasControlConfig]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfig_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO
ALTER TABLE [dbo].[CalidadListasControlConfig] CHECK CONSTRAINT [FK_CalidadListasControlConfig_CalidadListasControl]
GO

/****** Object:  Table [dbo].[CalidadListasControlProductos]    Script Date: 26/7/2019 15:49:03 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '6. Nueva Tabla CalidadListasControlProductos'
CREATE TABLE [dbo].[CalidadListasControlProductos](
	[IdProducto] [varchar](15) NOT NULL,
	[IdListaControl] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[IdUsuario] [varchar](10) NULL,
	[FecIngreso] [datetime] NULL,
	[FecEgreso] [datetime] NULL,
	[CincoS] [varchar](25) NULL,
	[CincoSComment] [varchar](8000) NULL,
	[CincoSC] [varchar](25) NULL,
	[CincoSCommentC] [varchar](8000) NULL,
	[CincoSUsr] [varchar](50) NULL,
	[CincoSFecha] [datetime] NULL,
	[CincoSUsrC] [varchar](50) NULL,
	[CincoSFechaC] [datetime] NULL,
 CONSTRAINT [PK_CalidadListasControlProductos2_1] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdListaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '6.1. Tabla CalidadListasControlProductos: FK'
ALTER TABLE [dbo].[CalidadListasControlProductos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductos_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO
ALTER TABLE [dbo].[CalidadListasControlProductos] CHECK CONSTRAINT [FK_CalidadListasControlProductos_CalidadListasControl]
GO

ALTER TABLE [dbo].[CalidadListasControlProductos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[CalidadListasControlProductos] CHECK CONSTRAINT [FK_CalidadListasControlProductos_Usuarios]
GO

ALTER TABLE [dbo].[CalidadListasControlProductos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlProductos2_CalidadListasControlProductos2] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[CalidadListasControlProductos] CHECK CONSTRAINT [FK_CalidadListasControlProductos2_CalidadListasControlProductos2]
GO

PRINT ''
PRINT '7. Menu Calidad'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'
BEGIN
--SOLO METALSUR

    IF dbo.ExisteFuncion('Calidad') = 'False'
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('Calidad', 'Calidad', 'Calidad', 'True', 'False', 'True', 'True'
            ,NULL, 50, NULL, NULL, NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'Calidad' AS Pantalla FROM dbo.Roles
	     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END;

    IF dbo.ExisteFuncion('Calidad') = 'True'
    BEGIN
        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('ListasControlItemsABM', 'Items de Listas de Control', 'Items de Listas de Control', 'True', 'False', 'True', 'True'
                ,'Calidad', 10, 'Eniac.Win', 'ListasControlItemsABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'ListasControlItemsABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('ListasControlABM', 'Listas de Control Configuración', 'Listas de Control Configuración', 'True', 'False', 'True', 'True'
                ,'Calidad', 20, 'Eniac.Win', 'ListasControlABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'ListasControlABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('ListasControlUsuarios', 'Usuarios de Listas de Control', 'Usuarios de Listas de Control', 'True', 'False', 'True', 'True'
                ,'Calidad', 30, 'Eniac.Win', 'ListasControlUsuarios', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'ListasControlUsuarios' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('ProductosCalidadABM', 'ABM de Productos', 'ABM de Productos', 'True', 'False', 'True', 'True'
                ,'Calidad', 40, 'Eniac.Win', 'ProductosCalidadABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'ProductosCalidadABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('ProductosListasControl', 'Listas de Control de Productos', 'Listas de Control de Productos', 'True', 'False', 'True', 'True'
                ,'Calidad', 50, 'Eniac.Win', 'ProductosListasControl', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'ProductosListasControl' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('GruposListasControlItemsABM', 'Grupos de Items de Listas de Control', 'Grupos de Items de Listas de Control', 'True', 'False', 'True', 'True'
                ,'Calidad', 110, 'Eniac.Win', 'GruposListasControlItemsABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'GruposListasControlItemsABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'


        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('SubGruposListasControlItemsABM', 'SubGrupos de Items de Listas de Control', 'SubGrupos de Items de Listas de Control', 'True', 'False', 'True', 'True'
                ,'Calidad', 120, 'Eniac.Win', 'SubGruposListasControlItemsABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'SubGruposListasControlItemsABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'
    END
END