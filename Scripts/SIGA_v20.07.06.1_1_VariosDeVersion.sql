-- ESTE SCRIPT SE ANULA. LUEGO SE VA A GENERAR UNO NUEVO.

PRINT '1. Drop del Trigger Clientes_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Clientes_Insert_Update'))
    DROP TRIGGER dbo.Clientes_Insert_Update
GO
PRINT '1.1. Create del Trigger Clientes_Insert_Update'
GO
CREATE TRIGGER dbo.Clientes_Insert_Update ON dbo.Clientes
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Clientes
           SET Clientes.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE Clientes.IdCliente = inserted.IdCliente
    END
GO

PRINT '1.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE Clientes
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '2. Drop del Trigger ProductosSucursales_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.ProductosSucursales_Insert_Update'))
    DROP TRIGGER dbo.ProductosSucursales_Insert_Update
GO
PRINT '2.1. Drop del Trigger ProductosSucursales_Insert_Update'
GO
CREATE TRIGGER dbo.ProductosSucursales_Insert_Update ON dbo.ProductosSucursales
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE ProductosSucursales
           SET ProductosSucursales.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE ProductosSucursales.IdSucursal = inserted.IdSucursal
          AND ProductosSucursales.IdProducto = inserted.IdProducto
    END
GO

PRINT '2.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE ProductosSucursales
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '3. Drop del Trigger ProductosSucursalesPrecios_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.ProductosSucursalesPrecios_Insert_Update'))
    DROP TRIGGER dbo.ProductosSucursalesPrecios_Insert_Update
GO
PRINT '3.1. Drop del Trigger ProductosSucursalesPrecios_Insert_Update'
GO
CREATE TRIGGER dbo.ProductosSucursalesPrecios_Insert_Update ON dbo.ProductosSucursalesPrecios
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE ProductosSucursalesPrecios
           SET ProductosSucursalesPrecios.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE ProductosSucursalesPrecios.IdSucursal = inserted.IdSucursal
          AND ProductosSucursalesPrecios.IdProducto = inserted.IdProducto
          AND ProductosSucursalesPrecios.IdListaPrecios = inserted.IdListaPrecios
    END
GO

PRINT '3.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE ProductosSucursalesPrecios
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '4. Drop del Trigger Productos_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Productos_Insert_Update'))
    DROP TRIGGER dbo.Productos_Insert_Update
GO
PRINT '4.1. Drop del Trigger Productos_Insert_Update'
GO
CREATE TRIGGER dbo.Productos_Insert_Update ON dbo.Productos
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Productos
           SET Productos.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE Productos.IdProducto = inserted.IdProducto
    END
GO

PRINT '4.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE Productos
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '5. Drop del Trigger Localidades_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Localidades_Insert_Update'))
    DROP TRIGGER dbo.Localidades_Insert_Update
GO
PRINT '5.1. Drop del Trigger Localidades_Insert_Update'
GO
CREATE TRIGGER dbo.Localidades_Insert_Update ON dbo.Localidades
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Localidades
           SET Localidades.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE Localidades.IdLocalidad = inserted.IdLocalidad
    END
GO

PRINT '5.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE Localidades
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '6. Drop del Trigger Rubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.Rubros_Insert_Update'))
    DROP TRIGGER dbo.Rubros_Insert_Update
GO
PRINT '6.1. Drop del Trigger Rubros_Insert_Update'
GO
CREATE TRIGGER dbo.Rubros_Insert_Update ON dbo.Rubros
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Rubros
           SET Rubros.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE Rubros.IdRubro = inserted.IdRubro
    END
GO

PRINT '6.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE Rubros
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '7. Drop del Trigger SubRubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.SubRubros_Insert_Update'))
    DROP TRIGGER dbo.SubRubros_Insert_Update
GO
PRINT '7.1. Drop del Trigger SubRubros_Insert_Update'
GO
CREATE TRIGGER dbo.SubRubros_Insert_Update ON dbo.SubRubros
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE SubRubros
           SET SubRubros.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE SubRubros.IdSubRubro = inserted.IdSubRubro
    END
GO

PRINT '7.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE SubRubros
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '8. Drop del Trigger SubSubRubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.SubSubRubros_Insert_Update'))
    DROP TRIGGER dbo.SubSubRubros_Insert_Update
GO
PRINT '8.1. Drop del Trigger SubSubRubros_Insert_Update'
GO
CREATE TRIGGER dbo.SubSubRubros_Insert_Update ON dbo.SubSubRubros
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE SubSubRubros
           SET SubSubRubros.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE SubSubRubros.IdSubSubRubro = inserted.IdSubSubRubro
    END
GO

PRINT '8.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE SubSubRubros
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL

PRINT ''
PRINT '9. Drop del Trigger SubSubRubros_Insert_Update'
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.ProductosWeb_Insert_Update'))
    DROP TRIGGER dbo.ProductosWeb_Insert_Update
