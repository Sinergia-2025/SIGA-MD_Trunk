PRINT ''
PRINT '1. Tabla VentasFormasPago: Nuevos Campos Requiere*'
ALTER TABLE dbo.VentasFormasPago ADD RequierePesos bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereDolares bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereTickets bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereTransferencia bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereCheques bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereTarjetaDebito bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereTarjetaCredito bit NULL
ALTER TABLE dbo.VentasFormasPago ADD RequiereTarjetaCredito1Pago bit NULL
GO

PRINT ''
PRINT '1.1. Tabla VentasFormasPago: Valores por defecto para campos Requiere*'
UPDATE VentasFormasPago
   SET RequierePesos                = 'False'
     , RequiereDolares              = 'False'
     , RequiereTickets              = 'False'
     , RequiereTransferencia        = 'False'
     , RequiereCheques              = 'False'
     , RequiereTarjetaDebito        = 'False'
     , RequiereTarjetaCredito       = 'False'
     , RequiereTarjetaCredito1Pago  = 'False'

PRINT ''
PRINT '1.2. Tabla VentasFormasPago: NOT NULL para campos Requiere*'
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequierePesos bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereDolares bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereTickets bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereTransferencia bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereCheques bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereTarjetaDebito bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereTarjetaCredito bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN RequiereTarjetaCredito1Pago bit NOT NULL
GO

PRINT ''
PRINT '2. Nuevo Parametro: PREVENTAAGRUPAORDENPRODUCTOENCADAPEDIDO'
DECLARE @idParametro VARCHAR(MAX) = 'PREVENTAAGRUPAORDENPRODUCTOENCADAPEDIDO'
DECLARE @descripcionParametro VARCHAR(MAX) = ''
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('23278908704') = 'True'      -- Solo 5M
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


PRINT ''
PRINT '3. Nueva Funciones: Facturación Masiva de Pedidos, Organizar Entregas (solo Pedidos) y Organizar Entregas (solo Ventas)'
IF dbo.ExisteFuncion('Logistica') = 'True'
BEGIN

    PRINT ''
    PRINT '3.1. Inserta Funcion: Facturación Masiva de Pedidos'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('OrganizarEntregasV2Masiva', 'Facturación Masiva de Pedidos', 'Facturación Masiva de Pedidos', 'True', 'False', 'True', 'True'
        ,'Logistica', 160, 'Eniac.Win', 'OrganizarEntregasV2', NULL, 'FACTURACION MASIVA'
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.2. Permisos Funcion: Facturación Masiva de Pedidos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'OrganizarEntregasV2Masiva' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')


    PRINT ''
    PRINT '3.3. Inserta Funcion: Organizar Entregas (solo Pedidos)'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('OrganizarEntregasV2Pedidos', 'Organizar Entregas (solo Pedidos)', 'Organizar Entregas (solo Pedidos)', 'True', 'False', 'True', 'True'
        ,'Logistica', 170, 'Eniac.Win', 'OrganizarEntregasV2', NULL, 'SOLO PEDIDOS'
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.4. Permisos Funcion: Organizar Entregas (solo Pedidos)'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'OrganizarEntregasV2Pedidos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')

    PRINT ''
    PRINT '3.5. Inserta Funcion: Organizar Entregas (solo Ventas)'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('OrganizarEntregasV2Ventas', 'Organizar Entregas (solo Ventas)', 'Organizar Entregas (solo Ventas)', 'True', 'False', 'True', 'True'
        ,'Logistica', 180, 'Eniac.Win', 'OrganizarEntregasV2', NULL, 'SOLO VENTAS'
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '3.6. Permisos Funcion: Organizar Entregas (solo Ventas)'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'OrganizarEntregasV2Ventas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END
