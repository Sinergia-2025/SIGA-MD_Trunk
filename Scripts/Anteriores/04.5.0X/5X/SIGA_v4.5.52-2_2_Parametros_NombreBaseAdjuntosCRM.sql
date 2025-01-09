
---Seteo el parametro para que use la base de datos nueva
-- VACIO es la ACTUAL. Mejor dejarlo asi por si hay varias bases.

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('NOMBREBASEADJUNTOSCRM', '', null, 'Nombre de la Base de Adjuntos')
GO
