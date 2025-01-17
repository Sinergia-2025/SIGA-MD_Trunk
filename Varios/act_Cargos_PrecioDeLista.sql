
DECLARE @PorcAumentoLista decimal(10,4) = 6

-- Aplico el Aumento al precio de Lista
UPDATE CargosClientes
   SET PrecioLista = ROUND( PrecioLista * (1 + @PorcAumentoLista / 100) ,2)
;

-- Recalculo el Porcentaje de Descuento.
UPDATE CargosClientes
   SET DescuentoRecargoPorc1 = -(1-ROUND(Monto / PrecioLista, 4))*100
;

SELECT IdCliente
      ,IdCargo
      ,PrecioLista
      ,DescuentoRecargoPorc1
      ,Monto
      ,Cantidad
  FROM CargosClientes
;
