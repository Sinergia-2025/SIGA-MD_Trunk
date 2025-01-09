Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class ContabilidadListadoLibroMayor

   Public Enum TipoReferencia
      Cliente
      Proveedor
   End Enum

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos
   Private _utilizaCentroCostos As Boolean = False
#End Region

#Region "Propiedades"

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Ayudante.Grilla.InicializaGrilla(ugDetalle)

      Me._publicosContabilidad = New ContabilidadPublicos()
      Me._publicos = New Publicos()

      Me._publicosContabilidad.CargaComboPlanes(Me.cmbPlan, True)
      Me._publicosContabilidad.CargarSucursalesACheckListBox(Me.clbSucursales)
      _publicos.CargaComboCentroCostos(cmbCentroCosto)
      Me._publicos.CargaComboDesdeEnum(cmbTipoReferencia, GetType(TipoReferencia))

      _utilizaCentroCostos = Reglas.ContabilidadPublicos.UtilizaCentroCostos

      cmbTipoReferencia.SelectedIndex = -1

      chbCentroCosto.Visible = _utilizaCentroCostos
      chbMostrarCentroCosto.Visible = _utilizaCentroCostos
      lblCentroCosto.Visible = _utilizaCentroCostos
      cmbCentroCosto.Visible = _utilizaCentroCostos

      Me.CargarValoresIniciales()

   End Sub

   'Public Function GetReglas() As Eniac.Reglas.Base
   '   Return New Reglas.ContabilidadReportes()
   'End Function

#End Region

