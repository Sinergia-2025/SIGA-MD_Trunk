PRINT ''
PRINT '1. Nueva opción de menu ABM de Estados de Asiento'
IF dbo.ExisteFuncion('Contabilidad') = 1 AND dbo.ExisteFuncion('ContabilidadEstadosAsientosABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ContabilidadEstadosAsientosABM', 'ABM de Estados de Asiento', 'ABM de Estados de Asiento', 'True', 'False', 'True', 'True'
        ,'Contabilidad', 335, 'Eniac.Win', 'ContabilidadEstadosAsientosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ContabilidadEstadosAsientosABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Nueva opción de menu ABM de Asientos PARA APROBAR'
IF dbo.ExisteFuncion('Contabilidad') = 1 AND dbo.ExisteFuncion('ContabilidadAsientosABM_PA') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ContabilidadAsientosABM_PA', 'ABM de Asientos PARA APROBAR', 'ABM de Asientos PARA APROBAR', 'True', 'False', 'True', 'True'
        ,'Contabilidad', 15, 'Eniac.Win', 'ContabilidadAsientosABM', NULL, 'IdEstadoAsiento=2'
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ContabilidadAsientosABM_PA' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '3. Nuevo parámetro LOGISTICANORMALIZACLIENTESENRUTAS'
DECLARE @clientesLiveABM int = (SELECT COUNT(1) FROM Funciones WHERE Pantalla = 'ClientesLiveABM')
DECLARE @clientesABM int = (SELECT COUNT(1) FROM Funciones WHERE Pantalla = 'ClientesABM')

DECLARE @idParametro VARCHAR(MAX) = 'LOGISTICANORMALIZACLIENTESENRUTAS'
DECLARE @descripcionParametro VARCHAR(MAX) = 'LOGISTICANORMALIZACLIENTESENRUTAS'
DECLARE @valorParametro VARCHAR(MAX) = 'True'
IF @clientesLiveABM > 0 AND @clientesABM = 0
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
