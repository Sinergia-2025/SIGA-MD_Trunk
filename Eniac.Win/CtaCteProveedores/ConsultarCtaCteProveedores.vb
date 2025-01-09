Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarCtaCteProveedores

#Region "Campos"

   Private _publicos As Publicos
   Private _mailProveedor As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Me.dtpDesde.Value = DateTime.Now
         'Me.dtpHasta.Value = DateTime.Now

         Me._publicos.CargaComboCategoriasProveedores(Me.cmbCategoria)

         Me._publicos.CargaComboTiposComprobantesCtaCteProveedores(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1

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

   Private Sub ConsultarCtaCteProveedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            Filtros = "Proveedor: " & Me.bscCodigoProveedor.Text & " - " & Me.bscProveedor.Text
         End If

         If Me.chkFechas.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Fechas: desde " & dtpDesde.Text & " hasta " & dtpHasta.Text
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Comprobante: " & Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         '0 Es TODOS
         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Filtros.Length > 0 Then Filtros = Filtros & " - "
         If Me.optConSaldo.Checked Then
            Filtros = Filtros & "Comprobantes con Saldo Pend."
         Else
            Filtros = Filtros & "Comprobantes con y sin Saldo Pend."
         End If

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("OcultarSaldo", Me.chkFechas.Checked.ToString()))

         Dim frmImprime As VisorReportes

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteProveedores.rdlc", "SistemaDataSet_CuentasCorrientesProv", dt, parm, True, 1) '# 1 = Cantidad Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteProveedoresPorProveedor.rdlc", "SistemaDataSet_CuentasCorrientesProv", dt, parm, True, 1) '# 1 = Cantidad Copias
         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         If Me.chbProveedor.Checked Then
            If Not String.IsNullOrEmpty(Me._mailProveedor) Then
               frmImprime.Destinatarios = Me._mailProveedor
            End If
         End If
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

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      Try

         'Pregunto distinto porque el boton Ver se me cambia de Posicion de 0 a 1, ni idea...
         If e.RowIndex <> -1 AndAlso Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "..." Then

            'If e.ColumnIndex = 0 And e.RowIndex <> -1 Then

            Try

               Me.Cursor = Cursors.WaitCursor

               Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
               oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString())

               If oTipoComprobante.EsRecibo = True Then

                  ' If Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString() = "PAGO" Or Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString() = "PAGOPROV" Then

                  Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
                  Dim ctacte As Entidades.CuentaCorrienteProv = reg.GetUna(actual.Sucursal.Id, _
                                 Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()), _
                                Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                                Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                                Int32.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                                Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))
                  Dim imp As PagosImprimir = New PagosImprimir()
                  imp.ImprimirPago(ctacte, True)

               Else

                  Dim oCompras As Reglas.Compras = New Reglas.Compras()
                  Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()))

                  Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

                  oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)

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

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      Me._mailProveedor = dr.Cells("CorreoElectronico").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbProveedor.Checked = False
      Me.chkFechas.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.optConSaldo.Checked = True

      'Limpio la Grilla.
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtTotal.Text = "0.00"
      Me.txtSaldo.Text = "0.00"

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteProv As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()

      Dim decTotal As Decimal = 0
      Dim decSaldo As Decimal = 0
      Dim decSaldoProveedor As Decimal = 0

      Dim idProveedor As Long = 0

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Dim IdTipoComprobante As String = String.Empty

      Dim TipoSaldo As String = String.Empty

      Dim IdCategoria As Integer = 0

      Try

         'Deberia Calcularse, el valor que muestra es con el saldo a lo actual y no a la fecha filtrada
         'Me.dgvDetalle.Columns("Saldo").Visible = Not Me.chkFechas.Checked

         If Me.chkFechas.Checked Then
            Me.optTodos.Checked = True
         End If

         Me.txtTotal.Visible = Not Me.chkFechas.Checked

         If Me.txtTotal.Visible And Not Me.optTodos.Checked Then
            Me.txtTotal.Visible = False
         End If

         '---------------------------------------------------------------------------------------------

         If Me.bscCodigoProveedor.Tag IsNot Nothing Then
            idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
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

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oCtaCteProv.GetDetalle(actual.Sucursal.Id, _
                                            Desde, Hasta, _
                                            idProveedor, _
                                            IdTipoComprobante, _
                                            TipoSaldo, _
                                            IdCategoria, _
                                            Me.cmbGrabanLibro.Text)

         'For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

         '   dr.Cells("Ver").Value = "..."

         '   If dr.Cells("ImporteTotal").Value IsNot System.DBNull.Value Then
         '      decTotal = decTotal + Decimal.Parse(dr.Cells("ImporteTotal").Value.ToString())
         '   End If
         '   If dr.Cells("Saldo").Value IsNot System.DBNull.Value Then
         '      decSaldo = decSaldo + Decimal.Parse(dr.Cells("Saldo").Value.ToString())
         '   End If

         'Next

         ''Le paso el total porque el otro esta oculto. Debe mostrar el Monto total no el saldo.
         'If Me.chkFechas.Checked Then
         '   decSaldo = decTotal
         'End If

         'Me.txtTotal.Text = decTotal.ToString("#,##0.00")
         'Me.txtSaldo.Text = decSaldo.ToString("#,##0.00")

         'If Me.dgvDetalle.Rows.Count = 1 Then
         '   Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registro"
         'Else
         '   Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"
         'End If

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            If Long.Parse(dr("IdProveedor").ToString()) <> idProveedor Then
               idProveedor = Long.Parse(dr("IdProveedor").ToString())
               decSaldoProveedor = 0
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
            drCl("IdProveedor") = Long.Parse(dr("IdProveedor").ToString())
            drCl("CodigoProveedor") = Long.Parse(dr("CodigoProveedor").ToString())
            drCl("NombreProveedor") = dr("NombreProveedor").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            If Not Me.chkFechas.Checked Then
               drCl("Saldo") = Decimal.Parse(dr("Saldo").ToString())
               decSaldo = decSaldo + Decimal.Parse(dr("Saldo").ToString())
            Else
               decSaldoProveedor += Decimal.Parse(dr("ImporteTotal").ToString())
               drCl("Saldo") = decSaldoProveedor
               decSaldo += Decimal.Parse(dr("ImporteTotal").ToString())
            End If

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
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("IdProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         '.Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Saldo", System.Type.GetType("System.Decimal"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

#End Region

End Class