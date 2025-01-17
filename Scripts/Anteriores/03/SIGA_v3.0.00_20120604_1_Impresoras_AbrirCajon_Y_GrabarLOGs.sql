
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
ALTER TABLE dbo.Impresoras ADD
	AbrirCajonDinero bit NULL,
	GrabarLOGs bit NULL
GO
ALTER TABLE dbo.Impresoras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

---------------------------------------

UPDATE dbo.Impresoras 
   SET AbrirCajonDinero = (CASE WHEN TipoImpresora = 'FISCAL' AND Metodo = 'DLLs' THEN 'True' ELSE 'False' END)
GO

UPDATE dbo.Impresoras 
   SET GrabarLOGs = 'False'
GO

---------------------------------------

ALTER TABLE dbo.Impresoras ALTER COLUMN AbrirCajonDinero bit NOT NULL
GO

ALTER TABLE dbo.Impresoras ALTER COLUMN GrabarLOGs bit NOT NULL
GO
