
UPDATE ComprasImpuestos
   SET Importe = Importe * -1
 WHERE IdTipoComprobante = 'NCREDCOM'
   AND Importe > 0
 GO
 