
--Vista para obtener el maximo valor de 2 tablas

IF EXISTS (SELECT * 
	   FROM   sysobjects 
	   WHERE  name = 'vw_ContabilidadAsientosIDMaximo')
	DROP VIEW vw_ContabilidadAsientosIDMaximo
GO

CREATE VIEW dbo.vw_ContabilidadAsientosIDMaximo AS 
SELECT IdPlanCuenta, max(maximo) as Maximo from 
 (SELECT IdPlanCuenta, isnull(MAX(IdAsiento),0) AS maximo 
 FROM ContabilidadAsientos
 GROUP BY IdPlanCuenta
 UNION
  SELECT IdPlanCuenta, isnull(MAX(IdAsiento),0) AS maximo 
 FROM ContabilidadAsientostmp
  GROUP BY IdPlanCuenta) tp
  GROUP BY IdPlanCuenta
GO
