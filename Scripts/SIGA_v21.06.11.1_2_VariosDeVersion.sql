PRINT ''
PRINT '1. Tabla Parametros: Nuevos Parametros Productos de Publicar En... PRODUCTOPUBLICARWEBCARRITO'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPUBLICARWEBCARRITO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto publica en Web/Carrito'
DECLARE @valorParametro VARCHAR(MAX) = 'True'

--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

-----------------
PRINT ''
PRINT '2. Tabla Parametros: Nuevos Parametros Productos de Publicar En... PRODUCTOPUBLICARBALANZA'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPUBLICARBALANZA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto publica en Balanza'
DECLARE @valorParametro VARCHAR(MAX) = 'False'

--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

-----------------
PRINT ''
PRINT '3. Tabla Parametros: Nuevos Parametros Productos de Publicar En... PRODUCTOPUBLICARLISTAPRECIOCLIENTES'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPUBLICARLISTAPRECIOCLIENTES'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto publica en Lista de Precio para Clientes'
DECLARE @valorParametro VARCHAR(MAX) = 'True'

--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

-----------------
PRINT ''
PRINT '4. Tabla Parametros: Nuevos Parametros Productos de Publicar En... PRODUCTOPUBLICARAPPGESTION'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPUBLICARAPPGESTION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto se publica en App Gestión'
DECLARE @valorParametro VARCHAR(MAX) = 'False'

--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

-----------------
PRINT ''
PRINT '5. Tabla Parametros: Nuevos Parametros Productos de Publicar En... PRODUCTOPUBLICARSINCRONIZACIONSUCURSAL'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPUBLICARSINCRONIZACIONSUCURSAL'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto se publica en Sincronización a Sucursal'
DECLARE @valorParametro VARCHAR(MAX) = 'False'

--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

-----------------
PRINT ''
PRINT '6. Tabla Parametros: Nuevos Parametros Productos de Publicar En... PRODUCTOPUBLICARAPPEMPRESARIAL'

DECLARE @idParametro VARCHAR(MAX) = 'PRODUCTOPUBLICARAPPEMPRESARIAL'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Producto publica en App Empresarial'
DECLARE @valorParametro VARCHAR(MAX) = 'False'

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
PRINT '7. CAMBIOS DE NOMBRE AL REPORTE eComprobante_PLAF del Cliente 270 DISTRIBUIDORA PLAF'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_PLAF.rdlc', '270_eComprobante.rdlc', 'N'

