Public Class ConsultarPedidos
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _dtsMaster_detalle As DataSet
   Private _dtDetalle As DataTable
   Private _dtPedidoDetalle As DataTable
   Private _dtPedidoDetalleComprobante As DataTable
   Private _tipoTipoComprobante As String

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit2 As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _puedeVerPrecios As Boolean
   Private _puedeVerPrecioCosto As Boolean

   Private IdUsuario As String = actual.Nombre

#End Region

   Private Const imprimirCompColumnKey As String = "ImprimirComp"
   Private Const imprimirCabConCantidadColumnKey As String = "ImprimirCabConCantidad"
   Private Const imprimirCabColumnKey As String = "ImprimirCab"

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

            _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")
            _puedeVerPrecioCosto = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPCosto")

            cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
            cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

            _publicos = New Publicos()

            _publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
            cmbEstados.SelectedIndex = 1

            chbFecha.Checked = True
            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

            _publicos.CargaComboUsuarios(cmbUsuario)
            _publicos.CargaComboListaDePrecios(cmbListaPrecios, activa:=True, insertarEnPosicionCero:=Nothing)

            ' Cargo combo de Origen Vendedor
            _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
            cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
               IdUsuario = ""
            End If

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
            If IdUsuario = "" Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            ugDetalle.DisplayLayout.Bands("Detalle").Columns("ClipArchivoAdjunto").Hidden = Not Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle

            If Not _puedeVerPrecios Then
               ugDetalle.DisplayLayout.Bands("Cabecera").Columns("ImporteTotal").Hidden = True

               ugDetalle.DisplayLayout.Bands("Detalle").Columns("PrecioLista").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Columns("Precio").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Columns("DescuentoRecargoPorc").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Columns("DescuentoRecargoPorc2").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Columns("PrecioNeto").Hidden = True

               ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImporteTotal").Hidden = True
               ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImportePesos").Hidden = True
            End If

            If Not _puedeVerPrecioCosto Then
               ugDetalle.DisplayLayout.Bands("Detalle").Columns("Costo").Hidden = True
            End If

            ugDetalle.DisplayLayout.Bands("Detalle").Columns("TipoOperacion").Hidden = Not Reglas.Publicos.ProductoPermiteEsBonificable And Not Reglas.Publicos.ProductoPermiteEsCambiable
            ugDetalle.DisplayLayout.Bands("Detalle").Columns("Nota").Hidden = Not Publicos.DetallePedido.PedidosMostrarNota

            If _tipoTipoComprobante = "PEDIDOSCLIE" Then
               ugDetalle.DisplayLayout.Bands("Detalle").Groups("GENERADO").Hidden = True

               If Not Reglas.Publicos.TieneModuloProduccion Then
                  ugDetalle.DisplayLayout.Bands("Detalle").Groups("PRODUCCION").Hidden = True
               End If
               If Not Reglas.Publicos.VisualizaStockFuturoReservado Then
                  ugDetalle.DisplayLayout.Bands("Detalle").Groups("VINCULADO").Hidden = True
               End If
            Else
               ugDetalle.DisplayLayout.Bands("Detalle").Groups("FACT").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Groups("REMITO").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Groups("PRODUCCION").Hidden = True
               ugDetalle.DisplayLayout.Bands("Detalle").Groups("VINCULADO").Hidden = True
            End If

            _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
            _tit1 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Detalle"))
            _tit2 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Comprobante"))

            ugDetalle.AgregarFiltroEnLineaMultiBanda({({"NombreCliente"}), ({"NombreProducto"})})
            '  Me.CargarColumnasASumar()

            PreferenciasLeer(ugDetalle, tsbPreferencias)
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

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()

            If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
               MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               cmbVendedor.Focus()
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

            If Me.chbListaPrecios.Checked And Me.cmbListaPrecios.SelectedIndex = -1 Then
               MessageBox.Show("ATENCION: Debe seleccionar una LISTA DE PRECIOS.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               cmbListaPrecios.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End Sub)

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         'IO.File.WriteAllText("d:\Temp\_turco\pedidos_20171005.json", New Reglas.Pedidos().ConvertToJson())

         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

         If Me.chbFecha.Checked Then
            Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
         End If

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
         End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged

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

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

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

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

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

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
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

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
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

   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged

      Me.txtIdPedido.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtIdPedido.Text = String.Empty
      Else
         Me.txtIdPedido.Focus()
      End If

   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      cmbOrigenVendedor.Enabled = True

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

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
#End Region

#Region "Eventos Grilla"
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         'Dim oReportePedido As New Entidades.Pedido
         'Dim dtsPedido As New dtsPedido

         'Abre el adjunto de la línea del pedido.
         If e.Cell.Column.Key = "ClipArchivoAdjunto" Then
            Try
               If e.Cell IsNot Nothing AndAlso
                  e.Cell.Row IsNot Nothing AndAlso
                  e.Cell.Row.ListObject IsNot Nothing AndAlso
                  TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
                  DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
                  Dim row As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
                  Dim urlPlano As String = row("UrlPlano").ToString()
                  If Not String.IsNullOrWhiteSpace(urlPlano) Then
                     Try
                        Process.Start(urlPlano)
                     Catch ex As Exception
                        ShowError(ex)
                     End Try
                  End If
               End If
               Exit Sub
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If

         'Imprimer el comprobante Fact o Remito según corresponda.
         If e.Cell.Column.Key = imprimirCompColumnKey Then

            Dim IdSucursal As Integer = 0
            Dim letra As String = String.Empty
            Dim IdTipoComprobante As String = String.Empty
            Dim CentroEmisor As Short = 0
            Dim NumeroComprobante As Long = 0

            IdSucursal = Integer.Parse(e.Cell.Row.Cells("IdSucursalFact").Value.ToString())
            IdTipoComprobante = e.Cell.Row.Cells("IdTipoComprobante").Value.ToString
            letra = e.Cell.Row.Cells("letra").Value.ToString
            CentroEmisor = Short.Parse(e.Cell.Row.Cells("CentroEmisor").Value.ToString)
            NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString)

            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim Comprobante As Entidades.Venta = oVentas.GetUna(IdSucursal, IdTipoComprobante, letra, CentroEmisor, NumeroComprobante)
            Dim oImpr As Impresion = New Impresion(Comprobante)
            Dim ReporteEstandar As Boolean = True

            oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)
         End If

         'Imprimer el Pedido (estandar o detallado)
         If e.Cell.Column.Key = imprimirCabColumnKey Or e.Cell.Column.Key = imprimirCabConCantidadColumnKey Then
            Dim IdSucursal As Integer = Integer.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.IdSucursal.ToString()).Value.ToString())
            Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).Value.ToString()
            Dim letra As String = e.Cell.Row.Cells(Entidades.Pedido.Columnas.Letra.ToString()).Value.ToString()
            Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.CentroEmisor.ToString()).Value.ToString())
            Dim numeroPedido As Long = Long.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.NumeroPedido.ToString()).Value.ToString())

            Dim oPedido As Entidades.Pedido = New Reglas.Pedidos().GetUno(IdSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
            Dim impresion As ImpresionPedidos = New ImpresionPedidos()

            If e.Cell.Column.Header.Caption = "Ver" Then
               'Reporte = "Eniac.Win.PedidoV2.rdlc"
               impresion.ImprimirPedido(oPedido, True)
            Else
               'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
               impresion.ImprimirPedidoDetallado(oPedido, True)
            End If
         End If

         'Abre la ventana con los contactos del Pedido
         If e.Cell.Column.Key = "CantidadContactos" Then
            If String.IsNullOrEmpty(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CantidadContactos").Value.ToString()) Then Exit Sub

            Dim Pedido As Entidades.Pedido = New Reglas.Pedidos().GetUno(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                        Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                        Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                        Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                        Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroPedido").Value.ToString()))

            Dim cl As ConsultarContactos = New ConsultarContactos(Pedido.TipoComprobante.IdTipoComprobante,
                                                          Pedido.LetraComprobante,
                                                          Pedido.CentroEmisor,
                                                          Pedido.NumeroPedido,
                                                          1)

            cl.ShowDialog()

         End If

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
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

      For Each banda As UltraGridBand In e.Layout.Bands
         If banda.Key <> "Detalle" Then
            banda.HeaderVisible = True
            banda.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            banda.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Else
            banda.HeaderVisible = False
         End If
      Next

   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            If row.Table.Columns.Contains("UrlPlano") Then
               If Not e.Row.Band.Columns.Exists("ClipArchivoAdjunto") Then
                  Dim col = e.Row.Band.Columns.Add("ClipArchivoAdjunto", "")
                  col.MaxWidth = 20
                  col.Width = 14
               End If
               If Not String.IsNullOrWhiteSpace(row("UrlPlano").ToString()) Then
                  e.Row.Cells("ClipArchivoAdjunto").Style = UltraWinGrid.ColumnStyle.EditButton
                  e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
               Else
                  e.Row.Cells("ClipArchivoAdjunto").Activation = Activation.Disabled
               End If
            End If
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

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub
#End Region

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

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
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

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
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

   Private Sub chbProv_CheckedChanged(sender As Object, e As EventArgs) Handles chbProv.CheckedChanged


      Me.bscCodigoProveedor.Enabled = Me.chbProv.Checked
      Me.bscProveedor.Enabled = Me.chbProv.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub


#End Region

#Region "Metodos"

   'Private Sub CargarColumnasASumar()
   '   Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"CantEstado", "cantPendiente"})
   'End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)


      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString

      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 1

      Me.chbFecha.Checked = False
      Me.chbCliente.Checked = False
      Me.chbUsuario.Checked = False

      Me.chbIdPedido.Checked = False
      Me.chbOrdenCompra.Checked = False
      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbFecha.Checked = True
      Me.chbProv.Checked = False

      If Me.ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataSet Then
         DirectCast(Me.ugDetalle.DataSource, DataSet).Clear()
      End If

      Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

      Me.cmbEstados.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim IdPedido As Integer = -1
      Dim OrdenCompra As Long = 0
      Dim Tamanio As Decimal = 0
      Dim IdProveedor As Long = 0

      Dim IdCliente As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0
      Dim TipoVendedor As Entidades.OrigenFK

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim idPed_str As String = String.Empty

      If Me.chbFecha.Checked Then
         FechaDesde = Me.dtpDesde.Value
         FechaHasta = Me.dtpHasta.Value
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
         IdPedido = Integer.Parse(Me.txtIdPedido.Text)
      End If

      If Me.chbOrdenCompra.Checked Then
         OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
      End If

      If Me.chbVendedor.Checked Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      ' Tipo de Vendedor
      TipoVendedor = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)

      _dtsMaster_detalle = New DataSet()

      _dtDetalle = oPedidos.pedidosCabecera(actual.Sucursal.Id,
                                           Me.cmbEstados.Text, alMenosUno_TodosSean:=True,
                                           FechaDesde, FechaHasta,
                                           cmbTiposComprobantes.GetTiposComprobantes(),
                                           letra:="",
                                           centroEmisor:=0,
                                           numeroPedidoDesde:=IdPedido,
                                           numeroPedidoHasta:=IdPedido,
                                           idProducto:=idProducto,
                                           idCliente:=IdCliente,
                                           idUsuario:=IdUsuario,
                                           idVendedor:=IdVendedor,
                                           tipoVendedor:=TipoVendedor,
                                           ordenCompra:=OrdenCompra,
                                           tipoTipoComprobante:=_tipoTipoComprobante,
                                           idProveedor:=IdProveedor,
                                           categorias:={},
                                           origenCategorias:=Entidades.OrigenFK.Actual,
                                           numeroReparto:=0,
                                           numeroRepartoHasta:=0,
                                           idFormasPago:=0,
                                           cmbListaPrecios.ValorSeleccionado(chbListaPrecios, -1I),
                                           impreso:=Entidades.Publicos.SiNoTodos.TODOS)

      If _dtDetalle.Rows.Count = 0 Then
         'If Me.ugDetalle.Rows.Count > 0 Then Me.ugDetalle.DataSource = Nothing ' (Me.ugDetalle.DataSource, DataSet).Tables.Clear()
         If TypeOf (ugDetalle.DataSource) Is DataSet Then DirectCast(ugDetalle.DataSource, DataSet).Clear()
         If TypeOf (ugDetalle.DataSource) Is DataTable Then DirectCast(ugDetalle.DataSource, DataTable).Clear()
         'End If
         Exit Sub
      End If



      _dtDetalle.TableName = "Cabecera"

      _dtsMaster_detalle.Tables.Add(_dtDetalle)

      _dtPedidoDetalle = oPedidos.GetPedidosDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                cmbEstados.Text,
                                                FechaDesde, FechaHasta,
                                                cmbTiposComprobantes.GetTiposComprobantes(),
                                                "", 0,
                                                IdPedido,
                                                IdPedido,
                                                idProducto,
                                                IdMarca,
                                                IdRubro,
                                                lote,
                                                IdCliente,
                                                IdUsuario,
                                                Tamanio,
                                                IdVendedor,
                                                TipoVendedor,
                                                OrdenCompra,
                                                _tipoTipoComprobante,
                                                IdProveedor,
                                                categorias:={},
                                                origenCategorias:=Entidades.OrigenFK.Actual,
                                                numeroReparto:=0,
                                                numeroRepartoHasta:=0,
                                                idFormasPago:=0,
                                                cmbListaPrecios.ValorSeleccionado(chbListaPrecios, -1I),
                                                chbMostrarAnulacionesPorModificacion.Checked)

      _dtPedidoDetalle.TableName = "detalle"
      _dtsMaster_detalle.Tables.Add(_dtPedidoDetalle)

      Dim ColumnasPadre(4) As DataColumn
      Dim ColumnasHijo(4) As DataColumn
      ColumnasPadre(0) = _dtsMaster_detalle.Tables("Cabecera").Columns("IdSucursal")
      ColumnasPadre(1) = _dtsMaster_detalle.Tables("Cabecera").Columns("IdTipoComprobante")
      ColumnasPadre(2) = _dtsMaster_detalle.Tables("Cabecera").Columns("CentroEmisor")
      ColumnasPadre(3) = _dtsMaster_detalle.Tables("Cabecera").Columns("Letra")
      ColumnasPadre(4) = _dtsMaster_detalle.Tables("Cabecera").Columns("NumeroPedido")
      ColumnasHijo(0) = _dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasHijo(1) = _dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasHijo(2) = _dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasHijo(3) = _dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasHijo(4) = _dtsMaster_detalle.Tables("detalle").Columns("NumeroPedido")

      Dim relConstEnum As DataRelation = New DataRelation("Detalle", ColumnasPadre, ColumnasHijo, True)
      _dtsMaster_detalle.Relations.Add(relConstEnum)

      _dtPedidoDetalleComprobante = oPedidos.GetPedidosDetalleComprobante(actual.Sucursal.Id,
                                                                         cmbEstados.Text,
                                                                         FechaDesde, FechaHasta,
                                                                         IdPedido,
                                                                         idProducto,
                                                                         IdMarca,
                                                                         IdRubro,
                                                                         lote,
                                                                         IdCliente,
                                                                         IdUsuario,
                                                                         Tamanio,
                                                                         IdVendedor,
                                                                         TipoVendedor,
                                                                         OrdenCompra,
                                                                         _tipoTipoComprobante,
                                                                         cmbTiposComprobantes.GetTiposComprobantes(),
                                                                         cmbListaPrecios.ValorSeleccionado(chbListaPrecios, -1I),
                                                                         chbMostrarAnulacionesPorModificacion.Checked)

      _dtPedidoDetalleComprobante.TableName = "dtPedidoDetalleComp"
      _dtsMaster_detalle.Tables.Add(_dtPedidoDetalleComprobante)

      Dim ColumnasPadre1(7) As DataColumn
      Dim ColumnasHijo1(7) As DataColumn
      ColumnasPadre1(0) = _dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasPadre1(1) = _dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasPadre1(2) = _dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasPadre1(3) = _dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasPadre1(4) = _dtsMaster_detalle.Tables("detalle").Columns("NumeroPedido")
      ColumnasPadre1(5) = _dtsMaster_detalle.Tables("detalle").Columns("IdProducto")
      ColumnasPadre1(6) = _dtsMaster_detalle.Tables("detalle").Columns("FechaEstado")
      ColumnasPadre1(7) = _dtsMaster_detalle.Tables("detalle").Columns("Orden")

      ColumnasHijo1(0) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdSucursal")
      ColumnasHijo1(1) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdTipoComprobanteP")
      ColumnasHijo1(2) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("CentroEmisorP")
      ColumnasHijo1(3) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("LetraP")
      ColumnasHijo1(4) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("NumeroPedido")
      ColumnasHijo1(5) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdProducto")
      ColumnasHijo1(6) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("FechaEstado")
      ColumnasHijo1(7) = _dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("Orden")

      relConstEnum = New DataRelation("Comprobante", ColumnasPadre1, ColumnasHijo1, False)
      _dtsMaster_detalle.Relations.Add(relConstEnum)

      Me.ugDetalle.SetDataBinding(_dtsMaster_detalle, "Cabecera")

      Me.ugDetalle.DataSource = _dtsMaster_detalle

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Columns.Exists(imprimirCabColumnKey) Then
         Me.ugDetalle.DisplayLayout.Bands(0).Columns.Add(imprimirCabColumnKey, "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabColumnKey).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabColumnKey).Header.VisiblePosition = 0
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabColumnKey).Width = 30
         If Not _tit.ContainsKey(imprimirCabColumnKey) Then _tit.Add(imprimirCabColumnKey, "")
      End If

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Columns.Exists(imprimirCabConCantidadColumnKey) Then
         Me.ugDetalle.DisplayLayout.Bands(0).Columns.Add(imprimirCabConCantidadColumnKey, "Ver/Cant.").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabConCantidadColumnKey).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabConCantidadColumnKey).Header.VisiblePosition = 1
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabConCantidadColumnKey).Width = 60
         If Not _tit.ContainsKey(imprimirCabConCantidadColumnKey) Then _tit.Add(imprimirCabConCantidadColumnKey, "")
      End If

      If Not Me.ugDetalle.DisplayLayout.Bands(2).Columns.Exists(imprimirCompColumnKey) Then
         Me.ugDetalle.DisplayLayout.Bands(2).Columns.Add(imprimirCompColumnKey, "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(2).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(2).Columns(imprimirCompColumnKey).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(2).Columns(imprimirCompColumnKey).Header.VisiblePosition = 0
         Me.ugDetalle.DisplayLayout.Bands(2).Columns(imprimirCompColumnKey).Width = 30
         'Me.ugDetalle.DisplayLayout.Bands(2).Groups("Detalle").Columns.Add(Me.ugDetalle.DisplayLayout.Bands(2).Columns(btnImprimirComp), 0)
         If Not _tit2.ContainsKey(imprimirCompColumnKey) Then _tit2.Add(imprimirCompColumnKey, "")
      End If

      AjustarColumnasGrilla()
      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
      PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      'AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Detalle"), _tit1)
      FormatearColumnasDetalle()
      'AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Comprobante"), _tit2)
      FormatearColumnasComprobante()
   End Sub

   Private Sub FormatearColumnasDetalle()
      For Each col In ugDetalle.DisplayLayout.Bands("Detalle").Columns
         col.Hidden = True
      Next

      Dim pos = 0I
      With ugDetalle.DisplayLayout.Bands("Detalle")
         .Columns("IdProducto").FormatearColumna("Nro. Prod.", pos, 90, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 200)
         .Columns("Tamano").FormatearColumna("Tamaño", pos, 60, HAlign.Right, , "N2")
         .Columns("IdUnidadDeMedida").FormatearColumna("U.M.", pos, 40, HAlign.Center)
         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 80, HAlign.Right, , "N2")
         .Columns("fechaEstado").FormatearColumna("Fecha Estado", pos, 90, HAlign.Center)
         .Columns("IdEstado").FormatearColumna("Estado", pos, 90).CellAppearance.FontData.Bold = DefaultableBoolean.True
         .Columns("CantEstado").FormatearColumna("Cant. Estado", pos, 80, HAlign.Right, , "N2")
         .Columns("CantPendiente").FormatearColumna("Cant. Pendiente", pos, 80, HAlign.Right, , "N2")

         .Columns("IdTipoComprobanteFact").FormatearColumna("Comprob.", pos, 65)
         .Columns("LetraFact").FormatearColumna("L.", pos, 20)
         .Columns("CentroEmisorFact").FormatearColumna("Emis.", pos, 40, HAlign.Right)
         .Columns("NumeroComprobanteFact").FormatearColumna("Número", pos, 70, HAlign.Right)

         .Columns("IdTipoComprobanteRemito").FormatearColumna("Comprob.", pos, 65)
         .Columns("LetraRemito").FormatearColumna("L.", pos, 20)
         .Columns("CentroEmisorRemito").FormatearColumna("Emis.", pos, 40, HAlign.Right)
         .Columns("NumeroComprobanteRemito").FormatearColumna("Número", pos, 70, HAlign.Right)

         .Columns("IdTipoComprobanteGenerado").FormatearColumna("Comprob.", pos, 65)
         .Columns("LetraGenerado").FormatearColumna("L.", pos, 20)
         .Columns("CentroEmisorGenerado").FormatearColumna("Emis.", pos, 40, HAlign.Right)
         .Columns("NumeroPedidoGenerado").FormatearColumna("Número", pos, 70, HAlign.Right)

         .Columns("IdTipoComprobanteProduccion").FormatearColumna("Comprob.", pos, 65)
         .Columns("LetraProduccion").FormatearColumna("L.", pos, 20)
         .Columns("CentroEmisorProduccion").FormatearColumna("Emis.", pos, 40, HAlign.Right)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Número", pos, 70, HAlign.Right)

         .Columns("IdTipoComprobanteVinculado").FormatearColumna("Comprob.", pos, 65)
         .Columns("LetraVinculado").FormatearColumna("L.", pos, 20)
         .Columns("CentroEmisorVinculado").FormatearColumna("Emis.", pos, 40, HAlign.Right)
         .Columns("NumeroPedidoVinculado").FormatearColumna("Número", pos, 70, HAlign.Right)

         .Columns("NombreListaPrecios").FormatearColumna("Lista de Precios", pos, 100)
         .Columns("TipoOperacion").FormatearColumna("Tp. Oper.", pos, 62)
         .Columns("Nota").FormatearColumna("Nota", pos, 150)

         .Columns("NombreFormula").FormatearColumna("Fórmula", pos, 100)
         .Columns("CantComponentes").FormatearColumna("", pos, 30)

         .Columns("Costo").FormatearColumna("Costo", pos, 80, HAlign.Right, , "N2")
         .Columns("PrecioLista").FormatearColumna("Precio Lista", pos, 80, HAlign.Right, , "N2")
         .Columns("Precio").FormatearColumna("Precio", pos, 80, HAlign.Right, , "N2")

         .Columns("DescuentoRecargoPorc").FormatearColumna("% D/R1", pos, 70, HAlign.Right, , "N2")
         .Columns("DescuentoRecargoPorc2").FormatearColumna("% D/R2", pos, 70, HAlign.Right, , "N2")

         .Columns("PrecioNeto").FormatearColumna("Precio Neto", pos, 80, HAlign.Right, , "N2")
         .Columns("CodigoProcesoProductivo").FormatearColumna("Código Proceso Productivo", pos, 80, HAlign.Right)
         .Columns("DescripcionProceso").FormatearColumna("Proceso Productivo", pos, 80, HAlign.Right)
         .Columns("NumeroReparto").FormatearColumna("Reparto", pos, 80, HAlign.Right)

         '.Columns("ClipArchivoAdjunto").FormatearColumna("", pos, 14).Style = ColumnStyle.Button
         '.Columns("ClipArchivoAdjunto").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         If Not .Groups.Exists("Detalle") Then
            Dim grupoDetalle = .Groups.Add("Detalle", "Detalle")
            grupoDetalle.Columns.Add(.Columns("IdProducto"))
            grupoDetalle.Columns.Add(.Columns("NombreProducto"))
            grupoDetalle.Columns.Add(.Columns("Tamano"))
            grupoDetalle.Columns.Add(.Columns("IdUnidadDeMedida"))
            'grupoDetalle.Columns.Add(.Columns("ClipArchivoAdjunto"))
            grupoDetalle.Columns.Add(.Columns("fechaEstado"))
            grupoDetalle.Columns.Add(.Columns("IdEstado"))
            grupoDetalle.Columns.Add(.Columns("CantPendiente"))
            grupoDetalle.Columns.Add(.Columns("CantEstado"))
            grupoDetalle.Columns.Add(.Columns("Costo"))
            grupoDetalle.Columns.Add(.Columns("PrecioLista"))
            grupoDetalle.Columns.Add(.Columns("Precio"))
            grupoDetalle.Columns.Add(.Columns("DescuentoRecargoPorc"))
            grupoDetalle.Columns.Add(.Columns("DescuentoRecargoPorc2"))
            grupoDetalle.Columns.Add(.Columns("PrecioNeto"))
            grupoDetalle.Columns.Add(.Columns("CodigoProcesoProductivo"))
            grupoDetalle.Columns.Add(.Columns("DescripcionProceso"))
            grupoDetalle.Columns.Add(.Columns("NombreListaPrecios"))
            grupoDetalle.Columns.Add(.Columns("TipoOperacion"))
            grupoDetalle.Columns.Add(.Columns("Nota"))
            grupoDetalle.Columns.Add(.Columns("NombreFormula"))
            grupoDetalle.Columns.Add(.Columns("CantComponentes"))
            grupoDetalle.Columns.Add(.Columns("NumeroReparto"))
         End If

         If Not .Groups.Exists("FACT") Then
            Dim grupoFacturo = .Groups.Add("FACT", "Facturó")
            grupoFacturo.Columns.Add(.Columns("IdTipoComprobanteFact"))
            grupoFacturo.Columns.Add(.Columns("LetraFact"))
            grupoFacturo.Columns.Add(.Columns("CentroEmisorFact"))
            grupoFacturo.Columns.Add(.Columns("NumeroComprobanteFact"))
         End If

         If Not .Groups.Exists("REMITO") Then
            Dim grupoRemitio = .Groups.Add("REMITO", "Remitió")
            grupoRemitio.Columns.Add(.Columns("IdTipoComprobanteRemito"))
            grupoRemitio.Columns.Add(.Columns("LetraRemito"))
            grupoRemitio.Columns.Add(.Columns("CentroEmisorRemito"))
            grupoRemitio.Columns.Add(.Columns("NumeroComprobanteRemito"))
         End If

         If Not .Groups.Exists("GENERADO") Then
            Dim grupoGenero = .Groups.Add("GENERADO", "Pedido Generado")
            grupoGenero.Columns.Add(.Columns("IdTipoComprobanteGenerado"))
            grupoGenero.Columns.Add(.Columns("LetraGenerado"))
            grupoGenero.Columns.Add(.Columns("CentroEmisorGenerado"))
            grupoGenero.Columns.Add(.Columns("NumeroPedidoGenerado"))
         End If

         If Not .Groups.Exists("PRODUCCION") Then
            Dim grupoProduccion = .Groups.Add("PRODUCCION", "Orden de Producción")
            grupoProduccion.Columns.Add(.Columns("IdTipoComprobanteProduccion"))
            grupoProduccion.Columns.Add(.Columns("LetraProduccion"))
            grupoProduccion.Columns.Add(.Columns("CentroEmisorProduccion"))
            grupoProduccion.Columns.Add(.Columns("NumeroOrdenProduccion"))
         End If

         If Not .Groups.Exists("VINCULADO") Then
            Dim grupoVinculado = .Groups.Add("VINCULADO", "Pedido de Compra Vinculado")
            grupoVinculado.Columns.Add(.Columns("IdTipoComprobanteVinculado"))
            grupoVinculado.Columns.Add(.Columns("LetraVinculado"))
            grupoVinculado.Columns.Add(.Columns("CentroEmisorVinculado"))
            grupoVinculado.Columns.Add(.Columns("NumeroPedidoVinculado"))
         End If

         If _tipoTipoComprobante = "PEDIDOSCLIE" Then
            .Groups("GENERADO").Hidden = True
            If Not Reglas.Publicos.TieneModuloProduccion Then
               .Groups("PRODUCCION").Hidden = True
            End If
            If Not Reglas.Publicos.VisualizaStockFuturoReservado Then
               .Groups("VINCULADO").Hidden = True
            End If
         Else
            .Groups("FACT").Hidden = True
            .Groups("REMITO").Hidden = True
            .Groups("PRODUCCION").Hidden = True
            .Groups("VINCULADO").Hidden = True
         End If

         For Each grupo In .Groups
            grupo.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Next

      End With

   End Sub

   Private Sub FormatearColumnasComprobante()
      For Each col In ugDetalle.DisplayLayout.Bands("Comprobante").Columns
         col.Hidden = True
      Next

      Dim pos = 0I
      With ugDetalle.DisplayLayout.Bands("Comprobante")
         .Columns("IdTipoComprobante").FormatearColumna("Comprob.", pos, 65)

         .Columns("Fecha").FormatearColumna("Fecha", pos, 79, HAlign.Center)
         .Columns("Observacion").FormatearColumna("Observación", pos, 300)

         .Columns("idCaja").FormatearColumna("Id Caja", pos, 60, HAlign.Right)
         .Columns("NumeroPlanilla").FormatearColumna("Planilla", pos, 90)
         .Columns("NumeroMovimiento").FormatearColumna("Número Movimiento", pos, 110)

         .Columns("ImportePesos").FormatearColumna("Importe Pesos", pos, 100, HAlign.Right, , "N2")
         .Columns("ImporteTotal").FormatearColumna("Importe Total", pos, 100, HAlign.Right, , "N2")

      End With

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

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub chbListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecios.CheckedChanged
      TryCatched(Sub() chbListaPrecios.FiltroCheckedChanged(cmbListaPrecios))
   End Sub



#End Region

End Class