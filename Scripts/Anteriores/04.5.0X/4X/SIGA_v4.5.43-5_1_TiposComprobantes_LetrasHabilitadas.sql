
--- La E no deberia estar, porque es una compra. Ahora se utiliza I. Se deja por compabilitdad con Datos.

UPDATE TiposComprobantes
    SET LetrasHabilitadas = 'A,B,C,E,I'
 WHERE IdTipoComprobante IN ('FACTCOM','NCREDCOM','NDEBCHEQRECHCOM','NDEBCOM')
GO
