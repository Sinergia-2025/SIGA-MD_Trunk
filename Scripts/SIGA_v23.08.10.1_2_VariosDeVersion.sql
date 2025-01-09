IF dbo.ExisteFuncion('Caja') = 1 AND dbo.ExisteFuncion('InformeSaldosCajas') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InformeSaldosCajas', 'Informe Saldos de Cajas', 'Informe de Saldos de Cajas', 'True', 'False', 'True', 'True'
        ,'Caja', 145, 'Eniac.Win', 'InformeSaldosCajas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeSaldosCajas' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END
GO

IF dbo.ExisteFuncion('CRMABMs') = 1 AND dbo.ExisteFuncion('CRMMotivosNovedadesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('CRMMotivosNovedadesABM', 'ABM Motivos de Novedades', 'ABM Motivos de Novedades', 'True', 'False', 'True', 'True'
        ,'CRMABMs', 145, 'Eniac.Win', 'CRMMotivosNovedadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CRMMotivosNovedadesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCANTIDADCARACTERESOBSERVACIONES'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Cantidad caracteres en Observaciones'
DECLARE @valorParametro VARCHAR(MAX) = '100'
IF dbo.BaseConCuit('30711915695') = 1
    SET @valorParametro = '300'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCONTROLATOPECF'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tope Consumidor Final'
DECLARE @valorParametro_NuevoTope DECIMAL(12) = '46360'

UPDATE Parametros
   SET ValorParametro = CASE WHEN ValorParametro < @valorParametro_NuevoTope THEN @valorParametro_NuevoTope ELSE ValorParametro END
 WHERE IdParametro = @idParametro
