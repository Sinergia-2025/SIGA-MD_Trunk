Imports Eniac.Entidades

Public Enum ModosV
   Ninguno
   PrestarProducto
   DevolverProducto
End Enum

<Serializable()> _
Public Class RecepcionNota
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _modo As Modos = Modos.Ninguno
   Private _estaPretado As Boolean
   Private _observacionPrestamo As String
   Private _productoPrestado As Eniac.Entidades.Producto
   Private _cantidadPrestada As Decimal
   Private _venta As Eniac.Entidades.Venta
   Private _cliente As Eniac.Entidades.Cliente
   Private _producto As Eniac.Entidades.Producto = Nothing
   Private _estado As RecepcionEstado = Nothing
   Private _nroNota As Integer = 0
   Private _fechaNota As DateTime = DateTime.Now
   Private _cantidadProductos As Decimal = 0
   Private _costoReparacion As Decimal = 0
   Private _defectoProducto As String = String.Empty
   Private _observacion As String = String.Empty

#End Region

#Region "Propiedades"

   Public Property Modo() As Modos
      Get
         Return _modo
      End Get
      Set(ByVal value As Modos)
         _modo = value
      End Set
   End Property
   Public Property EstaPrestado() As Boolean
      Get
         Return _estaPretado
      End Get
      Set(ByVal value As Boolean)
         _estaPretado = value
      End Set
   End Property
   Public Property ObservacionPrestamo() As String
      Get
         Return _observacionPrestamo
      End Get
      Set(ByVal value As String)
         _observacionPrestamo = value
      End Set
   End Property
   Public Property ProductoPrestado() As Eniac.Entidades.Producto
      Get
         If Me._productoPrestado Is Nothing Then
            Me._productoPrestado = New Eniac.Entidades.Producto()
         End If
         Return _productoPrestado
      End Get
      Set(ByVal value As Eniac.Entidades.Producto)
         _productoPrestado = value
      End Set
   End Property
   Public Property CantidadPrestada() As Decimal
      Get
         Return _cantidadPrestada
      End Get
      Set(ByVal value As Decimal)
         _cantidadPrestada = value
      End Set
   End Property
   Public Property Venta() As Eniac.Entidades.Venta
      Get
         If Me._venta Is Nothing Then
            Me._venta = New Eniac.Entidades.Venta()
         End If
         Return _venta
      End Get
      Set(ByVal value As Eniac.Entidades.Venta)
         _venta = value
      End Set
   End Property
   Public Property Cliente() As Eniac.Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Eniac.Entidades.Cliente()
         End If
         Return _cliente
      End Get
      Set(ByVal value As Eniac.Entidades.Cliente)
         _cliente = value
      End Set
   End Property
   Public Property Producto() As Eniac.Entidades.Producto
      Get
         Return _producto
      End Get
      Set(ByVal value As Eniac.Entidades.Producto)
         _producto = value
      End Set
   End Property
   Public Property Estado() As RecepcionEstado
      Get
         Return _estado
      End Get
      Set(ByVal value As RecepcionEstado)
         _estado = value
      End Set
   End Property
   Public Property NroNota() As Integer
      Get
         Return _nroNota
      End Get
      Set(ByVal value As Integer)
         _nroNota = value
      End Set
   End Property
   Public Property FechaNota() As DateTime
      Get
         Return _fechaNota
      End Get
      Set(ByVal value As DateTime)
         _fechaNota = value
      End Set
   End Property
   Public Property CantidadProductos() As Decimal
      Get
         Return _cantidadProductos
      End Get
      Set(ByVal value As Decimal)
         _cantidadProductos = value
      End Set
   End Property
   Public Property CostoReparacion() As Decimal
      Get
         Return _costoReparacion
      End Get
      Set(ByVal value As Decimal)
         _costoReparacion = value
      End Set
   End Property
   Public Property DefectoProducto() As String
      Get
         Return _defectoProducto
      End Get
      Set(ByVal value As String)
         _defectoProducto = value
      End Set
   End Property
   Public Property Observacion() As String
      Get
         Return _observacion
      End Get
      Set(ByVal value As String)
         _observacion = value
      End Set
   End Property

#End Region

End Class