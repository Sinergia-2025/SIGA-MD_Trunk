<Serializable(), DebuggerDisplay("{DebuggerDisplayForClass,nq}")>
Public Class Venta
   Inherits Entidad
   Implements IPKComprobante

   Public Const NombreTabla As String = "Ventas"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Fecha
      IdVendedor
      idCaja
      SubTotal
      DescuentoRecargo
      ImporteTotal
      IdCategoriaFiscal
      IdFormasPago
      Observacion
      ImporteBruto
      DescuentoRecargoPorc
      IdEstadoComprobante
      IdTipoComprobanteFact
      <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", True)> LetraFact
      <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", True)> CentroEmisorFact
      <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", True)> NumeroComprobanteFact
      NumeroPlanilla
      NumeroMovimiento
      ImportePesos
      ImporteTickets
      ImporteTarjetas
      ImporteCheques
      Kilos
      Bultos
      ValorDeclarado
      IdTransportista
      NumeroLote
      TotalImpuestos
      CantidadInvocados
      CantidadLotes
      Usuario
      FechaAlta
      CAE
      CAEVencimiento
      Utilidad
      FechaTransmisionAFIP
      CotizacionDolar
      ComisionVendedor
      FechaImpresion
      IdEjercicio
      IdPlanCuenta
      IdAsiento
      MercDespachada
      ImporteTransfBancaria
      IdCuentaBancaria
      IdActividad
      IdProvincia
      FechaEnvio
      NumeroReparto
      FechaRendicion
      IdCliente
      IdProveedor
      FechaActualizacion
      Direccion
      IdLocalidad
      IdCategoria
      CodigoErrorAfip
      TotalImpuestoInterno
      MetodoGrabacion
      IdFuncion
      SaldoActualCtaCte
      SaldoActualCtaCteUnificado
      NumeroOrdenCompra
      IdCobrador
      IdMoneda
      IdClienteVinculado
      FechaEnvioCorreo
      NombreCliente
      Cuit
      TipoDocCliente
      NroDocCliente
      FechaTransferencia
      Palets
      Cbu
      CbuAlias
      NroVersionAplicacion
      ReferenciaComercial
      AnulacionFCE
      EsCtaOrden
      DescuentoRecargoPorcManual
      FechaExportacion
      IdPaciente
      IdDoctor
      FechaCirugia
      IdAFIPReferenciaTransferencia

      '-- REQ-31198.- --------------
      IdIcotermExportacion
      IdDestinoExportacion
      '-----------------------------
      FechaPagoExportacion

      '-- REQ-33373.- --------------
      IdEmbarcacion
      CodigoEmbarcacion
      NombreEmbarcacion
      IdCategoriaEmbarcacion
      NombreCategoriaEmbarcacion
      '-- REQ-33532.- --------------
      IdTransportistaTransporte
      IdChoferTransporte
      PatenteVehiculoTransporte
      '-----------------------------
      NombreTransportistaTransporte
      IdConceptoCM05
      '-- REQ-34676.- --------------
      NroFacturaProveedor
      NroRemitoProveedor
      '-----------------------------
      IdTipoComprobanteInvocacionMasiva
      NroRepartoInvocacionMasiva
      '-- REQ-36331.- --------------
      IdCama
      CodigoCama
      IdNave
      NombreNave
      IdCategoriaCama
      NombreCategoriaCama
      '-- REQ-36331.- --------------
      FechaVencimiento
      ImporteCuota
      FechaVencimiento2
      ImporteVencimiento2
      FechaVencimiento3
      ImporteVencimiento3
      CodigoDeBarra
      CodigoDeBarraSirplus
      '-----------------------------
      IdDomicilio
   End Enum

   Public Enum SumaXAgrupamiento
      RUBRO
      LISTA
      ZONA
   End Enum

   Public Enum TipoUtilidad
      MARCA
      RUBRO
      PRODUCTO
      CLIENTE
      LISTAPRECIOS
   End Enum

   Public Sub New()
      Invocados = New VentasInvocadasCollection(Me)
      Invocadores = New VentasInvocadasCollection(Me)
      SeleccionoInvocados = Publicos.SiNoTodos.NO
   End Sub

