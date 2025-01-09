
UPDATE Bitacora
   SET Tipo = 'IniciarPantalla'
 WHERE Tipo IS NULL OR Tipo = ''
GO

ALTER TABLE Bitacora ALTER COLUMN Tipo varchar(15) NOT NULL
GO
