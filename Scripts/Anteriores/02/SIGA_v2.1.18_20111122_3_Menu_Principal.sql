
/* ------- REORGANIZO EL MENU PRINCIPAL ---------- */ 
   
UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'Ventas' THEN 10 
            WHEN 'FacturacionElectronica' THEN 20 
            WHEN 'Compras' THEN 30 
            WHEN 'Stock' THEN 40 
            WHEN 'Precios' THEN 50 
            WHEN 'Service' THEN 60 
            WHEN 'AFIP' THEN 70 
            WHEN 'CuentasCorrientes' THEN 80 
            WHEN 'CuentasCorrientesProveedores' THEN 90 
            WHEN 'Caja' THEN 100 
            WHEN 'Bancos' THEN 110 
            WHEN 'Estadisticas' THEN 120 
            WHEN 'Produccion' THEN 130 
            WHEN 'Sueldos' THEN 140 
            WHEN 'Contabilidad' THEN 150 
            WHEN 'Archivos' THEN 160 
            WHEN 'Procesos' THEN 170 
            WHEN 'Configuraciones' THEN 180 
            WHEN 'Seguridad' THEN 190 
            ELSE 0 END)
  WHERE IdPadre IS NULL
GO
