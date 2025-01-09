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
