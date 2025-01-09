Public Class CalidadListaControlItemGrupo
   Inherits Entidad
   Implements IEquatable(Of CalidadListaControlItemGrupo)
   Public Const NombreTabla As String = "CalidadListasControlItemsGrupos"

   Public Enum Columnas
      IdListaControlItemGrupo
      NombreListaControlItemGrupo
   End Enum

   Public Property IdListaControlItemGrupo As String
   Public Property NombreListaControlItemGrupo As String

#Region "Metodos IEquatable(Of T)"
   'Implemento el Equals de la interfase que nos está interesando usar para buscar por Equals
   Public Overloads Function Equals(other As CalidadListaControlItemGrupo) As Boolean Implements IEquatable(Of CalidadListaControlItemGrupo).Equals
      Return IdListaControlItemGrupo = other.IdListaControlItemGrupo
   End Function

   'Sobreescribo el Equals base para que, si el objeto recibido es del tipo que estoy trabajando evaue con el Equals antes implementado. En caso de no ser del mismo tipo retorna False.
   Public Overrides Function Equals(obj As Object) As Boolean
      Return TypeOf (obj) Is CalidadListaControlItemGrupo AndAlso Equals(DirectCast(obj, CalidadListaControlItemGrupo))
   End Function

   'Sobreescribo GetHashCode para que los Dictionary funcionen correctamente.
   'Se puede generar automáticamente parandose en el nombre de la clase y presionando CTRL+. o haciendo click en el icono de lapiz (refactoring).
   Public Overrides Function GetHashCode() As Integer
      Dim hashCode As Long = -515239700
      hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(IdListaControlItemGrupo)).GetHashCode()
      Return CType(hashCode, Integer)
   End Function
#End Region

End Class