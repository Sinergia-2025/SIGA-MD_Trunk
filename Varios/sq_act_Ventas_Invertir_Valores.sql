
SELECT * FROM CuentasCorrientes
 WHERE IdTipoComprobante = 'eNCRED'
  AND ImporteTotal>0
;

UPDATE CuentasCorrientes
   SET ImporteTotal = ImporteTotal * (-1)
      ,Saldo = Saldo * (-1)
 WHERE IdTipoComprobante = 'eNCRED'
  AND ImporteTotal>0
;


SELECT * FROM CuentasCorrientesPagos
 WHERE IdTipoComprobante = 'eNCRED'
  AND ImporteCuota>0
;
  

UPDATE CuentasCorrientesPagos
   SET ImporteCuota = ImporteCuota * (-1)
      ,SaldoCuota = SaldoCuota * (-1)
 WHERE IdTipoComprobante = 'eNCRED'
  AND ImporteCuota>0
;
 

------


select * --SubTotal, ImporteTotal, ImporteBruto, TotalImpuestos, Utilidad, ComisionVendedor
from Ventas
where   Fecha between '20170331 17:00:00' and '20170331 23:59:59'
and IdTipoComprobante  = 'eNCRED'
--para comparar
--and NumeroComprobante in (94, 95, 96, 97) 
order by Letra asc 

--update Ventas
--set SubTotal = (SubTotal * -1) , ImporteTotal = (ImporteTotal  * -1), ImporteBruto = (ImporteBruto  * -1), TotalImpuestos = (TotalImpuestos  * -1), Utilidad = (Utilidad  * -1), ComisionVendedor = (ComisionVendedor  * -1)
--where   Fecha between '20170331 17:00:00' and '20170331 23:59:59'
--and IdTipoComprobante  = 'eNCRED'




***************************************
-- comparar entre comprobantes
select *
from Ventas
where   Fecha between '20170331 17:00:00' and '20170331 23:59:59'
and IdTipoComprobante  = 'eNCRED'
--and NumeroComprobante in (94, 95, 96, 97)
order by Letra asc 


