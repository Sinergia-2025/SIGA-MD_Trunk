
PRINT ''
PRINT '1. Función: Agregando función FacturacionRapida-EditarItem'
IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'FacturacionRapida')
	INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
			 IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
			 PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	  VALUES
			('FacturacionRapida-EditarItem', 'Facturacion Rapida - Permite editar Item', 'Facturacion Rapida - Permite editar Item', 'False', 'False', 'True', 'True', 
			'FacturacionRapida', 999, '', '', NULL, NULL,
			'True', 'S', 'N', 'N', 'N')
	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FacturacionRapida-EditarItem' AS Pantalla FROM Roles
			WHERE Id IN ('Adm', 'Supervisor')
GO


PRINT ''
PRINT '2. Crear tabla TiposComprobantesProductos'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposComprobantesProductos]
(	[IdTipoComprobante] [varchar](15) NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Cantidad] [decimal] (16,4)  NOT NULL,
 CONSTRAINT [PK_TiposComprobantesProductos] PRIMARY KEY CLUSTERED 
([IdTipoComprobante] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO


PRINT ''
PRINT '2.1. Agregar FK a la tabla TiposComprobantesProductos'
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
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposComprobantesProductos
	DROP CONSTRAINT PK_TiposComprobantesProductos
GO
ALTER TABLE dbo.TiposComprobantesProductos ADD CONSTRAINT PK_TiposComprobantesProductos
	PRIMARY KEY CLUSTERED (IdTipoComprobante,IdProducto)
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.TiposComprobantesProductos ADD CONSTRAINT FK_TiposComprobantesProductos_TiposComprobantes
	FOREIGN KEY (IdTipoComprobante) 
	REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposComprobantesProductos ADD CONSTRAINT FK_TiposComprobantesProductos_Productos
	FOREIGN KEY (IdProducto)
	REFERENCES dbo.Productos (IdProducto)
	ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposComprobantesProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '3. Agregar campo Automatico en VentasProductos'
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
ALTER TABLE dbo.VentasProductos ADD Automatico bit NULL
GO
UPDATE VentasProductos SET Automatico = 0
GO
ALTER TABLE VentasProductos ALTER COLUMN Automatico bit NOT NULL
GO
COMMIT


PRINT ''
PRINT '4. Agregar campo Automatico en PedidosProductos'
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
ALTER TABLE dbo.PedidosProductos ADD Automatico bit NULL
GO
UPDATE PedidosProductos SET Automatico = 0 
GO
ALTER TABLE PedidosProductos ALTER COLUMN Automatico bit NOT NULL
GO
COMMIT


PRINT ''
PRINT '5. Agregar campo Automatico en CRMTiposNovedades'
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
ALTER TABLE dbo.CRMTiposNovedades ADD ReportaCantidad bit NULL
ALTER TABLE dbo.CRMTiposNovedades ADD ReportaAvance bit NULL
GO
UPDATE CRMTiposNovedades SET ReportaCantidad = 0, ReportaAvance = 0
GO
ALTER TABLE CRMTiposNovedades ALTER COLUMN ReportaCantidad bit NOT NULL
ALTER TABLE CRMTiposNovedades ALTER COLUMN ReportaAvance bit NOT NULL
GO
COMMIT

