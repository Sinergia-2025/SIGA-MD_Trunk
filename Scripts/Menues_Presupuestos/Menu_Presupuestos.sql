
--Elimino los menues anteriores.

DELETE [dbo].Bitacora WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Presupuestos' OR IdPadre='Presupuestos'
)
GO

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Presupuestos' OR IdPadre='Presupuestos'
)
GO

DELETE [dbo].[Funciones]
 WHERE IdPadre='Presupuestos'
GO

DELETE [dbo].[Funciones]
 WHERE id='Presupuestos'
GO


--Inserto el Menu nuevo

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
  VALUES
    ('Presupuestos', 'Presupuestos', '', 'True', 'False', 'True', 'True',
     NULL, 3, NULL, NULL, NULL, NULL
	 ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Presupuestos' AS Pantalla FROM [dbo].Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('PresupuestosClientesV2', 'Presupuestos de Clientes', 'Presupuestos de Clientes', 'True', 'False', 'True', 'True', 
          'Presupuestos', 10, 'Eniac.Win', 'PedidosClientesV2', NULL, 'PRESUPCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PresupuestosClientesV2' AS Pantalla FROM [dbo].Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('ConsultarPresupuestos', 'Consultar Presupuestos', 'Consultar Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 20, 'Eniac.Win', 'ConsultarPedidos', NULL, 'PRESUPCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPresupuestos' AS Pantalla FROM [dbo].Roles
WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('AnularPresupuestos', 'Anular Presupuestos', 'Anular Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 30, 'Eniac.Win', 'AnularPedidos', NULL, 'PRESUPCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')

GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnularPresupuestos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-----------------

-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('PresupuestosAdmin', 'Administración Presupuestos', 'Administración Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 40, 'Eniac.Win', 'PedidosAdmin', NULL, 'PRESUPCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PresupuestosAdmin' AS Pantalla FROM [dbo].Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('EstadosPresupuestosABM', 'ABM Estados de Presupuestos', 'ABM Estados de Presupuestos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 50, 'Eniac.Win', 'EstadosPedidosABM', NULL, 'PRESUPCLIE\PEDIDOSCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosPresupuestosABM' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--InfPedidosDetallados

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('InfPresupuestosDetallados', 'Inf. de Presupuestos Detallado', 'Inf. de Presupuestos Detallado', 'True', 'False', 'True', 'True', 
          'Presupuestos', 60, 'Eniac.Win', 'InfPedidosDetallados', NULL, 'PRESUPCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPresupuestosDetallados' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
     VALUES
         ('InfPresupuestosSumaPorProducto', 'Inf. de Presupuestos Suma por Productos', 'Inf. de Presupuestos Suma por Productos', 'True', 'False', 'True', 'True', 
          'Presupuestos', 70, 'Eniac.Win', 'InfPedidosSumaPorProductos', NULL, 'PRESUPCLIE'
		  ,'True', 'S', 'N', 'N', 'N', 'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPresupuestosSumaPorProducto' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-----

DECLARE @idAplicacion varchar(MAX)
SET @idAplicacion = (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'IDAPLICACION')

DELETE FROM Traducciones WHERE Control IN 
    ('__NoSeleccionoPedido', '__AnulacionPedidoExitosa', '__FaltaNumeroPedido', '__CambioEstadoMasivo',
     '__ErrorCambioMasivoNoPermitido', '__ErrorEstadoNoPermiteCambio', '__ErrorDebeCambiarEstado',
     '__ConfirmarCambioEstado', '__NoSeleccionoPedidoModificar', '__ErrorFechaEntregaPedidoInvalida',
     '__ErrorFechaEntregaInvalida', '__PedidoNoSuministrado')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('AnularPresupuestos','','__NoSeleccionoPedido','es_AR',
            'ATENCION: NO Seleccionó Ningún Presupuesto para Anular!!')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('AnularPresupuestos','','__AnulacionPedidoExitosa','es_AR',
            '¡¡¡ Presupuesto/s Anulado/s Exitosamente !!!')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'','__FaltaNumeroPedido','es_AR',
            'ATENCION: NO Ingresó un Número de Presupuesto aunque activó ese Filtro.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__CambioEstadoMasivo','es_AR',
            '¿Desea cambiar masivamente el Estado actual de los Presupuestos Seleccionados al Estado: {0}?')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ErrorCambioMasivoNoPermitido','es_AR',
            'Presupuesto: {0}-->El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto o cambiar Criticidad/Fecha de Entrega.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ErrorEstadoNoPermiteCambio','es_AR',
            'Presupuesto: {0} --> El Estado Actual NO permite cambio.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__NoSeleccionoPedido','es_AR',
            'Debe seleccionar un Presupuesto para cambiar el Estado.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ErrorDebeCambiarEstado','es_AR',
            'El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ConfirmarCambioEstado','es_AR',
            '¿Desea cambiar el Estado actual del Presupuesto - {0} - al Estado: {1}?')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__NoSeleccionoPedidoModificar','es_AR',
            'Por favor seleccione un Presupuesto.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__ConfirmarNuevoComprobante','es_AR',
            'ATENCION: ¿Desea Realizar un Presupuesto Nuevo?')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__PedidoNoSuministrado','es_AR',
            'Debe pasar un Presupuesto a modificar.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__ErrorFechaEntregaInvalida','es_AR',
            'La Fecha de Entrega del producto (Código {0}) es menor a la Fecha del Presupuesto ({1:dd/MM/yyyy}).')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__ErrorFechaEntregaPedidoInvalida','es_AR',
            'La Fecha de Entrega es menor a la Fecha del Presupuesto ({0:dd/MM/yyyy}.')
;

----

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'ConsultarPresupuestos')
BEGIN
	PRINT ''
	PRINT '2. Seguridad a Consultar Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)

         VALUES
             ('ConsultarPresupuestos-VerPre', 'Ver Precios en Consultar Presupuestos', 'Ver Precios en Consultar Presupuestos', 'False', 'False', 'True', 'True', 
              'ConsultarPresupuestos', 999, 'Eniac.Win', 'ConsultarPresupuestos-VerPre', NULL, NULL
			  ,'True', 'S', 'N', 'N', 'N', 'True');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ConsultarPresupuestos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPresupuestos';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PresupuestosAdmin')
