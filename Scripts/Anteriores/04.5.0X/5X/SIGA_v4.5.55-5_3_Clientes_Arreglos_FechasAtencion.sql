
-- Solo tiene Hora pero tiene los Segundos, le quito los segundos.
UPDATE Clientes
   SET HoraInicio = LEFT(HoraInicio,5)
 WHERE LEN(HoraInicio) = 8
;
UPDATE Clientes
   SET HoraFin = LEFT(HoraFin,5)
 WHERE LEN(HoraFin) = 8
;
UPDATE Clientes
   SET HoraInicio2 = LEFT(HoraInicio2,5)
 WHERE LEN(HoraInicio2) = 8
;
UPDATE Clientes
   SET HoraFin2 = LEFT(HoraFin2,5)
 WHERE LEN(HoraFin2) = 8
;

UPDATE Clientes
   SET HoraSabInicio = LEFT(HoraSabInicio,5)
 WHERE LEN(HoraSabInicio) = 8
;
UPDATE Clientes
   SET HoraSabFin = LEFT(HoraSabFin,5)
 WHERE LEN(HoraSabFin) = 8
;
UPDATE Clientes
   SET HoraSabInicio2 = LEFT(HoraSabInicio2,5)
 WHERE LEN(HoraSabInicio2) = 8
;
UPDATE Clientes
   SET HoraSabFin2 = LEFT(HoraSabFin2,5)
 WHERE LEN(HoraSabFin2) = 8
;


UPDATE Clientes
   SET HoraDomInicio = LEFT(HoraDomInicio,5)
 WHERE LEN(HoraDomInicio) = 8
;
UPDATE Clientes
   SET HoraDomFin = LEFT(HoraDomFin,5)
 WHERE LEN(HoraDomFin) = 8
;
UPDATE Clientes
   SET HoraDomInicio2 = LEFT(HoraDomInicio2,5)
 WHERE LEN(HoraDomInicio2) = 8
;
UPDATE Clientes
   SET HoraDomFin2 = LEFT(HoraDomFin2,5)
 WHERE LEN(HoraDomFin2) = 8
;


-- Tiene Fecha Hora completa (dd/MM/yyyy HH:mm:ss), solo tomo la hora/min
UPDATE Clientes
   SET HoraInicio = RIGHT(HoraInicio,5)
 WHERE LEN(HoraInicio) = 16
;
UPDATE Clientes
   SET HoraFin = RIGHT(HoraFin,5)
 WHERE LEN(HoraFin) = 16
;
UPDATE Clientes
   SET HoraInicio2 = RIGHT(HoraInicio2,5)
 WHERE LEN(HoraInicio2) = 16
;
UPDATE Clientes
   SET HoraFin2 = RIGHT(HoraFin2,5)
 WHERE LEN(HoraFin2) = 16
;


UPDATE Clientes
   SET HoraSabInicio = RIGHT(HoraSabInicio,5)
 WHERE LEN(HoraSabInicio) = 16
;
UPDATE Clientes
   SET HoraSabFin = RIGHT(HoraSabFin,5)
 WHERE LEN(HoraSabFin) = 16
;
UPDATE Clientes
   SET HoraSabInicio2 = RIGHT(HoraSabInicio2,5)
 WHERE LEN(HoraSabInicio2) = 16
;
UPDATE Clientes
   SET HoraSabFin2 = RIGHT(HoraSabFin2,5)
 WHERE LEN(HoraSabFin2) = 16
;


UPDATE Clientes
   SET HoraDomInicio = RIGHT(HoraDomInicio,5)
 WHERE LEN(HoraDomInicio) = 16
;
UPDATE Clientes
   SET HoraDomFin = RIGHT(HoraDomFin,5)
 WHERE LEN(HoraDomFin) = 16
;
UPDATE Clientes
   SET HoraDomInicio2 = RIGHT(HoraDomInicio2,5)
 WHERE LEN(HoraDomInicio2) = 16
;
UPDATE Clientes
   SET HoraDomFin2 = RIGHT(HoraDomFin2,5)
 WHERE LEN(HoraDomFin2) = 16
;





