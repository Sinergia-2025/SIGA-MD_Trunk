Public Class AplicacionEdicionModulo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdAplicacion
      IdEdicion
      IdModulo
      NombreModulo
   End Enum

#Region "Propiedades"
   Public Property IdAplicacion() As String
   Public Property IdEdicion() As String
   Public Property IdModulo() As Integer
   Public Property NombreModulo() As String
#End Region

End Class
