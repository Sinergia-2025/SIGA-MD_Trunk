Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarCtaCteDetalleProveedores

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Me.dtpDesde.Value = DateTime.Now
         'Me.dtpHasta.Value = DateTime.Now

         Me._publicos.CargaComboTiposComprobantesCtaCteProveedores(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me._publicos.CargaComboCategoriasProveedores(Me.cmbCategoria)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarCtaCteDetalleProveedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chkFechas.Checked Then
            filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If

         If Me.chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", Me.cmbCategoria.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", Me.cmbTiposComprobantes.Text)
         End If

         If Me.optConSaldo.Checked Then
            filtro.AppendFormat(" - Saldo: {0}", Me.optConSaldo.Text)
         End If
         If Me.optTodos.Checked Then
            filtro.AppendFormat(" - Saldo: {0}", Me.optTodos.Text)
         End If

         If Me.optVencTodos.Checked Then
            filtro.AppendFormat(" - Vencimiento: {0}", Me.optVencTodos.Text)
         End If
         If Me.optVencVencidos.Checked Then
            filtro.AppendFormat(" - Vencimiento: {0}", Me.optVencVencidos.Text)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Me.CargarFiltrosImpresion))

         Dim frmImprime As VisorReportes

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleProveedores.rdlc", "SistemaDataSet_CuentasCorrientesProvPagos", dt, parm, True, 1) '# 1 = Cantidad Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleProveedoresPorProveedor.rdlc", "SistemaDataSet_CuentasCorrientesProvPagos", dt, parm, True, 1) '# 1 = Cantidad Copias
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

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      If Not Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Text = ""
         Me.bscCodigoProveedor.Tag = Nothing
         Me.bscProveedor.Text = ""
      Else
         Me.bscCodigoProveedor.Focus()
      End If

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

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFechas.CheckedChanged

      Me.dtpDesde.Enabled = Me.chkFechas.Checked
      Me.dtpHasta.Enabled = Me.chkFechas.Checked

      If Me.chkFechas.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
      End If

      'Deberia Calcularse, el valor que muestra es con el saldo a lo actual y no a la fecha filtrada
      Me.dgvDetalle.Columns("SaldoCuota").Visible = Not Me.chkFechas.Checked
      If Me.chkFechas.Checked Then
         Me.optTodos.Checked = True
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

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Proveedor, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
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

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbProveedor.Checked = False
      Me.chkFechas.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.chbCategoria.Checked = False
      Me.optConSaldo.Checked = True
      Me.optVencTodos.Checked = True
      Me.bscCodigoProveedor.Tag = Nothing

      'Limpio la Grilla.
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      txtTotalVencido.Text = "0.00"
      txtTotal.Text = "0.00"
      txtSaldo.Text = "0.00"

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteDet As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos()

      Dim idProveedor As Long = 0
      Dim Total As Decimal = 0
      Dim TotalSaldo As Decimal = 0
      Dim TotalVencido As Decimal = 0

      Dim CodigoProveedor As Long = 0

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Dim IdTipoComprobante As String = String.Empty

      Dim TipoSaldo As String = String.Empty

      Dim Vencimiento As String = String.Empty

      Dim IdCategoria As Integer = 0

      Try

         If Me.bscCodigoProveedor.Text.Length > 0 Then
            CodigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text)
         End If

         If Me.chkFechas.Checked Then
            Desde = Me.dtpDesde.Value
            Hasta = Me.dtpHasta.Value
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         TipoSaldo = IIf(Me.optTodos.Checked, "TODOS", "SOLOSALDO").ToString()

         Vencimiento = IIf(Me.optVencTodos.Checked, "TODOS", "SOLOVENCIDOS").ToString()

         Me.txtTotal.Visible = Me.optTodos.Checked And Me.optVencTodos.Checked

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         If bscCodigoProveedor.Tag IsNot Nothing AndAlso bscCodigoProveedor.Tag.ToString() IsNot String.Empty Then
            idProveedor = Long.Parse(CStr(bscCodigoProveedor.Tag))
         End If

         dtDetalle = oCtaCteDet.GetDetalle({actual.Sucursal}, _
                                           Desde, Hasta, _
                                           idProveedor, _
                                           IdTipoComprobante, _
                                           TipoSaldo, _
                                           Vencimiento, _
                                           IdCategoria,
                                           "TODOS")
         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdProveedor") = Long.Parse(dr("IdProveedor").ToString())
            drCl("CodigoProveedor") = Long.Parse(dr("CodigoProveedor").ToString())
            drCl("NombreProveedor") = dr("NombreProveedor").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("CuotaNumero") = Integer.Parse(dr("CuotaNumero").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())

            If DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()), Date.Today) > 0 And Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then
               drCl("DiasVencido") = DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()), Date.Today)
               TotalVencido += Decimal.Parse(dr("SaldoCuota").ToString())
            End If

            drCl("ImporteCuota") = Decimal.Parse(dr("ImporteCuota").ToString())
            drCl("SaldoCuota") = Decimal.Parse(dr("SaldoCuota").ToString())

            'If dr.Cells("IdTipoComprobante").Value.ToString() = "PAGO" Then
            '   dr.Cells("FechaVencimiento").Value = dr.Cells("Fecha").Value
            'End If

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
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("IdProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("CuotaNumero", System.Type.GetType("System.Int32"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("DiasVencido", System.Type.GetType("System.Int32"))
         .Columns.Add("ImporteCuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("SaldoCuota", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

#End Region

End Class