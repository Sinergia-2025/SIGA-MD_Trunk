Public Class TareaProgramadaHorario
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TareasProgramadasHorarios"
   Public Enum Columnas
      IdTareaProgramada
      DiaSemana
      HoraProgramada

   End Enum

#Region "Propiedades"
   Public Property IdTareaProgramada As Integer
   Private _diaSemana As System.DayOfWeek
   Public Property DiaSemana As System.DayOfWeek
      Get
         Return _diaSemana
      End Get
      Set(value As System.DayOfWeek)
         _diaSemana = value
         _nombreDiaSemana = value.NombreDiaSemana()
      End Set
   End Property

   Public Property HoraProgramada As String

   Private _nombreDiaSemana As String
   Public Property NombreDiaSemana() As String
      Get
         If String.IsNullOrWhiteSpace(_nombreDiaSemana) Then
            _nombreDiaSemana = DiaSemana.NombreDiaSemana()
         End If
         Return _nombreDiaSemana
      End Get
      Set(ByVal value As String)
         _nombreDiaSemana = value
      End Set
   End Property

#End Region
End Class