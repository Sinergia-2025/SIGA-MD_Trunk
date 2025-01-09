
-- Para Productos --

-- Hago un luego luego del codigo de barras.

UPDATE BuscadoresCampos
  SET Orden = Orden + 1
 WHERE IdBuscador = 2
   AND Orden >= 13
GO

-- Agrego el Campo Oferta incluyendo la condicion para pintar de color.

INSERT INTO BuscadoresCampos
      (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato
      ,Condicion , Valor, ColorFila)
VALUES
      (2, 'EsOferta', 13, 'Oferta', 32, 50, ''
      ,'Igual', 'SI', 'Yellow')
GO

