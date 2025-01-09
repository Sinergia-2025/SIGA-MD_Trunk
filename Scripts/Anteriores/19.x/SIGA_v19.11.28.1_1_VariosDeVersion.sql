ALTER TABLE [dbo].[ContabilidadAsientosCuentas] DROP CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos]
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp] DROP CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadAsientos]
GO

UPDATE CAC
   SET IdEjercicio = CE.IdEjercicio
  FROM ContabilidadAsientos CA
 INNER JOIN ContabilidadAsientosCuentas CAC ON CAC.IdEjercicio = CA.IdEjercicio AND CAC.IdPlanCuenta = CA.IdPlanCuenta AND CAC.IdAsiento = CA.IdAsiento
  LEFT JOIN ContabilidadEjercicios CE ON CE.FechaDesde <= CA.FechaAsiento AND CE.FechaHasta >= CA.FechaAsiento
 WHERE CA.IdEjercicio <> CE.IdEjercicio

UPDATE CAT
   SET IdEjercicioDefinitivo = CE.IdEjercicio
  FROM ContabilidadAsientos CA
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicioDefinitivo = CA.IdEjercicio AND CAT.IdPlanCuentaDefinitivo = CA.IdPlanCuenta AND CAT.IdAsientoDefinitivo = CA.IdAsiento
  LEFT JOIN ContabilidadEjercicios CE ON CE.FechaDesde <= CA.FechaAsiento AND CE.FechaHasta >= CA.FechaAsiento
 WHERE CA.IdEjercicio <> CE.IdEjercicio

UPDATE CA
   SET IdEjercicio = CE.IdEjercicio
  FROM ContabilidadAsientos CA
  LEFT JOIN ContabilidadEjercicios CE ON CE.FechaDesde <= CA.FechaAsiento AND CE.FechaHasta >= CA.FechaAsiento
 WHERE CA.IdEjercicio <> CE.IdEjercicio


ALTER TABLE [dbo].[ContabilidadAsientosTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadAsientos] FOREIGN KEY([IdEjercicioDefinitivo], [IdPlanCuentaDefinitivo], [IdAsientoDefinitivo])
REFERENCES [dbo].[ContabilidadAsientos] ([IdEjercicio], [IdPlanCuenta], [IdAsiento])
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadAsientos]
GO

ALTER TABLE [dbo].[ContabilidadAsientosCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos] FOREIGN KEY([IdEjercicio], [IdPlanCuenta], [IdAsiento])
REFERENCES [dbo].[ContabilidadAsientos] ([IdEjercicio], [IdPlanCuenta], [IdAsiento])
GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos]
GO

