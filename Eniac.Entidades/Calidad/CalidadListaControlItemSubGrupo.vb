Public Class CalidadListaControlItemSubGrupo
   Inherits Entidad
   Implements IEquatable(Of CalidadListaControlItemSubGrupo)
   Public Const NombreTabla As String = "CalidadListasControlItemsSubGrupos"

   Public Enum Columnas
      IdListaControlItemGrupo
      IdListaControlItemSubGrupo
      NombreListaControlItemSubGrupo
   End Enum

   Public Property IdListaControlItemGrupo As String
   Public Property IdListaControlItemSubGrupo As String
   Public Property NombreListaControlItemSubGrupo As String

#Region "Metodos IEquatable(Of T)"
   'Implemento el Equals de la interfase que nos está interesando usar para buscar por Equals
   Public Overloads Function Equals(other As CalidadListaControlItemSubGrupo) As Boolean Implements IEquatable(Of CalidadListaControlItemSubGrupo).Equals
      Return IdListaControlItemGrupo = other.IdListaControlItemGrupo And IdListaControlItemSubGrupo = other.IdListaControlItemSubGrupo
   End Function

   'Sobreescribo el Equals base para que, si el objeto recibido es del tipo que estoy trabajando evaue con el Equals antes implementado. En caso de no ser del mismo tipo retorna False.
   Public Overrides Function Equals(obj As Object) As Boolean
      Return TypeOf (obj) Is CalidadListaControlItemSubGrupo AndAlso Equals(DirectCast(obj, CalidadListaControlItemSubGrupo))
   End Function

   'Sobreescribo GetHashCode para que los Dictionary funcionen correctamente.
   'Se puede generar automáticamente parandose en el nombre de la clase y presionando CTRL+. o haciendo click en el icono de lapiz (refactoring).
   Public Overrides Function GetHashCode() As Integer
      Dim hashCode As Long = -515239700
      hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(IdListaControlItemGrupo)).GetHashCode()
      hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(IdListaControlItemSubGrupo)).GetHashCode()
      Return CType(hashCode, Integer)
   End Function
#End Region

End Class