Imports Eniac.Win

Public Class SueldosObraSocialABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosObraSocialDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosObraSocial))
      End If
      Return New SueldosObraSocialDetalle(New Entidades.SueldosObraSocial)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosObraSocial()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.SueldosObraSocial.rdlc", "DSReportes_SueldosObraSocial", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Sueldos Categorias"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ent As Entidades.SueldosObraSocial = New Entidades.SueldosObraSocial()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         ent.idObraSocial = Integer.Parse(.Cells(Entidades.SueldosObraSocial.Columnas.idObraSocial.ToString()).Value.ToString())
         ent.NombreObraSocial = .Cells(Entidades.SueldosObraSocial.Columnas.NombreObraSocial.ToString()).Value.ToString()
      End With
      Return ent
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns(Entidades.SueldosObraSocial.Columnas.idObraSocial.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosObraSocial.Columnas.idObraSocial.ToString()).Width = 70
         .Columns(Entidades.SueldosObraSocial.Columnas.idObraSocial.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosObraSocial.Columnas.NombreObraSocial.ToString()).HeaderText = "Nombre Obra Social"
         .Columns(Entidades.SueldosObraSocial.Columnas.NombreObraSocial.ToString()).Width = 120
         .Columns(Entidades.SueldosObraSocial.Columnas.NombreObraSocial.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class
