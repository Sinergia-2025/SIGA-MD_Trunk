DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONRAPIDAMOSTRARLISTAPRECIO'
DECLARE @descripcionParametro VARCHAR(MAX) = ''
DECLARE @valorParametro VARCHAR(MAX) = 'False'
-- D5M
--IF dbo.BaseConCuit('23278908704') = 1 

-- Facturacion/Rapida: En caso que no actualice todos los precios, es conveniente mostrar la Lista
IF dbo.GetValorParametro('ACTUALIZAPRECIOSDEVENTA') = 'False'
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
SET @idParametro = 'FACTURACIONRAPIDAMOSTRARPRUNITARIO'
-- Siempre lo Muestro. Cada vez mas Clientes utilizan descuento general o individual.
SET @valorParametro = 'True'
MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

--SELECT * FROM Parametros
--WHERE IdParametro IN ('ACTUALIZAPRECIOSDEVENTA','FACTURACIONRAPIDAMOSTRARLISTAPRECIO','FACTURACIONRAPIDAMOSTRARPRUNITARIO')
--;