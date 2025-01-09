IF NOT EXISTS(SELECT * FROM Traducciones WHERE IdFuncion = 'OrdenCompraAdminProvV2' OR IdFuncion = 'PresupuestosAdminProvV2')
BEGIN
    INSERT INTO Traducciones
        (IdFuncion, Pantalla, Control, IdIdioma, Texto)
    SELECT IdFuncion + 'V2', Pantalla, Control, IdIdioma, Texto
      FROM Traducciones
     WHERE IdFuncion = 'OrdenCompraAdminProv' OR IdFuncion = 'PresupuestosAdminProv'
END

PRINT ''
PRINT '1.1. Tabla OrdenesProduccionMRPProductos: Nuevo Campo de Cantidades'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'CantidadUnitaria') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD CantidadUnitaria Decimal(16,4) NULL
END
GO

PRINT ''
PRINT '1.2. Tabla OrdenesProduccionMRPProductos: Nuevo Campo de Cantidades'
BEGIN
    UPDATE OrdenesProduccionMRPProductos SET CantidadUnitaria = 0
	ALTER TABLE dbo.OrdenesProduccionMRPProductos ALTER COLUMN CantidadUnitaria Decimal(16, 4) NOT NULL

END
GO

PRINT ''
PRINT 'F1. Nuevo Menu Procesos Productivos: MRP - Consulta de Procesos Productivos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPProcesosProductivosCST') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPProcesosProductivosCST', 'Consulta de Procesos Productivos', 'Consulta de Procesos Productivos', 'True', 'False', 'True', 'True'
        , 'MRP', 110, 'Eniac.Win', 'MRPProcesosProductivosABM', NULL, 'Modo=CONSULTA'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPProcesosProductivosCST' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
