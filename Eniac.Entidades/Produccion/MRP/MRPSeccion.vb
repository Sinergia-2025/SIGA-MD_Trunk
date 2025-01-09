Public Class MRPSeccion
   Inherits Entidad

   Public Const NombreTabla As String = "MRPSecciones"

   Public Enum Columnas
      IdSeccion
      CodigoSeccion
      Descripcion
      ClaseSeccion
      Activo
   End Enum

   Public Property IdSeccion As Integer
   Public Property CodigoSeccion As String
   Public Property Descripcion As String
   Public Property ClaseSeccion As ClaseSecciones
   Public Property Activo As Boolean

   Public Sub New()
      IdSeccion = 0
      CodigoSeccion = String.Empty
      Descripcion = String.Empty
      Activo = True
   End Sub

   Public Enum ClaseSecciones
      <Description("Centros Productivos")> SCP
      <Description("Apoyo a Producción")> SAP
   End Enum
End Class
