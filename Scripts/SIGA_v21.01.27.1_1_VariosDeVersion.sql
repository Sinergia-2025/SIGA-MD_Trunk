PRINT ''
PRINT '1. Menu: ABM  de Tipos Estados Novedades'
IF dbo.ExisteFuncion('CRMTiposEstadosNovedades') = 0 AND dbo.ExisteFuncion('CRM') = 1
BEGIN
    PRINT ''
    PRINT '1.1. Menu: Crear función ABM  de Tipos Estados Novedades'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CRMTiposEstadosNovedades', 'ABM  de Tipos Estados Novedades', 'Tipos Estados Novedades', 'True', 'False', 'True', 'True'
        ,'CRM', 595, 'Eniac.Win', 'CRMTiposEstadosNovedadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '1.2. Menu: Roles para ABM  de Tipos Estados Novedades'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMTiposEstadosNovedades' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Menu: Función de Seguridad para Alerta: Mostrar alerta de Pedidos Sin Facturar'
IF dbo.ExisteFuncion('Pedidos') = 1
BEGIN
    PRINT ''
    PRINT '2.1. Menu: Crar función de Seguridad para Alerta: Mostrar alerta de Pedidos Sin Facturar'
	INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Pedidos-PedidosSinFacturar', 'Pedidos-PedidosSinFacturar', 'Pedidos-PedidosSinFacturar', 'False', 'False', 'True', 'False'
        ,'Pedidos', 999, 'Eniac.Win', 'Pedidos-PedidosSinFacturar', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
    
    PRINT ''
    PRINT '2.2. Menu: Roles para función de Seguridad para Alerta: Mostrar alerta de Pedidos Sin Facturar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Pedidos-PedidosSinFacturar' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '3. Menú: Función de Seguridad para Alerta: Mostrar alerta de Remitos Sin Facturar'
IF dbo.ExisteFuncion('Ventas') = 1
BEGIN
    PRINT ''
    PRINT '3.1. Menú: Crear función de Seguridad para Alerta: Mostrar alerta de Remitos Sin Facturar'
	INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Remitos-RemitosSinFacturar', 'Remitos-RemitosSinFacturar', 'Remitos-RemitosSinFacturar', 'False', 'False', 'True', 'False'
        ,'Ventas', 999, 'Eniac.Win', 'Remitos-RemitosSinFacturar', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
    
    PRINT ''
    PRINT '3.2. Menú: Roles para función de Seguridad para Alerta: Mostrar alerta de Remitos Sin Facturar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Remitos-RemitosSinFacturar' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '4. Tableros de comando para HAR Group'
IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '4.1. Tablas TablerosControlPaneles: Paneles para HAR Group'
    INSERT [dbo].[TablerosControlPaneles] ([IdTableroControlPanel], [NombrePanel], [Parametros], [IdController]) 
        VALUES (57, 'Global de Entregas de Soporte', 'TICKETS', 'Eniac.Win.GrillaCRMGlobalEntrega'),
               (58, 'Global de Entregas de Desarrollo', 'PENDIENTE', 'Eniac.Win.GrillaCRMGlobalEntrega'),
               (59, 'Historico de Entregas de Soporte', 'TICKETS', 'Eniac.Win.GrillaCRMGlobalEntregaHistorico'),
               (60, 'Historico de Entregas de Desarrollo', 'PENDIENTE', 'Eniac.Win.GrillaCRMGlobalEntregaHistorico')
    PRINT ''
    PRINT '4.2. Tablas TablerosControl: Tableros para HAR Group'
    INSERT [dbo].[TablerosControl] ([IdTableroControl], [NombreTableroControl], [IdTableroControlPanel1], [IdTableroControlPanel2], [IdTableroControlPanel3], [IdTableroControlPanel4], [IdTableroControlPanel5], [IdTableroControlPanel6]) 
        VALUES (5, 'Global de Entregas de Soporte', 57, 59, NULL, NULL, NULL, NULL),
               (6, 'Global de Entregas de Desarrollo', 58, 60, NULL, NULL, NULL, NULL)

    PRINT ''
    PRINT '4.3. Crear Menu: Performance de Soporte desde TableroDeComandox3'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_globalsopo', 'Global de Entregas de Soporte', 'Global de Entregas de Soporte', EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, 140, Archivo, Pantalla, Icono, 'Tablero=5'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandox2'
    
    PRINT ''
    PRINT '4.4. Roles Menu: Performance de Soporte'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_globalsopo' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando_entregasopo'


    PRINT ''
    PRINT '4.5. Crear Menu: Performance de Desarrollo desde TableroDeComandox3'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_globaldesa', 'Global de Entregas de Desarrollo', 'Global de Entregas de Desarrollo', EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, 150, Archivo, Pantalla, Icono, 'Tablero=6'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandox2'
    
    PRINT ''
    PRINT '4.6. Roles Menu: Performance de Desarrollo'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_globaldesa' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando_entregadesa'
END

PRINT ''
PRINT '5. Tabla TablerosControl: Nuevo campo IdControllerFiltro'
ALTER TABLE dbo.TablerosControl ADD IdControllerFiltro varchar(200) NULL
GO
PRINT ''
PRINT '5.1 Tabla TablerosControl: Valores historicos de IdControllerFiltro'
UPDATE TablerosControl SET IdControllerFiltro = '';
PRINT ''
PRINT '5.2 Tabla TablerosControl: NOT NULL para IdControllerFiltro'
ALTER TABLE dbo.TablerosControl ALTER COLUMN IdControllerFiltro varchar(200) NOT NULL
GO
PRINT ''
PRINT '5.3 Tabla TablerosControl: Valores historicos de IdControllerFiltro de HAR'
UPDATE TablerosControl
   SET IdControllerFiltro = 'Eniac.Win.FiltroTableros_CategoriaActualiza'
 WHERE IdTableroControl < 3


