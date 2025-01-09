Public Class ConsultarPreciosClientes

#Region "Campos"

   Private _publicos As Publicos
   Private _mostrarCosto As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         cmbSucursales.Initializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         _publicos.CargaComboListaDePrecios(cmbListasDePreciosCliente)
         cmbListasDePreciosCliente.SelectedIndex = -1

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            dgvSubrubroDesc.Visible = False
         End If

         txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)

         '------------
         _publicos.CargaComboMonedas1(cmbMoneda, {New Entidades.Moneda() With {.IdMoneda = -1, .NombreMoneda = "del producto"}}, {})
         cmbMoneda.SelectedIndex = 0
         cmbMoneda.SelectedValue = Reglas.Publicos.ConsultaPreciosCliente.Moneda
         '------------------------------

         If Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado Then
            bscCodigoCliente.Text = Reglas.Publicos.ConsultaPreciosCliente.CodigoCliente.ToString()
            bscCodigoCliente.PresionarBoton()
            bscCodigoCliente.Permitido = False
            bscCliente.Permitido = False
            txtCodigo.Focus()
         End If

         'Seguridad del campo Precio de Costo
         Dim rUsuario = New Reglas.Usuarios()
         _mostrarCosto = rUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, actual.Sucursal.Id, "ConsultarPrecios-PrecioCosto")
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoSinIVA").Hidden = Reglas.Publicos.PreciosConIVA
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoConIVA").Hidden = Not Reglas.Publicos.PreciosConIVA
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = Reglas.Publicos.PreciosConIVA
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = Not Reglas.Publicos.PreciosConIVA

         If Not _mostrarCosto Then
            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoSinIVA").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoConIVA").Hidden = True
         End If

         ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto", "CodigoDeBarras"})
      End Sub)
      TryCatched(Sub() PreferenciasLeer(ugDetalle, tsbPreferencias))
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
      Sub()
         If Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado Then
            txtCodigo.Focus()
         Else
            bscCodigoCliente.Focus()
         End If
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnBuscar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, String.Empty))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, String.Empty))
   End Sub
   '-.PE-31705.-
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
#Region "Eventos Buscador Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown, txtProducto.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            DirectCast(sender, Control).Focus()
            DirectCast(sender, TextBox).SelectAll()
         End If
      End Sub)
   End Sub
   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbMoneda.SelectedIndex = 0 Then
            txtCotizacionDolar.Enabled = False
            txtCotizacionDolar.SetValor(1D)
         Else
            txtCotizacionDolar.Enabled = True
            txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)
         End If
      End Sub)
   End Sub
   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub
