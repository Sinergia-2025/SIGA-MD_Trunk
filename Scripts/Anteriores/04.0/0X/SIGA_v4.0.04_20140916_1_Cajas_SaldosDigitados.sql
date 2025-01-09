
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
ALTER TABLE dbo.Cajas ADD
	PesosSaldoFinalDigit decimal(10, 2) NULL,
	DolaresSaldoFinalDigit decimal(10, 2) NULL,
	ChequesSaldoFinalDigit decimal(10, 2) NULL,
	TarjetasSaldoFinalDigit decimal(10, 2) NULL,
	TicketsSaldoFinalDigit decimal(10, 2) NULL
GO
ALTER TABLE dbo.Cajas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ----------------- */

UPDATE Cajas 
   SET PesosSaldoFinalDigit = 0
	  ,DolaresSaldoFinalDigit = 0 
	  ,ChequesSaldoFinalDigit = 0 
	  ,TarjetasSaldoFinalDigit = 0 
	  ,TicketsSaldoFinalDigit = 0 
GO

---------------------------

ALTER TABLE dbo.Cajas ALTER COLUMN PesosSaldoFinalDigit decimal(10, 2) NOT NULL
GO
ALTER TABLE dbo.Cajas ALTER COLUMN DolaresSaldoFinalDigit decimal(10, 2) NOT NULL
GO
ALTER TABLE dbo.Cajas ALTER COLUMN ChequesSaldoFinalDigit decimal(10, 2) NOT NULL
GO
ALTER TABLE dbo.Cajas ALTER COLUMN TarjetasSaldoFinalDigit decimal(10, 2) NOT NULL
GO
ALTER TABLE dbo.Cajas ALTER COLUMN TicketsSaldoFinalDigit decimal(10, 2) NOT NULL
GO
