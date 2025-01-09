
INSERT INTO Parametros
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
SELECT 'NombreBaseARBA', DB_NAME(), NULL, 'Nombre de la Base del Padron ARBA'
GO
