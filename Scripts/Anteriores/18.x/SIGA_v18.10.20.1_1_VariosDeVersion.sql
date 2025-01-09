
PRINT ''
PRINT '0. Borrar funciones incorrectas'
GO

DELETE Bitacora WHERE IdFuncion LIKE 'TableroDeComando%'
DELETE RolesFunciones WHERE IdFuncion LIKE 'TableroDeComando%'
DELETE Funciones WHERE Id LIKE 'TableroDeComando%'

PRINT ''
PRINT '1. Nueva Funciones Estadisticas\TableroDeComandos.'
GO

-- Si es el CUIT de Generico/RDS/RDS ACE.

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))

BEGIN
	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('TableroDeComando', 'Tablero de Comando', 'Tablero de Comando', 
		'True', 'False', 'True', 'True', 'Estadisticas', 40, 'Eniac.Win', 'TableroDeComando', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TableroDeComando' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')
	;

END;


PRINT ''
PRINT '2. Nueva Funciones Estadisticas\TableroDeComandos\Tabs.'
GO
IF EXISTS (SELECT * FROM Funciones F WHERE F.Id = 'TableroDeComando')
BEGIN
    --Permisos de cada TAB

     INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('TableroDeComando-Versiones', 'TableroDeComando Tab Versiones', 'TableroDeComando Tab Versiones', 
        'False', 'False', 'True', 'True', 'TableroDeComando', 20, 'Eniac.Win', 'TableroDeComando-Versiones', NULL, null,
                  'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones 
                  (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComando-Versiones' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')

      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('TableroDeComando-VersionBackup', 'TableroDeComando Tab VersionesBackups', 'TableroDeComando Tab VersionesBackups', 
        'False', 'False', 'True', 'True', 'TableroDeComando', 20, 'Eniac.Win', 'TableroDeComando-VersionBackup', NULL, null,
                  'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones 
                  (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComando-VersionBackup' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')

      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('TableroDeComando-PCs', 'TableroDeComando Tab PCs', 'TableroDeComando Tab PCs', 
        'False', 'False', 'True', 'True', 'TableroDeComando', 20, 'Eniac.Win', 'TableroDeComando-PCs', NULL, null,
                  'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones 
                  (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComando-PCs' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')

      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('TableroDeComando-Backups', 'TableroDeComando Tab Backups', 'TableroDeComando Tab Backups', 
        'False', 'False', 'True', 'True', 'TableroDeComando', 20, 'Eniac.Win', 'TableroDeComando-Backups', NULL, null,
                  'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones 
                  (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TableroDeComando-Backups' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')
END


PRINT ''
PRINT '3. Tabla Calendarios: Agregar Campo IdProducto.'
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
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Calendarios ADD IdProducto varchar(15) NULL
GO
ALTER TABLE dbo.Calendarios ADD CONSTRAINT FK_Calendarios_Productos
    FOREIGN KEY (IdProducto)
    REFERENCES dbo.Productos (IdProducto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Calendarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla TurnosCalendarios: Agregar Campos IdProducto y Otros.'
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
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TurnosCalendarios ADD IdProducto varchar(15) NULL
ALTER TABLE dbo.TurnosCalendarios ADD PrecioLista decimal(16, 4) NULL
ALTER TABLE dbo.TurnosCalendarios ADD Precio decimal(16, 4) NULL
ALTER TABLE dbo.TurnosCalendarios ADD DescuentoRecargoPorcGral decimal(10, 5) NULL
ALTER TABLE dbo.TurnosCalendarios ADD DescuentoRecargoPorc1 decimal(10, 5) NULL
ALTER TABLE dbo.TurnosCalendarios ADD DescuentoRecargoPorc2 decimal(10, 5) NULL
ALTER TABLE dbo.TurnosCalendarios ADD PrecioNeto decimal(16, 4) NULL
GO
ALTER TABLE dbo.TurnosCalendarios ADD CONSTRAINT FK_TurnosCalendarios_Productos
    FOREIGN KEY (IdProducto)
    REFERENCES dbo.Productos (IdProducto)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TurnosCalendarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla TurnosCalendarios: Agregar Campos Para Referenciar Factura.'
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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TurnosCalendarios ADD IdSucursal int NULL
ALTER TABLE dbo.TurnosCalendarios ADD IdTipoComprobante varchar(15) NULL
ALTER TABLE dbo.TurnosCalendarios ADD Letra varchar(1) NULL
ALTER TABLE dbo.TurnosCalendarios ADD CentroEmisor int NULL
ALTER TABLE dbo.TurnosCalendarios ADD NumeroComprobante bigint NULL
GO
ALTER TABLE dbo.TurnosCalendarios ADD CONSTRAINT FK_TurnosCalendarios_Ventas
    FOREIGN KEY (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
    REFERENCES dbo.Ventas (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TurnosCalendarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '6. Tabla Pedidos: Agregar Campo ObservacionInterna.'
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
ALTER TABLE dbo.Pedidos ADD ObservacionInterna varchar(200) NULL
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '7. Nueva Funcion Pedidos\ModificarPedidos.'
GO

-- Si tiene modulo Pedidos

IF EXISTS (SELECT * FROM Funciones F WHERE F.Id = 'Pedidos')
BEGIN
	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('ModificarPedidos', 'Modificar Pedidos', 'Modificar Pedidos', 'True', 'False', 'True', 'True', 
        'Pedidos', 16, 'Eniac.Win', 'AnularPedidos', null, '|MODIFICAR',
        'True', 'S', 'S', 'N', 'N')
	;
	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT IdRol, 'ModificarPedidos' AS Pantalla FROM dbo.RolesFunciones
		WHERE IdFuncion = 'PedidosAdmin'
	;
    UPDATE Funciones
       SET Posicion = 17
     WHERE Id = 'AnularPedidos'
     ;
END;


PRINT ''
PRINT '8. Nueva Funcion Presupuestos\ModificarPedidos.'
GO

-- Si tiene modulo Pedidos

IF EXISTS (SELECT * FROM Funciones F WHERE F.Id = 'Presupuestos')
BEGIN
	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('ModificarPresupuesto', 'Modificar Presupuestos', 'Modificar Presupuestos', 'True', 'False', 'True', 'True', 
        'Presupuestos', 25, 'Eniac.Win', 'AnularPedidos', null, 'PRESUPCLIE|MODIFICAR',
        'True', 'S', 'S', 'N', 'N')
	;
	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT IdRol, 'ModificarPresupuesto' AS Pantalla FROM dbo.RolesFunciones
		WHERE IdFuncion = 'PresupuestosAdmin'
	;
END;
