Imports System.ComponentModel
Public Class GenerarPedidoProveedorDesdeStocks
   Implements IConParametros

#Region "Campos"
   Private _publicos As Publicos
   Private _dtDetalle As DataTable
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboSubRubros(cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         '-- REQ-38504.- --------------------------------------------------------------------------------------------
         cmbSucursal.Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=False, IdFuncion)
         cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})
         '-----------------------------------------------------------------------------------------------------------

         'Hay que colocarlo luego del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         RefrescarDatosGrilla()

         ugDetalle.AgregarFiltroEnLinea({Entidades.Producto.Columnas.NombreProducto.ToString(),
                                            Entidades.Producto.Columnas.Observacion.ToString(),
                                            Entidades.Proveedor.Columnas.NombreProveedor.ToString(),
                                            "ProveedoresAlternativos"})

         ugDetalle.AgregarTotalSumaColumna(ugDetalle.DisplayLayout.Bands(0).Columns("Estimativo"))
         ugDetalle.EnterMueveACeldaDeAbajo = True
      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGenerarPedido.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Public Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProveedor.Checked And Not IsNumeric(bscCodigoProveedor.Tag) Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            bscCodigoProveedor.Select()
            Exit Sub
         End If
         If chbProducto.Checked And bscCodigoProducto2.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
            bscCodigoProducto2.Select()
            Exit Sub
         End If

         If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro")
            cmbMarca.Select()
            Exit Sub
         End If

         If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro")
            cmbRubro.Select()
            Exit Sub
         End If

         If chbSubRubro.Checked And cmbSubRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Subrubro aunque activó ese Filtro")
            cmbSubRubro.Select()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            ugDetalle.Focus()
            ugDetalle.IrPrimerCeldaEditable()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbGenerarPedido_Click(sender As Object, e As EventArgs) Handles tsbGenerarPedido.Click
      TryCatched(Sub() GenerarPedido())
   End Sub
#Region "Imprimir/Exportar"
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
#End Region
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Filtros"
   Private Sub cmbDepositos_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositos.AfterSelectedIndexChanged
      TryCatched(Sub() _publicos.CargaComboUbicaciones(cmbUbicacion, cmbSucursal.GetSucursales(), cmbDepositos.GetDepositos()))
   End Sub
   Private Sub chbUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbUbicacion.CheckedChanged
      TryCatched(Sub() chbUbicacion.FiltroCheckedChanged(cmbUbicacion))
   End Sub

#Region "Buscador de Proveedores"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(
      Sub()
         '-- REQ-41941.- ---------------------------------
         chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor)
         '------------------------------------------------
         llbProveedor.Visible = chbProveedor.Checked
         chbReposicionProductosVendidos.Enabled = False
         If chbProveedor.Checked Then
            If chbCantidadVendida.Checked Then
               chbReposicionProductosVendidos.Enabled = chbProveedor.Checked
            End If
         End If
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
   Private Sub llbProveedor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked
      TryCatched(
      Sub()
         If bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono Then
            Dim blnIncluirFoto = True

            Dim prov = New Reglas.Proveedores().GetUnoPorCodigo(bscCodigoProveedor.Text.ValorNumericoPorDefecto(0L), blnIncluirFoto)
            prov.Usuario = actual.Nombre

            Using frm = New ProveedoresDetalle(prov)
               frm.StateForm = StateForm.Actualizar
               frm.CierraAutomaticamente = True
               frm.IdFuncion = IdFuncion
               frm.ShowDialog()
            End Using
         End If
      End Sub)
   End Sub
