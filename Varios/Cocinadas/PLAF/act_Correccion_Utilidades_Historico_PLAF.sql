--SELECT v.fecha
--		,vp.[IdSucursal]
--      ,vp.[IdTipoComprobante]
--      ,vp.[Letra]
--      ,vp.[CentroEmisor]
--      ,vp.[NumeroComprobante]
--      ,vp.[IdProducto]
--      ,[Cantidad]
--      ,[Precio]
--	  ,[PrecioLista]
--      ,[Costo]
--	  --,ps.PrecioCosto
--	  --,convert(decimal(16,4), (ps.PrecioCosto * v.CotizacionDolar)) as Costo_dolar
--	 -- ,	( Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from HistorialPrecios hpn
--		--where IdListaPrecios = -1
--		--	and hpn.FechaHora <= v.fecha
--		--	and hpn.idproducto = vp.idproducto 
--		--	order by fechahora desc) as COSTO_NEW
--		--,v.Usuario
--			/*Para calcaular costo de productos en dolares*/
--	--,(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--	--	where IdListaPrecios = -1
--	--		and hpn.FechaHora <= v.fecha
--	--		and hpn.idproducto = vp.idproducto 
--	--		and p.IdMoneda = 2
--	--		order by fechahora desc) as COSTO_USD


--		,CASE WHEN CFE.IvaDiscriminado = 1 THEN (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto 
--			and hpn.IdSucursal = vp.idsucursal
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto 
--			and hpn.IdSucursal = vp.idsucursal
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal
--				and p.IdMoneda = 1
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end) ELSE    CASE WHEN VP.OrigenPorcImpInt = 'BRUTO' THEN ((case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end) * (1 + (VP.AlicuotaImpuesto / 100))) * (1 + ((VP.PorcImpuestoInterno / 100) / (1 - (VP.PorcImpuestoInterno / 100)))) + P.ImporteImpuestoInterno ELSE ((case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end) * (1 + (VP.AlicuotaImpuesto / 100) + (VP.PorcImpuestoInterno / 100))) + P.ImporteImpuestoInterno END END AS Costo_2
		
		
--		,case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end as COSTO_NEW
--		, v.CotizacionDolar
--      ,[DescRecGeneral]
--      ,vp.[DescuentoRecargo]

