#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class InfCoeficienteCobranzas

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)

         Me._publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            Me.cmbOrigenVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me._publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
         Me.cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

         Me._publicos.CargaComboEstadosClientes(Me.cmbEstadoCliente)
         Me._publicos.CargaComboDesdeEnum(cmbOrigenEstadoCliente, GetType(Entidades.OrigenFK))
         Me.cmbOrigenEstadoCliente.SelectedValue = Entidades.OrigenFK.Movimiento

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)
         Me._publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         Me.cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Movimiento

         Me._publicos.CargaComboTiposComprobantesRecibo(Me.cmbTiposComprobantesRec, True, "CTACTECLIE", esReciboClienteVinculado:=Nothing)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = False
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
         Me.cmbCajas.SelectedIndex = -1

         With Me.cmbLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With Me.cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbModalidad, GetType(Entidades.EnumSql.GetCoeficienteCobranzasModalidad))
         cmbModalidad.SelectedValue = Reglas.Publicos.CuentasCorrientes.Informes.ModalidadCoeficienteCobranzas

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         ugDetalle.AgregarTotalesSuma({"ImporteCobrar", "ImporteCobrado"})
         ugDetalle.AgregarTotalCustomColumna("Margen", New Ayudante.CustomSummaries.SummaryMargen("ImporteCobrado", "ImporteCobrar", "Margen"))
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"}, {"Ver"})

         Me.PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
#End Region

