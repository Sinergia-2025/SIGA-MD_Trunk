Imports actual = Eniac.Entidades.Usuario.Actual

Public Class InfDetalleVentasPorVendedor

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me.cmbConComision.Items.Insert(0, "TODOS")
         Me.cmbConComision.Items.Insert(1, "SI")
         Me.cmbConComision.Items.Insert(2, "NO")
         Me.cmbConComision.SelectedIndex = 1       'SI

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         Me.cmbMarca.ValueMember = "IdMarca"
         Me.cmbMarca.DisplayMember = "NombreMarca"

         Me.cmbMarca.DataSource = oMarca.GetAll()
         Me.cmbMarca.SelectedIndex = -1

         Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         Me.cmbRubro.ValueMember = "IdRubro"
         Me.cmbRubro.DisplayMember = "NombreRubro"

         Me.cmbRubro.DataSource = oRubro.GetAll()
         Me.cmbRubro.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

            If Me.chbProducto.Checked And Me.bscCodigoProducto2.Text.Length = 0 Then
                MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoProducto2.Focus()
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            CargaGrillaDetalle()

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

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
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

         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

         Filtros = "Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text

            Filtros = Filtros & " / Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

         Filtros = Filtros & " / Con Comision: " & Me.cmbConComision.Text

            If Me.bscCodigoCliente.Text.Length > 0 Then
                Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
            End If

            If Me.chbMarca.Checked Then
                Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
            End If

            If Me.chbRubro.Checked Then
                Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
            End If

            If Me.chbSubRubro.Checked Then
                Filtros = Filtros & " / SubRubro: " & Me.cmbSubRubro.Text
            End If

            If Me.chbProducto.Checked Then
                Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
            End If

            If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
                Filtros = Filtros & " / Zona Geografica: " & Me.cmbZonaGeografica.Text
            End If

         Filtros = Filtros & " / Incluye IVA: " & IIf(Me.chbConIVA.Checked, "SI", "NO").ToString()

            Dim dt As DataTable

            dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfDetalleVentasPorVendedor.rdlc", "dsVentas_InfDetalleVentasPorVendedor", dt, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Me.Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
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

    Private Sub chbMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

        Dim FechaTemp As Date

        Try

            If Me.chbMesCompleto.Checked Then

                FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
                Me.dtpDesde.Value = FechaTemp

                'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
                FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
                dtpHasta.Value = FechaTemp

            End If

            Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
            Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

        Catch ex As Exception

            Me.chbMesCompleto.Checked = False

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

        Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
        Me.bscProducto2.Enabled = Me.chbProducto.Checked

        'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
        If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
        Else
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbMarca.Checked = False
            chbRubro.Checked = False
        End If

        Me.bscCodigoProducto2.Focus()

    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
            Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged

        Me.cmbMarca.Enabled = Me.chbMarca.Checked

        If Not Me.chbMarca.Checked Then
            Me.cmbMarca.SelectedIndex = -1
        Else
            If Me.cmbMarca.Items.Count > 0 Then
                Me.cmbMarca.SelectedIndex = 0
            End If
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
        End If

        Me.cmbMarca.Focus()

    End Sub

    Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged

        Me.cmbRubro.Enabled = Me.chbRubro.Checked

        If Not Me.chbRubro.Checked Then
            Me.cmbRubro.SelectedIndex = -1
        Else
            If Me.cmbRubro.Items.Count > 0 Then
                Me.cmbRubro.SelectedIndex = 0
            End If
            'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
            'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
        End If

        Me.cmbRubro.Focus()

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

    Private Sub InfDetalleVentasPorVendedor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F5 Then
            Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
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

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)
        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False
    End Sub

    Private Sub RefrescarDatosGrilla()

        Me.dtpDesde.Value = Date.Today
        Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

        Me.chbMesCompleto.Checked = False

        Me.chbCliente.Checked = False
        Me.bscCodigoCliente.Text = ""
        Me.bscCodigoCliente.Tag = Nothing
        Me.bscCliente.Text = ""

        Me.chbMarca.Checked = False
        Me.chbRubro.Checked = False
        Me.chbProducto.Checked = False

        Me.bscProducto2.Text = ""
        Me.bscCodigoProducto2.Text = ""

        Me.cmbVendedor.SelectedIndex = -1

      Me.cmbConComision.SelectedIndex = 1 'SI

      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

        If Not Me.dgvDetalle.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
        End If

    End Sub

    Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim IdCliente As Long = 0

         Dim IdVendedor As Integer = 0

         Dim Marca As Integer = 0
         Dim Rubro As Integer = 0
         Dim idSubRubro As Integer = 0
         Dim Producto As String = String.Empty

         Dim idZonaGeografica As String = String.Empty

         If Me.chbMarca.Checked Then
            Marca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If
         If Me.chbRubro.Checked Then
            Rubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.cmbSubRubro.Enabled Then
            idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If

         If Me.chbProducto.Checked Then
            Producto = Me.bscCodigoProducto2.Text
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         Dim Total As Decimal = 0
         Dim Comision As Decimal = 0

         If Me.bscCodigoCliente.Tag IsNot Nothing Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

         Me.dgvDetalle.DataSource = oVenta.GetComisionesDetalladoPorProductos(actual.Sucursal.Id, _
                                                                 dtpDesde.Value, dtpHasta.Value, _
                                                                 Me.cmbConComision.Text, _
                                                                 IdVendedor,
                                                                 IdCliente, _
                                                                 Marca, _
                                                                 Rubro, _
                                                                 idSubRubro, _
                                                                 Producto, _
                                                                 idZonaGeografica, _
                                                                 Me.chbConIVA.Checked)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            Total += Decimal.Parse(dr.Cells("ImporteTotalNeto").Value.ToString())
            Comision += Decimal.Parse(dr.Cells("Comision").Value.ToString())
         Next

         Me.txtTotal.Text = Total.ToString("##,##0.00")
         Me.txtTotalComision.Text = Comision.ToString("##,##0.00")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

    End Sub


#End Region

End Class