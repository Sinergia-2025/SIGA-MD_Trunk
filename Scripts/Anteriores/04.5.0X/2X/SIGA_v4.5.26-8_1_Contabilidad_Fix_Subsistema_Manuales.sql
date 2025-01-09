
UPDATE ContabilidadAsientos
   SET SubsiAsiento = 'MANUALES'
 WHERE SubsiAsiento IS NULL OR SubsiAsiento = ''
GO
