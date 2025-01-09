
-- Deberia encontrar solo las hecha con el modulo de cargos.
UPDATE Ventas
   SET CotizacionDolar = 1
 WHERE CotizacionDolar IS NULL OR CotizacionDolar = 0
GO
