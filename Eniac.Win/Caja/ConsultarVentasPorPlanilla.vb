Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarVentasPorPlanilla

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = False
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         'Dim TodasLasCajas As Integer = New Reglas.CajasNombres().GetAll(actual.Sucursal.IdSucursal).Rows.Count
         'If TodasLasCajas <> Me.cmbCajas.Items.Count Then
         '   Me.chbCaja.Checked = True
         '   Me.chbCaja.Enabled = False  'Para que no pueda modificarlo manualmente
         'End If

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarVentasPorPlanilla_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatosGrilla()
         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.dgvDetalle.RowCount = 0 Then Exit Sub

      Try

         Dim Filtros As String

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Filtros: Rango de Planillas: desde la " & Me.txtNroPlanillaDesde.Text & " hasta la " & Me.txtNroPlanillaHasta.Text

         If Me.chkPorFecha.Checked Then
            Filtros = Filtros & "  /  Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            Filtros = Filtros & "  /  Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            Filtros = Filtros & "  /  Comprobante: " & Me.cmbTiposComprobantes.Text
         End If

         If Me.chbNumero.Checked Then
            Filtros = Filtros & " / Numero: " & Me.txtNumero.Text
         End If

         Filtros = Filtros & "  /  Graban Libro: " & cmbGrabanLibro.SelectedItem.ToString()

         If Me.cmbVendedor.Enabled Then
            Dim IdVendedor As Integer
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            Filtros = Filtros & "  /  Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.Text
         End If

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ConsultarVentasPorPlanilla.rdlc", "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCajas.SelectedIndexChanged

      Dim rnCajas As Reglas.Cajas = New Reglas.Cajas

      Me.txtNroPlanillaDesde.Text = rnCajas.GetPlanillaActual(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString())).NumeroPlanilla.ToString()
      Me.txtNroPlanillaHasta.Text = Me.txtNroPlanillaDesde.Text

   End Sub

   Private Sub chkPorFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPorFecha.CheckedChanged

      Me.dtpDesde.Enabled = Me.chkPorFecha.Checked
      Me.dtpHasta.Enabled = Me.chkPorFecha.Checked

      If Me.dtpDesde.Enabled Then
         Me.dtpDesde.Value = DateTime.Today
         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      End If

   End Sub

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged

      Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

      If Not Me.chbTipoComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      Me.cmbTiposComprobantes.Focus()

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

         If Long.Parse("0" & Me.txtNroPlanillaDesde.Text) <= 0 Then
            MessageBox.Show("ATENCION: Debe ingresar una 'Planilla Desde' correcto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroPlanillaDesde.Focus()
            Exit Sub
         End If
         If Long.Parse("0" & Me.txtNroPlanillaHasta.Text) <= 0 Then
            MessageBox.Show("ATENCION: Debe ingresar una 'Planilla Hasta' correcto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroPlanillaHasta.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Me.bscCodigoCliente.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
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

   Private Sub dtgVentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                        Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                        Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                        Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                        Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString()))

            Dim oImpr As Impresion = New Impresion(venta)

            If Me.dgvDetalle.Rows(e.RowIndex).Cells("TipoImpresora").Value.ToString() = "NORMAL" Then
               oImpr.ImprimirComprobanteNoFiscal(True)
            Else
               oImpr.ReImprimirComprobanteFiscal()
            End If

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbCajas.SelectedIndex = 0

      Me.txtNroPlanillaDesde.Text = ""
      Me.txtNroPlanillaHasta.Text = ""
      Me.chkPorFecha.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbNumero.Checked = False

      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbUsuario.Checked = False

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtTotal.Text = "0.00"
      Me.txtImportePesos.Text = "0.00"
      Me.txtImporteCheques.Text = "0.00"
      Me.txtImporteTarjetas.Text = "0.00"
      Me.txtImporteTickets.Text = "0.00"
      Me.txtImporteBancos.Text = "0.00"

      Me.cmbCajas.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

      Dim Total As Decimal = 0
      Dim ImportePesos As Decimal = 0
      Dim ImporteTickets As Decimal = 0
      Dim ImporteTarjetas As Decimal = 0
      Dim ImporteCheques As Decimal = 0
      Dim ImporteBancos As Decimal = 0

      Dim IdCaja As Integer = 0

      Dim NroPlanillaDesde As Long
      Dim NroPlanillaHasta As Long

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim IdCliente As Long = 0

      Dim IdTipoComprobante As String = String.Empty
      Dim NumeroComprobante As Long = 0

      Dim IdVendedor As Integer = 0

      Dim IdUsuario As String = String.Empty

      Try

         IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

         NroPlanillaDesde = Long.Parse(Me.txtNroPlanillaDesde.Text)
         NroPlanillaHasta = Long.Parse(Me.txtNroPlanillaHasta.Text)

         If Me.chkPorFecha.Checked Then
            FechaDesde = Me.dtpDesde.Value
            FechaHasta = Me.dtpHasta.Value
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.chbNumero.Checked Then
            NumeroComprobante = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbUsuario.Enabled Then
            'IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Entidades.Usuario).Usuario
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         Me.dgvDetalle.DataSource = oVenta.GetPorRangoPlanillas(actual.Sucursal.Id, _
                                                                IdCaja, _
                                                                NroPlanillaDesde, NroPlanillaHasta, _
                                                                FechaDesde, FechaHasta, _
                                                                IdVendedor,
                                                                Me.cmbGrabanLibro.Text, _
                                                               IdCliente, _
                                                                "SI", _
                                                                IdTipoComprobante, _
                                                                NumeroComprobante, _
                                                                IdUsuario)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            If dr.Cells("TipoImpresora").Value.ToString() = "NORMAL" Then
               dr.Cells("Ver").Value = "..."
            Else
               dr.Cells("Ver").Value = "( F )"
            End If

            If dr.Cells("IdEstadoComprobante").Value.ToString() = "ANULADO" Then
               dr.Cells("NombreCliente").Value = "** COMPROBANTE ANULADO **"
            End If

            Total = Total + Decimal.Parse(dr.Cells("ImporteTotal").Value.ToString())
            ImportePesos = ImportePesos + Decimal.Parse(dr.Cells("ImportePesos").Value.ToString())
            ImporteTickets = ImporteTickets + Decimal.Parse(dr.Cells("ImporteTickets").Value.ToString())
            ImporteTarjetas = ImporteTarjetas + Decimal.Parse(dr.Cells("ImporteTarjetas").Value.ToString())
            ImporteCheques = ImporteCheques + Decimal.Parse(dr.Cells("ImporteCheques").Value.ToString())
            ImporteBancos = ImporteBancos + Decimal.Parse(dr.Cells("ImporteBancos").Value.ToString())
         Next

         txtTotal.Text = Total.ToString("#,##0.00")
         txtImportePesos.Text = ImportePesos.ToString("#,##0.00")
         txtImporteTickets.Text = ImporteTickets.ToString("#,##0.00")
         txtImporteTarjetas.Text = ImporteTarjetas.ToString("#,##0.00")
         txtImporteCheques.Text = ImporteCheques.ToString("#,##0.00")
         txtImporteBancos.Text = ImporteBancos.ToString("#,##0.00")

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class