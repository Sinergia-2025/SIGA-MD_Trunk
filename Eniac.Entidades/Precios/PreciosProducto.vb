''Esta clase es solo usada con fines de revolver valores. No existe en Base de Datos (todavía :))
Public Class PreciosProducto
   Public Property IdSucursal As Integer
   Public Property IdListaDePrecios As Integer
   Public Property IdProducto As String

   Public Property PrecioCostoSinIVA As Decimal
   Public Property PrecioCostoConIVA As Decimal
   Public Property PrecioVentaSinIVA As Decimal
   Public Property PrecioVentaConIVA As Decimal

   Public Sub New(idSucursal As Integer, idProducto As String, idListaDePrecios As Integer)
      Me.IdSucursal = idSucursal
      Me.IdListaDePrecios = idListaDePrecios
      Me.IdProducto = idProducto
   End Sub
End Class