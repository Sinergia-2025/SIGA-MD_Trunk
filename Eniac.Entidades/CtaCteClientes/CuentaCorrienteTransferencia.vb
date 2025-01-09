Public Class CuentaCorrienteTransferencia
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "CuentasCorrientesTransferencias"

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

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Orden As Integer
   Public Property Importe As Decimal
   Public Property IdCuentaBancaria As Integer
   Public Property NombreCuenta As String '# Esta propiedad es solo de visualización. No se graba en BD.
   Public Property IdSucursalLibroBanco As Integer?
   Public Property IdCuentaBancariaLibroBanco As Integer?
   Public Property NumeroMovimientoLibroBanco As Integer?

End Class