GO
PRINT '9.1. Drop del Trigger ProductosWeb_Insert_Update'
GO
CREATE TRIGGER dbo.ProductosWeb_Insert_Update ON dbo.ProductosWeb
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE ProductosWeb
           SET ProductosWeb.FechaActualizacionWeb = GETDATE()
        FROM inserted
        WHERE ProductosWeb.IdProducto = inserted.IdProducto
    END
GO

PRINT '9.2. Actualizar FechaActualizacionWeb NULL'
GO
UPDATE ProductosWeb
   SET FechaActualizacionWeb = CONVERT(DATETIME, '20200101')
 WHERE FechaActualizacionWeb IS NULL



PRINT '10. Tabla CRMNovedades: Nuevo Campo FechaActualizacionWeb'
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
ALTER TABLE dbo.CRMNovedades ADD FechaActualizacionWeb datetime NULL
GO

DECLARE @FechaActualizacionWeb DATETIME = GETDATE()
UPDATE CRMNovedades SET FechaActualizacionWeb = @FechaActualizacionWeb;
ALTER TABLE dbo.CRMNovedades ALTER COLUMN FechaActualizacionWeb datetime NOT NULL
GO

ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



PRINT '11. Parametrois: WEBARCHIVOSSYNCBASEURL'
GO
DECLARE @idParametro VARCHAR(MAX)
DECLARE @descripcionParametro VARCHAR(MAX)
DECLARE @categoriaParametro VARCHAR(MAX) = 'WEB-ARCHIVOS-SYNC'
DECLARE @valorParametro VARCHAR(MAX)

SET @idParametro = 'WEBARCHIVOSSYNCBASEURL'
SET @descripcionParametro = 'Base URL para Sincronización'
SET @valorParametro = 'http://sinergiamovil.com.ar/eniac.sincronizacion/api/'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro, DEST.CategoriaParametro = @categoriaParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, @categoriaParametro, ORIG.DescripcionParametro)
;

SET @idParametro = 'WEBARCHIVOSSYNCEXPORTPATH'
SET @descripcionParametro = 'Carpeta donde exportar JSon'
SET @valorParametro = 'c:\Eniac\Temp\_json\'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro, DEST.CategoriaParametro = @categoriaParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, @categoriaParametro, ORIG.DescripcionParametro)
;


PRINT '12. Parametrois: WEBARCHIVOSSYNCBASEURL'
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
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD IdUnico varchar(50) NULL
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD FechaActualizacionWeb datetime NULL
GO

DECLARE @FechaActualizacionWeb DATETIME = GETDATE()
UPDATE CRMNovedadesSeguimiento SET IdUnico = CONVERT(VARCHAR(50), NEWID()), FechaActualizacionWeb = @FechaActualizacionWeb;

ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN IdUnico varchar(50) NOT NULL
ALTER TABLE dbo.CRMNovedadesSeguimiento ALTER COLUMN FechaActualizacionWeb datetime NOT NULL
GO

ALTER TABLE dbo.CRMNovedadesSeguimiento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



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
ALTER TABLE dbo.CRMNovedadesSeguimiento DROP CONSTRAINT PK_CRMNovedadesSeguimiento
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT PK_CRMNovedadesSeguimiento
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad,IdSeguimiento,IdUnico)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


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
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ADD IdUnico varchar(50) NULL
GO

UPDATE A
   SET IdUnico = S.IdUnico
  FROM CRMNovedadesSeguimientoAdjuntos A
 INNER JOIN CRMNovedadesSeguimiento S ON S.IdTipoNovedad = A.IdTipoNovedad COLLATE Modern_Spanish_CI_AS
                                     AND S.Letra = A.Letra COLLATE Modern_Spanish_CI_AS
                                     AND S.CentroEmisor = A.CentroEmisor
                                     AND S.IdNovedad = A.IdNovedad
                                     AND S.IdSeguimiento = A.IdSeguimiento

ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ALTER COLUMN IdUnico varchar(50) NOT NULL
GO

ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


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
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos DROP CONSTRAINT PK_CRMNovedadesSeguimientoAdjuntos
GO
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos ADD CONSTRAINT PK_CRMNovedadesSeguimientoAdjuntos
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad,IdSeguimiento,IdUnico)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.CRMNovedadesSeguimientoAdjuntos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '1. Nuevo Campo en Compras: ExcluirDePasaje'
ALTER TABLE Compras 
	ADD ExcluirDePasaje BIT NULL
GO

PRINT ''
PRINT '2. Actualización histórica'
UPDATE Compras SET 
	ExcluirDePasaje = 0
GO

PRINT ''
PRINT '3. Actualizo el campo a NOT NULL'
ALTER TABLE Compras 
	ALTER COLUMN ExcluirDePasaje BIT NOT NULL
GO

