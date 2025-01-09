Imports System.ComponentModel

<Serializable()> _
Public Class Liquidacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      PeriodoLiquidacion
      FechaLiquidacion
      TotalExpensas
      TotalAlquiler
      TotalServicios
      TotalGastosAdmin
      TotalLiquidacion
      FechaFacturado
      TotalAlquilerAnterior
      TotalGastosOperativos
      TotalGastosNoGravado
      TotalGastosIVA105
      TotalGastosNeto105
      TotalGastosIVA210
      TotalGastosNeto210
      TotalGastosIVA270
      TotalGastosNeto270
   End Enum

   Public Enum TipoLiquidacion
      Unica
      Opcional
      <Browsable(False)>
      Unificado
   End Enum

#Region "Propiedades"

   Private _PeriodoLiquidacion As Integer

   Public Property PeriodoLiquidacion() As Integer
      Get
         Return Me._PeriodoLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._PeriodoLiquidacion = value
      End Set
   End Property

   Private _fechaLiquidacion As Date

   Public Property FechaLiquidacion() As Date
      Get
         Return Me._fechaLiquidacion
      End Get
      Set(ByVal value As Date)
         Me._fechaLiquidacion = value
      End Set
   End Property

   Private _totalExpensas As Decimal

   Public Property TotalExpensas() As Decimal
      Get
         Return Me._totalExpensas
      End Get
      Set(ByVal value As Decimal)
         Me._totalExpensas = value
      End Set
   End Property

   Private _totalAlquiler As Decimal

   Public Property TotalAlquiler() As Decimal
      Get
         Return Me._totalAlquiler
      End Get
      Set(ByVal value As Decimal)
         Me._totalAlquiler = value
      End Set
   End Property

   Private _totalServicios As Decimal

   Public Property TotalServicios() As Decimal
      Get
         Return Me._totalServicios
      End Get
      Set(ByVal value As Decimal)
         Me._totalServicios = value
      End Set
   End Property

   Private _totalGastosAdmin As Decimal

   Public Property TotalGastosAdmin() As Decimal
      Get
         Return Me._totalGastosAdmin
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosAdmin = value
      End Set
   End Property

   Private _totalLiquidacion As Decimal

   Public Property TotalLiquidacion() As Decimal
      Get
         Return Me._totalLiquidacion
      End Get
      Set(ByVal value As Decimal)
         Me._totalLiquidacion = value
      End Set
   End Property

   Private _fechaFacturado As Date

   Public Property FechaFacturado() As Date
      Get
         Return Me._fechaFacturado
      End Get
      Set(ByVal value As Date)
         Me._fechaFacturado = value
      End Set
   End Property

   Public Property FechaFacturadoExpensas() As Date

   Private _totalAlquilerAnterior As Decimal

   Public Property TotalAlquilerAnterior() As Decimal
      Get
         Return Me._totalAlquilerAnterior
      End Get
      Set(ByVal value As Decimal)
         Me._totalAlquilerAnterior = value
      End Set
   End Property

   Private _totalGastosOperativos As Decimal

   Public Property TotalGastosOperativos() As Decimal
      Get
         Return Me._totalGastosOperativos
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosOperativos = value
      End Set
   End Property

  
   Private _totalGastosNoGravado As Decimal

   Public Property TotalGastosNoGravado() As Decimal
      Get
         Return Me._totalGastosNoGravado
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosNoGravado = value
      End Set
   End Property

   Private _totalGastosIVA105 As Decimal

   Public Property TotalGastosIVA105() As Decimal
      Get
         Return Me._totalGastosIVA105
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosIVA105 = value
      End Set
   End Property

   Private _totalGastosNeto105 As Decimal

   Public Property TotalGastosNeto105() As Decimal
      Get
         Return Me._totalGastosNeto105
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosNeto105 = value
      End Set
   End Property

   Private _totalGastosIVA210 As Decimal

   Public Property TotalGastosIVA210() As Decimal
      Get
         Return Me._totalGastosIVA210
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosIVA210 = value
      End Set
   End Property

   Private _totalGastosNeto210 As Decimal

   Public Property TotalGastosNeto210() As Decimal
      Get
         Return Me._totalGastosNeto210
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosNeto210 = value
      End Set
   End Property

   Private _totalGastosIVA270 As Decimal

   Public Property TotalGastosIVA270() As Decimal
      Get
         Return Me._totalGastosIVA270
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosIVA270 = value
      End Set
   End Property

   Private _totalGastosNeto270 As Decimal

   Public Property TotalGastosNeto270() As Decimal
      Get
         Return Me._totalGastosNeto270
      End Get
      Set(ByVal value As Decimal)
         Me._totalGastosNeto270 = value
      End Set
   End Property

  
#End Region

End Class