Imports System.ComponentModel

<Serializable()>
Public Class CuentaCorriente
   Inherits Eniac.Entidades.Entidad
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
      ImporteTarjetas
      ImporteTickets
      ImporteTransfBancaria
      IdCuentaBancaria
      IdVendedor
      ImporteRetenciones
      IdCaja
      NumeroPlanilla
      NumeroMovimiento
      IdUsuario
      IdEstadoComprobante
      IdCliente
      FechaActualizacion
      IdClienteCtaCte
      IdCategoria
      SaldoCtaCte
      IdEjercicio
      IdPlanCuenta
      IdAsiento
      MetodoGrabacion
      IdFuncion
      ImprimeSaldos
      IdEstadoCliente
      IdCobrador
      NumeroOrdenCompra
      Referencia

      IdSucursalVinculado
      IdTipoComprobanteVinculado
      LetraVinculado
      CentroEmisorVinculado
      NumeroComprobanteVinculado
      CotizacionDolar
      FechaTransferencia
      FechaExportacion
      Direccion
      IdLocalidad
      FechaViaje
      NombreEstablecimiento
      NombrePrograma

      NumeroReparto
      FechaEnvioCorreo

      '-- REQ-31710.- ---
      IdTipoNovedad
      LetraNovedad
      CentroEmisorNovedad
      NumeroNovedad
      '-- REQ-33373.- ---
      IdEmbarcacion
      NombreEmbarcacion
      '------------------
      NombreCategoriaEmbarcacion
      '-- REQ-31947.- ---
      FechaCalculoInteresModif
      FechaCalculoInteres
      '-- REQ-36331.- ---
      IdCama
      '-- REQ-42455.- ---
      FechaPromedioCobro
      PromedioDiasCobro
      CantidadDiasCobro
      '------------------
   End Enum

   Public Sub New()
      Conciliado = False
      CCTransferencias = New List(Of CuentaCorrienteTransferencia)()
   End Sub

#Region "Campos"

   Private _tipoComprobante As Eniac.Entidades.TipoComprobante
   Private _categoriaEmbarcacion As CategoriaEmbarcacion
   Private _Letra As String
   Private _NumeroComprobante As Long
   Private _centroEmisor As Short

   Private _Fecha As Date
   Private _FechaVencimiento As Date
   Private _Importe As Decimal

   Private _anticipo As Decimal
   Private _cuotas As Integer
   Private _formaPago As Entidades.VentaFormaPago
   Private _interes As Decimal
   Private _saldo As Decimal
   Private _idEstado As String
   Private _nroFactura As Integer
   Private _observacion As String
   Private _pagos As Generic.List(Of CuentaCorrientePago)
   Private _Cliente As Eniac.Entidades.Cliente
   Private _Vendedor As Eniac.Entidades.Empleado

   Private _cheques As List(Of Entidades.Cheque)

   Private _importeTarjetas As Decimal = 0
   Private _importeCheques As Decimal = 0
   Private _ImporteTickets As Decimal = 0
   Private _importeDolares As Decimal = 0
   Private _importePesos As Decimal = 0
   Private _importeTransfBancaria As Decimal = 0
   Private _cuentaBancariaTransfBanc As Entidades.CuentaBancaria

   Private _importeRetenciones As Decimal = 0
   Private _FechaActualizacion As Date
   Private _IdClienteCtaCte As Long
   Private _IdCategoria As Integer
   Private _saldoCtaCte As Nullable(Of Decimal) ' o escribirlo asi: Decimal?

#End Region
   Public Enum FormatoPMC
      <Description("Pago Mis Cuentas")> PMC
      <Description("Roela Pago Mis Cuentas")> ROELAPMC
      <Description("SIRPLUS")> SIRPLUS
   End Enum

