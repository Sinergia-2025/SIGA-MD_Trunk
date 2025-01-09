
SELECT ImporteTotalNeto, ImporteTotal+IVA, MontoAplicado,  MontoSaldo, ProporcionalImp
--SELECT *
 FROM ComprasProductos
WHERE MontoSaldo <> 0
  and ABS(MontoSaldo)<0.01 
  
UPDATE ComprasProductos
   SET MontoAplicado = ImporteTotal + IVA
      ,MontoSaldo = 0
      --,ProporcionalImp = 0
WHERE MontoSaldo <> 0
  and ABS(MontoSaldo)<0.01 
  