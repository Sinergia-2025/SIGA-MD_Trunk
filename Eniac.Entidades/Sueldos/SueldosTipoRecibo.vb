<Serializable()> _
Public Class SueldosTipoRecibo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoRecibo
      NombreTipoRecibo
      PeriodoLiquidacion
      NumeroLiquidacion
      ImprimeRecibo
      CantidadLiquid
      CantidadLiquidPeriodo
      FechaPago
      LiquidacionEventual
   End Enum

#Region "Propiedades"

   Private _idTipoRecibo As Integer
   Public Property IdTipoRecibo() As Integer
      Get
         Return Me._idTipoRecibo
      End Get
      Set(ByVal value As Integer)
         Me._idTipoRecibo = value
      End Set
   End Property

   Private _nombreTipoRecibo As String
   Public Property NombreTipoRecibo() As String
      Get
         Return Me._nombreTipoRecibo
      End Get
      Set(ByVal value As String)
         Me._nombreTipoRecibo = value
      End Set
   End Property

   Private _periodoLiquidacion As Integer
   Public Property PeriodoLiquidacion() As Integer
      Get
         Return _periodoLiquidacion
      End Get
      Set(ByVal value As Integer)
         _periodoLiquidacion = value
      End Set
   End Property

   Private _numeroLiquidacion As Integer
   Public Property NumeroLiquidacion() As Integer
      Get
         Return _numeroLiquidacion
      End Get
      Set(ByVal value As Integer)
         _numeroLiquidacion = value
      End Set
   End Property

   Private _imprimeRecibo As Boolean
   Public Property ImprimeRecibo() As Boolean
      Get
         Return _imprimeRecibo
      End Get
      Set(ByVal value As Boolean)
         _imprimeRecibo = value
      End Set
   End Property

   Private _liquidacionEventual As Boolean
   Public Property LiquidacionEventual() As Boolean
      Get
         Return _liquidacionEventual
      End Get
      Set(ByVal value As Boolean)
         _liquidacionEventual = value
      End Set
   End Property

   Private _CantidadLiquid As Integer
   Public Property CantidadLiquid() As Integer
      Get
         Return _CantidadLiquid
      End Get
      Set(ByVal value As Integer)
         _CantidadLiquid = value
      End Set
   End Property

   Private _CantidadLiquidPeriodo As Integer
   Public Property CantidadLiquidPeriodo() As Integer
      Get
         Return _CantidadLiquidPeriodo
      End Get
      Set(ByVal value As Integer)
         _CantidadLiquidPeriodo = value
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

#End Region



End Class
