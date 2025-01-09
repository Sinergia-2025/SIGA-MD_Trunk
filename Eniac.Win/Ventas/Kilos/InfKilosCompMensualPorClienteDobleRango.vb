Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfKilosCompMensualPorClienteDobleRango

#Region "Campos"

   Private _publicos As Publicos
   Private _periodos As Long
   Private _periodos2 As Long

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)

         'Me._publicos.CargaComboMarcas(Me.cmbMarca)
         'Me._publicos.CargaComboRubros(Me.cmbRubro)
         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         '-.PE-31811.-
         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         Me.CargarColumnasASumar()

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
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

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
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
   Private Sub InfKilosCompMensualPorCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

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

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Dim Filtros As String = Me.CargarFiltrosImpresion

         Me.Cursor = Cursors.WaitCursor

         'Dim IdVendedor As Integer

         'Filtros = "Rango 1: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text & " - Rango 2: desde el " & Me.dtpDesde2.Text & " hasta el " & Me.dtpHasta2.Text

         'If Me.chbVendedor.Checked Then
         '   IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

         '   Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         'End If

         'If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
         '   Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         'End If

         'If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
         '   Filtros = Filtros & " / Zona Geografica: " & Me.cmbZonaGeografica.Text
         'End If

         'If Me.chbMarca.Checked Then
         '   Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
         'End If

         'If Me.chbRubro.Checked Then
         '   Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         'End If

         'If Me.chbProducto.Checked Then
         '   Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
         'End If

         'If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
         '   Filtros = Filtros & " / Localidad: " & Me.bscCodigoLocalidad.Text.Trim() & " - " & Me.bscNombreLocalidad.Text.Trim()
         'End If

         'If Me.rbtPorKilos.Checked Then
         '   Filtros = Filtros & " / Por Kilos"
         'Else
         '   Filtros = Filtros & " / Por Importe " & IIf(Me.chbConIVA.Checked, "Con IVA", "Sin IVA").ToString()
         'End If

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
      Finally
         Me.Cursor = Cursors.Default
      End Try

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

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub
   Private Sub chkMesCompleto2_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto2.CheckedChanged

      Dim FechaTemp As Date

      Try
         If chkMesCompleto2.Checked Then

            FechaTemp = New Date(Me.dtpDesde2.Value.Year, Me.dtpDesde2.Value.Month, 1)
            Me.dtpDesde2.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde2.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta2.Value = FechaTemp

         End If

         Me.dtpDesde2.Enabled = Not Me.chkMesCompleto2.Checked
         Me.dtpHasta2.Enabled = Not Me.chkMesCompleto2.Checked

      Catch ex As Exception
         Me.chkMesCompleto2.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Permitido = Me.chbCliente.Checked
      Me.bscCodigoCliente.Permitido = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty
      Else
         Me.bscCodigoCliente.Focus()
      End If
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
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
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
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

   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged

      Me.bscCodigoLocalidad.Permitido = Me.chbLocalidad.Checked
      Me.bscNombreLocalidad.Permitido = Me.chbLocalidad.Checked

      Me.bscCodigoLocalidad.Text = String.Empty
      Me.bscNombreLocalidad.Text = String.Empty

      Me.bscCodigoLocalidad.Focus()

   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         If Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("ATENCION: El periodo Rango 1 Desde es INVALIDO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         If Me.dtpDesde2.Value.Date > Me.dtpHasta2.Value.Date Then
            MessageBox.Show("ATENCION: El periodo Rango 2 Desde es INVALIDO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde2.Focus()
            Exit Sub
         End If

         Me._periodos = DateDiff(DateInterval.Month, Me.dtpDesde.Value.Date, Me.dtpHasta.Value.Date) + 1
         If Me._periodos > 12 Then
            MessageBox.Show("ATENCION: No puede elegir mas de 12 meses.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         Me._periodos2 = DateDiff(DateInterval.Month, Me.dtpDesde2.Value.Date, Me.dtpHasta2.Value.Date) + 1
         If Me._periodos2 > 12 Then
            MessageBox.Show("ATENCION: No puede elegir mas de 12 meses.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde2.Focus()
            Exit Sub
         End If
         'If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbVendedor.Focus()
         '   Exit Sub
         'End If

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

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
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

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
         'chbMarca.Checked = False
         'chbRubro.Checked = False
      End If

      Me.bscCodigoProducto2.Focus()

   End Sub

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

   'Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Me.cmbMarca.Enabled = Me.chbMarca.Checked

   '   If Not Me.chbMarca.Checked Then
   '      Me.cmbMarca.SelectedIndex = -1
   '   Else
   '      If Me.cmbMarca.Items.Count > 0 Then
   '         Me.cmbMarca.SelectedIndex = 0
   '      End If
   '      'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
   '      'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
   '      Me.chbProducto.Checked = False
   '   End If

   '   Me.cmbMarca.Focus()

   'End Sub

   'Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Me.cmbRubro.Enabled = Me.chbRubro.Checked

   '   If Not Me.chbRubro.Checked Then
   '      Me.cmbRubro.SelectedIndex = -1
   '   Else
   '      If Me.cmbRubro.Items.Count > 0 Then
   '         Me.cmbRubro.SelectedIndex = 0
   '      End If
   '      'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
   '      'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
   '      Me.chbProducto.Checked = False
   '   End If

   '   Me.cmbRubro.Focus()

   'End Sub
   Private Sub rbtPorMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPorMonto.CheckedChanged
      Try
         If Me.rbtPorMonto.Checked Then
            Me.chbConIVA.Visible = True
         Else
            Me.chbConIVA.Visible = False
         End If

      Catch ex As Exception

      End Try
   End Sub
   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub

   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub

   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)

      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscCodigoLocalidad.Permitido = False
      Me.bscNombreLocalidad.Permitido = False

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now.AddYears(-2)
      Me.dtpHasta.Value = Date.Now.AddMonths(-1).AddYears(-1)

      Me.chkMesCompleto2.Checked = False
      Me.dtpDesde2.Value = Date.Now.AddYears(-1)
      Me.dtpHasta2.Value = Date.Now.AddMonths(-1)

      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me.chbCliente.Checked = False

      'Me.chbMarca.Checked = False
      'Me.chbRubro.Checked = False
      Me.chbProducto.Checked = False

      Me.chbLocalidad.Checked = False
      Me.rbtPorKilos.Checked = True
      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      cmbSucursal.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0

      Dim IdVendedor As Integer = 0

      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim IdProducto As String = String.Empty

      Dim IdZonaGeografica As String = String.Empty

      Dim IdLocalidad As Integer = 0

      Dim decTotalKilos As Decimal = 0

      Dim TipoInforme As String = String.Empty

      Dim dtDetalle As DataTable, dtDetalle2 As DataTable, dt As DataTable, drCl As DataRow


      Try

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         'If Me.chbMarca.Checked Then
         '   IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         'End If

         'If Me.chbRubro.Checked Then
         '   IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         'End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         TipoInforme = IIf(Me.rbtPorKilos.Checked, "KILOS", "IMPORTE").ToString()


         dtDetalle = oVentas.GetKilosCompMensualPorCliente(cmbSucursal.GetSucursales(),
                                                           Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                           IdVendedor,
                                                           IdCliente,
                                                          cmbMarcas.GetMarcas(todosVacio:=True).ToList(),
                                       cmbModelos.GetModelos(todosVacio:=True).ToList(),
                                       cmbRubros.GetRubros(todosVacio:=True).ToList(),
                                       cmbSubRubros.GetSubRubros(todosVacio:=True).ToList(),
                                       cmbSubSubRubros.GetSubSubRubros(todosVacio:=True).ToList(),
                                                           IdProducto,
                                                           IdZonaGeografica,
                                                           IdLocalidad,
                                                           TipoInforme,
                                                           Me.chbConIVA.Checked,
                                                           idClienteVinculado:=0)

         dtDetalle2 = oVentas.GetKilosCompMensualPorCliente(cmbSucursal.GetSucursales(),
                                                            Me.dtpDesde2.Value, Me.dtpHasta2.Value,
                                                            IdVendedor,
                                                            IdCliente,
                                                                 cmbMarcas.GetMarcas(todosVacio:=True).ToList(),
                                       cmbModelos.GetModelos(todosVacio:=True).ToList(),
                                       cmbRubros.GetRubros(todosVacio:=True).ToList(),
                                       cmbSubRubros.GetSubRubros(todosVacio:=True).ToList(),
                                       cmbSubSubRubros.GetSubSubRubros(todosVacio:=True).ToList(),
                                                            IdProducto,
                                                            IdZonaGeografica,
                                                            IdLocalidad,
                                                            TipoInforme,
                                                            Me.chbConIVA.Checked,
                                                            idClienteVinculado:=0)

         'Me.FormatearGrilla()

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = dr("IdSucursal") '-.PE-31811.-
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
            drCl("Total") = Decimal.Parse(dr("Total").ToString())
            drCl("Promedio") = Decimal.Parse(dr("Promedio").ToString())
            drCl("Total2") = 0
            drCl("Promedio2") = 0

            dt.Rows.Add(drCl)

         Next

         For Each dr As DataRow In dtDetalle2.Rows
            Dim RowExistente() As Data.DataRow
            Try
                    RowExistente = dt.Select("CodigoCliente = " & dr("CodigoCliente").ToString())
               RowExistente(0)("Total2") = Decimal.Parse(dr("Total").ToString())
               RowExistente(0)("Promedio2") = Decimal.Parse(dr("Promedio").ToString())
            Catch ex As Exception
               drCl = dt.NewRow()

                    drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
               drCl("NombreCliente") = dr("NombreCliente").ToString()
               drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
               drCl("Total") = 0
               drCl("Promedio") = 0
               drCl("Total2") = Decimal.Parse(dr("Total").ToString())
               drCl("Promedio2") = Decimal.Parse(dr("Promedio").ToString())
               dt.Rows.Add(drCl)

            End Try

         Next

         For Each dr As DataRow In dt.Rows
            If Decimal.Parse(dr("Total").ToString()) <> 0 Then
               dr("DiferenciaTotal") = Decimal.Parse(dr("Total2").ToString()) - Decimal.Parse(dr("Total").ToString())
            Else
               dr("DiferenciaTotal") = 100
            End If

            If Decimal.Parse(dr("Promedio").ToString()) <> 0 Then
               dr("DiferenciaPorc") = (100 - (Decimal.Parse(dr("Total2").ToString()) * 100 / Decimal.Parse(dr("Total").ToString()))) * -1
            Else
               dr("DiferenciaPorc") = 100
            End If
         Next

         Me.ugDetalle.DataSource = dt

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("Total") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Total", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total2")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Total2", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("DiferenciaTotal")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("DiferenciaTotal", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      End If

   End Sub
   'Private Sub FormatearGrilla()

   '   With Me.ugDetalle

   '      For Cont As Long = 1 To 12
   '         .Columns("Mes" & Cont.ToString()).Visible = (Cont <= Me._periodos)
   '      Next

   '   End With

   'End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("Promedio", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total2", System.Type.GetType("System.Decimal"))
         .Columns.Add("Promedio2", System.Type.GetType("System.Decimal"))
         .Columns.Add("DiferenciaTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("DiferenciaPorc", System.Type.GetType("System.Decimal"))
         'For Cont As Long = 1 To Me._periodos
         '   .Columns.Add("Mes" & Cont.ToString(), System.Type.GetType("System.Decimal"))
         'Next
      End With

      Return dtTemp

   End Function
   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro
         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         .AppendFormat("Rango 1: desde el {0} hasta el {1} - Rango 2: desde el {2} hasta el {3}", Me.dtpDesde.Text, dtpHasta.Text, Me.dtpDesde2.Text, Me.dtpHasta2.Text)
         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         cmbMarcas.CargarFiltrosImpresionMarcas(filtro, False, True, " - ", String.Empty)
         cmbRubros.CargarFiltrosImpresionRubros(filtro, False, True, " - ", String.Empty)

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbProducto.Checked Then
            .AppendFormat(" / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text)
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            .AppendFormat("  / Localidad: " & Me.bscCodigoLocalidad.Text.Trim() & " - " & Me.bscNombreLocalidad.Text.Trim())
         End If

         If Me.rbtPorKilos.Checked Then
            .AppendFormat(" / Por Kilos")
         Else
            .AppendFormat(" / Por Importe " & IIf(Me.chbConIVA.Checked, "Con IVA", "Sin IVA").ToString())
         End If


      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region


End Class