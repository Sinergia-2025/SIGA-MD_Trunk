Option Strict On
Option Explicit On
Public Class ComboBoxHelper
   Public Shared Function GetVendedorCombo(combo As ComboBox, vendedor As Entidades.Empleado) As Object
      Return GetVendedorCombo(combo, vendedor.IdEmpleado)
   End Function
   Public Shared Function GetVendedorCombo(combo As ComboBox, Id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(combo.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If Id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function
   Public Shared Sub SetVendedorCombo(combo As ComboBox, vendedor As Entidades.Empleado)
      combo.SelectedItem = GetVendedorCombo(combo, vendedor.IdEmpleado)
   End Sub
   Public Shared Sub SetVendedorCombo(combo As ComboBox, id As Integer)
      combo.SelectedItem = GetVendedorCombo(combo, id)
   End Sub
End Class