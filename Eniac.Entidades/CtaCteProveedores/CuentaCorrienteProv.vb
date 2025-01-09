<Serializable()>
Public Class CuentaCorrienteProv
   Inherits Entidad
   Implements IComprobanteModificable
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Fecha
      FechaVencimiento
      ImporteTotal
      IdFormasPago
      Observacion
      Saldo
      CantidadCuotas
      ImportePesos
      ImporteDolares
      ImporteEuros
      ImporteCheques
      ImporteTransfBancaria
      ImporteTickets
      IdCuentaBancaria
      FechaTransferencia
      IdCaja
      NumeroPlanilla
      NumeroMovimiento
      ImporteRetenciones
      ImporteTarjetas
      IdEstadoComprobante
      IdUsuario
      IdProveedor
      FechaActualizacion
      IdEjercicio
      IdPlanCuenta
      IdAsiento
      MetodoGrabacion
      IdFuncion
      ImprimeSaldos
      CotizacionDolar
      RefProveedor
      PromedioDiasPago
      NumeroOrdenCompra
      SaldoCtaCte
   End Enum

   Public Sub New()
      Conciliado = False
      ImporteRetenciones = 0

      TipoComprobante = New TipoComprobante()
      CuentaBancariaTransfBanc = New CuentaBancaria()

      FormaPago = New VentaFormaPago()
      CajaDetalle = New CajaDetalles()

      ChequesPropios = New List(Of Cheque)
      ChequesTerceros = New List(Of Cheque)
      Retenciones = New List(Of RetencionCompra)
      Pagos = New List(Of CuentaCorrienteProvPago)
   End Sub

#Region "Propiedades"

   Public Property TipoComprobante As TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long
   Public Property Fecha As Date
   Public Property FechaVencimiento As Date
   Public Property ImporteTotal As Decimal
   Public Property Anticipo As Decimal
   Public Property Saldo As Decimal
   Public Property Interes As Decimal
   Public Property Cuotas As Integer

   Public Property ImportePesos As Decimal
   Public Property ImporteDolares As Decimal
   Public Property ImporteTickets As Decimal
   Public Property ImporteTarjetas As Decimal
   Public Property ImporteRetenciones As Decimal
   Public ReadOnly Property ImporteChequesTerceros As Decimal
      Get
         Return ChequesTerceros.SumSecure(Function(c) c.Importe).IfNull()
      End Get
   End Property
   Public ReadOnly Property ImporteChequesPropios As Decimal
      Get
         Return ChequesPropios.SumSecure(Function(c) c.Importe).IfNull()
      End Get
   End Property
   Public ReadOnly Property ImporteCheques() As Decimal
      Get
         Return ImporteChequesPropios + ImporteChequesTerceros
      End Get
   End Property
   Public Property ImporteTransfBancaria As Decimal
   Public Property FechaTransferencia As Date?
   Public Property CuentaBancariaTransfBanc As CuentaBancaria

   Public Property Conciliado As Boolean 'Para determinar al guardar si queremos que guarde la transferencia conciliada o no. No se persiste en CtaCte. Va directo a LibrosBancos.
   Public Property Observacion As String
   Public Property RefProveedor As String
   Public Property IdEstado As String

   Public Property Proveedor As Proveedor
   Public Property FormaPago() As VentaFormaPago

   Public Property Pagos As List(Of CuentaCorrienteProvPago)
   Public Property ChequesPropios As List(Of Entidades.Cheque)
   Public Property ChequesTerceros As List(Of Cheque)
   Public Property Retenciones As List(Of RetencionCompra)
   Public Property CajaDetalle As CajaDetalles

   Public Property FechaActualizacion As Date


   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?

   Public Property MetodoGrabacionCampo As MetodoGrabacion
   Public Property IdFuncion As String

   Public Property ImprimeSaldos As Boolean
   Public Property CotizacionDolar As Decimal
   Public Property NumeroOrdenCompra As Long

   Public Property PromedioDiasPago As Decimal
   Public Property CCTransferencias As List(Of Entidades.CuentaCorrienteProvTransferencia)

   Public Property SaldoCtaCte As Nullable(Of Decimal)
#End Region

#Region "Propiedades para Renumerar"
   'Solo se usan para el método Renumerar
   Private Property IdSucursalNuevo As Integer Implements IComprobanteModificable.IdSucursalNuevo
   Private Property IdTipoComprobanteNuevo As String Implements IComprobanteModificable.IdTipoComprobanteNuevo
   Private Property LetraNuevo As String Implements IComprobanteModificable.LetraNuevo
   Private Property CentroEmisorNuevo As Short Implements IComprobanteModificable.CentroEmisorNuevo
   Private Property NumeroComprobanteNuevo As Long Implements IComprobanteModificable.NumeroComprobanteNuevo

   Private ReadOnly Property DebeRenumerar As Boolean Implements IComprobanteModificable.DebeRenumerar
      Get
         Return (Not String.IsNullOrWhiteSpace(IdTipoComprobanteNuevo) And TipoComprobante.IdTipoComprobante <> IdTipoComprobanteNuevo) Or
                (Not String.IsNullOrWhiteSpace(LetraNuevo) And Letra <> LetraNuevo) Or
                (CentroEmisorNuevo <> 0 And CentroEmisor <> CentroEmisorNuevo) Or
                (NumeroComprobanteNuevo <> 0 And NumeroComprobante <> NumeroComprobanteNuevo)
      End Get
   End Property

   Private Sub LimpiaModificable() Implements IComprobanteModificable.LimpiaModificable
      IdSucursalNuevo = 0
      IdTipoComprobanteNuevo = String.Empty
      LetraNuevo = String.Empty
      CentroEmisorNuevo = 0
      NumeroComprobanteNuevo = 0
   End Sub
   Public Property Direccion() As String
   Public Property IdLocalidad() As Integer
#End Region
End Class