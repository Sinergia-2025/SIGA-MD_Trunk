<Serializable()>
<System.ComponentModel.Description("ContabilidadPlan")>
Public Class ContabilidadPlan
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdPlanCuenta
      NombrePlanCuenta

   End Enum

   Public Property IdPlanCuenta() As Integer
   Public Property NombrePlanCuenta() As String

End Class
