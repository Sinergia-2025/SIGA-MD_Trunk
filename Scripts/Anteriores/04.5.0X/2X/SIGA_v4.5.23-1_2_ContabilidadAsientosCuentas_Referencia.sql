
ALTER TABLE dbo.ContabilidadAsientosCuentasTmp ADD IdTipoReferencia char(1) NULL
GO

ALTER TABLE dbo.ContabilidadAsientosCuentasTmp ADD Referencia varchar(30) NULL
GO

ALTER TABLE dbo.ContabilidadAsientosCuentas ADD IdTipoReferencia char(1) NULL
GO

ALTER TABLE dbo.ContabilidadAsientosCuentas ADD Referencia varchar(30) NULL
GO
