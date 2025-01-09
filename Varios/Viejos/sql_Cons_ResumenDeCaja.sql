SELECT CdC.CuentaContable, CdC.NombreCuentaCaja, CdC.IdCuentaCaja, Ingresos.Ingresos, Egresos.Egresos
 FROM
(
SELECT  CD.IdCuentaCaja, SUM(CD.ImportePesos+CD.ImporteDolares+CD.ImporteEuros+CD.ImporteCheques+CD.ImporteTarjetas) as Ingresos
FROM  Cajas C, CajasDetalle CD
 WHERE C.IdSucursal=CD.IdSucursal
   AND C.NumeroPlanilla=CD.NumeroPlanilla
   AND C.idsucursal=1
   AND C.FechaPlanilla BETWEEN '20071201' AND '20091201'
   AND CD.IdTipoMovimiento='I'
 GROUP BY CD.IdCuentaCaja
) Ingresos,
(
SELECT  CD.IdCuentaCaja, SUM(CD.ImportePesos+CD.ImporteDolares+CD.ImporteEuros+CD.ImporteCheques+CD.ImporteTarjetas) as Egresos
FROM  Cajas C, CajasDetalle CD
 WHERE C.IdSucursal=CD.IdSucursal
   AND C.NumeroPlanilla=CD.NumeroPlanilla
   AND C.idsucursal=1
   AND C.FechaPlanilla BETWEEN '20071201' AND '20091201'
   AND CD.IdTipoMovimiento='E'
 GROUP BY CD.IdCuentaCaja
) Egresos,
(
select IdCuentaCaja, NombreCuentaCaja, CuentaContable from CuentasDeCajas
) CdC
 WHERE CdC.IdCuentaCaja=Ingresos.IdCuentaCaja
   AND CdC.IdCuentaCaja=Egresos.IdCuentaCaja
