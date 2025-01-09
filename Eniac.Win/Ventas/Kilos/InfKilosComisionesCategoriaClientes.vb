Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section


Public Class InfKilosComisionesCategoriaClientes

#Region "Campos"

   Private _publicos As Publicos
   Private _categorias As List(Of Entidades.Categoria)
   Private _tit As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
         Me._publicos = New Publicos()
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         cmbMarca.Inicializar(True, True, True)
         cmbRubro.Inicializar(True, True, True)
         cmbSubRubro.Inicializar(True, True, True, {})
         cmbSubSubRubro_M.Inicializar(True, True, True, {})

         If Not Reglas.Publicos.ProductoTieneSubSubRubro Then
            lblSubSubRubro.Visible = False
            cmbSubSubRubro_M.Visible = False
         End If

         Me._publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         Me.cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Movimiento

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)
         Me._publicos.CargaComboTransportistas(Me.cmbTransportista)
         Me.cmbTransportista.SelectedIndex = -1

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "NombreLocalidad"})
         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"Total", "Kilos", "Cantidad"})

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         Me.LeerPreferencias()

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfKilosTotalesPorCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un CLIENTE aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         'If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó un VENDEDOR aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbVendedor.Focus()
         '   Exit Sub
         'End If

         If Me.chbLocalidad.Checked And Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una LOCALIDAD aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         If chbTransportista.Checked AndAlso cmbTransportista.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un TRANSPORTISTA.")
            cmbTransportista.Focus()
            Exit Sub
         End If


         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If TypeOf (ugDetalle.DataSource) Is DataTable AndAlso DirectCast(ugDetalle.DataSource, DataTable).Rows.Count > 0 Then
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

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
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
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
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

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         Dim habilitaSubRubro As Boolean = False
         If cmbRubro.SelectedIndex > 0 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            If rubros.Length = 1 Then
               cmbSubRubro.Inicializar(True, True, True, rubros(0))
               habilitaSubRubro = True
            End If
         End If
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSubRubro.Enabled = habilitaSubRubro
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If
         Me.cmbCategoria.Focus()
      End If
   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged

      If Not Me.chbTransportista.Checked Then
         Me.cmbTransportista.SelectedIndex = -1
      Else
         If Me.cmbTransportista.Items.Count > 0 Then
            Me.cmbTransportista.SelectedIndex = 0
         End If
      End If

      Me.cmbTransportista.Enabled = Me.chbTransportista.Checked



      Me.cmbTransportista.Focus()

   End Sub

   Private Sub cmbSubRubro_M_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Dim habilitaSubSubRubro As Boolean = False
      If cmbSubRubro.SelectedIndex > 0 Then
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros()
         If subRubros.Length = 1 Then
            cmbSubSubRubro_M.Inicializar(True, True, True, subRubros(0))
            habilitaSubSubRubro = True
         End If
      End If
      cmbSubSubRubro_M.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      cmbSubSubRubro_M.Enabled = habilitaSubSubRubro
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

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbTransportista.Checked = False

      Me.cmbMarca.SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Me.cmbSubRubro.SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Me.cmbRubro.SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      cmbSubSubRubro_M.Refrescar()

      Me.chbZonaGeografica.Checked = False

      Me.chbLocalidad.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()


      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0
      Dim IdCategoria As Integer = 0
      Dim origenCategoria As Entidades.OrigenFK

      Dim IdVendedor As Integer = 0

      Dim IdZonaGeografica As String = String.Empty
      Dim IdLocalidad As Integer = 0
      Dim TipoCategoria As String = String.Empty

      Dim dtDetalle As DataTable = New DataTable()

      ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()

      Try

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         _categorias = New List(Of Entidades.Categoria)

         If chbCategoria.Checked Then
            Dim Categ As Entidades.Categoria = New Reglas.Categorias().GetUno(Integer.Parse(cmbCategoria.SelectedValue.ToString()))
            _categorias.Add(Categ)
         Else
            _categorias = New Reglas.Categorias().GetTodas()

         End If

         Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros(True)

         Dim marcas As Entidades.Marca() = cmbMarca.GetMarcas()

         Dim idTransportista As Integer = If(cmbTransportista.SelectedIndex > -1, Integer.Parse(cmbTransportista.SelectedValue.ToString()), 0)

         origenCategoria = DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK)

         dtDetalle = oVentas.GetKilosComisionesCategoriaClientes({actual.Sucursal},
                                                       Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                       IdCategoria,
                                                       IdVendedor,
                                                       IdCliente,
                                                       _categorias,
                                                       rubros,
                                                       If(rubros.Length = 1, cmbSubRubro.GetSubRubros(), {}),
                                                       If(subRubros.Length = 1, cmbSubSubRubro_M.GetSubSubRubros(True), {}),
                                                       marcas,
                                                       IdZonaGeografica,
                                                       IdLocalidad,
                                                       idTransportista,
                                                       origenCategoria)

         '  dt = Me.CrearDT()

         Me.ugDetalle.DataSource = dtDetalle
         FormateaColumnas()

         Dim kilos As Decimal = 0
         Dim Porc As Decimal = 0
         Dim Comision As Decimal = 0
         Dim TotalComision As Decimal = 0
         Dim TotalKilos As Decimal = 0

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            For Each dc As DataColumn In dtDetalle.Columns
               If dc.ColumnName.StartsWith("co_") Or dc.ColumnName.StartsWith("ki_") Then
                  For Each lis As Entidades.Categoria In _categorias
                     If dc.ColumnName.Equals(String.Format("co_{0}", lis.IdCategoria)) Then
                        If Not String.IsNullOrEmpty(dr.Cells(dc.ColumnName).Value.ToString()) Then
                           TotalComision += Decimal.Parse(dr.Cells(dc.ColumnName).Value.ToString())
                        Else
                           dr.Cells(dc.ColumnName).Value = 0
                        End If
                     End If
                     If dc.ColumnName.Equals(String.Format("ki_{0}", lis.IdCategoria)) Then
                        If Not String.IsNullOrEmpty(dr.Cells(dc.ColumnName).Value.ToString()) Then
                           TotalKilos += Decimal.Parse(dr.Cells(dc.ColumnName).Value.ToString())
                        Else
                           dr.Cells(dc.ColumnName).Value = 0
                        End If
                     End If
                  Next
               End If

            Next
            dr.Cells("TotalComision").Value = TotalComision
            TotalComision = 0
            dr.Cells("TotalKilos").Value = TotalKilos
            TotalKilos = 0
         Next

         For Each dc As DataColumn In dtDetalle.Columns
            If dc.ColumnName.StartsWith("ki_") Or dc.ColumnName.StartsWith("co_") Then
               For Each lis As Entidades.Categoria In _categorias
                  If dc.ColumnName.Equals(String.Format("ki_{0}", lis.IdCategoria)) Or _
                     dc.ColumnName.Equals(String.Format("co_{0}", lis.IdCategoria)) Then
                     ugDetalle.AgregarTotalSumaColumna(dc.ColumnName)
                  End If
               Next
            End If
         Next
         ugDetalle.AgregarTotalSumaColumna("TotalComision")
         ugDetalle.AgregarTotalSumaColumna("TotalKilos")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarColumnasASumar()


   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreLocalidad", GetType(String))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("Kilos", GetType(Decimal))
         .Columns.Add("Cantidad", GetType(Decimal))
      End With

      Return dtTemp
   End Function

   Private Sub FormateaColumnas()
      Dim formato As String = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()
      Dim maskInput As String = Formatos.MaskInput.CustomMaskInput(14, Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio)
      Dim pos As Integer = 0
      With ugDetalle.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            If columna.Key.StartsWith("ki_") Then
               columna.Width = 90
               columna.CellAppearance.TextHAlign = HAlign.Right
               columna.Format = "N2"
               columna.Header.Appearance.TextHAlign = HAlign.Center
               columna.FormatoMaskInput(formato, maskInput)
            End If
            If columna.Key.StartsWith("co_") Then
               columna.Width = 90
               columna.CellAppearance.TextHAlign = HAlign.Right
               columna.Format = "N2"
               columna.Header.Appearance.TextHAlign = HAlign.Center
            End If
         Next
         .Columns("TotalComision").FormatoMaskInput("N2", maskInput)
         .Columns("TotalKilos").FormatoMaskInput("N2", maskInput)
         '.Columns("PrecioCosto").FormatoMaskInput(formato, maskInput)
         .Columns("Fecha").FormatearColumna("Fecha", pos, 80, HAlign.Center, , "dd/MM/yyyy")
      End With

   End Sub

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

      Dim IdVendedor As Integer

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)


         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

            .AppendFormat("Vendedor: {0} - {1} - ", IdVendedor, cmbVendedor.Text)
         End If

         If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            .AppendFormat("Cliente: {0} - {1} - ", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
         End If

         If Not cmbMarca.SelectedValue.Equals(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
            cmbMarca.CargarFiltrosImpresionMarcas(filtro, False, True)
         End If

         If Not cmbRubro.SelectedValue.Equals(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
            cmbRubro.CargarFiltrosImpresionRubros(filtro, False, True)
         End If

         If Not cmbSubRubro.SelectedValue.Equals(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
            cmbSubRubro.CargarFiltrosImpresionSubRubros(filtro, False, True)
         End If

         If Not cmbSubSubRubro_M.SelectedValue.Equals(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
            cmbSubSubRubro_M.CargarFiltrosImpresionSubSubRubros(filtro, False, True)
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            .AppendFormat("Zona Geografica: {0} - ", cmbZonaGeografica.Text)
         End If

         If Me.cmbCategoria.SelectedIndex >= 0 Then
            .AppendFormat("Categoría: {0} - ", cmbCategoria.Text)
         End If

         If Me.cmbTransportista.SelectedIndex >= 0 Then
            .AppendFormat("Transportista: {0} - ", cmbTransportista.Text)
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            .AppendFormat("Localidad: {0} - {1} - ", bscCodigoLocalidad.Text.Trim(), bscNombreLocalidad.Text.Trim())
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

End Class