Namespace JSonEntidades.CobranzasMovil
   Public Class Clientes
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property NombreCliente As String
      Public Property Direccion As String
      Public Property NombreLocalidad As String
      Public Property Telefono As String
      Public Property Celular As String
      Public Property Cuit As String
      Public Property NombreVendedor As String
      Public Property EstadoDeVisita As String
      Public Property IdCategoriaFiscal As Short
      Public Property NombreCategoriaFiscal As String
      Public Property IdListaPrecios As Integer?
      Public Property NombreListaPrecios As String
      Public Property Observacion As String
      Public Property CorreoElectronico As String
      Public Property IdUsuario As String
      Public Property Clave As String

   End Class
End Namespace