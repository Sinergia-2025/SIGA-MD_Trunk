<Serializable()> _
Public Class ProductoConcepto
   Inherits Eniac.Entidades.Entidad

#Region "Propiedades"

   Private _idProducto As String = ""
   Public Property IdProducto() As String
      Get
         Return Me._idProducto
      End Get
      Set(ByVal value As String)
         Me._idProducto = value.Trim()
      End Set
   End Property

   Private _idConcepto As Integer = 0
   Public Property IdConcepto() As Integer
      Get
         Return Me._idConcepto
      End Get
      Set(ByVal value As Integer)
         Me._idConcepto = value
      End Set
   End Property

   Private _nombreConcepto As String = ""
   Public Property NombreConcepto() As String
      Get
         Return Me._nombreConcepto
      End Get
      Set(ByVal value As String)
         Me._nombreConcepto = value
      End Set
   End Property

#End Region

End Class