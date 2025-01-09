Public Class RequerimientoCompra
   Inherits Entidad
   Public Const NombreTabla As String = "RequerimientosCompras"
   Public Enum Columnas
      IdRequerimientoCompra
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroRequerimiento
      Fecha
      FechaAlta
      IdUsuarioAlta
      Observacion

   End Enum

   Public Sub New()
      Productos = New ListConBorrados(Of RequerimientoCompraProducto)()
      IdSucursal = actual.Sucursal.Id
      Fecha = Date.Now
   End Sub

   'Public Property IdSucursal As Integer
   Public Property IdRequerimientoCompra As Long
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroRequerimiento As Long
   Public Property Fecha As Date
   Public Property FechaAlta As Date
   Public Property IdUsuarioAlta As String
   Public Property Observacion As String

   Public Property Productos As ListConBorrados(Of RequerimientoCompraProducto)

End Class