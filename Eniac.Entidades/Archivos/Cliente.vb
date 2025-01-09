<Serializable()>
Public Class Cliente
   Inherits Entidad

   Public Const NombreTabla As String = "Clientes"

   Public Enum Columnas
      IdCliente
      CodigoCliente
      CodigoClienteLetras
      NombreCliente
      NombreDeFantasia
      Direccion
      IdLocalidad
      NombreLocalidad
      Cuit
      TipoDocCliente
      NroDocCliente
      IdCategoriaFiscal
      NombreCategoriaFiscal
      LetraFiscal
      Telefono
      Celular
      IdZonaGeografica
      NombreZonaGeografica
      FechaNacimiento
      NroOperacion
      CorreoElectronico
      NombreTrabajo
      DireccionTrabajo
      TelefonoTrabajo
      CorreoTrabajo
      IdLocalidadTrabajo
      NombreLocalidadTrabajo
      FechaIngresoTrabajo
      FechaAlta
      SaldoPendiente
      IdClienteGarante
      TipoDocumentoGarante
      NroDocumentoGarante
      NombreGarante
      IdCategoria
      NombreCategoria
      Observacion
      IdListaPrecios
      NombreListaPrecios
      IdVendedor
      NombreVendedor
      LimiteDeCredito
      SaldoLimiteDeCredito
      IdSucursalAsociada
      NombreSucursalAsociada
      DescuentoRecargoPorc
      Activo
      IdTipoComprobante
      IdFormasPago
      DescripcionFormasPago
      IdTransportista
      NombreTransportista
      Foto
      IngresosBrutos
      InscriptoIBStaFe
      LocalIB
      ConvMultilateralIB
      NumeroLote
      IdCaja
      NombreCaja
      DescuentoRecargoPorc2
      PaginaWeb
      ModificarDatos
      EsResidente
      CorreoAdministrativo
      IdEstado
      '  [IdCobrador]
      [IdTipoCliente]
      [HoraInicio]
      [HoraFin]
      [HoraInicio2]
      [HoraFin2]
      [HoraSabInicio]
      [HoraSabFin]
      [HoraSabInicio2]
      [HoraSabFin2]
      [HoraDomInicio]
      [HoraDomFin]
      [HoraDomInicio2]
      [HoraDomFin2]
      [HorarioCorrido]
      [HorarioCorridoSab]
      [HorarioCorridoDom]
      [NroVersion]
      FechaActualizacionVersion
      [FechaInicio]
      [FechaInicioReal]
      CBU
      IdBanco
      IdCuentaBancariaClase
      NumeroCuentaBancaria
      CuitCtaBancaria
      UsaArchivoAImprimir2
      FechaActualizacionWeb
      CantidadVisitas
      CantidadDePCs
      Facebook
      Instagram
      Twitter
      IdAplicacion
      Edicion
      DireccionAdicional
      RecibeNotificaciones
      Contacto
      FechaBaja
      VerEnConsultas
      IdCalle
      Altura
      IdCalle2
      Altura2
      DireccionAdicional2
      TelefonosParticulares
      Fax
      FechaSUS
      IdDadoAltaPor
      'TipoDocDadoAltaPor
      'NroDocDadoAltaPor
      HabilitarVisita
      Direccion2
      IdLocalidad2
      ObservacionWeb
      RepartoIndependiente
      NivelAutorizacion
      IdCuentaContable
      EsClienteGenerico
      URLWebmovilPropio
      URLWebmovilAdminPropio
      URLSimovilGestionPropio
      NroVersionWebmovilPropio
      NroVersionWebmovilAdminPropio
      NroVersionSimovilGestionPropio
      UtilizaAppSoporte
      CantidadLocal
      CantidadRemota
      CantidadMovil
      ObservacionAdministrativa
      SiMovilIdUsuario
      SiMovilClave
      URLActualizadorPropio
      NroVersionActualizadorPropio
      Alicuota2deProducto
      CertificadoMiPyme
      FechaDesdeCertificado
      FechaHastaCertificado
      IdCobrador
      Sexo
      HorarioClienteCompleto

      ValorizacionFacturacionMensual
      ValorizacionCoeficienteFacturacion
      ValorizacionFacturacion
      ValorizacionImporteAdeudado
      ValorizacionCoeficienteDeuda
      ValorizacionDeuda
      ValorizacionProyecto
      ValorizacionProyectoObservacion
      ValorizacionCliente
      ValorizacionEstrellas

      PublicarEnWeb
      IdClienteTiendaNube
      IdClienteMercadoLibre
      IdClienteArborea
      'PE-30972
      FechaCambioCategoria
      ObservacionCambioCategoria
      IdCategoriaCambio

      ActualizadorAptoParaInstalar
      ActualizadorFunciona
      ActualizadorFechaInstalacion
      ActualizadorVersion
      IdImpositivoOtroPais
      IdConceptoCM05
      IdTipoComprobanteInvocacionMasiva
      EsExentoPercIVARes53292023
      IdEstadoCivil
      VarPesosCotizDolar

      MonedaCredito

      PublicarEnTiendaNube
      PublicarEnMercadoLibre
      PublicarEnArborea
      PublicarEnSincronizacionSucursal
      PublicarEnGestion
      PublicarEnEmpresarial

   End Enum

   Public Enum ModoClienteProspecto As Integer
      Cliente = 0
      Prospecto = 1
   End Enum

   Public Enum ConfiguracionMail As Integer
      <Description("CORREO PRINCIPAL")> Principal = 0
      <Description("CORREO ADMINISTRATIVO")> Administrativo = 1
      <Description("CORREO ADMINISTRATIVO Y PRINCIPAL")> AdminyPrincipal = 2
      <Description("CORREO ADMINISTRATIVO O PRINCIPAL")> AdminoPrincipal = 3
   End Enum

   Public Function GetFiltradoPorNombre(text As String) As DataTable
      Throw New NotImplementedException()
   End Function

   Public Enum Alicuota2DeProductoSegun
      <Description("Según Categoría Fiscal")> SEGUNCATEGORIAFISCAL
      <Description("Si")> SI
      <Description("No")> NO
   End Enum

   Public Enum SexoOpciones
      <Description("No Aplica")> NoAplica
      <Description("Indefinido")> Indefinido
      <Description("Femenino")> Femenino
      <Description("Masculino")> Masculino
   End Enum

   Public Enum FuncionaActualizador
      EXPLICAR
      NO
      CLIENTE
      PENDIENTE
      NO_RESPONDE
      SINERGIA
   End Enum

   '-.PE-32017.-
   Public Enum ClienteVinculado
      Cliente
      Vinculado
   End Enum
   Public Sub New()
      Adjuntos = New ListConBorrados(Of ClienteAdjunto)()
      ActualizadorFunciona = FuncionaActualizador.PENDIENTE
      IdEstadoCivil = 10         ' 'A Definir'
   End Sub

