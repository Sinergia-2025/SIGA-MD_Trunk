Namespace JSonEntidades.Turismo
   Public Class Programas
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdPrograma As String
      Public Property NombrePrograma As String
      Public Property Visitas As List(Of Visitas)
      Public Property LugaresGastronomicos As List(Of LugaresGastronomicos)

   End Class
End Namespace