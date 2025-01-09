
/* ---- Stock Reservado para Futuros Cambio en Produccion ---- */

ALTER TABLE ProductosSucursales ADD StockReservado Decimal(14,4) NULL
GO

UPDATE ProductosSucursales SET StockReservado = 0
GO

-- no se afecta not null ??

