PRINT ''
PRINT '1. Tabla Productos: Nuevo Campo IdProductoNumerico'
ALTER TABLE Productos ADD IdProductoNumerico BIGINT NULL
GO

PRINT ''
PRINT '1.1. Tabla Productos: Actualización de registros pre-existentes'
UPDATE P SET P.IdProductoNumerico = X.IdProducto FROM Productos P
 INNER JOIN Productos X ON P.IdProducto = X.IdProducto AND P.IdProducto NOT LIKE '%[^0-9]%' AND P.IdProducto LIKE '%[^A-Za-z]%'
GO

PRINT ''
PRINT '1.2. Tabla AuditoriaProductos: Nuevo Campo IdProductoNumerico'
ALTER TABLE AuditoriaProductos ADD IdProductoNumerico BIGINT NULL
GO

PRINT ''
PRINT '2. Tabla CRMNovedades: Nuevo Campo IdUsuarioEntregado y IdUsuarioFinalizado'
ALTER TABLE dbo.CRMNovedades ADD IdUsuarioEntregado varchar(10) NULL
ALTER TABLE dbo.CRMNovedades ADD IdUsuarioFinalizado varchar(10) NULL
GO

PRINT ''
PRINT '2.1. Tabla CRMNovedades: FK IdUsuarioEntregado y IdUsuarioFinalizado'
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_Usuarios_Entregado
    FOREIGN KEY (IdUsuarioEntregado)
    REFERENCES dbo.Usuarios (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
    
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_Usuarios_Finalizado
    FOREIGN KEY (IdUsuarioFinalizado)
    REFERENCES dbo.Usuarios (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '2.2. Tabla AuditoriaCRMNovedades: Nuevo Campo IdUsuarioEntregado y IdUsuarioFinalizado'
ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdUsuarioEntregado varchar(10) NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD IdUsuarioFinalizado varchar(10) NULL
GO


PRINT ''
PRINT '3. Nueva Tabla TablerosControl'
/****** Object:  Table [dbo].[TablerosControl]    Script Date: 13/01/2021 09:35:00 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TablerosControl](
	[IdTableroControl] [int] NOT NULL,
	[NombreTableroControl] [varchar](50) NOT NULL,
	[IdTableroControlPanel1] [int] NOT NULL,
	[IdTableroControlPanel2] [int] NULL,
	[IdTableroControlPanel3] [int] NULL,
	[IdTableroControlPanel4] [int] NULL,
	[IdTableroControlPanel5] [int] NULL,
	[IdTableroControlPanel6] [int] NULL,
 CONSTRAINT [PK_TablerosControl] PRIMARY KEY CLUSTERED ([IdTableroControl] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO
PRINT ''
PRINT '4. Nueva Tabla TablerosControlPaneles'
CREATE TABLE [dbo].[TablerosControlPaneles](
	[IdTableroControlPanel] [int] NOT NULL,
	[NombrePanel] [varchar](50) NOT NULL,
	[Parametros] [varchar](200) NOT NULL,
	[IdController] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TablerosControlPaneles] PRIMARY KEY CLUSTERED 
 ([IdTableroControlPanel] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TablerosControl]  WITH CHECK ADD  CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_1] FOREIGN KEY([IdTableroControlPanel1])
    REFERENCES [dbo].[TablerosControlPaneles] ([IdTableroControlPanel])
ALTER TABLE [dbo].[TablerosControl] CHECK CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_1]
GO

ALTER TABLE [dbo].[TablerosControl]  WITH CHECK ADD  CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_2] FOREIGN KEY([IdTableroControlPanel2])
    REFERENCES [dbo].[TablerosControlPaneles] ([IdTableroControlPanel])
ALTER TABLE [dbo].[TablerosControl] CHECK CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_2]
GO

ALTER TABLE [dbo].[TablerosControl]  WITH CHECK ADD  CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_3] FOREIGN KEY([IdTableroControlPanel3])
    REFERENCES [dbo].[TablerosControlPaneles] ([IdTableroControlPanel])
ALTER TABLE [dbo].[TablerosControl] CHECK CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_3]
GO

ALTER TABLE [dbo].[TablerosControl]  WITH CHECK ADD  CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_4] FOREIGN KEY([IdTableroControlPanel4])
    REFERENCES [dbo].[TablerosControlPaneles] ([IdTableroControlPanel])
ALTER TABLE [dbo].[TablerosControl] CHECK CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_4]
GO

ALTER TABLE [dbo].[TablerosControl]  WITH CHECK ADD  CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_5] FOREIGN KEY([IdTableroControlPanel5])
    REFERENCES [dbo].[TablerosControlPaneles] ([IdTableroControlPanel])
ALTER TABLE [dbo].[TablerosControl] CHECK CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_5]
GO
ALTER TABLE [dbo].[TablerosControl]  WITH CHECK ADD  CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_6] FOREIGN KEY([IdTableroControlPanel6])
    REFERENCES [dbo].[TablerosControlPaneles] ([IdTableroControlPanel])
ALTER TABLE [dbo].[TablerosControl] CHECK CONSTRAINT [FK_TablerosControl_TablerosControlPaneles_6]
GO

PRINT ''
PRINT '5. Tablas TablerosControl y TablerosControlPaneles: Inicializar datos'
IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '5.1. Tablas TablerosControlPaneles: Paneles para HAR Group'
    INSERT [dbo].[TablerosControlPaneles] ([IdTableroControlPanel], [NombrePanel], [Parametros], [IdController]) 
        VALUES (1,  'Backups', '', 'GrillaBackup'),
               (2,  'Vencimiento de Licencias', '', 'GrillaVencimientoLicencias'),
               (3,  'Dispositivos Clientes', '', 'GrillaPcs'),
               (4,  'Clientes por Largar', '', 'GrillaLargada'),
               (5,  'Versión Aplicación', '', 'GrillaVersionAplicacion'),
               (6,  'Versión Api', '', 'GrillaVersionApi'),
               (7,  'Tickets', '', 'GrillaTickets'),
               (8,  'Pendientes', '', 'GrillaPendientes'),
               (9,  'Actualizador Automático', '', 'ActualizadorAutomatico'),
               (10, 'Actualizador Automático (Alerta)', '', 'ActualizadorAutomaticoAlerta'),
               (51, 'Situacion de Soporte por Tipos de Estados', 'TICKETS', 'Eniac.Win.GrillaCRMSituacionPorTipoEstado'),
               (52, 'Situacion de Desarrollo por Tipos de Estados', 'PENDIENTE', 'Eniac.Win.GrillaCRMSituacionPorTipoEstado'),
               (53, 'Situacion de Soporte por Estados', 'TICKETS', 'Eniac.Win.GrillaCRMSituacionPorEstado'),
               (54, 'Situacion de Desarrollo por Estados', 'PENDIENTE', 'Eniac.Win.GrillaCRMSituacionPorEstado')
END
IF dbo.BaseConCuit('27201734687') = 1
BEGIN
    PRINT ''
    PRINT '5.2. Tablas TablerosControlPaneles: Paneles para Balanmac'
    INSERT [dbo].[TablerosControlPaneles] ([IdTableroControlPanel], [NombrePanel], [Parametros], [IdController]) 
        VALUES (100, 'Situacion de Servicio Técnico por Tipos de Estados', 'SERVICE', 'Eniac.Win.GrillaCRMSituacionPorTipoEstado'),
               (101, 'Situacion de Servicio Técnico por Estados', 'SERVICE', 'Eniac.Win.GrillaCRMSituacionPorEstado')
END

IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '5.3. Tablas TablerosControl: Tableros para HAR Group'
    INSERT [dbo].[TablerosControl] ([IdTableroControl], [NombreTableroControl], [IdTableroControlPanel1], [IdTableroControlPanel2], [IdTableroControlPanel3], [IdTableroControlPanel4], [IdTableroControlPanel5], [IdTableroControlPanel6]) 
        VALUES (1, 'Tablero de Soporte', 1, 5, 2, 4, 7, 9),
               (2, 'Tablero de Desarrollo', 1, 6, 2, 4, 8, 9)
END
IF dbo.BaseConCuit('27201734687') = 1
BEGIN
    PRINT ''
    PRINT '5.3. Tablas TablerosControl: Tableros para Balanmac'
    INSERT [dbo].[TablerosControl] ([IdTableroControl], [NombreTableroControl], [IdTableroControlPanel1], [IdTableroControlPanel2], [IdTableroControlPanel3], [IdTableroControlPanel4], [IdTableroControlPanel5], [IdTableroControlPanel6]) 
        VALUES (100, 'Tablero para Técnicos', 100, 101, NULL, NULL, NULL, NULL)
END


PRINT ''
PRINT '6. Menu: Ajustar menú Tableros de Comando'
IF dbo.ExisteFuncion('TablerosDeComando') = 0
BEGIN
    PRINT ''
    PRINT '6.1. Crear Menu: Tableros de Comando'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TablerosDeComando', 'Tableros de Comando', 'Tableros de Comando', 'True', 'False', 'True', 'True'
        ,NULL, 125, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    IF dbo.BaseConCuit('27201734687') = 1
    BEGIN
        PRINT ''
        PRINT '6.2.1. Roles Menu: Si soy Balanmac copio Adm, Supervisor y Oficina'
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TablerosDeComando' AS Pantalla FROM dbo.Roles
         WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ELSE
    BEGIN
        PRINT ''
        PRINT '6.2.1. Roles Menu: Si NO soy Balanmac copio copio permisos de TableroDeComando'
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'TablerosDeComando' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando'
    END
END

IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '6.3. Crear Menu: Tablero de Soporte copia del viejo Tablero de Comandos (solo HAR)'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_soporte', 'Tablero de Soporte', 'Tablero de Soporte', EsMenu, EsBoton, [Enabled], Visible
           ,'TablerosDeComando', Posicion, Archivo, Pantalla, Icono, 'Tablero=1'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComando'
    
    PRINT ''
    PRINT '6.3.1. Roles Menu: Tablero de Soporte copia del viejo Tablero de Comandos (solo HAR)'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_soporte' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando'

    PRINT ''
    PRINT '6.3.2. Bitacora: Ajusto función para nueva función de Tablero de Soporte'
    UPDATE Bitacora
       SET IdFuncion = 'TableroDeComando_soporte'
     WHERE IdFuncion = 'TableroDeComando'


    PRINT ''
    PRINT '6.4. Crear Menu: Tablero de Desarrollo copia del viejo Tablero de Comandos (desa) (solo HAR)'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_desarrollo', 'Tablero de Desarrollo', 'Tablero de Desarrollo', EsMenu, EsBoton, [Enabled], Visible
           ,'TablerosDeComando', Posicion, Archivo, Pantalla, Icono, 'Tablero=2'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandoDesa'
    
    PRINT ''
    PRINT '6.4.1. Roles Menu: Tablero de Desarrollo copia del viejo Tablero de Comandos (desa) (solo HAR)'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_desarrollo' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComandoDesa'

    PRINT ''
    PRINT '6.4.2. Bitacora: Ajusto función para nueva función de Tablero de Desarrollo'
    UPDATE Bitacora
       SET IdFuncion = 'TableroDeComando_desarrollo'
     WHERE IdFuncion = 'TableroDeComandoDesa'

     DELETE RolesFunciones WHERE IdFuncion = 'TableroDeComandoDesa'
     DELETE Funciones WHERE Id = 'TableroDeComandoDesa'

END

IF dbo.ExisteFuncion('TableroDeComando') = 1
BEGIN
    PRINT ''
    PRINT '6.5. Menu TablerosDeComando: Lo muevo al padre Tableros de Comando, lo pongo por abajo y reseteo los parámetros al genérico'
    UPDATE Funciones
       SET IdPadre = 'TablerosDeComando'
         , Posicion = 960
         , Parametros = ''
     WHERE Id = 'TableroDeComando'
END
ELSE
BEGIN
    PRINT ''
    PRINT '6.5. Creo Menu: TablerosDeComando'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TableroDeComando', 'Tablero de Comando (6 panel)', 'Tablero de Comando (6 panel)', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 960, 'Eniac.Win', 'TableroDeComando', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '6.5.1. Roles Menu: TableroDeComando solo Admin'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComando' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm')
END

IF dbo.ExisteFuncion('TableroDeComandox1') = 1
BEGIN
    PRINT ''
    PRINT '6.6. Menu TablerosDeComandox1: Lo muevo al padre Tableros de Comando, lo pongo por abajo y reseteo los parámetros al genérico'
    UPDATE Funciones
       SET IdPadre = 'TablerosDeComando'
         , Posicion = 910
         , Parametros = ''
     WHERE Id = 'TableroDeComandox1'
END
ELSE
BEGIN
    PRINT ''
    PRINT '6.6. Creo Menu: TablerosDeComando'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TableroDeComandox1', 'Tablero de Comando simple', 'Tablero de Comando simple', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 910, 'Eniac.Win', 'TableroDeComandox1', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '6.6.1. Roles Menu: TableroDeComandox1 solo Admin'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComandox1' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END



    PRINT ''
    PRINT '6.7. Creo Menu: TableroDeComandox2'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TableroDeComandox2', 'Tablero de Comando (2 paneles)', 'Tablero de Comando (2 paneles)', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 920, 'Eniac.Win', 'TableroDeComandox2', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '6.7.1. Roles Menu: TableroDeComandox2 solo Admin'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComandox2' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm')


    PRINT ''
    PRINT '6.8. Creo Menu: TableroDeComandox3'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TableroDeComandox3', 'Tablero de Comando (3 paneles)', 'Tablero de Comando (3 paneles)', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 930, 'Eniac.Win', 'TableroDeComandox3', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '6.8.1. Roles Menu: TableroDeComandox3 solo Admin'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComandox3' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm')


    PRINT ''
    PRINT '6.8. Creo Menu: TableroDeComandox4'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TableroDeComandox4', 'Tablero de Comando (4 paneles)', 'Tablero de Comando (4 paneles)', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 940, 'Eniac.Win', 'TableroDeComandox4', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '6.8.1. Roles Menu: TableroDeComandox4 solo Admin'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComandox4' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')


IF dbo.BaseConCuit('27201734687') = 1
BEGIN
    PRINT ''
    PRINT '7. Crear Menu: Tablero para Técnicos desde TableroDeComandox2 (Balanmac)'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_tecnicos', 'Tablero para Técnicos', 'Tablero para Técnicos', EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, 10, Archivo, Pantalla, Icono, 'Tablero=100'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandox2'
    
    PRINT ''
    PRINT '7.1. Roles Menu: Tablero para Técnicos'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComando_tecnicos' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

