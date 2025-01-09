
ALTER TABLE SueldosCierreLiqDatos ADD TotalHaberesParaAguinaldo Decimal(12,2) null
GO

UPDATE SueldosCierreLiqDatos
  SET TotalHaberesParaAguinaldo = 0
GO

ALTER TABLE SueldosCierreLiqDatos ALTER COLUMN TotalHaberesParaAguinaldo Decimal(12,2) not null
GO

/* ----------- */
UPDATE SueldosCierreLiqDatos
   SET TotalHaberesParaAguinaldo = MS.Importe
  FROM (SELECT SCL.IdLegajo, SCL.IdTipoRecibo, SCL.PeriodoLiquidacion, SCL.NroLiquidacion
              ,SUM(Importe) AS Importe
          FROM SueldosCierreLiquidacion SCL
         INNER JOIN SueldosConceptos SC ON SC.IdTipoConcepto = SCL.IdTipoConcepto 
                                       AND SC.IdConcepto = SCL.IdConcepto
         INNER JOIN SueldosPersonal SP ON SP.IdLegajo = SCL.IdLegajo
         WHERE SC.EsContempladoAguinaldo = 'True'
         GROUP BY SCL.IdLegajo, SCL.IdTipoRecibo, SCL.PeriodoLiquidacion, SCL.NroLiquidacion) MS
 INNER JOIN SueldosCierreLiqDatos AS SCLD ON SCLD.IdLegajo = MS.IdLegajo
                                         AND SCLD.IdTipoRecibo = MS.IdTipoRecibo
                                         AND SCLD.PeriodoLiquidacion = MS.PeriodoLiquidacion
                                         AND SCLD.NroLiquidacion = MS.NroLiquidacion
GO
