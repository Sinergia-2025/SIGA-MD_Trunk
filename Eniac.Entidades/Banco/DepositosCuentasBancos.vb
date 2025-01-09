Public Class DepositosCuentasBancos
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "DepositosCuentasBancos"

   Public Enum Columnas
      IdSucursal
      NumeroDeposito
      IdTipoComprobante
      IdCuentaBanco
      IdTipoCuenta
      Importe
      Observacion
   End Enum

   Public Property NumeroDeposito As Long
   Public Property IdTipoComprobante As String
   Public Property IdCuentaBanco As Integer
   Public Property IdTipoCuenta As String
   Public Property Importe As Decimal
   Public Property Observacion As String


   '# Propiedades que no se persisten.
   Public Property NombreCuentaBanco As String

End Class
