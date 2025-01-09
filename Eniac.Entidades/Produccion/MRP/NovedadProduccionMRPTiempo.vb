Public Class NovedadProduccionMRPTiempo
   Inherits Entidad

   Public Const NombreTabla As String = "NovedadesProduccionMRPTiempos"

#Region "Columnas"
   Public Enum Columnas
      NumeroNovedadesProducccion
      CodigoOperacion
      IdTipoDeclaracion
      FechaHoraInicio
      FechaHoraFin
      IdConcepto
   End Enum
#End Region
   Public Sub New()
      NumeroNovedadesProducccion = 0
   End Sub

#Region "Propiedades"
   Public Property NumeroNovedadesProducccion As Integer
   Public Property CodigoOperacion As String
   Public Property IdTipoDeclaracion As String
   Public Property FechaHoraInicio As DateTime
   Public Property FechaHoraFin As DateTime
   Public Property IdConcepto As Integer
#End Region

#Region "Propiedades no contenida en la entidad"
   Public Property Tiempo As String
   Public Property DescripcionConcepto As String

#End Region
End Class
