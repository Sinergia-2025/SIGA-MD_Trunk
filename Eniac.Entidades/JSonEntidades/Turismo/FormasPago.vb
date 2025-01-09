Namespace JSonEntidades.Turismo
   Public Class FormasPago
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdFormasPago As Integer
      Public Property DescripcionFormasPago As String

   End Class
End Namespace