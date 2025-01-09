Public Class AFIPConceptoCM05
   Inherits Entidad

   Public Const NombreTabla As String = "AFIPConceptosCM05"

   Public Enum Columnas
      IdConceptoCM05
      DescripcionConceptoCM05
      TipoConceptoCM05

   End Enum

   Public Enum TiposConceptosCM05
      INGRESOS
      GASTOS
   End Enum

#Region "Propiedades"
   Public Property IdConceptoCM05 As Integer
   Public Property DescripcionConceptoCM05 As String
   Public Property TipoConceptoCM05 As TiposConceptosCM05
#End Region

End Class