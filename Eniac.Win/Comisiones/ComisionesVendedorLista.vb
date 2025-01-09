Imports Eniac.Entidades

Public Class ComisionesVendedorLista

   Private _publicos As Publicos
   Private _dtMarcas As DataTable
   Private _dtRubros As DataTable
   Private _dtProductos As DataTable

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Dim general = New Entidades.ListaDePrecios With {
            .IdListaPrecios = -1,
            .NombreListaPrecios = "Comisión General"
         }
         _publicos.CargaComboListaDePrecios(cmbListasDePrecios, general)
         cmbVendedor.SelectedIndex = -1
         tbcComisiones.Controls.Remove(tbcComisiones.TabPages("tbpProductos"))
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

         tbcComisiones.Enabled = True
         tsbGrabar.Enabled = True
         cmbListasDePrecios.Enabled = True
         txtPorcentaje.Enabled = True
         btnDescuentoRecargoPorc1.Enabled = True

         cmbVendedor.Enabled = False
         btnBuscar.Enabled = False
      End Sub)
   End Sub

   Public Sub GrabarGrillaDetalle()
      Dim IdVendedor As Integer

      If cmbVendedor.SelectedItem Is Nothing Then
         Throw New Exception("Debe seleccionar un vendedor.")
      End If

      If _dtMarcas.Rows.Count = 0 Then
         Throw New Exception("No es posible guardar porque no realizó la busqueda del producto.")
      End If

      IdVendedor = DirectCast(cmbVendedor.SelectedItem, Empleado).IdEmpleado

      Dim regla = New Reglas.Empleados()
      Using ds As New DataSet
         Try
            ds.Tables.Add(_dtMarcas)
            ds.Tables.Add(_dtRubros)
            regla.GrabaComisionesPorLista(IdVendedor, ds)

            ShowMessage("Se actualizaron las comisiones exitosamente.")
         Finally
            ds.Tables.Clear()
         End Try
         RefrescarDatosGrilla()
      End Using
   End Sub

   Public Sub RefrescarDatosGrilla()
      If _dtMarcas IsNot Nothing Then _dtMarcas.Clear()
      If _dtRubros IsNot Nothing Then _dtRubros.Clear()

      cmbListasDePrecios.SelectedIndex = 0
      ''cmbVendedor.SelectedIndex = -1
      txtPorcentaje.Text = "0.00"

      tbcComisiones.Enabled = False
      tsbGrabar.Enabled = False
      cmbListasDePrecios.Enabled = False
      txtPorcentaje.Enabled = False
      btnDescuentoRecargoPorc1.Enabled = False

      cmbVendedor.Enabled = True
      btnBuscar.Enabled = True

      Me.tbcComisiones.SelectedTab = tbpMarcas

   End Sub

   Public Sub CargaGrillaDetalle()
      Dim IdVendedor As Integer

      If cmbVendedor.SelectedItem Is Nothing Then
         Throw New Exception("Debe seleccionar un vendedor.")
      End If

      IdVendedor = DirectCast(cmbVendedor.SelectedItem, Empleado).IdEmpleado

      _dtMarcas = New Reglas.EmpleadosComisionesMarcasPrecios().GetParaABM(IdVendedor)
      _dtRubros = New Reglas.EmpleadosComisionesRubrosPrecios().GetParaABM(IdVendedor)

      ugMarca.DataSource = _dtMarcas
      ugRubro.DataSource = _dtRubros

      FormatearGrillaMarca()
      FormatearGrillaRubro()

   End Sub

   Private Sub FormatearGrillaMarca()
      With ugMarca.DisplayLayout.Bands(0)
         FormatearGrilla(ugMarca)
         .Columns(Marca.Columnas.IdMarca.ToString()).Hidden = False
         .Columns(Marca.Columnas.IdMarca.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Marca.Columnas.NombreMarca.ToString()).Hidden = False
      End With
   End Sub
   Private Sub FormatearGrillaRubro()
      With ugRubro.DisplayLayout.Bands(0)
         FormatearGrilla(ugRubro)
         .Columns(Rubro.Columnas.IdRubro.ToString()).Hidden = False
         .Columns(Rubro.Columnas.IdRubro.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Rubro.Columnas.NombreRubro.ToString()).Hidden = False
      End With
   End Sub
   Private Sub FormatearGrilla(grilla As UltraGrid)
      With grilla.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            If columna.Key.StartsWith("ComisionPorVenta") Then
               columna.Hidden = False
               columna.CellActivation = Activation.AllowEdit
               columna.CellAppearance.TextHAlign = HAlign.Right
               columna.Format = Formatos.Format.Decimales2
               columna.MaskInput = Formatos.MaskInput.Decimales3_2
               columna.MaxValue = 99.99
               columna.MinValue = -99.99
               columna.Width = .Columns("ComisionPorVenta").Width

               columna.Header.Appearance.TextHAlign = HAlign.Center
            Else
               columna.Hidden = True
               columna.CellActivation = Activation.NoEdit
            End If
         Next
      End With
   End Sub

   Private Sub btnDescuentoRecargoPorc1_Click(sender As Object, e As EventArgs) Handles btnDescuentoRecargoPorc1.Click
      TryCatched(
      Sub()
         If cmbListasDePrecios.SelectedItem Is Nothing Then
            Throw New Exception("Debe seleccionar una lista de precios.")
         End If

         'If Not IsNumeric(txtPorcentaje.Text) OrElse CDec(txtPorcentaje.Text) = 0 Then
         '   Throw New Exception("Debe ingresar un porcentaje para aplicar a la lista.")
         'End If

         Dim nombreColumna As String
         If DirectCast(cmbListasDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios < 0 Then
            nombreColumna = "ComisionPorVenta"
         Else
            nombreColumna = "ComisionPorVenta__" + DirectCast(cmbListasDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios.ToString()
         End If

         If tbcComisiones.SelectedTab.Equals(tbpMarcas) Then
            ComisionesMasivas(_dtMarcas, ugMarca)
         ElseIf tbcComisiones.SelectedTab.Equals(tbpRubros) Then
            ComisionesMasivas(_dtRubros, ugRubro)
         End If

         'If _dtMarcas.Columns.Contains(nombreColumna) Then
         '   For Each dr As DataRow In _dtMarcas.Rows
         '      dr(nombreColumna) = CDec(txtPorcentaje.Text)
         '   Next
         'End If

         'ugMarca.Refresh()
      End Sub)
   End Sub

   Public Sub ComisionesMasivas(dt As DataTable, grilla As UltraGrid)
      Dim nombreColumna As String
      If DirectCast(cmbListasDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios < 0 Then
         nombreColumna = "ComisionPorVenta"
      Else
         nombreColumna = "ComisionPorVenta__" + DirectCast(cmbListasDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios.ToString()
      End If

      If dt.Columns.Contains(nombreColumna) Then
         For Each dr As DataRow In dt.Rows
            dr(nombreColumna) = CDec(txtPorcentaje.Text)
         Next
      End If

      grilla.Refresh()
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

   End Sub

   Private Sub btnInsertarProductos_Click(sender As Object, e As EventArgs) Handles btnInsertarProductos.Click
      TryCatched(
      Sub()
         Dim dr As DataRow = _dtProductos.NewRow()
         ''dr("")
      End Sub)
   End Sub
End Class