Public Class PedidoProducto
   Inherits Entidad
   Implements IPKComprobante
   Public Enum Columnas
      IdSucursal
      NumeroPedido
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
      PorcImpuestoInterno
      OrigenPorcImpInt
      PrecioNeto
      ImporteTotalNeto
      DescRecGeneral
      DescRecGeneralProducto
      Kilos
      IdCriticidad
      FechaEntrega

      PrecioConImpuestos
      PrecioNetoConImpuestos
      ImporteTotalConImpuestos
      ImporteTotalNetoConImpuestos

      PrecioVentaPorTamano
      Tamano
      IdUnidadDeMedida
      IdMoneda
      Utilidad

      Espmm
      EspPulgadas
      CodigoSAE
      IdProduccionProceso
      IdProduccionForma
      LargoExtAlto
      AnchoIntBase
      Architrave
      IdProduccionModeloForma

      UrlPlano

      IdFormula
      TipoOperacion
      Nota
      NombreCortoListaPrecios
      Automatico
      ModificoPrecioManualmente
      CantidadManual
      Conversion

      ModificoDescuentos
      EsObservacion
      IdProcesoProductivo
   End Enum

   Public Sub New()
      CodigoSAE = String.Empty
      ProduccionModeloForma = New ProduccionModeloForma()

   End Sub

   Public ReadOnly Property IdTipoComprobante As String
      Get
         If TipoComprobante Is Nothing Then Return String.Empty
         Return TipoComprobante.IdTipoComprobante
      End Get
   End Property
   Public Property TipoComprobante As Entidades.TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property Producto As Entidades.Producto
   Public Property Orden As Integer

   Public Property Costo As Decimal
   Public Property Cantidad As Decimal
   Public Property CantidadOriginal As Decimal     ' Cantidad Original cuando se lee el Pedido y para detectar modificaciones de cantidad.
   Public Property Precio As Decimal
   Public Property ImporteTotal As Decimal

   Public Property CantPendiente As Decimal
   Public Property CantEntregada As Decimal
   Public Property CantEnProceso As Decimal
   Public Property CantAnulada As Decimal
   Public Property CantNoPendienteOriginal As Decimal

   Public Property TipoOperacion As Producto.TiposOperaciones

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

   Public Property ImporteImpuestoInterno As Decimal
   Public Property PorcImpuestoInterno As Decimal
   Public Property OrigenPorcImpInt As Entidades.OrigenesPorcImpInt
   Public Property PrecioNeto As Decimal
   Public Property ImporteTotalNeto As Decimal
   Public Property DescRecGeneral As Decimal
   Public Property DescRecGeneralProducto As Decimal
   Public Property Kilos As Decimal
   Public Property ModificoDescuentos As Boolean

   Public Property EsObservacion As Boolean

   Public Property PrecioConImpuestos As Decimal
   Public Property PrecioNetoConImpuestos As Decimal
   Public Property ImporteTotalConImpuestos As Decimal
   Public Property ImporteTotalNetoConImpuestos As Decimal

   Public Property PrecioVentaPorTamano As Decimal
   Public Property Tamano As Decimal
   Public Property IdUnidadDeMedida As String

   Public Property Moneda As Moneda

   Public Property Utilidad As Decimal
   Public Property ContribucionMarginalPorc As Decimal

   Public Property Espmm As Decimal
   Public Property EspPulgadas As String
   Public Property CodigoSAE As String
   Public Property AnchoIntBase As Decimal
   Public Property LargoExtAlto As Decimal
   Public Property Architrave As Decimal
   Public Property ProduccionModeloForma As ProduccionModeloForma
   Public Property ProduccionProceso As ProduccionProceso
   Public Property ProduccionForma As ProduccionForma
   Public Property UrlPlano As String

   Public Property IdFormula As Integer
   Public Property NombreFormula As String      'Solo para mostrar en grillas. No se persiste.

   Public Property IdProcesoProductivo As Long
   Public Property CodigoProcesoProductivo As String      'Solo para mostrar en grillas. No se persiste.
   Public Property DescripcionProcesoProductivo As String      'Solo para mostrar en grillas. No se persiste.

   Public Property Nota As String

   Public Property NombreCortoListaPrecios As String

   Public Property Automatico As Boolean
   Public Property ModificoPrecioManualmente As Boolean
   Public Property CantidadManual As Decimal
   Public Property Conversion As Decimal
   Public Property CodigoProductoProveedor As String '# Esta propiedad es solo para visualización en grillas. No se guarda en DB

   ''TODO: Agregar el campo en BD
   'Public Property CantPendiente As Decimal

   Private _pedidosEstados As List(Of PedidoEstado)
   Public Property PedidosEstados As List(Of PedidoEstado)
      Get
         If _pedidosEstados Is Nothing Then _pedidosEstados = New List(Of PedidoEstado)()
         Return _pedidosEstados
      End Get
      Set(value As List(Of PedidoEstado))
         _pedidosEstados = value
      End Set
   End Property

   Private _pedidosProductosFormulas As List(Of PedidoProductoFormula)
   Public Property PedidosProductosFormulas() As List(Of PedidoProductoFormula)
      Get
         If _pedidosProductosFormulas Is Nothing Then _pedidosProductosFormulas = New List(Of PedidoProductoFormula)()
         Return _pedidosProductosFormulas
      End Get
      Set(value As List(Of PedidoProductoFormula))
         _pedidosProductosFormulas = value
      End Set
   End Property


   Public Property PrecioDolar As Decimal
   Public Property PrecioNetoDolar As Decimal
   Public Property ImporteTotalDolar As Decimal
   Public Property CostoDolar As Decimal



