

/* Agrega y setea la Lista de Precios predeterminada por Cliente */

ALTER TABLE Clientes ADD IdListaPrecios int NULL
GO

UPDATE Clientes SET IdListaPrecios = 0
GO

ALTER TABLE Clientes ALTER COLUMN IdListaPrecios int NOT NULL
GO

INSERT INTO ListasDePrecios 
    (IdListaPrecios, NombreListaPrecios, FechaVigencia)
    VALUES ( 0, 'Lista de Venta 1', GETDATE() )
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
ALTER TABLE dbo.ListasDePrecios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_ListasDePrecios FOREIGN KEY
	(
	IdListaPrecios
	) REFERENCES dbo.ListasDePrecios
	(
	IdListaPrecios
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT






