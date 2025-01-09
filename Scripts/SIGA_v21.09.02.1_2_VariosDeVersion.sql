PRINT ''
PRINT 'A0. Creacion de Tabla CRMNovedadesProductos'
    IF OBJECT_ID('CRMNovedadesProductos', 'U') IS NULL
	    BEGIN    
            CREATE TABLE dbo.CRMNovedadesProductos
	            (
	            IdTipoNovedad varchar(10) NOT NULL,
	            IdNovedad bigint NOT NULL,
	            LetraNovedad varchar(1) NOT NULL,
	            CentroEmisor smallint NOT NULL,
	            IdProducto varchar(15) NOT NULL,
	            OrdenProducto int NOT NULL,
                NombreProducto Varchar(60) NOT NULL,
	            CantidadProducto decimal(16, 4) NOT NULL,
	            PrecioProducto decimal(16, 4) NOT NULL,
	            IdListaPrecios int NOT NULL,
	            StockConsumidoProducto bit NOT NULL
	            )  ON [PRIMARY]

            ALTER TABLE dbo.CRMNovedadesProductos ADD CONSTRAINT
	            PK_CRMNovedadesProductos PRIMARY KEY CLUSTERED 
	            (
	            IdTipoNovedad,
	            IdNovedad,
	            LetraNovedad,
	            CentroEmisor,
	            IdProducto,
	            OrdenProducto
	            ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

            ALTER TABLE dbo.CRMNovedadesProductos SET (LOCK_ESCALATION = TABLE)
        END

        ----------------------------------------------------
-- INSERTA PARAMETROS DEFAULT MERCADO LIBRE.- --
PRINT ''
PRINT 'B0. Inserta parametro Servicio Tecnico - tabla de Parametros'
BEGIN
    PRINT ''
    PRINT 'B1. Incorpora Parametro de Lista de Precios Servicios.-'
    IF not exists ( SELECT *
                    FROM Parametros 
                    WHERE IdParametro = 'CRMNOVEDADESLISTAPRECIOFACTURAR')
        BEGIN
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'CRMNOVEDADESLISTAPRECIOFACTURAR' AS IdParametro, 
                        (SELECT TOP(1) ValorParametro FROM PARAMETROS WHERE IdParametro = 'LISTAPRECIOSPREDETERMINADA') ValorParametro, 
                        'Servicio Tecnico' CategoriaParametro, 
                        'CRMNOVEDADESLISTAPRECIOFACTURAR' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END

    PRINT ''
    PRINT 'B2. Incorpora Parametro de Tipo de Movimiento de Consumo Servicios.-'
    IF not exists ( SELECT *
                    FROM Parametros 
                    WHERE IdParametro = 'CRMNOVEDADESTIPOMOVIMIENTOCONSUMO')
        BEGIN
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'CRMNOVEDADESTIPOMOVIMIENTOCONSUMO' AS IdParametro, 
                        '' ValorParametro, 
                        'Servicio Tecnico' CategoriaParametro, 
                        'CRMNOVEDADESTIPOMOVIMIENTOCONSUMO' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END

    PRINT ''
    PRINT 'B3. Incorpora Parametro de Tipo de Movimiento de Reversado Servicios.-'
    IF not exists ( SELECT *
                    FROM Parametros 
                    WHERE IdParametro = 'CRMNOVEDADESTIPOMOVIMIENTOREVERSO')
        BEGIN
            MERGE INTO Parametros AS DEST
            USING (
                    SELECT IdEmpresa, 
                        'CRMNOVEDADESTIPOMOVIMIENTOREVERSO' AS IdParametro, 
                        '' ValorParametro, 
                        'Servicio Tecnico' CategoriaParametro, 
                        'CRMNOVEDADESTIPOMOVIMIENTOREVERSO' DescripcionParametro FROM Empresas) AS ORIG 
                    ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
            WHEN NOT MATCHED THEN 
                INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
                VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
        END

END

PRINT ''
PRINT 'C0. Incorpora Campo ControlaStockConsumido de Servicios en CRMEstadosNovedades.-'
    IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
       WHERE TABLE_NAME = 'CRMEstadosNovedades' AND COLUMN_NAME = 'ControlaStockConsumido'
    )
    BEGIN
        ALTER TABLE dbo.CRMEstadosNovedades ADD
	        ControlaStockConsumido bit NULL

    END
GO
    UPDATE CRMEstadosNovedades SET ControlaStockConsumido = 'False' 

    ALTER TABLE dbo.CRMEstadosNovedades ALTER COLUMN
	    ControlaStockConsumido bit NOT NULL
    ALTER TABLE dbo.CRMEstadosNovedades SET (LOCK_ESCALATION = TABLE)

PRINT ''
PRINT 'D0. Incorpora Campo Visualiza Sucursal en CRM Tipo Novedades.-'
IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'CRMTiposNovedades' AND COLUMN_NAME = 'VisualizaSucursal'
)
BEGIN
    ALTER TABLE dbo.CRMTiposNovedades ADD
	    VisualizaSucursal Varchar(50) NULL

END
GO
UPDATE CRMTiposNovedades SET VisualizaSucursal = 'NoVisible'

ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN
	VisualizaSucursal Varchar(50) NOT NULL
ALTER TABLE dbo.CRMTiposNovedades SET (LOCK_ESCALATION = TABLE)



PRINT ''
PRINT 'E0. Incorpora Campo IdSucursalNovedad en CRM Novedades.-'
IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'CRMNovedades' AND COLUMN_NAME = 'IdSucursalNovedad'
)

ALTER TABLE dbo.CRMNovedades ADD
	IdSucursalNovedad int NULL
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	FK_CRMNovedades_CRMNovedades_SucursalNovedad FOREIGN KEY
	(
	IdSucursalNovedad
	) REFERENCES dbo.Sucursales
	(
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO

PRINT ''
PRINT 'F0. Incorpora Campo IdSucursalNovedad en Auditoria CRM Novedades.-'
IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'AuditoriaCRMNovedades' AND COLUMN_NAME = 'IdSucursalNovedad'
)

ALTER TABLE dbo.AuditoriaCRMNovedades ADD
	IdSucursalNovedad int NULL
GO
ALTER TABLE dbo.AuditoriaCRMNovedades SET (LOCK_ESCALATION = TABLE)
GO
