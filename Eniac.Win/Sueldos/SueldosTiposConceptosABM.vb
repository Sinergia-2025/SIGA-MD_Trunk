Option Strict Off
Public Class SueldosTiposConceptosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.tsbNuevo.Visible = False
      Me.tsbBorrar.Visible = False
      Me.BotonImprimir.Visible = False

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosTiposConceptosDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosTipoConcepto))
      End If
      Return New SueldosTiposConceptosDetalle(New Entidades.SueldosTipoConcepto)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosTiposConceptos()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.SueldosTiposConceptos.rdlc", "DSReportes_SueldosTiposConceptos", Me.dtDatos, True)
         frmImprime.Text = "Sueldos Categorias"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim zona As Entidades.SueldosTipoConcepto = New Entidades.SueldosTipoConcepto()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         zona.idTipoConcepto = .Cells(Entidades.SueldosTipoConcepto.Columnas.idTipoConcepto.ToString()).Value.ToString()
         zona.NombreTipoConcepto = .Cells(Entidades.SueldosTipoConcepto.Columnas.NombreTipoConcepto.ToString()).Value.ToString()
         zona.Orden = Integer.Parse(.Cells(Entidades.SueldosTipoConcepto.Columnas.Orden.ToString()).Value.ToString())
      End With
      Return zona
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns(Entidades.SueldosTipoConcepto.Columnas.idTipoConcepto.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosTipoConcepto.Columnas.idTipoConcepto.ToString()).Width = 70
         .Columns(Entidades.SueldosTipoConcepto.Columnas.idTipoConcepto.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosTipoConcepto.Columnas.NombreTipoConcepto.ToString()).HeaderText = "Nombre de Tipo de Concepto"
         .Columns(Entidades.SueldosTipoConcepto.Columnas.NombreTipoConcepto.ToString()).Width = 120
         .Columns(Entidades.SueldosTipoConcepto.Columnas.NombreTipoConcepto.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns(Entidades.SueldosTipoConcepto.Columnas.Tipo.ToString()).HeaderText = "Tipo"
         .Columns(Entidades.SueldosTipoConcepto.Columnas.Tipo.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoConcepto.Columnas.Tipo.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns(Entidades.SueldosTipoConcepto.Columnas.Orden.ToString()).HeaderText = "Orden"
         .Columns(Entidades.SueldosTipoConcepto.Columnas.Orden.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoConcepto.Columnas.Orden.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      End With
   End Sub

#End Region

End Class
