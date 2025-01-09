Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfHistoricoTarjetasCupones

#Region "Campos"

   Private _publicos As Publicos
   Private _IdActualCuentaBancaria As Integer = 0
   Public ConsultarAutomaticamente As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
         Me.cmbCajas.SelectedIndex = -1

         Me._publicos.CargaComboBancos(Me.cmbBanco)

         Me._publicos.CargaComboDesdeEnum(cmbEstado, GetType(Entidades.TarjetaCupon.Estados))
         Me.cmbEstado.SelectedIndex = -1

         ugDetalle.AgregarTotalesSuma({"Monto"})

         ugDetalle.AgregarFiltroEnLinea({""})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfTarjetasPorVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim Filtros As String = CargarFiltrosImpresion()
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

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumeroCupon.CheckedChanged
      Me.txtNumeroCupon.Enabled = Me.chbNumeroCupon.Checked
      If Not Me.chbNumeroCupon.Checked Then
         Me.txtNumeroCupon.Text = ""
      Else
         Me.txtNumeroCupon.Focus()
      End If
   End Sub
   Private Sub chbFechaIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechaIngreso.CheckedChanged
      If Not Me.chbFechaIngreso.Checked Then
         Me.dtpIngresoDesde.Value = Date.Now
         Me.dtpIngresoHasta.Value = Date.Now
      End If
      Me.dtpIngresoDesde.Enabled = Me.chbFechaIngreso.Checked
      Me.dtpIngresoHasta.Enabled = Me.chbFechaIngreso.Checked
   End Sub
   Private Sub chbFechaLiquidacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechaLiquidacion.CheckedChanged
      If Not Me.chbFechaLiquidacion.Checked Then
         Me.dtpLiquidacionDesde.Value = Date.Now
         Me.dtpLiquidacionHasta.Value = Date.Now
      End If
      Me.dtpLiquidacionDesde.Enabled = Me.chbFechaLiquidacion.Checked
      Me.dtpLiquidacionHasta.Enabled = Me.chbFechaLiquidacion.Checked
   End Sub
   Private Sub chbBanco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBanco.CheckedChanged
      If Not Me.chbBanco.Checked Then
         Me.cmbBanco.SelectedIndex = -1
      End If
      Me.cmbBanco.Enabled = Me.chbBanco.Checked
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
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
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
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
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

   Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
      Try
         If Not Me.chbCaja.Checked Then
            Me.cmbCajas.SelectedIndex = -1
         Else
            Me.cmbCajas.Focus()
         End If
         Me.cmbCajas.Enabled = Me.chbCaja.Checked
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

         If Me.chbBanco.Checked And Me.cmbBanco.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Banco aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbBanco.Focus()
            Exit Sub
         End If

         If Me.chbNumeroCupon.Checked And (Me.txtNumeroCupon.Text = "" OrElse Long.Parse(Me.txtNumeroCupon.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroCupon.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbEstado.Checked And Me.cmbEstado.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Estado aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEstado.Focus()
            Exit Sub
         End If

         If Me.chbNumeroCupon.Checked And (Me.txtNumeroCupon.Text = "" OrElse Integer.Parse(Me.txtNumeroCupon.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero de Cupon aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroCupon.Focus()
            Exit Sub
         End If

         If Me.chbNumeroLote.Checked And (Me.txtNumeroLote.Text = "" OrElse Integer.Parse(Me.txtNumeroLote.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero de Lote aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroLote.Focus()
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

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
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

      Me.chbCaja.Checked = False
      Me.chbNumeroCupon.Checked = False
      Me.chbBanco.Checked = False
      Me.chbEstado.Checked = False
      Me.chbFechaIngreso.Checked = True
      Me.chbFechaLiquidacion.Checked = False
      Me.chbFechaEnCarteraAl.Checked = False
      Me.chbNumeroCupon.Checked = False
      Me.chbNumeroLote.Checked = False
      Me.chbBanco.Checked = False
      Me.chbCliente.Checked = False
      Me.rdbOrdenFechaActualizacion.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCaja As Integer = 0

      Dim fechaLiquidacionDesde As Date? = Nothing
      Dim fechaLiquidacionHasta As Date? = Nothing

      Dim fechaIngresoDesde As Date? = Nothing
      Dim fechaIngresoHasta As Date? = Nothing

      Dim enCarteraAl As Date? = Nothing

      Dim idBanco As Integer = 0


      Dim idCliente As Long = 0

      Dim numeroCupon As Integer = 0
      Dim numeroLote As Integer = 0

      Dim estadoCupon As Entidades.TarjetaCupon.Estados
      Dim oCupones As Reglas.TarjetasCuponesHistorial = New Reglas.TarjetasCuponesHistorial()

      Dim orden As String = String.Empty
      Try

         If Me.chbFechaIngreso.Checked Then
            fechaIngresoDesde = Me.dtpIngresoDesde.Value
            fechaIngresoHasta = Me.dtpIngresoHasta.Value
         End If

         If Me.chbFechaLiquidacion.Checked Then
            fechaLiquidacionDesde = Me.dtpLiquidacionDesde.Value
            fechaLiquidacionHasta = Me.dtpLiquidacionHasta.Value
         End If

         If Me.chbFechaEnCarteraAl.Checked Then
            enCarteraAl = Me.dtpFechaEnCarteraAl.Value
         End If

         If Me.chbCaja.Checked Then
            idCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
         End If

         If Me.chbBanco.Checked Then
            idBanco = Integer.Parse(Me.cmbBanco.SelectedValue.ToString())
         End If

         If Me.chbNumeroCupon.Checked Then
            numeroCupon = Integer.Parse(Me.txtNumeroCupon.Text)
         End If

         If Me.chbNumeroLote.Checked Then
            numeroLote = Integer.Parse(Me.txtNumeroLote.Text)
         End If

         If Me.chbCliente.Checked Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbEstado.Checked Then
            estadoCupon = DirectCast([Enum].Parse(GetType(Entidades.TarjetaCupon.Estados), Me.cmbEstado.SelectedValue.ToString()), Entidades.TarjetaCupon.Estados)
         Else
            estadoCupon = Entidades.TarjetaCupon.Estados.NINGUNO
         End If

         If Me.rdbOrdenFechaActualizacion.Checked Then
            orden = Entidades.TarjetaCupon.Ordenamiento.FECHAACTUALIZACION.ToString()
         Else
            orden = Entidades.TarjetaCupon.Ordenamiento.NOMBREYFECHAACTUALIZACION.ToString()
         End If


         Dim dtDetalle As DataTable

         dtDetalle = oCupones.GetInformeCupones(actual.Sucursal.Id, _
                                                0,
                                                fechaIngresoDesde, _
                                                fechaIngresoHasta,
                                                estadoCupon.ToString(),
                                                fechaLiquidacionDesde,
                                                fechaLiquidacionHasta,
                                                numeroCupon,
                                                numeroLote,
                                                enCarteraAl,
                                                idCaja,
                                                idBanco,
                                                idCliente,
                                                orden)

         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         If Me.chbFechaIngreso.Checked Then
            .AppendFormat("Fecha Ingreso: Desde {0} Hasta {1} - ", Me.dtpIngresoHasta.Text, dtpIngresoHasta.Text)
         End If

         If Me.chbEstado.Checked Then
            .AppendFormat(" Estado: {0} -", Me.cmbEstado.Text)
         End If

         If Me.chbFechaLiquidacion.Checked Then
            .AppendFormat("Fecha Liquidacion: Desde {0} Hasta {1} - ", Me.dtpLiquidacionDesde.Text, dtpLiquidacionHasta.Text)
         End If

         If Me.chbNumeroCupon.Checked Then
            .AppendFormat(" Cupón: {0} - ", Me.txtNumeroCupon.Text)
         End If

         If Me.chbNumeroLote.Checked Then
            .AppendFormat(" Lote: {0} - ", Me.txtNumeroLote.Text)
         End If

         If Me.chbFechaEnCarteraAl.Checked Then
            .AppendFormat(" En Cartera Al: {0} - ", Me.dtpFechaEnCarteraAl.Text)
         End If

         If Me.chbCaja.Checked Then
            .AppendFormat(" Caja: {0} - ", Me.cmbCajas.Text)
         End If

         If Me.chbBanco.Checked Then
            .AppendFormat(" Banco: {0} -", Me.cmbBanco.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region


   Private Sub chbFechaEnCarteraAl_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnCarteraAl.CheckedChanged
      If Not Me.chbFechaEnCarteraAl.Checked Then
         Me.dtpFechaEnCarteraAl.Value = Date.Now
      End If
      Me.dtpFechaEnCarteraAl.Enabled = Me.chbFechaEnCarteraAl.Checked
   End Sub

   Private Sub chbNumeroLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroLote.CheckedChanged
      Me.txtNumeroLote.Enabled = Me.chbNumeroLote.Checked
      If Not Me.chbNumeroLote.Checked Then
         Me.txtNumeroLote.Text = ""
      Else
         Me.txtNumeroLote.Focus()
      End If
   End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      If Not Me.chbEstado.Checked Then
         Me.cmbEstado.SelectedIndex = -1
      End If
      Me.cmbEstado.Enabled = Me.chbEstado.Checked
   End Sub
End Class