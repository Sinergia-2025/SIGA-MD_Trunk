
ALTER TABLE dbo.ContabilidadCuentasRubros DROP CONSTRAINT PK_ContabilidadCuentasRubros
GO
ALTER TABLE dbo.ContabilidadCuentasRubros ADD CONSTRAINT
    PK_ContabilidadCuentasRubros PRIMARY KEY CLUSTERED 
    (idRubro,IdCuenta,IdPlanCuenta,Tipo) 
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.ContabilidadCuentasRubros DROP COLUMN Debe, Haber, GrupoAsiento, Campo
GO
EXECUTE sp_rename N'dbo.ContabilidadCuentasRubros.idRubro', N'Tmp_IdRubro_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.ContabilidadCuentasRubros.Tmp_IdRubro_2', N'IdRubro', 'COLUMN' 
GO

ALTER TABLE dbo.ContabilidadCuentasRubros ADD CONSTRAINT
    FK_ContabilidadCuentasRubros_Rubros FOREIGN KEY (IdRubro) 
    REFERENCES dbo.Rubros (IdRubro) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.ContabilidadCuentasRubros ADD CONSTRAINT
    FK_ContabilidadCuentasRubros_ContabilidadCuentas FOREIGN KEY (IdCuenta)
    REFERENCES dbo.ContabilidadCuentas (IdCuenta) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.ContabilidadCuentasRubros ADD CONSTRAINT
    FK_ContabilidadCuentasRubros_ContabilidadPlanes FOREIGN KEY (IdPlanCuenta)
    REFERENCES dbo.ContabilidadPlanes (IdPlanCuenta)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