#End Region

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         'Puede ser llamado por el enter antes de tiempo.
         If Not btnBuscar.Enabled Then Exit Sub
         '-.PE-31705.- Se quitan restricciones de producto.  Me.txtCodigo.Text.Trim().Length = 0 And Me.txtProducto.Text.Trim().Length = 0 And 
         'If _filtroMultiplesMarcas.Filtros.Count = 0 And _filtroMultiplesRubros.Filtros.Count = 0 And 
         If cmbMarcas.TodosSelected And cmbModelos.TodosSelected And
            cmbRubros.TodosSelected And cmbSubRubros.TodosSelected And cmbSubSubRubros.TodosSelected And
            Not chbConPrecio.Checked And Not chbConStock.Checked And Not chbInactivos.Checked Then
            ShowMessage("ATENCION: Debe elegir algún filtro para poder consultar.")
            txtProducto.Focus()
            Exit Sub
         End If
         CargarDatosGrilla()
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())

         cmbListasDePreciosCliente.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())
         txtDescuentoRecargoPorc.Text = dr.Cells("DescuentoRecargoPorc").Value.ToString()

         txtCategoriaFiscal.Text = dr.Cells("NombreCategoriaFiscal").Value.ToString()
         txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()

         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         txtDescuentoRecargoPorc.Enabled = True

         'Asigno al SelectedValue porque la numeracion de las listas, no necesamiente es correlativa y da error.
         cmbListasDePreciosCliente.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())
         cmbListasDePreciosCliente.Enabled = True

         'obtengo los datos de Clientes Marcas Listas de Precios
         Dim rMarcaLista = New Reglas.ClientesMarcasListasDePrecios()
         dgvMarcaListasPrecios.DataSource = rMarcaLista.ConsultaClientesMarcasListasDePrecios(Long.Parse(bscCodigoCliente.Tag.ToString()))

         Dim rMarcaDesc = New Reglas.ClientesDescuentosMarcas()
         dgvMarcasDescuentos.DataSource = rMarcaDesc.GetClientesDescuentosMarcas(Long.Parse(bscCodigoCliente.Tag.ToString()), False)

         Dim rSubRubroDesc = New Reglas.ClientesDescuentosSubRubros()
         dgvSubrubroDesc.DataSource = rSubRubroDesc.GetClientesDescuentosSubRubros(Long.Parse(bscCodigoCliente.Tag.ToString()))

         Dim rProdDesc = New Reglas.ClientesDescuentosProductos()
         ugdProductos.DataSource = rProdDesc.GetClientesDescuentosProductos(Long.Parse(bscCodigoCliente.Tag.ToString()), False)

         Dim clienteCatFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(dr.Cells("IdCategoriaFiscal").Value.ToString()))
         Dim empresaCatFiscal = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         If (clienteCatFiscal.IvaDiscriminado And empresaCatFiscal.IvaDiscriminado) Or
            Not clienteCatFiscal.UtilizaImpuestos Or Not empresaCatFiscal.UtilizaImpuestos Then

            If _mostrarCosto Then
               ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoSinIVA").Hidden = False
               ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoConIVA").Hidden = True
            End If

            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = True

         Else
            'Usa comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA

            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = False

            If _mostrarCosto Then
               ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoSinIVA").Hidden = True
               ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoConIVA").Hidden = False
            End If

         End If

         If Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado Then
            txtCodigo.Focus()
         Else
            txtProducto.Focus()
         End If

         btnBuscar.Enabled = True
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      txtCodigo.Text = String.Empty
      txtProducto.Text = String.Empty

      cmbSucursales.Refrescar()
      cmbMarcas.Refrescar()
      cmbRubros.Refrescar()

      If Not Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado Then
         bscCodigoCliente.Permitido = True
         bscCliente.Permitido = True
         bscCodigoCliente.Text = ""
         bscCliente.Text = ""
      End If

      cmbListasDePreciosCliente.Enabled = False
      cmbListasDePreciosCliente.SelectedIndex = -1

      txtDescuentoRecargoPorc.Enabled = False
      txtDescuentoRecargoPorc.Text = "0.00"

      txtCategoriaFiscal.Text = ""
      txtCategoria.Text = ""

      dgvMarcaListasPrecios.ClearFilas()
      dgvMarcasDescuentos.ClearFilas()
      dgvSubrubroDesc.ClearFilas()

      chbConPrecio.Checked = True
      chbConStock.Checked = False
      chbInactivos.Checked = False

      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("#0.00")

      cmbMoneda.SelectedIndex = 0

      btnBuscar.Enabled = Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      tbcCliente.SelectedTab = tbpCliente

      If Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado Then
         txtCodigo.Focus()
      Else
         bscCodigoCliente.Focus()
      End If
   End Sub
   Private Sub CargarDatosGrilla()
      Dim inicioProceso = Date.Now

      Dim rProd = New Reglas.Productos()
      Using dtDetalle = rProd.GetPrecios(cmbSucursales.GetSucursales().ToList(),
                                         cmbListasDePreciosCliente.ValorSeleccionado(-1I),
                                         cmbMarcas.GetMarcas(todosVacio:=True).ToList(), cmbModelos.GetModelos(todosVacio:=True).ToList(),
                                         cmbRubros.GetRubros(todosVacio:=True).ToList(), cmbSubRubros.GetSubRubros(todosVacio:=True).ToList(), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True).ToList(),
                                         txtCodigo.Text.Trim(), txtProducto.Text.Trim(),
                                         chbConPrecio.Checked, chbConStock.Checked, chbInactivos.Checked, False, "TODOS", "TODOS", "TODOS",
                                         cmbMoneda.ValorSeleccionado(0I), txtCotizacionDolar.ValorNumericoPorDefecto(0D),
                                         afectaStock:=Entidades.Publicos.SiNoTodos.TODOS.ToString())
         Dim dt = CrearDT()

         Dim simboloPesos = New Reglas.Monedas().GetUna(Entidades.Moneda.Peso).Simbolo
         Dim cliente = New Reglas.Clientes().GetUno(Long.Parse(bscCodigoCliente.Tag.ToString()))

         Dim cache = New Reglas.BusquedasCacheadas()
         'Cargo el cache antes de empezar la búsqueda para agilizar los calculos
         cache.BuscaClientesDescuentosMarcas(cliente.IdCliente, -1)
         cache.BuscaClientesDescuentosRubros(cliente.IdCliente, -1)
         cache.BuscaClientesDescuentosSubRubros(cliente.IdCliente, -1)
         cache.BuscaClientesDescuentosProductos(cliente.IdCliente, "")
         cache.BuscaCategoria(-1)
         cache.BuscaSubRubroEntidad(-1)
         cache.BuscaRubro(-1)

         Dim rCalcDescRec = New Reglas.CalculosDescuentosRecargos(cache)
         For Each dr In dtDetalle.AsEnumerable()

            Dim drCl = dt.NewRow()

            drCl("NombreSucursal") = dr("NombreSucursal").ToString()
            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("NombreMarca") = dr("NombreMarca").ToString()
            drCl("NombreRubro") = dr("NombreRubro").ToString()

            drCl("Alicuota") = Decimal.Parse(dr("Alicuota").ToString())
            drCl("DescRecProducto") = Decimal.Parse(dr("DescRecProducto").ToString())

            drCl("Simbolo") = dr("Simbolo").ToString()

            If _mostrarCosto Then
               drCl("PrecioCostoSinIVA") = Decimal.Round(Decimal.Parse(dr("PrecioCostoSinIVA").ToString()), 2) ' * FactorConversion, 2)
               drCl("PrecioCostoConIVA") = Decimal.Round(Decimal.Parse(dr("PrecioCostoConIVA").ToString()), 2) ' * FactorConversion, 2)
            End If

            Dim precioVentaSinIVA = Decimal.Parse(dr("PrecioVentaSinIVA").ToString())
            Dim precioVentaConIVA = Decimal.Parse(dr("PrecioVentaConIVA").ToString())

            'Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.


            Using dt1 = New Reglas.ClientesMarcasListasDePrecios().GetUno(Long.Parse(bscCodigoCliente.Tag.ToString()), Integer.Parse(dr("IdMarca").ToString()))
               If dt1.Rows.Count = 1 Then
                  Dim idListaDePrecio = Integer.Parse(dt1.Rows(0)("IdListaPrecios").ToString())
                  Using dt2 = New Reglas.Productos().GetPorCodigo(dr("IdProducto").ToString().Trim(), actual.Sucursal.Id, idListaDePrecio, "VENTAS")
                     precioVentaSinIVA = Decimal.Parse(dt2.Rows(0)("PrecioVentaSinIVA").ToString())
                     precioVentaConIVA = Decimal.Parse(dt2.Rows(0)("PrecioVentaConIVA").ToString())
                  End Using
               End If
            End Using

            'prod = produ.GetUno(dr("IdProducto").ToString().Trim())

            Dim descuentoGeneralDelCliente = rCalcDescRec.DescuentoRecargo(cliente, grabaLibro:=True, esPreElectronico:=False, formaPago:=Nothing, cantidadLineasVenta:=0)
            Dim descuentosProductos = rCalcDescRec.DescuentoRecargo(cliente, dr("IdProducto").ToString().Trim(), cantidad:=1, decimalesRedondeoEnPrecio:=2) ' 2 decimales para que coincida con la pantalla de facturacion

            drCl("PrecioVentaSinIVA") = rCalcDescRec.GetPreciosConDescuentos(precioVentaSinIVA, descuentoGeneralDelCliente, descuentosProductos.DescuentoRecargo1, descuentosProductos.DescuentoRecargo2, 1)
            drCl("PrecioVentaConIVA") = rCalcDescRec.GetPreciosConDescuentos(precioVentaConIVA, descuentoGeneralDelCliente, descuentosProductos.DescuentoRecargo1, descuentosProductos.DescuentoRecargo2, 1)

            drCl("DescRecProductoCalculado") = GetDescuentosProductoCalculado(descuentoGeneralDelCliente, descuentosProductos.DescuentoRecargo1, descuentosProductos.DescuentoRecargo2, 2)

            If Not String.IsNullOrEmpty(dr("Stock").ToString()) Then
               drCl("Stock") = Decimal.Parse(dr("Stock").ToString())
            End If

            drCl("FechaActualizacion") = Date.Parse(dr("FechaActualizacion").ToString())
            drCl("CodigoDeBarras") = dr("CodigoDeBarras").ToString()

            drCl("Activo") = Boolean.Parse(dr("Activo").ToString())

            dt.Rows.Add(drCl)

         Next

         If Not _mostrarCosto Then
            dt.Columns.Remove("PrecioCostoSinIVA")
            dt.Columns.Remove("PrecioCostoConIVA")
            'dt.Columns.Remove("CostoEmbalajeSinIVA")
            'dt.Columns.Remove("CostoEmbalajeConIVA")
         End If

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = (cmbSucursales.GetSucursales().Count = 1)

         If chbInactivos.Checked Then
            ugDetalle.DisplayLayout.Bands(0).Columns("Activo").Hidden = False
         Else
            ugDetalle.DisplayLayout.Bands(0).Columns("Activo").Hidden = True
         End If

         ugDetalle.DataSource = dt
      End Using

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      If ugDetalle.Rows.Count > 0 Then
         ugDetalle.Focus()
      End If

   End Sub

   Private Function GetDescuentosProductoCalculado(descuentoGeneral As Decimal, descuento1 As Decimal, descuento2 As Decimal, decimalesRedondeoEnPrecio As Integer) As Decimal
      Dim result As Decimal
      result = Reglas.CalculosDescuentosRecargos.CombinaDosDescuentos(descuentoGeneral, descuento1, decimalesRedondeoEnPrecio)
      result = Reglas.CalculosDescuentosRecargos.CombinaDosDescuentos(result, descuento2, decimalesRedondeoEnPrecio)
      Return result
   End Function

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("Alicuota", GetType(Decimal))
         .Columns.Add("Simbolo", GetType(String))
         .Columns.Add("PrecioCostoSinIVA", GetType(Decimal))
         .Columns.Add("PrecioCostoConIVA", GetType(Decimal))
         .Columns.Add("PrecioVentaSinIVA", GetType(Decimal))
         .Columns.Add("PrecioVentaConIVA", GetType(Decimal))
         .Columns.Add("Stock", GetType(Decimal))
         .Columns.Add("FechaActualizacion", GetType(Date))
         .Columns.Add("CodigoDeBarras", GetType(String))
         .Columns.Add("Activo", GetType(Boolean))
         .Columns.Add("NombreSucursal", GetType(String))
         .Columns.Add("DescRecProducto", GetType(Decimal))
         .Columns.Add("DescRecProductoCalculado", GetType(Decimal))
      End With
      Return dtTemp
   End Function
#End Region
End Class