
PRINT '1. Agrego Funcion ABM de SubSubRubros y seteo perfiles.'
GO

--Inserto la pantalla nueva

INSERT INTO Funciones
      (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
      ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
      ('SubSubRubrosABM', 'SubSubRubros', 'SubSubRubros', 'True', 'False', 'True', 'True',
      'Archivos', 160, 'Eniac.Win', 'SubSubRubrosABM', NULL)
GO

 INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SubSubRubrosABM' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


PRINT ''
PRINT '2. Creo Tabla SubSubRubros.'
GO

/****** Object:  Table [dbo].[SubSubRubros]    Script Date: 12/07/2017 13:28:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SubSubRubros](
	[IdSubSubRubro] [int] NOT NULL,
	[NombreSubSubRubro] [varchar](50) NOT NULL,
	[IdSubRubro] [int] NOT NULL,
 CONSTRAINT [PK_SubSubRubros] PRIMARY KEY CLUSTERED 
(
	[IdSubSubRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SubSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_SubSubRubros_SubRubros] FOREIGN KEY([IdSubRubro])
REFERENCES [dbo].[SubRubros] ([IdSubRubro])
GO

ALTER TABLE [dbo].[SubSubRubros] CHECK CONSTRAINT [FK_SubSubRubros_SubRubros]
GO


PRINT ''
PRINT '3. Tabla SubSubRubros: Genero Registros.'
GO

INSERT INTO SubSubRubros
           (IdSubSubRubro
           ,NombreSubSubRubro
           ,IdSubRubro)
SELECT A.xxIdSubSubRubro, A.xxNombreSubSubRubro, A.xxIdSubSubRubro FROM
(SELECT IdRubro
     , MIN(IdSubRubro) AS xxIdSubSubRubro
     , 'A Definir' AS xxNombreSubSubRubro
  FROM SubRubros
  GROUP BY IdRubro
) A
GO


PRINT ''
PRINT '4. Tabla Productos: agrego campo IdSubSubRubro y FK .'
GO

ALTER TABLE Productos ADD IdSubSubRubro	int null
GO

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
ALTER TABLE dbo.SubSubRubros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	FK_Productos_SubSubRubros FOREIGN KEY
	(
	IdSubSubRubro
	) REFERENCES dbo.SubSubRubros
	(
	IdSubSubRubro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla AuditoriaProductos: agrego campo IdSubSubRubro.'
GO

ALTER TABLE AuditoriaProductos ADD IdSubSubRubro int null
GO


PRINT ''
PRINT '5. Creo Tabla Productos: agrego campo ProductosWeb y FK hacia Productos.'
GO

/****** Object:  Table [dbo].[ProductosWeb]    Script Date: 12/07/2017 13:45:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductosWeb](
	[IdProducto] [varchar](15) NOT NULL,
	[Caracteristica1] [varchar](256) NULL,
	[ValorCaracteristica1] [varchar](512) NULL,
	[Caracteristica2] [varchar](256) NULL,
	[ValorCaracteristica2] [varchar](512) NULL,
	[Caracteristica3] [varchar](256) NULL,
	[ValorCaracteristica3] [varchar](512) NULL,
	[Foto2] [image] NULL,
	[Foto3] [image] NULL,
 CONSTRAINT [PK_ProductosWeb] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosWeb]  WITH CHECK ADD  CONSTRAINT [FK_ProductosWeb_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosWeb] CHECK CONSTRAINT [FK_ProductosWeb_Productos]
GO


PRINT ''
PRINT '6. Tabla ProductosWeb: Genero Registros.'
GO

INSERT INTO ProductosWeb
           (IdProducto
           ,Caracteristica1
           ,ValorCaracteristica1
           ,Caracteristica2
           ,ValorCaracteristica2
           ,Caracteristica3
           ,ValorCaracteristica3
           ,Foto2
           ,Foto3)
SELECT IdProducto
      ,NULL AS xxCaracteristica1
      ,NULL AS xxValorCaracteristica1
      ,NULL AS xxCaracteristica2
      ,NULL AS xxValorCaracteristica2
      ,NULL AS xxCaracteristica3
      ,NULL AS xxValorCaracteristica3
      ,NULL AS xxFoto2
      ,NULL AS xxFoto3
 FROM Productos
 WHERE PublicarEnWeb = 'True'
GO


PRINT ''
PRINT '7. Creo Parametro: PRODUCTOTIENESUBSUBRUBRO.'
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('PRODUCTOTIENESUBSUBRUBRO', 'False', null, 'El Producto tiene SubSubRubro')
GO


PRINT ''
PRINT '8. Creo Parametro: NombreBaseProductoWeb.'
GO

INSERT INTO Parametros
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
SELECT 'NombreBaseProductoWeb', '', NULL, 'Nombre de la Base de Productos Web'
GO


PRINT ''
PRINT '9. Creo Parametro: PRODUCTOUTILIZAPRODUCTOWEB.'
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('PRODUCTOUTILIZAPRODUCTOWEB', 'False', null, 'Producto Utiliza Producto Web')
GO

PRINT ''
PRINT '9. Tablas Productos, AuditoriaProductos y VentasProductos: ajusto campo PorcImpuestoInterno a 4 decimales.'
GO


/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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

ALTER TABLE Productos ALTER COLUMN PorcImpuestoInterno decimal(9,4) NOT NULL
 GO

 
ALTER TABLE AuditoriaProductos ALTER COLUMN PorcImpuestoInterno decimal(9,4)  NULL
 GO

ALTER TABLE VentasProductos ALTER COLUMN PorcImpuestoInterno decimal(9,4) NOT NULL
 GO

 ALTER TABLE PedidosProductos ALTER COLUMN PorcImpuestoInterno decimal(9,4) NOT NULL
 GO

ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
