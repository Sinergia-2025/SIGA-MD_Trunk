
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
ALTER TABLE dbo.PedidosProductos ADD IdListaPrecios int NULL
GO
ALTER TABLE dbo.PedidosProductos ADD NombreListaPrecios varchar(50) 
GO

UPDATE PedidosProductos
   SET IdListaPrecios = LP.IdListaPrecios
      ,NombreListaPrecios = LP.NombreListaPrecios
  FROM (SELECT TOP 1 * FROM ListasDePrecios ORDER BY IdListaPrecios) AS LP
GO

ALTER TABLE dbo.PedidosProductos ALTER COLUMN IdListaPrecios int NOT NULL
GO
ALTER TABLE dbo.PedidosProductos ALTER COLUMN NombreListaPrecios varchar(50) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
