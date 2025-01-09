Namespace JSonEntidades.Turismo
   Public Class Cursos
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdCurso As Integer
      Public Property NombreCurso As String

   End Class
End Namespace