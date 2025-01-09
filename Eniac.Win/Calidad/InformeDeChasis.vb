#Region "Option/Imports"
'Option Strict On
Option Explicit On
Imports Infragistics.Documents.Excel
Imports Infragistics.Win.UltraWinGrid.ExcelExport
#End Region
Public Class InformeDeChasis

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _dtDetalle As DataTable
   Private _dtListasDetalle As DataTable
   Private _dtItemsDetalle As DataTable
   Private _dtsMaster_detalle As DataSet
   Private _PermisoEjecucion As Boolean = False
   Private latestRowIndex As Integer = -1
   Private latestColIndex As Integer = -1


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         '_tit = GetColumnasVisiblesGrilla(ugDetalle)
         '_tit1 = GetColumnasVisiblesGrilla(ugDetalle)

         Me._publicos = New Publicos()

         Me.cmbPreEntrega.Items.Insert(0, "TODOS")
         Me.cmbPreEntrega.Items.Insert(1, "NO INICIADO")
         Me.cmbPreEntrega.Items.Insert(2, "EN LINEA")
         Me.cmbPreEntrega.Items.Insert(3, "LIBERADO")
         Me.cmbPreEntrega.Items.Insert(4, "ENTREGADO")

         Me.cmbPreEntrega.SelectedIndex = 0

         Dim n As Integer
         For n = 0 To clbChasis.Items.Count - 1
            clbChasis.SetItemChecked(n, True)
         Next

         Me.dtpDesde.Value = DateTime.Today

         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "CodigoCliente", "NombreCliente", "NombreListaControl", "NombreEstadoCalidad"})

         ugDetalle.ContextMenuStrip = MenuContext

         PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function


#End Region

#Region "Eventos"

