
DECLARE @max int
SET @max = (SELECT MAX(IdBuscador) FROM Buscadores) + 1

INSERT INTO Buscadores
    (IdBuscador,Titulo,AnchoAyuda)
    (SELECT @max, 'Prospectos', AnchoAyuda
       FROM Buscadores
      WHERE IdBuscador = 1)


INSERT INTO BuscadoresCampos
           (IdBuscador,IdBuscadorNombreCampo,Orden,Titulo
           ,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
           (SELECT @max,REPLACE(IdBuscadorNombreCampo, 'Cliente', 'Prospecto'),Orden,Titulo
                  ,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila
              FROM BuscadoresCampos
             WHERE IdBuscador = 1)
