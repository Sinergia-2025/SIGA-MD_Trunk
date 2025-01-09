BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD
	MercDespachada bit NULL
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*-------------------------*/

UPDATE dbo.Ventas 
 SET MercDespachada = 'False'
GO

/*-------------------------*/


ALTER TABLE dbo.Ventas ALTER COLUMN MercDespachada bit NOT NULL 
GO