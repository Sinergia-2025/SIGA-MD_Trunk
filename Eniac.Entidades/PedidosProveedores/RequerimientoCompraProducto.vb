Public Class RequerimientoCompraProducto
   Inherits Entidad
   Implements IEquatable(Of RequerimientoCompraProducto)

   Public Const NombreTabla As String = "RequerimientosComprasProductos"
   Public Enum Columnas
      IdRequerimientoCompra
      IdProducto
      Orden
      NombreProducto
      Cantidad
      CantidadUMCompra
      FactorConversionCompra
      FechaEntrega
      Observacion
      FechaAnulacion
      IdUsuarioAnulacion
      IdUnidadDeMedida
      IdUnidadDeMedidaCompra
   End Enum

   Public Sub New()
      Asignaciones = New ListConBorrados(Of RequerimientoCompraProductoAsignacion)()
      UnidadDeMedida = New UnidadDeMedida()
      UnidadDeMedidaCompra = New UnidadDeMedida()
      Selec = False
   End Sub

   Public Property IdRequerimientoCompra As Long
   Public Property IdProducto As String
   Public Property NombreProducto As String
   Public Property Orden As Integer
   Public Property Cantidad As Decimal
   Public Property CantidadUMCompra As Decimal
   Public Property UnidadDeMedida As UnidadDeMedida
   Public Property UnidadDeMedidaCompra As UnidadDeMedida
   Public Property FactorConversionCompra As Decimal
   Public Property FechaEntrega As Date
   Public Property Observacion As String
   Public Property FechaAnulacion As Date?
   Public Property IdUsuarioAnulacion As String

   Public Property Asignaciones As ListConBorrados(Of RequerimientoCompraProductoAsignacion)

#Region "Propiedades ReadOnly"
   Public ReadOnly Property CantidadAsignaciones As Integer
      Get
         Return Asignaciones.Count
      End Get
   End Property

   Public ReadOnly Property IdUnidadDeMedida As String
      Get
         Return If(UnidadDeMedida Is Nothing, String.Empty, UnidadDeMedida.IdUnidadDeMedida)
      End Get
   End Property
   Public ReadOnly Property NombreUnidadDeMedida As String
      Get
         Return If(UnidadDeMedida Is Nothing, String.Empty, UnidadDeMedida.NombreUnidadDeMedida)
      End Get
   End Property
   Public ReadOnly Property IdUnidadDeMedidaCompra As String
      Get
         Return If(UnidadDeMedidaCompra Is Nothing, String.Empty, UnidadDeMedidaCompra.IdUnidadDeMedida)
      End Get
   End Property
   Public ReadOnly Property NombreUnidadDeMedidaCompra As String
      Get
         Return If(UnidadDeMedidaCompra Is Nothing, String.Empty, UnidadDeMedidaCompra.NombreUnidadDeMedida)
      End Get
   End Property

#End Region

#Region "Metodos IEquatable(Of T)"
   'Implemento el Equals de la interfase que nos está interesando usar para buscar por Equals
   Public Overloads Function Equals(other As RequerimientoCompraProducto) As Boolean Implements IEquatable(Of RequerimientoCompraProducto).Equals
      Return IdRequerimientoCompra = other.IdRequerimientoCompra AndAlso IdProducto = other.IdProducto AndAlso Orden = other.Orden
   End Function

   'Sobreescribo el Equals base para que, si el objeto recibido es del tipo que estoy trabajando evaue con el Equals antes implementado. En caso de no ser del mismo tipo retorna False.
   Public Overrides Function Equals(obj As Object) As Boolean
      Return TypeOf (obj) Is RequerimientoCompraProducto AndAlso Equals(DirectCast(obj, RequerimientoCompraProducto))
   End Function

   'Sobreescribo GetHashCode para que los Dictionary funcionen correctamente.
   'Se puede generar automáticamente parandose en el nombre de la clase y presionando CTRL+. o haciendo click en el icono de lapiz (refactoring).
   Public Overrides Function GetHashCode() As Integer
      Dim hashCode As Long = -515239700
      hashCode = (hashCode * -1521134295 + IdRequerimientoCompra.GetHashCode()).GetHashCode()
      hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(IdProducto)).GetHashCode()
      hashCode = (hashCode * -1521134295 + Orden.GetHashCode()).GetHashCode()
      Return CType(hashCode, Integer)
   End Function
#End Region

#Region "Propiedades Solo para Pantalla"
   Public Property Selec As Boolean             'Se usa en las pantallas donde la grilla de Productos requiere seleccionar líneas
   Public Property Stock As Decimal             'Se usa para mostrarlo solo en la grilla de Productos de la pantalla Requerimientos
#End Region

End Class