PRINT ''
PRINT 'A0. Inserta parametro tabla de Parametros'
DECLARE @Valor as Varchar(10)
BEGIN
    PRINT ''
    PRINT 'A1. Carga Visualizacion de Precio de Costo - Facturacion'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'FACTURACIONVISUALIZAPRECIOCOSTO' AS IdParametro, 
                    'NOMOSTRAR' ValorParametro, 
                    'Facturacion V2' CategoriaParametro, 
                    'FACTURACIONVISUALIZAPRECIOCOSTO' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

    PRINT ''
    PRINT 'A2. Carga Visualizacion de Precio de Costo - Facturacion Rapida'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'FACTURACIONRAPIDAVISUALIZAPRECIOCOSTO' AS IdParametro, 
                    'NOMOSTRAR' ValorParametro, 
                    'Facturacion Rapida' CategoriaParametro, 
                    'FACTURACIONRAPIDAVISUALIZAPRECIOCOSTO' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END

END
GO
PRINT ''
PRINT 'B0. Modificar Pagos de Proveedores'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('ModificarPagosAProveedores', 'Modificar Recibo de Pagos a Proveedores', 'Modificar Recibo de Pagos a Proveedores', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientesProveedores', 75, 'Eniac.Win', 'ConsultarPagosAProveedores', NULL, 'Modificar'
        ,'True', 'S', 'N', 'N', 'N', NULL,'True')


	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ModificarPagosAProveedores' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END
GO

PRINT ''
PRINT 'C0. Se agrega el campo: Correo Administrativo'
BEGIN
    ALTER TABLE Proveedores ADD CorreoAdministrativo nvarchar(50) null
    ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)

END
GO
UPDATE Proveedores SET CorreoAdministrativo = ''
GO

PRINT ''
PRINT 'C0. Nuevo Campo: Tabla Clientes'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdClienteArborea' AND TABLE_NAME = 'Clientes')
    BEGIN
        ALTER TABLE dbo.Clientes ADD IdClienteArborea varchar(30) NULL
        ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_ClientesArborea ON dbo.Clientes
	        (
	        IdClienteArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.AuditoriaClientes ADD IdClienteArborea varchar(30) NULL
        ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.Prospectos ADD IdProspectoArborea varchar(30) NULL
        ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.AuditoriaProspectos ADD IdProspectoArborea varchar(30) NULL
        ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS RUBROS ARBOREA.- --
PRINT ''
PRINT 'D0. Nuevo Campo: Tabla Rubros'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdRubroArborea' AND TABLE_NAME = 'Rubros')
    BEGIN
        ALTER TABLE dbo.Rubros ADD IdRubroArborea varchar(30) NULL
        ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_RubroArborea ON dbo.Rubros
	        (
	        IdRubroArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS SUB RUBROS ARBOREA.- --
PRINT ''
PRINT 'E0. Nuevo Campo: Tabla SUB Rubros'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdSubRubroArborea' AND TABLE_NAME = 'SubRubros')
    BEGIN
        ALTER TABLE dbo.SubRubros ADD IdSubRubroArborea varchar(30) NULL
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_SubRubroArborea ON dbo.SubRubros
	        (
	        IdSubRubroArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS SUBSUB RUBROS ARBOREA.- --
PRINT ''
PRINT 'F0. Nuevo Campo: Tabla SUBSUB Rubros'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdSubSubRubroArborea' AND TABLE_NAME = 'SubSubRubros')
    BEGIN
        ALTER TABLE dbo.SubSubRubros ADD IdSubSubRubroArborea varchar(30) NULL
        ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_SubSubRubroArborea ON dbo.SubSubRubros
	        (
	        IdSubSubRubroArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
--INCORPORA CAMPOS SUBSUB RUBROS ARBOREA.- --
PRINT ''
PRINT 'G0. Nuevo Campo: Tabla Productos'
IF not exists ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'CodigoProductoArborea' AND TABLE_NAME = 'Productos')
    BEGIN
        ALTER TABLE dbo.Productos ADD CodigoProductoArborea varchar(30) NULL
        ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_CodigoProductoArborea ON dbo.Productos
	        (
	        CodigoProductoArborea
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ALTER TABLE dbo.SubRubros SET (LOCK_ESCALATION = TABLE)

        ALTER TABLE dbo.AuditoriaProductos ADD CodigoProductoArborea varchar(30) NULL
        ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)

    END
GO
----------------------------------------------------
PRINT ''
PRINT 'H0. TablaCalidadListasControlTipos: Nueva columna VisiblePanelControl'

ALTER TABLE CalidadListasControlTipos ADD VisiblePanelControl bit null
GO

UPDATE CalidadListasControlTipos SET VisiblePanelControl = 'True'
GO

ALTER TABLE CalidadListasControlTipos ALTER COLUMN  VisiblePanelControl bit not null
GO

----------------------------------------------------
