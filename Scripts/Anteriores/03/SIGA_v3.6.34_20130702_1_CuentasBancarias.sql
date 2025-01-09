
ALTER TABLE dbo.CuentasBancarias ADD [idCuentaDebe] [int] NULL
GO

ALTER TABLE dbo.CuentasBancarias ADD [idCuentaHaber] [int] NULL
GO

UPDATE dbo.CuentasBancarias SET [idCuentaDebe] = 0
GO

UPDATE dbo.CuentasBancarias SET [idCuentaHaber] = 0
GO
