Namespace JSonEntidades.Turismo
   Public Class Turnos
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdTurno As Integer
      Public Property NombreTurno As String

   End Class
End Namespace