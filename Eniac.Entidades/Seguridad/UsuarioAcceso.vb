Public Class UsuarioAcceso
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "UsuariosAccesos"

   Public Enum Columnas
      IdSucursal
      Usuario
      FechaAcceso
      NombrePC
      Exitoso
      Observacion
      UsuarioWindows
   End Enum

#Region "Propiedades"

   Public Property FechaAcceso As DateTime
   Public Property NombrePC As String
   Public Property Exitoso As Boolean
   Public Property Observacion As String
   Public Property UsuarioWindows As String

#End Region

End Class
