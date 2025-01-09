
PRINT ''
PRINT '1. Clientes: Actualizo Sexo a "No Aplica".'
GO
ALTER TABLE Clientes ALTER COLUMN Sexo varchar(10) NOT NULL
GO
UPDATE Clientes
   SET Sexo  = 'No Aplica'
GO

PRINT ''
PRINT '1. AuditoriaClientes: Actualizo Sexo a "No Aplica".'
GO
ALTER TABLE AuditoriaClientes ALTER COLUMN Sexo varchar(10) NULL
GO
UPDATE AuditoriaClientes
   SET Sexo  = 'No Aplica'
GO

PRINT ''
PRINT '1. Prospectos: Actualizo Sexo a "No Aplica".'
GO
ALTER TABLE Prospectos ALTER COLUMN Sexo varchar(10) NOT NULL
GO
UPDATE Prospectos
   SET Sexo  = 'No Aplica'
GO

PRINT ''
PRINT '1. AuditoriaProspectos: Actualizo Sexo a "No Aplica".'
GO
ALTER TABLE AuditoriaProspectos ALTER COLUMN Sexo varchar(10) NULL
GO
UPDATE AuditoriaProspectos
   SET Sexo  = 'No Aplica'
GO
