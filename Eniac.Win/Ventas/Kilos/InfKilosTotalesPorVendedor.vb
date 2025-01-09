Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class InfKilosTotalesPorVendedor

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Dim arrKilos As ArrayList = New ArrayList
         arrKilos.Insert(0, "TODOS")
         arrKilos.Insert(1, "CON KILOS")
         arrKilos.Insert(2, "SIN KILOS")
         Me.cboKilos.DataSource = arrKilos

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      'PE-31377
      Me.cmbSucursal.Initializar(False, IdFuncion)
      Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal


   End Sub

#End Region

#Region "Eventos"

   Private Sub InfTotalVentasPorVendedor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Dim IdVendedor As Integer

         Dim Filtros As String

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If chbMesCompleto.Checked Then
            Filtros = "Periodo: " & Me.dtpDesde.Value.ToString("MMMMM") & " " & Me.dtpHasta.Value.ToString("yyyy")
         End If

         Filtros = Filtros & " / Kilos: " & Me.cboKilos.Text

         If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

            Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = Filtros & "  / Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            Filtros = Filtros & " / Localidad: " & Me.bscCodigoLocalidad.Text.Trim() & " - " & Me.bscNombreLocalidad.Text.Trim()
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfKilosTotalesPorVendedor.rdlc", "SistemaDataSet_InfKilosTotalesPorVendedor", dt, parm, True, 1) '# 1 = Cantidad Copias

         'Porque en la impresion sale la barra Horizonzal?? en algun lado quedo apaisada ??
         frmImprime.Text = Me.Text
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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception

         chbMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Permitido = Me.chbCliente.Checked
      Me.bscCodigoCliente.Permitido = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty
      Else
         Me.bscCodigoCliente.Focus()
      End If

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
      End If

      Me.cmbVendedor.Focus()

   End Sub

   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged

      Me.bscCodigoLocalidad.Permitido = Me.chbLocalidad.Checked
      Me.bscNombreLocalidad.Permitido = Me.chbLocalidad.Checked

      Me.bscCodigoLocalidad.Text = String.Empty
      Me.bscNombreLocalidad.Text = String.Empty

      Me.bscCodigoLocalidad.Focus()

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un CLIENTE aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbLocalidad.Checked And Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una LOCALIDAD aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)

      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscCodigoLocalidad.Permitido = False
      Me.bscNombreLocalidad.Permitido = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.cboKilos.SelectedIndex = 0

      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me.chbLocalidad.Checked = False

      'Limpio la Grilla.
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtTotal.Text = "0.00"
      Me.txtTotalKilos.Text = "0.00"

      Me.dtpDesde.Focus()

      'PE-31377
      cmbSucursal.Refrescar()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim TipoKilos As String = String.Empty

      Dim IdCliente As Long = 0

      Dim IdVendedor As Integer = 0

      Dim IdZonaGeografica As String = String.Empty

      Dim IdLocalidad As Integer = 0

      Dim Total As Decimal = 0
      Dim Kilos As Decimal = 0

      Dim TotalesPorSucursal As Boolean = False

      Try

         TipoKilos = Me.cboKilos.Text

         If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         'PE-31377
         If Me.chbTotalesPorSucursal.Checked Then
            TotalesPorSucursal = True
         End If

         Me.dgvDetalle.DataSource = oVentas.GetKilosTotalesPorVendedor(cmbSucursal.GetSucursales(),
                                                                       Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                                       TipoKilos,
                                                                       IdVendedor,
                                                                       IdCliente,
                                                                       IdZonaGeografica,
                                                                       IdLocalidad,
                                                                       TotalesPorSucursal)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            Total += Decimal.Parse(dr.Cells("Total").Value.ToString())
            Kilos += Decimal.Parse(dr.Cells("Kilos").Value.ToString())
         Next

         Me.txtTotal.Text = Total.ToString("##,##0.00")
         Me.txtTotalKilos.Text = Kilos.ToString("##,##0.00")

         'PE-31377
         Dim sucursales As Entidades.Sucursal() = cmbSucursal.GetSucursales()
         If sucursales.Length > 1 Then
            If TotalesPorSucursal Then
               dgvDetalle.Columns("IdSucursal").Visible = True
            Else
               dgvDetalle.Columns("IdSucursal").Visible = False
            End If
         Else
            dgvDetalle.Columns("IdSucursal").Visible = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   'PE-31377
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      Dim sucursales As Entidades.Sucursal() = cmbSucursal.GetSucursales()

      If sucursales.Length > 1 Then
         Me.chbTotalesPorSucursal.Enabled = True
      Else
         Me.chbTotalesPorSucursal.Enabled = False
         Me.chbTotalesPorSucursal.Checked = False
      End If
   End Sub

#End Region

End Class