DELETE SueldosCierreLiquidacion
 WHERE PeriodoLiquidacion = 201610
   AND NroLiquidacion = 3

DELETE SueldosCierreLiqDatos
 WHERE PeriodoLiquidacion = 201610
   AND NroLiquidacion = 3

UPDATE SueldosPersonal
   SET MejorSueldo = pp.Haberes
FROM (
SELECT pp.IdLegajo,pp.NombrePersonal,MAX(pp.Haberes) Haberes
  FROM (
SELECT l.PeriodoLiquidacion,p.IdLegajo,p.NombrePersonal,
       SUM(CASE WHEN t.Tipo = 'H' THEN l.Importe ELSE 0 END) as Haberes
  FROM SueldosPersonal p 
 INNER JOIN SueldosCierreLiquidacion l ON   p.IdLegajo = l.IdLegajo
 INNER JOIN SueldosConceptos c ON l.IdConcepto = c.IdConcepto
 INNER JOIN SueldosTiposConceptos t ON t.IdTipoConcepto = c.IdTipoConcepto
 WHERE l.IdTipoRecibo = 1
 GROUP BY l.PeriodoLiquidacion, p.IdLegajo, p.NombrePersonal
) pp
GROUP BY pp.IdLegajo,pp.NombrePersonal
) pp
 INNER JOIN SueldosPersonal SP ON SP.IdLegajo = PP.IdLegajo
