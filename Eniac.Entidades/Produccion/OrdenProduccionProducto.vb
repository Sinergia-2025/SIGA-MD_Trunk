Public Class OrdenProduccionProducto
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      NumeroOrdenProduccion
      IdProducto
      Cantidad
      Precio
      Costo
      ImporteTotal
      NombreProducto
      CantPendiente
      CantEntregada
      CantEnProceso
      CantAnulada
      Orden
      DescuentoRecargoProducto
      DescuentoRecargoPorc2
      DescuentoRecargoPorc
      IdTipoImpuesto
      AlicuotaImpuesto
      ImporteImpuesto
      PrecioLista
      IdTipoComprobante
      Letra
      CentroEmisor
      FechaActualizacion
      IdListaPrecios
      NombreListaPrecios
      ImporteImpuestoInterno
      PrecioNeto
      ImporteTotalNeto
      DescRecGeneral
      DescRecGeneralProducto
      Kilos

      IdCriticidad
      FechaEntrega
      IdFormula

      IdProduccionProceso
      IdProduccionForma
      Espmm
      EspPies
      CodigoSAE
      LargoExtAlto
      AnchoIntBase
      Architrave
      IdProduccionModeloForma

      UrlPlano

      IdResponsable

      IdSucursalPedido
      IdTipoComprobantePedido
      LetraPedido
      CentroEmisorPedido
      NumeroPedido
      IdProductoPedido
      OrdenPedido

   End Enum

   Public Sub New()
      PedidoEstadoQueOrigino = New List(Of PedidoEstado)()
      ProduccionModeloForma = New ProduccionModeloForma()
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Producto As Entidades.Producto
   Public Property Orden As Integer

   Public Property Costo As Decimal
   Public Property Cantidad As Decimal
   Public Property Precio As Decimal
   Public Property ImporteTotal As Decimal
   Public Property CantPendiente As Decimal
   Public Property CantEntregada As Decimal
   Public Property CantEnProceso As Decimal
   Public Property CantAnulada As Decimal

   Public Property DescuentoRecargoProducto As Decimal
   Public Property DescuentoRecargoPorc2 As Decimal
   Public Property DescuentoRecargoPorc As Decimal
   Public Property TipoImpuesto As Entidades.TipoImpuesto
   Public Property AlicuotaImpuesto As Decimal
   Public Property ImporteImpuesto As Decimal
   Public Property PrecioLista As Decimal
   Public Property FechaActualizacion As DateTime
   Public Property IdListaPrecios As Integer
   Public Property NombreListaPrecios As String

   'TODO: Nuevos
   Public Property ImporteImpuestoInterno As Decimal
   Public Property PrecioNeto As Decimal
   Public Property ImporteTotalNeto As Decimal
   Public Property DescRecGeneral As Decimal
   Public Property DescRecGeneralProducto As Decimal
   Public Property Kilos As Decimal

   ''TODO: Agregar el campo en BD
   'Public Property CantPendiente As Decimal

   Private _ordenesProduccionMRP As OrdenProduccionMRP
   Public Property OrdenesProduccionMRP() As OrdenProduccionMRP
      Get
         If _ordenesProduccionMRP Is Nothing Then _ordenesProduccionMRP = New OrdenProduccionMRP
         Return _ordenesProduccionMRP
      End Get
      Set(ByVal value As OrdenProduccionMRP)
         _ordenesProduccionMRP = value
      End Set
   End Property


   Private _OrdenesProduccionEstados As List(Of OrdenProduccionEstado)
   Public Property OrdenesProduccionEstados As List(Of OrdenProduccionEstado)
      Get
         If _OrdenesProduccionEstados Is Nothing Then _OrdenesProduccionEstados = New List(Of OrdenProduccionEstado)()
         Return _OrdenesProduccionEstados
      End Get
      Set(value As List(Of OrdenProduccionEstado))
         _OrdenesProduccionEstados = value
      End Set
   End Property
   Private _ordenesProduccionProductosFormulas As List(Of OrdenProduccionProductoFormula)
   Public Property OrdenesProduccionProductosFormulas() As List(Of OrdenProduccionProductoFormula)
      Get
         If _ordenesProduccionProductosFormulas Is Nothing Then _ordenesProduccionProductosFormulas = New List(Of OrdenProduccionProductoFormula)()
         Return _ordenesProduccionProductosFormulas
      End Get
      Set(ByVal value As List(Of OrdenProduccionProductoFormula))
         _ordenesProduccionProductosFormulas = value
      End Set
   End Property


   Public Property IdCriticidad As String
   Public Property FechaEntrega As Date
   Public Property IdFormula As Integer
   Public Property NombreFormula As String      'Solo para mostrar en grillas. No se persiste.

   Public Property IdProcesoProductivo As Long
   Public Property CodigoProcesoProductivo As String      'Solo para mostrar en grillas. No se persiste.
   Public Property DescripcionProcesoProductivo As String      'Solo para mostrar en grillas. No se persiste.

   Public Property IdProduccionProceso As Integer
   Public Property IdProduccionForma As Integer
   Public Property Espmm As Decimal
   Public Property EspPies As String
   Public Property CodigoSAE As String
   Public Property LargoExtAlto As Decimal
   Public Property AnchoIntBase As Decimal
   Public Property Architrave As Decimal
   Public Property ProduccionModeloForma As ProduccionModeloForma

   Public Property UrlPlano As String

   Public Property IdResponsable As Integer
   Public Property NombreResponsable As String     'Para mostrar en grillas

   Public Property PedidoEstadoQueOrigino As List(Of PedidoEstado)               'Para controlar lógica de pantalla al editar


#Region "Propiedades de Calculo"
   Public Property Stock As Decimal
#End Region

   Public ReadOnly Property IdTipoImpuesto As Entidades.TipoImpuesto.Tipos
      Get
         If TipoImpuesto Is Nothing Then Return Nothing
         Return TipoImpuesto.IdTipoImpuesto
      End Get
   End Property

   Public ReadOnly Property IdProducto As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.IdProducto
      End Get
   End Property

   Public ReadOnly Property NombreProducto() As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.NombreProducto
      End Get
   End Property

   Public ReadOnly Property IdProduccionModeloForma As Integer
      Get
         If ProduccionModeloForma Is Nothing Then Return 0
         Return ProduccionModeloForma.IdProduccionModeloForma
      End Get
   End Property
   Public ReadOnly Property NombreProduccionModeloForma As String
      Get
         If ProduccionModeloForma Is Nothing Then Return String.Empty
         Return ProduccionModeloForma.NombreProduccionModeloForma
      End Get
   End Property


   '-- Campos Nuevos para trasladar el numero de Pedido Origen.- --
   Public Property IdSucursalPedido As Integer
   Public Property IdTipoComprobantePedido As String
   Public Property LetraPedido As String
   Public Property CentroEmisorPedido As Integer
   Public Property NumeroPedido As Integer
   Public Property IdProductoPedido As String
   Public Property OrdenPedido As Integer

End Class
