Namespace JSonEntidades.Concesionarios.Alcorta
   Public Class Provincia
      Public Const NombreTabla As String = "Provincias"

      Public Enum Campos
         IdProvincia
         Nombre
      End Enum

#Region "Propiedades"
      Public Property IdProvincia() As String
      Public Property Nombre() As String
#End Region

   End Class
   Public Class ProvinciaResponse
      Public Enum Campos
         sync
      End Enum
      Public Property sync As Boolean
   End Class
End Namespace
