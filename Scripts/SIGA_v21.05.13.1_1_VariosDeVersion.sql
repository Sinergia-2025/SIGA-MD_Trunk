--DELETE Bitacora WHERE IdFuncion = 'ReporteFiscalElectronico';
--DELETE RolesFunciones WHERE IdFuncion = 'ReporteFiscalElectronico';
--DELETE Funciones WHERE Id = 'ReporteFiscalElectronico';

--IF dbo.ExisteFuncion('VentasFiscal') = 1
--BEGIN
--    INSERT INTO Funciones
--        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
--        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
--        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
--    VALUES
--        ('ReporteFiscalElectronico', 'Reporte Fiscal Electrónico (Cierre Z)', 'Reporte Fiscal Electrónico (Cierre Z)', 'True', 'False', 'True', 'True'
--        ,'VentasFiscal', 280, 'Eniac.Win', 'ReporteFiscalElectronico', NULL, NULL
--        ,'True', 'S', 'N', 'N', 'N', 'True')

--    INSERT INTO RolesFunciones (IdRol,IdFuncion)
--    SELECT IdRol, 'ReporteFiscalElectronico' FROM RolesFunciones WHERE IdFuncion = 'CierreZ'
--END

IF dbo.ExisteFuncion('TablerosDeComando') = 1
BEGIN
	/*ABM Tableros de Controles*/
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('TablerosControlABM', 'Tablero de Control', 'Tablero de Control', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 215, 'Eniac.Win', 'TablerosControlABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TablerosControlABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

	 /*BUSCADOR TABLEROS DE CONTROL*/
INSERT INTO [dbo].[Buscadores]
           ([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
     VALUES
           (17,'Tableros de Control de Panel',600,'Grilla','')
GO

INSERT INTO [dbo].[BuscadoresCampos]
           ([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
     VALUES
           (17,'IdTableroControlPanel',1,'Código',64,70,'',null,null ,null) , 
           (17 ,'NombrePanel' ,2 , 'Nombre', 16, 200, '' ,null ,null ,null)


IF dbo.ExisteFuncion('TablerosDeComando') = 1
BEGIN
	/*ABM Paneles Tableros de Control*/
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('PanelesTablerosControlABM ', 'Paneles de Tableros de Control', 'Paneles de Tableros de Control', 'True', 'False', 'True', 'True'
        ,'TablerosDeComando', 225, 'Eniac.Win', 'PanelesTablerosControlABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PanelesTablerosControlABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

ALTER TABLE dbo.Impresoras ADD FiscalUltimaFechaExtraidaAuditoria datetime NULL
ALTER TABLE dbo.Impresoras ADD FiscalUltimoZetaExtraidoAuditoria int NULL
ALTER TABLE dbo.Impresoras ADD FiscalUltimaFechaExtraidaInforme datetime NULL
GO


ALTER TABLE ConcesionarioSubTiposUnidades DROP CONSTRAINT PK_IdSubTipoUnidad;  

ALTER TABLE ConcesionarioSubTiposUnidades ADD CONSTRAINT PK_IdSubTipoUnidad PRIMARY KEY CLUSTERED (IdSubTipoUnidad);



IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	PRINT ''
    PRINT '1. Nueva función menú Calidad: Informe Lead Time por Tipo de Lista de Control'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
      VALUES
	   ('InformeLeadTimePorTipo', 'Informe Lead Time por Tipo de Lista de Control', 'Informe Lead Time por Tipo de Lista de Control', 'True', 'False', 'True', 'True'
        ,'Calidad', 28, 'Eniac.Win', 'InformeLeadTimePorTipo', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
         
END

IF dbo.ExisteFuncion('Configuraciones') = 1
BEGIN
    /*Informe Auditoria de Parametros*/
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('InfAuditoriaParametros ', 'Auditoria de Parametros', 'Auditoria de Parametros', 'True', 'False', 'True', 'True'
        ,'Configuraciones', 120, 'Eniac.Win', 'InfAuditoriaParametros', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfAuditoriaParametros' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

