Option Explicit On
Option Strict On

Public Class ClientesListaDePreciosMarca

#Region "Campos"

   Private _publicos As Publicos
   Private _listasMarca As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboListaDePrecios(Me.cmbListasDePrecios)
         Me.cmbListasDePrecios.SelectedIndex = -1

         Me._publicos.CargaComboListaDePrecios(Me.cmbListasDePreciosCliente)
         Me.cmbListasDePreciosCliente.SelectedIndex = -1

         Me.bscMarca.Enabled = False
         Me.cmbListasDePrecios.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ClientesListaDePreciosMarca_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 Then
         Me.tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
      End If
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Dim reg As Reglas.ClientesMarcasListasDePrecios = New Reglas.ClientesMarcasListasDePrecios()
         reg.GrabarClientesListaPreciosMarcas(Me._listasMarca)
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
            Me.btnConsultar_Click(Me.bscCliente, New EventArgs())
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      Try
         Me._publicos.PreparaGrillaMarcas(Me.bscMarca)
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me.bscMarca.Datos = oMarcas.GetPorNombre(Me.bscMarca.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosMarca(e.FilaDevuelta)
            Me.cmbListasDePrecios.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.bscMarca.Enabled = True
         Me.cmbListasDePrecios.Enabled = True

         If dgvDetalle.Rows.Count > 0 Then
            Me.bscMarca.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay Listas Asignadas para el Cliente Seleccionado !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscMarca.Focus()
            Exit Sub
         End If

         Me.bscMarca.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Not Me.bscMarca.Selecciono Then
            MessageBox.Show("Debe elegir una Marca.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscMarca.Focus()
            Exit Sub
         End If
         If Me.cmbListasDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir una Lista de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbListasDePrecios.Focus()
            Exit Sub
         End If
         If Me.ExisteMarca(Integer.Parse(Me.bscMarca.FilaDevuelta.Cells("IdMarca").Value.ToString())) Then
            MessageBox.Show("Ya existe la Marca.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscMarca.Focus()
            Exit Sub
         End If
         If Me.cmbListasDePreciosCliente.SelectedValue.ToString() = Me.cmbListasDePrecios.SelectedValue.ToString() Then
            MessageBox.Show("La Lista de Precios NO puede Coincidir con la Predeterminada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbListasDePrecios.Focus()
            Exit Sub
         End If

         Me.tsbGrabar.Enabled = True

         Me.AgregarListaMarca()

         Me.bscMarca.Text = ""

         Me.bscMarca.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function ExisteMarca(ByVal idMarca As Integer) As Boolean

      If Me._listasMarca.GetChanges(DataRowState.Unchanged) IsNot Nothing Then
         For Each dr As DataRow In Me._listasMarca.GetChanges(DataRowState.Unchanged).Rows
            If Integer.Parse(dr("IdMarca").ToString()) = idMarca Then
               Return True
            End If
         Next
      End If

      If Me._listasMarca.GetChanges(DataRowState.Added) IsNot Nothing Then
         For Each dr As DataRow In Me._listasMarca.GetChanges(DataRowState.Added).Rows
            If Integer.Parse(dr("IdMarca").ToString()) = idMarca Then
               Return True
            End If
         Next
      End If

      Return False

   End Function

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.tsbGrabar.Enabled = True
               Me.EliminarLineaProducto()
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

      Me.bscCodigoCliente.Enabled = True
      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Enabled = True
      Me.bscCliente.Text = ""
      Me.cmbListasDePreciosCliente.Enabled = True
      Me.cmbListasDePreciosCliente.SelectedIndex = -1
      Me.bscMarca.Enabled = False
      Me.bscMarca.Text = ""
      Me.cmbListasDePrecios.Enabled = False
      Me.cmbListasDePrecios.SelectedIndex = -1
      Me.RefrescarDatosGrilla()
      Me.bscCodigoCliente.Focus()
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      'Asigno al SelectedValue porque la numeracion de las listas, no necesamiente es correlativa y da error.
      Me.cmbListasDePreciosCliente.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())
      Me.cmbListasDePreciosCliente.Enabled = False
   End Sub

   Private Sub AgregarListaMarca()

      Dim dr As DataRow = Me._listasMarca.NewRow()

      dr("IdCliente") = Me.bscCodigoCliente.Tag.ToString()
      dr("IdMarca") = Me.bscMarca.FilaDevuelta.Cells("IdMarca").Value.ToString()
      dr("NombreMarca") = Me.bscMarca.FilaDevuelta.Cells("NombreMarca").Value.ToString()
      dr("IdListaPrecios") = Me.cmbListasDePrecios.SelectedValue
      dr("NombreListaPrecios") = Me.cmbListasDePrecios.Text

      Me._listasMarca.Rows.Add(dr)

      Me.dgvDetalle.DataSource = Me._listasMarca

   End Sub

   Private Sub EliminarLineaProducto()
      Me._listasMarca.Rows(Me.dgvDetalle.SelectedRows(0).Index).Delete()
      Me.dgvDetalle.DataSource = Me._listasMarca
   End Sub

   Private Sub CargarDatosMarca(ByVal dr As DataGridViewRow)
      Me.bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
   End Sub

   Private Sub RefrescarDatosGrilla()
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If
      Me.bscCodigoCliente.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         Dim IdCliente As Long = 0
         Dim IdMarca As Integer = 0
         Dim IdListaDePrecios As Integer = -1

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim reg As Reglas.ClientesMarcasListasDePrecios

         reg = New Reglas.ClientesMarcasListasDePrecios()

         Me._listasMarca = reg.ClientesMarcasListasDePrecios(IdCliente, IdMarca, IdListaDePrecios)

         Me.dgvDetalle.DataSource = Me._listasMarca

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class