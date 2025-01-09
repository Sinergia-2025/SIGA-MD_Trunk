DECLARE @IdSituacionCheque INT = (SELECT TOP 1 IdSituacionCheque FROM SituacionCheques WHERE PorDefecto = 1)

UPDATE Cheques
   SET IdSituacionCheque = @IdSituacionCheque
 WHERE IdSituacionCheque IS NULL
