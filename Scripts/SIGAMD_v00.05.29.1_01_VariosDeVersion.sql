UPDATE Funciones
   SET Parametros = 'ORDENCOMPRAPROV\,PEDIDOSPROV'
 WHERE Id = 'EstadoOrdenCompraProvABM'

UPDATE Funciones
   SET Parametros = 'PRESUPPROV\,ORDENCOMPRAPROV'
 WHERE Id = 'EstadoPresupuestosProvABM'

PRINT ''
PRINT '01. Asigna Seguridad Usuarios Depositos.-'
BEGIN
	MERGE INTO SucursalesDepositosUsuarios AS D
        USING (	
		SELECT DISTINCT U.Id as Rol, UR.IdSucursal, SD.IdDeposito, 'True' Responsable, 'True' UsuarioDefault, 'True' PermitirEscritura  FROM [RolesFunciones] RF
			INNER JOIN UsuariosRoles UR ON UR.IdRol = RF.Idrol
			INNER JOIN Usuarios U on U.Id = UR.IdUsuario
			INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = UR.IdSucursal 
			  WHERE IDFUNCION = 'STOCK' and u.Activo = 'True') AS O 
		ON D.IdSucursal = O.IdSucursal AND D.IdDeposito = O.IdDeposito AND D.IdUsuario = O.Rol
    WHEN MATCHED THEN
        UPDATE SET D.IdDeposito                 = O.IdDeposito
                 , D.IdSucursal					= O.IdSucursal
                 , D.IdUsuario					= O.Rol
                 , D.Responsable				= O.Responsable
                 , D.UsuarioDefault				= O.UsuarioDefault
                 , D.PermitirEscritura			= O.PermitirEscritura
    WHEN NOT MATCHED THEN 
        INSERT (  IdDeposito, IdSucursal,   IdUsuario,  Responsable, UsuarioDefault, PermitirEscritura) 
        VALUES (O.IdDeposito, O.IdSucursal, O.Rol, O.Responsable, O.UsuarioDefault, O.PermitirEscritura);
END
GO

UPDATE ProductosSucursales 
	SET IdDepositoDefecto = 1 WHERE IdDepositoDefecto = 0
UPDATE ProductosSucursales 
	SET IdUbicacionDefecto = 1 WHERE IdUbicacionDefecto = 0

IF dbo.ExisteFK('FK_ProductosSucursales_SucursalesDepositos') = 0
BEGIN
    ALTER TABLE dbo.ProductosSucursales ADD CONSTRAINT FK_ProductosSucursales_SucursalesDepositos
        FOREIGN KEY (IdDepositoDefecto, IdSucursal)
        REFERENCES dbo.SucursalesDepositos (IdDeposito, IdSucursal)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteFK('FK_ProductosSucursales_SucursalesUbicaciones') = 0
BEGIN
    ALTER TABLE dbo.ProductosSucursales ADD CONSTRAINT FK_ProductosSucursales_SucursalesUbicaciones
        FOREIGN KEY (IdDepositoDefecto, IdSucursal, IdUbicacionDefecto)
        REFERENCES dbo.SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
PRINT ''
PRINT 'T1. Tabla MRPProcesosProductivosCategoriaEmpleados: Nuevo campo ValorHoraCategoria'
IF dbo.ExisteCampo('MRPProcesosProductivosCategoriasEmpleados', 'ValorHoraCategoria') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosCategoriasEmpleados ADD ValorHoraCategoria decimal(16,2) NULL
END
GO
PRINT ''
PRINT 'A1. Actualiza Campo ValorHoraCategoria'
BEGIN
	UPDATE MRPProcesosProductivosCategoriasEmpleados SET ValorHoraCategoria = 0
    ALTER TABLE MRPProcesosProductivosCategoriasEmpleados ALTER COLUMN ValorHoraCategoria decimal(16,2) NOT NULL
END
GO

IF dbo.ExisteIX('AK_CodigoUbicacion') = 0
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX AK_CodigoUbicacion ON dbo.SucursalesUbicaciones
	    (IdSucursal, IdDeposito, CodigoUbicacion)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

PRINT ''
PRINT 'T1. Tabla MRPCentroProductores: Elimina Campo IdProveedorDefecto'
IF dbo.ExisteCampo('MRPCentrosProductores', 'IdProveedorDefecto') = 1
BEGIN
    ALTER TABLE MRPCentrosProductores DROP COLUMN IdProveedorDefecto			
END
GO
------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T2. Tabla MRPProcesosProductivosCategoriaEmpleados: Nuevo campo ValorHoraCategoria'
IF dbo.ExisteCampo('MRPCentrosProductores', 'IdNormaFabricacion') = 0
BEGIN
    ALTER TABLE MRPCentrosProductores ADD IdNormaFabricacion Integer NULL
	ALTER TABLE MRPCentrosProductores ADD CONSTRAINT FK_MRPIdNormaFabricacion FOREIGN KEY
		(IdNormaFabricacion) 
	 REFERENCES MRPNormasFabricacion
		(IdNormaFab) 
	 ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
END
GO

ALTER TABLE ProductosSucursales ALTER COLUMN IdDepositoDefecto int NULL
ALTER TABLE ProductosSucursales ALTER COLUMN IdUbicacionDefecto int NULL

PRINT ''
PRINT 'C1. Nuevo Campo: Precio Costo Producto'
IF dbo.ExisteCampo('MRPProcesosProductivosProductos', 'PrecioCostoProducto') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosProductos ADD PrecioCostoProducto decimal(16, 2) NULL
END
GO

PRINT ''
PRINT 'C1. Nuevo Campo: Precio Costo Producto'
IF dbo.ExisteCampo('MRPProcesosProductivosProductos', 'PrecioCostoProducto') = 1
BEGIN
	UPDATE MRPProcesosProductivosProductos SET PrecioCostoProducto = 0
    ALTER TABLE MRPProcesosProductivosProductos ALTER COLUMN PrecioCostoProducto decimal(16, 2) NOT NULL
END
GO
DELETE RolesFunciones
 WHERE IdFuncion = 'ABMMonedas'
DELETE Bitacora
 WHERE IdFuncion = 'ABMMonedas'
DELETE Funciones
 WHERE Id = 'ABMMonedas'
GO

UPDATE Clientes
   SET MonedaCredito = 1
 WHERE MonedaCredito = 0

UPDATE CuentasBancarias
   SET IdMoneda = 1
 WHERE IdMoneda = 0

DELETE FROM Monedas WHERE IdMoneda = 0
GO