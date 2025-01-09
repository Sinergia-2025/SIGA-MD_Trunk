#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win.UltraWinGrid
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class InfUtilidadesPorProducto

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         Me.cmbMarca.ValueMember = "IdMarca"
         Me.cmbMarca.DisplayMember = "NombreMarca"

         Me.cmbMarca.DataSource = oMarca.GetAll()
         Me.cmbMarca.SelectedIndex = -1

         Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         Me.cmbRubro.ValueMember = "IdRubro"
         Me.cmbRubro.DisplayMember = "NombreRubro"

         Me.cmbRubro.DataSource = oRubro.GetAll()
         Me.cmbRubro.SelectedIndex = -1
         Me._publicos.CargaComboDesdeEnum(Me.cmbEsComercial, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         '-.PE-31806.-
         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         Ayudante.Grilla.AgregarTotalesSuma(ugUtilXProducto, {"Costo", "Total", "Utilidad", "CostoConImpuestos", "TotalConImpuestos", "UtilidadConImpuestos"})
         Ayudante.Grilla.AgregarTotalCustomColumna(ugUtilXProducto, "Margen", New Ayudante.CustomSummaries.SummaryMargen("Utilidad", "Total", "Margen"))
         Ayudante.Grilla.AgregarTotalCustomColumna(ugUtilXProducto, "MargenConImpuestos", New Ayudante.CustomSummaries.SummaryMargen("UtilidadConImpuestos", "TotalConImpuestos", "MargenConImpuestos"))

         Ayudante.Grilla.AgregarFiltroEnLinea(ugUtilXProducto, {"NombreProducto"})

         _tit = GetColumnasVisiblesGrilla(ugUtilXProducto)

         Me.LeerPreferencias()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub UtilidadesPorProducto_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.ugUtilXProducto.Rows.Count = 0 Then Exit Sub

      Try

         Dim Filtros As String

         Me.Cursor = Cursors.WaitCursor

         Filtros = CargarFiltrosImpresion()

         Dim dt As DataTable

         dt = DirectCast(Me.ugUtilXProducto.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfUtilidadesPorProducto.rdlc", "SistemaDataSet_UtilidadesPorProducto", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      Try

         If Me.ugUtilXProducto.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = CargarFiltrosImpresion()

         Dim Titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraGridPrintDocument1.Grid = ugUtilXProducto

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
         Dim grilla As UltraGrid
         grilla = ugUtilXProducto

         If grilla.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = String.Format("{0}.xls", Me.Name)
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(grilla, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Dim grilla As UltraGrid
         grilla = ugUtilXProducto

         If grilla.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = String.Format("{0}.pdf", Me.Name)
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(grilla, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugUtilXProducto, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
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

         dtpDesde.Enabled = Not chkMesCompleto.Checked
         dtpHasta.Enabled = Not chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         Me.cmbVendedor.SelectedIndex = 0
         Me.cmbVendedor.Focus()
      End If
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         If Me.cmbMarca.Items.Count > 0 Then
            Me.cmbMarca.SelectedIndex = 0
         End If
      End If
   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If
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

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub
#End Region

#Region "Eventos Busquedas"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugUtilXProducto.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      Try
         With ugUtilXProducto.DisplayLayout.Bands(0)
            If .Columns.Exists("Costo") Then

               .Columns("CostoUnitario").Hidden = chbConIVA.Checked
               .Columns("Costo").Hidden = chbConIVA.Checked
               .Columns("Total").Hidden = chbConIVA.Checked
               .Columns("Utilidad").Hidden = chbConIVA.Checked
               .Columns("Margen").Hidden = chbConIVA.Checked

               .Columns("CostoUnitarioConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("CostoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("TotalConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("UtilidadConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("MargenConImpuestos").Hidden = Not chbConIVA.Checked
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.chbVendedor.Checked = False

      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbProducto.Checked = False

      Me.bscProducto2.Text = ""
      Me.bscCodigoProducto2.Text = ""

      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA
      Me.cmbEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      If Not Me.ugUtilXProducto.DataSource Is Nothing Then
         DirectCast(Me.ugUtilXProducto.DataSource, DataTable).Rows.Clear()
      End If

      'Me.txtTotal.Text = "0.00"
      'Me.txtTotalUtilidad.Text = "0.00"
      'Me.txtTotalMargen.Text = "0.00"

      cmbSucursal.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

         Dim IdVendedor As Integer = 0

         Dim IdMarca As Integer = 0
         Dim IdRubro As Integer = 0
         Dim idSubRubro As Integer = 0

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.chbMarca.Checked Then
            IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If

         If Me.chbRubro.Checked Then
            IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.cmbSubRubro.Enabled Then
            idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If

         Dim decTotalMargen As Decimal

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oVentas.GetUtilidadesPorProducto(cmbSucursal.GetSucursales(),
                                                      Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                      IdVendedor,
                                                      IdMarca,
                                                      IdRubro,
                                                      idSubRubro,
                                                      bscCodigoProducto2.Text,
                                                      DirectCast(Me.cmbEsComercial.SelectedValue, Entidades.Publicos.SiNoTodos))

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = dr("IdSucursal") '-.PE-31806.-
            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()

            drCl("Total") = Decimal.Parse(dr("Total").ToString())
            drCl("Cantidad") = dr("Cantidad")
            drCl("Costo") = dr("Costo")
            Dim cantidad As Decimal = Decimal.Parse(dr("Cantidad").ToString())
            Try
               drCl("CostoUnitario") = Decimal.Parse(dr("Costo").ToString()) / If(cantidad = 0, 1, cantidad)
            Catch ex As Exception
               drCl("CostoUnitario") = 0
            End Try
            drCl("Utilidad") = Decimal.Parse(dr("Utilidad").ToString())
            If Decimal.Parse(drCl("Total").ToString()) > 0 Then
               Dim total As Decimal = Decimal.Parse(dr("Total").ToString())
               decTotalMargen = Decimal.Round(Decimal.Parse(drCl("Utilidad").ToString()) / If(total = 0, 1, total) * 100, 2)
            Else
               decTotalMargen = 0
            End If
            drCl("Margen") = decTotalMargen


            drCl("TotalConImpuestos") = dr("TotalConImpuestos")
            drCl("CostoConImpuestos") = dr("CostoConImpuestos")

            Try
               drCl("CostoUnitarioConImpuestos") = Decimal.Parse(dr("CostoConImpuestos").ToString()) / cantidad
            Catch ex As Exception
               drCl("CostoUnitarioConImpuestos") = 0
            End Try


            drCl("UtilidadConImpuestos") = dr("UtilidadConImpuestos")
            If Decimal.Parse(drCl("TotalConImpuestos").ToString()) > 0 Then
               Dim total As Decimal = Decimal.Parse(drCl("TotalConImpuestos").ToString())
               decTotalMargen = Decimal.Round(Decimal.Parse(drCl("UtilidadConImpuestos").ToString()) / If(total = 0, 1, total) * 100, 2)
            Else
               decTotalMargen = 0
            End If
            drCl("MargenConImpuestos") = decTotalMargen

            drCl("Stock") = dr("Stock")

            dt.Rows.Add(drCl)

         Next

         ugUtilXProducto.DataSource = dt

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdSucursal", System.Type.GetType("System.String")) '-.PE-31806.-
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("Cantidad", GetType(Decimal))
         .Columns.Add("Costo", System.Type.GetType("System.Decimal"))
         .Columns.Add("CostoUnitario", GetType(Decimal))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("Utilidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Margen", System.Type.GetType("System.Decimal"))

         .Columns.Add("CostoUnitarioConImpuestos", GetType(Decimal))
         .Columns.Add("CostoConImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalConImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("UtilidadConImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("MargenConImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("Stock", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim IdVendedor As Integer

      Dim Primero As Boolean = True
      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1}", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

            .AppendFormat(" - Vendedor: {0} - {1}", IdVendedor, Me.cmbVendedor.Text)
         End If

         If Me.chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            .AppendFormat(" - SubRubro: {0}", cmbSubRubro.Text)
         End If

         .AppendFormat(" - Precios Con IVA: {0}", IIf(Me.chbConIVA.Checked, "SI", "NO"))
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugUtilXProducto.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugUtilXProducto.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class