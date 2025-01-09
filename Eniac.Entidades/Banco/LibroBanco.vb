<Serializable()>
Public Class LibroBanco
   Inherits Entidad
   Public Const NombreTabla As String = "LibrosBancos"

   Public Enum Columnas
      IdSucursal
      IdCuentaBancaria
      NumeroMovimiento
      IdCuentaBanco
      IdTipoMovimiento
      Importe
      FechaMovimiento
      FechaAplicado
      Observacion
      Conciliado
      NumeroChequeAnterior
      IdBancoChequeAnterior
      IdBancoSucursalChequeAnterior
      IdLocalidadChequeAnterior
      IdEjercicio
      IdPlanCuenta
      IdAsiento
      EsModificable
      IdCentroCosto
      GeneraContabilidad
      IdTipoComprobante
      NumeroDeposito
      IdCheque
      FechaActualizacionAsiento
      IdConceptoCM05

   End Enum

#Region "Constructores"

   Public Sub New()
   End Sub
   Public Sub New(idSucursal As Integer, usuario As String, pwd As String)
      Me.New()
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Me.Password = pwd
   End Sub

#End Region

#Region "Propiedades"
   Public Property IdCuentaBancaria() As Integer
   Public Property NumeroMovimiento() As Integer
   Public Property IdCuentaBanco() As Integer
   Public Property IdTipoMovimiento() As String
   Public Property Importe() As Decimal
   Public Property FechaMovimiento() As Date

   '# PK Anterior
   ''''Public Property NumeroCheque() As Integer
   ''''Public Property IdBancoCheque() As Integer
   ''''Public Property IdBancoSucursalCheque() As Integer
   ''''Public Property IdLocalidadCheque() As Integer

   '# Nueva PK
   Public Property IdCheque As Long?

   Public Property FechaAplicado() As Date
   Public Property Observacion() As String
   Public Property Conciliado() As Boolean
   Public Property DescCuentaBancaria() As String
   Public Property DescCheque() As String
   Public Property NombreCuentaBanco() As String

   Public Property EsModificable() As Boolean
   Public Property GeneraContabilidad As Boolean

   Public Property IdEjercicio As Integer?
   Public Property IdPlanCuenta As Integer?
   Public Property IdAsiento As Integer?
   Public Property CentroCosto As ContabilidadCentroCosto
   Public Property IdTipoComprobante As String
   Public Property NumeroDeposito As Long?
   Public Property FechaActualizacionAsiento As Date
   Public Property IdConceptoCM05 As Integer?

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
   Public Enum TiposFechasLibrosBancos
      <Description("Fecha de Aplicación")> FechaAplicacion
      <Description("Fecha de Movimiento")> FechaMovimiento
      <Description("Fecha de Actualización")> FechaActualizacion
   End Enum
End Class
