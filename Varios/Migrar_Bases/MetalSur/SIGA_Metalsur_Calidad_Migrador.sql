
PRINT ''
PRINT '1. Migrador Metalsur'
IF dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN

DELETE FROM HistorialConsultaProductos;
DELETE FROM ProductosClientes;
DELETE FROM ProductosSucursalesPrecios;
DELETE FROM ProductosSucursales;
DELETE FROM ProductosWeb;
DELETE FROM ProductosComponentes;
DELETE FROM ProductosFormulas;
DELETE FROM ProductosLinks;
DELETE FROM CalidadPlantillasListasControl;
DELETE FROM CalidadPlantillas;
DELETE FROM CalidadListasControlRoles;
DELETE FROM AuditoriaCalidadListasControlProductos;
DELETE FROM AuditoriaCalidadListasControlProductosItems;
DELETE FROM CalidadEstadosListasControl;
DELETE FROM CalidadListasControlConfigLinks;
DELETE FROM CalidadListasControlProductosItems;
DELETE FROM CalidadListasControlProductos;
DELETE FROM CalidadListasControlUsuarios;
DELETE FROM Productos;
DELETE FROM Clientes;
DELETE FROM CalidadListasControlConfig;
DELETE FROM CalidadListasControl;
DELETE FROM CalidadListasControlItems;
DELETE FROM CalidadSubGruposListasControlItems;
DELETE FROM CalidadGruposListasControlItems;


--Inserta los Grupos de Items
INSERT INTO CalidadGruposListasControlItems (IdGrupoListaControlItem, NombreGrupoListaControlItem) 
SELECT distinct  CASE WHEN charindex('-',ChekListIDItemDesc,1)>0 THEN ltrim(rtrim(SUBSTRING(ChekListIDItemDesc,1,charindex('-',ChekListIDItemDesc,1)-1))) ELSE '' END
,CASE WHEN charindex('-',ChekListIDItemDesc,1)>0 THEN ltrim(rtrim(SUBSTRING(ChekListIDItemDesc,1,charindex('-',ChekListIDItemDesc,1)-1))) ELSE '' END  
FROM IGC.dbo.IGC_CheckListsItems 


--INSERT INTO [dbo].[CalidadSubGruposListasControlItems]
--           ([IdGrupoListaControlItem]
--           ,[IdSubGrupoListaControlItem]
--           ,[NombreSubGrupoListaControlItem])


-- Inserta los items
INSERT INTO CalidadListasControlItems  ([IdListaControlItem]
           ,[NombreListaControlItem]
           ,[IdGrupoListaControlItem]
           ,[IdSubGrupoListaControlItem]) 
SELECT ChekListIDItemID
,ChekListIDItemDesc
--,  ltrim(rtrim(SUBSTRING(ChekListIDItemDesc,charindex('-',ChekListIDItemDesc,1)+1,len(ChekListIDItemDesc))))
,  CASE WHEN charindex('-',ChekListIDItemDesc,1)>0 THEN ltrim(rtrim(SUBSTRING(ChekListIDItemDesc,1,charindex('-',ChekListIDItemDesc,1)-1))) ELSE '' END
, ''
FROM IGC.dbo.IGC_CheckListsItems 


-- Inserta las listas de control
INSERT INTO CalidadListasControl
           ([IdListaControl]
           ,[NombreListaControl]
           ,[Orden]
		   ,[ControlaProduccion]
           ,[ControlaCalidad]
           ,[Controla5SProduccion]
           ,[Controla5SCalidad]
           ,[InicioAutomatico]
           ,[DiasMaximoProceso]
		   ,[ModificaFechaEgreso]
           ,[ModificaFechaPreEntrega])
		   SELECT [ChekListID]
      ,[CheckListDesc]
      ,[Orden] * 10,'True', 'True', 'True','True', 'False', Null,'False', 'False'
  FROM IGC.dbo.[IGC_CheckLists]

  UPDATE CalidadListasControl SET ModificaFechaEgreso = 'True' WHERE IdListaControl = 21

UPDATE CalidadListasControl SET ModificaFechaPreEntrega = 'True' WHERE IdListaControl = 10

-- Inserta las listas de control Items Configuracion
INSERT INTO CalidadListasControlConfig
            ([IdListaControl]
           ,[Item]
           ,[IdListaControlItem]
           ,[Orden])
