
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
ALTER TABLE dbo.TiposComprobantes ADD IncluirEnExpensas bit NOT NULL
    CONSTRAINT DF_TiposComprobantes_IncluidoEnExpensas DEFAULT 0
GO

UPDATE TiposComprobantes
   SET IncluirEnExpensas = P.ValorParametro
  FROM TiposComprobantes TP
 CROSS JOIN (SELECT * FROM Parametros P WHERE P.IdParametro = 'MODULOEXPENSAS') AS P
   WHERE GrabaLibro = 'True' AND Tipo = 'COMPRAS'
GO

ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------ */ 

SELECT * FROM TiposComprobantes
 WHERE IncluirEnExpensas = 'True'
GO
