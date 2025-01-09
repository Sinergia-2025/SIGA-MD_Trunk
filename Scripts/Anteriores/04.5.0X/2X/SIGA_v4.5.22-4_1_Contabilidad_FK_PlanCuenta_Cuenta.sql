
ALTER TABLE dbo.ContabilidadPlanesCuentas ADD CONSTRAINT
    FK_ContabilidadPlanesCuentas_ContabilidadCuentas FOREIGN KEY (IdCuenta) 
    REFERENCES dbo.ContabilidadCuentas (IdCuenta) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
