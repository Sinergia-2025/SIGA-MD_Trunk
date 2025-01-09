Public Class InfPedidosDetallados
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private IdUsuario As String = actual.Nombre
   Private _tipoTipoComprobante As String
   Private _puedeVerPrecios As Boolean
   Private _puedeVerPrecioCosto As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         Me._publicos = New Publicos()


         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")
         _puedeVerPrecioCosto = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPCosto")

         Me._publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
         _publicos.CargaComboProduccionProcesos(cmbProduccionProceso)

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         Me.cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         _publicos.CargaComboListaPreciosPedidos(Me.cmbListaPrecios)

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         With ugDetalle.DisplayLayout.Bands(0)

            Dim pedidosMostrarTamano As Boolean = Publicos.DetallePedido.PedidosMostrarTamano
            Dim pedidosMostrarUM As Boolean = Publicos.DetallePedido.PedidosMostrarUM

            .Columns(Entidades.PedidoProducto.Columnas.Tamano.ToString()).Hidden = Not pedidosMostrarTamano
            .Columns("TamanoProducto").Hidden = pedidosMostrarTamano
            .Columns(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).Hidden = Not pedidosMostrarUM
            .Columns("IdUnidadDeMedidaProducto").Hidden = pedidosMostrarUM
            .Columns(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarPrecioVentaPorTamano
            .Columns(Entidades.Moneda.Columnas.Simbolo.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarMoneda
            '' ''.Columns(Entidades.PedidoProducto.Columnas.Costo.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarCosto
            '' ''.Columns("ContribucionMarginalPorc").Hidden = Not Publicos.DetallePedido.PedidosMostrarSemaforoRentabilidadDetalle

            .Columns(Entidades.PedidoProducto.Columnas.Espmm.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoEspmm
            .Columns(Entidades.PedidoProducto.Columnas.EspPulgadas.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoEspPulgadas
            .Columns(Entidades.PedidoProducto.Columnas.CodigoSAE.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoSAE
            .Columns(Entidades.ProduccionProceso.Columnas.NombreProduccionProceso.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoProduccionProceso
            .Columns(Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoProduccionForma
            .Columns(Entidades.PedidoProducto.Columnas.LargoExtAlto.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoLargoExtAlto
            .Columns(Entidades.PedidoProducto.Columnas.AnchoIntBase.ToString()).Hidden = Not Publicos.DetallePedido.PedidosMostrarProductoAnchoIntBase

            .Columns("TipoOperacion").Hidden = Not Reglas.Publicos.ProductoPermiteEsBonificable And Not Reglas.Publicos.ProductoPermiteEsCambiable
            .Columns("Nota").Hidden = Not Publicos.DetallePedido.PedidosMostrarNota
            .Columns("UrlPlano").Hidden = Not Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle
            '.Columns("ObservacinGeneral").Header.VisiblePosition = 1

         End With

         If Not _puedeVerPrecios Then
            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioLista").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("Precio").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("DescuentoRecargoPorc").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("DescuentoRecargoPorc2").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("PrecioNeto").Hidden = True

            ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("SubTotal").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestoInterno").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestos").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("CotizacionDolar").Hidden = True
         End If

         If Not _puedeVerPrecioCosto Then
            ugDetalle.DisplayLayout.Bands(0).Columns("Costo").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("CostoActual").Hidden = True
         End If

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {})

         Me.CargarColumnasASumar()

         Me.LeerPreferencias()
         _tit = GetColumnasVisiblesGrilla(ugDetalle)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfPedidosDetallados_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro


         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         If Me.chbFecha.Checked Then
            .AppendFormat(" Rango de Fechas: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbProducto.Checked Then
            .AppendFormat("  Producto: {0} - {1} ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat("  Marca: {0} - ", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.Text)
         End If

         If Me.cmbUsuario.Enabled Then
            .AppendFormat(" Usuario: {0} - ", Me.cmbUsuario.SelectedValue.ToString())
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text


         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.chkMesCompleto.Enabled = Me.chbFecha.Checked
      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Not Me.chbFecha.Checked Then
         Me.chkMesCompleto.Checked = False
         Me.dtpDesde.Value = DateTime.Today
         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpDesde.Focus()
      End If

   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Dim FechaTemp As Date
      Try
         If chkMesCompleto.Checked Then
            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp
         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked
      Catch ex As Exception
         chkMesCompleto.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked

      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
         Me.chbMarca.Checked = False
         Me.chbRubro.Checked = False
         Me.bscCodigoProducto2.Focus()
      End If

   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged

      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
         'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
         'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
         Me.cmbMarca.Focus()
      End If

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged

      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         Me.cmbRubro.SelectedIndex = 0
         'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
         'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
         Me.cmbRubro.Focus()
      End If
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing

      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbIdPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIdPedido.CheckedChanged

      Me.txtIdPedido.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtIdPedido.Text = String.Empty
      Else
         Me.txtIdPedido.Focus()
      End If

   End Sub

   Private Sub chbTamanio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTamanio.CheckedChanged

      Me.txtTamanio.Enabled = Me.chbTamanio.Checked

      If Not Me.chbTamanio.Checked Then
         Me.txtTamanio.Text = "0.000"
      Else
         Me.txtTamanio.Focus()
      End If

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbMarca.Focus()
            Exit Sub
         End If

         If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbRubro.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbProv.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtIdPedido.Text) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            Me.txtIdPedido.Focus()
            Exit Sub
         End If

         If Me.chbTamanio.Checked AndAlso Decimal.Parse("0" & Me.txtTamanio.Text) = 0 Then
            MessageBox.Show("ATENCION: NO Ingresó un Tamaño aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtTamanio.Focus()
            Exit Sub
         End If

         If chbEspPulgadas.Checked AndAlso String.IsNullOrWhiteSpace(txtEspPulgadas.Text) Then
            ShowMessage("ATENCION: NO Ingresó un Esp. "" aunque activó ese Filtro.")
            Me.txtEspPulgadas.Focus()
            Exit Sub
         End If

         If chbEspmm.Checked AndAlso Not IsNumeric(txtEspmm.Text) Then
            ShowMessage("ATENCION: NO Ingresó un Esp. mm aunque activó ese Filtro.")
            Me.txtEspmm.Focus()
            Exit Sub
         End If

         If chbSAE.Checked AndAlso Not IsNumeric(txtSAE.Text) Then
            ShowMessage("ATENCION: NO Ingresó un SAE aunque activó ese Filtro.")
            Me.txtSAE.Focus()
            Exit Sub
         End If

         If chbProduccionProceso.Checked AndAlso cmbProduccionProceso.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO Ingresó un Proceso aunque activó ese Filtro.")
            Me.cmbProduccionProceso.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.SingleBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedor As Reglas.Proveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedor.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            'If Short.Parse("0" & Me.txtEmisorFactura.Text) > 0 Then
            '    Me.bscCodigoProducto.Focus()
            'Else
            '    Me.txtEmisorFactura.Focus()
            'End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProv.CheckedChanged


      Me.bscCodigoProveedor.Enabled = Me.chbProv.Checked
      Me.bscProveedor.Enabled = Me.chbProv.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      Try
         Me.txtOrdenCompra.Enabled = Me.chbOrdenCompra.Checked

         If Not Me.chbOrdenCompra.Checked Then
            Me.txtOrdenCompra.Text = String.Empty
         Else
            Me.txtOrdenCompra.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged

      Me.chkMesCompletoEntrega.Enabled = Me.chbFechaEntrega.Checked
      Me.dtpDesdeEntrega.Enabled = Me.chbFechaEntrega.Checked
      Me.dtpHastaEntrega.Enabled = Me.chbFechaEntrega.Checked

      If Not Me.chbFechaEntrega.Checked Then
         Me.chkMesCompletoEntrega.Checked = False
         Me.dtpDesdeEntrega.Value = DateTime.Today
         Me.dtpHastaEntrega.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpDesdeEntrega.Focus()
      End If

   End Sub

   Private Sub chkMesCompletoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      Dim FechaTemp As Date
      Try
         If chkMesCompletoEntrega.Checked Then
            FechaTemp = New Date(Me.dtpDesdeEntrega.Value.Year, Me.dtpDesdeEntrega.Value.Month, 1)
            Me.dtpDesdeEntrega.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesdeEntrega.Value.AddMonths(1).AddSeconds(-1)
            dtpHastaEntrega.Value = FechaTemp
         End If

         Me.dtpDesdeEntrega.Enabled = Not Me.chkMesCompletoEntrega.Checked
         Me.dtpHastaEntrega.Enabled = Not Me.chkMesCompletoEntrega.Checked
      Catch ex As Exception
         chkMesCompletoEntrega.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEspPulgadas_CheckedChanged(sender As Object, e As EventArgs) Handles chbEspPulgadas.CheckedChanged
      Try
         txtEspPulgadas.Enabled = chbEspPulgadas.Checked
         If Not Me.chbEspPulgadas.Checked Then
            txtEspPulgadas.Text = String.Empty
         Else
            txtEspPulgadas.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEspmm_CheckedChanged(sender As Object, e As EventArgs) Handles chbEspmm.CheckedChanged
      Try
         txtEspmm.Enabled = chbEspmm.Checked
         If Not Me.chbEspmm.Checked Then
            txtEspmm.Text = "0.000"
         Else
            txtEspmm.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbSAE_CheckedChanged(sender As Object, e As EventArgs) Handles chbSAE.CheckedChanged
      Try
         txtSAE.Enabled = chbSAE.Checked
         If Not Me.chbSAE.Checked Then
            txtSAE.Text = String.Empty
         Else
            txtSAE.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProduccionProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chbProduccionProceso.CheckedChanged
      Try
         cmbProduccionProceso.Enabled = chbProduccionProceso.Checked
         If Not chbProduccionProceso.Checked Then
            cmbProduccionProceso.SelectedIndex = -1
         Else
            If cmbProduccionProceso.Items.Count > 0 Then
               cmbProduccionProceso.SelectedIndex = 0
            End If
         End If
         cmbProduccionProceso.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   'Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow
   Private Sub CargarColumnasASumar()

      Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"cantEntregada", "cantPendiente", "TamanoTotal", "Costo", "SubTotal", "ImporteTotal", "TotalImpuestoInterno", "TotalImpuestos"})

      'Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("cantEntregada")
      'Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("cantEntregada", SummaryType.Sum, columnToSummarize1)
      'summary1.DisplayFormat = "{0:N2}"
      'summary1.Appearance.TextHAlign = HAlign.Right

      'Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("cantPendiente")
      'Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("cantPendiente", SummaryType.Sum, columnToSummarize2)
      'summary2.DisplayFormat = "{0:N2}"
      'summary2.Appearance.TextHAlign = HAlign.Right
      'summary2.Appearance.BackColor = Color.LightCyan
      'summary2.Appearance.FontData.Bold = DefaultableBoolean.True

      'Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      'Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)


      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString

      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 0

      Me.chbFecha.Checked = False
      Me.chbCliente.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbProducto.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbProducto.Checked = False
      Me.chbIdPedido.Checked = False
      Me.chbTamanio.Checked = False
      Me.chbOrdenCompra.Checked = False
      Me.chbProv.Checked = False
      Me.chbZonaGeografica.Checked = False

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.cmbEstados.Focus()
      chbListaPrecios.Checked = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim FechaDesdeEntrega As Date? = Nothing
      Dim FechaHastaEntrega As Date? = Nothing

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim idPedido As Integer = -1
      Dim Tamanio As Decimal = 0
      Dim OrdenCompra As Long = 0

      Dim IdCliente As Long = 0
      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim espPulgadas As String = String.Empty
      Dim espmm As Decimal? = Nothing
      Dim sae As Integer? = Nothing
      Dim idProceso As Integer = 0
      Dim IdZonaGeografica As String = String.Empty
      Dim listaPrecios As String = ""

      If Me.chbFecha.Checked Then
         FechaDesde = Me.dtpDesde.Value
         FechaHasta = Me.dtpHasta.Value
      End If

      If chbFechaEntrega.Checked Then
         FechaDesdeEntrega = dtpDesdeEntrega.Value
         FechaHastaEntrega = dtpHastaEntrega.Value
      End If

      If Me.chbProducto.Checked Then
         idProducto = Me.bscCodigoProducto2.Text.Trim()
      End If

      If Me.chbMarca.Checked Then
         IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.chbRubro.Checked Then
         IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If

      If Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbProv.Checked Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.cmbUsuario.Enabled Then
         IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
      End If

      If Me.chbIdPedido.Checked Then
         idPedido = Integer.Parse(Me.txtIdPedido.Text)
      End If

      If Me.chbTamanio.Checked Then
         Tamanio = Decimal.Parse(Me.txtTamanio.Text)
      End If

      If Me.chbOrdenCompra.Checked Then
         OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
      End If

      If Me.chbVendedor.Checked Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      If chbEspPulgadas.Checked Then
         espPulgadas = txtEspPulgadas.Text
      End If
      If chbEspmm.Checked Then
         espmm = Decimal.Parse(txtEspmm.Text)
      End If
      If chbSAE.Checked Then
         sae = Integer.Parse(txtSAE.Text)
      End If
      If chbProduccionProceso.Checked Then
         idProceso = Integer.Parse(cmbProduccionProceso.SelectedValue.ToString())
      End If

      If Me.cmbZonaGeografica.Enabled Then
         IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
      End If

      If Me.cmbListaPrecios.Enabled Then
         listaPrecios = Me.cmbListaPrecios.SelectedValue.ToString()
      End If

      Dim dtDetalle As DataTable
      ', dt As DataTable, drCl As DataRow

      dtDetalle = oPedidos.GetPedidosDetalladoXEstados(actual.Sucursal.Id,
                                                         Me.cmbEstados.Text,
                                                         FechaDesde, FechaHasta,
                                                         FechaDesdeEntrega, FechaHastaEntrega,
                                                         idPedido,
                                                         idProducto,
                                                         IdMarca,
                                                         IdRubro,
                                                         lote,
                                                         IdCliente,
                                                         IdUsuario,
                                                         Tamanio,
                                                         IdVendedor,
                                                         OrdenCompra,
                                                         _tipoTipoComprobante,
                                                         cmbTiposComprobantes.GetTiposComprobantes(),
                                                         espPulgadas,
                                                         espmm,
                                                         sae,
                                                         idProceso,
                                                         IdProveedor,
                                                         IdZonaGeografica,
                                                         listaPrecios)

      Me.ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)
      'Me.FormatearGrilla()

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSCLIE")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

   Protected Overridable Sub LeerPreferencias()
      Try

         Dim nameGrid As String = Me.ugDetalle.FindForm().Name + _tipoTipoComprobante & "Grid.xml"
         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            If row.Table.Columns.Contains("Color") AndAlso IsNumeric(e.Row.Cells("Color").Value) Then
               e.Row.Cells("IdEstado").Appearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").Appearance.AlphaLevel = 128
               e.Row.Cells("IdEstado").Appearance.ForegroundAlpha = Alpha.Opaque

               e.Row.Cells("IdEstado").ActiveAppearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").ActiveAppearance.BackColorAlpha = Alpha.Opaque
               e.Row.Cells("IdEstado").ActiveAppearance.ForegroundAlpha = Alpha.Opaque
            End If
            If row.Table.Columns.Contains(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()) AndAlso
               Not row(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).Equals(Entidades.Producto.TiposOperaciones.NORMAL.ToString()) Then
               e.Row.Cells(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).Appearance.FontData.Bold = DefaultableBoolean.True
               e.Row.Cells(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).ActiveAppearance.FontData.Bold = DefaultableBoolean.True
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If e.Cell.Column.Key = "CantComponentes" Then
            Dim dr As DataRow = GetSelectedRow()
            If dr IsNot Nothing Then
               Using frm As New ConsultarProductosFormulas()
                  Dim rPPF As Reglas.PedidosProductosFormulas = New Reglas.PedidosProductosFormulas()

                  Dim dt As DataTable = rPPF.GetAll(Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdSucursal.ToString()).ToString()),
                                                    dr(Entidades.PedidoProducto.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                    dr(Entidades.PedidoProducto.Columnas.Letra.ToString()).ToString(),
                                                    Integer.Parse(dr(Entidades.PedidoProducto.Columnas.CentroEmisor.ToString()).ToString()),
                                                    Long.Parse(dr(Entidades.PedidoProducto.Columnas.NumeroPedido.ToString()).ToString()),
                                                    dr(Entidades.PedidoProducto.Columnas.IdProducto.ToString()).ToString(),
                                                    Integer.Parse(dr(Entidades.PedidoProducto.Columnas.Orden.ToString()).ToString()))
                  If dt.Rows.Count > 0 Then
                     frm.ShowDialog(dt)
                  End If
               End Using
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function GetSelectedRow() As DataRow
      If ugDetalle.ActiveRow IsNot Nothing AndAlso
         ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
         Return DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
      End If
      Return Nothing
   End Function

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.SufijoXML = _tipoTipoComprobante
         pre.ShowDialog()
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()
      End If
   End Sub

   Private Sub tsbImprimirPredisenado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPredisenado.Click
      TryCatched(
         Sub()
            If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

            Using dtMov As DataTable = DirectCast(ugDetalle.DataSource, DataTable)
               Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

               Dim Filtros As String = CargarFiltrosImpresion()

               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DecimalesEnPrecio", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio(actual.Sucursal).ToString()))
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

               Dim frmImprime = New VisorReportes("Eniac.Win.PedidosInfDetallado.rdlc", "PedidosProductos", dtMov, parm, True, 1) With {
               .Text = Text,
               .WindowState = FormWindowState.Maximized
               }
               frmImprime.Show()
            End Using
         End Sub)
   End Sub

   Private Sub chbListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecios.CheckedChanged
      Try
         Me.cmbListaPrecios.Enabled = Me.chbListaPrecios.Checked

         If Not Me.chbListaPrecios.Checked Then
            Me.cmbListaPrecios.SelectedIndex = -1
         Else
            Me.cmbListaPrecios.SelectedIndex = 0
            Me.cmbListaPrecios.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class