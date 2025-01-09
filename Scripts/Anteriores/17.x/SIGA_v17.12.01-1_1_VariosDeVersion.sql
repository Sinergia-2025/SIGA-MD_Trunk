
PRINT '1. Tabla OrdenesProduccionProductos : agrego campo IdFormula / Otros.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.ProductosFormulas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD IdFormula int NULL
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD CONSTRAINT FK_OrdenesProduccionProductos_ProductosFormulas
    FOREIGN KEY (IdProducto,IdFormula)
    REFERENCES dbo.ProductosFormulas (IdProducto,IdFormula)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.OrdenesProduccionProductos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.OrdenesProduccionEstados ADD IdFormula int NULL
GO
ALTER TABLE dbo.OrdenesProduccionEstados ADD CONSTRAINT FK_OrdenesProduccionEstados_ProductosFormulas
    FOREIGN KEY (IdProducto,IdFormula)
    REFERENCES dbo.ProductosFormulas (IdProducto,IdFormula)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.OrdenesProduccionEstados SET (LOCK_ESCALATION = TABLE)
GO

COMMIT


PRINT ''
PRINT '2. Tabla ProductosComponentes: agrego campo SegunCalculoForma.'


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.ProductosComponentes ADD SegunCalculoForma bit NULL
GO
UPDATE ProductosComponentes SET SegunCalculoForma = 0;
ALTER TABLE dbo.ProductosComponentes ALTER COLUMN SegunCalculoForma bit NOT NULL
GO
ALTER TABLE dbo.ProductosComponentes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla Productos: agrego campo CalculaPreciosSegunFormula.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Productos ADD CalculaPreciosSegunFormula bit NULL
GO
UPDATE Productos SET CalculaPreciosSegunFormula = 0;
ALTER TABLE dbo.Productos ALTER COLUMN CalculaPreciosSegunFormula bit NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProductos ADD CalculaPreciosSegunFormula bit NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla PedidosProductos: agrego campo IdFormula.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.ProductosFormulas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosProductos ADD IdFormula int NULL
GO
ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_ProductosFormulas
    FOREIGN KEY (IdProducto,IdFormula)
    REFERENCES dbo.ProductosFormulas (IdProducto,IdFormula)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT


PRINT ''
PRINT '5. Tabla OrdenesProduccionProductos: agrego campo IdProduccionProceso / Otros.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.ProduccionFormas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProduccionProcesos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD IdProduccionProceso int NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD IdProduccionForma int NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD Espmm decimal(10, 3) NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD EspPies varchar(30) NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD CodigoSAE int NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD LargoExtAlto decimal(10, 3) NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD AnchoIntBase decimal(10, 3) NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD UrlPlano varchar(300) NULL
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD CONSTRAINT FK_OrdenesProduccionProductos_ProduccionProcesos
    FOREIGN KEY (IdProduccionProceso)
    REFERENCES dbo.ProduccionProcesos (IdProduccionProceso)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD CONSTRAINT FK_OrdenesProduccionProductos_ProduccionFormas
    FOREIGN KEY (IdProduccionForma)
    REFERENCES dbo.ProduccionFormas (IdProduccionForma)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '6. Tabla ProduccionProductos: agrego campo IdProduccionProceso / Otros.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.ProduccionFormas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProduccionProcesos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProduccionProductos ADD IdProduccionProceso int NULL
ALTER TABLE dbo.ProduccionProductos ADD IdProduccionForma int NULL
ALTER TABLE dbo.ProduccionProductos ADD Espmm decimal(10, 3) NULL
ALTER TABLE dbo.ProduccionProductos ADD EspPies varchar(30) NULL
ALTER TABLE dbo.ProduccionProductos ADD CodigoSAE int NULL
ALTER TABLE dbo.ProduccionProductos ADD LargoExtAlto decimal(10, 3) NULL
ALTER TABLE dbo.ProduccionProductos ADD AnchoIntBase decimal(10, 3) NULL
ALTER TABLE dbo.ProduccionProductos ADD UrlPlano varchar(300) NULL
GO
ALTER TABLE dbo.ProduccionProductos ADD CONSTRAINT FK_ProduccionProductos_ProduccionProcesos
    FOREIGN KEY (IdProduccionProceso)
    REFERENCES dbo.ProduccionProcesos (IdProduccionProceso)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.ProduccionProductos ADD CONSTRAINT FK_ProduccionProductos_ProduccionFormas
    FOREIGN KEY (IdProduccionForma)
    REFERENCES dbo.ProduccionFormas (IdProduccionForma)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '7. Tabla OrdenesProduccionProductos: agrego campo TipoDocResponsable.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD TipoDocResponsable varchar(5) NULL
ALTER TABLE dbo.OrdenesProduccionProductos ADD NroDocResponsable varchar(12) NULL
GO
UPDATE OrdenesProduccionProductos
   SET TipoDocResponsable = 'COD'
      ,NroDocResponsable = '1'
  FROM OrdenesProduccionEstados
