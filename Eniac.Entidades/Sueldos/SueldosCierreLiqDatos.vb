<Serializable()>
Public Class SueldosCierreLiqDatos

   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idLegajo
      idTipoRecibo
      NroLiquidacion
      FechaPago
      LugarPago
      DomicilioEmpresa
      IdBancoCtaBancaria
      NombreBanco
      IdCuentasBancariasClaseCtaBancaria
      NombreCuentaBancariaClase
      NumeroCuentaBancaria
      CBU
      PeriodoLiquidacion
   End Enum

   Private _idLegajo As Integer
   Public Property idLegajo() As Integer
      Get
         Return Me._idLegajo
      End Get
      Set(ByVal value As Integer)
         Me._idLegajo = value
      End Set
   End Property

   Private _idTipoRecibo As Integer
   Public Property idTipoRecibo() As Integer
      Get
         Return Me._idTipoRecibo
      End Get
      Set(ByVal value As Integer)
         Me._idTipoRecibo = value
      End Set
   End Property

   Private _PeriodoLiquidacion As Integer
   Public Property PeriodoLiquidacion() As Integer
      Get
         Return Me._PeriodoLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._PeriodoLiquidacion = value
      End Set
   End Property

   Private _FechaPago As Date
   Public Property FechaPago() As Date
      Get
         Return Me._FechaPago
      End Get
      Set(ByVal value As Date)
         Me._FechaPago = value
      End Set
   End Property

   Private _LugarPago As String
   Public Property LugarPago() As String
      Get
         Return Me._LugarPago
      End Get
      Set(ByVal value As String)
         Me._LugarPago = value
      End Set
   End Property

   Private _DomicilioEmpresa As String
   Public Property DomicilioEmpresa() As String
      Get
         Return Me._DomicilioEmpresa
      End Get
      Set(ByVal value As String)
         Me._DomicilioEmpresa = value
      End Set
   End Property

   Private _IdBancoCtaBancaria As Integer
   Public Property IdBancoCtaBancaria() As Integer
      Get
         Return Me._IdBancoCtaBancaria
      End Get
      Set(ByVal value As Integer)
         Me._IdBancoCtaBancaria = value
      End Set
   End Property

   Private _NombreBanco As String
   Public Property NombreBanco() As String
      Get
         Return Me._NombreBanco
      End Get
      Set(ByVal value As String)
         Me._NombreBanco = value
      End Set
   End Property

   Private _IdCuentasBancariasClaseCtaBancaria As Integer
   Public Property IdCuentasBancariasClaseCtaBancaria() As Integer
      Get
         Return Me._IdCuentasBancariasClaseCtaBancaria
      End Get
      Set(ByVal value As Integer)
         Me._IdCuentasBancariasClaseCtaBancaria = value
      End Set
   End Property

   Private _NombreCuentaBancariaClase As String
   Public Property NombreCuentaBancariaClase() As String
      Get
         Return Me._NombreCuentaBancariaClase
      End Get
      Set(ByVal value As String)
         Me._NombreCuentaBancariaClase = value
      End Set
   End Property


   Private _NumeroCuentaBancaria As String
   Public Property NumeroCuentaBancaria() As String
      Get
         Return Me._NumeroCuentaBancaria
      End Get
      Set(ByVal value As String)
         Me._NumeroCuentaBancaria = value
      End Set
   End Property

   Private _CBU As Decimal
   Public Property CBU() As Decimal
      Get
         Return Me._CBU
      End Get
      Set(ByVal value As Decimal)
         Me._CBU = value
      End Set
   End Property

   Private _sueldoBasico As Decimal
   Public Property SueldoBasico() As Decimal
      Get
         Return Me._sueldoBasico
      End Get
      Set(ByVal value As Decimal)
         Me._sueldoBasico = value
      End Set
   End Property

   Private _sueldoCategoria As Entidades.SueldosCategoria
   Public Property SueldoCategoria() As Entidades.SueldosCategoria
      Get
         If Me._sueldoCategoria Is Nothing Then
            Me._sueldoCategoria = New Entidades.SueldosCategoria()
         End If
         Return Me._sueldoCategoria
      End Get
      Set(ByVal value As Entidades.SueldosCategoria)
         Me._sueldoCategoria = value
      End Set
   End Property

   Private _NroLiquidacion As Integer
   Public Property NroLiquidacion() As Integer
      Get
         Return Me._NroLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._NroLiquidacion = value
      End Set
   End Property

End Class