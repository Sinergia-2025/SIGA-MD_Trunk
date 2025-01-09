DELETE ContabilidadCuentasRubros WHERE Tipo = 'VENTAS';
INSERT INTO ContabilidadCuentasRubros
      (idRubro,IdCuenta,IdPlanCuenta,Tipo,Debe,Haber,GrupoAsiento,Campo)
SELECT IdRubro, 10501001, IdPlanCuenta, 'VENTAS', NULL, NULL, NULL, 'Imp. Bruto'
  FROM Rubros
 CROSS JOIN ContabilidadPlanes
;
DELETE ContabilidadCuentasRubros WHERE Tipo = 'COMPRAS';
INSERT INTO ContabilidadCuentasRubros
      (idRubro,IdCuenta,IdPlanCuenta,Tipo,Debe,Haber,GrupoAsiento,Campo)
SELECT IdRubro, 20101001, IdPlanCuenta, 'COMPRAS', NULL, NULL, NULL, 'Imp. Bruto'
  FROM Rubros
 CROSS JOIN ContabilidadPlanes
;
