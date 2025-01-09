<Serializable()>
Public Class VentaProductoLote
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProducto
      NombreProducto
      IdLote
      FechaVencimiento
      Cantidad
      Orden
   End Enum

#Region "Campos"

   Private _tipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _producto As Entidades.Producto
   Private _idLote As String
   Private _cantidad As Decimal

#End Region

#Region "Propiedades"
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

   Public ReadOnly Property IdProducto() As String
      Get
         Return Me.Producto.IdProducto
      End Get
   End Property

   Public ReadOnly Property NombreProducto() As String
      Get
         Return Me.Producto.NombreProducto
      End Get
   End Property

   Public Property TipoComprobante() As String
      Get
         Return _tipoComprobante
      End Get
      Set(ByVal value As String)
         _tipoComprobante = value
      End Set
   End Property

   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         Me._letra = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
      End Set
   End Property

   Public Property Producto() As Entidades.Producto
      Get
         If Me._producto Is Nothing Then
            Me._producto = New Entidades.Producto()
         End If
         Return Me._producto
      End Get
      Set(ByVal value As Entidades.Producto)
         Me._producto = value
      End Set
   End Property

   Public Property IdLote() As String
      Get
         Return _idLote
      End Get
      Set(ByVal value As String)
         Me._idLote = value
      End Set
   End Property

   Public Property FechaVencimiento() As Date?

   Public Property Cantidad() As Decimal
      Get
         Return _cantidad
      End Get
      Set(ByVal value As Decimal)
         _cantidad = value
      End Set
   End Property

   Private _orden As Integer
   Public Property Orden() As Integer
      Get
         Return _orden
      End Get
      Set(ByVal value As Integer)
         _orden = value
      End Set
   End Property


#End Region

End Class