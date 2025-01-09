Namespace JSonEntidades.Archivos
   Public Class ProductoSucursalPrecioJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdProducto As String
      Public Property IdSucursal As Integer
      Public Property IdListaPrecios As Integer
      Public Property PrecioVenta As Decimal
      Public Property FechaActualizacion As String
      Public Property Usuario As String
      Public Property FechaActualizacionWeb As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen

   End Class

   Public Class ProductoSucursalPrecioJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdProducto As String
      Public Property IdSucursal As Integer
      Public Property IdListaPrecios As Integer
      Public Property DatosProductoSucursalPrecio As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idProducto As String, idSucursal As Integer, idListaPrecios As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdProducto = idProducto
         Me.IdSucursal = idSucursal
         Me.IdListaPrecios = idListaPrecios
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace