DECLARE @Orden int = (SELECT MAX(Orden) FROM BuscadoresCampos WHERE IdBuscador = 2);

INSERT INTO BuscadoresCampos
        (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila)
VALUES  (2,'CodigoProductoProveedor',@Orden+1,'Prod. Prov.',64,80,'',NULL, NULL, NULL)

INSERT INTO BuscadoresCampos
        (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila)
VALUES  (2,'CodigoProveedor',@Orden+2,'Cód.Prov.H',64,80,'',NULL, NULL, NULL)

INSERT INTO BuscadoresCampos
        (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila)
VALUES  (2,'NombreProveedor',@Orden+3,'Proveedor Habitual',16,250,'',NULL, NULL, NULL)
