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
ALTER TABLE dbo.VentasCajeros ADD IdCategoria int NULL
GO
ALTER TABLE dbo.VentasCajeros ADD IdCategoriaFiscal smallint NULL
GO
ALTER TABLE dbo.VentasCajeros ADD NombreCategoriaFiscal varchar(40) NULL
GO

UPDATE VentasCajeros
   SET IdCategoria = CA.IdCategoria
     , IdCategoriaFiscal = CF.IdCategoriaFiscal
     , NombreCategoriaFiscal = CF.NombreCategoriaFiscal
  FROM VentasCajeros VC
 INNER JOIN Clientes C ON C.IdCliente = VC.IdCliente
 INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria
 INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal
 GO

ALTER TABLE dbo.VentasCajeros ALTER COLUMN IdCategoria int NOT NULL
GO
ALTER TABLE dbo.VentasCajeros ALTER COLUMN IdCategoriaFiscal smallint NOT NULL
GO
ALTER TABLE dbo.VentasCajeros ALTER COLUMN NombreCategoriaFiscal varchar(40) NOT NULL
GO

ALTER TABLE dbo.VentasCajeros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
