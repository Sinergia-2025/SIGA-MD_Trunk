<Serializable()>
Public Class Compra
   Inherits Entidad
   Implements IComprobanteComprasModificable, IPKComprobante

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Fecha
      'TipoDocComprador
      'NroDocComprador
      DescuentoRecargo
      ImporteTotal
      IdCategoriaFiscal
      IdFormasPago
      Observacion
      PorcentajeIVA
      IdRubro
      DescuentoRecargoPorc
      PercepcionIVA
      PercepcionIB
      PercepcionGanancias
      PercepcionVarias
      IdEmpresa
      PeriodoFiscal
      IdEjercicio
      IdPlanCuenta
      IdAsiento
      ImportePesos
      ImporteTarjetas
      ImporteCheques
      ImporteTransfBancaria
      IdCuentaBancaria
      IdEstadoComprobante
      IdTipoComprobanteFact
      LetraFact
      CentroEmisorFact
      NumeroComprobanteFact
      CantidadInvocados
      IdProveedor
      IdProveedorFact
      Usuario
      FechaActualizacion
      CotizacionDolar
      FechaOficializacionDespacho
      IdAduana
      IdDestinacion
      NumeroDespacho
      DigitoVerificadorDespacho
      IdDespachante
      IdAgenteTransporte
      DerechoAduanero
      BienCapitalDespacho
      MetodoGrabacion
      IdFuncion
      NumeroManifiestoDespacho
      Bultos
      ValorDeclarado
      IdTransportista
      NumeroLote

      IVAModificadoManual

      TotalBruto
      TotalNeto
      TotalIVA
      TotalPercepciones

      IdSucursalVenta
      IdTipoComprobanteVenta
      LetraVenta
      CentroEmisorVenta
      NumeroComprobanteVenta

      NombreProveedor
      CUITProveedor

      IdCaja
      NumeroPlanilla
      NumeroMovimiento
      ImpuestosInternos
      ExcluirDePasaje

      '-.PE-31849.-
      MercEnviada
      IdConceptoCM05

      NumeroOrdenCompra
   End Enum

   Public Sub New()
      CuponesTarjetasLiquidacion = New List(Of CompraTarjeta)()
      Retenciones = New List(Of CompraRetencion)()
   End Sub

#Region "Campos"

   Private _tipoComprobante As Entidades.TipoComprobante
   Private _letra As String
   Private _centroEmisor As Short
   Private _numero As Long
   Private _fecha As Date
   Private _comprador As Empleado
   Private _descuentoRecargo As Decimal
   Private _descuentoRecargoPorc As Decimal
   Private _importeTotal As Decimal
   Private _proveedor As Entidades.Proveedor
   Private _comprasProductos As System.Collections.Generic.List(Of Entidades.CompraProducto)
   Private _formaPago As Entidades.VentaFormaPago  'Queda o se hace una aparte?
   Private _observacion As String
   Private _porcentajeIVA As Decimal
   Private _rubro As Entidades.RubroCompra
   Private _chequesPropios As List(Of Entidades.Cheque)
   Private _chequesTerceros As List(Of Entidades.Cheque)
   Private _comprasObservaciones As System.Collections.Generic.List(Of Entidades.CompraObservacion)

#End Region

