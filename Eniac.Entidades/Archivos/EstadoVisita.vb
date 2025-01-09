Public Class EstadoVisita
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdEstadoVisita
      NombreEstadoVisita
      AdmitePedidoSinLineas
      AdmintePedidoConLineas
   End Enum

   Private _idEstadoVisita As Integer
   Public Property IdEstadoVisita() As Integer
      Get
         Return _idEstadoVisita
      End Get
      Set(ByVal value As Integer)
         _idEstadoVisita = value
      End Set
   End Property
   Private _nombreEstadoVisita As String
   Public Property NombreEstadoVisita() As String
      Get
         Return _nombreEstadoVisita
      End Get
      Set(ByVal value As String)
         _nombreEstadoVisita = value
      End Set
   End Property
   Private _admitePedidoSinLineas As Boolean
   Public Property AdmitePedidoSinLineas() As Boolean
      Get
         Return _admitePedidoSinLineas
      End Get
      Set(ByVal value As Boolean)
         _admitePedidoSinLineas = value
      End Set
   End Property
   Private _admintePedidoConLineas As Boolean
   Public Property AdmintePedidoConLineas() As Boolean
      Get
         Return _admintePedidoConLineas
      End Get
      Set(ByVal value As Boolean)
         _admintePedidoConLineas = value
      End Set
   End Property
End Class