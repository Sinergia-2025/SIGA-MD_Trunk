Namespace JSonEntidades.Archivos.CRM
   Public Class CRMNovedadJSon
      Implements IValidable

      Public Property IdTipoNovedad As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property IdNovedad As Long
      Public Property FechaNovedad As String
      Public Property Descripcion As String
      Public Property IdPrioridadNovedad As Integer
      Public Property IdCategoriaNovedad As Integer
      Public Property IdMedioComunicacionNovedad As Integer?
      Public Property IdMetodoResolucionNovedad As Integer?
      Public Property IdEstadoNovedad As Integer
      Public Property FechaEstadoNovedad As String
      Public Property IdUsuarioEstadoNovedad As String
      Public Property FechaAlta As String
      Public Property IdUsuarioAlta As String
      Public Property IdUsuarioAsignado As String
      Public Property IdUsuarioResponsable As String
      Public Property Avance As Decimal

      Public Property IdProyecto As Integer

      Public Property IdCliente As Long
      Public Property IdProspecto As Long
      Public Property IdProveedor As Long
      Public Property IdFuncion As String
      Public Property IdSistema As String

      Public Property FechaProximoContacto As String
      Public Property BanderaColor As Integer?

      Public Property Interlocutor As String

      Public Property RevisionAdministrativa As Boolean
      Public Property Priorizado As Boolean
      Public Property IdTipoNovedadPadre As String
      Public Property LetraPadre As String
      Public Property CentroEmisorPadre As Short
      Public Property IdNovedadPadre As Long
      Public Property Version As String
      Public Property VersionFecha As String
      Public Property FechaInicioPlan As String
      Public Property FechaFinPlan As String

      Public Property TiempoEstimado As Decimal

      Public Property Cantidad As Decimal
      Public Property IdSucursalService As Integer
      Public Property IdTipoComprobanteService As String
      Public Property LetraService As String
      Public Property CentroEmisorService As Short
      Public Property NumeroComprobanteService As Long
      Public Property IdProducto As String
      Public Property NombreProducto As String
      Public Property CantidadProducto As Decimal
      Public Property CostoReparacion As Decimal
      Public Property IdProductoPrestado As String
      Public Property CantidadProductoPrestado As Decimal
      Public Property NroSerieProductoPrestado As String
      Public Property ProductoPrestadoDevuelto As Boolean
      Public Property IdProveedorService As Long
      Public Property Contador1 As Integer
      Public Property Contador2 As Integer
      Public Property FechaActualizacionWeb As String
      Public Property IdProductoNovedad As String
      Public Property EtiquetaNovedad As String
      Public Property NroDeSerie As String
      Public Property TieneGarantiaService As Boolean?
      Public Property UbicacionService As String
      Public Property IdSucursalFact As Integer?
      Public Property IdTipoComprobanteFact As String
      Public Property LetraFact As String
      Public Property CentroEmisorFact As Integer?
      Public Property NumeroComprobanteFact As Long?
      Public Property RequiereTesteo As Boolean
      Public Property FechaEntregado As String
      Public Property FechaFinalizado As String
      Public Property IdEstadoNovedadEntregado As Integer?
      Public Property IdEstadoNovedadFinalizado As Integer?
      Public Property IdUsuarioEntregado As String
      Public Property IdUsuarioFinalizado As String
      Public Property IdEstadoNovedadAnterior As Integer?
      Public Property AvanceAnterior As Decimal?
      Public Property Observacion As String
      Public Property ClienteValorizacionEstrellas As Decimal?

      '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --
      Public Property AnticipoNovedad As Decimal?

      Public Property FechaHoraRetiro As String
      Public Property IdDomicilioRetiro As Integer?
      Public Property FechaHoraEntrega As String
      Public Property IdDomicilioEntrega As Integer?
      Public Property IdProveedorGarantia As Long?
      Public Property FechaHoraEnvioGarantia As String
      Public Property FechaHoraRetiroGarantia As String
      Public Property idMarcaProducto As Integer?
      Public Property NombreMarcaProducto As String
      Public Property idModeloProducto As Integer?
      Public Property NombreModeloProducto As String
      Public Property IdSucursalNovedad As Integer?

      Public Property ServiceLugarCompra As String
      Public Property ServiceLugarCompraFecha As String
      Public Property ServiceLugarCompraTipoComprobante As String
      Public Property ServiceLugarCompraNumeroComprobante As String

      Public Property IdAplicacionTerceros As String
      Public Property IdMotivoNovedad As Integer?
      Public Property ComentarioPrincipal As CRMNovedad.ComentarioPrincipalOptiones
      Public Property PatenteVehiculo As String


      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen

   End Class

   Public Class CRMNovedadJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdTipoNovedad As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property IdNovedad As Long
      Public Property Datos As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdTipoNovedad = idTipoNovedad
         Me.Letra = letra
         Me.CentroEmisor = centroEmisor
         Me.IdNovedad = idNovedad
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace