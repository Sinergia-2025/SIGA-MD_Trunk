
/* CLIENTES */

ALTER TABLE Clientes ADD ModificarDatos bit null
GO
UPDATE Clientes SET ModificarDatos = (CASE WHEN NombreCLiente = 'CONSUMIDOR FINAL' OR  NombreCLiente = 'MOSTRADOR'  THEN 'False' ELSE 'True' END)
GO
ALTER TABLE Clientes ALTER COLUMN ModificarDatos bit not null
GO

--- Valor DEFAULT para los Otros sistemas
ALTER TABLE dbo.Clientes ADD CONSTRAINT DF_Clientes_ModificarDatos DEFAULT 'True' FOR ModificarDatos
GO


ALTER TABLE AuditoriaClientes ADD ModificarDatos bit null
GO
UPDATE AuditoriaClientes SET ModificarDatos = (CASE WHEN NombreCLiente = 'CONSUMIDOR FINAL' OR  NombreCLiente = 'MOSTRADOR'  THEN 'False' ELSE 'True' END)
GO
ALTER TABLE AuditoriaClientes ALTER COLUMN ModificarDatos bit not null
GO

/* PROSPECTOS */
 
ALTER TABLE Prospectos ADD ModificarDatos bit null
GO
UPDATE Prospectos SET ModificarDatos = 'True'
GO
ALTER TABLE Prospectos ALTER COLUMN ModificarDatos bit not null
GO

ALTER TABLE AuditoriaProspectos ADD ModificarDatos bit null
GO
UPDATE AuditoriaProspectos SET ModificarDatos = 'True'
GO
ALTER TABLE AuditoriaProspectos ALTER COLUMN ModificarDatos bit not null
GO

