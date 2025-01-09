PRINT ''
PRINT '2. Tabla Buscadores: Agregar Buscador de Asientos Contables'
DECLARE @idBuscador300  int = 300
DECLARE @alineacion_der int = 64
DECLARE @alineacion_cen int = 32
DECLARE @alineacion_izq int = 16

DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador300)

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador300 IdBuscador, 'Lotes' Titulo, 760 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador300 IdBuscador, 'IdLote'           IdBuscadorNombreCampo,  1 Orden, 'Lote'             Titulo, @alineacion_izq Alineacion,  140 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador300 IdBuscador, 'IdProducto'       IdBuscadorNombreCampo,  2 Orden, 'Producto'         Titulo, @alineacion_der Alineacion,  100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador300 IdBuscador, 'NombreProducto'   IdBuscadorNombreCampo,  3 Orden, 'Nombre Producto'  Titulo, @alineacion_izq Alineacion,  180 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador300 IdBuscador, 'FechaVencimiento' IdBuscadorNombreCampo,  4 Orden, 'Vencimiento'      Titulo, @alineacion_cen Alineacion,   70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador300 IdBuscador, 'CantidadInicial'  IdBuscadorNombreCampo,  5 Orden, 'Cant. Inicial'    Titulo, @alineacion_der Alineacion,   70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador300 IdBuscador, 'CantidadActual'   IdBuscadorNombreCampo,  6 Orden, 'Cant. Actual'     Titulo, @alineacion_der Alineacion,   70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador300 IdBuscador, 'PrecioCosto'      IdBuscadorNombreCampo,  7 Orden, 'Precio Costo'     Titulo, @alineacion_der Alineacion,   70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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
PRINT '2. Tabla Buscadores: Agregar Buscador de Asientos Contables'
DECLARE @idBuscador310  int = 310
DECLARE @alineacion_der int = 64
DECLARE @alineacion_cen int = 32
DECLARE @alineacion_izq int = 16

DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador310)

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador310 IdBuscador, 'Despachos' Titulo, 500 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador310 IdBuscador, 'FechaOficializacionDespacho'  IdBuscadorNombreCampo,  1 Orden, 'Oficialización'   Titulo, @alineacion_cen Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador310 IdBuscador, 'Despacho'       IdBuscadorNombreCampo,  2 Orden, 'Despacho'   Titulo, @alineacion_izq Alineacion,  180 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador310 IdBuscador, 'NombreAduana'   IdBuscadorNombreCampo,  3 Orden, 'Aduana'     Titulo, @alineacion_izq Alineacion,  180 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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
