<Serializable()> _
<Description("ContabilidadAsientoModelo")>
Public Class ContabilidadAsientoModelo
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdPlanCuenta
      NombrePlanCuenta
      IdAsiento
      NombreAsiento
      idCuenta
      NombreCuenta
      DetallesAsiento
   End Enum

   Private _idPlanCuenta As Integer
   Public Property IdPlanCuenta() As Integer
      Get
         Return _idPlanCuenta
      End Get
      Set(ByVal value As Integer)
         _idPlanCuenta = value
      End Set
   End Property

   Private _idAsiento As Integer
   Public Property IdAsiento() As Integer
      Get
         Return _idAsiento
      End Get
      Set(ByVal value As Integer)
         _idAsiento = value
      End Set
   End Property

   Private _nombreAsiento As String
   Public Property NombreAsiento() As String
      Get
         Return _nombreAsiento
      End Get
      Set(ByVal value As String)
         _nombreAsiento = value
      End Set
   End Property



   Private _detallesAsiento As DataTable
   Public Property DetallesAsiento() As DataTable
      Get
         Return _detallesAsiento
      End Get
      Set(ByVal value As DataTable)
         _detallesAsiento = value
      End Set
   End Property


   Private _idCuenta As Integer
   Public Overloads Property idCuenta() As Integer
      Get
         Return _idCuenta
      End Get
      Set(ByVal value As Integer)
         _idCuenta = value
      End Set
   End Property

   Private _NombreCuenta As String
   Public Property NombreCuenta() As String
      Get
         Return _NombreCuenta
      End Get
      Set(ByVal value As String)
         _NombreCuenta = value
      End Set
   End Property

   Private _NombrePlanCuenta As String
   Public Property NombrePlanCuenta() As String
      Get
         Return _NombrePlanCuenta
      End Get
      Set(ByVal value As String)
         _NombrePlanCuenta = value
      End Set
   End Property

End Class