IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('ProcesoTalleresExternosEnvio') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ProcesoTalleresExternosEnvio', 'Talleres Externos - Envio', 'Talleres Externos - Envio', 'True', 'False', 'True', 'True'
        ,'MRP', 460, 'Eniac.Win', 'ProcesoTalleresExternosEnvio', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProcesoTalleresExternosEnvio' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('Stock') = 1 AND dbo.ExisteFuncion('AjusteMasivoDeStockMinimo') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AjusteMasivoDeStockMinimo', 'Ajuste Masivo de Stock Mínimo, Máximo y Punto de Pedido', 'Ajuste Masivo de Stock Mínimo, Máximo y Punto de Pedido', 'True', 'False', 'True', 'True'
        ,'Stock', 145, 'Eniac.Win', 'AjusteMasivoDeStockMinimo', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AjusteMasivoDeStockMinimo' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END
GO

PRINT ''
PRINT '2. Parametro: MRP: Estado de orden de compra A Vincular en funcionalidad Talleres externos'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOORDENCOMPRAAVINCULAR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado de orden de compra A Vincular en funcionalidad Talleres externos.'
DECLARE @valorParametro VARCHAR(MAX) = 'PENDIENTE'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
PRINT ''
PRINT '3. Parametro: MRP: Estado de orden de compra vinculada en funcionalidad Talleres externos'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOORDENCOMPRAVINCULADA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado de orden de compra vinculada en funcionalidad Talleres externos.'
DECLARE @valorParametro VARCHAR(MAX) = 'ENTREGADO'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

IF dbo.ExisteCampo('EstadosPedidosProveedores', 'IdEstadoFacturado') = 0
BEGIN
    ALTER TABLE dbo.EstadosPedidosProveedores ADD IdEstadoFacturado varchar(10) NULL
END
GO
IF dbo.ExisteFK('FK_EstadosPedidosProveedores_EstadosPedidosProveedores_Facturado') = 0
BEGIN
    ALTER TABLE dbo.EstadosPedidosProveedores ADD CONSTRAINT FK_EstadosPedidosProveedores_EstadosPedidosProveedores_Facturado
        FOREIGN KEY (IdEstadoFacturado, TipoEstadoPedido)
        REFERENCES dbo.EstadosPedidosProveedores (IdEstado, TipoEstadoPedido)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF NOT EXISTS (SELECT * FROM EstadosPedidosProveedores WHERE IdEstadoFacturado IS NOT NULL)
BEGIN
    DECLARE @idEmpresa int = (SELECT MIN(IdEmpresa) FROM Empresas)
    DECLARE @idEstadoAFacturar varchar(max) = (SELECT ValorParametro FROM Parametros WHERE IdEmpresa = @idEmpresa AND IdParametro = 'PEDIDOPROVEEDORESTADOAFACTURAR')
    DECLARE @idEstadoFacturado varchar(max) = (SELECT ValorParametro FROM Parametros WHERE IdEmpresa = @idEmpresa AND IdParametro = 'PEDIDOPROVEEDORESTADOFACTURADO')
    UPDATE EstadosPedidosProveedores
       SET IdEstadoFacturado = @idEstadoFacturado
     WHERE IdEstado = @idEstadoAFacturar
       AND TipoEstadoPedido <> 'PRESUPPROV'
END
GO

UPDATE Parametros
   SET IdParametro = 'BORRAR_' + IdParametro
 WHERE IdParametro IN ('PEDIDOPROVEEDORESTADOAFACTURAR', 'PEDIDOPROVEEDORESTADOFACTURADO')

SELECT * FROM Parametros
 WHERE IdParametro LIKE '%PEDIDOPROVEEDORESTADO%FACTURA%'

PRINT ''
PRINT '01. Asigna Seguridad a Todos los Usuarios Depositos.-'
BEGIN
	MERGE INTO SucursalesDepositosUsuarios AS D
        USING (	
		SELECT DISTINCT U.Id as Rol, UR.IdSucursal, SD.IdDeposito, 'True' Responsable, 'True' UsuarioDefault, 'True' PermitirEscritura  FROM [RolesFunciones] RF
			INNER JOIN UsuariosRoles UR ON UR.IdRol = RF.Idrol
			INNER JOIN Usuarios U on U.Id = UR.IdUsuario
			INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = UR.IdSucursal 
			  WHERE u.Activo = 'True') AS O 
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