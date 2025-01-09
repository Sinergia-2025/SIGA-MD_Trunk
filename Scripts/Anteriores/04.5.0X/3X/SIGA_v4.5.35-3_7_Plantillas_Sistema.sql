
ALTER TABLE Plantillas ADD Sistema bit NULL
GO

UPDATE Plantillas SET Sistema = 'False'
GO

UPDATE Plantillas 
   SET Sistema = 'True' 
     , IdProveedor = NULL
 WHERE IdPlantilla IN (1, 2)
GO
 
ALTER TABLE Plantillas ALTER COLUMN Sistema bit NOT NULL
GO
