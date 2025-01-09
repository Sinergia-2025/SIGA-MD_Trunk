BEGIN TRANSACTION
GO
UPDATE PedidosProductos
   SET PrecioConImpuestos = ROUND((Precio * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,PrecioNetoConImpuestos = ROUND((PrecioNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,ImporteTotalConImpuestos = ROUND((ImporteTotal * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno), 2)
      ,ImporteTotalNetoConImpuestos = ROUND((ImporteTotalNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno), 2)
;
UPDATE VentasProductos
   SET PrecioConImpuestos = ROUND((Precio * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,PrecioNetoConImpuestos = ROUND((PrecioNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,ImporteTotalConImpuestos = ROUND((ImporteTotal * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno), 2)
      ,ImporteTotalNetoConImpuestos = ROUND((ImporteTotalNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno), 2)
;
COMMIT
