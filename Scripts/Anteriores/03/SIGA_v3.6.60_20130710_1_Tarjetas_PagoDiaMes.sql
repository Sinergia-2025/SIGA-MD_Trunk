
ALTER TABLE dbo.Tarjetas ADD
	PagoDiaMes bit NULL,	
	DiaMes int NULL
GO

UPDATE Tarjetas 
   SET PagoDiaMes = 'False'
    GO

ALTER TABLE Tarjetas ALTER COLUMN PagoDiaMes bit NOT NULL
GO

