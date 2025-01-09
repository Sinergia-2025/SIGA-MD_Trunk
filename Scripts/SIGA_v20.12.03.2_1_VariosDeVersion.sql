UPDATE TurnosCalendarios
   SET IdTurnoUnico = NEWID()
 WHERE IdTurnoUnico = ''