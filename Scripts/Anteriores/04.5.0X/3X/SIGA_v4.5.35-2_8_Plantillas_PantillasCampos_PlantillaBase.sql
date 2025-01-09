
INSERT INTO Plantillas
    (IdPlantilla, NombrePlantilla, IdProveedor, FilaInicial)
 VALUES
    (1, 'Plantilla Base', 1, 1)
GO

INSERT INTO dbo.PlantillasCampos
    (IdPlantilla, IdCampo, OrdenColumna)
 VALUES
    (1, 1, 1),
    (1, 2, 2),
    (1, 3, NUll),
    (1, 4, 4),
    (1, 5, 5),
    (1, 6, 6),
    (1, 7, 7),
    (1 ,8 ,8),
    (1 ,9 ,9),
    (1 ,10 ,10)
GO
