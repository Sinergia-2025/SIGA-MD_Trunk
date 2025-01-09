
SELECT kcu.Table_Name, Column_Name, Ordinal_Position FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
 INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ON tc.Constraint_Name = kcu.Constraint_Name
 WHERE tc.Table_Name IN 
  ('AuditoriaClientes', 'CartasAClientes', 'Clientes', 'ClientesActividades', 'ClientesDescuentosMarcas',
   'ClientesDescuentosSubRubros', 'ClientesMarcasListasDePrecios', 'ClientesSucursales', 
   'CuentasCorrientesRetenciones', 'Fichas', 'FichasPagos', 'FichasPagosAjustes',
   'FichasPagosDetalle', 'FichasProductos',  'Retenciones')
  AND tc.Constraint_Type = 'PRIMARY KEY'
 ORDER BY tc.Table_Name, Ordinal_Position
 