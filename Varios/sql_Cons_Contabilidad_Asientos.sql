SELECT CA.*
     , CAC.IdCuenta, CAC.IdRenglon, CAC.Debe, CAC.Haber, CAC.IdTipoReferencia, CAC.Referencia, CAC.IdCentroCosto
     , CC.NombreCuenta, CC.Nivel, CC.EsImputable, CC.Activa, CC.IdCuentaPadre, CC.TipoCuenta, CC.AjustaPorInflacion
  FROM ContabilidadAsientos CA
 INNER JOIN ContabilidadAsientosCuentas CAC ON CAC.IdPlanCuenta = CA.IdPlanCuenta AND CAC.IdAsiento = CA.IdAsiento
 INNER JOIN ContabilidadCuentas CC ON CC.IdCuenta = CAC.IdCuenta
 WHERE CONVERT(varchar(11), CA.FechaAsiento, 120) >= '2018-05-01' 
   AND CONVERT(varchar(11), CA.FechaAsiento, 120) <= '2019-05-31' 
	-- 4. Perdidas / 5. Ganancias
   AND LEFT(CAC.IdCuenta,1) IN ('4','5')
ORDER BY CA.FechaAsiento, CA.IdAsiento
GO
