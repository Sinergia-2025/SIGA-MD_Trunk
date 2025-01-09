PRINT ''
PRINT 'C1. Nuevos campos Ordenes Produccion Productos'
IF dbo.ExisteCampo('OrdenesProduccionProductos', 'IdSucursalPedido') = 0
BEGIN
	ALTER TABLE OrdenesProduccionProductos ADD IdSucursalPedido int NULL
	ALTER TABLE OrdenesProduccionProductos ADD IdTipoComprobantePedido varchar(15) NULL
	ALTER TABLE OrdenesProduccionProductos ADD LetraPedido varchar(1) NULL
	ALTER TABLE OrdenesProduccionProductos ADD CentroEmisorPedido int NULL
	ALTER TABLE OrdenesProduccionProductos ADD NumeroPedido int NULL
	ALTER TABLE OrdenesProduccionProductos ADD IdProductoPedido varchar(15) NULL
	ALTER TABLE OrdenesProduccionProductos ADD OrdenPedido int NULL

	ALTER TABLE OrdenesProduccionProductos  
			WITH CHECK ADD  CONSTRAINT FK_OrdenesProduccionProductos_PedidosProductos 
			FOREIGN KEY(IdSucursalPedido, NumeroPedido, IdProductoPedido, OrdenPedido, IdTipoComprobantePedido, LetraPedido, CentroEmisorPedido)
			REFERENCES PedidosProductos (IdSucursal, NumeroPedido, IdProducto, Orden, IdTipoComprobante, Letra, CentroEmisor)

	ALTER TABLE OrdenesProduccionProductos CHECK CONSTRAINT FK_OrdenesProduccionProductos_PedidosProductos
END
GO

UPDATE Funciones
   SET Parametros = 'TipoTipoComprobante=' + Parametros
 WHERE Pantalla IN ('PedidosAdminProvV2', 'PedidosAdminProv')
   AND ISNULL(Parametros, '') <> ''
   AND NOT ISNULL(Parametros, '') LIKE 'TipoTipoComprobante=%'
GO

UPDATE Funciones
   SET Parametros = Parametros + ';PermitePrecioCero=SI'
 WHERE Pantalla IN ('PedidosAdminProvV2', 'PedidosAdminProv')
   AND ISNULL(Parametros, '') <> ''
   AND ISNULL(Parametros, '') LIKE '%PRESUPPROV%'
   AND NOT ISNULL(Parametros, '') LIKE '%PermitePrecioCero%'
GO

-- Sem / HAR / GAR Limpieza

IF dbo.BaseConCuit(30708470550) = 0 AND dbo.BaseConCuit(33711345499) = 0 AND dbo.BaseConCuit(20244785922) = 0
BEGIN

	DECLARE @Menu varchar(255) = 'xx'
	DECLARE @Pantalla varchar(255) = 'xx'

	--

	SET @Menu = 'MRP'
	
	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Funciones WHERE Id = @Menu or IdPadre = @Menu ;

	---

	SET @Menu = 'RequerimientosCompras'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Funciones WHERE Id = @Menu or IdPadre = @Menu ;

	---
	
	SET @Pantalla = 'ConsultarPresupuestosProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Funciones WHERE Id = @Pantalla or IdPadre = @Pantalla ;

	---
	
	SET @Pantalla = 'PresupuestosAdminProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Funciones WHERE Id = @Pantalla or IdPadre = @Pantalla ;

	---
		
	SET @Pantalla = 'InfPresupuestosDetalladosProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Funciones WHERE Id = @Pantalla or IdPadre = @Pantalla ;

	---

	SET @Menu = 'PresupuestosProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Funciones WHERE Id = @Menu or IdPadre = @Menu ;

	---

	SET @Pantalla = 'ConsultarOCProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Funciones WHERE Id = @Pantalla or IdPadre = @Pantalla ;

	---
	
	SET @Pantalla = 'OrdenCompraAdminProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Funciones WHERE Id = @Pantalla or IdPadre = @Pantalla ;

	----
		
	SET @Pantalla = 'InfOrdenCompraDetalladosProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Pantalla OR IdPadre = @Pantalla);

	DELETE Funciones WHERE Id = @Pantalla or IdPadre = @Pantalla ;

	----

	SET @Menu = 'OrdenCompraProv'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Traducciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Funciones WHERE Id = @Menu or IdPadre = @Menu ;

	---

	UPDATE Parametros
	   SET ValorParametro = 'False'
	 WHERE IdParametro = 'MODULOMRP';

END
GO


