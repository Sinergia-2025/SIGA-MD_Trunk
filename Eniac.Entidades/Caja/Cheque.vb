<Serializable()>
Public Class Cheque
   Inherits Entidad
   Public Const NombreTabla As String = "Cheques"
   Public Enum Columnas
      IdSucursal
      NumeroCheque
      IdBanco
      IdBancoSucursal
      IdLocalidad
      FechaEmision
      FechaCobro
      Titular
      Importe
      IdCajaIngreso
      NroPlanillaIngreso
      NroMovimientoIngreso
      IdCajaEgreso
      NroPlanillaEgreso
      NroMovimientoEgreso
      EsPropio
      IdCuentaBancaria
      IdEstadoCheque
      IdEstadoChequeAnt
      Cuit
      IdCliente
      IdProveedor
      FotoFrente
      FotoDorso
      IdProveedorPreasignado
      IdUsuarioActualizacion
      IdTipoCheque
      NroOperacion
      IdCheque
      IdChequera
      IdSituacionCheque
      Observacion
   End Enum

   Public Enum Estados
      ENCARTERA
      PROVEEDOR
      DEPOSITADO
      EGRESOCAJA
      RECHAZADO
      ALTA
      NINGUNO
      ANULADO
   End Enum

   Public Enum Ordenamiento
      <Description("FECHACOBRO")> FECHACOBRO
      <Description("NOMBREYFECHACOBRO")> NOMBREYFECHACOBRO
      <Description("FECHAACTUALIZACION")> FECHAACTUALIZACION
      <Description("NOMBREYFECHAACTUALIZACION")> NOMBREYFECHAACTUALIZACION
   End Enum

#Region "Constructores"

   Public Sub New()

   End Sub

   Public Sub New(idSucursal As Int32, usuario As String, pwd As String)
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Me.Password = pwd
   End Sub

#End Region

#Region "Campos"

   Private _banco As Entidades.Banco
   Private _IdBancoSucursal As Integer
   Private _localidad As Eniac.Entidades.Localidad
   Private _numeroCheque As Integer
   Private _FechaEmision As Date
   Private _FechaCobro As Date
   Private _Titular As String
   Private _Importe As Decimal
   Private _NroPlanillaIngreso As Integer
   Private _NroMovimientoIngreso As Integer
   Private _cliente As Eniac.Entidades.Cliente
   Private _NroPlanillaEgreso As Integer
   Private _NroMovimientoEgreso As Integer
   Private _proveedor As Eniac.Entidades.Proveedor
   Private _idProveedorPreasignado As Long
   Private _proveedorPreasignado As String
   Private _RowState As DataRowState
   Private _esPropio As Boolean = False
   Private _cuentaBancaria As Entidades.CuentaBancaria
   Private _idEstadoCheque As Estados
   Private _idEstadoChequeAnt As Estados
   Private _cuit As String = String.Empty
   'PE-31207
   Private _situacionCheque As Entidades.SituacionCheque

#End Region

