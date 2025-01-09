SELECT IdCuentaCaja, NombreCuentaCaja, 
       SUM(Enero) AS Enero, SUM(Febrero) AS Febrero, SUM(Marzo) AS Marzo, 
       SUM(Abril) AS Abril, SUM(Mayo) AS Mayo, SUM(Junio) AS Junio, SUM(Julio) AS Julio,
       SUM(Agosto) AS Agosto, SUM(Septiembre) AS Septiembre, SUM(Octubre) AS Octubre, 
       SUM(Noviembre) AS Noviembre, SUM(Diciembre) AS Diciembre,
       SUM(Enero+Febrero+Marzo+Abril+Mayo+Junio+Julio+Agosto+Septiembre+Octubre+Noviembre+Diciembre) AS Total

FROM 
( 
SELECT CdC.IdCuentaCaja, CdC.NombreCuentaCaja,
   CASE MONTH(C.FechaPlanilla)
      WHEN 1 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Enero, 
   CASE MONTH(C.FechaPlanilla)
      WHEN 2 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Febrero,
   CASE MONTH(C.FechaPlanilla)
      WHEN 3 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Marzo,
   CASE MONTH(C.FechaPlanilla)
      WHEN 4 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Abril,
   CASE MONTH(C.FechaPlanilla)
      WHEN 5 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Mayo,
   CASE MONTH(C.FechaPlanilla)
      WHEN 6 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Junio,
   CASE MONTH(C.FechaPlanilla)
      WHEN 7 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Julio,
   CASE MONTH(C.FechaPlanilla)
      WHEN 8 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Agosto,
   CASE MONTH(C.FechaPlanilla)
      WHEN 9 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Septiembre,
   CASE MONTH(C.FechaPlanilla)
      WHEN 10 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Octubre,
   CASE MONTH(C.FechaPlanilla)
      WHEN 11 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Noviembre,
   CASE MONTH(C.FechaPlanilla)
      WHEN 12 Then SUM(CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas) 
      ELSE 0 
   END Diciembre
 FROM Cajas C 
 INNER JOIN CajasDetalle CD ON C.IdSucursal = CD.IdSucursal AND C.NumeroPlanilla = CD.NumeroPlanilla
 INNER JOIN CuentasDeCajas CdC ON CD.IdCuentaCaja = CdC.IdCuentaCaja
 WHERE C.idsucursal=1 
   AND YEAR(C.FechaPlanilla) = 2009
 GROUP BY CdC.IdCuentaCaja, CdC.NombreCuentaCaja, C.FechaPlanilla
) Detalle 
GROUP BY IdCuentaCaja, NombreCuentaCaja