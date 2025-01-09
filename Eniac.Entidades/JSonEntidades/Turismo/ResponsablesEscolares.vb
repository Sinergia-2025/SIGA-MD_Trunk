Namespace JSonEntidades.Turismo
   Public Class ResponsablesEscolares
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdEstablecimiento As Long
      Public Property IdResponsableEscolar As Long
      Public Property CodigoResponsableEscolar As Long
      Public Property NombreResponsableEscolar As String
      Public Property Telefono As String
      Public Property CorreoElectronico As String
      Public Property IdCargo As Integer
      Public Property NombreCargo As String

   End Class
End Namespace