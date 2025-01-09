UPDATE ProductosComponentes
   SET IdFormulaComponente = NULL
 WHERE IdFormulaComponente = 0

IF dbo.ExisteFK('FK_ProductosComponentes_ProductosFormulas_Componente') = 0
BEGIN
    ALTER TABLE dbo.ProductosComponentes ADD CONSTRAINT FK_ProductosComponentes_ProductosFormulas_Componente
        FOREIGN KEY (IdProductoComponente, IdFormulaComponente)
        REFERENCES dbo.ProductosFormulas (IdProducto,IdFormula)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
