<Serializable()> _
Public Class ClienteDeuda
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCliente
      nro_prestamo
      fecha_corte
      tipo_cobro
      convenio
      linea
      fecha_emision
      cantidad_cuotas
      cuotas_pagas
      cuotas_adeudadas
      capital_total
      deuda_exigible
      fecha_ult_cobranza
      dias_mora
      deuda_exigible_con_quita
      empresa
      FechaCarta1
      FechaCarta2
      FechaLiquidacion
      ImporteAcordado
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      vendedor
      monto_cuota
      Activo

   End Enum

   Public Sub New()

   End Sub


#Region "Propiedades"

   Public Property IdCliente As Long
   Public Property nro_prestamo As Long
   Public Property fecha_corte As Date
   Public Property tipo_cobro As String
   Public Property convenio As String
   Public Property linea As String
   Public Property fecha_emision As Date
   Public Property cantidad_cuotas As Integer
   Public Property cuotas_pagas As Integer
   Public Property cuotas_adeudadas As Integer
   Public Property capital_total As Decimal
   Public Property deuda_exigible As Decimal
   Public Property fecha_ult_cobranza As Date
   Public Property dias_mora As Integer
   Public Property deuda_exigible_con_quita As Decimal
   Public Property empresa As String
   Public Property Cliente As Entidades.Cliente

   Public Property FechaCarta1 As DateTime
   Public Property FechaCarta2 As DateTime
   Public Property FechaLiquidacion As DateTime

   Public Property TipoComprobante() As Eniac.Entidades.TipoComprobante
   Public Property NumeroComprobante() As Long
   Public Property CentroEmisor() As Short
   Public Property Letra() As String
   Public Property ImporteAcordado As Decimal

   Public Property vendedor As String

   Public Property monto_cuota As Decimal

   Public Property Activo As Decimal


#End Region

End Class

