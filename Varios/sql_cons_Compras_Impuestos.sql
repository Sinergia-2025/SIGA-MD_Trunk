
select * from Compras c
where c.IdSucursal>0
	  and c.CentroEmisor=1156
	  and c.NumeroComprobante=31747
go

select * from ComprasImpuestos c
where c.IdSucursal>0
	  and c.CentroEmisor=1156
	  and c.NumeroComprobante=31747
go
