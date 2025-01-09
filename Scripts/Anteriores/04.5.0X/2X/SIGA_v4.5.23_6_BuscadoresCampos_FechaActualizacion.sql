
UPDATE BuscadoresCampos
  SET Orden = Orden + 1
 WHERE IdBuscador = 2
   AND Orden >= 10
GO

INSERT INTO BuscadoresCampos
  (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
 VALUES
  (2, 'FechaActualizacion',10,'Actualizacion', 32, 100, 'dd/MM/yyyy HH:mm')
GO

/*
SELECT * FROM BuscadoresCampos
 WHERE IdBuscador = 2
  ORDER BY Orden 
GO
*/
