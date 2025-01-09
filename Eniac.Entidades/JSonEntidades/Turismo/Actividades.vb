Namespace JSonEntidades.Turismo
   Public Class Actividades
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdPrograma As String
      Public Property IdVisita As String
      Public Property IdActividad As String
      Public Property NombreActividad As String

   End Class
End Namespace