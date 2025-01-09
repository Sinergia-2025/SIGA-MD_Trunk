Imports actual = Eniac.Entidades.Usuario.Actual

Public Class EstadisticaDeComprasProveedores

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.CargarSucursales()

         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboModelos(Me.cmbModelo)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Publicos.ProductoTieneModelo Then
            Me.chbModelo.Visible = False
            Me.cmbModelo.Visible = False
         End If

         If Not reglas.Publicos.ProductoTieneSubRubro Then
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

         Me.chbMesCompleto.Checked = False
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
         Me.chbMarca.Checked = False
         Me.chbModelo.Checked = False
         Me.chbProducto.Checked = False
         Me.chbRubro.Checked = False

         Me.txtCantidad.Text = "10"

         For i As Integer = 1 To Me.clbSucursales.Items.Count - 1
            Me.clbSucursales.SetItemCheckState(i, CheckState.Unchecked)
         Next

         Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)

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

         Dim Filtro1 As String = String.Empty
         Dim Filtro2 As String = String.Empty

         Filtro1 += "Los " + Me.txtCantidad.Text + " mejores Proveedores "
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

         If Me.chbMarca.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "Marca: " & Me.cmbMarca.Text
         End If

         If Me.chbModelo.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "Modelo: " & Me.cmbModelo.Text
         End If

         If Me.chbRubro.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "Rubro: " & Me.cmbRubro.Text
         End If

         If Me.chbSubRubro.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "SubRubro: " & Me.cmbSubRubro.Text
         End If

         If Me.chbProducto.Checked Then
            If Filtro2.Length > 0 Then Filtro2 += " / "
            Filtro2 += "Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
         End If


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtro", Filtro1))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtro1", Filtro2))

         Dim dt As DataTable
         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Me.Cursor = Cursors.Default

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.EstadisticaDeComprasProveedores.rdlc", "SistemaDataSet_EComprasProveedores", dt, parm, True, 1) '# 1 = Cantidad Copias
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

   Private Sub chbMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Dim suc As List(Of Integer) = New List(Of Integer)
         For Each ite As Object In Me.clbSucursales.CheckedItems
            suc.Add(DirectCast(ite, Entidades.Sucursal).Id)
         Next

         Me.Cursor = Cursors.WaitCursor
         If Me.ValidanDatos() Then
            Me.CargaGrillaDetalle(suc)

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

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
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

   Private Sub EstadisticaDeComprasProveedores_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
         Case Else
      End Select
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

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Function ValidanDatos() As Boolean

      If Me.dtpDesde.Value > Me.dtpHasta.Value Then
         MessageBox.Show("La fecha desde no puede ser mayor que la fecha hasta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpDesde.Focus()
         Return False
      End If

      If Me.chbProducto.Checked Then

         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("Activó el filtro de Producto, debe elegir uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscProducto2.Focus()
            Return False
         End If

      End If

      Return True

   End Function

   Public Sub CargaGrillaDetalle(ByVal suc As List(Of Integer))

      Dim cantidad As Integer = 0
      Dim idRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim idMarca As Integer = 0
      Dim idModelo As Integer = 0
      Dim idproducto As String = ""


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
         If Me.chbProducto.Enabled Then
            idproducto = Me.bscCodigoProducto2.Text.ToString()
         End If

         Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
         Dim IvaDiscriminado As Boolean
         IvaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado

         Dim reg As Reglas.Compras = New Reglas.Compras()
         Dim dt As DataTable = New DataTable()

         If Me.chbMarca.Checked Or Me.chbRubro.Checked Or Me.chbModelo.Checked Or Me.chbSubRubro.Checked Or Me.chbProducto.Checked Then
            dt = reg.GetEstadComprasProveedores(suc, cantidad, Me.dtpDesde.Value, Me.dtpHasta.Value, idMarca, idModelo, idRubro, idSubRubro, idproducto, IvaDiscriminado)
         Else
            dt = reg.GetEstadComprasProveedores(suc, cantidad, Me.dtpDesde.Value, Me.dtpHasta.Value, IvaDiscriminado)
         End If

         Me.dgvDetalle.DataSource = dt

         Dim Total As Decimal = 0
         For Each dr As DataRow In dt.Rows
            Total += Decimal.Parse(dr("Importe").ToString())
         Next
         Me.txtTotal.Text = Total.ToString("#,##0.00")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

End Class