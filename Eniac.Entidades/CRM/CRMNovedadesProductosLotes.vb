Public Class CRMNovedadProductoLote
   Inherits CRMEntidad
   Public Const NombreTabla As String = "CRMNovedadesProductosLotes"

   Public Enum Columnas
      idTipoNovedad
      IdNovedad
      LetraNovedad
      CentroEmisor
      IdProducto
      OrdenProducto
      IdLote
      FechaIngreso
      FechaVencimiento
      CantidadActual
      IdSucursal
      IdDeposito
      IdUbicacion

   End Enum

   Public Property IdNovedad As Long
   Public Property LetraNovedad As String
   Public Property CentroEmisor As Short
   Public Property IdSucursalNovedad As Integer?
   Public Property IdProducto As String
   Public Property OrdenProducto As Integer
   Public Property IdLote As String
   Public Property FechaIngreso As Date
   Public Property FechaVencimiento As Date
   Public Property CantidadActual As Decimal
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer


End Class
