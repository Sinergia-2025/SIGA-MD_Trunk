
DECLARE @Multiples Varchar(5)
SET @Multiples = 'False'

IF EXISTS (SELECT COUNT(IdSucursal) FROM Sucursales HAVING COUNT(IdSucursal)>1)
	SET @Multiples = 'True';

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('PERMITECONSULTARMULTIPLESUCURSAL', @Multiples, 'Empresa', 'Permite Consultar Multiple Sucursales')
;

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('CONSULTARMULTIPLESUCURSAL', @Multiples, 'Empresa', 'Consultar Multiple Sucursales')
;

SELECT * FROM Parametros 
 WHERE IdParametro IN ('PERMITECONSULTARMULTIPLESUCURSAL','CONSULTARMULTIPLESUCURSAL')
;
