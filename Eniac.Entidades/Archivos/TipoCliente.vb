Public Class TipoCliente
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoCliente
      NombreTipoCliente
   End Enum

   Private _idTipoCliente As Integer
   Public Property IdTipoCliente() As Integer
      Get
         Return _idTipoCliente
      End Get
      Set(ByVal value As Integer)
         _idTipoCliente = value
      End Set
   End Property

   Private _nombreTipoCliente As String
   Public Property NombreTipoCliente() As String
      Get
         Return _nombreTipoCliente
      End Get
      Set(ByVal value As String)
         _nombreTipoCliente = value
      End Set
   End Property

End Class
