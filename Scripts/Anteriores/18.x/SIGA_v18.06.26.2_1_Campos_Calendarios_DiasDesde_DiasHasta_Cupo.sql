
ALTER TABLE Calendarios ADD DiasDesde int null
GO

ALTER TABLE Calendarios ADD DiasHasta int null
GO

ALTER TABLE Calendarios ADD Cupo int null
GO

UPDATE Calendarios SET Cupo = 1, DiasDesde = 0, DiasHasta = 15
GO

ALTER TABLE Calendarios ALTER COLUMN DiasDesde int not null
GO

ALTER TABLE Calendarios ALTER COLUMN DiasHasta int not null
GO

ALTER TABLE Calendarios ALTER COLUMN Cupo int not null
GO

