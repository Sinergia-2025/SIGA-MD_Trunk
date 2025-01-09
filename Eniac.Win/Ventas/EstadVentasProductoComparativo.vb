Imports actual = Eniac.Entidades.Usuario.Actual

Public Class EstadVentasProductoComparativo

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Now.AddDays(-90)
         Me.dtpHasta.Value = Date.Now

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboModelos(Me.cmbModelo)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Publicos.ProductoTieneModelo Then
            Me.chbModelo.Visible = False
            Me.cmbModelo.Visible = False
         End If

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now

         Me.txtCantidad.Text = "10"

         Me.chbRubro.Checked = False
         Me.chbSubRubro.Checked = False
         Me.chbMarca.Checked = False
         Me.chbModelo.Checked = False
         If Not Me.dgvDetalle.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim filtro As String = String.Empty
         Dim filtro1 As String = String.Empty

         filtro += "Los " + Me.txtCantidad.Text + " Productos mas Vendidos "
         filtro += "desde el " + Me.dtpDesde.Value.ToString("dd/MM/yyyy")
         filtro += " hasta el " + Me.dtpHasta.Value.ToString("dd/MM/yyyy")


         If Me.chbRubro.Checked Then
            If filtro1.Length > 0 Then filtro1 = filtro1 & " ** "
            filtro1 = filtro1 & "Rubro: " & Me.cmbRubro.Text
         End If
         If Me.chbSubRubro.Checked Then
            If filtro1.Length > 0 Then filtro1 = filtro1 & " ** "
            filtro1 = filtro1 & "SubRubro: " & Me.cmbSubRubro.Text
         End If
         If Me.chbMarca.Checked Then
            If filtro1.Length > 0 Then filtro1 = filtro1 & " ** "
            filtro1 = filtro1 & "Marca: " & Me.cmbMarca.Text
         End If
         If Me.chbModelo.Checked Then
            If filtro1.Length > 0 Then filtro1 = filtro1 & " ** "
            filtro1 = filtro1 & "Modelo: " & Me.cmbModelo.Text
         End If
         If Me.chbCliente.Checked Then
            If filtro1.Length > 0 Then filtro1 = filtro1 & " ** "
            filtro1 = filtro1 & "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtro", filtro))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtro1", filtro1))

         Dim dt As DataTable
         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Me.Cursor = Cursors.Default

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.EstadisticaVentasProductos.rdlc", "SistemaDataSet_EVentasProductos", dt, parm, True, 1) '# 1 = Cantidad Copias
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

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Try
         Me.cmbMarca.Enabled = Me.chbMarca.Checked

         If Not Me.chbMarca.Checked Then
            Me.cmbMarca.SelectedIndex = -1
         Else
            If Me.cmbMarca.Items.Count > 0 Then
               Me.cmbMarca.SelectedIndex = 0
            End If
         End If

         Me.cmbMarca.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbModelo.CheckedChanged
      Try
         Me.cmbModelo.Enabled = Me.chbModelo.Checked

         If Not Me.chbModelo.Checked Then
            Me.cmbModelo.SelectedIndex = -1
         Else
            If Me.cmbModelo.Items.Count > 0 Then
               Me.cmbModelo.SelectedIndex = 0
            End If
         End If

         Me.cmbModelo.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Try
         Me.cmbRubro.Enabled = Me.chbRubro.Checked

         If Not Me.chbRubro.Checked Then
            Me.cmbRubro.SelectedIndex = -1
         Else
            If Me.cmbRubro.Items.Count > 0 Then
               Me.cmbRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbRubro.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
      Me.dtpDesde.Value = Me.dtpHasta.Value.AddDays(-90)
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         Me.Cursor = Cursors.WaitCursor
         If Me.ValidanDatos() Then
            Me.CargaGrillaDetalle()

            If dgvDetalle.Rows.Count > 0 Then
               Me.btnConsultar.Focus()
            Else
               Me.Cursor = Cursors.Default
               MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

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

#End Region

#Region "Métodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
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

   Public Sub CargaGrillaDetalle()

      Dim cantidad As Integer = 0
      Dim idRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim idMarca As Integer = 0
      Dim idModelo As Integer = 0

      Dim IdCliente As Long = 0

      Try
         cantidad = Integer.Parse(Me.txtCantidad.Text)

         If Me.cmbRubro.Enabled Then
            idRubro = Int32.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If
         If Me.cmbSubRubro.Enabled Then
            idSubRubro = Int32.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If
         If Me.cmbMarca.Enabled Then
            idMarca = Int32.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If
         If Me.cmbModelo.Enabled Then
            idModelo = Int32.Parse(Me.cmbModelo.SelectedValue.ToString())
         End If
         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim reg As Reglas.VentasProductos = New Reglas.VentasProductos()
         'Dim dt As DataTable = reg.GetEstadVentasProductos(cantidad, Me.dtpDesde.Value, Me.dtpHasta.Value, idRubro, idSubRubro, idMarca, idModelo, TipoDocCliente, NroDocCliente)

         '         Me.dgvDetalle.DataSource = dt

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region


End Class