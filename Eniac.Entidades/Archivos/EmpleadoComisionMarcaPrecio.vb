Public Class EmpleadoComisionMarcaPrecio
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "EmpleadoComisionMarcaPrecio"

   Public Enum Columnas
      IdEmpleado
      IdMarca
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

   Private _marca As Marca
   Public Property Marca() As Marca
      Get
         If _marca Is Nothing Then _marca = New Marca()
         Return _marca
      End Get
      Set(ByVal value As Marca)
         _marca = value
      End Set
   End Property
   Public ReadOnly Property IdMarca() As Integer
      Get
         Return Marca.IdMarca
      End Get
   End Property
   Public ReadOnly Property NombreMarca() As String
      Get
         Return Marca.NombreMarca
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