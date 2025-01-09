/****** Object:  StoredProcedure [dbo].[RenombrarReporte]    Script Date: 21/05/2019 15:30:40 ******/
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RenombrarReporte')
    DROP PROCEDURE [dbo].[RenombrarReporte]
GO

/****** Object:  StoredProcedure [dbo].[RenombrarReporte]    Script Date: 21/05/2019 15:30:40 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RenombrarReporte]
    @nombreReporteAnterior VARCHAR(MAX),
    @nombreReporteNuevo VARCHAR(MAX),
    @embebidoNuevo CHAR(1)
AS
BEGIN
    DECLARE @rowcount INT = 0
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE TiposComprobantesLetras
       SET ArchivoAImprimir = @nombreReporteNuevo,
           ArchivoAImprimirEmbebido = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE ArchivoAImprimirEmbebido END
     WHERE ArchivoAImprimir = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT
    UPDATE TiposComprobantesLetras
       SET ArchivoAImprimir2 = @nombreReporteNuevo,
           ArchivoAImprimirEmbebido2 = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE ArchivoAImprimirEmbebido2 END
     WHERE ArchivoAImprimir2 = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT
    UPDATE PersonalizacionDeInformes
       SET NombreArchivo = @nombreReporteNuevo,
           embebido = CASE @embebidoNuevo WHEN 'N' THEN 0 WHEN 'S' THEN 1 ELSE embebido END
     WHERE NombreArchivo = @nombreReporteAnterior;
     SET @rowcount = @rowcount+ @@ROWCOUNT

    PRINT '    ' + @nombreReporteNuevo + ' = ' + CONVERT(VARCHAR(MAX),@rowcount)

END

GO


