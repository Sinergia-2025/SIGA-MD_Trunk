<Serializable()>
Public Class CompraObservacion
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _proveedor As Entidades.Proveedor
   Private _linea As Integer
   Private _observacion As String

#End Region

#Region "Propiedades"

   Public Property IdTipoComprobante() As String
      Get
         Return _idTipoComprobante
      End Get
      Set(ByVal value As String)
         _idTipoComprobante = value
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
   Public Property Linea() As Integer
      Get
         Return Me._linea
      End Get
      Set(ByVal value As Integer)
         Me._linea = value
      End Set
   End Property
   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property
   Public Property Proveedor() As Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Entidades.Proveedor()

         End If
         Return Me._proveedor
      End Get
      Set(ByVal value As Entidades.Proveedor)
         Me._proveedor = value
      End Set
   End Property
#End Region

End Class