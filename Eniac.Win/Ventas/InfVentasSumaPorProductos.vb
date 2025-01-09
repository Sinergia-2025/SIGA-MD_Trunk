Public Class InfVentasSumaPorProductos

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private IdUsuario As String = actual.Nombre

   Private _blnMiraUsuario As Boolean
   Private _blnMiraPC As Boolean
   Private _blnCajasModificables As Boolean


   '-- REQ-35217.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _blnMiraUsuario = True
         _blnMiraPC = False
         _blnCajasModificables = False

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         _publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            cmbVendedor.SelectedIndex = -1
         Else
            chbVendedor.Checked = True
            chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboSubRubros(cmbSubRubro)
         _publicos.CargaComboCategorias(cmbCategoria)
         _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
         _publicos.CargaComboTransportistas(cmbTransportista)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         ugDetalle.AgregarTotalesSuma({"ImporteTotalNeto", "ImporteTotal", "Kilos", "Cantidad"})

         _publicos.CargaComboDesdeEnum(cmbEsComercial, GetType(Entidades.Publicos.SiNoTodos))
         cmbEsComercial.SelectedIndex = 1

         'Hay que colocarlo luego del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         chbUnificar.Enabled = cmbSucursal.Enabled

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("CodigoProductoProveedor").Hidden = True
            .Columns("Embalaje").Hidden = True

            '.Columns("CodigoProveedorHabitual").Hidden = True
            '.Columns("NombreProveedorHabitual").Hidden = True

            '-- REQ-35217.- ------------------------------------------------------
            .Columns("DescripcionAtributo01").Header.Caption = If(TipoAtributo01 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion)
            .Columns("DescripcionAtributo01").Hidden = (TipoAtributo01 = 0)
            '-- Atributo 02.- ------------------------------------------------------
            .Columns("DescripcionAtributo02").Header.Caption = If(TipoAtributo02 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion)
            .Columns("DescripcionAtributo02").Hidden = (TipoAtributo02 = 0)
            '-- Atributo 03.- ------------------------------------------------------
            .Columns("DescripcionAtributo03").Header.Caption = If(TipoAtributo03 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion)
            .Columns("DescripcionAtributo03").Hidden = (TipoAtributo03 = 0)
            '-- Atributo 04.- ------------------------------------------------------
            .Columns("DescripcionAtributo04").Header.Caption = If(TipoAtributo04 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion)
            .Columns("DescripcionAtributo04").Hidden = (TipoAtributo04 = 0)
            '---------------------------------------------------------------------
         End With

         _publicos.CargaComboCajas(cmbCajas, cmbSucursal.GetSucursales(), _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajas.SelectedIndex = -1

         _estaCargando = False

         RefrescarDatos()

         ugDetalle.AgregarFiltroEnLinea({"CodigoProductoProveedor"})
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

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         _publicos.CargaComboCajas(cmbCajas, cmbSucursal.GetSucursales(), _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajas.SelectedIndex = -1
      End Sub)
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
      TryCatched(Sub() lblPromediar.Text = DiasHabiles(dtpDesde.Value, dtpHasta.Value).ToString())
   End Sub
   Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
      TryCatched(Sub() lblPromediar.Text = DiasHabiles(dtpDesde.Value, dtpHasta.Value).ToString())
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
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

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(
      Sub()
         chbMarca.FiltroCheckedChanged(cmbMarca)
         If chbMarca.Checked Then
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(
      Sub()
         chbRubro.FiltroCheckedChanged(cmbRubro)
         If chbRubro.Checked Then
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(
      Sub()
         chbSubRubro.FiltroCheckedChanged(cmbSubRubro)
         If chbSubRubro.Checked Then
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub

#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(
      Sub()
         chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2)
         If chbProducto.Checked Then
            chbMarca.Checked = False
            chbRubro.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      TryCatched(Sub() chbTransportista.FiltroCheckedChanged(cmbTransportista))
   End Sub

#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
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

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      TryCatched(
      Sub()
         If _estaCargando Then Exit Sub
         ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalNeto").Hidden = chbConIVA.Checked
         ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = Not chbConIVA.Checked
      End Sub)
   End Sub
   Private Sub chbPromediar_CheckedChanged(sender As Object, e As EventArgs) Handles chbPromediar.CheckedChanged
      TryCatched(Sub() lblPromediar.Visible = chbPromediar.Checked)
   End Sub
   Private Sub chbListaDePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaDePrecios.CheckedChanged
      TryCatched(Sub() chbListaDePrecios.FiltroCheckedChanged(cmbListaDePrecios))
   End Sub
   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCajas))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbVendedor.Checked And cmbVendedor.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un VENDEDOR.")
            cmbVendedor.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not (bscCodigoCliente.Selecciono Or bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbProveedor.Checked And Not (bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If chbProducto.Checked And bscCodigoProducto2.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If
         If chbCaja.Checked AndAlso cmbCajas.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una CAJA.")
            cmbCajas.Focus()
            Exit Sub
         End If
         If chbListaDePrecios.Checked AndAlso cmbListaDePrecios.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una LISTA DE PRECIOS.")
            cmbListaDePrecios.Focus()
            Exit Sub
         End If
         If chbTransportista.Checked AndAlso cmbTransportista.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un TRANSPORTISTA.")
            cmbTransportista.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("Cantidad").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
            .Columns("Kilos").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
            .Columns("Stock").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
         End With

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

#End Region

#Region "Metodos"
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         If cmbSucursal.Enabled Then
            cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If


         If Me.chbProducto.Checked Then
            .AppendFormat(" Producto: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} - ", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            .AppendFormat(" SubRubro: {0} - ", Me.cmbSubRubro.Text)
         End If
         If Me.chbProveedor.Checked Then
            .AppendFormat(" Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If
         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoria: {0} - ", Me.cmbCategoria.Text)
         End If
         If Me.chbCaja.Checked Then
            .AppendFormat(" Caja: {0} - ", Me.cmbCajas.Text)
         End If
         If Me.chbListaDePrecios.Checked Then
            .AppendFormat(" Lista de Precios: {0} - ", Me.cmbListaDePrecios.Text)
         End If
         If Me.chbTransportista.Checked Then
            .AppendFormat(" Transportista: {0} - ", Me.cmbTransportista.Text)
         End If
         If Me.chbPromediar.Checked Then
            .AppendFormat(" Promedio Dias: {0} - ", Me.lblPromediar.Text)
         End If
         If Me.chbAlertaDeCaja.Checked Then
            .AppendFormat(" Solo con Alerta de Caja -")
         End If
         If Me.chbUnificar.Checked Then
            .AppendFormat(" Unificado -")
         End If
         .AppendFormat(" Incluye IVA: {0} -", If(Me.chbConIVA.Checked, "SI", "NO"))

         .AppendFormat(" Es Comercial: {0} - ", Me.cmbEsComercial.SelectedValue.ToString())

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatos()

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbMesCompleto.Checked = False
      chbMostrarProductoVenta.Checked = False
      chbMostrarProveedorHabitual.Checked = False
      chbCliente.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbSubRubro.Checked = False
      chbProducto.Checked = False
      chbProveedor.Checked = False
      chbAlertaDeCaja.Checked = False
      chbCategoria.Checked = False
      chbTransportista.Checked = False
      cmbTransportista.SelectedIndex = -1

      If IdUsuario = "" Then
         chbVendedor.Checked = False
      End If

      chbPromediar.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      cmbSucursal.Refrescar()

      cmbEsComercial.SelectedIndex = 1

      chbUnificar.Checked = True

      ugDetalle.ClearFilas()

      btnConsultar.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbSubRubro, 0I)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim idListaPrecios = cmbListaDePrecios.ValorSeleccionado(chbListaDePrecios, -1I)
      Dim idCaja As Integer = 0
      Dim idSucursalCaja As Integer = 0
      If chbCaja.Checked AndAlso cmbCajas.SelectedIndex > -1 Then
         idCaja = Integer.Parse(cmbCajas.SelectedValue.ToString())
         idSucursalCaja = Integer.Parse(DirectCast(cmbCajas.SelectedItem, DataRowView).Row("IdSucursal").ToString())
      End If

      Dim idTransportista As Integer = If(cmbTransportista.SelectedIndex > -1, Integer.Parse(cmbTransportista.SelectedValue.ToString()), 0)

      Dim rVenta = New Reglas.Ventas()
      Dim dtDetalle = rVenta.GetSumaPorProductos(
                                 cmbSucursal.GetSucursales(), depositos:=Nothing, ubicacion:=Nothing,
                                 dtpDesde.Value, dtpHasta.Value,
                                 idVendedor,
                                 idCliente,
                                 idMarca,
                                 idRubro,
                                 idSubRubro,
                                 idProducto,
                                 idProveedor,
                                 chbAlertaDeCaja.Checked,
                                 idCategoria,
                                 chbUnificar.Checked,
                                 idListaPrecios,
                                 idCaja,
                                 idSucursalCaja,
                                 idTransportista,
                                 chbMostrarProductoVenta.Checked,
                                 chbMostrarProveedorHabitual.Checked,
                                 cmbEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                 cantidadDias:=1, nivelAgrupamiento:=Entidades.Publicos.Reportes.NivelAgrupamientoStock.Sucursal)

      Dim dt = CrearDT()

      Dim promediarPor = If(chbPromediar.Checked, lblPromediar.Text.ValorNumericoPorDefecto(1I), 1I)

      For Each dr As DataRow In dtDetalle.Rows

         Dim drCl = dt.NewRow()

         drCl("NombreMarca") = dr("NombreMarca").ToString()
         drCl("NombreRubro") = dr("NombreRubro").ToString()
         drCl("IdProducto") = dr("IdProducto").ToString()
         drCl("NombreProducto") = dr("NombreProducto").ToString()
         If Not String.IsNullOrEmpty(dr("IdUnidadDeMedida").ToString()) Then
            drCl("Tamano") = Decimal.Parse(dr("Tamano").ToString())
            drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida").ToString()
         End If
         drCl("ImporteTotalNeto") = Decimal.Round(Decimal.Parse(dr("ImporteTotalNeto").ToString()) / PromediarPor, 2)
         drCl("ImporteTotal") = Decimal.Round(Decimal.Parse(dr("ImporteTotal").ToString()) / PromediarPor, 2)
         drCl("Kilos") = Decimal.Round(Decimal.Parse(dr("Kilos").ToString()) / PromediarPor, 2)
         drCl("Cantidad") = Decimal.Round(Decimal.Parse(dr("Cantidad").ToString()) / PromediarPor, Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad)
         drCl("Stock") = Decimal.Parse(dr("Stock").ToString())
         drCl("IdSucursal") = dr("IdSucursal")

         If IdProveedor > 0 AndAlso Not String.IsNullOrEmpty(dr("CodigoProductoProveedor").ToString()) Then
            drCl("CodigoProductoProveedor") = dr("CodigoProductoProveedor").ToString()
            drCl("Embalaje") = Integer.Parse(dr("Embalaje").ToString())
            ' End If
            '    If Me.chbMostrarProveedorHabitual.Checked Then
            ' If IdProveedor = 0 Then
            'drCl("CodigoProductoProveedor") = dr("CodigoProductoProveedor").ToString()
            'End If
         End If
         If Not String.IsNullOrEmpty(dr("CodigoProveedorHabitual").ToString()) Then
            drCl("CodigoProveedorHabitual") = dr("CodigoProveedorHabitual").ToString()
            drCl("NombreProveedorHabitual") = dr("NombreProveedorHabitual").ToString()
         End If
         '-- REQ-35217.- ------------------------------------------------------------
         drCl("IdaAtributoProducto01") = dr("IdaAtributoProducto01")
         drCl("DescripcionAtributo01") = dr("DescripcionAtributo01")
         drCl("IdaAtributoProducto02") = dr("IdaAtributoProducto02")
         drCl("DescripcionAtributo02") = dr("DescripcionAtributo02")
         drCl("IdaAtributoProducto03") = dr("IdaAtributoProducto03")
         drCl("DescripcionAtributo03") = dr("DescripcionAtributo03")
         drCl("IdaAtributoProducto04") = dr("IdaAtributoProducto04")
         drCl("DescripcionAtributo04") = dr("DescripcionAtributo04")
         '---------------------------------------------------------------------------
         dt.Rows.Add(drCl)

      Next

      ugDetalle.DataSource = dt

      ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = chbUnificar.Checked

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("Tamano", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida", GetType(String))
         .Columns.Add("ImporteTotalNeto", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Kilos", GetType(Decimal))
         .Columns.Add("Cantidad", GetType(Decimal))
         .Columns.Add("Stock", GetType(Decimal))
         .Columns.Add("CodigoProductoProveedor", GetType(String))
         .Columns.Add("Embalaje", GetType(Integer))
         .Columns.Add("CodigoProveedorHabitual", GetType(Integer))
         .Columns.Add("NombreProveedorHabitual", GetType(String))
         .Columns.Add("IdSucursal", GetType(Integer))
         '-- REQ-35217.- -----------------------------------------------------------
         .Columns.Add("IdaAtributoProducto01", GetType(String))
         .Columns.Add("DescripcionAtributo01", GetType(String))
         .Columns.Add("IdaAtributoProducto02", GetType(String))
         .Columns.Add("DescripcionAtributo02", GetType(String))
         .Columns.Add("IdaAtributoProducto03", GetType(String))
         .Columns.Add("DescripcionAtributo03", GetType(String))
         .Columns.Add("IdaAtributoProducto04", GetType(String))
         .Columns.Add("DescripcionAtributo04", GetType(String))
         '--------------------------------------------------------------------------
      End With
      Return dtTemp
   End Function

   Private Function DiasHabiles(FechaDesde As Date, FechaHasta As Date) As Integer
      Dim Dias As Integer = 1
      Dim Dia As Date = FechaDesde.Date
      Do While Dia < FechaHasta.Date
         If Dia.DayOfWeek <> DayOfWeek.Saturday And Dia.DayOfWeek <> DayOfWeek.Sunday Then
            Dias += 1
         End If
         Dia = Dia.AddDays(1)
      Loop
      Return Dias
   End Function
   Private Sub chbMostrarProductoVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarProductoVenta.CheckedChanged
      ugDetalle.DisplayLayout.Bands(0).Columns("CodigoProductoProveedor").Hidden = Not chbProveedor.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("Embalaje").Hidden = Not chbProveedor.Checked
   End Sub

#End Region
End Class