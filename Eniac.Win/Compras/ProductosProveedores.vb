Public Class ProductosProveedores

#Region "Campos"

   Private _publicos As Publicos
   Private _productosProveedores As DataTable
   Private _tit As Dictionary(Of String, String)
   Private _titPP As Dictionary(Of String, String)
   Private _actionControls As IEnumerable(Of Control)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _actionControls = {pnlAcciones, tstBarra, ugProductos, ugProductosProveedores}
         _publicos = New Publicos()
         _tit = GetColumnasVisiblesGrilla(ugProductos)
         _titPP = GetColumnasVisiblesGrilla(ugProductosProveedores)
         With ugProductosProveedores.DisplayLayout.Bands(0)
            .Columns(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica.ToString()).Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
            .Columns(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString()).Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
            .Columns(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString()).Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
            .Columns(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString()).Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
            .Columns(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString()).Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
         End With
         Refrescar()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Refrescar())
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()

         ugProductosProveedores.UpdateData()
         _productosProveedores.AcceptChanges()

         Dim cont = _productosProveedores.Count(Function(dr) String.IsNullOrWhiteSpace(dr.Field(Of String)("CodigoProductoProveedor")))
         If cont > 0 Then
            ShowMessage(String.Format("¡¡¡Hay {0} Producto{1} sin Código de Proveedor!!!", cont, If(cont = 1, "", "s")))
            Exit Sub
         End If

         Dim rProdProv = New Reglas.ProductosProveedores()
         rProdProv.GrabarProductosProveedores(Long.Parse(bscCodigoProveedor.Tag.ToString()), _productosProveedores)

         ShowMessage("Los Productos han sido modificados con exito!!")
         Refrescar()
      End Sub)
   End Sub
   Private Sub tsbImportarExcel_Click(sender As Object, e As EventArgs) Handles tsbImportarExcel.Click
      TryCatched(
      Sub()
         Dim fPre As New ImportarProductosProveedor
         fPre.ShowDialog()

         If Not fPre.DialogResult = Windows.Forms.DialogResult.OK Then
            Exit Sub
         End If

         Dim CodigoProducto As String
         Dim Contador As Integer
         Dim entro As Boolean = False
         Dim dt1 = DirectCast(ugProductosProveedores.DataSource, DataTable).Copy()

         With fPre.DtImport

            For Each Linea As DataRow In .Rows

               CodigoProducto = Linea(ImportarProductosProveedor.ColumnasExcel.Codigo.ToString()).ToString()

               For Each dr As DataRow In dt1.Rows
                  If dr("IdProducto").ToString.Trim() = CodigoProducto Then
                     entro = True
                     Exit For
                  End If

               Next
               Dim dr1 As DataRow = Me._productosProveedores.NewRow()

               If entro = False Then
                  dr1(Entidades.ProductoProveedor.Columnas.IdProveedor.ToString()) = Long.Parse(bscCodigoProveedor.Tag.ToString())
                  dr1(Entidades.ProductoProveedor.Columnas.IdProducto.ToString()) = CodigoProducto
                  dr1(Entidades.Producto.Columnas.NombreProducto.ToString()) = Linea(ImportarProductosProveedor.ColumnasExcel.Descripcion.ToString())
                  dr1(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()) = Linea(ImportarProductosProveedor.ColumnasExcel.CodProveedor.ToString())

                  'TODO: Revisar que pasa si se pisa el precio de compra con valor cero.
                  dr1(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString()) = 0
                  dr1(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString()) = DBNull.Value

                  dr1(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica.ToString()) = Linea.Field(Of Decimal?)(ImportarProductosProveedor.ColumnasExcel.Compra.ToString()).IfNull()
                  dr1(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString()) = Linea.Field(Of Decimal?)(ImportarProductosProveedor.ColumnasExcel.D_R_1.ToString()).IfNull()
                  dr1(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString()) = Linea.Field(Of Decimal?)(ImportarProductosProveedor.ColumnasExcel.D_R_2.ToString()).IfNull()
                  dr1(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString()) = Linea.Field(Of Decimal?)(ImportarProductosProveedor.ColumnasExcel.D_R_3.ToString()).IfNull()
                  dr1(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString()) = Linea.Field(Of Decimal?)(ImportarProductosProveedor.ColumnasExcel.D_R_4.ToString()).IfNull()
                  dr1(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc5.ToString()) = 0
                  dr1(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc6.ToString()) = 0

                  Me._productosProveedores.Rows.Add(dr1)

                  Contador += 1
               End If
               entro = False
            Next

            ugProductosProveedores.DataSource = _productosProveedores
            MessageBox.Show("Proceso Finalizado, los productos fueron agregados: " & Contador.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         End With
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

#Region "Eventos Buscador Proveedores"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Acciones Productos"
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(_actionControls, Sub() Agregar(ugProductos.FilasSeleccionadas(Of DataRow), True))
   End Sub
   Private Sub btnAgregarTodos_Click(sender As Object, e As EventArgs) Handles btnAgregarTodos.Click
      TryCatched(_actionControls, Sub() Agregar(ugProductos.TodasLasFilas(Of DataRow), False))
   End Sub
   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      TryCatched(_actionControls, Sub() Eliminar(ugProductosProveedores.FilasSeleccionadas(Of DataRow)))
   End Sub
   Private Sub btnQuitarTodos_Click(sender As Object, e As EventArgs) Handles btnQuitarTodos.Click
      TryCatched(_actionControls,
                 Sub()
                    _productosProveedores.Clear()
                    MostrarCantidadRegistros()
                 End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub Refrescar()

      bscCodigoProveedor.Permitido = True
      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing
      bscProveedor.Permitido = True
      bscProveedor.Text = String.Empty

      pnlAcciones.Enabled = False

      tsbGrabar.Enabled = False
      tsbImportarExcel.Enabled = True
      chbRepetirCodigo.Checked = False

      'Se hace al elegir al Proveedor

      ugProductos.ClearFilas()
      If _productosProveedores IsNot Nothing Then _productosProveedores.Clear()

      bscCodigoProveedor.Focus()
      MostrarCantidadRegistros()

   End Sub
   Private Sub Agregar(rows As IEnumerable(Of DataRow), mostrarMensajeSiExiste As Boolean)
      Try
         pgb.Minimum = 0
         pgb.Maximum = rows.Count
         pgb.Value = pgb.Minimum
         pgb.Visible = True
         For Each dg In rows
            If Not _productosProveedores.Any(Function(drPPAny) drPPAny.Field(Of String)("IdProducto") = dg.Field(Of String)("IdProducto")) Then
               Dim drPP = _productosProveedores.NewRow()
               drPP(Entidades.ProductoProveedor.Columnas.IdProveedor.ToString()) = Long.Parse(bscCodigoProveedor.Tag.ToString())
               drPP(Entidades.ProductoProveedor.Columnas.IdProducto.ToString()) = dg.Field(Of String)("IdProducto")
               drPP(Entidades.Producto.Columnas.NombreProducto.ToString()) = dg.Field(Of String)("NombreProducto")
               drPP(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()) = If(chbRepetirCodigo.Checked, dg.Field(Of String)("IdProducto"), String.Empty)
               drPP(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString()) = DBNull.Value
               drPP(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc5.ToString()) = 0
               drPP(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc6.ToString()) = 0
               _productosProveedores.Rows.Add(drPP)
            Else
               If mostrarMensajeSiExiste Then ShowMessage(String.Format("El Producto {0} ya existe", dg.Field(Of String)("IdProducto")))
            End If
            pgb.Value += 1
            Application.DoEvents()
         Next
         _productosProveedores.AcceptChanges()
         tsbImportarExcel.Enabled = False
      Finally
         pgb.Value = pgb.Maximum
         pgb.Visible = False
         MostrarCantidadRegistros()
      End Try
   End Sub
   Private Sub Eliminar(rows As IEnumerable(Of DataRow))
      Try
         pgb.Minimum = 0
         pgb.Maximum = rows.Count
         pgb.Value = pgb.Minimum
         pgb.Visible = True
         For Each dg In rows
            dg.Delete()
            pgb.Value += 1
            Application.DoEvents()
         Next
         _productosProveedores.AcceptChanges()
         tsbImportarExcel.Enabled = False
      Finally
         pgb.Value = pgb.Maximum
         pgb.Visible = False
         MostrarCantidadRegistros()
      End Try
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False

         tsbGrabar.Enabled = True
         tsbImportarExcel.Enabled = True

         CargarProductos()
         CargarProductosProveedor()
         MostrarCantidadRegistros()
      End If
   End Sub
   Private Sub CargarProductos()
      ugProductos.Enabled = True

      pnlAcciones.Enabled = True

      ugProductosProveedores.Enabled = True

      Dim rProd = New Reglas.Productos()
      Dim dt2 = rProd.GetProductosGrillaFiltroMarcaRubroSubrubro(actual.Sucursal.IdSucursal,
                                                                 nombreProducto:=String.Empty, idMarca:=0, idRubro:=0, idSubRubro:=0, idProducto:=String.Empty)
      ugProductos.DataSource = dt2
      AjustarColumnasGrilla(ugProductos, _tit)
      ugProductos.AgregarFiltroEnLinea({"NombreProducto"})
   End Sub
   Private Sub CargarProductosProveedor()
      Dim rProdProv = New Reglas.ProductosProveedores()
      _productosProveedores = rProdProv.GetPorProveedor(Long.Parse(bscCodigoProveedor.Tag.ToString()))
      ugProductosProveedores.DataSource = _productosProveedores
      AjustarColumnasGrilla(ugProductosProveedores, _titPP)
      ugProductosProveedores.AgregarFiltroEnLinea({"NombreProducto"})
   End Sub

   Private Sub MostrarCantidadRegistros()
      tssRegistros.Text = String.Format("Proveedor: {0} / Sistema: {1}",
                                        ugProductosProveedores.CantidadRegistrosParaStatusbar, ugProductos.CantidadRegistrosParaStatusbar)
   End Sub

#End Region

End Class