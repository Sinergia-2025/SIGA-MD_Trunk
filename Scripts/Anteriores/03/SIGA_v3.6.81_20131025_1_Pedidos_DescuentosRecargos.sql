
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
ALTER TABLE dbo.Pedidos ADD
DescuentoRecargo	decimal(14, 4)	NULL,
DescuentoRecargoPorc	decimal(6, 2)	NULL
		
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*----------------------------------------------------------------------*/

UPDATE Pedidos
  SET DescuentoRecargo = 0 , DescuentoRecargoPorc = 0
GO
/*----------------------------------------------------------------------*/

ALTER TABLE Pedidos ALTER COLUMN DescuentoRecargo	decimal(14, 4)	NOT NULL
ALTER TABLE Pedidos ALTER COLUMN DescuentoRecargoPorc	decimal(6, 2)	NOT NULL
		
	
GO
