
UPDATE BuscadoresCampos
  SET Orden = Orden + 6
 WHERE IdBuscador = 2
   AND Orden > 9
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'UnidHasta1',10,'Unid. 1', 64, 60,'')
GO
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'UHPorc1',11,'Desc.% 1', 64, 60,'N2')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'UnidHasta2',12,'Unid. 2', 64, 60,'')
GO
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'UHPorc2',13,'Desc.% 2', 64, 60,'N2')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'UnidHasta3',14,'Unid. 3', 64, 60,'')
GO
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'UHPorc3',15,'Desc.% 3', 64, 60,'N2')
GO