#Region "Campos"

   Private _tipoComprobante As Entidades.TipoComprobante
   Private _letraComprobante As String = String.Empty
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _fecha As Date
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _vendedor As Empleado
   Private _caja As CajaNombre
   Private _importeBruto As Decimal
   Private _descuentoRecargo As Decimal
   Private _descuentoRecargoPorc As Decimal
   Private _subtotal As Decimal
   Private _importeTotal As Decimal
   Private _cliente As Entidades.Cliente
   Private _ventasProductos As System.Collections.Generic.List(Of Entidades.VentaProducto)
   Private _impresora As Entidades.Impresora
   Private _formaPago As Entidades.VentaFormaPago
   Private _periodo As Entidades.VentaPeriodo
   Private _observacion As String
   Private _facturables As System.Collections.Generic.List(Of Entidades.Venta)
   Private _idEstadoComprobante As String = String.Empty
   Private _tipoComprobanteFact As Entidades.TipoComprobante
   <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", False)> Private _letraFact As String = String.Empty
   <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", False)> Private _centroEmisorFact As Integer
   <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", False)> Private _numeroComprobanteFact As Long
   Private _NumeroPlanilla As Integer
   Private _NumeroMovimiento As Integer
   Private _kilos As Decimal
   Private _comisionVendedor As Decimal
   Private _bultos As Integer
   Private _valorDeclarado As Decimal
   Private _transportista As Entidades.Transportista
   Private _vehiculoTransporte As Entidades.Vehiculo
   Private _numeroLote As Long
   Private _ventasObservaciones As System.Collections.Generic.List(Of Entidades.VentaObservacion)
   Private _chequesRechazados As List(Of Entidades.Cheque)
   Private _totalImpuestos As Decimal
   'Private _cantidadInvocados As Integer
   Private _cantidadLotes As Integer
   Private _ventasProductosLotes As System.Collections.Generic.List(Of Entidades.VentaProductoLote)
   'vml 22/09/12
   Private _tablaContabilidad As DataTable
   Private _importeTransfBancaria As Decimal = 0
   Private _cuentaBancariaTransfBanc As Entidades.CuentaBancaria
   Private _percepciones As List(Of Entidades.PercepcionVenta)
   Private _proveedor As Entidades.Proveedor
   'Private _idDireccion As Integer
   Private _direccion As String
   'Private _localidadCliente As String
   'Private _ProvinciaCliente As String
   Private _idLocalidad As Integer
   Private _localidad As Entidades.Localidad
   Private _idCategoria As Integer
   Private _usuario As Entidades.Usuario

#End Region

