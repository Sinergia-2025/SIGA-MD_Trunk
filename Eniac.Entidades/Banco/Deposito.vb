<Serializable()>
Public Class Deposito
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      NumeroDeposito
      IdCuentaBancaria
      Fecha
      UsoFechaCheque
      ImporteTotal
      Observacion
      ImportePesos
      ImporteDolares
      ImporteEuros
      ImporteCheques
      ImporteTarjetas
      ImporteTickets
      FechaAplicado
      IdEstado
      IdCaja
      IdPlanCuenta
      IdAsiento
      IdTipoComprobante
      IdCuentaBancariaDestino
      IdEjercicio
      CotizacionDolar

   End Enum

#Region "Propiedades"

   Private _tipoComprobante As TipoComprobante
   Public Property TipoComprobante() As TipoComprobante
      Get
         If _tipoComprobante Is Nothing Then _tipoComprobante = New TipoComprobante()
         Return _tipoComprobante
      End Get
      Set(value As TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property
   Public Property NumeroDeposito As Long
   Private _cuentaBancaria As CuentaBancaria
   Public Property CuentaBancaria() As CuentaBancaria
      Get
         If _cuentaBancaria Is Nothing Then _cuentaBancaria = New CuentaBancaria()
         Return _cuentaBancaria
      End Get
      Set(value As CuentaBancaria)
         _cuentaBancaria = value
      End Set
   End Property
   Public Property Fecha As Date
   Public Property FechaAplicado As Date
   Public Property UsoFechaCheque As Boolean
   Public Property ImporteTotal As Decimal
   Private _observacion As String
   Public Property Observacion() As String
      Get
         Return _observacion
      End Get
      Set(value As String)
         If value.Length <= 100 Then
            _observacion = value
         Else
            Throw New Exception("La Observación no puede tener mas de 100 caracteres")
         End If
      End Set
   End Property
   Private _chequesPropios As List(Of Cheque)
   Public Property ChequesPropios() As List(Of Cheque)
      Get
         If _chequesPropios Is Nothing Then _chequesPropios = New List(Of Cheque)
         Return _chequesPropios
      End Get
      Set(value As List(Of Cheque))
         _chequesPropios = value
      End Set
   End Property
   Private _chequesTerceros As List(Of Cheque)
   Public Property ChequesTerceros() As List(Of Cheque)
      Get
         If _chequesTerceros Is Nothing Then _chequesTerceros = New List(Of Cheque)
         Return _chequesTerceros
      End Get
      Set(value As List(Of Cheque))
         _chequesTerceros = value
      End Set
   End Property
   Public Property ImportePesos As Decimal
   Public Property ImporteDolares As Decimal
   Public Property ImporteCheques As Decimal
   Public Property ImporteTarjetas As Decimal
   Public Property ImporteTickets As Decimal
   Public Property IdCaja As Integer
   Public Property IdEstado As String

   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?

   Public Property CotizacionDolar As Decimal

   Private _cuentaBancariaDestino As CuentaBancaria
   Public Property CuentaBancariaDestino() As CuentaBancaria
      Get
         If _cuentaBancariaDestino Is Nothing Then _cuentaBancariaDestino = New CuentaBancaria()
         Return _cuentaBancariaDestino
      End Get
      Set(value As CuentaBancaria)
         _cuentaBancariaDestino = value
      End Set
   End Property

   '# Propiedad para almacenar los Cupones que se liquidan
   Public Property TarjetasCupones As DataTable

   '#Propiedad para almacenar las Cuentas Bancos asociadas a las Liquidaciones de Tarjeta
   Private _cuentasBancos As List(Of DepositosCuentasBancos)
   Public Property CuentasBancos As List(Of DepositosCuentasBancos)
      Get
         If _cuentasBancos Is Nothing Then _cuentasBancos = New List(Of DepositosCuentasBancos)
         Return _cuentasBancos
      End Get
      Set(value As List(Of Entidades.DepositosCuentasBancos))
         _cuentasBancos = value
      End Set
   End Property

   Public Property NombreCaja As String

#End Region

End Class
