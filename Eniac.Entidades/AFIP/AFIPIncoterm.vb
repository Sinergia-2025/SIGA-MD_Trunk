Public Class AFIPIncoterm
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "AFIPIncoterms"
   Public Enum Columnas
      IdIncoterm
      NombreIncoterm
   End Enum

   Public Property IdIncoterm As String
   Public Property NombreIncoterm As String
End Class
