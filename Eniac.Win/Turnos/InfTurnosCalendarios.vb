#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

#End Region
Public Class InfTurnosCalendarios

#Region "Campos"

   Private _publicos As Publicos
   Protected Property ConsultarAutomaticamente As Boolean = False
   Private _tit As Dictionary(Of String, String)
   Protected Property IdCalendario As Integer = 0
#End Region

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(idCalendario As Integer, consultarAutomaticamente As Boolean)
      Me.New()
      Me._IdCalendario = idCalendario
      Me._ConsultarAutomaticamente = consultarAutomaticamente
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         _publicos.CargaComboTiposTurnos(cmbTiposTurnos)
         Me.cmbTiposTurnos.SelectedIndex = -1

         _publicos.CargaComboEstadosTurnos(cmbEstadosTurnos)
         Me.cmbEstadosTurnos.SelectedIndex = -1

         _publicos.CargaComboCalendariosActivos(cmbCalendario, actual.Sucursal.Id, actual.Nombre)
         Me.cmbTiposTurnos.SelectedIndex = -1

         MuestraProductoDescuentoRecargoPrecios(Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario)
         MuestraColumnasSiSeN(Publicos.IDAplicacionSinergia = "SISEN")
         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "Observaciones"})

         ugDetalle.AgregarTotalesSuma({"PrecioNeto"})

         LeerPreferencias()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)

      If _IdCalendario > 0 Then
         chbCalendario.Checked = True
         cmbCalendario.SelectedValue = _IdCalendario
      End If
      If _ConsultarAutomaticamente Then
         Me.btnConsultar.PerformClick()
      End If
   End Sub

#End Region

#Region "Overridable"
   'Protected Overridable Function GetColumnasVisiblesGrilla() As Dictionary(Of String, String)
   '   Return MyBase.GetColumnasVisiblesGrilla(ugTurnos)
   'End Function
   Protected Overridable Function GetRegla() As Reglas.TurnosCalendarios
      Return New Reglas.TurnosCalendarios()
   End Function
   'Protected Overridable Function SubjectParaAppointment(turno As Entidades.TurnoCalendario) As String
   '   Return String.Format("{0} ({1})", turno.NombreCliente, turno.CodigoCliente)
   'End Function
   'Protected Overridable Function NewDetalle(turno As Entidades.TurnoCalendario, turnos As List(Of Entidades.TurnoCalendario), stateForm As StateForm) As TurnosDetalle
   '   Return New TurnosDetalle(turno, turnos, stateForm)
   'End Function
   'Protected Overridable Function NewEntidad(idCalendario As Integer, fechaDesde As DateTime, fechaHasta As DateTime) As Entidades.TurnoCalendario
   '   Return New Entidades.TurnoCalendario(idCalendario, fechaDesde, fechaHasta)
   'End Function
#End Region

#Region "Eventos"

   Private Sub InfTurnos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#Region "Eventos ToolBar"
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

         Dim Filtros As String = CargarFiltrosImpresion()
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
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Dim grilla As UltraGrid = ugDetalle

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

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Dim grilla As UltraGrid = ugDetalle
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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Try

         If chkMesCompleto.Checked Then

            Dim FechaTemp As Date

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 dia.
            FechaTemp = dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbTipoTurno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoTurno.CheckedChanged
      Me.cmbTiposTurnos.Enabled = Me.chbTipoTurno.Checked
   End Sub

   Private Sub chbCalendario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCalendario.CheckedChanged
      Me.cmbCalendario.Enabled = Me.chbCalendario.Checked
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
#End Region

