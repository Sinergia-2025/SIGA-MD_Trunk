Namespace SistemaE
   Public Class AlertaSistemaRol
      Inherits Entidad

      Public Const NombreTabla As String = "AlertasSistemaRoles"
      Public Enum Columnas
         IdAlertaSistema
         IdRol

      End Enum

      Public Property IdAlertaSistema As Integer
      Public Property IdRol As String
      Public Property NombreRol As String                   ' Solo para mostrar en pantalla

   End Class
End Namespace