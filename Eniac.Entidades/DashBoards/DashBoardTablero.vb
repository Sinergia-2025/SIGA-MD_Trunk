Public Class DashBoardTablero
   Inherits Entidad

   Public Const NombreTabla As String = "DashBoardsTableros"
   Public Enum Columnas
      IdTableros
      Descripcion
      Estados
   End Enum

   Public Property IdTableros As Integer
   Public Property Descripcion As String
   Public Property Estados As Boolean

End Class
