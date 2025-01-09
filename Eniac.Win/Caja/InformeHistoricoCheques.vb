Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InformeHistoricoCheques

#Region "Campos"

    Private _publicos As Publicos
    Public ConsultarAutomaticamente As Boolean = False

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        Try


            Me._publicos = New Publicos()

            Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = False
            Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
            Me._publicos.CargaComboEstadosCheques(Me.cmbEstado)

            Dim TodasLasCajas As Integer = New Reglas.CajasNombres().GetAll(actual.Sucursal.IdSucursal).Rows.Count
            If TodasLasCajas <> Me.cmbCajas.Items.Count Then
                Me.chbCaja.Checked = True
                Me.chbCaja.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            Me.dtpFechaCobroDesde.Value = Date.Today
            Me.dtpFechaCobroHasta.Value = Date.Today

            Me._publicos.CargaComboLocalidades(Me.cmbLocalidad)
            Me._publicos.CargaComboBancos(Me.cmbBanco)

            Me.CargoDatosGrilla(Me.CrearDT())

            Me.FormatearColumnas()

            'No Aplica.
            'Me.CargarColumnasASumar()

            Me.LeerPreferencias()

            If ConsultarAutomaticamente Then
                Me.chbFechaCobro.Checked = True
                Me.dtpFechaCobroDesde.Value = Date.Today.AddMonths(-1)
                Me.chbEstado.Checked = True
                Me.cmbEstado.SelectedValue = "ENCARTERA"
                Me.btnConsultar.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

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

