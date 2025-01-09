
ALTER TABLE Rubros ADD UnidHasta1 int null
GO
ALTER TABLE Rubros ADD UnidHasta2 int null
GO
ALTER TABLE Rubros ADD UnidHasta3 int null
GO
ALTER TABLE Rubros ADD UHPorc1 decimal(14, 2) null
GO
ALTER TABLE Rubros ADD UHPorc2 decimal(14, 2) null
GO
ALTER TABLE Rubros ADD UHPorc3 decimal(14, 2) null
GO

UPDATE Rubros 
   SET UnidHasta1 = 0
      ,UnidHasta2 = 0
      ,UnidHasta3 = 0
      ,UHPorc1 = 0
      ,UHPorc2 = 0
      ,UHPorc3 = 0
GO

ALTER TABLE Rubros ALTER COLUMN UnidHasta1 int not null
GO
ALTER TABLE Rubros ALTER COLUMN UnidHasta2 int not null
GO
ALTER TABLE Rubros ALTER COLUMN UnidHasta3 int not null
GO
ALTER TABLE Rubros ALTER COLUMN UHPorc1 decimal(14, 2) not null
GO
ALTER TABLE Rubros ALTER COLUMN UHPorc2 decimal(14, 2) not null
GO
ALTER TABLE Rubros ALTER COLUMN UHPorc3 decimal(14, 2) not null
GO


--Asigno el default para otros sistemas.

ALTER TABLE Rubros ADD DEFAULT 0 FOR UnidHasta1 
GO
ALTER TABLE Rubros ADD DEFAULT 0 FOR UnidHasta2 
GO
ALTER TABLE Rubros ADD DEFAULT 0 FOR UnidHasta3 
GO
ALTER TABLE Rubros ADD DEFAULT 0 FOR UHPorc1 
GO
ALTER TABLE Rubros ADD DEFAULT 0 FOR UHPorc2 
GO
ALTER TABLE Rubros ADD DEFAULT 0 FOR UHPorc3 
GO
