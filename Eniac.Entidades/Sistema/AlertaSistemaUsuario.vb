Namespace SistemaE
   Public Class AlertaSistemaUsuario
      Inherits Entidad

      Public Const NombreTabla As String = "AlertasSistemaUsuarios"
      Public Enum Columnas
         IdAlertaSistema
         IdUsuario

      End Enum

      Public Property IdAlertaSistema As Integer
      Public Property IdUsuario As String
      Public Property NombreUsuario As String               ' Solo para mostrar en pantalla

   End Class
End Namespace