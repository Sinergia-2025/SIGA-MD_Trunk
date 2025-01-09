Public Class VentaTransferencia
   Inherits Entidad
   Public Const NombreTabla As String = "VentasTransferencias"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Orden
      Importe
      IdCuentaBancaria
      IdSucursalLibroBanco
      IdCuentaBancariaLibroBanco
      NumeroMovimientoLibroBanco

   End Enum

   'Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Orden As Integer
   Public Property Importe As Decimal
   Public Property IdCuentaBancaria As Integer
   Public Property IdSucursalLibroBanco As Integer?
   Public Property IdCuentaBancariaLibroBanco As Integer?
   Public Property NumeroMovimientoLibroBanco As Integer?

#Region "Propiedades FK"
   Public Property NombreCuenta As String
#End Region

End Class