#Region "Propiedades"

   Public Property IdChequera As Integer?
   Public Property IdCheque As Long
   Public Property IdTipoCheque As String

   '# Solo para visualización
   Public Property NombreTipoCheque As String

   Public Property Banco() As Entidades.Banco
      Get
         If Me._banco Is Nothing Then
            Me._banco = New Entidades.Banco()
         End If
         Return _banco
      End Get
      Set(value As Entidades.Banco)
         _banco = value
      End Set
   End Property

   Public ReadOnly Property IdBanco() As Integer
      Get
         Return Me._banco.IdBanco
      End Get
   End Property

   Public ReadOnly Property NombreBanco() As String
      Get
         Return Me._banco.NombreBanco
      End Get
   End Property

   Public Property IdBancoSucursal() As Integer
      Get
         Return _IdBancoSucursal
      End Get
      Set(value As Integer)
         _IdBancoSucursal = value
      End Set
   End Property

   Public Property Localidad() As Eniac.Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Eniac.Entidades.Localidad()
         End If
         Return _localidad
      End Get
      Set(value As Eniac.Entidades.Localidad)
         _localidad = value
      End Set
   End Property

   Public ReadOnly Property CP() As Integer
      Get
         Return Me._localidad.IdLocalidad
      End Get
   End Property

   Public Property NumeroCheque() As Integer
      Get
         Return _numeroCheque
      End Get
      Set(value As Integer)
         _numeroCheque = value
      End Set
   End Property

   Public Property NroOperacion As String

   Public Property FechaEmision() As Date
      Get
         Return _FechaEmision
      End Get
      Set(value As Date)
         _FechaEmision = value
      End Set
   End Property

   Public Property FechaCobro() As Date
      Get
         Return _FechaCobro
      End Get
      Set(value As Date)
         _FechaCobro = value
      End Set
   End Property

   Public Property Titular() As String
      Get
         Return _Titular
      End Get
      Set(value As String)
         _Titular = value
      End Set
   End Property

   Public Property Importe() As Decimal
      Get
         Return _Importe
      End Get
      Set(value As Decimal)
         _Importe = value
      End Set
   End Property

   Private _idCajaIngreso As Integer
   Public Property IdCajaIngreso() As Integer
      Get
         Return _idCajaIngreso
      End Get
      Set(value As Integer)
         _idCajaIngreso = value
      End Set
   End Property

   Public Property NroPlanillaIngreso() As Integer
      Get
         Return _NroPlanillaIngreso
      End Get
      Set(value As Integer)
         _NroPlanillaIngreso = value
      End Set
   End Property

   Public Property NroMovimientoIngreso() As Integer
      Get
         Return _NroMovimientoIngreso
      End Get
      Set(value As Integer)
         _NroMovimientoIngreso = value
      End Set
   End Property

   Public Property Cliente() As Eniac.Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Eniac.Entidades.Cliente()
         End If
         Return Me._cliente
      End Get
      Set(value As Eniac.Entidades.Cliente)
         Me._cliente = value
      End Set
   End Property

   Private _idCajaEgreso As Integer
   Public Property IdCajaEgreso() As Integer
      Get
         Return _idCajaEgreso
      End Get
      Set(value As Integer)
         _idCajaEgreso = value
      End Set
   End Property

   Public Property NroPlanillaEgreso() As Integer
      Get
         Return _NroPlanillaEgreso
      End Get
      Set(value As Integer)
         _NroPlanillaEgreso = value
      End Set
   End Property

   Public Property NroMovimientoEgreso() As Integer
      Get
         Return _NroMovimientoEgreso
      End Get
      Set(value As Integer)
         _NroMovimientoEgreso = value
      End Set
   End Property
   Public Property Proveedor() As Eniac.Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Eniac.Entidades.Proveedor()
         End If
         Return Me._proveedor
      End Get
      Set(value As Eniac.Entidades.Proveedor)
         Me._proveedor = value
      End Set
   End Property
   Public Property IdProveedorPreasignado() As Long
      Get
         Return _idProveedorPreasignado
      End Get
      Set(value As Long)
         _idProveedorPreasignado = value
      End Set
   End Property
   Public Property CodigoProveedorPreasignado As Long    'Solo para mostrar en pantalla
   Public Property ProveedorPreasignado() As String      'Solo para mostrar en pantalla
      Get
         Return _proveedorPreasignado
      End Get
      Set(value As String)
         _proveedorPreasignado = value
      End Set
   End Property

   Public Property RowState() As DataRowState
      Get
         Return _RowState
      End Get
      Set(value As DataRowState)
         _RowState = value
      End Set
   End Property

   Public Property EsPropio() As Boolean
      Get
         Return _esPropio
      End Get
      Set(value As Boolean)
         _esPropio = value
      End Set
   End Property

   Public Property CuentaBancaria() As Entidades.CuentaBancaria
      Get
         If Me._cuentaBancaria Is Nothing Then
            Me._cuentaBancaria = New Entidades.CuentaBancaria()
         End If
         Return _cuentaBancaria
      End Get
      Set(value As Entidades.CuentaBancaria)
         _cuentaBancaria = value
      End Set
   End Property

   Public ReadOnly Property IdCuentaBancaria() As Integer
      Get
         Return Me.CuentaBancaria.IdCuentaBancaria
      End Get
   End Property

   Public ReadOnly Property NombreCuentaBancaria() As String
      Get
         Return Me._cuentaBancaria.NombreCuenta
      End Get
   End Property

   Public Property IdEstadoCheque() As Estados
      Get
         Return _idEstadoCheque
      End Get
      Set(value As Estados)
         _idEstadoCheque = value
      End Set
   End Property

   Public Property IdEstadoChequeAnt() As Estados
      Get
         Return _idEstadoChequeAnt
      End Get
      Set(value As Estados)
         _idEstadoChequeAnt = value
      End Set
   End Property

   Private _idSucursal2 As Integer
   Public Property IdSucursal2() As Integer
      Get
         Return _idSucursal2
      End Get
      Set(value As Integer)
         _idSucursal2 = value
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

   Private _fotoFrente As System.Drawing.Image
   Public Property FotoFrente() As System.Drawing.Image
      Get
         Return _fotoFrente
      End Get
      Set(value As System.Drawing.Image)
         _fotoFrente = value
      End Set
   End Property

   Private _fotoDorso As System.Drawing.Image
   Public Property FotoDorso() As System.Drawing.Image
      Get
         Return _fotoDorso
      End Get
      Set(value As System.Drawing.Image)
         _fotoDorso = value
      End Set
   End Property

   Public Property CajaDetalleParaIngresoDirectoPorABM As Entidades.CajaDetalles

   Public ReadOnly Property IdCuentaDeCaja() As Integer
      Get
         If Me.CajaDetalleParaIngresoDirectoPorABM IsNot Nothing Then
            Return Me.CajaDetalleParaIngresoDirectoPorABM.IdCuentaCaja
         Else
            Return 0
         End If
      End Get
   End Property

   Public Property IdSituacionCheque As Integer
   Public Property NombreSituacionCheque As String       'Utilizado solo para mostrar en grillas. No se persiste.
   Public Property Observacion As String

   Public Property ImporteDias As Decimal

#End Region

End Class