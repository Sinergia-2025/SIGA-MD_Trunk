<Serializable()> _
Public Class SueldosMotivoBaja
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdMotivoBaja
      NombreMotivoBaja
   End Enum

#Region "Propiedades"

   Private _idMotivoBaja As Integer
   Public Property IdMotivoBaja() As Integer
      Get
         Return _idMotivoBaja
      End Get
      Set(ByVal value As Integer)
         _idMotivoBaja = value
      End Set
   End Property

   Private _nombreMotivoBaja As String
   Public Property NombreMotivoBaja() As String
      Get
         Return _nombreMotivoBaja
      End Get
      Set(ByVal value As String)
         _nombreMotivoBaja = value
      End Set
   End Property

#End Region



End Class
