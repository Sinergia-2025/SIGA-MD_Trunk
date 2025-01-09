Public Class OrganizarEntregasV2
   Implements IConParametros

   Private _dsOrganizarEntrega As DataSet
   Private _dsProductoSinStock As DataSet
   Public Enum ModoCambioMasivo As Integer
      <ComponentModel.Description("Solo Actual")>
      SoloActual = 0
      Seleccionados = 1
      Todos = 2
   End Enum

   Private catEmpr As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

   Private _titPedidosPorDistribucion As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titArticulosSinStock0 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titArticulosSinStock1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _titFacturas As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _textOriginal As String
   Private _modo As ModoOrganizarEntregas = ModoOrganizarEntregas.FULL
   Private Enum ModoOrganizarEntregas
      FULL
      FACTURACIONMASIVA
      SOLOPEDIDOS
      SOLOVENTAS
   End Enum

#Region "Campos"

   Private _dtRepartos As DataTable
   Private _publicos As Publicos
   Private _PedidosSinFacturar As DataTable
   Private NumeroReparto As String
   Private _vieneDeModificar As Boolean
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
   Private _tipoCompNuevo As String
   Private _dtDetalleProducto As DataTable
   Private _dtProductosSinStock As DataTable
   Private _blnCajasModificables As Boolean = True
   Private _NecesitaModificarParametros As Boolean
   Private _ParametrosAModificar As DataTable

   Public Property VieneDeModificar As Boolean

      Get
         Return _vieneDeModificar

      End Get
      Set(value As Boolean)
         _vieneDeModificar = value
      End Set
   End Property

   Public Property tipoCompNuevo() As String
      Get
         Return _tipoCompNuevo
      End Get
      Set(value As String)
         _tipoCompNuevo = value
      End Set
   End Property


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      _textOriginal = Text

      MyBase.OnLoad(e)

      Try
         If Publicos.OrganizarEntregaFiltraFechaEnvio Then
            lblFechaDesde.Text = lblFechaDesde.Text.Replace("Pedido", "Envio")
         End If
         CreartablaProductosSinstock()
         utcPreventa.SelectedTab = utcPreventa.Tabs("tbpPedidosSinResponsable")
         _titPedidosPorDistribucion = GetColumnasVisiblesGrilla(ugvPedidosPorDistribucion.DisplayLayout.Bands(0))

         utcPreventa.SelectedTab = utcPreventa.Tabs("tbpArticulosSinStock")
         _titArticulosSinStock0 = GetColumnasVisiblesGrilla(ugvArticulosSinStock.DisplayLayout.Bands(0))
         _titArticulosSinStock1 = GetColumnasVisiblesGrilla(ugvArticulosSinStock.DisplayLayout.Bands(1))

         utcPreventa.SelectedTab = utcPreventa.Tabs("tbpComprobantes")
         _titFacturas = GetColumnasVisiblesGrilla(ugvFacturas)

         utcPreventa.SelectedTab = utcPreventa.Tabs("tbpDetallePedidos")

         _publicos = New Publicos()

         _publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboTransportistas(Me.cmbRespDistribucion, True)
         cmbRespDistribucion.SelectedIndex = -1

         _publicos.CargaComboEmpleados(Me.cboVendListados, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboTransportistas(Me.cboRespDistListado, True)
         cmbRespDistribucion.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbOrigen, GetType(Entidades.OrganizarEntregas.Origen))

         _publicos.CargaComboOrdenesProducto(cmbOrdenProducto, activos:=True)

         _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         'Me.dtpFechaDesde.Value = DateTime.Today.AddDays(-30)
         CrearDtResponsableDistribucion()


         Dim columnToSummarize0 As UltraGridColumn = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Columns("Direccion")
         Dim summary0 As SummarySettings = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Summaries.Add("Direccion", SummaryType.Count, columnToSummarize0)
         summary0.DisplayFormat = "Cantidad de Comprobante: {0:n2}"
         summary0.Appearance.TextHAlign = HAlign.Right
         summary0.Appearance.TextTrimming = TextTrimming.None

         Dim columnToSummarize As UltraGridColumn = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Columns("Kilos")
         Dim summary As SummarySettings = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Summaries.Add("Kilos", SummaryType.Sum, columnToSummarize)
         summary.DisplayFormat = "{0:n2}"
         summary.Appearance.TextHAlign = HAlign.Right
         summary.Appearance.TextTrimming = TextTrimming.None

         Dim columnToSummarize2 As UltraGridColumn = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Columns("KilosMaximo")
         Dim summary2 As SummarySettings = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Summaries.Add("KilosMaximo", SummaryType.Maximum, columnToSummarize2)
         summary2.DisplayFormat = "{0:n2}"
         summary2.Appearance.TextHAlign = HAlign.Right
         summary2.Appearance.TextTrimming = TextTrimming.None

         Dim columnToSummarize3 As UltraGridColumn = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Columns("Palets")
         Dim summary3 As SummarySettings = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Summaries.Add("Palets", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:n2}"
         summary3.Appearance.TextHAlign = HAlign.Right
         summary3.Appearance.TextTrimming = TextTrimming.None

         Dim columnToSummarize4 As UltraGridColumn = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Columns("PaletsMaximo")
         Dim summary4 As SummarySettings = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Summaries.Add("PaletsMaximo", SummaryType.Maximum, columnToSummarize4)
         summary4.DisplayFormat = "{0:n2}"
         summary4.Appearance.TextHAlign = HAlign.Right
         summary4.Appearance.TextTrimming = TextTrimming.None



         Dim columnToSummarize5 As UltraGridColumn = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary5 As SummarySettings = Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize5)
         summary5.DisplayFormat = "{0:n2}"
         summary5.Appearance.TextHAlign = HAlign.Right
         summary5.Appearance.TextTrimming = TextTrimming.None

         Dim columnToSummarize6 As UltraGridColumn = Me.ugvDetallePedidos.DisplayLayout.Bands(0).Columns("Kilos")
         Dim summary6 As SummarySettings = Me.ugvDetallePedidos.DisplayLayout.Bands(0).Summaries.Add("Kilos", SummaryType.Sum, columnToSummarize6)
         summary6.DisplayFormat = "{0:n2}"
         summary6.Appearance.TextHAlign = HAlign.Right
         summary6.Appearance.TextTrimming = TextTrimming.None

         Dim columnToSummarize7 As UltraGridColumn = Me.ugvDetallePedidos.DisplayLayout.Bands(0).Columns("Palets")
         Dim summary7 As SummarySettings = Me.ugvDetallePedidos.DisplayLayout.Bands(0).Summaries.Add("Palets", SummaryType.Sum, columnToSummarize7)
         summary7.DisplayFormat = "{0:n2}"
         summary7.Appearance.TextHAlign = HAlign.Right
         summary7.Appearance.TextTrimming = TextTrimming.None


         Dim columnToSummarize8 As UltraGridColumn = Me.ugvDetallePedidos.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary8 As SummarySettings = Me.ugvDetallePedidos.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize8)
         summary8.DisplayFormat = "{0:n2}"
         summary8.Appearance.TextHAlign = HAlign.Right
         summary8.Appearance.TextTrimming = TextTrimming.None


         Me.ugvPedidosPorDistribucion.DisplayLayout.Bands(0).SummaryFooterCaption = "Total Pedidos:"
         Me.ugvDetallePedidos.DisplayLayout.Bands(0).SummaryFooterCaption = "Total Pedidos:"


         ' vml todo esto se hace esde la pantalla de modificar pedidos.
         Me.tsbModificarRespDist.Visible = True
         Me.tsbCambiarFechaEnvio.Visible = True
         Me.tsbEliminarPedido.Visible = True
         Me.tsbRecalcularStock.Visible = True

         Dim oParametros As Eniac.Reglas.Parametros = New Eniac.Reglas.Parametros()
         _ParametrosAModificar = oParametros.GetParametrosDeOrganizarEntregasv2()
         If (_ParametrosAModificar.Rows.Count) <> 0 Then
            _NecesitaModificarParametros = True
         End If

         SeteaOrigenSegunModo()


         'If _modo = ModoOrganizarEntregas.FACTURACIONMASIVA Then
         '   Me.utcPreventa.Tabs("tbpComprobantes").Text = "Generar Comprobantes"
         'Else
         '   Me.utcPreventa.Tabs("tbpComprobantes").Text = "Generar Reparto"
         'End If

         ' Filtros en linea
         Ayudante.Grilla.AgregarFiltroEnLinea(ugvDetallePedidos, {"CodigoCliente", "NombreCliente", "NombreEmpleado"})

         Me.LeerPreferencias()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         If utcPreventa.SelectedTab.Equals(utcPreventa.Tabs("tbpComprobantes")) Then
            btnFacturas.PerformClick()
         Else
            utcPreventa.SelectedTab = utcPreventa.Tabs("tbpComprobantes")
         End If
      ElseIf keyData = Keys.F9 Then
         If utcPreventa.SelectedTab.Equals(utcPreventa.Tabs("tbpArticulosSinStock")) Then
            tsbDividirPedidoPorFaltante.PerformClick()
         Else
            utcPreventa.SelectedTab = utcPreventa.Tabs("tbpArticulosSinStock")
         End If
      ElseIf keyData = Keys.F3 Then
         btnBuscar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function


   Protected Overridable Sub LeerPreferencias()
      PreferenciasLeer(ugvDetallePedidos, tsbPreferencias)
   End Sub

#End Region

#Region "Eventos"
   Private Sub OrganizarEntregasV2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      TryCatched(
      Sub()
         If _NecesitaModificarParametros Then
            Dim mensaje = New StringBuilder()

            With mensaje
               .AppendLine("Los parámetros no están configurados correctamente. ")
               .AppendLine("Debe modificar los siguientes parámetros: ")
               For idx = 0 To (_ParametrosAModificar.Rows.Count - 1)
                  .AppendFormat("   - ""{0}"" (Solapa {1}).", _ParametrosAModificar.Rows(idx)("Parámetro").ToString(), _ParametrosAModificar.Rows(idx)("Solapa").ToString()).AppendLine()
               Next
            End With
            ShowMessage(mensaje.ToString())
            Close()
         End If
      End Sub)
   End Sub

