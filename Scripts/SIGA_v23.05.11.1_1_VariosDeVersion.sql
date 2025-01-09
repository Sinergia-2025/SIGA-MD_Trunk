PRINT ''
PRINT '1. Parametros: Cantidad de enteros en Cantidad (solo Rápida)'
DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCANTIDADENTEROSENCANTIDAD'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Cantidad de enteros en Cantidad (solo Rápida)'
DECLARE @valorParametro VARCHAR(MAX) = '4'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '2. Tabla Buscadores: Agregar Buscador de Asientos Contables'
DECLARE @idBuscador2000 int = 2000
DECLARE @alineacion_der int = 64
DECLARE @alineacion_cen int = 32
DECLARE @alineacion_izq int = 16

DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador2000)

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador2000 IdBuscador, 'Asientos Contables' Titulo, 1000 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
;

MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador2000 IdBuscador, 'IdAsiento'           IdBuscadorNombreCampo,  1 Orden, 'Asiento'      Titulo, @alineacion_der Alineacion,   80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'NombreAsiento'       IdBuscadorNombreCampo,  2 Orden, 'Nombre'       Titulo, @alineacion_izq Alineacion,  300 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'FechaAsiento'        IdBuscadorNombreCampo,  3 Orden, 'Fecha'        Titulo, @alineacion_cen Alineacion,   80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'NombrePlanCuenta'    IdBuscadorNombreCampo,  4 Orden, 'Plan'         Titulo, @alineacion_izq Alineacion,  100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'IdEjercicio'         IdBuscadorNombreCampo,  5 Orden, 'Ejer.'        Titulo, @alineacion_der Alineacion,   50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               --SELECT @idBuscador2000 IdBuscador, 'IdTipoDoc'           IdBuscadorNombreCampo,  6 Orden, 'Tipo'         Titulo, @alineacion_izq Alineacion,   80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'SubsiAsiento'        IdBuscadorNombreCampo,  6 Orden, 'Subsistema'   Titulo, @alineacion_izq Alineacion,   80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'NombreSucursal'      IdBuscadorNombreCampo,  7 Orden, 'Sucursal'     Titulo, @alineacion_izq Alineacion,  100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'EsManual'            IdBuscadorNombreCampo,  8 Orden, 'Manual'       Titulo, @alineacion_cen Alineacion,   50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador2000 IdBuscador, 'NombreEstadoAsiento' IdBuscadorNombreCampo,  9 Orden, 'Estado'       Titulo, @alineacion_izq Alineacion,  100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
;
GO

PRINT ''
PRINT '3. Tabla Buscadores: Agregar Buscador de Observaciones'
DECLARE @idBuscador95   int = 95  
DECLARE @alineacion_der int = 64
DECLARE @alineacion_cen int = 32
DECLARE @alineacion_izq int = 16

DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador95)

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador95 IdBuscador, 'Observaciones' Titulo, 560 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
;

MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador95 IdBuscador, 'DetalleObservacion'  IdBuscadorNombreCampo,  1 Orden, 'Observación'  Titulo, @alineacion_izq Alineacion,  500 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
;
GO
