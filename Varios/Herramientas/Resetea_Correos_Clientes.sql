SELECT CorreoElectronico, CorreoAdministrativo, *
  FROM Clientes
 WHERE NULLIF(CorreoElectronico, '') IS NOT NULL OR NULLIF(CorreoAdministrativo, '') IS NOT NULL
/*
UPDATE Clientes
   SET CorreoElectronico    = ISNULL(CASE WHEN NULLIF(CorreoElectronico, '')    IS NOT NULL THEN 'sebastian.carrozzo@sinergiasoftware.com'  ELSE NULL END, '')
     , CorreoAdministrativo = ISNULL(CASE WHEN NULLIF(CorreoAdministrativo, '') IS NOT NULL THEN 'sebastian.carrozzo@gmail.com'             ELSE NULL END, '')
 WHERE NULLIF(CorreoElectronico, '') IS NOT NULL OR NULLIF(CorreoAdministrativo, '') IS NOT NULL
*/
