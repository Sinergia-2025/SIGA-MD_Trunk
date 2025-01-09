Public Class EstadisticaDeVentasProductos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         _publicos = New Publicos()

         CargarSucursales()

         dtpDesde.Value = Date.Now
         dtpHasta.Value = Date.Now
         '-- REQ-35031.- ------------------------------
         cmbVendedor.Inicializar(False, True, True)
         cmbRubro.Inicializar(False, True, True)
         cmbMarca.Inicializar(False, True, True)

         If Reglas.Publicos.ProductoTieneSubRubro Then
            cmbSubRubro.SelectedIndex = -1
            lblSubRubro.Visible = True
            cmbSubRubro.Visible = True
         End If
         '---------------------------------------------
         _publicos.CargaComboModelos(Me.cmbModelo)

         If Not Publicos.ProductoTieneModelo Then
            chbModelo.Visible = False
            cmbModelo.Visible = False
         End If

         AgregarFiltroEnLinea(ugDetalle, {"NombreProducto", "IdProducto"})
         ugDetalle.AgregarTotalesSuma({"Cantidad", "Importe"})

         'Hay que colocarlo luego del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.chbMesCompleto.Checked = False
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now

         Me.txtCantidad.Text = "10"
         Me.chbModelo.Checked = False
         Me.chbCliente.Checked = False

         For i As Integer = 1 To Me.clbSucursales.Items.Count - 1
            Me.clbSucursales.SetItemCheckState(i, CheckState.Unchecked)
         Next

         Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)

         If Not Me.ugDetalle.DataSource Is Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
         End If
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim Filtro1 As String = String.Empty
         Dim Filtro2 As String = String.Empty

         Filtro1 += "Los " + Me.txtCantidad.Text + " Productos mas Vendidos "
         Filtro1 += "desde el " + Me.dtpDesde.Value.ToString("dd/MM/yyyy")
         Filtro1 += " hasta el " + Me.dtpHasta.Value.ToString("dd/MM/yyyy")

         If Me.clbSucursales.Items.Count > 1 Then
            Dim Sucursales As String = String.Empty
            For Each ite As Object In Me.clbSucursales.CheckedItems
               Sucursales += DirectCast(ite, Entidades.Sucursal).Nombre & " - "
            Next
            If Sucursales.Length > 0 Then Sucursales = Sucursales.Substring(0, Sucursales.Length - 3)
            Filtro2 = "Sucursal/es: " & Sucursales
         End If

         If Me.chbModelo.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "Modelo: " & Me.cmbModelo.Text
         End If

         'If Me.chbMarca.Checked Then
         '   If Filtro2.Length > 0 Then Filtro2 += " / "
         '   Filtro2 += "Marca: " & Me.cmbMarca.Text
         'End If
         'If Me.chbRubro.Checked Then
         '   cmbRubro.CargarFiltrosImpresionRubros(Filtro2, False, True)
         '   If Filtro2.Length > 0 Then Filtro2 += " / "
         '   Filtro2 += "Rubro: " & Me.cmbRubro.Text
         'End If
         'If Me.chbSubRubro.Checked Then
         '   If Filtro2.Length > 0 Then Filtro2 += " / "
         '   Filtro2 += "SubRubro: " & Me.cmbSubRubro.Text
         'End If
         'If Me.chbVendedor.Checked Then
         '   If Filtro2.Length > 0 Then Filtro2 += " / "
         '   Filtro2 += "Vendedor: " & Me.cmbVendedor1.Text
         'End If

         If Me.chbCliente.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
         End If


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtro", Filtro1))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtro1", Filtro2))

         Dim dt As DataTable
         '   dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)
         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Me.Cursor = Cursors.Default

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.EstadisticaDeVentasProductos.rdlc", "SistemaDataSet_EVentasProductos", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         dtpDesde.Enabled = Not chbMesCompleto.Checked
         dtpHasta.Enabled = Not chbMesCompleto.Checked

      Catch ex As Exception

         Me.chbMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbModelo_CheckedChanged(sender As Object, e As EventArgs) Handles chbModelo.CheckedChanged
      Try
         cmbModelo.Enabled = chbModelo.Checked
         If Not chbModelo.Checked Then
            cmbModelo.SelectedIndex = -1
         Else
            If cmbModelo.Items.Count > 0 Then
               cmbModelo.SelectedIndex = 0
            End If
         End If
         cmbModelo.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         Dim suc As List(Of Integer) = New List(Of Integer)
         For Each ite As Object In Me.clbSucursales.CheckedItems
            suc.Add(DirectCast(ite, Entidades.Sucursal).Id)
         Next

         Me.Cursor = Cursors.WaitCursor
         If Me.ValidanDatos() Then
            Me.CargaGrillaDetalle(suc)

            If ugDetalle.Rows.Count > 0 Then
               Me.btnConsultar.Focus()
            Else
               Me.Cursor = Cursors.Default
               MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

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

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
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

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EstadisticaDeVentasProductos_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
         Case Else
      End Select
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Métodos"

   Private Sub CargarSucursales()

      Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

      For Each suc As Entidades.Sucursal In lis
         Me.clbSucursales.Items.Add(suc)
         'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
         If suc.Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)
         End If
      Next
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
   End Sub

   Private Function ValidanDatos() As Boolean

      If Me.dtpDesde.Value > Me.dtpHasta.Value Then
         MessageBox.Show("La fecha desde no puede ser mayor que la fecha hasta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpDesde.Focus()
         Return False
      End If

      If Me.chbCliente.Checked Then

         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("Activó el filtro de Cliente, debe elegir uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCliente.Focus()
            Return False
         End If

      End If

      Return True

   End Function

   Public Sub CargaGrillaDetalle(suc As List(Of Integer))

      Dim cantidad As Integer = 0
      Dim idModelo As Integer = 0
      Dim IdCliente As Long = 0

      Try
         cantidad = Integer.Parse(Me.txtCantidad.Text)

         If Me.cmbModelo.Enabled Then
            idModelo = Int32.Parse(Me.cmbModelo.SelectedValue.ToString())
         End If
         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim reg As Reglas.VentasProductos = New Reglas.VentasProductos()
         Dim dt As DataTable = reg.GetEstadVentasProductos(suc, cantidad, Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                           If(cmbRubro.SelectedIndex > -1, cmbRubro.GetRubros(True), Nothing),
                                                           If(cmbSubRubro.SelectedIndex > -1, cmbSubRubro.GetSubRubros(True), Nothing),
                                                           If(cmbMarca.SelectedIndex > -1, cmbMarca.GetMarcas(True), Nothing),
                                                           idModelo, IdCliente,
                                                           If(cmbVendedor.SelectedIndex > -1, cmbVendedor.GetEmpleados(True), Nothing))

         Me.ugDetalle.DataSource = dt

         Dim TotalCantidad As Decimal = 0
         Dim TotalImporte As Decimal = 0

         For Each dr As DataRow In dt.Rows
            TotalCantidad += Decimal.Parse(dr("Cantidad").ToString())
            TotalImporte += Decimal.Parse(dr("Importe").ToString())
         Next

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         '# Actualizo los SubRubros segun el Rubro seleccionado
         If Me.cmbRubro.DataSource IsNot Nothing Then
            Me.cmbSubRubro.Inicializar(False, True, True, Me.cmbRubro.GetRubros())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region


End Class