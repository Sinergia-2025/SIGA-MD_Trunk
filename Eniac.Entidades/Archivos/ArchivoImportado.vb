Public Class ArchivoImportado
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdFuncion
      IdSubFuncion
      NombreArchivo
      FechaLectura
      IdUsuario
      NombrePC
      IdSucursal
   End Enum

#Region "Propiedades"
   Public Property IdFuncion As String
   Public Property IdSubFuncion As String
   Public Property NombreArchivo As String
   Public Property FechaLectura As DateTime
   Public Property IdUsuario As String
   Public Property NombrePC As String
   Public Property IdSucursal As Integer
#End Region

End Class
