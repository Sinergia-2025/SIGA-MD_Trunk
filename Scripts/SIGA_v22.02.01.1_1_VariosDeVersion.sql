
PRINT ''
PRINT '1. Parametros: Ubicacion de Parametro'
BEGIN
    ALTER TABLE dbo.Parametros ADD UbicacionParametro varchar(MAX) NULL
    ALTER TABLE dbo.AuditoriaParametros ADD UbicacionParametro varchar(MAX) NULL
END
GO

PRINT ''
PRINT '2. Buscador Zona Geografica.-'
BEGIN
    DECLARE @id int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
    INSERT INTO [dbo].[Buscadores]
               ([IdBuscador],[Titulo]           ,[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
         VALUES
               (@id         ,'Zonas Geograficas',400         ,'Grilla'         ,'')
    INSERT INTO [dbo].[BuscadoresCampos]
               ([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
         VALUES
               (@id, 'IdZonaGeografica',     1, 'Codigo', 16,  80, '', NULL, NULL, NULL),
               (@id, 'NombreZonaGeografica', 2, 'Nombre', 16, 250, '', NULL, NULL, NULL)
END
GO

PRINT ''
PRINT '3. Muestra Observacion Comprobantes.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'MOSTRAROBSERVACIONDECOMPROBANTES' AS IdParametro, 
                'False' ValorParametro, 
                '' CategoriaParametro, 
                'MOSTRAROBSERVACIONDECOMPROBANTES' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT '4. Parametros: Setea parametro 180dias'
BEGIN
    UPDATE Parametros 
    SET ValorParametro = '180' 
    WHERE IdParametro = 'CTACTECANTDIASDHRECIBOS' AND ValorParametro = '0'
END
GO



