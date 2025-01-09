Public Class ConsultarPreciosPorProducto

#Region "Campos"

   Private _publicos As Publicos
   Private _consultarPreciosConIVA As Boolean
   Private _codigoBarrasCompleto As String
   Private _cantidad As Decimal

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            tbcPrecioProducto.SelectedTab = tpgMultiple
            tbcPrecioProducto.SelectedTab = tpgStock
            tbcPrecioProducto.SelectedTab = tpgLista

            _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
            _consultarPreciosConIVA = Reglas.Publicos.ConsultarPreciosConIVA

            '-.PE-31632.-
            If Not Reglas.Publicos.MuestraFechaDeActualizacion Then
               txtFechaActProd.Visible = False
               LblFechaActProd.Visible = False
            End If
            _publicos.CargaComboDesdeEnum(cmbTipoDeposito, GetType(Entidades.SucursalDeposito.TiposDepositos))
            cmbTipoDeposito.SelectedIndex = 0

            RefrescarDatosGrilla()
         End Sub)

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
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
            txtCodigo.Text = String.Empty
            bscProducto2.Text = String.Empty
            bscProducto2.Tag = String.Empty

            RefrescarDatosGrilla()

            txtCodigo.Select()
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter Then
               btnBuscar_Click(btnBuscar, Nothing)
            End If
         End Sub)
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
         Sub()
            If txtCodigo.Text.Trim().Length = 0 Then
               ShowMessage("ATENCION: Debe elegir algún Producto para poder Consultar.")
               txtCodigo.Select()
               Exit Sub
            End If

            RefrescarDatosGrilla()
            CargarDatosProducto()
            CargaGrillaDetalle()
            GrabarHistorialConsulta()
            CargaStockDeposito()

            If txtCodigo.Text.Trim().Length > 0 Then
               txtCodigo.Select()
               txtCodigo.SelectAll()
            End If
         End Sub,
         onErrorAction:=
         Sub(owner, ex)
            If TypeOf (ex) Is ProductoInexistenteException Then
               Using frm As New AvisoProductoInexistente()
                  frm.ShowDialog()
               End Using
            Else
               ShowError(ex)
            End If
         End Sub)
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged
      TryCatched(Sub() PrecioUnaLista(_cantidad))
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
         End Sub)
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscProducto2.Text = e.FilaDevuelta.Cells("NombreProducto").Value.ToString()
               txtCodigo.Text = e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
               btnBuscar_Click(btnBuscar, Nothing)
            End If
         End Sub)
   End Sub