#Region "Eventos"
   Private Sub ConsultarRecibosAClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
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
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         .AppendFormat("Modalidad: {0} - ", cmbModalidad.Text)

         If Me.chbTipoComprobante.Checked Then
            .AppendFormat(" Tipo de Recibo: {0} - ", Me.cmbTiposComprobantesRec.Text)
         End If

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbLetra.SelectedIndex >= 0 Then
            .AppendFormat(" Letra: {0} - ", Me.cmbLetra.Text)
         End If

         If Me.cmbEmisor.SelectedIndex >= 0 Then
            .AppendFormat(" Emisor: {0} -", Me.cmbEmisor.Text)
         End If

         If Me.chbNumero.Checked Then
            .AppendFormat(" Número: {0} -", Me.txtNumero.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} ({1}) -", Me.cmbVendedor.Text, cmbOrigenVendedor.Text)
         End If

         If Me.chbCobrador.Checked Then
            .AppendFormat(" Cobrador: {0} ({1}) -", Me.cmbCobrador.Text, cmbOrigenCobrador.Text)
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat(" Cobrador: {0} ({1}) -", Me.cmbCategoria.Text, cmbOrigenCategoria.Text)
         End If

         If Me.chbUsuario.Checked Then
            .AppendFormat(" Usuario: {0} -", Me.cmbUsuario.Text)
         End If

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbCaja.Checked Then
            .AppendFormat(" Caja: {0} - ", Me.cmbCajas.Text)
         End If

         If Me.chbEstadoCliente.Checked Then
            .AppendFormat(" Estado Cliente: {0} ({1}) -", Me.cmbEstadoCliente.Text, cmbOrigenEstadoCliente.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

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
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If Me.chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         Me.chkMesCompleto.Checked = False

         ShowError(ex)

      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCliente.Text = String.Empty
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked
      'Me.cmbOrigenCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
         'Me.cmbOrigenVendedor.Enabled = Me.chbVendedor.Checked

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

   Private Sub chbCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCobrador.CheckedChanged
      Try
         Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
         'Me.cmbOrigenCobrador.Enabled = Me.chbCobrador.Checked

         If Not Me.chbCobrador.Checked Then
            Me.cmbCobrador.SelectedIndex = -1
         Else
            If Me.cmbCobrador.Items.Count > 0 Then
               Me.cmbCobrador.SelectedIndex = 0
            End If
         End If

         Me.cmbCobrador.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbEstadoCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbEstadoCliente.CheckedChanged
      Try
         Me.cmbEstadoCliente.Enabled = Me.chbEstadoCliente.Checked
         'Me.cmbOrigenEstadoCliente.Enabled = Me.chbEstadoCliente.Checked

         If Not Me.chbEstadoCliente.Checked Then
            Me.cmbEstadoCliente.SelectedIndex = -1
         Else
            If Me.cmbEstadoCliente.Items.Count > 0 Then
               Me.cmbEstadoCliente.SelectedIndex = 0
            End If
         End If

         Me.cmbEstadoCliente.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbRecibo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantesRec.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantesRec.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantesRec.Items.Count > 0 Then
               Me.cmbTiposComprobantesRec.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantesRec.Focus()
      Catch ex As Exception
         ShowError(ex)
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
         ShowError(ex)
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
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cmbLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cmbLetra.SelectedIndex = -1
      Else
         If Me.cmbLetra.Items.Count > 0 Then
            Me.cmbLetra.SelectedIndex = 0
         End If
      End If
      Me.cmbLetra.Focus()

   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      Me.cmbEmisor.Enabled = Me.chbEmisor.Checked
      If Not Me.chbEmisor.Checked Then
         Me.cmbEmisor.SelectedIndex = -1
      Else
         If Me.cmbEmisor.Items.Count > 0 Then
            Me.cmbEmisor.SelectedIndex = 0
         End If
      End If
      Me.cmbEmisor.Focus()

   End Sub

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged

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
#End Region

#Region "Eventos Foraneos"
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
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
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
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente pero NO selecciono", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbCaja.Checked And Me.cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Caja aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCajas.Focus()
            Exit Sub
         End If

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
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

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index > -1 And e.Cell.Column.Header.Caption = "Ver" Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(e.Cell.Row.Cells("IdSucursal").Value.ToString()),
                                                          e.Cell.Row.Cells("IdTipoComprobante").Value.ToString(),
                                                          e.Cell.Row.Cells("Letra").Value.ToString(), _
                                                          Short.Parse(e.Cell.Row.Cells("CentroEmisor").Value.ToString()), _
                                                          Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString()))

            Dim oImpr As Impresion = New Impresion(venta)

            oImpr.ImprimirComprobanteNoFiscal(True)


         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbCategoria.Checked = False
      Me.cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Movimiento

      Me.chbCliente.Checked = False
      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
         Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento
      End If

      Me.chbTipoComprobante.Checked = False
      Me.chbCaja.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbLetra.Checked = False
      Me.chbEmisor.Checked = False
      Me.chbNumero.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me.chbCobrador.Checked = False
      Me.cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

      Me.chbEstadoCliente.Checked = False
      Me.cmbOrigenEstadoCliente.SelectedValue = Entidades.OrigenFK.Movimiento

      Me.cmbSucursal.Refrescar()

      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         Dim IdTipoComprobante As String = If(Me.cmbTiposComprobantesRec.Enabled, Me.cmbTiposComprobantesRec.SelectedValue.ToString(), String.Empty)
         Dim Letra As String = If(Me.cmbLetra.Enabled, Me.cmbLetra.SelectedValue.ToString(), String.Empty)
         Dim emisor As Integer = If(Me.cmbEmisor.Enabled, Integer.Parse(Me.cmbEmisor.SelectedValue.ToString()), 0)
         Dim NumeroComprobante As Long = If(Me.chbNumero.Checked, Long.Parse(Me.txtNumero.Text), 0)

         Dim IdCliente As Long = If(Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0)

         Dim origenCategoria As Entidades.OrigenFK = DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK)
         Dim IdCategoria As Integer = If(Me.cmbCategoria.Enabled, Integer.Parse(Me.cmbCategoria.SelectedValue.ToString()), 0)

         Dim origenVendedor As Entidades.OrigenFK = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)
         Dim IdVendedor As Integer = If(Me.cmbVendedor.Enabled, DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado, 0)
      
         Dim origenCobrador As Entidades.OrigenFK = DirectCast(cmbOrigenCobrador.SelectedValue, Entidades.OrigenFK)
         Dim IdCobrador As Integer = If(Me.cmbCobrador.Enabled, Integer.Parse(Me.cmbCobrador.SelectedValue.ToString()), 0)

         Dim origenEstadoCliente As Entidades.OrigenFK = DirectCast(cmbOrigenEstadoCliente.SelectedValue, Entidades.OrigenFK)
         Dim IdEstadoCliente As Integer = If(Me.cmbEstadoCliente.Enabled, Integer.Parse(Me.cmbEstadoCliente.SelectedValue.ToString()), 0)

         Dim IdUsuario As String = If(Me.cmbUsuario.Enabled, DirectCast(Me.cmbUsuario.SelectedItem, Entidades.Usuario).Usuario, String.Empty)
         Dim IdCaja As Integer = If(Me.chbCaja.Checked, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), 0)
         Dim IdZonaGeografica As String = If(Me.cmbZonaGeografica.Enabled, DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica, String.Empty)


         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
         Dim dtDetalle As DataTable
         dtDetalle = oCtaCte.GetCoeficienteCobranzas(Me.cmbSucursal.GetSucursales(),
                                                     Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                     IdCliente,
                                                     IdCategoria, origenCategoria,
                                                     IdVendedor, origenVendedor,
                                                     IdTipoComprobante, Letra, emisor, NumeroComprobante,
                                                     IdUsuario,
                                                     IdCaja,
                                                     IdZonaGeografica,
                                                     IdCobrador, origenCobrador,
                                                     IdEstadoCliente, origenEstadoCliente,
                                                     DirectCast(cmbModalidad.SelectedValue, Entidades.EnumSql.GetCoeficienteCobranzasModalidad))

         dtDetalle.Columns.Add("Ver")
         For Each dr As DataRow In dtDetalle.Rows
            dr("Ver") = "..."
         Next

         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class