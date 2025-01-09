Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarCtaCteClientes

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
         If Not String.IsNullOrEmpty(IdUsuario) Then
            If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
               IdUsuario = ""
            End If
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

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me._publicos.CargaComboTiposComprobantesCtaCteClientes(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         If Publicos.CategoriaClientePredeterminada = "ACTUAL" Then
            Me.rbtCatActual.Checked = True
         Else
            Me.rbtCatMovimiento.Checked = True
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
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

         If Me.chbFecha.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & " Fechas: desde " & dtpDesde.Text & " hasta " & dtpHasta.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = "Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Tipo Comprobante: " & Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         '0 Es TODOS
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


         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable).Copy()

         'La impresion utiliza el campo que tiene otros datos (Direccion, Localidad, Cuit, Telefono+Celular, Correo y Transporte.
         For Each dr As DataRow In dt.Rows
            dr("NombreCliente") = dr("NombreCliente2")
         Next

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("OcultarSaldo", Me.chbFecha.Checked.ToString()))

         Dim frmImprime As VisorReportes

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteClientes.rdlc", "DataSetCtaCteClientes_CuentasCorrientes", dt, parm, True)
         Else
            If Me.rbtImpresionNormal.Checked Then
               frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteClientesPorVendedor.rdlc", "DataSetCtaCteClientes_CuentasCorrientes", dt, parm, True)
            Else
               frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteClientes1PorHoja.rdlc", "DataSetCtaCteClientes_CuentasCorrientes", dt, parm, True)
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

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      Try
         'If e.ColumnIndex = 2 And e.RowIndex <> -1 Then
         If e.RowIndex <> -1 And Me.dgvDetalle.Columns(e.ColumnIndex).HeaderText = "Ver" Then

            Try
               Me.Cursor = Cursors.WaitCursor

               Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
               oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString())

               If oTipoComprobante.EsRecibo = True Then

                  'imprime los recibos
                  Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
                  Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(actual.Sucursal.Id, _
                                 Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                                 Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                                 Int32.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                                 Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))
                  Dim imp As RecibosImprimir = New RecibosImprimir()
                  imp.ImprimirRecibo(ctacte, True)
               Else
                  'imprime los comprobantes que no son recibos
                  Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
                  Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))

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
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

   Private Sub chkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Me.chbFecha.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpDesde.Focus()

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
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

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

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If
      Me.rbtVenActual.Checked = False

      Me.chbCliente.Checked = False
      Me.chbFecha.Checked = False
      Me.chbGrupo.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.optConSaldo.Checked = True
      Me.chbExcluirSaldosNegativos.Checked = False
        Me.chbExcluirAnticipos.Checked = False
        Me.chbExcluirPreComprobantes.Checked = False

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.rbtImpresionNormal.Checked = True
      Me.chbProvincia.Checked = False

      Me.txtTotal.Text = "0.00"
      Me.txtSaldo.Text = "0.00"
      Me.rbtCatActual.Checked = True
      Me.rbtVenActual.Checked = True
      Me.bscCodigoCliente.Focus()
      Me.chbAgruparIdClienteCtaCte.Checked = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

         Dim decTotal As Decimal = 0
         Dim decSaldo As Decimal = 0
         Dim decSaldoCliente As Decimal = 0

         Dim TipoDocVendedor As String = String.Empty
         Dim NroDocVendedor As String = String.Empty
         Dim IdCliente As Long = 0
         Dim IdZonaGeografica As String = String.Empty
         Dim Desde As Date = Nothing
         Dim Hasta As Date = Nothing
         Dim TipoComprobante As String = String.Empty
         Dim TipoSaldo As String = String.Empty
         Dim TipoCategoria As String = String.Empty
         Dim TipoVendedor As String = String.Empty
         Dim IdCategoria As Integer = 0
         Dim Total As Decimal = 0
         Dim Grupo As String = String.Empty
         Dim ExcluirSaldosNegativos As String = "NO"
         Dim ExcluirAnticipos As String = "NO"
            Dim ExcluirPreComprobantes As String = "NO"
         Dim IdProvincia As String = String.Empty

         If Me.chbFecha.Checked Then
            Me.optTodos.Checked = True
         End If

         Me.txtTotal.Visible = Not Me.chbFecha.Checked

         If Me.txtTotal.Visible And Not Me.optTodos.Checked Then
            Me.txtTotal.Visible = False
         End If

         '---------------------------------------------------------------------------------------------

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

         If Me.chbFecha.Checked Then
            Desde = Me.dtpDesde.Value
            Hasta = Me.dtpHasta.Value
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

         TipoSaldo = IIf(Me.optTodos.Checked, "TODOS", "SOLOSALDO").ToString()

         TipoCategoria = IIf(Me.rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()

         TipoVendedor = IIf(Me.rbtVenMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()

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

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         If Me.chbAgruparIdClienteCtaCte.Checked Then
            dtDetalle = oCtaCte.GetCtaCteIdClienteCtaCte(actual.Sucursal.Id, _
                                                 Desde, Hasta, _
                                                 TipoDocVendedor, NroDocVendedor, _
                                                 IdCliente, _
                                                 TipoComprobante, _
                                                 TipoSaldo, _
                                                 IdZonaGeografica, _
                                                 IdCategoria, _
                                                 Me.cmbGrabanLibro.Text, _
                                                 Grupo, _
                                                 ExcluirSaldosNegativos, _
                                                 ExcluirAnticipos, _
                                                 ExcluirPreComprobantes, _
                                                 IdProvincia, TipoCategoria, TipoVendedor)
         Else
            dtDetalle = oCtaCte.GetCtaCte(actual.Sucursal.Id, _
                                                  Desde, Hasta, _
                                                  TipoDocVendedor, NroDocVendedor, _
                                                  IdCliente, _
                                                  TipoComprobante, _
                                                  TipoSaldo, _
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

            If Long.Parse(dr("IdCliente").ToString()) <> IdCliente Then
               IdCliente = Long.Parse(dr("IdCliente").ToString())
               decSaldoCliente = 0
            End If

            'If dr("TipoImpresora").ToString() = "NORMAL" Then
            drCl("Ver") = "..."
            'ElseIf dr("TipoImpresora").ToString() = "FISCAL" Then
            '   drCl("Ver") = "( F )"
            'ElseIf String.IsNullOrEmpty(dr("TipoImpresora").ToString()) Then
            '   drCl("Ver") = "CC"
            'End If

            'drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("TipoDocVendedor") = dr("TipoDocVendedor").ToString()
            drCl("NroDocVendedor") = dr("NroDocVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCliente2") = dr("NombreCliente2").ToString()
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionTipoComprobante") = dr("DescripcionTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            If Not Me.chbFecha.Checked Then
               drCl("Saldo") = Decimal.Parse(dr("Saldo").ToString())
               decSaldo = decSaldo + Decimal.Parse(dr("Saldo").ToString())
            Else
               decSaldoCliente += Decimal.Parse(dr("ImporteTotal").ToString())
               drCl("Saldo") = decSaldoCliente
               decSaldo += Decimal.Parse(dr("ImporteTotal").ToString())
            End If

            Total += Decimal.Parse(dr("Saldo").ToString())

            drCl("Total") = Total

            drCl("IdFormasPago") = Integer.Parse(dr("IdFormasPago").ToString())
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago").ToString()
            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)

            decTotal += Decimal.Parse(dr("ImporteTotal").ToString())

         Next

         Me.txtTotal.Text = decTotal.ToString("#,##0.00")
         Me.txtSaldo.Text = decSaldo.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dt

         If Me.dgvDetalle.Rows.Count = 1 Then
            Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registro"
         Else
            Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver", System.Type.GetType("System.String"))
         '.Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
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
         .Columns.Add("DescripcionTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Saldo", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdFormasPago", System.Type.GetType("System.Int32"))
         .Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

#End Region

End Class