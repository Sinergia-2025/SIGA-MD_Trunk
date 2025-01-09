Public Class InfNoVendidos

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbActivoProducto, Entidades.Publicos.SiNoTodos.TODOS)
         '-- Cargar combo de sucursales.- --
         cmbSucursal.Initializar(False, seleccionMultiple:=True, seleccionTodos:=True, idFuncion:=IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         '-- Carga Combos Marca - Rubros.- --
         cmbMarca.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubro.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbSubRubro.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})
         cmbSubSubRubro.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})

         '-- Carga Preferencias de la Grilla.- --
         '-- Verifica parametros.- --
         chbSubRubro.Visible = Reglas.Publicos.ProductoTieneSubRubro
         cmbSubRubro.Visible = chbSubRubro.Visible
         chbSubSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro
         cmbSubSubRubro.Visible = chbSubSubRubro.Visible

         _publicos.CargaComboCategorias(cmbCategoria)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1
         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1
         _publicos.CargaComboRutas(cmbRuta, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)

         Dim oProv = New Reglas.Provincias()
         Dim dtProv = oProv.GetAll()

         cmbProvincia.DisplayMember = "NombreProvincia"
         cmbProvincia.ValueMember = "IdProvincia"
         cmbProvincia.DataSource = dtProv.Copy()
         cmbProvincia.SelectedIndex = -1

         cmbRuta.Visible = New Reglas.Funciones().ExisteFuncion("MovilRutasABM")
         chbRuta.Visible = cmbRuta.Visible

         PreferenciasLeer(ugDetalle, tsbPreferencias)
      End Sub)
   End Sub
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosEntorno())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
      End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
#Region "Eventos Buscador Proveedor"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProveedor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
#Region "Eventos Buscador Cliente"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, busquedaParcial:=False, soloActivos:=False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscProducto))
   End Sub
