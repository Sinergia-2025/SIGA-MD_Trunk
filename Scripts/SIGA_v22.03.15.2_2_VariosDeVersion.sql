
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('AlertaClientesConDeuda', 'Alerta de Clientes clientes con deuda', 'Alerta de Clientes clientes con deuda', 'False', 'False', 'True', 'True'
        ,NULL, 999, '', 'AlertaClientesConDeuda', NULL, 'DiasVencimiento=0;SaldoMinimo=0;CantidadComprobantes=1'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AlertaClientesConDeuda' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
