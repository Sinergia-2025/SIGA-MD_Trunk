PRINT ''
PRINT '2. Menu: Presupuesto a Proveedor'
IF dbo.ExisteFuncion('PresupuestosProv') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('PresupuestosProv', 'Presupuestos Prov.', 'Presupuestos Proveedor', 'True', 'False', 'True', 'True'
        ,NULL, 24, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('PresupuestosProv') = 1 AND dbo.ExisteFuncion('PresupuestosProveedor') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('PresupuestosProveedor', 'Presupuesto a Proveedor', 'Presupuesto a Proveedor', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 10, 'Eniac.Win', 'PedidosProveedores', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('ConsultarPresupuestosProv', 'Consultar Presupuesto Proveedores', 'Consultar Presupuesto Proveedores', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 20, 'Eniac.Win', 'ConsultarPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('AnularPresupuestosProv', 'Anular Presupuesto Proveedores', 'Anular Presupuesto Proveedores', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 30, 'Eniac.Win', 'AnularPedidosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('PresupuestosAdminProv', 'Administracion de Presupuesto Prov', 'Administracion de Presupuesto Prov', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 40, 'Eniac.Win', 'PedidosAdminProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('EstadoPresupuestosProvABM', 'ABM Estados de Presupuesto Proveedores', 'ABM Estados de Presupuesto Proveedores', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 50, 'Eniac.Win', 'EstadosPedidosProvABM', NULL, 'PRESUPPROV\,PEDIDOSPROV'
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfPresupuestosDetalladosProv', 'Inf. de Presupuesto Detallado Prov', 'Inf. de Presupuesto Detallado Prov', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 60, 'Eniac.Win', 'InfPedidosDetalladosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('InfPresupSumaPorProductosProv', 'Inf. de Presupuesto Suma por Productos Prov', 'Inf. de Presupuesto Suma por Productos Prov', 'True', 'False', 'True', 'True'
        ,'PresupuestosProv', 70, 'Eniac.Win', 'InfPedidosSumaPorProductosProv', NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('ConsultarPresupuestosProv') = 1 AND dbo.ExisteFuncion('ConsultarPresupProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConsultarPresupProv-VerPre', 'Ver Precios en Consultar Pedidos', 'Ver Precios en Consultar Pedidos', 'False', 'False', 'True', 'True'
        ,'ConsultarPresupuestosProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('InfPresupuestosDetalladosProv') = 1 AND dbo.ExisteFuncion('InfPresupDetalladosProv-VerPre') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfPresupDetalladosProv-VerPre', 'Ver Precios en Inf.Ped.Suma Por Productos', 'Ver Precios en Inf.Ped.Suma Por Productos', 'False', 'False', 'True', 'True'
        ,'InfPresupuestosDetalladosProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END
IF dbo.ExisteFuncion('PresupuestosAdminProv') = 1 AND dbo.ExisteFuncion('PresupuestosAdminProv-Modif') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('PresupuestosAdminProv-Modif', 'Modif. Pedidos', 'Modif. Pedidos', 'False', 'False', 'True', 'True'
        ,'PresupuestosAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True'),
        ('PresupuestosAdminProv-VerPre', 'Ver Precios en Admin Pedidos', 'Ver Precios en Admin Pedidos', 'False', 'False', 'True', 'True'
        ,'PresupuestosAdminProv', 999, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'X', 'N', 'N', 'N', 'True')
END

UPDATE Funciones
   SET Parametros = 'PRESUPPROV'
 WHERE IdPadre = 'PresupuestosProv'
   AND ISNULL(Parametros, '') = ''

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT R.Id IdRol, F.Id IdFuncion
  FROM Funciones F
 CROSS JOIN (SELECT * FROM Roles WHERE Id IN ('Adm', 'Supervisor', 'Oficina')) R
 WHERE F.Plus = 'X'
   AND NOT EXISTS (SELECT * FROM RolesFunciones RF WHERE RF.IdRol = R.Id AND RF.IdFuncion = F.Id)

UPDATE Funciones
   SET Plus = 'S'
 WHERE Plus = 'X'

