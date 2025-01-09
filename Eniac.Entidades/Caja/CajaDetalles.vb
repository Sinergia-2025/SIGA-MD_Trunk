<Serializable()>
Public Class CajaDetalles
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdCaja
      NumeroPlanilla
      NumeroMovimiento
      FechaMovimiento
      IdCuentaCaja
      IdTipoMovimiento
      ImportePesos
      ImporteDolares
      ImporteEuros
      ImporteCheques
      ImporteTarjetas
      Observacion
      EsModificable
      ImporteTickets
      IdUsuario
      IdEjercicio
      IdPlanCuenta
      IdAsiento
      ImporteBancos
      ImporteRetenciones
      IdCentroCosto
      GeneraContabilidad
      CotizacionDolar
      IdTipoComprobante
      NumeroDeposito
      IdMonedaImporteBancos
      IdConceptoCM05

   End Enum

   Public Enum FechaConsulta
      Movimiento
      Planilla
   End Enum

   Public Class TipoMovimiento
      Public Const Ingreso As String = "I"
      Public Const Egreso As String = "E"
   End Class

#Region "Constructores"

   Public Sub New()
      IgnoraAcumulaVentas = False
   End Sub

   Public Sub New(idSucursal As Integer, usuario As String, pwd As String)
      Me.New()
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Password = pwd
   End Sub

#End Region

#Region "Propiedades"

   Public Property IdCaja As Integer
   Public Property NumeroPlanilla As Integer
   Public Property NumeroMovimiento As Integer
   Public Property IdCuentaCaja As Integer
   Public Property IdTipoMovimiento As Char
   Public Property FechaMovimiento As Date
   Private _observacion As String
   Public Property Observacion() As String
      Get
         Return _observacion
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            Throw New Exception("La observación no puede tener más de 100 caracteres")
         Else
            Me._observacion = value
         End If
      End Set
   End Property

   Public Property ImportePesos As Decimal
   Public Property ImporteDolares As Decimal
   Public Property ImporteTickets As Decimal
   Public Property ImporteCheques As Decimal
   Public Property ImporteTarjetas As Decimal
   Public Property ImporteBancos As Decimal
   Public Property ImporteRetenciones As Decimal

   Public Property EsModificable As Boolean
   Public Property GeneraContabilidad As Boolean

   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?
   Public Property CentroCosto As ContabilidadCentroCosto
   Public Property CotizacionDolar As Decimal
   Public Property IdTipoComprobante As String
   Public Property NumeroDeposito As Long?
   Public Property IdMonedaImporteBancos As Integer?
   Public Property IdConceptoCM05 As Integer?

   Public Property IgnoraAcumulaVentas As Boolean        ' No se persiste. Solo se tiene en cuenta para proceso de grabación.

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdCentroCosto As Integer?
      Get
         If CentroCosto Is Nothing Then Return Nothing
         Return CentroCosto.IdCentroCosto
      End Get
   End Property
   Public ReadOnly Property NombreCentroCosto As String
      Get
         If CentroCosto Is Nothing Then Return String.Empty
         Return CentroCosto.NombreCentroCosto
      End Get
   End Property
#End Region
#End Region

End Class