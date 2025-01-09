Option Strict Off
Public Class InfProductosMasMovimientos

#Region "Campos"

   Private _publicos As Publicos
   Private _stockInicial As Decimal

   '-- REQ-35225.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If
         '-- REQ-35225.- --------------------------------------------------------------------------------------------------------------------------------
         With dgvDetalle.Columns("DescripcionAtributo01")
            If TipoAtributo01 > 0 Then
               .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion
               .Visible = True
            End If
         End With
         With dgvDetalle.Columns("DescripcionAtributo02")
            If TipoAtributo02 > 0 Then
               .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
               .Visible = True
            End If
         End With
         With dgvDetalle.Columns("DescripcionAtributo03")
            If TipoAtributo03 > 0 Then
               .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion
               .Visible = True
            End If
         End With
         With dgvDetalle.Columns("DescripcionAtributo04")
            If TipoAtributo04 > 0 Then
               .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion
               .Visible = True
            End If
         End With
         '-----------------------------------------------------------------------------------------------------------------------------------------------
         Dim oTipoMov As New Reglas.TiposMovimientos
         'Me.cmbTipoMovimiento.DataSource = oTipoMov.GetParaCombos()
         Me.cmbTipoMovimiento.DataSource = oTipoMov.GetTodos()
         Me.cmbTipoMovimiento.DisplayMember = "Descripcion"
         Me.cmbTipoMovimiento.ValueMember = "IdTipoMovimiento"
         Me.cmbTipoMovimiento.SelectedIndex = -1

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfResumenMovimDeProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

         If Me.chbMarca.Checked Then
            Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
         End If

         If Me.chbRubro.Checked Then
            Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         End If

         If Me.chbSubRubro.Checked Then
            Filtros += " / SubRubro: " & Me.cmbSubRubro.Text
         End If


         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.chbProveedor.Checked Then
            Filtros = Filtros & " / Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
         End If

         If Me.chbTipoMovimiento.Checked Then
            Filtros += " / Tipo Movimiento: " & Me.cmbTipoMovimiento.Text
         End If

         Filtros += " / Cant. Prod a mostrar: " & Me.txtCantidad.Text

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfProductosMasMovimientos.rdlc", "DSReportes_InfResumenMovimDeProductos", dt, parm, True, 1) '# 1 = Cantidad Copias
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

         dtpDesde.Enabled = Not chkMesCompleto.Checked
         dtpHasta.Enabled = Not chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

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

   Private Sub chbTipoMovimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoMovimiento.CheckedChanged

      Me.cmbTipoMovimiento.Enabled = Me.chbTipoMovimiento.Checked
      If Not Me.chbTipoMovimiento.Checked Then
         Me.cmbTipoMovimiento.SelectedIndex = -1
      Else
         If Me.cmbTipoMovimiento.Items.Count > 0 Then
            Me.cmbTipoMovimiento.SelectedIndex = 0
         End If
      End If

      Me.cmbTipoMovimiento.Focus()

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

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()
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

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         'If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   cmbMarca.Focus()
         '   Exit Sub
         'End If

         'If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   cmbRubro.Focus()
         '   Exit Sub
         'End If

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

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub


   Private Sub RefrescarDatosGrilla()

      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now

      Me.chkMesCompleto.Checked = False
      Me.chbTipoMovimiento.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbSubRubro.Checked = False

      Me.chbCliente.Checked = False
      Me.chbProveedor.Checked = False


      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oStock As Reglas.Stock = New Reglas.Stock()

      Dim TipoMovimiento As String = String.Empty

      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim IdSubRubro As Integer = 0

      Dim IdCliente As Long = 0

      Dim IdProveedor As Long = 0

      If Me.chbMarca.Checked Then
         IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.chbRubro.Checked Then
         IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If

      If Me.cmbSubRubro.Enabled Then
         IdSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbProveedor.Checked Then
         IdProveedor = Me.bscCodigoProveedor.Tag.ToString()
      End If

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      Try

         If Me.cmbTipoMovimiento.SelectedValue IsNot Nothing Then
            TipoMovimiento = Me.cmbTipoMovimiento.SelectedValue.ToString()
         End If
         Dim Orden As String = "ASC"

         If rbDesc.Checked Then
            Orden = "DESC"
         End If

         dtDetalle = oStock.GetProductosMasMovimientos(actual.Sucursal.Id, _
                                                  dtpDesde.Value, dtpHasta.Value, _
                                                  TipoMovimiento, _
                                                  Integer.Parse(txtCantidad.Text), _
                                                  Orden, _
                                                  IdMarca, _
                                                  IdRubro, _
                                                  IdSubRubro, _
                                                  IdCliente, _
                                                  IdProveedor)


         dt = Me.CrearDT()


         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("NombreMarca") = dr("NombreMarca").ToString()
            drCl("NombreRubro") = dr("NombreRubro").ToString()
            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())

            '-- REQ-35225.- ------------------------------------------------------------
            drCl("IdaAtributoProducto01") = dr("IdaAtributoProducto01")
            drCl("DescripcionAtributo01") = dr("DescripcionAtributo01")
            drCl("IdaAtributoProducto02") = dr("IdaAtributoProducto02")
            drCl("DescripcionAtributo02") = dr("DescripcionAtributo02")
            drCl("IdaAtributoProducto03") = dr("IdaAtributoProducto03")
            drCl("DescripcionAtributo03") = dr("DescripcionAtributo03")
            drCl("IdaAtributoProducto04") = dr("IdaAtributoProducto04")
            drCl("DescripcionAtributo04") = dr("DescripcionAtributo04")
            '---------------------------------------------------------------------------
            dt.Rows.Add(drCl)

         Next

         Me.dgvDetalle.DataSource = dt

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))

         .Columns.Add("IdaAtributoProducto01", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo01", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto02", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo02", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto03", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo03", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto04", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo04", System.Type.GetType("System.String"))

      End With

      Return dtTemp

   End Function

#End Region

   Private Sub cmbTipoMovimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoMovimiento.SelectedIndexChanged
      If cmbTipoMovimiento.SelectedItem() IsNot Nothing Then
         If DirectCast(cmbTipoMovimiento.SelectedItem(), Entidades.TipoMovimiento).CoeficienteStock < 0 Then
            rbAsc.Checked = True
         Else
            rbDesc.Checked = True
         End If
      End If
   End Sub
End Class