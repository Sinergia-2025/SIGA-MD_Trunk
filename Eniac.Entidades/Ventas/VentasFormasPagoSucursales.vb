Public Class VentasFormasPagoSucursales
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "VentasFormasPagoSucursales"

   ' # Columnas
   Public Enum Columnas
      IdSucursal
      IdFormasPago
   End Enum

   ' # Propiedades
   Public Property IdFormasPago As Integer
   Public Property DescripcionFormasPago As String
   Public Property OrdenVentas As Integer
   Public Property OrdenCompras As Integer
   Public Property OrdenFichas As Integer

End Class
