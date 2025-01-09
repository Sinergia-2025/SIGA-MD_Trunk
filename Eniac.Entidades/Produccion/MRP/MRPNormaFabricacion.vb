Public Class MRPNormaFabricacion
   Inherits Entidad

   Public Const NombreTabla As String = "MRPNormasFabricacion"

   Public Enum Columnas
      IdNormaFab
      CodigoNormaFab
      Descripcion
      DetalleDispositivos
      DetalleMetodos
      DetalleSeguridad
      DetalleControlCalidad
      Activo
   End Enum

   Public Property IdNormaFab As Integer
   Public Property CodigoNormaFab As String
   Public Property Descripcion As String
   Public Property DetalleDispositivos As String
   Public Property DetalleMetodos As String
   Public Property DetalleSeguridad As String
   Public Property DetalleControlCalidad As String
   Public Property Activo As Boolean

   Public Sub New()
      IdNormaFab = 0
      CodigoNormaFab = String.Empty
      Descripcion = String.Empty
      DetalleDispositivos = String.Empty
      DetalleMetodos = String.Empty
      DetalleSeguridad = String.Empty
      DetalleControlCalidad = String.Empty
      Activo = True
   End Sub

End Class
