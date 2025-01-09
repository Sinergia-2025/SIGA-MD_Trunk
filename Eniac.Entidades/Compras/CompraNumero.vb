<Serializable()>
Public Class CompraNumero
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _centroEmisor As Short
   Private _numero As Long
   Private _letraFiscal As String
   Private _idTipoComprobante As String

#End Region

#Region "Propiedades"

   Public Property Numero() As Long
      Get
         Return _numero
      End Get
      Set(ByVal value As Long)
         _numero = value
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
   Public Property LetraFiscal() As String
      Get
         Return _letraFiscal
      End Get
      Set(ByVal value As String)
         _letraFiscal = value
      End Set
   End Property
   Public Property IdTipoComprobante() As String
      Get
         Return _idTipoComprobante
      End Get
      Set(ByVal value As String)
         _idTipoComprobante = value
      End Set
   End Property

#End Region

End Class