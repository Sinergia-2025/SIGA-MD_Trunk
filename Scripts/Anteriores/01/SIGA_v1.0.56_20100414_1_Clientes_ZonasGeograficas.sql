

ALTER TABLE Clientes ADD IdZonaGeografica varchar(20) NULL
GO


ALTER TABLE Clientes  WITH CHECK ADD  CONSTRAINT FK_Clientes_ZonasGeograficas FOREIGN KEY(IdZonaGeografica)
REFERENCES ZonasGeograficas (IdZonaGeografica)
GO


UPDATE CLientes set IdZonaGeografica = 'General' where IdZonaGeografica is NULL 
GO


ALTER TABLE CLientes ALTER COLUMN IdZonaGeografica varchar(20) NOT NULL 
GO
