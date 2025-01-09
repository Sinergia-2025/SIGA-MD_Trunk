<Serializable()>
Public Class SincronizaRegistro
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _estado As String
   Private _fechaHoraProceso As Nullable(Of DateTime)
   Private _tabla As String
   Private _query As String
   Private _sucursalDestino As Integer
   Private _sucursalOrigen As Integer
   Private _fechaHora As Nullable(Of DateTime)
   Private _id As Long

#End Region

#Region "Propiedades"

   Public Property SucursalDestino() As Integer
      Get
         Return _sucursalDestino
      End Get
      Set(ByVal value As Integer)
         _sucursalDestino = value
      End Set
   End Property
   Public Property SucursalOrigen() As Integer
      Get
         Return _sucursalOrigen
      End Get
      Set(ByVal value As Integer)
         _sucursalOrigen = value
      End Set
   End Property
   Public Property FechaHora() As Nullable(Of DateTime)
      Get
         Return _fechaHora
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         _fechaHora = value
      End Set
   End Property
   Public Property Id() As Long
      Get
         Return _id
      End Get
      Set(ByVal value As Long)
         _id = value
      End Set
   End Property
   Public Property Query() As String
      Get
         Return _query
      End Get
      Set(ByVal value As String)
         _query = value
      End Set
   End Property
   Public Property FechaHoraProceso() As Nullable(Of DateTime)
      Get
         Return _fechaHoraProceso
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         _fechaHoraProceso = value
      End Set
   End Property
   Public Property Estado() As String
      Get
         Return _estado
      End Get
      Set(ByVal value As String)
         _estado = value
      End Set
   End Property
   Public Property Tabla() As String
      Get
         Return _tabla
      End Get
      Set(ByVal value As String)
         _tabla = value
      End Set
   End Property

#End Region

End Class