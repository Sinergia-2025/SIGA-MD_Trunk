PRINT ''
PRINT '1. Tabla FormatosEtiquetas, se da de alta formato 2 x Ancho (5 x 3 cm).'
    BEGIN
        DELETE FormatosEtiquetas WHERE IdFormatoEtiqueta = 70;
        DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;
        PRINT @maxId;
        INSERT INTO FormatosEtiquetas
             (IdFormatoEtiqueta, NombreFormatoEtiqueta, Tipo, ArchivoAImprimir, ArchivoAImprimirEmbebido, NombreImpresora, ImprimeLote
             ,MaximoColumnas, UtilizaCabecera, SolicitaListaPrecios2, Activo)
          VALUES
             (@maxId, '2 x Ancho (5 x 3 cm)', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF14.rdlc', 1, '', 0,
              2, 0, 0, 1);
    END
GO

PRINT ''
PRINT '2. Copiar Saldo Service Efectivo.'
    BEGIN
        DECLARE @valorParametro VARCHAR(MAX) = 'False'
        IF dbo.BaseConCuit('30716345501') = 1
            SET @valorParametro = 'True'

        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'CRMNOVEDADESCOPIARSALDOCOMOEFECTIVOALFACTURAR' AS IdParametro, 
                    @valorParametro ValorParametro, 
                    'NULL' CategoriaParametro, 
                    'Copiar saldo como efectivo al Facturar' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END
GO

PRINT ''
PRINT '3. Campo: Depositos Cotizacion Dolar .'
    BEGIN
        ALTER TABLE dbo.Depositos ADD CotizacionDolar decimal(10, 3) NULL
    END
GO

PRINT ''
PRINT '4. Campo: Depositos Cotizacion Dolar .'
    BEGIN
        UPDATE Depositos SET CotizacionDolar = 0;
        ALTER TABLE dbo.Depositos ALTER COLUMN CotizacionDolar decimal(10, 3) NOT NULL
    END
GO
