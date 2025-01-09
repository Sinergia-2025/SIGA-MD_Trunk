
DELETE SueldosCierreLiquidacion
GO

DELETE SueldosCierreLiqDatos
GO

DELETE SueldosCierrePuntero
GO

DELETE SueldosLiquidacionActual
GO

--DELETE SueldosPersonalCodigos
--GO

--DELETE SueldosPersonalHijos
--GO

--DELETE SueldosPersonal
--GO

--DELETE SueldosConceptos
--GO


UPDATE SueldosTiposRecibos
  SET NumeroLiquidacion = 1
    ,PeriodoLiquidacion = 201401
  --SET PeriodoLiquidacion = CAST(LEFT(CONVERT(VARCHAR(8), GETDATE(), 112),6) AS int)
GO

UPDATE Parametros
   SET ValorParametro = GETDATE()
 WHERE IdParametro = 'SUELDOS_FECHA_DE_PAGO'
GO
