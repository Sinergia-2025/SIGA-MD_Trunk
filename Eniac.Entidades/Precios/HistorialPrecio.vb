Public Class HistorialPrecio
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "HistorialPrecios"
   Public Enum Columnas
      IdProducto
      IdSucursal
      IdListaPrecios
      FechaHora
      PrecioFabrica
      PrecioCosto
      PrecioVenta
      Usuario
      NombreListaPrecios
      IdFuncion
   End Enum

   Private Sub New(idFuncion As String)
      Me.IdFuncion = IdFuncion
   End Sub
   Public Sub New(ps As ProductoSucursal, idFuncion As String)
      Me.New(idFuncion)
      Me.IdProducto = ps.Producto.IdProducto
      Me.IdSucursal = ps.Sucursal.Id
      Me.IdListaPrecios = -1
      Me.NombreListaPrecios = String.Empty
      Me.FechaHora = Now
      Me.PrecioFabrica = ps.PrecioFabrica
      Me.PrecioCosto = ps.PrecioCosto
      Me.PrecioVenta = Nothing
      Me.Usuario = ps.Usuario
   End Sub

   Public Sub New(psp As ProductoSucursalPrecio, idFuncion As String)
      Me.New(idFuncion)
      Me.IdProducto = psp.ProductoSucursal.Producto.IdProducto
      Me.IdSucursal = psp.ProductoSucursal.Sucursal.Id
      Me.IdListaPrecios = psp.ListaDePrecios.IdListaPrecios
      Me.NombreListaPrecios = psp.ListaDePrecios.NombreListaPrecios
      Me.FechaHora = Now
      Me.PrecioFabrica = Nothing
      Me.PrecioCosto = Nothing
      Me.PrecioVenta = psp.PrecioVenta
      Me.Usuario = psp.Usuario
   End Sub

   'Public Property IdSucursal As Integer 'Estan en Entidad
   'Public Property Usuario As String     'Estan en Entidad
   Public Property IdProducto As String
   Public Property IdListaPrecios As Integer
   Public Property FechaHora As Date
   Public Property PrecioFabrica As Decimal?
   Public Property PrecioCosto As Decimal?
   Public Property PrecioVenta As Decimal?
   Public Property NombreListaPrecios As String
   Public Property IdFuncion As String

End Class