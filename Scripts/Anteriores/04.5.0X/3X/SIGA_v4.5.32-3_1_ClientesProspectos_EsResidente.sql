
/* ----- CLIENTES ----- */

ALTER TABLE Clientes ADD EsResidente bit null
GO

UPDATE Clientes SET EsResidente = 'False'
GO

ALTER TABLE Clientes ALTER COLUMN EsResidente bit not null
GO

--- Valor DEFAULT para los Otros sistemas
ALTER TABLE Clientes ADD CONSTRAINT DF_Clientes_EsResidente DEFAULT 'False' FOR EsResidente
GO

----

ALTER TABLE AuditoriaClientes ADD EsResidente bit null
GO

UPDATE AuditoriaClientes SET EsResidente = 'False'
GO

ALTER TABLE AuditoriaClientes ALTER COLUMN EsResidente bit not null
GO

/* ----- PROSPECTOS ----- */

ALTER TABLE Prospectos ADD EsResidente bit null
GO

UPDATE Prospectos SET EsResidente = 'False'
GO

ALTER TABLE Prospectos ALTER COLUMN EsResidente bit not null
GO

ALTER TABLE AuditoriaProspectos ADD EsResidente bit null
GO

UPDATE AuditoriaProspectos SET EsResidente = 'False'
GO

ALTER TABLE AuditoriaProspectos ALTER COLUMN EsResidente bit not null
GO