#Region "Eventos Toolbar Principal"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click
      TryCatched(
      Sub()
         Dim grillaExportar As UltraGrid
         Select Case utcPreventa.SelectedTab.Key
            Case "tbpDetallePedidos"
               ugvDetallePedidos.Rows.ExpandAll(True)
               UltraGridPrintDocument1.Grid = ugvDetallePedidos
               grillaExportar = ugvDetallePedidos
            Case "tbpPedidosSinResponsable"
               ugvPedidosPorDistribucion.Rows.ExpandAll(True)
               UltraGridPrintDocument1.Grid = ugvPedidosPorDistribucion
               grillaExportar = ugvPedidosPorDistribucion
            Case "tbpArticulosSinStock"
               'Me.ugvArticulosSinStock.Rows.ExpandAll(True)
               UltraGridPrintDocument1.Grid = ugvArticulosSinStock
               grillaExportar = ugvArticulosSinStock
            Case "tbpConsolidado"
               Dim impresion = New ImprimirRepartosConsolidadoCargaMercaderia()
               impresion.Imprimir(CargarFiltrosImpresion(), _dtConsolidadoTemporal, Text, False)
               Exit Sub
            Case "tbpComprobantes"
               ugvFacturas.Rows.ExpandAll(True)
               UltraGridPrintDocument1.Grid = ugvFacturas
               grillaExportar = ugvFacturas
            Case "tbpListados"
               Exit Sub
            Case Else
               ugvDetallePedidos.Rows.ExpandAll(True)
               UltraGridPrintDocument1.Grid = ugvDetallePedidos
               grillaExportar = ugvDetallePedidos
         End Select
         grillaExportar.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .Margins = New Drawing.Printing.Margins(5, 5, 14, 8)})
      End Sub,
      onFinallyAction:=Sub(owner) ugvDetallePedidos.Rows.ExpandAll(False))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
      Sub()
         Dim grillaExportar = GetGrillaExportar()
         If grillaExportar IsNot Nothing Then
            grillaExportar.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion())
         End If
      End Sub)
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
      Sub()
         Dim grillaExportar = GetGrillaExportar()
         If grillaExportar IsNot Nothing Then
            grillaExportar.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion())
         End If
      End Sub)
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugvDetallePedidos, tsbPreferencias))
   End Sub
   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Toolbar Pedidos/Comprobantes"
   Private Sub tsbNuevoPedido_Click(sender As Object, e As EventArgs) Handles tsbNuevoPedido.Click
      TryCatched(Sub() NuevoPedido())
   End Sub
   Private Sub tsbModificarPedido_Click(sender As Object, e As EventArgs) Handles tsbModificarPedido.Click
      TryCatched(Sub() ModificaPedido())
   End Sub
   Private Sub tsbDividirPedido_Click(sender As Object, e As EventArgs) Handles tsbDividirPedido.Click
      TryCatched(Sub() DividirPedido())
   End Sub
   Private Sub tsbEliminarPedido_Click(sender As Object, e As EventArgs) Handles tsbEliminarPedido.Click
      TryCatched(Sub() EliminarPedido())
   End Sub
   Private Sub tsbModificarRespDist_Click(sender As Object, e As EventArgs) Handles tsbModificarRespDist.Click
      TryCatched(Sub() CambiarResponsableDistribucion())
   End Sub
   Private Sub tsbModificarPalets_Click(sender As Object, e As EventArgs) Handles tsbModificarPalets.Click
      TryCatched(Sub() ModificarPalets())
   End Sub
   Private Sub tsbCambiarFechaEnvio_Click(sender As Object, e As EventArgs) Handles tsbCambiarFechaEnvio.Click
      TryCatched(Sub() CambiarFechaEnvio())
   End Sub
   Private Sub tsbCambiarFPago_Click(sender As Object, e As EventArgs) Handles tsbCambiarFPago.Click
      TryCatched(Sub() CambiarFormaPago())
   End Sub
   Private Sub tsbCambiarComprobante_Click(sender As Object, e As EventArgs) Handles tsbCambiarComprobante.Click
      TryCatched(Sub() CambiarComprobanteFact())
   End Sub
#End Region

#Region "Eventos Toolbar Art. Sin Stock"
   Private Sub tsbRecalcularStock_Click(sender As Object, e As EventArgs) Handles tsbRecalcularStock.Click
      TryCatched(Sub() Buscar(incluirPedidos:=False, mantenerPedidosSeleccionados:=True))
   End Sub
   Private Sub tsbDividirPedidoPorFaltante_Click(sender As Object, e As EventArgs) Handles tsbDividirPedidoPorFaltante.Click
      TryCatched(
      Sub()
         ugvArticulosSinStock.UpdateData()
         Dim drCol = _dtDetalleProducto.Where(Function(dr) dr.Field(Of Decimal?)("CantidadDividir").IfNull() <> 0)
         If Not drCol.AnySecure Then
            Throw New Exception("No ha seleccionado ningún articulo para dividir")
         End If
         Dim dtFaltantes = drCol.CopyToDataTable()
         Dim rPedidos = New Reglas.Pedidos()
         rPedidos.DividirFaltantePedidos(dtFaltantes)
         Buscar(incluirPedidos:=True, mantenerPedidosSeleccionados:=True)
      End Sub)
   End Sub
#End Region

#Region "Eventos Toolbar Comprobantes Generados"
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
      Sub()
         UltraPrintPreviewDialog1.Document = UltraGridPrintDocument1
         UltraGridPrintDocument1.Header.TextCenter = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + "Listado de Clientes"
         UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
         UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")
         UltraPrintPreviewDialog1.ShowDialog()
      End Sub)
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkRespDistribucion_CheckedChanged(sender As Object, e As EventArgs) Handles chbRespDistribucion.CheckedChanged
      TryCatched(Sub() chbRespDistribucion.FiltroCheckedChanged(cmbRespDistribucion))
   End Sub

#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscProducto))
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, 0, "TODOS")
      End Sub)
   End Sub
   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto)
         bscProducto.Datos = New Reglas.Productos().GetPorNombre(bscProducto.Text.Trim(), actual.Sucursal.Id, 0, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscProducto.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbOrdenProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProducto.CheckedChanged
      TryCatched(Sub() chbOrdenProducto.FiltroCheckedChanged(cmbOrdenProducto))
   End Sub
   Private Sub chkVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbProdDesc_CheckedChanged(sender As Object, e As EventArgs) Handles chbProdDesc.CheckedChanged
      TryCatched(Sub() chbProdDesc.FiltroCheckedChanged(txtProducto))
   End Sub

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

#Region "Eventos Buscador Localidades"
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
   End Sub
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
      TryCatched(Sub() CargarLocalidad(e.FilaDevuelta))
   End Sub
#End Region

#End Region

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         If chbLocalidad.Checked And Not bscCodigoLocalidad.Selecciono And Not bscNombreLocalidad.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó una Localidad aunque activó ese Filtro.")
            bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         If chbCliente.Checked AndAlso Not bscCodigoCliente.Selecciono AndAlso Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         Buscar(incluirPedidos:=True, mantenerPedidosSeleccionados:=False)

         utcPreventa.Enabled = True

         Dim stb = New StringBuilder()
         If chbPendientes.Checked Then
            Dim rOrgEntr = New Reglas.OrganizarEntregas()
            _PedidosSinFacturar = rOrgEntr.GetPedidosSinFacturarV2(dtpFechaDesde.Value.AddDays(-1))

            If _PedidosSinFacturar.Rows.Count > 1 Then
               stb.AppendFormat("Existen {0} Pedidos pendientes de facturar con fecha de entrega anterior al {1:d}", _PedidosSinFacturar.Rows.Count, dtpFechaDesde.Value)
            End If
         End If

         If ugvDetallePedidos.Rows.Count > 0 Then
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
            btnBuscar.Focus()
            btnFacturas.Enabled = True

            If _PedidosSinFacturar.Rows.Count > 1 Then
               ShowMessage(stb.ToString())
            End If
            'Chequeo Pedidos sin Facturar
         Else
            btnFacturas.Enabled = False
            stb.Insert(0, "NO hay registros que cumplan con la selección !!!" + Environment.NewLine() + Environment.NewLine())
            ShowMessage(stb.ToString())
            Exit Sub
         End If
      End Sub)
   End Sub