BEGIN
	PRINT ''
	PRINT '4. Seguridad a Admin Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
         VALUES
             ('PresupuestosAdmin-VerPre', 'Ver Precios en Admin Presupuestos', 'Ver Precios en Admin Presupuestos', 'False', 'False', 'True', 'True', 
              'PresupuestosAdmin', 999, 'Eniac.Win', 'PresupuestosAdmin-VerPre', NULL, NULL
			   ,'True', 'S', 'N', 'N', 'N', 'True');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PresupuestosAdmin-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'PresupuestosAdmin';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Presupuestos')
BEGIN
	PRINT ''
	PRINT '6. Seguridad a Impresion Presupuestos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
         VALUES
             ('ImpresionPresupuestos-VerPre', 'Ver Precios en Impresion Presupuestos', 'Ver Precios en Impresion Presupuestos', 'False', 'False', 'True', 'True', 
              'Presupuestos', 999, 'Eniac.Win', 'ImpresionPresupuestos-VerPre', NULL, NULL
			  ,'True', 'S', 'N', 'N', 'N', 'True');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImpresionPresupuestos-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'ConsultarPresupuestos';
END;

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfPresupuestosSumaPorProducto')
BEGIN
	PRINT ''
	PRINT '8. Seguridad a Inf. Presupuestos Suma Por Productos'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
         VALUES
             ('InfPreSumaPorProducto-VerPre', 'Ver Precios en Inf.Presup.Suma Por Productos', 'Ver Precios en Inf.Presup.Suma Por Productos', 'False', 'False', 'True', 'True', 
              'InfPresupuestosSumaPorProducto', 999, 'Eniac.Win', 'InfPreSumaPorProducto-VerPre', NULL, NULL
			  ,'True', 'S', 'N', 'N', 'N', 'True');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfPreSumaPorProducto-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'InfPresupuestosSumaPorProducto';
END;

----

PRINT ''
PRINT '8. Nueva Funcion Presupuestos\ModificarPedidos.'
GO

-- Si tiene modulo Pedidos

IF EXISTS (SELECT * FROM Funciones F WHERE F.Id = 'Presupuestos')
BEGIN
	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
	 VALUES
	   ('ModificarPresupuesto', 'Modificar Presupuestos', 'Modificar Presupuestos', 'True', 'False', 'True', 'True', 
        'Presupuestos', 25, 'Eniac.Win', 'AnularPedidos', null, 'PRESUPCLIE|MODIFICAR',
        'True', 'S', 'S', 'N', 'N', 'True')
	;
	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT IdRol, 'ModificarPresupuesto' AS Pantalla FROM dbo.RolesFunciones
		WHERE IdFuncion = 'PresupuestosAdmin'
	;
END;

----


PRINT ''
PRINT '2. Traducción: Modificar Presupuesto'
GO

IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'ModificarPresupuesto')
BEGIN
    INSERT Traducciones (IdFuncion, Pantalla, Control, IdIdioma, Texto) 
      VALUES 
		     ('ModificarPresupuesto', '', 'chbIdPedido', 'es_AR', 'Presupuesto'),   
		     ('ModificarPresupuesto', '', 'Me', 'es_AR', 'Modificar Presupuestos')   
