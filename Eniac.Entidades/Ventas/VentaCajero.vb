Public Class VentaCajero
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdCliente
      CodigoCliente
      NombreCliente
      IdVendedor
      NombreVendedor
      Fecha
      IdFormasPago
      DescripcionFormasPago
      ImporteTotal
      DescuentoRecargoPorc
      IdCategoria
      IdCategoriaFiscal
      NombreCategoriaFiscal
   End Enum

   Public Enum CajeroGenera
      Ventas
      Recibos
   End Enum

   Public Sub New()

   End Sub

#Region "Propiedades"
   Property IdTipoComprobante() As String
   Property Letra() As String
   Property CentroEmisor() As Integer
   Property NumeroComprobante() As Long
   Property IdCliente() As Long
   Property CodigoCliente() As Long
   Property NombreCliente() As String
   Property IdVendedor() As Integer
   Property NombreVendedor() As String
   Property Fecha() As DateTime
   Property IdFormasPago() As Integer
   Property DescripcionFormasPago() As String
   Property ImporteTotal() As Decimal
   Property DescuentoRecargoPorc As Decimal
   Property IdCategoria As Integer
   Property IdCategoriaFiscal As Short
   Property NombreCategoriaFiscal As String
#End Region


   Public Shared Function FromVenta(venta As Venta) As VentaCajero
      Dim result As VentaCajero = New VentaCajero()

      result.IdSucursal = venta.IdSucursal
      result.IdTipoComprobante = venta.IdTipoComprobante
      result.Letra = venta.LetraComprobante
      result.CentroEmisor = venta.CentroEmisor
      result.NumeroComprobante = venta.NumeroComprobante
      result.IdCliente = venta.Cliente.IdCliente
      result.CodigoCliente = venta.Cliente.CodigoCliente
      result.NombreCliente = venta.Cliente.NombreCliente
      If venta.Vendedor IsNot Nothing Then
         result.IdVendedor = venta.Vendedor.IdEmpleado
         result.NombreVendedor = venta.Vendedor.NombreEmpleado
      End If
      result.Fecha = venta.Fecha
      If venta.FormaPago IsNot Nothing Then
         result.IdFormasPago = venta.FormaPago.IdFormasPago
         result.DescripcionFormasPago = venta.FormaPago.DescripcionFormasPago
      End If
      result.ImporteTotal = venta.ImporteTotal
      result.DescuentoRecargoPorc = venta.DescuentoRecargoPorc
      result.IdCategoria = venta.IdCategoria
      result.IdCategoriaFiscal = venta.Cliente.CategoriaFiscal.IdCategoriaFiscal
      result.NombreCategoriaFiscal = venta.Cliente.CategoriaFiscal.NombreCategoriaFiscal

      Return result
   End Function
   Public Shared Function FromCuentaCorriente(ctacte As CuentaCorriente) As VentaCajero
      Dim result As VentaCajero = New VentaCajero()

      result.IdSucursal = ctacte.IdSucursal
      result.IdTipoComprobante = ctacte.TipoComprobante.IdTipoComprobante
      result.Letra = ctacte.Letra
      result.CentroEmisor = ctacte.CentroEmisor
      result.NumeroComprobante = ctacte.NumeroComprobante
      result.IdCliente = ctacte.Cliente.IdCliente
      result.CodigoCliente = ctacte.Cliente.CodigoCliente
      result.NombreCliente = ctacte.Cliente.NombreCliente
      If ctacte.Vendedor IsNot Nothing Then
         result.IdVendedor = ctacte.Vendedor.IdEmpleado
         result.NombreVendedor = ctacte.Vendedor.NombreEmpleado
      End If
      result.Fecha = ctacte.Fecha
      If ctacte.FormaPago IsNot Nothing Then
         result.IdFormasPago = ctacte.FormaPago.IdFormasPago
         result.DescripcionFormasPago = ctacte.FormaPago.DescripcionFormasPago
      End If
      result.ImporteTotal = ctacte.ImporteTotal
      'result.DescuentoRecargoPorc = venta.DescuentoRecargoPorc
      result.IdCategoria = ctacte.IdCategoria
      result.IdCategoriaFiscal = ctacte.Cliente.CategoriaFiscal.IdCategoriaFiscal
      result.NombreCategoriaFiscal = ctacte.Cliente.CategoriaFiscal.NombreCategoriaFiscal

      Return result
   End Function
End Class