#Region "Eventos Solapa Comprobantes"
   Private Sub btnFacturas_Click(sender As Object, e As EventArgs) Handles btnFacturas.Click
      TryCatched(
      Sub()
         If cmbCajas.SelectedValue Is Nothing Then
            ShowMessage("Debe seleccionar una caja.")
            Exit Sub
         End If

         If ShowPregunta("¿Desea generar automaticamente las facturas para los pedidos seleccionados?") = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If

         Dim rPedido = New Reglas.Pedidos()
         Dim resVal = rPedido.ValidaOrganizarEntrega(_dsOrganizarEntrega)
         If resVal.AlgunError Then
            ShowMessage(resVal.MensajeError)
            Exit Sub
         End If

         If resVal.AlgunWarning Then
            resVal.AppendLineWarning().AppendLineWarning("¿Desea continuar?")
            If ShowPregunta(resVal.MensajeWarning) = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If

         _dtRepartos = rPedido.GenerarReparto(resVal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()),
                                              grabarReparto:=_modo <> ModoOrganizarEntregas.FACTURACIONMASIVA,
                                              MetodoGrabacion:=Eniac.Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion:=IdFuncion)

         ugRepartos.DataSource = _dtRepartos

         tspBarra.Value = 0

         Dim stbMensaje As StringBuilder = New StringBuilder()
         stbMensaje.AppendFormat("Se han generado {0} Comprobantes nuevos y reenviados {1}!!!", resVal.Pedidos.Count, resVal.Ventas.Count).AppendLine().AppendLine()
         If MinIdReparto() = MaxIdReparto() Then
            stbMensaje.AppendFormat("Incluidos en el Reparto {0}.", MinIdReparto, MaxIdReparto)
         Else
            stbMensaje.AppendFormat("Incluidos en los Repartos del {0} al {1}.", MinIdReparto, MaxIdReparto).AppendLine().AppendLine()
         End If
         stbMensaje.AppendFormat("Puede ver un detalle de los mismos en el listado de Repartos.")

         ShowMessage(stbMensaje.ToString())

         ugvFacturas.Enabled = True
         btnImprimirFacturas.Enabled = True
         btnListadoClientes.Enabled = True
         btnListadoClientesConEnvases.Enabled = True
         btnConsolidadoMercaderiaTipoOperacion.Enabled = True
         btnConsolidadoMercaderia.Enabled = True

         btnImprimirFacturas.Enabled = True
         btnSolicitarCAE.Enabled = True
         btnListadoClientes.Enabled = True
         btnListadoClientesConEnvases.Enabled =
         btnConsolidadoMercaderia.Enabled = True

         Buscar()
      End Sub)
   End Sub
   Private Sub btnSolicitarCAE_Click(sender As Object, e As EventArgs) Handles btnSolicitarCAE.Click
      TryCatched(
      Sub()
         Using frm = New SolicitarCAE(MinIdReparto(), MaxIdReparto())
            frm.ConsultarAutomaticamente = True
            frm.IdFuncion = IdFuncion
            frm.ShowDialog(Me)
         End Using
      End Sub)
   End Sub
   Private Sub btnImprimirFacturas_Click(sender As Object, e As EventArgs) Handles btnImprimirFacturas.Click
      TryCatched(
      Sub()
         Using frm = New ImpresionMasiva(MinIdReparto(), MaxIdReparto(),
                                         Reglas.Publicos.OrganizarEntregaFiltroImpreso,
                                         Today.AddDays(Reglas.Publicos.OrganizarEntregaFiltroFechaDesde),
                                         Today.UltimoSegundoDelDia())
            frm.ConsultarAutomaticamente = True
            frm.ShowDialog(Me)
         End Using
      End Sub)
   End Sub
#End Region

#Region "Eventos Solapa Listados"
   Private Sub btnListadoClientes_Click_1(sender As Object, e As EventArgs) Handles btnListadoClientes.Click
      TryCatched(
      Sub()
         ImprimirListadoCliente(Sub(filtros As String,
                                    idSucursal As Integer,
                                    fechaDesde As Date, fechaHasta As Date,
                                    numeroReparto As Integer, numeroRepartoHasta As Integer,
                                    idTransportista As Integer,
                                    IdVendedor As Integer,
                                    titulo As String)
                                   Dim impresion As New ImprimirRepartosListadoDeClientes()
                                   impresion.Imprimir(filtros, idSucursal, fechaDesde, fechaHasta, numeroReparto, numeroRepartoHasta, idTransportista, IdVendedor, titulo)
                                End Sub)
      End Sub)
   End Sub
   Private Sub btnListadoClientesConEnvases_Click(sender As Object, e As EventArgs) Handles btnListadoClientesConEnvases.Click
      TryCatched(
      Sub()
         ImprimirListadoCliente(Sub(filtros As String,
                                    idSucursal As Integer,
                                    fechaDesde As Date, fechaHasta As Date,
                                    numeroReparto As Integer, numeroRepartoHasta As Integer,
                                    idTransportista As Integer,
                                    IdVendedor As Integer,
                                    titulo As String)
                                   Dim impresion As New ImprimirRepartosListadoDeClientes()
                                   impresion.ImprimirConEnvases(filtros, idSucursal, fechaDesde, fechaHasta, numeroReparto, numeroRepartoHasta, idTransportista, IdVendedor, titulo)
                                End Sub)
      End Sub)
   End Sub
   Private Sub btnConsolidadoMercaderia_Click(sender As Object, e As EventArgs) Handles btnConsolidadoMercaderia.Click
      TryCatched(Sub() ImprimirConsolidadoDeCarga(False))
   End Sub
   Private Sub btnConsolidadoMercaderiaTipoOperacion_Click(sender As Object, e As EventArgs) Handles btnConsolidadoMercaderiaTipoOperacion.Click
      TryCatched(Sub() ImprimirConsolidadoDeCarga(True))
   End Sub
   Private Sub chkRD_CheckedChanged(sender As Object, e As EventArgs) Handles chkRD.CheckedChanged
      TryCatched(Sub() cboRespDistListado.Enabled = chkRD.Checked)
   End Sub
   Private Sub chkVend_CheckedChanged(sender As Object, e As EventArgs) Handles chkVend.CheckedChanged
      TryCatched(Sub() cboVendListados.Enabled = chkVend.Checked)
   End Sub
#End Region

#Region "Eventos Grillas"
   Private Sub ugvDetallePedidos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugvDetallePedidos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing AndAlso dr.Table.Columns.Contains("SolicitaCUIT") Then
            If dr.Field(Of Boolean)("SolicitaCUIT") Then
               e.Row.Cells("MuestraCuitDni").Value = dr("Cuit")
            Else
               e.Row.Cells("MuestraCuitDni").Value = dr("NroDocCliente")
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugvDetallePedidos_CellChange(sender As Object, e As CellEventArgs) Handles ugvDetallePedidos.CellChange
      TryCatched(
      Sub()
         ugvDetallePedidos.UpdateData()
         RecalculaConsolidadCargaTemporal()
         ConsolidarResponsableDistribuccion()
         ConsolidarProductoSinStock()
      End Sub)
   End Sub
   Private Sub ugvArticulosSinStock_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugvArticulosSinStock.DoubleClickRow
      TryCatched(
      Sub()
         If e.Row.Band.Index = 0 Then
            Exit Sub
         End If

         Dim dr = e.Row.FilaSeleccionada(Of DataRow)

         If dr IsNot Nothing Then

            Dim dtPedidos = GetProductosSinStockDetalle()

            Dim dtPedidoSinStock = New DataTable()
            dtPedidoSinStock.Columns.Add("IdProducto", GetType(String))

            Dim oPedido = New Reglas.Pedidos().GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                      dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                      dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                      Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                      Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                      estadoPedido:=Nothing)

            For Each dr2 As DataRow In dtPedidos.Rows

               If Integer.Parse(dr2("IdSucursal").ToString()) = Integer.Parse(dr("IdSucursal").ToString()) And
                  dr2("IdTipoComprobante").ToString() = dr("IdTipoComprobante").ToString() And
                  dr2("Letra").ToString() = dr("Letra").ToString() And
                  Short.Parse(dr2("CentroEmisor").ToString()) = Short.Parse(dr("CentroEmisor").ToString()) And
                  Long.Parse(dr2("NumeroPedido").ToString()) = Long.Parse(dr("NumeroPedido").ToString()) Then

                  Dim drSinStockPedido As DataRow = dtPedidoSinStock.NewRow()
                  drSinStockPedido("IdProducto") = dr2("IdProducto").ToString()

                  dtPedidoSinStock.Rows.Add(drSinStockPedido)

               End If
            Next

            Using frmPedidos = New Win.PedidosClientesV2()
               frmPedidos.ModificarPedido(oPedido, False, Me, dtPedidoSinStock)
            End Using

            Buscar()
            utcPreventa.SelectedTab = utcPreventa.Tabs("tbpArticulosSinStock")
         End If
      End Sub)
   End Sub
   Private Sub ugvArticulosSinStock_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugvArticulosSinStock.InitializeRow
      TryCatched(
      Sub()
         If e.Row.Cells.Exists("Cantidad") And e.Row.Cells.Exists("CantidadDividir") Then
            Dim cantidad = e.Row.Cells("Cantidad").ValorAs(0D)
            Dim cantidadDividir = e.Row.Cells("CantidadDividir").ValorAs(0D)
            If cantidadDividir < 0 Or cantidadDividir > cantidad Then
               e.Row.Cells("CantidadDividir").Color(Color.White, Color.Red)
            Else
               e.Row.Cells("CantidadDividir").Color(Color.Black, Color.LightCyan)
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugRepartos_AfterRowActivate(sender As Object, e As EventArgs) Handles ugRepartos.AfterRowActivate
      TryCatched(
      Sub()
         Dim nroReparto As Integer = -1

         Dim dr = ugRepartos.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            nroReparto = dr.Field(Of Integer)("IdReparto")
         End If

         ugvFacturas.DataSource = New Reglas.Ventas().GetConsolidadoComprobantePorReparto(actual.Sucursal.IdSucursal, nroReparto, 0)

         AjustarColumnasGrillaFacturas()
      End Sub)
   End Sub
#End Region

#Region "Eventos Expandir Todos"
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugvArticulosSinStock.ColapsarExpandir(chkExpandAll.Checked))
   End Sub
   Private Sub chkExpandAllRespDist_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAllRespDist.CheckedChanged
      TryCatched(Sub() ugvPedidosPorDistribucion.ColapsarExpandir(chkExpandAllRespDist.Checked))
   End Sub
   Private Sub chkExpandAllPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAllPedidos.CheckedChanged
      TryCatched(Sub() ugvDetallePedidos.ColapsarExpandir(chkExpandAllPedidos.Checked))
   End Sub
