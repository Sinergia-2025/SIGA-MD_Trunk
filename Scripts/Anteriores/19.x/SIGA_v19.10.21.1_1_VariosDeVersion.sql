PRINT ''
PRINT '1. Nueva Funcion: Informe de Kilos Comisiones por Categoria de Clientes.'
IF dbo.ExisteFuncion('ComisionesVendedores') = 'True'
BEGIN
--    PRINT ''
--    PRINT '1.1. Inserta Funcion: Informe de Kilos Comisiones por Categoria de Clientes'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfKilosComisionesCategCli', 'Inf. de Comisiones por Kilo y Categoría de Cliente', 'Inf. de Comisiones por Kilo y Categoría de Cliente', 'True', 'False', 'True', 'True'
        ,'ComisionesVendedores', 50, 'Eniac.Win', 'InfKilosComisionesCategoriaClientes', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
--    PRINT ''
--    PRINT '1.2. Permisos Funcion: Informe de Kilos Comisiones por Categoria de Clientes'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfKilosComisionesCategCli' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END
