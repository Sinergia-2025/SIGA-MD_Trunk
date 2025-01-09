Imports Eniac.Entidades

Public Class ComisionesProductoVendedorLista

   Private _publicos As Publicos
   Private _dtProductos As DataTable

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboListaDePrecios(cmbListasDePrecios)

         cmbVendedor.SelectedIndex = -1
         Me.ugdProductos.AgregarFiltroEnLinea({"NombreProducto", "NombreListaPrecios"})

      End Sub)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() GrabarGrillaDetalle())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         CargaGrillaDetalle()
         pnlComision.Enabled = True
         tsbGrabar.Enabled = True
         cmbVendedor.Enabled = False
         btnBuscar.Enabled = False

      End Sub)
   End Sub

   Public Sub GrabarGrillaDetalle()
      Dim IdVendedor As Integer

      If cmbVendedor.SelectedItem Is Nothing Then
         Throw New Exception("Debe seleccionar un vendedor.")
      End If

      IdVendedor = DirectCast(cmbVendedor.SelectedItem, Empleado).IdEmpleado

      Dim regla = New Reglas.Empleados()

      Using ds As New DataSet
         Try
            ds.Tables.Add(_dtProductos)

            regla.GrabaComisionesPorListaProducto(IdVendedor, ds)

            ShowMessage("Se actualizaron las comisiones exitosamente.")

         Finally
            ds.Tables.Clear()
         End Try

         RefrescarDatosGrilla()

      End Using

   End Sub

   Public Sub RefrescarDatosGrilla()
      If _dtProductos IsNot Nothing Then _dtProductos.Clear()
      cmbListasDePrecios.SelectedIndex = 0
      txtPorcentaje.Text = "0.00"
      tsbGrabar.Enabled = False
      cmbVendedor.Enabled = True
      btnBuscar.Enabled = True
      cmbVendedor.SelectedIndex = -1
      pnlComision.Enabled = False
   End Sub

   Public Sub CargaGrillaDetalle()
      Dim IdVendedor As Integer
      Dim IdListaPrecios As Integer

      If cmbVendedor.SelectedItem Is Nothing Then
         Throw New Exception("Debe seleccionar un vendedor.")
      End If

      If cmbListasDePrecios.SelectedItem Is Nothing Then
         Throw New Exception("Debe seleccionar una Lista de Precios.")
      End If

      IdVendedor = DirectCast(cmbVendedor.SelectedItem, Empleado).IdEmpleado
      IdListaPrecios = cmbListasDePrecios.ValorSeleccionado(Of Integer)

      _dtProductos = New Reglas.EmpleadosComisionesProductosPrecios().GetParaABM(IdVendedor)

      ugdProductos.DataSource = _dtProductos

   End Sub



   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         _publicos.PreparaGrillaProductos2(Me.bscCodigoProducto)
         bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            CargarProducto(e.FilaDevuelta)
            btnInsertarProductos.Focus()
         End If
      End Sub)
   End Sub
   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
      Sub()
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         _publicos.PreparaGrillaProductos2(Me.bscProducto)
         bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            CargarProducto(e.FilaDevuelta)
            btnInsertarProductos.Focus()
         End If
      End Sub)
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)

      bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscProducto.Enabled = False
      bscCodigoProducto.Enabled = False
      Me.cmbListasDePrecios.Focus()

   End Sub

   Private Sub btnInsertarProductos_Click(sender As Object, e As EventArgs) Handles btnInsertarProductos.Click
      Try
         If String.IsNullOrEmpty(Me.bscCodigoProducto.Text) Then
            MessageBox.Show("Seleccione un Producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscProducto.Focus()
            Exit Sub
         End If
         If Me.bscCodigoProducto.Text IsNot Nothing AndAlso Decimal.Parse(Me.txtPorcentaje.Text.ToString()) > 0 Then
            If Me.ExisteProducto(Me.bscCodigoProducto.Text.ToString(), cmbListasDePrecios.ValorSeleccionado(Of Integer)) Then
               MessageBox.Show("Ya existe el Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarProducto()

            End If
            Me.bscCodigoProducto.Text = ""
            Me.bscProducto.Text = ""
            Me.txtPorcentaje.Text = "0.00"
            Me.bscProducto.Enabled = True
            Me.bscCodigoProducto.Enabled = True
            Me.bscCodigoProducto.Focus()
         Else
            If Me.txtPorcentaje.Text = "0.00" Then
               MessageBox.Show("La Comisión es no puede ser 0.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtPorcentaje.Focus()
            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Function ExisteProducto(ByVal idProducto As String, IdListaPrecios As Integer) As Boolean
      If _dtProductos IsNot Nothing Then
         For Each dr As DataRow In _dtProductos.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If dr.Field(Of String)("IdProducto") = idProducto And dr.Field(Of Integer)("IdListaPrecios") = IdListaPrecios Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function

   Private Sub AgregarProducto()
      Dim dr As DataRow = _dtProductos.NewRow()
      dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString()) = DirectCast(cmbVendedor.SelectedItem, Empleado).IdEmpleado
      dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString()) = Me.bscCodigoProducto.Text
      dr(Entidades.Producto.Columnas.NombreProducto.ToString()) = Me.bscProducto.Text
      dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString()) = cmbListasDePrecios.ValorSeleccionado(Of Integer)
      dr(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()) = cmbListasDePrecios.Text
      dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.Comision.ToString()) = Me.txtPorcentaje.Text
      _dtProductos.Rows.Add(dr)

      ugdProductos.DataSource = _dtProductos
   End Sub

   Private Sub btnEliminarProductos_Click(sender As Object, e As EventArgs) Handles btnEliminarProductos.Click
      Try
         If Me.ugdProductos.ActiveRow IsNot Nothing Then
            If MessageBox.Show("Esta seguro de eliminar la comisión seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub EliminarLineaProducto()
      EliminarLineaSeleccionada(ugdProductos)
   End Sub
   Private Sub EliminarLineaSeleccionada(grilla As UltraGrid)
      If grilla IsNot Nothing Then
         If grilla.ActiveRow IsNot Nothing Then
            grilla.Rows(grilla.ActiveRow.Index).Delete(False)
            grilla.Update()
         End If
      End If
   End Sub
End Class