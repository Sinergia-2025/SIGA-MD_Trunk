
/* ------- REORGANIZO EL MENU ARCHIVOS ---------- */ 
   
UPDATE Funciones SET
   Nombre = 'Proveedores - Consulta' 
   ,Descripcion = 'Proveedores - Consulta' 
 WHERE ID = 'ProveedoresConsultas'
GO

UPDATE Funciones SET
   Nombre = 'Transportistas - Consulta' 
   ,Descripcion = 'Transportistas - Consulta' 
 WHERE ID = 'TransportistasConsultas'
GO

UPDATE Funciones SET
   Nombre = 'Productos - Baja Masiva' 
   ,Descripcion = 'Productos - Baja Masiva' 
 WHERE ID = 'ProductosBajaMasiva'
GO

UPDATE Funciones SET
   Nombre = 'Tipos de Documento' 
   ,Descripcion = 'Tipos de Documento' 
 WHERE ID = 'TiposDoc'
GO

UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'Categorias' THEN 10 
            WHEN 'Clientes' THEN 20 
            WHEN 'ClientesSubRubrosDescuentos' THEN 30 
            WHEN 'Empleados' THEN 40 
            WHEN 'FormasPago' THEN 50 
            WHEN 'ImpuestosABM' THEN 60 
            WHEN 'Localidades' THEN 70 
            WHEN 'Marcas' THEN 80 
            WHEN 'Modelos' THEN 90 
            WHEN 'Productos' THEN 100 
            WHEN 'ProductosBajaMasiva' THEN 110 
            WHEN 'ProductosSucursales' THEN 120 
            WHEN 'Proveedores' THEN 130 
            WHEN 'ProveedoresConsultas' THEN 140 
            WHEN 'Rubros' THEN 150 
            WHEN 'SubRubros' THEN 160 
            WHEN 'Sucursales' THEN 170 
            WHEN 'TiposImpuestosABM' THEN 180 
            WHEN 'TiposDoc' THEN 190 
            WHEN 'Transportistas' THEN 200 
            WHEN 'TransportistasConsultas' THEN 210 
            WHEN 'UnidadesDeMedidas' THEN 220 
            WHEN 'ZonasGeograficas' THEN 230 
            ELSE 0 END)
  WHERE IdPadre='Archivos'
GO
   

