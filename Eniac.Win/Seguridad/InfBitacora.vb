Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class InfBitacora

#Region "Campos"

   Private _publicos As Publicos

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         _tit = New Dictionary(Of String, String)()
         For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
            If Not col.Hidden Then
               _tit.Add(col.Key, String.Empty)
            End If
         Next

         Me._publicos = New Publicos()


         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)
         _publicos.CargaComboDesdeEnum(cmbTipoBitacora, GetType(Entidades.Bitacora.TipoBitacora))
         cmbTipoBitacora.SelectedIndex = -1

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {Entidades.Bitacora.Columnas.Descripcion.ToString(),
                                                          Entidades.Bitacora.Columnas.IdFuncion.ToString(),
                                                          Entidades.Bitacora.Columnas.Nombre.ToString()})

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbUsuario.Checked = False
      Me.chbDescripcion.Checked = False
      Me.chbFuncion.Checked = False
      Me.chbNombrePC.Checked = False

      If IdUsuario = "" Then
         Me.chbUsuario.Checked = False
      End If

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtDescripcion.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oBitacoras As Reglas.Bitacora = New Reglas.Bitacora()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim IdUsuario As String = String.Empty
      Dim IdFuncion As String = String.Empty
      Dim descripcion As String = String.Empty
      Dim nombrepc As String = String.Empty
      Dim tipoBitacora As Entidades.Bitacora.TipoBitacora? = Nothing

      FechaDesde = Me.dtpDesde.Value
      FechaHasta = Me.dtpHasta.Value

      If Me.chbFuncion.Checked Then
         IdFuncion = Me.bscFuncion.Tag.ToString()
      End If

      If Me.chbDescripcion.Checked Then
         descripcion = Me.txtDescripcion.Text.Trim()
      End If

      If Me.chbNombrePC.Checked Then
         nombrepc = Me.txtNombrePC.Text.Trim()
      End If

      If Me.cmbUsuario.Enabled Then
         IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
      End If

      If chbTipoBitacora.Checked Then
         tipoBitacora = DirectCast(cmbTipoBitacora.SelectedValue, Entidades.Bitacora.TipoBitacora)
      End If

      Dim dtDetalle As DataTable
      ', dt As DataTable, drCl As DataRow

      dtDetalle = oBitacoras.GetAll(actual.Sucursal.Id, FechaDesde, FechaHasta, IdUsuario, IdFuncion, descripcion, nombrepc, tipoBitacora)

      Me.ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla()
      'Me.FormatearGrilla()

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

#End Region

#Region "Eventos"
   Private Sub Bitacora_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbNombrePC.Checked Then
            Filtros = Filtros & " / Equipo: " & Me.txtNombrePC.Text
         End If

         If Me.chbFuncion.Checked Then
            Filtros = Filtros & " / Función: " & Me.bscFuncion.Text
         End If

         If Me.chbDescripcion.Checked Then
            Filtros = Filtros & " / Descripción: " & Me.txtDescripcion.Text
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         Me.chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescripcion.CheckedChanged

      Me.txtDescripcion.Enabled = Me.chbDescripcion.Checked

      'Cuando quito el check de la descripcion, limpio la ingresada (hipoteticamente)
      If Not Me.chbDescripcion.Checked Then
         Me.txtDescripcion.Text = String.Empty
      End If
   End Sub

   Private Sub chbFuncion_CheckedChanged(sender As Object, e As EventArgs) Handles chbFuncion.CheckedChanged
      Me.bscFuncion.Enabled = Me.chbFuncion.Checked

      'Cuando quito el check de la funcion, limpio la ingresada (hipoteticamente)
      If Not Me.chbFuncion.Checked Then
         Me.bscFuncion.Text = String.Empty
         Me.bscFuncion.Tag = Nothing
      End If
   End Sub

   Private Sub chbNombrePC_CheckedChanged(sender As Object, e As EventArgs) Handles chbNombrePC.CheckedChanged
      Me.txtNombrePC.Enabled = Me.chbNombrePC.Checked

      'Cuando quito el check del nombre, limpio lo ingresado (hipoteticamente)
      If Not Me.chbNombrePC.Checked Then
         Me.txtNombrePC.Text = String.Empty
      End If
   End Sub

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbTipoBitacora_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoBitacora.CheckedChanged
      Try
         Me.cmbTipoBitacora.Enabled = Me.chbTipoBitacora.Checked

         If Not Me.chbTipoBitacora.Checked Then
            Me.cmbTipoBitacora.SelectedIndex = -1
         Else
            If Me.cmbTipoBitacora.Items.Count > 0 Then
               Me.cmbTipoBitacora.SelectedIndex = 0
            End If
         End If

         Me.cmbTipoBitacora.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbUsuario.Checked And Me.cmbUsuario.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un USUARIO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbUsuario.Focus()
            Exit Sub
         End If

         If Me.chbDescripcion.Checked AndAlso String.IsNullOrWhiteSpace(Me.txtDescripcion.Text) Then
            MessageBox.Show("ATENCION: NO ingresó una Descripción aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescripcion.Focus()
            Exit Sub
         End If

         If Me.chbFuncion.Checked AndAlso String.IsNullOrWhiteSpace(Me.bscFuncion.Text) Then
            MessageBox.Show("ATENCION: NO ingresó una Función aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            bscFuncion.Focus()
            Exit Sub
         End If

         If Me.chbNombrePC.Checked AndAlso String.IsNullOrWhiteSpace(Me.txtNombrePC.Text) Then
            MessageBox.Show("ATENCION: NO ingresó un Nombre de PC aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNombrePC.Focus()
            Exit Sub
         End If

         If Me.chbTipoBitacora.Checked AndAlso cmbTipoBitacora.SelectedValue Is Nothing Then
            MessageBox.Show("ATENCION: NO ingresó un Tipo de Bitacora aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbTipoBitacora.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub bscFuncion_BuscadorClick() Handles bscFuncion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscFuncion)
         Me.bscFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, Me.bscFuncion.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscFuncion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscFuncion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosFuncion(ByVal dr As DataGridViewRow)
      Me.bscFuncion.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscFuncion.Tag = dr.Cells("Id").Value.ToString().Trim()
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.SingleBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
   End Sub

#End Region

   Private Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
         col.Hidden = Not _tit.ContainsKey(col.Key)
         If _tit.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(_tit(col.Key)) Then
               col.Header.Caption = _tit(col.Key)
            End If
         End If
      Next
   End Sub

End Class
