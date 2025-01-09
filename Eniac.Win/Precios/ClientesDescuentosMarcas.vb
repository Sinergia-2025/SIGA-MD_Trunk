Public Class ClientesDescuentosMarcas

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            bscMarca.Enabled = False
            txtDescuentoRecargoPorc1.Enabled = False
            txtDescuentoRecargoPorc2.Enabled = False

            bscCodigoCliente.Focus()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            If dgvDetalle.Rows.Count > 0 And tsbGrabar.Enabled Then
               If ShowPregunta("¿Desea limpiar todos los datos ingresados?") = Windows.Forms.DialogResult.Yes Then
                  Refrescar()
               End If
            Else
               Refrescar()
            End If
         End Sub)
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
         Sub()
            Dim dt = DirectCast(dgvDetalle.DataSource, DataTable)
            Dim reg = New Reglas.ClientesDescuentosMarcas()
            reg.GrabarClientesDescuentosMarcas(Long.Parse(bscCodigoCliente.Tag.ToString()), dt)

            ShowMessage("Se actualizaron los datos correctamente.")
            Refrescar()
         End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
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

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar_Click(Me.bscCodigoCliente, New EventArgs())
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

   Private Sub bscMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosMarca(e.FilaDevuelta)
            Me.txtDescuentoRecargoPorc1.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs)
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.bscMarca.Enabled = True
         Me.txtDescuentoRecargoPorc1.Enabled = True
         Me.txtDescuentoRecargoPorc1.Text = "0.00"
         Me.txtDescuentoRecargoPorc2.Enabled = True
         Me.txtDescuentoRecargoPorc2.Text = "0.00"

         If dgvDetalle.Rows.Count > 0 Then
            Me.bscMarca.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Function ExisteMarca(idMarca As Integer) As Boolean

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Integer.Parse(dr.Cells("IdMarca").Value.ToString()) = idMarca Then
            Return True
         End If
      Next

      Return False

   End Function

   Private Sub txtDescuentoRecargoPorc1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargoPorc1.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtDescuentoRecargoPorc2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescuentoRecargoPorc2.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Me.bscMarca.FilaDevuelta IsNot Nothing And (Me.txtDescuentoRecargoPorc1.Text <> "0.00" Or Me.txtDescuentoRecargoPorc1.Text <> "0.00") Then
            If Me.ExisteMarca(Integer.Parse(Me.bscMarca.FilaDevuelta.Cells("IdMarca").Value.ToString())) Then
               MessageBox.Show("Ya existe el Marca.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.tsbGrabar.Enabled = True
               Me.AgregarMarca()

            End If
            Me.bscMarca.Text = ""
            Me.txtDescuentoRecargoPorc1.Text = "0.00"
            Me.txtDescuentoRecargoPorc2.Text = "0.00"
            Me.bscMarca.Focus()
         Else
            MessageBox.Show("El Descuento no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoRecargoPorc1.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Eliminar la Marca Seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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
      Me.bscMarca.Enabled = False
      Me.txtDescuentoRecargoPorc1.Enabled = False
      Me.txtDescuentoRecargoPorc2.Enabled = False
      Me.RefrescarDatosGrilla()

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

   End Sub

   Private Sub PresionarTab(e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub AgregarMarca()

      Dim dr As DataRow = Me._descuentos.NewRow()


      dr(0) = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      dr(1) = Me.bscMarca.FilaDevuelta.Cells("IdMarca").Value.ToString()
      dr(2) = Me.bscMarca.FilaDevuelta.Cells("NombreMarca").Value.ToString()
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

   Private Sub CargarDatosMarca(dr As DataGridViewRow)

      Me.bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()

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

         Dim reg As Reglas.ClientesDescuentosMarcas

         reg = New Reglas.ClientesDescuentosMarcas()

         Me._descuentos = reg.GetClientesDescuentosMarcas(IdCliente, False)

         Me.dgvDetalle.DataSource = Me._descuentos

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class