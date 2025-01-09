IF dbo.ExisteFuncion('Service') = 'True' AND dbo.ExisteFuncion('CRM') = 'True'
BEGIN

DELETE FROM CRMEstadosNovedades WHERE IdTipoNovedad = 'SERVICE'

--select * from [CRMEstadosNovedades]
--select * from recepcionestados

INSERT INTO [dbo].[CRMEstadosNovedades]
           ([IdEstadoNovedad]
      ,[NombreEstadoNovedad]
      ,[Posicion]
      ,[SolicitaUsuario]
      ,[Finalizado]
      ,[IdTipoNovedad]
      ,[PorDefecto]
      ,[Color]
      ,[DiasProximoContacto]
      ,[ActualizaUsuarioResponsable]
      ,[SolicitaProveedorService]
      ,[Imprime]
      ,[Reporte]
      ,[Embebido]
      ,[AcumulaContador1]
      ,[AcumulaContador2]
      ,[EsFacturable]
      ,[CantidadCopias]
      ,[IdTipoEstadoNovedad]
      ,[Entregado]
      ,[IdEstadoFacturado]
      ,[AvanceEstadoFacturado]
      ,[ControlaStockConsumido]
      ,[RequiereComentarios])
SELECT IdEstado + 100,  NombreEstado, IdEstado + 100, 'False', 
case when nombreestado = 'No reparado' or nombreestado = 'Reparado' or nombreestado = 'Entregado' then 'True' else 'False' end,
 'SERVICE','False', null, null, 'False', 'False', 'False', NULL, 
'False', 'False', 'False', 'False', 1, 
case when nombreestado = 'Pendiente' then 101 else case when nombreestado = 'Service' or nombreestado = 'Trabajando' then 102 else case when nombreestado = 'No reparado' then 104 else 103 end end end, 
case when nombreestado = 'Pendiente' or nombreestado = 'Service' or nombreestado = 'Trabajando' then 'NoAfecta' else 'Graba' end, 
 null, null, 'False', 'False'
 FROM [dbo].[RecepcionEstados]
 where idestado <> 0

 
 --select * from RecepcionNotas
 -- select * from RecepcionNotasEstados
 --select * from crmnovedades


 INSERT INTO [dbo].[CRMNovedades]
          ([IdTipoNovedad]
      ,[IdNovedad]
      ,[FechaNovedad]
      ,[Descripcion]
      ,[IdPrioridadNovedad]
      ,[IdCategoriaNovedad]
      ,[IdEstadoNovedad]
      ,[FechaEstadoNovedad]
      ,[IdUsuarioEstadoNovedad]
      ,[FechaAlta]
      ,[IdUsuarioAlta]
      ,[IdUsuarioAsignado]
      ,[Avance]
      ,[IdMedioComunicacionNovedad]
      ,[IdCliente]
      ,[IdProspecto]
      ,[IdFuncion]
      ,[IdSistema]
      ,[FechaProximoContacto]
      ,[BanderaColor]
      ,[Interlocutor]
      ,[IdMetodoResolucionNovedad]
      ,[IdProveedor]
      ,[IdProyecto]
      ,[RevisionAdministrativa]
      ,[Priorizado]
      ,[IdTipoNovedadPadre]
      ,[IdNovedadPadre]
      ,[Version]
      ,[VersionFecha]
      ,[FechaInicioPlan]
      ,[FechaFinPlan]
      ,[TiempoEstimado]
      ,[IdUsuarioResponsable]
      ,[Cantidad]
      ,[Letra]
      ,[CentroEmisor]
      ,[LetraPadre]
      ,[CentroEmisorPadre]
      ,[IdSucursalService]
      ,[IdTipoComprobanteService]
      ,[LetraService]
      ,[CentroEmisorService]
      ,[NumeroComprobanteService]
      ,[IdProducto]
      ,[CantidadProducto]
      ,[CostoReparacion]
      ,[IdProductoPrestado]
      ,[CantidadProductoPrestado]
      ,[ProductoPrestadoDevuelto]
      ,[IdProveedorService]
      ,[Contador1]
      ,[Contador2]
      ,[FechaActualizacionWeb]
      ,[IdProductoNovedad]
      ,[EtiquetaNovedad]
      ,[NroDeSerie]
      ,[TieneGarantiaService]
      ,[UbicacionService]
      ,[NroSerieProductoPrestado]
      ,[IdSucursalFact]
      ,[IdTipoComprobanteFact]
      ,[LetraFact]
      ,[CentroEmisorFact]
      ,[NumeroComprobanteFact]
      ,[RequiereTesteo]
      ,[FechaEntregado]
      ,[FechaFinalizado]
      ,[IdEstadoNovedadEntregado]
      ,[IdEstadoNovedadFinalizado]
      ,[IdUsuarioEntregado]
      ,[IdUsuarioFinalizado]
      ,[NombreProducto]
      ,[IdEstadoNovedadAnterior]
      ,[AvanceAnterior]
      ,[Observacion]
      ,[ClienteValorizacionEstrellas]
      ,[FechaHoraRetiro]
      ,[IdDomicilioRetiro]
      ,[FechaHoraEntrega]
      ,[IdDomicilioEntrega]
      ,[IdProveedorGarantia]
      ,[FechaHoraRetiroGarantia]
      ,[FechaHoraEnvioGarantia]
      ,[AnticipoNovedad]
      ,[IdMarcaProducto]
      ,[IdModeloProducto]
      ,[IdSucursalNovedad]
      ,[ServiceLugarCompra]
      ,[ServiceLugarCompraFecha]
      ,[ServiceLugarCompraTipoComprobante]
      ,[ServiceLugarCompraNumeroComprobante]
      ,[NombreMarcaProducto]
      ,[NombreModeloProducto])
 SELECT 'SERVICE', RN.NroNota ,RN.FechaNota ,RN.DefectoProducto , 507, 508
		, RE.IdEstado + 100 ,RNE.FechaEstado ,RN.Usuario,RN.FechaNota,RN.Usuario
		,RN.Usuario, 
		case when (RE.IdEstado + 100) = 110 or (RE.IdEstado + 100) = 120 or (RE.IdEstado + 100) = 100 or (RE.IdEstado + 100) = 125 then 0 else 100 end, 546, RN.IdCliente ,NULL	,NULL	
		,NULL	,NULL	,NULL	,NULL	,NULL	
		,NULL	,NULL ,'False','False', NULL
		,	NULL,	NULL,	NULL,	NULL,	NULL,	0.00
		,RN.Usuario	,0.00	,'X' ,1	,NULL	,NULL	
		,RN.IdSucursal,	RN.IdTipoComprobante	 ,RN.Letra ,RN.CentroEmisor
		 ,RN.NumeroComprobante	,RN.IdProducto ,RN.CantidadProductos,RN.CostoReparacion,RN.IdProductoPrestado
		 ,RN.CantidadPrestada ,RN.EstaPrestado ,RNP.IdProveedor, 0, 0, RNE.FechaEstado, NULL, '', NULL, 'False',
		 NULL, '', NULL, NULL, NULL, NULL, NULL, 'False', NULL, NULL, NULL, NULL, NULL, rn.Usuario, p.nombreproducto
		 , NULL, NULL, rn.Observacion, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0.00, m.idmarca, NULL, NULL, '', NULL,
		 '', '', m.Nombremarca, '' 
