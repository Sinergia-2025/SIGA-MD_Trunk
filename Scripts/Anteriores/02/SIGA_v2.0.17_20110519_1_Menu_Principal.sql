
UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'Ventas' THEN 10 
            WHEN 'Compras' THEN 20 
            WHEN 'Stock' THEN 30 
            WHEN 'Precios' THEN 40 
            WHEN 'AFIP' THEN 50 
            WHEN 'CuentasCorrientes' THEN 60 
            WHEN 'CuentasCorrientesProveedores' THEN 70 
            WHEN 'Sueldos' THEN 80 
            WHEN 'Caja' THEN 90 
            WHEN 'Bancos' THEN 100 
            WHEN 'Estadisticas' THEN 110 
            WHEN 'Archivos' THEN 120 
            WHEN 'Procesos' THEN 130 
            WHEN 'Configuraciones' THEN 140 
            WHEN 'Seguridad' THEN 150 
            ELSE 0 END)
  WHERE IdPadre IS NULL
GO
   