SELECT [ChekListID]
      ,[Item]
      ,[ChekListIDItemID]
      ,[Orden] * 10
  FROM IGC.[dbo].[IGC_CheckListsDet]


----- Inserta los Usuarios
--INSERT INTO [dbo].[Usuarios]
--           ([Id]
--           ,[Nombre]
--           ,[Clave]
--           ,[MailServidorSMTP]
--           ,[MailPuertoSalida]
--           ,[MailDireccion]
--           ,[MailUsuario]
--           ,[MailPassword]
--           ,[MailRequiereSSL]
--           ,[MailRequiereAutenticacion]
--           ,[MailCantxHora]
--           ,[MailCantxMinuto]
--           ,[UtilizaComoPredeterminado]
--           ,[CorreoElectronico]
--           ,[FechaUltimaModContraseña]
--           ,[Activo]
--           ,[NivelAutorizacion])
--		   SELECT substring([usr_name],1,10)
--      ,[usr_name]
--      ,''
--	  , NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL	
--	  ,NULL
--      ,getdate()
--      ,'True'
--      ,999
--       FROM IGC.[dbo].[app_users_config]


-- Inserta los Usuarios de las Listas de Control
INSERT INTO [dbo].[CalidadListasControlUsuarios]
           ([IdListaControl]
           ,[IdUsuario])
   SELECT [ChekListID]
      ,substring([UserName],1,10)
  FROM IGC.[dbo].[IGC_CheckListsUsers]



-- Inserta Clientes
DECLARE @Valor VARCHAR(MAX)
SELECT @Valor = ISNULL(MAX(CodigoCliente), 0) FROM Clientes

INSERT INTO Clientes (IdCliente,CodigoCliente,NombreCliente, NombreDeFantasia, 
Direccion, 
DireccionAdicional,
IdLocalidad, 
Telefono, 
FechaNacimiento, 
NroOperacion, 
CorreoElectronico, 
Celular, 
NombreTrabajo, 
DireccionTrabajo, 
TelefonoTrabajo, 
CorreoTrabajo, 
IdLocalidadTrabajo, 
FechaIngresoTrabajo, 
FechaAlta, 
SaldoPendiente, 
IdClienteGarante,IdCategoria,  
IdCategoriaFiscal, 
Cuit, 
TipoDocVendedor, 
NroDocVendedor, 
Observacion, 
idListaPrecios, 
IdZonaGeografica, 
LimiteDeCredito, 
IdSucursalAsociada, 
DescuentoRecargoPorc, 
Activo, 
IdTipoComprobante, 
IdFormasPago, 
IdTransportista,
IngresosBrutos,
InscriptoIBStaFe,
LocalIB,
ConvMultilateralIB,
NumeroLote,
IdCaja,
GeoLocalizacionLat,
GeoLocalizacionLng,
IdTipoDeExension,
AnioExension,
NroCertExension,
NroCertPropio,
 TipoDocCliente,  NroDocCliente, DescuentoRecargoPorc2, 
 IdClienteCtaCte, PaginaWeb,
 LimiteDiasVtoFactura,
 ModificarDatos,
 EsResidente,
 CorreoAdministrativo
 ,IdEstado
 ,IdCobrador
 ,IdTipoCliente
 ,HoraInicio
 ,HoraFin
 ,HoraInicio2
 ,HoraFin2
 ,HoraSabInicio
 ,HoraSabFin
 ,HoraSabInicio2
 ,HoraSabFin2
 ,HoraDomInicio
 ,HoraDomFin
 ,HoraDomInicio2
 ,HoraDomFin2
 ,HorarioCorrido
 ,HorarioCorridoSab
 ,HorarioCorridoDom
 ,NroVersion
 ,FechaActualizacionVersion
 ,FechaInicio
 ,FechaInicioReal
 ,VencimientoLicencia
 ,BackupAutoCuenta
 ,BackupAutoConfig
 ,TienePreciosConIVA
 ,ConsultaPreciosConIVA
 ,TieneServidorDedicado
 ,MotorBaseDatos
 ,CantidadDePCs
 ,HorasCapacitacionPactadas
 ,HorasCapacitacionRealizadas
           ,CBU
           ,IdBanco
           ,IdCuentaBancariaClase
           ,NumeroCuentaBancaria
           ,CuitCtaBancaria
           ,UsaArchivoAImprimir2
           ,CantidadVisitas
           ,BackupNroVersion
           ,Facebook
           ,Instagram
           ,Twitter
           ,IdAplicacion
           ,Edicion
           ,RecibeNotificaciones
       ,Contacto
       ,FechaBaja
       ,VerEnConsultas
       ,IdCalle
       ,Altura
       ,IdCalle2
       ,Altura2
       ,DireccionAdicional2
       ,TelefonosParticulares
      ,Fax
      ,FechaSUS
      ,TipoDocDadoAltaPor
      ,NroDocDadoAltaPor
      ,HabilitarVisita
      ,Direccion2
      ,IdLocalidad2
      ,ObservacionWeb
      ,RepartoIndependiente
      ,NivelAutorizacion
      ,IdCuentaContable
      ,EsClienteGenerico
      ,URLWebmovilPropio
      ,URLWebmovilAdminPropio
      ,URLSimovilGestionPropio
      ,NroVersionWebmovilPropio
      ,NroVersionWebmovilAdminPropio
      ,NroVersionSimovilGestionPropio
      ,UtilizaAppSoporte
      ,CantidadLocal
      ,CantidadRemota
      ,CantidadMovil
      ,ObservacionAdministrativa
    ,CodigoClienteLetras
	,SiMovilIdUsuario
	,SiMovilClave
	,Alicuota2deProducto
	,CertificadoMiPyme)
	
