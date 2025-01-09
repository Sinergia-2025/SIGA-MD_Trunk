
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPProductos') = 1
BEGIN
UPDATE funciones SET Nombre = 'Inf. Detalle Operaciones de Orden Producción', 
				     Descripcion = 'Inf. Detalle Operaciones de Orden Producción'
where id = 'InfOrdenProduccionMRPProductos'
END
GO

ALTER TABLE TarjetasCupones ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE TarjetasCuponesHistorial ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE CuentasCorrientesTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE VentasTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

IF dbo.ExisteCampo('RequerimientosComprasProductos', 'Kilos') = 1 AND dbo.ExisteCampo('RequerimientosComprasProductos', 'CantidadUMCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.RequerimientosComprasProductos.Kilos', 'CantidadUMCompra', 'COLUMN' 
END
GO
IF dbo.ExisteCampo('RequerimientosComprasProductos', 'KilosProducto') = 1 AND dbo.ExisteCampo('RequerimientosComprasProductos', 'FactorConversionCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.RequerimientosComprasProductos.KilosProducto', 'FactorConversionCompra', 'COLUMN' 
END
GO

IF dbo.ExisteCampo('RequerimientosComprasProductos', 'IdUnidadDeMedida') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos ADD IdUnidadDeMedida varchar(10) NULL
    ALTER TABLE dbo.RequerimientosComprasProductos ADD IdUnidadDeMedidaCompra varchar(10) NULL
END
GO

UPDATE RCP
   SET IdUnidadDeMedida = P.IdUnidadDeMedida
     , IdUnidadDeMedidaCompra = P.IdUnidadDeMedidaCompra
  FROM RequerimientosComprasProductos RCP
 INNER JOIN Productos P ON P.IdProducto = RCP.IdProducto
 WHERE RCP.IdUnidadDeMedida IS NULL

ALTER TABLE dbo.RequerimientosComprasProductos ALTER COLUMN IdUnidadDeMedida varchar(10) NOT NULL
ALTER TABLE dbo.RequerimientosComprasProductos ALTER COLUMN IdUnidadDeMedidaCompra varchar(10) NOT NULL
GO

IF dbo.ExisteFK('FK_RequerimientosComprasProductos_UnidadesDeMedidas') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos ADD CONSTRAINT FK_RequerimientosComprasProductos_UnidadesDeMedidas
        FOREIGN KEY (IdUnidadDeMedida)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
IF dbo.ExisteFK('FK_RequerimientosComprasProductos_UnidadesDeMedidas_Compra') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos ADD CONSTRAINT FK_RequerimientosComprasProductos_UnidadesDeMedidas_Compra
        FOREIGN KEY (IdUnidadDeMedidaCompra)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
        ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteCampo('PedidosProductosProveedores', 'Kilos') = 1 AND dbo.ExisteCampo('PedidosProductosProveedores', 'CantidadUMCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.PedidosProductosProveedores.Kilos', 'CantidadUMCompra', 'COLUMN' 
END
GO
IF dbo.ExisteCampo('PedidosProductosProveedores', 'KilosProducto') = 1 AND dbo.ExisteCampo('PedidosProductosProveedores', 'FactorConversionCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.PedidosProductosProveedores.KilosProducto', 'FactorConversionCompra', 'COLUMN' 
END
GO
IF dbo.ExisteCampo('PedidosProductosProveedores', 'PrecioPorKilos') = 1 AND dbo.ExisteCampo('PedidosProductosProveedores', 'PrecioPorUMCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.PedidosProductosProveedores.PrecioPorKilos', 'PrecioPorUMCompra', 'COLUMN' 
END
GO

IF EXISTS(SELECT * FROM sys.default_constraints WHERE name = 'DF_PedidosProductosProveedores_KilosTotalProducto')
BEGIN
    ALTER TABLE PedidosProductosProveedores DROP CONSTRAINT DF_PedidosProductosProveedores_KilosTotalProducto
END
GO
IF EXISTS(SELECT * FROM sys.default_constraints WHERE name = 'DF_PedidosProductosProveedores_KiloUnitario')
BEGIN
    ALTER TABLE PedidosProductosProveedores DROP CONSTRAINT DF_PedidosProductosProveedores_KiloUnitario
END
GO
IF EXISTS(SELECT * FROM sys.default_constraints WHERE name = 'DF_PedidosProductosProveedores_PrecioKiloUnitario')
BEGIN
    ALTER TABLE PedidosProductosProveedores DROP CONSTRAINT DF_PedidosProductosProveedores_PrecioKiloUnitario
END
GO

IF dbo.ExisteCampo('PedidosProductosProveedores', 'KiloUnitario') = 1
BEGIN
    ALTER TABLE PedidosProductosProveedores DROP COLUMN KiloUnitario
END
GO
IF dbo.ExisteCampo('PedidosProductosProveedores', 'KilosTotalProducto') = 1
BEGIN
    ALTER TABLE PedidosProductosProveedores DROP COLUMN KilosTotalProducto
END
GO
IF dbo.ExisteCampo('PedidosProductosProveedores', 'PrecioKiloUnitario') = 1
BEGIN
    ALTER TABLE PedidosProductosProveedores DROP COLUMN PrecioKiloUnitario
END
GO

IF dbo.ExisteCampo('PedidosProductosProveedores', 'IdUnidadDeMedidaCompra') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductosProveedores ADD IdUnidadDeMedidaCompra varchar(10) NULL
END
GO

UPDATE PP
   SET IdUnidadDeMedidaCompra = P.IdUnidadDeMedidaCompra
  FROM PedidosProductosProveedores PP
 INNER JOIN Productos P ON P.IdProducto = PP.IdProducto
 WHERE PP.IdUnidadDeMedidaCompra IS NULL

ALTER TABLE dbo.PedidosProductosProveedores ALTER COLUMN IdUnidadDeMedidaCompra varchar(10) NOT NULL
ALTER TABLE dbo.PedidosProductosProveedores ALTER COLUMN IdUnidadDeMedida varchar(10) NULL
GO

IF dbo.ExisteFK('FK_PedidosProductosProveedores_UnidadesDeMedidas_Compra') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductosProveedores ADD CONSTRAINT FK_PedidosProductosProveedores_UnidadesDeMedidas_Compra
        FOREIGN KEY (IdUnidadDeMedidaCompra)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
        ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
END
GO

--Verificación de que la Base no sea la de HAR GROUP
IF dbo.SoyHAR() = 0
BEGIN
	--Al NO ser la Base de HAR GROUP, comienza la sentencia
	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'PresupuestosAdminProv'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'PresupuestosAdminProv'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'PresupuestosAdminProv'
		DELETE RolesFunciones FROM  RolesFunciones RF INNER JOIN Funciones F ON F.Id = RF.IdFuncion  WHERE IdPadre = 'PresupuestosAdminProv'
		DELETE RolesFunciones WHERE IdFuncion = 'PresupuestosAdminProv'
		DELETE Funciones WHERE IdPadre = 'PresupuestosAdminProv'
		DELETE Funciones WHERE Id = 'PresupuestosAdminProv'
		PRINT 'Se eliminó la función "Administrador de Presupuestos a Proveedor (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Presupuestos a Proveedor (v1)"'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'OrdenCompraAdminProv'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'OrdenCompraAdminProv'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'OrdenCompraAdminProv'
		DELETE RolesFunciones WHERE IdFuncion = 'OrdenCompraAdminProv'
		DELETE Funciones WHERE Id = 'OrdenCompraAdminProv'
		PRINT 'Se eliminó la función "Administrador de Órdenes de Compra Proveedor (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Órdenes de Compra Proveedor (v1)"'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'PedidosAdminProv'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'PedidosAdminProv'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'PedidosAdminProv'
		DELETE RolesFunciones WHERE IdFuncion = 'PedidosAdminProv'
		DELETE Funciones WHERE Id = 'PedidosAdminProv'
		PRINT 'Se eliminó la función "Administrador de Pedidos a Proveedor (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Pedidos a Proveedor (v1)"'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'OrdenesProduccionAdmin'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'OrdenesProduccionAdmin'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'OrdenesProduccionAdmin'
		DELETE RolesFunciones WHERE IdFuncion = 'OrdenesProduccionAdmin'
		DELETE Funciones WHERE Id = 'OrdenesProduccionAdmin'
		PRINT 'Se eliminó la función "Administrador de Órdenes de Producción (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Órdenes de Producción (v1)"'
	END

END
ELSE --La Base SÍ es de HAR GROUP, no se elimina la función de Administrador
BEGIN
    PRINT 'Script corrido sobre HAR GROUP, no se elimina la función de Administrador'
END
GO

IF dbo.ExisteCampo('ComprasProductos', 'Kilos') = 1 AND dbo.ExisteCampo('ComprasProductos', 'CantidadUMCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.ComprasProductos.Kilos', 'CantidadUMCompra', 'COLUMN' 
END
GO
IF dbo.ExisteCampo('ComprasProductos', 'KilosProducto') = 1 AND dbo.ExisteCampo('ComprasProductos', 'FactorConversionCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.ComprasProductos.KilosProducto', 'FactorConversionCompra', 'COLUMN' 
END
GO
IF dbo.ExisteCampo('ComprasProductos', 'PrecioPorKilo') = 1 AND dbo.ExisteCampo('ComprasProductos', 'PrecioPorUMCompra') = 0
BEGIN
    EXECUTE sp_rename 'dbo.ComprasProductos.PrecioPorKilo', 'PrecioPorUMCompra', 'COLUMN' 
END
GO

IF EXISTS(SELECT * FROM sys.default_constraints WHERE name = 'DF_ComprasProductos_KilosTotalProducto')
BEGIN
    ALTER TABLE ComprasProductos DROP CONSTRAINT DF_ComprasProductos_KilosTotalProducto
END
GO
IF EXISTS(SELECT * FROM sys.default_constraints WHERE name = 'DF_ComprasProductos_KiloUnitario')
BEGIN
    ALTER TABLE ComprasProductos DROP CONSTRAINT DF_ComprasProductos_KiloUnitario
END
GO
IF EXISTS(SELECT * FROM sys.default_constraints WHERE name = 'DF_ComprasProductos_PrecioKiloUnitario')
BEGIN
    ALTER TABLE ComprasProductos DROP CONSTRAINT DF_ComprasProductos_PrecioKiloUnitario
END
GO

IF dbo.ExisteCampo('ComprasProductos', 'KiloUnitario') = 1
BEGIN
    ALTER TABLE ComprasProductos DROP COLUMN KiloUnitario
END
GO
IF dbo.ExisteCampo('ComprasProductos', 'KilosTotalProducto') = 1
BEGIN
    ALTER TABLE ComprasProductos DROP COLUMN KilosTotalProducto
END
GO
IF dbo.ExisteCampo('ComprasProductos', 'PrecioKiloUnitario') = 1
BEGIN
    ALTER TABLE ComprasProductos DROP COLUMN PrecioKiloUnitario
END
GO

IF dbo.ExisteCampo('ComprasProductos', 'IdUnidadDeMedidaCompra') = 0
BEGIN
    ALTER TABLE dbo.ComprasProductos ADD IdUnidadDeMedida varchar(10) NULL
    ALTER TABLE dbo.ComprasProductos ADD IdUnidadDeMedidaCompra varchar(10) NULL
END
GO

UPDATE CP
   SET IdUnidadDeMedida       = P.IdUnidadDeMedida
     , IdUnidadDeMedidaCompra = P.IdUnidadDeMedidaCompra
  FROM ComprasProductos CP
 INNER JOIN Productos P ON P.IdProducto = CP.IdProducto
 WHERE CP.IdUnidadDeMedidaCompra IS NULL

ALTER TABLE dbo.ComprasProductos ALTER COLUMN IdUnidadDeMedida varchar(10) NULL
ALTER TABLE dbo.ComprasProductos ALTER COLUMN IdUnidadDeMedidaCompra varchar(10) NOT NULL
GO

IF dbo.ExisteFK('FK_ComprasProductos_UnidadesDeMedidas') = 0
BEGIN
    ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT FK_ComprasProductos_UnidadesDeMedidas
        FOREIGN KEY (IdUnidadDeMedida)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
        ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
END
GO
IF dbo.ExisteFK('FK_ComprasProductos_UnidadesDeMedidas_Compra') = 0
BEGIN
    ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT FK_ComprasProductos_UnidadesDeMedidas_Compra
        FOREIGN KEY (IdUnidadDeMedidaCompra)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
        ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteCampo('ComprasTarjetas', 'IdEstadoTarjeta') = 0
BEGIN
    ALTER TABLE dbo.ComprasTarjetas ADD IdEstadoTarjeta varchar(10) NULL
    ALTER TABLE dbo.ComprasTarjetas ADD IdEstadoTarjetaAnt varchar(10) NULL
END
GO

UPDATE CT
   SET IdEstadoTarjeta    = TC.IdEstadoTarjetaAnt
     , IdEstadoTarjetaAnt = TC.IdEstadoTarjetaAnt
  FROM ComprasTarjetas CT
 INNER JOIN TarjetasCupones TC ON TC.IdTarjetaCupon = CT.IdTarjetaCupon
 WHERE CT.IdEstadoTarjeta IS NULL

ALTER TABLE dbo.ComprasTarjetas ALTER COLUMN IdEstadoTarjeta varchar(10) NOT NULL
ALTER TABLE dbo.ComprasTarjetas ALTER COLUMN IdEstadoTarjetaAnt varchar(10) NOT NULL
GO

PRINT ''
PRINT '1. Parametros: Configurar visivilidad de opcion Modelo Forma solo para Asa'

IF dbo.BaseConCuit('30676889376') = 1
BEGIN
    Update Parametros 
		SET ValorParametro = 'True' 
	WHERE Idparametro = 'ORDPRODMOSTRARPRODUCTOMODELOFORMA'
END
GO