;
ALTER TABLE dbo.OrdenesProduccionProductos ALTER COLUMN TipoDocResponsable varchar(5) NOT NULL
ALTER TABLE dbo.OrdenesProduccionProductos ALTER COLUMN NroDocResponsable varchar(12) NOT NULL
GO
ALTER TABLE dbo.OrdenesProduccionProductos ADD CONSTRAINT FK_OrdenesProduccionProductos_Empleados
    FOREIGN KEY (TipoDocResponsable,NroDocResponsable)
    REFERENCES dbo.Empleados (TipoDocEmpleado,NroDocEmpleado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.OrdenesProduccionProductos SET (LOCK_ESCALATION = TABLE)
GO


ALTER TABLE dbo.OrdenesProduccionEstados ADD TipoDocResponsable varchar(5) NULL
ALTER TABLE dbo.OrdenesProduccionEstados ADD NroDocResponsable varchar(12) NULL
GO
UPDATE OrdenesProduccionEstados
   SET TipoDocResponsable = 'COD'
      ,NroDocResponsable = '1'
  FROM OrdenesProduccionEstados
;
ALTER TABLE dbo.OrdenesProduccionEstados ALTER COLUMN TipoDocResponsable varchar(5) NOT NULL
ALTER TABLE dbo.OrdenesProduccionEstados ALTER COLUMN NroDocResponsable varchar(12) NOT NULL
GO
ALTER TABLE dbo.OrdenesProduccionEstados ADD CONSTRAINT FK_OrdenesProduccionEstados_Empleados
    FOREIGN KEY (TipoDocResponsable,NroDocResponsable)
    REFERENCES dbo.Empleados (TipoDocEmpleado,NroDocEmpleado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.OrdenesProduccionEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '8. Tabla PedidosEstados: agrego campo IdSucursalProduccion / Otros.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.OrdenesProduccion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD IdSucursalProduccion int NULL
ALTER TABLE dbo.PedidosEstados ADD IdTipoComprobanteProduccion varchar(15) NULL
ALTER TABLE dbo.PedidosEstados ADD LetraProduccion varchar(1) NULL
ALTER TABLE dbo.PedidosEstados ADD CentroEmisorProduccion int NULL
ALTER TABLE dbo.PedidosEstados ADD NumeroOrdenProduccion int NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_OrdenesProduccion
    FOREIGN KEY (IdSucursalProduccion,NumeroOrdenProduccion,IdTipoComprobanteProduccion,LetraProduccion,CentroEmisorProduccion)
    REFERENCES dbo.OrdenesProduccion (IdSucursal,NumeroOrdenProduccion,IdTipoComprobante,Letra,CentroEmisor)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '9. Tabla EstadosPedidos: agrego registro PRODUCCION.'

INSERT INTO dbo.EstadosPedidos
    (idEstado, IdTipoComprobante, IdTipoEstado, Orden, AfectaPendiente, TipoEstadoPedido, Color, ReservaStock)
VALUES
    ('PRODUCCION', 'ORDENPRODUCCION', 'ENTREGADO', 17, 0, 'PEDIDOSCLIE', -4144960, 0)
GO


PRINT ''
PRINT '10. Tabla EstadosOrdenesProduccion: agrego campos TipoEstadoPedido / IdEstadoPedido.'

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EstadosOrdenesProduccion ADD TipoEstadoPedido varchar(15) NULL
ALTER TABLE dbo.EstadosOrdenesProduccion ADD IdEstadoPedido varchar(10) NULL
GO
ALTER TABLE dbo.EstadosOrdenesProduccion ADD CONSTRAINT FK_EstadosOrdenesProduccion_EstadosPedidos
    FOREIGN KEY (IdEstadoPedido,TipoEstadoPedido)
    REFERENCES dbo.EstadosPedidos (idEstado,TipoEstadoPedido)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.EstadosOrdenesProduccion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '11. Tabla PedidosEstados: agrego campos IdProductoProduccion/OrdenProduccion.'


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.OrdenesProduccionProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstados ADD IdProductoProduccion varchar(15) NULL
ALTER TABLE dbo.PedidosEstados ADD OrdenProduccion int NULL
GO
ALTER TABLE dbo.PedidosEstados ADD CONSTRAINT FK_PedidosEstados_OrdenesProduccionProductos
	FOREIGN KEY (IdSucursalProduccion,NumeroOrdenProduccion,IdProductoProduccion,OrdenProduccion,
	             IdTipoComprobanteProduccion,LetraProduccion,CentroEmisorProduccion)
	REFERENCES dbo.OrdenesProduccionProductos (IdSucursal,NumeroOrdenProduccion,IdProducto,Orden,
	                                           IdTipoComprobante,Letra,CentroEmisor)
     ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

