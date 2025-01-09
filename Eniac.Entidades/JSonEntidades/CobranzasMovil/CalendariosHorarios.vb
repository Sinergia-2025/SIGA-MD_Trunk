Namespace JSonEntidades.CobranzasMovil
   Public Class CalendariosHorarios
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer

      Public Property IdCalendario As Integer
      Public Property IdDiaSemana As System.DayOfWeek
      Public Property IdHorario As Integer
      Public Property HoraDesde As String
      Public Property HoraHasta As String
      Public Property NombreDiaSemana As String

   End Class
End Namespace