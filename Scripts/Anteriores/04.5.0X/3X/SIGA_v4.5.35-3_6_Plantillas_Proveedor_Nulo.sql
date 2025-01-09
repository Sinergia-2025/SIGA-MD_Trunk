
ALTER TABLE Plantillas DROP CONSTRAINT [FK_Plantillas_Proveedores] 
GO 

ALTER TABLE Plantillas ALTER COLUMN IdProveedor int NULL
GO

