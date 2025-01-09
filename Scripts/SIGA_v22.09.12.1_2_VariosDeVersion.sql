PRINT ''
PRINT '1. Borro Menu Padre "Servicio Tecnico" si Corresponde (x CUIT).'
BEGIN
	IF dbo.BaseConCUIT('20267244686') = 0 AND dbo.BaseConCUIT('20272910570') = 0 AND dbo.BaseConCUIT('27201734687') = 0
			AND dbo.BaseConCUIT('20205360450') = 0 AND dbo.BaseConCUIT('30716345501') = 0 AND dbo.BaseConCUIT('20140869113') = 0
			AND dbo.BaseConCUIT('30709217719') = 0 AND dbo.BaseConCUIT('33711345499') = 0 AND dbo.BaseConCUIT('27432331178') = 0
			AND dbo.BaseConCUIT('20244785922') = 0 AND dbo.BaseConCUIT('20243377081') = 0 AND dbo.BaseConCUIT('30716534142') = 0
			AND dbo.BaseConCUIT('23293111979') = 0 
		BEGIN
			--- Primero: Borro las Opciones NIETOS (Botones de Seguridad o Perfil de las Pantallas).
			DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE IdPadre IN ('ServicioTecnico','CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE'));
			DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE IdPadre IN ('ServicioTecnico','CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE'));
			DELETE Funciones WHERE IdPadre IN ('ServicioTecnico','CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE') ;

			--- Segundo: Borro las Pantallas y Padre.
			DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE IdPadre = 'ServicioTecnico' OR Id IN ('ServicioTecnico','CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE'));
			DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE IdPadre = 'ServicioTecnico' OR Id IN ('ServicioTecnico','CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE'));
			DELETE Funciones WHERE IdPadre = 'ServicioTecnico' OR Id IN ('ServicioTecnico','CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE') ;
		END
END
GO

