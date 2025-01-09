IF dbo.ExisteFuncion('FacturacionV2') = 1 AND dbo.ExisteFuncion('FactV2LimiteCreditoPermitido') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('FactV2LimiteCreditoPermitido', 'Factura Limite de Crédito Permite', 'Factura Limite de Crédito Permite', 'False', 'False', 'True', 'True'
        ,'FacturacionV2', 9999, '', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FactV2LimiteCreditoPermitido' AS Pantalla FROM dbo.Roles
END
IF dbo.ExisteFuncion('FacturacionV2') = 1 AND dbo.ExisteFuncion('FactV2LimiteDiasVtoPermitido') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('FactV2LimiteDiasVtoPermitido', 'Factura Limite Dias Vto. Permite', 'Factura Limite Dias Vto. Permite', 'False', 'False', 'True', 'True'
        ,'FacturacionV2', 9999, '', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FactV2LimiteDiasVtoPermitido' AS Pantalla FROM dbo.Roles
END

IF dbo.ExisteFuncion('FacturacionRapida') = 1 AND dbo.ExisteFuncion('FactRapLimiteCreditoPermitido') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('FactRapLimiteCreditoPermitido', 'Factura Limite de Crédito Permite', 'Factura Limite de Crédito Permite', 'False', 'False', 'True', 'True'
        ,'FacturacionRapida', 9999, '', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FactRapLimiteCreditoPermitido' AS Pantalla FROM dbo.Roles
END
IF dbo.ExisteFuncion('FacturacionRapida') = 1 AND dbo.ExisteFuncion('FactRapLimiteDiasVtoPermitido') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('FactRapLimiteDiasVtoPermitido', 'Factura Limite Dias Vto. Permite', 'Factura Limite Dias Vto. Permite', 'False', 'False', 'True', 'True'
        ,'FacturacionRapida', 9999, '', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FactRapLimiteDiasVtoPermitido' AS Pantalla FROM dbo.Roles
END

IF dbo.ExisteFuncion('Configuraciones') = 1 AND dbo.ExisteFuncion('BuscadoresABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('BuscadoresABM', 'ABM de Buscadores', 'ABM de Buscadores', 'True', 'False', 'True', 'True'
        ,'Configuraciones', 97, 'Eniac.Win', 'BuscadoresABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'BuscadoresABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

IF dbo.ExisteFuncion('ArchivosTipos') = 1 AND dbo.ExisteFuncion('ConcesionarioTiposUnidadesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConcesionarioTiposUnidadesABM', 'Tipos de Unidades', 'Tipos de Unidades', 'True', 'False', 'True', 'True'
        ,'ArchivosTipos', 197, 'Eniac.Win', 'ConcesionarioTiposUnidadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConcesionarioTiposUnidadesABM' AS Pantalla FROM dbo.Roles
END
