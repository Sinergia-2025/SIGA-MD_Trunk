PRINT ''
PRINT '1. Nueva Función: Chequeras'
IF dbo.ExisteFuncion('Caja') = 1 AND dbo.ExisteFuncion('ChequerasABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ChequerasABM', 'ABM de Chequeras', 'ABM de Chequeras', 'True', 'False', 'True', 'True'
        ,'Caja', 100, 'Eniac.Win', 'ChequerasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ChequerasABM' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO


PRINT ''
PRINT '2. Nuevo Comprobante específico para el cliente 393.'
IF dbo.BaseConCuit('30710595158') = 1
BEGIN
    --# COTIZACION
    IF (SELECT COUNT(1) FROM TiposComprobantesLetras WHERE IdTipoComprobante = 'COTIZACION' AND Letra = 'X') = 0
    BEGIN
        INSERT INTO [dbo].[TiposComprobantesLetras]
           ([IdTipoComprobante], [Letra], [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora]
          , [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], [ArchivoAImprimir2]
          , [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido], [ArchivoAExportar], [ArchivoAExportarEmbebido]
          , [IdTipoImpresionFiscalArchivoAImprimir], [IdTipoImpresionFiscalArchivoAImprimir2], [IdTipoImpresionFiscalArchivoAImprimirComplementario], [IdTipoImpresionFiscalArchivoAExportar]
          , [DesplazamientoXArchivoAImprimir], [DesplazamientoYArchivoAImprimir], [DesplazamientoXArchivoAImprimir2], [DesplazamientoYArchivoAImprimir2]
          , [DesplazamientoXArchivoAImprimirComplementario], [DesplazamientoYArchivoAImprimirComplementario], [DesplazamientoXArchivoAExportar], [DesplazamientoYArchivoAExportar])
        VALUES
           ('COTIZACION', 'X', '393_Comprobante.rdlc', 0, ''
          , 24, 23, 0, 1, ''
          , 0, '', 0, '', 0
          , 2, 2, 2, 2
          , 0, 0, 0, 0
          , 0, 0, 0, 0)
    END

    --# eFACT A
    IF (SELECT COUNT(1) FROM TiposComprobantesLetras WHERE IdTipoComprobante = 'eFACT' AND Letra = 'A') = 0
    BEGIN
        INSERT INTO [dbo].[TiposComprobantesLetras]
           ([IdTipoComprobante], [Letra], [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora]
          , [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], [ArchivoAImprimir2]
          , [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido], [ArchivoAExportar], [ArchivoAExportarEmbebido]
          , [IdTipoImpresionFiscalArchivoAImprimir], [IdTipoImpresionFiscalArchivoAImprimir2], [IdTipoImpresionFiscalArchivoAImprimirComplementario], [IdTipoImpresionFiscalArchivoAExportar]
          , [DesplazamientoXArchivoAImprimir], [DesplazamientoYArchivoAImprimir], [DesplazamientoXArchivoAImprimir2], [DesplazamientoYArchivoAImprimir2]
          , [DesplazamientoXArchivoAImprimirComplementario], [DesplazamientoYArchivoAImprimirComplementario], [DesplazamientoXArchivoAExportar], [DesplazamientoYArchivoAExportar])
        VALUES
           ('eFACT'
          , 'A', '393_eComprobante_A.rdlc', 0, ''
          , 99, 99, 0, 1, ''
          , 0, '', 0, '', 0
          , 2, 2, 2, 2
          , 0, 0, 0, 0
          , 0, 0, 0, 0)
    END
    
    --# eFACT B
    IF (SELECT COUNT(1) FROM TiposComprobantesLetras WHERE IdTipoComprobante = 'eFACT' AND Letra = 'B') = 0
    BEGIN
        INSERT INTO [dbo].[TiposComprobantesLetras]
           ([IdTipoComprobante], [Letra], [ArchivoAImprimir], [ArchivoAImprimirEmbebido], [NombreImpresora]
          , [CantidadItemsProductos], [CantidadItemsObservaciones], [Imprime], [CantidadCopias], [ArchivoAImprimir2]
          , [ArchivoAImprimirEmbebido2], [ArchivoAImprimirComplementario], [ArchivoAImprimirComplementarioEmbebido], [ArchivoAExportar], [ArchivoAExportarEmbebido]
          , [IdTipoImpresionFiscalArchivoAImprimir], [IdTipoImpresionFiscalArchivoAImprimir2], [IdTipoImpresionFiscalArchivoAImprimirComplementario], [IdTipoImpresionFiscalArchivoAExportar]
          , [DesplazamientoXArchivoAImprimir], [DesplazamientoYArchivoAImprimir], [DesplazamientoXArchivoAImprimir2], [DesplazamientoYArchivoAImprimir2]
          , [DesplazamientoXArchivoAImprimirComplementario], [DesplazamientoYArchivoAImprimirComplementario], [DesplazamientoXArchivoAExportar], [DesplazamientoYArchivoAExportar])
        VALUES
           ('eFACT'
          , 'B', '393_eComprobante_B.rdlc', 0, ''
          , 99, 99, 0, 1, ''
          , 0, '', 0, '', 0
          , 2, 2, 2, 2
          , 0, 0, 0, 0
          , 0, 0, 0, 0)
    END
END
