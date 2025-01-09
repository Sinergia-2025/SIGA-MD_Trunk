Option Strict Off

Public Class SueldosEstadoCivilABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosEstadoCivilDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosEstadoCivil))
      End If
      Return New SueldosEstadoCivilDetalle(New Entidades.SueldosEstadoCivil)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosEstadoCivil()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.SueldosEstadoCivil.rdlc", "DSReportes_SueldosEstadoCivil", Me.dtDatos, True)
         frmImprime.Text = "Sueldos Categorias"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ent As Entidades.SueldosEstadoCivil = New Entidades.SueldosEstadoCivil()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         ent.idEstadoCivil = .Cells(Entidades.SueldosEstadoCivil.Columnas.idEstadoCivil.ToString()).Value.ToString()
         ent.NombreEstadoCivil = .Cells(Entidades.SueldosEstadoCivil.Columnas.NombreEstadoCivil.ToString()).Value.ToString()
      End With
      Return ent
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns(Entidades.SueldosEstadoCivil.Columnas.idEstadoCivil.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosEstadoCivil.Columnas.idEstadoCivil.ToString()).Width = 70
         .Columns(Entidades.SueldosEstadoCivil.Columnas.idEstadoCivil.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosEstadoCivil.Columnas.NombreEstadoCivil.ToString()).HeaderText = "Nombre Estado Civil"
         .Columns(Entidades.SueldosEstadoCivil.Columnas.NombreEstadoCivil.ToString()).Width = 120
         .Columns(Entidades.SueldosEstadoCivil.Columnas.NombreEstadoCivil.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class
