
SELECT TOP (5) * FROM AuditoriaMonedas
  WHERE IdMoneda = 2 
      AND YEAR(FechaAuditoria) = 2024
	  AND MONTH(FechaAuditoria) = 1
 ORDER BY FechaAuditoria DESC
