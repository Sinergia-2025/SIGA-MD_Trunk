Imports Eniac.Win

Public Class SueldosCategoriasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosCategoriasDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosCategoria))
      End If
      Return New SueldosCategoriasDetalle(New Entidades.SueldosCategoria)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosCategorias()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.SueldosCategorias.rdlc", "DSReportes_SueldosCategorias", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Sueldos Categorias"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ent As Entidades.SueldosCategoria = New Entidades.SueldosCategoria()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         ent.idCategoria = Integer.Parse(.Cells(Entidades.SueldosCategoria.Columnas.idCategoria.ToString()).Value.ToString())
         ent.NombreCategoria = .Cells(Entidades.SueldosCategoria.Columnas.NombreCategoria.ToString()).Value.ToString()
      End With
      Return ent
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns(Entidades.SueldosCategoria.Columnas.idCategoria.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosCategoria.Columnas.idCategoria.ToString()).Width = 70
         .Columns(Entidades.SueldosCategoria.Columnas.idCategoria.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosCategoria.Columnas.NombreCategoria.ToString()).HeaderText = "Nombre Categoría"
         .Columns(Entidades.SueldosCategoria.Columnas.NombreCategoria.ToString()).Width = 120
         .Columns(Entidades.SueldosCategoria.Columnas.NombreCategoria.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class
