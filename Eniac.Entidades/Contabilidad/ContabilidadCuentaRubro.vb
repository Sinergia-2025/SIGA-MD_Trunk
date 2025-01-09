<Serializable()>
<Description("ContabilidadCuentaRubro")>
Public Class ContabilidadCuentaRubro
   Inherits Entidad

   Public Const NombreTabla As String = "ContabilidadCuentasRubros"

   'Public _grillaCuentas As DataTable

   Public Enum Columnas
      IdPlanCuenta
      'GrillaCuentas
      IdCuenta
      IdRubro
      Tipo
      CentroEmisor

   End Enum

   Public Property IdRubro As Integer
   Public Property Tipo As String
   Public Property IdPlanCuenta As Integer
   Public Property IdCuenta As Long
   Public Property CentroEmisor As Integer

   ''Public Property OtrosCentroEmisores As List(Of ContabilidadCuentaRubro)


   'Public Property grillaCuentas() As DataTable
   '   Get
   '      Return _grillaCuentas
   '   End Get
   '   Set(value As DataTable)
   '      _grillaCuentas = value
   '   End Set
   'End Property

End Class