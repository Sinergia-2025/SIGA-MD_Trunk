
DECLARE @max int
DECLARE @titulo varchar(max)

SET @titulo = 'Aduanas'
IF NOT EXISTS (SELECT 1 FROM Buscadores VT WHERE Titulo = @titulo)
BEGIN
    SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)
    INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, @titulo, 390);
    INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
        VALUES
           (@max, 'IdAduana',1, 'Código', 64, 80,''),
           (@max, 'NombreAduana',2, 'Nombre Aduana', 16, 250,'');
END

SET @titulo = 'AduanasAgentesTransporte'
IF NOT EXISTS (SELECT 1 FROM Buscadores VT WHERE Titulo = @titulo)
BEGIN
    SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)
    INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, @titulo, 470);
    INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
        VALUES
           (@max, 'IdAgenteTransporte',1, 'Código', 64, 80,''),
           (@max, 'NombreAgenteTransporte',2, 'Nombre Aduana', 16, 250,''),
           (@max, 'Cuit',3, 'CUIT', 16, 80,'');
END

SET @titulo = 'AduanasDespachantes'
IF NOT EXISTS (SELECT 1 FROM Buscadores VT WHERE Titulo = @titulo)
BEGIN
    SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)
    INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, @titulo, 470);
    INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
        VALUES
           (@max, 'IdDespachante',1, 'Código', 64, 80,''),
           (@max, 'NombreDespachante',2, 'Nombre Despachante', 16, 250,''),
           (@max, 'Cuit',3, 'CUIT', 16, 80,'');
END

SET @titulo = 'AduanasDestinaciones'
IF NOT EXISTS (SELECT 1 FROM Buscadores VT WHERE Titulo = @titulo)
BEGIN
    SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)
    INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, @titulo, 800);
    INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
        VALUES
           (@max, 'IdDestinacion', 1, 'Código', 16, 75,''),
           (@max, 'NombreDestinacion', 2, 'Nombre Destinacion', 16, 550,''),
           (@max, 'RegimenArancelario', 3, 'Régimen Arancelario', 16, 120,'');
END
