
DECLARE @max int
DECLARE @titulo varchar(max)

SET @titulo = 'ContabilidadCentrosCostos'
IF NOT EXISTS (SELECT 1 FROM Buscadores VT WHERE Titulo = @titulo)
BEGIN
    SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)
    INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, @titulo, 390);
    INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
        VALUES
           (@max, 'IdCentroCosto',1, 'Código', 64, 80,''),
           (@max, 'NombreCentroCosto',2, 'Nombre Centro de Costo', 16, 250,'');
END
