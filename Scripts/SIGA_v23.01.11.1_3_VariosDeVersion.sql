
IF dbo.BaseConCuit('30653129889') = 1 --SOLO CLIENTE Cachero Analia
BEGIN
--Corrige puntero de Octubre y Noviembre
delete from SueldosCierrePuntero where LiqAno = 2022 and LiqMes = 10 and NroPerson = 0
delete from SueldosCierrePuntero where LiqAno = 2022 and LiqMes = 10 and NroPerson = 73
delete from SueldosCierrePuntero where LiqAno = 2022 and LiqMes = 11 and NroPerson = 74

--Corrige numero de liquidacion de Octubre era 73 como setiembre
UPDATE SueldosCierreLiqDatos SET NroLiquidacion = 74 where PeriodoLiquidacion = '202210' and IdTipoRecibo = 1
UPDATE SueldosCierreLiquidacion SET NroLiquidacion = 74 where PeriodoLiquidacion = '202210' and IdTipoRecibo = 1

--Corrige Tipos Recibos con datos de la proxima liquidacion
UPDATE SueldosTiposRecibos SET NumeroLiquidacion = 75 where IdTipoRecibo = 1
UPDATE SueldosTiposRecibos SET PeriodoLiquidacion = 202211 where IdTipoRecibo = 1

END;