SELECT @valor + ROW_NUMBER() OVER(ORDER BY ClienteId ASC),  @valor + ROW_NUMBER()OVER(ORDER BY ClienteId ASC), [ClienteDesc], 
[NombreFantasia] , 
'.', 
'',2000, 
'', 
'19000101 00:00:00', 
'0', 
'', 
'', 
'', 
'', 
'', 
'', 
NULL, 
'20190726 00:00:00', 
'20190726 10:23:44', 
0, 
null, 
 1, 
 1, 
 '', 
 'COD', 
 '1', 
 '', 
0, 'General', 
0, NULL, 
0,  'True',
NULL, 
NULL, 
NULL, 
NULL, 
 'False',
 'False',
 'False',
NULL, 
NULL,
NULL,
NULL,
NULL,
NULL,
NULL, 
NULL, 
null, 
null, 
0,null, 
'',
0,'True',
'False', 
''
,1
, 1, 1, '', '', '', '', '', '', '', '', '', '', '', '', '0', '0', '0', '', null, null, null, null, '', NULL, NULL, NULL, NULL, '', 0, 0, 0           ,null           ,null           ,null           ,null           ,null           ,0           ,7
           ,''
           ,''
           ,''
           ,''
           ,'SIGA'
           ,NULL
           ,'True'
           ,null           ,null           ,1           ,1           ,0           ,1           ,0           ,null           ,null           ,null           ,null           ,'COD'           ,'1'           ,0           ,'.'           ,2000,''
           ,0  ,0
  ,NULL
, '0'
      ,''
      ,''
      ,''
      ,''
      ,''
      ,''
, '0'
,  0
,  0
,  0
, ''
, [ClienteID],'','','SEGUNCATEGORIAFISCAL','False'
  FROM IGC.dbo.[IGC_Clientes]

          
	



-- Inserta los Productos 