PRINT ''
PRINT '2. Creo Menu Padre "Servicio Tecnico" si Corresponde (x CUIT).'
BEGIN
	IF dbo.ExisteFuncion('ServicioTecnico') = 0 
	  AND ( dbo.BaseConCUIT('20267244686') = 1 OR dbo.BaseConCUIT('20272910570') = 1 OR dbo.BaseConCUIT('27201734687') = 1
			OR dbo.BaseConCUIT('20205360450') = 1 OR dbo.BaseConCUIT('30716345501') = 1 OR dbo.BaseConCUIT('20140869113') = 1
			OR dbo.BaseConCUIT('30709217719') = 1 OR dbo.BaseConCUIT('33711345499') = 1 OR dbo.BaseConCUIT('27432331178') = 1
			OR dbo.BaseConCUIT('20244785922') = 1 OR dbo.BaseConCUIT('20243377081') = 1 OR dbo.BaseConCUIT('30716534142') = 1
			OR dbo.BaseConCUIT('23293111979') = 1 ) 
		BEGIN
			INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
			VALUES
				('ServicioTecnico', 'Servicio Tecnico', 'Servicio Tecnico', 'True', 'False', 'True', 'True'
				,NULL, 60, NULL, NULL, NULL, NULL
				,'True', 'S', 'N', 'N', 'N', NULL, 'True');
   
			INSERT INTO RolesFunciones (IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'ServicioTecnico' AS Pantalla FROM dbo.Roles
			 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		END
END
GO

PRINT ''
PRINT '3. Reasigno Padre de las Funciones Servicio Tecnico.'
BEGIN
	UPDATE Funciones
	   SET IdPadre = 'ServicioTecnico'
	 WHERE id IN ('CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE')
	UPDATE Funciones
	   SET Nombre = 'ABM de Servicio Técnico'
		  ,Descripcion = 'ABM de Servicio Técnico'
	 WHERE id = 'CRMNovedadesABMSERVICE'
END
GO

PRINT ''
PRINT '4. Reordeno las Funciones del Menu Servicio Tecnico.'
BEGIN
	UPDATE Funciones  
	   SET Posicion = CASE Id
						WHEN 'CRMNovedadesABMSERVICE' THEN 10  
						WHEN 'InformeDeNovedadesService' THEN 110  
						WHEN 'InformeDeNovEstadosSERVICE' THEN 120  
						WHEN 'InformeDeServiceDetallado' THEN 130  
						WHEN 'InfOrdenesReparacion' THEN 210
						WHEN 'InfOrdenesTalleresExternos' THEN 220  
						WHEN 'InfRetirosEntregasADomicilio' THEN 230  
						ELSE NULL  
					  END  
	 WHERE Id IN ('CRMNovedadesABMSERVICE', 'InformeDeNovedadesService', 'InformeDeServiceDetallado', 'InfOrdenesReparacion', 'InfOrdenesTalleresExternos', 'InfRetirosEntregasADomicilio', 'InformeDeNovEstadosSERVICE')
END
GO

PRINT ''
PRINT '5. Altero las Tablas que tienen ancho incorrecto de IdUsuario. (ATENCION!!!) SIN FK Previa.'
BEGIN
	ALTER TABLE dbo.AuditoriaCalidadListasControlProductosItems ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.AuditoriaCalidadListasControlProductosItems ALTER COLUMN UsuarioCalidad VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.CalidadListasControlProductosItems ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.CalidadListasControlProductosItems ALTER COLUMN UsuarioCalidad VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.CalidadListasControlProductosItemsProceso ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.CalidadListasControlProductosItemsProceso ALTER COLUMN UsuarioOtraArea VARCHAR(10) NOT NULL;
END
GO

PRINT ''
PRINT '6. Creo las FKs de IdUSUARIO .'
BEGIN
	---TABLE_NAME ='xx' 
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_AuditoriaCalidadListasControlProductosItems_Usuarios') 
		ALTER TABLE dbo.AuditoriaCalidadListasControlProductosItems ADD CONSTRAINT FK_AuditoriaCalidadListasControlProductosItems_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_AuditoriaCalidadListasControlProductosItems2_Usuarios') 
		ALTER TABLE dbo.AuditoriaCalidadListasControlProductosItems ADD CONSTRAINT FK_AuditoriaCalidadListasControlProductosItems2_Usuarios 
			FOREIGN KEY	(UsuarioCalidad) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CalidadListasControlProductosItems_Usuarios') 
		ALTER TABLE dbo.CalidadListasControlProductosItems ADD CONSTRAINT FK_CalidadListasControlProductosItems_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CalidadListasControlProductosItems2_Usuarios') 
		ALTER TABLE dbo.CalidadListasControlProductosItems ADD CONSTRAINT FK_CalidadListasControlProductosItems2_Usuarios 
			FOREIGN KEY	(UsuarioCalidad) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CalidadListasControlProductosItemsProceso_Usuarios') 
		ALTER TABLE dbo.CalidadListasControlProductosItemsProceso ADD CONSTRAINT FK_CalidadListasControlProductosItemsProceso_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CalidadListasControlProductosItemsProceso2_Usuarios') 
		ALTER TABLE dbo.CalidadListasControlProductosItemsProceso ADD CONSTRAINT FK_CalidadListasControlProductosItemsProceso2_Usuarios 
			FOREIGN KEY	(UsuarioOtraArea) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
END
GO

PRINT ''
PRINT '7. Altero las Tablas que tienen ancho incorrecto de IdUsuario. (ATENCION!!!) SIN FK Previa.'
BEGIN
	ALTER TABLE dbo.Fichas ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.RecepcionNotas ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.RecepcionNotasEstados ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.RecepcionNotasProveedores ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.RecepcionNotasEstadosF ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.RecepcionNotasF ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
	ALTER TABLE dbo.RecepcionNotasProveedoresF ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
END
GO

PRINT ''
PRINT '8. Creo las FKs de IdUSUARIO para Recepcion.'
BEGIN
	---TABLE_NAME ='xx' 
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Fichas_Usuarios') 
		ALTER TABLE dbo.Fichas ADD CONSTRAINT FK_Fichas_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_RecepcionNotas_Usuarios') 
		ALTER TABLE dbo.RecepcionNotas ADD CONSTRAINT FK_RecepcionNotas_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_RecepcionNotasEstados_Usuarios') 
		ALTER TABLE dbo.RecepcionNotasEstados ADD CONSTRAINT FK_RecepcionNotasEstados_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_RecepcionNotasProveedores_Usuarios') 
		ALTER TABLE dbo.RecepcionNotasProveedores ADD CONSTRAINT FK_RecepcionNotasProveedores_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_RecepcionNotasF_Usuarios') 
		ALTER TABLE dbo.RecepcionNotasF ADD CONSTRAINT FK_RecepcionNotasF_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_RecepcionNotasEstadosF_Usuarios') 
		ALTER TABLE dbo.RecepcionNotasEstadosF ADD CONSTRAINT FK_RecepcionNotasEstadosF_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
	IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_RecepcionNotasProveedoresF_Usuarios') 
		ALTER TABLE dbo.RecepcionNotasProveedoresF ADD CONSTRAINT FK_RecepcionNotasProveedoresF_Usuarios 
			FOREIGN KEY	(Usuario) 
			REFERENCES dbo.Usuarios (Id) 
		ON UPDATE NO ACTION 
		ON DELETE NO ACTION;	
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '9. Borro Opciones Clasificacion, Aplicaciones y Otras si Corresponde (x CUIT).'
BEGIN
	IF dbo.BaseConCUIT('33711345499') = 0 AND dbo.BaseConCUIT('20244785922') = 0 
		BEGIN
			DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id IN ('AplicacionesEdicionesABM', 'AplicacionesABM', 'ClasificacionesABM'));
			DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id IN ('AplicacionesEdicionesABM', 'AplicacionesABM', 'ClasificacionesABM'));
			DELETE Funciones WHERE Id IN ('AplicacionesEdicionesABM', 'AplicacionesABM', 'ClasificacionesABM');
		END
