PRINT ''
PRINT '0. Nuevo Menu Padre: ServicioVehiculos'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'URLWSPN4'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'URL WebService de Consulta a Padron Contribuyentes'
	DECLARE @valorParametro VARCHAR(MAX) = 'https://aws.afip.gov.ar/sr-padron/webservices/personaServiceA5'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO
------------------------------------------------------------------------------------------------------------------------


PRINT ''
PRINT '0. Nuevo Menu Padre: ServicioVehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 0 AND dbo.SoyHAR() = 1
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
	VALUES
		('ServicioVehiculos', 'Talleres', 'Talleres', 'True', 'False', 'True', 'True'
		, NULL, 70, NULL, NULL, NULL, NULL
		,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ServicioVehiculos' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Nuevo Menu ABM de Servicio Taller'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.ExisteFuncion('CRMNovedadesABMVEHICULO') = 0 AND dbo.SoyHAR() = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('CRMNovedadesABMVEHICULO', 'ABM de Servicio Vehiculos', 'ABM de Servicio Vehiculos', 'True', 'False', 'True', 'True'
        , 'ServicioVehiculos', 10, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TipoNovedad=VEHICULO'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMNovedadesABMVEHICULO' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Nuevo Menu Informe de Servicio Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.ExisteFuncion('InformeDeNovedadesVehiculo') = 0 AND dbo.SoyHAR() = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('InformeDeNovedadesVehiculo', 'Informe de Servicio Vehiculos', 'Informe de Servicio Vehiculos', 'True', 'False', 'True', 'True'
        , 'ServicioVehiculos', 110, 'Eniac.Win', 'InformeDeNovedades', NULL, 'VEHICULO'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeDeNovedadesVehiculo' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Nuevo Menu Informe de Servicio Vehiculos Cambios de Estado'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.ExisteFuncion('InformeDeNovEstadosVEHICULOS') = 0 AND dbo.SoyHAR() = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('InformeDeNovEstadosVEHICULOS', 'Informe de Servicio Vehiculos Cambios de Estado', 'Informe de Servicio Vehiculos Cambios de Estado', 'True', 'False', 'True', 'True'
        , 'ServicioVehiculos', 120, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'VEHICULO'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeDeNovEstadosVEHICULOS' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '4. Nuevo Tipo de Novedad CRM: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1 AND NOT EXISTS(SELECT * FROM CRMTiposNovedades WHERE IdTipoNovedad = 'VEHICULO')
BEGIN
	INSERT INTO CRMTiposNovedades
			   (IdTipoNovedad, NombreTipoNovedad, UnidadDeMedida, UsuarioRequerido, UsuarioPorDefecto, ProximoContactoRequerido
			   ,PrimerOrdenGrilla, PrimerOrdenDesc, SegundoOrdenGrilla, SegundoOrdenDesc, VisualizaOtrasNovedades, VisualizaRevisionAdministrativa
			   ,PermiteBorrarComentarios, DiasProximoContacto, PermiteIngresarNumero, ReportaCantidad, ReportaAvance, LetrasHabilitadas, VerCambios
			   ,RequierePadre, Reporte, Embebido, CantidadCopias, SolapaPorDefecto, VisualizaSucursal)
		 VALUES
			   ('VEHICULO', 'Servicio de Vehiculos', '%', 1, 1, 0, 'N__FechaNovedad', 0, NULL, 0, 1, 0, 1, 1, 1, 0
			   , 1, 'X', 0, 0, NULL, 0, 1, 'Comentario', 'NoVisible')
	
	INSERT INTO CRMTiposNovedadesDinamicos
           (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden)
     VALUES
           ('VEHICULO', 'VEHICULO', 1, 10),
           ('VEHICULO', 'CLIENTES', 1, 20)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '5. Nuevos Tipos Estados Novedad: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1 AND NOT EXISTS( SELECT * FROM CRMTiposEstadosNovedades WHERE IdTipoEstadoNovedad = 201 )
BEGIN
	INSERT INTO CRMTiposEstadosNovedades
			   (IdTipoEstadoNovedad, NombreTipoEstadoNovedad, Posicion, IdTipoNovedad)
		 VALUES
			   (201, 'NUEVO', 10, 'VEHICULO'),
			   (202, 'EN PROCESO', 20, 'VEHICULO'),
			   (203, 'FINALIZADO', 30, 'VEHICULO'),
			   (204, 'CANCELADO', 40, 'VEHICULO')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '6. Nuevos Estados Novedad: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1  AND NOT EXISTS( SELECT * FROM CRMEstadosNovedades WHERE IdEstadoNovedad = 260 )
BEGIN
	INSERT INTO CRMEstadosNovedades
			   (IdEstadoNovedad, NombreEstadoNovedad, Posicion, SolicitaUsuario, Finalizado, IdTipoNovedad, PorDefecto
			   , Color, DiasProximoContacto, ActualizaUsuarioResponsable, SolicitaProveedorService, Imprime, Reporte, Embebido
			   , AcumulaContador1, AcumulaContador2, EsFacturable, CantidadCopias, IdTipoEstadoNovedad, Entregado, IdEstadoFacturado
			   , AvanceEstadoFacturado, ControlaStockConsumido, RequiereComentarios)
		 VALUES
			   (260, '1 - ALTA',				10, 0, 0, 'VEHICULO', 1, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 201, 'NoAfecta', 151, 100.00,  0, 0),
			   (261, '2 - INGRESADO',			20, 0, 0, 'VEHICULO', 0, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 201, 'NoAfecta', 151, 100.00,  0, 0),
			   (262, '3 - REVISADO',			30, 0, 0, 'VEHICULO', 0, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 202, 'NoAfecta', 151, 100.00,  0, 0),
			   (263, '4 - OK SIN CONFIRMAR',	40, 0, 0, 'VEHICULO', 0, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 201, 'NoAfecta', 151, 100.00,  0, 0),
			   (264, '5 - PRESUPUESTADO',		50, 0, 0, 'VEHICULO', 0, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 201, 'NoAfecta', 151, 100.00,  0, 0),
			   (265, '6 - CONFIRMADO',			60, 0, 0, 'VEHICULO', 0, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 201, 'NoAfecta', 151, 100.00,  0, 0),
			   (266, 'CANCELADO',				70, 0, 0, 'VEHICULO', 0, NULL, NULL, 0, 0, 0, '', 0, 0, 0, 0, 1, 201, 'NoAfecta', 151, 100.00,  0, 0)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '7. Nuevas Prioridades: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1  AND NOT EXISTS( SELECT * FROM CRMPrioridadesNovedades WHERE IdPrioridadNovedad = 600 )
BEGIN
	INSERT INTO CRMPrioridadesNovedades
			   (IdPrioridadNovedad, NombrePrioridadNovedad, Posicion, IdTipoNovedad, PorDefecto)
		 VALUES (600, 'ALTA', 1, 'VEHICULO', 1),
				(601, 'MEDIA', 1, 'VEHICULO', 0),
				(602, 'BAJA', 1, 'VEHICULO', 0)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '8. Nuevos Tipos Categorias Novedad: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1  AND NOT EXISTS( SELECT * FROM CRMTiposCategoriasNovedades WHERE IdTipoCategoriaNovedad = 600 )
BEGIN
	INSERT INTO CRMTiposCategoriasNovedades
			   (IdTipoCategoriaNovedad, NombreTipoCategoriaNovedad, Posicion, IdTipoNovedad)
		 VALUES
			   (60, 'GENERAL', 10, 'VEHICULO')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '9. Nuevos Medios de Comunicacion Novedad: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1  AND NOT EXISTS( SELECT * FROM CRMMediosComunicacionesNovedades WHERE IdMedioComunicacionNovedad = 600 )
BEGIN
	INSERT INTO CRMMediosComunicacionesNovedades
			   (IdMedioComunicacionNovedad, NombreMedioComunicacionNovedad, Posicion, IdTipoNovedad, PorDefecto, Color)
		 VALUES
			   (600, 'DOMICILIO', 1, 'VEHICULO', 1, NULL),
			   (601, 'LOCAL', 2, 'VEHICULO', 0, NULL)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '10. Nuevos Comentarios Novedad: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1 AND NOT EXISTS( SELECT * FROM CRMTiposComentariosNovedades WHERE IdTipoComentarioNovedad = 601 )
BEGIN
	INSERT INTO CRMTiposComentariosNovedades
			   (IdTipoComentarioNovedad, NombreTipoComentarioNovedad, Posicion, PorDefecto, Color, IdTipoNovedad, VisibleParaCliente, VisibleParaRepresentante)
		 VALUES
			   (601, 'COMENTARIO',		10, 1, NULL, 'VEHICULO', 0, 1),
			   (602, 'ACTIVIDAD',		20, 0, NULL, 'VEHICULO', 0, 1),
			   (603, 'ULTIMO CONTACTO', 30, 0, NULL, 'VEHICULO', 0, 1),
			   (604, 'OBSERVACIÓN',		40, 0, NULL, 'VEHICULO', 0, 1)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '11. Nuevas Categorias Novedad: Vehiculos'
IF dbo.ExisteFuncion('ServicioVehiculos') = 1 AND dbo.SoyHAR() = 1 AND NOT EXISTS( SELECT * FROM CRMCategoriasNovedades WHERE IdCategoriaNovedad = 601 )
BEGIN
	INSERT INTO CRMCategoriasNovedades
			   (IdCategoriaNovedad, NombreCategoriaNovedad, Posicion, IdTipoNovedad, PorDefecto, Reporta, Color, PublicarEnWeb, IdTipoCategoriaNovedad)
		 VALUES
			   (601, 'ACEPTADA', 1, 'VEHICULO', 1, 'NO', NULL, 1, 60),
			   (602, 'ENVIADA', 2, 'VEHICULO', 1, 'NO', NULL, 1, 60),
			   (603, 'INGRESADA', 3, 'VEHICULO', 1, 'NO', NULL, 1, 60),
			   (604, 'RECHAZADA', 4, 'VEHICULO', 1, 'NO', NULL, 1, 60)
END
GO
------------------------------------------------------------------------------------------------------------------------