#Region "Campos"

   Private _IdCliente As Long
   Private _CodigoCliente As Long
   Private _nombreCliente As String = ""
   Private _nombreDeFantasia As String = ""
   Private _direccion As String = ""
   Private _idLocalidad As Integer = 0
   Private _nombreLocalidad As String = String.Empty
   Private _localidad As Entidades.Localidad
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _telefono As String = ""
   Private _celular As String = ""
   Private _fechaNacimiento As Date = DateTime.Now
   Private _nroOperacion As Integer = 0
   Private _correoElectronico As String = ""
   Private _nombreTrabajo As String = ""
   Private _direccionTrabajo As String = ""
   Private _telefonoTrabajo As String = ""
   Private _correoTrabajo As String = ""
   Private _idLocalidadTrabajo As Integer = 0
   Private _nombreLocalidadTrabajo As String = String.Empty
   Private _fechaIngresoTrabajo As Date = Date.Now
   Private _fechaAlta As DateTime = Date.Now
   Private _saldoPendiente As Decimal = 0
   Private _IdClienteGarante As Long
   Private _tipoDocumentoGarante As String = ""
   Private _nroDocumentoGarante As String = ""
   Private _nombreGarante As String = String.Empty
   Private _idCategoria As Integer = 0
   Private _nombreCategoria As String = String.Empty
   Private _cuit As String = String.Empty
   Private _tipoDocCliente As String = ""
   Private _nroDocCliente As Long = 0
   Private _vendedor As Entidades.Empleado
   Private _observacion As String = String.Empty
   Private _idListaPrecios As Integer
   Private _actividades As DataTable
   Private _direcciones As DataTable
   Private _contactos As DataTable
   Private _NumeroLote As Long
   Private _GeoLocalizacionLat As Double
   Private _GeoLocalizacionLng As Double
   Private _IdTipoDeExension As Short
   Private _AnioExension As Integer
   Private _NroCertExension As String
   Private _NroCertPropio As String
   Private _modulosAdic As DataTable

