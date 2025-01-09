Namespace JSonEntidades.Turismo
   Public Class Usuarios
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdUsuario As String
      Public Property Clave As String

   End Class
End Namespace