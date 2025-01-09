Public Class CalidadOrdenDeControl
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadOrdenDeControl"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Fecha
      IdProveedor
      IdProducto
      IdLote
      IdDeposito
      IdUbicacion
      IdSucursalCompra
      IdTipoComprobanteCompra
      LetraCompra
      CentroEmisorCompra
      NumeroComprobanteCompra
      OrdenComprobanteCompra
      CantidadControlar
      IdEstadoCalidad
      Observaciones
      IdUsuarioAlta
      FechaAlta
      IdUsuarioActualizacion
      FechaActualizacion

   End Enum

   Public Sub New()
      CalidadOrdenDeControlItems = New List(Of CalidadOrdenDeControlItem)
      EstadoCalidad = New EstadoOrdenCalidad()
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Fecha As Date
   Public Property IdProducto As String

   Public Property IdDeposito As Integer?
   Public Property IdUbicacion As Integer?
   Public Property IdLote As String

   Public Property IdProveedor As Long?
   Public Property IdSucursalCompra As Integer?
   Public Property IdTipoComprobanteCompra As String
   Public Property LetraCompra As String
   Public Property CentroEmisorCompra As Integer?
   Public Property NumeroComprobanteCompra As Long?
   Public Property OrdenComprobanteCompra As Integer?

   Public Property CantidadControlar As Decimal

   Public Property EstadoCalidad As EstadoOrdenCalidad
   Public Property CalidadOrdenDeControlItems As List(Of CalidadOrdenDeControlItem)

   Public Property Observaciones As String

   Public Property IdUsuarioAlta As String
   Public Property FechaAlta As Date
   Public Property IdUsuarioActualizacion As String
   Public Property FechaActualizacion As Date

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdEstadoCalidad As String
      Get
         Return EstadoCalidad.IdEstadoCalidad
      End Get
   End Property
#End Region

End Class