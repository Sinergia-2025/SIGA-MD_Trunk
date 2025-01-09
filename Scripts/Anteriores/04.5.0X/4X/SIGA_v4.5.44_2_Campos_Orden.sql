
-- Corrige Orden en tabla Campos segun el Codigo

UPDATE Campos SET Orden = 1 WHERE NombreCampo = 'CodigoProducto';
UPDATE Campos SET Orden = 2 WHERE NombreCampo = 'NombreProducto';
UPDATE Campos SET Orden = 3 WHERE NombreCampo = 'NombreProducto2';
UPDATE Campos SET Orden = 4 WHERE NombreCampo = 'NombreMarca';
UPDATE Campos SET Orden = 5 WHERE NombreCampo = 'NombreRubro';
UPDATE Campos SET Orden = 6 WHERE NombreCampo = 'IVA';
UPDATE Campos SET Orden = 7 WHERE NombreCampo = 'PrecioCompra';
UPDATE Campos SET Orden = 8 WHERE NombreCampo = 'PrecioCosto';
UPDATE Campos SET Orden = 9 WHERE NombreCampo = 'PrecioVenta';
UPDATE Campos SET Orden = 10 WHERE NombreCampo = 'Moneda';
UPDATE Campos SET Orden = 11 WHERE NombreCampo = 'CodigoDeBarras';