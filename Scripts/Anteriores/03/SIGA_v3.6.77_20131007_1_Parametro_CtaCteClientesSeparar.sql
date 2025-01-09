DELETE Parametros 
 WHERE IdParametro = 'SEPARACTACTE'
GO

INSERT INTO Parametros 
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
    ('CTACTECLIENTESSEPARAR', 'True', NULL, 'Separar Comprobantes')
GO
