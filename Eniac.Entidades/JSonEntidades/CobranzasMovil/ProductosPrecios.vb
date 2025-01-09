Namespace JSonEntidades.CobranzasMovil
   Public Class ProductosPrecios
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdProducto As String
      Public Property IdListaPrecios As Integer
      Public Property NombreListaPrecios As String
      Public Property PrecioVenta As Decimal
      Public Property FechaActualizacion As DateTime
   End Class
End Namespace