Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarVentas

#Region "Campos"

   Private _publicos As Publicos
   'Private _puedeAnularComprobantes As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddDays(1).AddSeconds(-1)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me.cmbFormaPago.SelectedIndex = -1
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 0

         Me.cmbMercDespachada.Items.Insert(0, "TODOS")
         Me.cmbMercDespachada.Items.Insert(1, "SI")
         Me.cmbMercDespachada.Items.Insert(2, "NO")
         Me.cmbMercDespachada.SelectedIndex = 0

         Me.cmbEsComercial.Items.Insert(0, "TODOS")
         Me.cmbEsComercial.Items.Insert(1, "SI")
         Me.cmbEsComercial.Items.Insert(2, "NO")
         Me.cmbEsComercial.SelectedIndex = 0

         With Me.cboLetra
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

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me.dgvDetalle.Columns("Percepciones").Visible = Publicos.RetieneIIBB
         Me.txtPercepciones.Visible = Publicos.RetieneIIBB
         Me.dgvDetalle.Columns("colCAE").Visible = Publicos.TieneModuloFacturacionElectronica
         Me.dgvDetalle.Columns("colCAEVencimiento").Visible = Publicos.TieneModuloFacturacionElectronica

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.bscCodigoCliente.Text.Length > 0 Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            Filtros = Filtros & " / Comprobante: " & Me.cmbTiposComprobantes.Text
         End If

         If Me.chbNumero.Checked Then
            Filtros = Filtros & " / Numero: " & Me.txtNumero.Text
         End If

         Filtros = Filtros & " / Graban Libro: " & Me.cmbGrabanLibro.Text

         Filtros = Filtros & " / Afecta Caja: " & Me.cmbAfectaCaja.Text

         Filtros = Filtros & " / Es Comercial: " & Me.cmbEsComercial.Text

         If Me.cmbVendedor.Enabled Then
            Dim TipoDocVendedor As String
            Dim NroDocVendedor As String
            TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).TipoDocEmpleado
            NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).NroDocEmpleado
            Filtros = Filtros & " / Vendedor: " & TipoDocVendedor & " " & NroDocVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.cmbFormaPago.Enabled Then
            Filtros = Filtros & " / Forma de Pago: " & Me.cmbFormaPago.Text
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.Text
         End If

         If Me.cmbMercDespachada.SelectedIndex > 0 Then
            Filtros = Filtros & " / Merc. Despachada: " & Me.cmbMercDespachada.Text
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If


         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ConsultarVentas.rdlc", "SistemaDataSet_Ventas", dt, parm, True)
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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If Me.chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         Me.chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub dtgVentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

         If e.RowIndex <> -1 Then

            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim oComprobante As Entidades.Venta

            Select Case Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name

               Case "colVer", "colImprimir", "colVerEstandar"
                  Me.Cursor = Cursors.WaitCursor

                  oComprobante = oVentas.GetUna(actual.Sucursal.Id, Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))

                  'Si se necesita probar la exportación, descomentar este codigo.
                  'Dim ePDF As ExportarPDF = New ExportarPDF()
                  'Dim ArchivoDestino As String = New Reglas.Parametros().GetValor2(Entidades.Parametro.Parametros.UBICACIONPDFSFE.ToString()) & "\" & Publicos.CuitEmpresa & "_" & _
                  '               oComprobante.TipoComprobante.DescripcionAbrev & "_" & _
                  '               oComprobante.LetraComprobante & "_" & _
                  '               oComprobante.CentroEmisor.ToString("0000") & "_" & _
                  '               oComprobante.NumeroComprobante.ToString("00000000") + ".pdf"
                  'ePDF.Exportar(oComprobante, ArchivoDestino)

                  Dim oImpr As Impresion = New Impresion(oComprobante)

                  If Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name <> "colImprimir" Then

                     If oComprobante.Impresora.TipoImpresora = "NORMAL" Then
                        Dim ReporteEstandar As Boolean = (Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "colVerEstandar")
                        oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

                        'ver donde iria
                        'If Publicos.RetieneIIBB Then
                        '   If Comprobante.Cliente.InscriptoIBStaFe Then
                        If oComprobante.Percepciones IsNot Nothing Then
                           If oComprobante.Percepciones.ImporteTotal <> 0 Then
                              Dim ret As PercepcionImprimir = New PercepcionImprimir()
                              ret.ImprimirPercepcion(oComprobante)
                           End If
                        End If
                        '   End If
                        'End If
                        'ver donde iria

                     Else
                        oImpr.ReImprimirComprobanteFiscal()
                     End If

                  Else

                     If Me.dgvDetalle.Rows(e.RowIndex).Cells("TipoImpresora").Value.ToString() = "NORMAL" Then

                        oImpr.ImprimirComprobanteNoFiscal(False)

                     ElseIf Not oComprobante.TipoComprobante.GrabaLibro Then

                        Dim fc As FacturacionComunes = New FacturacionComunes()
                        fc.ImprimirComprobante(oComprobante, oComprobante.TipoComprobante.EsFiscal)

                     Else
                        MessageBox.Show("No es posible Reimprimir en la Impresora Fiscal un Comprobante FISCAL.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     End If
                  End If

               Case "colCantidadInvocados"

                  If String.IsNullOrEmpty(Me.dgvDetalle.Rows(Me.dgvDetalle.SelectedRows(0).Index).Cells("colCantidadInvocados").Value.ToString()) Then Exit Sub

                  oComprobante = oVentas.GetUna(actual.Sucursal.Id, Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                                                Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                                                Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                                                Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))

                  Dim oComprobantesInvocados As FacturablesInvocados

                  oComprobantesInvocados = New FacturablesInvocados(oComprobante.TipoComprobante.IdTipoComprobante, _
                                                                    oComprobante.LetraComprobante, _
                                                                    oComprobante.CentroEmisor, _
                                                                    oComprobante.NumeroComprobante)

                  oComprobantesInvocados.ShowDialog()

               Case "colCantidadLotes"

                  If String.IsNullOrEmpty(Me.dgvDetalle.Rows(Me.dgvDetalle.SelectedRows(0).Index).Cells("colCantidadLotes").Value.ToString()) Then Exit Sub

                  oComprobante = oVentas.GetUna(actual.Sucursal.Id, Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))

                  Dim cl As ConsultarLotes = New ConsultarLotes(oComprobante.TipoComprobante.IdTipoComprobante, _
                                                                oComprobante.LetraComprobante, _
                                                                oComprobante.CentroEmisor, _
                                                                oComprobante.NumeroComprobante, _
                                                                0)

                  cl.ShowDialog()
               Case Else
            End Select
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
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

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked


         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

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

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbLocalidad.Checked And Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
            MessageBox.Show("No seleccionó una Localidad aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

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

   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged

      Me.bscCodigoLocalidad.Enabled = Me.chbLocalidad.Checked
      Me.bscNombreLocalidad.Enabled = Me.chbLocalidad.Checked

      Me.bscCodigoLocalidad.Text = String.Empty
      Me.bscNombreLocalidad.Text = String.Empty

      If Me.chbLocalidad.Checked Then
         Me.bscCodigoLocalidad.Focus()
      End If

   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cboLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cboLetra.SelectedIndex = -1
      Else
         If Me.cboLetra.Items.Count > 0 Then
            Me.cboLetra.SelectedIndex = 0
         End If
      End If
      Me.cboLetra.Focus()

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

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbNumero.Checked = False
      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 0
      Me.cmbMercDespachada.SelectedIndex = 0
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbFormaPago.Checked = False
      Me.cmbEsComercial.SelectedIndex = 0
      Me.chbCategoria.Checked = False
      Me.chbLocalidad.Checked = False
      Me.chbProvincia.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbLetra.Checked = False
      Me.chbEmisor.Checked = False

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtSubtotal.Text = "0.00"
      Me.txtImpuestos.Text = "0.00"
      Me.txtTotal.Text = "0.00"

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim TotalNeto As Decimal = 0
         Dim TotalImpuestos As Decimal = 0
         Dim Total As Decimal = 0
         Dim TotalPercepciones As Decimal = 0

         Dim IdCliente As Long = 0

         Dim IdTipoComprobante As String = String.Empty
         Dim NumeroComprobante As Long = 0

         Dim TipoDocVendedor As String = String.Empty
         Dim NroDocVendedor As String = String.Empty

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty

         Dim IdCategoria As Integer = 0
         Dim Letra As String = ""
         Dim emisor As Integer = 0

         Dim IdZonaGeografica As String = String.Empty
         Dim IdLocalidad As Integer = 0
         Dim IdProvincia As String = String.Empty

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
            TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).TipoDocEmpleado
            NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).NroDocEmpleado
         End If

         If Me.cmbFormaPago.Enabled Then
            IdFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.chbLocalidad.Checked Then
            IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         If Me.chbProvincia.Checked Then
            IdProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.cboLetra.Enabled Then
            Letra = Me.cboLetra.SelectedValue.ToString()
         End If

         If Me.cmbEmisor.Enabled Then
            emisor = Integer.Parse(Me.cmbEmisor.SelectedValue.ToString())
         End If



         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oVenta.GetConsultarVentas(actual.Sucursal.Id, _
                                              Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                              TipoDocVendedor, NroDocVendedor, _
                                              Me.cmbGrabanLibro.Text, _
                                              IdCliente, _
                                              Me.cmbAfectaCaja.Text, _
                                              IdTipoComprobante, _
                                              NumeroComprobante, _
                                              IdFormasPago, _
                                              IdUsuario, _
                                              Me.cmbMercDespachada.Text, _
                                              Me.cmbEsComercial.Text, _
                                              IdCategoria, IdLocalidad, IdProvincia, _
                                              Letra, emisor, IdZonaGeografica)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            'If dr("TipoImpresora").ToString() = "NORMAL" Then
            drCl("Ver") = "..."
            'Else
            '   drCl("Ver") = "( F )"
            'End If

            drCl("Imprimir") = "I"
            drCl("VerEstandar") = ".E."

            drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            'drCl("IdSucursal") = Decimal.Parse(dr("IdSucursal").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
                drCl("IdCliente") = dr("IdCliente").ToString()
                If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
                    drCl("NombreCliente") = dr("NombreCliente").ToString()
                Else
                    drCl("NombreCliente") = "** COMPROBANTE ANULADO **"
                End If

            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
            drCl("FormaDePago") = dr("FormaDePago").ToString()

            If Integer.Parse(dr("CantidadInvocados").ToString()) > 0 Then
               drCl("CantidadInvocados") = Integer.Parse(dr("CantidadInvocados").ToString())
            End If

            If Integer.Parse(dr("CantidadLotes").ToString()) > 0 Then
               drCl("CantidadLotes") = Integer.Parse(dr("CantidadLotes").ToString())
            End If

            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            drCl("Usuario") = dr("Usuario").ToString()
            If Not String.IsNullOrEmpty(dr("CAE").ToString()) Then
               drCl("CAE") = dr("CAE").ToString()
            End If
            If Not String.IsNullOrEmpty(dr("CAEVencimiento").ToString()) Then
               drCl("CAEVencimiento") = dr("CAEVencimiento").ToString()
            End If
            drCl("Observacion") = dr("Observacion").ToString()

            drCl("MercDespachada") = Boolean.Parse(dr("MercDespachada").ToString())
            If Not String.IsNullOrEmpty(dr("FechaActualizacion").ToString()) Then
               drCl("FechaActualizacion") = Date.Parse(dr("FechaActualizacion").ToString())
            End If
            If Not String.IsNullOrEmpty(dr("NombreProveedor").ToString()) Then
               drCl("NombreProveedor") = dr("NombreProveedor").ToString()
            End If
            drCl("ImportePesos") = Decimal.Parse(dr("ImportePesos").ToString())
            drCl("ImporteTickets") = Decimal.Parse(dr("ImporteTickets").ToString())
            drCl("ImporteCheques") = Decimal.Parse(dr("ImporteCheques").ToString())
            drCl("ImporteTarjetas") = Decimal.Parse(dr("ImporteTarjetas").ToString())
            drCl("ImporteTransfBancaria") = Decimal.Parse(dr("ImporteTransfBancaria").ToString())

            If Decimal.Parse(dr("ImporteTransfBancaria").ToString()) <> 0 Then
               drCl("IdCuentaBancaria") = Integer.Parse(dr("IdCuentaBancaria").ToString())
               drCl("NombreBanco") = dr("NombreBanco").ToString()
            End If

            drCl("Iva") = Decimal.Parse(dr("IVA").ToString())
            drCl("Percepciones") = Decimal.Parse(dr("Percepciones").ToString())
            dt.Rows.Add(drCl)

            TotalNeto = TotalNeto + Decimal.Parse(drCl("SubTotal").ToString())
            TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("Iva").ToString())
            TotalPercepciones = TotalPercepciones + Decimal.Parse(drCl("Percepciones").ToString())
            Total = Total + Decimal.Parse(drCl("ImporteTotal").ToString())

         Next

         Me.txtSubtotal.Text = TotalNeto.ToString("#,##0.00")
         Me.txtImpuestos.Text = TotalImpuestos.ToString("#,##0.00")
         Me.txtPercepciones.Text = TotalPercepciones.ToString("#,##0.00")
         Me.txtTotal.Text = Total.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("Imprimir")
         .Columns.Add("VerEstandar")
         .Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("CantidadInvocados", System.Type.GetType("System.Int32"))
         .Columns.Add("CantidadLotes", System.Type.GetType("System.Int32"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         '.Columns.Add("IdTipoMovimiento", System.Type.GetType("System.String"))
         '.Columns.Add("NumeroMovimiento", System.Type.GetType("System.Int64"))
         '.Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("CAE", System.Type.GetType("System.String"))
         .Columns.Add("CAEVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("MercDespachada", System.Type.GetType("System.Boolean"))
         .Columns.Add("FechaActualizacion", System.Type.GetType("System.DateTime"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("ImportePesos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTickets", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteCheques", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTarjetas", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdCuentaBancaria", System.Type.GetType("System.Int32"))
         .Columns.Add("ImporteTransfBancaria", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreBanco", System.Type.GetType("System.String"))
         .Columns.Add("Iva", System.Type.GetType("System.Decimal"))
         .Columns.Add("Percepciones", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Enabled = False
      Me.bscCodigoLocalidad.Enabled = False
   End Sub
#End Region

End Class