#Region "Eventos"

    Private Sub InformeChequesDeTerceros_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

            If Me.cmbCajas.Enabled Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = "Caja: " & Me.cmbCajas.Text
            End If

            If Me.cmbEstado.Enabled Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = Filtros & "Estado: " & Me.cmbEstado.Text
            End If

            If Me.dtpFechaCobroDesde.Enabled Then
                Filtros = Filtros & "Rango de Fechas: desde el " & Me.dtpFechaCobroDesde.Text & " hasta el " & Me.dtpFechaCobroHasta.Text
            End If


            If Me.txtNumero.Enabled Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = Filtros & "Numero: " & Me.txtNumero.Text
            End If

            If Me.cmbBanco.Enabled Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = Filtros & "Banco: " & Me.cmbBanco.Text
            End If

            If Me.cmbLocalidad.Enabled Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = Filtros & "Localidad: " & Me.cmbLocalidad.Text
            End If

            If Me.chbCliente.Checked And Me.bscCodigoCliente.Selecciono Or bscCliente.Selecciono Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
            End If

            If Me.chbProveedor.Checked And Me.bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono Then
                If Filtros.Length > 0 Then Filtros = Filtros & " / "
                Filtros = Filtros & "Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
            End If

            If Filtros.Length > 0 Then Filtros = "Filtros: " & Filtros

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

    Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
        If Not Me.chbCaja.Checked Then
            Me.cmbCajas.SelectedIndex = -1
        Else
            Me.cmbCajas.Focus()
        End If
        Me.cmbCajas.Enabled = Me.chbCaja.Checked
    End Sub

    Private Sub chbEstado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbEstado.CheckedChanged
        If Not Me.chbEstado.Checked Then
            Me.cmbEstado.SelectedIndex = -1
        Else
            Me.cmbEstado.Focus()
        End If
        Me.cmbEstado.Enabled = Me.chbEstado.Checked
    End Sub

    Private Sub chbFechaCobro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechaCobro.CheckedChanged
        If Not Me.chbFechaCobro.Checked Then
            Me.dtpFechaCobroDesde.Value = Date.Now
            Me.dtpFechaCobroHasta.Value = Date.Now
        End If
        Me.dtpFechaCobroDesde.Enabled = Me.chbFechaCobro.Checked
        Me.dtpFechaCobroHasta.Enabled = Me.chbFechaCobro.Checked
    End Sub


    Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
        Me.txtNumero.Enabled = Me.chbNumero.Checked
        If Not Me.chbNumero.Checked Then
            Me.txtNumero.Text = ""
        Else
            Me.txtNumero.Focus()
        End If
    End Sub

    Private Sub chbTitular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTitular.CheckedChanged
        Me.txtTitular.Enabled = Me.chbTitular.Checked
        If Not Me.chbTitular.Checked Then
            Me.txtTitular.Text = ""
        Else
            Me.txtTitular.Focus()
        End If
    End Sub

    Private Sub chbBanco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBanco.CheckedChanged
        If Not Me.chbBanco.Checked Then
            Me.cmbBanco.SelectedIndex = -1
        End If
        Me.cmbBanco.Enabled = Me.chbBanco.Checked
    End Sub

    Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged
        If Not Me.chbLocalidad.Checked Then
            Me.cmbLocalidad.SelectedIndex = -1
        End If
        Me.cmbLocalidad.Enabled = Me.chbLocalidad.Checked
    End Sub

    Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

        Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
        Me.bscCliente.Enabled = Me.chbCliente.Checked

        Me.bscCodigoCliente.Text = String.Empty
        Me.bscCodigoCliente.Tag = Nothing
        Me.bscCliente.Text = String.Empty

        Me.bscCodigoCliente.Focus()

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

    Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

        Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
        Me.bscProveedor.Enabled = Me.chbProveedor.Checked

        Me.bscCodigoProveedor.Text = String.Empty
        Me.bscCodigoProveedor.Tag = Nothing
        Me.bscProveedor.Text = String.Empty

        Me.bscCodigoProveedor.Focus()

    End Sub

    Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
        Dim codigoProveedor As Long = -1
        Try
            Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
            Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
            If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
                codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
            End If
            Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarDatosProveedor(e.FilaDevuelta)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
        Try
            Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
            Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
            Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProveedorProv_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarDatosProveedor(e.FilaDevuelta)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

            If Me.chbCaja.Checked And Me.cmbCajas.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó una Caja aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbCajas.Focus()
                Exit Sub
            End If

            If Me.chbEstado.Checked And Me.cmbEstado.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó un Estado aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbEstado.Focus()
                Exit Sub
            End If

            If Me.chbBanco.Checked And Me.cmbBanco.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó un Banco aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbBanco.Focus()
                Exit Sub
            End If

            If Me.chbLocalidad.Checked And Me.cmbLocalidad.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó una Localidad aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbLocalidad.Focus()
                Exit Sub
            End If

            If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
                MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNumero.Focus()
                Exit Sub
            End If

            If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
                MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoCliente.Focus()
                Exit Sub
            End If

            If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
                MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoProveedor.Focus()
                Exit Sub
            End If

            If Me.chbTitular.Checked And String.IsNullOrEmpty(Me.txtTitular.Text.Trim()) Then
                MessageBox.Show("ATENCION: NO seleccionó un Titular aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtTitular.Focus()
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            If Me.ugDetalle.Rows.Count > 0 Then
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

    Private Sub tsbPreferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPreferencias.Click
        Try
            Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
            pre.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chbIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIngreso.CheckedChanged
        If Not Me.chbIngreso.Checked Then
            Me.dtpDesdeFechaIng.Value = Date.Now
            Me.dtpHastaFechaIng.Value = Date.Now
        End If
        Me.dtpDesdeFechaIng.Enabled = Me.chbIngreso.Checked
        Me.dtpHastaFechaIng.Enabled = Me.chbIngreso.Checked
    End Sub


#End Region

#Region "Metodos"

    Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

        Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
        Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
        Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
        Me.bscProveedor.Enabled = False
        Me.bscCodigoProveedor.Enabled = False

    End Sub

    Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

        Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
        Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
        Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
        Me.bscCliente.Enabled = False
        Me.bscCodigoCliente.Enabled = False

    End Sub

    Private Sub RefrescarDatosGrilla()

        Me.dtpFechaActDesde.Value = Date.Now
        Me.dtpFechaActHasta.Value = Date.Now

        If Me.chbCaja.Enabled Then
            Me.chbCaja.Checked = False
        End If

        Me.chbEstado.Checked = False

        Me.chbFechaCobro.Checked = False

        Me.chbIngreso.Checked = False

        Me.chbNumero.Checked = False

        Me.chbBanco.Checked = False
        Me.chbLocalidad.Checked = False

        Me.chbCliente.Checked = False
        Me.chbProveedor.Checked = False

        Me.chbTitular.Checked = False

        Me.chkMesCompleto.Checked = False

        If Not Me.ugDetalle.DataSource Is Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
        End If

        Me.rdbOrdenFechaActualizacion.Checked = True

    End Sub

    Private Sub CargaGrillaDetalle()

        Dim oCheques As Reglas.ChequesHistorial = New Reglas.ChequesHistorial()

        Dim IdCaja As Integer = 0
        Dim EstadoCheque As Entidades.Cheque.Estados

        Dim FechaCobroDesde As Date = Nothing
        Dim FechaCobroHasta As Date = Nothing

        Dim FechaIngresoDesde As Date = Nothing
        Dim FechaIngresoHasta As Date = Nothing

        Dim FechaEnCarteraAl As Date = Nothing

        Dim Numero As Long = 0
        Dim IdBanco As Integer = 0
        Dim IdLocalidad As Integer = 0

        Dim IdCliente As Long = 0

        Dim IdProveedor As Long = 0

        Dim Titular As String = String.Empty

        Dim orden As String = String.Empty

        Try

            If Me.cmbCajas.Enabled Then
                IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            End If

            If Me.cmbEstado.Enabled Then
                EstadoCheque = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), Me.cmbEstado.SelectedValue.ToString()), Entidades.Cheque.Estados)
            Else
                EstadoCheque = Entidades.Cheque.Estados.NINGUNO
            End If

            If Me.chbFechaCobro.Checked Then
                FechaCobroDesde = Me.dtpFechaCobroDesde.Value
                FechaCobroHasta = Me.dtpFechaCobroHasta.Value
            End If

            If Me.chbIngreso.Checked Then
                FechaIngresoDesde = Me.dtpDesdeFechaIng.Value
                FechaIngresoHasta = Me.dtpHastaFechaIng.Value()
            End If

            If Me.chbNumero.Checked Then
                Numero = Long.Parse(Me.txtNumero.Text)
            End If

            If Me.chbBanco.Checked Then
                IdBanco = Integer.Parse(Me.cmbBanco.SelectedValue.ToString())
            End If

            If Me.chbLocalidad.Checked Then
                IdLocalidad = Integer.Parse(Me.cmbLocalidad.SelectedValue.ToString())
            End If

            If Me.chbCliente.Checked Then
                IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If

            If bscCodigoProveedor.Tag IsNot Nothing Then
                IdProveedor = Long.Parse(bscCodigoProveedor.Tag.ToString())
            End If

            If Me.chbTitular.Checked Then
                Titular = Me.txtTitular.Text
            End If

            If Me.rdbOrdenFechaActualizacion.Checked Then
                orden = Entidades.Cheque.Ordenamiento.FECHAACTUALIZACION.ToString()
            Else
                orden = Entidades.Cheque.Ordenamiento.NOMBREYFECHACOBRO.ToString()
            End If

            Dim dtDetalle As DataTable
            Dim dt As DataTable
            Dim drCl As DataRow

            dtDetalle = oCheques.GetInformeHistoriaCheques(actual.Sucursal.Id, _
                                                           Me.dtpFechaActDesde.Value, Me.dtpFechaActHasta.Value, _
                                            IdCaja, _
                                            EstadoCheque, _
                                            FechaCobroDesde, FechaCobroHasta, _
                                            Numero, _
                                            IdBanco, _
                                            IdLocalidad, _
                                            False, _
                                            IdCliente, _
                                            IdProveedor, _
                                            Titular,
                                            FechaIngresoDesde,
                                            FechaIngresoHasta,
                                            0,
                                            orden)

            dt = Me.CrearDT()

            For Each dr As DataRow In dtDetalle.Rows

                drCl = dt.NewRow()

                    drCl("FechaActualizacion") = dr("FechaActualizacion").ToString()
                drCl("Orden") = dr("Orden").ToString()

                If Not String.IsNullOrEmpty(dr("NombreCajaIngreso").ToString()) Then
                    drCl("NombreCajaIngreso") = dr("NombreCajaIngreso")
                End If

                drCl("NombreBanco") = dr("NombreBanco").ToString()
                drCl("IdBancoSucursal") = Integer.Parse(dr("IdBancoSucursal").ToString())
                drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
                drCl("NumeroCheque") = Long.Parse(dr("NumeroCheque").ToString())

                drCl("FechaEmision") = Date.Parse(dr("FechaEmision").ToString())
                drCl("FechaCobro") = Date.Parse(dr("FechaCobro").ToString())
                drCl("Titular") = dr("Titular").ToString()
                drCl("Cuit") = dr("Cuit").ToString()
                drCl("Importe") = Decimal.Parse(dr("Importe").ToString())
                drCl("IdEstadoCheque") = dr("IdEstadoCheque").ToString()
                drCl("IdEstadoChequeAnt") = dr("IdEstadoChequeAnt").ToString()

                If Not String.IsNullOrEmpty(dr("NombreCliente").ToString()) Then
                    drCl("NombreCliente") = dr("NombreCliente").ToString()
                End If

                If Not String.IsNullOrEmpty(dr("NroPlanillaIngreso").ToString()) Then

                    drCl("FechaIngreso") = Date.Parse(dr("FechaIngreso").ToString())

                    drCl("NroPlanillaIngreso") = Integer.Parse(dr("NroPlanillaIngreso").ToString())
                    drCl("NroMovimientoIngreso") = Integer.Parse(dr("NroMovimientoIngreso").ToString())
                    'If Not String.IsNullOrEmpty(dr("FechaIngreso").ToString()) Then
                    'Fec = Date.Parse(dr("FechaIngreso").ToString())
                    'drCl("Ingreso") = "P: " & dr("NroPlanillaIngreso").ToString() & " - M: " & dr("NroMovimientoIngreso").ToString() & " - " & Fec.ToString("dd/MM/yyyy HH:mm") & " / " & dr("ObservacionIngreso").ToString()

                    drCl("Ingreso") = "P: " & dr("NroPlanillaIngreso").ToString() & " - M: " & dr("NroMovimientoIngreso").ToString() & " / " & dr("ObservacionIngreso").ToString()
                    'End If
                End If

                If Not String.IsNullOrEmpty(dr("NombreProveedor").ToString()) Then
                    drCl("NombreProveedor") = dr("NombreProveedor").ToString()
                End If

                If Not String.IsNullOrEmpty(dr("NroPlanillaEgreso").ToString()) Then
                    drCl("FechaEgreso") = Date.Parse(dr("FechaEgreso").ToString())
                    drCl("NroPlanillaEgreso") = Integer.Parse(dr("NroPlanillaEgreso").ToString())
                    drCl("NroMovimientoEgreso") = Integer.Parse(dr("NroMovimientoEgreso").ToString())
                    'If Not String.IsNullOrEmpty(dr("FechaEgreso").ToString()) Then
                    'Fec = Date.Parse(dr("FechaEgreso").ToString())
                    'drCl("Egreso") = "P: " & dr("NroPlanillaEgreso").ToString() & " - M: " & dr("NroMovimientoEgreso").ToString() & " - " & Fec.ToString("dd/MM/yyyy HH:mm") & " / " & dr("ObservacionEgreso").ToString()

                    drCl("Egreso") = "P: " & dr("NroPlanillaEgreso").ToString() & " - M: " & dr("NroMovimientoEgreso").ToString() & " / " & dr("ObservacionEgreso").ToString()
                    'End If
                End If
                If Not String.IsNullOrEmpty(dr("ProveedorPreasignado").ToString()) Then
                    drCl("ProveedorPreasignado") = dr("ProveedorPreasignado").ToString()
                End If

                dt.Rows.Add(drCl)
            Next

            'Me.dgvDetalle.DataSource = dt
            Me.CargoDatosGrilla(dt)

            Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub CargoDatosGrilla(ByVal dt As DataTable)
        Me.ugDetalle.DataSource = dt
    End Sub

    Private Sub FormatearColumnas()
        For Each cl As UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
            cl.Hidden = True
            cl.CellActivation = Activation.NoEdit
        Next

        With Me.ugDetalle.DisplayLayout.Bands(0)

            .Columns("FechaActualizacion").Header.Caption = "Fecha Actualización"
            .Columns("FechaActualizacion").Width = 120
            .Columns("FechaActualizacion").Hidden = False
            .Columns("FechaActualizacion").CellAppearance.TextHAlign = HAlign.Center
            .Columns("FechaActualizacion").Format = "dd/MM/yyyy HH:mm"
            '.Columns("FechaActualizacion").Header.VisiblePosition = 0

            .Columns("Orden").Header.Caption = "Orden"
            .Columns("Orden").Width = 60
            .Columns("Orden").Hidden = False
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("Orden").Header.VisiblePosition = 1    'LAs demas se acomodan solas.

            .Columns("NombreCajaIngreso").Header.Caption = "Caja"
            .Columns("NombreCajaIngreso").Width = 80
            .Columns("NombreCajaIngreso").Hidden = False

            .Columns("NombreBanco").Header.Caption = "Nombre Banco"
            .Columns("NombreBanco").Width = 120
            .Columns("NombreBanco").Hidden = False

            .Columns("IdBancoSucursal").Header.Caption = "Suc."
            .Columns("IdBancoSucursal").Width = 40
            .Columns("IdBancoSucursal").Hidden = False
            .Columns("IdBancoSucursal").CellAppearance.TextHAlign = HAlign.Right

            .Columns("NombreLocalidad").Header.Caption = "Localidad"
            .Columns("NombreLocalidad").Width = 100
            .Columns("NombreLocalidad").Hidden = False

            .Columns("NumeroCheque").Header.Caption = "Número"
            .Columns("NumeroCheque").Width = 70
            .Columns("NumeroCheque").Hidden = False
            .Columns("NumeroCheque").CellAppearance.TextHAlign = HAlign.Right

            .Columns("FechaEmision").Header.Caption = "Emisión"
            .Columns("FechaEmision").Width = 70
            .Columns("FechaEmision").Hidden = False
            .Columns("FechaEmision").CellAppearance.TextHAlign = HAlign.Center
            .Columns("FechaEmision").Format = "dd/MM/yyyy"


            .Columns("FechaCobro").Header.Caption = "Cobro"
            .Columns("FechaCobro").Width = 70
            .Columns("FechaCobro").Hidden = False
            .Columns("FechaCobro").CellAppearance.TextHAlign = HAlign.Center
            .Columns("FechaCobro").Format = "dd/MM/yyyy"

            .Columns("Titular").Header.Caption = "Titular"
            .Columns("Titular").Width = 160
            .Columns("Titular").Hidden = False

            .Columns("Cuit").Header.Caption = My.Resources.RTextos.Cuit
            .Columns("Cuit").Width = 80
            .Columns("Cuit").Hidden = False

            .Columns("Importe").Header.Caption = "Importe"
            .Columns("Importe").Width = 80
            .Columns("Importe").Hidden = False
            .Columns("Importe").CellAppearance.TextHAlign = HAlign.Right

            .Columns("IdEstadoCheque").Header.Caption = "Estado"
            .Columns("IdEstadoCheque").Width = 100
            .Columns("IdEstadoCheque").Hidden = False

            .Columns("IdEstadoChequeAnt").Header.Caption = "Estado Anterior"
            .Columns("IdEstadoChequeAnt").Width = 100
            .Columns("IdEstadoChequeAnt").Hidden = False

            .Columns("NombreCliente").Header.Caption = "Nombre Cliente"
            .Columns("NombreCliente").Width = 200
            .Columns("NombreCliente").Hidden = False

            .Columns("FechaIngreso").Header.Caption = "Ingreso"
            .Columns("FechaIngreso").Width = 70
            .Columns("FechaIngreso").Hidden = False
            .Columns("FechaIngreso").CellAppearance.TextHAlign = HAlign.Center
            .Columns("FechaIngreso").Format = "dd/MM/yyyy"

            .Columns("Ingreso").Header.Caption = "Movimiento Ingreso"
            .Columns("Ingreso").Width = 250
            .Columns("Ingreso").Hidden = False

            .Columns("FechaEgreso").Header.Caption = "Egreso"
            .Columns("FechaEgreso").Width = 70
            .Columns("FechaEgreso").Hidden = False
            .Columns("FechaEgreso").CellAppearance.TextHAlign = HAlign.Center
            .Columns("FechaEgreso").Format = "dd/MM/yyyy"

            .Columns("NombreProveedor").Header.Caption = "Nombre Proveedor"
            .Columns("NombreProveedor").Width = 200
            .Columns("NombreProveedor").Hidden = False

            .Columns("Egreso").Header.Caption = "Movimiento Egreso"
            .Columns("Egreso").Width = 250
            .Columns("Egreso").Hidden = False

            .Columns("ProveedorPreasignado").Header.Caption = "Proveedor Preasignado"
            .Columns("ProveedorPreasignado").Width = 200
            .Columns("ProveedorPreasignado").Hidden = False

        End With
    End Sub

    Private Function CrearDT() As DataTable

        Dim dtTemp As DataTable = New DataTable()
        With dtTemp
            '.Columns.Add("IdCajaIngreso", System.Type.GetType("System.Int32"))
            .Columns.Add("FechaActualizacion", System.Type.GetType("System.DateTime"))
            .Columns.Add("Orden", System.Type.GetType("System.String"))
            .Columns.Add("NombreCajaIngreso", System.Type.GetType("System.String"))
            .Columns.Add("NombreBanco", System.Type.GetType("System.String"))
            .Columns.Add("IdBancoSucursal", System.Type.GetType("System.Int32"))
            .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
            .Columns.Add("NumeroCheque", System.Type.GetType("System.Int64"))
            .Columns.Add("FechaEmision", System.Type.GetType("System.DateTime"))
            .Columns.Add("FechaCobro", System.Type.GetType("System.DateTime"))
            .Columns.Add("Titular", System.Type.GetType("System.String"))
            .Columns.Add("Cuit", System.Type.GetType("System.String"))
            .Columns.Add("Importe", System.Type.GetType("System.Decimal"))
            .Columns.Add("IdEstadoCheque", System.Type.GetType("System.String"))
            .Columns.Add("IdEstadoChequeAnt", System.Type.GetType("System.String"))
            .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
            .Columns.Add("FechaIngreso", System.Type.GetType("System.DateTime"))
            .Columns.Add("Ingreso", System.Type.GetType("System.String"))
            .Columns.Add("NroPlanillaIngreso", System.Type.GetType("System.Int32"))
            .Columns.Add("NroMovimientoIngreso", System.Type.GetType("System.Int32"))
            .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
            .Columns.Add("FechaEgreso", System.Type.GetType("System.DateTime"))
            .Columns.Add("Egreso", System.Type.GetType("System.String"))
            .Columns.Add("NroPlanillaEgreso", System.Type.GetType("System.Int32"))
            .Columns.Add("NroMovimientoEgreso", System.Type.GetType("System.Int32"))
            .Columns.Add("ProveedorPreasignado", System.Type.GetType("System.String"))
        End With
        Return dtTemp

    End Function

    Private Sub CargarColumnasASumar()

        If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("Importe") Then
            Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
            Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

            Dim columnToSummarize As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Importe")
            Dim summary As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Importe", SummaryType.Sum, columnToSummarize)
            summary.DisplayFormat = "{0:N2}"
            summary.Appearance.TextHAlign = HAlign.Right

            Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

        End If

    End Sub

#End Region

    Private Function dtpFechaEnCarteraAl() As Object
        Throw New NotImplementedException
    End Function


    Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

        Dim FechaTemp As Date

        Try

            If chkMesCompleto.Checked Then

                FechaTemp = New Date(Me.dtpFechaActDesde.Value.Year, Me.dtpFechaActHasta.Value.Month, 1)
                Me.dtpFechaActDesde.Value = FechaTemp

                'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
                FechaTemp = Me.dtpFechaActDesde.Value.AddMonths(1).AddSeconds(-1)
                Me.dtpFechaActHasta.Value = FechaTemp

            End If

            Me.dtpFechaActDesde.Enabled = Not Me.chkMesCompleto.Checked
            Me.dtpFechaActHasta.Enabled = Not Me.chkMesCompleto.Checked

        Catch ex As Exception

            chkMesCompleto.Checked = False

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

End Class