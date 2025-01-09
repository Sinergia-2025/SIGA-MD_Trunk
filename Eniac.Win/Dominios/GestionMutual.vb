#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
#End Region
Public Class GestionMutual

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _vieneDeOnLoad As Boolean = False
   Private _facturacionPermiteFacturarEnOtrasMonedas As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _vieneDeOnLoad = True

         Me.CargaGrillaDetalle()
      
         _vieneDeOnLoad = False

         _facturacionPermiteFacturarEnOtrasMonedas = Reglas.Publicos.Facturacion.FacturacionPermiteFacturarEnOtrasMonedas

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Dim permiteMostrarTotalesImpresionExportacion As Boolean = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.IdSucursal, "InfDeVts-Totales+Toolbar")

         If permiteMostrarTotalesImpresionExportacion Then
            Me.CargarColumnasASumar()
         Else
            tsbImprimir.Visible = False
            tsddExportar.Visible = False
            ToolStripSeparator2.Visible = False
            ToolStripSeparator4.Visible = False
         End If

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "CodigoCliente", "CUIT", "Empresa", "Activo"}, {"Ver", "VerEstandar", "Imprimir"})

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         Me.LeerPreferencias()

         If Not permiteMostrarTotalesImpresionExportacion Then
            ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfVentasDetallePorProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim Filtros As String = Me.CargarFiltrosImpresion
         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
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

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If

         'Me.sfdExportar.FileName = Me.Name & ".xls"
         'Me.sfdExportar.Filter = "Archivos excel|*.xls"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
         '   End If
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

         'Me.sfdExportar.FileName = Me.Name & ".pdf"
         'Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
         '   End If
         'End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If Me.chkExpandAll.Checked Then
      '   Me.ugDetalle.Rows.ExpandAll(True)
      'Else
      '   Me.ugDetalle.Rows.CollapseAll(True)
      'End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton

      If e.Cell.Row.Index <> -1 Then

         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

            Select Case Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption

               Case Is = "Ver", "Imp", "V.E."

                  Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))


                  Dim oImpr As Impresion = New Impresion(venta)

                  If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption <> "Imp" Then
                     If venta.Impresora.TipoImpresora = "NORMAL" Then
                        Dim ReporteEstandar As Boolean = (Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption = "V.E.")
                        oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

                        'If venta.Percepciones IsNot Nothing Then
                        '   For Each perc As Entidades.PercepcionVenta In venta.Percepciones
                        '      If perc.ImporteTotal <> 0 Then
                        '         Dim ret As PercepcionImprimir = New PercepcionImprimir()
                        '         ret.ImprimirPercepcion(venta, perc)
                        '      End If
                        '   Next
                        'End If

                     Else
                        oImpr.ReImprimirComprobanteFiscal()
                     End If

                  Else
                     If venta.Impresora.TipoImpresora = "NORMAL" Then

                        oImpr.ImprimirComprobanteNoFiscal(False)

                     ElseIf Not venta.TipoComprobante.GrabaLibro Then

                        Dim fc As FacturacionComunes = New FacturacionComunes()
                        fc.ImprimirComprobante(venta, venta.TipoComprobante.EsFiscal)

                     Else
                        MessageBox.Show("No es posible Reimprimir en la Impresora Fiscal un Comprobante FISCAL.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     End If

                  End If

               Case "Invoc"

                  If String.IsNullOrEmpty(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CantidadInvocados").Value.ToString()) Then Exit Sub

                  Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

                  Dim oComprobantesInvocados As FacturablesInvocados

                  oComprobantesInvocados = New FacturablesInvocados(venta.TipoComprobante.IdTipoComprobante, _
                                                                    venta.LetraComprobante, _
                                                                    venta.CentroEmisor, _
                                                                    venta.NumeroComprobante)

                  oComprobantesInvocados.ShowDialog()

               Case "Lotes"

                  If String.IsNullOrEmpty(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CantidadLotes").Value.ToString()) Then Exit Sub

                  Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

                  Dim cl As ConsultarLotes = New ConsultarLotes(venta.TipoComprobante.IdTipoComprobante, _
                                                                venta.LetraComprobante, _
                                                                venta.CentroEmisor, _
                                                                venta.NumeroComprobante, _
                                                                0)

                  cl.ShowDialog()

               Case "Contactos"

                  If String.IsNullOrEmpty(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CantidadContactos").Value.ToString()) Then Exit Sub

                  Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

                  Dim cl As ConsultarContactos = New ConsultarContactos(venta.TipoComprobante.IdTipoComprobante, _
                                                                venta.LetraComprobante, _
                                                                venta.CentroEmisor, _
                                                                venta.NumeroComprobante, _
                                                                0)

                  cl.ShowDialog()

               Case Else

            End Select

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs)

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Dim Filtros As String = CargarFiltrosImpresion()

         Me.Cursor = Cursors.WaitCursor
         Dim dt As DataTable

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InformeDeVentas.rdlc", "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Try
         Dim en As Entidades.ClienteDeuda = New Reglas.ClientesDeudas().GetUno(Long.Parse(Me.ugDetalle.ActiveRow.Cells("IdCliente").Value.ToString()), _
                                                                            Integer.Parse(Me.ugDetalle.ActiveRow.Cells("nro_prestamo").Value.ToString()))


         Me.Cursor = Cursors.Default
         Dim da As MutualDetalle = New MutualDetalle(en)
         da.StateForm = Eniac.Win.StateForm.Actualizar

         da.ShowDialog()

         If da.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.CargaGrillaDetalle()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDetalle.AfterRowFilterChanged
      Try
         Me.tssRegistros.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.CargaGrillaDetalle()

   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("deuda_exigible") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("capital_total")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("capital_total", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize10 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible_con_quita")
         Dim summary10 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible_con_quita", SummaryType.Sum, columnToSummarize10)
         summary10.DisplayFormat = "{0:N2}"
         summary10.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If


   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oClientesDeudas As Reglas.ClientesDeudas = New Reglas.ClientesDeudas()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0
      Dim Letra As String = ""
      Dim emisor As Integer = 0
      Dim NumeroComprobante As Long = 0
      Dim TipoCategoria As String = String.Empty
      Dim NumeroRepartoDesde As Integer? = Nothing
      Dim NumeroRepartoHasta As Integer? = Nothing

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow


      dtDetalle = oClientesDeudas.GetDeudas()

      For Each dr As DataRow In dtDetalle.Rows
         If String.IsNullOrEmpty(dr("G").ToString()) Then
            dr("G") = "NO"
         Else
            dr("G") = "SI"
         End If
      Next

      Me.ugDetalle.DataSource = dtDetalle

      Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Activo").FilterConditions.Add(FilterComparisionOperator.Equals, True)
    
      Me.tssRegistros.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("Imprimir")
         .Columns.Add("VerEstandar")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))

         .Columns.Add("IdClienteVinculado", GetType(Long))
         .Columns.Add("CodigoClienteVinculado", GetType(Long))
         .Columns.Add("NombreClienteVinculado", GetType(String))

         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("Subtotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("FechaActualizacion", System.Type.GetType("System.DateTime"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("ImportePesos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTickets", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteCheques", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTarjetas", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdCuentaBancaria", System.Type.GetType("System.Int32"))
         .Columns.Add("ImporteTransfBancaria", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreBanco", System.Type.GetType("System.String"))
         .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("Percepciones", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Long))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("CantidadInvocados", System.Type.GetType("System.Int32"))
         .Columns.Add("CantidadLotes", System.Type.GetType("System.Int32"))
         .Columns.Add("CAE", System.Type.GetType("System.String"))
         .Columns.Add("CAEVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("NombreCaja", System.Type.GetType("System.String"))
         .Columns.Add("NumeroPlanilla", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroMovimiento", System.Type.GetType("System.Int32"))
         .Columns.Add("MetodoGrabacion", System.Type.GetType("System.String"))
         .Columns.Add("IdFuncion", System.Type.GetType("System.String"))
         .Columns.Add("NumeroReparto", System.Type.GetType("System.Int32"))
         .Columns.Add("TotalImpuestoInterno", System.Type.GetType("System.Decimal"))
         .Columns.Add("CantidadContactos", System.Type.GetType("System.Int32"))

         .Columns.Add("IdMoneda", GetType(Integer))
         .Columns.Add("NombreMoneda", GetType(String))
         .Columns.Add("Simbolo", GetType(String))
         .Columns.Add("CotizacionDolar", GetType(Decimal))
      End With

      Return dtTemp

   End Function

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         'cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         'cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         'If Me.cboLetra.SelectedIndex >= 0 Then
         '   .AppendFormat(" Letra: {0} - ", Me.cboLetra.SelectedText)
         'End If

         'If Me.cmbEmisor.SelectedIndex >= 0 Then
         '   .AppendFormat(" Emisor: {0} -", Me.cmbEmisor.SelectedText)
         'End If

         'If Me.chbNumero.Checked Then
         '   .AppendFormat(" Número: {0} -", Me.txtNumero.Text)
         'End If

         'If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
         '   .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         'End If


      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region


End Class