FROM RecepcionNotas RN
inner join productos p on p.idproducto = rn.idproducto
inner join marcas m on m.idmarca = p.idmarca
LEFT JOIN RecepcionNotasProveedores RNP ON RNP.IdSucursal = RN.IdSucursal AND RNP.NroNota = RN.NroNota AND RNP.FechaEntrega =   
(SELECT MAX(RNP1.FechaEntrega) FROM RecepcionNotasProveedores RNP1 
	WHERE RNP1.NroNota = RN.NroNota GROUP BY RNP1.NroNota)
INNER JOIN RecepcionNotasEstados RNE ON RNE.FechaEstado = 
(SELECT MAX(RNE.FechaEstado) FROM RecepcionNotasEstados RNE 
	WHERE RNE.NroNota = RN.NroNota GROUP BY RNE.NroNota)
INNER JOIN RecepcionEstados RE ON RE.IdEstado = 
	(SELECT RNE1.IdEstado FROM RecepcionNotasEstados RNE1 
	WHERE RNE1.NroNota = RN.NroNota AND RNE1.FechaEstado =
	(SELECT MAX(RNE.FechaEstado) FROM RecepcionNotasEstados RNE 
	WHERE RNE.IdSucursal = RN.IdSucursal AND RNE.NroNota = RN.NroNota GROUP BY RNE.NroNota))
	Where rn.NroNota <> 556

--select * from CRMNovedadesSeguimiento
--select * from [RecepcionNotasEstados]

	 INSERT INTO [dbo].[CRMNovedadesSeguimiento]
           ([IdTipoNovedad]
      ,[IdNovedad]
      ,[IdSeguimiento]
      ,[FechaSeguimiento]
      ,[Comentario]
      ,[EsComentario]
      ,[UsuarioSeguimiento]
      ,[Interlocutor]
      ,[Letra]
      ,[CentroEmisor]
      ,[IdTipoComentarioNovedad]
      ,[Activo]
      ,[IdEstadoNovedad]
      ,[UsuarioAsignado]
      ,[IdUnico]
      ,[FechaActualizacionWeb])
  SELECT 'SERVICE',  RN.NroNota , ROW_NUMBER() over( order by  [FechaEstado]) 
  , [FechaEstado] , RNE.[Observacion], 'True',  RNE.[Usuario], '', 'X' ,1, 101, 'True', Rne.IdEstado + 100, rne.Usuario
  , 'Migracion de service', rne.FechaEstado
  FROM [dbo].[RecepcionNotasEstados] RNE
  INNER JOIN RecepcionNotas RN ON  RN.IdSucursal = RNE.IdSucursal AND RN.NroNota = RNE.NroNota
  INNER JOIN RecepcionEstados RE ON RE.IdEstado = RNE.IdEstado
  Where rn.NroNota <> 556


--select * from [CRMNovedadesCambiosEstados]
--select * from [RecepcionNotasEstados]

  	 INSERT INTO [dbo].[CRMNovedadesCambiosEstados]
           ([IdTipoNovedad]
      ,[Letra]
      ,[CentroEmisor]
      ,[IdNovedad]
      ,[IdCambioEstado]
      ,[FechaCambioEstado]
      ,[IdEstadoNovedad]
      ,[IdUsuario]
      ,[IdUsuarioAsignado])
  SELECT 'SERVICE', 'X', 1, RN.NroNota , ROW_NUMBER() over( order by  [FechaEstado]) 
  , [FechaEstado] , RE.IdEstado + 100 , RNE.[Usuario], RNE.[Usuario]
  FROM [dbo].[RecepcionNotasEstados] RNE
  INNER JOIN RecepcionNotas RN ON  RN.IdSucursal = RNE.IdSucursal AND RN.NroNota = RNE.NroNota
  INNER JOIN RecepcionEstados RE ON RE.IdEstado = RNE.IdEstado
    Where rn.NroNota <> 556


  END 