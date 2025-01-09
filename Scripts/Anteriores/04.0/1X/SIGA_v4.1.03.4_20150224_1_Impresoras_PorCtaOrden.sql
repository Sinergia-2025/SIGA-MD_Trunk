
ALTER TABLE Impresoras ADD PorCtaOrden bit NULL
GO

UPDATE Impresoras SET PorCtaOrden = 'False'
GO

ALTER TABLE Impresoras ALTER COLUMN PorCtaOrden bit NOT NULL
GO
