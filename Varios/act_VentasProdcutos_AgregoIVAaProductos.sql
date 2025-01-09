
-- Sumo el IVA
UPDATE VentasProductos
   SET precio = ROUND(precio * (1+AlicuotaImpuesto/100), 4)
     , importetotal = ROUND(importetotal * (1+AlicuotaImpuesto/100), 4)
     , precioneto = ROUND(precioneto * (1+AlicuotaImpuesto/100), 4)
     , importetotalneto = ROUND(importetotalneto * (1+AlicuotaImpuesto/100), 4)
     , precioconimpuestos = ROUND(precioconimpuestos * (1+AlicuotaImpuesto/100), 4)
     , precionetoconimpuestos = ROUND(precionetoconimpuestos * (1+AlicuotaImpuesto/100), 4)
     , importetotalconimpuestos = ROUND(importetotalconimpuestos * (1+AlicuotaImpuesto/100), 4)
     , importetotalnetoconimpuestos = ROUND(importetotalnetoconimpuestos * (1+AlicuotaImpuesto/100), 4)
 FROM VentasProductos
 GO
 
 -- Recalculo la Utilidad
 
 UPDATE VentasProductos
    SET Utilidad =  ROUND(ImportetotalNeto - (Costo * Cantidad), 4)
GO

 
 Costo - 10.6777 * 15