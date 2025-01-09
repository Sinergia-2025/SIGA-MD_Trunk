PRINT '';
PRINT '1. Nueva función= "Facturacion: Modifica el Desc/Recargo General"';
IF dbo.ExisteFuncion('Facturacion-ModifDescRecGral') = 0 AND dbo.ExisteFuncion('FacturacionV2') = 1
BEGIN
    PRINT '1.1. Crea Función'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion
		 ,EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Facturacion-ModifDescRecGral', 'Facturacion: Modifica el Desc/Recargo General', 'Facturacion: Modifica el Desc/Recargo General','False', 'False', 'True', 'True'
        ,'FacturacionV2', 999, 'Eniac.Win', 'Facturacion-ModifDescRecGral', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
    PRINT '1.2. Crea RolesFunciones'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Facturacion-ModifDescRecGral' FROM RolesFunciones WHERE IdFuncion = 'FacturacionV2'
END
PRINT '';
PRINT '2. Nueva función= "Facturacion Rapida: Modifica el Desc/Recargo General"';
IF dbo.ExisteFuncion('Fact-RapidModifDescRecGral') = 0 AND dbo.ExisteFuncion('FacturacionRapida') = 1
BEGIN
    PRINT '2.1. Crea Función'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion
		 ,EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Fact-RapidModifDescRecGral', 'Facturacion Rapida: Modifica el Desc/Recargo General', 'Facturacion Rapida: Modifica el Desc/Recargo General','False', 'False', 'True', 'True'
        ,'FacturacionRapida', 999, 'Eniac.Win', 'Fact-RapidModifDescRecGral', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
    PRINT '2.2. Crea RolesFunciones'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Fact-RapidModifDescRecGral' FROM RolesFunciones WHERE IdFuncion = 'FacturacionRapida'
END
