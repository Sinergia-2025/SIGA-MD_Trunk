Public Class Nodo
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadNodos"

   Public Enum Columnas
      IdNodo
      NombreNodo
   End Enum

   Public Property IdNodo As Integer
   Public Property NombreNodo As String

End Class
