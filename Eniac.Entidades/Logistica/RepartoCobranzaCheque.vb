Public Class RepartoCobranzaCheque
   Inherits Entidad

   Public Const NombreTabla As String = "RepartosCobranzasCheques"

   Public Enum Columnas
      IdSucursal
      IdReparto
      IdCobranza
      IdSucursalComp
      IdTipoComprobanteComp
      LetraComp
      CentroEmisorComp
      NumeroComprobanteComp
      IdBanco
      IdBancoSucursal
      IdLocalidad
      NumeroCheque
      IdTipoCheque
      FechaEmision
      FechaCobro
      Titular
      Importe
      NroOperacion
      Cuit
   End Enum

   Public Sub New()

   End Sub

   Public Property IdReparto As Integer
   Public Property IdCobranza As Integer
   Public Property IdSucursalComp As Integer
   Public Property IdTipoComprobanteComp As String
   Public Property LetraComp As String
   Public Property CentroEmisorComp As Short
   Public Property NumeroComprobanteComp As Long
   Public Property IdBanco As Integer
   Public Property IdBancoSucursal As Integer
   Public Property IdLocalidad As Integer
   Public Property NumeroCheque As Integer
   Public Property IdTipoCheque As String
   Public Property FechaEmision As DateTime
   Public Property FechaCobro As DateTime
   Public Property Titular As String
   Public Property Importe As Decimal
   Public Property NroOperacion As String
   Public Property Cuit As String
End Class