#Region "Eventos Buscadores"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Dim reglas As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim idCliente As Long = -1
         If IsNumeric(bscCodigoCliente.Text) Then
            idCliente = Long.Parse(bscCodigoCliente.Text)
         End If
         Me.bscCodigoCliente.Datos = reglas.GetFiltradoPorCodigo(idCliente, False, False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Dim reglas As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes2(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = reglas.GetFiltradoPorNombre(Me.bscNombreCliente.Text, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscNombreCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Public Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCalendario.Checked And Me.cmbCalendario.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Calendario aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCalendario.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Me.bscCodigoCliente.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbTipoTurno.Checked And Me.cmbTiposTurnos.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Tipo de Turno aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposTurnos.Focus()
            Exit Sub
         End If

         If Me.chbEstadoTurno.Checked And Me.cmbEstadosTurnos.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Estado de Turno aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEstadosTurnos.Focus()
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
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
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
   Private Sub chbEstadoTurno_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoTurno.CheckedChanged
      Me.cmbEstadosTurnos.Enabled = Me.chbEstadoTurno.Checked
      If Not Me.chbEstadoTurno.Checked Then
         Me.cmbEstadosTurnos.SelectedIndex = -1
      End If
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarCliente(ByVal dr As DataGridViewRow)
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()

      Me.bscCodigoCliente.Enabled = False
      Me.bscNombreCliente.Enabled = False
   End Sub

   Protected Overridable Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbCliente.Checked = False
      Me.chbTipoTurno.Checked = False
      chbCalendario.Checked = False
      chbEstadoTurno.Checked = False
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Protected Overridable Function GetFiltrosParaConsulta() As Entidades.Filtros.GetPorRangoFechasFiltros
      Return New Entidades.Filtros.GetPorRangoFechasFiltros(dtpDesde.Value, dtpHasta.Value)
   End Function

   Protected Overridable Sub CargarFiltrosParaConsulta(filtros As Entidades.Filtros.GetPorRangoFechasFiltros)

      filtros.IdSucursal = actual.Sucursal.Id

      If chbCalendario.Checked Then
         filtros.IdCalendario = Integer.Parse(cmbCalendario.SelectedValue.ToString())
      End If

      If Me.chbCliente.Checked Then
         filtros.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbTipoTurno.Checked Then
         filtros.IdTipoTurno = Me.cmbTiposTurnos.SelectedValue.ToString()
      End If

      If Me.chbEstadoTurno.Checked Then
         filtros.IdEstadoTurno = Me.cmbEstadosTurnos.SelectedValue.ToString()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim clTurnos As Reglas.TurnosCalendarios = GetRegla()

         Dim filtros As Entidades.Filtros.GetPorRangoFechasFiltros = GetFiltrosParaConsulta()
         CargarFiltrosParaConsulta(filtros)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         Dim dtDetalle As DataTable

         dtDetalle = clTurnos.GetPorRangoFechas(filtros)

         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

         AjustarColumnasGrilla(ugDetalle, _tit)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub MuestraProductoDescuentoRecargoPrecios(visible As Boolean)
      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdProducto").Hidden = Not visible
         .Columns("NombreProducto").Hidden = Not visible
         .Columns("PrecioLista").Hidden = Not visible
         .Columns("Precio").Hidden = Not visible
         .Columns("DescuentoRecargoPorcGral").Hidden = Not visible
         .Columns("DescuentoRecargoPorc1").Hidden = Not visible
         .Columns("DescuentoRecargoPorc2").Hidden = Not visible
         .Columns("PrecioNeto").Hidden = Not visible
         .Columns("NumeroSesion").Hidden = Not visible
      End With
   End Sub
   Private Sub MuestraColumnasSiSeN(visible As Boolean)
      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdEmbarcacion").Hidden = True
         .Columns("CodigoEmbarcacion").Hidden = True
         .Columns("NombreEmbarcacion").Hidden = Not visible
         .Columns("IdDestino").Hidden = True
         .Columns("DestinoLibre").Hidden = Not visible
         .Columns("CantidadPasajeros").Hidden = Not visible
         .Columns("FechaHoraLlegada").Hidden = Not visible
      End With
   End Sub
   Protected Overridable Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If chbCalendario.Checked Then
            .AppendFormat("Calendario: {0} - ", cmbCalendario.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            .AppendFormat("Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text.Trim(), Me.bscNombreCliente.Text.Trim())
         End If

         If chbTipoTurno.Checked Then
            .AppendFormat("Tipo de Turno: {0} - ", cmbTiposTurnos.Text)
         End If

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

End Class