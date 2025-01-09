PRINT ''
PRINT '1. Nueva Funcion: Informe de Comisiones Totales por Clientes.'
IF dbo.ExisteFuncion('ComisionesVendedores') = 'True'
BEGIN
--    PRINT ''
--    PRINT '1.1. Inserta Funcion: Informe de Comisiones Totales por Clientes'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfTotalClientesVentasPorVend', 'Inf. de Comisiones Totales por Clientes', 'Inf. de Comisiones Totales por Clientes', 'True', 'False', 'True', 'True'
        ,'ComisionesVendedores', 50, 'Eniac.Win', 'InfTotalClientesVentasPorVendedor', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
--    PRINT ''
--    PRINT '1.2. Permisos Funcion: Informe de Comisiones Totales por Clientes'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfTotalClientesVentasPorVend' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END
