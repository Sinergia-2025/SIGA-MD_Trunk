Namespace JSonEntidades.CobranzasMovil
   Public Class Productos
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdProducto As String
      Public Property NombreProducto As String
      Public Property IdRubro As Integer
      Public Property NombreCorto As String
      Public Property PrecioVenta As Decimal
      Public Property Embalaje As Integer
      Public Property EsCambiable As Boolean
      Public Property EsBonificable As Boolean
      Public Property EsDevuelto As Boolean
      Public Property CalidadNumeroChasis As String
      Public Property CalidadNroCarroceria As Integer?
      Public Property Stock As Decimal
   End Class
End Namespace