END
GO

PRINT ''
PRINT '10. Creo Menu Padre "CRM ABM" si tiene CRM.'
BEGIN
	IF dbo.ExisteFuncion('CRMABMs') = 0 AND dbo.ExisteFuncion('CRM') = 1 
		BEGIN
			INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
			VALUES
				('CRMABMs', 'CRM ABMs', 'CRM ABMs', 'True', 'False', 'True', 'True'
				,'CRM', 900, NULL, NULL, NULL, NULL
				,'False', 'S', 'N', 'N', 'N', NULL, 'True');
   
			INSERT INTO RolesFunciones (IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'CRMABMs' AS Pantalla FROM dbo.Roles
			 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		END
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '10. Reasigno Padre de las Funciones CRM ABMs.'
BEGIN
	UPDATE Funciones
	   SET IdPadre = 'CRMABMs'
	 WHERE id IN ('AplicacionesEdicionesABM', 'AplicacionesABM', 'CRMCategoriasNovedadesABM', 'ClasificacionesABM', 'CRMEstadosNovedadesABM', 'EstadosProyectosABM', 'CRMMediosComunicacionesABM', 'CRMMetodosResolucionesABM', 'CRMPrioridadesNovedadesABM', 'ProyectosABM', 'CRMTiposComentariosNovABM', 'CRMTiposNovedadesABM', 'CRMTiposNovedadesObjetivosABM', 'VersionesABM')
	UPDATE Funciones
	   SET Nombre = 'ABM de Aplicaciones Ediciones'
		  ,Descripcion = 'ABM de Aplicaciones Ediciones'
	 WHERE Id = 'AplicacionesEdicionesABM'
	UPDATE Funciones
	   SET Nombre = 'ABM de Estados de Proyectos'
		  ,Descripcion = 'ABM de Estados de Proyectos'
	 WHERE Id = 'EstadosProyectosABM'
	UPDATE Funciones
	   SET Nombre = 'ABM de Proyectos'
		  ,Descripcion = 'ABM de Proyectos'
	 WHERE Id = 'ProyectosABM'
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '11. Reordeno las Funciones del Menu CRM ABMs.'
BEGIN
	UPDATE Funciones  
	   SET Posicion = CASE Id
						WHEN 'aa' THEN 10  
						WHEN 'CRMCategoriasNovedadesABM' THEN 110  
						WHEN 'CRMEstadosNovedadesABM' THEN 120  
						WHEN 'CRMMediosComunicacionesABM' THEN 130  
						WHEN 'CRMMetodosResolucionesABM' THEN 140  
						WHEN 'CRMPrioridadesNovedadesABM' THEN 150  
						WHEN 'CRMTiposComentariosNovABM' THEN 160  
						WHEN 'CRMTiposNovedadesABM' THEN 170  
						WHEN 'CRMTiposNovedadesObjetivosABM' THEN 180  
						WHEN 'ClasificacionesABM' THEN 210		-- Proyectos en el futuro se dividira.
						WHEN 'EstadosProyectosABM' THEN 220  
						WHEN 'ProyectosABM' THEN 230  
						WHEN 'AplicacionesABM' THEN 310
						WHEN 'AplicacionesEdicionesABM' THEN 320
						WHEN 'VersionesABM' THEN 330
						ELSE NULL  
					  END  
	 WHERE Id IN ('AplicacionesEdicionesABM', 'AplicacionesABM', 'CRMCategoriasNovedadesABM', 'ClasificacionesABM', 'CRMEstadosNovedadesABM', 'EstadosProyectosABM', 'CRMMediosComunicacionesABM', 'CRMMetodosResolucionesABM', 'CRMPrioridadesNovedadesABM', 'ProyectosABM', 'CRMTiposComentariosNovABM', 'CRMTiposNovedadesABM', 'CRMTiposNovedadesObjetivosABM', 'VersionesABM')
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '12. Creo Menu Padre "CRM Informes" si tiene CRM.'
BEGIN
	IF dbo.ExisteFuncion('CRMInformes') = 0 AND dbo.ExisteFuncion('CRM') = 1 
		BEGIN
			INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
			VALUES
				('CRMInformes', 'CRM Informes', 'CRM Informes', 'True', 'False', 'True', 'True'
				,'CRM', 910, NULL, NULL, NULL, NULL
				,'False', 'S', 'N', 'N', 'N', NULL, 'True');
   
			INSERT INTO RolesFunciones (IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'CRMInformes' AS Pantalla FROM dbo.Roles
			 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		END
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '13. Reasigno Padre de las Funciones CRM Informes.'
BEGIN
	UPDATE Funciones
	   SET IdPadre = 'CRMInformes'
	 WHERE Id IN ('InformeDeNovedadesACTIVIDAD', 'InformeDeNovedadesPENDIENTE', 'InformeDeNovedadesCRM', 'InformeDeNovedadesREQUER', 'InformeDeNovedadesTAREAS', 'InformeDeNovedadesRECCLTE', 'InformeDeNovedadesTICKETS', 'InformeDeNovedadesPROSP', 'InformeDeNovedadesRECPROV', 'InfNovedadesPorProyecto')
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '14. Reordeno las Funciones del Menu CRM Informes.'
BEGIN
	UPDATE Funciones  
	   SET Posicion = CASE Id
						WHEN 'aa' THEN 10  
						WHEN 'InformeDeNovedadesACTIVIDAD' THEN 110  --Dejo Primero los que mas usamos en Sinergia
						WHEN 'InformeDeNovedadesPENDIENTE' THEN 120  
						WHEN 'InformeDeNovedadesREQUER' THEN 130  
						WHEN 'InformeDeNovedadesTAREAS' THEN 140  
						WHEN 'InformeDeNovedadesTICKETS' THEN 150  
						WHEN 'InformeDeNovedadesCRM' THEN 210
						WHEN 'InformeDeNovedadesRECCLTE' THEN 220  
						WHEN 'InformeDeNovedadesPROSP' THEN 230  
						WHEN 'InformeDeNovedadesRECPROV' THEN 240
						WHEN 'InfNovedadesPorProyecto' THEN 310	-- Proyectos en el futuro se dividira.
						ELSE NULL  
					  END  
	 WHERE Id IN ('InformeDeNovedadesACTIVIDAD', 'InformeDeNovedadesPENDIENTE', 'InformeDeNovedadesCRM', 'InformeDeNovedadesREQUER', 'InformeDeNovedadesTAREAS', 'InformeDeNovedadesRECCLTE', 'InformeDeNovedadesTICKETS', 'InformeDeNovedadesPROSP', 'InformeDeNovedadesRECPROV', 'InfNovedadesPorProyecto')
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT '15. Creo Menu Padre "CRM Informes Detalle" si tiene CRM.'
PRINT ''
GO
IF dbo.ExisteFuncion('CRMInformesDetalle') = 0 AND dbo.ExisteFuncion('CRM') = 1 
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
			('CRMInformesDetalle', 'CRM Informes Detalle', 'CRM Informes Detalle', 'True', 'False', 'True', 'True'
			,'CRM', 920, NULL, NULL, NULL, NULL
			,'False', 'S', 'N', 'N', 'N', NULL, 'True');
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'CRMInformesDetalle' AS Pantalla FROM dbo.Roles
		 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
	END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '16. Reasigno Padre de las Funciones CRM Informes Detalle.'
BEGIN
	UPDATE Funciones
	   SET IdPadre = 'CRMInformesDetalle'
	 WHERE Id IN ('InformeDeNovSeguimCRM', 'InformeDeNovSeguimPendientes', 'InformeDeNovSeguimRECCLTE', 'InformeDeNovSeguimTICKETS', 'InformeDeNovSeguimPROSP', 'InformeDeNovSeguimRECPROV')
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '17. Reordeno las Funciones del Menu CRM Informes Detalle.'
BEGIN
	UPDATE Funciones  
	   SET Posicion = CASE Id
						WHEN 'aa' THEN 10  
						WHEN 'InformeDeNovSeguimPendientes' THEN 110  --Dejo Primero los que mas usamos en Sinergia
						WHEN 'InformeDeNovSeguimTICKETS' THEN 120  
						WHEN 'InformeDeNovSeguimCRM' THEN 210
						WHEN 'InformeDeNovSeguimRECCLTE' THEN 220  
						WHEN 'InformeDeNovSeguimPROSP' THEN 230  
						WHEN 'InformeDeNovSeguimRECPROV' THEN 240
						ELSE NULL  
					  END  
	 WHERE Id IN ('InformeDeNovSeguimCRM', 'InformeDeNovSeguimPendientes', 'InformeDeNovSeguimRECCLTE', 'InformeDeNovSeguimTICKETS', 'InformeDeNovSeguimPROSP', 'InformeDeNovSeguimRECPROV')
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '18. Creo Menu Padre "CRM Informes Estado" si tiene CRM.'
BEGIN
	IF dbo.ExisteFuncion('CRMInformesEstado') = 0 AND dbo.ExisteFuncion('CRM') = 1 
		BEGIN
			INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
			VALUES
				('CRMInformesEstado', 'CRM Informes Estado', 'CRM Informes Estado', 'True', 'False', 'True', 'True'
				,'CRM', 930, NULL, NULL, NULL, NULL
				,'False', 'S', 'N', 'N', 'N', NULL, 'True');
   
			INSERT INTO RolesFunciones (IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'CRMInformesEstado' AS Pantalla FROM dbo.Roles
			 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		END
END
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '19. Reasigno Padre de las Funciones CRM Informes Estado.'
BEGIN
	UPDATE Funciones
	   SET IdPadre = 'CRMInformesEstado'
	 WHERE Id IN ('InformeDeNovEstadosACTIVIDAD', 'InformeDeNovEstadosCRM', 'InformeDeNovEstadosPENDIENTE', 'InformeDeNovEstadosPROSP', 'InformeDeNovEstadosRECCLTE', 'InformeDeNovEstadosRECPROV', 'InformeDeNovEstadosREQUER', 'InformeDeNovEstadosTAREAS', 'InformeDeNovEstadosTICKETS')
END
GO
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
PRINT ''
PRINT '20. Reordeno las Funciones del Menu CRM Informes Estado.'
BEGIN
	UPDATE Funciones  
	   SET Posicion = CASE Id
						WHEN 'aa' THEN 10  
						WHEN 'InformeDeNovEstadosACTIVIDAD' THEN 110  --Dejo Primero los que mas usamos en Sinergia
						WHEN 'InformeDeNovEstadosPENDIENTE' THEN 120  
						WHEN 'InformeDeNovEstadosREQUER' THEN 130  
						WHEN 'InformeDeNovEstadosTAREAS' THEN 140  
						WHEN 'InformeDeNovEstadosTICKETS' THEN 150  
						WHEN 'InformeDeNovEstadosCRM' THEN 210
						WHEN 'InformeDeNovEstadosPROSP' THEN 220  
						WHEN 'InformeDeNovEstadosRECCLTE' THEN 230  
						WHEN 'InformeDeNovEstadosRECPROV' THEN 240
						ELSE NULL  
					  END  
	 WHERE Id IN ('InformeDeNovEstadosACTIVIDAD', 'InformeDeNovEstadosCRM', 'InformeDeNovEstadosPENDIENTE', 'InformeDeNovEstadosPROSP', 'InformeDeNovEstadosRECCLTE', 'InformeDeNovEstadosRECPROV', 'InformeDeNovEstadosREQUER', 'InformeDeNovEstadosTAREAS', 'InformeDeNovEstadosTICKETS')
END
GO
