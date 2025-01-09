PRINT ''
PRINT '1. Nuevo Parámetro: FACTURACIONCANTIDADDECIMALESENCOTIZACIONDOLAR'

DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCANTIDADDECIMALESENCOTIZACIONDOLAR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Facturación: Cantidad de decimales en la cotización del Dolar'
DECLARE @valorParametro INT = 2
IF dbo.BaseConCuit('33714918449') = 1 -- BBP Amoblamientos
    SET @valorParametro = 4

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '2. Cotización Dolar: Se agrega la posibilidad de ingresar hasta 4 decimales'
ALTER TABLE Ventas 
	ALTER COLUMN CotizacionDolar DECIMAL(10,4) NOT NULL

GO

PRINT ''
PRINT '3.- Seteo de Comprobantes para D. LAS MELLIS: Recibo Provisorio.'
IF dbo.BaseConCuit('27276336636') = 'True' -- Distribuidora Las Mellis
BEGIN
		PRINT ''
		PRINT '3.1.- Seteo de Comprobantes para D. LAS MELLIS: Factura Compra.'
			INSERT [dbo].[TiposComprobantesLetras] 
				([IdTipoComprobante], [Letra], 
				 [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora], [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], 
				 [ArchivoAImprimir2], [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido]) 
				VALUES  ('RECIBOPROV', 'X', 
				 '351_ReciboProvisorio.rdlc', 'False', '', 99, 98, 1, 1, 
				 '', 'False', '', 'False')
		
		
		PRINT ''
		PRINT '3.2.- Seteo de Comprobantes para D. LAS MELLIS: Factura Compra.'
			INSERT [dbo].[TiposComprobantesLetras] 
						([IdTipoComprobante], [Letra], 
						 [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora], [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], 
						 [ArchivoAImprimir2], [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido]) 
				VALUES  ('FACTCOM', 'A', 
						 '351_ComprobanteCompra.rdlc', 'False', '', 99, 98, 1, 1, 
						 '', 'False', '', 'False')
		
		
		PRINT ''
		PRINT '3.3.- Seteo de Comprobantes para D. LAS MELLIS: Factura Compra.'
			INSERT [dbo].[TiposComprobantesLetras] 
						([IdTipoComprobante], [Letra], 
						 [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora], [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], 
						 [ArchivoAImprimir2], [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido]) 
				VALUES  ('FACTCOM', 'B', 
						 '351_ComprobanteCompra.rdlc', 'False', '', 99, 98, 1, 1, 
						 '', 'False', '', 'False')
		PRINT ''
		PRINT '3.4.- Seteo de Comprobantes para D. LAS MELLIS: Factura Compra.'
			INSERT [dbo].[TiposComprobantesLetras] 
						([IdTipoComprobante], [Letra], 
						 [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora], [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], 
						 [ArchivoAImprimir2], [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido]) 
				VALUES  ('COTIZACIONCOM', 'X', 
						 '351_ComprobanteCompra.rdlc', 'False', '', 99, 98, 1, 1, 
						 '', 'False', '', 'False')

END

GO

PRINT ''
PRINT '4. Nuevo Parámetro: FACTURACIONCANTIDADENTEROSENCOTIZACIONDOLAR'

DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCANTIDADENTEROSENCOTIZACIONDOLAR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Facturación: Cantidad de enteros en la cotización del Dolar'
DECLARE @valorParametro INT = 3
--IF dbo.BaseConCuit('33714918449') = 1
    --SET @valorParametro = 4

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;