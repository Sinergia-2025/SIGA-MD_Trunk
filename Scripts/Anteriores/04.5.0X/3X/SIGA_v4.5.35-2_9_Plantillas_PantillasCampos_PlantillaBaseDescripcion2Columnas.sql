
INSERT INTO Plantillas
    (IdPlantilla, NombrePlantilla, IdProveedor, FilaInicial)
 VALUES
    (2, 'Plantilla Base - Nombre Producto en 2 columnas', 1, 1)
GO

INSERT INTO dbo.PlantillasCampos
    (IdPlantilla, IdCampo, OrdenColumna)
 VALUES
    (2, 1, 1),
    (2 ,2 ,2),
    (2 ,3 ,3),
    (2 ,4 ,4),
    (2 ,5 ,5),
    (2 ,6 ,6),
    (2 ,7 ,7),
    (2 ,8 ,8),
    (2 ,9 ,9),
    (2 ,10 ,10)
GO
