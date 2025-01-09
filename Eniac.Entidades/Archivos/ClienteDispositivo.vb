Public Class ClienteDispositivo
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ClientesDispositivos"
   Public Enum Columnas
      IdCliente
      NombreServidor
      BaseDatos
      IdDispositivo
      NombreDispositivo
      FechaUltimoLogin
      UsuarioUltimoLogin
      IdTipoDispositivo
      SistemaOperativo
      ArquitecturaSO
      NumeroSerieDiscoRigido

   End Enum

   Public Property IdCliente As Long
   Public Property NombreServidor As String
   Public Property BaseDatos As String
   Public Property IdDispositivo As String
   Public Property NombreDispositivo As String
   Public Property FechaUltimoLogin As DateTime
   Public Property UsuarioUltimoLogin As String
   Public Property IdTipoDispositivo As String
   Public Property SistemaOperativo As String
   Public Property ArquitecturaSO As String
   Public Property NumeroSerieDiscoRigido As String

End Class