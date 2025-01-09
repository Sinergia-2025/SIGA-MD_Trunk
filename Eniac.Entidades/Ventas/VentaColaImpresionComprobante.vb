Public Class VentaColaImpresionComprobante
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdVentaColaImpresion
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

   Public Sub New()

   End Sub

#Region "Propiedades"
   Public Property IdVentaColaImpresion() As Integer
   Public Property IdTipoComprobante() As String
   Public Property Letra() As String
   Public Property CentroEmisor() As Integer
   Public Property NumeroComprobante() As Long
   Public Property IdCliente() As Long
   Public Property CodigoCliente() As Long
   Public Property NombreCliente() As String
   Public Property IdVendedor() As Integer
   Public Property NombreVendedor() As String
   Public Property Fecha() As DateTime
   Public Property IdFormasPago() As Integer
   Public Property DescripcionFormasPago() As String
   Public Property ImporteTotal() As Decimal
   Public Property DescuentoRecargoPorc As Decimal
   Public Property IdCategoria As Integer
   Public Property IdCategoriaFiscal As Short
   Public Property NombreCategoriaFiscal As String

   Public Property ColaImpresion As VentaColaImpresion

#Region "Propiedades ReadOnly"
   Public ReadOnly Property NombreColaImpresion() As String
      Get
         If ColaImpresion Is Nothing Then Return String.Empty
         Return ColaImpresion.NombreColaImpresion
      End Get
   End Property
#End Region

#End Region


   Public Shared Function FromVenta(idVentaColaImpresion As Integer, venta As Venta) As VentaColaImpresionComprobante
      Dim result As VentaColaImpresionComprobante = New VentaColaImpresionComprobante()

      result.IdVentaColaImpresion = idVentaColaImpresion
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
End Class