
PRINT ''
PRINT '1. Parametro: Venta CF con DNI pasa a $ 5000.'
GO

DECLARE @topeActual int
DECLARE @topeNuevo  int = 5000

SELECT @topeActual = ValorParametro FROM Parametros WHERE IdParametro = 'FACTURACIONCONTROLATOPECF'

IF @topeActual < @topeNuevo
    UPDATE Parametros SET ValorParametro = @topeNuevo WHERE IdParametro = 'FACTURACIONCONTROLATOPECF';
    --Según RG 4290 que modifica la RG 1415

--SELECT * FROM Parametros WHERE IdParametro = 'FACTURACIONCONTROLATOPECF'


PRINT ''
PRINT '2. Parametro: DebitoAutomatico seteo para HAR.'
GO


IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN

    MERGE INTO Parametros AS P
         USING (SELECT 'DEBITOAUTOMATICOSANTANDERCODIGOSERVICIO'   AS IdParametro, 'SOFTWARE' ValorParametro,   'Código de Servicio'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);
END

--SELECT * FROM Parametros WHERE IdParametro = 'DEBITOAUTOMATICOSANTANDERCODIGOSERVICIO'


PRINT ''
PRINT '3. Nuevo Menu: Archivos\Consultar Clientes.'
GO

DELETE FROM RolesFunciones WHERE IdFuncion = 'ConsultaClientes';
DELETE FROM Funciones WHERE Id = 'ConsultaClientes';

INSERT INTO Funciones
	(Id, Nombre, Descripcion
	,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	VALUES
	('ConsultaClientes', 'Consulta de Clientes', 'Consulta de Clientes', 
	'True', 'False', 'True', 'True', 'Archivos', 25, 'Eniac.Win', 'ClientesABM', NULL, 'Consultar')
;

INSERT INTO RolesFunciones 
	            (IdRol,IdFuncion)
SELECT IdRol,'ConsultaClientes'
    FROM RolesFunciones WHERE IdFuncion = 'Clientes'
;