#Region "Propiedades"

   Public Property FechaVencimiento As Date?
   Public Property ImporteCuota As Decimal?
   Public Property FechaVencimiento2 As Date?
   Public Property ImporteVencimiento2 As Decimal?
   Public Property FechaVencimiento3 As Date?
   Public Property ImporteVencimiento3 As Decimal?
   Public Property CodigoDeBarra As String
   Public Property CodigoDeBarraSirplus As String

   Public Property IdDomicilio As Integer?
   Public Property IdPaciente As Long?
   Public Property IdDoctor As Long?
   Public Property FechaCirugia As Date?
   Public Property FechaExportacion As Date?
   Public Property DescuentoRecargoPorcManual As Boolean
   Public Property EsCtaOrden() As Boolean

   Public ReadOnly Property ImporteTarjetas() As Decimal
      Get
         Dim val As Decimal = 0
         For Each ch As Entidades.VentaTarjeta In Me.Tarjetas
            val += ch.Monto
         Next
         Return val
      End Get
   End Property

   Private _importeTickets As Decimal
   Public Property ImporteTickets() As Decimal
      Get
         Return _importeTickets
      End Get
      Set(ByVal value As Decimal)
         _importeTickets = value
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
   Public Property ImporteDolares As Decimal

   Private _embarques As List(Of Entidades.VentaExportacionEmbarques)
   Public Property ExportacionEmbarques() As List(Of Entidades.VentaExportacionEmbarques)
      Get
         If Me._embarques Is Nothing Then
            Me._embarques = New List(Of Entidades.VentaExportacionEmbarques)()
         End If
         Return _embarques
      End Get
      Set(ByVal value As List(Of Entidades.VentaExportacionEmbarques))
         _embarques = value
      End Set
   End Property

   Private _cheques As List(Of Entidades.Cheque)
   Public Property Cheques() As List(Of Entidades.Cheque)
      Get
         If Me._cheques Is Nothing Then
            Me._cheques = New List(Of Entidades.Cheque)()
         End If
         Return _cheques
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         _cheques = value
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

   Private _cuentaCorriente As Entidades.CuentaCorriente
   Public Property CuentaCorriente() As Entidades.CuentaCorriente
      Get
         If Me._cuentaCorriente Is Nothing Then
            Me._cuentaCorriente = New Entidades.CuentaCorriente()
         End If
         Return _cuentaCorriente
      End Get
      Set(ByVal value As Entidades.CuentaCorriente)
         _cuentaCorriente = value
      End Set
   End Property

   Public Property LetraComprobante() As String
      Get
         'Si no fue seteado de la venta, tomo el del Cliente
         If String.IsNullOrEmpty(Me._letraComprobante) Then
            Me._letraComprobante = Me.Cliente.CategoriaFiscal.LetraFiscal
         End If
         Return Me._letraComprobante
      End Get
      Set(ByVal value As String)
         Me._letraComprobante = value
      End Set
   End Property

   'INVMUL:
   <Obsolete("INVMUL: Se debe reemplazar por Invocados", True)>
   Public Property Facturables() As Generic.List(Of Entidades.Venta)
      Get
         If Me._facturables Is Nothing Then
            Me._facturables = New Generic.List(Of Entidades.Venta)
         End If
         Return Me._facturables
      End Get
      Set(ByVal value As Generic.List(Of Entidades.Venta))
         Me._facturables = value
      End Set
   End Property

   Public Property Invocadores As VentasInvocadasCollection
   Public Property Invocados As VentasInvocadasCollection

   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If Me._categoriaFiscal Is Nothing Then
            Me._categoriaFiscal = Me.Cliente.CategoriaFiscal
         End If
         Return Me._categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         Me._categoriaFiscal = value
      End Set
   End Property

   Public Property Vendedor() As Empleado
      Get
         Return Me._vendedor
      End Get
      Set(ByVal value As Empleado)
         Me._vendedor = value
      End Set
   End Property
   Public Property Caja() As CajaNombre
      Get
         Return Me._caja
      End Get
      Set(ByVal value As CajaNombre)
         Me._caja = value
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

   Public ReadOnly Property DescripcionFormaPago() As String
      Get
         If Me._formaPago IsNot Nothing Then
            Return Me._formaPago.DescripcionFormasPago
         Else
            Return String.Empty
         End If
      End Get
   End Property

   Public Property Periodo() As Entidades.VentaPeriodo
      Get
         If Me._periodo Is Nothing Then
            Me._periodo = New Entidades.VentaPeriodo()
         End If
         Return Me._periodo
      End Get
      Set(ByVal value As Entidades.VentaPeriodo)
         Me._periodo = value
      End Set
   End Property

   Public Property Impresora() As Entidades.Impresora
      Get
         If Me._impresora Is Nothing Then
            Me._impresora = New Entidades.Impresora()
         End If
         Return _impresora
      End Get
      Set(ByVal value As Entidades.Impresora)
         _impresora = value
      End Set
   End Property

   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Entidades.Cliente()
         End If
         Return Me._cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         Me._cliente = value
      End Set
   End Property

   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
      Get
         Return Me._centroEmisor
      End Get
      Set(ByVal value As Short)
         Me._centroEmisor = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
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

   Public Property ImporteBruto() As Decimal
      Get
         Return _importeBruto
      End Get
      Set(ByVal value As Decimal)
         _importeBruto = value
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

   Public Property Subtotal() As Decimal
      Get
         Return _subtotal
      End Get
      Set(ByVal value As Decimal)
         _subtotal = value
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

   Public Property VentasProductos() As Generic.List(Of Entidades.VentaProducto)
      Get
         If Me._ventasProductos Is Nothing Then
            Me._ventasProductos = New Generic.List(Of Entidades.VentaProducto)
         End If
         Return Me._ventasProductos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.VentaProducto))
         Me._ventasProductos = value
      End Set
   End Property

   Private _ventasImpuestos As List(Of Entidades.VentaImpuesto)
   Public Property VentasImpuestos() As List(Of Entidades.VentaImpuesto)
      Get
         If Me._ventasImpuestos Is Nothing Then
            Me._ventasImpuestos = New List(Of Entidades.VentaImpuesto)()
         End If
         Return _ventasImpuestos
      End Get
      Set(ByVal value As List(Of Entidades.VentaImpuesto))
         _ventasImpuestos = value
      End Set
   End Property

   Private _impuestosVarios As List(Of Entidades.VentaImpuesto)
   Public Property ImpuestosVarios() As List(Of Entidades.VentaImpuesto)
      Get
         If Me._impuestosVarios Is Nothing Then
            Me._impuestosVarios = New List(Of Entidades.VentaImpuesto)()
         End If
         Return Me._impuestosVarios
      End Get
      Set(ByVal value As List(Of Entidades.VentaImpuesto))
         Me._impuestosVarios = value
      End Set
   End Property

   'Public ReadOnly Property TotalImpuestos() As Decimal
   '   Get
   '      Dim val As Decimal = 0
   '      For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
   '         val += vi.Importe
   '      Next
   '      Return val
   '   End Get
   'End Property

   Public Property IdEstadoComprobante() As String
      Get
         Return Me._idEstadoComprobante
      End Get
      Set(ByVal value As String)
         Me._idEstadoComprobante = value
      End Set
   End Property

   Public Property TipoComprobanteFact() As Entidades.TipoComprobante
      Get
         Return _tipoComprobanteFact
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobanteFact = value
      End Set
   End Property

   <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", True)>
   Public Property LetraFact() As String
      Get
         Return Me._letraFact
      End Get
      Set(ByVal value As String)
         Me._letraFact = value
      End Set
   End Property

   <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", True)>
   Public Property CentroEmisorFact() As Integer
      Get
         Return Me._centroEmisorFact
      End Get
      Set(ByVal value As Integer)
         Me._centroEmisorFact = value
      End Set
   End Property

   <Obsolete("INVMUL: La información de invocado por sale de la colección de Invocadores", True)>
   Public Property NumeroComprobanteFact() As Long
      Get
         Return Me._numeroComprobanteFact
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobanteFact = value
      End Set
   End Property

   Public Property NumeroPlanilla() As Integer
      Get
         Return _NumeroPlanilla
      End Get
      Set(ByVal value As Integer)
         _NumeroPlanilla = value
      End Set
   End Property

   Public Property NumeroMovimiento() As Integer
      Get
         Return _NumeroMovimiento
      End Get
      Set(ByVal value As Integer)
         _NumeroMovimiento = value
      End Set
   End Property

   Public Property Kilos() As Decimal
      Get
         Return _kilos
      End Get
      Set(ByVal value As Decimal)
         _kilos = value
      End Set
   End Property

   Public Property ComisionVendedor() As Decimal
      Get
         Return Me._comisionVendedor
      End Get
      Set(ByVal value As Decimal)
         Me._comisionVendedor = value
      End Set
   End Property

   Public Property Bultos() As Integer
      Get
         Return _bultos
      End Get
      Set(ByVal value As Integer)
         _bultos = value
      End Set
   End Property

   Public Property ValorDeclarado() As Decimal
      Get
         Return _valorDeclarado
      End Get
      Set(ByVal value As Decimal)
         _valorDeclarado = value
      End Set
   End Property

   Public Property Transportista() As Entidades.Transportista
      Get
         If Me._transportista Is Nothing Then
            Me._transportista = New Entidades.Transportista()
         End If
         Return Me._transportista
      End Get
      Set(ByVal value As Entidades.Transportista)
         Me._transportista = value
      End Set
   End Property
   Public Property VehiculoTransporte() As Entidades.Vehiculo
      Get
         If Me._vehiculoTransporte Is Nothing Then
            Me._vehiculoTransporte = New Entidades.Vehiculo()
         End If
         Return Me._vehiculoTransporte
      End Get
      Set(ByVal value As Entidades.Vehiculo)
         Me._vehiculoTransporte = value
      End Set
   End Property

   Public Property NumeroLote() As Long
      Get
         Return Me._numeroLote
      End Get
      Set(ByVal value As Long)
         Me._numeroLote = value
      End Set
   End Property

   Public Property VentasObservaciones() As Generic.List(Of Entidades.VentaObservacion)
      Get
         If Me._ventasObservaciones Is Nothing Then
            Me._ventasObservaciones = New Generic.List(Of Entidades.VentaObservacion)
         End If
         Return Me._ventasObservaciones
      End Get
      Set(ByVal value As Generic.List(Of Entidades.VentaObservacion))
         Me._ventasObservaciones = value
      End Set
   End Property

   Public Property ChequesRechazados() As List(Of Entidades.Cheque)
      Get
         If Me._chequesRechazados Is Nothing Then
            Me._chequesRechazados = New List(Of Entidades.Cheque)
         End If
         Return _chequesRechazados
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         Me._chequesRechazados = value
      End Set
   End Property

   Public Property TotalImpuestos() As Decimal
      Get
         Return Me._totalImpuestos
      End Get
      Set(ByVal value As Decimal)
         Me._totalImpuestos = value
      End Set
   End Property

   'Public Property CantidadInvocados() As Integer
   '   Get
   '      Return Me._cantidadInvocados
   '   End Get
   '   Set(ByVal value As Integer)
   '      Me._cantidadInvocados = value
   '   End Set
   'End Property

   Public ReadOnly Property CantidadInvocados() As Integer
      Get
         Return Invocados.Count
      End Get
   End Property
   Public ReadOnly Property CantidadInvocadores() As Integer
      Get
         Return Invocadores.Count
      End Get
   End Property

   Public Property CantidadLotes() As Integer
      Get
         Return Me._cantidadLotes
      End Get
      Set(ByVal value As Integer)
         Me._cantidadLotes = value
      End Set
   End Property

   Public Property VentasProductosLotes() As Generic.List(Of Entidades.VentaProductoLote)
      Get
         If Me._ventasProductosLotes Is Nothing Then
            Me._ventasProductosLotes = New Generic.List(Of Entidades.VentaProductoLote)
         End If
         Return Me._ventasProductosLotes
      End Get
      Set(ByVal value As Generic.List(Of Entidades.VentaProductoLote))
         Me._ventasProductosLotes = value
      End Set
   End Property

   Private _afipCAE As Entidades.AFIPCAE
   Public Property AFIPCAE() As Entidades.AFIPCAE
      Get
         If _afipCAE Is Nothing Then
            Me._afipCAE = New Entidades.AFIPCAE()
         End If
         Return _afipCAE
      End Get
      Set(ByVal value As Entidades.AFIPCAE)
         _afipCAE = value
      End Set
   End Property

   Private _afipIdTipoComprobante As Integer
   Public Property AFIPIdTipoComprobante() As Integer
      Get
         Return _afipIdTipoComprobante
      End Get
      Set(ByVal value As Integer)
         _afipIdTipoComprobante = value
      End Set
   End Property

   Private _utilidad As Decimal
   Public Property Utilidad() As Decimal
      Get
         Return Me._utilidad
      End Get
      Set(ByVal value As Decimal)
         Me._utilidad = value
      End Set
   End Property

   Private _fechaTransmisionAFIP As Date
   Public Property FechaTransmisionAFIP() As Date
      Get
         Return Me._fechaTransmisionAFIP
      End Get
      Set(ByVal value As Date)
         Me._fechaTransmisionAFIP = value
      End Set
   End Property

   Private _cotizacionDolar As Decimal
   Public Property CotizacionDolar() As Decimal
      Get
         Return Me._cotizacionDolar
      End Get
      Set(ByVal value As Decimal)
         Me._cotizacionDolar = value
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

   Private _mercDespachada As Boolean
   Public Property MercDespachada() As Boolean
      Get
         Return Me._mercDespachada
      End Get
      Set(ByVal value As Boolean)
         Me._mercDespachada = value
      End Set
   End Property

   Public Property tablaContabilidad() As DataTable
      Get
         Return _tablaContabilidad
      End Get
      Set(ByVal value As DataTable)
         _tablaContabilidad = value
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

   Private _idActividad As Integer
   Public Property IdActividad() As Integer
      Get
         Return _idActividad
      End Get
      Set(ByVal value As Integer)
         _idActividad = value
      End Set
   End Property

   Private _idProvincia As String
   Public Property IdProvincia() As String
      Get
         Return Me._idProvincia
      End Get
      Set(ByVal value As String)
         Me._idProvincia = value
      End Set
   End Property

   Public Property Percepciones() As List(Of Entidades.PercepcionVenta)
      Get
         If Me._percepciones Is Nothing Then
            Me._percepciones = New List(Of Entidades.PercepcionVenta)()
         End If
         Return _percepciones
      End Get
      Set(ByVal value As List(Of Entidades.PercepcionVenta))
         _percepciones = value
      End Set
   End Property

   Private _reemplazaComprobante As Boolean
   Public Property ReemplazaComprobante() As Boolean
      Get
         Return Me._reemplazaComprobante
      End Get
      Set(ByVal value As Boolean)
         Me._reemplazaComprobante = value
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

   Public Property SaldoActualCtaCte As Decimal?
   Public Property SaldoActualCtaCteUnificado As Decimal?

   '**** PARA EL LIVE ***

   Private _fechaEnvio As Date
   Public Property FechaEnvio() As Date
      Get
         Return Me._fechaEnvio
      End Get
      Set(ByVal value As Date)
         Me._fechaEnvio = value
      End Set
   End Property

   Private _numeroReparto As Integer
   Public Property NumeroReparto() As Integer
      Get
         Return _numeroReparto
      End Get
      Set(ByVal value As Integer)
         _numeroReparto = value
      End Set
   End Property

   Private _fechaRendicion As Date
   Public Property FechaRendicion() As Date
      Get
         Return Me._fechaRendicion
      End Get
      Set(ByVal value As Date)
         Me._fechaRendicion = value
      End Set
   End Property
   '**********************

   Private _fechaActualizacion As Date
   Public Property FechaActualizacion() As Date
      Get
         Return Me._fechaActualizacion
      End Get
      Set(ByVal value As Date)
         Me._fechaActualizacion = value
      End Set
   End Property

   Public Property Direccion() As String
      Get
         Return Me._direccion
      End Get
      Set(ByVal value As String)
         Me._direccion = value
      End Set
   End Property

   'TODO: Hacer este campo de solo lectura, tendria que obtenerlo del objeto Localidad
   Public Property IdLocalidad() As Integer
      Get
         Return Me._idLocalidad
      End Get
      Set(ByVal value As Integer)
         Me._idLocalidad = value
      End Set
   End Property

   'Public Property LocalidadCliente() As String
   '   Get
   '      Return Me._localidadCliente
   '   End Get
   '   Set(ByVal value As String)
   '      Me._localidadCliente = value
   '   End Set
   'End Property
   'Public Property ProvinciaCliente() As String
   '   Get
   '      Return Me._ProvinciaCliente
   '   End Get
   '   Set(ByVal value As String)
   '      Me._ProvinciaCliente = value
   '   End Set
   'End Property

   Public Property Localidad() As Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Entidades.Localidad()
         End If
         Return Me._localidad
      End Get
      Set(ByVal value As Entidades.Localidad)
         Me._localidad = value
      End Set
   End Property

   Public Property IdCategoria() As Integer
      Get
         Return _idCategoria
      End Get
      Set(ByVal value As Integer)
         _idCategoria = value
      End Set
   End Property

   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?

   Private Property _codigoErrorAfip As String = String.Empty
   Public Property CodigoErrorAfip As String
      Set(value As String)
         Me._codigoErrorAfip = value
      End Set
      Get
         Return Me._codigoErrorAfip
      End Get
   End Property

   'Este valor es calculado en el GetUna. No se guarda en BD.
   Public Property CantidadProductos As Integer

   Private _ventasContactos As List(Of VentaClienteContacto)
   Public Property VentasContactos() As List(Of VentaClienteContacto)
      Get
         If _ventasContactos Is Nothing Then _ventasContactos = New List(Of VentaClienteContacto)()
         Return _ventasContactos
      End Get
      Set(ByVal value As List(Of VentaClienteContacto))
         _ventasContactos = value
      End Set
   End Property

   Public Property NumeroOrdenCompra As Long

   '-- REG-33373.- --------------------------------------------
   Public Property IdEmbarcacion As Long
   Public Property CodigoEmbarcacion As Long
   Public Property NombreEmbarcacion As String
   Public Property IdCategoriaEmbarcacion As Integer
   Public Property NombreCategoriaEmbarcacion As String
   '-- REG-36331.- --------------------------------------------
   Public Property IdCama As Long
   Public Property CodigoCama As String
   Public Property IdNave As Short
   Public Property NombreNave As String
   Public Property IdCategoriaCama As Integer
   Public Property NombreCategoriaCama As String

   '-- REQ-33532.- --------------------------------------
   Public Property IdTransportistaTransporte As Integer
   Public Property IdChoferTransporte As Integer

   '-- REG-34676.- --------------------------------------------
   Public Property NroFacturaProveedor As String
   Public Property NroRemitoProveedor As String

   Public Property IdTipoComprobanteInvocacionMasiva As String
   Public Property NroRepartoInvocacionMasiva As Integer
   '-----------------------------------------------------
   Public Property NombreTransportistaTransporte As String      '# No se graba en BD


   'Para persistir en fichas los adjuntos agregados/eliminados
   Public Property VentasAdjuntos As ListConBorrados(Of VentaAdjunto)
   Public Property Transferencias As List(Of VentaTransferencia)

   Public Property Cobrador As Entidades.Empleado

   Public Property IdMoneda As Integer = 1

   Public Property ClienteVinculado As Entidades.Cliente

   Public Property FechaEnvioCorreo As Date?

   Private _turnosInvocados As List(Of TurnoCalendario)
   Public Property TurnosInvocados() As List(Of TurnoCalendario)
      Get
         If _turnosInvocados Is Nothing Then _turnosInvocados = New List(Of TurnoCalendario)()
         Return _turnosInvocados
      End Get
      Set(ByVal value As List(Of TurnoCalendario))
         _turnosInvocados = value
      End Set
   End Property

   Private _crmInvocados As List(Of CRMNovedad)

   Public Property CrmInvocados() As List(Of CRMNovedad)
      Get
         If _crmInvocados Is Nothing Then _crmInvocados = New List(Of CRMNovedad)()
         Return _crmInvocados
      End Get
      Set(ByVal value As List(Of CRMNovedad))
         _crmInvocados = value
      End Set
   End Property

   Public Property Cuit As String
   Public Property TipoDocCliente As String
   Public Property NroDocCliente As Long
   Public Property NombreCliente As String
   Public Property FechaTransferencia As Date?
   Public Property Palets As Integer = 1
   Public Property Cbu As String
   Public Property CbuAlias As String
   Public Property ReferenciaComercial As String
   Public Property AnulacionFCE As Boolean?
   Public Property NroVersionAplicacion As String
   Public Property IdAFIPTipoDocCliente As Integer '# No se graba en BD
   Public Property AFIPNroDocCliente As Long '# No se graba en BD

   Public Property IdAFIPReferenciaTransferencia As String

   '-- REQ-31198.- ---------------------------------------
   Public Property IdIcotermExportacion As String
   Public Property IdDestinoExportacion As String
   '------------------------------------------------------
   Public Property FechaPagoExportacion As Date?

   Public Property EsFacturaExportacion As Boolean
   Public Property AgregarObservacionEmbarcacion As Boolean = False

   Public Property ConceptoCM05 As AFIPConceptoCM05
   Public Property SeleccionoInvocados As Publicos.SiNoTodos
   Public Property AplicarSaldoCtaCte As Boolean = False                'Para configurar comportamiento desde la pantalla

