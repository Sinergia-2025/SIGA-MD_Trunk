PRINT ''
PRINT '1. Nueva Funcion: Informe de Cta. Cte. Pendientes por Producto.'
IF dbo.ExisteFuncion('InfCtaCteClientes') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Inserta Funcion: Informe de Cta. Cte. Pendientes por Producto'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfCtaCtePendientePorProducto', 'Informe de Cta. Cte. Pendientes por Producto', 'Informe de Cta. Cte. Pendientes por Producto', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 115, 'Eniac.Win', 'InfCtaCtePendientePorProducto', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
    PRINT ''
    PRINT '1.2. Permisos Funcion: Informe de Cta. Cte. Pendientes por Producto'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfCtaCtePendientePorProducto' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END

PRINT ''
PRINT '2. Indices varios'

PRINT '2.0. Drop de Indices pre-existentes'
PRINT '2.0.1. IX_Ventas_IdAsiento'
IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.Ventas') AND NAME ='IX_Ventas_IdAsiento')
    DROP INDEX IX_Ventas_IdAsiento ON Ventas;
PRINT '2.0.2. IX_CuentasCorrientes_IdAsiento'
IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.CuentasCorrientes') AND NAME ='IX_CuentasCorrientes_IdAsiento')
    DROP INDEX IX_CuentasCorrientes_IdAsiento ON CuentasCorrientes;
PRINT '2.0.3. IX_Compras_IdAsiento'
IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.Compras') AND NAME ='IX_Compras_IdAsiento')
    DROP INDEX IX_Compras_IdAsiento ON Compras;
PRINT '2.0.4. IX_CuentasCorrientesProv_IdAsiento'
IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.CuentasCorrientesProv') AND NAME ='IX_CuentasCorrientesProv_IdAsiento')
    DROP INDEX IX_CuentasCorrientesProv_IdAsiento ON CuentasCorrientesProv;
PRINT '2.0.5. IX_CajasDetalle_IdAsiento'
IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.CajasDetalle') AND NAME ='IX_CajasDetalle_IdAsiento')
    DROP INDEX IX_CajasDetalle_IdAsiento ON CajasDetalle;
PRINT '2.0.6. IX_LibrosBancos_IdAsiento'
IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.LibrosBancos') AND NAME ='IX_LibrosBancos_IdAsiento')
    DROP INDEX IX_LibrosBancos_IdAsiento ON LibrosBancos;
GO

PRINT ''
PRINT '2.1. Tabla ContabilidadAsientosTmp: Nuevo Indice IX_ContabilidadAsientosTmp_AsientoDefinitivo'
CREATE NONCLUSTERED INDEX IX_ContabilidadAsientosTmp_AsientoDefinitivo ON dbo.ContabilidadAsientosTmp
    (IdEjercicioDefinitivo, IdPlanCuentaDefinitivo, IdAsientoDefinitivo)
WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.ContabilidadAsientosTmp SET (LOCK_ESCALATION = TABLE)


PRINT '2.2. Tabla Ventas: Nuevo Indice IX_Ventas_IdAsiento'
CREATE NONCLUSTERED INDEX IX_Ventas_IdAsiento ON dbo.Ventas
    (IdEjercicio,IdPlanCuenta,IdAsiento) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
PRINT '2.3. Tabla CuentasCorrientes: Nuevo Indice IX_CuentasCorrientes_IdAsiento'
CREATE NONCLUSTERED INDEX IX_CuentasCorrientes_IdAsiento ON dbo.CuentasCorrientes
    (IdEjercicio,IdPlanCuenta,IdAsiento) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
PRINT '2.3. Tabla Compras: Nuevo Indice IX_Compras_IdAsiento'
CREATE NONCLUSTERED INDEX IX_Compras_IdAsiento ON dbo.Compras
    (IdEjercicio,IdPlanCuenta,IdAsiento) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
PRINT '2.4. Tabla CuentasCorrientesProv: Nuevo Indice IX_CuentasCorrientesProv_IdAsiento'
CREATE NONCLUSTERED INDEX IX_CuentasCorrientesProv_IdAsiento ON dbo.CuentasCorrientesProv
    (IdEjercicio,IdPlanCuenta,IdAsiento) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
PRINT '2.5. Tabla CajasDetalle: Nuevo Indice IX_CajasDetalle_IdAsiento'
CREATE NONCLUSTERED INDEX IX_CajasDetalle_IdAsiento ON dbo.CajasDetalle
    (IdEjercicio,IdPlanCuenta,IdAsiento) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
PRINT '2.6. Tabla LibrosBancos: Nuevo Indice IX_LibrosBancos_IdAsiento'
CREATE NONCLUSTERED INDEX IX_LibrosBancos_IdAsiento ON dbo.LibrosBancos
    (IdEjercicio,IdPlanCuenta,IdAsiento) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
