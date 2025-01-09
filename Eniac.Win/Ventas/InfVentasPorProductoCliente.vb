Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfVentasPorProductoCliente

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboModelos(Me.cmbModelo)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)
         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         'Me.cmbTiposComprobantes.SelectedIndex = -1

         'Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         'Me.cmbAfectaCaja.Items.Insert(1, "SI")
         'Me.cmbAfectaCaja.Items.Insert(2, "NO")
         'Me.cmbAfectaCaja.SelectedIndex = 1

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         If Not Publicos.ProductoTieneModelo Then
            Me.chbModelo.Visible = False
            Me.cmbModelo.Visible = False
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1


         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"ImporteNeto", "ImporteTotal", "Cantidad", "Kilos"})
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "NombreProducto"})

         PreferenciasLeer(ugDetalle)

         'Hecho en la grilla
         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton

         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True


         Me.cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.NORMAL)
         If Publicos.ProductoPermiteEsCambiable Then
            Me.cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.CAMBIO)
         End If
         If Publicos.ProductoPermiteEsBonificable Then
            Me.cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.BONIFICACION)
         End If

         Me.cmbTipoOperacion.SelectedItem = Entidades.Producto.TiposOperaciones.NORMAL

         Dim visi As Boolean = cmbTipoOperacion.Items.Count > 1

         'Me.cmbTipoOperacion.Visible = visi
         'Me.chbTipoOperacion.Visible = visi
         'Me.lblNota.Visible = visi
         'Me.cmbTipoOperacion.Visible = visi

         Me._estaCargando = False

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfVentasPorProductoCliente_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

   'Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

   '   Try

   '      Dim Filtros As String

   '      Me.Cursor = Cursors.WaitCursor

   '      Filtros = "Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

   '      If Me.chbMarca.Checked Then
   '         If Filtros.Length > 0 Then Filtros += " / "
   '         Filtros += "Marca: " & Me.cmbMarca.Text
   '      End If

   '      If Me.chbModelo.Checked Then
   '         If Filtros.Length > 0 Then Filtros += " / "
   '         Filtros += "Modelo: " & Me.cmbModelo.Text
   '      End If

   '      If Me.chbRubro.Checked Then
   '         If Filtros.Length > 0 Then Filtros += " / "
   '         Filtros += "Rubro: " & Me.cmbRubro.Text
   '      End If

   '      If Me.chbSubRubro.Checked Then
   '         If Filtros.Length > 0 Then Filtros += " / "
   '         Filtros += "SubRubro: " & Me.cmbSubRubro.Text
   '      End If

   '      If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
   '         Filtros += " / Zona Geografica: " & Me.cmbZonaGeografica.Text
   '      End If

   '      If Me.chbTipoComprobante.Checked Then
   '         Filtros += " / Comprobante: " & Me.cmbTiposComprobantes.Text
   '      End If

   '      Dim dt As DataTable

   '      dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

   '      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

   '      Dim frmImprime As VisorReportes

   '      If Me.chkExpandAll.Checked Then
   '         frmImprime = New VisorReportes("Eniac.Win.InfVentasPorProductoCliente.rdlc", "DSReportes_InfVentasPorProductoCliente", dt, parm, True)
   '      Else
   '         frmImprime = New VisorReportes("Eniac.Win.InfVentasPorProducto.rdlc", "DSReportes_InfVentasPorProductoCliente", dt, parm, True)
   '      End If

   '      frmImprime.Text = Me.Text
   '      frmImprime.WindowState = FormWindowState.Maximized
   '      frmImprime.Show()

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   Finally
   '      Me.Cursor = Cursors.Default
   '   End Try

   'End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion()

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
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
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
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
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
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Try
         Me.cmbMarca.Enabled = Me.chbMarca.Checked

         If Not Me.chbMarca.Checked Then
            Me.cmbMarca.SelectedIndex = -1
         Else
            If Me.cmbMarca.Items.Count > 0 Then
               Me.cmbMarca.SelectedIndex = 0
            End If
         End If

         Me.cmbMarca.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbModelo.CheckedChanged
      Try
         Me.cmbModelo.Enabled = Me.chbModelo.Checked

         If Not Me.chbModelo.Checked Then
            Me.cmbModelo.SelectedIndex = -1
         Else
            If Me.cmbModelo.Items.Count > 0 Then
               Me.cmbModelo.SelectedIndex = 0
            End If
         End If

         Me.cmbModelo.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Try
         Me.cmbRubro.Enabled = Me.chbRubro.Checked

         If Not Me.chbRubro.Checked Then
            Me.cmbRubro.SelectedIndex = -1
         Else
            If Me.cmbRubro.Items.Count > 0 Then
               Me.cmbRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbRubro.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbMarca.Checked = False
      Me.chbModelo.Checked = False
      Me.chbRubro.Checked = False
      Me.chbSubRubro.Checked = False
      Me.chbZonaGeografica.Checked = False
      'Me.cmbAfectaCaja.SelectedIndex = 1

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      Me.chbTipoComprobante.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVProd As Reglas.VentasProductos = New Reglas.VentasProductos()

         Dim idMarca As Integer = 0
         Dim idModelo As Integer = 0
         Dim idRubro As Integer = 0
         Dim idSubRubro As Integer = 0
         Dim zonaGeografica As String = String.Empty
         Dim idTipoComprobante As String = String.Empty
         Dim tipoOperacion As Entidades.Producto.TiposOperaciones?

         If Me.cmbMarca.Enabled Then
            idMarca = Int32.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If
         If Me.cmbModelo.Enabled Then
            idModelo = Int32.Parse(Me.cmbModelo.SelectedValue.ToString())
         End If
         If Me.cmbRubro.Enabled Then
            idRubro = Int32.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If
         If Me.cmbSubRubro.Enabled Then
            idSubRubro = Int32.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            zonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            idTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If cmbTipoOperacion.Enabled Then
            tipoOperacion = DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones)
         End If

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oVProd.GetTotalesPorProductosClientes(actual.Sucursal.Id,
                                                           Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                           idMarca,
                                                           idModelo,
                                                           idRubro,
                                                           idSubRubro,
                                                           zonaGeografica,
                                                           idTipoComprobante,
                                                           tipoOperacion,
                                                           cmbNota.Text)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = dr("CodigoCliente")
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            If Not String.IsNullOrEmpty(dr("IdUnidadDeMedida").ToString()) Then
               drCl("Tamano") = Decimal.Parse(dr("Tamano").ToString())
               drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida")
            End If
            drCl("ImporteNeto") = Decimal.Parse(dr("ImporteNeto").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())
            drCl("Kilos") = Decimal.Parse(dr("Kilos").ToString())

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", GetType(String))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("Tamano", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("ImporteNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

