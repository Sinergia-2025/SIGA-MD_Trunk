
DECLARE @max int
SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)

INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, 'Plantillas', 800)
;
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
    VALUES
       (@max, 'IdPlantilla',1, 'Plantilla', 32, 80,''),
       (@max, 'NombrePlantilla',2, 'Nombre Plantilla', 16, 250,''),
       (@max, 'NombreProveedor',3, 'Proveedor', 16, 300,''),
       (@max, 'FilaInicial',4, 'Fila Inicial', 32, 100,'')
GO
