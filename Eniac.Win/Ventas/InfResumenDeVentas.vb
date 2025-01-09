#Region "Imports"
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

#End Region
Public Class InfResumenDeVentas

   Private dsDetalle As DataSet = New DataSet()
   Private _publicos As Publicos

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
         cmbGrabanLibro.SelectedIndex = 0

         _publicos.CargaComboDesdeEnum(cmbInformaLibroIVA, GetType(Entidades.Publicos.SiNoTodos))
         cmbInformaLibroIVA.SelectedIndex = 1

         '# Combo Es Comercial ( Por defecto en TODOS )
         _publicos.CargaComboDesdeEnum(cmbEsComercial, GetType(Entidades.Publicos.SiNoTodos))
         cmbEsComercial.SelectedIndex = 0

         cmbEmpresas.Initializar(IdFuncion)

         DefaultRadioFechas()
      End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      DefaultFocus()
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

#Region "Eventos ToolBar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
      Sub()
         If Not dsDetalle.Tables.OfType(Of DataTable).AnySecure() Then Exit Sub
         If dsDetalle.Tables(0).Rows.Count = 0 Then Exit Sub

         GetGrilla().Imprimir(String.Format("{0} - {1}", Text, tbcDetalle.SelectedTab.Text), CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1})
      End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
      Sub()
         If dsDetalle.Tables.Count = 0 OrElse dsDetalle.Tables(0).Rows.Count = 0 Then Exit Sub

         GetGrilla().Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion(), String.Format("{0} - {1}", Text, tbcDetalle.SelectedTab.Text))
      End Sub)
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
      Sub()
         If dsDetalle.Tables.Count = 0 OrElse dsDetalle.Tables(0).Rows.Count = 0 Then Exit Sub

         GetGrilla().Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion(), String.Format("{0} - {1}", Text, tbcDetalle.SelectedTab.Text))
      End Sub)
   End Sub

   Private Sub tsmiAExcelUnificado_Click(sender As Object, e As EventArgs) Handles tsmiAExcelUnificado.Click
      TryCatched(
      Sub()
         If dsDetalle.Tables.Count = 0 OrElse dsDetalle.Tables(0).Rows.Count = 0 Then Exit Sub

         Dim excelExport = New UltraGridExportarExcel(UltraGridExcelExporter1, Reglas.Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.xls", Name), GetGrillasExportar(), CargarFiltrosImpresion())
      End Sub)
   End Sub

   Private Sub tsmiAPDFUnificado_Click(sender As Object, e As EventArgs) Handles tsmiAPDFUnificado.Click
      TryCatched(
      Sub()
         If dsDetalle.Tables.Count = 0 OrElse dsDetalle.Tables(0).Rows.Count = 0 Then Exit Sub

         Dim excelExport = New UltraGridExportarPDF(UltraGridDocumentExporter1, Reglas.Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.pdf", Name), GetGrillasExportar(), CargarFiltrosImpresion())
      End Sub)
   End Sub

   Private Function GetGrillasExportar() As UltraGridExportTituloGrilla()
      Return {New UltraGridExportTituloGrilla() With {.Grilla = ugPorComprobante, .Titulo = String.Format("{0} - {1}", Text, tbpPorComprobante.Text), .NombreHoja = tbpPorComprobante.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugPorCategoriaFiscal, .Titulo = String.Format("{0} - {1}", Text, tbpPorCategoriaFiscal.Text), .NombreHoja = tbpPorCategoriaFiscal.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugPorRubroProducto, .Titulo = String.Format("{0} - {1}", Text, tbpPorRubrosProductos.Text), .NombreHoja = tbpPorRubrosProductos.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugPorRubroSubRubroProducto, .Titulo = String.Format("{0} - {1}", Text, "Por Rubros y SubRubros Prod"), .NombreHoja = "Por Rubros y SubRubros Prod"},
              New UltraGridExportTituloGrilla() With {.Grilla = ugPorCategoriaCliente, .Titulo = String.Format("{0} - {1}", Text, tbpPorCategoriaCliente.Text), .NombreHoja = tbpPorCategoriaCliente.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugPorRubroProductoCategoriaFiscal, .Titulo = String.Format("{0} - {1}", Text, tbpPorRubrosProductosCatgegoriaFiscal.Text), .NombreHoja = tbpPorRubrosProductosCatgegoriaFiscal.Text}}
   End Function

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region
#Region "Eventos Filtros"
   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoDesde.ValueChanged
      TryCatched(
      Sub()
         If Not chkUltimoAno.Checked Then
            dtpPeriodoHasta.Value = dtpPeriodoDesde.Value
         End If
         dtpPeriodoDesde.Value = dtpPeriodoDesde.Value.PrimerDiaMes
      End Sub)
   End Sub
   Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoHasta.ValueChanged
      TryCatched(Sub() dtpPeriodoHasta.Value = dtpPeriodoHasta.Value.UltimoDiaMes())
   End Sub
   Private Sub chkUltimoAno_CheckedChanged(sender As Object, e As EventArgs) Handles chkUltimoAno.CheckedChanged
      TryCatched(
      Sub()
         If chkUltimoAno.Checked Then
            dtpPeriodoDesde.Value = dtpPeriodoHasta.Value.AddYears(-1).AddMonths(1)
         End If
         dtpPeriodoDesde.Enabled = Not chkUltimoAno.Checked
      End Sub)
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Radiobuttons Fechas Filtro"
   Private Sub rdbPorPeriodoFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPorPeriodoFiscal.CheckedChanged
      TryCatched(Sub() HabilitarFiltrosFecha())
   End Sub
   Private Sub rdbPorFechas_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPorFechas.CheckedChanged
      TryCatched(Sub() HabilitarFiltrosFecha())
   End Sub
   Private Sub rdbAmbos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAmbos.CheckedChanged
      TryCatched(Sub() HabilitarFiltrosFecha())
   End Sub
#End Region
#End Region

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs)
      TryCatched(Sub() UltraGridPrintDocument1.Footer.TextRight = "Página: " + UltraGridPrintDocument1.PageNumber.ToString())
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         CargaGrillaDetalle()
         If dsDetalle.Tables(0).Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la selección !")
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      DefaultRadioFechas()
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      chkUltimoAno.Checked = False
      dtpPeriodoDesde.Value = Date.Today
      dtpPeriodoHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      cmbGrabanLibro.SelectedIndex = 0
      cmbInformaLibroIVA.SelectedIndex = 1

      chbSepararNetos.Checked = False

      DefaultFocus()

      cmbEmpresas.Refrescar()

      dsDetalle.Clear()
   End Sub
   Private Sub CargaGrillaDetalle()

      Dim fechaDesde = dtpDesde.Valor(rdbPorFechas.Checked Or rdbAmbos.Checked)
      Dim fechaHasta = dtpHasta.Valor(rdbPorFechas.Checked Or rdbAmbos.Checked)

      Dim periodoDesde = dtpPeriodoDesde.Valor(rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked)
      Dim periodoHasta = dtpPeriodoHasta.Valor(rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked)

      Dim separarNetos = chbSepararNetos.Checked

      Dim rVI = New Reglas.VentasImpuestos()
      dsDetalle = rVI.GetResumenDeVenta(cmbEmpresas.GetEmpresas(), fechaDesde, fechaHasta, periodoDesde, periodoHasta,
                                        cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                        cmbEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                        cmbInformaLibroIVA.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), separarNetos)

      ugPorComprobante.DataSource = dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra.ToString())
      ugPorCategoriaFiscal.DataSource = dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal.ToString())
      ugPorRubroProducto.DataSource = dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto.ToString())
      ugPorRubroSubRubroProducto.DataSource = dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto.ToString())
      ugPorCategoriaCliente.DataSource = dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente.ToString())
      ugPorRubroProductoCategoriaFiscal.DataSource = dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal.ToString())

      FormatearGrilla(ugPorComprobante)
      FormatearGrilla(ugPorCategoriaFiscal)
      FormatearGrilla(ugPorRubroProducto)
      FormatearGrilla(ugPorRubroSubRubroProducto)
      FormatearGrilla(ugPorCategoriaCliente)
      FormatearGrilla(ugPorRubroProductoCategoriaFiscal)

   End Sub
   Private Sub FormatearGrilla(ug As UltraGrid)
      Dim col = 0I
      ug.AgregarTotalesSuma({"NetoNoGravado", "Neto", "Total"})
      Dim dt = ug.DataSource(Of DataTable)()

      ug.DisplayLayout.Bands(0).Columns("NombreEmpresa").Hidden = cmbEmpresas.GetEmpresas().Length = 1
      ug.DisplayLayout.Bands(0).Columns("Neto").Width = 90
      ug.DisplayLayout.Bands(0).Columns("NetoNoGravado").Width = 90
      ug.DisplayLayout.Bands(0).Columns("Total").Width = 90

      For Each dc In ug.DisplayLayout.Bands(0).Columns
         If dc.Key.StartsWith("____") Then
            Dim caption = String.Empty
            Dim partes = dc.Key.Replace("____", "").Split("_"c)
            If partes.Length > 1 Then
               caption = partes(1)
            End If
            If partes.Length > 2 Then
               caption += " " + partes(2).Replace("#", ".") + " %"
            End If
            dc.FormatearColumna(caption, col, If(dc.Key.Contains("NetoGravado"), 135, 90), HAlign.Right, , "N2")
            ug.AgregarTotalSumaColumna(dc)
            If dt IsNot Nothing AndAlso dt.Select(String.Format("[{0}] <> 0", dc.Key)).Length = 0 Then
               dc.Hidden = True
            End If
         Else
            col += Math.Max(col, dc.Header.VisiblePosition)
            If dc.Key = "Total" Then dc.Header.VisiblePosition = 9999
         End If
      Next

      ug.ColapsarExpandir(AccionColapsarExpandir.Expandir)
      ug.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed Or SummaryDisplayAreas.GroupByRowsFooter

   End Sub

   Private Sub DefaultRadioFechas()
      Select Case Publicos.ValorPorDefectoEnResumenDeVentas
         Case "PorFechas"
            rdbPorFechas.Checked = True
         Case "PorPeriodoFiscal"
            rdbPorPeriodoFiscal.Checked = True
         Case Else
            rdbAmbos.Checked = True
      End Select
   End Sub
   Private Sub DefaultFocus()
      If rdbPorFechas.Checked Then
         dtpDesde.Focus()
      Else
         dtpPeriodoDesde.Focus()
      End If
   End Sub

   Private Function GetGrilla() As UltraGrid
      If tbcDetalle.SelectedTab.Equals(tbpPorComprobante) Then
         Return ugPorComprobante
      ElseIf tbcDetalle.SelectedTab.Equals(tbpPorCategoriaFiscal) Then
         Return ugPorCategoriaFiscal
      ElseIf tbcDetalle.SelectedTab.Equals(tbpPorRubrosProductos) Then
         Return ugPorRubroProducto
      ElseIf tbcDetalle.SelectedTab.Equals(tbpPorRubrosSubRubrosProductos) Then
         Return ugPorRubroSubRubroProducto
      ElseIf tbcDetalle.SelectedTab.Equals(tbpPorCategoriaCliente) Then
         Return ugPorCategoriaCliente
      ElseIf tbcDetalle.SelectedTab.Equals(tbpPorRubrosProductosCatgegoriaFiscal) Then
         Return ugPorRubroProductoCategoriaFiscal
      Else
         Return Nothing
      End If
   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      cmbEmpresas.CargarFiltrosImpresionEmpresas(filtro, True, False)
      With filtro
         If rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked Then
            .AppendFormat(" - Periodo: {0:MM/yyyy} Hasta {1:MM/yyyy}", dtpPeriodoDesde.Value, dtpPeriodoHasta.Value)
         End If
         If rdbPorFechas.Checked Or rdbAmbos.Checked Then
            .AppendFormat(" - Fecha: {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If
         .AppendFormat(" - Graba Libro: {0}", cmbGrabanLibro.Text)
         .AppendFormat(" - Es Comercial: {0}", cmbEsComercial.Text)
         .AppendFormat(" - Informa Libro IVA: {0}", cmbInformaLibroIVA.Text)
         If chbSepararNetos.Checked Then .AppendFormat(" Separar Netos: SI - ")

      End With
      Return filtro.ToString()
   End Function
   Private Sub HabilitarFiltrosFecha()
      chkUltimoAno.Enabled = rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked
      dtpPeriodoDesde.Enabled = chkUltimoAno.Enabled And Not chkUltimoAno.Checked
      dtpPeriodoHasta.Enabled = chkUltimoAno.Enabled

      chkMesCompleto.Enabled = rdbPorFechas.Checked Or rdbAmbos.Checked
      dtpDesde.Enabled = chkMesCompleto.Enabled
      dtpHasta.Enabled = chkMesCompleto.Enabled

      If rdbPorPeriodoFiscal.Checked Then
         dtpPeriodoDesde.Focus()
      ElseIf rdbPorFechas.Checked Or rdbAmbos.Checked Then
         dtpDesde.Focus()
      End If
   End Sub
#End Region

End Class