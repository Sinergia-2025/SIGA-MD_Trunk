
--Vista para obtener el maximo valor de 2 tablas

CREATE VIEW dbo.vw_ContabilidadAsientosIDMaximo AS 
SELECT max(maximo) as Maximo from 
 (SELECT isnull(MAX(IdAsiento),0) AS maximo 
 FROM ContabilidadAsientos
  WHERE IdPlanCuenta = 1
 UNION
  SELECT isnull(MAX(IdAsiento),0) AS maximo 
 FROM ContabilidadAsientostmp
  WHERE IdPlanCuenta = 1) tp
GO
