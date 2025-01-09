Public Class PedidosAdmin
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Dim IdEstado As String = String.Empty
   Dim idTipoEstado As String = String.Empty
   Dim InsertaEstado As Boolean = False
   Dim idCriticidad As String = String.Empty
   Dim FechaEntrega As Date? = Nothing
   Private _tipoTipoComprobante As String

   Private IdUsuario As String = actual.Nombre

   Private _puedeVerPrecios As Boolean

   Private _dtEstadosEscritura As DataTable

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         cmbSucursal.Initializar(False, IdFuncion)
         'Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         ' Cargo combo de Origen Vendedor
         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

         ' Carga combo de empleados
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
         cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboSubRubros(cmbSubRubro)
         _publicos.CargaComboCriticidades(cmbCriticidad)
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboEstadosPedidos(cmbEstadoCambiar, False, False, False, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
         _dtEstadosEscritura = New Reglas.EstadosPedidos().GetAll(_tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA, activos:=Entidades.Publicos.SiNoTodos.SI)


         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton

         ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
         cmbEstadoCambiar.SelectedIndex = 0

         ugDetalle.DisplayLayout.Bands(0).Columns("ClipArchivoAdjunto").Hidden = Not Reglas.Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle

         If Not _puedeVerPrecios Then
            'ugDetalle.DisplayLayout.Bands(0).Columns("").Hidden = True
         End If

         ugDetalle.DisplayLayout.Bands(0).Columns("TipoOperacion").Hidden = Not Reglas.Publicos.ProductoPermiteEsBonificable And Not Reglas.Publicos.ProductoPermiteEsCambiable
         ugDetalle.DisplayLayout.Bands(0).Columns("Nota").Hidden = Not Reglas.Publicos.DetallePedido.PedidosMostrarNota

         ugDetalle.DisplayLayout.Bands(0).Columns("CodigoSAE").Hidden = Not Reglas.Publicos.DetallePedido.PedidosMostrarProductoSAE
         ugDetalle.DisplayLayout.Bands(0).Columns("LargoExtAlto").Hidden = Not Reglas.Publicos.DetallePedido.PedidosMostrarProductoLargoExtAlto
         ugDetalle.DisplayLayout.Bands(0).Columns("AnchoIntBase").Hidden = Not Reglas.Publicos.DetallePedido.PedidosMostrarProductoAnchoIntBase
         ugDetalle.DisplayLayout.Bands(0).Columns("UrlPlano").Hidden = Not Reglas.Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle

         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1


         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreProducto", "observacion", "Direccion", "Telefono"}, {"ClipArchivoAdjunto"})

         Dim oUsuario = New Reglas.Usuarios()
         tsbModificarPedido.Visible = oUsuario.TienePermisos("PedidosAdmin-Modif")
         ToolStripSeparator1.Visible = tsbModificarPedido.Visible Or tsbConvertirEnFactura.Visible

         HabilitaDetalle()

         chbFecha.Checked = True

         CargarColumnasASumar()

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         LeerPreferencias()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"


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

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      Try
         Me.cmbMarca.Enabled = Me.chbMarca.Checked

         If Not Me.chbMarca.Checked Then
            Me.cmbMarca.SelectedIndex = -1
         Else
            If Me.cmbMarca.Items.Count > 0 Then
               Me.cmbMarca.SelectedIndex = 0
            End If
         End If

         Me.cmbMarca.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      Try
         Me.cmbRubro.Enabled = Me.chbRubro.Checked

         If Not Me.chbRubro.Checked Then
            Me.cmbRubro.SelectedIndex = -1
         Else
            If Me.cmbRubro.Items.Count > 0 Then
               Me.cmbRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbRubro.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub




   Private Sub PedidosAdmin_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
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

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String = String.Format("{1}{0}{0}{2}{0}{0}{3}", Environment.NewLine, Reglas.Publicos.NombreEmpresa, Me.Text, CargarFiltrosImpresion())

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraPrintPreviewDialog1.Name = Me.Text
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

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         ugDetalle.Exportar(Me.Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         ugDetalle.Exportar(Me.Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbImprimirPredisenado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPredisenado.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String = CargarFiltrosImpresion()

         Using dt As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone()
            dt.ImportRowRange(DirectCast(Me.ugDetalle.DataSource, DataTable).Select("masivo"))

            If dt.Rows.Count = 0 Then
               MessageBox.Show("Debe Seleccionar al Menos un Pedido para poder emitir Listado de Productos Seleccionados!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

            Using frmImprime As VisorReportes = New VisorReportes("Eniac.Win.PedidosAdminSelec.rdlc", "PedidosProductos", dt, parm, True, 1) '# 1 = Cantidad de Copias
               frmImprime.Text = Me.Text
               frmImprime.WindowState = FormWindowState.Maximized
               frmImprime.ShowDialog()
            End Using
         End Using

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

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

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)

         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         'Try
         '    Me.Nuevo()
         'Catch ex1 As Exception
         '    MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         'End Try
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

   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged

      Me.txtIdPedido.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtIdPedido.Text = String.Empty
      Else
         Me.txtIdPedido.Focus()
      End If

   End Sub

   Private Sub chbTamanio_CheckedChanged(sender As Object, e As EventArgs) Handles chbTamanio.CheckedChanged

      Me.txtTamanio.Enabled = Me.chbTamanio.Checked

      If Not Me.chbTamanio.Checked Then
         Me.txtTamanio.Text = "0.000"
      Else
         Me.txtTamanio.Focus()
      End If

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
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

         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.CargaGrillaDetalle()

         HabilitaDetalle()

         If ugDetalle.Rows.Count > 0 Then

            ugDetalle.ActiveRow = ugDetalle.Rows.GetAllNonGroupByRows()(0)
            If ugDetalle.ActiveRow.Cells.Contains("IdEstado") Then
               ugDetalle.ActiveCell = ugDetalle.ActiveRow.Cells("IdEstado")
            End If

            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   'Ademas de tomar el CLIC sobre la fila, toma el desplazamiento con las flechas!!! 
   'Private Sub ugDetalle_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell
   Private Sub ugDetalle_AfterCellActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterCellActivate

      'If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      'If Me.ugDetalle.ActiveCell Is Nothing Then Exit Sub

      'IdEstado = Me.ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString()
      'idTipoEstado = Me.ugDetalle.ActiveCell.Row.Cells("idTipoEstado").Value.ToString()
      'idCriticidad = Me.ugDetalle.ActiveCell.Row.Cells("IdCriticidad").Value.ToString()

      'Try
      '   FechaEntrega = DirectCast(Me.ugDetalle.ActiveCell.Row.Cells("FechaEntrega").Value, Date?)
      'Catch ex As Exception
      '   FechaEntrega = Nothing
      'End Try

      'Me.txtCantidad.Text = Me.ugDetalle.ActiveCell.Row.Cells("CantEntregada").Value.ToString
      'Me.cmbCriticidad.SelectedValue = idCriticidad
      'Me.cmbEstadoCambiar.SelectedValue = IdEstado


      'If FechaEntrega IsNot Nothing Then
      '   dtpFechaEntrega.Value = FechaEntrega.Value
      'Else
      '   dtpFechaEntrega.Value = Today.Date
      'End If

   End Sub

   Private Sub cmdMasivo_Click(sender As Object, e As EventArgs) Handles cmdMasivo.Click
      Try
         Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

         Dim mensage As String = String.Empty
         Dim tablaGrabar As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone
         Dim graba As Boolean = True
         Dim cantTotalProducto As Decimal = 0

         Dim tipoComprobanteEstadoCambia As Entidades.TipoComprobante = Nothing
         If Not String.IsNullOrWhiteSpace(DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row("IdTipoComprobante").ToString()) Then
            tipoComprobanteEstadoCambia = New Reglas.TiposComprobantes().GetUno(DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row("IdTipoComprobante").ToString())
         End If

         If Not _dtEstadosEscritura.Any(Function(dr) dr.Field(Of String)("IdEstado") = cmbEstadoCambiar.Text) Then
            Throw New Exception(String.Format("No tiene permisos para cambiar al estado {0}", cmbEstadoCambiar.Text))
         End If

         If cmbResponsable.Visible AndAlso cmbResponsable.SelectedIndex = -1 Then
            ShowMessage(String.Format("El estado {0}, genera una Orden de Producción. Debe seleccionar un Responsable.", cmbEstadoCambiar.Text))
            Exit Sub
         End If

         Dim estadoSeleccionado As Entidades.EstadoPedido
         estadoSeleccionado = cache.BuscaEstadosPedido(cmbEstadoCambiar.Text, _tipoTipoComprobante)

         If estadoSeleccionado.ReservaStock And estadoSeleccionado.IdDeposito = 0 Then
            ShowMessage(String.Format("El estado {0}, reserva stock. Debe seleccionar Deposito y Ubicacion Por Defecto.", cmbEstadoCambiar.Text))
            Exit Sub
         End If


         Cursor = Cursors.WaitCursor
         For Each fila As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows

            If Boolean.Parse(fila("masivo").ToString) Then


               ''idem cambiar comun!!!
               If fila("IdEstado").ToString() = Me.cmbEstadoCambiar.Text Then

                  idCriticidad = fila("IdCriticidad").ToString()

                  Try
                     FechaEntrega = DirectCast(fila("FechaEntrega"), Date?)
                  Catch ex As Exception
                     FechaEntrega = Nothing
                  End Try

                  If idCriticidad = cmbCriticidad.Text AndAlso FechaEntrega = dtpFechaEntrega.Value AndAlso fila("Observacion").ToString() = txtObservacion.Text Then
                     mensage += String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado a cambiar debe ser distinto al Estado Actual del Pedido o cambiar Criticidad/Fecha de Entrega.", Me, "__ErrorCambioMasivoNoPermitido"), fila("numeropedido")) & vbCrLf
                     graba = False
                  End If

               End If

               If txtCantidad.Enabled Then
                  Dim cantidadNueva As Decimal = 0
                  Dim cantidadEstado As Decimal = 0
                  If IsNumeric(txtCantidad.Text) Then cantidadNueva = Decimal.Parse(txtCantidad.Text)
                  If IsNumeric(fila("CantPendiente")) Then cantidadEstado = Decimal.Parse(fila("CantPendiente").ToString())
                  If cantidadNueva > cantidadEstado Then
                     mensage += String.Format(Traducciones.TraducirTexto("Pedido: {0} --> La cantidad Involucrada supera la Cantidad Pendiente.", Me, "__ErrorCambioMasivoCantidadInvolucrada"), fila("numeropedido")) & vbCrLf
                     graba = False
                  End If
               End If

               'idEstado = oEstado.GetIdEstadosXTipo(fila("IdEstado").ToString).Rows(0)("idEstado").ToString

               If idTipoEstado = Entidades.EstadoPedido.TipoEstado.ANULADO Or
                  idTipoEstado = Entidades.EstadoPedido.TipoEstado.RECHAZADO Or
                  idTipoEstado = Entidades.EstadoPedido.TipoEstado.ENTREGADO Then
                  mensage += String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado Actual NO permite cambio.", Me, "__ErrorEstadoNoPermiteCambio"), fila("numeropedido")) & vbCrLf
                  graba = False
               End If

               If tipoComprobanteEstadoCambia IsNot Nothing AndAlso tipoComprobanteEstadoCambia.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() Then
                  If Not IsNumeric(fila("IdFormula")) Then
                     If Not IsNumeric(fila("IdProcesoProductivo")) Then
                        mensage += String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Producto {1} - '{2}' no tiene definida una Formula o Un Procesos Productivo de Producción. No es posible pasar al módulo de Producción.", Me, "__ErrorCambioMasivoNoPermitido"), fila("numeropedido"), fila("IdProducto"), fila("NombreProducto")) & vbCrLf
                        graba = False
                     End If
                  End If
               End If

               'Se toma la cantidad Pendiente.
               'If idTipoEstado = "PENDIENTE" And Decimal.Parse(Me.txtCantidad.Text) > Decimal.Parse(fila("CantPendiente").ToString()) Then
               '   mensage += "Pedido: " & fila("idpedido").ToString & " --> La Cantidad Involucrada supera la Cantidad Pendiente." & vbCrLf
               '   graba = False
               'End If

               'If idTipoEstado <> "PENDIENTE" And Decimal.Parse(Me.txtCantidad.Text) <> Decimal.Parse(fila("CantEntregada").ToString()) Then
               '   mensage += "Pedido: " & fila("idpedido").ToString & " --> La Cantidad Involucrada es Distinta a la Seleccionada." & vbCrLf
               '   graba = False
               'End If

               If graba Then tablaGrabar.ImportRow(fila)

               graba = True

            End If

         Next

         If Not String.IsNullOrEmpty(mensage) Then
            MessageBox.Show(mensage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         ElseIf tablaGrabar.Rows.Count = 0 Then
            MessageBox.Show("No se han seleccionado filas para el cambio masivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If



         tablaGrabar.Columns.Add("StockActual", GetType(Decimal), "Stock - CantEntregada")

         Dim cantidad As Decimal? = Nothing
         If txtCantidad.Enabled AndAlso IsNumeric(txtCantidad.Text) Then cantidad = Decimal.Parse(txtCantidad.Text)


         Dim respuesta As DialogResult
         If Not estadoSeleccionado.Divide Then
            If estadoSeleccionado.ReservaStock And tablaGrabar.Select("ReservaStock = False").Count > 0 Then
               Using oFormDepo = New PedidosAdminDepositos(tablaGrabar)
                  respuesta = oFormDepo.ShowDialog()
               End Using
               cantidad = Nothing
            Else
               respuesta = ShowPregunta(String.Format(Traducciones.TraducirTexto("¿Desea cambiar masivamente el Estado actual de los Pedidos Seleccionados al Estado: {0}?", Me, "__CambioEstadoMasivo"),
               Me.cmbEstadoCambiar.Text))
            End If
         Else
            respuesta = Windows.Forms.DialogResult.Yes
         End If

         If respuesta = Windows.Forms.DialogResult.Yes Then
            Dim oPedidos As Reglas.PedidosEstados = New Reglas.PedidosEstados()


            Dim IdResponsable As Integer = 0
            If cmbResponsable.SelectedIndex > -1 Then
               Dim responsable As Entidades.Empleado = DirectCast(cmbResponsable.SelectedItem, Entidades.Empleado)
               IdResponsable = responsable.IdEmpleado
            End If

            Dim criticidad2 As String = Nothing
            If Me.chbCriticidad.Checked Then
               criticidad2 = Me.cmbCriticidad.Text
            End If

            Dim fechaEntrega2 As DateTime? = Nothing
            If Me.chbFechaEntrega.Checked Then
               fechaEntrega2 = Me.dtpFechaEntrega.Value
            End If

            If estadoSeleccionado.Divide Then
               Using frmDividor As New PedidosAdminDividir(IdFuncion, _tipoTipoComprobante)
                  If frmDividor.ShowDialog(estadoSeleccionado, tablaGrabar, Me) = Windows.Forms.DialogResult.OK Then
                     oPedidos.ActualizarEstadoPedidoMasivo(String.Empty,
                                                           _tipoTipoComprobante,
                                                           actual.Nombre,
                                                           Me.txtObservacion.Text,
                                                           criticidad2,
                                                           fechaEntrega2,
                                                           Nothing,
                                                           IdResponsable,
                                                           Nothing,
                                                           frmDividor.TablaGrabar,
                                                           Entidades.Entidad.MetodoGrabacion.Automatico,
                                                           Me.IdFuncion)
                  Else
                     Exit Sub
                  End If
               End Using
            Else
               oPedidos.ActualizarEstadoPedidoMasivo(Me.cmbEstadoCambiar.Text,
                                                     _tipoTipoComprobante,
                                                     actual.Nombre,
                                                     Me.txtObservacion.Text,
                                                     criticidad2,
                                                     fechaEntrega2,
                                                     cantidad,
                                                     IdResponsable,
                                                     Nothing,
                                                     tablaGrabar,
                                                     Entidades.Entidad.MetodoGrabacion.Automatico,
                                                     Me.IdFuncion)
            End If

            MessageBox.Show("Estado/s actualizado/s Exitosamente !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.CargaGrillaDetalle()
            HabilitaDetalle()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub cmbEstadoCambiar_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEstadoCambiar.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub cmbResponsable_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbResponsable.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
      Me.cmbEstadoCambiar.SelectedIndex = 0
   End Sub

   Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs) Handles txtCantidad.GotFocus
      Me.txtCantidad.SelectAll()
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.SingleBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "masivo"), Sub(owner) HabilitaDetalle())
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 1

      Me.chbFecha.Checked = False
      Me.chbProducto.Checked = False
      Me.chbCliente.Checked = False
      Me.chbIdPedido.Checked = False
      Me.chbTamanio.Checked = False
      Me.chbOrdenCompra.Checked = False
      Me.chbZonaGeografica.Checked = False

      cmbResponsable.SelectedIndex = -1
      If cmbResponsable.Items.Count = 1 Then
         cmbResponsable.SelectedIndex = 0
      End If

      Me.cmbEstadoCambiar.SelectedIndex = 0

      Me.cmbTodos.SelectedIndex = 0
      Me.txtObservacion.Text = String.Empty
      Me.txtCantidad.Text = "0.00"

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      IdEstado = String.Empty
      idTipoEstado = String.Empty

      cmbSucursal.Refrescar()

      Me.cmbEstados.Focus()

      HabilitaDetalle()
   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos
         Dim IdZonaGeografica As String = String.Empty

         Dim FechaDesde As Date = Nothing
         Dim FechaHasta As Date = Nothing

         Dim IdProducto As String = String.Empty

         Dim IdCliente As Long = 0
         Dim idPedido As Integer = -1
         Dim Tamanio As Decimal = 0

         Dim IdVendedor As Integer = 0
         Dim TipoVendedor As Entidades.OrigenFK

         Dim idMarca As Integer = 0
         Dim idRubro As Integer = 0
         Dim idSubRubro As Integer = 0
         Dim OrdenCompra As Long = 0

         If Me.chbFecha.Checked Then
            FechaDesde = Me.dtpDesde.Value
            FechaHasta = Me.dtpHasta.Value
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Me.cmbEstadoCambiar.SelectedIndex = 0

         If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
         End If

         If Me.chbIdPedido.Checked Then
            idPedido = Integer.Parse(Me.txtIdPedido.Text)
         End If

         If Me.chbTamanio.Checked Then
            Tamanio = Decimal.Parse(Me.txtTamanio.Text)
         End If

         If Me.cmbMarca.Enabled Then
            idMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If

         If Me.cmbRubro.Enabled Then
            idRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.cmbSubRubro.Enabled Then
            idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If

         If Me.chbOrdenCompra.Checked Then
            OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
         End If
         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         ' Tipo de Vendedor
         TipoVendedor = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)

         Dim dtDetalle As DataTable

         dtDetalle = oPedidos.GetPedidos(cmbSucursal.GetSucursales(),
                                         Me.cmbEstados.Text,
                                         FechaDesde, FechaHasta,
                                         idPedido,
                                         IdProducto,
                                         IdCliente,
                                         Tamanio,
                                         idMarca,
                                         idRubro,
                                         idSubRubro,
                                         IdVendedor,
                                         TipoVendedor,
                                         OrdenCompra,
                                         _tipoTipoComprobante,
                                         cmbTiposComprobantes.GetTiposComprobantes(),
                                         "", 0, 0, Nothing,
                                         IdZonaGeografica, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)

         Dim dt As New DataTable
         dt = dtDetalle.Copy
         dt.Columns.Add("Ver")


         'dt = Me.CrearDT()

         'For Each dr As DataRow In dtDetalle.Rows

         '    drCl = dt.NewRow()

         '    drCl("Color") = ""
         '    drCl("IdEstado") = Integer.Parse(dr("IdEstado").ToString())
         '    drCl("NombreEstado") = dr("NombreEstado").ToString()
         '    drCl("IdProducto") = dr("IdProducto").ToString()
         '    drCl("NombreProducto") = dr("NombreProducto").ToString()
         '    drCl("NumeroContrato") = Long.Parse(dr("NumeroContrato").ToString())
         '    drCl("FechaContrato") = Date.Parse(dr("FechaContrato").ToString())
         '    drCl("FechaDesde") = Date.Parse(dr("FechaDesde").ToString())
         '    drCl("FechaHasta") = Date.Parse(dr("FechaHasta").ToString())
         '    drCl("CantDias") = Date.Parse(dr("FechaRealFin").ToString()).Date.Subtract(Date.Parse(dr("FechaDesde").ToString()).Date).TotalDays.ToString
         '    drCl("FechaRealFin") = Date.Parse(dr("FechaRealFin").ToString())
         '    drCl("EsRenovable") = IIf(Boolean.Parse(dr("EsRenovable").ToString()), "SI", "NO")
         '    drCl("NombreCliente") = dr("NombreCliente").ToString()
         '    drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
         '    drCl("IdUsuario") = dr("IdUsuario").ToString()

         '    If Not String.IsNullOrEmpty(dr("Letra").ToString()) Then
         '        drCl("Remito") = dr("Letra").ToString() & " " & Integer.Parse(dr("CentroEmisor").ToString()).ToString("0000") & "-" & Long.Parse(dr("NumeroComprobante").ToString()).ToString("00000000")
         '    End If

         '    dt.Rows.Add(drCl)

         'Next

         Me.ugDetalle.DataSource = dt

         'Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal


         'Me.FormatearGrilla()

         Dim oEstado As Reglas.EstadosPedidos = New Reglas.EstadosPedidos
         'Dim ColorEstado As Integer
         Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

         '###############################################################################################################################################################
         '# Este código se movió de este método y paso a estar en el evento InitializeRow de la grilla para evitar que se rompa cuando se agrupan columnas de la grilla #
         '###############################################################################################################################################################
         '
         'For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugDetalle.Rows
         '
         '   fila.Cells("Ver").Value = "..."
         '   ''TODO: Revisar posible problema de performance.
         '   'ColorEstado = New Reglas.EstadosPedidos().GetUno(fila.Cells("IdEstado").Value.ToString(), _tipoTipoComprobante).Color
         '   ColorEstado = cache.BuscaEstadosPedido(fila.Cells("IdEstado").Value.ToString(), _tipoTipoComprobante).Color
         '
         '   fila.Cells("Color").Appearance.BackColor = Color.FromArgb(ColorEstado)
         '   fila.Cells("Color").ActiveAppearance.BackColor = Color.FromArgb(ColorEstado)
         '
         'Next
         '
         '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

         AjustarColumnasGrilla(ugDetalle, _tit)

         Me.LeerPreferencias()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()

      'Me.calcularSaldoPedido(DirectCast(Me.ugDetalle.DataSource, DataTable))

      ugDetalle.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.Default

      With Me.ugDetalle.DisplayLayout.Bands(0)

         .Columns("color").Header.Caption = "  "
         .Columns("color").Width = 30
         .Columns("color").CellActivation = Activation.NoEdit

         .Columns("masivo").Width = 50
         '.Columns("masivo").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         '.Columns("masivo").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
         '.Columns("masivo").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
         '.Columns("masivo").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

         .Columns("IdSucursal").Hidden = True

         .Columns("idPedido").Header.Caption = "Pedido"
         .Columns("idPedido").Width = 55
         .Columns("idPedido").CellAppearance.TextHAlign = HAlign.Right
         '.Columns("idPedido").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         .Columns("idPedido").CellActivation = Activation.NoEdit

         .Columns("fechaPedido").Header.Caption = "Fecha Pedido"
         .Columns("fechaPedido").Width = 100
         .Columns("fechaPedido").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaPedido").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaPedido").CellActivation = Activation.NoEdit

         .Columns("IdCriticidad").Header.Caption = "Criticidad"
         .Columns("IdCriticidad").Width = 100
         .Columns("IdCriticidad").CellAppearance.TextHAlign = HAlign.Left
         .Columns("IdCriticidad").CellActivation = Activation.NoEdit

         .Columns("FechaEntrega").Header.Caption = "Fecha Entrega"
         .Columns("FechaEntrega").Width = 100
         .Columns("FechaEntrega").CellAppearance.TextHAlign = HAlign.Center
         .Columns("FechaEntrega").Format = "dd/MM/yyyy"
         .Columns("FechaEntrega").CellActivation = Activation.NoEdit

         .Columns("IdCliente").Hidden = True

         .Columns("NombreCliente").Header.Caption = "Nombre Cliente"
         .Columns("NombreCliente").Width = 150
         .Columns("NombreCliente").CellActivation = Activation.NoEdit

         .Columns("idProducto").Header.Caption = "Código Producto"
         .Columns("idProducto").Width = 80
         .Columns("idProducto").CellAppearance.TextHAlign = HAlign.Right


         .Columns("NombreProducto").Header.Caption = "Nombre Producto"
         .Columns("NombreProducto").Width = 200
         .Columns("NombreProducto").CellActivation = Activation.NoEdit

         .Columns("Tamano").Header.Caption = "Tamaño"
         .Columns("Tamano").Width = 60
         .Columns("Tamano").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Tamano").Format = "N4"
         .Columns("Tamano").CellActivation = Activation.NoEdit

         .Columns("Orden").Hidden = True

         .Columns("Cantidad").Header.Caption = "Cant.Pedida"
         .Columns("Cantidad").Width = 70
         .Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Cantidad").Format = "N2"
         .Columns("Cantidad").CellActivation = Activation.NoEdit

         .Columns("fechaEstado").Header.Caption = "Fecha Estado"
         .Columns("fechaEstado").Width = 100
         .Columns("fechaEstado").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaEstado").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaEstado").CellActivation = Activation.NoEdit

         .Columns("idEstado").Header.Caption = "Estado"
         .Columns("idEstado").Width = 90
         .Columns("idEstado").CellActivation = Activation.NoEdit

         .Columns("IdTipoEstado").Hidden = True

         .Columns("CantEntregada").Header.Caption = "Cant.Involucrada"
         .Columns("CantEntregada").Width = 70
         .Columns("CantEntregada").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CantEntregada").Format = "N2"
         .Columns("CantEntregada").CellActivation = Activation.NoEdit

         .Columns("CantPendiente").Header.Caption = "Cant.Pendiente"
         .Columns("CantPendiente").Width = 70
         .Columns("CantPendiente").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CantPendiente").Format = "N2"
         .Columns("CantPendiente").CellAppearance.BackColor = Color.LightCyan
         .Columns("CantPendiente").CellAppearance.FontData.Bold = DefaultableBoolean.True
         .Columns("CantPendiente").CellActivation = Activation.NoEdit

         'pe.IdSucursal, pe.IdTipoComprobante, pe.Letra, pe.CentroEmisor, pe.NumeroComprobante

         .Columns("IdTipoComprobante").Header.Caption = "Comprobante"
         .Columns("IdTipoComprobante").Width = 90
         .Columns("IdTipoComprobante").CellActivation = Activation.NoEdit

         .Columns("Letra").Header.Caption = "Letra"
         .Columns("Letra").Width = 30
         .Columns("Letra").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Letra").CellActivation = Activation.NoEdit

         .Columns("CentroEmisor").Header.Caption = "Emisor"
         .Columns("CentroEmisor").Width = 40
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CentroEmisor").CellActivation = Activation.NoEdit

         .Columns("NumeroComprobante").Header.Caption = "Nro.Comprobante"
         .Columns("NumeroComprobante").Width = 55
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NumeroComprobante").CellActivation = Activation.NoEdit

         .Columns("IdUsuario").Header.Caption = "Usuario"
         .Columns("IdUsuario").Width = 75
         .Columns("IdUsuario").CellActivation = Activation.NoEdit

         .Columns("observacion").Header.Caption = "Observacion"
         .Columns("observacion").Width = 200
         .Columns("observacion").CellActivation = Activation.NoEdit

         '.Columns("saldo").Hidden = True
         '.Columns("cantOriginal").Hidden = True ' se usa para las cuentas...
         '.Columns("saldoFila").Hidden = True ' se usa para las cuentas...

      End With

   End Sub

   'Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow
   Private Sub CargarColumnasASumar()
      Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"cantEntregada", "cantPendiente"})
   End Sub

   'Private Function CrearDT() As DataTable

   '    Dim dtTemp As DataTable = New DataTable()

   '    With dtTemp
   '        '.Columns.Add("Color")
   '        .Columns.Add("Color", System.Type.GetType("System.String"))
   '        .Columns.Add("IdEstado", System.Type.GetType("System.Int32"))
   '        .Columns.Add("IdProducto", System.Type.GetType("System.String"))
   '        .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
   '        .Columns.Add("NumeroContrato", System.Type.GetType("System.Int64"))
   '        .Columns.Add("FechaContrato", System.Type.GetType("System.DateTime"))
   '        .Columns.Add("FechaDesde", System.Type.GetType("System.DateTime"))
   '        .Columns.Add("FechaHasta", System.Type.GetType("System.DateTime"))
   '        .Columns.Add("CantDias", System.Type.GetType("System.Int32"))
   '        .Columns.Add("FechaRealFin", System.Type.GetType("System.DateTime"))
   '        .Columns.Add("EsRenovable", System.Type.GetType("System.String"))
   '        .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
   '        .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
   '        .Columns.Add("IdUsuario", System.Type.GetType("System.String"))
   '        .Columns.Add("Remito", System.Type.GetType("System.String"))
   '    End With

   '    Return dtTemp

   'End Function

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         filtro.AppendFormatLine("Filtros: Estado: {0}", Me.cmbEstados.Text)

         If Me.chbFecha.Checked Then
            filtro.AppendFormatLine(" - Rango de Fechas: desde el {0:dd/MM/yyyy} hasta el {1:dd/MM/yyyy}", Me.dtpDesde.Value, Me.dtpHasta.Value)
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)
         If Me.chbIdPedido.Checked Then
            filtro.AppendFormatLine(" - Número: {0}", txtIdPedido.Text)
         End If

         If Me.chbCliente.Checked Then
            filtro.AppendFormatLine(" - Cliente: {0} - {1}", Me.bscCodigoCliente.Text.Trim(), Me.bscCliente.Text.Trim())
         End If

         If Me.chbOrdenCompra.Checked Then
            filtro.AppendFormatLine(" - Orden de Compra: {0} ", txtOrdenCompra.Text)
         End If

         If Me.chbTamanio.Checked Then
            filtro.AppendFormatLine(" - {1}: {0} ", txtOrdenCompra.Text, chbOrdenCompra.Text)
         End If

         If Me.chbProducto.Checked Then
            filtro.AppendFormatLine(" - Producto: {0} - {1}", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            filtro.AppendFormatLine("Marca: {0}", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            filtro.AppendFormatLine("Rubro: {0}", Me.cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            filtro.AppendFormatLine("SubRubro: {0}", Me.cmbSubRubro.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

   Private Sub cmbCriticidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCriticidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub


   Private Sub dtpFechaEntrega_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEntrega.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub tsbModificarPedido_Click(sender As Object, e As EventArgs) Handles tsbModificarPedido.Click
      Try
         AbrePedidoParaModificar(False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbCopiarPedido_Click(sender As Object, e As EventArgs) Handles tsbCopiarPedido.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.tssInfo.Text = "Copiando Pedido...."
         Application.DoEvents()
         Me.AbrePedidoParaModificar(True)
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tssInfo.Text = ""
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub AbrePedidoParaModificar(esCopia As Boolean)
      If ugDetalle.ActiveRow IsNot Nothing AndAlso
         ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

         Dim dr As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row

         Dim oPedido As Entidades.Pedido = New Reglas.Pedidos().GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                                       dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                       dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                                       Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                                       Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()))

         Using frmPedidos As PedidosClientesV2 = New PedidosClientesV2()
            frmPedidos.IdFuncion = IdFuncion
            frmPedidos.SetParametros(_tipoTipoComprobante)
            frmPedidos.ModificarPedido(oPedido, esCopia, Me, Nothing)
         End Using

         Me.btnConsultar.PerformClick()

      Else
         Throw New Exception(Traducciones.TraducirTexto("Por favor seleccione un pedido.", Me, "__NoSeleccionoPedidoModificar"))
      End If
   End Sub

   Private Sub tsbConvertirEnFactura_Click(sender As Object, e As EventArgs) Handles tsbConvertirEnFactura.Click
      Try
         If ugDetalle.ActiveRow IsNot Nothing AndAlso
            ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
            Dim dr As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
            Dim rPedido As Reglas.Pedidos = New Reglas.Pedidos()
            Dim rVenta As Reglas.Ventas = New Reglas.Ventas()
            Dim caja As Entidades.CajaNombre = New Reglas.CajasNombres().GetTodas(actual.Sucursal.IdSucursal)(0)
            Dim idReparto As Integer = rVenta.GetUltNumeroReparto()

            Dim oPedido As Entidades.Pedido = rPedido.GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                                          dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                          dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                                          Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                                          Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()))

            Dim venta As Entidades.Venta = rPedido.ConvertirPedidoEnVenta(oPedido, caja.IdCaja, idReparto)
            rVenta.Insertar(venta, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
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

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub HabilitaDetalle()
      Dim cantidadSeleccionados As Integer = 0
      Dim drCol As DataRow() = Nothing
      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         drCol = DirectCast(ugDetalle.DataSource, DataTable).Select("masivo")
         cantidadSeleccionados = drCol.Length
      End If

      Me.chbCriticidad.Enabled = cantidadSeleccionados > 0
      Me.chbFechaEntrega.Enabled = cantidadSeleccionados > 0
      cmbCriticidad.Enabled = cantidadSeleccionados = 1
      cmbEstadoCambiar.Enabled = cantidadSeleccionados > 0
      dtpFechaEntrega.Enabled = cantidadSeleccionados = 1
      txtObservacion.Enabled = cantidadSeleccionados > 0
      txtCantidad.Enabled = cantidadSeleccionados = 1

      Me.chbCriticidad.Checked = cantidadSeleccionados = 1
      Me.chbFechaEntrega.Checked = cantidadSeleccionados = 1


      cmdMasivo.Enabled = cantidadSeleccionados > 0

      If cantidadSeleccionados = 1 And drCol IsNot Nothing Then
         Dim dr As DataRow = drCol(0)

         IdEstado = dr("IdEstado").ToString()
         idTipoEstado = dr("idTipoEstado").ToString()
         idCriticidad = dr("IdCriticidad").ToString()

         Try
            Me.chbFechaEntrega.Checked = True
            FechaEntrega = DirectCast(dr("FechaEntrega"), Date?)
         Catch ex As Exception
            FechaEntrega = Nothing
         End Try

         Me.txtCantidad.Text = dr("CantEntregada").ToString()

         Me.chbCriticidad.Checked = True
         Me.cmbCriticidad.SelectedValue = idCriticidad
         Me.cmbEstadoCambiar.SelectedValue = IdEstado

         If FechaEntrega IsNot Nothing Then
            dtpFechaEntrega.Value = FechaEntrega.Value
         Else
            dtpFechaEntrega.Value = Today.Date
         End If
      End If

   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      ugDetalle.UpdateData()
      HabilitaDetalle()
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then

            ' Declaración de variables
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            Dim oEstado As Reglas.EstadosPedidos = New Reglas.EstadosPedidos
            Dim ColorEstado As Integer
            Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

            e.Row.Cells("Ver").Value = "..."
            ''TODO: Revisar posible problema de performance.
            'ColorEstado = New Reglas.EstadosPedidos().GetUno(fila.Cells("IdEstado").Value.ToString(), _tipoTipoComprobante).Color
            ColorEstado = cache.BuscaEstadosPedido(e.Row.Cells("IdEstado").Value.ToString(), _tipoTipoComprobante).Color

            e.Row.Cells("Color").Appearance.BackColor = Color.FromArgb(ColorEstado)
            e.Row.Cells("Color").ActiveAppearance.BackColor = Color.FromArgb(ColorEstado)

            If Not String.IsNullOrWhiteSpace(row("UrlPlano").ToString()) Then
               e.Row.Cells("ClipArchivoAdjunto").Style = UltraWinGrid.ColumnStyle.EditButton
               e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
            Else
               e.Row.Cells("ClipArchivoAdjunto").Activation = Activation.Disabled
            End If

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugdDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Me.Cursor = Cursors.WaitCursor

         If e.Cell IsNot Nothing AndAlso
            e.Cell.Row IsNot Nothing AndAlso
            e.Cell.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row

            Select Case e.Cell.Column.Key
               Case "Ver"

                  Dim oPedido As Entidades.Pedido = New Reglas.Pedidos().GetUno(Integer.Parse(row(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                                                row(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                                row(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                                                Short.Parse(row(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                                                Long.Parse(row(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()))
                  Dim impresion As ImpresionPedidos = New ImpresionPedidos()
                  impresion.ImprimirPedido(oPedido, True)

               Case "UrlPlano"

                  Dim urlPlano As String = row("UrlPlano").ToString()
                  If Not String.IsNullOrWhiteSpace(urlPlano) Then
                     Try
                        Process.Start(urlPlano)
                     Catch ex As Exception
                        ShowError(ex)
                     End Try
                  End If

            End Select

         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub cmbEstadoCambiar_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstadoCambiar.SelectedValueChanged
      Try
         cmbResponsable.Visible = False
         lblResponsable.Visible = False
         If cmbEstadoCambiar.SelectedIndex > -1 AndAlso
            TypeOf (cmbEstadoCambiar.SelectedItem) Is DataRowView AndAlso
            DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row IsNot Nothing AndAlso
            Not String.IsNullOrWhiteSpace(DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row("IdTipoComprobante").ToString()) Then
            Dim idTipoComprobante As String = DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row("IdTipoComprobante").ToString()
            Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)
            If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() Then
               cmbResponsable.Visible = True
               lblResponsable.Visible = True
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCriticidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbCriticidad.CheckedChanged
      Try
         If Me.chbCriticidad.Checked Then
            Me.cmbCriticidad.Enabled = True
         Else
            Me.cmbCriticidad.Enabled = False
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      Try
         If Me.chbFechaEntrega.Checked Then
            Me.dtpFechaEntrega.Enabled = True
         Else
            Me.dtpFechaEntrega.Enabled = False
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.SufijoXML = _tipoTipoComprobante
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
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

End Class