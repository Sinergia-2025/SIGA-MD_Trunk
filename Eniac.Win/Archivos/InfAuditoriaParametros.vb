Public Class InfAuditoriaParametros
#Region "Campos"
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   'Private _MostrarVendedor As Boolean
   Private _tit As Dictionary(Of String, String)
#End Region


#Region "Overrides"
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)

      Me.ugDetalle.AgregarFiltroEnLinea({"IdParametro"})

      Try

         Me._publicos = New Publicos()

         '# Guardo las columnas visibles de la grilla para normalizar las columnas
         _tit = GetColumnasVisiblesGrilla(Me.ugDetalle)

         Me.RefrescarDatos()

         Me.CargarGrillaDetalle()

         Me._publicos.CargaComboDesdeEnum(Me.cmbTipoOperacion, GetType(Entidades.OperacionesAuditorias))
         Me.cmbTipoOperacion.SelectedIndex = -1

         Me.FormatearGrilla()


      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region


#Region "Eventos"
   Private Sub InfAuditoriaParametros_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatos()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

         If Me.bscCodigo.Text.Length > 0 Then
            Filtros = Filtros & " / Parametros: " & Me.bscCodigo.Text.Trim() & " - " & Me.bscParametro.Text.Trim()
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
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
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

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
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

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      Dim FechaTemp As Date

      Try
         If chbMesCompleto.Checked Then
            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp
         End If
         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception
         chbMesCompleto.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbParametro_CheckedChanged(sender As Object, e As EventArgs) Handles chbParametro.CheckedChanged
      Me.bscCodigo.Enabled = Me.chbParametro.Checked
      Me.bscParametro.Enabled = Me.chbParametro.Checked

      Me.bscCodigo.Tag = Nothing
      Me.bscCodigo.Text = String.Empty
      Me.bscParametro.Text = String.Empty

      Me.bscCodigo.Focus()
   End Sub

   Private Sub bscCodigoParametro_BuscadorClick() Handles bscCodigo.BuscadorClick
      Try
         Dim rParametro As Reglas.Parametros = New Reglas.Parametros
         'Dim uEmpresa As Entidades.Usuario.Actual = New Entidades.Usuario.Actual
         Me._publicos.PreparaGrillaParametros2(Me.bscCodigo)
         'actual.Sucursal.IdEmpresa
         Me.bscCodigo.Datos = rParametro.GetPorCodigo(If(IsNumeric(txtIdEmpresa.Text), Integer.Parse(txtIdEmpresa.Text), 0),
                                                      Me.bscParametro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoParametro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosParametros(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscParametro_BuscadorClick() Handles bscParametro.BuscadorClick
      Try
         Dim rParametro As Reglas.Parametros = New Reglas.Parametros
         Me._publicos.PreparaGrillaParametros2(Me.bscParametro)
         Me.bscParametro.Datos = rParametro.GetPorNombre(If(IsNumeric(txtIdEmpresa.Text), Integer.Parse(txtIdEmpresa.Text), 0),
                                                         Me.bscParametro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscParametro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscParametro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosParametros(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If Me.chbParametro.Checked And Not (Me.bscCodigo.Selecciono Or Me.bscParametro.Selecciono) Then
            MessageBox.Show("ATENCION: No seleccionó un Parametro aunque activó ese filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigo.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargarGrillaDetalle()

         Me.AnalizaCambiosGrilla()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkExpandAll_Click(sender As Object, e As EventArgs) Handles chkExpandAll.Click
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.SelectionOverlayColor = SystemColors.Highlight

      With e.Layout.Bands(0)
         .Override.SelectedAppearancesEnabled = DefaultableBoolean.False
         .Override.ActiveAppearancesEnabled = DefaultableBoolean.False
      End With
   End Sub
   Private Sub chbTipoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoOperacion.CheckedChanged
      Me.cmbTipoOperacion.Enabled = Me.chbTipoOperacion.Checked
      If Not Me.chbTipoOperacion.Checked Then
         Me.cmbTipoOperacion.SelectedIndex = -1
      Else
         Me.cmbTipoOperacion.SelectedIndex = 0
         Me.cmbTipoOperacion.Focus()
      End If
   End Sub
#End Region


#Region "Metodos"
   Private Sub RefrescarDatos()

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompleto.Checked = False
      Me.chbParametro.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()
   End Sub

   Private Sub AnalizaCambiosGrilla()
      Dim row As UltraGridRow
      Dim rowBase As UltraGridRow = Nothing
      Dim i As Integer = 0

      For Each row In Me.ugDetalle.Rows.GetRowEnumerator(GridRowType.DataRow, Nothing, Nothing)
         If i = 0 Then
            i = 1
            rowBase = row
         Else
            If row.Cells("IdParametro").ToString() = rowBase.Cells("IdParametro").ToString() Then
               For Each col As UltraGridCell In rowBase.Cells
                  If col.Column.Key <> "FechaAuditoria" AndAlso col.Column.Key <> "OperacionAuditoria" AndAlso col.Column.Key <> "UsuarioAuditoria" Then
                     If rowBase.Cells(col.Column).Value.ToString() <> row.Cells(col.Column).Value.ToString() Then
                        row.Cells(col.Column).Appearance.BackColor = Color.SkyBlue
                     End If
                  End If
               Next
            End If
            rowBase = row
         End If

         Select Case rowBase.Cells("OperacionAuditoria").Value.ToString()
            Case "A"
               rowBase.Cells("Modificado").Appearance.BackColor = Color.Green
            Case "M"
               rowBase.Cells("Modificado").Appearance.BackColor = Color.Yellow
            Case "B"
               rowBase.Cells("Modificado").Appearance.BackColor = Color.Red
         End Select

      Next row
   End Sub

   Private Sub CargarGrillaDetalle()
      Try

         Dim rParametros As Reglas.Parametros = New Reglas.Parametros()
         Dim IdParametro As String = ""

         If Me.bscCodigo.Text IsNot Nothing Then
            IdParametro = Me.bscCodigo.Text.ToString()
         End If

         Dim dtDetalle As DataTable

         dtDetalle = rParametros.GetAuditoriasParametros(Me.dtpDesde.Value, Me.dtpHasta.Value, IdParametro, Me.cmbTipoOperacion.Text)

         Me.ugDetalle.DataSource = dtDetalle
         AjustarColumnasGrilla(Me.ugDetalle, _tit)
         '
         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub FormatearGrilla()
      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("Modificado").Header.Caption = String.Empty
         .Columns("Modificado").Width = 30
         .Columns("FechaAuditoria").Header.Caption = "Fecha"
         .Columns("FechaAuditoria").Width = 100
         .Columns("FechaAuditoria").Format = "dd/MM/yyyy HH:mm"
         .Columns("FechaAuditoria").CellAppearance.TextHAlign = HAlign.Center
         .Columns("OperacionAuditoria").Header.Caption = "Tipo"
         .Columns("OperacionAuditoria").Width = 40
         .Columns("OperacionAuditoria").CellAppearance.TextHAlign = HAlign.Center
         .Columns("UsuarioAuditoria").Header.Caption = "Usuario"
         .Columns("UsuarioAuditoria").Width = 70

         '-------------------------------------------------------------------------
         .Columns("IdEmpresa").Header.Caption = "Codigo"
         .Columns("IdEmpresa").Width = 100
         .Columns("IdEmpresa").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdParametro").Header.Caption = "Parametro"
         .Columns("IdParametro").Width = 250
         .Columns("IdParametro").CellAppearance.TextHAlign = HAlign.Left
         .Columns("ValorParametro").Header.Caption = "Valor"
         .Columns("ValorParametro").Width = 80
         .Columns("ValorParametro").CellAppearance.TextHAlign = HAlign.Left
         .Columns("CategoriaParametro").Header.Caption = "Categoria"
         .Columns("CategoriaParametro").Width = 100
         .Columns("CategoriaParametro").CellAppearance.TextHAlign = HAlign.Left
         .Columns("DescripcionParametro").Header.Caption = "Descripcion"
         .Columns("DescripcionParametro").Width = 250
         .Columns("DescripcionParametro").CellAppearance.TextHAlign = HAlign.Left
      End With
   End Sub

   Private Sub CargarDatosParametros(ByVal dr As DataGridViewRow)
      Me.bscParametro.Text = dr.Cells("DescripcionParametro").Value.ToString()
      Me.bscCodigo.Text = dr.Cells("IdParametro").Value.ToString()
      'Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString() deberia ir?
      Me.bscParametro.Enabled = False
      Me.bscCodigo.Enabled = False
   End Sub



#End Region

End Class