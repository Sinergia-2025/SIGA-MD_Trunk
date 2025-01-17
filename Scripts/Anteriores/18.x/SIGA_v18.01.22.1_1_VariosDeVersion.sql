
PRINT ''
PRINT '1. Menu Nuevo: Pedidos Proveedores\Desvincular Pedidos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PedidosProv')
	BEGIN
		--Inserto la pantalla nueva
		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('DesvincularPedidos', 'Desvincular Pedidos', 'Desvincular Pedidos', 'True', 'False', 'True', 'True',
			  'PedidosProv', 110, 'Eniac.Win', 'DesvincularPedidos', NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'DesvincularPedidos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

	END;


PRINT ''
PRINT '2. Tabla EstadosPedidosProveedores: Agregar Campos TipoEstadoPedidoCliente / IdEstadoPedidoCliente y FK.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD TipoEstadoPedidoCliente varchar(15) NULL
ALTER TABLE dbo.EstadosPedidosProveedores ADD IdEstadoPedidoCliente varchar(10) NULL
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD CONSTRAINT FK_EstadosPedidosProveedores_EstadosPedidos
    FOREIGN KEY (IdEstadoPedidoCliente,TipoEstadoPedidoCliente)
    REFERENCES dbo.EstadosPedidos (idEstado,TipoEstadoPedido)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla EstadosPedidosProveedores: Agregar campos IdTipoMovimiento/StockAfectado y FK.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposMovimientos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD IdTipoMovimiento varchar(15) NULL;
ALTER TABLE dbo.EstadosPedidosProveedores ADD StockAfectado varchar(20) NULL;
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD CONSTRAINT FK_EstadosPedidosProveedores_TiposMovimientos
    FOREIGN KEY (IdTipoMovimiento) REFERENCES dbo.TiposMovimientos (IdTipoMovimiento) ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.EstadosPedidosProveedores DROP COLUMN IncrementaStockFuturo
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Menu Nuevo: PedidosProv\Vincular Pedidos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'PedidosProv')
	BEGIN
		--Inserto la pantalla nueva
		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('VincularPedidos', 'Vincular Pedidos', 'Vincular Pedidos', 'True', 'False', 'True', 'True',
			  'PedidosProv', 100, 'Eniac.Win', 'VincularPedidos', NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'VincularPedidos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

	END;


PRINT ''
PRINT '5. Tabla PedidosEstados: Agregar varios campos para Vinculacion.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstadosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD IdSucursalVinculado int NULL
ALTER TABLE dbo.PedidosEstados ADD IdTipoComprobanteVinculado varchar(15) NULL
ALTER TABLE dbo.PedidosEstados ADD LetraVinculado varchar(1) NULL
ALTER TABLE dbo.PedidosEstados ADD CentroEmisorVinculado int NULL
ALTER TABLE dbo.PedidosEstados ADD NumeroPedidoVinculado bigint NULL
ALTER TABLE dbo.PedidosEstados ADD IdProductoVinculado varchar(15) NULL
ALTER TABLE dbo.PedidosEstados ADD OrdenVinculado int NULL
ALTER TABLE dbo.PedidosEstados ADD FechaEstadoVinculado datetime NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_PedidosEstadosProveedores
    FOREIGN KEY (IdSucursalVinculado,IdTipoComprobanteVinculado,LetraVinculado,CentroEmisorVinculado,NumeroPedidoVinculado,IdProductoVinculado,OrdenVinculado,FechaEstadoVinculado)
    REFERENCES dbo.PedidosEstadosProveedores (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroPedido,IdProducto,Orden,FechaEstado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '6. Nueva Funciones CuentasCorrientes\Generar Débitos Automáticos.'
GO

-- Si es el CUIT de Generico/RDS/RDS ACE.

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '30714107220', '30714757128'))
BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
	 VALUES
	   ('ClientesRecepDebitosAuto', 'Recepción Débitos Automáticos', 'Recepción Débitos Automáticos', 
	    'True', 'False', 'True', 'True', 'CuentasCorrientes', 23, 'Eniac.Win', 'ClientesRecepDebitosAutomaticos', null)
	;

	INSERT INTO RolesFunciones 
	              (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ClientesRecepDebitosAuto' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;


PRINT ''
PRINT '7. Tabla EstadosPedidosProveedores: Agregar Campo IdEstadoDestino.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD IdEstadoDestino varchar(10) NULL
GO
ALTER TABLE dbo.EstadosPedidosProveedores ADD CONSTRAINT FK_EstadosPedidosProveedores_EstadosPedidosProveedores
    FOREIGN KEY (IdEstadoDestino,TipoEstadoPedido)
    REFERENCES dbo.EstadosPedidosProveedores (IdEstado,TipoEstadoPedido)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '8. Nuevo Parametros de Reserva de Stock.'
GO

-- Generico/Plumas Aloe
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                      AND P.ValorParametro IN ('50000000024', '23238857449'))
BEGIN
    IF NOT EXISTS (SELECT * FROM [EstadosPedidos] WHERE [idEstado] = 'RES.FUTURO')
        INSERT [dbo].[EstadosPedidos] ([idEstado], [IdTipoComprobante], [IdTipoEstado], [Orden], [AfectaPendiente], [TipoEstadoPedido], [Color], [ReservaStock]) 
            VALUES ('RES.FUTURO', NULL, 'ENTREGADO', 90, 0, 'PEDIDOSCLIE', -10046004, 0)

    IF NOT EXISTS (SELECT * FROM [EstadosPedidos] WHERE [idEstado] = 'RESERVAR')
        INSERT [dbo].[EstadosPedidos] ([idEstado], [IdTipoComprobante], [IdTipoEstado], [Orden], [AfectaPendiente], [TipoEstadoPedido], [Color], [ReservaStock]) 
            VALUES ('RESERVAR', NULL, 'EN PROCESO', 15, 0, 'PEDIDOSCLIE', -32640, 1)

    IF NOT EXISTS (SELECT * FROM [EstadosPedidosProveedores] WHERE [idEstado] = 'EN AGUA')
        INSERT [dbo].[EstadosPedidosProveedores] ([IdEstado], [IdTipoComprobante], [IdTipoEstado], [Orden], [TipoEstadoPedido], [Color], [TipoEstadoPedidoCliente], [IdEstadoPedidoCliente], [IdTipoMovimiento], [StockAfectado], [IdEstadoDestino]) 
            VALUES ('EN AGUA', NULL, 'EN PROCESO', 15, 'PEDIDOSPROV', -986896, NULL, NULL, 'AJUSTE', 'FUTURO', NULL)

    IF NOT EXISTS (SELECT * FROM [EstadosPedidosProveedores] WHERE [idEstado] = 'RESERVADO')
        INSERT [dbo].[EstadosPedidosProveedores] ([IdEstado], [IdTipoComprobante], [IdTipoEstado], [Orden], [TipoEstadoPedido], [Color], [TipoEstadoPedidoCliente], [IdEstadoPedidoCliente], [IdTipoMovimiento], [StockAfectado], [IdEstadoDestino]) 
            VALUES ('RESERVADO', NULL, 'EN PROCESO', 90, 'PEDIDOSPROV', -10046004, NULL, NULL, 'AJUSTE', 'FUTURORESERVADO', NULL)
END
