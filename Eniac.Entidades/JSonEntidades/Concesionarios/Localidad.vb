Namespace JSonEntidades.Concesionarios.Alcorta

   Public Class Localidad
      Public Const NombreTabla As String = "Localidades"

      Public Enum Campos
         IdLocalidad
         NombreLocalidad
         IdPronvicia
      End Enum

#Region "Propiedades"
      Public Property IdLocalidad() As Integer
      Public Property NombreLocalidad() As String
      Public Property IdPronvincia() As String
#End Region

   End Class
   Public Class LocalidadResponse
      Public Enum Campos
         sync
      End Enum
      Public Property sync As Boolean
   End Class

End Namespace
