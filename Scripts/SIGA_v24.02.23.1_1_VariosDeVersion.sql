PRINT ''
PRINT 'F1. Nuevo Menu Sincronizacion Movil'
IF dbo.ExisteFuncion('Concesionarios') = 1 AND dbo.ExisteFuncion('ConcesionarioSincronizacionM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('ConcesionarioSincronizacionM', 'Sincronización Movil', 'Sincronización Movil', 'True', 'False', 'True', 'True'
        , 'Concesionarios', 200, 'Eniac.Win', 'SincronizacionOperaciones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConcesionarioSincronizacionM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILGESTIONURLBASE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'URL Base API Gestión'
DECLARE @valorParametro VARCHAR(MAX) = 'http://sinergiamovil.com.ar/simovilgestion/api/'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

IF dbo.ExisteFuncion('Ayuda') = 1 AND dbo.ExisteFuncion('SolicitarSoporte') = 0
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('SolicitarSoporte', 'Solicitar Soporte', 'Solicitar Soporte', 'True', 'False', 'True', 'True'
        ,'Ayuda', 100, 'Eniac.Win', 'SolicitarSoporte', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SolicitarSoporte' AS Pantalla FROM dbo.Roles
END