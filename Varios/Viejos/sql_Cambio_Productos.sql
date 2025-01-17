UPDATE Productos SET Tamano = NULL, IdUnidadDeMedida = NULL ;



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos
	DROP CONSTRAINT FK_Productos_TiposDeProductos
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos
	DROP CONSTRAINT FK_Productos_Marcas
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Productos
	(
	IdProducto varchar(15) NOT NULL,
	NombreProducto varchar(60) NULL,
	Tamano decimal(6, 2) NULL,
	IdUnidadDeMedida char(2) NULL,
	IdMarca int NULL,
	IdRubro int NULL,
	MesesGarantia int NULL,
	EsNogravado bit NULL
	)  ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.Productos)
	 EXEC('INSERT INTO dbo.Tmp_Productos (IdProducto, NombreProducto, Tamano, IdUnidadDeMedida, IdMarca, IdRubro, MesesGarantia, EsNogravado)
		SELECT IdProducto, NombreProducto, CONVERT(decimal(6, 2), Tamano), CONVERT(char(2), IdUnidadDeMedida), IdMarca, IdRubro, MesesGarantia, EsNogravado FROM dbo.Productos WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.ProductosSucursales
	DROP CONSTRAINT FK_ProductosSucursales_Productos
GO
ALTER TABLE dbo.HistorialPrecios
	DROP CONSTRAINT FK_HistorialPrecios_Productos
GO
ALTER TABLE dbo.MovimientosVentasProductos
	DROP CONSTRAINT FK_MovimientosVentasProductos_Productos
GO
ALTER TABLE dbo.ComprasProductos
	DROP CONSTRAINT FK_ComprasProductos_Productos
GO
ALTER TABLE dbo.MovimientosComprasProductos
	DROP CONSTRAINT FK_MovimientosComprasProductos_Productos
GO
ALTER TABLE dbo.VentasProductos
	DROP CONSTRAINT FK_Ventas_Productos
GO
DROP TABLE dbo.Productos
GO
EXECUTE sp_rename N'dbo.Tmp_Productos', N'Productos', 'OBJECT' 
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	PK_Productos PRIMARY KEY CLUSTERED 
	(
	IdProducto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_Marcas FOREIGN KEY
	(
	IdMarca
	) REFERENCES dbo.Marcas
	(
	IdMarca
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_TiposDeProductos FOREIGN KEY
	(
	IdRubro
	) REFERENCES dbo.Rubros
	(
	IdRubro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT
	FK_Ventas_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimientosComprasProductos ADD CONSTRAINT
	FK_MovimientosComprasProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT
	FK_ComprasProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimientosVentasProductos ADD CONSTRAINT
	FK_MovimientosVentasProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.HistorialPrecios ADD CONSTRAINT
	FK_HistorialPrecios_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProductosSucursales ADD CONSTRAINT
	FK_ProductosSucursales_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_UnidadesDeMedidas FOREIGN KEY
	(
	IdUnidadDeMedida
	) REFERENCES dbo.UnidadesDeMedidas
	(
	IdUnidadDeMedida
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
