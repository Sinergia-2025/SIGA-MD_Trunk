Public Class PedidoTiendaWeb
   Inherits Entidad

   Public Const NombreTabla As String = "PedidosTiendasWeb"

   Public Property Id As String
   Public Property SistemaDestino As String
   Public Property Numero As Long
   Public Property IdClienteTiendaWeb As String
   Public Property NombreClienteTiendaWeb As String
   Public Property ObservacionesTiendaWeb As String
   Public Property IdMoneda As String
   Public Property TipoEnvio As String
   Public Property DireccionEnvio As String
   Public Property CostoEnvio As Decimal?
   Public Property FechaPedido As DateTime
   Public Property ImporteTotal As Decimal
   Public Property SubTotal As Decimal
   Private _productos As List(Of PedidoProductoTiendaWeb)
   Public Property Productos() As List(Of PedidoProductoTiendaWeb)
      Get
         If _productos Is Nothing Then
            _productos = New List(Of PedidoProductoTiendaWeb)
         End If
         Return _productos
      End Get
      Set(ByVal value As List(Of PedidoProductoTiendaWeb))
         _productos = value
      End Set
   End Property

   Public Property IdUsuarioEstado As String
   Public Property FechaEstado As DateTime
   Public Property IdUsuarioDescarga As String
   Public Property FechaDescarga As DateTime
   Public Property IdEstadoPedidoTiendaWeb As String
   Public Property MensajeError As String
   Public Property JSON As String
   Public Property NroDocCliente As Long?
   Public Property Email As String
   Public Property Telefono As String
   Public Property DireccionCalle As String
   Public Property DireccionNumero As String
   Public Property Adicional As String
   Public Property CodigoPostal As Integer?
   Public Property Localidad As String
   Public Property Provincia As String
   Public Property Observacion As String
   Public Property PacksIdTiendaWeb As String

   Public Enum Columnas
      Id
      SistemaDestino
      Numero
      IdClienteTiendaWeb
      NombreClienteTiendaWeb
      ObservacionesTiendaWeb
      IdMoneda
      TipoEnvio
      DireccionEnvio
      FechaPedido
      CostoEnvio
      ImporteTotal
      SubTotal
      IdUsuarioEstado
      FechaEstado
      IdUsuarioDescarga
      FechaDescarga
      IdEstadoPedidoTiendaWeb
      MensajeError
      JSON
      NroDocCliente
      Email
      Telefono
      DireccionCalle
      DireccionNumero
      Adicional
      CodigoPostal
      Localidad
      Provincia
      Observacion
      PacksIdTiendaWeb
   End Enum

End Class
Public Enum TiendasWeb
   <Description("Tienda Nube")> TIENDANUBE
   <Description("Mercado Libre")> MERCADOLIBRE
   <Description("Arborea")> ARBOREA
End Enum