#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return If(TipoComprobante IsNot Nothing, TipoComprobante.IdTipoComprobante, String.Empty)
      End Get
   End Property

   Public ReadOnly Property TipoComprobanteDescripcion() As String
      Get
         Return If(TipoComprobante IsNot Nothing, TipoComprobante.Descripcion, String.Empty)
      End Get
   End Property

   Public ReadOnly Property ImporteCheques() As Decimal
      Get
         Dim val As Decimal = 0
         For Each ch As Entidades.Cheque In Me.Cheques
            val += ch.Importe
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que son IVAs.
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de IVAs</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalIVA() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
               val += vi.Importe
            End If
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que son IVAs.
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de IVAs</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalImpuestoInterno() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IMINT Then
               val += vi.Importe
            End If
         Next
         Return val
      End Get
   End Property

   Public ReadOnly Property TotalIVA(ByVal alicuota As Decimal) As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
               If vi.Alicuota = alicuota Then
                  val += vi.Importe
               End If
            End If
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que son IVAs que tiene IVA igual a Cero
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de importes Exentos</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalImporteExento() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
               If vi.Alicuota = 0 Then
                  val += vi.Importe
               End If
            End If
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que no son IVAs
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de Impuestos que no son IVAs</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalTributos() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.ImpuestosVarios
            If vi.TipoImpuesto.IdTipoImpuesto <> TipoImpuesto.Tipos.IVA And vi.TipoImpuesto.IdTipoImpuesto <> TipoImpuesto.Tipos.IMINT Then
               val += vi.Importe
            End If
         Next
         Return val
      End Get
   End Property

   Public Enum Concepto As Short
      Productos = 1
      Servicios = 2
      ProductosyServicios = 3
   End Enum

   Public ReadOnly Property ConceptoDelComprobante() As Concepto
      Get
         Dim producto As Boolean = False
         Dim servicio As Boolean = False
         For Each pro As Entidades.VentaProducto In Me.VentasProductos
            If pro.Producto.EsServicio Then
               servicio = True
            Else
               producto = True
            End If
         Next
         If producto Then
            If servicio Then
               Return Concepto.ProductosyServicios
            Else
               Return Concepto.Productos
            End If
         Else
            If servicio Then
               Return Concepto.Servicios
            Else
               Return Nothing
            End If
         End If
      End Get
   End Property

   Public ReadOnly Property ImporteACtaCte() As Decimal
      Get
         Return ImporteTotal - (ImportePesos + (ImporteDolares * CotizacionDolar) + ImporteTarjetas + ImporteTickets + ImporteCheques + ImporteTransfBancaria)
      End Get
   End Property

   'Public ReadOnly Property TipoDocCobrador As String
   '   Get
   '      If Cobrador Is Nothing Then Return ""
   '      Return Cobrador.TipoDocEmpleado
   '   End Get
   'End Property

   'Public ReadOnly Property NroDocCobrador As String
   '   Get
   '      If Cobrador Is Nothing Then Return ""
   '      Return Cobrador.NroDocEmpleado
   '   End Get
   'End Property

   Public ReadOnly Property NombreCobrador As String
      Get
         If Cobrador Is Nothing Then Return ""
         Return Cobrador.NombreEmpleado
      End Get
   End Property

   Public ReadOnly Property IdCobrador As Integer
      Get
         If Cobrador Is Nothing Then Return 0
         Return Cobrador.IdEmpleado
      End Get
   End Property

   'Public ReadOnly Property NombreCobrador As String
   '   Get
   '      If Cobrador Is Nothing Then Return ""
   '      Return Cobrador.NombreCobrador
   '   End Get
   'End Property

   Public ReadOnly Property IdCliente As Long
      Get
         If _cliente Is Nothing Then Return 0
         Return _cliente.IdCliente
      End Get
   End Property
   Public ReadOnly Property CodigoCliente As Long
      Get
         If _cliente Is Nothing Then Return 0
         Return _cliente.CodigoCliente
      End Get
   End Property

   Public ReadOnly Property IdClienteVinculado As Long
      Get
         If _ClienteVinculado Is Nothing Then Return 0
         Return _ClienteVinculado.IdCliente
      End Get
   End Property
   Public ReadOnly Property CodigoClienteVinculado As Long
      Get
         If _ClienteVinculado Is Nothing Then Return 0
         Return _ClienteVinculado.CodigoCliente
      End Get
   End Property
   Public ReadOnly Property NombreClienteVinculado As String
      Get
         If _ClienteVinculado Is Nothing Then Return String.Empty
         Return _ClienteVinculado.NombreCliente
      End Get
   End Property

   Public ReadOnly Property IdConceptoCM05 As Integer?
      Get
         If ConceptoCM05 Is Nothing Then Return Nothing
         Return ConceptoCM05.IdConceptoCM05
      End Get
   End Property

   Public Const FormatoPKStandard As String = "{0} {1} {2:0000}-{3:00000000}"
   Public ReadOnly Property PkToString As String
      Get
         Return String.Format(FormatoPKStandard, IdTipoComprobante, LetraComprobante, CentroEmisor, NumeroComprobante)
      End Get
   End Property

