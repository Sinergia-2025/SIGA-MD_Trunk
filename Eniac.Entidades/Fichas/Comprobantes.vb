'cboco
<Serializable()> _
Public Class Comprobantes
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _idSucursalComprobante As Integer
   Private _idComprobante As Integer
   Private _nombreComprobante As String
   Private _afectaStock As String
   Private _esFacturable As String
   Private _grabaLibroIVA As String

#End Region

#Region "Propiedades"

   Public Property IdSucursalComprobante() As Integer
      Get
         Return Me._idSucursalComprobante
      End Get
      Set(ByVal value As Integer)
         Me._idSucursalComprobante = value
      End Set
   End Property
   Public Property IdComprobante() As Integer
      Get
         Return Me._idComprobante
      End Get
      Set(ByVal value As Integer)
         Me._idComprobante = value
      End Set
   End Property
   Public Property NombreComprobante() As String
      Get
         Return Me._nombreComprobante
      End Get
      Set(ByVal value As String)
         Me._nombreComprobante = value
      End Set
   End Property
   Public Property AfectaStock() As String
      Get
         Return Me._afectaStock
      End Get
      Set(ByVal value As String)
         Me._afectaStock = value
      End Set
   End Property
   Public Property EsFacturable() As String
      Get
         Return Me._esFacturable
      End Get
      Set(ByVal value As String)
         Me._esFacturable = value
      End Set
   End Property
   Public Property GrabaLibroIVA() As String
      Get
         Return Me._grabaLibroIVA
      End Get
      Set(ByVal value As String)
         Me._grabaLibroIVA = value
      End Set
   End Property

#End Region

End Class
