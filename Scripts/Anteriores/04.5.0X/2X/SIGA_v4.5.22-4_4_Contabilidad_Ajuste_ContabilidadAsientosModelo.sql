
ALTER TABLE dbo.ContabilidadAsientosModelo ADD CONSTRAINT
    FK_ContabilidadAsientosModelo_ContabilidadPlanes FOREIGN KEY (IdPlanCuenta)
    REFERENCES dbo.ContabilidadPlanes (IdPlanCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.ContabilidadAsientosModelo ADD CONSTRAINT
    FK_ContabilidadAsientosModelo_ContabilidadCuentas FOREIGN KEY (IdCuenta)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
