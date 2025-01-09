

---COMPRAS
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
('CONTABILIDADCUENTACOMPRASDEBE', '10501002', 'CONTABILIDAD', 'Valor por defecto de cuenta de compras para el debe')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
('CONTABILIDADCUENTACOMPRASHABER', '40102002', 'CONTABILIDAD', 'Valor por defecto de cuenta de compras para el haber')
GO

--IVA
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
 ('CONTABILIDADCUENTAIVADEBE', '10401007', 'CONTABILIDAD', 'Valor por defecto de cuenta de IVA para el debe')
 GO
 
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
('CONTABILIDADCUENTAIVAHABER', '10401006', 'CONTABILIDAD', 'Valor por defecto de cuenta de IVA para el haber')
GO

----VENTAS
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
('CONTABILIDADCUENTAVENTASDEBE', '10301001', 'CONTABILIDAD', 'Valor por defecto de cuenta de ventas para el debe')
GO

INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
('CONTABILIDADCUENTAVENTASHABER', '40101001', 'CONTABILIDAD', 'Valor por defecto de cuenta de ventas para el haber')
GO