#Region "Propiedades para Insertar PedidosEstados"
   Public Property IdCriticidad() As String
   Public Property FechaEntrega() As Date
#End Region


#Region "Propiedades de Calculo"
   Public Property Stock As Decimal
#End Region

#Region "Propiedades ReadOnly"
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

   Public ReadOnly Property IdMoneda As Integer
      Get
         If Moneda Is Nothing Then Return 0
         Return Moneda.IdMoneda
      End Get
   End Property

   Public ReadOnly Property NombreMoneda As String
      Get
         If Moneda Is Nothing Then Return String.Empty
         Return Moneda.NombreMoneda
      End Get
   End Property

   Public ReadOnly Property IdProduccionProceso As Integer
      Get
         If ProduccionProceso Is Nothing Then Return 0
         Return ProduccionProceso.IdProduccionProceso
      End Get
   End Property

   Public ReadOnly Property NombreProduccionProceso As String
      Get
         If ProduccionProceso Is Nothing Then Return String.Empty
         Return ProduccionProceso.NombreProduccionProceso
      End Get
   End Property

   Public ReadOnly Property IdProduccionForma As Integer
      Get
         If ProduccionForma Is Nothing Then Return 0
         Return ProduccionForma.IdProduccionForma
      End Get
   End Property

   Public ReadOnly Property NombreProduccionForma As String
      Get
         If ProduccionForma Is Nothing Then Return String.Empty
         Return ProduccionForma.NombreProduccionForma
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


   'ESTA PROPIEDAD ES USADA SOLO PARA LA GRILLA DE PRESUPUESTOS EN LA COLUMNA DEL BOTÓN DE ADJUNTOS.
   Public ReadOnly Property UrlPlanoCount As String
      Get
         If String.IsNullOrWhiteSpace(UrlPlano) Then
            Return String.Empty
         Else
            Return "1"
         End If
      End Get
   End Property
#End Region

#Region "IPKComprobante"
   Private ReadOnly Property IPKComprobante_IdSucursal As Integer Implements IPKComprobante.IdSucursal
      Get
         Return IdSucursal
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_IdTipoComprobante As String Implements IPKComprobante.IdTipoComprobante
      Get
         Return IdTipoComprobante
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_Letra As String Implements IPKComprobante.Letra
      Get
         Return Letra
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_CentroEmisor As Integer Implements IPKComprobante.CentroEmisor
      Get
         Return CentroEmisor
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_NumeroComprobante As Long Implements IPKComprobante.NumeroComprobante
      Get
         Return NumeroPedido
      End Get
   End Property
#End Region

End Class