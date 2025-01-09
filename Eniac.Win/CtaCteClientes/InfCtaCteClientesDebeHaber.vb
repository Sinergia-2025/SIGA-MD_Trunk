Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports System.Windows.Forms.DataVisualization.Charting

Public Class InfCtaCteClientesDebeHaber

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _tit As Dictionary(Of String, String)
   Private _vieneDeOnLoad As Boolean = False
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

         _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

         _vieneDeOnLoad = True
         'Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , , , True)
         'Me.cmbTiposComprobantes.SelectedIndex = -1
         cmbTiposComprobantes.Initializar(False, "VENTAS", "CTACTECLIE")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         _vieneDeOnLoad = False


         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"ImporteTotalDebe", "ImporteTotalHaber", "Saldo"})
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "Observacion", "NombreClienteCtaCte"})

         Me.LeerPreferencias()

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal


         If Not Publicos.TieneModuloContabilidad Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ugDetalle_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 And e.Cell.Column.Key = "Ver" Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString())

            If oTipoComprobante.EsRecibo = True Then
               'imprime los recibos
               Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
               Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                             Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                             Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                             Int32.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                             Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))
               Dim imp As RecibosImprimir = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            Else
               Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                           Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                           Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

               Dim oImpr As Impresion = New Impresion(venta)

               If Not oTipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If

            End If
         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub
   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      Try
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         KardexComprobCtaCteClientesUC1.RefrescarDatosGrilla()
         If dr IsNot Nothing Then
            If Not Boolean.Parse(dr("EsRecibo").ToString()) Then
               KardexComprobCtaCteClientesUC1.CargaGrillaDetalle(Integer.Parse(dr("IdSucursal").ToString()),
                                                                 dr("IdTipoComprobante").ToString(),
                                                                 dr("Letra").ToString(),
                                                                 Short.Parse(dr("CentroEmisor").ToString()),
                                                                 Long.Parse(dr("NumeroComprobante").ToString()))
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub InfCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = "0 Registros"
      Catch ex As Exception
         ShowError(ex)
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
         ShowError(ex)
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
      Catch ex As Exception
         ShowError(ex)
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
         ShowError(ex)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked
      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If
         Me.cmbZonaGeografica.Focus()
      End If
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      cmbVendedor.Enabled = chbVendedor.Checked
      cmbOrigenVendedor.Enabled = chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
         Me.cmbVendedor.Focus()
      End If
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = chbCliente.Checked
      Me.bscCodigoCliente.Enabled = chbCliente.Checked

      If chbFecha.Checked AndAlso chbCliente.Checked Then
         VerificarControles(True)
      Else
         VerificarControles(False)
      End If



      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            '_listaTipoComprobante = New List(Of Entidades.TipoComprobante)()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

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
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged
      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If chbFecha.Checked AndAlso chbCliente.Checked Then
         VerificarControles(True)
      Else
         VerificarControles(False)
      End If

      If Me.chbFecha.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
         Me.txtSaldoActual.Text = "0.00"
         Me.txtSaldoInicial.Text = "0.00"
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked
      cmbOrigenCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un Vendedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         If Me.chbGrupo.Checked And Me.cmbGrupos.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         If Me.chbCategoria.Checked And Me.cmbCategoria.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbCategoria.Focus()
            Exit Sub
         End If

         If Me.chbProvincia.Checked And Me.cmbProvincia.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Provincia aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbProvincia.Focus()
            Exit Sub
         End If



         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
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

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      Try
         Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

         If Not Me.chbGrupo.Checked Then
            Me.cmbGrupos.SelectedIndex = -1
         Else
            If Me.cmbGrupos.Items.Count > 0 Then
               Me.cmbGrupos.SelectedIndex = 0
            End If
         End If

         Me.cmbGrupos.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.chbCliente.Checked = False
      Me.chbFecha.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      Me.chbGrupo.Checked = False
      Me.cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual
      Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

      Me.chbExcluirMinutas.Checked = True

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      KardexComprobCtaCteClientesUC1.RefrescarDatosGrilla()

      Me.chbAgruparIdClienteCtaCte.Checked = False

      cmbSucursal.Refrescar()

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Me.ugDetalle.Update()

      Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim IdVendedor As Integer = 0
      Dim IdCliente As Long = 0
      Dim IdZonaGeografica As String = String.Empty
      Dim Desde As Date?
      Dim Hasta As Date?
      'Dim TipoComprobante As String = String.Empty
      Dim IdCategoria As Integer = 0
      Dim Grupo As String = String.Empty
      Dim excluirPreComprobantes As Boolean = Me.chbExcluirPreComprobantes.Checked
      Dim IdProvincia As String = String.Empty
      Dim origenCategoria As Entidades.OrigenFK
      Dim origenVendedor As Entidades.OrigenFK
      Dim ExcluirMinutas As String = "NO"

      Dim Total As Decimal = 0

      Try

         '---------------------------------------------------------------------------------------------
         Dim graba As Boolean? = Nothing
         If Me.cmbGrabanLibro.Text <> "TODOS" Then
            graba = Me.cmbGrabanLibro.Text = "SI"
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbFecha.Checked Then
            Desde = Me.dtpDesde.Value
            Hasta = Me.dtpHasta.Value
            Me.txtSaldoInicial.Text = oCtaCte.GetSaldoCliente(cmbSucursal.GetSucursales(), IdCliente, Desde.Value.AddDays(-1), False, "TODOS", graba, Nothing, "", excluirPreComprobantes, 0, 0).ToString("#,##0.00")
         Else
            Me.txtSaldoInicial.Text = "0.00"
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbGrupos.Enabled Then
            Grupo = Me.cmbGrupos.SelectedValue.ToString()
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            excluirPreComprobantes = True
         End If

         Me.txtSaldoActual.Text = oCtaCte.GetSaldoCliente(cmbSucursal.GetSucursales(), IdCliente, Nothing, False, "TODOS", graba, Nothing, "", excluirPreComprobantes, 0, 0).ToString("#,##0.00")

         If Me.chbProvincia.Checked Then
            IdProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         origenCategoria = DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK)
         origenVendedor = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)

         If Me.chbExcluirMinutas.Checked Then
            ExcluirMinutas = "SI"
         End If

         Dim dtDetalle As DataTable

         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
         tiposComprobantes.AddRange(cmbTiposComprobantes.GetTiposComprobantes())

         dtDetalle = oCtaCte.GetCtaCteDebeHaber(Me.cmbSucursal.GetSucursales(),
                                                Desde, Hasta,
                                                IdVendedor, origenVendedor,
                                                IdCliente,
                                                tiposComprobantes,
                                                IdZonaGeografica,
                                                IdCategoria, origenCategoria,
                                                Me.cmbGrabanLibro.Text,
Grupo,
                                                excluirPreComprobantes,
                                                IdProvincia, ExcluirMinutas,
                                                chbAgruparIdClienteCtaCte.Checked)

         Me.ugDetalle.DataSource = dtDetalle

         With ugDetalle.DisplayLayout.Bands(0)
            If chbAgruparIdClienteCtaCte.Checked Then
               .Columns("CodigoClienteCtaCte").Header.Caption = "Código Original"
               .Columns("NombreClienteCtaCte").Header.Caption = "Cliente Original"
            Else
               .Columns("CodigoClienteCtaCte").Header.Caption = "Código Cta.Cte."
               .Columns("NombreClienteCtaCte").Header.Caption = "Cliente Cta.Cte."
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} ({1}) - ", Me.cmbVendedor.Text, cmbOrigenVendedor.SelectedValue.ToString() & ")")
         End If

         If Me.chbFecha.Checked Then
            .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbGrupo.Checked Then
            .AppendFormat(" Grupo: {0} - ", Me.cmbGrupos.Text)
         End If

         If Me.cmbGrabanLibro.Text <> "TODOS" Then
            .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            .AppendFormat("Excluir Pre-Comprobantes - ")
         End If

         If Me.chbAgruparIdClienteCtaCte.Checked Then
            .AppendFormat("Agrupados por Cliente de Cta. Cte. - ")
         End If

         'Minuta nunca tendria saldo solo.
         If Me.chbExcluirMinutas.Checked Then
            .AppendFormat("Excluir Minutas - ")
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoría: {0} ({1}) - ", Me.cmbCategoria.Text, cmbOrigenVendedor.SelectedValue.ToString())
         End If

         If Me.chbProvincia.Checked Then
            .AppendFormat(" Provincia: {0} - ", Me.cmbProvincia.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub VerificarControles(habilitado As Boolean)
      ' Mostrar u ocultar controles relacionados con saldos
      Me.lblSaldoActual.Visible = habilitado
      Me.txtSaldoActual.Visible = habilitado

      Me.lblSaldoInicial.Visible = habilitado
      Me.txtSaldoInicial.Visible = habilitado

      pnlSaldoInicial.Visible = habilitado
   End Sub

#End Region

End Class