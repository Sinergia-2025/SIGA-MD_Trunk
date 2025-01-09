PRINT ''
PRINT '1. Parametro: Mantiene valoración del Dólar del comprobante Invocado'
DECLARE @idParametro VARCHAR(MAX) = 'COTIZACIONDOLARCOMPROBANTEINVOCADO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Mantiene valoración del Dólar del comprobante Invocado'
DECLARE @valorParametro VARCHAR(MAX) = 'NO'
-- IF dbo.BaseConCuit('30711162891') = 1 OR dbo.BaseConCuit('30711915695') = 1
    -- SET @valorParametro = 'PREGUNTAR'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

GO

PRINT ''
PRINT '2. Parametro: Mantiene valoración del Dólar del pedido Invocado'
DECLARE @idParametro VARCHAR(MAX) = 'COTIZACIONDOLARPEDIDOINVOCADO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Mantiene valoración del Dólar del pedido Invocado'
DECLARE @valorParametro VARCHAR(MAX) = 'NO'
-- IF dbo.BaseConCuit('30711162891') = 1
    -- SET @valorParametro = 'PREGUNTAR'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


PRINT ''
PRINT '3. Nuevo Buscador: Talle-Color - ABM de Atributos de Productos(AtributosProductos).'
BEGIN
    --- Buscador - Tipos de Atributos de Productos.- ---
    DECLARE @id int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
    INSERT INTO [dbo].[Buscadores]
                ([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
            VALUES
                (@id,'AtributosProductos',400,'Grilla','')
    INSERT INTO [dbo].[BuscadoresCampos]
                ([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
            VALUES
                (@id, 'IdAtributoProducto', 1, 'Codigo Atributo', 16,  80, '', NULL, NULL, NULL),
                (@id, 'Descripcion', 2, 'Descripcion Atributo', 16, 250, '', NULL, NULL, NULL),
                (@id, 'IdGrupoTipoAtributoProducto', 3, 'Codigo Grupo', 16,  80, '', NULL, NULL, NULL),
                (@id, 'DescripcionGrupo', 4, 'Descripcion Grupo', 16, 250, '', NULL, NULL, NULL),
                (@id, 'IdTipoAtributoProducto', 5, 'Codigo Tipo', 16,  80, '', NULL, NULL, NULL),
                (@id, 'DescripcionTipo', 6, 'Descripcion Tipo', 16, 250, '', NULL, NULL, NULL)
END
GO

DELETE Bitacora WHERE IdFuncion = 'LoginNuevaVersion'
DELETE RolesFunciones WHERE IdFuncion = 'LoginNuevaVersion'
DELETE Funciones WHERE Id = 'LoginNuevaVersion'

PRINT ''
PRINT '4. Nuevo Menu: Impedir Login con nueva versión'
IF dbo.SoyHAR() = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('Login_ProhibicionDeActualizar', 'Impedir Login con nueva versión', 'Impedir Login con nueva versión', 'True', 'False', 'True', 'True'
        ,NULL, 999, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
END


PRINT ''
PRINT '5. QUitar opción de menú: AnularRecibos'
UPDATE Funciones
   SET Enabled = 0
     , Visible = 0
   WHERE Pantalla = 'AnularRecibos'
