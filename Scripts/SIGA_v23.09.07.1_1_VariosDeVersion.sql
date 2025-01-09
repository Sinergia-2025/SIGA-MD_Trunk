IF dbo.ExisteCampo('CRMNovedades', 'PatenteVehiculo') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD PatenteVehiculo varchar(8) NULL
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD PatenteVehiculo varchar(8) NULL
END
GO
IF dbo.ExisteFK('FK_CRMNovedades_Vehiculos') = 0
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_Vehiculos
        FOREIGN KEY (PatenteVehiculo)
        REFERENCES dbo.Vehiculos (PatenteVehiculo)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
