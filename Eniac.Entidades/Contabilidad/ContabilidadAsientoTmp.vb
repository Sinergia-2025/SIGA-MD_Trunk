<Serializable()>
<System.ComponentModel.Description("ContabilidadAsientoTmp")>
Public Class ContabilidadAsientoTmp
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdPlanCuenta
      IdAsiento
      NombreAsiento
      FechaAsiento
      IdTipoDoc
      IdEjercicio
      DetallesAsiento
      idSucursal
      SubsiAsiento
      IdEjercicioDefinitivo
      IdPlanCuentaDefinitivo
      IdAsientoDefinitivo
   End Enum

   Public Sub New()
      SubsiAsiento = String.Empty
   End Sub

   'Public Overloads Property idSucursal As Integer
   Public Property IdPlanCuenta As Integer
   Public Property IdAsiento As Integer
   Public Property NombreAsiento As String
   Public Property FechaAsiento As DateTime
   Public Property IdTipoDoc As Integer
   Public Property IdEjercicio As Integer
   Public Property SubsiAsiento As String

   Public Property IdEjercicioDefinitivo As Integer?
   Public Property IdPlanCuentaDefinitivo As Integer?
   Public Property IdAsientoDefinitivo As Integer?


   Public Property DetallesAsiento As DataTable

End Class