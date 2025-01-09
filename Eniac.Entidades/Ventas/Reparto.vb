Imports actual = Eniac.Entidades.Usuario.Actual
Public Class Reparto
   Inherits Entidad
   Public Const NombreTabla As String = "Repartos"
   Public Enum Columnas
      IdSucursal
      IdReparto
      FechaReparto
      IdTransportista
      IdEstado
      IdUsuario
      FechaActualizacion
      IdSucursalSalida
      IdTipoComprobanteSalida
      LetraSalida
      CentroEmisorSalida
      NumeroComprobanteSalida
      IdSucursalEntrada
      IdTipoComprobanteEntrada
      LetraEntrada
      CentroEmisorEntrada
      NumeroComprobanteEntrada
      TotalGastos
      TotalGastosCompras
      TotalGastosCaja
      TotalResumenComprobante
      TotalResumenEfectivo
      TotalResumenTransferencia
      TotalResumenCtaCte
      TotalResumenCheques
      TotalResumenNCred
      TotalResumenReenvio
      TotalResumenSaldoGeneral
   End Enum

   Public Enum EstadosReparto
      ACTIVO
      ANULADO
   End Enum

   Public Sub New()
      IdUsuario = actual.Nombre
      IdSucursal = actual.Sucursal.Id
      IdEstado = EstadosReparto.ACTIVO.ToString()
      Comprobantes = New List(Of RepartoComprobante)()
      Gastos = New List(Of RepartoGasto)()
   End Sub

   Public Property IdReparto As Integer
   Public Property FechaReparto As DateTime?
   Public Property Transportista As Transportista
   Public Property IdEstado As String
   Public Property IdUsuario As String
   Public Property FechaActualizacion As DateTime


   Public Property IdSucursalSalida As Integer?
   Public Property IdTipoComprobanteSalida As String
   Public Property LetraSalida As String
   Public Property CentroEmisorSalida As Short?
   Public Property NumeroComprobanteSalida As Long?
   Public Property IdSucursalEntrada As Integer?
   Public Property IdTipoComprobanteEntrada As String
   Public Property LetraEntrada As String
   Public Property CentroEmisorEntrada As Short?
   Public Property NumeroComprobanteEntrada As Long?

   Public Property TotalGastos As Decimal
   Public Property TotalGastosCompras As Decimal
   Public Property TotalGastosCaja As Decimal

   Public Property TotalResumenComprobante As Decimal
   Public Property TotalResumenEfectivo As Decimal
   Public Property TotalResumenTransferencia As Decimal
   Public Property TotalResumenCtaCte As Decimal
   Public Property TotalResumenCheques As Decimal
   Public Property TotalResumenNCred As Decimal
   Public Property TotalResumenReenvio As Decimal
   Public Property TotalResumenSaldoGeneral As Decimal

   Public Property Comprobantes As List(Of RepartoComprobante)
   Public Property Gastos As List(Of RepartoGasto)

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdTransportista As Integer?
      Get
         If Transportista Is Nothing Then Return Nothing
         Return Transportista.idTransportista
      End Get
   End Property
   Public ReadOnly Property NombreTransportista As String
      Get
         If Transportista Is Nothing Then Return String.Empty
         Return Transportista.NombreTransportista
      End Get
   End Property
#End Region

End Class