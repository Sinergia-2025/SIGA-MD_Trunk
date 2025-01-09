
PRINT '1. Tabla ListasDePrecios: Agrego campo NombreCortoListaPrecios.'
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
ALTER TABLE dbo.ListasDePrecios ADD NombreCortoListaPrecios varchar(10) NULL
GO
UPDATE ListasDePrecios SET NombreCortoListaPrecios = '';
ALTER TABLE dbo.ListasDePrecios ALTER COLUMN NombreCortoListaPrecios varchar(10) NOT NULL
GO
ALTER TABLE dbo.ListasDePrecios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Nuevo Parametro: ACTUALIZAPRECIOSUTILIZAAJUSTEA.'
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('ACTUALIZAPRECIOSUTILIZAAJUSTEA', 'False', null, 'Actualiza Precios: Utiliza Ajuste a decimales.')
GO


PRINT ''
PRINT '3. Nuevo Parametro: ACTUALIZAPRECIOSUTILIZAAJUSTEA.'
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
ALTER TABLE dbo.VentasProductos ADD NombreCortoListaPrecios varchar(10) NULL
GO
UPDATE VentasProductos SET NombreCortoListaPrecios = '';
ALTER TABLE dbo.VentasProductos ALTER COLUMN NombreCortoListaPrecios varchar(10) NOT NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.PedidosProductos ADD NombreCortoListaPrecios varchar(10) NULL
GO
UPDATE PedidosProductos SET NombreCortoListaPrecios = '';
ALTER TABLE dbo.PedidosProductos ALTER COLUMN NombreCortoListaPrecios varchar(10) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Nueva Funciones CuentasCorrientes\ClientesDebitosAutomaticos.'
GO

-- Si es el CUIT de Generico/RDS/RDS ACE.

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024', '30714107220', '30714757128'))

BEGIN
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
	 VALUES
	   ('ClientesDebitosAutomaticos', 'Generar Débitos Automáticos', 'Generar Débitos Automáticos', 
		'True', 'False', 'True', 'True', 'CuentasCorrientes', 22, 'Eniac.Win', 'ClientesDebitosAutomaticos', null)
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ClientesDebitosAutomaticos' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;


PRINT ''
PRINT '5. Elimino (DROP) de Triggers relacionados con Precios.'
GO

PRINT ''
PRINT '5.1. Drop del Trigger Clientes_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Clientes_Insert_Update'))
    DROP TRIGGER dbo.Clientes_Insert_Update
GO
PRINT ''
PRINT '5.2. Drop del Trigger ProductosSucursales_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.ProductosSucursales_Insert_Update'))
    DROP TRIGGER dbo.ProductosSucursales_Insert_Update
GO
PRINT ''
PRINT '5.3. Drop del Trigger ProductosSucursalesPrecios_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.ProductosSucursalesPrecios_Insert_Update'))
    DROP TRIGGER dbo.ProductosSucursalesPrecios_Insert_Update
GO
PRINT ''
PRINT '5.4. Drop del Trigger Productos_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Productos_Insert_Update'))
    DROP TRIGGER dbo.Productos_Insert_Update
GO
PRINT ''
PRINT '5.5. Drop del Trigger Localidades_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Localidades_Insert_Update'))
    DROP TRIGGER dbo.Localidades_Insert_Update
GO
PRINT ''
PRINT '5.6. Drop del Trigger Rubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Rubros_Insert_Update'))
    DROP TRIGGER dbo.Rubros_Insert_Update
GO
PRINT ''
PRINT '5.7. Drop del Trigger SubRubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.SubRubros_Insert_Update'))
    DROP TRIGGER dbo.SubRubros_Insert_Update
GO
PRINT ''
PRINT '5.8. Drop del Trigger SubSubRubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.SubSubRubros_Insert_Update'))
    DROP TRIGGER dbo.SubSubRubros_Insert_Update
GO
PRINT ''
PRINT '5.9. Drop del Trigger SubSubRubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.ProductosWeb_Insert_Update'))
    DROP TRIGGER dbo.ProductosWeb_Insert_Update
GO