#Region "Propiedades"
   Public Property IdTipoComprobanteFact As String
   Public Property LetraFact As String
   Public Property CentroEmisorFact As Short
   Public Property NumeroComprobanteFact As Long
   Public Property IdProveedorFact As Long

   Public Property ExcluirDePasaje As Boolean
   Public Property MercEnviada As Boolean

   Public Property Rubro() As Entidades.RubroCompra
      Get
         If Me._rubro Is Nothing Then
            Me._rubro = New Entidades.RubroCompra()
         End If
         Return Me._rubro
      End Get
      Set(ByVal value As Entidades.RubroCompra)
         Me._rubro = value
      End Set
   End Property
   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property
   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         _letra = value
      End Set
   End Property
   Public Property PorcentajeIVA() As Decimal
      Get
         Return Me._porcentajeIVA
      End Get
      Set(ByVal value As Decimal)
         Me._porcentajeIVA = value
      End Set
   End Property
   Public Property Comprador() As Empleado
      Get
         If Me._comprador Is Nothing Then
            Me._comprador = New Empleado()
         End If
         Return Me._comprador
      End Get
      Set(ByVal value As Empleado)
         Me._comprador = value
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
   Public Property FormaPago() As Entidades.VentaFormaPago
      Get
         Return Me._formaPago
      End Get
      Set(ByVal value As Entidades.VentaFormaPago)
         Me._formaPago = value
      End Set
   End Property
   Public Property Proveedor() As Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Entidades.Proveedor()

         End If
         Return Me._proveedor
      End Get
      Set(ByVal value As Entidades.Proveedor)
         Me._proveedor = value
      End Set
   End Property
   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property
   Public Property NumeroComprobante() As Long
      Get
         Return Me._numero
      End Get
      Set(ByVal value As Long)
         Me._numero = value
      End Set
   End Property
   Public Property Fecha() As Date
      Get
         Return Me._fecha
      End Get
      Set(ByVal value As Date)
         Me._fecha = value
      End Set
   End Property

   Public Property DescuentoRecargo() As Decimal
      Get
         Return _descuentoRecargo
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargo = value
      End Set
   End Property
   Public Property DescuentoRecargoPorc() As Decimal
      Get
         Return _descuentoRecargoPorc
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc = value
      End Set
   End Property

   Public Property ImporteTotal() As Decimal
      Get
         Return _importeTotal

      End Get
      Set(ByVal value As Decimal)
         _importeTotal = value
      End Set
   End Property
   Public Property ComprasProductos() As Generic.List(Of Entidades.CompraProducto)
      Get
         If Me._comprasProductos Is Nothing Then
            Me._comprasProductos = New Generic.List(Of Entidades.CompraProducto)
         End If
         Return Me._comprasProductos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.CompraProducto))
         Me._comprasProductos = value
      End Set
   End Property

   Private _comprasImpuestos As List(Of CompraImpuesto)
   Public Property ComprasImpuestos As List(Of CompraImpuesto)
      Get
         If _comprasImpuestos Is Nothing Then _comprasImpuestos = New List(Of CompraImpuesto)()
         Return _comprasImpuestos
      End Get
      Set(value As List(Of CompraImpuesto))
         _comprasImpuestos = value
      End Set
   End Property

   Public Property IVAModificadoManual As Boolean

   Private _percepcionIVA As Decimal
   Public Property PercepcionIVA() As Decimal
      Get
         Return _percepcionIVA
      End Get
      Set(ByVal value As Decimal)
         _percepcionIVA = value
      End Set
   End Property

   Private _percepcionIB As Decimal
   Public Property PercepcionIB() As Decimal
      Get
         Return _percepcionIB
      End Get
      Set(ByVal value As Decimal)
         _percepcionIB = value
      End Set
   End Property

   Private _percepcionGanancias As Decimal
   Public Property PercepcionGanancias() As Decimal
      Get
         Return _percepcionGanancias
      End Get
      Set(ByVal value As Decimal)
         _percepcionGanancias = value
      End Set
   End Property

   Private _percepcionVarias As Decimal
   Public Property PercepcionVarias() As Decimal
      Get
         Return _percepcionVarias
      End Get
      Set(ByVal value As Decimal)
         _percepcionVarias = value
      End Set
   End Property

   Public Property PeriodoFiscal As Integer
   Public Property IdEmpresa As Integer

   Private _cuentaCorrienteProv As Entidades.CuentaCorrienteProv
   Public Property CuentaCorrienteProv() As Entidades.CuentaCorrienteProv
      Get
         If Me._cuentaCorrienteProv Is Nothing Then
            Me._cuentaCorrienteProv = New Entidades.CuentaCorrienteProv()
         End If
         Return _cuentaCorrienteProv
      End Get
      Set(ByVal value As Entidades.CuentaCorrienteProv)
         _cuentaCorrienteProv = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return _idCaja
      End Get
      Set(ByVal value As Integer)
         _idCaja = value
      End Set
   End Property


   Private _importeTarjetas As Decimal
   Public Property ImporteTarjetas() As Decimal
      Get
         Return _importeTarjetas
      End Get
      Set(ByVal value As Decimal)
         _importeTarjetas = value
      End Set
   End Property

   Private _importePesos As Decimal
   Public Property ImportePesos() As Decimal
      Get
         Return _importePesos
      End Get
      Set(ByVal value As Decimal)
         _importePesos = value
      End Set
   End Property

   Public ReadOnly Property ImporteChequesTerceros As Decimal
      Get
         Dim total As Decimal = 0
         For Each cheq As Entidades.Cheque In Me.ChequesTerceros
            total += cheq.Importe
         Next
         Return total
      End Get
   End Property

   Public ReadOnly Property ImporteChequesPropios As Decimal
      Get
         Dim total As Decimal = 0
         For Each cheq As Entidades.Cheque In Me.ChequesPropios
            total += cheq.Importe
         Next
         Return total
      End Get
   End Property

   Public ReadOnly Property ImporteCheques As Decimal
      Get
         Return Me.ImporteChequesPropios + Me.ImporteChequesTerceros
      End Get
   End Property

   Private _importeTransfBancaria As Decimal = 0
   Public Property ImporteTransfBancaria() As Decimal
      Get
         Return _importeTransfBancaria
      End Get
      Set(ByVal value As Decimal)
         _importeTransfBancaria = value
      End Set
   End Property

   Private _cuentaBancariaTransfBanc As Entidades.CuentaBancaria
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

   Public Property Conciliado As Boolean

   Public ReadOnly Property ImporteACtaCte() As Decimal
      Get
         Return Me.ImporteTotal - (Me.ImportePesos + Me.ImporteTarjetas + Me.ImporteCheques + Me.ImporteTransfBancaria)
      End Get
   End Property

   Public Property ChequesPropios() As List(Of Entidades.Cheque)
      Get
         If Me._chequesPropios Is Nothing Then
            Me._chequesPropios = New List(Of Entidades.Cheque)
         End If
         Return _chequesPropios
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         _chequesPropios = value
      End Set
   End Property

   Public Property ChequesTerceros() As List(Of Entidades.Cheque)
      Get
         If Me._chequesTerceros Is Nothing Then
            Me._chequesTerceros = New List(Of Entidades.Cheque)
         End If
         Return _chequesTerceros
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         _chequesTerceros = value
      End Set
   End Property

   Public ReadOnly Property TipoComprobanteDescripcion() As String
      Get
         Return Me.TipoComprobante.Descripcion
      End Get
   End Property

   Private _facturables As System.Collections.Generic.List(Of Entidades.Compra)
   Public Property Facturables() As Generic.List(Of Entidades.Compra)
      Get
         If Me._facturables Is Nothing Then
            Me._facturables = New Generic.List(Of Entidades.Compra)
         End If
         Return Me._facturables
      End Get
      Set(ByVal value As Generic.List(Of Entidades.Compra))
         Me._facturables = value
      End Set
   End Property

   Private _idEstadoComprobante As String = String.Empty
   Public Property IdEstadoComprobante() As String
      Get
         Return Me._idEstadoComprobante
      End Get
      Set(ByVal value As String)
         Me._idEstadoComprobante = value
      End Set
   End Property

   Private _cantidadInvocados As Integer
   Public Property CantidadInvocados() As Integer
      Get
         Return Me._cantidadInvocados
      End Get
      Set(ByVal value As Integer)
         Me._cantidadInvocados = value
      End Set
   End Property

   Public Property ComprasObservaciones() As Generic.List(Of Entidades.CompraObservacion)
      Get
         If Me._comprasObservaciones Is Nothing Then
            Me._comprasObservaciones = New Generic.List(Of Entidades.CompraObservacion)
         End If
         Return Me._comprasObservaciones
      End Get
      Set(ByVal value As Generic.List(Of Entidades.CompraObservacion))
         Me._comprasObservaciones = value
      End Set
   End Property

   Private _fechaActualizacion As Date
   Public Property FechaActualizacion() As Date
      Get
         Return Me._fechaActualizacion
      End Get
      Set(ByVal value As Date)
         Me._fechaActualizacion = value
      End Set
   End Property

   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?


   Private _cotizacionDolar As Decimal
   Public Property CotizacionDolar() As Decimal
      Get
         Return Me._cotizacionDolar
      End Get
      Set(ByVal value As Decimal)
         Me._cotizacionDolar = value
      End Set
   End Property

   Public Property ConceptoCM05 As Entidades.AFIPConceptoCM05


   Public Property FechaOficializacionDespacho As DateTime?
   Public Property IdAduana As Integer
   Public Property IdDestinacion As String
   Public Property NumeroDespacho As Long
   Public Property DigitoVerificadorDespacho As String
   Public Property NumeroManifiestoDespacho As String
   Public Property IdDespachante As Integer
   Public Property IdAgenteTransporte As Integer
   Public Property DerechoAduanero As Decimal
   Public Property BienCapitalDespacho As Boolean

   Public Property Bultos As Integer
   Public Property ValorDeclarado As Decimal
   Public Property Transportista As Transportista
   Public Property NumeroLote As Long

   Public Property MetodoGrabacionCampo As MetodoGrabacion
   Public Property IdFuncion As String

   Public Property NumeroOrdenCompra As Long

   Public Property TotalBruto As Decimal
   Public Property TotalNeto As Decimal
   Public Property TotalIVA As Decimal
   Public Property TotalPercepciones As Decimal

   Public Property IdSucursalVenta As Integer
   Public Property IdTipoComprobanteVenta As String
   Public Property LetraVenta As String
   Public Property CentroEmisorVenta As Short
   Public Property NumeroComprobanteVenta As Long
   Public Property CuitProveedor As String
   Public Property NombreProveedor As String
   Public Property IdcategoriaFiscal As Integer
   Public Property NumeroPlanilla() As Integer
   Public Property NumeroMovimiento() As Integer
   Public Property ImpuestosInternos() As Decimal
   ' Public Property NumeroOrdenCompra As Long
   Public Property Transferencias As List(Of CompraTransferencia)
   Public Property CuponesTarjetasLiquidacion As List(Of CompraTarjeta)
   Public Property Retenciones As List(Of CompraRetencion)