PRINT ''
PRINT '6. Tableros de comando para Balanmac'
IF dbo.BaseConCuit('27201734687') = 1
BEGIN
    PRINT ''
    PRINT '6.1. Tablas TablerosControlPaneles: Paneles para Balanmac'
    INSERT [dbo].[TablerosControlPaneles] ([IdTableroControlPanel], [NombrePanel], [Parametros], [IdController]) 
        VALUES (103, 'Global de Entregas de Servicio Técnico', 'SERVICE;INGRESADOS,REPARADOS,ENTREGADOS,TRP,TEP,CRP', 'Eniac.Win.GrillaCRMGlobalEntrega'),
               (104, 'Historico de Entregas de Servicio Técnico', 'SERVICE;INGRESADOS,REPARADOS,ENTREGADOS,TRP,TEP,CRP', 'Eniac.Win.GrillaCRMGlobalEntregaHistorico')
    PRINT ''
    PRINT '6.2. Tablas TablerosControl: Tableros para Balanmac'
    INSERT [dbo].[TablerosControl] ([IdTableroControl], [NombreTableroControl], [IdTableroControlPanel1], [IdTableroControlPanel2], [IdTableroControlPanel3], [IdTableroControlPanel4], [IdTableroControlPanel5], [IdTableroControlPanel6], [IdControllerFiltro]) 
        VALUES (101, 'Global de Entregas de Servicio Técnico', 103, 104, NULL, NULL, NULL, NULL, '')

    PRINT ''
    PRINT '6.3. Crear Menu: Performance de Soporte desde TableroDeComandox3'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    SELECT  'TableroDeComando_global', 'Global de Entregas de Servicio Técnico', 'Global de Entregas de Servicio Técnico', EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, 20, Archivo, Pantalla, Icono, 'Tablero=101'
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV
      FROM Funciones
     WHERE Id = 'TableroDeComandox2'
    
    PRINT ''
    PRINT '6.4. Roles Menu: Performance de Soporte'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'TableroDeComando_global' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando_tecnicos'
END


PRINT ''
PRINT '8. Corrección de registros pre-existentes'
INSERT INTO CuentasCorrientesTransferencias (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Orden, Importe, IdCuentaBancaria)
SELECT 
	CC.IdSucursal, 
	CC.IdTipoComprobante, 
	CC.Letra, 
	CC.CentroEmisor, 
	CC.NumeroComprobante, 
	1, 
    CC.ImporteTransfBancaria, 
    CC.IdCuentaBancaria
FROM CuentasCorrientes CC WHERE 1=1 
	AND ImporteTransfBancaria <> 0
	AND NOT EXISTS(SELECT * FROM CuentasCorrientesTransferencias CCT 
					WHERE CC.IdSucursal = CCT.IdSucursal
					  AND CC.IdTipoComprobante = CCT.IdTipoComprobante
					  AND CC.Letra = CCT.Letra
					  AND CC.CentroEmisor = CCT.CentroEmisor
					  AND CC.NumeroComprobante = CCT.NumeroComprobante)
GO

PRINT ''
PRINT '8.1. Corrección de la relación entre LibrosBancos y CCTransferencias en los registros pre-existentes'
UPDATE CCT SET 
	   CCT.IdSucursalLibroBanco = Z.IdSucursalBanco,
	   CCT.IdCuentaBancariaLibroBanco = Z.IdCuentaBancaria,
	   CCT.NumeroMovimientoLibroBanco = Z.NumeroMovimiento 
FROM CuentasCorrientesTransferencias CCT 
INNER JOIN (
	SELECT LB.IdSucursal IdSucursalBanco, LB.IdCuentaBancaria, LB.NumeroMovimiento, X.IdSucursal, X.IdTipoComprobante, X.Letra, X.CentroEmisor, X.NumeroComprobante
	FROM (SELECT 
		 	CC.IdSucursal, 
		 	CC.IdTipoComprobante,
			TC.Descripcion, 
		 	CC.Letra, 
		 	CC.CentroEmisor, 
		 	CC.NumeroComprobante 
		   FROM CuentasCorrientes CC 
		   INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante WHERE ImporteTransfBancaria <> 0) X 
	INNER JOIN LibrosBancos LB ON
	LTRIM(LB.Observacion) LIKE (LTRIM(X.Descripcion) + ' ' + X.Letra + ' '+ CONVERT(VARCHAR,X.CentroEmisor) + '-' + RIGHT('00000000' + CONVERT(VARCHAR(MAX),X.NumeroComprobante),8) + ' - Transf. a Cuenta.')+ '%' ) Z 
	ON	CCT.IdSucursal = Z.IdSucursal 
	AND CCT.IdTipoComprobante = Z.IdTipoComprobante
	AND CCT.Letra = Z.Letra
	AND CCT.CentroEmisor = Z.CentroEmisor
	AND CCT.NumeroComprobante = Z.NumeroComprobante
WHERE CCT.IdSucursalLibroBanco IS NULL
GO
