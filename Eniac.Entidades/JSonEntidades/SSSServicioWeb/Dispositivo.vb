Namespace JSonEntidades.SSSServicioWeb
   Public Class Dispositivo
      Public Const FormatoFecha As String = "yyyy-MM-dd HH:mm:ss"
      Public Enum Columnas
         IdDispositivo
         NombreDispositivo
         FechaUltimoLogin
         UsuarioUltimoLogin
         IdTipoDispositivo
         SistemaOperativo
         ArquitecturaSO
         NumeroSerieDiscoRigido
      End Enum

      Public Property IdDispositivo As String
      Public Property NombreDispositivo As String
      Public Property FechaUltimoLogin As String
      Public Property UsuarioUltimoLogin As String
      Public Property IdTipoDispositivo As String
      Public Property SistemaOperativo As String
      Public Property ArquitecturaSO As String
      Public Property NumeroSerieDiscoRigido As String
   End Class
End Namespace