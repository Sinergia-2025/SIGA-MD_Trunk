Imports System.Drawing
Imports Eniac.Entidades
Public Class CRMNovedades
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub CRMNovedades_I(fechaActualizacionWebSync As Date?,
                             idTipoNovedad As String,
                             letra As String,
                             centroEmisor As Short,
                             idNovedad As Long,
                             fechaNovedad As Date,
                             descripcion As String,
                             idPrioridadNovedad As Integer,
                             idCategoriaNovedad As Integer,
                             idEstadoNovedad As Integer,
                             fechaEstadoNovedad As Date,
                             idUsuarioEstadoNovedad As String,
                             fechaAlta As Date,
                             idUsuarioAlta As String,
                             idUsuarioAsignado As String,
                             avance As Decimal,
                             idMedioComunicacionNovedad As Integer,
                             idCliente As Long,
                             idProspecto As Long,
                             idFuncion As String,
                             idSistema As String,
                             fechaProximoContacto As Date?,
                             banderaColor As Color?,
                             interlocutor As String,
                             idMetodoResolucionNovedad As Integer,
                             idProveedor As Long,
                             idProyecto As Integer,
                             revisionAdministrativa As Boolean,
                             priorizado As Boolean,
                             idTipoNovedadPadre As String,
                             letraPadre As String,
                             centroEmisorPadre As Short,
                             idNovedadPadre As Long,
                             version As String,
                             versionFecha As Date?,
                             fechaInicioPlan As Date?,
                             fechaFinPlan As Date?,
                             tiempoEstimado As Decimal,
                             idUsuarioResponsable As String)
      CRMNovedades_I(fechaActualizacionWebSync,
                     idTipoNovedad,
                     letra,
                     centroEmisor,
                     idNovedad,
                     fechaNovedad,
                     descripcion,
                     idPrioridadNovedad,
                     idCategoriaNovedad,
                     idEstadoNovedad,
                     fechaEstadoNovedad,
                     idUsuarioEstadoNovedad,
                     fechaAlta,
                     idUsuarioAlta,
                     idUsuarioAsignado,
                     avance,
                     idMedioComunicacionNovedad,
                     idCliente,
                     idProspecto,
                     idFuncion,
                     idSistema,
                     fechaProximoContacto,
                     banderaColor,
                     interlocutor,
                     idMetodoResolucionNovedad,
                     idProveedor,
                     idProyecto,
                     revisionAdministrativa,
                     priorizado,
                     idTipoNovedadPadre,
                     letraPadre,
                     centroEmisorPadre,
                     idNovedadPadre,
                     version,
                     versionFecha,
                     fechaInicioPlan,
                     fechaFinPlan,
                     tiempoEstimado,
                     idUsuarioResponsable,
                     cantidad:=0, idSucursalService:=0, idTipoComprobanteService:=Nothing, letraService:=Nothing, centroEmisorService:=0, numeroComprobanteService:=0, idProducto:=Nothing, nombreProducto:=Nothing,
                     cantidadProducto:=0, 0, Nothing, 0, Nothing, False, 0, 0, 0, Nothing, String.Empty, nroDeSerie:=Nothing, tieneGarantiaService:=Nothing, ubicacionService:=Nothing, idSucursalFact:=Nothing,
                     idTipoComprobanteFact:=Nothing, letraFact:=Nothing, centroEmisorFact:=Nothing, numeroComprobanteFact:=Nothing, requiereTesteo:=False, fechaEntregado:=Nothing, fechaFinalizado:=Nothing,
                     idEstadoNovedadEntregado:=Nothing, idEstadoNovedadFinalizado:=Nothing, idUsuarioEntregado:=String.Empty, idUsuarioFinalizado:=String.Empty, idEstadoNovedadAnterior:=Nothing, avanceAnterior:=Nothing,
                     observacion:=Nothing, clienteValorizacionEstrellas:=Nothing, anticipoNovedad:=Nothing, retiroFechaHora:=Nothing, retiroDomicilio:=Nothing, entregaFechaHora:=Nothing,
                     entregaDomicilio:=Nothing, garantiaProveedor:=Nothing, garantiaFechaHoraEnvio:=Nothing, garantiaFechaHoraRetiro:=Nothing, idMarcaProducto:=Nothing, nombreMarcaProducto:=Nothing, idModeloProducto:=Nothing, nombreModeloProducto:=Nothing,
                     idSucursalNovedad:=Nothing, serviceLugarCompra:=String.Empty, serviceLugarCompraFecha:=Nothing, serviceLugarCompraTipoComprobante:=String.Empty, serviceLugarCompraNumeroComprobante:=String.Empty,
                     idAplicacionTerceros:=String.Empty, idMotivoNovedad:=0, comentarioPrincipal:=Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ninguno, patenteVehiculo:=String.Empty)
   End Sub

   Public Sub CRMNovedades_I(fechaActualizacionWebSync As Date?,
                             idTipoNovedad As String,
                             letra As String,
                             centroEmisor As Short,
                             idNovedad As Long,
                             fechaNovedad As Date,
                             descripcion As String,
                             idPrioridadNovedad As Integer,
                             idCategoriaNovedad As Integer,
                             idEstadoNovedad As Integer,
                             fechaEstadoNovedad As Date,
                             idUsuarioEstadoNovedad As String,
                             fechaAlta As Date,
                             idUsuarioAlta As String,
                             idUsuarioAsignado As String,
                             avance As Decimal,
                             idMedioComunicacionNovedad As Integer,
                             idCliente As Long,
                             idProspecto As Long,
                             idFuncion As String,
                             idSistema As String,
                             fechaProximoContacto As Date?,
                             banderaColor As Color?,
                             interlocutor As String,
                             idMetodoResolucionNovedad As Integer,
                             idProveedor As Long,
                             idProyecto As Integer,
                             revisionAdministrativa As Boolean,
                             priorizado As Boolean,
                             idTipoNovedadPadre As String,
                             letraPadre As String,
                             centroEmisorPadre As Short,
                             idNovedadPadre As Long,
                             version As String,
                             versionFecha As Date?,
                             fechaInicioPlan As Date?,
                             fechaFinPlan As Date?,
                             tiempoEstimado As Decimal,
                             idUsuarioResponsable As String,
                             cantidad As Decimal,
                             idSucursalService As Integer,
                             idTipoComprobanteService As String,
                             letraService As String,
                             centroEmisorService As Integer,
                             numeroComprobanteService As Long,
                             idProducto As String,
                             nombreProducto As String,
                             cantidadProducto As Decimal,
                             costoReparacion As Decimal,
                             idProductoPrestado As String,
                             cantidadProductoPrestado As Decimal,
                             nroSerieProductoPrestado As String,
                             productoPrestadoDevuelto As Boolean,
                             idProveedorService As Long,
                             contador1 As Integer,
                             contador2 As Integer,
                             idProductoNovedad As String,
                             etiquetaNovedad As String,
                             nroDeSerie As String,
                             tieneGarantiaService As Boolean?,
                             ubicacionService As String,
                             idSucursalFact As Integer?,
                             idTipoComprobanteFact As String,
                             letraFact As String,
                             centroEmisorFact As Integer?,
                             numeroComprobanteFact As Long?,
                             requiereTesteo As Boolean,
                             fechaEntregado As Date?,
                             fechaFinalizado As Date?,
                             idEstadoNovedadEntregado As Integer?,
                             idEstadoNovedadFinalizado As Integer?,
                             idUsuarioEntregado As String,
                             idUsuarioFinalizado As String,
                             idEstadoNovedadAnterior As Integer?,
                             avanceAnterior As Decimal?,
                             observacion As String,
                             clienteValorizacionEstrellas As Decimal?,
                             anticipoNovedad As Decimal?,
                             retiroFechaHora As Date?,
                             retiroDomicilio As Integer?,
                             entregaFechaHora As Date?,
                             entregaDomicilio As Integer?,
                             garantiaProveedor As Long?,
                             garantiaFechaHoraEnvio As Date?,
                             garantiaFechaHoraRetiro As Date?,
                             idMarcaProducto As Integer?,
                             nombreMarcaProducto As String,
                             idModeloProducto As Integer?,
                             nombreModeloProducto As String,
                             idSucursalNovedad As Integer?,
                             serviceLugarCompra As String,
                             serviceLugarCompraFecha As Date?,
                             serviceLugarCompraTipoComprobante As String,
                             serviceLugarCompraNumeroComprobante As String,
                             idAplicacionTerceros As String,
                             idMotivoNovedad As Integer,
                             comentarioPrincipal As Entidades.CRMNovedad.ComentarioPrincipalOptiones,
                             patenteVehiculo As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO CRMNovedades")
         .AppendFormatLine(" ({0} ", Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Letra.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Descripcion.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdPrioridadNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdCategoriaNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdEstadoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaAlta.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Avance.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdMedioComunicacionNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdCliente.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProspecto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdFuncion.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdSistema.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.BanderaColor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Interlocutor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProveedor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProyecto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.RevisionAdministrativa.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Priorizado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.LetraPadre.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Version.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.VersionFecha.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Cantidad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdSucursalService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdTipoComprobanteService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.LetraService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProducto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NombreProducto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CantidadProducto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CostoReparacion.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProductoPrestado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NroSerieProductoPrestado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ProductoPrestadoDevuelto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProveedorService.ToString())

         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Contador1.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Contador2.ToString())

         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.EtiquetaNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NroDeSerie.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.TieneGarantiaService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.UbicacionService.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdSucursalFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdTipoComprobanteFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.LetraFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.CentroEmisorFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NumeroComprobanteFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.RequiereTesteo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaEntregado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdEstadoNovedadEntregado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdEstadoNovedadFinalizado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdUsuarioEntregado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdUsuarioFinalizado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdEstadoNovedadAnterior.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.AvanceAnterior.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.Observacion.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ClienteValorizacionEstrellas.ToString())

         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.AnticipoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaHoraRetiro.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdDomicilioRetiro.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaHoraEntrega.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdDomicilioEntrega.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdProveedorGarantia.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaHoraEnvioGarantia.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.FechaHoraRetiroGarantia.ToString())
         '-- REQ-31825.- --
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.idMarcaProducto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NombreMarcaProducto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.idModeloProducto.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.NombreModeloProducto.ToString())
         '-- REQ-31656.- --
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdSucursalNovedad.ToString())
         '-----------------

         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ServiceLugarCompra.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ServiceLugarCompraFecha.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ServiceLugarCompraTipoComprobante.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ServiceLugarCompraNumeroComprobante.ToString())

         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdAplicacionTerceros.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.IdMotivoNovedad.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.ComentarioPrincipal.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.CRMNovedad.Columnas.PatenteVehiculo.ToString())

         .AppendLine(")")
         .AppendFormatLine(" VALUES")
         If Not fechaActualizacionWebSync.HasValue Then
            .AppendFormatLine(" (GETDATE()", Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString())
         Else
            .AppendFormatLine(" ('{1}'", Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionWebSync.Value, True, True))
         End If

         .AppendFormatLine(" ,'{0}'", idTipoNovedad)
         .AppendFormatLine(" ,'{0}'", letra)
         .AppendFormatLine(" , {0} ", centroEmisor)
         .AppendFormatLine(" , {0} ", idNovedad)
         .AppendFormatLine(" ,'{0}'", ObtenerFecha(fechaNovedad, True))
         .AppendFormatLine(" ,'{0}'", descripcion)
         .AppendFormatLine(" , {0} ", idPrioridadNovedad)
         .AppendFormatLine(" , {0} ", idCategoriaNovedad)
         .AppendFormatLine(" , {0} ", idEstadoNovedad)
         .AppendFormatLine(" ,'{0}'", ObtenerFecha(fechaEstadoNovedad, True))
         .AppendFormatLine(" ,'{0}'", idUsuarioEstadoNovedad)
         .AppendFormatLine(" ,'{0}'", ObtenerFecha(fechaAlta, True))
         .AppendFormatLine(" ,'{0}'", idUsuarioAlta)
         If Not String.IsNullOrWhiteSpace(idUsuarioAsignado) Then
            .AppendFormatLine(" ,'{0}'", idUsuarioAsignado)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idUsuarioResponsable) Then
            .AppendFormatLine(" ,'{0}'", idUsuarioResponsable)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" , {0} ", avance)
         .AppendFormatLine(" , {0} ", idMedioComunicacionNovedad)
         If idCliente > 0 Then
            .AppendFormatLine(" , {0}", idCliente)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idProspecto > 0 Then
            .AppendFormatLine(" , {0}", idProspecto)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine(" , '{0}'", idFuncion)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idSistema) Then
            .AppendFormatLine(" , '{0}'", idSistema)
         Else
            .AppendFormatLine(" , NULL")
         End If

         If fechaProximoContacto.HasValue Then
            .AppendFormatLine(" , '{0}'", ObtenerFecha(fechaProximoContacto.Value, True))
         Else
            .AppendFormatLine(" , NULL")
         End If
         If banderaColor.HasValue Then
            .AppendFormatLine(" ,  {0} ", banderaColor.Value.ToArgb())
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(interlocutor) Then
            .AppendFormatLine(" , '{0}'", interlocutor)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idMetodoResolucionNovedad > 0 Then
            .AppendFormatLine(" , {0}", idMetodoResolucionNovedad)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idProveedor > 0 Then
            .AppendFormatLine(" , {0}", idProveedor)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idProyecto > 0 Then
            .AppendFormatLine(" , {0}", idProyecto)
         Else
            .AppendFormatLine(" , NULL")
         End If
         .AppendFormatLine(" , '{0}'", Me.GetStringFromBoolean(revisionAdministrativa))
         .AppendFormatLine(" , '{0}'", Me.GetStringFromBoolean(priorizado))
         'para la novedad padre debo chequear que el IdNovedad no sea cero, sino automaticamente no le inserto nada
         If idNovedadPadre > 0 And Not String.IsNullOrEmpty(idTipoNovedadPadre) Then
            .AppendFormatLine(" , '{0}'", idTipoNovedadPadre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idNovedadPadre > 0 And Not String.IsNullOrEmpty(letraPadre) Then
            .AppendFormatLine(" , '{0}'", letraPadre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idNovedadPadre > 0 And centroEmisorPadre > 0 Then
            .AppendFormatLine(" , {0}", centroEmisorPadre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idNovedadPadre > 0 Then
            .AppendFormatLine(" , {0}", idNovedadPadre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(version) Then
            .AppendFormatLine(" , '{0}'", version)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If versionFecha.HasValue Then
            .AppendFormatLine(" , '{0}'", ObtenerFecha(versionFecha.Value, True))
         Else
            .AppendFormatLine(" , NULL")
         End If
         If fechaInicioPlan.HasValue Then
            .AppendFormatLine(" , '{0}'", ObtenerFecha(fechaInicioPlan.Value, True))
         Else
            .AppendFormatLine(" , NULL")
         End If
         If fechaFinPlan.HasValue Then
            .AppendFormatLine(" , '{0}'", ObtenerFecha(fechaFinPlan.Value, True))
         Else
            .AppendFormatLine(" , NULL")
         End If
         'tiempoEstimado
         .AppendFormatLine(" , {0}", tiempoEstimado)

         .AppendFormatLine(" , {0}", cantidad)
         If idSucursalService > 0 Then
            .AppendFormatLine(" , {0}", idSucursalService)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteService) Then
            .AppendFormatLine(" , '{0}'", idTipoComprobanteService)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(letraService) Then
            .AppendFormatLine(" , '{0}'", letraService)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If centroEmisorService > 0 Then
            .AppendFormatLine(" , {0}", centroEmisorService)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If numeroComprobanteService > 0 Then
            .AppendFormatLine(" , {0}", numeroComprobanteService)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine(" , '{0}'", idProducto)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(nombreProducto) Then
            .AppendFormatLine(" , '{0}'", nombreProducto)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If cantidadProducto > 0 Then
            .AppendFormatLine(" , {0}", cantidadProducto)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If costoReparacion > 0 Then
            .AppendFormatLine(" , {0}", costoReparacion)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idProductoPrestado) Then
            .AppendFormatLine(" , '{0}'", idProductoPrestado)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If cantidadProductoPrestado > 0 Then
            .AppendFormatLine(" , {0}", cantidadProductoPrestado)
         Else
            .AppendFormatLine(" , NULL")
         End If
         .AppendFormatLine(" , '{0}'", nroSerieProductoPrestado)
         .AppendFormatLine(" , '{0}'", GetStringFromBoolean(productoPrestadoDevuelto))
         If idProveedorService > 0 Then
            .AppendFormatLine(" , {0}", idProveedorService)
         Else
            .AppendFormatLine(" , NULL")
         End If

         .AppendFormatLine(" ,  {0} ", contador1)
         .AppendFormatLine(" ,  {0} ", contador2)
         If Not String.IsNullOrWhiteSpace(idProductoNovedad) Then
            .AppendFormatLine(" , '{0}'", idProductoNovedad)
         Else
            .AppendFormatLine(" , NULL")
         End If
         .AppendFormatLine(" , '{0}'", etiquetaNovedad)

         .AppendFormatLine(" ,{0}", If(Not String.IsNullOrEmpty(nroDeSerie), String.Format("'{0}'", nroDeSerie), "NULL"))
         .AppendFormatLine(" ,{0}", If(tieneGarantiaService.HasValue, String.Format("'{0}'", GetStringFromBoolean(tieneGarantiaService)), "NULL"))
         .AppendFormatLine(" ,{0}", If(Not String.IsNullOrEmpty(ubicacionService), String.Format("'{0}'", ubicacionService), "NULL"))

         '# Campos correspondientes a la venta facturada
         If idSucursalFact.HasValue AndAlso idSucursalFact.Value > 0 Then '# Suponiendo si la sucursal facturada viene con valor, toda la PK está con valor.
            .AppendFormatLine(" ,{0}", idSucursalFact.Value)
            .AppendFormatLine(" ,'{0}'", idTipoComprobanteFact)
            .AppendFormatLine(" ,'{0}'", letra)
            .AppendFormatLine(" ,{0}", centroEmisorFact.Value)
            .AppendFormatLine(" ,{0}", numeroComprobanteFact.Value)
         Else
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" ,  {0} ", GetStringFromBoolean(requiereTesteo))

         .AppendFormatLine(" ,  {0} ", ObtenerFecha(fechaEntregado, True))
         .AppendFormatLine(" ,  {0} ", ObtenerFecha(fechaFinalizado, True))
         .AppendFormatLine(" ,  {0} ", GetStringFromNumber(idEstadoNovedadEntregado))
         .AppendFormatLine(" ,  {0} ", GetStringFromNumber(idEstadoNovedadFinalizado))
         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(idUsuarioEntregado))
         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(idUsuarioFinalizado))

         If idEstadoNovedadAnterior.HasValue Then
            .AppendFormatLine(" , {0}", idEstadoNovedadAnterior.Value)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If avanceAnterior.HasValue Then
            .AppendFormatLine(" , {0}", avanceAnterior.Value)
         Else
            .AppendFormatLine(" , NULL")
         End If
         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(observacion))
         .AppendFormatLine(" ,  {0} ", GetStringFromDecimal(clienteValorizacionEstrellas))

         .AppendFormatLine(" ,  {0} ", anticipoNovedad)
         If retiroFechaHora.HasValue Then
            .AppendFormatLine(" ,'{0}'", retiroFechaHora)
            .AppendFormatLine(" , {0}", GetStringFromNumber(retiroDomicilio))
         Else
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
         End If
         If entregaFechaHora.HasValue Then
            .AppendFormatLine(" ,'{0}'", entregaFechaHora)
            .AppendFormatLine(" , {0}", GetStringFromNumber(entregaDomicilio))
         Else
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
         End If
         If garantiaProveedor.HasValue Then
            .AppendFormatLine(" , {0}", garantiaProveedor)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If garantiaFechaHoraEnvio.HasValue Then
            .AppendFormatLine(" ,'{0}'", garantiaFechaHoraEnvio)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If garantiaFechaHoraRetiro.HasValue Then
            .AppendFormatLine(" ,'{0}'", garantiaFechaHoraRetiro)
         Else
            .AppendFormatLine(" ,NULL")
         End If

         If idMarcaProducto.HasValue Then
            .AppendFormatLine(" , {0}", idMarcaProducto)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" , '{0}' ", nombreMarcaProducto)

         If idModeloProducto.HasValue Then
            .AppendFormatLine(" , {0} ", idModeloProducto)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" , '{0}' ", nombreModeloProducto)

         If idSucursalNovedad.HasValue Then
            .AppendFormatLine(" , '{0}' ", idSucursalNovedad)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" , '{0}'", serviceLugarCompra)
         .AppendFormatLine(" ,  {0} ", ObtenerFecha(serviceLugarCompraFecha, False))
         .AppendFormatLine(" , '{0}'", serviceLugarCompraTipoComprobante)
         .AppendFormatLine(" , '{0}'", serviceLugarCompraNumeroComprobante)

         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(idAplicacionTerceros))
         .AppendFormatLine(" ,  {0} ", GetStringFromNumber(idMotivoNovedad))
         .AppendFormatLine(" , '{0}'", comentarioPrincipal.ToString())
         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(patenteVehiculo))

         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMNovedades_U(fechaActualizacionWebSync As Date?,
                             idTipoNovedad As String,
                             letra As String,
                             centroEmisor As Short,
                             idNovedad As Long,
                             fechaNovedad As Date,
                             descripcion As String,
                             idPrioridadNovedad As Integer,
                             idCategoriaNovedad As Integer,
                             idEstadoNovedad As Integer,
                             fechaEstadoNovedad As Date,
                             idUsuarioEstadoNovedad As String,
                             fechaAlta As Date,
                             idUsuarioAlta As String,
                             idUsuarioAsignado As String,
                             avance As Decimal,
                             idMedioComunicacionNovedad As Integer,
                             idCliente As Long,
                             idProspecto As Long,
                             idFuncion As String,
                             idSistema As String,
                             fechaProximoContacto As Date?,
                             banderaColor As Color?,
                             interlocutor As String,
                             idMetodoResolucionNovedad As Integer,
                             idProveedor As Long,
                             idProyecto As Integer,
                             revisionAdministrativa As Boolean,
                             priorizado As Boolean,
                             idTipoNovedadPadre As String,
                             letraPadre As String,
                             centroEmisorPadre As Short,
                             idNovedadPadre As Long,
                             version As String,
                             versionFecha As Date?,
                             fechaInicioPlan As Date?,
                             fechaFinPlan As Date?,
                             tiempoEstimado As Decimal,
                             idUsuarioResponsable As String)
      CRMNovedades_U(fechaActualizacionWebSync,
                     idTipoNovedad,
                     letra,
                     centroEmisor,
                     idNovedad,
                     fechaNovedad,
                     descripcion,
                     idPrioridadNovedad,
                     idCategoriaNovedad,
                     idEstadoNovedad,
                     fechaEstadoNovedad,
                     idUsuarioEstadoNovedad,
                     fechaAlta,
                     idUsuarioAlta,
                     idUsuarioAsignado,
                     avance,
                     idMedioComunicacionNovedad,
                     idCliente,
                     idProspecto,
                     idFuncion,
                     idSistema,
                     fechaProximoContacto,
                     banderaColor,
                     interlocutor,
                     idMetodoResolucionNovedad,
                     idProveedor,
                     idProyecto,
                     revisionAdministrativa,
                     priorizado,
                     idTipoNovedadPadre,
                     letraPadre,
                     centroEmisorPadre,
                     idNovedadPadre,
                     version,
                     versionFecha,
                     fechaInicioPlan,
                     fechaFinPlan,
                     tiempoEstimado,
                     idUsuarioResponsable,
                     cantidad:=0, idSucursalService:=0, idTipoComprobanteService:=Nothing, letraService:=Nothing, centroEmisorService:=0, numeroComprobanteService:=0, idProducto:=Nothing, NombreProducto:=Nothing,
                     cantidadProducto:=0, 0, Nothing, 0, Nothing, False, 0, 0, 0, Nothing, String.Empty, nroDeSerie:=Nothing, tieneGarantiaService:=Nothing, ubicacionService:=Nothing, idSucursalFact:=Nothing,
                     idTipoComprobanteFact:=Nothing, letraFact:=Nothing, centroEmisorFact:=Nothing, numeroComprobanteFact:=Nothing, requiereTesteo:=False, fechaEntregado:=Nothing, fechaFinalizado:=Nothing,
                     idEstadoNovedadEntregado:=Nothing, idEstadoNovedadFinalizado:=Nothing, idUsuarioEntregado:=String.Empty, idUsuarioFinalizado:=String.Empty, idEstadoNovedadAnterior:=Nothing, avanceAnterior:=Nothing,
                     observacion:=Nothing, clienteValorizacionEstrellas:=Nothing, anticipoNovedad:=Nothing, retiroFechaHora:=Nothing, retiroDomicilio:=Nothing, entregaFechaHora:=Nothing,
                     entregaDomicilio:=Nothing, garantiaProveedor:=Nothing, garantiaFechaHoraEnvio:=Nothing, garantiaFechaHoraRetiro:=Nothing, idMarcaProducto:=Nothing, nombreMarcaProducto:=Nothing, idModeloProducto:=Nothing, nombreModeloProducto:=Nothing,
                     idSucursalNovedad:=Nothing, serviceLugarCompra:=String.Empty, serviceLugarCompraFecha:=Nothing, serviceLugarCompraTipoComprobante:=String.Empty, serviceLugarCompraNumeroComprobante:=String.Empty,
                     idAplicacionTerceros:=String.Empty, idMotivoNovedad:=0, comentarioPrincipal:=Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ninguno, patenteVehiculo:=String.Empty)

   End Sub
   Public Sub CRMNovedades_U(fechaActualizacionWebSync As Date?,
                             idTipoNovedad As String,
                             letra As String,
                             centroEmisor As Short,
                             idNovedad As Long,
                             fechaNovedad As Date,
                             descripcion As String,
                             idPrioridadNovedad As Integer,
                             idCategoriaNovedad As Integer,
                             idEstadoNovedad As Integer,
                             fechaEstadoNovedad As Date,
                             idUsuarioEstadoNovedad As String,
                             fechaAlta As Date,
                             idUsuarioAlta As String,
                             idUsuarioAsignado As String,
                             avance As Decimal,
                             idMedioComunicacionNovedad As Integer,
                             idCliente As Long,
                             idProspecto As Long,
                             idFuncion As String,
                             idSistema As String,
                             fechaProximoContacto As Date?,
                             banderaColor As Color?,
                             interlocutor As String,
                             idMetodoResolucionNovedad As Integer,
                             idProveedor As Long,
                             idProyecto As Integer,
                             revisionAdministrativa As Boolean,
                             priorizado As Boolean,
                             idTipoNovedadPadre As String,
                             letraPadre As String,
                             centroEmisorPadre As Short,
                             idNovedadPadre As Long,
                             version As String,
                             versionFecha As Date?,
                             fechaInicioPlan As Date?,
                             fechaFinPlan As Date?,
                             tiempoEstimado As Decimal,
                             idUsuarioResponsable As String,
                             cantidad As Decimal,
                             idSucursalService As Integer,
                             idTipoComprobanteService As String,
                             letraService As String,
                             centroEmisorService As Integer,
                             numeroComprobanteService As Long,
                             idProducto As String,
                             NombreProducto As String,
                             cantidadProducto As Decimal,
                             costoReparacion As Decimal,
                             idProductoPrestado As String,
                             cantidadProductoPrestado As Decimal,
                             nroSerieProductoPrestado As String,
                             productoPrestadoDevuelto As Boolean,
                             idProveedorService As Long,
                             contador1 As Integer,
                             contador2 As Integer,
                             idProductoNovedad As String,
                             etiquetaNovedad As String,
                             nroDeSerie As String,
                             tieneGarantiaService As Boolean?,
                             ubicacionService As String,
                             idSucursalFact As Integer?,
                             idTipoComprobanteFact As String,
                             letraFact As String,
                             centroEmisorFact As Integer?,
                             numeroComprobanteFact As Long?,
                             requiereTesteo As Boolean,
                             fechaEntregado As Date?,
                             fechaFinalizado As Date?,
                             idEstadoNovedadEntregado As Integer?,
                             idEstadoNovedadFinalizado As Integer?,
                             idUsuarioEntregado As String,
                             idUsuarioFinalizado As String,
                             idEstadoNovedadAnterior As Integer?,
                             avanceAnterior As Decimal?,
                             observacion As String,
                             clienteValorizacionEstrellas As Decimal?,
                             anticipoNovedad As Decimal?,
                             retiroFechaHora As Date?,
                             retiroDomicilio As Integer?,
                             entregaFechaHora As Date?,
                             entregaDomicilio As Integer?,
                             garantiaProveedor As Long?,
                             garantiaFechaHoraEnvio As Date?,
                             garantiaFechaHoraRetiro As Date?,
                             idMarcaProducto As Integer?,
                             nombreMarcaProducto As String,
                             idModeloProducto As Integer?,
                             nombreModeloProducto As String,
                             idSucursalNovedad As Integer?,
                             serviceLugarCompra As String,
                             serviceLugarCompraFecha As Date?,
                             serviceLugarCompraTipoComprobante As String,
                             serviceLugarCompraNumeroComprobante As String,
                             idAplicacionTerceros As String,
                             idMotivoNovedad As Integer,
                             comentarioPrincipal As Entidades.CRMNovedad.ComentarioPrincipalOptiones,
                             patenteVehiculo As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CRMNovedades ")

         If Not fechaActualizacionWebSync.HasValue Then
            .AppendFormatLine("   SET {0} = GETDATE()", Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString())
         Else
            .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionWebSync.Value, True, True))
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaNovedad.ToString(), ObtenerFecha(fechaNovedad, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.Descripcion.ToString(), descripcion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdPrioridadNovedad.ToString(), idPrioridadNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdCategoriaNovedad.ToString(), idCategoriaNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdEstadoNovedad.ToString(), idEstadoNovedad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString(), ObtenerFecha(fechaEstadoNovedad, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString(), idUsuarioEstadoNovedad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaAlta.ToString(), ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         If Not String.IsNullOrWhiteSpace(idUsuarioAsignado) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString(), idUsuarioAsignado)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(idUsuarioResponsable) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString(), idUsuarioResponsable)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString())
         End If
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.Avance.ToString(), avance)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdMedioComunicacionNovedad.ToString(), idMedioComunicacionNovedad)
         If idCliente > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdCliente.ToString(), idCliente)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdCliente.ToString())
         End If
         If idProspecto > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdProspecto.ToString(), idProspecto)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdProspecto.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdFuncion.ToString(), idFuncion)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdFuncion.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(idSistema) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdSistema.ToString(), idSistema)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdSistema.ToString())
         End If

         If fechaProximoContacto.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString(), ObtenerFecha(fechaProximoContacto.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString())
         End If
         If banderaColor.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.BanderaColor.ToString(), banderaColor.Value.ToArgb())
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.BanderaColor.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(interlocutor) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.Interlocutor.ToString(), interlocutor)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.Interlocutor.ToString())
         End If
         If idMetodoResolucionNovedad > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString(), idMetodoResolucionNovedad)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString())
         End If
         If idProveedor > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdProveedor.ToString(), idProveedor)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdProveedor.ToString())
         End If
         If idProyecto > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdProyecto.ToString(), idProyecto)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdProyecto.ToString())
         End If
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.RevisionAdministrativa.ToString(), Me.GetStringFromBoolean(revisionAdministrativa))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.Priorizado.ToString(), Me.GetStringFromBoolean(priorizado))
         'para la novedad padre debo chequear que el IdNovedad no sea cero, sino automaticamente no le inserto nada
         If idNovedadPadre > 0 And Not String.IsNullOrWhiteSpace(idTipoNovedadPadre) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString(), idTipoNovedadPadre)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString())
         End If
         If idNovedadPadre > 0 And Not String.IsNullOrWhiteSpace(letraPadre) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.LetraPadre.ToString(), letraPadre)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.LetraPadre.ToString())
         End If
         If idNovedadPadre > 0 And centroEmisorPadre > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString(), centroEmisorPadre)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString())
         End If
         If idNovedadPadre > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString(), idNovedadPadre)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(version) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.Version.ToString(), version)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.Version.ToString())
         End If
         If versionFecha.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.VersionFecha.ToString(), ObtenerFecha(versionFecha.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.VersionFecha.ToString())
         End If
         If fechaInicioPlan.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString(), ObtenerFecha(fechaInicioPlan.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString())
         End If
         If fechaFinPlan.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString(), ObtenerFecha(fechaFinPlan.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString())
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString(), tiempoEstimado)

         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdSucursalService.ToString(), idSucursalService)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoComprobanteService.ToString(), idTipoComprobanteService)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.LetraService.ToString(), letraService)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString(), centroEmisorService)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString(), numeroComprobanteService)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.NombreProducto.ToString(), NombreProducto)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.CantidadProducto.ToString(), cantidadProducto)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.CostoReparacion.ToString(), costoReparacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdProductoPrestado.ToString(), idProductoPrestado)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString(), cantidadProductoPrestado)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.NroSerieProductoPrestado.ToString(), nroSerieProductoPrestado)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.ProductoPrestadoDevuelto.ToString(), Me.GetStringFromBoolean(productoPrestadoDevuelto))
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdProveedorService.ToString(), idProveedorService)

         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.Contador1.ToString(), contador1)
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.Contador2.ToString(), contador2)

         If Not String.IsNullOrWhiteSpace(idProductoNovedad) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString(), idProductoNovedad)
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString())
         End If

         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.EtiquetaNovedad.ToString(), etiquetaNovedad)

         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.NroDeSerie.ToString(), If(Not String.IsNullOrEmpty(nroDeSerie), String.Format("'{0}'", nroDeSerie), "NULL"))

         If tieneGarantiaService.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.TieneGarantiaService.ToString(), tieneGarantiaService.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.TieneGarantiaService.ToString())
         End If
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.UbicacionService.ToString(), If(Not String.IsNullOrEmpty(ubicacionService), String.Format("'{0}'", ubicacionService), "NULL"))


         '# Campos correspondientes a la venta facturada
         If idSucursalFact.HasValue AndAlso idSucursalFact.Value > 0 Then '# Suponiendo si la sucursal facturada viene con valor, toda la PK está con valor.
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdSucursalFact.ToString(), idSucursalFact.Value)
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoComprobanteFact.ToString(), idTipoComprobanteFact)
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.LetraFact.ToString(), letraFact)
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.CentroEmisorFact.ToString(), centroEmisorFact.Value)
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.NumeroComprobanteFact.ToString(), numeroComprobanteFact.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdSucursalFact.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdTipoComprobanteFact.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.LetraFact.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.CentroEmisorFact.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.NumeroComprobanteFact.ToString())
         End If
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.RequiereTesteo.ToString(), GetStringFromBoolean(requiereTesteo))

         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.FechaEntregado.ToString(), ObtenerFecha(fechaEntregado, True))
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString(), ObtenerFecha(fechaFinalizado, True))

         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdEstadoNovedadEntregado.ToString(), GetStringFromNumber(idEstadoNovedadEntregado))
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdEstadoNovedadFinalizado.ToString(), GetStringFromNumber(idEstadoNovedadFinalizado))

         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdUsuarioEntregado.ToString(), GetStringParaQueryConComillas(idUsuarioEntregado))
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdUsuarioFinalizado.ToString(), GetStringParaQueryConComillas(idUsuarioFinalizado))

         If idEstadoNovedadAnterior.HasValue Then
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdEstadoNovedadAnterior.ToString(), idEstadoNovedadAnterior.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdEstadoNovedadAnterior.ToString())
         End If
         If avanceAnterior.HasValue Then
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.AvanceAnterior.ToString(), avanceAnterior.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.AvanceAnterior.ToString())
         End If
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.Observacion.ToString(), GetStringParaQueryConComillas(observacion))
         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.ClienteValorizacionEstrellas.ToString(), GetStringFromDecimal(clienteValorizacionEstrellas))

         .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.AnticipoNovedad.ToString(), anticipoNovedad.Value)

         If retiroFechaHora.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaHoraRetiro.ToString(), ObtenerFecha(retiroFechaHora.Value, True))
            If retiroDomicilio Is Nothing Then
               .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdDomicilioRetiro.ToString())
            Else
               .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdDomicilioRetiro.ToString(), retiroDomicilio)
            End If
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.FechaHoraRetiro.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdDomicilioRetiro.ToString())
         End If
         If entregaFechaHora.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaHoraEntrega.ToString(), ObtenerFecha(entregaFechaHora.Value, True))
            If entregaDomicilio Is Nothing Then
               .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdDomicilioEntrega.ToString())
            Else
               .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdDomicilioEntrega.ToString(), entregaDomicilio)
            End If
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.FechaHoraEntrega.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdDomicilioEntrega.ToString())
         End If
         If garantiaProveedor.HasValue Then
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdProveedorGarantia.ToString(), garantiaProveedor)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdProveedorGarantia.ToString())
         End If
         If garantiaFechaHoraEnvio.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaHoraEnvioGarantia.ToString(), ObtenerFecha(garantiaFechaHoraEnvio.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.FechaHoraEnvioGarantia.ToString())
         End If
         If garantiaFechaHoraRetiro.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.FechaHoraRetiroGarantia.ToString(), ObtenerFecha(garantiaFechaHoraRetiro.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.FechaHoraRetiroGarantia.ToString())
         End If
         '-- REQ-31825.- --
         If idMarcaProducto.HasValue Then
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.idMarcaProducto.ToString(), idMarcaProducto)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.idMarcaProducto.ToString())
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.NombreMarcaProducto.ToString(), nombreMarcaProducto)

         If idModeloProducto.HasValue Then
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.idModeloProducto.ToString(), idModeloProducto.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.idModeloProducto.ToString())
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.NombreModeloProducto.ToString(), nombreModeloProducto)

         '-- REQ-31825.- --
         If idSucursalNovedad.HasValue Then
            .AppendFormatLine("     , {0} = {1}", Entidades.CRMNovedad.Columnas.IdSucursalNovedad.ToString(), idSucursalNovedad.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedad.Columnas.IdSucursalNovedad.ToString())
         End If

         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.ServiceLugarCompra.ToString(), serviceLugarCompra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.ServiceLugarCompraFecha.ToString(), ObtenerFecha(serviceLugarCompraFecha, False))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.ServiceLugarCompraTipoComprobante.ToString(), serviceLugarCompraTipoComprobante)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.ServiceLugarCompraNumeroComprobante.ToString(), serviceLugarCompraNumeroComprobante)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdAplicacionTerceros.ToString(), GetStringParaQueryConComillas(idAplicacionTerceros))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdMotivoNovedad.ToString(), GetStringFromNumber(idMotivoNovedad))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedad.Columnas.ComentarioPrincipal.ToString(), comentarioPrincipal.ToString())

         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedad)

      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMNovedades_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMNovedades")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormat("   AND {0} = '{1}'", Entidades.CRMNovedad.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND {0} =  {1} ", Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND {0} =  {1} ", Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedad)
      End With

      Execute(myQuery)
   End Sub

   Protected Overridable Sub SelectTexto(stb As StringBuilder, esAuditoria As Boolean, Optional campoCalculado As String = "")
      SelectTexto(stb, esAuditoria,
                  Function(stb1)
                     If Not String.IsNullOrWhiteSpace(campoCalculado) Then
                        stb1.AppendFormatLine(campoCalculado)
                     End If
                     Return stb1
                  End Function,
                  Nothing)

   End Sub

   Protected Overridable Sub SelectTextoCambioEstado(stb As StringBuilder, esAuditoria As Boolean, embarcacion As Boolean, Optional campoCalculado As String = "")
      SelectTexto(stb, esAuditoria:=False,
                  Function(stb1)
                     If embarcacion Then
                        stb1.AppendFormatLine(" , EMB.NombreEmbarcacion")
                     End If
                     stb1.AppendFormatLine(" , ESTA.IdEstadoNovedad IdEstadoCambioEstado")
                     stb1.AppendFormatLine(" , ESTADOS.NombreEstadoNovedad AS NombreEstadoCambioEstado ")
                     stb1.AppendFormatLine(" , ESTADOS.Color ColorEstadoCambioEstado ")

                     stb1.AppendFormatLine(" , ESTA.FechaCambioEstado ")
                     stb1.AppendFormatLine(" , CONVERT(DATE, ESTA.FechaCambioEstado) AS FechaCambioEstado_Fecha")
                     stb1.AppendFormatLine(" , CONVERT(VARCHAR(5), ESTA.FechaCambioEstado, 108) AS FechaCambioEstado_Hora")
                     stb1.AppendFormatLine(" , ESTA.IdUsuario AS UsuarioCambioEstado ")
                     stb1.AppendFormatLine(" , ESTA.IdUsuarioAsignado as UsuarioAsignadoCambioEstado ")

                     Return stb1
                  End Function,
                  Function(stb1)
                     If embarcacion Then
                        stb1.AppendFormatLine(" INNER JOIN Embarcaciones AS EMB ON EMB.IdEmbarcacion = N.IdEmbarcacion")
                     End If
                     stb1.AppendFormatLine(" INNER JOIN CRMNovedadesCambiosEstados AS ESTA ON ESTA.IdTipoNovedad = N.IdTipoNovedad and ESTA.Letra = N.Letra and ESTA.CentroEmisor = N.CentroEmisor and ESTA.IdNovedad = N.IdNovedad")
                     stb1.AppendFormatLine(" INNER JOIN CRMEstadosNovedades AS ESTADOS ON ESTADOS.IdTipoNovedad = ESTA.IdTipoNovedad and ESTADOS.IdEstadoNovedad = ESTA.IdEstadoNovedad")

                     Return stb1
                  End Function)

   End Sub


   Public Shared Sub SelectTexto(stb As StringBuilder, esAuditoria As Boolean,
                                agregaCampos As Func(Of StringBuilder, StringBuilder),
                                agregaJoin As Func(Of StringBuilder, StringBuilder))
      With stb
         .AppendFormatLine("SELECT  N.* ")

         If agregaCampos IsNot Nothing Then
            agregaCampos(stb)
         End If
         '.AppendFormatLine(campoCalculado)

         .AppendFormatLine(" , ISNULL(NSPr.Comentario, '') ComentarioSeguimientoPrincipal")

         .AppendFormatLine(" , CONVERT(DATE, N.FechaNovedad) AS FechaNovedad_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaNovedad, 108) AS FechaNovedad_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.FechaEstadoNovedad) AS FechaEstadoNovedad_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaEstadoNovedad, 108) AS FechaEstadoNovedad_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.FechaProximoContacto) AS FechaProximoContacto_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaProximoContacto, 108) AS FechaProximoContacto_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.FechaAlta) AS FechaAlta_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaAlta, 108) AS FechaAlta_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.FechaInicioPlan) AS FechaInicioPlan_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaInicioPlan, 108) AS FechaInicioPlan_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.FechaFinPlan) AS FechaFinPlan_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaFinPlan, 108) AS FechaFinPlan_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.VersionFecha) AS VersionFecha_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.VersionFecha, 108) AS VersionFecha_Hora")

         .AppendFormatLine(" , CONVERT(DATE, N.FechaEntregado) AS FechaEntregado_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaEntregado, 108) AS FechaEntregado_Hora")
         .AppendFormatLine(" , CONVERT(DATE, N.FechaFinalizado) AS FechaFinalizado_Fecha")
         .AppendFormatLine(" , CONVERT(VARCHAR(5), N.FechaFinalizado, 108) AS FechaFinalizado_Hora")

         .AppendFormatLine(" , TN.NombreTipoNovedad")
         .AppendFormatLine(" , PN.NombrePrioridadNovedad")
         .AppendFormatLine(" , CN.NombreCategoriaNovedad")
         .AppendFormatLine(" , CN.Reporta AS Reporta")
         .AppendFormatLine(" , CN.Color AS ColorCategoria")
         .AppendFormatLine(" , EN.NombreEstadoNovedad")
         .AppendFormatLine(" , EN.Finalizado")
         .AppendFormatLine(" , EN.Color AS ColorEstado")

         .AppendFormatLine(" , ENE.NombreEstadoNovedad NombreEstadoNovedadEntregado")
         .AppendFormatLine(" , ENE.Finalizado FinalizadoEntregado")
         .AppendFormatLine(" , ENE.Color AS ColorEstadoEntregado")
         .AppendFormatLine(" , ENF.NombreEstadoNovedad NombreEstadoNovedadFinalizado")
         .AppendFormatLine(" , ENF.Finalizado FinalizadoFinalizado")
         .AppendFormatLine(" , ENF.Color AS ColorEstadoFinalizado")

         .AppendFormatLine(" , PNP.NombrePrioridadNovedad AS NombrePrioridadNovedadPadre")
         .AppendFormatLine(" , CNP.NombreCategoriaNovedad AS NombreCategoriaNovedadPadre")
         .AppendFormatLine(" , CNP.Color                  AS ColorCategoriaPadre")
         .AppendFormatLine(" , ENP.NombreEstadoNovedad    AS NombreEstadoNovedadPadre")
         .AppendFormatLine(" , ENP.Finalizado             AS FinalizadoPadre")
         .AppendFormatLine(" , ENP.Color                  AS ColorEstadoPadre")
         .AppendFormatLine(" , NP.Descripcion DescripcionPadre")

         .AppendFormatLine(" , MN.NombreMedioComunicacionNovedad")
         .AppendFormatLine(" , MN.Color AS ColorMedio")
         .AppendFormatLine(" , MRN.NombreMetodoResolucionNovedad")
         .AppendFormatLine(" , C.CodigoCliente")
         .AppendFormatLine(" , C.NombreCliente")
         .AppendFormatLine(" , C.NombreDeFantasia")
         .AppendFormatLine(" , CATC.NombreCategoria AS NombreCategoriaCliente")
         .AppendFormatLine(" , TIPOC.NombreTipoCliente")
         .AppendFormatLine(" , C.IdZonaGeografica")
         .AppendFormatLine(" , C.ActualizadorFunciona")
         .AppendFormatLine(" , Z.NombreZonaGeografica")

         .AppendFormatLine(" , P.CodigoProspecto")
         .AppendFormatLine(" , P.NombreProspecto")
         .AppendFormatLine(" , P.NombreDeFantasia AS NombreDeFantasiaProspecto")
         .AppendFormatLine(" , CATP.NombreCategoria AS NombreCategoriaProspecto")
         .AppendFormatLine(" , TIPOP.NombreTipoCliente AS NombreTipoProspecto")

         .AppendFormatLine(" , PR.CodigoProveedor")
         .AppendFormatLine(" , PR.NombreProveedor")
         .AppendFormatLine(" , CATPR.NombreCategoria AS NombreCategoriaProveedor")

         .AppendFormatLine(" , P.CantidadDePCs CantidadDePCsProspecto")
         .AppendFormatLine(" , P.CantidadMovil CantidadMovilProspecto")

         .AppendFormatLine(" , PRO.IdProyecto")
         .AppendFormatLine(" , PRO.NombreProyecto")
         .AppendFormatLine(" , PRO.IdPrioridadProyecto")
         .AppendFormatLine(" , PRO.IdEstado")
         .AppendFormatLine(" , PROE.NombreEstado")
         .AppendFormatLine(" , PRO.IdClasificacion")
         .AppendFormatLine(" , CL.NombreClasificacion")
         .AppendFormatLine(" , UE.Nombre AS NombreUsuarioEstadoNovedad")
         .AppendFormatLine(" , UA.Nombre AS NombreUsuarioAlta")
         .AppendFormatLine(" , UG.Nombre AS NombreUsuarioAsignado")
         .AppendFormatLine(" , UR.Nombre AS NombreUsuarioResponsable")
         '-- REQ-35844.- --------------------------------------
         .AppendFormatLine(" , SUC.Nombre AS NombreSucursalNovedad")
         '-----------------------------------------------------
         .AppendFormatLine(" , F.Nombre AS NombreFuncion")
         .AppendFormatLine(" , (CASE WHEN FP.Nombre IS NULL THEN  F.Nombre ELSE FP.Nombre END) AS NombrePadre")

         .AppendFormatLine(" , CASE WHEN EN.Finalizado = 0 THEN NULL ELSE ")
         .AppendFormatLine("       CONVERT(VARCHAR(4),(CONVERT(INT, ROUND(CONVERT(decimal(20,10), N.FechaEstadoNovedad - N.FechaNovedad),0,1)) * 24)")
         .AppendFormatLine("           + DATEPART(hh, N.FechaEstadoNovedad - N.FechaNovedad))")
         .AppendFormatLine("           + ':' + RIGHT('00' + CONVERT(VARCHAR(2), DATEPART(mi, N.FechaEstadoNovedad - N.FechaNovedad)), 2)")
         .AppendFormatLine("           + ':' + RIGHT('00' + CONVERT(VARCHAR(2), DATEPART(ss, N.FechaEstadoNovedad - N.FechaNovedad)), 2) END AS HorasFinalizacion")

         .AppendFormatLine(" , (CASE WHEN N.NombreProducto IS NULL THEN  P1.NombreProducto ELSE N.NombreProducto END) AS NombreProducto")

         '.AppendFormatLine("   ,P1.NombreProducto AS NombreProducto ")
         .AppendFormatLine("   ,M1.NombreMarca AS NombreMarcaService")
         .AppendFormatLine("   ,Mo1.NombreModelo AS NombreModeloService")
         .AppendFormatLine("   ,P2.NombreProducto AS NombreProductoPrestado ")
         .AppendFormatLine("   ,N.IdProveedorService  ")
         .AppendFormatLine("   ,PR1.CodigoProveedor AS CodigoProveedorService")
         .AppendFormatLine("   ,PR1.NombreProveedor AS NombreProveedorService ")
         .AppendFormatLine("   ,P3.NombreProducto AS NombreProductoCalidad ")
         .AppendFormatLine(" ,ISNULL((SELECT SUM(H.Cantidad)")
         .AppendFormatLine("            FROM CRMNovedades H")
         .AppendFormatLine("           WHERE H.IdTipoNovedadPadre = N.IdTIpoNovedad")
         .AppendFormatLine("             AND H.LetraPadre         = N.Letra")
         .AppendFormatLine("             AND H.CentroEmisorPadre  = N.CentroEmisor")
         .AppendFormatLine("             AND H.IdNovedadPadre     = N.IdNovedad), 0) CantidadHorasHijos")
         .AppendFormatLine("   ,TN.Reporte")
         .AppendFormatLine("   ,TN.Embebido")

         '# Campos correspondientes a la facturación de la novedad
         .AppendFormatLine("   ,ISNULL(N.ClienteValorizacionEstrellas, C.ValorizacionEstrellas) ClienteValorizacionEstrellasResuelto")
         .AppendFormatLine("   ,CONVERT(DECIMAL(5,2), ")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'TICKETS' AND PNP.Posicion = 1 THEN 1 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'TICKETS' AND PNP.Posicion = 2 THEN 2 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'REQUER'  AND PRO.IdPrioridadProyecto = 1 THEN 3 + CONVERT(DECIMAL(5,2), ISNULL(PNP.Posicion, 99)) / 100 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'TICKETS' AND PNP.Posicion = 3 THEN 4 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'REQUER'  AND PRO.IdPrioridadProyecto > 1 AND PRO.IdPrioridadProyecto <= 2 THEN 5 + CONVERT(DECIMAL(5,2), ISNULL(PNP.Posicion, 99)) / 100 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'TICKETS' AND PNP.Posicion = 4 THEN 6 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'REQUER'  AND PRO.IdPrioridadProyecto > 2 THEN 7 + CONVERT(DECIMAL(5,2), ISNULL(PNP.Posicion, 99)) / 100 ELSE")
         .AppendFormatLine("    CASE WHEN N.IdTipoNovedadPadre = 'TICKETS' AND PNP.Posicion > 4 THEN 8")
         .AppendFormatLine("    ELSE 9 END END END END END END END END) PrioridadParaPriorizar")

         .AppendFormatLine("   ,MtN.NombreMotivoNovedad")
         .AppendFormatLine("   ,A3.NombreAplicacion NombreAplicacionTerceros")

         .AppendFormatLine("   , MaVh.IdMarcaVehiculo")
         .AppendFormatLine("   , MaVh.NombreMarcaVehiculo")
         .AppendFormatLine("   , MoVh.IdModeloVehiculo")
         .AppendFormatLine("   , MoVh.NombreModeloVehiculo")
         .AppendFormatLine("   , Vh.AnioPatentamiento")
         .AppendFormatLine("   , Vh.Color AS ColorVehiculo")

         .AppendFormatLine("  FROM {0}CRMNovedades AS N", If(esAuditoria, "Auditoria", Nothing))

         .AppendFormatLine(" INNER JOIN CRMTiposNovedades AS TN ON TN.IdTipoNovedad = N.IdTipoNovedad")

         .AppendFormatLine("  LEFT JOIN CRMNovedadesSeguimiento AS NSPr", If(esAuditoria, "Auditoria", Nothing))
         .AppendFormatLine("         ON NSPr.IdTipoNovedad = N.IdTipoNovedad")
         .AppendFormatLine("        AND NSPr.Letra = N.Letra")
         .AppendFormatLine("        AND NSPr.CentroEmisor = N.CentroEmisor")
         .AppendFormatLine("        AND NSPr.IdNovedad = N.IdNovedad")
         .AppendFormatLine("        AND NSPr.ComentarioPrincipal = 'True'")

         If agregaJoin IsNot Nothing Then
            agregaJoin(stb)
         End If

         .AppendFormatLine("  LEFT JOIN CRMPrioridadesNovedades AS PN ON PN.IdPrioridadNovedad = N.IdPrioridadNovedad")
         .AppendFormatLine("  LEFT JOIN CRMCategoriasNovedades AS CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad")

         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS ENE ON ENE.IdEstadoNovedad = N.IdEstadoNovedadEntregado")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS ENF ON ENF.IdEstadoNovedad = N.IdEstadoNovedadFinalizado")

         .AppendFormatLine("  LEFT JOIN CRMMediosComunicacionesNovedades AS MN ON MN.IdMedioComunicacionNovedad = N.IdMedioComunicacionNovedad")
         .AppendFormatLine("  LEFT JOIN CRMMetodosResolucionesNovedades AS MRN ON MRN.IdMetodoResolucionNovedad = N.IdMetodoResolucionNovedad")

         .AppendFormatLine("  LEFT JOIN CRMMotivosNovedades AS MtN ON MtN.IdMotivoNovedad = N.IdMotivoNovedad")
         .AppendFormatLine("  LEFT JOIN Aplicaciones AS A3 ON A3.IdAplicacion = N.IdAplicacionTerceros")

         .AppendFormatLine("  LEFT JOIN Vehiculos Vh ON Vh.PatenteVehiculo = N.PatenteVehiculo")
         .AppendFormatLine("  LEFT JOIN MarcasVehiculos MaVh ON MaVh.IdMarcaVehiculo = Vh.IdMarcaVehiculo")
         .AppendFormatLine("  LEFT JOIN ModelosVehiculos MoVh ON MoVh.IdModeloVehiculo = Vh.IdModeloVehiculo")

         .AppendFormatLine("  LEFT JOIN Clientes AS C ON C.IdCliente = N.IdCliente")
         .AppendFormatLine("  LEFT JOIN ZonasGeograficas Z  ON Z.IdZonaGeografica = C.IdZonaGeografica ")
         .AppendFormatLine("  LEFT JOIN Categorias AS CATC ON CATC.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  LEFT JOIN TiposClientes AS TIPOC ON TIPOC.IdTipoCliente = C.IdTipoCliente")

         .AppendFormatLine("  LEFT JOIN Prospectos AS P ON P.IdProspecto = N.IdProspecto")
         .AppendFormatLine("  LEFT JOIN Categorias AS CATP ON CATP.IdCategoria = P.IdCategoria")
         .AppendFormatLine("  LEFT JOIN TiposClientes AS TIPOP ON TIPOP.IdTipoCliente = P.IdTipoCliente")

         .AppendFormatLine("  LEFT JOIN Proveedores AS PR ON PR.IdProveedor = N.IdProveedor")
         .AppendFormatLine("  LEFT JOIN CategoriasProveedores AS CATPR ON CATPR.IdCategoria = PR.IdCategoria")

         .AppendFormatLine("  LEFT JOIN Usuarios AS UE ON UE.Id = N.IdUsuarioEstadoNovedad")
         .AppendFormatLine("  LEFT JOIN Usuarios AS UA ON UA.Id = N.IdUsuarioAlta")
         .AppendFormatLine("  LEFT JOIN Usuarios AS UG ON UG.Id = N.IdUsuarioAsignado")
         .AppendFormatLine("  LEFT JOIN Usuarios AS UR ON UR.Id = N.IdUsuarioResponsable")
         .AppendFormatLine("  LEFT JOIN Funciones AS F ON F.Id = N.IdFuncion")
         .AppendFormatLine("  LEFT JOIN Funciones AS FP ON FP.Id = F.IdPadre")
         .AppendFormatLine("  LEFT JOIN Proyectos AS PRO ON PRO.IdProyecto = N.IdProyecto")
         .AppendFormatLine("  LEFT JOIN ProyectosEstados AS PROE ON PRO.IdEstado = PROE.IdEstado")
         .AppendFormatLine("  LEFT JOIN Clasificaciones AS CL ON PRO.IdClasificacion = CL.IdClasificacion")
         .AppendFormatLine("  LEFT JOIN Productos AS P1 ON P1.IdProducto = N.IdProducto")
         .AppendFormatLine("  LEFT JOIN Marcas AS M1 ON M1.IdMarca = P1.IdMarca")
         .AppendFormatLine("  LEFT JOIN Modelos AS Mo1 ON Mo1.IdModelo = P1.IdModelo")
         .AppendFormatLine("  LEFT JOIN Productos AS P2 ON P2.IdProducto = N.IdProductoPrestado ")
         .AppendFormatLine("  LEFT JOIN Proveedores AS PR1 ON PR1.IdProveedor = N.IdProveedorService ")
         .AppendFormatLine("  LEFT JOIN Productos AS P3 ON P3.IdProducto = N.IdProductoNovedad")

         .AppendFormatLine("  LEFT JOIN CRMNovedades AS NP ON NP.IdTipoNovedad = N.IdTipoNovedadPadre AND NP.Letra = N.LetraPadre AND NP.CentroEmisor = N.CentroEmisorPadre AND NP.IdNovedad = N.IdNovedadPadre")
         .AppendFormatLine("  LEFT JOIN CRMPrioridadesNovedades AS PNP ON PNP.IdPrioridadNovedad = NP.IdPrioridadNovedad")
         .AppendFormatLine("  LEFT JOIN CRMCategoriasNovedades AS CNP ON CNP.IdCategoriaNovedad = NP.IdCategoriaNovedad")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS ENP ON ENP.IdEstadoNovedad = NP.IdEstadoNovedad")
         '--REQ-35844.- --------------
         .AppendFormatLine("  LEFT JOIN Sucursales AS SUC ON N.IdSucursalNovedad = SUC.IdSucursal")
         '----------------------------
         'AgregarJoins(stb)

      End With
   End Sub


   Public Function CRMNovedades_Sync(fechaActualizacionDesde As Date?) As DataTable
      Return CRMNovedades_GetNovedades(desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad,
                                       idTipoNovedad:=String.Empty, buscarABM:=Nothing,
                                        CategoriasNovedades:=Nothing, EstadosNovedades:=Nothing,
                                       MedioNovedades:=Nothing, MetodoNovedades:=Nothing, idUsuarioAsignado:=String.Empty,
                                       idNovedad:=0, idNovedadPadre:=0, idCliente:=0, idProspecto:=0, idProveedor:=0, idPrioridadNovedad:=0,
                                       idUsuarioAlta:=String.Empty, finalizado:="TODOS", idProyecto:=0,
                                       revisionAdministrativa:=Entidades.Publicos.SiNoTodos.TODOS, idAplicacion:=String.Empty, nroVersion:=String.Empty, descripcion:=String.Empty,
                                       priorizado:=Entidades.Publicos.SiNoTodos.TODOS, ordenamiento:=String.Empty, idFuncion:=String.Empty,
                                       fechaActualizacionDesde:=fechaActualizacionDesde, prioridadDelProyectoDesde:=0, prioridadDelProyectoHasta:=0, estadoDelProyecto:=0, clasificacionDelProyecto:=0,
                                       enGarantia:=Entidades.Publicos.SiNoTodos.TODOS, enPrestamo:=Entidades.Publicos.SiNoTodos.TODOS, estadoPrestamo:=Entidades.CRMNovedad.EstadosProductosPrestados.TODOS,
                                       tipoUsuario:=0, visualizaSucursal:=Nothing, sucursales:=Nothing, categoriaReporta:="TODOS", patenteVehiculo:=String.Empty)
   End Function

   Public Function CRMNovedades_GetNovedades(desde As Date?, hasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                             idTipoNovedad As String,
                                             buscarABM As Eniac.Entidades.Buscar,
                                             CategoriasNovedades As Entidades.CRMCategoriaNovedad(),
                                             EstadosNovedades As Entidades.CRMEstadoNovedad(),
                                             MedioNovedades As Entidades.CRMMedioComunicacionNovedad(),
                                             MetodoNovedades As Entidades.CRMMetodoResolucionNovedad(),
                                             idUsuarioAsignado As String,
                                             idNovedad As Long, idNovedadPadre As Long, idCliente As Long, idProspecto As Long, idProveedor As Long,
                                             idPrioridadNovedad As Integer, idUsuarioAlta As String,
                                             finalizado As String, idProyecto As Integer, revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                             idAplicacion As String,
                                             nroVersion As String,
                                             descripcion As String,
                                             priorizado As Entidades.Publicos.SiNoTodos,
                                             ordenamiento As String,
                                             idFuncion As String,
                                             fechaActualizacionDesde As Date?,
                                             prioridadDelProyectoDesde As Decimal,
                                             prioridadDelProyectoHasta As Decimal,
                                             estadoDelProyecto As Integer,
                                             clasificacionDelProyecto As Integer,
                                             enGarantia As Entidades.Publicos.SiNoTodos,
                                             enPrestamo As Entidades.Publicos.SiNoTodos,
                                             estadoPrestamo As Entidades.CRMNovedad.EstadosProductosPrestados,
                                             tipoUsuario As Integer,
                                             visualizaSucursal As String,
                                             sucursales As Entidades.Sucursal(),
                                             categoriaReporta As String,
                                             patenteVehiculo As String) As DataTable

      'medioDeComunicacion As Integer, -- Se quita porque el parámetro está duplicado.
      'fecNovedad As Boolean,

      If buscarABM IsNot Nothing Then PreparaColumnaParaBuscar(buscarABM.Columna)

      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery, esAuditoria:=False)
         .AppendLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat("   AND N.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If

         If desde.HasValue Then
            .AppendFormat("  AND N.{1} >= '{0}'", ObtenerFecha(desde.Value, True), tipoFechaFiltro.ToString())
         End If
         If hasta.HasValue Then
            .AppendFormat("  AND N.{1} <= '{0}'", ObtenerFecha(hasta.Value, True), tipoFechaFiltro.ToString())
         End If

         'If idCategoriaNovedad <> 0 Then
         '   .AppendFormat(" AND N.idCategoriaNovedad = {0}", idCategoriaNovedad).AppendLine()
         'End If
         GetListaCategoriasNovedadesMultiples(myQuery, CategoriasNovedades, "N")
         GetListaEstadosNovedadesMultiples(myQuery, EstadosNovedades, "N")
         GetListaMediosNovedadesMultiples(myQuery, MedioNovedades, "N")
         GetListaMetodoNovedadesMultiples(myQuery, MetodoNovedades, "N")

         'If idEstadoNovedad <> 0 Then
         '.AppendFormat(" AND N.idEstadoNovedad = {0}", idEstadoNovedad).AppendLine()
         'End If
         If Not String.IsNullOrEmpty(idUsuarioAsignado) Then
            .AppendFormat(" AND N.IdUsuarioAsignado = '{0}'", idUsuarioAsignado).AppendLine()
         End If
         'If idMedioComunicacionNovedad <> 0 Then
         '   .AppendFormat(" AND N.IdMedioComunicacionNovedad = {0}", idMedioComunicacionNovedad).AppendLine()
         'End If
         'If idMetodoResolucionNovedad <> 0 Then
         '   .AppendFormatLine(" AND N.IdMetodoResolucionNovedad = {0}", idMetodoResolucionNovedad)
         'End If
         If idNovedad <> 0 Then
            .AppendFormat(" AND N.IdNovedad = {0}", idNovedad).AppendLine()
         End If
         If idNovedadPadre <> 0 Then
            .AppendFormat(" AND N.IdNovedadPadre = {0}", idNovedadPadre).AppendLine()
         End If
         If idCliente <> 0 Then
            .AppendFormat(" AND N.IdCliente = {0}", idCliente).AppendLine()
         End If
         If idProspecto <> 0 Then
            .AppendFormat(" AND N.IdProspecto = {0}", idProspecto).AppendLine()
         End If
         If idProveedor <> 0 Then
            .AppendFormat(" AND N.IdProveedor = {0}", idProveedor).AppendLine()
         End If
         If idProyecto <> 0 Then
            .AppendFormat(" AND N.IdProyecto = {0}", idProyecto).AppendLine()
         End If
         If idPrioridadNovedad <> 0 Then
            .AppendFormat(" AND N.IdPrioridadNovedad = '{0}'", idPrioridadNovedad).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idUsuarioAlta) Then
            .AppendFormat(" AND N.IdUsuarioAlta = '{0}'", idUsuarioAlta).AppendLine()
         End If

         If finalizado <> "TODOS" Then
            .AppendLine("  AND EN.Finalizado = " & IIf(finalizado = "SI", "1", "0").ToString())
         End If

         If revisionAdministrativa <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.RevisionAdministrativa = '{0}'", Me.GetStringFromBoolean(revisionAdministrativa = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            .AppendFormatLine("  AND N.IdSistema = '{0}'", idAplicacion)
         End If

         If Not String.IsNullOrWhiteSpace(patenteVehiculo) Then
            .AppendFormatLine("  AND N.PatenteVehiculo = '{0}'", patenteVehiculo)
         End If
         If Not String.IsNullOrWhiteSpace(nroVersion) Then
            .AppendFormatLine("  AND N.Version = '{0}'", nroVersion)
         End If

         If priorizado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.Priorizado = {0}", GetStringFromBoolean(priorizado = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrEmpty(descripcion) Then
            If Not descripcion.Contains(" ") Then
               .AppendFormatLine("   AND N.Descripcion LIKE '%{0}%'", descripcion)
            Else
               Dim Palabras() As String = descripcion.Split(" "c)
               .Append("   AND ( 1=1 ")
               For Each palabra As String In Palabras
                  .AppendFormatLine("   AND N.Descripcion LIKE '%{0}%'", palabra)
               Next
               .AppendLine("  )")
            End If
         End If
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine("  AND N.IdFuncion = '{0}'", idFuncion)
         End If

         '' # Medio de Comunicación
         'If medioDeComunicacion <> 0 Then
         '   .AppendFormatLine("  AND N.IdMedioComunicacionNovedad = {0}", medioDeComunicacion)
         'End If

         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine("   AND N.{0} > '{1}'",
                              Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If

         '# Prioridad del Proyecto
         If prioridadDelProyectoDesde > 0 Then
            .AppendFormatLine("  AND PRO.IdPrioridadProyecto >= {0} AND PRO.IdPrioridadProyecto <= {1}", prioridadDelProyectoDesde, prioridadDelProyectoHasta)
         End If

         '# Estado del Proyecto
         If estadoDelProyecto > 0 Then
            .AppendFormatLine("  AND PRO.IdEstado = {0}", estadoDelProyecto)
         End If

         '# Clasificacion del Proyecto
         If clasificacionDelProyecto > 0 Then
            .AppendFormatLine("  AND PRO.IdClasificacion = {0}", clasificacionDelProyecto)
         End If

         '# Service
         If enGarantia <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.TieneGarantiaService = '{0}'", enGarantia = Entidades.Publicos.SiNoTodos.SI)
         End If
         If enPrestamo <> Entidades.Publicos.SiNoTodos.TODOS Then
            If enPrestamo = Entidades.Publicos.SiNoTodos.SI Then
               .AppendFormatLine("  AND N.IdProductoPrestado <> '' AND N.IdProductoPrestado IS NOT NULL")
            Else
               .AppendFormatLine("  AND (N.IdProductoPrestado = '' OR N.IdProductoPrestado IS NULL)")
            End If
         End If
         If estadoPrestamo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.ProductoPrestadoDevuelto = '{0}'", estadoPrestamo = Entidades.CRMNovedad.EstadosProductosPrestados.DEVUELTO)
         End If

         '# Tipo de Usuario
         If tipoUsuario > 0 Then
            .AppendFormatLine("  AND UG.TipoUsuario = {0}", tipoUsuario)
         End If

         '# Visualiza Sucursal.- -- REQ-31656.- --
         Select Case visualizaSucursal
            Case Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.Exclusiva.ToString()
               .AppendFormatLine("  AND N.IdSucursalNovedad = {0}", actual.Sucursal.IdSucursal)
            Case Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.Compartida.ToString()
               If sucursales IsNot Nothing Then
                  GetListaSucursalesNovedadesMultiples(myQuery, sucursales, "N")
               End If
         End Select

         If Not String.IsNullOrWhiteSpace(categoriaReporta) AndAlso categoriaReporta <> "TODOS" Then
            .AppendFormatLine("  AND CN.Reporta = '{0}'", categoriaReporta)
         End If

         If buscarABM IsNot Nothing Then
            .AppendFormatLine(FormatoBuscarAnd, buscarABM.Columna, buscarABM.Valor.ToString())
         End If

         '-- Comienza el Order --
         If String.IsNullOrWhiteSpace(ordenamiento) Then
            .AppendFormat(" ORDER BY N.{0}", tipoFechaFiltro.ToString())
         Else
            .AppendFormat("ORDER BY " & ordenamiento)
         End If


      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function CRMNovedades_GetNovedadesCambioEstado(desde As Date?, hasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                            idTipoNovedad As String,
                                            buscarABM As Eniac.Entidades.Buscar,
                                            idCategoriaNovedad As Integer, idEstadoNovedad As Integer,
                                            idUsuarioAsignado As String, idMedioComunicacionNovedad As Integer,
                                            idMetodoResolucionNovedad As Integer,
                                            idNovedad As Long, idNovedadPadre As Long, idCliente As Long, idProspecto As Long, idProveedor As Long,
                                            idPrioridadNovedad As Integer, idUsuarioAlta As String,
                                            finalizado As String, idProyecto As Integer, revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                            idAplicacion As String,
                                            nroVersion As String,
                                            descripcion As String,
                                            priorizado As Entidades.Publicos.SiNoTodos,
                                            ordenamiento As String,
                                            idFuncion As String,
                                            fechaActualizacionDesde As Date?,
                                            prioridadDelProyectoDesde As Decimal,
                                            prioridadDelProyectoHasta As Decimal,
                                            estadoDelProyecto As Integer,
                                            clasificacionDelProyecto As Integer,
                                            enGarantia As Entidades.Publicos.SiNoTodos,
                                            enPrestamo As Entidades.Publicos.SiNoTodos,
                                            estadoPrestamo As Entidades.CRMNovedad.EstadosProductosPrestados,
                                            tipoUsuario As Integer,
                                            visualizaSucursal As String, embarcacion As Boolean, patenteVehiculo As String) As DataTable
      'medioDeComunicacion As Integer, -- Se quita porque el parámetro está duplicado.
      'fecNovedad As Boolean,

      If buscarABM IsNot Nothing Then PreparaColumnaParaBuscar(buscarABM.Columna)

      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTextoCambioEstado(myQuery, esAuditoria:=False, embarcacion:=embarcacion)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat("   AND N.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If

         Dim prefix As String = If(tipoFechaFiltro = Entidades.CRMNovedad.TipoFechaFiltro.FechaCambioEstado, "ESTA", "N")
         If desde.HasValue Then
            .AppendFormat("  AND {2}.{1} >= '{0}'", ObtenerFecha(desde.Value, True), tipoFechaFiltro.ToString(), prefix)
         End If
         If hasta.HasValue Then
            .AppendFormat("  AND {2}.{1} <= '{0}'", ObtenerFecha(hasta.Value, True), tipoFechaFiltro.ToString(), prefix)
         End If

         If idCategoriaNovedad <> 0 Then
            .AppendFormat(" AND N.idCategoriaNovedad = {0}", idCategoriaNovedad).AppendLine()
         End If
         If idEstadoNovedad <> 0 Then
            .AppendFormat(" AND ESTADOS.idEstadoNovedad = {0}", idEstadoNovedad).AppendLine()
         End If
         If Not String.IsNullOrEmpty(idUsuarioAsignado) Then
            .AppendFormat(" AND ESTA.IdUsuarioAsignado = '{0}'", idUsuarioAsignado).AppendLine()
         End If
         If idMedioComunicacionNovedad <> 0 Then
            .AppendFormat(" AND N.IdMedioComunicacionNovedad = {0}", idMedioComunicacionNovedad).AppendLine()
         End If
         If idMetodoResolucionNovedad <> 0 Then
            .AppendFormatLine(" AND N.IdMetodoResolucionNovedad = {0}", idMetodoResolucionNovedad)
         End If
         If idNovedad <> 0 Then
            .AppendFormat(" AND N.IdNovedad = {0}", idNovedad).AppendLine()
         End If
         If idNovedadPadre <> 0 Then
            .AppendFormat(" AND N.IdNovedadPadre = {0}", idNovedadPadre).AppendLine()
         End If
         If idCliente <> 0 Then
            .AppendFormat(" AND N.IdCliente = {0}", idCliente).AppendLine()
         End If
         If idProspecto <> 0 Then
            .AppendFormat(" AND N.IdProspecto = {0}", idProspecto).AppendLine()
         End If
         If idProveedor <> 0 Then
            .AppendFormat(" AND N.IdProveedor = {0}", idProveedor).AppendLine()
         End If
         If idProyecto <> 0 Then
            .AppendFormat(" AND N.IdProyecto = {0}", idProyecto).AppendLine()
         End If
         If idPrioridadNovedad <> 0 Then
            .AppendFormat(" AND N.IdPrioridadNovedad = '{0}'", idPrioridadNovedad).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idUsuarioAlta) Then
            .AppendFormat(" AND ESTA.IdUsuario = '{0}'", idUsuarioAlta).AppendLine()
         End If

         If finalizado <> "TODOS" Then
            .AppendLine("  AND EN.Finalizado = " & IIf(finalizado = "SI", "1", "0").ToString())
         End If

         If revisionAdministrativa <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.RevisionAdministrativa = '{0}'", Me.GetStringFromBoolean(revisionAdministrativa = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            .AppendFormatLine("  AND N.IdSistema = '{0}'", idAplicacion)
         End If

         If Not String.IsNullOrWhiteSpace(nroVersion) Then
            .AppendFormatLine("  AND N.Version = '{0}'", nroVersion)
         End If

         If priorizado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.Priorizado = {0}", GetStringFromBoolean(priorizado = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrWhiteSpace(patenteVehiculo) Then
            .AppendFormatLine("  AND N.PatenteVehiculo = '{0}'", patenteVehiculo)
         End If

         If Not String.IsNullOrEmpty(descripcion) Then
            If Not descripcion.Contains(" ") Then
               .AppendFormatLine("   AND N.Descripcion LIKE '%{0}%'", descripcion)
            Else
               Dim Palabras() As String = descripcion.Split(" "c)
               .Append("   AND ( 1=1 ")
               For Each palabra As String In Palabras
                  .AppendFormatLine("   AND N.Descripcion LIKE '%{0}%'", palabra)
               Next
               .AppendLine("  )")
            End If
         End If
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine("  AND N.IdFuncion = '{0}'", idFuncion)
         End If

         '' # Medio de Comunicación
         'If medioDeComunicacion <> 0 Then
         '   .AppendFormatLine("  AND N.IdMedioComunicacionNovedad = {0}", medioDeComunicacion)
         'End If

         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine("   AND N.{0} > '{1}'",
                          Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If

         '# Prioridad del Proyecto
         If prioridadDelProyectoDesde > 0 Then
            .AppendFormatLine("  AND PRO.IdPrioridadProyecto >= {0} AND PRO.IdPrioridadProyecto <= {1}", prioridadDelProyectoDesde, prioridadDelProyectoHasta)
         End If

         '# Estado del Proyecto
         If estadoDelProyecto > 0 Then
            .AppendFormatLine("  AND PRO.IdEstado = {0}", estadoDelProyecto)
         End If

         '# Clasificacion del Proyecto
         If clasificacionDelProyecto > 0 Then
            .AppendFormatLine("  AND PRO.IdClasificacion = {0}", clasificacionDelProyecto)
         End If

         '# Service
         If enGarantia <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.TieneGarantiaService = '{0}'", enGarantia = Entidades.Publicos.SiNoTodos.SI)
         End If
         If enPrestamo <> Entidades.Publicos.SiNoTodos.TODOS Then
            If enPrestamo = Entidades.Publicos.SiNoTodos.SI Then
               .AppendFormatLine("  AND N.IdProductoPrestado <> '' AND N.IdProductoPrestado IS NOT NULL")
            Else
               .AppendFormatLine("  AND (N.IdProductoPrestado = '' OR N.IdProductoPrestado IS NULL)")
            End If
         End If
         If estadoPrestamo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.ProductoPrestadoDevuelto = '{0}'", estadoPrestamo = Entidades.CRMNovedad.EstadosProductosPrestados.DEVUELTO)
         End If

         '# Tipo de Usuario
         If tipoUsuario > 0 Then
            .AppendFormatLine("  AND UG.TipoUsuario = {0}", tipoUsuario)
         End If

         '# Visualiza Sucursal.- -- REQ-31656.- --
         If visualizaSucursal = Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.Exclusiva.ToString() Then
            .AppendFormatLine("  AND N.IdSucursalNovedad = {0}", actual.Sucursal.IdSucursal)
         End If

         If buscarABM IsNot Nothing Then
            .AppendFormatLine(FormatoBuscarAnd, buscarABM.Columna, buscarABM.Valor.ToString())
         End If

         '-- Comienza el Order --
         If String.IsNullOrWhiteSpace(ordenamiento) Then
            .AppendFormat(" ORDER BY {1}.{0}", tipoFechaFiltro.ToString(), prefix)
         Else
            .AppendFormat("ORDER BY " & ordenamiento)
         End If


      End With

      Return GetDataTable(myQuery)

   End Function


   Public Function CRMNovedades_GetAlertasInforme(desde As Date, hasta As Date, idTipoNovedad As String, fecNovedad As Boolean,
                                                 idCategoriaNovedad As Integer, Priorizado As Boolean?) As DataTable

      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, esAuditoria:=False)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" WHERE N.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If
         .AppendLine("  AND N.RevisionAdministrativa = 0")

         .AppendFormat("    AND N.FechaNovedad >= '{0} 00:00:00'", desde.ToString("yyyyMMdd"))

         .AppendFormat("  AND N.FechaNovedad <= '{0} 23:59:59'", hasta.ToString("yyyyMMdd"))

         If idCategoriaNovedad <> 0 Then
            .AppendFormat(" AND N.idCategoriaNovedad = {0}", idCategoriaNovedad).AppendLine()
         End If
         If Priorizado.HasValue Then
            .AppendFormatLine("  AND N.Priorizado = '{0}'", Me.GetStringFromBoolean(Priorizado.Value))
         End If

         If fecNovedad Then
            .AppendFormat(" ORDER BY N.FechaNovedad")
         Else
            .AppendFormat(" ORDER BY N.FechaProximoContacto")
         End If

      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function CRMNovedades_GetGestionesInforme(desde As Date, hasta As Date, idTipoNovedad As String, Usuario As String,
                                           idCategoriaNovedad As Integer, IdCategoria As Integer) As DataTable

      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, esAuditoria:=False)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" WHERE N.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If
         ' .AppendLine("  AND N.RevisionAdministrativa = 0")

         .AppendFormat("    AND N.FechaNovedad >= '{0} 00:00:00'", desde.ToString("yyyyMMdd"))

         .AppendFormat("  AND N.FechaNovedad <= '{0} 23:59:59'", hasta.ToString("yyyyMMdd"))

         If idCategoriaNovedad <> 0 Then
            .AppendFormat(" AND N.idCategoriaNovedad = {0}", idCategoriaNovedad).AppendLine()
         End If

         If Not String.IsNullOrEmpty(Usuario) Then
            .AppendFormat(" AND N.IdUsuarioAlta = '{0}'", Usuario).AppendLine()
         End If

         .AppendFormat(" ORDER BY N.FechaNovedad")

      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function CRMNovedades_GetNovedadesRelacionadas(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long,
                                                         idTipoNovedadPadre As String, letraPadre As String, centroEmisorPadre As Short, idNovedadPadre As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, esAuditoria:=False, campoCalculado:=
                     String.Format(" , CASE WHEN (N.{0} = '{1}' AND N.{2} = '{3}' AND N.{4} = {5} AND N.{6} = {7}) THEN 'Padre' ELSE CASE WHEN (N.{8} = '{9}' AND N.{10} = '{11}' AND N.{12}= {13} AND N.{14} = {15}) THEN 'Hermano' ELSE 'Hijo' END END AS Parentesco",
                                   Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedadPadre,
                                   Entidades.CRMNovedad.Columnas.Letra.ToString(), letraPadre,
                                   Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisorPadre,
                                   Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedadPadre,
                                   Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString(), idTipoNovedadPadre,
                                   Entidades.CRMNovedad.Columnas.LetraPadre.ToString(), letraPadre,
                                   Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString(), centroEmisorPadre,
                                   Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString(), idNovedadPadre))
         'Busco todas las novedades donde YO soy su padre
         .AppendFormatLine(" WHERE ((N.{0} = '{1}' AND N.{2} = '{3}' AND N.{4} = {5} AND N.{6} = {7})",
                           Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString(), idTipoNovedad,
                           Entidades.CRMNovedad.Columnas.LetraPadre.ToString(), letra,
                           Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString(), centroEmisor,
                           Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString(), idNovedad)

         If Not String.IsNullOrWhiteSpace(idTipoNovedadPadre) And Not String.IsNullOrWhiteSpace(letraPadre) And centroEmisorPadre > 0 And idNovedadPadre > 0 Then
            'Busco la novedade que ES mi padre
            .AppendFormatLine("    OR (N.{0} = '{1}' AND N.{2} = '{3}' AND N.{4} = {5} AND N.{6} = {7})",
                              Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedadPadre,
                              Entidades.CRMNovedad.Columnas.Letra.ToString(), letraPadre,
                              Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisorPadre,
                              Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedadPadre)
            .AppendFormatLine("    OR (N.{0} = '{1}' AND N.{2} = '{3}' AND N.{4} = {5} AND N.{6} = {7})",
                              Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString(), idTipoNovedadPadre,
                              Entidades.CRMNovedad.Columnas.LetraPadre.ToString(), letraPadre,
                              Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString(), centroEmisorPadre,
                              Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString(), idNovedadPadre)
         End If
         .AppendFormatLine(" )")
         .AppendFormatLine("  AND (N.{0} <> '{1}' OR N.{2} <> '{3}' OR N.{4} <> {5} OR N.{6} <> {7})",
                           Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                           Entidades.CRMNovedad.Columnas.Letra.ToString(), letra,
                           Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisor,
                           Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedad)

         '# Seguridad en Novedades Relacionadas - Tableros 
         .AppendFormatLine("  -- #Seguridad en Novedades Relacionadas - Tableros")
         .AppendFormatLine("  AND EXISTS")
         .AppendFormatLine("	(SELECT * FROM RolesFunciones RFUN ")
         .AppendFormatLine("		INNER JOIN Usuarios USU ON USU.Id = '{0}'", actual.Nombre)
         .AppendFormatLine("		INNER JOIN UsuariosRoles UROL ON UROL.IdUsuario = USU.Id AND UROL.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("	 WHERE RFUN.IdFuncion = 'CRMNovedadesABM' + N.IdTipoNovedad AND RFUN.IdRol = UROL.IdRol)")
         .AppendFormatLine("")

         '# Seguridad en Novedades Relacionadas - Ver Otros Usuarios (siempre que el usuario NO sea yo)
         .AppendFormatLine("  -- #Seguridad en Novedades Relacionadas - Ver Otros Usuarios")
         .AppendFormatLine("  AND EXISTS")
         .AppendFormatLine("	(SELECT * FROM RolesFunciones RFUN ")
         .AppendFormatLine("		INNER JOIN Usuarios USU ON USU.Id = '{0}'", actual.Nombre)
         .AppendFormatLine("		INNER JOIN UsuariosRoles UROL ON UROL.IdUsuario = USU.Id AND UROL.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("	 WHERE N.IdUsuarioAsignado = '{0}' OR RFUN.IdFuncion = N.IdTipoNovedad + '-VerOtrosUsuarios' AND RFUN.IdRol = UROL.IdRol)", actual.Nombre)

         .AppendFormat(" ORDER BY Parentesco DESC, N.FechaNovedad")

      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function GetNovedadXTipo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, esAuditoria:=False)
         .AppendFormat(" WHERE N.IdTipoNovedad = '{0}' ", idTipoNovedad)

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND N.Letra = '{0}'", letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormat("   AND N.CentroEmisor =  {0} ", centroEmisor)
         End If

         If idNovedad <> 0 Then
            .AppendFormat(" AND N.IdNovedad = {0} ", idNovedad)
         End If
         .AppendFormat(" ORDER BY N.IdNovedad ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function CRMNovedades_G1(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, esAuditoria:=False)
         .AppendFormat(" WHERE N.{0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormat("   AND N.{0} = '{1}'", Entidades.CRMNovedad.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND N.{0} =  {1} ", Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND N.{0} =  {1} ", Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedad)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, String.Empty, Nothing, String.Empty)
   End Function

   Private Sub PreparaColumnaParaBuscar(ByRef columna As String)

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      ElseIf columna = "NombrePrioridadNovedad" Then
         columna = "PN." + columna
      ElseIf columna = "NombreCategoriaNovedad" Then
         columna = "CN." + columna
      ElseIf columna = "NombreEstadoNovedad" Then
         columna = "EN." + columna
      ElseIf columna = "NombreEstadoNovedadEntregado" Then
         columna = "ENE." + columna
      ElseIf columna = "NombreEstadoNovedadFinalizado" Then
         columna = "ENF." + columna
      ElseIf columna = "NombreMedioComunicacionNovedad" Then
         columna = "MN." + columna
      ElseIf columna = "NombreMetodoResolucionNovedad" Then
         columna = "MRN." + columna
      ElseIf columna = "CodigoCliente" Or columna = "NombreCliente" Then
         columna = "C." + columna
      ElseIf columna = "CodigoProspecto" Or columna = "NombreProspecto" Then
         columna = "P." + columna
      ElseIf columna = "CodigoProveedor" Or columna = "NombreProveedor" Then
         columna = "PR." + columna
      ElseIf columna = "NombreUsuarioEstadoNovedad" Then
         columna = "UE." + columna
      ElseIf columna = "NombreUsuarioAlta" Then
         columna = "UA." + columna
      ElseIf columna = "NombreUsuarioAsignado" Then
         columna = "UG." + columna
      ElseIf columna = "NombreUsuarioResponsable" Then
         columna = "UR." + columna
      ElseIf columna = "NombreFuncion" Then
         columna = "FN." + columna
      ElseIf columna = "NombreDeFantasia" Then
         columna = "C." + columna
      ElseIf columna = "NombreDeFantasiaProspecto" Then
         columna = "P.NombreDeFantasia"
      ElseIf columna = "NombreProyecto" Then
         columna = "PR.NombreProyecto"
      ElseIf columna = "NombrePrioridadNovedadPadre" Then
         columna = "PNP.NombrePrioridadNovedad"
      ElseIf columna = "NombreCategoriaNovedadPadre" Then
         columna = "CNP.NombreCategoriaNovedad"
      ElseIf columna = "ColorCategoriaPadre" Then
         columna = "CNP.Color"
      ElseIf columna = "NombreEstadoNovedadPadre" Then
         columna = "ENP.NombreEstadoNovedad"
      ElseIf columna = "FinalizadoPadre" Then
         columna = "ENP.Finalizado"
      ElseIf columna = "ColorEstadoPadre" Then
         columna = "ENP.Color"

      ElseIf columna = "NombreCategoriaCliente" Then
         columna = "CATC.NombreCategoria"
      ElseIf columna = "NombreCategoriaProspecto" Then
         columna = "CATP.NombreCategoria"
      ElseIf columna = "NombreCategoriaProveedor" Then
         columna = "CATPR.NombreCategoria"

      ElseIf columna = "NombreTipoCliente" Then
         columna = "TIPOC.NombreTipoCliente"
      ElseIf columna = "NombreTipoProspecto" Then
         columna = "TIPOP.NombreTipoCliente"

      Else
         columna = "N." + columna
      End If
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String, idTipoNovedad As String,
                                    finalizado As Boolean?, usuarioAsignado As String) As DataTable

      Dim esFecha As Boolean = columna = Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() Or
                               columna = Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() Or
                               columna = Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() Or
                               columna = Entidades.CRMNovedad.Columnas.FechaAlta.ToString()

      PreparaColumnaParaBuscar(columna)

      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb, esAuditoria:=False)
         Dim fecha As Date = Nothing
         Dim valorFecha As String = valor
         If esFecha Then
            If valorFecha.Split("/"c).Length < 2 Then
               valorFecha = String.Concat(valorFecha, Today.ToString("/MM"))
            End If
            If valorFecha.Split("/"c).Length < 3 Then
               valorFecha = String.Concat(valorFecha, Today.ToString("/yyyy"))
            End If

            Try
               fecha = DateTime.Parse(valorFecha)
            Catch ex As Exception
               esFecha = False
            End Try
         End If
         If esFecha Then
            .AppendFormatLine(" WHERE {0} BETWEEN '{1}' AND '{2}' ", columna, ObtenerFecha(fecha.Date, True), ObtenerFecha(fecha.Date.AddDays(1).AddSeconds(-1), True))
         Else
            .AppendFormatLine(FormatoBuscar, columna, valor)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" AND N.{0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If finalizado.HasValue Then
            .AppendFormat(" AND EN.Finalizado = {0}", GetStringFromBoolean(finalizado.Value))
         End If
         If Not String.IsNullOrWhiteSpace(usuarioAsignado) Then
            .AppendFormat(" AND N.IdUsuarioAsignado = '{0}'", usuarioAsignado).AppendLine()
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short) As Long
      Return MyBase.GetCodigoMaximo(Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), "CRMNovedades",
                                    String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5}",
                                                  Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                  Entidades.CRMNovedad.Columnas.Letra.ToString(), letra,
                                                  Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisor))
   End Function

   Public Function GetNovedadesVencidas(hoy As Date, idUsuario As String) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("SELECT Count(1) Cantidad,tn.IdTipoNovedad,tn.NombreTipoNovedad")
         .AppendFormat("  FROM CRMNovedades AS n INNER JOIN CRMTiposNovedades AS tn ON n.IdTipoNovedad = tn.IdTipoNovedad")
         .AppendFormat("  INNER JOIN CRMEstadosNovedades AS en ON n.IdEstadoNovedad = en.IdEstadoNovedad")
         .AppendFormat("  WHERE n.FechaProximoContacto <= '{0}'", ObtenerFecha(hoy, True))
         .AppendFormat("  AND (n.IdUsuarioAsignado = '{0}' OR", idUsuario)
         .AppendFormat("       EXISTS(SELECT * FROM Funciones F")
         .AppendFormat("               INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id")
         .AppendFormat("               INNER JOIN UsuariosRoles UR ON UR.IdRol = RF.IdRol")
         .AppendFormat("               WHERE F.Id = N.IdTipoNovedad + '-VerOtrUsrAlertas'")
         .AppendFormat("                 AND UR.IdUsuario = '{0}'))", idUsuario)
         .AppendFormat("  AND en.Finalizado = {0}", GetStringFromBoolean(False))
         .AppendFormat("  GROUP BY tn.IdTipoNovedad,TN.NombreTipoNovedad")
      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function GetNovedadesPorVencer(hoy As Date, idUsuario As String) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT Count(1) Cantidad,tn.IdTipoNovedad,tn.NombreTipoNovedad")
         .AppendLine("  FROM CRMNovedades AS n INNER JOIN CRMTiposNovedades AS tn ON n.IdTipoNovedad = tn.IdTipoNovedad")
         .AppendLine("  INNER JOIN CRMEstadosNovedades AS en ON n.IdEstadoNovedad = en.IdEstadoNovedad")
         .AppendLine("  WHERE n.FechaProximoContacto >= '" & ObtenerFecha(Today, True) & "'")
         .AppendLine("  AND n.FechaProximoContacto <= '" & ObtenerFecha(hoy, True) & "'")
         .AppendFormat("  AND (n.IdUsuarioAsignado = '{0}' OR", idUsuario)
         .AppendFormat("       EXISTS(SELECT * FROM Funciones F")
         .AppendFormat("               INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id")
         .AppendFormat("               INNER JOIN UsuariosRoles UR ON UR.IdRol = RF.IdRol")
         .AppendFormat("               WHERE F.Id = N.IdTipoNovedad + '-VerOtrUsrAlertas'")
         .AppendFormat("                 AND UR.IdUsuario = '{0}'))", idUsuario)
         .AppendLine("  AND en.Finalizado = " & GetStringFromBoolean(False))
         .AppendLine("  GROUP BY tn.IdTipoNovedad,TN.NombreTipoNovedad")
      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function Existe(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Boolean
      Dim myQuery = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendFormatLine("SELECT IdNovedad Cantidad FROM CRMNovedades AS N")
         .AppendFormatLine(" WHERE N.{0} = '{1}'", Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND N.{0} = '{1}'", Entidades.CRMNovedad.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND N.{0} =  {1} ", Entidades.CRMNovedad.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND N.{0} =  {1} ", Entidades.CRMNovedad.Columnas.IdNovedad.ToString(), idNovedad)
      End With
      Dim dt As DataTable = GetDataTable(myQuery.ToString())
      Return dt.Rows.Count > 0
   End Function

   Public Function GetClientesGestion(idCliente As Long, fechaDesde As Date, fechaHasta As Date,
                                      periodosCantidad As List(Of String), periodosHoras As List(Of String)) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT Th.IdCliente, Th.CodigoCliente, Th.NombreCliente, Th.NombreDeFantasia, Th.IdTipoNovedad, Th.NombreTipoNovedad, Th.IdCategoriaNovedad, Th.NombreCategoriaNovedad")
         .AppendFormatLine("     , {0}", String.Join(",", periodosCantidad.ConvertAll(Function(c) String.Format("SUM({0}) AS {0}", c))))
         .AppendFormatLine("     , {0}", String.Join(",", periodosHoras.ConvertAll(Function(c) String.Format("SUM({0}) AS {0}", c))))
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT N.IdCliente")
         .AppendFormatLine("             , C.CodigoCliente")
         .AppendFormatLine("             , C.NombreCliente")
         .AppendFormatLine("             , C.NombreDeFantasia")
         .AppendFormatLine("             , N.IdTipoNovedad")
         .AppendFormatLine("             , TN.NombreTipoNovedad")
         .AppendFormatLine("             , N.IdCategoriaNovedad")
         .AppendFormatLine("             , CN.NombreCategoriaNovedad")
         .AppendFormatLine("             , N.Cantidad")
         .AppendFormatLine("             , N.Horas")
         .AppendFormatLine("             , N.Periodo_Cantidad")
         .AppendFormatLine("             , N.Periodo_Horas")
         .AppendFormatLine("          FROM (")
         .AppendFormatLine("                SELECT N.IdCliente")
         .AppendFormatLine("                     , N.IdTipoNovedad")
         .AppendFormatLine("                     , N.IdCategoriaNovedad")
         .AppendFormatLine("                     , 'Cantidad_' + Nh.Periodo Periodo_Cantidad")
         .AppendFormatLine("                     , 'Horas_' + Nh.Periodo Periodo_Horas")
         .AppendFormatLine("                     , COUNT(1) Cantidad")
         .AppendFormatLine("                     , SUM(Nh.Horas) Horas")
         .AppendFormatLine("                     --, *")
         .AppendFormatLine("                  FROM (SELECT N.IdTipoNovedadPadre, N.LetraPadre, N.CentroEmisorPadre, N.IdNovedadPadre")
         .AppendFormatLine("                             , 'Mes_' + CONVERT(NVARCHAR(4), DATEPART(YEAR, N.FechaNovedad)) + RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(MONTH, N.FechaNovedad)), 2) Periodo")
         .AppendFormatLine("                             , SUM(N.Cantidad) Horas")
         .AppendFormatLine("                          FROM CRMNovedades N")
         .AppendFormatLine("                         INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = N.IdTipoNovedad")
         .AppendFormatLine("                         WHERE TN.ReportaCantidad = 'True'")
         .AppendFormatLine("                           AND N.IdTipoNovedadPadre IN ('TICKETS','PENDIENTE')")
         .AppendFormatLine("                         GROUP BY N.IdTipoNovedadPadre, N.LetraPadre, N.CentroEmisorPadre, N.IdNovedadPadre")
         .AppendFormatLine("                                , 'Mes_' + CONVERT(NVARCHAR(4), DATEPART(YEAR, N.FechaNovedad)) + RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(MONTH, N.FechaNovedad)), 2)")
         .AppendFormatLine("                        ) Nh")
         .AppendFormatLine("                 INNER JOIN CRMNovedades N ON N.IdTipoNovedad = Nh.IdTipoNovedadPadre AND N.Letra = Nh.LetraPadre AND N.CentroEmisor = Nh.CentroEmisorPadre AND N.IdNovedad = Nh.IdNovedadPadre")
         .AppendFormatLine("                                          AND 'Mes_' + CONVERT(NVARCHAR(4), DATEPART(YEAR, N.FechaNovedad)) + RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(MONTH, N.FechaNovedad)), 2) = Nh.Periodo")
         .AppendFormatLine("                 WHERE N.IdTipoNovedad IN ('TICKETS','PENDIENTE')")
         .AppendFormatLine("                   AND N.FechaNovedad BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         If idCliente > 0 Then
            .AppendFormatLine("                   AND N.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine("                 GROUP BY N.IdCliente, N.IdTipoNovedad, N.IdCategoriaNovedad, Nh.Periodo")
         .AppendFormatLine("                ) N")
         .AppendFormatLine("         INNER JOIN Clientes C ON C.IdCliente = N.IdCliente")
         .AppendFormatLine("         INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad")
         .AppendFormatLine("         INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = N.IdTipoNovedad")
         .AppendFormatLine("        ) N")
         .AppendFormatLine(" PIVOT (")
         .AppendFormatLine("    SUM(N.Cantidad) ")
         .AppendFormatLine("    FOR N.Periodo_Cantidad IN ({0})", String.Join(",", periodosCantidad))
         .AppendFormatLine("       ) AS T")
         .AppendFormatLine(" PIVOT (")
         .AppendFormatLine("    SUM(T.Horas) ")
         .AppendFormatLine("    FOR T.Periodo_Horas IN ({0})", String.Join(",", periodosHoras))
         .AppendFormatLine("       ) AS Th")

         .AppendFormatLine(" GROUP BY Th.IdCliente, Th.CodigoCliente, Th.NombreCliente, Th.NombreDeFantasia, Th.IdTipoNovedad, Th.NombreTipoNovedad, Th.IdCategoriaNovedad, Th.NombreCategoriaNovedad")
         .AppendFormatLine(" ORDER BY Th.NombreCliente, Th.NombreTipoNovedad, Th.NombreCategoriaNovedad")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function GetNovedadesXCliente(idTipoNovedad As String, idCliente As Long, fechaDesde As Date?, fechaHasta As Date?, topRegistros As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("SELECT ")
         If topRegistros > 0 Then
            .AppendFormat("TOP {0} ", topRegistros)
         End If
         .AppendLine("C.NombreCliente")
         .AppendLine("     , TN.NombreTipoNovedad")
         .AppendLine("     , N.IdNovedad")
         .AppendLine("     , U.Nombre Usuario")
         .AppendLine("     , N.FechaNovedad")
         .AppendLine("     , N.Interlocutor")
         .AppendLine("     , N.Descripcion")
         .AppendLine("     , NS.FechaSeguimiento")
         .AppendLine("     , US.Nombre UsuarioSeguimiento")
         .AppendLine("     , NS.Comentario")
         .AppendLine("     , N.Cantidad")
         .AppendLine("  FROM CRMNovedades N")
         .AppendLine("  LEFT JOIN CRMNovedadesSeguimiento NS ON N.IdTipoNovedad = NS.IdTipoNovedad AND N.IdNovedad = NS.IdNovedad")
         .AppendLine(" INNER JOIN Clientes C ON N.Idcliente = C.idcliente")
         .AppendLine(" INNER JOIN CRMTiposNovedades TN ON N.IdTipoNovedad = TN.IdTipoNovedad")
         .AppendLine(" INNER JOIN Usuarios U ON N.IdUsuarioAsignado = U.Id")
         .AppendLine(" INNER JOIN Usuarios US ON NS.UsuarioSeguimiento = US.Id")
         .AppendFormatLine(" WHERE N.idcliente = {0}", idCliente)
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormatLine("   AND N.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(fechaDesde.Value.Date, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND N.FechaNovedad <= '{0}'", ObtenerFecha(fechaDesde.Value.UltimoSegundoDelDia(), True))
         End If

         .AppendLine(" ORDER BY N.FechaNovedad DESC")
      End With

      Return GetDataTable(myQuery)

   End Function

   Public Function GetGestionesAlertasXCliente(idTipoNovedad As String, idCliente As Long) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("select N.IdCliente ")
         .AppendLine(" ,TN.NombreTipoNovedad")
         .AppendLine(" ,N.IdNovedad")
         .AppendLine(" ,N.IdUsuarioAsignado")
         .AppendLine(" ,N.FechaNovedad")
         .AppendLine(" ,N.Descripcion")
         .AppendLine(" ,CN.NombreCategoriaNovedad ")
         .AppendLine(" ,N.Priorizado")
         .AppendLine(" ,N.RevisionAdministrativa")
         .AppendLine(" FROM CRMNovedades N ")
         .AppendLine(" INNER JOIN Clientes C ON N.Idcliente = C.idcliente ")
         .AppendLine(" INNER JOIN CRMTiposNovedades TN ON N.IdTipoNovedad = TN.IdTipoNovedad ")
         .AppendLine(" INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad")
         .AppendFormat(" where N.idcliente = {0}", idCliente)
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and N.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         .AppendLine(" order by N.FechaNovedad ASC")
      End With

      Return GetDataTable(myQuery)

   End Function
   Public Function GetHojaNovedades(idUsuario As String, verDetalleActividades As Boolean, revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                    fechaDesde As Date, fechaHasta As Date, dias As List(Of String), idCliente As Long?, idProyecto As Integer?,
                                    idTipoCategoriaNovedad As Integer?, idCategoriaNovedad As Integer?, agrupadoPorCategoria As Boolean,
                                    idNovedad As Long, idAplicacion As String, nroVersion As String, idFuncion As String,
                                    totalizadoPor As Entidades.Publicos.PeriodosCalendarios, expresionTotal As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT *, {0} AS Total FROM", expresionTotal)
         .AppendFormatLine("     (SELECT")
         If totalizadoPor = Entidades.Publicos.PeriodosCalendarios.Dia Then
            .AppendFormatLine("             'Fecha_' + CONVERT(char(10), N.FechaNovedad, 112) AS FechaNovedad")
         ElseIf totalizadoPor = Entidades.Publicos.PeriodosCalendarios.Mes Then
            .AppendFormatLine("             'Mes_' + CONVERT(NVARCHAR(4), DATEPART(YEAR, N.FechaNovedad)) + RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(MONTH, N.FechaNovedad)), 2) AS FechaNovedad")
         ElseIf totalizadoPor = Entidades.Publicos.PeriodosCalendarios.Anio Then
            .AppendFormatLine("             'Anio_' + CONVERT(NVARCHAR(4), DATEPART(YEAR, N.FechaNovedad)) AS FechaNovedad")
         End If
         .AppendFormatLine("           , N.Cantidad AS Avance")
         If agrupadoPorCategoria Then
            .AppendFormatLine("           , CN.IdCategoriaNovedad")
            .AppendFormatLine("           , CN.NombreCategoriaNovedad")
         Else
            .AppendFormatLine("           , N.IdUsuarioAsignado")
            .AppendFormatLine("           , C.IdCliente")
            .AppendFormatLine("           , C.CodigoCliente")
            .AppendFormatLine("           , C.NombreCliente")
            .AppendFormatLine("           , CONVERT(CHAR(4), N.IdProyecto) + '-' + P.NombreProyecto AS Proyecto")
            If verDetalleActividades Then
               .AppendFormatLine("           , F.Nombre NombreFuncion")
               .AppendFormatLine("           , CN.IdCategoriaNovedad")
               .AppendFormatLine("           , CN.NombreCategoriaNovedad")
            End If
            .AppendFormatLine("           , CAT.NombreCategoria")
            .AppendFormatLine("           , E.NombreEstadoCliente")
            .AppendFormatLine("           , T.NombreTipoCliente")

            .AppendFormatLine("           , P.IdEstado")
            .AppendFormatLine("           , PE.NombreEstado")
            .AppendFormatLine("           , P.IdClasificacion")
            .AppendFormatLine("           , CL.NombreClasificacion")

         End If
         .AppendFormatLine("        FROM CRMNovedades N")
         .AppendFormatLine("       INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = N.IdTipoNovedad")
         .AppendFormatLine("       INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad")
         .AppendFormatLine("        LEFT JOIN CRMNovedades Padre ON N.IdNovedadPadre = Padre.IdNovedad")
         .AppendFormatLine("		                               AND N.IdTipoNovedadPadre = Padre.IdTipoNovedad")
         .AppendFormatLine("									          AND N.CentroEmisorPadre = Padre.CentroEmisor")
         .AppendFormatLine("									          AND N.LetraPadre = Padre.Letra")
         .AppendFormatLine("        LEFT JOIN Clientes C ON C.IdCliente = N.IdCliente")
         .AppendFormatLine("        LEFT JOIN Proyectos P ON N.IdProyecto = P.IdProyecto")
         .AppendFormatLine("        LEFT JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendFormatLine("        LEFT JOIN EstadosClientes E ON E.IdEstadoCliente = C.IdEstado")
         .AppendFormatLine("        LEFT JOIN TiposClientes T ON T.IdTipoCliente = C.IdTipoCliente")
         .AppendFormatLine("        LEFT JOIN ProyectosEstados PE ON PE.IdEstado = P.IdEstado")
         .AppendFormatLine("        LEFT JOIN Clasificaciones CL ON CL.IdClasificacion = P.IdClasificacion")

         If verDetalleActividades Then
            .AppendFormatLine("        LEFT JOIN Funciones F ON F.Id = N.IdFuncion")
         End If

         .AppendFormatLine(" WHERE TN.ReportaCantidad = 'True'")
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND N.IdUsuarioAsignado = '{0}' ", idUsuario)
         End If

         If idCliente.HasValue Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente.Value)
         End If
         If idProyecto.HasValue Then
            .AppendFormatLine("   AND P.IdProyecto = {0}", idProyecto.Value)
         End If
         If idCategoriaNovedad.HasValue AndAlso idCategoriaNovedad.Value > 0 Then
            .AppendFormatLine("   AND N.IdCategoriaNovedad = {0}", idCategoriaNovedad.Value)
         End If
         If idTipoCategoriaNovedad.HasValue AndAlso idTipoCategoriaNovedad.Value > 0 Then
            .AppendFormatLine("   AND CN.IdTipoCategoriaNovedad = {0}", idTipoCategoriaNovedad.Value)
         End If
         If idNovedad <> 0 Then
            .AppendFormatLine("   AND Padre.IdNovedad = {0}", idNovedad)
         End If
         If Not String.IsNullOrEmpty(idFuncion) Then
            .AppendFormatLine("   AND Padre.IdFuncion = '{0}'", idFuncion)
         End If
         If Not String.IsNullOrEmpty(idAplicacion) Then
            .AppendFormatLine("   AND Padre.IdSistema = '{0}'", idAplicacion)
         End If
         If Not String.IsNullOrEmpty(nroVersion) Then
            .AppendFormatLine("   AND Padre.Version = '{0}'", nroVersion)
         End If

         If revisionAdministrativa <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND N.RevisionAdministrativa = {0}", GetStringFromBoolean(revisionAdministrativa = Entidades.Publicos.SiNoTodos.SI))
         End If
         .AppendFormatLine("   AND N.FechaNovedad BETWEEN '{0}' AND '{1}') AS N", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         .Append(" PIVOT (SUM(avance) FOR FechaNovedad IN (")
         For Each dia As String In dias
            .AppendFormat("{0},", dia)
         Next
         .Remove(.Length - 1, 1)
         .AppendLine(")) AS tabla")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetNovedadesPorVersion(idAplicacion As String, idZonaGeografica As String, nroVersionDesde As String, nroVersionHasta As String) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT N.IdCategoriaNovedad, CN.NombreCategoriaNovedad, N.IdNovedad as Novedad, N.IdTipoNovedad, N.FechaNovedad, N.Descripcion, N.IdFuncion, N.Version, N.VersionFecha ")
         .AppendLine("     , CASE WHEN FP.Nombre IS NULL THEN '' ELSE F.Nombre END AS NombreFuncion, F.IdPadre, ISNULL(FP.Nombre, F.Nombre) AS NombreFuncionPadre")
         .AppendLine("     , F.Plus, F.Express, F.Basica, F.PV, N.IdCliente, C.CodigoCliente, C.NombreCliente, CN.Reporta, N.IdSistema as ZonaGeografica")
         .AppendLine("  FROM CRMNovedades N ")
         .AppendLine(" INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad ")
         .AppendLine(" INNER JOIN Funciones F ON F.Id = N.IdFuncion ")
         .AppendLine("  LEFT JOIN Funciones FP ON FP.Id = F.IdPadre")
         .AppendLine("  LEFT JOIN Clientes C ON C.IdCliente = N.IdCliente")
         .AppendLine(" WHERE CN.Reporta IN ('SI', 'CLIENTE')")

         If idAplicacion = "SIGA" Then
            If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
               .AppendFormatLine("   AND N.IdSistema IN ('{0}')", idZonaGeografica)
            Else
               .AppendFormatLine("   AND N.IdSistema IN ('SIGA', 'SIGA-MD', 'SILIVE')")
            End If
            'GAR: 06/12/2024. Chanchada para poder incorporar los pendientes de MD que tienen 12 meses sumado a la version. Cuando unifiqus y actualicemos la historio esto podra sacarse.
            .AppendFormatLine("   AND N.Version >= '{0}'", nroVersionDesde)
            '---------------------------------------
          Else
            .AppendFormatLine("   AND N.IdSistema = '{0}'", idAplicacion)
            .AppendFormatLine("   AND N.Version >= '{0}'", nroVersionDesde)
            .AppendFormatLine("   AND N.Version <= '{0}'", nroVersionHasta)
         End If
         .AppendFormatLine("   AND N.IdTipoNovedad = 'PENDIENTE'")
         .AppendFormatLine("   AND N.IdTipoNovedad = 'PENDIENTE'")


         .AppendLine(" ORDER BY N.Version")
      End With
      Return GetDataTable(stb)
   End Function


   Public Function GetNovedadesParaWeb(fechaMinimaTicketsFinalizados As Date, fechaMinimaMejorasFinalizados As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT N.*")
         .AppendFormatLine("      ,C.CodigoCliente")
         .AppendFormatLine("      ,ISNULL(NS.Comentario, '') Comentario")
         .AppendFormatLine("      ,TN.NombreTipoNovedad")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = N.IdCliente")
         '.AppendFormatLine("  LEFT JOIN (SELECT IdTipoNovedad, Letra, CentroEmisor, IdNovedad, MIN(IdSeguimiento) IdSeguimientoMin FROM CRMNovedadesSeguimiento")
         '.AppendFormatLine("              WHERE EsComentario = 1")
         '.AppendFormatLine("             GROUP BY IdTipoNovedad, Letra, CentroEmisor, IdNovedad) X")
         '.AppendFormatLine("         ON X.IdTipoNovedad = N.IdTipoNovedad AND X.Letra = N.Letra AND X.CentroEmisor = N.CentroEmisor AND X.IdNovedad = N.IdNovedad")
         .AppendFormatLine("  LEFT JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = N.IdTipoNovedad AND NS.Letra = N.Letra AND NS.CentroEmisor = N.CentroEmisor AND NS.IdNovedad = N.IdNovedad")
         .AppendFormatLine("                                      AND NS.ComentarioPrincipal = 'True'")
         '.AppendFormatLine("                                      AND NS.IdSeguimiento = X.IdSeguimientoMin")
         .AppendFormatLine(" INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = N.IdTipoNovedad")
         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad")
         .AppendFormatLine(" WHERE 1 = 1", ObtenerFecha(fechaMinimaTicketsFinalizados, True))
         .AppendFormatLine("   AND CN.PublicarEnWeb = 'True'")
         .AppendFormatLine("   AND ((N.IdTipoNovedad = 'TICKETS' AND (E.Finalizado = 'False' OR (E.Finalizado = 'True' AND N.FechaEstadoNovedad > '{0}'))) OR", ObtenerFecha(fechaMinimaTicketsFinalizados, True))
         .AppendFormatLine("        (N.IdTipoNovedad = 'PENDIENTE' AND N.FechaEstadoNovedad > '{0}'))", ObtenerFecha(fechaMinimaMejorasFinalizados, True))
         .AppendFormatLine("   AND CN.Reporta IN ('SI', 'CLIENTE')")

         ', 'PENDIENTE'
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetCantidadNovedadesPorProyecto(idProyecto As Integer, finalizado As Boolean) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT COUNT(CN.IdTipoNovedad) Cantidad, CN.IdTipoNovedad, CTN.NombreTipoNovedad  FROM CRMNovedades CN")
         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades CEN ON CN.IdEstadoNovedad = CEN.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN CRMTiposNovedades CTN ON CN.IdTipoNovedad = CTN.IdTipoNovedad")
         .AppendFormatLine("WHERE 1=1")
         .AppendFormatLine("  AND CEN.Finalizado = {0}", GetStringFromBoolean(finalizado))
         .AppendFormatLine("  AND CN.IdProyecto = {0}", idProyecto)
         .AppendFormatLine("GROUP BY CN.IdTipoNovedad, CTN.NombreTipoNovedad")
      End With
      Return GetDataTable(query)
   End Function

   Public Sub ActualizarDatosVentaCRM(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long,
                                      idSucursalFact As Integer?, idTipoComprobanteFact As String, letraFact As String, centroEmisorFact As Integer?, numeroComprobanteFact As Long?)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE N SET ")
         If idSucursalFact.HasValue AndAlso idSucursalFact.Value > 0 Then
            .AppendFormatLine("         N.IdSucursalFact = {0},", idSucursalFact.Value)
            .AppendFormatLine("			 N.IdTipoComprobanteFact = '{0}',", idTipoComprobanteFact)
            .AppendFormatLine("			 N.LetraFact = '{0}',", letraFact)
            .AppendFormatLine("			 N.CentroEmisorFact = {0},", centroEmisorFact.Value)
            .AppendFormatLine("			 N.NumeroComprobanteFact = {0}", numeroComprobanteFact.Value)

         Else
            .AppendFormatLine("         N.IdSucursalFact = NULL,")
            .AppendFormatLine("         N.IdTipoComprobanteFact = NULL,")
            .AppendFormatLine("         N.LetraFact = NULL,")
            .AppendFormatLine("         N.CentroEmisorFact = NULL,")
            .AppendFormatLine("         N.NumeroComprobanteFact = NULL")

         End If
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdNovedad = {0} AND N.IdTipoNovedad = '{1}' AND N.Letra = '{2}' AND N.CentroEmisor = {3}", idNovedad, idTipoNovedad, letra, centroEmisor)
      End With
      Execute(query)
   End Sub

   Public Sub ActualizarAnticipos(idTipoNovedad As String,
                                  letra As String,
                                  centroEmisor As Short,
                                  idNovedad As Long,
                                  importeNovedad As Double)

      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE CRMNovedades SET ")
         .AppendFormatLine("		AnticipoNovedad = ISNULL(AnticipoNovedad,0) + {0} ", importeNovedad)
         .AppendFormatLine(" WHERE IdNovedad = {0} AND IdTipoNovedad = '{1}' AND Letra = '{2}' AND CentroEmisor = {3}", idNovedad, idTipoNovedad, letra, centroEmisor)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ObtenerServiciosFacturados(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Short,
                                              numeroComprobante As Long) As DataTable

      Dim query = New StringBuilder()
      With query
         SelectTexto(query, esAuditoria:=False)
         '.AppendFormatLine("SELECT *,NP.Descripcion DescripcionPadre FROM CRMNovedades N")
         '.AppendFormatLine("LEFT JOIN CRMNovedades NP ON N.IdTipoNovedadPadre = NP.IdTipoNovedad")
         '.AppendFormatLine("					      AND N.LetraPadre = NP.Letra")
         '.AppendFormatLine("						  AND N.CentroEmisorPadre = NP.CentroEmisor")
         '.AppendFormatLine("						  AND N.IdNovedadPadre = NP.IdNovedad")
         .AppendFormatLine(" WHERE N.IdSucursalFact = {0}", idSucursal)
         .AppendFormatLine("   AND N.IdTipoComprobanteFact = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND N.LetraFact = '{0}'", letra)
         .AppendFormatLine("   AND N.CentroEmisorFact = {0}", centroEmisor)
         .AppendFormatLine("   AND N.NumeroComprobanteFact = {0}", numeroComprobante)
      End With
      Return GetDataTable(query)
   End Function

   Public Function GetAuditoriaCRMNovedades(fechaDesde As Date?,
                                            fechaHasta As Date?,
                                            idTipoNovedad As String,
                                            idNovedad As Long,
                                            tipoOperacion As String) As DataTable
      Dim query = New StringBuilder()
      With query

         '# Paso por parámetro los campos correspondientes a la auditoría
         SelectTexto(query, esAuditoria:=True, campoCalculado:=",' ' Modificado, N.FechaAuditoria, CONVERT(DATE, N.FechaAuditoria) FechaAuditoria_Fecha, CONVERT(TIME, N.FechaAuditoria) FechaAuditoria_Hora, N.OperacionAuditoria , N.UsuarioAuditoria")

         .AppendFormatLine("WHERE 1=1")
         If fechaDesde.HasValue Then
            .AppendFormatLine(" AND N.FechaAuditoria >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine(" AND N.FechaAuditoria <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         If idNovedad > 0 Then .AppendFormatLine(" AND N.IdNovedad = {0}", idNovedad)
         If Not String.IsNullOrEmpty(tipoOperacion) Then
            Select Case tipoOperacion
               Case Entidades.OperacionesAuditorias.Alta.ToString()
                  .AppendFormatLine(" AND N.OperacionAuditoria = 'A'")
               Case Entidades.OperacionesAuditorias.Modificacion.ToString()
                  .AppendFormatLine(" AND N.OperacionAuditoria = 'M'")
               Case Entidades.OperacionesAuditorias.Baja.ToString()
                  .AppendFormatLine(" AND N.OperacionAuditoria = 'B'")
            End Select
         End If
         If Not String.IsNullOrEmpty(idTipoNovedad) Then .AppendFormatLine(" AND N.IdTipoNovedad = '{0}'", idTipoNovedad)

         .AppendFormatLine("")
         .AppendFormatLine(" ORDER BY N.IdNovedad, N.FechaAuditoria")
      End With
      Return GetDataTable(query)
   End Function

   Public Function GetInfCRMServiceCabecera(idSucursal As Integer,
                                            desdeFechaNovedad As Date?, hastaFechaNovedad As Date?, nullFechaNovedad As Boolean,
                                            desdeFechaHoraEnvioGarantia As Date?, hastaFechaHoraEnvioGarantia As Date?, nullFechaHoraEnvioGarantia As Boolean,
                                            desdeFechaHoraRetiroGarantia As Date?, hastaFechaHoraRetiroGarantia As Date?, nullFechaHoraRetiroGarantia As Boolean,
                                            desdeFechaHoraRetiro As Date?, hastaFechaHoraRetiro As Date?, nullFechaHoraRetiro As Boolean,
                                            desdeFechaHoraEntrega As Date?, hastaFechaHoraEntrega As Date?, nullFechaHoraEntrega As Boolean, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                            idProducto As String,
                                            idEstadoNovedad As Integer,
                                            idProveedorService As Long,
                                            idCliente As Long) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine(" SELECT N.IdTipoNovedad")
         .AppendFormatLine("  , N.Letra")
         .AppendFormatLine("  , N.CentroEmisor")
         .AppendFormatLine("  , N.IdNovedad")
         .AppendFormatLine("  , N.Descripcion")
         .AppendFormatLine("  , CONVERT(DATE, N.FechaNovedad) AS FechaNovedad_Fecha")
         .AppendFormatLine("  , CONVERT(VARCHAR(5), N.FechaNovedad, 108) AS FechaNovedad_Hora")

         .AppendFormatLine("  , CONVERT(DATE, N.FechaHoraRetiro) AS FechaRetiro_Fecha")
         .AppendFormatLine("  , CONVERT(VARCHAR(5), N.FechaHoraRetiro, 108) AS FechaRetiro_Hora ")
         .AppendFormatLine("  , CONVERT(DATE, N.FechaHoraEntrega) AS FechaEntregado_Fecha ")
         .AppendFormatLine("  , CONVERT(VARCHAR(5), N.FechaHoraEntrega, 108) AS FechaEntregado_Hora ")

         .AppendFormatLine("  , CONVERT(DATE, N.FechaHoraEnvioGarantia) AS FechaEntregadoGarantia_Fecha")
         .AppendFormatLine("  , CONVERT(VARCHAR(5), N.FechaHoraEnvioGarantia, 108) AS FechaEntregadoGarantia_Hora")
         .AppendFormatLine("  , CONVERT(DATE, N.FechaHoraRetiroGarantia) AS FechaRetiroGarantia_Fecha")
         .AppendFormatLine("  , CONVERT(VARCHAR(5), N.FechaHoraRetiroGarantia, 108) AS FechaRetiroGarantia_Hora")

         .AppendFormatLine("  , C.NombreCliente")
         .AppendFormatLine("  , C.Direccion")
         .AppendFormatLine("  , L.NombreLocalidad")
         .AppendFormatLine("  , (CASE WHEN N.NombreProducto IS NULL THEN P.NombreProducto ELSE N.NombreProducto END) AS NombreProducto")
         .AppendFormatLine("  , N.NombreMarcaProducto AS NombreMarca")
         .AppendFormatLine("  , N.NombreModeloProducto AS NombreModelo")
         .AppendFormatLine("  , N.NroDeSerie AS NumeroSerie")
         .AppendFormatLine("  , PR.NombreProveedor AS NombreProveedorService")
         .AppendFormatLine("  , ENE.NombreEstadoNovedad AS Estado")

         '-- REQ-36519.- -------------------------------------------------------------------------
         .AppendFormatLine("  , (CASE WHEN N.FechaHoraEntrega Is NULL THEN NULL ELSE (CASE WHEN N.IdDomicilioEntrega Is NULL THEN C.Direccion ELSE CDE.Direccion END) END) AS DomicilioEntrega")
         .AppendFormatLine("  , (CASE WHEN N.FechaHoraRetiro  Is NULL THEN NULL ELSE (CASE WHEN N.IdDomicilioRetiro  Is NULL THEN C.Direccion ELSE CDR.Direccion END) END) AS DomicilioRetiro")
         '----------------------------------------------------------------------------------------
         .AppendFormatLine("  , NS.Comentario
                              , (CASE WHEN N.IdProveedorGarantia IS NULL THEN 'NO' ELSE 'SI' END) AS GARANTIA
                              , N.CostoReparacion")
         .AppendFormatLine(" FROM CRMNovedades AS N")
         .AppendFormatLine("  INNER JOIN CRMTiposNovedades AS TN ON TN.IdTipoNovedad = N.IdTipoNovedad")
         .AppendFormatLine("  LEFT JOIN Clientes AS C ON C.IdCliente = N.IdCliente")
         .AppendFormatLine("  LEFT JOIN Localidades l  ON L.IdLocalidad = C.IdLocalidad")
         '-- REQ-36519.- -------------------------------------------------------------------------
         .AppendFormatLine("  LEFT JOIN ClientesDirecciones AS CDE ON CDE.IdCliente = N.IdCliente AND CDE.IdDireccion = ")
         .AppendFormatLine("       (CASE WHEN N.FechaHoraEntrega Is NULL THEN NULL ELSE (CASE WHEN N.IdDomicilioEntrega Is NULL THEN 0 ELSE N.IdDomicilioEntrega  END) END)")
         .AppendFormatLine("  LEFT JOIN ClientesDirecciones AS CDR ON CDR.IdCliente = N.IdCliente AND CDR.IdDireccion =")
         .AppendFormatLine("       (CASE WHEN N.FechaHoraRetiro  IS NULL THEN NULL ELSE (CASE WHEN N.IdDomicilioRetiro  IS NULL THEN 0 ELSE N.IdDomicilioRetiro   END) END)")
         '----------------------------------------------------------------------------------------
         .AppendFormatLine("  LEFT JOIN Productos AS P ON P.IdProducto = N.IdProducto")
         .AppendFormatLine("  LEFT JOIN Modelos AS M ON M.IdModelo = P.IdModelo")
         .AppendFormatLine("  LEFT JOIN Proveedores AS PR ON PR.IdProveedor = N.IdProveedorGarantia ")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS ENE ON ENE.IdEstadoNovedad = N.IdEstadoNovedad ")
         .AppendFormatLine("  LEFT JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = N.IdTipoNovedad 
                               AND NS.IdNovedad = N.IdNovedad 
                               AND NS.Letra = N.Letra AND NS.CentroEmisor = n.CentroEmisor 
                               AND NS.EsComentario = 1 AND NS.ComentarioPrincipal = 1")
         .AppendFormatLine("  WHERE EXISTS(SELECT 1 FROM CRMTiposNovedadesDinamicos TND WHERE TND.IdTipoNovedad = TN.IdTipoNovedad AND TND.IdNombreDinamico = '{0}')",
                           Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString())

         If desdeFechaNovedad.HasValue Then
            .AppendFormat("  AND N.FechaNovedad >= '{0}'", ObtenerFecha(desdeFechaNovedad.Value, True))
         End If
         If hastaFechaNovedad.HasValue Then
            .AppendFormat("  AND N.FechaNovedad <= '{0}'", ObtenerFecha(hastaFechaNovedad.Value, True))
         End If
         If Not desdeFechaNovedad.HasValue AndAlso Not hastaFechaNovedad.HasValue AndAlso nullFechaNovedad Then
            .AppendFormat("  AND N.FechaNovedad IS NULL")
         End If

         If desdeFechaHoraEnvioGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraEnvioGarantia >= '{0}'", ObtenerFecha(desdeFechaHoraEnvioGarantia.Value, True))
         End If
         If hastaFechaHoraEnvioGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraEnvioGarantia <= '{0}'", ObtenerFecha(hastaFechaHoraEnvioGarantia.Value, True))
         End If
         If Not desdeFechaHoraEnvioGarantia.HasValue AndAlso Not hastaFechaHoraEnvioGarantia.HasValue AndAlso nullFechaHoraEnvioGarantia Then
            .AppendFormat("  AND N.FechaHoraEnvioGarantia IS NULL")
         End If
         If desdeFechaHoraRetiroGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiroGarantia >= '{0}'", ObtenerFecha(desdeFechaHoraRetiroGarantia.Value, True))
         End If
         If hastaFechaHoraRetiroGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiroGarantia <= '{0}'", ObtenerFecha(hastaFechaHoraRetiroGarantia.Value, True))
         End If
         If Not desdeFechaHoraRetiroGarantia.HasValue AndAlso Not hastaFechaHoraRetiroGarantia.HasValue AndAlso nullFechaHoraRetiroGarantia Then
            .AppendFormat("  AND N.FechaHoraRetiroGarantia IS NULL")
         End If

         If desdeFechaHoraRetiro.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiro >= '{0}'", ObtenerFecha(desdeFechaHoraRetiro.Value, True))
         End If
         If hastaFechaHoraRetiro.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiro <= '{0}'", ObtenerFecha(hastaFechaHoraRetiro.Value, True))
         End If
         If Not desdeFechaHoraRetiro.HasValue AndAlso Not hastaFechaHoraRetiro.HasValue AndAlso nullFechaHoraRetiro Then
            .AppendFormat("  AND N.FechaHoraRetiro IS NULL")
         End If
         If desdeFechaHoraEntrega.HasValue Then
            .AppendFormat("  AND N.FechaHoraEntrega >= '{0}'", ObtenerFecha(desdeFechaHoraEntrega.Value, True))
         End If
         If hastaFechaHoraEntrega.HasValue Then
            .AppendFormat("  AND N.FechaHoraEntrega <= '{0}'", ObtenerFecha(hastaFechaHoraEntrega.Value, True))
         End If
         If Not desdeFechaHoraEntrega.HasValue AndAlso Not hastaFechaHoraEntrega.HasValue AndAlso nullFechaHoraEntrega Then
            .AppendFormat("  AND N.FechaHoraEntrega IS NULL")
         End If

         ''FILTROS FECHAS
         'If fechaDesde.HasValue Then
         '   .AppendFormat("  AND N.{1} >= '{0}'", ObtenerFecha(fechaDesde.Value, True), tipoFechaFiltro.ToString())
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormat("  AND N.{1} <= '{0}'", ObtenerFecha(fechaHasta.Value, True), tipoFechaFiltro.ToString())
         'End If

         If idSucursal > 0 Then
            .AppendFormatLine("  AND N.IdSucursalNovedad = {0}", idSucursal)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("  AND P.IdProducto = '{0}'", idProducto)
         End If
         If idEstadoNovedad > 0 Then
            .AppendFormatLine("  AND N.IdEstadoNovedad = {0}", idEstadoNovedad)
         End If

         If idProveedorService > 0 Then
            .AppendFormatLine("  AND N.IdProveedorService = {0}", idProveedorService)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("  AND N.IdCliente = {0}", idCliente)
         End If

      End With
      Return GetDataTable(query)
   End Function

   Public Function GetInfCRMServiceDetalle(idSucursal As Integer,
                                           desdeFechaNovedad As Date?, hastaFechaNovedad As Date?, nullFechaNovedad As Boolean,
                                           desdeFechaHoraEnvioGarantia As Date?, hastaFechaHoraEnvioGarantia As Date?, nullFechaHoraEnvioGarantia As Boolean,
                                           desdeFechaHoraRetiroGarantia As Date?, hastaFechaHoraRetiroGarantia As Date?, nullFechaHoraRetiroGarantia As Boolean,
                                           desdeFechaHoraRetiro As Date?, hastaFechaHoraRetiro As Date?, nullFechaHoraRetiro As Boolean,
                                           desdeFechaHoraEntrega As Date?, hastaFechaHoraEntrega As Date?, nullFechaHoraEntrega As Boolean, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                           idProducto As String,
                                           idEstadoNovedad As Integer,
                                           idTipoComentario As Integer,
                                           visibleClientes As Entidades.Publicos.SiNoTodos,
                                           visibleRepresentantes As Entidades.Publicos.SiNoTodos) As DataTable

      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT NS.Comentario")
         .AppendFormatLine("  , N.IdTipoNovedad")
         .AppendFormatLine("  , N.Letra")
         .AppendFormatLine("  , N.CentroEmisor")
         .AppendFormatLine("  , N.IdNovedad")
         .AppendFormatLine("  ,CONVERT(DATE, N.FechaNovedad) AS FechaNovedad_Fecha")
         .AppendFormatLine("  , (CASE WHEN N.NombreProducto IS NULL THEN  P.NombreProducto ELSE N.NombreProducto END) AS NombreProducto")
         .AppendFormatLine("  , M.NombreModelo")
         .AppendFormatLine("  , P.NumeroSerie")
         .AppendFormatLine(" FROM CRMNovedades N")
         .AppendFormatLine(" INNER JOIN CRMTiposNovedades AS TN ON TN.IdTipoNovedad = N.IdTipoNovedad ")
         .AppendFormatLine("  LEFT JOIN Clientes AS C ON C.IdCliente = N.IdCliente")
         .AppendFormatLine("  LEFT JOIN Localidades l  ON L.IdLocalidad = C.IdLocalidad")
         .AppendFormatLine("  LEFT JOIN Productos AS P ON P.IdProducto = N.IdProducto")
         .AppendFormatLine("  LEFT JOIN Modelos AS M ON M.IdModelo = P.IdModelo")
         .AppendFormatLine("  LEFT JOIN Proveedores AS PR1 ON PR1.IdProveedor = N.IdProveedorService")

         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS ENP ON ENP.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine("  LEFT JOIN CRMNovedadesSeguimiento NS ON N.IdTipoNovedad = NS.IdTipoNovedad AND N.IdNovedad = NS.IdNovedad")
         .AppendFormatLine("  LEFT JOIN CRMTiposComentariosNovedades TCN ON TN.IdTipoNovedad = TCN.IdTipoNovedad AND NS.IdTipoComentarioNovedad = TCN.IdTipoComentarioNovedad")

         .AppendFormatLine("  WHERE EXISTS(SELECT 1 FROM CRMTiposNovedadesDinamicos TND WHERE TND.IdTipoNovedad = TN.IdTipoNovedad AND TND.IdNombreDinamico = '{0}')",
                           Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString())

         If desdeFechaNovedad.HasValue Then
            .AppendFormat("  AND N.FechaNovedad >= '{0}'", ObtenerFecha(desdeFechaNovedad.Value, True))
         End If
         If hastaFechaNovedad.HasValue Then
            .AppendFormat("  AND N.FechaNovedad <= '{0}'", ObtenerFecha(hastaFechaNovedad.Value, True))
         End If
         If Not desdeFechaNovedad.HasValue AndAlso Not hastaFechaNovedad.HasValue AndAlso nullFechaNovedad Then
            .AppendFormat("  AND N.FechaNovedad IS NULL")
         End If

         If desdeFechaHoraEnvioGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraEnvioGarantia >= '{0}'", ObtenerFecha(desdeFechaHoraEnvioGarantia.Value, True))
         End If
         If hastaFechaHoraEnvioGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraEnvioGarantia <= '{0}'", ObtenerFecha(hastaFechaHoraEnvioGarantia.Value, True))
         End If
         If Not desdeFechaHoraEnvioGarantia.HasValue AndAlso Not hastaFechaHoraEnvioGarantia.HasValue AndAlso nullFechaHoraEnvioGarantia Then
            .AppendFormat("  AND N.FechaHoraEnvioGarantia IS NULL")
         End If
         If desdeFechaHoraRetiroGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiroGarantia >= '{0}'", ObtenerFecha(desdeFechaHoraRetiroGarantia.Value, True))
         End If
         If hastaFechaHoraRetiroGarantia.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiroGarantia <= '{0}'", ObtenerFecha(hastaFechaHoraRetiroGarantia.Value, True))
         End If
         If Not desdeFechaHoraRetiroGarantia.HasValue AndAlso Not hastaFechaHoraRetiroGarantia.HasValue AndAlso nullFechaHoraRetiroGarantia Then
            .AppendFormat("  AND N.FechaHoraRetiroGarantia IS NULL")
         End If

         If desdeFechaHoraRetiro.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiro >= '{0}'", ObtenerFecha(desdeFechaHoraRetiro.Value, True))
         End If
         If hastaFechaHoraRetiro.HasValue Then
            .AppendFormat("  AND N.FechaHoraRetiro <= '{0}'", ObtenerFecha(hastaFechaHoraRetiro.Value, True))
         End If
         If Not desdeFechaHoraRetiro.HasValue AndAlso Not hastaFechaHoraRetiro.HasValue AndAlso nullFechaHoraRetiro Then
            .AppendFormat("  AND N.FechaHoraRetiro IS NULL")
         End If
         If desdeFechaHoraEntrega.HasValue Then
            .AppendFormat("  AND N.FechaHoraEntrega >= '{0}'", ObtenerFecha(desdeFechaHoraEntrega.Value, True))
         End If
         If hastaFechaHoraEntrega.HasValue Then
            .AppendFormat("  AND N.FechaHoraEntrega <= '{0}'", ObtenerFecha(hastaFechaHoraEntrega.Value, True))
         End If
         If Not desdeFechaHoraEntrega.HasValue AndAlso Not hastaFechaHoraEntrega.HasValue AndAlso nullFechaHoraEntrega Then
            .AppendFormat("  AND N.FechaHoraEntrega IS NULL")
         End If

         If idSucursal > 0 Then
            .AppendFormatLine("  AND N.IdSucursalNovedad = {0}", idSucursal)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("  AND P.IdProducto = '{0}'", idProducto)
         End If
         If idEstadoNovedad > 0 Then
            .AppendFormatLine("  AND N.IdEstadoNovedad = {0}", idEstadoNovedad)
         End If
         If idTipoComentario > 0 Then
            .AppendFormatLine("  AND TCN.IdTipoComentarioNovedad = {0}", idTipoComentario)
         End If

         If visibleClientes <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND TCN.VisibleParaCliente = {0}", GetStringFromBoolean(visibleClientes = Entidades.Publicos.SiNoTodos.SI))
         End If

         If visibleRepresentantes = Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND TCN.VisibleParaRepresentante = {0}", GetStringFromBoolean(visibleRepresentantes = Entidades.Publicos.SiNoTodos.SI))
         End If

      End With
      Return GetDataTable(query)
   End Function
End Class