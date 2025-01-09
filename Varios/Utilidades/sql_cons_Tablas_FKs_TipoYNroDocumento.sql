SELECT * FROM [INFORMATION_SCHEMA].[KEY_COLUMN_USAGE]
   where (column_name like 'tipoDoc%'
    and column_name not like '%Proveedor%'
    and column_name not like '%Vendedor%'    
    and column_name not like '%Empleado%'    
    and column_name not like '%Cobrador%'    
    and column_name not like '%Comprador%')
    or column_name like 'IdCliente%'
    
order by Constraint_Name


