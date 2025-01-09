ALTER TABLE Bancos ADD
	DebitoDirecto bit NULL,
    Empresa int NULL,
    Convenio int NULL,
    Servicio varchar(10) NULL	
GO

UPDATE Bancos 
  SET DebitoDirecto = 'False'
GO

ALTER TABLE Bancos ALTER COLUMN DebitoDirecto bit NOT NULL
GO
