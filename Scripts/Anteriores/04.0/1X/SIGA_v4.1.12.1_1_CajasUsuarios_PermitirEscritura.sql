
ALTER TABLE CajasUsuarios ADD PermitirEscritura bit null 
GO

UPDATE CajasUsuarios SET PermitirEscritura = 'True'
GO

ALTER TABLE CajasUsuarios ALTER COLUMN PermitirEscritura bit not null 
GO
