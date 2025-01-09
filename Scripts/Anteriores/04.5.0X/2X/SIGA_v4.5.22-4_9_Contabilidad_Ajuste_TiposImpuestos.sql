
EXECUTE sp_rename N'dbo.TiposImpuestos.idCuentaDebe', N'Tmp_IdCuentaDebe', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.TiposImpuestos.idCuentaHaber', N'Tmp_IdCuentaHaber_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.TiposImpuestos.Tmp_IdCuentaDebe', N'IdCuentaDebe', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.TiposImpuestos.Tmp_IdCuentaHaber_1', N'IdCuentaHaber', 'COLUMN' 
GO

ALTER TABLE TiposImpuestos ALTER COLUMN IdCuentaDebe bigint NULL
GO
ALTER TABLE TiposImpuestos ALTER COLUMN IdCuentaHaber bigint NULL
GO

ALTER TABLE dbo.TiposImpuestos ADD CONSTRAINT
    FK_TiposImpuestos_ContabilidadCuentas_Debe FOREIGN KEY (IdCuentaDebe)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.TiposImpuestos ADD CONSTRAINT
    FK_TiposImpuestos_ContabilidadCuentas_Haber FOREIGN KEY (IdCuentaHaber)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
