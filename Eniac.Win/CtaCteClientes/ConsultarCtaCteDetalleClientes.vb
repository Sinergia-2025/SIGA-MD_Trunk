Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarCtaCteDetalleClientes

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboTiposComprobantesCtaCteClientes(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarCtaCteDetalleClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            Filtros = "Vendedor: " & Me.cmbVendedor.Text
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
         End If

         If Me.chbFechasVencimiento.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & " Fechas: desde " & dtpVencimientoDesde.Text & " hasta " & dtpVencimientoHasta.Text
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Tipo Comprobante: " & Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = "Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If

         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Me.chbProvincia.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Provincia: " & Me.cmbProvincia.Text
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Saldos Negativos"
         End If

         If Me.chbExcluirAnticipos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Anticipos"
         End If

         If Filtros.Length > 0 Then Filtros = Filtros & " - "
         If Me.optConSaldo.Checked Then
            Filtros = Filtros & "Comprobantes con Saldo Pend."
         Else
            Filtros = Filtros & "Comprobantes con y sin Saldo Pend."
         End If

         If Me.optVencVencidos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Comprobantes Vencidos"
         End If

         'dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)
         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable).Copy()

         'La impresion utiliza el campo que tiene otros datos (Direccion, Localidad, Cuit, Telefono+Celular, Correo y Transporte.
         For Each dr As DataRow In dt.Rows
            dr("NombreCliente") = dr("NombreCliente2")
         Next


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Titulo", Me.Text))

         Dim frmImprime As VisorReportes

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleClientes.rdlc", "SistemaDataSet_CuentasCorrientesPagos", dt, parm, True)
         Else
            If Me.rbtImpresionNormal.Checked Then
               frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleClientesPorVendedor.rdlc", "SistemaDataSet_CuentasCorrientesPagos", dt, parm, True)
            Else
               frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleClientes1PorHoja.rdlc", "SistemaDataSet_CuentasCorrientesPagos", dt, parm, True)
            End If

         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
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

   Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechasVencimiento.CheckedChanged

      Me.dtpVencimientoDesde.Enabled = Me.chbFechasVencimiento.Checked
      Me.dtpVencimientoHasta.Enabled = Me.chbFechasVencimiento.Checked

      If Me.chbFechasVencimiento.Checked Then
         Me.dtpVencimientoDesde.Value = Date.Now
         Me.dtpVencimientoHasta.Value = Date.Now
      End If

      'Deberia Calcularse, el valor que muestra es con el saldo a lo actual y no a la fecha filtrada
      Me.dgvDetalle.Columns("SaldoCuota").Visible = Not Me.chbFechasVencimiento.Checked
      If Me.chbFechasVencimiento.Checked Then
         Me.optTodos.Checked = True
      End If

      Me.dtpVencimientoDesde.Focus()

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

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
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

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      Try
         If e.RowIndex <> -1 And Me.dgvDetalle.Columns(e.ColumnIndex).HeaderText = "Ver" Then
            Try
               Me.Cursor = Cursors.WaitCursor

               Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
               oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString())

               If oTipoComprobante.EsRecibo Or oTipoComprobante.EsAnticipo Then
                  Dim IdTipoComprobante As String = IIf(oTipoComprobante.EsRecibo, oTipoComprobante.IdTipoComprobante, oTipoComprobante.IdTipoComprobanteSecundario).ToString()
                  Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
                  Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(actual.Sucursal.Id, _
                                 IdTipoComprobante, _
                                 Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                                 Int32.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                                 Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString()))
                  Dim imp As RecibosImprimir = New RecibosImprimir()
                  imp.ImprimirRecibo(ctacte, True)
               Else
                  'imprime los comprobantes que no son recibos
                  Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
                  Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString()))

                  Dim oImpr As Impresion = New Impresion(venta)

                  If Not oTipoComprobante.EsFiscal Then
                     oImpr.ImprimirComprobanteNoFiscal(True)
                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If
               End If

            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
               Me.Cursor = Cursors.Default
            End Try

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      Try
         Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

         If Not Me.chbGrupo.Checked Then
            Me.cmbGrupos.SelectedIndex = -1
         Else
            If Me.cmbGrupos.Items.Count > 0 Then
               Me.cmbGrupos.SelectedIndex = 0
            End If
         End If

         Me.cmbGrupos.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If
      Me.rbtVenActual.Checked = False

      Me.chbCliente.Checked = False
      Me.chbFechasVencimiento.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.chbCategoria.Checked = False
      Me.optConSaldo.Checked = True
      'Me.dgvDetalle.Columns("Total").Visible = Me.optConSaldo.Checked
      Me.chbGrupo.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbExcluirSaldosNegativos.Checked = False
      Me.chbExcluirAnticipos.Checked = False
        Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False

      Me.optVencTodos.Checked = True

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.rbtImpresionNormal.Checked = True
      Me.rbtCatActual.Checked = True
      Me.txtTotalVencido.Text = "0.00"
      Me.txtTotal.Text = "0.00"
      Me.txtSaldo.Text = "0.00"
      Me.chbAgruparIdClienteCtaCte.Checked = False

      Me.chbVendedor.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()

      Dim Total As Decimal = 0
      Dim TotalSaldo As Decimal = 0
      Dim TotalVencido As Decimal = 0

      Dim TipoDocVendedor As String = String.Empty
      Dim NroDocVendedor As String = String.Empty
      Dim IdCliente As Long = 0
      Dim IdZonaGeografica As String = String.Empty
      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing
      Dim TipoComprobante As String = String.Empty
      Dim TipoSaldo As String = String.Empty
      Dim Vencimiento As String = String.Empty
      Dim IdCategoria As Integer = 0
      Dim Grupo As String = String.Empty
      Dim ExcluirSaldosNegativos As String = "NO"
      Dim ExcluirAnticipos As String = "NO"
        Dim ExcluirPreComprobantes As String = "NO"
      Dim IdProvincia As String = String.Empty
      Dim TipoCategoria As String = String.Empty
      Dim TipoVendedor As String = String.Empty

      Dim TotalArraste As Decimal = 0

      Try

         'Me.dgvDetalle.Columns("Total").Visible = Me.optConSaldo.Checked

         If Me.cmbVendedor.Enabled Then
            TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).TipoDocEmpleado
            NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).NroDocEmpleado
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbFechasVencimiento.Checked Then
            Desde = Me.dtpVencimientoDesde.Value
            Hasta = Me.dtpVencimientoHasta.Value
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            TipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbGrupos.Enabled Then
            Grupo = Me.cmbGrupos.SelectedValue.ToString()
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            ExcluirSaldosNegativos = "SI"
         End If
         If Me.chbExcluirAnticipos.Checked Then
            ExcluirAnticipos = "SI"
         End If

            If Me.chbExcluirPreComprobantes.Checked Then
                ExcluirPreComprobantes = "SI"
            End If

         If Me.chbProvincia.Checked Then
            IdProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         TipoSaldo = IIf(Me.optTodos.Checked, "TODOS", "SOLOSALDO").ToString()

         Vencimiento = IIf(Me.optVencTodos.Checked, "TODOS", "SOLOVENCIDOS").ToString()

         TipoCategoria = IIf(Me.rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()

         TipoVendedor = IIf(Me.rbtVenMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()

         Me.txtTotal.Visible = Me.optTodos.Checked And Me.optVencTodos.Checked


         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow
         If Me.chbAgruparIdClienteCtaCte.Checked Then
            dtDetalle = oCtaCteDet.GetDetalleIdClienteCtaCte(actual.Sucursal.Id, _
                                                   Desde, Hasta, _
                                                   TipoDocVendedor, NroDocVendedor, _
                                                   IdCliente, _
                                                   TipoComprobante, _
                                                   TipoSaldo, _
                                                   Vencimiento, _
                                                   IdZonaGeografica, _
                                                   IdCategoria, _
                                                   Me.cmbGrabanLibro.Text, _
                                                   Grupo, _
                                                   ExcluirSaldosNegativos, _
                                                   ExcluirAnticipos, _
                                                   ExcluirPreComprobantes, _
                                                   IdProvincia, TipoCategoria, TipoVendedor)
         Else
            dtDetalle = oCtaCteDet.GetDetalle(actual.Sucursal.Id, _
                                                     Desde, Hasta, _
                                                     TipoDocVendedor, NroDocVendedor, _
                                                     IdCliente, _
                                                     TipoComprobante, _
                                                     TipoSaldo, _
                                                     Vencimiento, _
                                                     IdZonaGeografica, _
                                                     IdCategoria, _
                                                     Me.cmbGrabanLibro.Text, _
                                                     Grupo, _
                                                     ExcluirSaldosNegativos, _
                                                     ExcluirAnticipos, _
                                                     ExcluirPreComprobantes, _
                                                     IdProvincia, TipoCategoria, TipoVendedor)
         End If


         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("Ver") = "..."
            drCl("TipoDocVendedor") = dr("TipoDocVendedor").ToString()
            drCl("NroDocVendedor") = dr("NroDocVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCliente2") = dr("NombreCliente2").ToString()
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("CuotaNumero") = Integer.Parse(dr("CuotaNumero").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())

            If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then  ''DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today) > 0 And 
               Dim diasFactura As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today)), 0)
               drCl("DiasFactura") = diasFactura
            End If

            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())

            If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then ''DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today) > 0 And 
               Dim diasVencido As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today)), 0)
               drCl("DiasVencido") = diasVencido
               If diasVencido > 0 Then
                  TotalVencido += Decimal.Parse(dr("SaldoCuota").ToString())
               End If
            End If

            drCl("ImporteCuota") = Decimal.Parse(dr("ImporteCuota").ToString())
            drCl("SaldoCuota") = Decimal.Parse(dr("SaldoCuota").ToString())

            TotalArraste += Decimal.Parse(dr("SaldoCuota").ToString())

            drCl("Total") = TotalArraste

            Total += Decimal.Parse(dr("ImporteCuota").ToString())
            TotalSaldo += Decimal.Parse(dr("SaldoCuota").ToString())

            dt.Rows.Add(drCl)

         Next

         txtTotalVencido.Text = TotalVencido.ToString("#,##0.00")

         txtTotal.Text = Total.ToString("#,##0.00")
         txtSaldo.Text = TotalSaldo.ToString("#,##0.00")

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
         .Columns.Add("Ver", System.Type.GetType("System.String"))
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("TipoDocVendedor", System.Type.GetType("System.String"))
         .Columns.Add("NroDocVendedor", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCliente2", System.Type.GetType("System.String"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("CuotaNumero", System.Type.GetType("System.Int32"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("DiasFactura", System.Type.GetType("System.Int32"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("DiasVencido", System.Type.GetType("System.Int32"))
         .Columns.Add("ImporteCuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("SaldoCuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

#End Region

End Class