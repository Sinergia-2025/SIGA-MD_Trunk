Public Class Version
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "Versiones"

   Public Sub New()
      MyBase.New()
   End Sub
   Public Enum Columnas
      IdAplicacion
      NroVersion
      VersionFecha
      IdAplicacionBase
      NroVersionAplicacionBase
      VersionFramework
      VersionReportViewer
      VersionLenguaje
   End Enum

   Public Property IdAplicacion As String
   Public Property NroVersion As String
   Public Property VersionFecha As DateTime
   Public Property IdAplicacionBase As String
   Public Property NroVersionAplicacionBase As String
   Public Property VersionFramework As String
   Public Property VersionReportViewer As String
   Public Property VersionLenguaje As String

End Class