#Region "Eventos Buscador Producto"
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto)
            bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub
   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto)
            bscProducto.Datos = New Reglas.Productos().GetPorNombre(bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscProducto.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProducto(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         Dim habilitaSubRubro As Boolean = False
         If cmbRubro.SelectedIndex > 0 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            If rubros.Length = 1 Then
               cmbSubRubro.Inicializar(True, True, True, rubros(0))
               habilitaSubRubro = True
            End If
         End If
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSubRubro.Enabled = habilitaSubRubro
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Dim habilitaSubSubRubro As Boolean = False
      If cmbSubRubro.SelectedIndex > 0 Then
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros()
         If subRubros.Length = 1 Then
            cmbSubSubRubro.Inicializar(True, True, True, subRubros(0))
            habilitaSubSubRubro = True
         End If
      End If
      cmbSubSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      cmbSubSubRubro.Enabled = habilitaSubSubRubro
   End Sub

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
               bscCodigoProveedor.Focus()
               Exit Sub
            End If
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
               bscCodigoCliente.Focus()
               Exit Sub
            End If
            If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscProducto.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
               bscCodigoProducto.Focus()
               Exit Sub
            End If

            '-------------------------------------------------------------------------
            CargaGrillaDetalle()

            If ugDetalle.Rows.Count = 0 Then
               ShowMessage("NO hay registros que cumplan con la seleccion !!!")
            End If
         End Sub)
   End Sub
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
   End Sub


#Region "Eventos Buscador Localidades"
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
            bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
            bscNombreLocalidad.Datos = New Reglas.Localidades().GetPorNombre(bscNombreLocalidad.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarLocalidad(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub
   Private Sub chbCategoriaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaCliente.CheckedChanged
      TryCatched(Sub() chbCategoriaCliente.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      TryCatched(Sub() chbRuta.FiltroCheckedChanged(cmbRuta))
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosEntorno()

      cmbSucursal.Refrescar()
      chbFecha.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbProveedor.Checked = False
      chbCliente.Checked = False
      chbProducto.Checked = False

      cmbMarca.Refrescar()
      cmbRubro.Refrescar()
      cmbSubRubro.Refrescar()
      cmbSubSubRubro.Refrescar()

      chbStockSN.Checked = False
      chbVendedor.Checked = False
      chbCategoriaCliente.Checked = False
      chbZonaGeografica.Checked = False
      chbLocalidad.Checked = False
      chbProvincia.Checked = False
      chbRuta.Checked = False

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      btnConsultar.Focus()
   End Sub

   ''' <summary>
   ''' Proceso de Carga de Datos a la Grilla.- 
   ''' </summary>
   Private Sub CargaGrillaDetalle()
      '-- Define y Carga Variable de Proveedor.- --
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoriaCliente, 0I)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idRuta = cmbRuta.ValorSeleccionado(chbRuta, 0I)

      '-- Recupera Datos.- --
      Dim regla = New Reglas.VentasProductos()
      Dim dtDetalle = regla.GetProductosNoVendidos(cmbSucursal.GetSucursales(),
                                                   dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                   idProveedor, idCliente, idProducto, cmbActivoProducto.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                   cmbMarca.GetMarcas(todosVacio:=True), cmbRubro.GetRubros(todosVacio:=True),
                                                   cmbSubRubro.GetSubRubros(todosVacio:=True), cmbSubSubRubro.GetSubSubRubros(todosVacio:=True),
                                                   Publicos.ListaPreciosPredeterminada, chbStockSN.Checked, idVendedor, idZonaGeografica, idCategoria,
                                                   idLocalidad, idProvincia, idRuta)
      '-- Carga Datos.- --------------------
      ugDetalle.DataSource = dtDetalle
      FormateGrillaDetalle()
      '-- Informa cantidad de Registros.- --
   End Sub
   Private Sub FormateGrillaDetalle()
      Dim pos = 0I
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdSucursal").FormatearColumna("Suc", pos, 30, HAlign.Center)
         .Columns("IdProducto").FormatearColumna("Codigo Producto", pos, 100, HAlign.Left)
         .Columns("NombreProducto").FormatearColumna("Nombre Producto", pos, 200, HAlign.Left)
         .Columns("Stock").FormatearColumna("Stock", pos, 70, HAlign.Right, , "N2")

         .Columns("IdMoneda").FormatearColumna("Codigo Moneda", pos, 80, HAlign.Right).Hidden = True
         .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 60, HAlign.Center)

         .Columns("PrecioVenta").FormatearColumna("Precio Venta", pos, 90, HAlign.Right, , "N2")
         .Columns("PrecioCosto").FormatearColumna("Precio Costo", pos, 90, HAlign.Right, , "N2")

         .Columns("CodigoProveedor").FormatearColumna("Codigo Proveedor", pos, 80, HAlign.Right).Hidden = True
         .Columns("NombreProveedor").FormatearColumna("Nombre Proveedor", pos, 150, HAlign.Left)

         .Columns("IdMarca").FormatearColumna("Codigo Marca", pos, 80, HAlign.Right).Hidden = True
         .Columns("NombreMarca").FormatearColumna("Marca", pos, 150, HAlign.Left)

         .Columns("IdRubro").FormatearColumna("Codigo Rubro", pos, 80, HAlign.Right).Hidden = True
         .Columns("NombreRubro").FormatearColumna("Nombre Rubro", pos, 150, HAlign.Left)

         .Columns("IdSubRubro").FormatearColumna("Codigo SubRubro", pos, 80, HAlign.Right).Hidden = True
         .Columns("NombreSubRubro").FormatearColumna("Nombre SubRubro", pos, 150, HAlign.Left)

         .Columns("IdSubSubRubro").FormatearColumna("Codigo SubSub", pos, 80, HAlign.Right).Hidden = True
         .Columns("NombreSubSubRubro").FormatearColumna("Nombre SubSubRubro", pos, 150, HAlign.Left)
      End With
      ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "NombreProveedor"})
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      bscProveedor.Permitido = False
      bscCodigoProveedor.Permitido = False

      btnConsultar.Focus()
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      bscCliente.Permitido = False
      bscCodigoCliente.Permitido = False

      btnConsultar.Focus()
   End Sub
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscProducto.Permitido = False
      bscCodigoProducto.Permitido = False

      btnConsultar.Focus()
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto.Text, bscProducto.Text)
         End If

         cmbMarca.CargarFiltrosImpresionMarcas(filtro, muestraId:=False, muestraNombre:=True, prefijo:=" - ", sufijo:=String.Empty, todosVacio:=True)
         cmbRubro.CargarFiltrosImpresionRubros(filtro, muestraId:=False, muestraNombre:=True, prefijo:=" - ", sufijo:=String.Empty, todosVacio:=True)
         cmbSubRubro.CargarFiltrosImpresionSubRubros(filtro, muestraId:=False, muestraNombre:=True, prefijo:=" - ", sufijo:=String.Empty, todosVacio:=True)
         cmbSubSubRubro.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=False, muestraNombre:=True, prefijo:=" - ", sufijo:=String.Empty, todosVacio:=True)

         .AppendFormat(" - Productos {0} Stock", If(chbStockSN.Checked, "Con", "Sin"))

         If cmbActivoProducto.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - Producto Activo: {0}", cmbActivoProducto.Text)
         End If
      End With
      Return filtro.ToString()
   End Function
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      bscCodigoLocalidad.Permitido = False
      bscNombreLocalidad.Permitido = False

      btnConsultar.Focus()
   End Sub
#End Region

End Class