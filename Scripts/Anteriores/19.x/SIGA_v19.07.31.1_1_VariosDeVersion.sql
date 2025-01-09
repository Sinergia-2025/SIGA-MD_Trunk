PRINT ''
PRINT '1. Seguridad a Consultar Pedidos: Ver Costo en Consultar Pedidos'
IF dbo.ExisteFuncion('ConsultarPedidos') = 'True' AND dbo.ExisteFuncion('ConsultarPedidos-VerPCosto') = 'False'
BEGIN
	PRINT '1.1. Agregar funcion'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('ConsultarPedidos-VerPCosto', 'Ver Costo en Consultar Pedidos', 'Ver Costo en Consultar Pedidos', 'False', 'False', 'True', 'True'
             ,'ConsultarPedidos', 999, 'Eniac.Win', 'ConsultarPedidos-VerPCosto', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

	PRINT '1.2. Agregar permisos'
    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ConsultarPedidos-VerPCosto' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'InfPedidosDetallados-VerPCosto';
END;

PRINT ''
PRINT '2. DROP SP UsuariosRoles_GA'
--P: SQL_STORED_PROCEDURE // PC: CLR_STORED_PROCEDURE
IF EXISTS (SELECT * FROM sys.objects WHERE type IN ('P','PC') AND name = 'UsuariosRoles_GA')
	DROP PROCEDURE dbo.UsuariosRoles_GA
GO

PRINT ''
PRINT '3. DROP SP UsuariosRoles_D'
IF EXISTS (SELECT * FROM sys.objects WHERE type IN ('P','PC') AND name = 'UsuariosRoles_D')
	DROP PROCEDURE dbo.UsuariosRoles_D
GO

PRINT ''
PRINT '4. DROP SP UsuariosRoles_I'
IF EXISTS (SELECT * FROM sys.objects WHERE type IN ('P','PC') AND name = 'UsuariosRoles_I')
	DROP PROCEDURE dbo.UsuariosRoles_I
GO
