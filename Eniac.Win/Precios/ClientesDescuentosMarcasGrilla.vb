Public Class ClientesDescuentosMarcasGrilla

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.bscCodigoCliente.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ClientesMarcasDescuentos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim dt As DataTable = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim reg As Reglas.ClientesDescuentosMarcas = New Reglas.ClientesDescuentosMarcas()

         reg.GrabarClientesDescuentosMarcas(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), dt)

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.dgvDetalle.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCliente.Focus()
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnDescuentoRecargoPorc1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescuentoRecargoPorc1.Click

      Try

         If Not IsNumeric(Me.txtDescuentoRecargoPorc1.Text) Then
            MessageBox.Show("El Descuento/Recargo debe ser un Número", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            Me.AplicarDescuentoRecargo(1, Decimal.Parse(Me.txtDescuentoRecargoPorc1.Text))
            MessageBox.Show("Fueron Aplicados " & Me.dgvDetalle.Rows.Count.ToString() & " Descuentos/Recargos en 1° Posicion.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         Me.txtDescuentoRecargoPorc1.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnDescuentoRecargoPorc2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescuentoRecargoPorc2.Click

      Try

         If Not IsNumeric(Me.txtDescuentoRecargoPorc2.Text) Then
            MessageBox.Show("El Descuento/Recargo debe ser un Número", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            Me.AplicarDescuentoRecargo(2, Decimal.Parse(Me.txtDescuentoRecargoPorc2.Text))
            MessageBox.Show("Fueron Aplicados " & Me.dgvDetalle.Rows.Count.ToString() & " Descuentos/Recargos en 2° Posicion.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         Me.txtDescuentoRecargoPorc2.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dgvDetalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit

      Try

         If e.RowIndex > -1 Then
            Dim Dbl As Double = 0

            If Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
            End If

            If Double.TryParse(Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) Then
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl.ToString("N2")
            Else
               MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dgvDetalle_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvDetalle.CellValueNeeded
      Try

         If e.RowIndex > -1 Then
            Dim Dbl As Double = 0

            If Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
            End If

            If Double.TryParse(Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) Then
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl.ToString("N2")
            Else
               MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      'If e.Value Is Nothing Then
      '   e.Value = "0.00"
      'End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()

      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Permitido = True
      Me.bscCliente.Text = ""

      Me.txtDescuentoRecargoPorc1.Text = "0.00"
      Me.txtDescuentoRecargoPorc2.Text = "0.00"

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

   Private Sub RefrescarDatosGrilla()

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         Dim IdCliente As Long = 0

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim reg As Reglas.ClientesDescuentosMarcas = New Reglas.ClientesDescuentosMarcas()

         'Dim _Descuentos As DataTable
         '_Descuentos = reg.GetClientesDescuentosMarcas(TipoDocumento, NroDocumento, True)
         'Me.dgvDetalle.DataSource = _Descuentos

         Me.dgvDetalle.DataSource = reg.GetClientesDescuentosMarcas(IdCliente, True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub AplicarDescuentoRecargo(ByVal Posicion As Integer, ByVal Monto As Decimal)

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         dr.Cells("DescuentoRecargoPorc" & Posicion.ToString()).Value = Monto
      Next

   End Sub

#End Region

End Class