#Region "Propiedades ReadOnly"
   Public ReadOnly Property DescripcionFormasPago As String
      Get
         If FormaPago Is Nothing Then Return ""
         Return FormaPago.DescripcionFormasPago
      End Get
   End Property

   Public ReadOnly Property IdTransportista As Long
      Get
         If Transportista Is Nothing Then Return 0
         Return Transportista.idTransportista
      End Get
   End Property

   'Public ReadOnly Property NombreProveedor As String
   '   Get
   '      If Proveedor Is Nothing Then Return ""
   '      Return Proveedor.NombreProveedor
   '   End Get
   'End Property

   Public ReadOnly Property IdConceptoCM05 As Integer?
      Get
         If ConceptoCM05 Is Nothing Then Return Nothing
         Return ConceptoCM05.IdConceptoCM05
      End Get
   End Property

#End Region
#Region "Propiedades para Renumerar (IComprobanteComprasModificable)"
   'Solo se usan para el método Renumerar
   Private Property IdSucursalNuevo As Integer Implements IComprobanteComprasModificable.IdSucursalNuevo
   Private Property IdTipoComprobanteNuevo As String Implements IComprobanteComprasModificable.IdTipoComprobanteNuevo
   Private Property LetraNuevo As String Implements IComprobanteComprasModificable.LetraNuevo
   Private Property CentroEmisorNuevo As Short Implements IComprobanteComprasModificable.CentroEmisorNuevo
   Private Property NumeroComprobanteNuevo As Long Implements IComprobanteComprasModificable.NumeroComprobanteNuevo
   Private Property IdProveedorNuevo As Long Implements IComprobanteComprasModificable.IdProveedorNuevo

   Private ReadOnly Property DebeRenumerar As Boolean Implements IComprobanteComprasModificable.DebeRenumerar
      Get
         Return (CentroEmisorNuevo <> 0 And CentroEmisor <> CentroEmisorNuevo) Or
                (NumeroComprobanteNuevo <> 0 And NumeroComprobante <> NumeroComprobanteNuevo)
      End Get
   End Property

   Private Sub LimpiaModificable() Implements IComprobanteComprasModificable.LimpiaModificable
      IdSucursalNuevo = 0
      IdTipoComprobanteNuevo = String.Empty
      LetraNuevo = String.Empty
      CentroEmisorNuevo = 0
      NumeroComprobanteNuevo = 0
      IdProveedorNuevo = 0
   End Sub
#End Region

#End Region


#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return If(TipoComprobante IsNot Nothing, TipoComprobante.IdTipoComprobante, String.Empty)
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_IdSucursal As Integer Implements IPKComprobante.IdSucursal
      Get
         Return IdSucursal
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_IdTipoComprobante As String Implements IPKComprobante.IdTipoComprobante
      Get
         Return IdTipoComprobante
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_Letra As String Implements IPKComprobante.Letra
      Get
         Return Letra
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_CentroEmisor As Integer Implements IPKComprobante.CentroEmisor
      Get
         Return CentroEmisor
      End Get
   End Property

   Private ReadOnly Property IPKComprobante_NumeroComprobante As Long Implements IPKComprobante.NumeroComprobante
      Get
         Return NumeroComprobante
      End Get
   End Property
#End Region

End Class