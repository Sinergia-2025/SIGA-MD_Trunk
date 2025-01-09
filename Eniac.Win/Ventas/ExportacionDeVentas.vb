Public Class ExportacionDeVentas
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _VentasPDA As VentasPDA
   Private _VentasHolistor As Reglas.VentasExportarDatos
   Private _VentasSellOut As Reglas.VentasExportarSellOut
   Private _VentasMostradorAndina As VentasMostradorAndina
   Private _VentasMostradorAndinaDetalle As VentasMostradorAndinaDetalle
   Private _Tipo As String = String.Empty
   Private _tipoComprobantePedido As String = String.Empty
   'Private _tipoComprobanteVenta As String = String.Empty
   Private _estaCargando As Boolean = True
   Private _listaTiposComprobantes As List(Of Entidades.TipoComprobante)
   'Private _lis As List(Of Entidades.TipoComprobante)
   Private _columnaSelec As String = "Selec"
   Private _CodAFIPFacturaA As Integer = 1
   Private _exportacionHolistor As Boolean
   Private _exportacionSellOut As Boolean
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = DateTime.Today
         Me.dtpHasta.Value = DateTime.Today.UltimoSegundoDelDia()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "PEDIDOSCLIE")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboDesdeEnum(cmbExportarVentasFormato, GetType(Reglas.Publicos.ExportacionVentasEnum), , True)


         cmbTiposComprobantesVenta.Initializar(False, "VENTAS")
         Me.cmbTiposComprobantesVenta.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 0

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal


         If Not String.IsNullOrEmpty(_Tipo) Then
            Me.cmbExportarVentasFormato.SelectedValue = (DirectCast([Enum].Parse(GetType(Reglas.Publicos.ExportacionVentasEnum), _Tipo), Reglas.Publicos.ExportacionVentasEnum)).ToString()
         Else
            Me.cmbExportarVentasFormato.Enabled = True
            Me.cmbExportarVentasFormato.SelectedValue = Reglas.Publicos.Facturacion.Exportacion.ExportarVentasConFormato.ToString()
         End If

         If Not String.IsNullOrEmpty(_tipoComprobantePedido) Then
            Me.chbTipoComprobante.Checked = True
            Me.cmbTiposComprobantes.SelectedValue = _tipoComprobantePedido
         End If

         If _listaTiposComprobantes IsNot Nothing AndAlso _listaTiposComprobantes.Count > 0 Then
            Me.chbTipoComprobanteVenta.Checked = True
            cmbTiposComprobantesVenta.SetValoresSeleccionados(_listaTiposComprobantes)
            'Me.cmbTiposComprobantesVenta.SelectedValue = _tipoComprobanteVenta
         End If

         MostrarNombreArchivo()
         MostrarComprobantesProductos()

         _estaCargando = False

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tbcExportacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcExportacion.SelectedIndexChanged
      Try
         Me.tssRegistros.Text = ContarRegistros()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

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
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         If ValidarFiltros() Then
            Me.btnConsultar.Enabled = False
            Me.tsbExportarVentas.Enabled = False

            '# Cargo el detalle
            Me.CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Or ugProductos.Rows.Count > 0 Then
               Me.btnConsultar.Focus()
               Me.tsbExportarVentas.Enabled = True
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If

         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.btnConsultar.Enabled = True
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = ContarRegistros()
      End Try

   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         Me.ugDetalle.UpdateData()
         If cmbExportarVentasFormato.ValorSeleccionado(Of String) = Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString() Then
            Dim row As DataRow = Me.ugDetalle.FilaSeleccionada(Of DataRow)()
            If row IsNot Nothing Then
               Me.SeleccionarRegistros(row)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 And e.Cell.Column.Header.Caption = "Ver" Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim rVentass As Reglas.Ventas = New Reglas.Ventas()
            Dim venta As Entidades.Venta = rVentass.GetUna(actual.Sucursal.Id,
                          Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                          Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                          Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                          Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))
            Dim oImpr As Impresion = New Impresion(venta)

            If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("TipoImpresora").Value.ToString() = "NORMAL" Then
               oImpr.ImprimirComprobanteNoFiscal(True)
            Else
               oImpr.ReImprimirComprobanteFiscal()
            End If
         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged

      Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

      If Not Me.chbTipoComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      Me.cmbTiposComprobantes.Focus()

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbCliente.CheckedChanged

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
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub AnularComprobantes_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbVendedor.CheckedChanged

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
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            dr.Cells(_columnaSelec).Value = Me.chbTodos.Checked
         Next

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbExportarVentas_Click(sender As Object, e As EventArgs) Handles tsbExportarVentas.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not Me.ugDetalle.Rows.Count > 0 And Not Me.ugProductos.Rows.Count > 0 Then Exit Sub

         Me.ugDetalle.UpdateData()
         Me.ugProductos.UpdateData()

         '# Exportar
         Me.ExportarDatos(DirectCast(Me.ugDetalle.DataSource, DataTable),
                          DirectCast(Me.ugProductos.DataSource, DataTable))

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      Using DialogoGuardarArchivo As New SaveFileDialog()

         Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString(), Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
               DialogoGuardarArchivo.InitialDirectory = Publicos.UbicacionArchivoPDA
            Case Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
               DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            Case Else
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
         End Select

         DialogoGuardarArchivo.FilterIndex = 1
         DialogoGuardarArchivo.RestoreDirectory = True

         If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
               If DialogoGuardarArchivo.FileName <> "" Then
                  Me.txtArchivoDestino.Text = DialogoGuardarArchivo.FileName
               End If
            Catch Ex As Exception
               ShowError(Ex)
            End Try
         End If
      End Using
   End Sub
   'Private Sub cmbFormato_TextChanged(sender As Object, e As EventArgs) Handles cmbExportarVentasFormato.TextChanged

   'End Sub
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      If Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Focus()
      End If

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty
   End Sub

   Private Sub cmbExportarVentasFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExportarVentasFormato.SelectedIndexChanged
      Try
         If Not _estaCargando Then
            Me.MostrarComprobantesProductos()
            Me.MostrarNombreArchivo()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbTipoComprobanteVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobanteVenta.CheckedChanged
      Try
         Me.cmbTiposComprobantesVenta.Enabled = Me.chbTipoComprobanteVenta.Checked

         If Not Me.chbTipoComprobante.Checked Then
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantesVenta.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            '_listaTipoComprobante = New List(Of Entidades.TipoComprobante)()
         Else
            Me.cmbTiposComprobantesVenta.SelectedIndex = -1
            Me.cmbTiposComprobantesVenta.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbTodosDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodosDetalle.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For Each dr As UltraGridRow In Me.ugProductos.Rows
            dr.Cells(_columnaSelec).Value = Me.chbTodosDetalle.Checked
         Next

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnExaminarDetalle_Click(sender As Object, e As EventArgs) Handles btnExaminarDetalle.Click
      Using DialogoGuardarArchivo As New SaveFileDialog()

         Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString(), Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
               DialogoGuardarArchivo.InitialDirectory = Publicos.UbicacionArchivoPDA
            Case Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
               DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            Case Else
               DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
         End Select

         DialogoGuardarArchivo.FilterIndex = 1
         DialogoGuardarArchivo.RestoreDirectory = True

         If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
               If DialogoGuardarArchivo.FileName <> "" Then
                  Me.txtArchivoDestinoDetalle.Text = DialogoGuardarArchivo.FileName
               End If
            Catch Ex As Exception
               ShowError(Ex)
            End Try
         End If
      End Using
   End Sub
