
ALTER TABLE dbo.Tarjetas ADD
	Acreditacion bit NULL,	
	IdCuentaBancaria int NULL,
	CantDiasAcredit int NULL,
	PagoPosVenta bit NULL,
        PagoPosCorte bit NULL,
	DiaCorte int NULL
GO

UPDATE Tarjetas 
   SET PagoPosVenta = 'False'
      ,PagoPosCorte = 'False'
      ,Acreditacion = 'False'
GO

ALTER TABLE Tarjetas ALTER COLUMN PagoPosVenta bit NOT NULL
GO

ALTER TABLE Tarjetas ALTER COLUMN PagoPosCorte bit NOT NULL
GO

ALTER TABLE Tarjetas ALTER COLUMN Acreditacion bit NOT NULL
GO
