<Serializable()>
<Description("CriticidadPedido")>
Public Class CriticidadOrdenProduccion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCriticidad
      Orden
   End Enum

   Private _IdCriticidad As String
   Public Property IdCriticidad() As String
      Get
         Return _IdCriticidad
      End Get
      Set(ByVal value As String)
         _IdCriticidad = value
      End Set
   End Property

   Private _orden As Integer
   Public Property Orden() As Integer
      Get
         Return _orden
      End Get
      Set(ByVal value As Integer)
         _orden = value
      End Set
   End Property

End Class