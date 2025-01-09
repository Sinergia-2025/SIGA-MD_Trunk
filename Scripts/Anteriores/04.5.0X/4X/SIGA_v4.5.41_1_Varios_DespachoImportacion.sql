
PRINT '1. Ajusto Descripcion del Despacho para dejarlo Ultimo y que no afecte a la mayoria.';

UPDATE TiposComprobantes
   SET Descripcion ='z. Despacho Importacion'
 WHERE IdTipoComprobante = 'DESPACHOIMP';


PRINT '2. Agrego DESPACHOIMP en TiposMovimientos.';

UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',DESPACHOIMP'
 WHERE IdTipoMovimiento = 'COMPRA';


PRINT '3. Permito NULL en ProductosLotes.FechaVencimiento';

ALTER TABLE ProductosLotes ALTER COLUMN FechaVencimiento datetime NULL;


PRINT '4. Permito NULL en VentasProductosLotes.FechaVencimiento';

ALTER TABLE VentasProductosLotes ALTER COLUMN FechaVencimiento datetime NULL;
