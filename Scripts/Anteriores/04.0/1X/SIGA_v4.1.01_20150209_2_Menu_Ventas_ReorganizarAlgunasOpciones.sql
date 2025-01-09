/* ------- REORGANIZO EL MENU Ventas ---------- */ 
   
UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'ModificarComprobantes' THEN 280 
			WHEN 'AnularComprobantes' THEN 290
            WHEN 'AnularComprobantesSinEmitir' THEN 300
            WHEN 'EliminarComprobantes' THEN 310
            WHEN 'EliminarVentas' THEN 320
            ELSE 0 END)
  WHERE Id IN ('EliminarComprobantes', 'EliminarVentas', 'ModificarComprobantes', 'AnularComprobantes', 'AnularComprobantesSinEmitir')
GO





