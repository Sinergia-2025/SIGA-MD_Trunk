PRINT ''
PRINT '1. Tabla ProductosNrosSerie: Ajustar datos de IdSucursalVenta en 0'
UPDATE PNS
   SET IdSucursalVenta = V.IdSucursal
  FROM ProductosNrosSerie PNS
  LEFT JOIN VentasProductos V ON V.IdTipoComprobante = PNS.IdTipoCompVenta AND V.Letra = PNS.LetraVenta AND V.CentroEmisor = PNS.CentroEmisorVenta AND V.NumeroComprobante = PNS.NumeroComprobanteVenta
                             AND V.IdProducto = PNS.IdProducto
 WHERE 1 = 1
   AND PNS.IdSucursalVenta = 0


PRINT ''
PRINT '2. Actualizar SP RenombrarReporte'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[RenombrarReporte]
    @nombreReporteAnterior VARCHAR(MAX),
    @nombreReporteNuevo VARCHAR(MAX),
    @embebidoNuevo CHAR(1)
AS
BEGIN
    DECLARE @rowcount INT = 0
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- TiposComprobantesLetras.ArchivoAImprimir
    UPDATE TiposComprobantesLetras
       SET ArchivoAImprimir = @nombreReporteNuevo,
           ArchivoAImprimirEmbebido = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE ArchivoAImprimirEmbebido END
     WHERE ArchivoAImprimir = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT

    -- TiposComprobantesLetras.ArchivoAImprimir2
    UPDATE TiposComprobantesLetras
       SET ArchivoAImprimir2 = @nombreReporteNuevo,
           ArchivoAImprimirEmbebido2 = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE ArchivoAImprimirEmbebido2 END
     WHERE ArchivoAImprimir2 = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT

    -- TiposComprobantesLetras.ArchivoAImprimirComplementario
    UPDATE TiposComprobantesLetras
       SET ArchivoAImprimirComplementario = @nombreReporteNuevo,
           ArchivoAImprimirComplementarioEmbebido = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE ArchivoAImprimirEmbebido END
     WHERE ArchivoAImprimirComplementario = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT

    -- TiposComprobantesLetras.ArchivoAExportar
    UPDATE TiposComprobantesLetras
       SET ArchivoAExportar = @nombreReporteNuevo,
           ArchivoAExportarEmbebido = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE ArchivoAImprimirEmbebido END
     WHERE ArchivoAExportar = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT

    -- PersonalizacionDeInformes.NombreArchivo
    UPDATE PersonalizacionDeInformes
       SET NombreArchivo = @nombreReporteNuevo,
           embebido = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE embebido END
     WHERE NombreArchivo = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT

    PRINT '    ' + @nombreReporteNuevo + ' = ' + CONVERT(VARCHAR(MAX),@rowcount)

END

