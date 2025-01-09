SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('VentasTransferencias') = 0
BEGIN
    CREATE TABLE VentasTransferencias(
	    IdSucursal int NOT NULL,
	    IdTipoComprobante varchar(15) NOT NULL,
	    Letra varchar(1) NOT NULL,
	    CentroEmisor int NOT NULL,
	    NumeroComprobante bigint NOT NULL,
	    Orden int NOT NULL,
	    Importe decimal(14, 2) NOT NULL,
	    IdCuentaBancaria int NOT NULL,
	    IdSucursalLibroBanco int NULL,
	    IdCuentaBancariaLibroBanco int NULL,
	    NumeroMovimientoLibroBanco int NULL,
     CONSTRAINT PK_VentasTransferencias PRIMARY KEY CLUSTERED (IdSucursal ASC, IdTipoComprobante ASC, Letra ASC, CentroEmisor ASC, NumeroComprobante ASC, Orden ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO
IF dbo.ExisteFK('FK_VentasTransferencias_CuentasBancarias') = 0
BEGIN
    ALTER TABLE dbo.VentasTransferencias  WITH CHECK ADD  CONSTRAINT FK_VentasTransferencias_CuentasBancarias FOREIGN KEY(IdCuentaBancaria)
    REFERENCES dbo.CuentasBancarias (IdCuentaBancaria)
    ALTER TABLE dbo.VentasTransferencias CHECK CONSTRAINT FK_VentasTransferencias_CuentasBancarias
END
GO
IF dbo.ExisteFK('FK_VentasTransferencias_LibrosBancos') = 0
BEGIN
    ALTER TABLE dbo.VentasTransferencias  WITH CHECK ADD  CONSTRAINT FK_VentasTransferencias_LibrosBancos FOREIGN KEY(IdSucursalLibroBanco, IdCuentaBancariaLibroBanco, NumeroMovimientoLibroBanco)
    REFERENCES dbo.LibrosBancos (IdSucursal, IdCuentaBancaria, NumeroMovimiento)
    ALTER TABLE dbo.VentasTransferencias CHECK CONSTRAINT FK_VentasTransferencias_LibrosBancos
END
GO
IF dbo.ExisteFK('FK_VentasTransferencias_Ventas') = 0
BEGIN
    ALTER TABLE dbo.VentasTransferencias  WITH CHECK ADD  CONSTRAINT FK_VentasTransferencias_Ventas FOREIGN KEY(IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdSucursal)
    REFERENCES dbo.Ventas (IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdSucursal)
    ALTER TABLE dbo.VentasTransferencias CHECK CONSTRAINT FK_VentasTransferencias_Ventas
END
GO

IF dbo.ExisteCampo('Ventas', 'ImporteDolares') = 0
BEGIN
    ALTER TABLE dbo.Ventas ADD ImporteDolares decimal(14, 2) NULL
END
GO

UPDATE Ventas SET ImporteDolares = 0 WHERE ImporteDolares IS NULL;
ALTER TABLE dbo.Ventas ALTER COLUMN ImporteDolares decimal(14, 2) NOT NULL
GO


------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F1. Nuevo Menu Planificacion de Requerimientos: MRP - ABM de Planificacion de Requerimientos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPPlanificacionRequerimientos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPPlanificacionRequerimientos', 'Planificacion de Requerimientos de Producción.', 'Planificacion de Requerimientos de Producción.', 'True', 'False', 'True', 'True'
        ,'MRP', 450, 'Eniac.Win', 'MRPPlanificacionRequerimientosProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPPlanificacionRequerimientos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T1. Tabla MRPProcesosProductivosOperaciones: Nuevo campo.'
IF dbo.ExisteCampo('MRPProcesosProductivosOperaciones', 'IdCodigoTarea') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosOperaciones ADD IdCodigoTarea int NULL
    ALTER TABLE MRPProcesosProductivosOperaciones 
		WITH CHECK ADD  CONSTRAINT FK_MRPProcesosProductivos_Tareas FOREIGN KEY(IdCodigoTarea)
    REFERENCES MRPTareas (IdTarea)
END
GO

PRINT ''
PRINT 'T2. Tabla MRPProcesosProductivosOperaciones: Crea Indice.'
IF dbo.ExisteCampo('MRPProcesosProductivosOperaciones', 'IdCodigoTarea') = 1
BEGIN
	UPDATE MRPProcesosProductivosOperaciones SET IdCodigoTarea = (SELECT MIN(IdTarea) FROM MRPTareas)
    ALTER TABLE MRPProcesosProductivosOperaciones ALTER COLUMN IdCodigoTarea int NOT NULL
END
GO

PRINT ''
PRINT 'T3. Tabla OrdenesProduccionMRPOperaciones: Nuevo campo.'
IF dbo.ExisteCampo('OrdenesProduccionMRPOperaciones', 'IdCodigoTarea') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPOperaciones ADD IdCodigoTarea int NULL
	ALTER TABLE OrdenesProduccionMRPOperaciones 
		WITH CHECK ADD  CONSTRAINT FK_OrdenesProduccionMRPOperaciones_Tareas FOREIGN KEY(IdCodigoTarea)
    REFERENCES MRPTareas (IdTarea)
END
GO

PRINT ''
PRINT 'T4. Tabla OrdenesProduccionMRPOperaciones: Nuevo campo.'
IF dbo.ExisteCampo('OrdenesProduccionMRPOperaciones', 'IdCodigoTarea') = 1
BEGIN
	UPDATE OrdenesProduccionMRPOperaciones SET IdCodigoTarea = (SELECT MIN(IdTarea) FROM MRPTareas)
    ALTER TABLE OrdenesProduccionMRPOperaciones ALTER COLUMN IdCodigoTarea int NOT NULL
END
GO