#End Region
#Region "Buscador de Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(
      Sub()
         chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2)
         If chbProducto.Checked Then
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbMarca.Checked = False
            chbRubro.Checked = False
         Else
            '-- REQ-34109.- --------------------------------------
            bscCodigoProducto2.Text = String.Empty
            bscProducto2.Text = String.Empty
            '-----------------------------------------------------
         End If
         chbReposicionProductosVendidos.Enabled = chbProducto.Checked
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub

   Private Sub chbCantidadVendida_CheckedChanged(sender As Object, e As EventArgs) Handles chbCantidadVendida.CheckedChanged
      TryCatched(
      Sub()
         chbMesCompleto.Enabled = chbCantidadVendida.Checked
         dtpDesde.Enabled = chbCantidadVendida.Checked
         dtpHasta.Enabled = chbCantidadVendida.Checked
         If chbCantidadVendida.Checked And chbProveedor.Checked Then
            chbReposicionProductosVendidos.Enabled = chbCantidadVendida.Checked
         Else
            chbReposicionProductosVendidos.Enabled = False
         End If
      End Sub)
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#End Region

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing Then

            If String.IsNullOrWhiteSpace(dr("Pedido").ToString()) Then
               dr("Pedido") = 0
            End If
            If String.IsNullOrWhiteSpace(dr("PrecioCosto").ToString()) Then
               dr("PrecioCosto") = 0
            End If

            Dim stock = Decimal.Parse(dr("Stock").ToString())
            Dim stockMinimo = Decimal.Parse(dr("StockMinimo").ToString())
            Dim stockMaximo = Decimal.Parse(dr("StockMaximo").ToString())
            Dim puntoDePedido = Decimal.Parse(dr("PuntoDePedido").ToString())
            If stock < 0 Then stock = stock

            If Decimal.Parse(e.Row.Cells("Pedido").Value.ToString()) <> 0 Then
               e.Row.Cells("Pedido").Color(Color.Black, Color.Cyan)
            Else
               e.Row.Cells("Pedido").Color(Nothing, Nothing)
            End If

            If stock < stockMinimo Then
               e.Row.Cells("Stock").Color(Nothing, Color.LightCoral)
            ElseIf stock < puntoDePedido Then
               e.Row.Cells("Stock").Color(Color.Black, Color.Yellow)
            Else
               e.Row.Cells("Stock").Color(Nothing, Nothing)
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(
      Sub()
         If e.Cell.Row.ListObject IsNot Nothing AndAlso e.Cell.Column.Key = "Pedido" Then
            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
            If Not String.IsNullOrWhiteSpace(dr("Pedido").ToString()) Then
               dr("Estimativo") = Decimal.Parse(dr("Pedido").ToString()) * Decimal.Parse(dr("PrecioCosto").ToString())
            Else
               dr("Estimativo") = 0
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      optTodos.Checked = True

      cmbDepositos.Refrescar()
      chbUbicacion.Checked = False

      chbProducto.Checked = False
      chbProveedor.Checked = False
      chbProveedorHabitual.Checked = True
      chbMarca.Checked = False
      chbRubro.Checked = False

      chbCantidadVendida.Checked = _parametros.GetValor(Of Boolean)(ParametrosPermitidos.MuestraCantidadVendida)
      dtpDesde.Value = Today.AddDays(_parametros.GetValor(Of Integer)(ParametrosPermitidos.DiasSumarFechaDesdeCantidadVendida))
      dtpHasta.Value = Today.UltimoSegundoDelDia.AddDays(_parametros.GetValor(Of Integer)(ParametrosPermitidos.DiasSumarFechaHastaCantidadVendida))
      chbMesCompleto.Checked = False

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim tipoPedido As Entidades.ProductoSucursal.SituacionDeStock
      If optStockMinimo.Checked Then
         tipoPedido = Entidades.ProductoSucursal.SituacionDeStock.StockMinimo
      ElseIf optPuntoPedido.Checked Then
         tipoPedido = Entidades.ProductoSucursal.SituacionDeStock.PuntoDePedido
      Else
         tipoPedido = Entidades.ProductoSucursal.SituacionDeStock.Todos
      End If

      Dim idProducto = If(bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono, bscCodigoProducto2.Text, String.Empty)
      Dim idMarca = If(chbMarca.Checked, cmbMarca.ValorSeleccionado(Of Integer), 0)
      Dim idRubro = If(chbRubro.Checked, cmbRubro.ValorSeleccionado(Of Integer), 0)
      Dim idSubRubro = If(cmbSubRubro.Enabled, cmbSubRubro.ValorSeleccionado(Of Integer), 0)
      Dim idProveedor = If(chbProveedor.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoProveedor.Tag, 0L), 0L)
      Dim proveedorHabitual = chbProveedorHabitual.Checked

      Dim calculaCantidadesVendida As Boolean = chbCantidadVendida.Checked
      Dim fechaDesdeCantidadesVendida As Date? = dtpDesde.Valor(chbCantidadVendida)
      Dim fechaHastaCantidadesVendida As Date? = dtpHasta.Valor(chbCantidadVendida)

      Dim oProdSuc = New Reglas.ProductosSucursales()
      _dtDetalle = oProdSuc.GetProductosGenerarPedidos(cmbSucursal.GetSucursales(),
                                                       cmbDepositos.GetDepositos(),
                                                       cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)(chbUbicacion),
                                                       tipoPedido,
                                                       idProducto,
                                                       idMarca, idRubro, idSubRubro,
                                                       idProveedor, proveedorHabitual,
                                                       calculaCantidadesVendida, fechaDesdeCantidadesVendida, fechaHastaCantidadesVendida)
      _dtDetalle.Columns.Add("PedidoOriginal", GetType(Decimal))

      Dim generarPedidosStockSeleccionaTrue = Reglas.Publicos.GenerarPedidosStockSeleccionaTrue
      For Each drDetalle As DataRow In _dtDetalle.Rows
         '--
         If chbReposicionProductosVendidos.Checked Then
            drDetalle("Pedido") = drDetalle("CantidadVendida")
         Else
            Dim pedido As Decimal = 0
            If Not IsDBNull(drDetalle("Pedido")) Then pedido = Decimal.Parse(drDetalle("Pedido").ToString())
            drDetalle("PedidoOriginal") = pedido
            drDetalle("Pedido") = 0
            If generarPedidosStockSeleccionaTrue AndAlso pedido <> 0 Then
               Dim stock As Decimal = Decimal.Parse(drDetalle("Stock").ToString())
               Dim stockMinimo As Decimal = Decimal.Parse(drDetalle("StockMinimo").ToString())
               Dim puntoDePedido As Decimal = Decimal.Parse(drDetalle("PuntoDePedido").ToString())

               If stock <= stockMinimo Or stock <= puntoDePedido Then
                  drDetalle("Pedido") = pedido
                  drDetalle("Estimativo") = pedido * Decimal.Parse(drDetalle("PrecioCosto").ToString())
               End If
            End If
         End If
         '--
      Next
      ugDetalle.DataSource = _dtDetalle

      ugDetalle.DisplayLayout.Bands(0).Columns("CantidadVendida").Hidden = Not chbCantidadVendida.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("ProveedoresAlternativos").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)

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

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Situación de Stock: {0}", If(optStockMinimo.Checked, "Por debajo de Stock Mínimo", If(optPuntoPedido.Checked, "Por debajo de Punto de Pedido", "Todos")))

         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
            If chbProveedorHabitual.Checked Then
               .AppendFormat(" - Proveedor Habitual")
            End If
         End If

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If

         If chbRubro.Checked Then
            .AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If

         If chbSubRubro.Checked Then
            .AppendFormat(" - Subrubro: {0}", cmbSubRubro.Text)
         End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub GenerarPedido()
      ugDetalle.UpdateData()
      If _dtDetalle.Select(String.Format("{0} <> 0", "Pedido")).Length = 0 Then
         ShowMessage("No ha seleccionado ningún producto para crear un pedido. Por favor verifique.")
         Exit Sub
      End If

      Dim codigoProveedor As Long? = Nothing
      If chbProveedor.Checked AndAlso IsNumeric(bscCodigoProveedor.Text) AndAlso Long.Parse(bscCodigoProveedor.Text) > 0 Then
         codigoProveedor = Long.Parse(bscCodigoProveedor.Text)
      End If

      Dim frmPedido = New PedidosProveedores()
      frmPedido.MdiParent = MdiParent
      frmPedido.Show()
      frmPedido.CreaDesdeStock(codigoProveedor, _dtDetalle)
   End Sub

