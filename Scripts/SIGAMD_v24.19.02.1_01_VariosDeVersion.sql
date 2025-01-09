IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('GenerarOrdenesDeCalidad') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('GenerarOrdenesDeCalidad', 'Generación Masiva de Ordenes de Calidad', 'Generación Masiva de Ordenes de Calidad', 'True', 'False', 'True', 'True'
        ,'Calidad', 500, 'Eniac.Win', 'GenerarOrdenesDeCalidad', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'GenerarOrdenesDeCalidad' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteCampo('CalidadOrdenDeControl', 'IdUsuarioAlta') = 0
BEGIN
    ALTER TABLE dbo.CalidadOrdenDeControl ADD IdUsuarioAlta varchar(10) NULL
    ALTER TABLE dbo.CalidadOrdenDeControl ADD FechaAlta datetime NULL
    ALTER TABLE dbo.CalidadOrdenDeControl ADD IdUsuarioActualizacion varchar(10) NULL
    ALTER TABLE dbo.CalidadOrdenDeControl ADD FechaActualizacion datetime NULL
END
GO

IF dbo.ExisteCampo('CalidadOrdenDeControl', 'IdUsuario') = 1
BEGIN
    EXEC ('UPDATE CalidadOrdenDeControl
       SET IdUsuarioAlta = IdUsuario
         , IdUsuarioActualizacion = IdUsuario
         , FechaAlta = Fecha
         , FechaActualizacion = Fecha
     WHERE IdUsuarioAlta IS NULL');
END

ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN IdUsuarioAlta varchar(10) NOT NULL
ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN FechaAlta datetime NOT NULL
ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN IdUsuarioActualizacion varchar(10) NOT NULL
ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN FechaActualizacion datetime NOT NULL

ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN IdDeposito int NULL
ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN IdUbicacion int NULL

IF dbo.ExisteFK('FK_CalidadOrdenDeControl_Usuarios_Alta') = 0
BEGIN
    ALTER TABLE dbo.CalidadOrdenDeControl ADD CONSTRAINT FK_CalidadOrdenDeControl_Usuarios_Alta
        FOREIGN KEY (IdUsuarioAlta)
        REFERENCES dbo.Usuarios (Id)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteFK('FK_CalidadOrdenDeControl_Usuarios_Actualizacion') = 0
BEGIN
    ALTER TABLE dbo.CalidadOrdenDeControl ADD CONSTRAINT FK_CalidadOrdenDeControl_Usuarios_Actualizacion
        FOREIGN KEY (IdUsuarioActualizacion)
        REFERENCES dbo.Usuarios (Id)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteFK('FK_CalidadOrdenDeControls_Usuarios') = 1
BEGIN
    ALTER TABLE CalidadOrdenDeControl DROP CONSTRAINT FK_CalidadOrdenDeControls_Usuarios
END
GO

IF dbo.ExisteCampo('CalidadOrdenDeControl', 'IdUsuario') = 1
BEGIN
    ALTER TABLE dbo.CalidadOrdenDeControl DROP COLUMN IdUsuario
END
GO

IF dbo.ExisteCampo('CalidadOrdenDeControl', 'CantidadComprobante') = 1
BEGIN
    EXECUTE sp_rename N'dbo.CalidadOrdenDeControl.CantidadComprobante', N'CantidadControlar', 'COLUMN' 
END
GO

IF dbo.ExisteCampo('CalidadOrdenDeControl', 'Observaciones') = 0
BEGIN
    ALTER TABLE dbo.CalidadOrdenDeControl ADD Observaciones varchar(MAX) NULL
END
GO

UPDATE CalidadOrdenDeControl
       SET Observaciones = ''
     WHERE Observaciones IS NULL
;

ALTER TABLE dbo.CalidadOrdenDeControl ALTER COLUMN Observaciones varchar(MAX) NOT NULL
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('CRMEstadosCiclosPlanificacion') = 0
BEGIN
    CREATE TABLE CRMEstadosCiclosPlanificacion(
	    IdEstadoCicloPlanificacion varchar(20) NOT NULL,
	    TipoEstadoCicloPlanificacion varchar(20) NOT NULL,
	    Orden int NOT NULL,
	    PorDefecto bit NOT NULL,
	    BackColor int NULL,
	    ForeColor int NULL,
     CONSTRAINT PK_CRMEstadosCiclosPlanificacion PRIMARY KEY CLUSTERED (IdEstadoCicloPlanificacion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM CRMEstadosCiclosPlanificacion)
BEGIN
    INSERT INTO CRMEstadosCiclosPlanificacion
               (IdEstadoCicloPlanificacion, TipoEstadoCicloPlanificacion, Orden, PorDefecto, BackColor)
        VALUES ('PLANIFICANDO'  , 'PENDIENTE' , 1, 'True', NULL),
               ('ACTIVO'        , 'ENPROCESO' , 2, 'False', -16711936),
               ('CERRADO'       , 'ENPROCESO' , 3, 'False', -256),
               ('FINALIZADO'    , 'FINALIZADO', 4, 'False',-32640)
END
GO

/****** Object:  Table dbo.CRMCiclosPlanificacion    Script Date: 19/6/2024 19:43:13 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('CRMCiclosPlanificacion') = 0
BEGIN
    CREATE TABLE CRMCiclosPlanificacion(
	    IdCicloPlanificacion int NOT NULL,
	    NombreCicloPlanificacion varchar(30) NOT NULL,
	    IdEstadoCicloPlanificacion varchar(20) NOT NULL,
	    FechaInicio datetime NOT NULL,
	    FechaCierre datetime NOT NULL,
	    FechaFinalizacion datetime NOT NULL,
	    IdUsuarioAlta varchar(10) NOT NULL,
	    FechaAlta datetime NOT NULL,
	    IdUsuarioActualizacion varchar(10) NOT NULL,
	    FechaActualizacion datetime NOT NULL,
     CONSTRAINT PK_CRMCicloPlanificacion PRIMARY KEY CLUSTERED (IdCicloPlanificacion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacion_CRMEstadosCiclosPlanificacion') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacion  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacion_CRMEstadosCiclosPlanificacion FOREIGN KEY(IdEstadoCicloPlanificacion)
        REFERENCES dbo.CRMEstadosCiclosPlanificacion (IdEstadoCicloPlanificacion)
    ALTER TABLE dbo.CRMCiclosPlanificacion CHECK CONSTRAINT FK_CRMCiclosPlanificacion_CRMEstadosCiclosPlanificacion
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacion_Usuarios_Actualizacion') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacion  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacion_Usuarios_Actualizacion FOREIGN KEY(IdUsuarioActualizacion)
        REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.CRMCiclosPlanificacion CHECK CONSTRAINT FK_CRMCiclosPlanificacion_Usuarios_Actualizacion
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacion_Usuarios_Alta') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacion  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacion_Usuarios_Alta FOREIGN KEY(IdUsuarioAlta)
        REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.CRMCiclosPlanificacion CHECK CONSTRAINT FK_CRMCiclosPlanificacion_Usuarios_Alta
END
GO

/****** Object:  Table dbo.CRMCiclosPlanificacionNovedades    Script Date: 19/6/2024 19:45:18 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('CRMCiclosPlanificacionNovedades') = 0
BEGIN
    CREATE TABLE CRMCiclosPlanificacionNovedades(
	    IdCicloPlanificacion int NOT NULL,
	    IdTipoNovedad varchar(10) NOT NULL,
	    Letra varchar(1) NOT NULL,
	    CentroEmisor smallint NOT NULL,
	    IdNovedad bigint NOT NULL,
	    Orden int NOT NULL,
	    TipoPlanificacion varchar(10) NOT NULL,
	    Planificada bit NOT NULL,
	    IdEstadoNovedadInicio int NULL,
	    IdEstadoNovedadCierre int NULL,
	    IdEstadoNovedadFinal int NULL,
	    IdUsuarioAlta varchar(10) NOT NULL,
	    FechaAlta datetime NOT NULL,
	    IdUsuarioActualizacion varchar(10) NOT NULL,
	    FechaActualizacion datetime NOT NULL,
     CONSTRAINT PK_CRMCiclosPlanificacionNovedades PRIMARY KEY CLUSTERED (IdCicloPlanificacion ASC, IdTipoNovedad ASC, Letra ASC, CentroEmisor ASC, IdNovedad ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_CRMCiclosPlanificacion') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMCiclosPlanificacion FOREIGN KEY(IdCicloPlanificacion)
        REFERENCES dbo.CRMCiclosPlanificacion (IdCicloPlanificacion)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMCiclosPlanificacion
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Cierre') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Cierre FOREIGN KEY(IdEstadoNovedadCierre)
        REFERENCES dbo.CRMEstadosNovedades (IdEstadoNovedad)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Cierre
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Final') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Final FOREIGN KEY(IdEstadoNovedadFinal)
        REFERENCES dbo.CRMEstadosNovedades (IdEstadoNovedad)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Final
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Inicio') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Inicio FOREIGN KEY(IdEstadoNovedadInicio)
        REFERENCES dbo.CRMEstadosNovedades (IdEstadoNovedad)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMEstadosNovedades_Inicio
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_CRMNovedades') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMNovedades FOREIGN KEY(IdTipoNovedad, Letra, CentroEmisor, IdNovedad)
        REFERENCES dbo.CRMNovedades (IdTipoNovedad, Letra, CentroEmisor, IdNovedad)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_CRMNovedades
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_Usuarios_Actualizacion') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_Usuarios_Actualizacion FOREIGN KEY(IdUsuarioActualizacion)
        REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_Usuarios_Actualizacion
END
GO

IF dbo.ExisteFK('FK_CRMCiclosPlanificacionNovedades_Usuarios_Alta') = 0
BEGIN
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades  WITH CHECK ADD  CONSTRAINT FK_CRMCiclosPlanificacionNovedades_Usuarios_Alta FOREIGN KEY(IdUsuarioAlta)
        REFERENCES dbo.Usuarios (Id)
    ALTER TABLE dbo.CRMCiclosPlanificacionNovedades CHECK CONSTRAINT FK_CRMCiclosPlanificacionNovedades_Usuarios_Alta
END
GO

IF dbo.ExisteCampo('CuentasCorrientes', 'FechaPromedioCobro') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientes ADD FechaPromedioCobro DateTime NULL
    ALTER TABLE dbo.CuentasCorrientes ADD PromedioDiasCobro decimal(16,2) NULL
    ALTER TABLE dbo.CuentasCorrientes ADD CantidadDiasCobro decimal(16,2) NULL
END
GO

IF dbo.ExisteCampo('CuentasCorrientesPagos', 'FechaPromedioCobro') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientesPagos ADD FechaPromedioCobro DateTime NULL
    ALTER TABLE dbo.CuentasCorrientesPagos ADD PromedioDiasCobro decimal(16,2) NULL
    ALTER TABLE dbo.CuentasCorrientesPagos ADD CantidadDiasCobro decimal(16,2) NULL
END
GO

IF dbo.ExisteFuncion('CRM') = 1 AND dbo.ExisteFuncion('CRMPlanificacion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('CRMPlanificacion', 'Planificación', 'Planificación', 'True', 'False', 'True', 'True'
        ,'CRM', 940, 'Eniac.Win', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMPlanificacion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteFuncion('CRMPlanificacion') = 1 AND dbo.ExisteFuncion('EstadosCiclosPlanificacionABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('EstadosCiclosPlanificacionABM', 'ABM Estados de Ciclos de Planificación', 'ABM Estados de Ciclos de Planificación', 'True', 'False', 'True', 'True'
        ,'CRMPlanificacion', 500, 'Eniac.Win', 'CRMEstadosCiclosPlanificacionABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EstadosCiclosPlanificacionABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteFuncion('CRMPlanificacion') = 1 AND dbo.ExisteFuncion('CRMCiclosPlanificacionABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('CRMCiclosPlanificacionABM', 'Ciclos de Planificación', 'Ciclos de Planificación', 'True', 'False', 'True', 'True'
        ,'CRMPlanificacion', 10, 'Eniac.Win', 'CRMCiclosPlanificacionABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMCiclosPlanificacionABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteFuncion('CRMPlanificacion') = 1 AND dbo.ExisteFuncion('CiclosPlanificacionNovedades') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('CiclosPlanificacionNovedades', 'Novedades de Ciclos de Planificación', 'Novedades de Ciclos de Planificación', 'True', 'False', 'True', 'True'
        ,'CRMPlanificacion', 30, 'Eniac.Win', 'CRMCiclosPlanificacionNovedadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CiclosPlanificacionNovedades' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
go

DECLARE @idBuscador int = 700
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Ciclos de Planificación' Titulo, 650 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
;
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'IdCicloPlanificacion'        IdBuscadorNombreCampo,  1 Orden, 'Código'       Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreCicloPlanificacion'    IdBuscadorNombreCampo,  2 Orden, 'Nombre'       Titulo, @alineacion_izq Alineacion, 200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'IdEstadoCicloPlanificacion'  IdBuscadorNombreCampo,  3 Orden, 'Estado'       Titulo, @alineacion_izq Alineacion,  80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'FechaInicio'                 IdBuscadorNombreCampo,  4 Orden, 'Fecha Inicio' Titulo, @alineacion_izq Alineacion,  80 Ancho, 'dd/MM/yyyy' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'FechaCierre'                 IdBuscadorNombreCampo,  5 Orden, 'Fecha Cierre' Titulo, @alineacion_izq Alineacion,  80 Ancho, 'dd/MM/yyyy' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'FechaFinalizacion'           IdBuscadorNombreCampo,  6 Orden, 'Fecha FIn'    Titulo, @alineacion_izq Alineacion,  80 Ancho, 'dd/MM/yyyy' Formato, NULL Condicion, NULL Valor, NULL ColorFila
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
;



IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPProductos') = 1
BEGIN
UPDATE funciones SET Nombre = 'Inf. Detalle Operaciones de Orden Producción', 
				     Descripcion = 'Inf. Detalle Operaciones de Orden Producción'
where id = 'InfOrdenProduccionMRPProductos'
END


ALTER TABLE TarjetasCupones ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE TarjetasCuponesHistorial ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE CuentasCorrientesTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE VentasTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL
