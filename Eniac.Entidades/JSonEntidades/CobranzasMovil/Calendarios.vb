Namespace JSonEntidades.CobranzasMovil
   Public Class Calendarios
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer

      Public Property IdCalendario As Integer
      Public Property IdTipoCalendario As Short
      Public Property NombreCalendario As String
      Public Property Activo As Boolean
      Public Property IdNave As Integer?
      Public Property LapsoPorDefecto As Integer
      Public Property LapsoPorDefectoFijo As Boolean

      Public Property Horarios As IEnumerable(Of CalendariosHorarios)
      Public Property TiposServicios As IEnumerable(Of CalendariosTiposTurnos)

      Public Property Cupo As Integer
      Public Property DiasHabilitacionReserva As Integer

   End Class
End Namespace