INSERT INTO Productos (
   IdProducto
  ,NombreProducto
  ,Tamano
  ,IdUnidadDeMedida
  ,IdMarca
  ,IdModelo
  ,IdRubro
  ,IdSubRubro
  ,MesesGarantia
  ,IdTipoImpuesto
  ,Alicuota
  ,Alicuota2
  ,AfectaStock
  ,Activo
  ,Lote
  ,NroSerie
  ,CodigoDeBarras
  ,EsServicio
  ,PublicarEnWeb
  ,Observacion
  ,EsCompuesto
  ,DescontarStockComponentes
  ,EsDeCompras
  ,EsDeVentas
  ,IdMoneda
  ,CodigoDeBarrasConPrecio
  ,PermiteModificarDescripcion
  ,EsAlquilable
  ,EquipoMarca
  ,EquipoModelo
  ,NumeroSerie
  ,CaractSII
  ,Anio
  ,PagaIngresosBrutos
  ,Embalaje
  ,Kilos
  ,IdFormula
  ,IdProductoMercosur
  ,IdProductoSecretaria
  ,publicarListaDePreciosClientes
  ,facturacionCantidadNegativa
  ,solicitaEnvase
  ,alertaDeCaja
  ,nombreCorto
  ,EsRetornable
  ,Orden
  ,IdProveedor
  ,CodigoLargoProducto
  ,ModalidadCodigoDeBarras
  ,EsObservacion
 ,UnidHasta1
 ,UnidHasta2
 ,UnidHasta3
 ,UnidHasta4
 ,UnidHasta5
 ,UHPorc1
 ,UHPorc2
 ,UHPorc3
 ,UHPorc4
 ,UHPorc5
 ,PrecioPorEmbalaje
 ,IdCuentaCompras
 ,IdCuentaVentas
 ,ImporteImpuestoInterno
 ,EsOferta
 ,IdCuentaComprasSecundaria
 ,IncluirExpensas
 ,IdCentroCosto
 ,ObservacionCompras
 ,SolicitaPrecioVentaPorTamano
 ,Espmm
 ,EspPulgadas
 ,CodigoSAE
 ,IdProduccionProceso
 ,IdProduccionForma
 ,CalculaPreciosSegunFormula
 ,IdSubSubRubro
 ,PorcImpuestoInterno
 ,OrigenPorcImpInt
 ,EsCambiable
 ,EsBonificable
 ,ALto
 ,Ancho
 ,Largo
 ,DescRecProducto
 ,ActualizaPreciosSucursalesAsociadas
 , CalidadStatusLiberado 
 , CalidadFechaLiberado
 , CalidadUserLiberado 
 , CalidadStatusEntregado
 , CalidadFechaEntregado
 , CalidadUserEntregado
 , CalidadFechaIngreso
 , CalidadFechaEgreso
 , CalidadNroCertificado
 , CalidadFecCertificado
 , CalidadUsrCertificado
 , CalidadObservaciones
 , CalidadFechaPreEnt
 , CalidadFechaEntProg 
 ,EsComercial)
SELECT [ProductID] ,CASE WHEN [ProductDesc] IS NULL THEN '.' ELSE [ProductDesc] END ,null  ,null
  ,1
  ,null
  ,1
  ,null
, 0
, 'IVA'
, 21
, 0
, 'True'
, 'True'
, 'False'
, 'False'
  , NULL
, 0, 0, ''
, 0, 0, 1, 1, 1
, 0, 0, 0  , NULL
  , NULL
  , NULL
  , NULL
  , NULL
, 1, 1
, 0
  ,NULL
  , NULL
  , NULL
  ,1
  ,0
  ,0
  ,0
  ,''
  ,0
, 1
, NULL 
, ''
, NULL 
 ,0,
0,0,0,0,0,0,0,0,0,0,0
 , NULL
 , NULL
 ,0
 ,'NO'
 , NULL
 ,0
 , NULL
 ,''
 ,0
 ,0
 ,''
 ,''
 ,NULL
 ,NULL
 ,0
 ,NULL
 ,'0'
,'NETO'
 ,0
 ,0
, 0
, 0
, 0
 ,0
 ,1
   ,CASE WHEN [StatusLiberado] IS NULL THEN 0 ELSE [StatusLiberado] END
      ,[FechaLiberado]
      ,[UserLiberado]
      ,CASE WHEN [StatusEntregado] IS NULL THEN 0 ELSE [StatusEntregado] END 
      ,[FechaEntregado]
      ,[UserEntregado]
      ,[FechaIngreso]
      ,[FechaEgreso]
      ,[NroCertificado]
      ,[FecCertificado]
      ,[UsrCertificado]
      ,[Observaciones]
      ,[FechaPreEnt]
      ,[FechaEntProg]
	  ,'False'
  FROM IGC.[dbo].[IGC_Productos] M
  