#Region "Parametros"
   Private _parametros As New ParametrosFuncion()
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      ConParametrosAyudante.Parse(parametros, GetType(ParametrosPermitidos), _parametros,
                                  convertirDato:=
                                  Function(key, value, h)
                                     If key.Equals(ParametrosPermitidos.MuestraCantidadVendida) Then
                                        Return h.ToBoolean(value)
                                     ElseIf key.Equals(ParametrosPermitidos.DiasSumarFechaDesdeCantidadVendida) Or key.Equals(ParametrosPermitidos.DiasSumarFechaHastaCantidadVendida) Then
                                        Return h.ToInteger(value)
                                     Else
                                        Throw New Exception(String.Format("Clave de parámetro '{0}' no válida", key.ToString()))
                                     End If
                                  End Function)
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(ParametrosPermitidos))
   End Function
   Public Enum ParametrosPermitidos
      <DefaultValue(False), Description("Indica si se debe tildar el filtro de Muestra Cantidad Vencida (True/False o SI/NO)")> MuestraCantidadVendida
      <DefaultValue(0I), Description("Indica la cantidad de días a sumarle a la fecha desde para Cantidad Vencida (puede ser negativa)")> DiasSumarFechaDesdeCantidadVendida
      <DefaultValue(0I), Description("Indica la cantidad de días a sumarle a la fecha hasta para Cantidad Vencida (puede ser negativa)")> DiasSumarFechaHastaCantidadVendida
   End Enum
#End Region

#End Region

End Class