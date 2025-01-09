Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfCargosClientes

#Region "Campos"

   Private _publicosEniac As Eniac.Win.Publicos
   Private _publicos As Publicos
   Private _expensas As DataTable
   Private _conceptos As DataTable
   Private _adicionales As DataTable
   Private _voucher As DataTable
   Private _mostrarDescRec As Boolean = Reglas.Publicos.CargosUtilizaDescuentosRecargos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicosEniac = New Eniac.Win.Publicos()
         Me._publicos = New Publicos


         Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
         Me.cmbTiposLiquidacion.SelectedIndex = 0

         Me._publicos.CargaComboCategorias(Me.cmbCategorias)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.



         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfCargos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim Filtros As String = String.Empty

         If Me.chbCliente.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscNombreCliente.Text.Trim()
         End If

         If Me.chbCargo.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Cargo: " & Me.bscCodigoCargo.Text.Trim() & " - " & Me.bscNombreCargo.Text.Trim()
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Categoria: " & Me.cmbCategorias.Text
         End If

         If Me.chbZonaGeografica.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Filtros.Length > 0 Then
            Filtros = "Filtros: " & Filtros
         End If


         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
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

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbCategoria.CheckedChanged
      Me.cmbCategorias.Enabled = Me.chbCategoria.Checked

      If Me.chbCliente.Checked Then
         Me.cmbCategorias.Focus()
      Else
         Me.cmbCategorias.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscNombreCliente.Enabled = Me.chbCliente.Checked

      If Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Focus()
      Else
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscNombreCliente.Text = String.Empty
      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscNombreCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscNombreCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscNombreCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCategoria.Checked And Me.cmbCategorias.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCategorias.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscNombreCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbCargo.Checked And Not Me.bscCodigoCargo.Selecciono And Not Me.bscNombreCargo.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cargo aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCargo.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCargo_BuscadorClick() Handles bscCodigoCargo.BuscadorClick
      Try
         Dim entidad As Reglas.Cargos = New Reglas.Cargos()
         Me._publicos.PreparaGrillaAutomatico(Me.bscCodigoCargo, "Cargos")
         Dim id As Integer? = Nothing
         If Not String.IsNullOrWhiteSpace(bscCodigoCargo.Text) Then
            id = Integer.Parse(Me.bscCodigoCargo.Text)
         End If
         Me.bscCodigoCargo.Datos = entidad.GetPorCodigoNombre(id, String.Empty)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      'Dim codigoCliente As Long = -1
      'Try
      '   Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
      '   Dim oClientes As Reglas.Clientes = New Reglas.Clientes
      '   If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
      '      codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
      '   End If
      '   Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Private Sub bscCodigoCargo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCargo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCargo(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCargo_BuscadorClick() Handles bscNombreCargo.BuscadorClick
      Try
         Dim entidad As Reglas.Cargos = New Reglas.Cargos()
         Me._publicos.PreparaGrillaAutomatico(Me.bscNombreCargo, "Cargos")
         Me.bscNombreCargo.Datos = entidad.GetPorCodigoNombre(Nothing, bscNombreCargo.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCargo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreCargo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCargo(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbCargo.CheckedChanged

      Me.bscCodigoCargo.Enabled = Me.chbCargo.Checked
      Me.bscNombreCargo.Enabled = Me.chbCargo.Checked

      If Me.chbCargo.Checked Then
         Me.bscCodigoCargo.Focus()
      Else
         Me.bscCodigoCargo.Text = String.Empty
         Me.bscNombreCargo.Text = String.Empty
      End If
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Me.chbZonaGeografica.Checked = True Then
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedItem = 0
         End If
         Me.cmbZonaGeografica.Focus()
      Else
         Me.cmbZonaGeografica.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCobrador.CheckedChanged

      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
      'cmbOrigenCobrador.Enabled = chbCobrador.Checked
      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         Me.cmbCobrador.Focus()

      End If

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()
      ugDetalle.AgregarTotalesSuma({"Importe", "ImporteSinIva"})
   End Sub

   Private Sub CargarCliente(ByVal dr As DataGridViewRow)
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscNombreCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscCodigoCliente.Enabled = False
      Me.bscNombreCliente.Enabled = False
   End Sub

   Private Sub CargarCargo(dr As DataGridViewRow)
      Me.bscCodigoCargo.Text = dr.Cells(Entidades.Cargo.Columnas.IdCargo.ToString()).Value.ToString()
      Me.bscNombreCargo.Text = dr.Cells(Entidades.Cargo.Columnas.NombreCargo.ToString()).Value.ToString()
      Me.bscCodigoCargo.Enabled = False
      Me.bscNombreCargo.Enabled = False
   End Sub


   Private Sub RefrescarDatosGrilla()

      Me.chbCategoria.Checked = False
      Me.chbCliente.Checked = False
      Me.chbCargo.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbCobrador.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbCliente.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Me.ugDetalle.DisplayLayout.ClearGroupByColumns()

      Dim clCargos As Reglas.CargosClientes = New Reglas.CargosClientes()

      Dim idCliente As Long? = Nothing
      Dim idAdicional As Integer? = Nothing
      Dim idCategoria As Integer? = Nothing
      Dim idZonaGeografica As String = Nothing
      Dim idCobrador As Integer = 0

      If chbCliente.Checked AndAlso bscCodigoCliente.Tag IsNot Nothing Then
         idCliente = CLng(bscCodigoCliente.Tag)
      End If

      If chbCargo.Checked AndAlso Not String.IsNullOrWhiteSpace(bscCodigoCargo.Text) Then
         idAdicional = CInt(bscCodigoCargo.Text)
      End If

      If chbCategoria.Checked AndAlso cmbCategorias.SelectedValue IsNot Nothing Then
         idCategoria = CInt(cmbCategorias.SelectedValue)
      End If

      If chbZonaGeografica.Checked AndAlso cmbZonaGeografica.SelectedValue IsNot Nothing Then
         idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
      End If

      If chbCobrador.Checked Then
         idCobrador = Integer.Parse(cmbCobrador.SelectedValue.ToString())
      End If

      Me.ugDetalle.DataSource = clCargos.Get(idCliente, idAdicional, idCategoria, idZonaGeografica,
                                             True, actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()), idCobrador)

      Me.AjustarColumnasGrilla()

      Me.LeerPreferencias()

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
   End Sub

   'Private Function CrearDT() As DataTable

   '    Dim dtTemp As DataTable = New DataTable()

   '    With dtTemp
   '        .Columns.Add("PeriodoLiquidacion", System.Type.GetType("System.Int32"))
   '        .Columns.Add("IdInmueble", System.Type.GetType("System.Int32"))
   '        .Columns.Add("IdExpensa", System.Type.GetType("System.Int32"))
   '        .Columns.Add("ExpensasInmueble", System.Type.GetType("System.Decimal"))
   '        .Columns.Add("TipoDocPropietario", System.Type.GetType("System.String"))
   '        .Columns.Add("NroDocPropietario", System.Type.GetType("System.Int64"))
   '        .Columns.Add("NombrePropietario", System.Type.GetType("System.String"))
   '        .Columns.Add("IdCargo", System.Type.GetType("System.Int32"))
   '        .Columns.Add("NombreAdicional", System.Type.GetType("System.String"))
   '        .Columns.Add("ImporteAdicional", System.Type.GetType("System.Decimal"))
   '    End With

   '    Return dtTemp

   'End Function

   Private Sub AjustarColumnasGrilla()
      With ugDetalle.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next

         Dim pos As Integer = 0

         .Columns(Entidades.CargoCliente.Columnas.IdCliente.ToString()).Header.Caption = "Id Cliente"
         .Columns(Entidades.CargoCliente.Columnas.IdCargo.ToString()).Header.Caption = "Id Cargo"
         .Columns(Entidades.Cargo.Columnas.ModificaImporte.ToString()).Header.Caption = "Permite modificar importe"
         .Columns(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).Header.Caption = "Permite modificar cantidad"

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).FormatearColumna("Tp.Doc", pos, 60, HAlign.Left, True)
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).FormatearColumna("Nro.Doc", pos, 100, HAlign.Right, True)
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Cliente", pos, 250, HAlign.Left)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasia", pos, 220, HAlign.Left)
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).FormatearColumna("Categoría", pos, 150, HAlign.Left)
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).FormatearColumna("Zona Geografica", pos, 150, HAlign.Left)
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).MinWidth = 60

         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).FormatearColumna("Nombre Cargo", pos, 260, HAlign.Left)
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).MinWidth = 60

         .Columns(Entidades.CargoCliente.Columnas.Cantidad.ToString()).FormatearColumna("Cantidad", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.CargoCliente.Columnas.Cantidad.ToString()).MinWidth = 60

         If _mostrarDescRec Then

            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()).FormatearColumna("P.Lista", pos, 100, HAlign.Right, , "N2")
            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()).MinWidth = 60

            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.PrecioListaSinIVA.ToString()).FormatearColumna("P.Lista S/IVA", pos, 100, HAlign.Right, , "N2")
            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.PrecioListaSinIVA.ToString()).MinWidth = 60

            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()).FormatearColumna("% Gral", pos, 70, HAlign.Right, , "N2")
            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()).MinWidth = 60

            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()).FormatearColumna("D/R %", pos, 70, HAlign.Right, , "N2")
            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()).MinWidth = 60

         End If


         .Columns(Entidades.CargoCliente.Columnas.Monto.ToString()).FormatearColumna("Precio", pos, 100, HAlign.Right, , "N2")
         .Columns(Entidades.CargoCliente.Columnas.Monto.ToString()).MinWidth = 60

         .Columns(Entidades.CargoCliente.Columnas.MontoSinIVA.ToString()).FormatearColumna("Precio S/IVA", pos, 110, HAlign.Right, , "N2")
         .Columns(Entidades.CargoCliente.Columnas.MontoSinIVA.ToString()).MinWidth = 60

         .Columns("Importe").FormatearColumna("Total", pos, 100, HAlign.Right, , "N2")
         .Columns("Importe").MinWidth = 60

         .Columns("ImporteSinIva").FormatearColumna("Total S/IVA", pos, 100, HAlign.Right, , "N2")
         .Columns("ImporteSinIva").MinWidth = 60

         FormatearColumna(.Columns("Observacion"), "Observación", pos, 250, HAlign.Left)
      End With

      'ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      ugDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(), Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
                                      Entidades.Cargo.Columnas.NombreCargo.ToString()})
      'ugDetalle.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
      'ugDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

      Me.CargarColumnasASumar()

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

#End Region


End Class