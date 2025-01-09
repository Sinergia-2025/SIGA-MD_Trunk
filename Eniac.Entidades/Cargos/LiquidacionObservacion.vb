<Serializable()>
Public Class LiquidacionObservacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      PeriodoLiquidacion
      'IdLiquidacionCargo
      IdCliente
      Linea
      Observacion
      IdTipoLiquidacion
   End Enum

#Region "Campos"

   'Private _IdSucursal As Integer
   Private _PeriodoLiquidacion As Integer
   'Private _IdLiquidacionCargo As Integer
   Private _IdCliente As Long
   Private _Linea As Integer
   Private _Observacion As String
   Private _IdTipoLiquidacion As Integer

#End Region

#Region "Propiedades"

   'Public Property IdSucursal() As Integer
   '   Get
   '      Return _IdSucursal
   '   End Get
   '   Set(ByVal value As Integer)
   '      _IdSucursal = value
   '   End Set
   'End Property
   Public Property PeriodoLiquidacion() As Integer
      Get
         Return _PeriodoLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._PeriodoLiquidacion = value
      End Set
   End Property
   'Public Property IdLiquidacionCargo() As Integer
   '   Get
   '      Return _IdLiquidacionCargo
   '   End Get
   '   Set(ByVal value As Integer)
   '      _IdLiquidacionCargo = value
   '   End Set
   'End Property
   Public Property IdCliente() As Long
      Get
         Return _IdCliente
      End Get
      Set(ByVal value As Long)
         _IdCliente = value
      End Set
   End Property
   Public Property Linea() As Integer
      Get
         Return Me._Linea
      End Get
      Set(ByVal value As Integer)
         Me._Linea = value
      End Set
   End Property
   Public Property Observacion() As String
      Get
         Return Me._Observacion
      End Get
      Set(ByVal value As String)
         Me._Observacion = value
      End Set
   End Property

   Public Property IdTipoLiquidacion() As Integer
      Get
         Return Me._IdTipoLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._IdTipoLiquidacion = value
      End Set
   End Property
#End Region

End Class