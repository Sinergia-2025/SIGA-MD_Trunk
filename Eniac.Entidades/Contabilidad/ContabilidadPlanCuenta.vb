<Serializable()>
<Description("ContabilidadPlanCuenta")>
Public Class ContabilidadPlanCuenta
   Inherits Eniac.Entidades.Entidad

   Private _idPlanCuenta As Integer
   Public _grillaCuentas As DataTable
   Public _idCuenta As Long

   Public Enum Columnas
      IdPlanCuenta
      GrillaCuentas
      IdCuenta
   End Enum

   Public Property IdPlanCuenta() As Integer
      Get
         Return _idPlanCuenta
      End Get
      Set(ByVal value As Integer)
         _idPlanCuenta = value
      End Set
   End Property

   Public Property IdCuenta() As Long
      Get
         Return _idCuenta
      End Get
      Set(ByVal value As Long)
         _idCuenta = value
      End Set
   End Property

   'Public Property IdCentroCosto() As Integer
   '   Get
   '      Return _idCentroCosto
   '   End Get
   '   Set(ByVal value As Integer)
   '      _idCentroCosto = value
   '   End Set
   'End Property

   'Public Property NombrePlanCuenta() As String
   '   Get
   '      Return _nombrePlanCuenta
   '   End Get
   '   Set(ByVal value As String)
   '      _nombrePlanCuenta = value
   '   End Set
   'End Property

   Public Property grillaCuentas() As DataTable
      Get
         Return _grillaCuentas
      End Get
      Set(ByVal value As DataTable)
         _grillaCuentas = value
      End Set
   End Property

End Class