--      ,vp.[Utilidad]
--		,CASE WHEN CFE.IvaDiscriminado = 1 THEN ((vp.PrecioNeto - (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end))* vp.Cantidad)ELSE    CASE WHEN VP.OrigenPorcImpInt = 'BRUTO' THEN (((vp.PrecioNeto - (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100))) * (1 + ((VP.PorcImpuestoInterno / 100) / (1 - (VP.PorcImpuestoInterno / 100)))) + P.ImporteImpuestoInterno ELSE (((vp.PrecioNeto - (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto ) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100) + (VP.PorcImpuestoInterno / 100))) + P.ImporteImpuestoInterno END END as UTILIDAD_NEW
      
--	  , ((vp.PrecioNeto -vp.Costo) *vp.Cantidad) as Utilidad_calc
--	  ,vp.[ImporteTotal]
--      ,[DescuentoRecargoProducto]
--      ,vp.[DescuentoRecargoPorc]
--      ,[DescRecGeneralProducto]
--      ,[PrecioNeto]
--      ,[ImporteTotalNeto]
--      ,[DescuentoRecargoPorc2]
--      ,vp.[NombreProducto]
--      ,vp.[IdTipoImpuesto]
--      --,[AlicuotaImpuesto]
--      --,[ImporteImpuesto]
--      ,[NombreListaPrecios]
--      ,vp.[ImporteImpuestoInterno]
--      ,vp.[IdMoneda]
--      ,[Garantia]
--      ,vp.[PorcImpuestoInterno]
--      ,[NombreCortoListaPrecios]
--      ,vp.[OrigenPorcImpInt]
--	  ,V.NroVersionAplicacion
--  FROM [VentasProductos] VP
--  INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal 
--						AND V.IdTipoComprobante = VP.IdTipoComprobante 
--						AND V.Letra = VP.Letra 
--						AND V.CentroEmisor = VP.CentroEmisor
--						AND V.NumeroComprobante = VP.NumeroComprobante 
--	INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
--	 INNER JOIN Productos P ON P.IdProducto = VP.IdProducto
--	 inner join ProductosSucursales ps on ps.IdProducto = vp.IdProducto
--									and ps.IdSucursal = vp.IdSucursal
--	INNER JOIN (SELECT P.IdEmpresa, S.Id IdSucursal, CFC.IdCategoriaFiscalCliente, CFC.IvaDiscriminado FROM Parametros P 
--		LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON P.ValorParametro = CFC.IdCategoriaFiscalEmpresa AND P.ValorParametro = CFC.IdCategoriaFiscalCliente
--		LEFT JOIN Sucursales S ON S.IdEmpresa = P.IdEmpresa
--		WHERE P.IdParametro = 'CATEGORIAFISCALEMPRESA' ) CFE ON CFE.IdSucursal = V.IdSucursal
--	where 1 = 1
--	AND convert(varchar(10),V.Fecha,120) >= '2021-06-01'
--    AND convert(varchar(10),V.Fecha,120) <= '2021-09-30'
--	--and v.NroVersionAplicacion LIKE '%21.06.12.1%'
--	AND TC.AfectaCaja = 1
--	and vp.Utilidad < 0
--	--and vp.Costo < vp.PrecioLista
--	--and vp.Costo > vp.Precio
----	and round(vp.PrecioLista,2) = round(vp.Precio,2)
----and case when ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc) is not null
----					then ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc)
----	when ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc) is null
----					then ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc)
----					else 
----					convert(decimal(16,2),ps.PrecioCosto)
----			end <> convert(decimal(16,2),vp.costo)
----	and case when ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc) is not null
----					then ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc)
----	when ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc) is null
----					then ( Select top 1 convert(decimal(16,2),hpn.PrecioCosto) from HistorialPrecios hpn
----					where IdListaPrecios = -1
----						and hpn.FechaHora <= v.fecha
----						and hpn.IdSucursal = vp.idsucursal
----						and hpn.idproducto = vp.idproducto
----						order by fechahora desc)
----					else 
----					ps.PrecioCosto
----			end < convert(decimal(16,2),vp.costo)
--	--and round (case when 
--	--	 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--	--	 where IdListaPrecios = -1
--	--		and hpn.FechaHora <= v.fecha
--	--		and hpn.idproducto = vp.idproducto
--	--		and hpn.IdSucursal = vp.idsucursal 
--	--		and p.IdMoneda = 2
--	--		order by fechahora desc) is not NULL
--	--	then
--	--	(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--	--	 where IdListaPrecios = -1
--	--		and hpn.FechaHora <= v.fecha
--	--		and hpn.idproducto = vp.idproducto
--	--		and hpn.IdSucursal = vp.idsucursal 
--	--		and p.IdMoneda = 2
--	--		order by fechahora desc)
--	--		when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--	--	 where IdListaPrecios = -1
--	--		and hpn.FechaHora <= v.fecha
--	--		and hpn.idproducto = vp.idproducto
--	--		and hpn.IdSucursal = vp.idsucursal 
--	--		and p.IdMoneda = 2
--	--		order by fechahora desc) is NULL
--	--		then
--	--		convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--	--		 when 
--	--			vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--	--			where IdListaPrecios = -1
--	--			and hpn.FechaHora <= v.fecha
--	--			and hpn.idproducto = vp.idproducto
--	--			and hpn.IdSucursal = vp.idsucursal 
--	--			order by fechahora desc) is not null
--	--			then
--	--			(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--	--			where IdListaPrecios = -1
--	--			and hpn.FechaHora <= v.fecha
--	--			and hpn.idproducto = vp.idproducto
--	--			and hpn.IdSucursal = vp.idsucursal 
--	--			order by fechahora desc)
--	--			else 
--	--			ps.preciocosto
--	--			end, 2) = round(vp.costo,2)
--	and CASE WHEN CFE.IvaDiscriminado = 1 THEN ((vp.PrecioNeto - (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end))* vp.Cantidad)ELSE    CASE WHEN VP.OrigenPorcImpInt = 'BRUTO' THEN (((vp.PrecioNeto - (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100))) * (1 + ((VP.PorcImpuestoInterno / 100) / (1 - (VP.PorcImpuestoInterno / 100)))) + P.ImporteImpuestoInterno ELSE (((vp.PrecioNeto - (case when 
--		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is not NULL
--		then
--		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc)
--			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
--		 where IdListaPrecios = -1
--			and hpn.FechaHora <= v.fecha
--			and hpn.idproducto = vp.idproducto
--			and hpn.IdSucursal = vp.idsucursal 
--			and p.IdMoneda = 2
--			order by fechahora desc) is NULL
--			then
--			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
--			 when 
--				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc) is not null
--				then
--				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto ) from [HistorialPrecios] hpn
--				where IdListaPrecios = -1
--				and hpn.FechaHora <= v.fecha
--				and hpn.idproducto = vp.idproducto
--				and hpn.IdSucursal = vp.idsucursal 
--				order by fechahora desc)
--				else 
--				ps.preciocosto
--				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100) + (VP.PorcImpuestoInterno / 100))) + P.ImporteImpuestoInterno END END <> vp.Utilidad
----and convert(decimal(16,4),((vp.PrecioNeto -vp.Costo) *vp.Cantidad)) <> vp.utilidad
--AND TC.CoeficienteValores > 0
----order by v.NroVersionAplicacion
----order by vp.Utilidad asc
--order by v.fecha 
--go



