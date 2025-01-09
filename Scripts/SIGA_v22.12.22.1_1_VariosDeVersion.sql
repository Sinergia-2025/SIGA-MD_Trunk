PRINT ''
PRINT '1. Nueva Función: ABM de Sucursales Depositos.'
IF dbo.ExisteFuncion('Compras') = 'True' AND dbo.ExisteFuncion('MovimientosDeComprasV2Sueldo') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MovimientosDeComprasV2Sueldo', 'Movimientos de Compras (v2) Sueldo', 'Movimientos de Compras (v2) Sueldo', 'True', 'False', 'True', 'True'
        ,'Compras', 10, 'Eniac.Win', 'MovimientosDeComprasV2', NULL, 'SUELDO,SALARIO'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'MovimientosDeComprasV2Sueldo' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