--  INSERT INTO [dbo].[ProductosSucursales]
--           ([IdProducto]
--           ,[IdSucursal]
--           ,[PrecioFabrica]
--           ,[PrecioCosto]
--           ,[Usuario]
--           ,[FechaActualizacion]
--           ,[Stock]
--           ,[StockInicial]
--           ,[PuntoDePedido]
--           ,[StockMinimo]
--           ,[StockMaximo]
--           ,[Ubicacion]
--           ,[StockReservado]
--           ,[FechaActualizacionWeb]
--           ,[StockDefectuoso]
--           ,[StockFuturo]
--           ,[StockFuturoReservado])
--SELECT [ProductID]	,1	,0.0000,	0.0000	,'admin' ,	'20190726 00:00:00'	,0.0000	,0.0000,	0.0000	,0.0000	,0.0000	,NULL	,0.0000	,'20190726 00:00:00'	,0.00	,0.00	,0.00
-- FROM IGC.[dbo].[IGC_Productos] M

-- INSERT INTO [dbo].[ProductosSucursalesPrecios]
--           ([IdProducto]
--           ,[IdSucursal]
--           ,[IdListaPrecios]
--           ,[PrecioVenta]
--           ,[FechaActualizacion]
--           ,[Usuario]
--           ,[FechaActualizacionWeb])
--SELECT [ProductID],	1	,0	,0.0000	,'20190726 00:00:00'	,'admin' ,	'20190726 00:00:00'
-- FROM IGC.[dbo].[IGC_Productos] M

  -- Insertta Cliente del Producto
  INSERT INTO [dbo].[ProductosClientes]
           ([IdProducto]
           ,[IdCliente])
		   SELECT [ProductID], C.IdCliente
            FROM IGC.[dbo].[IGC_Productos] M
 LEFT JOIN Clientes C ON  C.CodigoClienteLetras = M.ClienteID COLLATE Modern_Spanish_100_CI_AS
 WHERE IdCliente is not null


INSERT INTO [dbo].[ProductosSucursales]
           ([IdProducto]
           ,[IdSucursal]
           ,[PrecioFabrica]
           ,[PrecioCosto]
           ,[Usuario]
           ,[FechaActualizacion]
           ,[Stock]
           ,[StockInicial]
           ,[PuntoDePedido]
           ,[StockMinimo]
           ,[StockMaximo]
           ,[Ubicacion]
           ,[StockReservado]
           ,[FechaActualizacionWeb]
           ,[StockDefectuoso]
           ,[StockFuturo]
           ,[StockFuturoReservado])
SELECT IdProducto, IdSucursal, 0, 0, 'admin', GETDATE(), 1, 1, 0, 0, 0, 'MIGRADO', 0, GETDATE(), 0, 0, 0
  FROM Productos
 CROSS JOIN Sucursales

 PRINT '8. Tabla CalidadListasControlRoles: Cargar datos iniciales'
-- Agrego permiso Admin, Suoervisor
INSERT INTO [dbo].[CalidadListasControlRoles]
           ([IdListaControl]
           ,[IdRol])
 SELECT IdListaControl, 'Adm' FROM CalidadListasControl
 UNION ALL
 SELECT IdListaControl, 'Supervisor' FROM CalidadListasControl


 INSERT INTO [dbo].[CalidadListasControlProductos]
           ([IdProducto]
           ,[IdListaControl]
           ,[fecha]
           ,[Idusuario]
           ,[FecIngreso]
           ,[FecEgreso]
           ,[CincoS]
           ,[CincoSComment]
           ,[CincoSC]
           ,[CincoSCommentC]
           ,[CincoSUsr]
           ,[CincoSFecha]
           ,[CincoSUsrC]
           ,[CincoSFechaC]
		   ,[Aplica]
           ,[IdEstadoCalidad]
           ,[Observacion])
SELECT [ProductID]
      ,[ChekListID]
      ,[fecha]
      ,substring([Usuario],1,10)
      ,[FecIngreso]
      ,[FecEgreso]
      ,[CincoS]
      ,[CincoSComment]
      ,[CincoSC]
      ,[CincoSCommentC]
      ,[CincoSUsr]
      ,[CincoSFecha]
      ,[CincoSUsrC]
      ,[CincoSFechaC], CASE WHEN Aplica = 'Y' THEN 'True' ELSE 'False' END,1,null
  FROM IGC.[dbo].[IGC_CheckListsProd] M
  INNER JOIN Productos P ON P.IdProducto = M.ProductID COLLATE Modern_Spanish_100_CI_AS
  WHERE M.Aplica = 'Y'

