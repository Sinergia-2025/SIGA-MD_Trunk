Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class InfKilosCompMarcasPorCliente

#Region "Campos"

   Private _publicos As Publicos
   Private _periodos As Long

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca1)
         Me._publicos.CargaComboMarcas(Me.cmbMarca2)
         Me._publicos.CargaComboMarcas(Me.cmbMarca3)
         Me._publicos.CargaComboMarcas(Me.cmbMarca4)
         Me._publicos.CargaComboMarcas(Me.cmbMarca5)
         Me._publicos.CargaComboRubros(Me.cmbRubro)

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)

         '-.PE-31810.-
         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal
         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfKilosCompMensualPorCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

      If Me.dgvDetalle.RowCount = 0 Then Exit Sub

      Try

         Dim Filtros As String

         Dim IdVendedor As Integer

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         Filtros = Filtros & " / Marca 1: " & Me.cmbMarca1.Text
         Filtros = Filtros & " / Marca 2: " & Me.cmbMarca2.Text

         If Me.chbMarca3.Checked Then
            Filtros = Filtros & " / Marca 3: " & Me.cmbMarca3.Text
         End If

         If Me.chbMarca4.Checked Then
            Filtros = Filtros & " / Marca 4: " & Me.cmbMarca4.Text
         End If

         If Me.chbMarca5.Checked Then
            Filtros = Filtros & " / Marca 5: " & Me.cmbMarca5.Text
         End If

         If Me.chbRubro.Checked Then
            Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         End If

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

            Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = Filtros & " / Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            Filtros = Filtros & " / Localidad: " & Me.bscCodigoLocalidad.Text.Trim() & " - " & Me.bscNombreLocalidad.Text.Trim()
         End If

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfKilosCompMarcasPorCliente.rdlc", "DSReportes_InfKilosCompMarcasPorCliente", dt, parm, True, 1) '# 1 = Cantidad Copias
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


   Private Sub chbMarca3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca3.CheckedChanged

      Me.cmbMarca3.Enabled = Me.chbMarca3.Checked

      If Not Me.chbMarca3.Checked Then
         Me.cmbMarca3.SelectedIndex = -1
      Else
         If Me.cmbMarca3.Items.Count > 0 Then
            Me.cmbMarca3.SelectedIndex = 0
         End If
      End If

      Me.cmbMarca3.Focus()

      Me.dgvDetalle.Columns("Marca3").Visible = Me.chbMarca3.Checked
      Me.dgvDetalle.Columns("PorcMarca3").Visible = Me.chbMarca3.Checked

   End Sub

   Private Sub chbMarca4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca4.CheckedChanged

      Me.cmbMarca4.Enabled = Me.chbMarca4.Checked

      If Not Me.chbMarca4.Checked Then
         Me.cmbMarca4.SelectedIndex = -1
      Else
         If Me.cmbMarca4.Items.Count > 0 Then
            Me.cmbMarca4.SelectedIndex = 0
         End If
      End If

      Me.cmbMarca4.Focus()

      Me.dgvDetalle.Columns("Marca4").Visible = Me.chbMarca4.Checked
      Me.dgvDetalle.Columns("PorcMarca4").Visible = Me.chbMarca4.Checked

   End Sub

   Private Sub chbMarca5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca5.CheckedChanged

      Me.cmbMarca5.Enabled = Me.chbMarca5.Checked

      If Not Me.chbMarca5.Checked Then
         Me.cmbMarca5.SelectedIndex = -1
      Else
         If Me.cmbMarca5.Items.Count > 0 Then
            Me.cmbMarca5.SelectedIndex = 0
         End If
      End If

      Me.cmbMarca5.Focus()

      Me.dgvDetalle.Columns("Marca5").Visible = Me.chbMarca5.Checked
      Me.dgvDetalle.Columns("PorcMarca5").Visible = Me.chbMarca5.Checked

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged

      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If

      Me.cmbRubro.Focus()

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

         If Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("ATENCION: El periodo Desde es INVALIDO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         If Me.cmbMarca1.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó la Marca 1.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca1.Focus()
            Exit Sub
         End If

         If Me.cmbMarca2.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó la Marca 2.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca2.Focus()
            Exit Sub
         End If

         If Me.cmbMarca1.SelectedValue.ToString() = Me.cmbMarca2.SelectedValue.ToString() Then
            MessageBox.Show("ATENCION: NO pueden coincidir la Marca 1 y 2.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca2.Focus()
            Exit Sub
         End If

         If Me.chbMarca3.Checked And Me.cmbMarca3.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó la Marca 3 aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca3.Focus()
            Exit Sub
         End If

         If Me.chbMarca3.Checked AndAlso (Me.cmbMarca1.SelectedValue.ToString() = Me.cmbMarca3.SelectedValue.ToString() Or Me.cmbMarca2.SelectedValue.ToString() = Me.cmbMarca3.SelectedValue.ToString()) Then
            MessageBox.Show("ATENCION: NO pueden coincidir la Marca 3 con alguna de las anteriores.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca3.Focus()
            Exit Sub
         End If

         If Me.chbMarca4.Checked And Me.cmbMarca4.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó la Marca 4 aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca4.Focus()
            Exit Sub
         End If

         If Me.chbMarca5.Checked And Me.cmbMarca5.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó la Marca 5 aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca5.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

         If dgvDetalle.Rows.Count > 0 Then
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

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.cmbMarca1.SelectedIndex = -1
      Me.cmbMarca2.SelectedIndex = -1
      Me.chbMarca3.Checked = False
      Me.chbMarca4.Checked = False
      Me.chbMarca5.Checked = False
      Me.chbRubro.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbCliente.Checked = False

      Me.chbLocalidad.Checked = False

      'Limpio la Grilla.
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtTotalKilos.Text = "0.00"

      cmbSucursal.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

         Dim Marca1 As Integer = 0
         Dim Marca2 As Integer = 0
         Dim Marca3 As Integer = 0
         Dim Marca4 As Integer = 0
         Dim Marca5 As Integer = 0
         Dim Rubro As Integer = 0
         Dim IdVendedor As Integer = 0

         Dim IdZonaGeografica As String = String.Empty
         Dim IdCliente As Long = 0

         Dim IdLocalidad As Integer = 0

         Dim decTotalKilos As Decimal = 0

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         Marca1 = Integer.Parse(Me.cmbMarca1.SelectedValue.ToString())
         Marca2 = Integer.Parse(Me.cmbMarca2.SelectedValue.ToString())

         If Me.chbMarca3.Checked Then
            Marca3 = Integer.Parse(Me.cmbMarca3.SelectedValue.ToString())
         End If

         If Me.chbMarca4.Checked Then
            Marca4 = Integer.Parse(Me.cmbMarca4.SelectedValue.ToString())
         End If

         If Me.chbMarca5.Checked Then
            Marca5 = Integer.Parse(Me.cmbMarca5.SelectedValue.ToString())
         End If

         If Me.chbRubro.Checked Then
            Rubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         dtDetalle = oVentas.GetKilosCompMarcasPorCliente(cmbSucursal.GetSucursales(),
                                                          Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                          Marca1,
                                                          Marca2,
                                                          Marca3,
                                                          Marca4,
                                                          Marca5,
                                                          Rubro,
                                                          IdVendedor,
                                                          IdZonaGeografica,
                                                          IdCliente,
                                                          IdLocalidad)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = dr("IdSucursal") '-.PE-31810.-
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()

            drCl("Marca1") = Decimal.Parse(dr("Marca1").ToString())
            drCl("PorcMarca1") = Decimal.Parse(dr("PorcMarca1").ToString())
            drCl("Marca2") = Decimal.Parse(dr("Marca2").ToString())
            drCl("PorcMarca2") = Decimal.Parse(dr("PorcMarca2").ToString())

            If Me.chbMarca3.Checked Then
               drCl("Marca3") = Decimal.Parse(dr("Marca3").ToString())
               drCl("PorcMarca3") = Decimal.Parse(dr("PorcMarca3").ToString())
            End If

            If Me.chbMarca4.Checked Then
               drCl("Marca4") = Decimal.Parse(dr("Marca4").ToString())
               drCl("PorcMarca4") = Decimal.Parse(dr("PorcMarca4").ToString())
            End If

            If Me.chbMarca5.Checked Then
               drCl("Marca5") = Decimal.Parse(dr("Marca5").ToString())
               drCl("PorcMarca5") = Decimal.Parse(dr("PorcMarca5").ToString())
            End If

            drCl("Total") = Decimal.Parse(dr("Total").ToString())
            drCl("Promedio") = Decimal.Parse(dr("Promedio").ToString())

            decTotalKilos = decTotalKilos + Decimal.Parse(dr("Total").ToString())

            dt.Rows.Add(drCl)

         Next

         Me.txtTotalKilos.Text = decTotalKilos.ToString("##,##0.00")

         Me.dgvDetalle.DataSource = dtDetalle

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()

      With Me.dgvDetalle

         For Cont As Long = 1 To 12
            .Columns("Mes" & Cont.ToString()).Visible = (Cont <= Me._periodos)
         Next

      End With

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp

         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32")) '-.PE-31810.-
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("Marca1", System.Type.GetType("System.Decimal"))
         .Columns.Add("PorcMarca1", System.Type.GetType("System.Decimal"))
         .Columns.Add("Marca2", System.Type.GetType("System.Decimal"))
         .Columns.Add("PorcMarca2", System.Type.GetType("System.Decimal"))
         .Columns.Add("Marca3", System.Type.GetType("System.Decimal"))
         .Columns.Add("PorcMarca3", System.Type.GetType("System.Decimal"))
         .Columns.Add("Marca4", System.Type.GetType("System.Decimal"))
         .Columns.Add("PorcMarca4", System.Type.GetType("System.Decimal"))
         .Columns.Add("Marca5", System.Type.GetType("System.Decimal"))
         .Columns.Add("PorcMarca5", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("Promedio", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

#End Region

End Class