#End Region

#Region "Métodos"

   Private Sub ValidacionesHolistor(dt As DataTable)

      '# Si el cliente no tiene configurado Tipo de Doc. y/o la categoría fiscal no tiene configurado Cód. Exportación, se lo informo al usuario por pantalla
      Dim msgSinDocumento As StringBuilder = New StringBuilder
      Dim msgSinCF As StringBuilder = New StringBuilder
      Dim countClientesSinDocumento, countClientesSinCF As Integer '# CF = Categoría Fiscal (Cód. Exportación CF)

      For Each row As DataRow In dt.Select(String.Format("{0} = True", _columnaSelec))
         With msgSinDocumento '# Sin Documento
            If Not IsNumeric(row(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString())) AndAlso String.IsNullOrEmpty(row("Cuit").ToString()) AndAlso Boolean.Parse(row(_columnaSelec).ToString()) Then

               '# Verifico que el cliente no haya sido ya agregado al mensaje de advertencia.
               If Not msgSinDocumento.ToString().Contains(row.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())) Then
                  .AppendFormatLine("{0}", row.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString()))
                  countClientesSinDocumento += 1
               End If
            End If
         End With

         With msgSinCF '# Sin Código Exportación de Categoría Fiscal
            If String.IsNullOrEmpty(row("CodigoExportacion_CF").ToString()) AndAlso Boolean.Parse(row(_columnaSelec).ToString()) Then

               '# Verifico que el cliente no haya sido ya agregado al mensaje de advertencia.
               If Not msgSinCF.ToString().Contains(row.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())) Then
                  .AppendFormatLine("{0}", row.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString()))
                  countClientesSinCF += 1
               End If
            End If
         End With
      Next

      '# Si la cantidad de lineas de cualquiera de las dos advertencias NO supera las 5 lineas, muestro un detalle de cuales son los clientes que se deben modificar
      Dim msg As StringBuilder = New StringBuilder
      If countClientesSinDocumento > 0 Then
         If countClientesSinDocumento < 6 Then
            With msg
               .AppendFormatLine("ATENCIÓN: Los siguientes clientes no tienen configurado un Nro. Documento. Debe configurarlos para poder visualizarlos en el archivo exportado.").AppendLine()
               .AppendFormatLine("{0}", msgSinDocumento.ToString())
            End With
            ShowMessage(msg.ToString())
         Else
            ShowMessage("ATENCIÓN: Existen más de 5 clientes cuyo Nro. Documento no se encuentra configurado. Debe confirarlos para poder visualizarlos en el archivo exportado.")
         End If
      End If
      msg = New StringBuilder
      If countClientesSinCF > 0 Then
         If countClientesSinCF < 6 Then
            With msg
               .AppendFormatLine("ATENCIÓN: La categoría fiscal de los siguientes clientes no tienen configurado un Cód. Exportación. Debe configurarlos para poder visualizarlos en el archivo exportado.").AppendLine()
               .AppendFormatLine("{0}", msgSinCF.ToString())
            End With
            ShowMessage(msg.ToString())
         Else
            ShowMessage("ATENCIÓN: Existen más de 5 clientes cuya categoría fiscal no tiene configurado un Cód. Exportación. Debe configurarlos para poder visualizarlos en el archivo exportado.")
         End If
      End If

   End Sub

   Private Sub SeleccionarRegistros(row As DataRow)
      Dim condicion As String = String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                              row.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                              row.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                              row.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                              row.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                              row.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
      For Each dr As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Select(condicion)
         dr(_columnaSelec) = row(_columnaSelec)
         Me.ugDetalle.UpdateData()
      Next

   End Sub

   Private Function ValidarFiltros() As Boolean

      If Me.chbCliente.Checked And Me.bscCodigoCliente.Text.Length = 0 Then
         ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
         ShowMessage("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.")
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      Return True
   End Function

   Private Function ContarRegistros() As String
      If Me.tbcExportacion.SelectedTab Is tbpComprobantes Then
         Return String.Format("{0} Comprobantes", Me.ugDetalle.Rows.Count.ToString())
      Else
         Return String.Format("{0} Productos", Me.ugProductos.Rows.Count.ToString())
      End If
   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.UltimoSegundoDelDia() ''.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False

      If Me.cmbExportarVentasFormato.ValorSeleccionado(Of String) = Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString() Then
         Me.cmbGrabanLibro.SelectedItem = "SI"
      Else
         Me.cmbGrabanLibro.SelectedIndex = 0
      End If

      Me.cmbAfectaCaja.SelectedIndex = 0
      '  Me.cmbExportarVentasFormato.SelectedValue = Publicos.ExportarVentasConFormato
      cmbSucursal.Refrescar()
      Me.chbTipoComprobante.Checked = False
      Me.chbTipoComprobanteVenta.Checked = False
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugProductos.DataSource Is Nothing Then
         DirectCast(Me.ugProductos.DataSource, DataTable).Rows.Clear()
      End If
      Me.chbTodos.Checked = False
      Me.chbTodosDetalle.Checked = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim IdCliente As Long = 0
      Dim IdProveedor As Long = 0
      Dim IdTipoComprobanteInvocado As String = String.Empty
      Dim IdVendedor As Integer = 0

      ''''Dim CentroEmisorPedido As Integer
      ''''Dim CentroEmisor As Integer
      ''''Dim numeroPedido As Long
      ''''Dim TipoComprobantePDA As Integer
      ''''Dim CoeficienteValores As Integer
      _exportacionSellOut = False

      _exportacionHolistor = False

      Try

         '# Filtros
         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If
         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobanteInvocado = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If
         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If
         If Me.bscCodigoProveedor.Text.Length > 0 Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If
         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
         tiposComprobantes.AddRange(cmbTiposComprobantesVenta.GetTiposComprobantes())


         '# Consulta
         Dim dtComprobantes As DataTable = New DataTable
         Dim dtProductos As DataTable = New DataTable
         Dim rVentas As Reglas.Ventas = New Reglas.Ventas()

         Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()

            Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString()
               dtComprobantes = rVentas.GetExportacionVentasPDA(actual.Sucursal.Id,
                                           Me.dtpDesde.Value, Me.dtpHasta.Value,
                                           IdVendedor,
                                           Me.cmbGrabanLibro.Text,
                                           IdCliente,
                                           Me.cmbAfectaCaja.Text,
                                           IdTipoComprobanteInvocado)

            Case Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
               dtComprobantes = rVentas.GetExportacionVentasHolistor(Me.cmbSucursal.GetSucursales(),
                                                                     Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                                     IdVendedor,
                                                                     Me.cmbGrabanLibro.Text,
                                                                     IdCliente,
                                                                     Me.cmbAfectaCaja.Text,
                                                                     IdTipoComprobanteInvocado)
               _exportacionHolistor = True

            Case Reglas.Publicos.ExportacionVentasEnum.SellOut.ToString()
               dtProductos = rVentas.GetExportacionVentasDetalle(Me.cmbSucursal.GetSucursales(),
                                             Me.dtpDesde.Value, Me.dtpHasta.Value,
                                             IdProveedor,
                                             IdVendedor,
                                             Me.cmbGrabanLibro.Text,
                                             IdCliente,
                                             Me.cmbAfectaCaja.Text,
                                             IdTipoComprobanteInvocado,
                                             tiposComprobantes)
               _exportacionSellOut = True
            Case Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()

               dtComprobantes = rVentas.GetExportacionVentas(Me.cmbSucursal.GetSucursales(),
                                            Me.dtpDesde.Value, Me.dtpHasta.Value,
                                            tiposComprobantes,
                                            IdVendedor,
                                            Me.cmbGrabanLibro.Text,
                                            IdCliente,
                                            Me.cmbAfectaCaja.Text,
                                            IdTipoComprobanteInvocado)

               dtProductos = rVentas.GetExportacionVentasDetalle(Me.cmbSucursal.GetSucursales(),
                                          Me.dtpDesde.Value, Me.dtpHasta.Value,
                                          IdProveedor,
                                          IdVendedor,
                                          Me.cmbGrabanLibro.Text,
                                          IdCliente,
                                          Me.cmbAfectaCaja.Text,
                                          IdTipoComprobanteInvocado,
                                          tiposComprobantes)
         End Select

         '# Select Column
         dtComprobantes.Columns.Add(_columnaSelec, GetType(Boolean))
         dtProductos.Columns.Add(_columnaSelec, GetType(Boolean))
         For Each dr As DataRow In dtComprobantes.Rows
            dr(_columnaSelec) = Me.chbTodos.Checked
         Next
         For Each dr As DataRow In dtProductos.Rows
            dr(_columnaSelec) = Me.chbTodosDetalle.Checked
         Next

         Me.ugDetalle.DataSource = dtComprobantes
         Me.ugProductos.DataSource = dtProductos

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.FormatearGrilla()
         End If

         If dtProductos IsNot Nothing AndAlso dtProductos.Rows.Count <> 0 Then

            '# En caso que sea una exportación de tipo "Sell out" se agrega una columna a la tabla.
            '# En un principio va fija en "E0" (Ventas por Mostrador), puede que luego se haga una tabla para este tipo.
            If _exportacionSellOut Then
               dtProductos.Columns.Add("Canal", GetType(String))
               For Each dr As DataRow In dtProductos.Rows
                  dr("Canal") = "E0"
               Next
            End If

            Me.ugProductos.DataSource = dtProductos
            ugProductos.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled
            Me.ugProductos.AgregarTotalesSuma({"ImporteTotalNeto", "ImporteImpuesto", "ImporteTotalConImpuestos"})
            Me.FormatearGrillaDetalle()
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = ContarRegistros()
      End Try

   End Sub

   Public Sub FormatearGrilla()

      With Me.ugDetalle.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         Dim pos As Integer = 0

         FormatearColumna(.Columns(_columnaSelec), "S.", pos, 30, HAlign.Center)
         Me.ugDetalle.DisplayLayout.Bands(0).Columns(_columnaSelec).CellActivation = Activation.AllowEdit

         FormatearColumna(.Columns("IdSucursal"), "Suc.", pos, 30)
         FormatearColumna(.Columns("DescripcionAbrev"), "Comprobante", pos, 80)
         FormatearColumna(.Columns("Letra"), "Letra", pos, 40)
         FormatearColumna(.Columns("CentroEmisor"), "Emisor", pos, 50, HAlign.Right)
         FormatearColumna(.Columns("NumeroComprobante"), "Número", pos, 60, HAlign.Right)
         FormatearColumna(.Columns("Fecha"), "Fecha", pos, 80, HAlign.Center)
         FormatearColumna(.Columns("CodigoCliente"), "Cód. Cliente", pos, 90, HAlign.Right)
         FormatearColumna(.Columns("NombreCliente"), "Cliente", pos, 200)
         '  FormatearColumna(.Columns("Cuit"), "Cuit", pos, 80, HAlign.Center)
         FormatearColumna(.Columns("SubTotal"), "SubTotal", pos, 100, HAlign.Right, , "N2")

         If _exportacionHolistor Then
            FormatearColumna(.Columns("Alicuota"), "Alícuota", pos, 65, HAlign.Right)
            FormatearColumna(.Columns("CodigoExportacion_CF"), "Cód. Exportación Fiscal", pos, 70, HAlign.Left)
            FormatearColumna(.Columns("CodigoExportacion"), "Cód. Exportación", pos, 70, HAlign.Left, True)
         End If

         FormatearColumna(.Columns("TotalImpuestos"), "Total Impuestos", pos, 100, HAlign.Right, , "N2")
         FormatearColumna(.Columns("TotalImpuestoInterno"), "Total Impuesto Interno", pos, 100, HAlign.Right, , "N2")
         FormatearColumna(.Columns("ImporteTotal"), "Importe Total", pos, 100, HAlign.Right, , "N2") '# Importe total discriminado por IVA
         'FormatearColumna(.Columns("ImporteTotal"), "Importe Total", pos, 100, HAlign.Right, , "N2") '# Importe total del comprobante
         If Me.cmbExportarVentasFormato.SelectedValue.ToString() = Reglas.Publicos.ExportacionVentasEnum.PDA.ToString() Then
            FormatearColumna(.Columns("NumeroPedido"), "Número Pedido", pos, 80, HAlign.Right)
         End If

         '# Totales
         Me.ugDetalle.AgregarTotalesSuma({"Subtotal", "TotalImpuestos", "TotalImpuestoInterno", "ImporteTotal"})

      End With
   End Sub
   Public Sub FormatearGrillaDetalle()

      With Me.ugProductos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         Dim pos As Integer = 0

         FormatearColumna(.Columns(_columnaSelec), "S.", pos, 30, HAlign.Center)
         Me.ugProductos.DisplayLayout.Bands(0).Columns(_columnaSelec).CellActivation = Activation.AllowEdit

         FormatearColumna(.Columns("IdSucursal"), "Suc.", pos, 30)

         If _exportacionSellOut Then
            FormatearColumna(.Columns("Sucursal"), "Sucursal", pos, 100)
         End If

         FormatearColumna(.Columns("DescripcionAbrev"), "Comprobante", pos, 80)
         FormatearColumna(.Columns("Letra"), "Letra", pos, 40)
         FormatearColumna(.Columns("CentroEmisor"), "Emisor", pos, 50, HAlign.Right)
         FormatearColumna(.Columns("NumeroComprobante"), "Numero", pos, 60, HAlign.Right)
         FormatearColumna(.Columns("Fecha"), "Fecha", pos, 80, HAlign.Center)
         FormatearColumna(.Columns("CodigoCliente"), "Codigo Cliente", pos, 90)
         FormatearColumna(.Columns("NombreCliente"), "Cliente", pos, 200)
         FormatearColumna(.Columns("Cuit"), "Cuit", pos, 80, HAlign.Center)

         If _exportacionSellOut Then
            FormatearColumna(.Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()), "Tipo", pos, 100, HAlign.Left)
            FormatearColumna(.Columns(Entidades.Localidad.Columnas.IdLocalidad.ToString()), "ZIP", pos, 80, HAlign.Right)
            FormatearColumna(.Columns(Entidades.Provincia.Columnas.NombreProvincia.ToString()), "Provincia", pos, 100, HAlign.Left)
         End If

         FormatearColumna(.Columns("IdProducto"), "Codigo Producto", pos, 110)
         FormatearColumna(.Columns("CodigoProductoProveedor"), "Codigo Proveedor", pos, 110)
         FormatearColumna(.Columns("NombreProducto"), "Producto", pos, 250)
         FormatearColumna(.Columns("NombreMoneda"), "Moneda", pos, 70)
         FormatearColumna(.Columns("Cantidad"), "Cantidad", pos, 70, HAlign.Right, , "N")
         FormatearColumna(.Columns("Costo"), "Costo", pos, 70, HAlign.Right, , "N2")
         FormatearColumna(.Columns("Precio"), "Precio", pos, 70, HAlign.Right, , "N2")
         FormatearColumna(.Columns("PrecioLista"), "Precio Lista", pos, 70, HAlign.Right, , "N2")
         FormatearColumna(.Columns("PrecioNeto"), "Precio Neto", pos, 70, HAlign.Right, , "N2")
         FormatearColumna(.Columns("ImporteTotalNeto"), "Neto", pos, 80, HAlign.Right, , "N2")
         FormatearColumna(.Columns("ImporteImpuesto"), "IVA", pos, 80, HAlign.Right, , "N2")
         FormatearColumna(.Columns("ImporteTotalConImpuestos"), "Total", pos, 80, HAlign.Right, , "N2")
         ugProductos.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

         If _exportacionSellOut Then
            FormatearColumna(.Columns(Entidades.Empleado.Columnas.NombreEmpleado.ToString()), "Vendedor", pos, 100, HAlign.Left)
            FormatearColumna(.Columns("Canal"), "Canal", pos, 100, HAlign.Left)
         End If

      End With
   End Sub


   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("TipoImpresora", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("DescripcionAbrev", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("Fecha", GetType(DateTime))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCategoriaFiscal", GetType(String))
         .Columns.Add("FormaDePago", GetType(String))
         .Columns.Add("SubTotal", GetType(Decimal))
         .Columns.Add("TotalImpuestos", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Kilos", GetType(Decimal))
         .Columns.Add("FechaTransmisionAFIP", GetType(DateTime))
         .Columns.Add("IdEstadoComprobante", GetType(String))
         .Columns.Add("CentroEmisorPedido", GetType(Integer))
         .Columns.Add("NumeroPedido", GetType(Long))
         .Columns.Add("TipoComprobantePDA", GetType(Integer))
         .Columns.Add("CoeficienteValores", GetType(Integer))
         .Columns.Add("Cuit", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("TipoDocCliente", GetType(String))
         .Columns.Add("NroDocCliente", GetType(String))
         .Columns.Add("CP", GetType(String))
         .Columns.Add("NombreLocalidad", GetType(String))
         .Columns.Add("NombreProvincia", GetType(String))
         .Columns.Add("IdCategoriaFiscal", GetType(String))
         .Columns.Add("Neto", GetType(String))
         .Columns.Add("Alicuota", GetType(String))
         .Columns.Add("IdAFIPTipoDocumento", GetType(String))
         .Columns.Add("IdTipoImpuesto", GetType(String))
         .Columns.Add("ImportePorPercepcion", GetType(String))
         '  .Columns.Add("IdVendedor", GetType(Integer))

      End With

      Return dtTemp

   End Function
   Private Sub ExportarDatos(dtComprobantes As DataTable,
                             dtProductos As DataTable)

      Try
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
         Dim cant As Integer = 0
         Dim cant1 As Integer = 0

         Me.ugDetalle.UpdateData()
         Me.ugProductos.UpdateData()

         If Me.cmbExportarVentasFormato.SelectedValue.ToString() = Reglas.Publicos.ExportacionVentasEnum.PDA.ToString() AndAlso
            Not IO.Directory.Exists(Publicos.UbicacionArchivoPDA) Then
            ShowMessage(String.Format("No existe la carpeta {0}. Configure una carpeta valida en los Parametros del Sistema -> Ventas.", Publicos.UbicacionArchivoPDA))
            Exit Sub
         End If

         For Each dr As DataRow In dtComprobantes.Select(String.Format("{0} = True", _columnaSelec))
            cant += 1
         Next

         For Each dr As DataRow In dtProductos.Select(String.Format("{0} = True", _columnaSelec))
            cant1 += 1
         Next

         Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString(), Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
               If cant = 0 Then
                  ShowMessage("No seleccionó ningún Comprobante")
                  Exit Sub
               End If
               stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", cant)
            Case Reglas.Publicos.ExportacionVentasEnum.SellOut.ToString()
               If cant1 = 0 Then
                  ShowMessage("No seleccionó ningún Producto")
                  Exit Sub
               End If
               stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", cant1)
            Case Reglas.Publicos.ExportacionVentasEnum.SellOut.ToString(), Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()
               If cant = 0 Then
                  ShowMessage("No seleccionó ningún Comprobante")
                  Me.tbcExportacion.SelectedTab = Me.tbpComprobantes
                  Exit Sub
               End If
               If cant1 = 0 Then
                  ShowMessage("No seleccionó ningún Producto")
                  Me.tbcExportacion.SelectedTab = Me.tbpDetalle
                  Exit Sub
               End If
               stb.AppendFormat("¿Realmente desea generar el archivo para los {0} registros?", cant)
         End Select

         '###########################
         '# ADVERTENCIAS AL USUARIO #
         '###########################

         Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
               Me.ValidacionesHolistor(dtComprobantes)
         End Select

         If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then
            Dim nombreArchivo As String
            Dim nombreArchivoProductos As String

            nombreArchivo = txtArchivoDestino.Text
            nombreArchivoProductos = txtArchivoDestinoDetalle.Text

            Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
               Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString()
                  Me.CrearExportacionVentasPDA()
                  Me._VentasPDA.GrabarArchivo(nombreArchivo)
                  ShowMessage("Se Exportaron " & cant.ToString() & " registros EXITOSAMENTE !!!")
               Case Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
                  Me.CrearVentasHolistor(DirectCast(Me.ugDetalle.DataSource, DataTable))
                  Me._VentasHolistor.GrabarArchivo(nombreArchivo)
                  ShowMessage("Se Exportaron " & cant.ToString() & " registros EXITOSAMENTE !!!")
               Case Reglas.Publicos.ExportacionVentasEnum.SellOut.ToString()
                  Me.CrearVentasSellOut()
                  Me._VentasSellOut.GrabarArchivo(nombreArchivoProductos)
                  ShowMessage("Se Exportaron " & cant1.ToString() & " registros EXITOSAMENTE !!!")
               Case Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()
                  Me.CrearExportacionVentasAndina()
                  Me.CrearExportacionVentasAndinaDetalle()
                  Me._VentasMostradorAndina.GrabarArchivo(nombreArchivo)
                  Me._VentasMostradorAndinaDetalle.GrabarArchivo(nombreArchivoProductos)
                  ShowMessage("Se Exportaron " & cant.ToString() & " registros EXITOSAMENTE !!!")
                  ShowMessage("Se Exportaron " & cant1.ToString() & " registros EXITOSAMENTE !!!")
            End Select
         Else
            ShowMessage("Ha cancelado la exportación.")
         End If
      Catch ex As Exception
         Throw
      End Try

   End Sub

   Private Sub CrearExportacionVentasPDA()
      Try
         Me._VentasPDA = New VentasPDA()

         Dim linea As VentasPDALinea

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugDetalle.Rows.Count
         Me.tspBarra.Value = 0
         Dim nroPedido As String

         For Each dr As UltraGridRow In ugDetalle.Rows
            Me.tspBarra.Value += 1
            If Boolean.Parse(dr.Cells(_columnaSelec).Value.ToString()) Then

               linea = New VentasPDALinea()

               '"NumeroPedido;CodigoCliente;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;FechaEmision;IdEstadoComprobante;ImporteCuota"

               ' 01 - NumeroPedido
               'linea.CentroEmisorPedido = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())
               nroPedido = dr.Cells("NumeroPedido").Value.ToString()
               If String.IsNullOrWhiteSpace(nroPedido) Then
                  nroPedido = "0"
               End If

               If nroPedido.Length = 7 Then
                  linea.CentroEmisorPedido = Integer.Parse(nroPedido.Substring(0, 1))
                  linea.NumeroPedido = Long.Parse(nroPedido.Substring(1, 6))
               ElseIf nroPedido.Length = 8 Then
                  linea.CentroEmisorPedido = Integer.Parse(nroPedido.Substring(0, 2))
                  linea.NumeroPedido = Long.Parse(nroPedido.Substring(2, 6))
               Else
                  linea.CentroEmisor = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())
                  linea.NumeroPedido = Long.Parse(nroPedido)
               End If

               '02 - CodigoCliente
               linea.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())
               '03 - IdTipoComprobante
               If Not String.IsNullOrEmpty(dr.Cells("TipoComprobantePDA").Value.ToString()) Then
                  linea.TipoComprobantePDA = Integer.Parse(dr.Cells("TipoComprobantePDA").Value.ToString())
               Else
                  linea.TipoComprobantePDA = 7
               End If
               '04 - Letra
               linea.Letra = dr.Cells("Letra").Value.ToString()
               '05 - CentroEmisor
               linea.CentroEmisor = Integer.Parse(dr.Cells("CentroEmisorPedido").Value.ToString())
               '06 - NumeroComprobante
               linea.NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())
               '07 - FechaEmision
               linea.FechaEmision = Date.Parse(dr.Cells("Fecha").Value.ToString())
               '08 - Estado Comprobante
               If dr.Cells("IdEstadoComprobante").Value.ToString() = "ANULADO" Then
                  linea.IdEstadoComprobante = "1"
               Else
                  linea.IdEstadoComprobante = "0"
               End If
               '09 - Importe
               linea.ImporteTotal = Decimal.Parse(dr.Cells("ImporteTotal").Value.ToString())
               linea.CoeficienteValores = Integer.Parse(dr.Cells("CoeficienteValores").Value.ToString())

               Me._VentasPDA.Lineas.Add(linea)

            End If

         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub CrearVentasHolistor(dt As DataTable)

      Try
         _VentasHolistor = New Reglas.VentasExportarDatos()
         Dim linea As Reglas.VentasCamposAExportar

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugDetalle.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Select(String.Format("{0} = True", _columnaSelec))
            Me.tspBarra.Value += 1
            linea = New Reglas.VentasCamposAExportar()

            With linea

               .Fecha = dr.Field(Of Date)(Entidades.Venta.Columnas.Fecha.ToString())
               .Comprobante = dr.Field(Of String)(Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString())
               .Letra = dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString())
               .CentroEmisor = dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString())
               .NumeroComprobante = dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString())

               If IsNumeric(dr(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString())) Then
                  .TipoComprobanteIdAFIP = dr.Field(Of Integer)(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString())
               End If

               .NombreCliente = dr.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
               .Cuit = dr.Field(Of String)(Entidades.Cliente.Columnas.Cuit.ToString())
               .Direccion = dr.Field(Of String)(Entidades.Cliente.Columnas.Direccion.ToString())
               .CP = dr.Field(Of Integer)("CP").ToString()

               .IdAFIPProvincia = dr.Field(Of Integer)(Entidades.Provincia.Columnas.IdAFIPProvincia.ToString())
               .NombreProvincia = dr.Field(Of String)(Entidades.Provincia.Columnas.NombreProvincia.ToString())

               '.IdCategoriaFiscal = Convert.ToInt32(dr.Field(Of Short)(Entidades.Venta.Columnas.IdCategoriaFiscal.ToString()))
               .CodigoExportacion = dr.Field(Of String)(Entidades.CategoriaFiscal.Columnas.CodigoExportacion.ToString() + "_CF")

               '# CodigoExportacion - Refleja el tipo de operación - Servicio, bienes, etc.
               .CodNetoGravado = dr.Field(Of String)(Entidades.SubRubro.Columnas.CodigoExportacion.ToString())

               .NetoGravado = dr.Field(Of Decimal)(Entidades.Venta.Columnas.SubTotal.ToString())

               .Alicuota = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Alicuota.ToString())

               If Not String.IsNullOrEmpty(.Cuit) Then .TipoDocumentoIdAFIP = 80 '# CUIT en AFIP
               If IsNumeric(dr(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString())) Then
                  .TipoDocumentoIdAFIP = dr.Field(Of Integer)(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString())
               End If

               .IVADebito = dr.Field(Of Decimal)(Entidades.Venta.Columnas.TotalImpuestos.ToString())

               '# Cuando se emite una FACTURA A el iva liquidado es igual al iva débito,
               '# pero cuando el cliente emite una factura B se completa únicamente el iva débito y el iva liquidado queda vació
               If .TipoComprobanteIdAFIP = _CodAFIPFacturaA Then
                  .IVALiquidado = .IVADebito
               End If

               '# Los campos si no tienen valores van vacios, no con 0.
               '.CodNgEx = 0
               '.ConceptosNgEx = 0

               .ProvinciaPercRet = .IdAFIPProvincia

               .CodPerRet = dr.Field(Of String)(Entidades.VentaImpuesto.Columnas.IdTipoImpuesto.ToString())
               .PercRet = dr.Field(Of Decimal)("ImportePorPercepcion")
               '.Total = dr.Field(Of Decimal)(Entidades.Venta.Columnas.ImporteTotal.ToString()) # Este es el importe total del comprobante
               .Total = dr.Field(Of Decimal)("Total") '# Este es el importe total x linea (IVA discriminado)

            End With

            Me._VentasHolistor.Lineas.Add(linea)
         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try

   End Sub

   Private Sub CrearVentasSellOut()
      Try
         _VentasSellOut = New Reglas.VentasExportarSellOut()

         Dim linea As Reglas.VentasCamposAExportarSellOut

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugProductos.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As UltraGridRow In ugProductos.Rows
            Me.tspBarra.Value += 1
            If Boolean.Parse(dr.Cells(_columnaSelec).Value.ToString()) Then

               linea = New Reglas.VentasCamposAExportarSellOut()

               With linea
                  .CentroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())

                  .NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

                  .Fecha = Date.Parse(dr.Cells("Fecha").Value.ToString())

                  If Not String.IsNullOrEmpty(dr.Cells("Cuit").Value.ToString()) Then
                     .Cuit = Long.Parse(dr.Cells("Cuit").Value.ToString())
                  Else
                     .Cuit = 0
                  End If

                  .NombreCliente = dr.Cells("NombreCliente").Value.ToString()

                  .CodigoProveedor = dr.Cells("CodigoProductoProveedor").Value.ToString()

                  .Cantidad = Decimal.Parse(dr.Cells("Cantidad").Value.ToString())

                  .TipoCliente = dr.Cells("NombreTipoCliente").Value.ToString()
                  .Canal = dr.Cells("Canal").Value.ToString()
                  .Zip = Integer.Parse(dr.Cells("IdLocalidad").Value.ToString())
                  .Provincia = dr.Cells("NombreProvincia").Value.ToString()
                  .Sucursal = dr.Cells("Sucursal").Value.ToString()
                  .Vendedor = dr.Cells("NombreEmpleado").Value.ToString()

                  .Moneda = dr.Cells("NombreMoneda").Value.ToString()

                  If .Moneda = "Dolares" Then
                     .PrecioNeto = Math.Round(Decimal.Parse(dr.Cells("PrecioNeto").Value.ToString()) / Decimal.Parse(dr.Cells("CotizacionDolar").Value.ToString()), 2)
                  Else
                     .PrecioNeto = Decimal.Parse(dr.Cells("PrecioNeto").Value.ToString())
                  End If

               End With

               Me._VentasSellOut.Lineas.Add(linea)

            End If

         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try



   End Sub

   Private Sub CrearExportacionVentasAndina()
      Try
         Me._VentasMostradorAndina = New VentasMostradorAndina()

         Dim linea As VentasMostradorAndinaLinea

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugDetalle.Rows.Count
         Me.tspBarra.Value = 0
         ''''Dim nroPedido As String

         For Each dr As UltraGridRow In ugDetalle.Rows
            Me.tspBarra.Value += 1
            If Boolean.Parse(dr.Cells(_columnaSelec).Value.ToString()) Then

               linea = New VentasMostradorAndinaLinea()

               '02 - CodigoCliente
               linea.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())
               '03 - IdTipoComprobante
               If Not String.IsNullOrEmpty(dr.Cells("TipoComprobantePDA").Value.ToString()) Then
                  linea.TipoComprobantePDA = Integer.Parse(dr.Cells("TipoComprobantePDA").Value.ToString())
               Else
                  linea.TipoComprobantePDA = 7
               End If
               '04 - Letra
               linea.Letra = dr.Cells("Letra").Value.ToString()
               '05 - CentroEmisor
               linea.CentroEmisor = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())
               '06 - NumeroComprobante
               linea.NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())
               '07 - FechaEmision
               linea.FechaEmision = Date.Parse(dr.Cells("Fecha").Value.ToString())
               '08 - Estado Comprobante
               If dr.Cells("IdEstadoComprobante").Value.ToString() = "ANULADO" Then
                  linea.IdEstadoComprobante = "1"
               Else
                  linea.IdEstadoComprobante = "0"
               End If
               '09 - Importe
               linea.ImporteTotal = Decimal.Parse(dr.Cells("ImporteTotal").Value.ToString())
               linea.CoeficienteValores = Integer.Parse(dr.Cells("CoeficienteValores").Value.ToString())
               linea.Vendedor = New Reglas.Empleados().GetUno(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))

               Me._VentasMostradorAndina.Lineas.Add(linea)

            End If

         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub CrearExportacionVentasAndinaDetalle()
      Try
         Me._VentasMostradorAndinaDetalle = New VentasMostradorAndinaDetalle()

         Dim linea As VentasMostradorAndinaLineaDetalle

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugProductos.Rows.Count
         Me.tspBarra.Value = 0
         ''''Dim nroPedido As String

         For Each dr As UltraGridRow In ugProductos.Rows
            Me.tspBarra.Value += 1
            If Boolean.Parse(dr.Cells(_columnaSelec).Value.ToString()) Then

               linea = New VentasMostradorAndinaLineaDetalle()


               linea.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())

               If Not String.IsNullOrEmpty(dr.Cells("TipoComprobantePDA").Value.ToString()) Then
                  linea.TipoComprobantePDA = Integer.Parse(dr.Cells("TipoComprobantePDA").Value.ToString())
               Else
                  linea.TipoComprobantePDA = 7
               End If

               linea.Letra = dr.Cells("Letra").Value.ToString()

               linea.CentroEmisor = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())

               linea.NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

               linea.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString())

               linea.Cantidad = Decimal.Parse(dr.Cells("Cantidad").Value.ToString())

               linea.PrecioNeto = Math.Round(Decimal.Parse(dr.Cells("PrecioConIVA").Value.ToString()), 3)

               linea.DescuentoRecargoProducto = Math.Round(Decimal.Parse(dr.Cells("DescuentoRecargoProductoConImpuestos").Value.ToString()), 3)

               linea.DescuentoRecargoPorc1 = Math.Round(Decimal.Parse(dr.Cells("DescuentoRecargoPorc").Value.ToString()), 2)

               linea.ImporteImpuesto = Math.Round(Decimal.Parse(dr.Cells("ImporteImpuesto").Value.ToString()), 3)

               linea.AlicuotaImpuesto = Math.Round(Decimal.Parse(dr.Cells("AlicuotaImpuesto").Value.ToString()), 2)

               linea.ImporteImpuestoInterno = Math.Round(Decimal.Parse(dr.Cells("ImporteImpuestoInterno").Value.ToString()), 3)

               linea.ImporteTotalNeto = Math.Round(Decimal.Parse(dr.Cells("ImporteTotalConImpuestos").Value.ToString()), 3)

               Me._VentasMostradorAndinaDetalle.Lineas.Add(linea)

            End If

         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub
   Private Sub MostrarNombreArchivo()
      Try
         If Not Me.ugDetalle.DataSource Is Nothing Then
            If DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Count > 0 Then
               DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
               Me.btnConsultar.Focus()
            End If
         End If
         If Not Me.ugProductos.DataSource Is Nothing Then
            If DirectCast(Me.ugProductos.DataSource, DataTable).Rows.Count > 0 Then
               DirectCast(Me.ugProductos.DataSource, DataTable).Rows.Clear()
               Me.btnConsultar.Focus()
            End If
         End If
         Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString()
               Me.txtArchivoDestino.Text = System.IO.Path.Combine(Publicos.UbicacionArchivoPDA, String.Format("TRN_{0:yyyyMMddhhmmss}.txt", Date.Now()))
            Case Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
               '# En caso que sea Holistor, solo se filtran las ventas que graben libro
               Me.cmbGrabanLibro.SelectedItem = "SI"
               Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Publicos.CuitEmpresa & "_Ventas_Holistor_" & Date.Today().ToString("yyyyMMdd") & ".csv"
            Case Reglas.Publicos.ExportacionVentasEnum.SellOut.ToString()
               Me.txtArchivoDestinoDetalle.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Publicos.CuitEmpresa & "_Ventas_SellOut_" & Date.Today().ToString("yyyyMMdd") & ".csv"
            Case Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()
               Me.txtArchivoDestino.Text = System.IO.Path.Combine(Publicos.UbicacionArchivoPDA, String.Format("CMPC_{0:yyyyMMddhhmmss}.txt", Date.Now()))
               Me.txtArchivoDestinoDetalle.Text = System.IO.Path.Combine(Publicos.UbicacionArchivoPDA, String.Format("CMPD_{0:yyyyMMddhhmmss}.txt", Date.Now()))
         End Select

         Me.txtArchivoDestino.Text = Me.txtArchivoDestino.Text.Replace(" ", "_")
         Me.tssRegistros.Text = "0 Registros"

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub MostrarComprobantesProductos()

      Select Case Me.cmbExportarVentasFormato.SelectedValue.ToString()
         Case Reglas.Publicos.ExportacionVentasEnum.PDA.ToString(), Reglas.Publicos.ExportacionVentasEnum.Holistor.ToString()
            If Not Me.tbcExportacion.Contains(Me.tbpComprobantes) Then
               Me.tbcExportacion.TabPages.Add(Me.tbpComprobantes)
            End If
            tbcExportacion.TabPages.Remove(tbpDetalle)
            Me.chbProveedor.Enabled = False
            Me.chbTipoComprobanteVenta.Checked = False
            Me.chbTipoComprobanteVenta.Enabled = False
            Me.chbTipoComprobante.Enabled = True
         Case Reglas.Publicos.ExportacionVentasEnum.SellOut.ToString()
            If Not Me.tbcExportacion.Contains(Me.tbpDetalle) Then
               Me.tbcExportacion.TabPages.Add(Me.tbpDetalle)
            End If
            tbcExportacion.TabPages.Remove(Me.tbpComprobantes)
            Me.chbProveedor.Enabled = True
            Me.chbTipoComprobanteVenta.Enabled = True
            Me.chbTipoComprobante.Checked = False
            Me.chbTipoComprobante.Enabled = False
         Case Reglas.Publicos.ExportacionVentasEnum.Mostrador.ToString()

            If Not Me.tbcExportacion.Contains(Me.tbpComprobantes) Then
               tbcExportacion.TabPages.Insert(0, Me.tbpComprobantes)
               tbcExportacion.SelectedTab = Me.tbpComprobantes
            End If
            If Not Me.tbcExportacion.Contains(Me.tbpDetalle) Then
               tbcExportacion.TabPages.Add(Me.tbpDetalle)
            End If
            Me.chbTipoComprobanteVenta.Enabled = True
            Me.chbTipoComprobante.Checked = False
            Me.chbTipoComprobante.Enabled = False
            Me.chbProveedor.Enabled = False
      End Select
   End Sub


   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros

      For Each params As String In parametros.Split(";"c)
         Dim keyValue As String() = params.Split("="c)
         If keyValue(0).Trim() = "Formato" Then
            _Tipo = If(keyValue.Length > 0, keyValue(1).Trim(), String.Empty)
         ElseIf keyValue(0).Trim() = "ComprobanteInvocado" Then
            _tipoComprobantePedido = If(keyValue.Length > 0, keyValue(1).Trim(), String.Empty)
         ElseIf keyValue(0).Trim() = "TipoComprobanteVenta" Then
            If keyValue.Length > 0 Then
               _listaTiposComprobantes = New List(Of Entidades.TipoComprobante)()
               Dim cache As New Reglas.BusquedasCacheadas()
               For Each idTp As String In keyValue(1).Split(","c)
                  _listaTiposComprobantes.Add(cache.BuscaTipoComprobante(idTp))
               Next
            End If
         End If
      Next
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
#End Region

End Class