#Region "Propiedades"

   Public Property TipoComprobante() As Eniac.Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Eniac.Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Eniac.Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property
   'Public Property CategoriaEmbarcacion() As Eniac.Entidades.CategoriaEmbarcacion
   '   Get
   '      If Me._categoriaEmbarcacion Is Nothing Then
   '         Me._categoriaEmbarcacion = New Eniac.Entidades.CategoriaEmbarcacion()
   '      End If
   '      Return _categoriaEmbarcacion
   '   End Get
   '   Set(ByVal value As Eniac.Entidades.CategoriaEmbarcacion)
   '      _categoriaEmbarcacion = value
   '   End Set
   'End Property
   Private Property _cobrador As Entidades.Empleado
   Public Property Cobrador() As Eniac.Entidades.Empleado
      Get
         If Me._cobrador Is Nothing Then
            Me._cobrador = New Eniac.Entidades.Empleado()
         End If
         Return _cobrador
      End Get
      Set(ByVal value As Eniac.Entidades.Empleado)
         _cobrador = value
      End Set
   End Property

   Private Property _estadoCliente As Entidades.EstadoCliente
   Public Property EstadoCliente() As Entidades.EstadoCliente
      Get
         If Me._estadoCliente Is Nothing Then
            Me._estadoCliente = New Eniac.Entidades.EstadoCliente()
         End If
         Return _estadoCliente
      End Get
      Set(ByVal value As Entidades.EstadoCliente)
         _estadoCliente = value
      End Set
   End Property


   Public Property Fecha() As Date
      Get
         Return Me._Fecha
      End Get
      Set(ByVal value As Date)
         Me._Fecha = value
      End Set
   End Property

   Public Property ImporteAnticipo As Decimal      'NO SE GUARDA EN NINGUN LADO. SOLO PARA QUE LA FICHA PUEDA DECIRLA A LA REGLA CUANTO ES DE CUOTA CERO.

   Public Property Pagos() As Generic.List(Of Entidades.CuentaCorrientePago)
      Get
         If Me._pagos Is Nothing Then
            Me._pagos = New Generic.List(Of Entidades.CuentaCorrientePago)
         End If
         Return Me._pagos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.CuentaCorrientePago))
         Me._pagos = value
      End Set
   End Property

   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property

   Public Property IdEstado() As String
      Get
         Return Me._idEstado
      End Get
      Set(ByVal value As String)
         If value.Length <= 10 Then
            Me._idEstado = value
         Else
            Throw New Exception("El estado no puede tener mas de 10 caracteres")
         End If
      End Set
   End Property

   Public Property Saldo() As Decimal
      Get
         Return Me._saldo
      End Get
      Set(ByVal value As Decimal)
         Me._saldo = value
      End Set
   End Property

   Public Property Cliente() As Eniac.Entidades.Cliente
      Get
         Return _Cliente
      End Get
      Set(ByVal value As Eniac.Entidades.Cliente)
         _Cliente = value
      End Set
   End Property

   Public Property Vendedor() As Eniac.Entidades.Empleado
      Get
         Return _Vendedor
      End Get
      Set(ByVal value As Eniac.Entidades.Empleado)
         _Vendedor = value
      End Set
   End Property

   Public Property ImporteTotal() As Decimal
      Get
         Return Me._Importe
      End Get
      Set(ByVal value As Decimal)
         Me._Importe = value
      End Set
   End Property

   Public Property Interes() As Decimal
      Get
         Return Me._interes
      End Get
      Set(ByVal value As Decimal)
         Me._interes = value
      End Set
   End Property

   Public Property FormaPago() As Entidades.VentaFormaPago
      Get
         If Me._formaPago Is Nothing Then
            Me._formaPago = New Entidades.VentaFormaPago()
         End If
         Return Me._formaPago
      End Get
      Set(ByVal value As Entidades.VentaFormaPago)
         Me._formaPago = value
      End Set
   End Property

   Public Property CantidadCuotas() As Integer
      Get
         Return Me._cuotas
      End Get
      Set(ByVal value As Integer)
         Me._cuotas = value
      End Set
   End Property

   Public Property Anticipo() As Decimal
      Get
         Return Me._anticipo
      End Get
      Set(ByVal value As Decimal)
         Me._anticipo = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long
      Get
         Return Me._NumeroComprobante
      End Get
      Set(ByVal value As Long)
         '       If value.Length <= 12 Then
         Me._NumeroComprobante = value
         '   Else
         '    Throw New Exception("El nro. de documento no puede tener mas de 12 caracteres")
         '   End If
      End Set
   End Property

   Public Property CentroEmisor() As Short
      Get
         Return Me._centroEmisor
      End Get
      Set(ByVal value As Short)
         '       If value.Length <= 12 Then
         Me._centroEmisor = value
         '   Else
         '    Throw New Exception("El nro. de documento no puede tener mas de 12 caracteres")
         '   End If
      End Set
   End Property

   Public Property Letra() As String
      Get
         Return Me._Letra
      End Get
      Set(ByVal value As String)
         If value.Length = 1 Then
            Me._Letra = value
         Else
            Throw New Exception("La letra solo puede tener un caracter")
         End If
      End Set
   End Property

   Public Property FechaVencimiento() As Date
      Get
         Return Me._FechaVencimiento
      End Get
      Set(ByVal value As Date)
         Me._FechaVencimiento = value
      End Set
   End Property

   Public Property Cheques() As List(Of Entidades.Cheque)
      Get
         If Me._cheques Is Nothing Then
            Me._cheques = New List(Of Entidades.Cheque)
         End If
         Return _cheques
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         _cheques = value
      End Set
   End Property

   Public Property ImporteTarjetas() As Decimal
      Get
         Return _importeTarjetas
      End Get
      Set(ByVal value As Decimal)
         _importeTarjetas = value
      End Set
   End Property

   Public Property ImporteCheques() As Decimal
      Get
         Return _importeCheques
      End Get
      Set(ByVal value As Decimal)
         _importeCheques = value
      End Set
   End Property

   Public Property ImporteTickets() As Decimal
      Get
         Return _ImporteTickets
      End Get
      Set(ByVal value As Decimal)
         _ImporteTickets = value
      End Set
   End Property

   Public Property ImporteDolares() As Decimal
      Get
         Return _importeDolares
      End Get
      Set(ByVal value As Decimal)
         _importeDolares = value
      End Set
   End Property

   Public Property ImportePesos() As Decimal
      Get
         Return _importePesos
      End Get
      Set(ByVal value As Decimal)
         _importePesos = value
      End Set
   End Property

   Public Property ImporteTransfBancaria() As Decimal
      Get
         Return _importeTransfBancaria
      End Get
      Set(ByVal value As Decimal)
         _importeTransfBancaria = value
      End Set
   End Property

   Public Property Conciliado As Boolean 'Para determinar al guardar si queremos que guarde la transferencia conciliada o no. No se persiste en CtaCte. Va directo a LibrosBancos.

   Public Property CuentaBancariaTransfBanc() As Entidades.CuentaBancaria
      Get
         If Me._cuentaBancariaTransfBanc Is Nothing Then
            Me._cuentaBancariaTransfBanc = New Entidades.CuentaBancaria()
         End If
         Return _cuentaBancariaTransfBanc
      End Get
      Set(ByVal value As Entidades.CuentaBancaria)
         _cuentaBancariaTransfBanc = value
      End Set
   End Property

   Private _retenciones As List(Of Entidades.Retencion)
   Public Property Retenciones() As List(Of Entidades.Retencion)
      Get
         If Me._retenciones Is Nothing Then
            Me._retenciones = New List(Of Entidades.Retencion)
         End If
         Return Me._retenciones
      End Get
      Set(ByVal value As List(Of Entidades.Retencion))
         Me._retenciones = value
      End Set
   End Property

   Public Property ImporteRetenciones() As Decimal
      Get
         Return Me._importeRetenciones
      End Get
      Set(ByVal value As Decimal)
         Me._importeRetenciones = value
      End Set
   End Property

   Private _cajaDetalle As Entidades.CajaDetalles
   Public Property CajaDetalle() As Entidades.CajaDetalles
      Get
         If Me._cajaDetalle Is Nothing Then
            Me._cajaDetalle = New Entidades.CajaDetalles()
         End If
         Return _cajaDetalle
      End Get
      Set(ByVal value As Entidades.CajaDetalles)
         _cajaDetalle = value
      End Set
   End Property

   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Public Property Tarjetas() As List(Of Entidades.VentaTarjeta)
      Get
         If Me._tarjetas Is Nothing Then
            Me._tarjetas = New List(Of Entidades.VentaTarjeta)()
         End If
         Return _tarjetas
      End Get
      Set(ByVal value As List(Of Entidades.VentaTarjeta))
         _tarjetas = value
      End Set
   End Property

   Public Property FechaActualizacion() As Date
      Get
         Return Me._FechaActualizacion
      End Get
      Set(ByVal value As Date)
         Me._FechaActualizacion = value
      End Set
   End Property

   Public Property IdClienteCtaCte() As Long
      Get
         Return Me._IdClienteCtaCte
      End Get
      Set(ByVal value As Long)
         Me._IdClienteCtaCte = value
      End Set
   End Property
   Public Property IdCategoria() As Integer
      Get
         Return _IdCategoria
      End Get
      Set(ByVal value As Integer)
         _IdCategoria = value
      End Set
   End Property

   Public Property SaldoCtaCte() As Nullable(Of Decimal)
      Get
         Return Me._saldoCtaCte
      End Get
      Set(ByVal value As Nullable(Of Decimal))
         Me._saldoCtaCte = value
      End Set
   End Property

   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?

   Public Property MetodoGrabacionCampo As Entidad.MetodoGrabacion
   Public Property IdFuncion As String
   Public Property ImprimeSaldos As Boolean

   Public Property NumeroOrdenCompra As Long

   Public Property Referencia As String

   Public Property IdSucursalVinculado As Integer
   Public Property IdTipoComprobanteVinculado As String
   Public Property LetraVinculado As String
   Public Property CentroEmisorVinculado As Short
   Public Property NumeroComprobanteVinculado As Long

   Public Property CotizacionDolar As Decimal

   Public Property FechaTransferencia As Date?

   Public Property FechaExportacion As Date?

   Public Property FechaViaje As Date
   Public Property NombreEstablecimiento As String
   Public Property NombrePrograma As String
   Public Property NumeroReparto() As Integer?
   Public Property CCTransferencias As List(Of Entidades.CuentaCorrienteTransferencia)

   Public Property FechaEnvioCorreo As Date?

   '-- REQ-31710.- ------------------------------
   Public Property IdTipoNovedad As String
   Public Property LetraNovedad As String
   Public Property CentroEmisorNovedad As Short?
   Public Property NumeroNovedad As Long?
   '-- REQ-33373.- ------------------------------
   Public Property IdEmbarcacion As Long
   Public Property NombreEmbarcacion As String
   Public Property NombreCategoriaEmbarcacion As String
   '-- REQ-31947.- ------------------------------
   Public Property FechaCalculoInteresModif As Boolean
   Public Property FechaCalculoInteres As Date?
   '-- REQ-36331.- ------------------------------
   Public Property IdCama As Long
   Public Property CodigoCama As String
   Public Property IdNave As Short
   Public Property NombreNave As String
   Public Property IdCategoriaCama As Integer
   Public Property NombreCategoriaCama As String
   '-- REQ-42455.- ------------------------------
   Public Property FechaPromedioCobro As Date?
   Public Property PromedioDiasCobro As Decimal?
   Public Property CantidadDiasCobro As Decimal?
   '---------------------------------------------

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

#End Region
End Class