#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      txtCodigo.Tag = String.Empty
      txtNombreProducto.Text = String.Empty
      txtNombreProductoII.Text = String.Empty
      txtNombreMarca.Text = String.Empty
      txtNombreRubro.Text = String.Empty
      txtStock.Text = "0.00"
      txtCodigoDeBarras.Text = String.Empty
      txtAlicuota.Text = "0.00"
      txtMoneda.Text = String.Empty
      lblDescripcion.Visible = False
      txtPrecio.Visible = False
      lblOferta.Visible = False
      txtCantidad.Visible = False

      ugvPrecios.ClearFilas()
      ugStockDepositos.ClearFilas()

      tssRegistros.Text = ugvPrecios.CantidadRegistrosParaStatusbar

      LblFechaActProd.Text = "Ultima actualización"
      txtFechaActProd.Text = String.Empty
      txtCodigo.Select()

   End Sub

   Private Class ProductoInexistenteException
      Inherits ApplicationException
   End Class

   Private Sub CargarDatosProducto()

      Dim orProd = New Reglas.Productos()
      _codigoBarrasCompleto = Me.txtCodigo.Text.Trim()

      If Not orProd.Existe(txtCodigo.Text, Entidades.Publicos.SiNoTodos.SI) And Not orProd.ExisteCodigoDeBarras(txtCodigo.Text, Entidades.Publicos.SiNoTodos.SI) Then
         Throw New ProductoInexistenteException()
      End If

      Dim ProdSuc = New Reglas.ProductosSucursales().GetUnoCB(actual.Sucursal.Id, Me.txtCodigo.Text.Trim())

      txtNombreProducto.Text = ProdSuc.Producto.NombreProducto
      txtNombreProductoII.Text = ProdSuc.Producto.NombreProducto
      bscProducto2.Text = txtNombreProducto.Text
      txtNombreMarca.Text = New Reglas.Marcas().GetUna(ProdSuc.Producto.IdMarca).NombreMarca
      txtNombreRubro.Text = New Reglas.Rubros().GetUno(ProdSuc.Producto.IdRubro).NombreRubro
      txtStock.Text = ProdSuc.Stock.ToString("##,##0.00")
      txtCodigoDeBarras.Text = ProdSuc.Producto.CodigoDeBarras
      txtAlicuota.Text = ProdSuc.Producto.Alicuota.ToString("##,##0.00")
      txtMoneda.Text = ProdSuc.Producto.Moneda.NombreMoneda
      Dim esCodigo As Boolean = False

      If ProdSuc.Producto.IdProducto = _codigoBarrasCompleto Then
         esCodigo = True
      End If

      If Not ProdSuc.Producto.CodigoDeBarrasConPrecio And Not esCodigo Then
         _codigoBarrasCompleto = ProdSuc.Producto.IdProducto
      End If

      txtCantidad.Text = Decimal.Round(Me.GetPrecioModalidadPeso(esCodigo, ProdSuc.Producto.CodigoDeBarrasConPrecio), 2).ToString("##,##0.000")

      'Si busco por el codigo de barras, luego la grabacion da error por FK inexistente.
      txtCodigo.Tag = ProdSuc.Producto.IdProducto

      '-- REQ-40289.-
      txtCodigo.Text = ProdSuc.Producto.IdProducto
         txtCodigo.Tag = ProdSuc.Producto.CodigoDeBarras



      picBoxProducto.Image = orProd.GetUno(ProdSuc.Producto.IdProducto, incluirFoto:=True).Foto

      If picBoxProducto.Image Is Nothing Then
         picBoxProducto.Visible = False
      Else
         picBoxProducto.Visible = True
      End If
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("NombreListaPrecios", GetType(String))
         .Columns.Add("PrecioVentaSinIVA", GetType(Decimal))
         .Columns.Add("PrecioVentaConIVA", GetType(Decimal))
         .Columns.Add("FechaActualizacion", GetType(Date))
      End With
      Return dtTemp
   End Function
   Private Sub CargaGrillaDetalle()
      Dim rProd = New Reglas.Productos()

      _cantidad = Decimal.Parse(IIf(Decimal.Parse(txtCantidad.Text.ToString()) = 0, 1, Decimal.Parse(txtCantidad.Text.ToString())).ToString())
      txtCantidad.Visible = _cantidad <> 1

      Using dtDetalle = rProd.GetPreciosSoloPorCodigoLista(actual.Sucursal.IdSucursal, txtCodigo.Text.Trim(), idListaPrecios:=Nothing, activo:=True)
         Dim dt = CrearDT()
         dtDetalle.AsEnumerable().ToList().
            ForEach(Sub(dr) dt.Rows.Add(dr("NombreListaPrecios"), Decimal.Parse(dr("PrecioVentaSinIVA").ToString()) * _cantidad, Decimal.Parse(dr("PrecioVentaConIVA").ToString()) * _cantidad, dr("FechaActualizacion")))
         ugvPrecios.DataSource = dt
      End Using

      ugvPrecios.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = _consultarPreciosConIVA
      ugvPrecios.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = Not _consultarPreciosConIVA

      PrecioUnaLista(_cantidad)

      tssRegistros.Text = ugvPrecios.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub PrecioUnaLista(cantidad As Decimal)
      Dim oProd = New Reglas.Productos()
      Using dtDetalle2 = oProd.GetPreciosSoloPorCodigoLista(actual.Sucursal.Id, txtCodigo.Text.Trim(), cmbListaDePrecios.ValorSeleccionado(0I), activo:=True)

         If dtDetalle2.Any() Then
            Dim drDetalle2 = dtDetalle2.First()
            lblDescripcion.Text = drDetalle2.Field(Of String)("NombreProducto")
            lblDescripcion.Visible = True
            If _consultarPreciosConIVA Then
               txtPrecio.Text = (drDetalle2.Field(Of Decimal?)("PrecioVentaConIVA").IfNull() * cantidad).ToString("N2")
            Else
               txtPrecio.Text = (drDetalle2.Field(Of Decimal?)("PrecioVentaSinIVA").IfNull() * cantidad).ToString("N2")
            End If
            lblOferta.Visible = drDetalle2.Field(Of Boolean)("Oferta")
            If lblOferta.Visible Then
               LblFechaActProd.Text = "Vigencia"
               ugvPrecios.DisplayLayout.Bands(0).Columns("FechaActualizacion").Header.Caption = "Vigencia"
            Else
               LblFechaActProd.Text = "Ultima Actualización"
               ugvPrecios.DisplayLayout.Bands(0).Columns("FechaActualizacion").Header.Caption = "Fecha Actualización"
            End If

            txtFechaActProd.Text = drDetalle2.Field(Of Date?)("FechaActualizacion").ToStringFormat("dd/MM/yyyy HH:mm")
            txtPrecio.Visible = True

         End If
      End Using
   End Sub

   Private Sub GrabarHistorialConsulta()
      Dim ohistorialConsProd = New Reglas.HistorialConsultaProductos()
      ohistorialConsProd.Grabar(txtCodigo.Text.ToString(), actual.Sucursal.IdSucursal, Date.Now, actual.Nombre)
   End Sub

   Private Function GetPrecioModalidadPeso(esCodigo As Boolean, conPrecio As Boolean) As Decimal
      If Not esCodigo AndAlso conPrecio Then
         Return Decimal.Parse(_codigoBarrasCompleto.Substring(Reglas.Publicos.CaracteresProductoCBPesoCantidad,
                                                              12 - Reglas.Publicos.CaracteresProductoCBPesoCantidad).
                                                    Insert(12 - Reglas.Publicos.CaracteresProductoCBPesoCantidad - 3, "."))
      Else
         Return 0
      End If
   End Function

   Private Sub CargaStockDeposito()
      '-- Carga Stock y Distribucion de Producto en Suc-Dep-Ubi.-
      ugStockDepositos.DataSource = New Reglas.Productos().GetProductosDepositos(txtCodigo.Text.ToString(), actual.Sucursal.IdSucursal, cmbTipoDeposito.Text)
      ugStockDepositos.AgregarTotalesSuma({"Stock"})
      ugStockDepositos.AgregarFiltroEnLinea({"TipoDeposito"})
      '----------------------------------------------------------
   End Sub

   Private Sub cmbTipoDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDeposito.SelectedIndexChanged
      TryCatched(
         Sub()
            If Not String.IsNullOrEmpty(txtCodigo.Text) Then
               btnBuscar_Click(btnBuscar, Nothing)
            End If
         End Sub)
   End Sub

#End Region

End Class