-- Tiene Fecha Hora completa (dd/MM/yyyy HH:mm:ss), solo tomo la hora/min
UPDATE Clientes
   SET HoraInicio = LEFT(RIGHT(HoraInicio,8),5)
 WHERE LEN(HoraInicio) = 19
;
UPDATE Clientes
   SET HoraFin = LEFT(RIGHT(HoraFin,8),5)
 WHERE LEN(HoraFin) = 19
;
UPDATE Clientes
   SET HoraInicio2 = LEFT(RIGHT(HoraInicio2,8),5)
 WHERE LEN(HoraInicio2) = 19
;
UPDATE Clientes
   SET HoraFin2 = LEFT(RIGHT(HoraFin2,8),5)
 WHERE LEN(HoraFin2) = 19
;


UPDATE Clientes
   SET HoraSabInicio = LEFT(RIGHT(HoraSabInicio,8),5)
 WHERE LEN(HoraSabInicio) = 19
;
UPDATE Clientes
   SET HoraSabFin = LEFT(RIGHT(HoraSabFin,8),5)
 WHERE LEN(HoraSabFin) = 19
;
UPDATE Clientes
   SET HoraSabInicio2 = LEFT(RIGHT(HoraSabInicio2,8),5)
 WHERE LEN(HoraSabInicio2) = 19
;
UPDATE Clientes
   SET HoraSabFin2 = LEFT(RIGHT(HoraSabFin2,8),5)
 WHERE LEN(HoraSabFin2) = 19
;


UPDATE Clientes
   SET HoraDomInicio = LEFT(RIGHT(HoraDomInicio,8),5)
 WHERE LEN(HoraDomInicio) = 19
;
UPDATE Clientes
   SET HoraDomFin = LEFT(RIGHT(HoraDomFin,8),5)
 WHERE LEN(HoraDomFin) = 19
;
UPDATE Clientes
   SET HoraDomInicio2 = LEFT(RIGHT(HoraDomInicio2,8),5)
 WHERE LEN(HoraDomInicio2) = 19
;
UPDATE Clientes
   SET HoraDomFin2 = LEFT(RIGHT(HoraDomFin2,8),5)
 WHERE LEN(HoraDomFin2) = 19
;



-- Solo Tiene Fecha, lo dejo vacio.
UPDATE Clientes
   SET HoraInicio = ''
 WHERE LEN(HoraInicio) = 10 or LEN(HoraInicio) > 19
;
;
UPDATE Clientes
   SET HoraFin = ''
 WHERE LEN(HoraFin) = 10 or LEN(HoraFin) > 19
;
UPDATE Clientes
   SET HoraInicio2 = ''
 WHERE LEN(HoraInicio2) = 10 or LEN(HoraInicio2) > 19
;
UPDATE Clientes
   SET HoraFin2 = ''
 WHERE LEN(HoraFin2) = 10 or LEN(HoraFin2) > 19
;



UPDATE Clientes
   SET HoraSabInicio = ''
 WHERE LEN(HoraSabInicio) = 10 or LEN(HoraSabInicio) > 19
;
UPDATE Clientes
   SET HoraSabFin = ''
 WHERE LEN(HoraSabFin) = 10 or LEN(HoraSabFin) > 19
;
UPDATE Clientes
   SET HoraSabInicio2 = ''
 WHERE LEN(HoraSabInicio2) = 10 or LEN(HoraSabInicio2) > 19
;
UPDATE Clientes
   SET HoraSabFin2 = ''
 WHERE LEN(HoraSabFin2) = 10 or LEN(HoraSabFin2) > 19
;


UPDATE Clientes
   SET HoraDomInicio = ''
 WHERE LEN(HoraDomInicio) = 10 or LEN(HoraDomInicio) > 19
;
UPDATE Clientes
   SET HoraDomFin = ''
 WHERE LEN(HoraDomFin) = 10 or LEN(HoraDomFin) > 19
;
UPDATE Clientes
   SET HoraDomInicio2 = ''
 WHERE LEN(HoraDomInicio2) = 10 or LEN(HoraDomInicio2) > 19
;
UPDATE Clientes
   SET HoraDomFin2 = ''
 WHERE LEN(HoraDomFin2) = 10 or LEN(HoraDomFin2) > 19
;
