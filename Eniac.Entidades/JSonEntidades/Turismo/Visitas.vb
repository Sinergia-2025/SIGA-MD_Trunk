Namespace JSonEntidades.Turismo
   Public Class Visitas
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdPrograma As String
      Public Property IdVisita As String
      Public Property NombreVisita As String
      Public Property Actividades As List(Of Actividades)

   End Class
End Namespace