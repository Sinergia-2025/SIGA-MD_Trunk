Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfRepartos

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarRepartos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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


         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraPrintPreviewDialog1.Name = Me.Text
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
         Me.UltraGridPrintDocument1.FitWidthToPages = 1  'Fuerzo el Ancho en uno por la observacion, tal vez haya que quitar ese campo.

         Me.UltraGridPrintDocument1.Grid = Me.ugDetalle

         Me.UltraPrintPreviewDialog1.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
        Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, CargarFiltrosImpresion)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro
         .AppendFormat("Fechas: desde " & Date.Parse(dtpDesde.Text).ToString("dd/MM/yyyy") & " hasta " & Date.Parse(dtpHasta.Text).ToString("dd/MM/yyyy"))

         If Me.chbNumero.Checked Then
            .AppendFormat(" Nro. Reparto: {0} ", Me.txtNumero.Text)
         End If
         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} ", Me.cmbVendedor.Text)
         End If
         If Me.chbTransportista.Checked Then
            .AppendFormat(" Transportista: {0} ", Me.bscTransportista.Text)
         End If

         If Me.chbUsuario.Checked Then
            .AppendFormat(" Usuario: {0} ", Me.cmbUsuario.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbTransportista.Checked And Not Me.bscTransportista.Selecciono And IsNumeric(Me.bscTransportista.Tag) Then
            MessageBox.Show("No seleccionó un Transportista aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscTransportista.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedItem Is Nothing Then
            MessageBox.Show("No seleccionó un Vendedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbUsuario.Checked And Me.cmbUsuario.SelectedItem Is Nothing Then
            MessageBox.Show("No seleccionó un Usuario aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbUsuario.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then

            Me.ugDetalle.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.dtpDesde.Focus()

            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas
         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      Try
         Me.bscTransportista.Enabled = Me.chbTransportista.Checked

         If Not Me.chbTransportista.Checked Then
            Me.bscTransportista.Text = ""
         End If

         Me.bscTransportista.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbNumero.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbTransportista.Checked = False

      'Limpio las Grillas.

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

         Dim TotalNeto As Decimal = 0
         Dim TotalImpuestos As Decimal = 0
         Dim Total As Decimal = 0

         Dim IdCliente As Long = 0
         Dim IdTransportista As Integer = 0

         Dim IdTipoComprobante As String = String.Empty
         Dim NumeroReparto As Long = 0

         Dim IdVendedor As Integer = 0

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty

         If Me.chbNumero.Checked Then
            NumeroReparto = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
         End If

         If Me.bscTransportista.Enabled AndAlso Me.bscTransportista.Tag IsNot Nothing Then
            IdTransportista = CInt(Me.bscTransportista.Tag)
         End If

         If Me.chbUsuario.Checked Then
            IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Eniac.Entidades.Usuario).Id
         End If

         Dim dtDetalle As DataTable

         dtDetalle = oVenta.GetInfReparto(actual.Sucursal.Id,
                                        dtpDesde.Value,
                                        dtpHasta.Value,
                                        IdVendedor,
                                        IdCliente,
                                        IdTipoComprobante,
                                        NumeroReparto,
                                        IdFormasPago,
                                        IdUsuario,
                                        IdTransportista)


         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarDatosTransportista(ByVal dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      Dim Transp As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas()
      Me.bscTransportista.Tag = Long.Parse(dr.Cells("IdTransportista").Value.ToString())
   End Sub

#End Region



End Class