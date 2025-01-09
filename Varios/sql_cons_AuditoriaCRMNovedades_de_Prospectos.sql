
SELECT P.CodigoProspecto, P.NombreDeFantasia,  ACRM.* FROM AuditoriaCRMNovedades ACRM
 INNER JOIN Prospectos P ON P.IdProspecto = ACRM.IdProspecto
 WHERE P.CodigoProspecto IN (2132, 2125, 2105, 2002, 2111, 2003, 669, 2078, 2075, 2087, 2001, 2124, 2004, 2070, 1953)
 ORDER BY P.NombreDeFantasia, ACRM.FechaAuditoria