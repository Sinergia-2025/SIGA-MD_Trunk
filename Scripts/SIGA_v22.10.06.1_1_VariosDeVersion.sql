PRINT ''
PRINT '1. Tabla ProductosComponentes: Nuevo campo PorcCostoProduccion'
IF dbo.ExisteCampo('ProductosComponentes', 'PorcCostoProduccion') = 0
    ALTER TABLE dbo.ProductosComponentes ADD PorcCostoProduccion decimal(16, 6) NULL
GO

PRINT ''
PRINT '1.1. Tabla ProductosComponentes: PorcCostoProduccion valor por defecto 0'
UPDATE ProductosComponentes SET PorcCostoProduccion = 0;
PRINT ''
PRINT '1.2. Tabla ProductosComponentes: PorcCostoProduccion NO NULL'
ALTER TABLE dbo.ProductosComponentes ALTER COLUMN PorcCostoProduccion decimal(16, 6) NOT NULL
GO

PRINT ''
PRINT '1.3. Tabla ProductosComponentes: Calculo de PorcCostoProduccion actual'
--UPDATE PC
--   SET PorcCostoProduccion = (PS.PrecioCosto * Cantidad) / PCT.ImporteTotalCosto * 100
UPDATE PC
   SET PorcCostoProduccion = ISNULL((PS.PrecioCosto * Cantidad) / NULLIF(PCT.IMPORTETOTALCOSTO, 0)* 100, 0)
  FROM ProductosComponentes PC
 CROSS JOIN (SELECT * FROM Sucursales WHERE SoyLaCentral = 1) S
 INNER JOIN ProductosSucursales PS ON PS.IdSucursal = S.IdSucursal AND PS.IdProducto = PC.IdProductoComponente
 INNER JOIN (SELECT PC.IdProducto, PC.IdFormula, SUM(PS.PrecioCosto * Cantidad) AS ImporteTotalCosto
              FROM ProductosComponentes PC
             CROSS JOIN (SELECT * FROM Sucursales WHERE SoyLaCentral = 1) S
             INNER JOIN ProductosSucursales PS ON PS.IdSucursal = S.IdSucursal AND PS.IdProducto = PC.IdProductoComponente
             GROUP BY PC.IdProducto, PC.IdFormula) PCT ON PCT.IdProducto = PC.IdProducto AND PCT.IdFormula = PC.IdFormula
GO


PRINT ''
PRINT '2. Nuevo parámetro: Actualiza Descripcion de Producto Tienda Nube.-'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 
            'TIENDANUBEACTUALIZAPRODUCTODESCRIPCION' AS IdParametro, 
            'AMBAS' ValorParametro, 
            'Arborea' CategoriaParametro, 
            'Actualizacion Descrip Producto' DescripcionParametro FROM Empresas) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);


PRINT ''
PRINT '3. Menu RegistracionPagos: Reemplazar por RegistracionPagosV2 y eliminar.'
IF dbo.ExisteFuncion('RegistracionPagos') = 1 AND dbo.ExisteFuncion('RegistracionPagosV2') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('RegistracionPagosV2', 'Registración de Pagos (v2)', 'Registración de Pagos (v2)', 'True', 'False', 'True', 'True'
        ,'Logistica', 45, 'Eniac.Win', 'RegistracionPagosV2', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'RegistracionPagosV2' FROM RolesFunciones WHERE IdFuncion = 'RegistracionPagos'
END

IF dbo.ExisteFK('FK_Bitacora_Funciones') = 1
    ALTER TABLE [dbo].[Bitacora] DROP CONSTRAINT [FK_Bitacora_Funciones]
IF dbo.ExisteFK('FK_CuentasCorrientes_IdFuncion') = 1
    ALTER TABLE [dbo].[CuentasCorrientes] DROP CONSTRAINT [FK_CuentasCorrientes_IdFuncion]
IF dbo.ExisteFK('FK_Ventas_IdFuncion') = 1
    ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_IdFuncion]
GO

IF dbo.ExisteFuncion('RegistracionPagos') = 1 AND dbo.ExisteFuncion('RegistracionPagosV2') = 1 AND dbo.SoyHAR() = 0
BEGIN
    DELETE FuncionesDocumentos  WHERE IdFuncion = 'RegistracionPagos'
    DELETE RolesFunciones       WHERE IdFuncion = 'RegistracionPagos'
    DELETE Funciones            WHERE Id        = 'RegistracionPagos'
END


PRINT ''
PRINT '4. Nuevo Buscador: Transportistas'
DECLARE @idBuscador int = 45
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Transportistas' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador IdBuscador, 'IdTransportista'         IdBuscadorNombreCampo,  1 Orden, 'Código'       Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreTransportista'     IdBuscadorNombreCampo,  2 Orden, 'Nombre'       Titulo, @alineacion_izq Alineacion, 200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'DireccionTransportista'  IdBuscadorNombreCampo,  3 Orden, 'Dirección'    Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreLocalidad'         IdBuscadorNombreCampo,  4 Orden, 'Localidad'    Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'CuitTransportista'       IdBuscadorNombreCampo,  5 Orden, 'CUIT'         Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'TelefonoTransportista'   IdBuscadorNombreCampo,  6 Orden, 'Teléfono'     Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Observacion'             IdBuscadorNombreCampo,  7 Orden, 'Observacion'  Titulo, @alineacion_izq Alineacion, 200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreCategoriaFiscal'   IdBuscadorNombreCampo,  3 Orden, 'Categ.Fiscal' Titulo, @alineacion_izq Alineacion, 120 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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

