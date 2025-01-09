--Agregar Direccion y localidad a Impresoras
ALTER TABLE dbo.Impresoras ADD Direccion varchar(100) NULL
GO
ALTER TABLE dbo.Impresoras ADD IdLocalidad int NULL
GO
ALTER TABLE dbo.Impresoras ADD CONSTRAINT FK_Impresoras_Localidades
    FOREIGN KEY (IdLocalidad)
    REFERENCES dbo.Localidades (IdLocalidad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

