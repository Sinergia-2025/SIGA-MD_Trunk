--LS INFROMATICA
IF dbo.ExisteFuncion('Service') = 'True' AND dbo.ExisteFuncion('CRM') = 'True'
BEGIN

DELETE FROM CRMEstadosNovedades WHERE IdTipoNovedad = 'SERVICE'

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
           ,[Embebido])
SELECT IdEstado + 100,  NombreEstado, IdEstado + 100, 'False', 'False',  'SERVICE','False', null, null, 'False', 'False', 'False', 'False'
 FROM [dbo].[RecepcionEstados]


 INSERT INTO [dbo].[CRMNovedades]
          ([IdTipoNovedad] ,[IdNovedad] ,[FechaNovedad] ,[Descripcion] ,[IdPrioridadNovedad] ,[IdCategoriaNovedad]
           ,[IdEstadoNovedad] ,[FechaEstadoNovedad] ,[IdUsuarioEstadoNovedad] ,[FechaAlta] ,[IdUsuarioAlta]
           ,[IdUsuarioAsignado] ,[Avance] ,[IdMedioComunicacionNovedad] ,[IdCliente] ,[IdProspecto] ,[IdFuncion]
           ,[IdSistema] ,[FechaProximoContacto] ,[BanderaColor] ,[Interlocutor] ,[IdMetodoResolucionNovedad]
           ,[IdProveedor] ,[IdProyecto] ,[RevisionAdministrativa] ,[Priorizado] ,[IdTipoNovedadPadre]
           ,[IdNovedadPadre] ,[Version] ,[VersionFecha] ,[FechaInicioPlan] ,[FechaFinPlan] ,[TiempoEstimado]
           ,[IdUsuarioResponsable] ,[Cantidad] ,[Letra] ,[CentroEmisor] ,[LetraPadre] ,[CentroEmisorPadre]
           ,[IdSucursalService] ,[IdTipoComprobanteService] ,[LetraService] ,[CentroEmisorService]
           ,[NumeroComprobanteService] ,[IdProducto] ,[CantidadProducto] ,[CostoReparacion] ,[IdProductoPrestado]
           ,[CantidadProductoPrestado] ,[ProductoPrestadoDevuelto] ,[IdProveedorService])
 SELECT 'SERVICE', RN.NroNota ,RN.FechaNota ,RN.DefectoProducto , 508, 507
		, RE.IdEstado + 100 ,RNE.FechaEstado ,RN.Usuario,FechaNota,RN.Usuario
		,RN.Usuario, 0.00, 542, RN.IdCliente ,NULL	,NULL	
		,NULL	,NULL	,NULL	,NULL	,NULL	
		,NULL	,NULL ,'False','False', NULL
		,	NULL,	NULL,	NULL,	NULL,	NULL,	0.00
		,RN.Usuario	,0.00	,'X' ,1	,NULL	,NULL	
		,RN.IdSucursal,	RN.IdTipoComprobante	 ,RN.Letra ,RN.CentroEmisor
		 ,RN.NumeroComprobante	,RN.IdProducto ,RN.CantidadProductos,RN.CostoReparacion,RN.IdProductoPrestado
		 ,RN.CantidadPrestada ,RN.EstaPrestado ,RNP.IdProveedor
FROM RecepcionNotas RN
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
           ,[CentroEmisor])
  SELECT 'SERVICE',  RN.NroNota , ROW_NUMBER() over( order by  [FechaEstado]) 
  , [FechaEstado] ,'Cambió el Estado a ' + RE.NombreEstado+ ' - ' + RNE.[Observacion], 'True',  RNE.[Usuario], '', 'X' ,1
  FROM [dbo].[RecepcionNotasEstados] RNE
  INNER JOIN RecepcionNotas RN ON  RN.IdSucursal = RNE.IdSucursal AND RN.NroNota = RNE.NroNota
  INNER JOIN RecepcionEstados RE ON RE.IdEstado = RNE.IdEstado


  END 