#End Region

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         For Each dr As DataRow In _dsOrganizarEntrega.Tables("Pedidos").Rows
            dr("PASA") = Me.chbTodos.Checked
         Next
      End Sub,
      onFinallyAction:=
      Sub(owner)
         TryCatched(
         Sub()
            RecalculaConsolidadCargaTemporal()
            ConsolidarResponsableDistribuccion()
            ConsolidarProductoSinStock()
         End Sub)
      End Sub)
   End Sub

   Private Sub utcPreventa_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcPreventa.SelectedTabChanged
      TryCatched(
      Sub()
         Dim tbpComprobantes As UltraWinTabControl.UltraTab = utcPreventa.Tabs("tbpComprobantes")
         If utcPreventa.SelectedTab.Equals(tbpComprobantes) Then
            tbpComprobantes.Text = tbpComprobantes.Text.Replace(" (F4)", "")
         Else
            tbpComprobantes.Text = btnFacturas.Text
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False

         bscCodigoCliente.Permitido = True
         bscCliente.Permitido = True
         btnBuscar.Focus()
      End If
   End Sub
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
         bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
         bscNombreLocalidad.Enabled = False
         bscCodigoLocalidad.Enabled = False
         btnBuscar.Focus()
      End If
   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()

         bscCodigoProducto.Permitido = True
         bscProducto.Permitido = True
         btnBuscar.Focus()
      End If
   End Sub

   Public Sub Buscar()
      Buscar(incluirPedidos:=True, mantenerPedidosSeleccionados:=True)
   End Sub
   Public Sub Buscar(incluirPedidos As Boolean, mantenerPedidosSeleccionados As Boolean)
      Dim distribucion As Integer
      Dim IdVendedor As Integer = 0
      Dim ordenProducto As Integer? = Nothing
      Dim IdLocalidad As Integer? = Nothing
      Dim IdCliente As Long? = Nothing
      Dim producto As String = String.Empty

      If Me.cmbRespDistribucion.Enabled Then
         distribucion = DirectCast(Me.cmbRespDistribucion.SelectedItem, Eniac.Entidades.Transportista).idTransportista
      End If

      If Me.cmbVendedor.Enabled Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
      End If

      If Me.bscCodigoProducto.Enabled Then
         producto = Me.bscCodigoProducto.Text
      End If

      If chbOrdenProducto.Checked Then
         ordenProducto = Integer.Parse(cmbOrdenProducto.SelectedValue.ToString())
      End If

      If Me.chbLocalidad.Checked Then
         IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text.ToString())
      End If

      If Me.chbCliente.Checked Then
         IdCliente = Integer.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      Dim rOrganizarEntregas As New Reglas.OrganizarEntregas()

      Dim dsOrganizarEntregaTemp As DataSet = _dsOrganizarEntrega

      _dsOrganizarEntrega = rOrganizarEntregas.GetPedidosYProductos(dtpFechaDesde.Value, dtpFechaHasta.Value,
                                                                    distribucion,
                                                                    IdVendedor,
                                                                    producto, chbArtSinStock.Checked, txtProducto.Text.Trim,
                                                                    DirectCast(cmbOrigen.SelectedValue, Entidades.OrganizarEntregas.Origen),
                                                                    ordenProducto,
                                                                    IdLocalidad,
                                                                    IdCliente)

      If incluirPedidos Then
         Me.ugvDetallePedidos.DataSource = _dsOrganizarEntrega

         If mantenerPedidosSeleccionados Then
            For Each dr As DataRow In _dsOrganizarEntrega.Tables("Pedidos").Rows
               Dim drTemp As DataRow()
               drTemp = dsOrganizarEntregaTemp.Tables("Pedidos").Select(
                                             String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroPedido = {4} AND Pasa = True",
                                                            dr("IdSucursal"),
                                                            dr("IdTipoComprobante"),
                                                            dr("Letra"),
                                                            dr("CentroEmisor"),
                                                            dr("NumeroPedido")))
               If drTemp.Length > 0 Then
                  dr("Pasa") = drTemp(0)("Pasa")
               Else
                  dr("Pasa") = False
               End If
            Next
         End If

         FormatearBandaProductosDetallePedidos()
         RecalculaConsolidadCargaTemporal()

         chkExpandAll.Checked = True
         chkExpandAll.Checked = False

         If Not mantenerPedidosSeleccionados Then
            chbTodos.Checked = True
         End If

         ConsolidarResponsableDistribuccion()
         ConsolidarProductoSinStock()

         If Me.ugvDetallePedidos.Rows.Count = 1 Then
            Me.tssRegistros.Text = Me.ugvDetallePedidos.Rows.Count.ToString() & " Registro"
         Else
            Me.tssRegistros.Text = Me.ugvDetallePedidos.Rows.Count.ToString() & " Registros"
         End If

         Me.btnFacturas.Enabled = _dsOrganizarEntrega.Tables("Pedidos").Rows.Count > 0
      End If

      Me.LeerPreferencias()

   End Sub

   Public Sub FormatearBandaProductosDetallePedidos()
      With ugvDetallePedidos.DisplayLayout.Bands("Productos")
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdProducto"), "Código", col, 100)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Producto", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Ubicacion"), "Ubicación", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreRubro"), "Rubro", col, 100)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Cantidad"), "Cantidad", col, 80, HAlign.Right, , "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Precio"), "Precio", col, 80, HAlign.Right, , "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("ImporteTotalProducto"), "Importe Total", col, 80, HAlign.Right, , "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("TipoOperacion"), "Tp. Oper.", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Nota"), "Nota", col, 150)
      End With

      Eniac.Win.Ayudante.Grilla.FormatearColumna(ugvDetallePedidos.DisplayLayout.Bands("Pedidos").Columns("Kilos"), "Kilos", 8, 70, HAlign.Right, , "N2")
      Eniac.Win.Ayudante.Grilla.FormatearColumna(ugvDetallePedidos.DisplayLayout.Bands("Pedidos").Columns("Palets"), "Palets", 9, 50, HAlign.Right, False, "N0")
      Eniac.Win.Ayudante.Grilla.FormatearColumna(ugvDetallePedidos.DisplayLayout.Bands("Pedidos").Columns("NumeroPedido"), "# Ped.", 14, 60, HAlign.Right)
      Me.ugvDetallePedidos.DisplayLayout.Bands(0).Columns("HorarioClienteCompleto").FormatearColumna("Horario Cliente", 80, 150, HAlign.Left)
   End Sub

   Private Function GetRowsParaModificar(cambioMasivo As ModoCambioMasivo, cambiaReenvio As Boolean) As DataRow()
      ugvDetallePedidos.UpdateData()
      If cambioMasivo = ModoCambioMasivo.SoloActual Then
         Return New DataRow() {DirectCast(Me.ugvDetallePedidos.ActiveRow.ListObject, DataRowView).Row}
      ElseIf cambioMasivo = ModoCambioMasivo.Todos Then
         Return DirectCast(Me.ugvDetallePedidos.DataSource, DataSet).Tables("Pedidos").Select(IIf(cambiaReenvio, "", "Reenvio = 0").ToString())
      ElseIf cambioMasivo = ModoCambioMasivo.Seleccionados Then
         Dim list As New List(Of DataRow)
         ugvDetallePedidos.UpdateData()
         For Each dr As UltraGridRow In ugvDetallePedidos.Rows
            If CBool(dr.Cells("Pasa").Value) And (cambiaReenvio Or Not CBool(dr.Cells("Reenvio").Value)) Then
               If dr.ListObject IsNot Nothing AndAlso TypeOf (dr.ListObject) Is DataRowView AndAlso
                  DirectCast(dr.ListObject, DataRowView).Row IsNot Nothing Then
                  list.Add(DirectCast(dr.ListObject, DataRowView).Row)
               End If
            End If
         Next
         Return list.ToArray()
      End If
      Return Nothing
   End Function

   Private Sub RefrescarDatosGrilla()

      Me.utcPreventa.Enabled = False
      Me.utcPreventa.SelectedTab = Me.UltraTabPageControl3.Tab

      Me.dtpFechaDesde.Value = DateTime.Today
      Me.dtpFechaHasta.Value = DateTime.Today
      Me.chbProducto.Checked = False
      Me.chbArtSinStock.Checked = False
      Me.chbRespDistribucion.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbProdDesc.Checked = False
      Me.chbLocalidad.Checked = False
      Me.chbCliente.Checked = False

      If _dsOrganizarEntrega IsNot Nothing Then
         _dsOrganizarEntrega.Clear()
      End If

      'Me.btnBuscar.Enabled = True
      Me.dtpFechaDesde.Enabled = True
      Me.dtpFechaHasta.Enabled = True
      Me.btnFacturas.Enabled = True

      btnSolicitarCAE.Enabled = False
      btnImprimirFacturas.Enabled = False
      btnListadoClientes.Enabled = False
      Me.btnListadoClientesConEnvases.Enabled = False
      btnConsolidadoMercaderia.Enabled = False
      lblNumeroReparto.Text = ""
      NumeroReparto = ""

      SeteaOrigenSegunModo()

      If _dtRepartos IsNot Nothing Then _dtRepartos.Clear()

      btnBuscar.Focus()
   End Sub

   Private Sub SeteaOrigenSegunModo()
      Select Case _modo
         Case ModoOrganizarEntregas.FACTURACIONMASIVA
            cmbOrigen.SelectedValue = Entidades.OrganizarEntregas.Origen.PEDIDOS
            Text = "Factura masiva de pedidos (no genera repartos)"
            utcPreventa.Tabs("tbpDetallePedidos").Text = "Pedidos"
         Case ModoOrganizarEntregas.SOLOPEDIDOS
            cmbOrigen.SelectedValue = Entidades.OrganizarEntregas.Origen.PEDIDOS
            Text = _textOriginal + " (Solo Pedidos)"
            utcPreventa.Tabs("tbpDetallePedidos").Text = "Pedidos"
         Case ModoOrganizarEntregas.SOLOVENTAS
            cmbOrigen.SelectedValue = Entidades.OrganizarEntregas.Origen.VENTAS
            Text = _textOriginal + " (Solo Ventas)"
            utcPreventa.Tabs("tbpDetallePedidos").Text = "Comprobantes"
         Case Else
            cmbOrigen.SelectedValue = Entidades.OrganizarEntregas.Origen.TODOS
            Text = _textOriginal
            utcPreventa.Tabs("tbpDetallePedidos").Text = "Pedidos/Comprobantes"
      End Select

      OcultarControlesSegunModo()

      cmbOrigen.Enabled = _modo = ModoOrganizarEntregas.FULL

   End Sub
   Private Sub OcultarControlesSegunModo()

      Me.tsbNuevoPedido.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      Me.tsbModificarPedido.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      Me.tsbDividirPedido.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      Me.tsbEliminarPedido.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS

      Me.tsbModificarRespDist.Visible = _modo <> ModoOrganizarEntregas.FACTURACIONMASIVA
      Me.tsbCambiarFechaEnvio.Visible = _modo <> ModoOrganizarEntregas.FACTURACIONMASIVA

      Me.ToolStripSeparator1.Visible = Me.tsbNuevoPedido.Visible Or Me.tsbModificarPedido.Visible Or Me.tsbDividirPedido.Visible Or Me.tsbEliminarPedido.Visible

      Me.tsbCambiarFPago.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      Me.tsbCambiarComprobante.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      Me.chbArtSinStock.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      btnSolicitarCAE.Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS
      utcPreventa.Tabs("tbpArticulosSinStock").Visible = _modo <> ModoOrganizarEntregas.SOLOVENTAS

      Me.utcPreventa.Tabs("tbpListados").Visible = _modo <> ModoOrganizarEntregas.FACTURACIONMASIVA
      Me.utcPreventa.Tabs("tbpPedidosSinResponsable").Visible = _modo <> ModoOrganizarEntregas.FACTURACIONMASIVA

      If _modo = ModoOrganizarEntregas.FACTURACIONMASIVA Then
         Me.btnFacturas.Text = "&Generar Comprobantes (F4)"
      End If
      utcPreventa.Tabs("tbpComprobantes").Text = btnFacturas.Text

   End Sub

   Private Sub EliminarPedido()

      Dim dr As DataRow = GetDrPedidoSeleccionado()

      If dr Is Nothing Then
         Throw New Exception("Debe seleccionar una fila.")
      End If

      If CBool(dr("Reenvio")) Then
         Throw New Exception(String.Format("El comprobante seleccionado es una {0} reenviado o con mercadería sin despachar. No es posible modificar por este medio.",
                                           dr("IdTipoComprobante")))
      End If

      If MessageBox.Show("¿Desea Anular el Pedido seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim tablaAnular As DataTable = dr.Table.Clone() '' DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Clone

            Dim oPedido As Reglas.Pedidos = New Reglas.Pedidos()

            tablaAnular.ImportRow(dr)

            oPedido.AnularPedidos(tablaAnular, Eniac.Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString(), IdFuncion)

            MessageBox.Show("¡¡¡ Pedido Anulado Exitosamente !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Finally
            Buscar()
         End Try
      End If

   End Sub

   Private Sub NuevoPedido()
      Try
         Using frmPedidos As Eniac.Win.PedidosClientesV2 = New Eniac.Win.PedidosClientesV2()
            frmPedidos.ShowDialog(Me)
         End Using
      Finally
         Me.Buscar()
      End Try
   End Sub


   Private Function GetDrPedidoSeleccionado() As DataRow
      Dim row As UltraGridRow = ugvDetallePedidos.ActiveRow
      If row IsNot Nothing Then
         If row.Band.Index > 0 Then
            row = row.ParentRow
         End If
         If row IsNot Nothing AndAlso
         row.ListObject IsNot Nothing AndAlso
         TypeOf (row.ListObject) Is DataRowView AndAlso
         DirectCast(row.ListObject, DataRowView).Row IsNot Nothing Then

            Return DirectCast(row.ListObject, DataRowView).Row

         Else
            Return Nothing
         End If
      Else
         Return Nothing
      End If

   End Function

   Private Sub DividirPedido()
      Dim dr As DataRow = GetDrPedidoSeleccionado()

      If dr Is Nothing Then
         MessageBox.Show("Debe seleccionar una fila.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      If CBool(dr("Reenvio")) Then
         MessageBox.Show(String.Format("El comprobante seleccionado es una {0} reenviada. No es posible dividirlo.",
                                       dr("IdTipoComprobante")), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      Dim opedido = New Reglas.Pedidos()
      'Dim opedidoMasivo As Reglas.Ventas = New Reglas.Ventas()

      Dim pedido = opedido.GetUno(actual.Sucursal.Id,
                                  dr.Field(Of String)("IdTipoComprobante"),
                                  dr.Field(Of String)("Letra"),
                                  dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                  dr.Field(Of Long)("NumeroPedido"),
                                  estadoPedido:=Nothing)

      Dim rPedidos = New Reglas.Pedidos()
      rPedidos.VerificaPedidoModificable(pedido)

      Using frm As New DividirPedidoV2(pedido)
         If frm.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then Exit Sub
         Buscar()
      End Using
      RecalculaConsolidadCargaTemporal()
   End Sub

   Private Sub ModificaPedido()

      Dim dr As DataRow = GetDrPedidoSeleccionado()

      If dr Is Nothing Then
         Throw New Exception("Debe seleccionar una fila.")
      End If

      If CBool(dr("Reenvio")) Then
         Throw New Exception(String.Format("El comprobante seleccionado es una {0} reenviado o con mercadería sin despachar. No es posible modificar por este medio.",
                                           dr("IdTipoComprobante")))
      End If

      Try
         Dim oPedido As Eniac.Entidades.Pedido = New Eniac.Reglas.Pedidos().GetUno(Integer.Parse(dr(Eniac.Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                                                   dr(Eniac.Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                                   dr(Eniac.Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                                                   Short.Parse(dr(Eniac.Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                                                   Long.Parse(dr(Eniac.Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                                                   estadoPedido:=Nothing)

         '# Solo voy a pasar el ID del producto que no se encuentra en stock 
         Dim dtPedidos As DataTable = GetProductosSinStockDetalle()
         Dim dtPedidoSinStock As DataTable = New DataTable()
         dtPedidoSinStock.Columns.Add("IdProducto", GetType(String))

         For Each dr2 As DataRow In dtPedidos.Rows
            If Integer.Parse(dr2("IdSucursal").ToString()) = Integer.Parse(dr("IdSucursal").ToString()) And
               dr2("IdTipoComprobante").ToString() = dr("IdTipoComprobante").ToString() And
               dr2("Letra").ToString() = dr("Letra").ToString() And
               Short.Parse(dr2("CentroEmisor").ToString()) = Short.Parse(dr("CentroEmisor").ToString()) And
               Long.Parse(dr2("NumeroPedido").ToString()) = Long.Parse(dr("NumeroPedido").ToString()) Then

               Dim drSinStockPedido As DataRow = dtPedidoSinStock.NewRow()
               drSinStockPedido("IdProducto") = dr2("IdProducto").ToString()

               dtPedidoSinStock.Rows.Add(drSinStockPedido)
            End If
         Next

         Using frmPedidos As Eniac.Win.PedidosClientesV2 = New Eniac.Win.PedidosClientesV2()

            '# Solo mando los productos sin stock del comprobante que estoy seleccionando
            frmPedidos.ModificarPedido(oPedido, False, Me, dtPedidoSinStock)
         End Using

      Finally
         Me.Buscar()
      End Try

   End Sub

   Private Sub ImprimirListadoCliente(imprimir As Action(Of String, Integer, DateTime, DateTime, Integer, Integer, Integer, Integer, String))
      Dim Filtros As String = String.Empty

      Dim Distribucion As Integer = 0
      Dim IdVendedor As Integer = 0

      Dim cl As Reglas.OrganizarEntregas = New Reglas.OrganizarEntregas()

      If Me.cboRespDistListado.Enabled Then
         Distribucion = DirectCast(Me.cboRespDistListado.SelectedItem, Eniac.Entidades.Transportista).idTransportista
         Filtros = " Resp. de Distribución: " & DirectCast(Me.cboRespDistListado.SelectedItem, Eniac.Entidades.Transportista).NombreTransportista.ToString & " -- "
      End If


      If Me.cboVendListados.Enabled Then
         IdVendedor = DirectCast(Me.cboVendListados.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
         Filtros = Filtros + " Vendedor: " & DirectCast(Me.cboVendListados.SelectedItem, Eniac.Entidades.Empleado).NombreEmpleado & " -- "
      End If

      Filtros = Filtros + " Fecha de envío: desde el " & Me.dtpFechaDesde.Text & " hasta el " & Me.dtpFechaHasta.Text


      Me.Cursor = Cursors.WaitCursor

      imprimir(Filtros, actual.Sucursal.Id, Nothing, Nothing, MinIdReparto(), MaxIdReparto(), Distribucion, IdVendedor, Me.Text)

   End Sub

   Private Sub ImprimirConsolidadoDeCarga(porTipoOperacion As Boolean)
      Try

         Dim Filtros As String = String.Empty
         Dim cl As Reglas.OrganizarEntregas = New Reglas.OrganizarEntregas()


         Dim Distribucion As Integer = 0
         Dim IdVendedor As Integer = 0

         'NumeroReparto = 0

         If Me.cboRespDistListado.Enabled Then
            Distribucion = DirectCast(Me.cboRespDistListado.SelectedItem, Eniac.Entidades.Transportista).idTransportista
            Filtros = " Resp. de Distribución: " & DirectCast(Me.cboRespDistListado.SelectedItem, Eniac.Entidades.Transportista).NombreTransportista.ToString & " -- "
         End If


         If Me.cboVendListados.Enabled Then
            IdVendedor = DirectCast(Me.cboVendListados.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
            Filtros = Filtros + " Vendedor: " & DirectCast(Me.cboVendListados.SelectedItem, Eniac.Entidades.Empleado).NombreEmpleado & " -- "
         End If

         Dim reparto As List(Of Integer) = New List(Of Integer)()
         NumeroReparto = ""
         For Each drRepartos As DataRow In _dtRepartos.Rows
            reparto.Add(Integer.Parse(drRepartos("IdReparto").ToString()))
            NumeroReparto += String.Format("{0},", drRepartos("IdReparto"))
         Next

         Filtros = Filtros + " Nro. Reparto: " & NumeroReparto.Trim().Trim(","c) & " -- "
         Filtros = Filtros + " Fecha de envío: desde el " & Me.dtpFechaDesde.Text & " hasta el " & Me.dtpFechaHasta.Text

         Me.Cursor = Cursors.WaitCursor

         Dim impresion As New ImprimirRepartosConsolidadoCargaMercaderia()

         impresion.Imprimir(Filtros, actual.Sucursal.Id, Nothing, Nothing, reparto.ToArray(), Distribucion, IdVendedor, Me.Text, porTipoOperacion)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      filtro.AppendFormat("Fecha de Envio: {0:dd/MM/yyyy} - {1:dd/MM/yyyy} - ", dtpFechaDesde.Value, dtpFechaHasta.Value)

      Select Case utcPreventa.SelectedTab.Key
         Case "tbpDetallePedidos"
            CargarFiltrosImpresionDetallePedidos(filtro)
         Case "tbpConsolidado"
            filtro.Insert(0, "*** TENTATIVO ***  ")
            filtro.Append("  *** TENTATIVO ***")
         Case Else

      End Select
      Return filtro.ToString.Trim().Trim("-"c).Trim()
   End Function
   Private Sub CargarFiltrosImpresionDetallePedidos(filtro As System.Text.StringBuilder)
      With filtro

         If chbRespDistribucion.Checked And Me.cmbRespDistribucion.SelectedIndex >= 0 Then
            .AppendFormat("Resp. Distr.: {0} - ", Me.cmbRespDistribucion.Text)
         End If

         If chbVendedor.Checked And Me.cmbVendedor.SelectedIndex >= 0 Then
            .AppendFormat("Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         If chbProducto.Checked Then
            .AppendFormat("Producto: {0} - {1} - ", Me.bscCodigoProducto.Text, Me.bscProducto.Text)
         End If

         If chbProdDesc.Checked Then
            .AppendFormat("Producto: {0} - ", txtProducto.Text)
         End If

         If chbArtSinStock.Checked Then
            .AppendFormat("{0} - ", chbArtSinStock.Text)
         End If

      End With
   End Sub

   Private Function MinIdReparto() As Integer
      If _modo = ModoOrganizarEntregas.FACTURACIONMASIVA Then
         Return 0
      Else
         Return Convert.ToInt32(_dtRepartos.Compute("MIN(IdReparto)", String.Empty))
      End If

   End Function

   Private Function MaxIdReparto() As Integer
      If _modo = ModoOrganizarEntregas.FACTURACIONMASIVA Then
         Return 0
      Else
         Return Convert.ToInt32(_dtRepartos.Compute("MAX(IdReparto)", String.Empty))
      End If

   End Function


   Private _dtConsolidadoTemporal As DataTable

   Private Sub RecalculaConsolidadCargaTemporal()
      If _dtConsolidadoTemporal Is Nothing Then
         _dtConsolidadoTemporal = CreaDT()
         ugvConsolidado.DataSource = _dtConsolidadoTemporal
      End If
      _dtConsolidadoTemporal.Clear()

      For Each udrPedidos As UltraGridRow In ugvDetallePedidos.Rows
         If CBool(udrPedidos.Cells("Pasa").Value) Then
            If udrPedidos.ListObject IsNot Nothing AndAlso TypeOf (udrPedidos.ListObject) Is DataRowView AndAlso DirectCast(udrPedidos.ListObject, DataRowView).Row IsNot Nothing Then
               Dim drPedido As DataRow = DirectCast(udrPedidos.ListObject, DataRowView).Row
               For Each drProductos As DataRow In drPedido.GetChildRows("Productos")

                  Dim idTransportista As Integer = 0
                  If Not IsDBNull(drPedido(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString())) Then
                     idTransportista = Integer.Parse(drPedido(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString()).ToString())
                  End If

                  Dim drCol As DataRow() = _dtConsolidadoTemporal.Select(String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5}",
                                                                                       Eniac.Entidades.Producto.Columnas.IdProducto.ToString(),
                                                                                       drProductos(Eniac.Entidades.Producto.Columnas.IdProducto.ToString()),
                                                                                       Eniac.Entidades.Producto.Columnas.CodigoDeBarras.ToString(),
                                                                                       drProductos(Eniac.Entidades.Producto.Columnas.CodigoDeBarras.ToString()),
                                                                                       Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString(),
                                                                                       idTransportista))
                  Dim drConsol As DataRow
                  If drCol.Length > 0 Then
                     drConsol = drCol(0)
                  Else
                     drConsol = _dtConsolidadoTemporal.NewRow()
                     _dtConsolidadoTemporal.Rows.Add(drConsol)
                     drConsol(Eniac.Entidades.Producto.Columnas.IdProducto.ToString()) = drProductos(Eniac.Entidades.Producto.Columnas.IdProducto.ToString())

                     drConsol(Eniac.Entidades.Producto.Columnas.CodigoDeBarras.ToString()) = drProductos(Eniac.Entidades.Producto.Columnas.CodigoDeBarras.ToString())

                     drConsol(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString()) = drProductos(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString())
                     If Not IsDBNull(drPedido(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString())) Then
                        drConsol(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString()) = drPedido(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString())
                        drConsol(Eniac.Entidades.Transportista.Columnas.NombreTransportista.ToString()) = drPedido(Eniac.Entidades.Transportista.Columnas.NombreTransportista.ToString())
                     Else
                        drConsol(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString()) = 0
                        drConsol(Eniac.Entidades.Transportista.Columnas.NombreTransportista.ToString()) = String.Empty
                     End If

                     drConsol(Eniac.Entidades.Rubro.Columnas.IdRubro.ToString()) = drProductos(Eniac.Entidades.Rubro.Columnas.IdRubro.ToString())
                     drConsol(Eniac.Entidades.Rubro.Columnas.NombreRubro.ToString()) = drProductos(Eniac.Entidades.Rubro.Columnas.NombreRubro.ToString())

                     drConsol("OrdenProducto") = drProductos("OrdenProducto")

                     drConsol("Ubicacion") = drProductos("Ubicacion")
                     'drConsol("TipoDocVendedor") = drPedido("TipoDocVendedor")
                     'drConsol("NroDocVendedor") = drPedido("NroDocVendedor")
                     drConsol("NombreVendedor") = drPedido("NombreEmpleado")
                     drConsol(Eniac.Entidades.VentaProducto.Columnas.Cantidad.ToString()) = 0

                     drConsol(Eniac.Entidades.VentaProducto.Columnas.Kilos.ToString()) = drProductos(Eniac.Entidades.VentaProducto.Columnas.Kilos.ToString())
                  End If

                  drConsol(Eniac.Entidades.VentaProducto.Columnas.Cantidad.ToString()) = CDec(drConsol(Eniac.Entidades.VentaProducto.Columnas.Cantidad.ToString())) +
                                                                                         CDec(drProductos(Eniac.Entidades.VentaProducto.Columnas.Cantidad.ToString()))
               Next
            End If
         End If
      Next

      Try
         Dim dt As DataTable = New Reglas.OrganizarEntregas().GetEsqueletos(_dtConsolidadoTemporal)
         ugvConsolidadoEsqueletos.DataSource = dt
         ugvConsolidadoEsqueletos.Rows.ExpandAll(True)
         ugvConsolidadoEsqueletos.Visible = dt.Rows.Count > 0

      Catch ex As Exception
         MessageBox.Show(String.Format("Error obteniendo los esqueletos: {0}.", ex.Message), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      With ugvConsolidado.DisplayLayout
         With .Bands(0)
            Dim summary As SummarySettings
            If Not .Summaries.Exists("Cantidad") Then
               summary = .Summaries.Add("Cantidad", SummaryType.Sum, .Columns("Cantidad"))
               summary.DisplayFormat = "{0:N2}"
               summary.Appearance.TextHAlign = HAlign.Right
            End If
            .SummaryFooterCaption = "Totales:"
         End With
         .Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
         .Override.SummaryValueAppearance.BackColor = Color.Yellow
      End With

      With ugvConsolidadoEsqueletos.DisplayLayout
         With .Bands(0)
            Dim summary As SummarySettings
            If Not .Summaries.Exists("CantidadNec") Then
               summary = .Summaries.Add("CantidadNec", SummaryType.Sum, .Columns("CantidadNec"))
               summary.DisplayFormat = "{0:N2}"
               summary.Appearance.TextHAlign = HAlign.Right
            End If
            .SummaryFooterCaption = "Totales:"
         End With
         .Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
         .Override.SummaryValueAppearance.BackColor = Color.Yellow
      End With

      ugvConsolidado.Rows.ExpandAll(True)
   End Sub

   Private Function CreaDT() As DataTable
      Dim result As DataTable = New DataTable()

      result.Columns.Add(Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString(), GetType(Integer))
      result.Columns.Add(Eniac.Entidades.Transportista.Columnas.NombreTransportista.ToString(), GetType(String))
      result.Columns.Add(Eniac.Entidades.Rubro.Columnas.IdRubro.ToString(), GetType(Integer))
      result.Columns.Add(Eniac.Entidades.Rubro.Columnas.NombreRubro.ToString(), GetType(String))
      result.Columns.Add(Eniac.Entidades.Producto.Columnas.IdProducto.ToString(), GetType(String))

      result.Columns.Add(Eniac.Entidades.Producto.Columnas.CodigoDeBarras.ToString(), GetType(String))

      result.Columns.Add(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString(), GetType(String))
      result.Columns.Add(Eniac.Entidades.VentaProducto.Columnas.Cantidad.ToString(), GetType(Decimal))

      result.Columns.Add(Eniac.Entidades.VentaProducto.Columnas.Kilos.ToString(), GetType(Decimal)) 'PE-31579
      result.Columns.Add("OrdenProducto", GetType(Integer))
      result.Columns.Add("Ubicacion", GetType(String))

      result.Columns.Add("IdVendedor", GetType(Integer))
      ' result.Columns.Add("NroDocVendedor", GetType(String))
      result.Columns.Add("NombreVendedor", GetType(String))

      Return result
   End Function

   Private _dtPedidosPorDistribucion As DataTable
   Private Sub CrearDtResponsableDistribucion()
      _dtPedidosPorDistribucion = New DataTable()
      With _dtPedidosPorDistribucion
         .Columns.Add("NombreTransportista", GetType(String))
         .Columns.Add("NombreEmpleado", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Short))
         .Columns.Add("NumeroComprobante", GetType(Integer))
         .Columns.Add("FechaEnvio", GetType(String))
         .Columns.Add("TipoDocCliente", GetType(String))
         .Columns.Add("NroDocCliente", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("Kilos", GetType(Decimal))
         .Columns.Add("KilosMaximo", GetType(Decimal))
         .Columns.Add("Palets", GetType(Integer))
         .Columns.Add("PaletsMaximo", GetType(Integer))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("Fecha", GetType(String))
      End With

   End Sub
   Private Sub ConsolidarResponsableDistribuccion()

      If _dtPedidosPorDistribucion IsNot Nothing Then _dtPedidosPorDistribucion.Clear()

      For Each drPedido As DataRow In _dsOrganizarEntrega.Tables("Pedidos").Rows
         If Boolean.Parse(drPedido("PASA").ToString()) Then
            Dim drPorTransportista As DataRow = _dtPedidosPorDistribucion.NewRow()
            drPorTransportista("NombreTransportista") = drPedido("NombreTransportista").ToString()
            drPorTransportista("NombreEmpleado") = drPedido("NombreEmpleado").ToString()
            drPorTransportista("IdTipoComprobante") = drPedido("IdTipoComprobante").ToString()
            drPorTransportista("Letra") = drPedido("Letra").ToString()
            drPorTransportista("CentroEmisor") = Short.Parse(drPedido("CentroEmisor").ToString())
            drPorTransportista("NumeroComprobante") = Integer.Parse(drPedido("NumeroPedido").ToString())
            drPorTransportista("FechaEnvio") = drPedido("FechaEntrega").ToString()
            drPorTransportista("TipoDocCliente") = drPedido("TipoDocCliente").ToString()
            drPorTransportista("NroDocCliente") = drPedido("NroDocCliente").ToString()
            drPorTransportista("Direccion") = drPedido("Direccion").ToString()

            drPorTransportista("Kilos") = Decimal.Parse(drPedido("Kilos").ToString())
            If Not String.IsNullOrWhiteSpace(drPedido("KilosMaximo").ToString()) Then
               drPorTransportista("KilosMaximo") = Decimal.Parse(drPedido("KilosMaximo").ToString())
            Else
               drPorTransportista("KilosMaximo") = 0
            End If

            drPorTransportista("Palets") = Integer.Parse(drPedido("Palets").ToString())
            If Not String.IsNullOrWhiteSpace(drPedido("KilosMaximo").ToString()) Then
               drPorTransportista("PaletsMaximo") = Integer.Parse(drPedido("PaletsMaximo").ToString())
            Else
               drPorTransportista("PaletsMaximo") = 0
            End If

            drPorTransportista("ImporteTotal") = Decimal.Parse(drPedido("ImporteTotal").ToString())
            drPorTransportista("IdSucursal") = Integer.Parse(drPedido("IdSucursal").ToString())
            drPorTransportista("Fecha") = drPedido("FechaEntrega").ToString()
            Me._dtPedidosPorDistribucion.Rows.Add(drPorTransportista)
         End If
      Next

      ugvPedidosPorDistribucion.DataSource = _dtPedidosPorDistribucion
      AjustarColumnasGrillaPedidosPorDistribucion()
   End Sub
   Private Sub CreartablaProductosSinstock()
      _dtProductosSinStock = New DataTable()
      With _dtProductosSinStock
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("Stock", GetType(Decimal))
         .Columns.Add("CantidadSolicitada", GetType(Decimal))
         .Columns.Add("CantidadFaltante", GetType(Decimal))
      End With
      _dtDetalleProducto = New DataTable()
      With _dtDetalleProducto
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Short))
         .Columns.Add("NumeroPedido", GetType(Long))
         .Columns.Add("Stock", GetType(Decimal))
         .Columns.Add("Cantidad", GetType(Decimal))
         .Columns.Add("CantidadDividir", GetType(Decimal))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("TipoOperacion", GetType(String))
      End With

      Dim Relacion As DataRelation
      _dsProductoSinStock = New DataSet()
      _dsProductoSinStock.Tables.Add("ProductosSinStock", _dtProductosSinStock)
      _dsProductoSinStock.Tables.Add("ProductosSinStockDetalle", _dtDetalleProducto)



      Relacion = New DataRelation("ProductosSinStock",
                                  {_dtProductosSinStock.Columns("IdProducto")},
                                  {_dtDetalleProducto.Columns("IdProducto")})
      _dsProductoSinStock.Relations.Add(Relacion)
   End Sub
   Private Sub ConsolidarProductoSinStock()
      If _dsProductoSinStock IsNot Nothing Then
         _dsProductoSinStock.Clear()
      End If

      For Each drPedido As DataRow In _dsOrganizarEntrega.Tables("Pedidos").Rows
         If Boolean.Parse(drPedido("PASA").ToString()) Then
            For Each drProducto As DataRow In _dsOrganizarEntrega.Tables("ProductosSinStockDetalle").Rows

               If (Integer.Parse(drPedido("IdSucursal").ToString()) = Integer.Parse(drProducto("IdSucursal").ToString()) And
                drPedido("IdTipoComprobante").ToString() = drProducto("IdTipoComprobante").ToString() And
                drPedido("Letra").ToString() = drProducto("Letra").ToString() And
                Integer.Parse(drPedido("CentroEmisor").ToString()) = Integer.Parse(drProducto("CentroEmisor").ToString()) And
                Long.Parse(drPedido("NumeroPedido").ToString()) = Long.Parse(drProducto("NumeroPedido").ToString())) Then


                  Dim existe As Boolean = False

                  For Each dr As DataRow In _dtProductosSinStock.Select(String.Format("IdProducto = '{0}'", drProducto("IdProducto").ToString()))
                     existe = True
                     dr("CantidadSolicitada") = Decimal.Parse(dr("CantidadSolicitada").ToString()) + Decimal.Parse(drProducto("Cantidad").ToString())
                     If Decimal.Parse(dr("Stock").ToString()) > 0 Then
                        dr("CantidadFaltante") = Decimal.Parse(dr("CantidadSolicitada").ToString()) - Decimal.Parse(dr("Stock").ToString())
                     Else
                        dr("CantidadFaltante") = Decimal.Parse(dr("CantidadSolicitada").ToString())
                     End If

                  Next

                  If existe = False Then
                     Dim drNewProductosSinStock As DataRow = _dtProductosSinStock.NewRow()
                     drNewProductosSinStock("IdProducto") = drProducto("IdProducto").ToString()
                     drNewProductosSinStock("NombreProducto") = drProducto("NombreProducto").ToString()
                     drNewProductosSinStock("Stock") = drProducto("Stock").ToString()
                     drNewProductosSinStock("CantidadSolicitada") = drProducto("Cantidad")
                     If Decimal.Parse(drProducto("Stock").ToString()) <= 0 Then
                        drNewProductosSinStock("CantidadFaltante") = -1 * (Decimal.Parse(drProducto("Stock").ToString()) - Decimal.Parse(drProducto("Cantidad").ToString()))
                     Else
                        drNewProductosSinStock("CantidadFaltante") = Decimal.Parse(drProducto("Cantidad").ToString()) - Decimal.Parse(drProducto("Stock").ToString())
                     End If

                     _dtProductosSinStock.Rows.Add(drNewProductosSinStock)
                  End If

                  Dim drDetalle As DataRow = _dtDetalleProducto.NewRow()
                  drDetalle("IdProducto") = drProducto("IdProducto")
                  drDetalle("IdSucursal") = drProducto("IdSucursal")
                  drDetalle("IdTipoComprobante") = drProducto("IdTipoComprobante")
                  drDetalle("Letra") = drProducto("Letra")
                  drDetalle("CentroEmisor") = drProducto("CentroEmisor")
                  drDetalle("NumeroPedido") = drProducto("NumeroPedido")
                  drDetalle("Cantidad") = drProducto("Cantidad")
                  drDetalle("Stock") = drProducto("Stock")
                  drDetalle("CantidadDividir") = 0D
                  drDetalle("TipoOperacion") = drProducto("TipoOperacion")
                  drDetalle("CodigoCliente") = drProducto("CodigoCliente")
                  drDetalle("NombreCliente") = drProducto("NombreCliente")
                  _dtDetalleProducto.Rows.Add(drDetalle)

               End If
            Next

         End If
      Next

      ProductoSinStockBindingSource.DataSource = _dsProductoSinStock.Tables("ProductosSinStock")
      ProductoSinStockBindingSource.Filter = "CantidadSolicitada>Stock"

      ugvArticulosSinStock.DataSource = ProductoSinStockBindingSource
      AjustarColumnasGrillaProductosSinStock()
   End Sub

   Private Sub AjustarColumnasGrillaPedidosPorDistribucion()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"
      AjustarColumnasGrilla(ugvPedidosPorDistribucion.DisplayLayout.Bands(0), _titPedidosPorDistribucion)
   End Sub

   Private Sub AjustarColumnasGrillaProductosSinStock()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"
      AjustarColumnasGrilla(ugvArticulosSinStock.DisplayLayout.Bands(0), _titArticulosSinStock0)
      AjustarColumnasGrilla(ugvArticulosSinStock.DisplayLayout.Bands(1), _titArticulosSinStock1)

      With ugvArticulosSinStock.DisplayLayout.Bands(1)
         .Override.AllowUpdate = DefaultableBoolean.True
         Dim col As Integer = 0
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 80)
         .Columns("Letra").FormatearColumna("L.", col, 30)
         .Columns("CentroEmisor").FormatearColumna("Emisor", col, 50)
         .Columns("NumeroPedido").FormatearColumna("Número", col, 80, HAlign.Right)
         .Columns("Cantidad").FormatearColumna("Cantidad", col, 80, HAlign.Right, False, "N2")
         .Columns("CantidadDividir").FormatearColumna("Cantidad a Dividir", col, 80, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2, Activation.AllowEdit).Color(Color.Black, Color.LightCyan)
         .Columns("CodigoCliente").FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", col, 250)
         .Columns("TipoOperacion").FormatearColumna("Tipo de Operación", col, 120)
         .Columns("Stock").FormatearColumna("Stock", col, 80, HAlign.Right, False, "N2")

         ugvArticulosSinStock.AgregarTotalesSuma({"CantidadDividir"})

      End With


   End Sub

   Private Sub AjustarColumnasGrillaFacturas()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"
      AjustarColumnasGrilla(ugvFacturas, _titFacturas)
      _titFacturas = GetColumnasVisiblesGrilla(ugvFacturas)
   End Sub

   Private Function GetGrillaExportar() As UltraGrid
      Select Case utcPreventa.SelectedTab.Key
         Case "tbpDetallePedidos"
            Return ugvDetallePedidos
         Case "tbpPedidosSinResponsable"
            Return ugvPedidosPorDistribucion
         Case "tbpArticulosSinStock"
            Return ugvArticulosSinStock
         Case "tbpConsolidado"
            Return ugvConsolidado
         Case "tbpComprobantes"
            Return ugvFacturas
         Case "tbpListados"
            Return Nothing
         Case Else
            Return ugvDetallePedidos
      End Select
   End Function


#Region "Cambio Masivo"
   Private Sub CambiarFechaEnvio()
      Try
         Dim dr As DataRow = GetDrPedidoSeleccionado()

         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una fila.")
         End If
         Me.Cursor = Cursors.WaitCursor

         Using mr As CambiarFechaEnvio = New CambiarFechaEnvio()
            mr.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            mr.Letra = dr("Letra").ToString()
            mr.CentroEmisor = CShort(dr("CentroEmisor").ToString())
            mr.NumeroPedido = CLng(dr("NumeroPedido").ToString())
            If Not IsDBNull(dr("FechaEntrega")) Then
               mr.fecEnvio = CDate(dr("FechaEntrega"))
            End If

            If mr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            ModificaFechaEnvio(GetRowsParaModificar(mr.CambioMasivo, True), mr.fecEnvio)

            MessageBox.Show("Fecha de Envío modificada Exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Using
         Me.Buscar()
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ModificaFechaEnvio(filas As DataRow(), fecEnvio As Date)
      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      oPedidos.ModificaFechaEnvio(filas, fecEnvio)
   End Sub

   Private Sub CambiarResponsableDistribucion()
      Try
         Dim dr As DataRow = GetDrPedidoSeleccionado()

         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una fila.")
         End If

         Me.Cursor = Cursors.WaitCursor

         Using mr As CambiarRespDistribucion = New CambiarRespDistribucion()
            mr.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            mr.Letra = dr("Letra").ToString()
            mr.CentroEmisor = CShort(dr("CentroEmisor").ToString())
            mr.NumeroPedido = CLng(dr("NumeroPedido").ToString())
            mr.NomTransp = dr("NombreTransportista").ToString()

            If mr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            ModificaRespDistribucion(GetRowsParaModificar(mr.CambioMasivo, True), mr.IdRespDist, mr.NomTransp)

            MessageBox.Show("Responsable de Distribución modificado Exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Using

         Me.Buscar()
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ModificaRespDistribucion(filas As DataRow(), idRespDist As Integer, nomTransp As String)
      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      oPedidos.ModificaRespDistribucion(filas, idRespDist, nomTransp)
   End Sub
   Private Sub ModificarPalets()
      Try
         Dim dr As DataRow = GetDrPedidoSeleccionado()

         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una fila.")
         End If

         Me.Cursor = Cursors.WaitCursor

         Using mr As CambiarPalets = New CambiarPalets()

            mr.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            mr.Letra = dr("Letra").ToString()
            mr.CentroEmisor = CShort(dr("CentroEmisor").ToString())
            mr.NumeroPedido = CLng(dr("NumeroPedido").ToString())

            mr.CantidadActual = Integer.Parse(dr("Palets").ToString())

            If mr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            ModificaCantidadPalets(GetRowsParaModificar(mr.CambioMasivo, True), mr.NuevaCantidad)

            MessageBox.Show("La cantidad Palets fue modificada con Exito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Using

         Me.Buscar()
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ModificaCantidadPalets(filas As DataRow(), cantidadPalets As Integer)
      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      oPedidos.ModificaPalets(filas, cantidadPalets)

   End Sub

   Private Sub CambiarFormaPago()
      Try
         Dim dr As DataRow = GetDrPedidoSeleccionado()

         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una fila.")
         End If

         If CBool(dr("Reenvio")) Then
            Throw New Exception(String.Format("El comprobante seleccionado/a es un/a {0} reenviado/a. No es posible cambiar la forma de pago.",
                                              dr("IdTipoComprobante")))
         End If
         Me.Cursor = Cursors.WaitCursor

         Using mr As CambiarFormaPago = New CambiarFormaPago()
            mr.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            mr.Letra = dr("Letra").ToString()
            mr.CentroEmisor = CShort(dr("CentroEmisor").ToString())
            mr.NumeroPedido = CLng(dr("NumeroPedido").ToString())
            mr.IdFormaPago = CInt(dr("IdFormasPago"))
            mr.formaPago = dr("DescripcionFormasPago").ToString()

            If mr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            ModificaFormaPago(GetRowsParaModificar(mr.CambioMasivo, False), mr.IdFormaPago, mr.formaPago)

            MessageBox.Show("Forma de Pago modificada Exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Using
         Me.Buscar()
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ModificaFormaPago(filas As DataRow(), idFormaPago As Integer, formaPago As String)
      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      oPedidos.ModificaFormaPago(filas, idFormaPago, formaPago)
   End Sub

   Private Sub ModificaTipoComprobante(filas As DataRow(), idTipoComprobante As String)
      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      oPedidos.ModificarTComp(filas, idTipoComprobante)
   End Sub

   Private Sub CambiarComprobanteFact()
      Try
         Dim dr As DataRow = GetDrPedidoSeleccionado()


         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una fila.")
         End If

         If CBool(dr("Reenvio")) Then
            Throw New Exception(String.Format("El comprobante seleccionado/a es un/a {0} reenviado/a. No es posible cambiar el tipo de comprobante a generar.",
                                              dr("IdTipoComprobante")))
         End If

         Me.Cursor = Cursors.WaitCursor

         Using mr As CambiarTipoComprobante = New CambiarTipoComprobante()
            mr.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            mr.Letra = dr("Letra").ToString()
            mr.CentroEmisor = CShort(dr("CentroEmisor").ToString())
            mr.NumeroPedido = CLng(dr("NumeroPedido").ToString())
            mr.comprobante = dr("tipoCompCliente").ToString()

            If mr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            ModificaTipoComprobante(GetRowsParaModificar(mr.CambioMasivo, True), mr.comprobante)

            MessageBox.Show("Comprobante a generar modificada Exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Using
         Me.Buscar()

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

   Private Function GetProductosSinStockDetalle() As DataTable
      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("IdProducto", GetType(String))
      dt.Columns.Add("IdSucursal", GetType(Integer))
      dt.Columns.Add("IdTipoComprobante", GetType(String))
      dt.Columns.Add("Letra", GetType(String))
      dt.Columns.Add("CentroEmisor", GetType(Short))
      dt.Columns.Add("NumeroPedido", GetType(Long))

      For Each drProductosSinStock As DataRow In _dsProductoSinStock.Tables("ProductosSinStock").Select("CantidadSolicitada>Stock")
         For Each drProductos As DataRow In _dsOrganizarEntrega.Tables("Productos").Select(String.Format("IdProducto = '{0}'", drProductosSinStock("IdProducto")))
            Dim dr As DataRow = dt.NewRow()
            dt.Rows.Add(dr)
            dr("IdProducto") = drProductos("IdProducto")
            dr("IdSucursal") = drProductos("IdSucursal")
            dr("IdTipoComprobante") = drProductos("IdTipoComprobante")
            dr("Letra") = drProductos("Letra")
            dr("CentroEmisor") = drProductos("CentroEmisor")
            dr("NumeroPedido") = drProductos("NumeroPedido")
         Next
      Next

      Return dt
   End Function

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      Select Case parametros
         Case "FACTURACION MASIVA"
            _modo = ModoOrganizarEntregas.FACTURACIONMASIVA
         Case "SOLO PEDIDOS"
            _modo = ModoOrganizarEntregas.SOLOPEDIDOS
         Case "SOLO VENTAS"
            _modo = ModoOrganizarEntregas.SOLOVENTAS
         Case Else
            _modo = ModoOrganizarEntregas.FULL
      End Select
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
#End Region

End Class