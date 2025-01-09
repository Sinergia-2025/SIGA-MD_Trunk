DECLARE @idParametro VARCHAR(MAX) 
DECLARE @descripcionParametro VARCHAR(MAX) 
DECLARE @valorParametro VARCHAR(MAX) 

IF dbo.BaseConCuit('30714374938') = 'True' -- EduViajes
BEGIN
    PRINT ''
    PRINT '1. Permitir que todos los clientes se puedan editar desde Mas Info'
    UPDATE Clientes SET ModificarDatos = 1

    PRINT ''
    PRINT '2. Habilitar SubRubro en Parametros'
    SET @idParametro = 'PRODUCTOTIENESUBRUBRO'
    SET @descripcionParametro = 'El Producto tiene SubRubro'
    SET @valorParametro = 'True'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    PRINT ''
    PRINT '3. Habilitar SubRubro en Menu'

    UPDATE F
       SET [Enabled] = 'True'
         , [Visible] = 'True'
         , [EsMenu]  = 'True'
      FROM Funciones F
     WHERE F.Id = 'SubRubros'


    MERGE INTO RolesFunciones AS DEST
            USING (SELECT IdRol, 'SubRubros' IdFuncion FROM RolesFunciones WHERE IdFuncion = 'Rubros') AS ORIG ON DEST.IdRol = ORIG.IdRol AND DEST.IdFuncion = ORIG.IdFuncion
        WHEN NOT MATCHED THEN 
            INSERT (IdRol, IdFuncion) VALUES (ORIG.IdRol, ORIG.IdFuncion)
    ;

    PRINT ''
    PRINT '4. Inicializo datos de SubRubro'

    INSERT INTO [dbo].[SubRubros]
               ([IdRubro],[IdSubRubro],[NombreSubRubro]
               ,[DescuentoRecargoPorc1],[DescuentoRecargoPorc2]
               ,[UnidHasta1],[UnidHasta2],[UnidHasta3],[UnidHasta4],[UnidHasta5]
               ,[UHPorc1],[UHPorc2],[UHPorc3],[UHPorc4],[UHPorc5])
         VALUES
               (4, 4001, 'DESAYUNO', 0, 0,0,0,0,0,0,0,0,0,0,0),
               (4, 4002, 'ALMUERZO', 0, 0,0,0,0,0,0,0,0,0,0,0),
               (4, 4003, 'MERIENDA', 0, 0,0,0,0,0,0,0,0,0,0,0),
               (4, 4004, 'CENA',     0, 0,0,0,0,0,0,0,0,0,0,0);

    PRINT ''
    PRINT '5. Inicializo Parametros de Categorias'

    SET @idParametro = 'TURISMOCATEGORIAESTABLECIMIENTO'
    SET @descripcionParametro = 'Categoria para Establecimiento'
    SET @valorParametro = '1'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
    SET @idParametro = 'TURISMOCATEGORIAPASAJEROS'
    SET @descripcionParametro = 'Categoria para Pasajeros'
    SET @valorParametro = '2'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
    SET @idParametro = 'TURISMOCATEGORIARESPONSABLE'
    SET @descripcionParametro = 'Categoria para Responsables'
    SET @valorParametro = '3'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    PRINT ''
    PRINT '6. Inicializo Parametros de Sincronizacion'

    SET @idParametro = 'SIMOVILCOBRANZAINCLUIRCLIENTES'
    SET @descripcionParametro = 'Incluir Clientes'
    SET @valorParametro = 'TodosLosClientes'

    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    PRINT ''
    PRINT '7. Inicializo Parametros de URL Sincronizacion Turismo'

    SET @idParametro = 'SIMOVILTURISMOURLBASE'
    SET @descripcionParametro = 'URL Base para Simovil Turismo'
    SET @valorParametro = 'http://sinergiamovil.com.ar/simovil.turismo/api/'

    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
END