INSERT INTO [dbo].[ProductosSucursalesPrecios]
           ([IdProducto]
           ,[IdSucursal]
           ,[IdListaPrecios]
           ,[PrecioVenta]
           ,[FechaActualizacion]
           ,[Usuario]
           ,[FechaActualizacionWeb])
SELECT IdProducto, IdSucursal, IdListaPrecios, 0, GETDATE(), 'admin', GETDATE()
  FROM ProductosSucursales
 CROSS JOIN ListasDePrecios


 
INSERT INTO [dbo].[AuditoriaCalidadListasControlProductos]
           ([FechaAuditoria]
           ,[OperacionAuditoria]
           ,[UsuarioAuditoria]
           ,[IdProducto]
           ,[IdListaControl]
           ,[fecha]
           ,[IdUsuario]
           ,[FecIngreso]
           ,[FecEgreso]
           ,[CincoS]
           ,[CincoSComment]
           ,[CincoSC]
           ,[CincoSCommentC]
           ,[CincoSUsr]
           ,[CincoSFecha]
           ,[CincoSUsrC]
           ,[CincoSFechaC]
           ,[Aplica]
           ,[IdEstadoCalidad])
 SELECT [FechaMod]
    ,CASE WHEN [Operacion] = 'ALTA' THEN 'A' ELSE CASE WHEN [Operacion] = 'BAJA' THEN 'B' ELSE CASE WHEN [Operacion] = 'MODIFICACION' THEN 'M' ELSE '' END END END
    ,substring([UsrMod],1,10)
      ,[ProductID]
      ,[ChekListID]
       ,[fecha]
       ,substring([Usuario],1,10)
      ,[FecIngreso]
      ,[FecEgreso]
      ,[CincoS]
      ,[CincoSComment]
      ,[CincoSC]
      ,[CincoSCommentC]
      ,[CincoSUsr]
      ,[CincoSFecha]
      ,[CincoSUsrC]
      ,[CincoSFechaC]
   	  , CASE WHEN Aplica = 'Y' THEN 'True' ELSE 'False' END
      ,1
  FROM  IGC.[dbo].[IGC_CheckListsProd_LOG]

 

  INSERT INTO [dbo].[CalidadListasControlProductosItems]
               ([IdProducto]
               ,[IdListaControl]
               ,[Item]
               ,[IdListaControlItem]
               ,[Ok]
               ,[NoOk]
               ,[Obs]
               ,[Mat]
               ,[NA]
               ,[Observ]
               ,[Orden]
               ,[Usuario]
               ,[FechaMod]  
		        ,[OkCalidad]
               ,[NoOkCalidad]
               ,[ObsCalidad]
               ,[MatCalidad]
               ,[NACalidad]
               ,[ObservCalidad]
               ,[UsuarioCalidad]
               ,[FechaModCalidad])
      SELECT [ProductID]
          ,[ChekListID]
          ,M.[Item]
          ,[ChekListIDItemID]
	      ,CASE WHEN [Estado] = 1 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 2 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 3 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 4 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 5 THEN 'True' ELSE 'False' END 
	      ,[Observ]
          ,M.[Orden]
          ,[Usuario]
          ,[FechaMod]
		   ,CASE WHEN [Estado] = 1 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 2 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 3 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 4 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 5 THEN 'True' ELSE 'False' END 
		--  , 'False','False','False','False','False'
		  , null, null,null
      FROM IGC.[dbo].[IGC_CheckListsProdDet] M
        INNER JOIN Productos P ON P.IdProducto = M.ProductID COLLATE Modern_Spanish_100_CI_AS
	    INNER JOIN CalidadListasControlConfig CLCC ON CLCC.IdListaControl = M.ChekListID
	    AND CLCC.Item = M.Item


   INSERT INTO [dbo].[AuditoriaCalidadListasControlProductosItems]
               ([FechaAuditoria]
               ,[OperacionAuditoria]
               ,[UsuarioAuditoria]
               ,[IdProducto]
               ,[IdListaControl]
               ,[Item]
               ,[IdListaControlItem]
               ,[Ok]
               ,[NoOk]
               ,[Obs]
               ,[Mat]
               ,[NA]
               ,[Observ]
               ,[Orden]
               ,[Usuario]
               ,[FechaMod]   
		        ,[OkCalidad]
               ,[NoOkCalidad]
               ,[ObsCalidad]
               ,[MatCalidad]
               ,[NACalidad]
               ,[ObservCalidad]
               ,[UsuarioCalidad]
               ,[FechaModCalidad])
    SELECT [FechaMod]
    ,CASE WHEN [Operacion] = 'ALTA' THEN 'A' ELSE CASE WHEN [Operacion] = 'BAJA' THEN 'B' ELSE CASE WHEN [Operacion] = 'MODIFICACION' THEN 'M' ELSE '' END END END
    ,substring(M.[Usuario],1,10)
		    ,[ProductID]
          ,[ChekListID]
          ,M.[Item]
          ,[ChekListIDItemID]
	      ,CASE WHEN [Estado] = 1 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 2 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 3 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 4 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 5 THEN 'True' ELSE 'False' END 
	      ,[Observ]
          ,M.[Orden]
     	     ,substring(M.[Usuario],1,10)
		    ,[FechaMod]
			--, 'False','False','False','False','False'
		  ,CASE WHEN [Estado] = 1 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 2 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 3 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 4 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 5 THEN 'True' ELSE 'False' END 
			, null, null,null
       FROM IGC.[dbo].[IGC_CheckListsProdDet_LOG] M
       INNER JOIN Productos P ON P.IdProducto = M.ProductID COLLATE Modern_Spanish_100_CI_AS
	    INNER JOIN CalidadListasControlProductos CLCP ON CLCP.IdListaControl = M.ChekListID
	    AND CLCP.IdProducto = M.ProductID  COLLATE Modern_Spanish_100_CI_AS


