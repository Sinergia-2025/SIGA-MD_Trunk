Public Class ImpresionMasivaPedido
   Implements IConParametros

#Region "Campos"
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

   Private _impreso As Entidades.Publicos.SiNoTodos
   Private _tipoTipoComprobante As String
   Private _filtros As FiltrosPredeterminados
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         _publicos = New Publicos()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos.CargaComboEstadosPedidos(cmbEstadoComprobante, True, True, True, True, False, _tipoTipoComprobante)
         cmbEstadoComprobante.SelectedIndex = 0

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1
         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboUsuarios(cmbUsuario)
         cmbCategoria.Inicializar(False)
         _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

         _publicos.CargaComboDesdeEnum(cmbImpreso, GetType(Entidades.Publicos.SiNoTodos))
         'Me.cmbImpreso.SelectedIndex = 1   'No Impresos
         cmbImpreso.SelectedValue = _impreso

         RefrescarDatos()

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         If _filtros IsNot Nothing Then
            If _filtros.NumeroDesde.HasValue Then txtNroDesde.Text = _filtros.NumeroDesde.Value.ToString()
            If _filtros.NumeroHasta.HasValue Then txtNroHasta.Text = _filtros.NumeroHasta.Value.ToString()

            If _filtros.FechaDesde.HasValue Then dtpDesde.Value = _filtros.FechaDesde.Value
            If _filtros.FechaHasta.HasValue Then dtpHasta.Value = _filtros.FechaHasta.Value

            If _filtros.ConsultaAutomatica Then
               btnConsultar.PerformClick()
            End If
         End If

         CargarColumnasASumar()
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
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         If Integer.Parse("0" & Me.txtNroHasta.Text) > 0 And Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 <> ugDetalle.Rows.Count Then

            Dim intDiferencia As Integer = Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 - ugDetalle.Rows.Count

            If MessageBox.Show("ATENCION: Existe una diferencia de " & intDiferencia.ToString() & " entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               txtNroDesde.Focus()
               Exit Sub
            End If

         End If

         tssInfo.Text = "Imprimiendo..."
         tspBarra.Value = 0
         tspBarra.Visible = True
         Imprimir()
         tspBarra.Value = 0
         btnConsultar.PerformClick()
      End Sub,
      onFinallyAction:=
      Sub(owner)
         tspBarra.Visible = False
         tssInfo.Text = String.Empty
      End Sub)
   End Sub
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         If Integer.Parse("0" & Me.txtNroHasta.Text) > 0 And Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 <> ugDetalle.Rows.Count Then
            Dim intDiferencia As Integer = Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 - ugDetalle.Rows.Count
            If MessageBox.Show("ATENCION: Existe una diferencia de " & intDiferencia.ToString() & " entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               txtNroDesde.Focus()
               Exit Sub
            End If
         End If

         tssInfo.Text = "Exportando..."
         tspBarra.Visible = True
         tspBarra.Value = 0
         Exportar()
         tspBarra.Value = 0
         btnConsultar.PerformClick()
      End Sub,
      onFinallyAction:=
      Sub(owner)
         tspBarra.Visible = False
         tssInfo.Text = String.Empty
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cmbLetras))
   End Sub
   Private Sub chbNumeroRep_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroRep.CheckedChanged
      TryCatched(Sub() chbNumeroRep.FiltroCheckedChanged(txtNroRepartoHasta))
      TryCatched(Sub() chbNumeroRep.FiltroCheckedChanged(txtNroReparto))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("No seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("No hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

   'Private Sub dgvDetalle_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
   '   Dim ventas As Reglas.Ventas
   '   Dim venta As Entidades.Venta
   '   Dim idSucursal As Integer
   '   Dim idTipoComprobante As String
   '   Dim letra As String
   '   Dim centroEmisor As Short
   '   Dim numeroComprobante As Integer
   '   Dim dr As DataGridViewRow

   '   Try

   '      If Me.dgvDetalle.RowCount = 0 Then Exit Sub

   '      If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

   '      If e.RowIndex <> -1 Then

   '         dr = Me.dgvDetalle.Rows(e.RowIndex)

   '         If dr.Cells(e.ColumnIndex).OwningColumn.Name = "colVer" Then

   '            Me.Cursor = Cursors.WaitCursor

   '            ventas = New Reglas.Ventas()

   '            idSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
   '            idTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
   '            letra = dr.Cells("Letra").Value.ToString()
   '            centroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
   '            numeroComprobante = Int32.Parse(dr.Cells("NumeroComprobante").Value.ToString())

   '            venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

   '            Dim oImpr As Impresion = New Impresion(venta)

   '            If dr.Cells("TipoImpresora").Value.ToString() = "NORMAL" Then
   '               oImpr.ImprimirComprobanteNoFiscal(True)
   '            Else
   '               oImpr.ReImprimirComprobanteFiscal()
   '            End If

   '            Me.btnConsultar.PerformClick()

   '         End If

   '      End If
   '   Catch ex As Exception
   '      Me.Cursor = Cursors.Default
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   Finally
   '      Me.Cursor = Cursors.Default
   '   End Try
   'End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
         For Each dr As UltraGridRow In ugDetalle.Rows
            dr.Cells("anula").Value = Me.chbTodos.Checked
         Next
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
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatos()

      'Me.cmbImpreso.SelectedIndex = 1   'No Impresos
      cmbImpreso.SelectedValue = _impreso
      chkMesCompleto.Checked = False

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      chbCliente.Checked = False

      chbLetra.Checked = False

      cmbLetras.SelectedIndex = -1
      txtEmisor.Text = String.Empty
      txtNroDesde.Text = String.Empty
      txtNroHasta.Text = String.Empty

      chbVendedor.Checked = False
      chbUsuario.Checked = False
      chbFormaPago.Checked = False
      chbNumeroRep.Checked = False

      ugDetalle.ClearFilas()

      chbTodos.Checked = False

      cmbCategoria.Refrescar()
      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

      dtpDesde.Focus()

   End Sub

   Private Function GetVendedorCombo() As Entidades.Empleado
      If cmbVendedor.SelectedIndex < 0 Then Return Nothing
      Return DirectCast(cmbVendedor.SelectedItem, Entidades.Empleado)
   End Function

   Private Sub CargaGrillaDetalle()
      Dim idCliente As Long
      idCliente = If(Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0)

      Dim IdVendedor As Integer = 0

      If Me.cmbVendedor.Enabled Then
         IdVendedor = GetVendedorCombo().IdEmpleado
      End If

      Dim rPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      Dim dtDetallePedido As DataTable
      Dim impreso As Eniac.Entidades.Publicos.SiNoTodos = CType(cmbImpreso.SelectedValue, Eniac.Entidades.Publicos.SiNoTodos)

      dtDetallePedido = rPedidos.pedidosCabecera(actual.Sucursal.Id,
                                              cmbEstadoComprobante.Text, alMenosUno_TodosSean:=True,
                                              dtpDesde.Value, dtpHasta.Value,
                                              cmbTiposComprobantes.GetTiposComprobantes(),
                                              letra:=cmbLetras.Text,
                                              centroEmisor:=If(IsNumeric(txtEmisor.Text.Trim()), Short.Parse(txtEmisor.Text.Trim()), 0S),
                                              numeroPedidoDesde:=If(IsNumeric(txtNroDesde.Text.Trim()), Long.Parse(txtNroDesde.Text.Trim()), 0L),
                                              numeroPedidoHasta:=If(IsNumeric(txtNroHasta.Text.Trim()), Long.Parse(txtNroHasta.Text.Trim()), 0L),
                                              idProducto:=String.Empty,
                                              idCliente:=idCliente,
                                              idUsuario:=If(Me.cmbUsuario.Enabled, Me.cmbUsuario.SelectedValue.ToString(), ""),
                                              idVendedor:=IdVendedor,
                                              tipoVendedor:=Entidades.OrigenFK.Actual,
                                              ordenCompra:=0,
                                              tipoTipoComprobante:=_tipoTipoComprobante,
                                              idProveedor:=0,
                                              categorias:=cmbCategoria.GetCategorias(True), origenCategorias:=DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK),
                                              numeroReparto:=If(Me.txtNroReparto.Enabled And IsNumeric(txtNroReparto.Text), Integer.Parse(Me.txtNroReparto.Text), 0),
                                              numeroRepartoHasta:=If(Me.txtNroReparto.Enabled And IsNumeric(txtNroRepartoHasta.Text), Integer.Parse(Me.txtNroRepartoHasta.Text), 0),
                                              idFormasPago:=If(chbFormaPago.Checked, Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()), 0),
                                              idListaPrecios:=-1,
                                              impreso:=impreso)

      ugDetalle.DataSource = dtDetallePedido
      AjustarColumnasGrilla(ugDetalle, _tit)

      'No Impresos
      Me.chbTodos.Checked = True

      For Each dr As DataRow In dtDetallePedido.Rows
         dr("anula") = Boolean.TrueString
      Next

      Me.tssRegistros.Text = dtDetallePedido.Rows.Count.ToString() & " Registros"
   End Sub

   Private Sub Imprimir()

      If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub

      Dim total As Integer
      Dim rPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      Dim ePedido As Entidades.Pedido

      total = 0

      ugDetalle.UpdateData()

      total = DirectCast(ugDetalle.DataSource, DataTable).Select("anula = 'True'").Length

      If total = 0 Then
         ShowMessage("No se indicaron comprobantes para Imprimir.")
         Exit Sub
      End If

      Me.tspBarra.Maximum = total

      Dim idSucursal As Integer
      Dim idTipoComprobante As String
      Dim letra As String
      Dim centroEmisor As Short
      Dim numeroPedido As Long

      For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Select("anula = 'True'")
         idSucursal = Integer.Parse(dr("IdSucursal").ToString())
         idTipoComprobante = dr("IdTipoComprobante").ToString()
         letra = dr("Letra").ToString()
         centroEmisor = Short.Parse(dr("CentroEmisor").ToString())
         numeroPedido = Long.Parse(dr("NumeroPedido").ToString())

         tspBarra.PerformStep()
         tssInfo.Text = String.Format("Imprimiendo... {0} de {1}", tspBarra.Value, total)

         Application.DoEvents()

         Try
            ePedido = rPedidos.GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, estadoPedido:=Nothing)

            Dim impresion As ImpresionPedidos = New ImpresionPedidos()
            impresion.ImprimirPedido(ePedido, False)
         Catch ex As Exception
            Throw New ApplicationException(String.Format("Error imprimiendo {1} {2} {3:0000}-{4:00000000}: {5}",
                                                         idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                         ex.Message), ex)
         End Try
      Next

      ShowMessage(String.Format("Se imprimieron {0} pedidos.", total))

   End Sub

   Private Sub Exportar()

      'Cuando se haga la exportación descomentar y corregir
      ''Dim total As Integer
      ''Dim progreso As Integer
      ''Dim venta As Entidades.Venta
      ''Dim ventas As Reglas.Ventas
      ''Dim idSucursal As Integer
      ''Dim idTipoComprobante As String
      ''Dim letra As String
      ''Dim centroEmisor As Short
      ''Dim numeroComprobante As Long
      ''Dim imp As Impresion

      ''ventas = New Reglas.Ventas()
      ''total = 0

      ''ugDetalle.UpdateData()

      ''total = DirectCast(ugDetalle.DataSource, DataTable).Select("Anula = 'True'").Length

      ''If total = 0 Then
      ''   MessageBox.Show("No se indicaron comprobantes para Exportar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      ''   Exit Sub
      ''End If

      ''If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

      ''   progreso = 0

      ''   Me.tspBarra.Maximum = total
      ''   Me.tspBarra.Value = progreso

      ''   Dim ePDF As ExportarPDF = New ExportarPDF()
      ''   Dim cuitEmpresa As String = Publicos.CuitEmpresa
      ''   For Each dr As UltraGridRow In ugDetalle.Rows

      ''      If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then

      ''         progreso += 1
      ''         Me.tspBarra.Value = progreso
      ''         Me.tssInfo.Text = "Exportando... " + progreso.ToString() + " de " + total.ToString()

      ''         System.Windows.Forms.Application.DoEvents()

      ''         idSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
      ''         idTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
      ''         letra = dr.Cells("Letra").Value.ToString()
      ''         centroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
      ''         numeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

      ''         venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      ''         Dim archivoDestino As String = IO.Path.Combine(FolderBrowserDialog1.SelectedPath,
      ''                                                        String.Format("{0}_{1}_{2}_{3:0000}_{4:00000000}.pdf",
      ''                                                                      cuitEmpresa,
      ''                                                                      venta.TipoComprobante.DescripcionAbrev,
      ''                                                                      venta.LetraComprobante,
      ''                                                                      venta.CentroEmisor,
      ''                                                                      venta.NumeroComprobante))

      ''         ePDF.Exportar(venta, archivoDestino)

      ''      End If
      ''   Next

      ''   MessageBox.Show("Se imprimieron " + progreso.ToString() + " comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      ''End If

   End Sub

   Private Sub CargarColumnasASumar()
      ugDetalle.AgregarTotalesSuma({"ImporteTotal"})
   End Sub

#End Region

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

   Public Overloads Function ShowDialog(filtros As FiltrosPredeterminados) As DialogResult

      _filtros = filtros

      Return Me.ShowDialog()
   End Function

   Public Class FiltrosPredeterminados
      Public Property FechaDesde As Date?
      Public Property FechaHasta As Date?

      Public Property NumeroDesde As Long?
      Public Property NumeroHasta As Long?

      Public Property ConsultaAutomatica As Boolean = True
   End Class

End Class