Public Class DepositosTarjetasCupones
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "DepositosTarjetasCupones"

   Public Enum Columnas
      IdSucursal
      NumeroDeposito
      IdTipoComprobante
      IdTarjetaCupon
   End Enum

   Public Property NumeroDeposito As Long
   Public Property IdTipoComprobante As String
   Public Property IdTarjetaCupon As Integer

End Class
