<Serializable()> _
Public Class Transportista
   Inherits Entidad
   Public Const NombreTabla As String = "Transportistas"
   Public Enum Columnas
      IdTransportista
      NombreTransportista
      DireccionTransportista
      IdLocalidadTransportista
      TelefonoTransportista
      IdCategoriaFiscalTransportista
      CuitTransportista
      Observacion
      KilosMaximo
      PaletsMaximo
      Activo
   End Enum

#Region "Campos"

   Private _idTransportista As Int32
   Private _nombreTransportista As String = ""
   Private _direccionTransportista As String = ""
   Private _idLocalidadTransportista As Integer = 0
   Private _cuit As String = ""
   Private _telefonoTransportista As String = ""
   Private _nombreLocalidad As String = ""
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _observacion As String = ""

#End Region

#Region "Propiedades"

   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If Me._categoriaFiscal Is Nothing Then
            Me._categoriaFiscal = New Entidades.CategoriaFiscal()
         End If
         Return Me._categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         Me._categoriaFiscal = value
      End Set
   End Property

   Public Property idTransportista() As Int32
      Get
         Return Me._idTransportista
      End Get
      Set(ByVal value As Int32)
         Me._idTransportista = value
      End Set
   End Property

   Public Property CuitTransportista() As String
      Get
         Return _cuit
      End Get
      Set(ByVal value As String)
         _cuit = value
      End Set
   End Property
   Public Property DireccionTransportista() As String
      Get
         Return _direccionTransportista
      End Get
      Set(ByVal value As String)
         _direccionTransportista = value
      End Set
   End Property

   Public Property IdLocalidadTransportista() As Integer
      Get
         Return _idLocalidadTransportista
      End Get
      Set(ByVal value As Integer)
         _idLocalidadTransportista = value
      End Set
   End Property
   Public Property NombreLocalidad() As String
      Get
         Return _nombreLocalidad
      End Get
      Set(ByVal value As String)
         _nombreLocalidad = value
      End Set
   End Property
   Public Property NombreTransportista() As String
      Get
         Return _nombreTransportista
      End Get
      Set(ByVal value As String)
         _nombreTransportista = value
      End Set
   End Property
   Public Property TelefonoTransportista() As String
      Get
         Return _telefonoTransportista
      End Get
      Set(ByVal value As String)
         _telefonoTransportista = value
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
   Public Property KilosMaximo() As Decimal
   Public Property PaletsMaximo() As Integer

   Public Property Activo() As Boolean
#End Region

   Public Overrides Function ToString() As String
      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder("")
      With stb
         .Append(Me.NombreTransportista)
      End With
      Return stb.ToString()
   End Function

End Class