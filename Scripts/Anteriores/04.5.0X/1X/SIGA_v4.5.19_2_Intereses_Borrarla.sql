
-- Solo NO borra en Marinzaldi que lo usa en Fichas
IF NOT EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro = '20175798162')
BEGIN
	DELETE FROM Intereses;
END
