ALTER TABLE dbo.CajasDetalle ADD IdMonedaImporteBancos int NULL
GO
ALTER TABLE dbo.CajasDetalle ADD CONSTRAINT FK_CajasDetalle_Monedas
    FOREIGN KEY (IdMonedaImporteBancos)
    REFERENCES dbo.Monedas (IdMoneda) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
UPDATE CajasDetalle
   SET IdMonedaImporteBancos = 1
 WHERE ImporteBancos <> 0


ALTER TABLE dbo.Cajas ADD BancosDolaresSaldoInicial decimal(16, 2) NULL
ALTER TABLE dbo.Cajas ADD BancosDolaresSaldoFinal decimal(16, 2) NULL
ALTER TABLE dbo.Cajas ADD BancosDolaresSaldoFinalDigit decimal(16, 2) NULL
GO
UPDATE Cajas 
   SET BancosDolaresSaldoInicial = 0
     , BancosDolaresSaldoFinal = 0
     , BancosDolaresSaldoFinalDigit = 0;
ALTER TABLE dbo.Cajas ALTER COLUMN BancosDolaresSaldoInicial decimal(16, 2) NOT NULL
ALTER TABLE dbo.Cajas ALTER COLUMN BancosDolaresSaldoFinal decimal(16, 2) NOT NULL
ALTER TABLE dbo.Cajas ALTER COLUMN BancosDolaresSaldoFinalDigit decimal(16, 2) NOT NULL
GO