END;

---

PRINT ''
PRINT '2. Parametro: Pedidos/Presupuestos: Mostrar el combo de Criticidad'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSMOSTRARCRITICIDAD'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedidos/Presupuestos: Mostrar el combo de Criticidad'
DECLARE @valorParametro VARCHAR(MAX) = 'True'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

--Agrego en las traducciones

INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('AnularPresupuestos','','__AnulacionPedidoExitosa','es_AR','¡¡¡ Presupuesto/s Anulado/s Exitosamente !!!');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('AnularPresupuestos','','__NoSeleccionoPedido','es_AR','ATENCION: NO Seleccionó Ningún Presupuesto para Anular!!');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('AnularPresupuestos','','Me','es_AR','Anular Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('ConsultarPresupuestos','','Me','es_AR','Consultar Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('ConsultarPresupuestosProv','','Me','es_AR','Consultar Presupuestos Proveedor');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('EstadosPresupuestosABM','EstadosPedidosABM','Me','es_AR','Estados Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('EstadosPresupuestosABM','EstadosPedidosDetalle','Me','es_AR','Estado de Presupuesto');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('InfPresupSumaPorProductosProv','','Me','es_AR','Inf. de Presupuesto Proveedor Suma por Productos Prov');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('InfPresupuestosDetallados','','FechaPedido','es_AR','Fecha Presupuesto');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('InfPresupuestosDetallados','','Me','es_AR','Informe de Presupuestos Detallados');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('InfPresupuestosSumaPorProducto','','Me','es_AR','Informe de Presupuestos Suma por Productos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('ModificarPresupuesto','','chbIdPedido','es_AR','Presupuesto');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('ModificarPresupuesto','','Me','es_AR','Modificar Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__CambioEstadoMasivo','es_AR','¿Desea cambiar masivamente el Estado actual de los Presupuestos Seleccionados al Estado: {0}?');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__ConfirmarCambioEstado','es_AR','¿Desea cambiar el Estado actual del Presupuesto - {0} - al Estado: {1}?');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__ErrorCambioMasivoNoPermitido','es_AR','Presupuesto: {0}-->El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto o cambiar Criticidad/Fecha de Entrega.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__ErrorDebeCambiarEstado','es_AR','El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__ErrorEstadoNoPermiteCambio','es_AR','Presupuesto: {0} --> El Estado Actual NO permite cambio.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__NoSeleccionoPedido','es_AR','Debe seleccionar un Presupuesto para cambiar el Estado.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','__NoSeleccionoPedidoModificar','es_AR','Por favor seleccione un Presupuesto.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','FechaPedido','es_AR','Fecha Presup.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','Me','es_AR','Administración de Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','NumeroPedido','es_AR','Presupuesto');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','','tsbModificarPedido','es_AR','Modificar Presupuesto');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','PedidosClientesV2','__ConfirmarNuevoComprobante','es_AR','ATENCION: ¿Desea Realizar un Presupuesto Nuevo?');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','PedidosClientesV2','__ErrorFechaEntregaInvalida','es_AR','La Fecha de Entrega del producto (Código {0}) es menor a la Fecha del Presupuesto ({1:dd/MM/yyyy}).');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','PedidosClientesV2','__ErrorFechaEntregaPedidoInvalida','es_AR','La Fecha de Entrega es menor a la Fecha del Presupuesto ({0:dd/MM/yyyy}.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','PedidosClientesV2','__PedidoNoSuministrado','es_AR','Debe pasar un Presupuesto a modificar.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosAdmin','PedidosClientesV2','Me','es_AR','Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosClientesV2','PedidosClientesV2','__ConfirmarNuevoComprobante','es_AR','ATENCION: ¿Desea Realizar un Presupuesto Nuevo?');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosClientesV2','PedidosClientesV2','__ErrorFechaEntregaInvalida','es_AR','La Fecha de Entrega del producto (Código {0}) es menor a la Fecha del Presupuesto ({1:dd/MM/yyyy}).');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosClientesV2','PedidosClientesV2','__ErrorFechaEntregaPedidoInvalida','es_AR','La Fecha de Entrega es menor a la Fecha del Presupuesto ({0:dd/MM/yyyy}.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosClientesV2','PedidosClientesV2','__PedidoNoSuministrado','es_AR','Debe pasar un Presupuesto a modificar.');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('PresupuestosClientesV2','PedidosClientesV2','Me','es_AR','Presupuestos');
INSERT INTO [dbo].[Traducciones] ([IdFuncion],[Pantalla],[Control],[IdIdioma],[Texto]) VALUES ('SIGA','','__FaltaNumeroPedido','es_AR','ATENCION: NO Ingresó un Número de Presupuesto aunque activó ese Filtro.');




