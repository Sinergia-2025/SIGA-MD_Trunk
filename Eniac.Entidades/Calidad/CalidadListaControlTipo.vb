Public Class CalidadListaControlTipo
   Inherits Entidad
   Implements IEquatable(Of CalidadListaControlTipo)
   Public Const NombreTabla As String = "CalidadListasControlTipos"

   Public Enum Columnas
      IdListaControlTipo
      NombreListaControlTipo
   End Enum

   Public Property IdListaControlTipo As Integer
   Public Property NombreListaControlTipo As String

#Region "Metodos IEquatable(Of T)"
   'Implemento el Equals de la interfase que nos está interesando usar para buscar por Equals
   Public Overloads Function Equals(other As CalidadListaControlTipo) As Boolean Implements IEquatable(Of CalidadListaControlTipo).Equals
      Return IdListaControlTipo = other.IdListaControlTipo
   End Function

   'Sobreescribo el Equals base para que, si el objeto recibido es del tipo que estoy trabajando evaue con el Equals antes implementado. En caso de no ser del mismo tipo retorna False.
   Public Overrides Function Equals(obj As Object) As Boolean
      Return TypeOf (obj) Is CalidadListaControlTipo AndAlso Equals(DirectCast(obj, CalidadListaControlTipo))
   End Function

   'Sobreescribo GetHashCode para que los Dictionary funcionen correctamente.
   'Se puede generar automáticamente parandose en el nombre de la clase y presionando CTRL+. o haciendo click en el icono de lapiz (refactoring).
   Public Overrides Function GetHashCode() As Integer
      Return IdListaControlTipo.GetHashCode()
   End Function
#End Region

End Class