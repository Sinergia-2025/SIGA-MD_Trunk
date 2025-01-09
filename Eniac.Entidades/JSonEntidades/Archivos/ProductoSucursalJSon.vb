Namespace JSonEntidades.Archivos
   Public Class ProductoSucursalJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdProducto As String
      Public Property IdSucursal As Integer
      Public Property PrecioFabrica As Decimal
      Public Property PrecioCosto As Decimal
      Public Property Usuario As String
      Public Property FechaActualizacion As String
      Public Property Stock As Decimal
      Public Property StockInicial As Decimal
      Public Property PuntoDePedido As Decimal
      Public Property StockMinimo As Decimal
      Public Property StockMaximo As Decimal
      Public Property Ubicacion As String
      'Public Property StockReservado As Decimal

      ''' -->
      'Public Property StockDefectuoso As Decimal
      'Public Property StockFuturo As Decimal
      'Public Property StockFuturoReservado As Decimal
      '' <--

      Public Property FechaActualizacionWeb As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class ProductoSucursalJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdProducto As String
      Public Property IdSucursal As Integer
      Public Property DatosProductoSucursal As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idProducto As String, idSucursal As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdProducto = idProducto
         Me.IdSucursal = idSucursal
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class
End Namespace