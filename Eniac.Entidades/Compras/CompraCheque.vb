<Serializable()>
Public Class CompraCheque
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _tipoComprobante As Entidades.TipoComprobante
   Private _letra As String
   Private _centroEmisor As Short
   Private _numero As Long
   Private _proveedor As Entidades.Proveedor

#End Region

#Region "Propiedades"

   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
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

   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long
      Get
         Return Me._numero
      End Get
      Set(ByVal value As Long)
         Me._numero = value
      End Set

   End Property
   Public Property IdCheque As Long

#End Region

End Class