Namespace JSonEntidades.CobranzasMovil
   Public Class CalendariosTiposTurnos
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer

      Public Property IdCalendario As Integer
      Public Property IdTipoServicio As String
      Public Property NombreTipoServicio As String

   End Class
End Namespace