Public Class MRPAQLA
   Inherits Entidad

   Public Const NombreTabla As String = "MRPAQLA"

   Public Enum Columnas
      IdMRPAQLA
      TamanoLoteDesde
      TamanoLoteHasta
      NivelGeneral1
      NivelGeneral2
      NivelGeneral3
      NivelEspecialS1
      NivelEspecialS2
      NivelEspecialS3
      NivelEspecialS4

   End Enum
   Public Sub New()

   End Sub

   Public Property IdMRPAQLA As Integer
   Public Property TamanoLoteDesde As Integer
   Public Property TamanoLoteHasta As Integer
   Public Property NivelGeneral1 As String
   Public Property NivelGeneral2 As String
   Public Property NivelGeneral3 As String
   Public Property NivelEspecialS1 As String
   Public Property NivelEspecialS2 As String
   Public Property NivelEspecialS3 As String
   Public Property NivelEspecialS4 As String

End Class