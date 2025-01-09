PRINT ''
PRINT '1. Nueva Función: ABM de Monedas.'
IF dbo.ExisteFuncion('ABMMonedas') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ABMMonedas', 'Monedas', 'ABM de Monedas', 'True', 'False', 'True', 'True'
        ,'Archivos', 92, 'Eniac.Win', 'MonedasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ABMMonedas' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO


PRINT ''
PRINT '2. Nueva Función: Auditoria de Monedas.'
IF dbo.ExisteFuncion('InfAuditoriaMonedas') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfAuditoriaMonedas', 'Inf. Auditoría de Monedas', 'Inf. Auditoría de Monedas', 'True', 'False', 'True', 'True'
        ,'ArchivosAuditorias', 50, 'Eniac.Win', 'InfAuditoriaMonedas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfAuditoriaMonedas' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '3. Nuevo Campo Predeterminada-Monedas.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'Predeterminada' AND TABLE_NAME = 'Monedas')
BEGIN
	ALTER TABLE Monedas ADD Predeterminada bit NULL
	ALTER TABLE AuditoriaMonedas ADD Predeterminada bit NULL
END
GO

PRINT ''
PRINT '4. Nuevo Campo Predeterminada-Monedas.'
BEGIN
	UPDATE Monedas SET Predeterminada = 0
	ALTER TABLE Monedas ALTER COLUMN Predeterminada bit NOT NULL
END
GO
