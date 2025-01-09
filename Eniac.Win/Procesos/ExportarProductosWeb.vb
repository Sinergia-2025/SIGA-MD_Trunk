Public Class ExportarProductosWeb

#Region "Campos"

   Private _publicos As Publicos
   Private _Productos As List(Of Entidades.Producto)
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _filtroMultiplesSubRubros As MFSubRubros
   Private _filtroMultiplesSubSubRubros As MFSubSubRubros
   Private _EmbalajeNormal As Boolean = Not Publicos.ProductoEmbalajeHaciaArriba
   Private _ProdWeb As Reglas.ProductosWebArchivo
   Private _Prod As DataTable = New DataTable()
   Private _carpetaImagenes As String
   Private _busquedaSucursal As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _Productos = New List(Of Entidades.Producto)

         _filtroMultiplesMarcas = New MFMarcas()
         _filtroMultiplesRubros = New MFRubros()
         _filtroMultiplesSubRubros = New MFSubRubros()
         _filtroMultiplesSubSubRubros = New MFSubSubRubros()

         If Reglas.Publicos.ProductoTieneSubRubro Then
            lnkFiltroMultiplesSubRubros.Visible = True
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = False
         End If

         If Reglas.Publicos.ProductoTieneSubSubRubro Then
            lnkFiltroMultiplesSubSubRubros.Visible = True
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = False
         End If

         If Reglas.Publicos.ProductoUtilizaProductoWeb Then
            ugDetalle.DisplayLayout.Bands(0).Columns("Caracteristica1").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("Caracteristica2").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("Caracteristica3").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("ValorCaracteristica1").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("ValorCaracteristica2").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("ValorCaracteristica3").Hidden = False
         End If


         _publicos.CargaComboSubRubros(cmbSubRubro)
         _publicos.CargaComboListaDePrecios(cmbListaPrecios)

         '-.PE-32135.-
         _publicos.CargaComboSucursales(cmbSucursal)
         cmbSucursal.SelectedValue = actual.Sucursal.IdSucursal
         _publicos.CargaComboListaDePrecios(cmbListaPreciosMayorista)

         _publicos.CargaComboMonedas1(cmbMoneda,
                                         agregarAlPrincipio:={New Entidades.Moneda() With {.IdMoneda = -1, .NombreMoneda = "del producto"}},
                                         agregarAlFinal:={})

         cmbMoneda.SelectedValue = Reglas.Publicos.ExportarPrecioProductoUsandoMoneda

         _publicos.CargaComboDesdeEnum(cmbPublicarEnGestion, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnEmpresarial, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnTiendaNube, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnMercadoLibre, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnWeb, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnArborea, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnBalanza, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnSincronizarSucursal, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbPublicarEnListaDePreciosParaClientes, Entidades.Publicos.SiNoTodos.TODOS)

         _publicos.CargaComboDesdeEnum(cmbTipoInforme, Entidades.EnumSql.Stock_TipoReporte.General)

         _publicos.CargaComboDesdeEnum(cmbSubirImagenes, GetType(Entidades.Publicos.SiNo))
         cmbSubirImagenes.SelectedValue = If(cmbFormato.Text = Reglas.Publicos.FTPFormato, Entidades.Publicos.SiNo.SI, Entidades.Publicos.SiNo.NO)

         _publicos.CargaComboDesdeEnum(cmbEnviando, GetType(Entidades.Producto.ExportarEnviando))
         cmbEnviando.SelectedValue = Entidades.Producto.ExportarEnviando.TODOS

         _publicos.CargaComboDesdeEnum(cmbAfectaStock, GetType(Entidades.Publicos.SiNoTodos))
         cmbAfectaStock.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbActivo, GetType(Entidades.Publicos.SiNoTodos))
         cmbActivo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbEsDeCompras, GetType(Entidades.Publicos.SiNoTodos))
         cmbEsDeCompras.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbEsDeVentas, GetType(Entidades.Publicos.SiNoTodos))
         cmbEsDeVentas.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbEsServicio, GetType(Entidades.Publicos.SiNoTodos))
         cmbEsServicio.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPagaIngBrutos, GetType(Entidades.Publicos.SiNoTodos))
         cmbPagaIngBrutos.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPermiteModDesc, GetType(Entidades.Publicos.SiNoTodos))
         cmbPermiteModDesc.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbFormato, GetType(Entidades.Producto.FormatosProductos))
         cmbFormato.SelectedValue = Entidades.Producto.FormatosProductos.Web

         chbConIVA.Checked = Reglas.Publicos.ExportarPreciosConIVA

         _carpetaImagenes = Entidades.Publicos.CarpetaEniac + "ImagenesWeb\"

         txtRedondeoDecimales.Text = Reglas.Publicos.ExportarProductosDecimalesRedondeoEnPrecio.ToString()

         txtProducto.Focus()
         FiltersManager1.Refrescar()
      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(Sub() ExportarDatos())
   End Sub
   Private Sub tsbSubirArchivosALaWeb_Click(sender As Object, e As EventArgs) Handles tsbSubirArchivosALaWeb.Click
      TryCatched(
      Sub()
         tssInfo.Text = "Subiendo archivos al servidor."

         Dim carpetaImagenes = IO.Path.Combine(Entidades.Publicos.CarpetaEniac, "ImagenesWeb")
         DirectCast(ugDetalle.DataSource, DataTable).AcceptChanges()
         Using frm As New ExportarProductosWebInformacionProgresoSubida()
            frm.ShowDialog(Me, DirectCast(ugDetalle.DataSource, DataTable), carpetaImagenes, txtArchivoDestino.Text)
         End Using
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub

   Private Sub lnkFiltroMultiplesMarcas_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesMarcas.LinkClicked
      TryCatched(
      Sub()
         _filtroMultiplesMarcas.ShowDialog()
         If _filtroMultiplesMarcas.Filtros.Count = 0 Then
            lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
         ElseIf _filtroMultiplesMarcas.Filtros.Count = 1 Then
            lnkFiltroMultiplesMarcas.Text = _filtroMultiplesMarcas.Filtros(0).NombreMarca
         Else
            lnkFiltroMultiplesMarcas.Text = "Algunas Marcas"
         End If
      End Sub)
   End Sub

   Private Sub lnkFiltroMultiplesRubros_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesRubros.LinkClicked
      TryCatched(
      Sub()
         _filtroMultiplesRubros.ShowDialog()
         If _filtroMultiplesRubros.Filtros.Count = 0 Then
            lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
         ElseIf _filtroMultiplesRubros.Filtros.Count = 1 Then
            lnkFiltroMultiplesRubros.Text = _filtroMultiplesRubros.Filtros(0).NombreRubro
         Else
            lnkFiltroMultiplesRubros.Text = "Algunos Rubros"
         End If
      End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         For Each dr As UltraGridRow In ugDetalle.Rows
            dr.Cells("Check").Value = chbTodos.Checked
         Next
      End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         chbTodos.Checked = False
         tsbExportar.Enabled = True
         tsbSubirArchivosALaWeb.Enabled = False
         If chbFechaActualizado.Checked And dtpDesde.Value > dtpHasta.Value Then
            ShowMessage("ATENCION: Rango Invalido de fecha.")
            dtpDesde.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub


   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(Sub() ugDetalle.PerformAction(UltraGridAction.ExitEditMode))
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         Using DialogoGuardarArchivo As New SaveFileDialog()
            If cmbFormato.SelectedIndex = 0 Or cmbFormato.SelectedIndex = 1 Then
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
            ElseIf cmbFormato.SelectedIndex = 2 Or cmbFormato.SelectedIndex = 3 Then
               DialogoGuardarArchivo.Filter = "Archivos de Excel (*.xls)|*.xls|Todos los Archivos (*.*)|*.*"
            End If
            DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            DialogoGuardarArchivo.FilterIndex = 1
            DialogoGuardarArchivo.RestoreDirectory = True

            If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               Try
                  If DialogoGuardarArchivo.FileName <> "" Then
                     Me.txtArchivoDestino.Text = DialogoGuardarArchivo.FileName
                  End If
               Catch Ex As Exception
                  MessageBox.Show(Ex.Message)
               End Try
            End If
         End Using
      End Sub)
   End Sub

   Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown, txtProducto.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnConsultar.PerformClick()
      End If
   End Sub

   Private Sub chbFechaActualizado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaActualizado.CheckedChanged
      TryCatched(
      Sub()
         dtpDesde.Enabled = chbFechaActualizado.Checked
         dtpHasta.Enabled = chbFechaActualizado.Checked
         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
         If chbFechaActualizado.Checked Then
            dtpDesde.Focus()
         End If
      End Sub)
   End Sub

   Private Sub cmbFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormato.SelectedIndexChanged
      TryCatched(
      Sub()
         MostrarNombreArchivo()
         If cmbFormato.Text = Reglas.Publicos.FTPFormato Then
            cmbSubirImagenes.SelectedIndex = 0
            cmbSubirImagenes.Enabled = True
         Else
            cmbSubirImagenes.SelectedIndex = 1
            cmbSubirImagenes.Enabled = False
         End If
         cmbEnviando.Enabled = cmbSubirImagenes.Enabled
         dtpEnviando.Enabled = cmbSubirImagenes.Enabled And
                               DirectCast(cmbEnviando.SelectedValue, Entidades.Producto.ExportarEnviando) = Entidades.Producto.ExportarEnviando.FECHAENVIO
         If cmbFormato.SelectedIndex = 9 Then
            cmbListaPreciosMayorista.Enabled = True
            _busquedaSucursal = True
         Else
            cmbListaPreciosMayorista.Enabled = False
            _busquedaSucursal = False
         End If
         '-- REQ-35886.- --------------------------------------------------------------------------------
         With ugDetalle.DisplayLayout.Bands(0)
            .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).Hidden = Not (cmbFormato.SelectedValue.ToString() Is Entidades.Producto.FormatosProductos.ParaSucursales.ToString() Or
                                                                                              cmbFormato.SelectedValue.ToString() Is Entidades.Producto.FormatosProductos.ParaClientes.ToString() Or
                                                                                              cmbFormato.SelectedValue.ToString() Is Entidades.Producto.FormatosProductos.NEO.ToString())
            .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).Header.VisiblePosition = 3
         End With
         '-----------------------------------------------------------------------------------------------
      End Sub)
   End Sub

   Private Sub cmbListaPrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaPrecios.SelectedIndexChanged
      TryCatched(Sub() MostrarNombreArchivo())
   End Sub

   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbMoneda.SelectedIndex = 0 Then
            txtTipoCambio.Enabled = False
            txtTipoCambio.Text = "1.00"
         Else
            txtTipoCambio.Enabled = True
            txtTipoCambio.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
         End If
      End Sub)
   End Sub

   Private Sub lnkFiltroMultiplesSubRubros_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesSubRubros.LinkClicked
      TryCatched(
      Sub()
         _filtroMultiplesSubRubros.ShowDialog()
         If _filtroMultiplesSubRubros.Filtros.Count = 0 Then
            lnkFiltroMultiplesSubRubros.Text = "Todos los SubRubros"
         ElseIf _filtroMultiplesSubRubros.Filtros.Count = 1 Then
            lnkFiltroMultiplesSubRubros.Text = Me._filtroMultiplesSubRubros.Filtros(0).NombreSubRubro
         Else
            lnkFiltroMultiplesSubRubros.Text = "Algunos SubRubros"
         End If
      End Sub)
   End Sub

   Private Sub lnkFiltroMultiplesSubSubRubros_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesSubSubRubros.LinkClicked
      TryCatched(
      Sub()
         _filtroMultiplesSubSubRubros.ShowDialog()
         If _filtroMultiplesSubSubRubros.Filtros.Count = 0 Then
            lnkFiltroMultiplesSubSubRubros.Text = "Todos los SubSubRubros"
         ElseIf _filtroMultiplesSubSubRubros.Filtros.Count = 1 Then
            lnkFiltroMultiplesSubSubRubros.Text = Me._filtroMultiplesSubSubRubros.Filtros(0).NombreSubSubRubro
         Else
            lnkFiltroMultiplesSubSubRubros.Text = "Algunos SubSubRubros"
         End If
      End Sub)
   End Sub

   Private Sub cmbEnviando_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEnviando.SelectedIndexChanged
      TryCatched(
      Sub()
         If TypeOf (cmbEnviando.SelectedValue) Is Entidades.Producto.ExportarEnviando Then
            dtpEnviando.Enabled = DirectCast(cmbEnviando.SelectedValue, Entidades.Producto.ExportarEnviando) = Entidades.Producto.ExportarEnviando.FECHAENVIO
         End If
      End Sub)
   End Sub

   Private Sub tsbFiltros_Click(sender As Object, e As EventArgs) Handles tsbFiltros.Click
      TryCatched(Sub() FiltersManager1.SeleccionarFiltro())
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      txtCodigo.Text = String.Empty
      txtProducto.Text = String.Empty

      If _filtroMultiplesMarcas.dgvDatos.DataSource IsNot Nothing Then
         _filtroMultiplesMarcas.Filtros.Clear()
         _filtroMultiplesMarcas.dgvDatos.DataSource = _filtroMultiplesMarcas.Filtros.ToArray()
         lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
      End If

      If _filtroMultiplesRubros.dgvDatos.DataSource IsNot Nothing Then
         _filtroMultiplesRubros.Filtros.Clear()
         _filtroMultiplesRubros.dgvDatos.DataSource = _filtroMultiplesRubros.Filtros.ToArray()
         lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
      End If

      If _filtroMultiplesSubRubros.dgvDatos.DataSource IsNot Nothing Then
         _filtroMultiplesSubRubros.Filtros.Clear()
         _filtroMultiplesSubRubros.dgvDatos.DataSource = _filtroMultiplesSubRubros.Filtros.ToArray()
         lnkFiltroMultiplesSubRubros.Text = "Todos los SubRubros"
      End If

      If _filtroMultiplesSubSubRubros.dgvDatos.DataSource IsNot Nothing Then
         _filtroMultiplesSubSubRubros.Filtros.Clear()
         _filtroMultiplesSubSubRubros.dgvDatos.DataSource = _filtroMultiplesSubSubRubros.Filtros.ToArray()
         lnkFiltroMultiplesSubSubRubros.Text = "Todos los SubSubRubros"
      End If

      cmbAfectaStock.SelectedIndex = 0
      cmbActivo.SelectedIndex = 0
      txtEmbalaje.Text = "0"

      cmbEsDeCompras.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbEsDeVentas.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbEsServicio.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPagaIngBrutos.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPermiteModDesc.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnGestion.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnEmpresarial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnTiendaNube.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnMercadoLibre.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnArborea.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnWeb.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnBalanza.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnSincronizarSucursal.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPublicarEnListaDePreciosParaClientes.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbMoneda.SelectedIndex = 0

      cmbTipoInforme.SelectedValue = Entidades.EnumSql.Stock_TipoReporte.General

      cmbMoneda.SelectedValue = Reglas.Publicos.ExportarPrecioProductoUsandoMoneda

      chbSubRubro.Checked = False
      chbFechaActualizado.Checked = False

      tsbExportar.Enabled = False
      tsbSubirArchivosALaWeb.Enabled = False
      tssInfo.Text = String.Empty

      ugDetalle.ClearFilas()

      chbTodos.Checked = False

      '-.PE-32135.-
      cmbSucursal.SelectedValue = actual.Sucursal.Id
      cmbListaPreciosMayorista.SelectedIndex = 0

      chbConIVA.Checked = Reglas.Publicos.ExportarPreciosConIVA

      txtRedondeoDecimales.Text = Reglas.Publicos.ExportarProductosDecimalesRedondeoEnPrecio.ToString()

      btnConsultar.Focus()
      FiltersManager1.Refrescar()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idSubRubro As Integer = 0
      Dim fechaActDesde As Date = Nothing
      Dim fechaActHasta As Date = Nothing

      If chbFechaActualizado.Checked Then
         fechaActDesde = dtpDesde.Value
         fechaActHasta = dtpHasta.Value
      End If

      Dim rRegProductos = New Reglas.Productos()

      If chbSubRubro.Checked Then
         idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      Dim publicarEn = New Entidades.Filtros.ProductosPublicarEnFiltros With {
         .Gestion = cmbPublicarEnGestion.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .Empresarial = cmbPublicarEnEmpresarial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .TiendaNube = cmbPublicarEnTiendaNube.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .MercadoLibre = cmbPublicarEnMercadoLibre.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .Arborea = cmbPublicarEnArborea.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .Web = cmbPublicarEnWeb.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .Balanza = cmbPublicarEnBalanza.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .SincronizacionSucursal = cmbPublicarEnSincronizarSucursal.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
         .ListaPrecioCliente = cmbPublicarEnListaDePreciosParaClientes.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      }

      Dim dtDetalle = rRegProductos.GetProductosParaExportar(
                           txtCodigo.Text, txtProducto.Text,
                           _filtroMultiplesMarcas.Filtros, _filtroMultiplesRubros.Filtros,
                           idSubRubro,
                           txtEmbalaje.ValorNumericoPorDefecto(0I),
                           cmbAfectaStock.Text,
                           cmbActivo.Text, cmbEsServicio.Text, cmbEsDeCompras.Text,
                           cmbEsDeVentas.Text, cmbPagaIngBrutos.Text, cmbPermiteModDesc.Text,
                           cmbSucursal.ValorSeleccionado(0I),
                           cmbListaPrecios.ValorSeleccionado(0I),
                           cmbMoneda.ValorSeleccionado(0I),
                           txtTipoCambio.ValorNumericoPorDefecto(0D),
                           fechaActDesde, fechaActHasta, publicarEn,
                           _filtroMultiplesSubRubros.Filtros, _filtroMultiplesSubSubRubros.Filtros,
                           chbConIVA.Checked,
                           If(IsNumeric(txtRedondeoDecimales.Text), txtRedondeoDecimales.ValorNumericoPorDefecto(0I), Reglas.Publicos.ExportarProductosDecimalesRedondeoEnPrecio),
                           If(cmbEnviando.Enabled, cmbEnviando.ValorSeleccionado(Of Entidades.Producto.ExportarEnviando), Entidades.Producto.ExportarEnviando.TODOS),
                           dtpEnviando.Value,
                           cmbSubirImagenes.SelectedItem.ToString() = "SI",
                           cmbFormato.ValorSeleccionado(Of Entidades.Producto.FormatosProductos),
                           cmbListaPreciosMayorista.ValorSeleccionado(0I),
                           cmbTipoInforme.ValorSeleccionado(Of Entidades.EnumSql.Stock_TipoReporte))

      _Prod = dtDetalle.Clone()

      ugDetalle.DataSource = dtDetalle

      With ugDetalle.DisplayLayout.Bands(0)
         Dim format = String.Format("N{0}", txtRedondeoDecimales.Text)
         .Columns("PrecioCosto").Format = format
         .Columns("PrecioVenta").Format = format
      End With

      'GAR: 01/02/2017 - No hay datos que cambien en el nombre de archivo luego de consultar.
      'Me.MostrarNombreArchivo()
      '----
   End Sub

   Private Sub CrearProductosWeb()
      Try
         If cmbFormato.SelectedIndex = 1 Then 'DonWeb
            _ProdWeb = New Reglas.ProductosDonWeb()
         ElseIf cmbFormato.SelectedIndex = 0 Then 'Web
            _ProdWeb = New Reglas.ProductosWebArchivo()
         ElseIf cmbFormato.SelectedIndex = 4 Then 'Qendra
            _ProdWeb = New Reglas.ProductosQendra()
         ElseIf cmbFormato.SelectedIndex = 5 Then 'WebExperto
            _ProdWeb = New Reglas.ProductosWebExperto()
         ElseIf cmbFormato.SelectedIndex = 6 Then 'iTegra/Kretz
            _ProdWeb = New Reglas.ProductosiTegraKretz()
         ElseIf cmbFormato.SelectedIndex = 7 Then 'WooCommerceCompacto/
            _ProdWeb = New Reglas.ProductosWooCommerceCompacto()
         ElseIf cmbFormato.SelectedIndex = 8 Then 'Dabadoo
            _ProdWeb = New Reglas.ProductosDabadoo()
         ElseIf cmbFormato.SelectedIndex = 9 Then 'Arborea
            _ProdWeb = New Reglas.ProductosArborea()
         ElseIf cmbFormato.SelectedIndex = 10 Then 'WooCommerceSimple/
            _ProdWeb = New Reglas.ProductosWooCommerceSimple()
         ElseIf cmbFormato.SelectedIndex = 11 Then 'NEO
            _ProdWeb = New Reglas.ProductosNEO()
         ElseIf cmbFormato.SelectedIndex = 12 Then 'Mi Tienda
            _ProdWeb = New Reglas.ProductosMiTienda()
         ElseIf cmbFormato.SelectedIndex = 13 Then 'iTegraConVenc
            _ProdWeb = New Reglas.ProductosiTegraConVenc()
         End If

         'Habilito el boton de subir al FTP si es configurado.
         If cmbFormato.Text = Reglas.Publicos.FTPFormato Then
            tsbSubirArchivosALaWeb.Enabled = True
         End If

         'Dim linea As Reglas.ProductosWebLinea

         tspBarra.Visible = True
         tspBarra.Minimum = 0
         tspBarra.Maximum = ugDetalle.Rows.Count
         tspBarra.Value = 0

         Dim regPro = New Reglas.ProductosWeb()

         regPro.CrearProductosWeb(ugDetalle.DataSource(Of DataTable), _ProdWeb, _carpetaImagenes)
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try
   End Sub

   Private Sub ExportarDatos()
      Dim stb = New StringBuilder()
      Dim cant = 0I

      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
            cant += 1
         End If
      Next

      If cant = 0 Then
         MessageBox.Show("No selecciono ningún Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Exit Sub
      End If

      stb.AppendFormat("¿Realmente desea generar el archivo para los {0} productos?", cant)

      If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

         If Me.cmbFormato.SelectedIndex = 0 Then 'Web
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
         ElseIf Me.cmbFormato.SelectedIndex = 1 Then 'DonWeb
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
         ElseIf Me.cmbFormato.SelectedIndex = 2 Then 'Para Sucursales
            ExportarSucursal()
         ElseIf Me.cmbFormato.SelectedIndex = 3 Then 'Para Clientes
            ExportarCliente()
         ElseIf Me.cmbFormato.SelectedIndex = 4 Then 'Qendra
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivoQendra(Me.txtArchivoDestino.Text)
         ElseIf Me.cmbFormato.SelectedIndex = 5 Then 'WebExperto
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivoWebExperto(Me.txtArchivoDestino.Text)
         ElseIf Me.cmbFormato.SelectedIndex = 6 Then 'iTegra/Kretz
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivoWebExperto(Me.txtArchivoDestino.Text)
         ElseIf Me.cmbFormato.SelectedIndex = 7 Then 'WooCommerceCompacto
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
         ElseIf Me.cmbFormato.SelectedIndex = 8 Then 'Dabadoo
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
            'Nuevo
         ElseIf Me.cmbFormato.SelectedIndex = 9 Then 'Arborea
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
         ElseIf Me.cmbFormato.SelectedIndex = 10 Then 'WooCommerceSimple
            '-- REG-35639.- -----------------------------------------
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
            '--------------------------------------------------------
         ElseIf Me.cmbFormato.SelectedIndex = 11 Then  'NEO
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivoNEO(Me.txtArchivoDestino.Text)
         ElseIf Me.cmbFormato.SelectedIndex = 12 Then  'Mi Tienda
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, True)
         ElseIf Me.cmbFormato.SelectedIndex = 13 Then  'iTegraConVenc
            Me.CrearProductosWeb()
            Me._ProdWeb.GrabarArchivo(Me.txtArchivoDestino.Text, False)
         End If


         ShowMessage("Se Exportaron " & cant.ToString() & " productos EXITOSAMENTE !!!")
      Else
         ShowMessage("Ha cancelado la exportación.")
      End If
   End Sub

   Private Sub MostrarNombreArchivo()
      Try
         If Me.cmbFormato.Text = "Web" Then
            Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Reglas.Publicos.CuitEmpresa & "_Productos_Web_" & Date.Today().ToString("yyyyMMdd") & ".csv"
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf Me.cmbFormato.SelectedIndex = 1 Then
            Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Reglas.Publicos.CuitEmpresa & "_Productos_DonWeb_" & Date.Today().ToString("yyyyMMdd") & ".csv"
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf Me.cmbFormato.SelectedIndex = 2 Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_Sucursal_{1}_{0:yyyyMMdd}.xls", Date.Today(),
                                                                      cmbListaPrecios.Text))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.TODOS, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf cmbFormato.SelectedIndex = 3 Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_Cliente_{1}_{0:yyyyMMdd}.xls", Date.Today(),
                                                                      cmbListaPrecios.Text))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.TODOS, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf cmbFormato.SelectedIndex = 4 Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_Qendra_{1}_{0:yyyyMMdd}.csv", Date.Today(),
                                                                      cmbListaPrecios.Text))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.TODOS, balanza:=Entidades.Publicos.SiNoTodos.SI)

         ElseIf cmbFormato.SelectedIndex = 5 Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_WebExperto_{1}_{0:yyyyMMdd}.csv", Date.Today(),
                                                                      cmbListaPrecios.Text))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf cmbFormato.Text = "iTegra/Kretz" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_iTegraKretz_{1}_{0:yyyyMMdd}.csv", Date.Today(),
                                                                      cmbListaPrecios.Text))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.TODOS, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf cmbFormato.Text = "WooCommerce Compacta" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_WooCommerce_Compacta_{1}_{0:yyyyMMdd}.csv", Date.Today(),
                                                                      cmbListaPrecios.Text))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)

         ElseIf cmbFormato.Text = "Dabadoo" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_Dabadoo_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
         ElseIf cmbFormato.Text = "Arborea" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_Arborea_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
            '-- REG-32775.- -----------------------------------------------------------------------------------------------------------------------
         ElseIf cmbFormato.Text = "WooCommerceCompacto" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_WooCommerceCompacto_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
            '-- REG-35639.- -----------------------------------------------------------------------------------------------------------------------
         ElseIf cmbFormato.Text = "WooCommerceSimple" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_WooCommerceSimple_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
            '--------------------------------------------------------------------------------------------------------------------------------------
         ElseIf cmbFormato.Text = "NEO" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_NEO_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
            '--------------------------------------------------------------------------------------------------------------------------------------
         ElseIf cmbFormato.Text = "Mi Tienda" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_MiTienda_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
         ElseIf cmbFormato.Text = "iTegraConVenc" Then
            Me.txtArchivoDestino.Text = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                        String.Format(Reglas.Publicos.CuitEmpresa & "_Productos_iTegraConVenc_{0:yyyyMMdd}.csv", Date.Today()))
            CambiaPublicarEn(web:=Entidades.Publicos.SiNoTodos.SI, balanza:=Entidades.Publicos.SiNoTodos.TODOS)
         End If

         Me.txtArchivoDestino.Text = Me.txtArchivoDestino.Text.Replace(" ", "_")
      Catch ex As Exception
         MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CambiaPublicarEn(web As Entidades.Publicos.SiNoTodos, balanza As Entidades.Publicos.SiNoTodos)
      Me.cmbPublicarEnWeb.SelectedValue = web
      Me.cmbPublicarEnBalanza.SelectedValue = balanza
   End Sub

   Private Sub ExportarSucursal()

      Dim dr As DataRow

      For Each dr1 As UltraGridRow In Me.ugDetalle.Rows
         If Boolean.Parse(dr1.Cells("Check").Value.ToString()) Then
            dr = Me._Prod.NewRow
            dr.ItemArray = CType(dr1.ListObject, DataRowView).Row.ItemArray
            Me._Prod.Rows.Add(dr)
         End If
      Next

      Me.ugDetalle.DataSource = Me._Prod

      If ugDetalle.Layouts.Count = 0 Then
         ugDetalle.Layouts.Add(ugDetalle.DisplayLayout.Clone())
      End If

      With ugDetalle.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         .Columns(Entidades.Producto.Columnas.IdProducto.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.IdProducto.ToString()).Header.VisiblePosition = 1
         '-- REQ-35886.- --------------------------------------------------------------------------------
         .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).Header.VisiblePosition = 2
         '-----------------------------------------------------------------------------------------------
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).Header.VisiblePosition = 3

         .Columns(Entidades.Marca.Columnas.NombreMarca.ToString()).Hidden = False
         .Columns(Entidades.Marca.Columnas.NombreMarca.ToString()).Header.VisiblePosition = 4

         .Columns(Entidades.Rubro.Columnas.NombreRubro.ToString()).Hidden = False
         .Columns(Entidades.Rubro.Columnas.NombreRubro.ToString()).Header.VisiblePosition = 5

         .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Hidden = False
         .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Header.VisiblePosition = 6

         .Columns(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).Hidden = False
         .Columns(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).Header.VisiblePosition = 7

         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Header.VisiblePosition = 8
         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Header.Caption = "IVA"

         .Columns("PrecioCosto").Hidden = False
         .Columns("PrecioCosto").Header.VisiblePosition = 9
         .Columns("PrecioCosto").Header.Caption = "Costo"

         .Columns("PrecioVenta").Hidden = False
         .Columns("PrecioVenta").Header.VisiblePosition = 10
         .Columns("PrecioVenta").Header.Caption = "Venta"

         .Columns("NombreMonedaCorto").Hidden = False
         .Columns("NombreMonedaCorto").Header.VisiblePosition = 11
         .Columns("NombreMonedaCorto").Header.Caption = "M"
         .Columns("NombreMonedaCorto").Width = 30

         .Columns(Entidades.Producto.Columnas.CodigoDeBarras.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.CodigoDeBarras.ToString()).Header.VisiblePosition = 12

         .Columns("PORCENTAJE").Hidden = False
         .Columns("PORCENTAJE").Header.VisiblePosition = 13
         .Columns("PORCENTAJE").Header.Caption = "%"
         .Columns("PORCENTAJE").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreProveedor").Hidden = False
         .Columns("NombreProveedor").Header.VisiblePosition = 14

         .Columns(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()).Hidden = False
         .Columns(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()).Header.VisiblePosition = 15

      End With
      UltraGridExcelExporter1.Export(ugDetalle, txtArchivoDestino.Text, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)

      If ugDetalle.Layouts.Count > 0 Then
         ugDetalle.DisplayLayout.CopyFrom(ugDetalle.Layouts(0))
      End If

      RefrescarDatosGrilla()

   End Sub

   Private Sub ExportarCliente()

      Dim dr As DataRow

      For Each dr1 As UltraGridRow In Me.ugDetalle.Rows
         If Boolean.Parse(dr1.Cells("Check").Value.ToString()) Then
            dr = Me._Prod.NewRow
            dr.ItemArray = CType(dr1.ListObject, DataRowView).Row.ItemArray
            Me._Prod.Rows.Add(dr)
         End If
      Next

      Me.ugDetalle.DataSource = Me._Prod

      If ugDetalle.Layouts.Count = 0 Then
         ugDetalle.Layouts.Add(ugDetalle.DisplayLayout.Clone())
      End If
      With ugDetalle.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         .Columns(Entidades.Producto.Columnas.IdProducto.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.IdProducto.ToString()).Header.VisiblePosition = 1

         '-- REQ-35886.- --------------------------------------------------------------------------------
         .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).Header.VisiblePosition = 2
         '-----------------------------------------------------------------------------------------------

         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).Header.VisiblePosition = 3

         .Columns(Entidades.Marca.Columnas.NombreMarca.ToString()).Hidden = False
         .Columns(Entidades.Marca.Columnas.NombreMarca.ToString()).Header.VisiblePosition = 4

         .Columns(Entidades.Rubro.Columnas.NombreRubro.ToString()).Hidden = False
         .Columns(Entidades.Rubro.Columnas.NombreRubro.ToString()).Header.VisiblePosition = 5

         '-- REQ-35931.- ---------------------------------------------------------------------
         .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Hidden = False
         .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Header.VisiblePosition = 6
         .Columns(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).Hidden = False
         .Columns(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).Header.VisiblePosition = 7
         '------------------------------------------------------------------------------------

         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Header.VisiblePosition = 8
         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Header.Caption = "IVA"
         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).Width = 50
         .Columns(Entidades.Producto.Columnas.Alicuota.ToString()).CellAppearance.TextHAlign = HAlign.Center

         .Columns("PrecioVenta").Hidden = False
         .Columns("PrecioVenta").Header.VisiblePosition = 9
         .Columns("PrecioVenta").Header.Caption = "Costo"
         .Columns("PrecioVenta").Format = "N" & Reglas.Publicos.PreciosDecimalesEnVenta.ToString()


         'GAR: 14/04/2016 - Lo anulo porque el precio de venta siempre va cero, dado que el costo del cliente es nuestro precio de venta.
         'Si ellos van a utilizar el formato estandar, que agreguen manualmente.
         'En caso que alguno se queje, lo vemos.
         '.Columns("Kilos").Hidden = False
         '.Columns("Kilos").Header.VisiblePosition = 7
         '.Columns("Kilos").Header.Caption = "Venta"
         .Columns("Kilos").Hidden = True

         .Columns("NombreMonedaCorto").Hidden = False
         .Columns("NombreMonedaCorto").Header.VisiblePosition = 10
         .Columns("NombreMonedaCorto").Header.Caption = "Moneda"
         .Columns("NombreMonedaCorto").Width = 50
         .Columns("NombreMonedaCorto").CellAppearance.TextHAlign = HAlign.Center

         .Columns(Entidades.Producto.Columnas.CodigoDeBarras.ToString()).Hidden = False
         .Columns(Entidades.Producto.Columnas.CodigoDeBarras.ToString()).Header.VisiblePosition = 11

         'GAR: 14/04/2016
         'Si ellos van a utilizar el formato estandar, que agreguen manualmente.
         'En caso que alguno se queje, lo vemos.

         '.Columns("PORCENTAJE").Hidden = False
         '.Columns("PORCENTAJE").Header.VisiblePosition = 10
         '.Columns("PORCENTAJE").Header.Caption = "%"
         '.Columns("PORCENTAJE").CellAppearance.TextHAlign = HAlign.Right

      End With

      'If TypeOf (ugDetalle.DataSource) Is DataTable Then
      '   For Each dr As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows
      '      dr("Kilos") = 0
      '   Next
      'End If

      Me.UltraGridExcelExporter1.Export(Me.ugDetalle, txtArchivoDestino.Text, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)

      If ugDetalle.Layouts.Count > 0 Then
         ugDetalle.DisplayLayout.CopyFrom(ugDetalle.Layouts(0))
      End If

      Me.RefrescarDatosGrilla()

   End Sub

#End Region

End Class