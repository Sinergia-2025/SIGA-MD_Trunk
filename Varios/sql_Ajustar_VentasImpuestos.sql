
select IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, 
   Total-Neto-Importe
  from VentasImpuestos
where abs(Total-Neto-Importe)>0.01
order by IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
;


update VentasImpuestos
  set Total=Neto+Importe
where abs(Total-Neto-Importe)>0.01
;
