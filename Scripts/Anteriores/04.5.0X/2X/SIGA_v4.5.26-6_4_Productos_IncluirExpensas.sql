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
ALTER TABLE dbo.Productos ADD IncluirExpensas bit NULL
GO

UPDATE Productos
   SET IncluirExpensas = CASE WHEN Parametros.ValorParametro = 'True' THEN 1 ELSE 0 END
  FROM Productos
 CROSS JOIN (SELECT * FROM Parametros WHERE Parametros.IdParametro LIKE 'MODULOEXPENSAS') AS Parametros
GO

ALTER TABLE dbo.Productos ALTER COLUMN IncluirExpensas bit NOT NULL
GO

ALTER TABLE dbo.AuditoriaProductos ADD IncluirExpensas bit NULL
GO

ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* -------------- */

IF EXISTS (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'MODULOEXPENSAS' AND ValorParametro = 'True')
    BEGIN

		ALTER TABLE dbo.Productos 
		  ADD CONSTRAINT DF_Productos_IncluirExpensas DEFAULT 'True' FOR IncluirExpensas
		;

    END
ELSE
    BEGIN
		ALTER TABLE dbo.Productos 
		  ADD CONSTRAINT DF_Productos_IncluirExpensas DEFAULT 'False' FOR IncluirExpensas
		;
    END
GO

