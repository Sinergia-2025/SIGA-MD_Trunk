Namespace JSonEntidades.CobranzasMovil
   Public Class ProductosClientes
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub

      Public Property IdEmpresa As Integer
      Public Property IdCliente As Long
      Public Property IdProducto As String
   End Class
End Namespace