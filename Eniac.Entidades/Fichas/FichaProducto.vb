<Serializable()>
Public Class FichaProducto
   Inherits Eniac.Entidades.Entidad

#Region "Constructores"

   Public Sub New(ByVal idSucursal As Int32, ByVal usuario As String, ByVal pwd As String)
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Me.Password = pwd
   End Sub

#End Region

#Region "Campos"

   Private _idCliente As Long = 0
   Private _nroOperacion As Integer = 0
   'Private _tipoDocumento As String = ""
   'Private _nroDocumento As String = ""
   Private _idProducto As String = ""
   Private _cantidad As Integer = 0
   Private _precio As Decimal = 0
   Private _productoDesc As String = ""
   Private _fechaEntrega As DateTime = Nothing
   Private _garantia As Integer = 0
   Private _proveedor As Proveedor

#End Region

#Region "Propiedades"

   Public Property IdCliente() As Long
      Get
         Return Me._idCliente
      End Get
      Set(ByVal value As Long)
         Me._idCliente = value
      End Set
   End Property

   Public Property Proveedor() As Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Proveedor()
         End If
         Return _proveedor
      End Get
      Set(ByVal value As Proveedor)
         _proveedor = value
      End Set
   End Property
   Public Property ProductoDesc() As String
      Get
         Return Me._productoDesc
      End Get
      Set(ByVal value As String)
         Me._productoDesc = value
      End Set
   End Property
   Public ReadOnly Property Importe() As Decimal
      Get
         Return (Me._precio * Me._cantidad)
      End Get
   End Property
   Public Property Precio() As Decimal
      Get
         Return Me._precio
      End Get
      Set(ByVal value As Decimal)
         Me._precio = value
      End Set
   End Property
   Public Property Cantidad() As Integer
      Get
         Return Me._cantidad
      End Get
      Set(ByVal value As Integer)
         Me._cantidad = value
      End Set
   End Property
   Public Property IdProducto() As String
      Get
         Return Me._idProducto
      End Get
      Set(ByVal value As String)
         If value.Length <= 20 Then
            Me._idProducto = value
         Else
            Throw New Exception("El id de producto no puede tener mas de 20 caracteres")
         End If
      End Set
   End Property
   Public Property NroOperacion() As Integer
      Get
         Return Me._nroOperacion
      End Get
      Set(ByVal value As Integer)
         Me._nroOperacion = value
      End Set
   End Property
   'Public Property TipoDocumento() As String
   '   Get
   '      Return Me._tipoDocumento
   '   End Get
   '   Set(ByVal value As String)
   '      If value.Length <= 5 Then
   '         Me._tipoDocumento = value
   '      Else
   '         Throw New Exception("El tipo de documento no puede tener mas de 5 caracteres")
   '      End If
   '   End Set
   'End Property
   'Public Property NroDocumento() As String
   '   Get
   '      Return Me._nroDocumento
   '   End Get
   '   Set(ByVal value As String)
   '      If value.Length <= 12 Then
   '         Me._nroDocumento = value
   '      Else
   '         Throw New Exception("El nro. de documento no puede tener mas de 12 caracteres")
   '      End If
   '   End Set
   'End Property
   Public Property FechaEntrega() As DateTime
      Get
         Return Me._fechaEntrega
      End Get
      Set(ByVal value As DateTime)
         Me._fechaEntrega = value
      End Set
   End Property
   Public Property Garantia() As Integer
      Get
         Return Me._garantia
      End Get
      Set(ByVal value As Integer)
         Me._garantia = value
      End Set
   End Property

#End Region

End Class