Namespace JSonEntidades.Turismo
   Public Class Establecimientos
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdEstablecimiento As Long
      Public Property CodigoEstablecimiento As Long
      Public Property NombreEstablecimiento As String
      Public Property Telefono As String
      Public Property CorreoElectronico As String
      Public Property Direccion As String
      Public Property IdLocalidad As Integer
      Public Property NombreLocalidad As String

      Public Property Responsables As IEnumerable(Of ResponsablesEscolares)

   End Class
End Namespace