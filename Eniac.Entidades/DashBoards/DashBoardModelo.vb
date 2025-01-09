Public Class DashBoardModelo
   Inherits Entidad

   Public Const NombreTabla As String = "DashBoardsModelos"
   Public Enum Columnas
      IdModelo
      Descripcion
      Estados
      IdModeloDB
   End Enum

   Public Property IdModelo As Integer
   Public Property Descripcion As String
   Public Property Estados As Boolean
   Public Property IdModeloDB As Integer

End Class
