PRINT ''
PRINT '1. Parametro: MRP: Tipo Comprobante Orden de Produccion en Planificacion'
DECLARE @idParametro VARCHAR(MAX) = 'TIPOCOMPROBANTEORDENPRODUCCIONPLANIFICACION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Tipo Comprobante Orden de Produccion en Planificacion '
DECLARE @valorParametro VARCHAR(MAX) = 'ORDENPRODUCCION'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'F1. Nuevo Menu Procesos Productivos: MRP - ABM de Procesos Productivos'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPPlanificacionProduccion') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPPlanificacionProduccion', 'Planificacion de Necesidades de Producción.', 'Planificacion de Necesidades de Producción.', 'True', 'False', 'True', 'True'
        ,'MRP', 400, 'Eniac.Win', 'MRPPlanificacionNecesidadesProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPPlanificacionProduccion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

------------------------------------------------------------------------------------------------------------------------

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPConceptosNoProductivosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPConceptosNoProductivosABM', 'ABM de Conceptos No Productivos', 'ABM de Conceptos No Productivos', 'True', 'False', 'True', 'True'
        ,'MRP', 2150, 'Eniac.Win', 'MRPConceptosNoProductivosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPConceptosNoProductivosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '1. Parametro: MRP: Estado Orden de Produccion en Planificacion'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOORDENPRODUCCIONPLANIFICACION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado Orden de Produccion en Planificacion '
DECLARE @valorParametro VARCHAR(MAX) = ''

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

