Namespace JSonEntidades.Turismo
   Public Class LugaresGastronomicos
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdPrograma As String
      Public Property IdLugarGastronomico As String
      Public Property IdTipo As Integer
      Public Property NombreTipo As String
      Public Property NombreLugarGastronomico As String

   End Class
End Namespace