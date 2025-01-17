
ALTER TABLE Clientes ADD
	IngresosBrutos	varchar(20)	NULL,	
	InscriptoIBStaFe bit NULL,
    LocalIB bit NULL,
    ConvMultilateralIB bit NULL	
GO

UPDATE Clientes 
  SET InscriptoIBStaFe = 'False'
     ,LocalIB = 'False'
     ,ConvMultilateralIB = 'False'
GO

ALTER TABLE Clientes ALTER COLUMN InscriptoIBStaFe bit NOT NULL
GO
ALTER TABLE Clientes ALTER COLUMN LocalIB bit NOT NULL
GO
ALTER TABLE Clientes ALTER COLUMN ConvMultilateralIB bit NOT NULL
GO


/* ---- Auditoria ---- */

ALTER TABLE AuditoriaClientes ADD
	IngresosBrutos	varchar(20)	NULL,	
	InscriptoIBStaFe bit NULL,
    LocalIB bit NULL,
    ConvMultilateralIB bit NULL	
GO

UPDATE AuditoriaClientes 
   SET InscriptoIBStaFe = 'False'
      ,LocalIB = 'False'
      ,ConvMultilateralIB = 'False'
GO

ALTER TABLE AuditoriaClientes ALTER COLUMN InscriptoIBStaFe bit NOT NULL
GO
ALTER TABLE AuditoriaClientes ALTER COLUMN LocalIB bit NOT NULL
GO
ALTER TABLE AuditoriaClientes ALTER COLUMN ConvMultilateralIB bit NOT NULL
GO
