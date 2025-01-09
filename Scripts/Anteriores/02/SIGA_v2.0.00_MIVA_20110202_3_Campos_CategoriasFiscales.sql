
ALTER TABLE CategoriasFiscales ADD UtilizaImpuestos bit NULL
GO

UPDATE CategoriasFiscales SET
  UtilizaImpuestos = (CASE WHEN IvaInscripto > 0 THEN 'True' ELSE 'False' END)
GO

ALTER TABLE CategoriasFiscales ALTER COLUMN UtilizaImpuestos bit NOT NULL
GO


ALTER TABLE CategoriasFiscales DROP COLUMN IvaInscripto
GO

ALTER TABLE CategoriasFiscales DROP COLUMN IvaNoInscripto
GO
