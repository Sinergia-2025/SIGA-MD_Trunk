PRINT ''
PRINT '1. Nuevo Parámetro: Mostrar Prov. Habitual en la grilla de Facturación'
DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONMUESTRAPROVHABITUAL'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Facturación: Mostrar Prov. Habitual en la grilla'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30712079459') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '2. Nuevo Parámetro: Mostrar Prov. Habitual en la grilla de Pedidos'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSMUESTRAPROVHABITUAL'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedidos: Mostrar Prov. Habitual en la grilla'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30712079459') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '3. Nuevo Parámetro: Mostrar Prov. Habitual en la grilla de Pedidos Prov.'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSPROVMUESTRAPROVHABITUAL'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedidos Prov.: Mostrar Prov. Habitual en la grilla'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30712079459') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '4. Nueva Función: Exportación de Compras'
IF dbo.ExisteFuncion('Compras') = 1 
BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('ExportacionDeCompras', 'Exportación de Compras', 'Exportación de Compras', 'True', 'False', 'True', 'True'
	    ,'Compras', 200, 'Eniac.Win', 'ExportacionDeCompras', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ExportacionDeCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO