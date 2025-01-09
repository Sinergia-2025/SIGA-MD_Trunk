
PRINT ''
PRINT '1. Tabla Productos: Agregar FechaExportacionWeb.'
GO

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
ALTER TABLE dbo.Productos ADD FechaExportacionWeb datetime NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProductos ADD FechaExportacionWeb datetime NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla Productos: Agrego Trigger para Actualizar FechaExportacionWeb.'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Productos_Insert_Update] ON [dbo].[Productos]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;
        IF NOT (UPDATE(FechaExportacionWeb))
        BEGIN
            UPDATE Productos
               SET Productos.FechaActualizacionWeb = GETDATE()
            FROM inserted
            WHERE Productos.IdProducto = inserted.IdProducto
        END
    END
GO
