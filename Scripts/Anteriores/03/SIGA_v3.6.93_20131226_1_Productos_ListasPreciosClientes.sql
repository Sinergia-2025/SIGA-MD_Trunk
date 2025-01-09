
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
ALTER TABLE dbo.Productos ADD
	PublicarListaDePreciosClientes bit NULL,
	FacturacionCantidadNegativa bit NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ----------------------------*/

UPDATE dbo.Productos
  SET PublicarListaDePreciosClientes = AfectaStock
     ,FacturacionCantidadNegativa = 'False'
GO

ALTER TABLE dbo.Productos ALTER COLUMN PublicarListaDePreciosClientes bit NOT NULL
GO

ALTER TABLE dbo.Productos ALTER COLUMN FacturacionCantidadNegativa bit NOT NULL
GO
