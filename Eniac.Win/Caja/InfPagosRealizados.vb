Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class InfPagosRealizados

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)
         Me.cmbComprador.SelectedIndex = -1

         Me.cmbComercial.Items.Insert(0, "TODOS")
         Me.cmbComercial.Items.Insert(1, "SI")
         Me.cmbComercial.Items.Insert(2, "NO")
         Me.cmbComercial.SelectedIndex = 0


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfCobranzasRealizadas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim dtCC As DataTable

         Me.Cursor = Cursors.WaitCursor

         Filtros = " Fechas: desde " & dtpDesde.Text & " hasta " & dtpHasta.Text

         If Filtros.Length > 0 Then Filtros = Filtros & " - "
         If Me.optCompradorProveedor.Checked Then
            Filtros = Filtros & "Comprador: Proveedor"
         Else
            Filtros = Filtros & "Comprador: Movimiento"
         End If

         If Me.cmbComprador.SelectedIndex >= 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = "Comprador: " & Me.cmbComprador.Text
         End If

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Proveedor: " & Me.bscCodigoProveedor.Text & " - " & Me.bscProveedor.Text
         End If

         'dtV = DirectCast(Me.dgvVentas.DataSource, DataTable)
         dtCC = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalContadoNeto", Me.txtTotalContadoNeto.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalContadoFinal", Me.txtTotalContadoFinal.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalCtaCteNeto", Me.txtTotalCtaCteNeto.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalCtaCteFinal", Me.txtTotalCtaCteFinal.Text))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.Win.InfPagosRealizados.rdlc", "DSReportes_InfPagosRealizados", dtCC, parm, True, 1) '# 1 = Cantidad Copias

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillasDetalle()

         If Me.dgvDetalle.Rows.Count > 0 Then
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

   Private Sub chbComprador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbComprador.CheckedChanged

      Me.cmbComprador.Enabled = Me.chbComprador.Checked

      If Not Me.chbComprador.Checked Then
         Me.cmbComprador.SelectedIndex = -1
      Else
         If Me.cmbComprador.Items.Count > 0 Then
            Me.cmbComprador.SelectedIndex = 0
         End If

         Me.cmbComprador.Focus()

      End If

   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked

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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.optCompradorProveedor.Checked = True
      Me.chbComprador.Checked = False
      Me.chbProveedor.Checked = False
      Me.cmbComercial.SelectedIndex = 0

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtTotalContadoNeto.Text = "0.00"
      Me.txtTotalContadoFinal.Text = "0.00"
      Me.txtTotalCtaCteNeto.Text = "0.00"
      Me.txtTotalCtaCteFinal.Text = "0.00"
      Me.txtTotalGeneralNeto.Text = "0.00"
      Me.txtTotalGeneralFinal.Text = "0.00"

   End Sub

   Private Sub CargaGrillasDetalle()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()
      Dim oCaja As Reglas.Cajas = New Reglas.Cajas()

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Dim TotalContadoNeto As Decimal = 0
      Dim TotalContadoFinal As Decimal = 0
      Dim TotalCtaCteNeto As Decimal = 0
      Dim TotalCtaCteFinal As Decimal = 0
      Dim ImporteNeto As Decimal = 0
      Dim CoeficienteIVA As Decimal = Publicos.ProductoIVA

      Dim IdComprador As Integer = 0

      Dim IdProveedor As Long = 0

      Dim QueComprador As String = String.Empty

      Try

         Desde = Me.dtpDesde.Value
         Hasta = Me.dtpHasta.Value

         QueComprador = IIf(Me.optCompradorMovim.Checked, "MOVIMIENTO", "Proveedor").ToString()

         If Me.cmbComprador.Enabled Then
            IdComprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.bscCodigoProveedor.Text.Length > 0 Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         Dim dtDetalleCC As DataTable, dtCC As DataTable, drClCC As DataRow

         dtDetalleCC = oCaja.GetPagosDetallados(actual.Sucursal.Id, _
                                                Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                                Me.cmbComercial.Text, _
                                                IdComprador,
                                                IdProveedor)

         'QueComprador, _

         dtCC = Me.CrearDT()

         For Each dr As DataRow In dtDetalleCC.Rows

            drClCC = dtCC.NewRow()

            drClCC("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())

            'If QueComprador = "MOVIMIENTO" Then
            'drClCC("TipoDocComprador") = dr("TipoDocComprador").ToString()
            'drClCC("NroDocComprador") = dr("NroDocComprador").ToString()
            If Not String.IsNullOrEmpty(dr("IdComprador").ToString()) Then
               drClCC("IdComprador") = Integer.Parse(dr("IdComprador").ToString())
               drClCC("NombreComprador") = dr("NombreComprador").ToString()
            End If

            'Else
            '   drClCC("TipoDocComprador") = dr("TipoDocCompradorProv").ToString()
            '   drClCC("NroDocComprador") = dr("NroDocCompradorProv").ToString()
            '   drClCC("NombreComprador") = dr("NombreCompradorProv").ToString()
            'End If

            drClCC("Fecha") = Date.Parse(dr("Fecha").ToString())
            drClCC("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drClCC("Letra") = dr("Letra").ToString()
            drClCC("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drClCC("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())

            drClCC("IdProveedor") = Long.Parse(dr("IdProveedor").ToString())
            drClCC("CodigoProveedor") = Long.Parse(dr("CodigoProveedor").ToString())
            drClCC("NombreProveedor") = dr("NombreProveedor").ToString()

            If Not String.IsNullOrEmpty(dr("ImporteNeto").ToString()) Then
               ImporteNeto = Decimal.Parse(dr("ImporteNeto").ToString())
            Else
               ImporteNeto = Decimal.Round(Decimal.Parse(dr("ImporteTotal").ToString()) / (1 + CoeficienteIVA / 100), 2)   'Normalmente el 21
            End If

            drClCC("ImporteNeto") = ImporteNeto

            If dr("TipoCobro").ToString() = "COMPRA" Then
               TotalContadoNeto = TotalContadoNeto + ImporteNeto
            Else
               TotalCtaCteNeto = TotalCtaCteNeto + ImporteNeto
            End If

            drClCC("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            If dr("TipoCobro").ToString() = "COMPRA" Then

               TotalContadoFinal = TotalContadoFinal + Decimal.Parse(dr("ImporteTotal").ToString())

            Else

               drClCC("IdTipoComprobante2") = dr("IdTipoComprobante2").ToString()
               drClCC("Letra2") = dr("Letra2").ToString()
               drClCC("CentroEmisor2") = Integer.Parse(dr("CentroEmisor2").ToString())
               drClCC("NumeroComprobante2") = Long.Parse(dr("NumeroComprobante2").ToString())
               drClCC("CuotaNumero2") = Integer.Parse(dr("CuotaNumero2").ToString())

               If Not String.IsNullOrEmpty(dr("Fecha2").ToString()) Then
                  drClCC("Fecha2") = Date.Parse(dr("Fecha2").ToString())
               End If

               If Not String.IsNullOrEmpty(dr("DiasPago").ToString()) Then
                  drClCC("DiasPago") = Integer.Parse(dr("DiasPago").ToString())
               End If

               TotalCtaCteFinal = TotalCtaCteFinal + Decimal.Parse(drClCC("ImporteTotal").ToString())

            End If


            dtCC.Rows.Add(drClCC)

         Next

         Me.txtTotalContadoNeto.Text = TotalContadoNeto.ToString("#,##0.00")
         Me.txtTotalContadoFinal.Text = TotalContadoFinal.ToString("#,##0.00")
         Me.txtTotalCtaCteNeto.Text = TotalCtaCteNeto.ToString("#,##0.00")
         Me.txtTotalCtaCteFinal.Text = TotalCtaCteFinal.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dtCC

         Me.txtTotalGeneralNeto.Text = (TotalContadoNeto + TotalCtaCteNeto).ToString("#,##0.00")
         Me.txtTotalGeneralFinal.Text = (TotalContadoFinal + TotalCtaCteFinal).ToString("#,##0.00")

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
         '.Columns.Add("TipoDocComprador", System.Type.GetType("System.String"))
         '.Columns.Add("NroDocComprador", System.Type.GetType("System.String"))
         .Columns.Add("IdComprador", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreComprador", System.Type.GetType("System.String"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("ImporteNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdTipoComprobante2", System.Type.GetType("System.String"))
         .Columns.Add("Letra2", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor2", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante2", System.Type.GetType("System.Int64"))
         .Columns.Add("CuotaNumero2", System.Type.GetType("System.Int32"))
         .Columns.Add("Fecha2", System.Type.GetType("System.DateTime"))
         .Columns.Add("DiasPago", System.Type.GetType("System.Int32"))
      End With

      Return dtTemp

   End Function

#End Region

End Class