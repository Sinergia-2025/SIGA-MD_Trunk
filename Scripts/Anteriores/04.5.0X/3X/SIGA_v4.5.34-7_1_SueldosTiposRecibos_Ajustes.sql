
--- Paso Todos a No Eventual
UPDATE SueldosTiposRecibos
   SET LiquidacionEventual = 'False'
;

-- Cambiar el tipo de Liquidación a Eventual de aquellos No Estandar.
UPDATE SueldosTiposRecibos
   SET LiquidacionEventual = 'True'
 WHERE NombreTipoRecibo NOT IN ('Sueldo', 'Mensual', 'Quincenal')
;

-- Corrijo Periodos incorrectos
UPDATE SueldosTiposRecibos
   SET PeriodoLiquidacion = 201001
      ,FechaPago = '2010-01-01'
 WHERE PeriodoLiquidacion < 201000
;

-- Para Controlar Visualmente
SELECT * FROM SueldosTiposRecibos
;
