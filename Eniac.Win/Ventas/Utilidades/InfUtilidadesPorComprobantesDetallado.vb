Public Class InfUtilidadesPorComprobantesDetallado

#Region "Campos"

   Private _publicos As Publicos
   Private _TotalCosto As Decimal = 0
   Private _TotalNeto As Decimal = 0
   Private _TotalImpuestos As Decimal = 0
   Private _TotalUtilidad As Decimal = 0
   Private _TotalPorcUtilidad As Decimal = 0

   Private _TotalCostoCI As Decimal = 0
   Private _TotalNetoCI As Decimal = 0
   Private _TotalImpuestosCI As Decimal = 0
   Private _TotalUtilidadCI As Decimal = 0
   Private _TotalPorcUtilidadCI As Decimal = 0

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)

         _publicos.CargaComboGrupos(cmbGrupos)
         cmbGrupos.SelectedIndex = -1

         cmbTiposComprobantes.Initializar(False, "VENTAS")
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboUsuarios(cmbUsuario)

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbAfectaCaja, Entidades.Publicos.SiNoTodos.SI)
         _publicos.CargaComboDesdeEnum(cmbEsComercial, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbProductoEsComercial, Entidades.Publicos.SiNoTodos.TODOS)

         _publicos.CargaComboSemaforoVentasUtilidades(cmbPorcUtilidadDesde)
         _publicos.CargaComboSemaforoVentasUtilidades(cmbPorcUtilidadHasta)
         _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
         cmbListaDePrecios.SelectedIndex = -1

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
         ugDetalle.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor", "NombreProducto"})

         RefrescarDatosGrilla()

         PreferenciasLeer(ugDetalle, tsbPreferencias)
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
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
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

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(
      Sub()
         chbMarca.FiltroCheckedChanged(cmbMarca)
         If chbMarca.Checked Then
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(
      Sub()
         chbRubro.FiltroCheckedChanged(cmbRubro)
         If chbRubro.Checked Then
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbUtilidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbUtilidad.CheckedChanged
      TryCatched(Sub() chbUtilidad.FiltroCheckedChanged(cmbPorcUtilidadHasta))
      TryCatched(Sub() chbUtilidad.FiltroCheckedChanged(cmbPorcUtilidadDesde))
   End Sub

   Private Sub chbListaDePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaDePrecios.CheckedChanged
      TryCatched(Sub() chbListaDePrecios.FiltroCheckedChanged(cmbListaDePrecios))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      TryCatched(Sub() chbGrupo.FiltroCheckedChanged(cmbGrupos))
   End Sub
#End Region

#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(
      Sub()
         chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2)
         If chbProducto.Checked Then
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
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

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Lote"
   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged
      TryCatched(Sub() chbLote.FiltroCheckedChanged(usaPermitido:=True, bscLote))
   End Sub
   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetFiltradoPorId(bscLote.Text, actual.Sucursal.Id)
      End Sub)
   End Sub

   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            bscLote.Permitido = False
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.")
            cmbMarca.Focus()
            Exit Sub
         End If
         If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.")
            cmbRubro.Focus()
            Exit Sub
         End If
         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbLote.Checked And Not bscLote.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Lote aunque activó ese Filtro.")
            bscLote.Focus()
            Exit Sub
         End If
         If chbListaDePrecios.Checked AndAlso cmbListaDePrecios.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una LISTA DE PRECIOS.")
            cmbListaDePrecios.Focus()
            Exit Sub
         End If
         If chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.")
            cmbTiposComprobantes.Focus()
            Exit Sub
         End If
         If chbGrupo.Checked And cmbGrupos.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO Informó el Grupo aunque activó ese Filtro.")
            cmbGrupos.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub
   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      TryCatched(
      Sub()
         With ugDetalle.DisplayLayout.Bands(0)
            If .Columns.Exists("Costo") Then
               .Columns("Costo").Hidden = chbConIVA.Checked
               .Columns("Precio").Hidden = chbConIVA.Checked
               .Columns("PrecioLista").Hidden = chbConIVA.Checked
               .Columns("PrecioNeto").Hidden = chbConIVA.Checked
               .Columns("ImporteTotalNeto").Hidden = chbConIVA.Checked
               .Columns("Utilidad").Hidden = chbConIVA.Checked
               .Columns("PorcUtilidad").Hidden = chbConIVA.Checked

               .Columns("CostoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("PrecioConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("PrecioListaConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("PrecioNetoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("ImporteTotalNetoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("UtilidadConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("PorcUtilidadConImpuestos").Hidden = Not chbConIVA.Checked
            End If
         End With
         '-- REQ-34518.- ------------------
         CalculaTotalesCostoNetoUtilidad()
         '---------------------------------
      End Sub)
   End Sub
#End Region

#Region "Metodos"

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

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbTipoComprobante.Checked = False

      chbProducto.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbProducto.Checked = False

      bscLote.Text = String.Empty

      chbCliente.Checked = False
      chbVendedor.Checked = False

      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbAfectaCaja.SelectedValue = Entidades.Publicos.SiNoTodos.SI
      cmbEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbProductoEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      chbFormaPago.Checked = False
      chbUsuario.Checked = False

      chbUtilidad.Checked = False
      chbListaDePrecios.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      txtTotalCosto.SetValor(0)
      txtTotalNeto.SetValor(0)
      txtTotalUtilidad.SetValor(0)
      txtPorcUtilidad.SetValor(0)

      chbGrupo.Checked = False
      cmbSucursal.Refrescar()

      dtpDesde.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()

      '# Reset de variables
      _TotalCosto = 0
      _TotalNeto = 0
      _TotalUtilidad = 0
      _TotalCostoCI = 0
      _TotalNetoCI = 0
      _TotalUtilidadCI = 0

      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim porcUtilidadDesde = If(chbUtilidad.Checked, cmbPorcUtilidadDesde.Text.ValorNumericoPorDefecto(0D), -1D)
      Dim porcUtilidadHasta = If(chbUtilidad.Checked, cmbPorcUtilidadHasta.Text.ValorNumericoPorDefecto(0D), -1D)
      Dim idListaPrecios = cmbListaDePrecios.ValorSeleccionado(chbListaDePrecios, -1I)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idFormaDePago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)
      Dim idUsuario = cmbFormaPago.ValorSeleccionado(chbUsuario, String.Empty)
      Dim lote = If(chbLote.Checked, bscLote.Text, String.Empty)
      Dim tiposComprobantes = cmbTiposComprobantes.GetTiposComprobantes().ToList()
      Dim grupo = cmbGrupos.ValorSeleccionado(chbGrupo, String.Empty)
      Dim esComercial = cmbEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos).ToBoolean()

      Dim rVentasProd = New Reglas.VentasProductos()
      Dim dtDetalle = rVentasProd.GetDetallePorProductos(cmbSucursal.GetSucursales(),
                                                         dtpDesde.Value, dtpHasta.Value,
                                                         idProducto, idMarca, idModelo:=0, idRubro, idSubRubro:=0I, idSubSubRubro:=0I,
                                                         idZonaGeografica:=String.Empty, idTipoComprobante:=String.Empty,
                                                         idVendedor, vendedor:=Entidades.OrigenFK.Actual,
                                                         idCliente,
                                                         cmbGrabanLibro.Text, cmbAfectaCaja.Text,
                                                         idFormaDePago, idUsuario, porcUtilidadDesde, porcUtilidadHasta,
                                                         cantidad:=String.Empty, ingresosBrutos:=Entidades.Publicos.SiNoTodos.TODOS.ToString(), prodDescRec:=Entidades.Publicos.SiNoTodos.TODOS.ToString(),
                                                         idProveedor:=0L, idLocalidad:=0I, idProvincia:=String.Empty, idCategoria:=0I, listaPrecios:=String.Empty, categoria:=Entidades.OrigenFK.Actual,
                                                         tiposComprobantes, esComercial,
                                                         idTransportista:=0I, tipoOperacion:=Nothing, nota:=String.Empty,
                                                         letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0L,
                                                         cajas:=Nothing,
                                                         idListaPrecios:=idListaPrecios, grupo:=grupo,
                                                         idPaciente:=Nothing, idDoctor:=Nothing, fechaCirugia:=Nothing,
                                                         cliente:=Entidades.Cliente.ClienteVinculado.Cliente,
                                                         cmbProductoEsComercial.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS))
      Dim dt = CrearDT()
      For Each dr As DataRow In dtDetalle.Rows
         Dim drCl = dt.NewRow()

         drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
         drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
         drCl("TipoComprobante") = dr("DescripcionAbrev").ToString()
         drCl("Letra") = dr("Letra").ToString()
         drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
         drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
         drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
         drCl("NombreCliente") = dr("NombreCliente").ToString()
         drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
         drCl("FormaDePago") = dr("FormaDePago").ToString()
         drCl("IdVendedor") = dr("IdVendedor").ToString()
         ' drCl("NroDocVendedor") = Long.Parse(dr("NroDocVendedor").ToString())
         drCl("NombreVendedor") = dr("NombreEmpleado").ToString()
         drCl("IdProducto") = dr("IdProducto").ToString()
         drCl("NombreProducto") = dr("NombreProducto").ToString()
         drCl("NombreMarca") = dr("NombreMarca").ToString()
         drCl("NombreRubro") = dr("NombreRubro").ToString()
         drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())

         drCl("Costo") = Decimal.Parse(dr("Costo").ToString())
         drCl("PrecioLista") = Decimal.Parse(dr("PrecioLista").ToString())
         drCl("Precio") = Decimal.Parse(dr("Precio").ToString())

         drCl("CostoConImpuestos") = Decimal.Parse(dr("CostoConImpuestos").ToString())
         drCl("PrecioListaConImpuestos") = Decimal.Parse(dr("PrecioListaConIva").ToString())
         drCl("PrecioConImpuestos") = Decimal.Parse(dr("PrecioConIva").ToString())

         drCl("DescuentoRecargoPorc") = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         drCl("DescuentoRecargoPorc2") = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
         drCl("DescuentoRecargoPorcGral") = Decimal.Parse(dr("DescuentoRecargoPorcGral").ToString())

         drCl("PrecioNeto") = Decimal.Parse(dr("PrecioNeto").ToString())
         drCl("PrecioNetoConImpuestos") = Decimal.Parse(dr("PrecioNetoConIva").ToString())

         drCl("AlicuotaImpuesto") = Decimal.Parse(dr("AlicuotaImpuesto").ToString())

         drCl("ImporteTotalNeto") = Decimal.Parse(dr("ImporteTotalNeto").ToString())
         drCl("ImporteTotalNetoConImpuestos") = Decimal.Parse(dr("ImporteTotalNetoConImpuestos").ToString())

         drCl("Utilidad") = Decimal.Parse(dr("Utilidad").ToString())
         drCl("UtilidadConImpuestos") = Decimal.Parse(dr("UtilidadConImpuestos").ToString())

         If Decimal.Parse(dr("ImporteTotalNeto").ToString()) <> 0 Then
            drCl("PorcUtilidad") = Decimal.Round(Decimal.Parse(dr("Utilidad").ToString()) / Decimal.Parse(dr("ImporteTotalNeto").ToString()) * 100, 2)
         Else
            drCl("PorcUtilidad") = 0
         End If

         If Decimal.Parse(dr("ImporteTotalNetoConImpuestos").ToString()) <> 0 Then
            drCl("PorcUtilidadConImpuestos") = Decimal.Round(Decimal.Parse(dr("UtilidadConImpuestos").ToString()) / Decimal.Parse(dr("ImporteTotalNetoConImpuestos").ToString()) * 100, 2)
         Else
            drCl("PorcUtilidadConImpuestos") = 0
         End If

         drCl("Usuario") = dr("Usuario").ToString()
         drCl("NombreListaPrecios") = dr("NombreListaPrecios").ToString()
         dt.Rows.Add(drCl)

         _TotalCosto = _TotalCosto + Decimal.Round(Decimal.Parse(dr("Cantidad").ToString()) * Decimal.Parse(dr("Costo").ToString()), 2)
         _TotalNeto = _TotalNeto + Decimal.Parse(drCl("ImporteTotalNeto").ToString())
         _TotalUtilidad = _TotalUtilidad + Decimal.Parse(drCl("Utilidad").ToString())

         _TotalCostoCI = _TotalCostoCI + Decimal.Round(Decimal.Parse(dr("Cantidad").ToString()) * Decimal.Parse(dr("CostoConImpuestos").ToString()), 2)
         _TotalNetoCI = _TotalNetoCI + Decimal.Parse(drCl("ImporteTotalNetoConImpuestos").ToString())
         _TotalUtilidadCI = _TotalUtilidadCI + Decimal.Parse(drCl("UtilidadConImpuestos").ToString())

      Next
      '-- REQ-34518.- ------------------
      CalculaTotalesCostoNetoUtilidad()
      '---------------------------------
      ugDetalle.DataSource = dt
      '-- REQ-34518.- ------------------
      ugDetalle.AgregarTotalesSuma({"Costo", "CostoConImpuestos", "Utilidad", "UtilidadConImpuestos", "ImporteTotalNeto", "ImporteTotalNetoConImpuestos"})
      ugDetalle.AgregarTotalCustomColumna("PorcUtilidad", New Ayudante.CustomSummaries.SummaryMargen("Utilidad", "ImporteTotalNeto", "PorcUtilidad"))
      ugDetalle.AgregarTotalCustomColumna("PorcUtilidadConImpuestos", New Ayudante.CustomSummaries.SummaryMargen("UtilidadConImpuestos", "ImporteTotalNetoConImpuestos", "PorcUtilidadConImpuestos"))
      '---------------------------------

   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("TipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCategoriaFiscal", GetType(String))
         .Columns.Add("FormaDePago", GetType(String))
         .Columns.Add("IdVendedor", GetType(Integer))
         ' .Columns.Add("NroDocVendedor", GetType(Long))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("Cantidad", GetType(Decimal))

         .Columns.Add("Costo", GetType(Decimal))
         .Columns.Add("CostoConImpuestos", GetType(Decimal))
         .Columns.Add("Precio", GetType(Decimal))
         .Columns.Add("PrecioConImpuestos", GetType(Decimal))
         .Columns.Add("PrecioLista", GetType(Decimal))
         .Columns.Add("PrecioListaConImpuestos", GetType(Decimal))

         .Columns.Add("DescuentoRecargoPorc", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc2", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorcGral", GetType(Decimal))

         .Columns.Add("PrecioNeto", GetType(Decimal))
         .Columns.Add("PrecioNetoConImpuestos", GetType(Decimal))

         .Columns.Add("AlicuotaImpuesto", GetType(Decimal))

         .Columns.Add("ImporteTotalNeto", GetType(Decimal))
         .Columns.Add("ImporteTotalNetoConImpuestos", GetType(Decimal))
         .Columns.Add("Utilidad", GetType(Decimal))
         .Columns.Add("UtilidadConImpuestos", GetType(Decimal))

         .Columns.Add("PorcUtilidad", GetType(Decimal))
         .Columns.Add("PorcUtilidadConImpuestos", GetType(Decimal))
         .Columns.Add("Usuario", GetType(String))
         .Columns.Add("NombreListaPrecios", GetType(String))
      End With
      Return dtTemp
   End Function

   Private Sub CalculaTotalesCostoNetoUtilidad()
      If Me.chbConIVA.Checked = True Then
         txtTotalCosto.Text = _TotalCostoCI.ToString("#,##0.00")
         txtTotalNeto.Text = _TotalNetoCI.ToString("#,##0.00")
         txtTotalUtilidad.Text = _TotalUtilidadCI.ToString("#,##0.00")
         If _TotalNetoCI <> 0 Then
            _TotalPorcUtilidadCI = Decimal.Round(_TotalUtilidadCI / _TotalNetoCI * 100, 2)
         End If
         txtPorcUtilidad.Text = _TotalPorcUtilidadCI.ToString("#,##0.00") & " %"

      Else
         txtTotalCosto.Text = _TotalCosto.ToString("#,##0.00")
         txtTotalNeto.Text = _TotalNeto.ToString("#,##0.00")
         txtTotalUtilidad.Text = _TotalUtilidad.ToString("#,##0.00")
         If _TotalNeto <> 0 Then
            _TotalPorcUtilidad = Decimal.Round(_TotalUtilidad / _TotalNeto * 100, 2)
         End If
         txtPorcUtilidad.Text = _TotalPorcUtilidad.ToString("#,##0.00") & " %"
      End If
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         If chbMarca.Checked Then
            filtro.AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            filtro.AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If
         If chbVendedor.Checked Then
            filtro.AppendFormat(" - Vendedor: {0}", cmbVendedor.Text)
         End If
         If chbUtilidad.Checked Then
            filtro.AppendFormat(" - Utilidad Desde: {0}  Hasta: {1}", cmbPorcUtilidadDesde.Text, cmbPorcUtilidadHasta.Text)
         End If
         If chbProducto.Checked Then
            filtro.AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbListaDePrecios.Checked Then
            filtro.AppendFormat(" - Lista de Precios: {0}", cmbListaDePrecios.Text)
         End If
         If chbCliente.Checked Then
            filtro.AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbFormaPago.Checked Then
            filtro.AppendFormat(" - Formas de Pago: {0}", cmbFormaPago.Text)
         End If
         If cmbUsuario.Enabled Then
            filtro.AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         If chbLote.Checked Then
            filtro.AppendFormat(" - Lote: {0}", bscLote.Text)
         End If
         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)
         If chbGrupo.Checked Then
            filtro.AppendFormat(" - Grupo: {0}", cmbGrupos.Text)
         End If
         If cmbGrabanLibro.SelectedIndex > 0 Then
            filtro.AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         End If
         If cmbAfectaCaja.SelectedIndex > 0 Then
            filtro.AppendFormat(" - Afecta Caja: {0}", cmbAfectaCaja.Text)
         End If
         If cmbEsComercial.SelectedIndex > 0 Then
            filtro.AppendFormat(" - Comercial: {0}", cmbEsComercial.Text)
         End If
         If cmbProductoEsComercial.SelectedIndex > 0 Then
            filtro.AppendFormat(" - Producto Comercial: {0}", cmbProductoEsComercial.Text)
         End If
         .AppendFormat(" - Precios Con IVA: {0}", If(chbConIVA.Checked, "SI", "NO"))
      End With
      Return filtro.ToString()
   End Function
#End Region

End Class