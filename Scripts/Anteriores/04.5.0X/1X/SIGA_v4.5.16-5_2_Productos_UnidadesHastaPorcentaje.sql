
ALTER TABLE Productos ADD UnidHasta1 int null
GO
ALTER TABLE Productos ADD UnidHasta2 int null
GO
ALTER TABLE Productos ADD UnidHasta3 int null
GO
ALTER TABLE Productos ADD UHPorc1 decimal(14, 2) null
GO
ALTER TABLE Productos ADD UHPorc2 decimal(14, 2) null
GO
ALTER TABLE Productos ADD UHPorc3 decimal(14, 2) null
GO

UPDATE Productos 
   SET UnidHasta1 = 0
      ,UnidHasta2 = 0
      ,UnidHasta3 = 0
      ,UHPorc1 = 0
      ,UHPorc2 = 0
      ,UHPorc3 = 0
GO

ALTER TABLE Productos ALTER COLUMN UnidHasta1 int NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UnidHasta2 int NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UnidHasta3 int NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UHPorc1 decimal(14, 2) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UHPorc2 decimal(14, 2) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UHPorc3 decimal(14, 2) NOT NULL
GO


--Asigno el default para otros sistemas.

ALTER TABLE Productos ADD DEFAULT 0 FOR UnidHasta1 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UnidHasta2 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UnidHasta3 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UHPorc1 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UHPorc2 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UHPorc3 
GO


/* ------------------- */

ALTER TABLE AuditoriaProductos ADD UnidHasta1 int null
GO
ALTER TABLE AuditoriaProductos ADD UnidHasta2 int null
GO
ALTER TABLE AuditoriaProductos ADD UnidHasta3 int null
GO
ALTER TABLE AuditoriaProductos ADD UHPorc1 decimal(14, 2) null
GO
ALTER TABLE AuditoriaProductos ADD UHPorc2 decimal(14, 2) null
GO
ALTER TABLE AuditoriaProductos ADD UHPorc3 decimal(14, 2) null
GO

UPDATE AuditoriaProductos 
   SET UnidHasta1 = 0
      ,UnidHasta2 = 0
      ,UnidHasta3 = 0
      ,UHPorc1 = 0
      ,UHPorc2 = 0
      ,UHPorc3 = 0
GO
