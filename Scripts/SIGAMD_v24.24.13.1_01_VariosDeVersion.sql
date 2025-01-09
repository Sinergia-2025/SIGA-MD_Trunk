PRINT ''
PRINT '3. Nuevo buscador de Medios'

DECLARE @idBuscador INT = 22
DECLARE @alineacion_der INT = 64
DECLARE @alineacion_izq INT = 16

-- MERGE para la tabla Buscadores
MERGE INTO [dbo].[Buscadores] AS D
USING (SELECT @idBuscador AS IdBuscador, 
              'CRMMediosComunicacionesNovedades' AS Titulo, 
              1000 AS AnchoAyuda, 
              'Grilla' AS IniciaConFocoEn, 
              '' AS ColumaBusquedaInicial) AS O 
ON D.IdBuscador = O.IdBuscador
WHEN MATCHED THEN
    UPDATE SET D.Titulo = O.Titulo,
               D.AnchoAyuda = O.AnchoAyuda,
               D.IniciaConFocoEn = O.IniciaConFocoEn,
               D.ColumaBusquedaInicial = O.ColumaBusquedaInicial
WHEN NOT MATCHED THEN 
    INSERT (IdBuscador, Titulo, AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial) 
    VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);

-- MERGE para la tabla BuscadoresCampos
MERGE INTO [dbo].[BuscadoresCampos] AS D
USING (
       SELECT @idBuscador AS IdBuscador, 
              'IdMedioComunicacionNovedad' AS IdBuscadorNombreCampo, 
              1 AS Orden, 
              'Código' AS Titulo, 
              @alineacion_der AS Alineacion, 
              70 AS Ancho, 
              '' AS Formato, 
              NULL AS Condicion, 
              NULL AS Valor, 
              NULL AS ColorFila 
       UNION ALL
       SELECT @idBuscador AS IdBuscador, 
              'NombreMedioComunicacionNovedad' AS IdBuscadorNombreCampo, 
              2 AS Orden, 
              'Nombre' AS Titulo, 
              @alineacion_izq AS Alineacion, 
              200 AS Ancho, 
              '' AS Formato, 
              NULL AS Condicion, 
              NULL AS Valor, 
              NULL AS ColorFila 
) AS O 
ON D.IdBuscador = O.IdBuscador 
   AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
WHEN MATCHED THEN
    UPDATE SET D.Orden = O.Orden,
               D.Titulo = O.Titulo,
               D.Alineacion = O.Alineacion,
               D.Ancho = O.Ancho,
               D.Formato = O.Formato,
               D.Condicion = O.Condicion,
               D.Valor = O.Valor,
               D.ColorFila = O.ColorFila
WHEN NOT MATCHED THEN 
    INSERT (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila) 
    VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila);
