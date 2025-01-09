<Serializable()>
Public Class Facturable
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Integer
   Private _numeroComprobante As Long
   Private _idProveedor As Long
   Private _idEstadoComprobante As String
   Private _idTipoComprobanteFact As String
   Private _letraFact As String
   Private _centroEmisorFact As Integer
   Private _numeroComprobanteFact As Long
   Private _idProveedorFact As Long
   Private _MercDespachada As Boolean
   Private _MercEnviada As Boolean

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
         _letra = value
      End Set
   End Property

   Public Property CentroEmisor() As Integer
      Get
         Return Me._centroEmisor
      End Get
      Set(ByVal value As Integer)
         Me._centroEmisor = value
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

   Public Property IdProveedor() As Long
      Get
         Return Me._idProveedor
      End Get
      Set(ByVal value As Long)
         Me._idProveedor = value
      End Set
   End Property

   Public Property IdEstadoComprobante() As String
      Get
         Return _idEstadoComprobante
      End Get
      Set(ByVal value As String)
         _idEstadoComprobante = value
      End Set
   End Property

   Public Property IdTipoComprobanteFact() As String
      Get
         Return _idTipoComprobanteFact
      End Get
      Set(ByVal value As String)
         _idTipoComprobanteFact = value
      End Set
   End Property

   Public Property LetraFact() As String
      Get
         Return _letraFact
      End Get
      Set(ByVal value As String)
         _letraFact = value
      End Set
   End Property

   '-- REQ-30768 --
   Public Property MercDespachada() As Boolean
      Get
         Return Me._MercDespachada
      End Get
      Set(ByVal value As Boolean)
         Me._MercDespachada = value
      End Set
   End Property

   Public Property NumeroComprobanteFact() As Long
      Get
         Return Me._numeroComprobanteFact
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobanteFact = value
      End Set
   End Property

   Public Property IdProveedorFact() As Long
      Get
         Return Me._idProveedorFact
      End Get
      Set(ByVal value As Long)
         Me._idProveedorFact = value
      End Set
   End Property

   Public Property CentroEmisorFact() As Integer
      Get
         Return Me._centroEmisorFact
      End Get
      Set(ByVal value As Integer)
         Me._centroEmisorFact = value
      End Set
   End Property

   Public Property MercEnviada() As Boolean
      Get
         Return Me._MercEnviada
      End Get
      Set(ByVal value As Boolean)
         Me._MercEnviada = value
      End Set
   End Property


#End Region

#Region "Propiedades ReadOnly"
#End Region

End Class