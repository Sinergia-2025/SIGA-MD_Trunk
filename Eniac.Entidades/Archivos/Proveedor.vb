<Serializable()>
Public Class Proveedor
   Inherits Entidad

   Public Const NombreTabla As String = "Proveedores"
   Public Enum Columnas
      IdProveedor
      CodigoProveedor
      NombreProveedor

      TipoDocProveedorAnterior
      NroDocProveedorAnterior
      DireccionProveedor
      IdLocalidadProveedor
      CuitProveedor
      TelefonoProveedor
      FaxProveedor
      IdCategoriaFiscal
      Observacion
      IngresosBrutos
      CorreoElectronico
      Activo
      IdCategoria
      IdRubroCompra
      IdCuentaCaja
      EsPasibleRetencion
      IdRegimen
      IdTipoComprobante
      DescuentoRecargoPorc
      IdFormasPago
      Foto
      PorCtaOrden
      TipoDocProveedor
      NroDocProveedor
      FechaHigSeg
      FechaRes559
      FechaIndiceInc
      EsPasibleRetencionIVA
      IdRegimenIVA
      EsPasibleRetencionIIBB
      IdRegimenIIBB
      IdRegimenIIBBComplem
      IdRegimenGan
      IdCuentaContable
      NombreDeFantasia
      IdCuentaBanco
      NivelAutorizacion
      FechaIndemnidad
      EsProveedorGenerico
      CBUProveedor
      CBUAliasProveedor
      CBUCuit
      CodigoProveedorLetras
      CorreoAdministrativo
      NroCuenta
      IdConceptoCM05
      IdTransportista
      IdClienteVinculado
   End Enum

#Region "Campos"
   Private _direccionProveedor As String = ""
   Private _idLocalidadProveedor As Integer = 0
   Private _nombreLocalidad As String = ""
   Private _cuitProveedor As String = ""
   Private _telefonoProveedor As String = ""
   Private _faxProveedor As String = ""
   Private _correoElectronico As String = ""
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _ingresosBrutos As String = ""
   Private _observacion As String = ""
   Private _idProveedor As Long = 0
   Private _codigoProveedor As Long = 0
   Private _categoria As Entidades.CategoriaProveedor
   Private _tipoDocProveedor As String = String.Empty
   Private _nroDocProveedor As Long = 0
   Private _nombreProveedor As String = ""
   Private _rubroCompra As Entidades.RubroCompra
   Private _cuentaDeCaja As Entidades.CuentaDeCaja
   Private _activo As Boolean
   Private _esPasibleRetencion As Boolean
   Private _regimen As Entidades.Regimen
   Private _regimenGan As Entidades.Regimen
   Private _esPasibleRetencionIVA As Boolean
   Private _regimenIVA As Entidades.Regimen
   Private _esPasibleRetencionIIBB As Boolean
   Private _regimenIIBB As Entidades.Regimen
   Private _regimenIIBBComplem As Entidades.Regimen
   Private _idtipoComprobante As String = ""
   Private _porCtaOrden As Boolean
   Private _foto As System.Drawing.Image
   Private _idFormasPago As Integer = 0
   Private _descuentoRecargoPorc As Decimal = 0
   Private _cambiodescuentoRecargoPorc As Boolean = False
   Private _fechaHigSeg As DateTime?
   Private _fechaRes559 As DateTime?
   Private _fechaIndiceInc As DateTime?
   Private _fechaIndemnidad As DateTime?
   Private _correoAdministrativo As String = ""
   Private _nroCuenta As String = ""

#End Region

   Public Sub New()
      NivelAutorizacion = 1
   End Sub

