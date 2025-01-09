<Serializable()>
Public Class CargoClienteObservacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdCliente
      Linea
      Observacion
      IdTipoLiquidacion
   End Enum

#Region "Campos"

   'Private _IdSucursal As Integer
   Private _IdCliente As Long
   'Private _IdCargo As Integer
   Private _Linea As Integer
   Private _Observacion As String

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
   Public Property IdCliente() As Long
      Get
         Return _IdCliente
      End Get
      Set(ByVal value As Long)
         Me._IdCliente = value
      End Set
   End Property
   'Public Property IdCargo() As Integer
   '   Get
   '      Return _IdCargo
   '   End Get
   '   Set(ByVal value As Integer)
   '      _IdCargo = value
   '   End Set
   'End Property
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

   Private _idTipoLiquidacion As Integer
   Public Property IdTipoLiquidacion() As Integer
      Get
         Return _idTipoLiquidacion
      End Get
      Set(ByVal value As Integer)
         _idTipoLiquidacion = value
      End Set
   End Property

#End Region

End Class