Public Class VersionCliente
   Inherits Eniac.Entidades.Entidad

   Public Sub New()
      MyBase.New()
   End Sub

   Private _codigoCliente As Long
   Public Property CodigoCliente() As Long
      Get
         Return _codigoCliente
      End Get
      Set(ByVal value As Long)
         _codigoCliente = value
      End Set
   End Property

   Private _nroVersion As String
   Public Property NroVersion() As String
      Get
         Return _nroVersion
      End Get
      Set(ByVal value As String)
         _nroVersion = value
      End Set
   End Property

   Private _nombreCliente As String
   Public Property NombreCliente() As String
      Get
         Return _nombreCliente
      End Get
      Set(ByVal value As String)
         _nombreCliente = value
      End Set
   End Property

End Class