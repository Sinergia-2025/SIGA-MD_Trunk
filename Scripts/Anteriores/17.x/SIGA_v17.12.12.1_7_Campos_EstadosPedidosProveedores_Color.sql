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
PRINT '1. Agrego la columna Color'
ALTER TABLE dbo.EstadosPedidosProveedores ADD Color int NULL
GO
PRINT '2. Copio los colores de EstadosPedidos a EstadosPedidosProveedores'
UPDATE EstadosPedidosProveedores
   SET Color = EP.Color
  FROM EstadosPedidosProveedores EPP
 INNER JOIN EstadosPedidos EP ON EP.idEstado = EPP.idEstado AND EP.TipoEstadoPedido = 'PEDIDOSCLIE'
;
PRINT '3. Si me queda algún color en blanco le pongo amarillo'
UPDATE EstadosPedidosProveedores
   SET Color = -256
 WHERE Color IS NULL
;
PRINT '4. Hago NOT NULL el Color'
ALTER TABLE dbo.EstadosPedidosProveedores ALTER COLUMN Color int NOT NULL
GO
ALTER TABLE dbo.EstadosPedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