#End Region


   Private Sub chbTipoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoOperacion.CheckedChanged
      Try
         Me.cmbTipoOperacion.Enabled = Me.chbTipoOperacion.Checked

         If Not Me.chbTipoOperacion.Checked Then
            Me.cmbTipoOperacion.SelectedIndex = -1
            'Me.cmbNota.Text = ""
            'Me.cmbNota.Enabled = True
         Else
            'Me.cmbNota.Enabled = False
            If Me.cmbTipoOperacion.Items.Count > 0 Then
               Me.cmbTipoOperacion.SelectedIndex = 0
            End If
         End If

         Me.cmbTipoOperacion.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
      Try
         If cmbTipoOperacion.SelectedIndex > -1 Then
            _publicos.CargaComboObservaciones(cmbNota, DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones))
         Else
            cmbNota.Items.Clear()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            .AppendFormat(" Zona G.: {0} - ", Me.cmbZonaGeografica.SelectedText)
         End If

         If Me.cmbMarca.SelectedIndex >= 0 Then
            .AppendFormat(" Marca: {0} - ", Me.cmbMarca.SelectedText)
         End If

         If Me.cmbRubro.SelectedIndex >= 0 Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.SelectedText)
         End If

         If Me.cmbTiposComprobantes.SelectedIndex >= 0 Then
            .AppendFormat(" Tipo Comprobante: {0} -", Me.cmbTiposComprobantes.SelectedText)
         End If

         If Me.cmbTipoOperacion.SelectedIndex >= 0 Then
            .AppendFormat(" Tipo Comprobante: {0} -", Me.cmbTipoOperacion.SelectedText)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      If Me._estaCargando Then Exit Sub
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteNeto").Hidden = Me.chbConIVA.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = Not Me.chbConIVA.Checked
   End Sub
End Class