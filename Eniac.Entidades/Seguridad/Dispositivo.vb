Public Class Dispositivo
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "Dispositivos"
   Public Enum Columnas
      IdDispositivo
      NombreDispositivo
      FechaUltimoLogin
      UsuarioUltimoLogin
      IdTipoDispositivo
      SistemaOperativo
      ArquitecturaSO
      NumeroSerieDiscoRigido
      DireccionMAC
      NumeroSerieMotherboard
      NumeroSerieDiscoPrimario
      ResolucionPantalla
      VersionFramework
      Activo
      Control1
   End Enum

#Region "Propiedades"
   Public Property IdDispositivo As String
   Public Property NombreDispositivo As String
   Public Property FechaUltimoLogin As Date?
   Public Property UsuarioUltimoLogin As String
   Public Property IdTipoDispositivo As String
   Public Property SistemaOperativo As String
   Public Property ArquitecturaSO As String
   Public Property NumeroSerieDiscoRigido As String
   Public Property DireccionMAC As String
   Public Property NumeroSerieMotherboard As String
   Public Property NumeroSerieDiscoPrimario As String
   Public Property ResolucionPantalla As String
   Public Property VersionFramework As String
   Public Property Activo As Boolean
   Public Property Control1 As String

#End Region

End Class