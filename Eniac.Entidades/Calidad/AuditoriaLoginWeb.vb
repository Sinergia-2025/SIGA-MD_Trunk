Public Class AuditoriaLoginWeb
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadAuditoriaLoginWebPaneles"

   Public Enum Columnas
      Id
      sincronizado
      id_usuario
      nombre_usuario
      ip
      pais_code
      pais
      login
      logout
      navegador
      estado_registro

   End Enum

   Public Property Id As Long
   Public Property sincronizado As String
   Public Property nombre_usuario As String
   Public Property ip As String
   Public Property id_usuario As Integer
   Public Property pais_code As String
   Public Property pais As String
   Public Property login As DateTime
   Public Property logout As DateTime?
   Public Property navegador As String
   Public Property estado_registro As String

End Class
