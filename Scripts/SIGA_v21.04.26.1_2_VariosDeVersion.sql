PRINT ''
PRINT '1. Nueva opción de menú Referencia Transferencia'
IF dbo.ExisteFuncion('AFIP') = 1 AND dbo.ExisteFuncion('AFIPReferenciaTransferenciaABM') = 0
BEGIN
    PRINT ''
    PRINT '1.1. Agregar nueva opción de menú Referencia Transferencia'
    /*ABM AFIPReferenciaTransferenia*/
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('AFIPReferenciaTransferenciaABM', 'Referencia Transferencia', 'Referencia Trasnferencia', 'True', 'False', 'True', 'True'
        ,'AFIP', 160, 'Eniac.SiGA.Win', 'AFIPReferenciaTransferenciaABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '1.2. Roles nueva opción de menú Referencia Transferencia'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AFIPReferenciaTransferenciaABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Nueva opción de menú Emisión de Etiquetas Para Bultos'
IF dbo.ExisteFuncion('Procesos') = 1 AND dbo.ExisteFuncion('EmisionEtiquetasParaBultos') = 0
BEGIN
    PRINT ''
    PRINT '2.1. Agregar nueva opción de menú Emisión de Etiquetas Para Bultos'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('EmisionEtiquetasParaBultos', 'Emisión de Etiquetas Para Bultos', 'Emisión de Etiquetas Para Bultos', 'True', 'False', 'True', 'True'
        ,'Procesos', 120, 'Eniac.Win', 'EmisionEtiquetasParaBultos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '2.2. Roles nueva opción de menú Emisión de Etiquetas Para Bultos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EmisionEtiquetasParaBultos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

DECLARE @crmamb VARCHAR(MAX) = 'CRMABMs'
IF dbo.ExisteFuncion(@crmamb) = 0
    SET @crmamb = 'CRM'
PRINT ''
PRINT '3. Nueva opción de menú ABM de Clasificaciones'
IF dbo.ExisteFuncion(@crmamb) = 1 AND dbo.ExisteFuncion('ClasificacionesABM') = 0
BEGIN
    PRINT ''
    PRINT '3.1. Agregar nueva opción de menú ABM de Clasificaciones'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ClasificacionesABM', 'ABM de Clasificaciones', 'ABM de Clasificaciones', 'True', 'False', 'True', 'True'
        ,@crmamb, 505, 'Eniac.Win', 'ClasificacionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.2. Roles nueva opción de menú ABM de Clasificaciones'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ClasificacionesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '4. Nueva opción de menú Tipos de Usuarios'
IF dbo.ExisteFuncion('Seguridad') = 1 AND dbo.ExisteFuncion('TiposUsuariosABM') = 0
BEGIN
    PRINT ''
    PRINT '4.1. Agregar nueva opción de menú Tipos de Usuarios'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TiposUsuariosABM', 'Tipos de Usuarios', 'Tipos de Usuarios', 'True', 'False', 'True', 'True'
        ,'Seguridad', 130, 'Eniac.Win', 'TiposUsuariosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '4.2. Roles nueva opción de menú Tipos de Usuarios'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TiposUsuariosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END


PRINT ''
PRINT '5. Nueva opción de menú Dispositivos'
IF dbo.ExisteFuncion('Seguridad') = 1 AND dbo.ExisteFuncion('DispositivosABM') = 0
BEGIN
    PRINT ''
    PRINT '5.1. Agregar nueva opción de menú Dispositivos'
    /*ABM DISPOSITIVOS*/
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('DispositivosABM', 'Dispositivos', 'Dispositivos', 'True', 'False', 'True', 'True'
        ,'Seguridad', 130, 'Eniac.Win', 'DispositivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '5.2. Roles nueva opción de menú Dispositivos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'DispositivosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END


PRINT ''
PRINT '6. Nuevo Buscador'
/*BUSCADOR TIPO DE UNIDAD*/
INSERT INTO Buscadores ([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial]) VALUES (15, 'Tipos de Unidades', 1000, 'Grilla', '')

PRINT ''
PRINT '6.1. Campos del nuevo Buscador'
INSERT INTO BuscadoresCampos ([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho])
        VALUES (15, 'IdTipoUnidad', 1, 'Codigo', 64, 70),
               (15, 'NombreTipoUnidad', 1, 'Nombre', 16, 200),
               (15, 'DescripcionTipoUnidad', 1, 'Descripcion', 16, 300)

