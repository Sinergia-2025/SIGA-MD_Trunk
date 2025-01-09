Public Class Interes
   Inherits Entidad

   Public Const NombreTabla As String = "Intereses"

   Public Enum Columnas
      IdInteres
      NombreInteres
      AdicionalProporcinalDias
      MetodoParaDeterminarRango
      UtilizaVigencia
      FechaVigenciaDesde
      FechaVigenciaHasta

      VencimientoExcluyeSabado
      VencimientoExcluyeDomingo
      VencimientoExcluyeFeriados

   End Enum

   Public Sub New()
      InteresesDias = New List(Of InteresDias)()
   End Sub

#Region "Propiedades"
   Public Property IdInteres As Integer
   Public Property NombreInteres As String
   Public Property AdicionalProporcinalDias As Decimal
   Public Property MetodoParaDeterminarRango As String
   Public Property InteresesDias As List(Of InteresDias)
   Public Property UtilizaVigencia As Boolean
   Public Property FechaVigenciaDesde As Date?
   Public Property FechaVigenciaHasta As Date?

   Public Property VencimientoExcluyeSabado As Boolean
   Public Property VencimientoExcluyeDomingo As Boolean
   Public Property VencimientoExcluyeFeriados As Boolean
#End Region

End Class

Public Enum InteresesMetodoParaDeterminarRangoEnum As Integer
   <Description("Día del Mes")> DIAMES = 0
   <Description("Días Corridos Desde Fecha Emisión")> DIASCORRIDOSEMISION = 1
   <Description("Días Corridos Desde Fecha Vencimiento")> DIASCORRIDOSVENCIMIENTO = 2
   <Description("Día del Mes de Vencimiento")> DIAMESVENCIMIENTO = 3
End Enum