
PRINT ''
PRINT '1. Tabla Proveedores: Nuevo campo IdTransportista'
IF dbo.ExisteCampo('Proveedores', 'IdTransportista') = 0
BEGIN
    ALTER TABLE dbo.Proveedores ADD IdTransportista int NULL
END
GO

PRINT ''
PRINT '2. Tabla FormatoEtiquetas: Agrega formato 3 x Ancho (6.4 x 3.39 cm)'
IF NOT EXISTS (select * FROM FormatosEtiquetas where ArchivoAImprimir =  'Eniac.Win.EmisionDeEtiquetasCodBarraF20.rdlc')
BEGIN
    DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;
	INSERT INTO [dbo].[FormatosEtiquetas]
			   ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
			   ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
			   ,[Activo])
		 VALUES
			   (@maxId, '3 x Ancho (6.4 x 3.39 cm) ', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF20.rdlc', 'True'
			   ,'', 'False', 4, 'False', 'False','True');
END
GO

PRINT ''
PRINT '3. Tabla Buscadores: Agregar Buscador de Sucursales y Modelos'
DECLARE @idBuscador60   int = 60
DECLARE @idBuscador208  int = 208
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador60, @idBuscador208)

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador60  IdBuscador, 'Sucursales' Titulo, 720 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
               SELECT @idBuscador208 IdBuscador, 'Modelos'    Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador60  IdBuscador, 'IdSucursal'              IdBuscadorNombreCampo,  1 Orden, 'Código'               Titulo, @alineacion_der Alineacion,   50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador60  IdBuscador, 'Nombre'                  IdBuscadorNombreCampo,  2 Orden, 'Sucursal'             Titulo, @alineacion_izq Alineacion,  200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador60  IdBuscador, 'NombreSucursalAsociada'  IdBuscadorNombreCampo,  3 Orden, 'Sucursal Asociada'    Titulo, @alineacion_izq Alineacion,  200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador60  IdBuscador, 'NombreEmpresa'           IdBuscadorNombreCampo,  4 Orden, 'Empresa'              Titulo, @alineacion_izq Alineacion,  200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador208 IdBuscador, 'IdModelo'                IdBuscadorNombreCampo,  1 Orden, 'Modelo'               Titulo, @alineacion_der Alineacion,   50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador208 IdBuscador, 'NombreModelo'            IdBuscadorNombreCampo,  2 Orden, 'Descripcion'          Titulo, @alineacion_izq Alineacion,  200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador208 IdBuscador, 'IdMarca'                 IdBuscadorNombreCampo,  3 Orden, 'Marca'                Titulo, @alineacion_der Alineacion,   50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador208 IdBuscador, 'NombreMarca'             IdBuscadorNombreCampo,  4 Orden, 'Nombre Marca'         Titulo, @alineacion_izq Alineacion,  200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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
PRINT '4. Tabla Ventas: Agregar IX_Ventas_NumeroReparto'
IF dbo.ExisteIX('IX_Ventas_NumeroReparto') = 0
    CREATE NONCLUSTERED INDEX IX_Ventas_NumeroReparto
         ON [dbo].[Ventas] ([IdSucursal],[MercDespachada],[NumeroReparto])
    INCLUDE ([IdEstadoComprobante],[IdTransportista],[FechaEnvio])
GO
