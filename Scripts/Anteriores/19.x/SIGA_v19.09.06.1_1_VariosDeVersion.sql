PRINT ''
PRINT '1. Menu: Renombrar opci�n de men� por Productos Asignaci�n de Listas de Control'
UPDATE Funciones
   SET Nombre = 'Productos Asignaci�n de Listas de Control' 
     , Descripcion = 'Productos Asignaci�n de Listas de Control' 
 WHERE Id = 'ProductosListasControl'


PRINT ''
PRINT '2. Menu Nueva funci�n: Inf. Pedidos Facturados'
IF dbo.ExisteFuncion('Pedidos') = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Menu: Agregar funci�n: Inf. Pedidos Facturados'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfPedidosFacturados', 'Inf. Pedidos Facturados', 'Inf. Pedidos Facturados', 'True', 'False', 'True', 'True'
        ,'Pedidos', 43, 'Eniac.Win', 'InfPedidosFacturados', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '2.2. Menu: Asignar roles: Inf. Pedidos Facturados'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfPedidosFacturados' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm') --, 'Supervisor', 'Oficina')
END
