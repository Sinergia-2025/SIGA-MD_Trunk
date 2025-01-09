ALTER TABLE dbo.CajasNombres ADD TopeAviso decimal(10, 2) NULL
GO

ALTER TABLE dbo.CajasNombres ADD TopeBloqueo decimal(10, 2) NULL
GO

UPDATE dbo.CajasNombres SET TopeAviso = 0
GO

UPDATE dbo.CajasNombres SET TopeBloqueo = 0
GO

ALTER TABLE dbo.CajasNombres ALTER COLUMN TopeAviso decimal(10, 2) NOT NULL
GO

ALTER TABLE dbo.CajasNombres ALTER COLUMN TopeBloqueo decimal(10, 2) NOT NULL
GO