INSERT INTO [dbo].[ProductosLinks]
           ([IdProducto]
           ,[ItemLink]
           ,[Descripcion]
           ,[Link])
 SELECT [ProductID]
      ,[ItemLink]
      ,[Descripcion]
      ,[Link]
  FROM IGC.[dbo].[IGC_ProductoLinks] M


   PRINT ''
    PRINT '1.4. Migrador Metalsur: Actualizar CalidadListasControlProductos.IdEstadoCalidad'
    UPDATE  LCP SET  LCP.IdEstadoCalidad = 4
    FROM CalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado = 1

	 UPDATE  LCP SET  LCP.IdEstadoCalidad = 4
    FROM AuditoriaCalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado = 1

    PRINT ''
    PRINT '1.5. Migrador Metalsur: Cambia a Terminado si no esta Entregado pero tiene ok de Calidad'
    UPDATE  LCP SET  LCP.IdEstadoCalidad = 4
    FROM CalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado = 0
    AND LCP.CincoSC = 'Ok'

	  UPDATE  LCP SET  LCP.IdEstadoCalidad = 4
    FROM AuditoriaCalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado = 0
    AND LCP.CincoSC = 'Ok'

    PRINT ''
    PRINT '1.6. Migrador Metalsur: Cambia a en proceso si no esta Entregado, no tiene ok de calidad y tiene algun check'
    UPDATE  LCP SET  LCP.IdEstadoCalidad = 2
    FROM CalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado <> 1
    AND LCP.CincoSC <> 'Ok' AND (LCPI.Ok = 'True' OR LCPI.NoOk = 'True' OR LCPI.Obs = 'True' OR LCPI.Mat = 'True')

	 UPDATE  LCP SET  LCP.IdEstadoCalidad = 2
    FROM AuditoriaCalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado <> 1
    AND LCP.CincoSC <> 'Ok' AND (LCPI.Ok = 'True' OR LCPI.NoOk = 'True' OR LCPI.Obs = 'True' OR LCPI.Mat = 'True')



	PRINT '1. Tabla CalidadEstadosListasControl: Carga inicial de tabla'
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (1, N'PENDIENTE',  1, 'False', 'True',  -32126)
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (2, N'EN PROCESO', 2, 'False', 'False',-107 )
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (3, N'CALIDAD',    3, 'False', 'False', -16744193)
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (4, N'TERMINADO',  4, 'True',  'False', -5308498)

END