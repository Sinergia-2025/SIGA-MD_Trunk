Public Class PlazoEntrega
   Inherits Entidad

   Public Const NombreTabla As String = "PlazosEntregas"

#Region "Columnas"
   Public Enum Columnas
      IdPlazoEntrega
      DescripcionPlazoEntrega
      ActivoPlazoEntrega
   End Enum

#End Region

#Region "Campos"
   Public Property IdPlazoEntrega As Integer
   Public Property DescripcionPlazoEntrega As String
   Public Property ActivoPlazoEntrega As Boolean
#End Region
End Class
