Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class TiposContactosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposContactosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.TipoContacto))
      End If
      Return New TiposContactosDetalle(New Entidades.TipoContacto)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposContactos()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         'Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Modelos.rdlc", "SistemaDataSet_Modelos", Me.dtDatos, parm, True)

         'frmImprime.Text = "Modelos"
         'frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim TipoContacto As Entidades.TipoContacto = New Entidades.TipoContacto
      With Me.dgvDatos.ActiveCell.Row
         TipoContacto.IdTipoContacto = Int32.Parse(.Cells("IdTipoContacto").Value.ToString())
         TipoContacto.NombreTipoContacto = .Cells("NombreTipoContacto").Value.ToString()
         TipoContacto.NombreAbrevTipoContacto = .Cells("NombreAbrevTipoContacto").Value.ToString()
      End With
      Return TipoContacto
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns("IdTipoContacto").Header.Caption = "Código"
         .Columns("IdTipoContacto").Width = 70
         .Columns("IdTipoContacto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NombreTipoContacto").Header.Caption = "Nombre"
         .Columns("NombreTipoContacto").Width = 300
         .Columns("NombreAbrevTipoContacto").Header.Caption = "Abrev"
         .Columns("NombreAbrevTipoContacto").Width = 70
      End With
   End Sub

  
#End Region

End Class
