
-- Bases que NO usan Sueldos. Falta una FK !!!
DELETE SueldosCierreLiqDatos 
  WHERE NOT EXISTS 
       ( SELECT SueldoBasico FROM SueldosPersonal SP
           WHERE SueldosCierreLiqDatos.IdLegajo = SP.IdLegajo 
       )
GO

---
ALTER TABLE SueldosCierreLiqDatos ADD SueldoBasico decimal(8,2) null
GO

UPDATE SueldosCierreLiqDatos
 SET SueldoBasico =   
       ( SELECT SueldoBasico FROM SueldosPersonal SP
           WHERE SueldosCierreLiqDatos.IdLegajo = SP.IdLegajo 
       )
GO

ALTER TABLE SueldosCierreLiqDatos ALTER COLUMN SueldoBasico decimal(8,2) not null
GO


--ALTER TABLE SueldosLiquidacionActual ADD SueldoBasico decimal(8,2) null
--GO

--UPDATE SueldosLiquidacionActual
-- SET SueldoBasico =   
--       ( SELECT SueldoBasico FROM SueldosPersonal SP
--           WHERE SueldosLiquidacionActual.IdLegajo = SP.IdLegajo 
--       )
--GO

--ALTER TABLE SueldosLiquidacionActual ALTER COLUMN SueldoBasico decimal(8,2) not null
--GO