#Region "Propiedades"

   Public Property CBUProveedor As String
   Public Property CBUAliasProveedor As String
   Public Property CBUCuit As String

   Public Property IdProveedor() As Long
      Get
         Return Me._idProveedor
      End Get
      Set(value As Long)
         Me._idProveedor = value
      End Set
   End Property

   Public Property CodigoProveedorLetras As String

   Public Property CodigoProveedor() As Long
      Get
         Return Me._codigoProveedor
      End Get
      Set(value As Long)
         Me._codigoProveedor = value
      End Set
   End Property

   Public Property TipoDocProveedor() As String
      Get
         Return Me._tipoDocProveedor
      End Get
      Set(value As String)
         Me._tipoDocProveedor = value
      End Set
   End Property

   Public Property NroDocProveedor() As Long
      Get
         Return Me._nroDocProveedor
      End Get
      Set(value As Long)
         Me._nroDocProveedor = value
      End Set
   End Property

   Public Property NombreProveedor() As String
      Get
         Return _nombreProveedor
      End Get
      Set(value As String)
         _nombreProveedor = value
      End Set
   End Property

   Public Property CuitProveedor() As String
      Get
         Return _cuitProveedor
      End Get
      Set(value As String)
         _cuitProveedor = value
      End Set
   End Property
   Public Property DireccionProveedor() As String
      Get
         Return _direccionProveedor
      End Get
      Set(value As String)
         _direccionProveedor = value
      End Set
   End Property
   Public Property FaxProveedor() As String
      Get
         Return _faxProveedor
      End Get
      Set(value As String)
         _faxProveedor = value
      End Set
   End Property
   Public Property IdLocalidadProveedor() As Integer
      Get
         Return _idLocalidadProveedor
      End Get
      Set(value As Integer)
         _idLocalidadProveedor = value
      End Set
   End Property
   Public Property NombreLocalidad() As String
      Get
         Return _nombreLocalidad
      End Get
      Set(value As String)
         _nombreLocalidad = value
      End Set
   End Property
   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If Me._categoriaFiscal Is Nothing Then
            Me._categoriaFiscal = New Entidades.CategoriaFiscal()
         End If
         Return Me._categoriaFiscal
      End Get
      Set(value As Entidades.CategoriaFiscal)
         Me._categoriaFiscal = value
      End Set
   End Property
   Public Property TelefonoProveedor() As String
      Get
         Return _telefonoProveedor
      End Get
      Set(value As String)
         _telefonoProveedor = value
      End Set
   End Property
   Public Property CorreoElectronico() As String
      Get
         Return Me._correoElectronico
      End Get
      Set(value As String)
         Me._correoElectronico = value
      End Set
   End Property
   Public Property IngresosBrutos() As String
      Get
         Return _ingresosBrutos
      End Get
      Set(value As String)
         _ingresosBrutos = value
      End Set
   End Property
   Public Property Observacion() As String
      Get
         Return _observacion
      End Get
      Set(value As String)
         _observacion = value
      End Set
   End Property


   Public Property Categoria() As Entidades.CategoriaProveedor
      Get
         If Me._categoria Is Nothing Then
            Me._categoria = New Entidades.CategoriaProveedor()
         End If
         Return Me._categoria
      End Get
      Set(value As Entidades.CategoriaProveedor)
         Me._categoria = value
      End Set
   End Property


   Public Property RubroCompra() As Entidades.RubroCompra
      Get
         If Me._rubroCompra Is Nothing Then
            Me._rubroCompra = New Entidades.RubroCompra()
         End If
         Return Me._rubroCompra
      End Get
      Set(value As Entidades.RubroCompra)
         Me._rubroCompra = value
      End Set
   End Property


   Public Property CuentaDeCaja() As Entidades.CuentaDeCaja
      Get
         If Me._cuentaDeCaja Is Nothing Then
            Me._cuentaDeCaja = New Entidades.CuentaDeCaja()
         End If
         Return Me._cuentaDeCaja
      End Get
      Set(value As Entidades.CuentaDeCaja)
         Me._cuentaDeCaja = value
      End Set
   End Property


   Public Property Activo() As Boolean
      Get
         Return Me._activo
      End Get
      Set(value As Boolean)
         Me._activo = value
      End Set
   End Property


   Public Property EsPasibleRetencion() As Boolean
      Get
         Return _esPasibleRetencion
      End Get
      Set(value As Boolean)
         _esPasibleRetencion = value
      End Set
   End Property


   Public Property Regimen() As Entidades.Regimen
      Get
         If Me._regimen Is Nothing Then
            Me._regimen = New Entidades.Regimen()
         End If
         Return _regimen
      End Get
      Set(value As Entidades.Regimen)
         _regimen = value
      End Set
   End Property

   Public Property RegimenGan() As Entidades.Regimen
      Get
         If Me._regimenGan Is Nothing Then
            Me._regimenGan = New Entidades.Regimen()
         End If
         Return _regimenGan
      End Get
      Set(value As Entidades.Regimen)
         _regimenGan = value
      End Set
   End Property

   Public Property EsPasibleRetencionIVA() As Boolean
      Get
         Return _esPasibleRetencionIVA
      End Get
      Set(value As Boolean)
         _esPasibleRetencionIVA = value
      End Set
   End Property


   Public Property RegimenIVA() As Entidades.Regimen
      Get
         If Me._regimenIVA Is Nothing Then
            Me._regimenIVA = New Entidades.Regimen()
         End If
         Return _regimenIVA
      End Get
      Set(value As Entidades.Regimen)
         _regimenIVA = value
      End Set
   End Property

   Public Property EsPasibleRetencionIIBB() As Boolean
      Get
         Return _esPasibleRetencionIIBB
      End Get
      Set(value As Boolean)
         _esPasibleRetencionIIBB = value
      End Set
   End Property


   Public Property RegimenIIBB() As Entidades.Regimen
      Get
         If Me._regimenIIBB Is Nothing Then
            Me._regimenIIBB = New Entidades.Regimen()
         End If
         Return _regimenIIBB
      End Get
      Set(value As Entidades.Regimen)
         _regimenIIBB = value
      End Set
   End Property

   Public Property RegimenIIBBComplem() As Entidades.Regimen
      Get
         If Me._regimenIIBBComplem Is Nothing Then
            Me._regimenIIBBComplem = New Entidades.Regimen()
         End If
         Return _regimenIIBBComplem
      End Get
      Set(value As Entidades.Regimen)
         _regimenIIBBComplem = value
      End Set
   End Property

   Public Property IdTipoComprobante() As String
      Get
         Return _idtipoComprobante
      End Get
      Set(value As String)
         _idtipoComprobante = value
      End Set
   End Property

   Public Property CambioDescuentoRecargoPorc() As Boolean
      Get
         Return Me._cambiodescuentoRecargoPorc
      End Get
      Set(value As Boolean)
         Me._cambiodescuentoRecargoPorc = value
      End Set
   End Property


   Public Property DescuentoRecargoPorc() As Decimal
      Get
         Return Me._descuentoRecargoPorc
      End Get
      Set(value As Decimal)
         Me._descuentoRecargoPorc = value
      End Set
   End Property

   Public Property IdFormasPago() As Integer
      Get
         Return _idFormasPago
      End Get
      Set(value As Integer)
         _idFormasPago = value
      End Set
   End Property


   Public Property PorCtaOrden() As Boolean
      Get
         Return Me._porCtaOrden
      End Get
      Set(value As Boolean)
         Me._porCtaOrden = value
      End Set
   End Property


   Public Property Foto() As System.Drawing.Image
      Get
         Return _foto
      End Get
      Set(value As System.Drawing.Image)
         _foto = value
      End Set
   End Property

   Public Property FechaHigSeg() As DateTime?
      Get
         Return _fechaHigSeg
      End Get
      Set(value As DateTime?)
         _fechaHigSeg = value
      End Set
   End Property

   Public Property FechaRes559() As DateTime?
      Get
         Return _fechaRes559
      End Get
      Set(value As DateTime?)
         _fechaRes559 = value
      End Set
   End Property

   Public Property FechaIndiceInc() As DateTime?
      Get
         Return _fechaIndiceInc
      End Get
      Set(value As DateTime?)
         _fechaIndiceInc = value
      End Set
   End Property

   Private _cuentaContable As ContabilidadCuenta
   Public Property CuentaContable() As ContabilidadCuenta
      Get
         Return _cuentaContable
      End Get
      Set(value As ContabilidadCuenta)
         _cuentaContable = value
      End Set
   End Property

   Public Property NombreDeFantasia As String

   Private _cuentaBanco As Entidades.CuentaBanco
   Public Property CuentaBanco() As Entidades.CuentaBanco
      Get
         If Me._cuentaBanco Is Nothing Then
            Me._cuentaBanco = New Entidades.CuentaBanco()
         End If
         Return Me._cuentaBanco
      End Get
      Set(value As Entidades.CuentaBanco)
         Me._cuentaBanco = value
      End Set
   End Property

   Public Property NivelAutorizacion As Short

   Public Property FechaIndemnidad() As DateTime?
      Get
         Return _fechaIndemnidad
      End Get
      Set(value As DateTime?)
         _fechaIndemnidad = value
      End Set
   End Property

   Public Property EsProveedorGenerico As Boolean

   Public Property CorreoAdministrativo() As String
      Get
         Return Me._correoAdministrativo
      End Get
      Set(value As String)
         Me._correoAdministrativo = value
      End Set
   End Property

   Public Property NroCuenta() As String
      Get
         Return Me._nroCuenta
      End Get
      Set(value As String)
         Me._nroCuenta = value
      End Set
   End Property

   Public Property IdConceptoCM05 As Integer?
   Public Property IdTransportista As Integer
   Public Property IdClienteVinculado As Long?