#End Region

   <DebuggerBrowsable(DebuggerBrowsableState.Never)>
   Private ReadOnly Property DebuggerDisplayForClass() As String
      Get
         Return String.Format("{0} / {1}-{2} {3:0000}-{4:00000000} / {5:dd/MM/yyyy HH:mm:ss}",
                              IdSucursal, IdTipoComprobante, LetraComprobante, CentroEmisor, NumeroComprobante, Fecha)
      End Get
   End Property

   ''''#Region "IPKComprobante"
   ''''   Private ReadOnly Property IPKComprobante_IdSucursal As Integer Implements IPKComprobante.IdSucursal
   ''''      Get
   ''''         Return IdSucursal
   ''''      End Get
   ''''   End Property

   ''''   Private ReadOnly Property IPKComprobante_IdTipoComprobante As String Implements IPKComprobante.IdTipoComprobante
   ''''      Get
   ''''         Return IdTipoComprobante
   ''''      End Get
   ''''   End Property

   ''''   Public ReadOnly Property Letra As String Implements IPKComprobante.Letra
   ''''      Get
   ''''         Return LetraComprobante
   ''''      End Get
   ''''   End Property

   ''''   Private ReadOnly Property IPKComprobante_CentroEmisor As Integer Implements IPKComprobante.CentroEmisor
   ''''      Get
   ''''         Return CentroEmisor
   ''''      End Get
   ''''   End Property

   ''''   Private ReadOnly Property IPKComprobante_NumeroComprobante As Long Implements IPKComprobante.NumeroComprobante
   ''''      Get
   ''''         Return NumeroComprobante
   ''''      End Get
   ''''   End Property
   ''''#End Region
End Class