#Region "Eventos Buscadores"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCliente.Text = String.Empty
      End If
   End Sub

   Private Sub BscModelo_BuscadorClick() Handles bscModelo.BuscadorClick
      Try
         _publicos.PreparaGrillaModelosProductos(Me.bscModelo)
         Dim oProductosModelos As Reglas.ProductosModelos = New Reglas.ProductosModelos
         Me.bscModelo.Datos = oProductosModelos.GetPorNombre(Me.bscModelo.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub BscModelo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscModelo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosModelo(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = titulo
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
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If chbProducto.Checked AndAlso (Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbCliente.Checked AndAlso (Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbModelo.Checked AndAlso Not bscModelo.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Modelo aunque activó ese Filtro.")
            bscModelo.Focus()
            Exit Sub
         End If

         Me.CargarGrillaDetalle()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#Region "Eventos Filtros"
   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
   End Sub

#End Region

#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp
         Else
            Me.dtpDesde.Value = DateTime.Today

            Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Me.ListasControlPorProducto()
   End Sub

   Private Sub MenuContext_Click(sender As Object, e As EventArgs) Handles MenuContext.Click
      Me.ListasControlPorProducto()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbPreEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPreEntrega.SelectedIndexChanged
      Try

         'Dim Fechas As Boolean = False
         'If cmbPreEntrega.Text = "TODOS" Or cmbPreEntrega.Text = "LIBERADO" Then
         '   Fechas = True
         'End If

         'Me.chkMesCompleto.Enabled = Fechas
         'Me.lblDesde.Enabled = Fechas
         'Me.dtpDesde.Enabled = Fechas
         'Me.dtpHasta.Enabled = Fechas
         'Me.lblHasta.Enabled = Fechas

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub()
                    chkMesCompleto.Enabled = chbFecha.Checked
                    dtpDesde.Enabled = chbFecha.Checked
                    dtpHasta.Enabled = chbFecha.Checked
                 End Sub)
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try

         Select Case e.Row.Cells("Chasis").Value.ToString()
            Case = "NO INICIADOS"
               e.Row.Cells("Chasis").Color(Nothing, Color.LightGreen)
            Case = "EN LINEA"
               e.Row.Cells("Chasis").Color(Nothing, Color.SkyBlue)
            Case = "LIBERADOS"
               e.Row.Cells("Chasis").Color(Nothing, Color.Yellow)
            Case = "LIBERADOS PDI"
               e.Row.Cells("Chasis").Color(Nothing, Color.LightCoral)
            Case = "ENTREGADOS"
               e.Row.Cells("Chasis").Color(Nothing, Color.DarkOrange)
         End Select


      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDetalle.AfterRowFilterChanged
      Try
         Me.tssRegistros.Text = ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcelGrafico_Click(sender As Object, e As EventArgs) Handles tsmiAExcelGrafico.Click
      Try

         Me.sfdExportar.FileName = "EstadosDeChasis.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               latestRowIndex = -1
               latestColIndex = -1

               Dim book As New Workbook()

               Dim ugExcelExporter As New UltraGridExcelExporter()
               AddHandler ugExcelExporter.CellExported, AddressOf ugExcelExporter_CellExported

               Dim s As Worksheet = book.Worksheets.Add("Chart")

               ugExcelExporter.Export(ugDetalle, s)

               Dim ms As New System.IO.MemoryStream()

               UltraChart1.SaveTo(ms, Infragistics.UltraChart.Shared.Styles.RenderingType.Image)

               Dim i As New WorksheetImage(Image.FromStream(ms))

               i.TopLeftCornerCell = s.Rows(0).Cells(latestColIndex + 1)

               i.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

               i.BottomRightCornerCell = s.Rows(20).Cells(latestColIndex + 7)

               i.BottomRightCornerPosition = New PointF(0.0F, 0.0F)

               s.Shapes.Add(i)

               book.Save(Me.sfdExportar.FileName)
               'book.Save("Test.xls")
               ms.Dispose()

               'Process.Start("Test.xls")
               ' Process.Start(Me.sfdExportar.FileName)

               ' Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDFRelacionPromedios_Click(sender As Object, e As EventArgs) Handles tsmiAPDFRelacionPromedios.Click
      Try
         Me.sfdExportar.FileName = "EstadosDeChasis.pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"

         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then

               'UltraChart1.Size = New Size(400, 300)
               Dim report As New Infragistics.Documents.Reports.Report.Report()
               report.Preferences.Printing.PaperSize = Infragistics.Documents.Reports.Report.Preferences.Printing.PaperSize.A4
               report.Preferences.Printing.PaperOrientation = Infragistics.Documents.Reports.Report.Preferences.Printing.PaperOrientation.Landscape

               Dim section As Infragistics.Documents.Reports.Report.Section.ISection = report.AddSection()
               section.PageAlignment.Horizontal = Infragistics.Documents.Reports.Report.Alignment.Center
               'section.PageAlignment.Vertical = Infragistics.Documents.Reports.Report.Alignment.Center
               section.PageOrientation = Infragistics.Documents.Reports.Report.PageOrientation.Landscape
               'section.PagePaddings.Top = 20

               Dim header As Infragistics.Documents.Reports.Report.Section.ISectionHeader = section.AddHeader()

               header.Height = 50

               Dim text As Infragistics.Documents.Reports.Report.Text.IText = header.AddText(0, 150)
               text.Alignment.Horizontal = Infragistics.Documents.Reports.Report.Alignment.Center
               text.Style.Font.Underline = True
               text.Style.Font.Bold = True
               'text.AddContent("Estados de Chasis")

               Dim text2 As Infragistics.Documents.Reports.Report.Text.IText = header.AddText(0, 180)
               text2.Alignment.Horizontal = Infragistics.Documents.Reports.Report.Alignment.Center
               'text2.AddContent("Municipio/Comuna: " & Me.cmbLocalidades.Text + System.Environment.NewLine + System.Environment.NewLine)

               Dim canvas As Infragistics.Documents.Reports.Report.ICanvas = section.AddCanvas()
               canvas.Width = New Infragistics.Documents.Reports.Report.FixedWidth(700)
               canvas.Height = New Infragistics.Documents.Reports.Report.FixedHeight(500)
               'canvas.Margins.Left = 20
               'canvas.Margins.Top = 20
               Dim g As Graphics = canvas.CreateGraphics()
               UltraChart1.RenderPdfFriendlyGraphics(g)

               report.Publish(Me.sfdExportar.FileName, Infragistics.Documents.Reports.Report.FileFormat.PDF)

            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarGrilla()

      Me.chbProducto.Checked = False
      Me.chbCliente.Checked = False
      Me.chbModelo.Checked = False

      Me.dtpDesde.Value = DateTime.Today

      Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chkMesCompleto.Checked = False

      Me.chbFecha.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      Me.cmbPreEntrega.SelectedIndex = 0

      Me.tssRegistros.Text = "0 Registros"

      Dim n As Integer
      For n = 0 To clbChasis.Items.Count - 1
         clbChasis.SetItemChecked(n, True)
      Next

      Me.UltraChart1.Visible = False
      Me.grbFechasUnidad.Visible = False

      Me.btnConsultar.Focus()
   End Sub

   Private Sub CargarGrillaDetalle()

      Dim Estado As Integer = 0
      Dim ListaControl As Integer = 0
      Dim Ubicacion As String = String.Empty

      Dim ChasisEstados As List(Of String) = New List(Of String)()
      Dim entro As Boolean = False
      For n = 0 To clbChasis.Items.Count - 1
         If clbChasis.GetItemChecked(n) = True Then
            ChasisEstados.Add(clbChasis.Items(n).ToString())
            entro = True
         End If
      Next
      If Not entro Then
         ChasisEstados.Add("")
      End If

      _dtListasDetalle = New Reglas.Productos().GetInformeDeChasis(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                ChasisEstados, If(chbModelo.Checked, bscModelo.Tag.ToString().ValorNumericoPorDefecto(0I), 0I),
                                                               Publicos.CalidadBaseExternaClientes)

      Me.ugDetalle.DataSource = _dtListasDetalle

      Me.Graficar()

      If ugDetalle.Rows.Count > 0 Then
         Me.btnConsultar.Focus()

      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub
   Private Sub Graficar()
      Dim NoIniciados As Integer = 0
      Dim EnLInea As Integer = 0
      Dim Liberados As Integer = 0
      '  Dim LiberadosPDI As Integer = 0
      Dim Entregados As Integer = 0
      Dim cant As Integer = 0

      Me.UltraChart1.Visible = True
      Me.grbFechasUnidad.Visible = True
      'Me.UltraChart2.Visible = True

      Dim table As DataTable = New DataTable()

      table.Columns.Add("Label", System.Type.GetType("System.String"))

      table.Columns.Add("NO INICIADOS", System.Type.GetType("System.Int32"))

      table.Columns.Add("EN LINEA", System.Type.GetType("System.Int32"))

      table.Columns.Add("LIBERADOS", System.Type.GetType("System.Int32"))

      ' table.Columns.Add("LIBERADOS PDI", System.Type.GetType("System.Int32"))

      table.Columns.Add("ENTREGADOS", System.Type.GetType("System.Int32"))



      For Each dr1 As UltraGridRow In ugDetalle.Rows
         Select Case dr1.Cells("Chasis").Value.ToString()
            Case = "NO INICIADOS"
               NoIniciados += 1
            Case = "EN LINEA"
               EnLInea += 1
            Case = "LIBERADOS"
               Liberados += 1
               '  Case = "LIBERADOS PDI"
         '      LiberadosPDI += 1
            Case = "ENTREGADOS"
               Entregados += 1
         End Select
      Next

      Dim dr As DataRow = table.NewRow
      dr("NO INICIADOS") = NoIniciados
      dr("EN LINEA") = EnLInea
      dr("LIBERADOS") = Liberados
      '   dr("LIBERADOS PDI") = LiberadosPDI
      dr("ENTREGADOS") = Entregados


      table.Rows.Add(dr)

      If rbtAutomatico.Checked Then
         Me.UltraChart1.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Automatic
      Else

         Dim Mayor As Integer
         Dim Mayor1 As Integer
         Dim MayorTotal As Integer

         If NoIniciados > EnLInea Then
            Mayor = NoIniciados
         Else
            Mayor = EnLInea
         End If
         If Liberados > Entregados Then
            Mayor1 = Liberados
         Else
            Mayor1 = Entregados
         End If
         If Mayor > Mayor1 Then
            MayorTotal = Mayor
         Else
            MayorTotal = Mayor1
         End If

         If MayorTotal > Integer.Parse(Me.txtManualMaximo.Text.ToString()) Then
            MessageBox.Show("El máximo es menor que los datos, reingrese valor máximo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtManualMaximo.Focus()
            Exit Sub
         Else
            Me.UltraChart1.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom
            Me.UltraChart1.Axis.Y.RangeMin = Double.Parse(Me.txtManualMinimo.Text.ToString())
            Me.UltraChart1.Axis.Y.RangeMax = Double.Parse(Me.txtManualMaximo.Text.ToString())
         End If

      End If
      Me.UltraChart1.DataSource = table

      Me.UltraChart1.DataBind()


      ' Me.UltraChart2.DataSource = table

      ' Me.UltraChart2.DataBind()

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbProducto.Checked Then
            .AppendFormat(" Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbPreEntrega.SelectedIndex >= 0 Then
            .AppendFormat(" Liberado: {0}", Me.cmbPreEntrega.Text.ToString())
         End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub ColorEstados(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      Dim ColorEstado As Integer
      Dim color As Color = SystemColors.Control
      For Each dr As UltraGridRow In ugDetalle.Rows

         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
               ColorEstado = New Reglas.EstadosListasControl().GetEstadoColorPorNombre(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString())
               color = Drawing.Color.FromArgb(ColorEstado)
               dr.Cells(drColumnas("NombreColumma").ToString()).Appearance.BackColor = color
            End If
         Next
      Next
   End Sub

   Private Sub ListasControlPorProducto()
      Try
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         _PermisoEjecucion = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos")
         If _PermisoEjecucion Then
            'si no seleccionó una fila no le deja continuar
            If Me.ugDetalle.ActiveRow Is Nothing Then
               Exit Sub
            End If
            '----------
            Me.Cursor = Cursors.WaitCursor
            Dim fr As ListasControlProductos = New ListasControlProductos(Me.ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim(), IdFuncion)
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Else
            MessageBox.Show("No tiene acceso a la pantalla de Ejecución de Listas de Control.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
   End Sub

   Private Sub ugExcelExporter_CellExported(sender As Object, e As CellExportedEventArgs)
      If e.CurrentRowIndex > latestRowIndex Then
         latestRowIndex = e.CurrentRowIndex
      End If
      If e.CurrentColumnIndex > latestColIndex Then
         latestColIndex = e.CurrentColumnIndex
      End If

   End Sub

   Private Sub CargarDatosModelo(ByVal dr As DataGridViewRow)
      Me.bscModelo.Text = dr.Cells("NombreProductoModelo").Value.ToString()
      Me.bscModelo.Tag = Long.Parse(dr.Cells("IdProductoModelo").Value.ToString())
   End Sub

   Private Sub PreparaGrillaModelo(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Modelos de Productos",
                                .AnchoAyuda = 500}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "CodigoProductoModelo"
         col.Titulo = "Codigo"
         col.Ancho = 100
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "NombreProductoModelo"
         col.Titulo = "Descripcion"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 250
         .ColumnasVisibles.Add(col)
         '-- 

      End With
   End Sub

   Private Sub chbModelo_CheckedChanged(sender As Object, e As EventArgs) Handles chbModelo.CheckedChanged
      Me.bscModelo.Enabled = Me.chbModelo.Checked
      If Not Me.chbModelo.Checked Then
         Me.bscModelo.Text = String.Empty
      End If
   End Sub

   Private Sub rbtManual_CheckedChanged(sender As Object, e As EventArgs) Handles rbtManual.CheckedChanged
      Try

         Me.txtManualMinimo.Enabled = rbtManual.Checked
         Me.lblMinimo.Enabled = rbtManual.Checked
         Me.txtManualMaximo.Enabled = rbtManual.Checked
         Me.lblMaximo.Enabled = rbtManual.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAutomatico.CheckedChanged
      If rbtAutomatico.Checked = True Then
         Me.txtManualMinimo.Text = "0"
         Me.txtManualMaximo.Text = "500"
      End If
   End Sub

#End Region

End Class