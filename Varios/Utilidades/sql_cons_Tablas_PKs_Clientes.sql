SELECT tc.Table_Name, tc.Constraint_Name 
  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
 WHERE tc.Table_Name IN 
  ('AuditoriaClientes', 'CartasAClientes', 'Clientes', 'ClientesActividades', 'ClientesDescuentosMarcas',
   'ClientesDescuentosSubRubros', 'ClientesMarcasListasDePrecios', 'ClientesSucursales', 
   'CuentasCorrientesRetenciones', 'Fichas', 'FichasPagos', 'FichasPagosAjustes',
   'FichasPagosDetalle', 'FichasProductos', 'Retenciones')
  AND tc.Constraint_Type = 'PRIMARY KEY'
 ORDER BY tc.Table_Name 
 