update VentasProductos set 
					Costo = (CASE WHEN CFE.IvaDiscriminado = 1 THEN (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto 
			and hpn.IdSucursal = vp.idsucursal
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto 
			and hpn.IdSucursal = vp.idsucursal
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal
				and p.IdMoneda = 1
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end) ELSE    CASE WHEN VP.OrigenPorcImpInt = 'BRUTO' THEN ((case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end) * (1 + (VP.AlicuotaImpuesto / 100))) * (1 + ((VP.PorcImpuestoInterno / 100) / (1 - (VP.PorcImpuestoInterno / 100)))) + P.ImporteImpuestoInterno ELSE ((case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end) * (1 + (VP.AlicuotaImpuesto / 100) + (VP.PorcImpuestoInterno / 100))) + P.ImporteImpuestoInterno END END)
				, garantia = 1
from ventasproductos vp
    INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal 
						AND V.IdTipoComprobante = VP.IdTipoComprobante 
						AND V.Letra = VP.Letra 
						AND V.CentroEmisor = VP.CentroEmisor
						AND V.NumeroComprobante = VP.NumeroComprobante 
	INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
	 INNER JOIN Productos P ON P.IdProducto = VP.IdProducto
	 inner join ProductosSucursales ps on ps.IdProducto = vp.IdProducto
									and ps.IdSucursal = vp.IdSucursal
	INNER JOIN (SELECT P.IdEmpresa, S.Id IdSucursal, CFC.IdCategoriaFiscalCliente, CFC.IvaDiscriminado FROM Parametros P 
		LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON P.ValorParametro = CFC.IdCategoriaFiscalEmpresa AND P.ValorParametro = CFC.IdCategoriaFiscalCliente
		LEFT JOIN Sucursales S ON S.IdEmpresa = P.IdEmpresa
		WHERE P.IdParametro = 'CATEGORIAFISCALEMPRESA') As CFE ON CFE.IdSucursal = V.IdSucursal
	where 1 = 1
	AND convert(varchar(10),V.Fecha,120) >= '2021-06-01'
    AND convert(varchar(10),V.Fecha,120) <= '2021-09-30'
	--and v.NroVersionAplicacion LIKE '%21.06.12.1%'
	AND TC.AfectaCaja = 1
	and round (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end, 2) <> round(vp.costo,2)
	and CASE WHEN CFE.IvaDiscriminado = 1 THEN ((vp.PrecioNeto - (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end))* vp.Cantidad)ELSE    CASE WHEN VP.OrigenPorcImpInt = 'BRUTO' THEN (((vp.PrecioNeto - (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100))) * (1 + ((VP.PorcImpuestoInterno / 100) / (1 - (VP.PorcImpuestoInterno / 100)))) + P.ImporteImpuestoInterno ELSE (((vp.PrecioNeto - (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto ) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100) + (VP.PorcImpuestoInterno / 100))) + P.ImporteImpuestoInterno END END <> vp.Utilidad
AND TC.CoeficienteValores > 0
go

------select * from VentasProductos where Garantia = 1

update Ventasproductos set
					utilidad = (CASE WHEN CFE.IvaDiscriminado = 1 THEN ((vp.PrecioNeto - (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end))* vp.Cantidad)ELSE    CASE WHEN VP.OrigenPorcImpInt = 'BRUTO' THEN (((vp.PrecioNeto - (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100))) * (1 + ((VP.PorcImpuestoInterno / 100) / (1 - (VP.PorcImpuestoInterno / 100)))) + P.ImporteImpuestoInterno ELSE (((vp.PrecioNeto - (case when 
		 vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is not NULL
		then
		(Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc)
			when vp.IdMoneda = 2 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto * v.CotizacionDolar) from [HistorialPrecios] hpn
		 where IdListaPrecios = -1
			and hpn.FechaHora <= v.fecha
			and hpn.idproducto = vp.idproducto
			and hpn.IdSucursal = vp.idsucursal 
			and p.IdMoneda = 2
			order by fechahora desc) is NULL
			then
			convert(decimal(16,4),ps.PrecioCosto * v.CotizacionDolar)
			 when 
				vp.IdMoneda = 1 and (Select top 1 convert(decimal(16,4), hpn.PrecioCosto) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc) is not null
				then
				(Select top 1 convert(decimal(16,4), hpn.PrecioCosto ) from [HistorialPrecios] hpn
				where IdListaPrecios = -1
				and hpn.FechaHora <= v.fecha
				and hpn.idproducto = vp.idproducto
				and hpn.IdSucursal = vp.idsucursal 
				order by fechahora desc)
				else 
				ps.preciocosto
				end))* vp.Cantidad) * (1 + (VP.AlicuotaImpuesto / 100) + (VP.PorcImpuestoInterno / 100))) + P.ImporteImpuestoInterno END END)
