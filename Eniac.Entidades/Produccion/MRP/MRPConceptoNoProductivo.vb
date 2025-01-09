Public Class MRPConceptoNoProductivo
   Inherits Entidad

   Public Const NombreTabla As String = "MRPConceptosNoProductivos"

   Public Enum Columnas
      IdConceptoNoProductivo
      CodigoConceptoNoProductivo
      NombreConceptoNoProductivo
      Activo
   End Enum
   Public Sub New()
      IdConceptoNoProductivo = 0
      CodigoConceptoNoProductivo = String.Empty
      NombreConceptoNoProductivo = String.Empty
      Activo = True
   End Sub

   Public Property IdConceptoNoProductivo As Integer
   Public Property CodigoConceptoNoProductivo As String
   Public Property NombreConceptoNoProductivo As String
   Public Property Activo As Boolean
End Class