PRINT ''
PRINT '1. Tabla Pedidos: Campo nuevo IdDomicilio.-'
BEGIN
    ALTER TABLE Pedidos ADD IdDomicilio int NULL

    ALTER TABLE Pedidos ADD CONSTRAINT
	    FK_Pedidos_Domicilio FOREIGN KEY
			(IdCliente, IdDomicilio) 
		REFERENCES ClientesDirecciones
			(IdCliente,IdDireccion) 
		ON UPDATE  NO ACTION 
	    ON DELETE  NO ACTION 

END
GO

PRINT ''
PRINT '2. Tabla Pedidos: Campo nuevo IdDomicilio.-'
BEGIN
    ALTER TABLE Ventas ADD IdDomicilio int NULL

    ALTER TABLE Ventas ADD CONSTRAINT
	    FK_Ventas_Domicilio FOREIGN KEY
			(IdCliente, IdDomicilio) 
		REFERENCES ClientesDirecciones
			(IdCliente,IdDireccion) 
		ON UPDATE  NO ACTION 
	    ON DELETE  NO ACTION 

END
GO

PRINT ''
PRINT '3. Nueva Función: Alerta Inconsistencias de Depositos vs Sucursales'
IF dbo.ExisteFuncion('InconsistDepositoVsSucursales') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistDepositoVsSucursales', 'Alerta Inconsistencias de Depositos vs Sucursales', 'Alerta Inconsistencias de Depositos vs Sucursales', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistDepositoVsSucursales', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistDepositoVsSucursales' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '4. Nueva Función: Alerta Inconsistencias de Depositos vs Ubicaciones'
IF dbo.ExisteFuncion('InconsistDepositoVsUbicaciones') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistDepositoVsUbicaciones', 'Alerta Inconsistencias de Depositos vs Ubicaciones', 'Alerta Inconsistencias de Depositos vs Ubicaciones', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistDepositoVsUbicaciones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistDepositoVsUbicaciones' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '5. Nueva Función: Alerta Inconsistencias de Depositos vs Movim. de Stock'
IF dbo.ExisteFuncion('InconsistDepositosVsMovStock') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistDepositosVsMovStock', 'Alerta Inconsistencias de Depositos vs MovStock', 'Alerta Inconsistencias de Depositos vs MovStock', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistDepositosVsMovStock', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistDepositosVsMovStock' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '6. Nueva Función: Alerta Inconsistencias de Ubicaciones vs Movim. de Stock'
IF dbo.ExisteFuncion('InconsistUbicacionesVsMovStock') = 0 AND dbo.ExisteFuncion('Stock') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InconsistUbicacionesVsMovStock', 'Alerta Inconsistencias de Ubicaciones vs MovStock', 'Alerta Inconsistencias de Ubicaciones vs MovStock', 'False', 'False', 'True', 'False'
        ,'Stock', 999, 'Eniac.Win', 'InconsistUbicacionesVsMovStock', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InconsistUbicacionesVsMovStock' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