#End Region

#Region "Propiedades"

#Region "Primaria"

   Public Property IdCliente() As Long
      Get
         Return _IdCliente
      End Get
      Set(value As Long)
         _IdCliente = value
      End Set
   End Property

#End Region

   Public Property CodigoCliente() As Long
      Get
         Return _CodigoCliente
      End Get
      Set(value As Long)
         _CodigoCliente = value
      End Set
   End Property
   Public Property CodigoClienteLetras As String

   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If _categoriaFiscal Is Nothing Then
            _categoriaFiscal = New Entidades.CategoriaFiscal()
         End If
         Return _categoriaFiscal
      End Get
      Set(value As Entidades.CategoriaFiscal)
         _categoriaFiscal = value
      End Set
   End Property
   Public Property IdCategoria() As Int32
      Get
         Return _idCategoria
      End Get
      Set(value As Int32)
         _idCategoria = value
      End Set
   End Property
   Public Property IdLocalidadTrabajo() As Int32
      Get
         Return _idLocalidadTrabajo
      End Get
      Set(value As Int32)
         _idLocalidadTrabajo = value
      End Set
   End Property
   Public Property NombreCategoria() As String
      Get
         Return _nombreCategoria
      End Get
      Set(value As String)
         _nombreCategoria = value
      End Set
   End Property
   Public Property NombreGarante() As String
      Get
         Return _nombreGarante
      End Get
      Set(value As String)
         _nombreGarante = value
      End Set
   End Property
   Public Property NombreLocalidadTrabajo() As String
      Get
         Return _nombreLocalidadTrabajo
      End Get
      Set(value As String)
         _nombreLocalidadTrabajo = value
      End Set
   End Property
   Public Property NombreCliente() As String
      Get
         Return Me._nombreCliente
      End Get
      Set(value As String)
         If value.Length > 100 Then
            Throw New Exception("El ancho del nombre del cliente no puede exceder los 100 caracteres")
         Else
            Me._nombreCliente = value.Trim()
         End If
      End Set
   End Property
   Public Property NombreDeFantasia() As String
      Get
         Return Me._nombreDeFantasia
      End Get
      Set(value As String)
         If value.Length > 100 Then
            Throw New Exception("El ancho del Nombre de Fantasia no puede exceder los 100 caracteres")
         Else
            Me._nombreDeFantasia = value.Trim()
         End If
      End Set
   End Property
   Public Property Direccion() As String
      Get
         Return Me._direccion
      End Get
      Set(value As String)
         If value.Length > 100 Then
            System.Windows.Forms.MessageBox.Show("El ancho de la dirección no puede exceder los 100 caracteres")
            Throw New Exception("El ancho de la dirección no puede exceder los 100 caracteres")
         Else
            Me._direccion = value.Trim()
         End If
      End Set
   End Property
   Public Property DireccionAdicional As String
   Public Property RecibeNotificaciones As Boolean
   Public ReadOnly Property IdLocalidad() As Integer
      Get
         Return Me.Localidad.IdLocalidad
      End Get
   End Property
   Public ReadOnly Property NombreLocalidad() As String
      Get
         Return Me.Localidad.NombreLocalidad
      End Get
   End Property
   Public Property Localidad() As Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Entidades.Localidad()
         End If
         Return Me._localidad
      End Get
      Set(value As Entidades.Localidad)
         Me._localidad = value
      End Set
   End Property
   Public Property Telefono() As String
      Get
         Return Me._telefono
      End Get
      Set(value As String)
         Me._telefono = value.Trim()
      End Set
   End Property
   Public Property Celular() As String
      Get
         Return Me._celular
      End Get
      Set(value As String)
         Me._celular = value.Trim()
      End Set
   End Property
   Public Property FechaNacimiento() As DateTime
      Get
         Return Me._fechaNacimiento
      End Get
      Set(value As DateTime)
         Me._fechaNacimiento = value
      End Set
   End Property
   Public Property NroOperacion() As Integer
      Get
         Return Me._nroOperacion
      End Get
      Set(value As Integer)
         Me._nroOperacion = value
      End Set
   End Property
   Public Property CorreoElectronico() As String
      Get
         Return Me._correoElectronico
      End Get
      Set(value As String)
         Me._correoElectronico = value.Trim()
      End Set
   End Property
   Public Property NombreTrabajo() As String
      Get
         Return Me._nombreTrabajo
      End Get
      Set(value As String)
         Me._nombreTrabajo = value.Trim()
      End Set
   End Property
   Public Property DireccionTrabajo() As String
      Get
         Return Me._direccionTrabajo
      End Get
      Set(value As String)
         Me._direccionTrabajo = value.Trim()
      End Set
   End Property
   Public Property TelefonoTrabajo() As String
      Get
         Return Me._telefonoTrabajo
      End Get
      Set(value As String)
         Me._telefonoTrabajo = value.Trim()
      End Set
   End Property
   Public Property CorreoTrabajo() As String
      Get
         Return Me._correoTrabajo
      End Get
      Set(value As String)
         Me._correoTrabajo = value.Trim()
      End Set
   End Property
   Public Property FechaIngresoTrabajo() As DateTime
      Get
         Return Me._fechaIngresoTrabajo
      End Get
      Set(value As DateTime)
         Me._fechaIngresoTrabajo = value
      End Set
   End Property
   Public Property FechaAlta() As DateTime
      Get
         Return Me._fechaAlta
      End Get
      Set(value As DateTime)
         Me._fechaAlta = value
      End Set
   End Property
   Public Property SaldoPendiente() As Decimal
      Get
         Return Me._saldoPendiente
      End Get
      Set(value As Decimal)
         Me._saldoPendiente = value
      End Set
   End Property
   Public Property IdClienteGarante() As Long
      Get
         Return _IdClienteGarante
      End Get
      Set(value As Long)
         _IdClienteGarante = value
      End Set
   End Property
   Public Property TipoDocumentoGarante() As String
      Get
         Return Me._tipoDocumentoGarante
      End Get
      Set(value As String)
         Me._tipoDocumentoGarante = value
      End Set
   End Property
   Public Property NroDocumentoGarante() As String
      Get
         Return Me._nroDocumentoGarante
      End Get
      Set(value As String)
         Me._nroDocumentoGarante = value.Trim()
      End Set
   End Property
   Public Property Cuit() As String
      Get
         Return Me._cuit
      End Get
      Set(value As String)
         Me._cuit = value.Trim()
      End Set
   End Property

   Public Property TipoDocCliente() As String
      Get
         Return Me._tipoDocCliente
      End Get
      Set(value As String)
         Me._tipoDocCliente = value
      End Set
   End Property

   Public Property NroDocCliente() As Long
      Get
         Return Me._nroDocCliente
      End Get
      Set(value As Long)
         Me._nroDocCliente = value
      End Set
   End Property

   Public Property Vendedor() As Entidades.Empleado
      Get
         If Me._vendedor Is Nothing Then
            Me._vendedor = New Entidades.Empleado()
         End If
         Return _vendedor
      End Get
      Set(value As Entidades.Empleado)
         _vendedor = value
      End Set
   End Property

   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(value As String)
         Me._observacion = value.Trim()
      End Set
   End Property
   Public Property IdListaPrecios() As Integer
      Get
         Return _idListaPrecios
      End Get
      Set(value As Integer)
         _idListaPrecios = value
      End Set
   End Property

   Private _zonaGeografica As Entidades.ZonaGeografica
   Public Property ZonaGeografica() As Entidades.ZonaGeografica
      Get
         If Me._zonaGeografica Is Nothing Then
            Me._zonaGeografica = New Entidades.ZonaGeografica()
         End If
         Return _zonaGeografica
      End Get
      Set(value As Entidades.ZonaGeografica)
         _zonaGeografica = value
      End Set
   End Property

   Public Property LimiteDeCredito As Decimal
   Public Property LimiteDeCredito_Original As Decimal      'Para guardar el dato original de modo de que al guardar se ajuste correctamente el Saldo a partir del Delta de LimiteDeCredito
   Public Property SaldoLimiteDeCredito As Decimal

   Private _limiteDiasVtoFactura As Integer = 0
   Public Property LimiteDiasVtoFactura() As Integer
      Get
         Return Me._limiteDiasVtoFactura
      End Get
      Set(value As Integer)
         Me._limiteDiasVtoFactura = value
      End Set
   End Property

   Private _idSucursalAsociada As Integer = 0
   Public Property IdSucursalAsociada() As Integer
      Get
         Return Me._idSucursalAsociada
      End Get
      Set(value As Integer)
         Me._idSucursalAsociada = value
      End Set
   End Property

   Private _IdCaja As Integer = 0
   Public Property IdCaja() As Integer
      Get
         Return Me._IdCaja
      End Get
      Set(value As Integer)
         Me._IdCaja = value
      End Set
   End Property


   Private _cambiodescuentoRecargoPorc As Boolean = False
   Public Property CambioDescuentoRecargoPorc() As Boolean
      Get
         Return Me._cambiodescuentoRecargoPorc
      End Get
      Set(value As Boolean)
         Me._cambiodescuentoRecargoPorc = value
      End Set
   End Property

   Private _descuentoRecargoPorc As Decimal = 0
   Public Property DescuentoRecargoPorc() As Decimal
      Get
         Return Me._descuentoRecargoPorc
      End Get
      Set(value As Decimal)
         Me._descuentoRecargoPorc = value
      End Set
   End Property

   Private _activo As Boolean
   Public Property Activo() As Boolean
      Get
         Return Me._activo
      End Get
      Set(value As Boolean)
         Me._activo = value
      End Set
   End Property

   Private _idtipoComprobante As String = ""
   Public Property IdTipoComprobante() As String
      Get
         Return _idtipoComprobante
      End Get
      Set(value As String)
         _idtipoComprobante = value
      End Set
   End Property

   Private _idTipoComprobanteInvocacionMasiva As String = ""
   Public Property IdTipoComprobanteInvocacionMasiva() As String
      Get
         Return _idTipoComprobanteInvocacionMasiva
      End Get
      Set(value As String)
         _idTipoComprobanteInvocacionMasiva = value
      End Set
   End Property

   Private _idFormasPago As Integer = 0
   Public Property IdFormasPago() As Integer
      Get
         Return _idFormasPago
      End Get
      Set(value As Integer)
         _idFormasPago = value
      End Set
   End Property

   Private _idTransportista As Integer = 0
   Public Property IdTransportista() As Integer
      Get
         Return _idTransportista
      End Get
      Set(value As Integer)
         _idTransportista = value
      End Set
   End Property

   Private _nombreTransportista As String = ""
   Public Property NombreTransportista() As String
      Get
         Return _nombreTransportista
      End Get
      Set(value As String)
         _nombreTransportista = value
      End Set
   End Property

   Private _foto As System.Drawing.Image
   Public Property Foto() As System.Drawing.Image
      Get
         Return _foto
      End Get
      Set(value As System.Drawing.Image)
         _foto = value
      End Set
   End Property

   Private _ingresosBrutos As String = ""
   Public Property IngresosBrutos() As String
      Get
         Return _ingresosBrutos
      End Get
      Set(value As String)
         _ingresosBrutos = value
      End Set
   End Property

   Private _inscriptoIBStaFe As Boolean
   Public Property InscriptoIBStaFe() As Boolean
      Get
         Return Me._inscriptoIBStaFe
      End Get
      Set(value As Boolean)
         Me._inscriptoIBStaFe = value
      End Set
   End Property

   Private _localIB As Boolean
   Public Property LocalIB() As Boolean
      Get
         Return Me._localIB
      End Get
      Set(value As Boolean)
         Me._localIB = value
      End Set
   End Property

   Private _convMultilateralIB As Boolean
   Public Property ConvMultilateralIB() As Boolean
      Get
         Return Me._convMultilateralIB
      End Get
      Set(value As Boolean)
         Me._convMultilateralIB = value
      End Set
   End Property

   Public Property Actividades() As DataTable
      Get
         Return Me._actividades
      End Get
      Set(value As DataTable)
         Me._actividades = value
      End Set
   End Property

   Public Property Direcciones() As DataTable
      Get
         Return Me._direcciones
      End Get
      Set(value As DataTable)
         Me._direcciones = value
      End Set
   End Property

   Public Property Contactos() As DataTable
      Get
         Return Me._contactos
      End Get
      Set(value As DataTable)
         Me._contactos = value
      End Set
   End Property

   Public Property DescuentosDataSet As DataSet    'Solo usado para Insert/Update

   Private _contactosBorrados As DataTable
   Public Property ContactosBorrados() As DataTable
      Get
         If _contactosBorrados Is Nothing And _contactos IsNot Nothing Then
            _contactosBorrados = _contactos.Clone()
         End If
         Return Me._contactosBorrados
      End Get
      Set(value As DataTable)
         Me._contactosBorrados = value
      End Set
   End Property

   Public Property NumeroLote() As Long
      Get
         Return _NumeroLote
      End Get
      Set(value As Long)
         _NumeroLote = value
      End Set
   End Property

   Public Property GeoLocalizacionLat() As Double
      Get
         Return _GeoLocalizacionLat
      End Get
      Set(value As Double)
         _GeoLocalizacionLat = value
      End Set
   End Property
   Public Property GeoLocalizacionLng() As Double
      Get
         Return _GeoLocalizacionLng
      End Get
      Set(value As Double)
         _GeoLocalizacionLng = value
      End Set
   End Property

   Public Property IdTipoDeExension() As Short
      Get
         Return _IdTipoDeExension
      End Get
      Set(value As Short)
         _IdTipoDeExension = value
      End Set
   End Property

   Public Property AnioExension() As Integer
      Get
         Return _AnioExension
      End Get
      Set(value As Integer)
         _AnioExension = value
      End Set
   End Property

   Public Property NroCertExension() As String
      Get
         Return _NroCertExension
      End Get
      Set(value As String)
         _NroCertExension = value
      End Set
   End Property

   Public Property NroCertPropio() As String
      Get
         Return _NroCertPropio
      End Get
      Set(value As String)
         _NroCertPropio = value
      End Set
   End Property

   Private _descuentoRecargoPorc2 As Decimal = 0
   Public Property DescuentoRecargoPorc2() As Decimal
      Get
         Return Me._descuentoRecargoPorc2
      End Get
      Set(value As Decimal)
         Me._descuentoRecargoPorc2 = value
      End Set
   End Property

   Private _idClienteCtaCte As Long = 0
   Public Property IdClienteCtaCte() As Long
      Get
         Return _idClienteCtaCte
      End Get
      Set(value As Long)
         _idClienteCtaCte = value
      End Set
   End Property

   Private _paginaWeb As String
   Public Property PaginaWeb() As String
      Get
         Return _paginaWeb
      End Get
      Set(value As String)
         _paginaWeb = value
      End Set
   End Property

   Private _modificarDatos As Boolean = False
   Public Property ModificarDatos() As Boolean
      Get
         Return Me._modificarDatos
      End Get
      Set(value As Boolean)
         Me._modificarDatos = value
      End Set
   End Property

   Private _esResidente As Boolean = False
   Public Property EsResidente() As Boolean
      Get
         Return Me._esResidente
      End Get
      Set(value As Boolean)
         Me._esResidente = value
      End Set
   End Property

   Public Property CorreoAdministrativo() As String

   Private _estadoCliente As Entidades.EstadoCliente
   Public Property EstadoCliente() As Entidades.EstadoCliente
      Get
         If Me._estadoCliente Is Nothing Then
            Me._estadoCliente = New Entidades.EstadoCliente()
         End If
         Return _estadoCliente
      End Get
      Set(value As Entidades.EstadoCliente)
         _estadoCliente = value
      End Set
   End Property

   Private _cobrador As Entidades.Empleado
   Public Property Cobrador() As Entidades.Empleado
      Get
         If Me._cobrador Is Nothing Then
            Me._cobrador = New Entidades.Empleado()
         End If
         Return _cobrador
      End Get
      Set(value As Entidades.Empleado)
         _cobrador = value
      End Set
   End Property

   Private _tipoCliente As Entidades.TipoCliente
   Public Property TipoCliente() As Entidades.TipoCliente
      Get
         If Me._tipoCliente Is Nothing Then
            Me._tipoCliente = New Entidades.TipoCliente()
         End If
         Return _tipoCliente
      End Get
      Set(value As Entidades.TipoCliente)
         _tipoCliente = value
      End Set
   End Property

   Public Property IdEstadoCivil As Integer
   Public Property MonedaCredito As Integer

   Public Property [HoraInicio] As String
   Public Property [HoraFin] As String
   Public Property [HoraInicio2] As String
   Public Property [HoraFin2] As String
   Public Property [HoraSabInicio] As String
   Public Property [HoraSabFin] As String
   Public Property [HoraSabInicio2] As String
   Public Property [HoraSabFin2] As String
   Public Property [HoraDomInicio] As String
   Public Property [HoraDomFin] As String
   Public Property [HoraDomInicio2] As String
   Public Property [HoraDomFin2] As String
   Public Property [HorarioCorrido] As Boolean
   Public Property [HorarioCorridoSab] As Boolean
   Public Property [HorarioCorridoDom] As Boolean
   Public Property [NroVersion] As String
   Public Property [FechaActualizacionVersion] As DateTime?
   Public Property FechaActualizacionWeb As DateTime
   Public Property [FechaInicio] As DateTime?
   Public Property [FechaInicioReal] As DateTime?
   Public Property [VencimientoLicencia] As DateTime?
   Public Property [BackupAutoCuenta] As String
   Public Property [BackupAutoConfig] As Boolean?
   Public Property [BackupNroVersion] As String
   Public Property [TienePreciosConIVA] As Boolean?
   Public Property [ConsultaPreciosConIVA] As Boolean?
   Public Property [TieneServidorDedicado] As Boolean?
   Public Property [MotorBaseDatos] As String
   Public Property [CantidadDePCs] As Integer
   Public Property [HorasCapacitacionPactadas] As Integer
   Public Property [HorasCapacitacionRealizadas] As Integer

   Public Property Facebook As String
   Public Property Instagram As String
   Public Property Twitter As String
   Public Property IdAplicacion As String
   Public Property Edicion As String


   Public Property CBU() As String
   Private _banco As Eniac.Entidades.Banco
   Public Property Banco() As Eniac.Entidades.Banco
      Get
         If Me._banco Is Nothing Then
            Me._banco = New Eniac.Entidades.Banco()
         End If
         Return _banco
      End Get
      Set(value As Eniac.Entidades.Banco)
         _banco = value
      End Set
   End Property

   Private _cuentaBancariaClase As Eniac.Entidades.CuentaBancariaClase
   Public Property CuentaBancariaClase() As Eniac.Entidades.CuentaBancariaClase
      Get
         If Me._cuentaBancariaClase Is Nothing Then
            Me._cuentaBancariaClase = New Eniac.Entidades.CuentaBancariaClase()
         End If
         Return _cuentaBancariaClase
      End Get
      Set(value As Eniac.Entidades.CuentaBancariaClase)
         _cuentaBancariaClase = value
      End Set
   End Property

   Public Property NumeroCuentaBancaria() As String
   Public Property CuitCtaBancaria() As String
   Public Property UsaArchivoAImprimir2 As Boolean

   Public Property CantidadVisitas As Integer

   Public Property Adjuntos As ListConBorrados(Of ClienteAdjunto)

   Public Property Contacto As String
   Public Property FechaBaja As DateTime
   Public Property VerEnConsultas As Boolean
   Private _Calle As Entidades.Calle
   Public Property Calle() As Entidades.Calle
      Get
         If _Calle Is Nothing Then _Calle = New Calle()
         Return _Calle
      End Get
      Set(value As Entidades.Calle)
         _Calle = value
      End Set
   End Property
   Public Property Altura As Integer
   Private _Calle2 As Entidades.Calle
   Public Property Calle2() As Entidades.Calle
      Get
         If _Calle2 Is Nothing Then _Calle2 = New Calle()
         Return _Calle2
      End Get
      Set(value As Entidades.Calle)
         _Calle2 = value
      End Set
   End Property
   Public Property Altura2 As Integer
   Public Property DireccionAdicional2 As String
   Public Property TelefonosParticulares As String
   Public Property Fax As String
   Public Property FechaSUS As DateTime
   Private _DadoAltaPor As Eniac.Entidades.Empleado
   Public Property DadoAltaPor As Eniac.Entidades.Empleado
      Get
         If _DadoAltaPor Is Nothing Then _DadoAltaPor = New Empleado()
         Return _DadoAltaPor
      End Get
      Set(value As Eniac.Entidades.Empleado)
         _DadoAltaPor = value
      End Set
   End Property
   Public Property HabilitarVisita As Boolean
   Public Property Direccion2 As String
   Public Property IdLocalidad2 As Integer
   Public Property ObservacionWeb As String
   Public Property RepartoIndependiente As Boolean
   Public Property NivelAutorizacion As Short

   Public Property URLWebmovilPropio As String
   Public Property URLWebmovilAdminPropio As String
   Public Property URLSimovilGestionPropio As String
   Public Property URLActualizadorPropio As String
   Public Property NroVersionWebmovilPropio As String
   Public Property NroVersionWebmovilAdminPropio As String
   Public Property NroVersionSimovilGestionPropio As String
   Public Property NroVersionActualizadorPropio As String


   Private _cuentaContable As ContabilidadCuenta
   Public Property CuentaContable() As ContabilidadCuenta
      Get
         Return _cuentaContable
      End Get
      Set(value As ContabilidadCuenta)
         _cuentaContable = value
      End Set
   End Property

   Public ReadOnly Property IdCuentaContable As Long
      Get
         If CuentaContable Is Nothing Then Return 0
         Return CuentaContable.IdCuenta
      End Get
   End Property

   Public Property ModulosAdic() As DataTable
      Get
         Return Me._modulosAdic
      End Get
      Set(value As DataTable)
         Me._modulosAdic = value
      End Set
   End Property

   Public Property EsClienteGenerico As Boolean

   Public Property ControlaBackup As Boolean 'El Campo es de la Entidad Categoria
   Public Property ActualizarAplicacion As Boolean 'El Campo es de la Entidad Categoria
   Public Property UtilizaAppSoporte As Boolean
   Public Property CantidadLocal As Integer
   Public Property CantidadRemota As Integer
   Public Property CantidadMovil As Integer
   Public Property ObservacionAdministrativa As String

   Public Property SiMovilIdUsuario As String
   Public Property SiMovilClave As String

   Public Property Alicuota2deProducto As Alicuota2DeProductoSegun
   Public Property CertificadoMiPyme As Boolean
   Public Property FechaDesdeCertificado As DateTime?
   Public Property FechaHastaCertificado As DateTime?
   Public Property Sexo As SexoOpciones
   Public Property HorarioClienteCompleto As String

   Public Property ValorizacionFacturacionMensual As Decimal
   Public Property ValorizacionCoeficienteFacturacion As Decimal
   Public Property ValorizacionFacturacion As Decimal
   Public Property ValorizacionImporteAdeudado As Decimal
   Public Property ValorizacionCoeficienteDeuda As Decimal
   Public Property ValorizacionDeuda As Decimal
   Public Property ValorizacionProyecto As Decimal
   Public Property ValorizacionProyectoObservacion As String
   Public Property ValorizacionCliente As Decimal
   Public Property ValorizacionEstrellas As Decimal

   Public Property PublicarEnWeb As Boolean
   Public Property IdClienteTiendaNube As String
   Public Property IdClienteMercadoLibre As String
   Public Property IdClienteArborea As String

   'PE-30972
   Public Property FechaCambioCategoria As Date?
   Public Property ObservacionCambioCategoria As String
   Public Property IdCategoriaCambio As Integer?

   '-.PE-31491.-
   Public Property IdCategoriaFiscal As Integer


   Public Property ActualizadorAptoParaInstalar As Boolean
   Public Property ActualizadorFunciona As FuncionaActualizador
   Public Property ActualizadorFechaInstalacion As Date?
   Public Property ActualizadorVersion As String
   Public Property IdImpositivoOtroPais As String
   Public Property IdConceptoCM05 As Integer?

   Public Property EsExentoPercIVARes53292023 As Boolean
   Public Property VarPesosCotizDolar As Decimal?


   Public Property PublicarEnTiendaNube As Boolean
   Public Property PublicarEnMercadoLibre As Boolean
   Public Property PublicarEnArborea As Boolean
   Public Property PublicarEnGestion As Boolean
   Public Property PublicarEnEmpresarial As Boolean
   Public Property PublicarEnSincronizacionSucursal As Boolean

#End Region

End Class
Public Class ClienteLiviano
   Inherits Entidad
   Public Property IdCliente As Long
   Public Property CodigoCliente As Long
   Public Property NombreCliente As String

   Public Property IdCategoriaFiscal As Short

   Public Property TipoDocCliente As String
   Public Property NroDocCliente As Long
   Public Property Cuit As String

   Public Property Telefono As String
   Public Property Celular As String

   '-.PE-32189.-
   Public Property IdCategoria As Integer
   Public Property NombreCategoria As String

   Public Property LimiteDeCredito As Decimal
   Public Property SaldoLimiteDeCredito As Decimal



End Class