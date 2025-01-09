PRINT ''
PRINT '1. DROP SP Sucursales_GA'
--P: SQL_STORED_PROCEDURE // PC: CLR_STORED_PROCEDURE
IF EXISTS (SELECT * FROM sys.objects WHERE type IN ('P','PC') AND name = 'Sucursales_GA')
	DROP PROCEDURE dbo.Sucursales_GA
GO

PRINT ''
PRINT '2. Tabla Bitacora: Campo Descripcion cambiar tipo de dato a TEXT'
ALTER TABLE Bitacora ALTER COLUMN Descripcion TEXT NULL

-- Si tiene el menu de Logistica
PRINT ''
PRINT '3. Menu: Habilitar Modificar Reparto y Anular Reparto a quienes utilizan Logistica'
IF dbo.ExisteFuncion('Logistica') = 'True'
BEGIN
    IF dbo.ExisteFuncion('ModificarRepartos') = 'False'
    BEGIN
        INSERT INTO [dbo].Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
                  IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
             VALUES
                 ('ModificarRepartos', 'Modificar Repartos', 'Modificar Repartos', 'True', 'False', 'True', 'True'
                 ,'Logistica', 108, 'Eniac.Win', 'ModificarRepartos', NULL, NULL
                 ,'True', 'S', 'N', 'N', 'N');
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'ModificarRepartos' FROM RolesFunciones WHERE IdFuncion IN ('OrganizarEntregas','OrganizarEntregasV2');
    END
    IF dbo.ExisteFuncion('AnularRepartos') = 'False'
    BEGIN
        INSERT INTO [dbo].Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
                  IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
             VALUES
                 ('AnularRepartos', 'Anular Repartos', 'Anular Repartos', 'True', 'False', 'True', 'True'
                 ,'Logistica', 110, 'Eniac.Win', 'AnularRepartos', NULL, NULL
                 ,'True', 'S', 'N', 'N', 'N');
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'AnularRepartos' FROM RolesFunciones WHERE IdFuncion IN ('OrganizarEntregas','OrganizarEntregasV2');
    END
END
