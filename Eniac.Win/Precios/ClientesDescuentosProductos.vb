Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ClientesDescuentosProductos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.bscCodigoProducto2.Enabled = False
         Me.bscProducto2.Enabled = False

         Me.txtDescuentoRecargoPorc1.Enabled = False
         Me.txtDescuentoRecargoPorc2.Enabled = False

         Me.bscCodigoCliente.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ClientesProductosDescuentos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 Then
         Me.tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
      End If
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         If dgvDetalle.Rows.Count > 0 And Me.tsbGrabar.Enabled Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Desea limpiar todos los datos ingresados", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.Refrescar()
            End If
         Else
            Me.Refrescar()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click

      Try

         Dim dt As DataTable = DirectCast(Me.dgvDetalle.DataSource, DataTable)
         Dim reg As Reglas.ClientesDescuentosProductos = New Reglas.ClientesDescuentosProductos()

         reg.GrabarClientesDescuentosProductos(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), dt)

         MessageBox.Show("Se actualizaron los datos correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.Refrescar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
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
            Me.btnConsultar_Click(Me.bscCodigoCliente, New EventArgs())
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
            Me.btnConsultar_Click(Me.bscCodigoCliente, New EventArgs())
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
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
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.bscCodigoProducto2.Enabled = True
         Me.bscProducto2.Enabled = True

         Me.txtDescuentoRecargoPorc1.Enabled = True
         Me.txtDescuentoRecargoPorc1.Text = "0.00"
         Me.txtDescuentoRecargoPorc2.Enabled = True
         Me.txtDescuentoRecargoPorc2.Text = "0.00"

         If dgvDetalle.Rows.Count > 0 Then
                Me.bscCodigoProducto2.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function ExisteProducto(ByVal idProducto As String) As Boolean

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If dr.Cells("IdProducto").Value.ToString() = idProducto Then
            Return True
         End If
      Next

      Return False

   End Function

   Private Sub txtDescuentoRecargoPorc1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargoPorc1.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtDescuentoRecargoPorc2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargoPorc2.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try
         If (Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono) And (Me.txtDescuentoRecargoPorc1.Text <> "0.00" Or Me.txtDescuentoRecargoPorc1.Text <> "0.00") Then
            'If Me.ExisteProducto(Me.bscProducto2.FilaDevuelta.Cells("IdProducto").Value.ToString()) Then
            If Me.ExisteProducto(Me.bscCodigoProducto2.Text) Then
               MessageBox.Show("Ya existe el Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.tsbGrabar.Enabled = True
               Me.AgregarMarca()

            End If
            Me.bscCodigoProducto2.Text = ""
            Me.bscProducto2.Text = ""
            Me.txtDescuentoRecargoPorc1.Text = "0.00"
            Me.txtDescuentoRecargoPorc2.Text = "0.00"
            Me.bscProducto2.Focus()
         Else
            MessageBox.Show("El Descuento no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoRecargoPorc1.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Eliminar el Producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.tsbGrabar.Enabled = True
               Me.EliminarLineaDescuento()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()

      Me.tsbGrabar.Enabled = False
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Permitido = True
      Me.bscCliente.Text = ""
      Me.bscCodigoProducto2.Enabled = False
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Text = ""
        Me.bscProducto2.Text = ""
      Me.txtDescuentoRecargoPorc1.Enabled = False
      Me.txtDescuentoRecargoPorc2.Enabled = False
      Me.RefrescarDatosGrilla()

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
        Me.bscCodigoCliente.Permitido = False

   End Sub

   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub AgregarMarca()

      Dim dr As DataRow = Me._descuentos.NewRow()


      dr(0) = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      dr(1) = Me.bscCodigoProducto2.Text.ToString()
      dr(2) = Me.bscProducto2.Text.ToString()
      dr(3) = Me.txtDescuentoRecargoPorc1.Text
      dr(4) = Me.txtDescuentoRecargoPorc2.Text

      Me._descuentos.Rows.Add(dr)

      Me.dgvDetalle.DataSource = Me._descuentos

   End Sub

   Private Sub EliminarLineaDescuento()

      Me._descuentos.Rows(Me.dgvDetalle.SelectedRows(0).Index).Delete()
      Me.dgvDetalle.DataSource = Me._descuentos

      If Me.dgvDetalle.Rows.Count > 0 Then
         Me.dgvDetalle.FirstDisplayedScrollingRowIndex = Me.dgvDetalle.Rows.Count - 1
         Me.dgvDetalle.Rows(Me.dgvDetalle.Rows.Count - 1).Selected = True
      End If

   End Sub

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()

   End Sub

   Private Sub RefrescarDatosGrilla()

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscCodigoCliente.Focus()

   End Sub

   Private _descuentos As DataTable

   Private Sub CargaGrillaDetalle()
      Try
         Dim IdCliente As Long = 0

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim reg As Reglas.ClientesDescuentosProductos

         reg = New Reglas.ClientesDescuentosProductos()

         Me._descuentos = reg.GetClientesDescuentosProductos(IdCliente, False)

         Me.dgvDetalle.DataSource = Me._descuentos

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.txtDescuentoRecargoPorc1.Focus()

   End Sub

#End Region

End Class