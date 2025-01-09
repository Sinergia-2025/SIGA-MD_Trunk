UPDATE Buscadores
  SET AnchoAyuda=1300
 WHERE IdBuscador = 2
GO


--SELECT * FROM BuscadoresCampos
-- WHERE IdBuscador = 2
--  ORDER BY Orden
--GO

UPDATE BuscadoresCampos
  SET Orden = Orden + 1
 WHERE IdBuscador = 2
   AND IdBuscadorNombreCampo = 'CodigoDeBarras'
GO

UPDATE BuscadoresCampos
  SET Orden = Orden - 1
 WHERE IdBuscador = 2
   AND IdBuscadorNombreCampo = 'FechaActualizacion'
GO

UPDATE BuscadoresCampos
  SET Orden = Orden + 2
 WHERE IdBuscador = 2
   AND Orden >= 10
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'NombreMarca',10,'Marca', 16, 150,'')
GO
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'NombreRubro',11,'Rubro', 16, 150,'')
GO

