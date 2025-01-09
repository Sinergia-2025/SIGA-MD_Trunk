-- Preservo Informacion Anterior

-- CLIENTES

ALTER TABLE dbo.CuentasCorrientesPagos ADD ImporteCuotaOriginal decimal(12, 2) NULL
GO

UPDATE CuentasCorrientesPagos 
   SET ImporteCuotaOriginal = ImporteCuota
GO

UPDATE CuentasCorrientesPagos 
   SET ImporteCuota = SaldoCuota 
GO

ALTER TABLE dbo.CuentasCorrientes ADD ImporteTotalOriginal decimal(12, 2) NULL
GO

UPDATE CuentasCorrientes 
   SET ImporteTotalOriginal = ImporteTotal
GO

UPDATE CuentasCorrientes 
   SET ImporteTotal = Saldo
GO


-- PROVEEDOREs

ALTER TABLE dbo.CuentasCorrientesProvPagos ADD ImporteCuotaOriginal decimal(12, 2) NULL
GO

UPDATE CuentasCorrientesProvPagos 
   SET ImporteCuotaOriginal = ImporteCuota
GO

UPDATE CuentasCorrientesProvPagos 
   SET ImporteCuota = SaldoCuota 
GO

ALTER TABLE dbo.CuentasCorrientesProv ADD ImporteTotalOriginal decimal(12, 2) NULL
GO

UPDATE CuentasCorrientesProv 
   SET ImporteTotalOriginal = ImporteTotal
GO

UPDATE CuentasCorrientesProv 
   SET ImporteTotal = Saldo
GO
