
UPDATE Clientes 
   SET Telefono = ''
 WHERE Telefono IS NULL
GO

UPDATE Clientes 
   SET Celular = ''
 WHERE Celular IS NULL
GO

UPDATE Clientes 
   SET CorreoElectronico = ''
 WHERE CorreoElectronico IS NULL
GO

