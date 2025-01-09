<Serializable()>
Public Class CuentaBancaria
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdBancoSucursal
      IdCuentaBancaria
      CodigoBancario
      IdCuentaBancariaClase
      TieneChequera
      IdMoneda
      IdBanco
      IdLocalidad
      Saldo
      SaldoConfirmado
      NombreCuenta
      Activo
      IdPlanCuenta
      IdCuentaContable
      Cbu
      CbuAlias
      ParaInformarEnFEC
      IdEmpresa

   End Enum

   Public Property IdCuentaBancaria As Integer
   Public Property NombreCuenta As String
   Public Property CodigoBancario As String
   Public Property TieneChequera As Boolean

   Private _cuentaBancariaClase As Entidades.CuentaBancariaClase
   Public Property CuentaBancariaClase() As Entidades.CuentaBancariaClase
      Get
         If Me._cuentaBancariaClase Is Nothing Then
            Me._cuentaBancariaClase = New Entidades.CuentaBancariaClase()
         End If
         Return _cuentaBancariaClase
      End Get
      Set(ByVal value As Entidades.CuentaBancariaClase)
         _cuentaBancariaClase = value
      End Set
   End Property
   Private _moneda As Entidades.Moneda
   Public Property Moneda() As Entidades.Moneda
      Get
         If Me._moneda Is Nothing Then
            Me._moneda = New Entidades.Moneda()
         End If
         Return _moneda
      End Get
      Set(ByVal value As Entidades.Moneda)
         _moneda = value
      End Set
   End Property
   Private _banco As Entidades.Banco
   Public Property Banco() As Entidades.Banco
      Get
         If Me._banco Is Nothing Then
            Me._banco = New Entidades.Banco()
         End If
         Return _banco
      End Get
      Set(ByVal value As Entidades.Banco)
         _banco = value
      End Set
   End Property
   Private _localidad As Entidades.Localidad
   Public Property Localidad() As Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Entidades.Localidad()
         End If
         Return _localidad
      End Get
      Set(ByVal value As Entidades.Localidad)
         _localidad = value
      End Set
   End Property

   Public Property Saldo As Decimal
   Public Property SaldoConfirmado As Decimal
   Public Property IdBancoSucursal As Integer
   Public Property Activo As Boolean = False

   'vml 04/02/13 - contabilidad
   Public Property idPlanCuenta As Integer
   Public Property idCuentaContable As Integer
   'vml 04/02/13 - contabilidad

   '09/02/17 - cbu
   Public Property Cbu As String
   Public Property CbuAlias As String
   '09/02/17 - cbu

   Public Property ParaInformarEnFEC As Boolean

   '-.PE-32476.-
   Public Property IdEmpresa As Integer
End Class