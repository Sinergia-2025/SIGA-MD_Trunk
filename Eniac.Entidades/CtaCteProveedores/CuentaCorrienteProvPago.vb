<Serializable()>
Public Class CuentaCorrienteProvPago
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      CuotaNumero
      Fecha
      FechaVencimiento
      ImporteCuota
      SaldoCuota
      IdFormasPago
      Observacion
      IdTipoComprobante2
      NumeroComprobante2
      CentroEmisor2
      CuotaNumero2
      Letra2
      IdProveedor
      DescuentoRecargo
      DescuentoRecargoPorc
      MercEnviada
   End Enum

   Public Sub New()
      TipoComprobante = New TipoComprobante()
      ImporteCuota = 0
      SaldoCuota = 0
      CuentaCorrienteProv = New CuentaCorrienteProv()
      FormaPago = New VentaFormaPago()
      DescuentoRecargoPorc = 0
      DescuentoRecargo = 0

   End Sub

#Region "Propiedades"

   Public Property TipoComprobante As TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long
   Public Property Cuota As Integer
   Public Property Fecha As Date
   Public Property FechaVencimiento As Date
   Public Property ImporteCuota As Decimal
   Public Property SaldoCuota As Decimal
   Public Property Paga As Decimal
   Public Property CuentaCorrienteProv As CuentaCorrienteProv
   Public Property FormaPago As VentaFormaPago
   Public Property DescuentoRecargoPorc As Decimal
   Public Property DescuentoRecargo As Decimal
   Public Property MercEnviada As Boolean
   Public Property Observacion As String

#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return TipoComprobante.IdTipoComprobante
      End Get
   End Property

   Public ReadOnly Property FormasPagoDescripcion() As String
      Get
         Return FormaPago.DescripcionFormasPago
      End Get
   End Property

#End Region

End Class