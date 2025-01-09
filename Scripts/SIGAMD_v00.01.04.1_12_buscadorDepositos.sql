
PRINT ''
PRINT '1. Nuevo Buscador: D`posito'
DECLARE @idBuscador int = 55
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Depositos' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador IdBuscador, 'IdSucursal'              IdBuscadorNombreCampo,  1 Orden, 'Sucursal'				Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreSucursal'          IdBuscadorNombreCampo,  2 Orden, 'Nombre Sucursal'      Titulo, @alineacion_izq Alineacion, 200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'IdDeposito'				IdBuscadorNombreCampo,  3 Orden, 'Deposito'				Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreDeposito'			IdBuscadorNombreCampo,  4 Orden, 'Localidad'			Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'TipoDeposito'			IdBuscadorNombreCampo,  5 Orden, 'Tipo'					Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila 
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