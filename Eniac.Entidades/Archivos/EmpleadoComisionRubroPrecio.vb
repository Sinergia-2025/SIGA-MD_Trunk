Public Class EmpleadoComisionRubroPrecio
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "EmpleadoComisionRubroPrecio"

   Public Enum Columnas
      IdEmpleado
      IdRubro
      IdListaPrecios
      Comision
   End Enum

   Private _empleado As Empleado
   Public Property Empleado() As Empleado
      Get
         If _empleado Is Nothing Then _empleado = New Empleado()
         Return _empleado
      End Get
      Set(ByVal value As Empleado)
         _empleado = value
      End Set
   End Property
   Public ReadOnly Property IdEmpleado() As Integer
      Get
         Return Empleado.IdEmpleado
      End Get
   End Property

   Private _Rubro As Rubro
   Public Property Rubro() As Rubro
      Get
         If _Rubro Is Nothing Then _Rubro = New Rubro()
         Return _Rubro
      End Get
      Set(ByVal value As Rubro)
         _Rubro = value
      End Set
   End Property
   Public ReadOnly Property IdRubro() As Integer
      Get
         Return Rubro.IdRubro
      End Get
   End Property
   Public ReadOnly Property NombreRubro() As String
      Get
         Return Rubro.NombreRubro
      End Get
   End Property

   Private _listaDePrecios As ListaDePrecios
   Public Property ListaDePrecios() As ListaDePrecios
      Get
         If _listaDePrecios Is Nothing Then _listaDePrecios = New ListaDePrecios()
         Return _listaDePrecios
      End Get
      Set(ByVal value As ListaDePrecios)
         _listaDePrecios = value
      End Set
   End Property
   Public ReadOnly Property IdListaPrecios() As Integer
      Get
         Return ListaDePrecios.IdListaPrecios
      End Get
   End Property
   Public ReadOnly Property NombreListaPrecios() As String
      Get
         Return ListaDePrecios.NombreListaPrecios
      End Get
   End Property

   Private _comision As Decimal
   Public Property Comision() As Decimal
      Get
         Return _comision
      End Get
      Set(ByVal value As Decimal)
         _comision = value
      End Set
   End Property
End Class