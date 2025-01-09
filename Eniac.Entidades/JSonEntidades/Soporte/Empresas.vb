Namespace JSonEntidades.Soporte
   Public Class Empresas
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub
      Public Sub New(idEmpresa As Integer,
                     drCliente As DataRow)
         Me.New(idEmpresa)
         Me.CodigoEmpresa = drCliente.Field(Of Long)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
         Me.Cuit = drCliente.Field(Of String)(Entidades.Cliente.Columnas.Cuit.ToString())
         Me.NombreEmpresa = drCliente.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())

      End Sub

      Public Property CodigoEmpresa As Long
      Public Property Cuit As String
      Public Property NombreEmpresa As String

   End Class
End Namespace