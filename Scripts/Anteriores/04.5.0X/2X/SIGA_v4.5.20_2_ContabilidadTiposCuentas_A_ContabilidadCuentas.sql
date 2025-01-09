
--no uso mas la tabal ContabilidadTiposCuentas e inserto los registros en la tabla de cuentas
INSERT INTO ContabilidadCuentas
   (IdCuenta, NombreCuenta, Nivel, IdCentroCosto ,EsImputable, Activa, IdCuentaPadre)
SELECT IdTipoCuenta, NombreTipoCuenta, 1, 1, 'False', 'True', NULL FROM ContabilidadTiposCuentas
GO

DROP TABLE ContabilidadTiposCuentas
GO
