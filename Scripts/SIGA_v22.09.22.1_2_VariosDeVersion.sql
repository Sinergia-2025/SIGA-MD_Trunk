PRINT ''
PRINT '1. Tabla ConcesionarioOperaciones: Nuevo campo IdEjeCeroKilometro'
IF dbo.ExisteCampo('ConcesionarioOperaciones', 'IdEjeCeroKilometro') = 0
BEGIN
    ALTER TABLE dbo.ConcesionarioOperaciones ADD IdEjeCeroKilometro int NULL
    ALTER TABLE dbo.ConcesionarioOperaciones ADD CONSTRAINT FK_ConcesionarioOperaciones_ConcesionarioDistribucionEjes
        FOREIGN KEY (IdEjeCeroKilometro)
        REFERENCES dbo.ConcesionarioDistribucionEjes (IdEje)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

PRINT ''
PRINT '2. Tabla BuscadoresCampos: Bancos actualiza Buscador'
UPDATE BuscadoresCampos SET IdBuscador = 40 where IdBuscador = 30 AND IdBuscadorNombreCampo = 'IdBanco'
UPDATE BuscadoresCampos SET IdBuscador = 40 where IdBuscador = 30 AND IdBuscadorNombreCampo = 'NombreBanco'

DECLARE @idBuscador int = 35
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

PRINT ''
PRINT '3. Buscadores: Nuevo Buscador Localidades'
MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Localidades' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador IdBuscador, 'IdLocalidad' IdBuscadorNombreCampo,      1 Orden, 'Código'    Titulo, @alineacion_der Alineacion, 70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreLocalidad' IdBuscadorNombreCampo,  2 Orden, 'Localidad' Titulo, @alineacion_izq Alineacion, 70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreProvincia' IdBuscadorNombreCampo,  3 Orden, 'Provincia' Titulo, @alineacion_izq Alineacion, 70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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
