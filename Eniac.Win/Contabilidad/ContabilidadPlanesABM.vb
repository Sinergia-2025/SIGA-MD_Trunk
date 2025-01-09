
Option Explicit On
Option Strict On

'Imports Eniac.SiPrueba.Win
Imports Eniac.Win
Public Class ContabilidadPlanesABM


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   ' Protected Overrides Sub Borrar()

   '     'If Integer.Parse(Me.dgvDatos.SelectedCells(0).OwningRow.Cells(Entidades.CentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString) = 1 Then
   '     '    MessageBox.Show("Este centro de costo no se puede eliminar", "Centro Costo", MessageBoxButtons.OK, MessageBoxIcon.Information)

   '     If ValidarPlan(Integer.Parse(Me.dgvDatos.SelectedCells(0).OwningRow.Cells(Entidades.CentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString)) Then
   '         MessageBox.Show("Este Plan tiene cuentas contables asociadas. No se puede eliminar", "Plan Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
   '     Else
   '         MyBase.Borrar()
   '     End If

   'End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContabilidadPlanesDetalle(DirectCast(Me.GetEntidad(), Entidades.ContabilidadPlan))
      End If
      Return New ContabilidadPlanesDetalle(New Entidades.ContabilidadPlan)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadPlanes()
   End Function

   'Protected Overrides Sub Imprimir()
   '    MyBase.Imprimir()
   '    Try
   '        Me.Cursor = Cursors.WaitCursor
   '        Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '        parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))

   '        Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiPrueba.Win.MarcasVehiculos.rdlc", "SistemaDataSet_MarcasVehiculos", Me.dtDatos, parm, True)
   '        frmImprime.Text = Me.Text
   '        frmImprime.Show()
   '        Me.Cursor = Cursors.Default
   '    Catch ex As Exception
   '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '    End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim plan As Entidades.ContabilidadPlan = New Entidades.ContabilidadPlan
      Dim planes As Reglas.ContabilidadPlanes = New Reglas.ContabilidadPlanes()

      With Me.dgvDatos.SelectedCells(0).OwningRow
         plan = planes.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString()).Value.ToString()))
      End With

      Return plan

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString()).HeaderText = "Código Plan"
         .Columns(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString()).Width = 85
         .Columns(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.ContabilidadPlan.Columnas.NombrePlanCuenta.ToString()).HeaderText = "Descripcion Plan"
         .Columns(Entidades.ContabilidadPlan.Columnas.NombrePlanCuenta.ToString()).Width = 250
         .Columns(Entidades.ContabilidadPlan.Columnas.NombrePlanCuenta.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

   Private Function ValidarPlan(ByVal IdPlanCuenta As Integer) As Boolean

      Return New Reglas.ContabilidadPlanes().TieneCuentasAsociadas(IdPlanCuenta)


   End Function


#End Region
End Class