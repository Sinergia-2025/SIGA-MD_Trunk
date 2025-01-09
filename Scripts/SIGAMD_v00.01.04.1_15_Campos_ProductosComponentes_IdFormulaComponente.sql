IF dbo.ExisteCampo('ProductosComponentes', 'IdFormulaComponente') = 0
BEGIN
    ALTER TABLE dbo.ProductosComponentes ADD IdFormulaComponente int NULL
END
GO

UPDATE PC
   SET IdFormulaComponente = P.IdFormula
  FROM ProductosComponentes PC
 INNER JOIN Productos P ON P.IdProducto = PC.IdProductoComponente
 WHERE P.IdFormula IS NOT NULL

