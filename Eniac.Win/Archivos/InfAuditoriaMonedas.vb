Public Class InfAuditoriaMonedas

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _MostrarVendedor As Boolean
   Private _tit As Dictionary(Of String, String)
#End Region

   ' Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      ' ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
   End Sub


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(Sub()
                    Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
                 End Sub)
      Try

         Me._publicos = New Publicos()

         '# Guardo las columnas visibles de la grilla para normalizar las columnas
         _tit = GetColumnasVisiblesGrilla(Me.ugDetalle)

         Me._publicos.CargaComboDesdeEnum(Me.cmbTipoOperacion, GetType(Entidades.OperacionesAuditorias))
         Me.cmbTipoOperacion.SelectedIndex = -1
         'CargaComboDesdeEnum(combo, enumArray, ordenar, valueAsString)
         _publicos.CargaComboMonedas(cmbMonedas)

         Me.RefrescarDatos()

         'GAR: 25/12/2017 - hay que agregar todos los campos o cambiar la logica de diseño (vacio inicial?)

         'Me.CargaGrillaDetalle()

         'Me.FormatearGrilla()


         'Seguridad del campo Vendedor
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         '  Me._MostrarVendedor = oUsuario.TienePermisos("Clientes-MostrarVendedor")

         'If Not Me._MostrarVendedor Then
         '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = True
         '   Me.tsbPreferencias.Visible = False
         'End If


         ' Text = "Informe de Auditoria de " & ModoClienteProspecto.ToString() + "s"


      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfAuditoriaClientes_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
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


         If Me.cmbMonedas.Text.Length > 0 Then
            Filtros = Filtros & " / Moneda: " & Me.cmbMonedas.Text.Trim()
         End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

         'Dim vri As VisorReportesInfra = New VisorReportesInfra()
         'vri.Documento = Me.UltraGridPrintDocument1
         'vri.Name = Me.Text
         'vri.Show()

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

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
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

   Private Sub chbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles chbMoneda.CheckedChanged

      Me.cmbMonedas.Enabled = Me.chbMoneda.Checked
      If Not Me.chbMoneda.Checked Then
         Me.cmbMonedas.SelectedIndex = -1
      Else
         Me.cmbMonedas.SelectedIndex = 0
         Me.cmbMonedas.Focus()
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbMoneda.Checked And cmbMonedas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Moneda aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMonedas.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         ''Solo si filtra por cliente se activa el proceso que marca los cambios entre registros
         'If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
         '   Me.AnalizaCambiosGrilla()
         'End If

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

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.SelectionOverlayColor = SystemColors.Highlight

      With e.Layout.Bands(0)
         .Override.SelectedAppearancesEnabled = DefaultableBoolean.False
         .Override.ActiveAppearancesEnabled = DefaultableBoolean.False
      End With
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatos()

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompleto.Checked = False
      Me.chbMoneda.Checked = False
      Me.chbTipoOperacion.Checked = False
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
            If Long.Parse(row.Cells("IdMoneda").Value.ToString()) = Long.Parse(rowBase.Cells("IdMoneda").Value.ToString()) Then
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

   Private Sub CargaGrillaDetalle()

      Try

         Dim oMonedas As Reglas.Monedas = New Reglas.Monedas()
         Dim IdMoneda As Integer = 0

         If Me.cmbMonedas.SelectedIndex <> -1 Then
            IdMoneda = Integer.Parse(Me.cmbMonedas.SelectedValue.ToString())
         End If

         Dim dtDetalle As DataTable

         dtDetalle = oMonedas.GetAuditoriasMonedas(Me.dtpDesde.Value, Me.dtpHasta.Value, IdMoneda, Me.cmbTipoOperacion.Text)

         Me.ugDetalle.DataSource = dtDetalle
         AjustarColumnasGrilla(Me.ugDetalle, _tit)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()

      'Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"Codigo" + ModoClienteProspecto.ToString(),
      '                                          "Nombre" + ModoClienteProspecto.ToString(),
      '                                          "NombreDeFantasia", "Direccion", "Observacion", "Telefono", "Celular",
      '                                          "CorreoElectronico", "CorreoAdministrativo", "PaginaWeb"})

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

         '------------------------

         .Columns("NombreMoneda").Header.Caption = "Moneda"
         .Columns("NombreMoneda").Width = 180
         .Columns("IdTipoMoneda").Header.Caption = "Tipo Moneda"
         .Columns("IdTipoMoneda").Width = 60
         .Columns("OperadorConversion").Header.Caption = "Op. Conversion"
         .Columns("OperadorConversion").Width = 60
         .Columns("FactorConversion").Header.Caption = "Factor Conversion"
         .Columns("FactorConversion").Width = 60
         .Columns("Simbolo").Header.Caption = "Simbolo"
         .Columns("Simbolo").Width = 50
         .Columns("IdBanco").Hidden = True

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


End Class