#End Region

   Public Overrides Function ToString() As String
      'Dim stb = New StringBuilder()
      'With stb
      '   .Append(NombreProveedor)
      'End With
      Return NombreProveedor
   End Function

   Public Function GetCopia() As Entidades.Proveedor
      Dim copia = New Proveedor()
      With copia
         .Activo = Me.Activo
         .Categoria = Me._categoria.GetCopia()
         .CategoriaFiscal = Me._categoriaFiscal.GetCopia()
         .CorreoElectronico = Me._correoElectronico
         .CuentaDeCaja = Me._cuentaDeCaja.GetCopia()
         .CuitProveedor = Me._cuitProveedor
         .DireccionProveedor = Me._direccionProveedor
         .EsPasibleRetencion = Me._esPasibleRetencion
         .FaxProveedor = Me._faxProveedor
         .IdLocalidadProveedor = Me._idLocalidadProveedor
         .IdSucursal = Me.IdSucursal
         .IngresosBrutos = Me._ingresosBrutos
         .NombreLocalidad = Me._nombreLocalidad
         .NombreProveedor = Me.NombreProveedor
         .NroDocProveedor = Me._nroDocProveedor
         .Observacion = Me._observacion
         .Password = Me.Password
         .Regimen = Me._regimen.GetCopia()
         .RubroCompra = Me._rubroCompra.GetCopia()
         .TelefonoProveedor = Me._telefonoProveedor
         .TipoDocProveedor = Me._tipoDocProveedor
         .IdTipoComprobante = Me.IdTipoComprobante
         .Usuario = Me.Usuario
         .IdFormasPago = Me.IdFormasPago
         .DescuentoRecargoPorc = Me.DescuentoRecargoPorc
         .IdProveedor = Me.IdProveedor
         .CodigoProveedor = Me.CodigoProveedor
         .CodigoProveedorLetras = Me.CodigoProveedorLetras
         .FechaHigSeg = Me.FechaHigSeg
         .FechaRes559 = Me.FechaRes559
         .FechaIndiceInc = Me.FechaIndiceInc
         .NombreDeFantasia = Me.NombreDeFantasia
         .NivelAutorizacion = Me.NivelAutorizacion
         .FechaIndemnidad = Me.FechaIndemnidad
         .EsProveedorGenerico = Me.EsProveedorGenerico
         .CorreoAdministrativo = Me._correoAdministrativo
         .NroCuenta = Me._nroCuenta
         .IdConceptoCM05 = _IdConceptoCM05
         .IdTransportista = Me.IdTransportista
         .IdClienteVinculado = Me.IdClienteVinculado
      End With
      Return copia
   End Function

End Class