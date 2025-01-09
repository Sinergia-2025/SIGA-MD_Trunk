
UPDATE ComprasProductos
   SET ImporteTotal = ImporteTotal * (CASE WHEN ImporteTotal > 0 THEN -1 ELSE 1 END)
      ,ImporteTotalNeto = ImporteTotalNeto * (CASE WHEN ImporteTotalNeto > 0 THEN -1 ELSE 1 END)
      ,IVA = IVA * (CASE WHEN IVA > 0 THEN -1 ELSE 1 END)
  FROM ComprasProductos
 WHERE IdTipoComprobante = 'NCREDCOM'
   AND (ImporteTotal > 0 OR ImporteTotalNeto > 0 OR IVA > 0)
GO
