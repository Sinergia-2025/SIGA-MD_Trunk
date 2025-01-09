
--Elimino los menues anteriores.

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id IN ('Produccion', 'Producción') OR IdPadre IN ('Produccion', 'Producción')
)
GO

DELETE [Funciones]
 WHERE id IN ('Produccion', 'Producción') OR IdPadre IN ('Produccion', 'Producción')
GO


--Inserto el Menu Nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild)
  VALUES
    ('Produccion', 'Produccion', '', 'True', 'False', 'True', 'True',
     NULL, 130, NULL, NULL, NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Produccion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las pantallas nuevas -----------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild)
     VALUES
         ('MovimientosDeProduccion', 'Movimientos de Produccion', 'Movimientos de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 10, 'Eniac.Win', 'MovimientosDeProduccion', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovimientosDeProduccion' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
     VALUES
         ('InfProduccion', 'Informe de Produccion', 'Informe de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 20, 'Eniac.Win', 'InfProduccion', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProduccion' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild)
     VALUES
         ('CalculoProduccion', 'Calculo de Produccion', 'Calculo de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 30, 'Eniac.Win', 'CalculoProduccion', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CalculoProduccion' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo,EsMDIChild)
     VALUES
         ('ProductosComponentes', 'Componentes de Productos', 'Componentes de Productos', 'True', 'False', 'True', 'True', 
          'Produccion' , 40, 'Eniac.Win', 'ProductosComponentes' , NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosComponentes' AS Pantalla FROM Roles
GO

-----------------------------------------------------------------------------------------------
--    PRINT ''
--    PRINT '4.2. Permisos Funcion: Pedidos Permite Modificar Descuento/Recargo del Producto'
--	INSERT INTO RolesFunciones (IdRol,IdFuncion)
--    SELECT IdRol, 'Pedidos-ModifDescRecProd' FROM RolesFunciones WHERE IdFuncion = 'Facturacion-ModifDescRecProd'
--END
