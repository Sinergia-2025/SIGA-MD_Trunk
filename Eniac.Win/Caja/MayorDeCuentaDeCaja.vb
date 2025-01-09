Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class MayorDeCuentaDeCaja

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _blnMiraUsuario As Boolean
   Private _blnMiraPC As Boolean
   Private _blnCajasModificables As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         _blnMiraUsuario = True
         _blnMiraPC = False
         _blnCajasModificables = False

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal
         '   Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = False
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         Me.dgvDetalle.Columns("IdSucursal").Visible = Me.cmbSucursal.Enabled

         Dim TodasLasCajas As Integer = New Reglas.CajasNombres().GetAll(actual.Sucursal.IdSucursal).Rows.Count
         If TodasLasCajas <> Me.cmbCajas.Items.Count Then
            Me.chbCaja.Checked = True
            Me.chbCaja.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         'Me.dtpDesde.Value = DateTime.Now
         'Me.dtpHasta.Value = DateTime.Now

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"


   Private Sub MayorDeCuentaDeCaja_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         If Me.dgvDetalle.RowCount = 0 Then
            Exit Sub
         End If

         Dim dt As DataTable
         Dim Filtros As String
         Dim decSaldo As Decimal = 0

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Filtros = "Cuenta: " & Me.bscCuentaCaja.Text & " - " & Me.bscNombreCuentaCaja.Text

         If Me.chbCaja.Checked Then
            Filtros = Filtros & " / Caja: " & Me.cmbCajas.Text
         End If

         Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         Filtros = Filtros & " / Fecha de: " & IIf(Me.rdbFechaMovimiento.Checked, "Movimiento", "Planilla").ToString()

         decSaldo = Decimal.Parse(Me.txtTotalIngresos.Text) + Decimal.Parse(Me.txtTotalEgresos.Text)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", decSaldo.ToString()))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.MayorDeCuentaDeCaja.rdlc", "DataSetCaja_MayorDeCuentaDeCaja", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Mayor de Cuenta de Caja"
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

   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      Try
         'Me._publicos.PreparaGrillaClientes(Me.bscCuentaCaja)

         Me._publicos.PreparaGrillaCuentasDeCajas(Me.bscCuentaCaja)

         Dim oCuentasDeCaja As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas()

         bscCuentaCaja.Datos = oCuentasDeCaja.GetTodas(Me.bscCuentaCaja.Text)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCuentaCaja_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaDeCaja(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      Try
         'Me._publicos.PreparaGrillaClientes(Me.bscNombreCuentaCaja)
         Me._publicos.PreparaGrillaCuentasDeCajas(Me.bscNombreCuentaCaja)

         Dim oCuentasDeCaja As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas()

         bscNombreCuentaCaja.Datos = oCuentasDeCaja.GetPorNombre(Me.bscNombreCuentaCaja.Text)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCuentaCaja.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaDeCaja(e.FilaDevuelta)
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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Not Me.bscCuentaCaja.Selecciono And Not Me.bscNombreCuentaCaja.Selecciono Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar una Cuenta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaCaja.Focus()
            Exit Sub
         End If

         If Me.chbCaja.Checked And Me.cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Caja aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCajas.Focus()
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

   Private Sub CargarDatosCuentaDeCaja(ByVal dr As DataGridViewRow)

      Me.bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
      Me.bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      'Me.bscNombreCuentaCaja.Enabled = False
      'Me.bscCuentaCaja.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.bscCuentaCaja.Text = ""
      Me.bscNombreCuentaCaja.Text = ""

      If Me.chbCaja.Enabled Then
         Me.chbCaja.Checked = False
      End If

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.rdbFechaMovimiento.Checked = True

      'Limpio la Grilla.
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtTotalIngresos.Text = "0.00"
      Me.txtTotalEgresos.Text = "0.00"
      Me.txtSaldo.Text = "0.00"

      cmbSucursal.Refrescar()

      Me.bscCuentaCaja.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles()

      Dim decTotalIngresos As Decimal = 0
      Dim decTotalEgresos As Decimal = 0
      Dim decSaldo As Decimal = 0

      Dim IdCuentaDeCaja As Integer = 0
      Dim IdCaja As Integer = 0

      Try

         IdCuentaDeCaja = Integer.Parse(Me.bscCuentaCaja.Text)

         If Me.cmbCajas.Enabled Then
            IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
         End If

         Me.dgvDetalle.DataSource = oCajaDet.MayorDeCuentaDeCaja(cmbSucursal.GetSucursales(), _
                                                                 IdCaja, _
                                                                 IdCuentaDeCaja, _
                                                                 Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                                                 Me.rdbFechaMovimiento.Checked)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            decTotalIngresos = decTotalIngresos + Decimal.Parse(dr.Cells("Ingreso").Value.ToString())
            decTotalEgresos = decTotalEgresos + Decimal.Parse(dr.Cells("Egreso").Value.ToString())

         Next

         decSaldo = decTotalIngresos + decTotalEgresos

         txtTotalIngresos.Text = decTotalIngresos.ToString("#,##0.00")
         txtTotalEgresos.Text = decTotalEgresos.ToString("#,##0.00")
         txtSaldo.Text = decSaldo.ToString("#,##0.00")

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      Try
         Me._publicos.CargaComboCajas(Me.cmbCajas, cmbSucursal.GetSucursales(), _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajas.SelectedIndex = -1
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class