Public Class RepartoGasto
   Inherits Entidad
   Public Const NombreTabla As String = "RepartosGastos"
   Public Enum Columnas
      IdSucursal
      IdReparto
      IdGasto
      IdCuentaCaja
      ImportePesos
      Observacion
      IdCaja
      NumeroPlanilla
      NumeroMovimiento

   End Enum

   Public Property IdReparto As Integer
   Public Property IdGasto As Integer
   Public Property CuentaCaja As CuentaDeCaja
   Public Property ImportePesos As Decimal
   Public Property Observacion As String
   Public Property IdCaja As Integer
   Public Property NumeroPlanilla As Integer
   Public Property NumeroMovimiento As Integer

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdCuentaCaja As Integer
      Get
         If CuentaCaja Is Nothing Then Return 0
         Return CuentaCaja.IdCuentaCaja
      End Get
   End Property
   Public ReadOnly Property NombreCuentaCaja As String
      Get
         If CuentaCaja Is Nothing Then Return ""
         Return CuentaCaja.NombreCuentaCaja
      End Get
   End Property
#End Region
   '   

End Class