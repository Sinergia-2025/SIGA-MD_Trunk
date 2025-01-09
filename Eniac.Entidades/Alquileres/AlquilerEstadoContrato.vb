<Serializable()> _
<System.ComponentModel.Description("AlquilerEstadoContrato")> _
Public Class AlquilerEstadoContrato
   Inherits Eniac.Entidades.Entidad

   Private _idEstado As Integer
   Private _nombreEstado As String
   Private _FechaDesde As Date
   Private _FechaHasta As Date
   Private _esRenovable As Boolean
   Private _verTodos As Boolean
   Private _estadoCambiar As String
   Private _grillaContratos As DataTable

   Public Enum Columnas
      IdEstado
      NombreEstado
      FechaDesde
      FechaHasta
      verTodos
      esRenovable
      estadoCambiar
      grillaContratos
   End Enum

   Public Property IdEstado() As Integer
      Get
         Return _idEstado
      End Get
      Set(ByVal value As Integer)
         _idEstado = value
      End Set
   End Property

   Public Property NombreEstado() As String
      Get
         Return _nombreEstado
      End Get
      Set(ByVal value As String)
         _nombreEstado = value
      End Set
   End Property


   Public Property FechaDesde() As Date
      Get
         Return _FechaDesde
      End Get
      Set(ByVal value As Date)
         _FechaDesde = value
      End Set
   End Property
   Public Property FechaHasta() As Date
      Get
         Return _FechaHasta
      End Get
      Set(ByVal value As Date)
         _FechaHasta = value
      End Set
   End Property

   Public Property esRenovable() As Boolean
      Get
         Return _esRenovable
      End Get
      Set(ByVal value As Boolean)
         _esRenovable = value
      End Set
   End Property

   Public Property verTodos() As Boolean
      Get
         Return _verTodos
      End Get
      Set(ByVal value As Boolean)
         _verTodos = value
      End Set
   End Property

   Public Property estadocambiar() As String
      Get
         Return _estadoCambiar
      End Get
      Set(ByVal value As String)
         _estadoCambiar = value
      End Set
   End Property

   Public Property grillaContratos() As DataTable
      Get
         Return _grillaContratos
      End Get
      Set(ByVal value As DataTable)
         _grillaContratos = value
      End Set
   End Property

End Class
