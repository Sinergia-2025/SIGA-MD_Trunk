/****** CREAR TABLA CategoriasMercadoLibre ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

PRINT ''
PRINT '1. Nueva Tabla: CategoriasMercadoLibre'
--- Crear tabla.- --
CREATE TABLE [dbo].[CategoriasMercadoLibre](
	[IdCategoria] [varchar](10) NOT NULL,
	[NombreCategoria] [varchar](30) NOT NULL,
	[ActivoCategoria] [bit] NOT NULL,
 CONSTRAINT [PK_CategoriasMercadoLibre] PRIMARY KEY CLUSTERED 
([IdCategoria] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
--- Crear Indice.- --
CREATE NONCLUSTERED INDEX [IDX_ActivoCategoria] ON [dbo].[CategoriasMercadoLibre]
([ActivoCategoria] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '1.1. Tabla CategoriasMercadoLibre: Iniciualizo valores'
--- Insertar Datos.- --
INSERT INTO CategoriasMercadoLibre (IdCategoria, NombreCategoria, ActivoCategoria)
                            VALUES ('MLA3530', 'Categoria Generica ML','True')


PRINT ''
PRINT '2. Tabla Empleados: Nuevos Campos: DebitoTarjeta, IdTarjeta'
ALTER TABLE Empleados ADD [DebitoTarjeta] bit NULL, [IdTarjeta] int NULL
GO

PRINT ''
PRINT '2.1 Tabla Empleados: Actualizar registros pre-existentes para los campos'
UPDATE Empleados SET [DebitoTarjeta]  = 'False', [IdTarjeta]  = NULL
GO

PRINT ''
PRINT '2.2. Se agrega Foreign Key a IdTarjeta'
ALTER TABLE [dbo].Empleados  WITH CHECK ADD  CONSTRAINT [FK_Empleados_IdTarjeta] FOREIGN KEY([IdTarjeta]) REFERENCES [dbo].[Tarjetas] ([IdTarjeta])
GO

PRINT ''
PRINT '2.3. Tabla Empleados: NOT NULL para campo DebitoTarjeta'
ALTER TABLE Empleados ALTER COLUMN [DebitoTarjeta] bit NOT NULL
GO

----------------------------------------------------
-- CREA CAMPO DE IDCAJA PARA FACTURACION EN PEDIDOS.- --
PRINT ''
PRINT '3. Tabla Pedidos: Crea Campo IdCaja'
--  Crea campo IDCAJA en Pedidos Tiendas Web.- --
IF NOT EXISTS ( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdCaja' AND TABLE_NAME = 'Pedidos')
    BEGIN
        BEGIN TRANSACTION
            ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
        COMMIT
        BEGIN TRANSACTION
                ALTER TABLE dbo.Pedidos ADD IdCaja int NULL
                ALTER TABLE dbo.Pedidos ADD CONSTRAINT
	                FK_Pedidos_Caja FOREIGN KEY
	                (IdSucursal, IdCaja) REFERENCES dbo.CajasNombres
	                (IdSucursal, IdCaja) ON UPDATE  NO ACTION 
	                 ON DELETE  NO ACTION 
	            ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
        COMMIT
    END
GO
----------------------------------------------------

PRINT ''
PRINT '4. Tabla Productos: Nuevo campo IdCategoriaMercadoLibre'
ALTER TABLE dbo.Productos ADD IdCategoriaMercadoLibre varchar(10) NULL
GO
CREATE NONCLUSTERED INDEX IX_Productos_CategoriaMercadoLibre ON dbo.Productos (IdCategoriaMercadoLibre)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
PRINT ''
PRINT '5. Tabla AuditoriaProductos: Nuevo campo IdCategoriaMercadoLibre'
ALTER TABLE dbo.AuditoriaProductos ADD IdCategoriaMercadoLibre varchar(10) NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

PRINT ''
PRINT '4. Tabla PedidosTiendasWeb: Nuevo campo PacksIdTiendaWeb'
ALTER TABLE dbo.PedidosTiendasWeb ADD PacksIdTiendaWeb varchar(50) NULL
GO

CREATE NONCLUSTERED INDEX IX_PacksIdTiendaWeb ON dbo.PedidosTiendasWeb (PacksIdTiendaWeb)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.PedidosTiendasWeb SET (LOCK_ESCALATION = TABLE)
GO

