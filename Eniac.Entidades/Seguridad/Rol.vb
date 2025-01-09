<Serializable()>
Public Class Rol
   Inherits Entidad
   Public Const NombreTabla As String = "Roles"

   Public Enum Columnas
      Id
      Nombre
      Descripcion

   End Enum

   Public Property Id As String = ""
   Public Property Nombre As String = ""
   Public Property Descripcion As String = ""

End Class