#Region "Eventos"

   Private Sub ContabilidadListadoLibroMayor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.RefrescarDatos()
   End Sub

   Private Sub tsbImprimirPrediseñado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirPrediseñado.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim Sucursales As String = String.Empty
         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
         Next
         If Sucursales.Length > 0 Then Sucursales = Sucursales.Substring(2)

         Dim strFechaDesde As String = String.Empty
         Dim codCuenta As Integer = CInt(Me.bscCodCuenta.Text)

         If Me.dtpDesde.Checked Then
            strFechaDesde = Me.dtpDesde.Value.ToShortDateString
         Else
            strFechaDesde = "-"
         End If

         Dim FechaHasta As Date = Me.dtpHasta.Value

         Dim dt As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Sucursales))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Me.CargarFiltrosImpresion()))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptLibroMayor.rdlc", "dtsLibroMayor_dtLibro", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

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
         Me.UltraGridPrintDocument1.Header.Height = 160
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
   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
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
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbPlanEnArbol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlanEnArbol.Click

      Using frmplan As New ContabilidadPlanesCuentasPreView()
         frmplan.IdPlanCuenta = CInt(Me.cmbPlan.SelectedValue)
         If frmplan.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso frmplan.Cuenta IsNot Nothing Then
            bscDescripcion.Text = String.Empty
            Me.bscCodCuenta.Text = frmplan.Cuenta.IdCuenta.ToString()
            Me.bscCodCuenta.PresionarBoton()
            btnConsultar.Focus()
         End If
      End Using
   End Sub

   Private Sub cmbPlanEnArbolHasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlanEnArbolHasta.Click

      Using frmplan As New ContabilidadPlanesCuentasPreView()
         frmplan.IdPlanCuenta = CInt(Me.cmbPlan.SelectedValue)
         If frmplan.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso frmplan.Cuenta IsNot Nothing Then
            bscDescripcionHasta.Text = String.Empty
            Me.bscCodCuentaHasta.Text = frmplan.Cuenta.IdCuenta.ToString()
            Me.bscCodCuentaHasta.PresionarBoton()
            btnConsultar.Focus()
         End If
      End Using
   End Sub

   Private Sub bsccodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicosContabilidad.PreparaGrillaCuentas(Me.bscCodCuenta)
         'Me.bscCodCuenta.Datos = oAsientos.GetCuentasImputablesXCodigo(Long.Parse("0" + Me.bscCodCuenta.Text.Trim()))
         Me.bscCodCuenta.Datos = oAsientos.GetPorCodigo(Long.Parse("0" + Me.bscCodCuenta.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuenta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells("idCuenta").Value.ToString()
            bscCodCuenta.Tag = e.FilaDevuelta.Cells("EsImputable").Value
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcion.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas
         Me._publicosContabilidad.PreparaGrillaCuentas(Me.bscDescripcion)
         Me.bscDescripcion.Datos = oAsientos.GetCuentasImputablesXNombre(Me.bscDescripcion.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells("idCuenta").Value.ToString()
            bscCodCuenta.Tag = e.FilaDevuelta.Cells("EsImputable").Value
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuentaHasta_BuscadorClick() Handles bscCodCuentaHasta.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicosContabilidad.PreparaGrillaCuentas(Me.bscCodCuentaHasta)
         'Me.bscCodCuenta.Datos = oAsientos.GetCuentasImputablesXCodigo(Long.Parse("0" + Me.bscCodCuenta.Text.Trim()))
         Me.bscCodCuentaHasta.Datos = oAsientos.GetPorCodigo(Long.Parse("0" + Me.bscCodCuentaHasta.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuentaHasta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuentaHasta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcionHasta.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCodCuentaHasta.Text = e.FilaDevuelta.Cells("idCuenta").Value.ToString()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcionHasta_BuscadorClick() Handles bscDescripcionHasta.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas
         Me._publicosContabilidad.PreparaGrillaCuentas(Me.bscDescripcionHasta)
         Me.bscDescripcionHasta.Datos = oAsientos.GetCuentasImputablesXNombre(Me.bscDescripcionHasta.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcionHasta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcionHasta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcionHasta.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCodCuentaHasta.Text = e.FilaDevuelta.Cells("idCuenta").Value.ToString()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Cursor = Cursors.WaitCursor
         Me.CargaGrillaDetalle()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

   End Sub

   Private Function AplicarJerarquia(ByVal codigo As String) As String

      Return codigo.Substring(0, 1) & "." _
                      & codigo.Substring(1, 2) & "." _
                      & codigo.Substring(3, 2) & "." _
                      & codigo.Substring(5, 3)
   End Function

   Private Sub CargaGrillaDetalle()

      If Me.ValidarLibroMayor() Then

         Dim idPlan As Integer? = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
         Dim fechaDesde As Date? = Nothing
         Dim fechaHasta As Date? = Me.dtpHasta.Value
         Dim codCuenta As Integer? = CInt(Me.bscCodCuenta.Text)
         Dim codCuentaHasta As Integer? = Nothing

         If radRango.Checked Then
            codCuentaHasta = CInt(Me.bscCodCuentaHasta.Text)
         End If

         Dim tpRef As String = String.Empty
         Dim referencia As String = String.Empty

         Dim Sucursales As List(Of Integer) = New List(Of Integer)
         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales.Add(DirectCast(ite, Entidades.Sucursal).Id)
         Next

         If Me.dtpDesde.Checked Then
            fechaDesde = Me.dtpDesde.Value
         End If

         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteLibro As New Entidades.ContabilidadReporte

         If chbReferencia.Checked Then
            If cmbTipoReferencia.SelectedValue IsNot Nothing Then
               If cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Cliente) Then
                  tpRef = "C"
               ElseIf cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Proveedor) Then
                  tpRef = "P"
               End If
            End If
            If bscReferencia.Tag IsNot Nothing Then
               referencia = bscReferencia.Tag.ToString()
            End If
         End If

         Dim idCentroCosto As Integer? = Nothing
         If chbCentroCosto.Checked AndAlso IsNumeric(cmbCentroCosto.SelectedValue) Then
            idCentroCosto = Integer.Parse(cmbCentroCosto.SelectedValue.ToString())
         End If

         Dim dtsLibroMayor As New dtsLibroMayor
         oReporteLibro = reg.LibroMayor(fechaDesde, fechaHasta, codCuenta, codCuentaHasta, idPlan, Sucursales.ToArray(), tpRef, referencia, chbMostrarComprobanteOrigen.Checked, Me.chbSaldoInicial.Checked, idCentroCosto, chbMostrarCentroCosto.Checked)

         Me.ugDetalle.DataSource = oReporteLibro.libroMayor

         Me.formatearGrilla()

         If oReporteLibro.libroMayor Is Nothing OrElse oReporteLibro.libroMayor.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados.", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.tssRegistros.Text = oReporteLibro.libroMayor.Rows.Count.ToString() & " Registros"

      End If

   End Sub

   Private Function ValidarLibroMayor() As Boolean

      If Me.bscCodCuenta.Text = String.Empty Then
         MessageBox.Show("Selecione una cuenta para generar el Mayor.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodCuenta.Focus()
         Return False
      End If

      If chbReferencia.Checked AndAlso (bscCodigoReferencia.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(bscCodigoReferencia.Tag.ToString())) Then
         MessageBox.Show("Indicó que desea filtrar por referencia pero no seleccionó una. Por favor verifique.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodCuenta.Focus()
         Return False
      End If

      If chbCentroCosto.Checked AndAlso Not IsNumeric(cmbCentroCosto.SelectedValue) Then
         ShowMessage("Indicó que desea filtrar por Centro de Costos pero no seleccionó uno. Por favor verifique.")
         Me.cmbCentroCosto.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub RefrescarDatos()

      Dim Cont As Integer

      For Cont = 0 To clbSucursales.Items.Count - 1
         'Siempre marco la actual
         If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Cont, True)
         Else
            Me.clbSucursales.SetItemChecked(Cont, False)
         End If
      Next

      Me.dtpDesde.Value = Now
      Me.dtpHasta.Value = Now

      Me.cmbPlan.SelectedIndex = 0
      Me.bscCodCuenta.Text = ""
      Me.bscDescripcion.Text = ""

      Me.radUnaCuenta.Checked = True

      'Me.bscCodCuentaHasta.Text = ""
      'Me.bscDescripcionHasta.Text = ""

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      chbReferencia.Checked = False
      chbMostrarComprobanteOrigen.Checked = False

      Me.tssRegistros.Text = " 0 Registros"

   End Sub

   Private Sub formatearGrilla()
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Rows.ExpandAll(False)

      'For Each cl As UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
      '   cl.CellActivation = UltraWinGrid.Activation.ActivateOnly
      'Next

      With Me.ugDetalle.DisplayLayout.Bands(0)

         Ayudante.Grilla.FormatearColumna(.Columns("idAsiento"), "Nro.", 0, 50, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns("fechaAsiento"), "Fecha", 1, 80, HAlign.Center, , Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         Ayudante.Grilla.FormatearColumna(.Columns("nombreAsiento"), "Asiento", 2, 350)
         Ayudante.Grilla.FormatearColumna(.Columns("idCuenta"), "Nro. Cuenta", 3, 50, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreCuenta"), "Cuenta", 4, 250)

         If radUnaCuenta.Checked And bscCodCuenta.Tag IsNot Nothing AndAlso bscCodCuenta.Tag.Equals(True) Then
            .Columns("idCuenta").Hidden = True
            .Columns("NombreCuenta").Hidden = True
         Else
            .Columns("idCuenta").Hidden = False
            .Columns("NombreCuenta").Hidden = False
         End If

         Ayudante.Grilla.FormatearColumna(.Columns("Debe"), "Debe", 5, 80, HAlign.Right, , "N2")
         Ayudante.Grilla.FormatearColumna(.Columns("Haber"), "Haber", 6, 80, HAlign.Right, , "N2")
         Ayudante.Grilla.FormatearColumna(.Columns("saldo"), "Saldo", 7, 80, HAlign.Right, , "N2")

         Ayudante.Grilla.FormatearColumna(.Columns("CodigoReferencia"), "Referencia", 8, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreReferencia"), "Nombre Referencia", 9, 170)

         .Columns("orden").Hidden = True
         .Columns("IdTipoReferencia").Hidden = True
         .Columns("Referencia").Hidden = True

         If chbMostrarCentroCosto.Checked Then
            Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()),
                                             "C.C.", 10, 50, HAlign.Right, Not chbMostrarCentroCosto.Checked)
            Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()),
                                             "Centro de Costos", 11, 150, , Not chbMostrarCentroCosto.Checked)
         End If

         If chbMostrarComprobanteOrigen.Checked Then
            .Columns("IdSucursal").Hidden = True
            Ayudante.Grilla.FormatearColumna(.Columns("IdTipoComprobante"), "Tipo", 12, 90)
            Ayudante.Grilla.FormatearColumna(.Columns("Letra"), "L.", 13, 25, HAlign.Center)
            Ayudante.Grilla.FormatearColumna(.Columns("CentroEmisor"), "Emisor", 14, 50, HAlign.Right)
            Ayudante.Grilla.FormatearColumna(.Columns("NumeroComprobante"), "Numero", 15, 60, HAlign.Right)
         End If

         .Summaries.Clear()

         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"Debe", "Haber"})

         If ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataTable Then
            Dim summary1 As UltraWinGrid.SummarySettings
            summary1 = .Summaries.Add("saldo", SummaryType.Custom, New SummarySaldo(DirectCast(ugDetalle.DataSource, DataTable)), .Columns("saldo"), SummaryPosition.UseSummaryPositionColumn, .Columns("saldo"))
            summary1.DisplayFormat = "{0:N2}"
            summary1.Appearance.TextHAlign = HAlign.Right
         End If
      End With

      Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"nombreAsiento", "NombreCuenta", "NombreReferencia",
                                                       Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()})

   End Sub