from VentasProductos VP
		 INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal 
						AND V.IdTipoComprobante = VP.IdTipoComprobante 
						AND V.Letra = VP.Letra 
						AND V.CentroEmisor = VP.CentroEmisor
						AND V.NumeroComprobante = VP.NumeroComprobante 
	INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
	 INNER JOIN Productos P ON P.IdProducto = VP.IdProducto
	 inner join ProductosSucursales ps on ps.IdProducto = vp.IdProducto
									and ps.IdSucursal = vp.IdSucursal
		INNER JOIN (SELECT P.IdEmpresa, S.Id IdSucursal, CFC.IdCategoriaFiscalCliente, CFC.IvaDiscriminado FROM Parametros P 
		LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON P.ValorParametro = CFC.IdCategoriaFiscalEmpresa AND P.ValorParametro = CFC.IdCategoriaFiscalCliente
		LEFT JOIN Sucursales S ON S.IdEmpresa = P.IdEmpresa
		WHERE P.IdParametro = 'CATEGORIAFISCALEMPRESA') As CFE ON CFE.IdSucursal = V.IdSucursal
where VP.Garantia = 1
go
--select distinct v.NumeroComprobante
--from Ventas V
--INNER JOIN VentasProductos VP ON V.IdSucursal = VP.IdSucursal 
--			AND VP.IdTipoComprobante = V.IdTipoComprobante 
--			AND VP.Letra = V.Letra 
--			AND VP.CentroEmisor = V.CentroEmisor
--			AND VP.NumeroComprobante = V.NumeroComprobante 
--where VP.Garantia = 1
--group by v.fecha ,v.IdSucursal, v.IdTipoComprobante, v.Letra, v.CentroEmisor, v.NumeroComprobante 

update ventas set Utilidad = vp.utilidad
from Ventas V
INNER JOIN VentasProductos VP ON V.IdSucursal = VP.IdSucursal 
			AND V.IdTipoComprobante = VP.IdTipoComprobante 
			AND V.Letra = VP.Letra 
			AND V.CentroEmisor = VP.CentroEmisor
			AND V.NumeroComprobante = VP.NumeroComprobante 
where VP.Garantia = 1
go
--select * from ventas


update ventasproductos set Garantia = 0
where Garantia = 1
go



