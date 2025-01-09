Public Class CuentaCorrienteTarjeta
   Inherits Entidad
   Public Const NombreTabla As String = "CuentasCorrientesTarjetas"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTarjeta
      IdBanco
      Orden

      IdTarjetaCupon
      Monto
      Cuotas
      NumeroCupon
      NumeroLote

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdTarjeta As Integer
   Public Property IdBanco As Integer
   Public Property Orden As Integer

   Public Property IdTarjetaCupon As Integer
   Public Property Monto As Decimal
   Public Property Cuotas As Integer
   Public Property NumeroCupon As Integer
   Public Property NumeroLote As Integer

End Class