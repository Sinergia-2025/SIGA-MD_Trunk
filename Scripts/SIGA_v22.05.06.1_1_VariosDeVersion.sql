PRINT ''
PRINT '1.- Nueva Campo Atributo: IdaAtributoProducto para indexsacion de Atributos.'
BEGIN
    ALTER TABLE AtributosProductos ADD IdaAtributoProducto int NOT NULL IDENTITY (1, 1)

    CREATE UNIQUE NONCLUSTERED INDEX AK_AtributosProductos ON dbo.AtributosProductos
        (IdaAtributoProducto)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

PRINT ''
PRINT '2.- Nueva Campo Atributo - MovimientosVentasProductos: IdaAtributos para indexsacion de Atributos.'
BEGIN
    ALTER TABLE MovimientosVentasProductos ADD IdaAtributoProducto01 Int NULL
    ALTER TABLE MovimientosVentasProductos ADD IdaAtributoProducto02 Int NULL
    ALTER TABLE MovimientosVentasProductos ADD IdaAtributoProducto03 Int NULL
    ALTER TABLE MovimientosVentasProductos ADD IdaAtributoProducto04 Int NULL
END
GO

PRINT ''
PRINT '3.- Nueva Campo Atributo - MovimientosComprasProductos: IdaAtributos para indexsacion de Atributos.'
BEGIN
    ALTER TABLE MovimientosComprasProductos ADD IdaAtributoProducto01 Int NULL
    ALTER TABLE MovimientosComprasProductos ADD IdaAtributoProducto02 Int NULL
    ALTER TABLE MovimientosComprasProductos ADD IdaAtributoProducto03 Int NULL
    ALTER TABLE MovimientosComprasProductos ADD IdaAtributoProducto04 Int NULL
END
GO


PRINT ''
PRINT '4.- Nueva Campo Atributo - VentasProductos: IdaAtributos para indexsacion de Atributos.'
BEGIN
    ALTER TABLE VentasProductos ADD IdaAtributoProducto01 Int NULL
    ALTER TABLE VentasProductos ADD IdaAtributoProducto02 Int NULL
    ALTER TABLE VentasProductos ADD IdaAtributoProducto03 Int NULL
    ALTER TABLE VentasProductos ADD IdaAtributoProducto04 Int NULL
END
GO

PRINT ''
PRINT '5.- Nueva Campo Atributo - ComprasProductos: IdaAtributos para indexsacion de Atributos.'
BEGIN
    ALTER TABLE ComprasProductos ADD IdaAtributoProducto01 Int NULL
    ALTER TABLE ComprasProductos ADD IdaAtributoProducto02 Int NULL
    ALTER TABLE ComprasProductos ADD IdaAtributoProducto03 Int NULL
    ALTER TABLE ComprasProductos ADD IdaAtributoProducto04 Int NULL
END
GO


PRINT ''
PRINT '6.- Nueva Campo: Nuevo Atributo: IdaAtributoProducto para indexsacion de Atributos.'
BEGIN
    CREATE TABLE ProductosSucursalesAtributos(
        [IdProducto] [VarChar](15) NOT NULL,
        [IdSucursal] [Int] NOT NULL,
        [IdProdSucAtributo] [Int] NOT NULL,
        [IdaAtributo01] [Int] NULL,
        [IdaAtributo02] [Int] NULL,
        [IdaAtributo03] [Int] NULL,
        [IdaAtributo04] [Int] NULL,
        [Stock] [Decimal](16,4) NULL
     CONSTRAINT [PK_ProductoSucursalAtributo] PRIMARY KEY CLUSTERED 
    ([IdProducto],[IdSucursal],[IdProdSucAtributo]   
        ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

    ALTER TABLE [dbo].[ProductosSucursalesAtributos]  WITH CHECK ADD  CONSTRAINT [FK_AtributosProductosSucursales] 
    FOREIGN KEY([IdProducto], [IdSucursal]) REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal])

    ALTER TABLE [dbo].[ProductosSucursalesAtributos]  WITH CHECK ADD  CONSTRAINT [FK_AtributosProductos_01] 
    FOREIGN KEY([IdaAtributo01]) REFERENCES [dbo].[AtributosProductos] ([IdaAtributoProducto])

    ALTER TABLE [dbo].[ProductosSucursalesAtributos]  WITH CHECK ADD  CONSTRAINT [FK_AtributosProductos_02] 
    FOREIGN KEY([IdaAtributo02]) REFERENCES [dbo].[AtributosProductos] ([IdaAtributoProducto])

    ALTER TABLE [dbo].[ProductosSucursalesAtributos]  WITH CHECK ADD  CONSTRAINT [FK_AtributosProductos_03] 
    FOREIGN KEY([IdaAtributo03]) REFERENCES [dbo].[AtributosProductos] ([IdaAtributoProducto])

    ALTER TABLE [dbo].[ProductosSucursalesAtributos]  WITH CHECK ADD  CONSTRAINT [FK_AtributosProductos_04] 
    FOREIGN KEY([IdaAtributo04]) REFERENCES [dbo].[AtributosProductos] ([IdaAtributoProducto])
END
GO


PRINT ''
PRINT '7.- Tabla ContabilidadCuentasRubros: Nuevo campo CentroEmisor'
ALTER TABLE dbo.ContabilidadCuentasRubros ADD CentroEmisor int NULL
GO
UPDATE ContabilidadCuentasRubros SET CentroEmisor = 0;
ALTER TABLE dbo.ContabilidadCuentasRubros ALTER COLUMN CentroEmisor int NOT NULL
GO


PRINT ''
PRINT '8.- Tabla ContabilidadCuentasRubros: Recrear PK'
ALTER TABLE dbo.ContabilidadCuentasRubros
    DROP CONSTRAINT PK_ContabilidadCuentasRubros
GO
ALTER TABLE dbo.ContabilidadCuentasRubros ADD CONSTRAINT PK_ContabilidadCuentasRubros
    PRIMARY KEY CLUSTERED 
    (IdRubro, IdCuenta, IdPlanCuenta, Tipo, CentroEmisor)
    WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

