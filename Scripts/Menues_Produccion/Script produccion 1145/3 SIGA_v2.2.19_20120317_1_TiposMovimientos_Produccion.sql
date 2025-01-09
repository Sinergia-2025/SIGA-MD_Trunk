
--En caso de no usar el Modulo de Produccion activa el Movimiento para que pueda hacerlo manualmente. 

IF EXISTS(SELECT * FROM ParametroS 
           WHERE IdParametro = 'MODULOPRODUCCION'
             AND ValorParametro = 'False')

  UPDATE TiposMovimientos SET 
         MuestraCombo = 'True'
   WHERE IdTipoMovimiento = 'PRODUCCION'

GO

-- . 

UPDATE TiposMovimientos 
   SET CargaPrecio = 'PrecioCosto'
 WHERE IdTipoMovimiento IN ('PRODUCCION', 'COMPROD')
GO


