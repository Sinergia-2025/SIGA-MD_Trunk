Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ProductosBajaMasiva

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
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

         Me.btnBorrar.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosGrilla()

      Dim oProd As Reglas.Productos = New Reglas.Productos()
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim ConStock As String = "TODOS"

      If Me.cmbMarca.SelectedIndex > -1 Then
         IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.cmbRubro.SelectedIndex > -1 Then
         IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If

      If Me.chbSinStock.Checked Then
         ConStock = "NO"
      End If

      Me.chbTodos.Checked = False

      Me.dgvProductos.DataSource = oProd.GetPorNombreMarcaRubro(IdMarca, IdRubro, idSubRubro, Me.txtProducto.Text.Trim(), actual.Sucursal.Id, "TODOS", ConStock)

      Me.tssRegistros.Text = Me.dgvProductos.RowCount.ToString() & " Registros"

      If Me.dgvProductos.Rows.Count > 0 Then
         Me.dgvProductos.Focus()
      Else
         Me.txtProducto.Focus()
      End If

      Me.btnBorrar.Enabled = True

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.CargarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
      End If
   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         Me.cmbRubro.SelectedIndex = 0
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try

         Me.txtProducto.Text = String.Empty
         Me.chbMarca.Checked = False
         Me.chbRubro.Checked = False
         Me.chbSinStock.Checked = True

         Dim oProd As Reglas.Productos = New Reglas.Productos()

         'Me.dgvProductos.DataSource = oProd.GetPorCodigo("0", 0)

         If Not Me.dgvProductos.DataSource Is Nothing Then
            DirectCast(Me.dgvProductos.DataSource, DataTable).Rows.Clear()
         End If

         Me.tssRegistros.Text = Me.dgvProductos.Rows.Count.ToString() & " Registros"

         Me.btnBorrar.Enabled = False

         Me.txtProducto.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ProductosBajaMasiva_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvProductos.Rows
         dr.Cells("chkBaja").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

      Dim lngTotalReg As Long = 0, strMensaje As String, lngTotalRegBorrados As Long = 0

      Try

         Me.Cursor = Cursors.WaitCursor

         For Each dr As DataGridViewRow In Me.dgvProductos.Rows

            If Not dr.Cells("chkBaja").Value Is Nothing Then
               If Boolean.Parse(dr.Cells("chkBaja").Value.ToString()) Then
                  lngTotalReg = lngTotalReg + 1
               End If

            End If

         Next

         If lngTotalReg = 0 Then Exit Sub

         If lngTotalReg = 1 Then
            strMensaje = "¿ Procede a ELIMINAR el Producto Seleccionado ?"
         Else
            strMensaje = "¿ Procede a ELIMINAR los " & lngTotalReg.ToString & " Productos Seleccionados ?"
         End If

         If MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If


         Dim oProductos As Reglas.Productos
         Dim oProd As Entidades.Producto

         For Each dr As DataGridViewRow In Me.dgvProductos.Rows

            If Not dr.Cells("chkBaja").Value Is Nothing Then

               If Boolean.Parse(dr.Cells("chkBaja").Value.ToString()) Then
                  oProductos = New Reglas.Productos()
                  oProd = New Entidades.Producto

                  oProd.IdProducto = dr.Cells("Producto").Value.ToString.Trim()

                  Try

                     oProductos.Borrar(oProd)

                     lngTotalRegBorrados = lngTotalRegBorrados + 1

                  Catch ex As Exception

                     'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                     strMensaje = "IMPOSIBLE Borrar el Producto " & dr.Cells("Producto").Value.ToString & "-" & dr.Cells("NombreProducto").Value.ToString
                     strMensaje = strMensaje & Chr(13) & Chr(13) & " porque fue utilizado para alguna operacion (Venta, Compra, etc) "
                     strMensaje = strMensaje & Chr(13) & Chr(13) & "¿ Continua ELIMINANDO el resto de los Productos Seleccionados ?"

                     If MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit For
                     End If

                  End Try

               End If

            End If

         Next

         Select Case lngTotalRegBorrados
            Case 0
               strMensaje = " ATENCION!!: NO se ELIMINO ningún Producto !!"
            Case 1
               strMensaje = " Producto eliminado SATISFACTORIAMENTE !!"
            Case Else
               strMensaje = lngTotalRegBorrados.ToString & " productos de " & lngTotalReg.ToString & " (Seleccionados) fueron eliminados SATISFACTORIAMENTE !!"
         End Select

         MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         If lngTotalRegBorrados > 0 Then
            Me.btnBuscar_Click(Me.btnBuscar, New EventArgs())
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class