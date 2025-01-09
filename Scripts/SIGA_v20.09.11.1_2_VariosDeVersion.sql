PRINT ''
PRINT '1. Parametrización Metalsur'
IF dbo.BaseConCuit('33631312379') = 1
BEGIN
    DECLARE @idParametro VARCHAR(MAX)
    DECLARE @descripcionParametro VARCHAR(MAX)
    DECLARE @valorParametro VARCHAR(MAX)

    PRINT ''
    PRINT '1.1. Parámetro PRODUCTOCODIGONUMERICO'
    SET @idParametro = 'PRODUCTOCODIGONUMERICO'
    SET @descripcionParametro = 'Codigo de Producto es numérico'
    SET @valorParametro = 'True'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    PRINT ''
    PRINT '1.2. Parámetro METALSURURLBASEWEBOC'
    SET @idParametro = 'METALSURURLBASEWEBOC'
    SET @descripcionParametro = 'Base URL para OC Web de Metalsur'
    SET @valorParametro = 'http://www.arborea.com.ar/metalsur/rest-metal/index.php/api/'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

    PRINT ''
    PRINT '1.3. Parámetro WEBARCHIVOSCARPETAEXPORTACION'
    SET @idParametro = 'WEBARCHIVOSCARPETAEXPORTACION'
    SET @descripcionParametro = 'Carpeta exportacion'
    SET @valorParametro = 'd:\Temp\_json_meta'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;


    PRINT ''
    PRINT '1.4. Provincia y Localidad A Definir'
    INSERT INTO Provincias
               (IdProvincia,NombreProvincia
               ,EsAgentePercepcion,IngBrutos,AgenteIngBrutos,IdCuentaDebe,IdCuentaHaber
               ,Jurisdiccion,IdPais)
         VALUES
               ('1', 'A Definir'
               , 'False', NULL, NULL, NULL, NULL
               , 0, 'ARS')

    INSERT INTO Localidades
               (IdLocalidad,NombreLocalidad,IdProvincia)
         VALUES
               (1, 'A Definir', '1')
END
