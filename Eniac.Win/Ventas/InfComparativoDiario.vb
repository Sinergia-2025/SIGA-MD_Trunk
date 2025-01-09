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
Public Class InfComparativoDiario

#Region "Campos"

   Private _publicos As Publicos
   Private _dt As DataTable
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)

         _publicos.CargaComboDesdeEnum(cmbCampoTotalizar, GetType(Entidades.Publicos.ComparativoDiario_CampoTotalizar))
         _publicos.CargaComboDesdeEnum(cmbColumnasMostrar, GetType(Entidades.Publicos.ComparativoDiario_ColumnasMostrar))

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfKilosCompMensualPorCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimirInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirInf.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = CargarFiltrosImpresion()

         Dim Titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Try

         If chkMesCompleto.Checked Then
            Me.dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            Me.dtpHasta.Value = dtpDesde.Value.UltimoDiaMes(True)
         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked
      Catch ex As Exception
         chkMesCompleto.Checked = False

         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

         If Not Me.chbVendedor.Checked Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            End If
         End If

         Me.cmbVendedor.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked
         If Not Me.chbCliente.Checked Then
            Me.bscCodigoCliente.Text = String.Empty
            Me.bscCodigoCliente.Tag = Nothing
            Me.bscCliente.Text = String.Empty
         Else
            Me.bscCodigoCliente.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged
      Try
         Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked
         If Not Me.chbZonaGeografica.Checked Then
            Me.cmbZonaGeografica.SelectedIndex = -1
         Else
            If Me.cmbZonaGeografica.Items.Count > 0 Then
               Me.cmbZonaGeografica.SelectedIndex = 0
            End If

            Me.cmbZonaGeografica.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged
      Try
         Me.bscCodigoLocalidad.Enabled = Me.chbLocalidad.Checked
         Me.bscNombreLocalidad.Enabled = Me.chbLocalidad.Checked

         Me.bscCodigoLocalidad.Text = String.Empty
         Me.bscNombreLocalidad.Text = String.Empty

         Me.bscCodigoLocalidad.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Try
         Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
         Me.bscProducto2.Enabled = Me.chbProducto.Checked

         'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
         If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
         Else
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbMarca.Checked = False
            chbRubro.Checked = False
         End If

         Me.bscCodigoProducto2.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
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
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
         End If

         Me.cmbMarca.Focus()
      Catch ex As Exception
         ShowError(ex)
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
            'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
            'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
         End If

         Me.cmbRubro.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If IsNumeric(Me.bscCodigoCliente.Text) Then
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
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
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


   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("ATENCION: El periodo Desde es INVALIDO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un CLIENTE aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Me.bscCodigoProducto2.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un PRODUCTO aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbLocalidad.Checked And Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una LOCALIDAD aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar una ZONA GEOGRÁFICA.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar una MARCA.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca.Focus()
            Exit Sub
         End If

         If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un RUBRO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbRubro.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If _dt.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub cmbCampoTotalizar_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCampoTotalizar.SelectedValueChanged
      Try
         If cmbCampoTotalizar.SelectedValue IsNot Nothing Then
            chbConIVA.Enabled = cmbCampoTotalizar.SelectedValue.ToString() = "IMPORTE"
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub
#End Region

#Region "Métodos"
#Region "Métodos Busquedas Foráneas"
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscCodigoLocalidad.Enabled = False
      Me.bscNombreLocalidad.Enabled = False
   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
   End Sub
#End Region

   Private Sub RefrescarDatosGrilla()
      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me.chbCliente.Checked = False

      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbProducto.Checked = False

      Me.chbLocalidad.Checked = False

      chkExpandAll.Checked = True

      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      cmbCampoTotalizar.SelectedValue = Entidades.Publicos.ComparativoDiario_CampoTotalizar.CANTIDAD
      cmbColumnasMostrar.SelectedValue = Entidades.Publicos.ComparativoDiario_ColumnasMostrar.SEPARADO

      'Limpio la Grilla.
      If _dt IsNot Nothing Then _dt.Clear()

      Me.dtpDesde.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         Dim IdVendedor As Integer = 0

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         Dim idCliente As Long = 0
         If Me.chbCliente.Checked Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim idZonaGeografica As String = String.Empty
         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         Dim idMarca As Integer = 0
         If Me.chbMarca.Checked Then
            idMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If

         Dim idRubro As Integer = 0
         If Me.chbRubro.Checked Then
            idRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         Dim idProducto As String = String.Empty
         If Me.chbProducto.Checked Then
            idProducto = Me.bscCodigoProducto2.Text
         End If

         Dim idLocalidad As Integer = 0
         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            idLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         Dim campoTotalizar As Entidades.Publicos.ComparativoDiario_CampoTotalizar = DirectCast(cmbCampoTotalizar.SelectedValue, Entidades.Publicos.ComparativoDiario_CampoTotalizar)

         Dim dtTemp As DataTable = _dt
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         _dt = oVentas.GetInfComparativoDiario({actual.Sucursal},
                                               dtpDesde.Value, dtpHasta.Value,
                                               IdVendedor,
                                               idCliente,
                                               idMarca,
                                               idRubro,
                                               idProducto,
                                               idZonaGeografica,
                                               idLocalidad,
                                               campoTotalizar,
                                               chbConIVA.Checked)

         Me.ugDetalle.DataSource = _dt

         If dtTemp IsNot Nothing Then dtTemp.Dispose()

         Me.FormatearGrilla()

         chkExpandAll.Checked = False
         chkExpandAll.Checked = True
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()
      ugDetalle.InicializaTotales()
      ugDetalle.AgregarFiltroEnLinea({"NombreVendedor", "NombreProducto"})
      AjustarColumnasGrilla(ugDetalle, _tit)

      Dim col As Integer = ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Header.VisiblePosition + 1
      For Each columna As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
         If Not _tit.ContainsKey(columna.Key) Then
            Dim splittedKey As String() = columna.Key.Split("_"c)
            If splittedKey.Length > 1 Then
               Dim fecha As DateTime = DateTime.ParseExact(splittedKey(0), "yyyyMMdd", Nothing)
               Dim tipo As String
               Dim hidden As Boolean
               Select Case splittedKey(1)
                  Case "cv"
                     tipo = "Venta"
                     hidden = Not cmbColumnasMostrar.SelectedValue.Equals(Entidades.Publicos.ComparativoDiario_ColumnasMostrar.SEPARADO)
                  Case "cd"
                     tipo = "Devolución"
                     hidden = Not cmbColumnasMostrar.SelectedValue.Equals(Entidades.Publicos.ComparativoDiario_ColumnasMostrar.SEPARADO)
                  Case Else
                     tipo = ""
                     hidden = Not cmbColumnasMostrar.SelectedValue.Equals(Entidades.Publicos.ComparativoDiario_ColumnasMostrar.CONSOLIDADO)
               End Select
               Dim caption As String = String.Format("{0:dd/MM/yyyy} {1}", fecha, tipo)
               FormatearColumna(columna, caption, col, 70, HAlign.Right, hidden, "N2").Header.Appearance.TextHAlign = HAlign.Center
               ugDetalle.AgregarTotalSumaColumna(columna)
            End If
         End If
      Next
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.SelectedText)
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            .AppendFormat(" Zona G.: {0} - ", Me.cmbZonaGeografica.SelectedText)
         End If

         If chbCliente.Checked And Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbMarca.SelectedIndex >= 0 Then
            .AppendFormat(" Marca: {0} - ", Me.cmbMarca.SelectedText)
         End If

         If Me.cmbRubro.SelectedIndex >= 0 Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.SelectedText)
         End If

         If chbProducto.Checked And Me.bscCodigoProducto2.Text.Length > 0 And Me.bscProducto2.Text.Length > 0 Then
            .AppendFormat(" Producto: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If chbLocalidad.Checked And Me.bscCodigoLocalidad.Text.Length > 0 And Me.bscNombreLocalidad.Text.Length > 0 Then
            .AppendFormat(" Localidad: {0} - {1} - ", Me.bscCodigoLocalidad.Text, Me.bscNombreLocalidad.Text)
         End If

         .AppendFormat("Totaliza - ", cmbCampoTotalizar.Text)

         If chbConIVA.Enabled Then
            If chbConIVA.Checked Then
               .AppendFormat("Con IVA - ")
            Else
               .AppendFormat("Sin IVA - ")
            End If
         End If

         .AppendFormat("Mostrando - ", cmbColumnasMostrar.Text)

      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

End Class