#Region "Custom Summary para la columna de Saldo"
   Public Class SummarySaldo
      Inherits Ayudante.CustomSummaries.SummaryUltimoValorColumna

      Public Sub New(dt As DataTable)
         MyBase.New(dt, "saldo")
      End Sub
   End Class
#End Region

#End Region

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro
         If clbSucursales.CheckedItems.Count > 0 Then
            Dim Sucursales As String = String.Empty
            For Each ite As Object In Me.clbSucursales.CheckedItems
               Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
            Next
            Sucursales = Sucursales.Trim().Trim(","c)
            .AppendFormat("Suc.: {0} - ", Sucursales)
         End If

         If cmbPlan.SelectedIndex >= 0 Then
            .AppendFormat("Plan: {0} - ", cmbPlan.Text)
         End If

         .AppendFormat("Fecha ")
         If dtpDesde.Checked Then
            .AppendFormat("desde: {0:d} - ", dtpDesde.Value)
         End If
         .AppendFormat("hasta: {0:d} - ", dtpHasta.Value)

         If radUnaCuenta.Checked = True Then
            .AppendFormat("Cuenta: {0} - {1} - ", bscCodCuenta.Text, bscDescripcion.Text)
         Else
            .AppendFormat("Cuentas: desde ""{0} - {1}"" hasta ""{2} - {3}"" - ", bscCodCuenta.Text, bscDescripcion.Text,
                                                                                    bscCodCuentaHasta.Text, bscDescripcionHasta.Text)
         End If

         If chbReferencia.Checked = True Then
            .AppendFormat("Sólo con referencia al {0} ""{1} - {2}"" - ", cmbTipoReferencia.Text, bscCodigoReferencia.Text,
                                                                        bscReferencia.Text)
         End If

         If chbMostrarComprobanteOrigen.Checked = True Then
            .AppendFormat("Muestra Comprobantes que originaron las cuentas - ")
         End If

         If chbMostrarComprobanteOrigen.Checked = True Then
            .AppendFormat("Incluye Saldos Iniciales - ")
         End If

         If chbCentroCosto.Checked Then
            .AppendFormat("Centro Costo: {0} - {1} - ", cmbCentroCosto.SelectedValue, cmbCentroCosto.SelectedText)
         End If
         If chbMostrarCentroCosto.Checked = True Then
            .AppendFormat("{0} - ", chbMostrarCentroCosto.Text)
         End If

      End With

      Return filtro.ToString().Trim().Trim("-"c).Trim()
   End Function

   Private Sub ugDetalle_AfterSortChange(sender As Object, e As UltraWinGrid.BandEventArgs) Handles ugDetalle.AfterSortChange
      Try
         Static reordenando As Boolean = False
         'Si estoy reordenando o ya está ordenando por la columna mágica, salgo
         If reordenando OrElse e.Band.SortedColumns.Contains(e.Band.Columns("Orden")) Then Exit Sub

         'Guardo las columnas por las que el usuario desea ordenar
         Dim columnas As New Dictionary(Of UltraGridColumn, Boolean)
         For Each col As UltraGridColumn In e.Band.SortedColumns
            columnas.Add(col, col.SortIndicator = SortIndicator.Descending)
         Next

         'Comienzo a reordenar yo
         reordenando = True

         e.Band.SortedColumns.Clear()

         'Agrego la columna mágica
         e.Band.SortedColumns.Add(e.Band.Columns("Orden"), False)

         'Vuelvo a poner las columnas del usuario
         For Each col As KeyValuePair(Of UltraGridColumn, Boolean) In columnas
            e.Band.SortedColumns.Add(col.Key, col.Value)
         Next

         'Termino de ordenar
         reordenando = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles chbReferencia.CheckedChanged, chbMostrarComprobanteOrigen.CheckedChanged
      Try
         cmbTipoReferencia.Enabled = chbReferencia.Checked

         If Not chbReferencia.Checked Then
            cmbTipoReferencia.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTipoReferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoReferencia.SelectedIndexChanged
      Try
         bscCodigoReferencia.Text = String.Empty
         bscReferencia.Text = String.Empty
         bscCodigoReferencia.Tag = Nothing

         bscCodigoReferencia.Enabled = cmbTipoReferencia.SelectedValue IsNot Nothing
         bscReferencia.Enabled = cmbTipoReferencia.SelectedValue IsNot Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoReferencia_BuscadorClick() Handles bscCodigoReferencia.BuscadorClick
      If cmbTipoReferencia.SelectedValue Is Nothing Then Exit Sub
      If cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Cliente) Then
         Dim codigoCliente As Long = -1
         Try
            Me._publicos.PreparaGrillaClientes(Me.bscCodigoReferencia)
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes
            If Me.bscCodigoReferencia.Text.Trim.Length > 0 Then
               codigoCliente = Long.Parse(Me.bscCodigoReferencia.Text.Trim())
            End If
            Me.bscCodigoReferencia.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      ElseIf cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Proveedor) Then
         Dim codigoProveedor As Long = -1
         Try
            Me._publicos.PreparaGrillaProveedores(Me.bscCodigoReferencia)
            Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
            If Me.bscCodigoReferencia.Text.Trim.Length > 0 Then
               codigoProveedor = Long.Parse(Me.bscCodigoReferencia.Text.Trim())
            End If
            Me.bscCodigoReferencia.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If
   End Sub

   Private Sub bscCodigoReferencia_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoReferencia.BuscadorSeleccion
      If cmbTipoReferencia.SelectedValue Is Nothing Then Exit Sub
      If cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Cliente) Then
         Try
            If Not e.FilaDevuelta Is Nothing Then
               Me.CargarDatosCliente(e.FilaDevuelta)
               Me.btnConsultar.Focus()
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      ElseIf cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Proveedor) Then
         Try
            If Not e.FilaDevuelta Is Nothing Then
               Me.CargarDatosProveedor(e.FilaDevuelta)
               Me.btnConsultar.Focus()
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If
   End Sub

   Private Sub bscReferencia_BuscadorClick() Handles bscReferencia.BuscadorClick
      If cmbTipoReferencia.SelectedValue Is Nothing Then Exit Sub
      If cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Cliente) Then
         Try
            Me._publicos.PreparaGrillaClientes(Me.bscReferencia)
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes
            Me.bscReferencia.Datos = oClientes.GetFiltradoPorNombre(Me.bscReferencia.Text.Trim(), False)
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      ElseIf cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Proveedor) Then
         Try
            Me._publicos.PreparaGrillaProveedores(Me.bscReferencia)
            Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
            Me.bscReferencia.Datos = oProveedores.GetFiltradoPorNombre(Me.bscReferencia.Text.Trim())
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If
   End Sub

   Private Sub bscReferencia_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscReferencia.BuscadorSeleccion
      If cmbTipoReferencia.SelectedValue Is Nothing Then Exit Sub
      If cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Cliente) Then
         Try
            If Not e.FilaDevuelta Is Nothing Then
               Me.CargarDatosCliente(e.FilaDevuelta)
               Me.btnConsultar.Focus()
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      ElseIf cmbTipoReferencia.SelectedValue.Equals(TipoReferencia.Proveedor) Then
         Try
            If Not e.FilaDevuelta Is Nothing Then
               Me.CargarDatosProveedor(e.FilaDevuelta)
               Me.btnConsultar.Focus()
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscReferencia.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
      Me.bscCodigoReferencia.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString()
      Me.bscCodigoReferencia.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscReferencia.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscReferencia.Text = dr.Cells(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).Value.ToString()
      Me.bscCodigoReferencia.Text = dr.Cells(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()).Value.ToString()
      Me.bscCodigoReferencia.Tag = dr.Cells(Entidades.Proveedor.Columnas.IdProveedor.ToString()).Value.ToString()
      Me.bscReferencia.Tag = dr.Cells(Entidades.Proveedor.Columnas.IdProveedor.ToString()).Value.ToString()
   End Sub

   Private Sub radUnaCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles radUnaCuenta.CheckedChanged
      bscCodCuentaHasta.Enabled = radRango.Checked
      bscDescripcionHasta.Enabled = radRango.Checked
      cmbPlanEnArbolHasta.Enabled = radRango.Checked
      If radUnaCuenta.Checked Then
         bscCodCuentaHasta.Text = String.Empty
         bscDescripcionHasta.Text = String.Empty
      End If
   End Sub

   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged

      Me.chbSaldoInicial.Visible = Me.dtpDesde.Checked
      Me.chbSaldoInicial.Checked = Me.dtpDesde.Checked

   End Sub


   Private Sub chbCentroCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroCosto.CheckedChanged
      Try
         cmbCentroCosto.Enabled = chbCentroCosto.Checked
         If Not chbCentroCosto.Checked Then
            cmbCentroCosto.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub lblCentroCosto_Click(sender As Object, e As EventArgs) Handles lblCentroCosto.Click
      chbCentroCosto.Checked = Not chbCentroCosto.Checked
   End Sub

End Class