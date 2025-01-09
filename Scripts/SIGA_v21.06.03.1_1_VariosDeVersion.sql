IF NOT EXISTS (SELECT * FROM SituacionCheques)
BEGIN
    INSERT INTO [dbo].[SituacionCheques]
               ([IdSituacionCheque], [NombreSituacionCheque], [PorDefecto])
        VALUES (1, 'NORMAL', 'True')
END

IF NOT EXISTS (SELECT * FROM SituacionCheques WHERE PorDefecto = 1)
BEGIN
    UPDATE SC
       SET PorDefecto = 'True'
      FROM SituacionCheques SC
     INNER JOIN (SELECT TOP 1 IdSituacionCheque FROM SituacionCheques) SC1 ON SC1.IdSituacionCheque = SC.IdSituacionCheque
END

DECLARE @IdSituacionCheque INT = (SELECT TOP 1 IdSituacionCheque FROM SituacionCheques WHERE PorDefecto = 1)

UPDATE Cheques
   SET IdSituacionCheque = @IdSituacionCheque
 WHERE IdSituacionCheque IS NULL

ALTER TABLE Cheques ALTER COLUMN IdSituacionCheque INT NOT NULL
