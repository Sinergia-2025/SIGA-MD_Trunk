
PRINT ''
PRINT '1. Proveedores: campos Correo '

ALTER TABLE Proveedores ALTER COLUMN CorreoElectronico	varchar(250) NULL
GO
ALTER TABLE Proveedores ALTER COLUMN CorreoAdministrativo	varchar(250) NULL
GO