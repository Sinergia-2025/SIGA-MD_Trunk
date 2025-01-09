
PRINT '1. Tabla EstadosPedidos: Ajusto de Campo ReservaStock en Falso para Produccion.'
GO

UPDATE EstadosPedidos
   SET ReservaStock = 'faLSE'
 WHERE IdEstado = 'PRODUCCION'
GO


PRINT ''
PRINT '2. Seguridad: Perfil Supervisor a Informe de CRM Detallado.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimCRM' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '3. Seguridad: Perfil Supervisor a Informe de Seguimiento de Prospectos Detallado.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimPROSP' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '4. Seguridad: Perfil Supervisor a Informe de Reclamos de Clientes Detallado.'
GO
 
INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimRECCLTE' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '5. Seguridad: Perfil Supervisor a Informe de Reclamos a Proveedores Detallado.'
GO
 
INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimRECPROV' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '6. Seguridad: Perfil Supervisor a Informe de Percepciones Compra.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPercepcionesCompras' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '7. Seguridad: Perfil Supervisor a Estados de Clientes.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosClientesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '8. Seguridad: Perfil Supervisor a Tipos de Movimientos.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposMovimientosABM' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '9. Seguridad: Perfil Supervisor a Tipos de Clientes.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposClientesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '10. Seguridad: Perfil Supervisor a Cobradores.'
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CobradoresABM' AS Pantalla FROM Roles
    WHERE Id IN ('Supervisor')
GO


PRINT ''
PRINT '11. Seguridad: Perfil Supervisor a Fichas (de Clientes) (v2).'
GO

-- Si tiene el menu de Fichas
IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Fichas')
BEGIN
      
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'FichasABM2' AS Pantalla FROM Roles
        WHERE Id IN ('Supervisor')
    ;
END


PRINT ''
PRINT '12. Seguridad: Perfil Supervisor a ABM de Formas de Productos/ABM de Procesos de Produccion.'
GO
 
-- Solo lo agrega si utiliza el Modulo de Cuentas Corrientes de Proveedores
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Produccion')

BEGIN

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ProduccionFormasABM' AS Pantalla FROM Roles
        WHERE Id IN ('Supervisor');

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ProduccionProcesosABM' AS Pantalla FROM Roles
        WHERE Id IN ('Supervisor');

END;


PRINT ''
PRINT '13. Seguridad: Perfil Supervisor a Enviar Pedidos a la Web/Preventa.'
GO

-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Pedidos')
  AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '23238857449'))
BEGIN
      
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PedidosEnvioWeb' AS Pantalla FROM Roles
        WHERE Id IN ('Supervisor')
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PreventaV2' AS Pantalla FROM Roles
        WHERE Id IN ('Supervisor')
    ;
END


PRINT ''
PRINT '14. Seguridad: Perfil Supervisor a Generar Pedido Proveedores desde Pedidos Clientes.'
GO

-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Pedidos')

BEGIN
      
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'GeneraPedidoProvDesdeClie' AS Pantalla FROM Roles
        WHERE Id IN ('Supervisor')
    ;
        
END
