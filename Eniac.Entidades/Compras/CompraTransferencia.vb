Public Class CompraTransferencia
   Inherits Entidad
   Public Const NombreTabla As String = "ComprasTransferencias"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProveedor
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
   Public Property IdProveedor As Long
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