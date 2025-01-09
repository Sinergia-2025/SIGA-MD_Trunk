Public Class InfPedidosSiMovil
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _modo As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            tsbQuitarMarcaProcesado.Visible = _modo = "ADMIN"
            tssQuitarMarcaProcesado.Visible = tsbQuitarMarcaProcesado.Visible

            If _modo = "ADMIN" Then
               Text = "Administración de Pedidos Web de SiMovil"
            End If

            _publicos.CargaComboDesdeEnum(cmbProcesado, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboRutas(cmbRuta, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)

            RefrescarDatosGrilla()

            _tit = GetColumnasVisiblesGrilla(ugDetalle)

            AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "Observaciones"})

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

#Region "Eventos ToolBar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            RefrescarDatosGrilla()
            tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Me.Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Me.Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbQuitarMarcaProcesado_Click(sender As Object, e As EventArgs) Handles tsbQuitarMarcaProcesado.Click
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of Entidades.JSonEntidades.SiMovilPedidos.PedidoSiMovilJSon)()
            If dr IsNot Nothing Then
               If Not dr.Procesado Then
                  ShowMessage("El pedido seleccionado no está procesado. Para marcar un pedido como procesado utilizar la pantalla de PreventaV3.")
                  Return
               End If

               If ShowPregunta("¿Desea desmarcar el Pedido seleccionado de la web?") = Windows.Forms.DialogResult.Yes Then
                  Dim regla = New Reglas.ServiciosRest.Pedidos.PedidosSiMovilPedidos()
                  regla.SetEstadoPedidoProcesado(dr, Reglas.ServiciosRest.Pedidos.BasePedidosWeb.EstadoSiWeb.Borrador)

                  ShowMessage("Pedido desmarcado exitosamente.")

                  CargaGrillaDetalle()
               End If
            Else
               ShowMessage("Debe seleccionar un Pedido.")
               Return
            End If
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
   Private Sub chbFechaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPedido.CheckedChanged
      TryCatched(Sub() chbFechaPedido.FiltroCheckedChanged(chbMesCompletoFechaPedidos, dtpDesdeFechaPedidos, dtpHastaFechaPedidos))
   End Sub

   Private Sub chbFechaProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaProceso.CheckedChanged
      TryCatched(Sub() chbFechaProceso.FiltroCheckedChanged(chbMesCompletoFechaProceso, dtpDesdeFechaProceso, dtpHastaFechaProceso))
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoFechaPedidos.CheckedChanged
      TryCatched(Sub() chbMesCompletoFechaPedidos.FiltroCheckedChangedMesCompleto(dtpDesdeFechaPedidos, dtpHastaFechaPedidos))
   End Sub

   Private Sub chbMesCompletoFechaProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoFechaProceso.CheckedChanged
      TryCatched(Sub() chbMesCompletoFechaProceso.FiltroCheckedChangedMesCompleto(dtpDesdeFechaProceso, dtpHastaFechaProceso),
         Sub(owner, ex)
            chbMesCompletoFechaProceso.Checked = False
            ShowError(ex)
         End Sub)
   End Sub

   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      TryCatched(Sub() chbRuta.FiltroCheckedChanged(cmbRuta))
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscNombreCliente))
   End Sub

#End Region

#Region "Eventos Buscadores"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim idCliente As Long = If(IsNumeric(bscCodigoCliente.Text), Long.Parse(bscCodigoCliente.Text), -1)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(idCliente, False, False)
         End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscNombreCliente)
            bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text, False)
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarCliente(e.FilaDevuelta)
               btnConsultar.Select()
            End If
         End Sub)
   End Sub
#End Region

   Public Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbRuta.Checked And cmbRuta.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Calendario aunque activó ese Filtro")
               cmbRuta.Select()
               Exit Sub
            End If

            If chbCliente.Checked And bscCodigoCliente.Text.Length = 0 Then
               ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
               bscCodigoCliente.Select()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
               Exit Sub
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarCliente(dr As DataGridViewRow)
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()

      bscCodigoCliente.Permitido = False
      bscNombreCliente.Permitido = False
   End Sub

   Protected Overridable Sub RefrescarDatosGrilla()
      chbFechaPedido.Checked = True
      chbMesCompletoFechaPedidos.Checked = False
      dtpDesdeFechaPedidos.Value = Date.Today
      dtpHastaFechaPedidos.Value = Date.Today.UltimoSegundoDelDia()

      chbFechaProceso.Checked = True
      chbMesCompletoFechaProceso.Checked = False
      dtpDesdeFechaProceso.Value = Date.Today
      dtpHastaFechaProceso.Value = Date.Today.UltimoSegundoDelDia()

      chbCliente.Checked = False
      chbRuta.Checked = False
      cmbProcesado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      ugDetalle.ClearFilas(Of Entidades.JSonEntidades.SiMovilPedidos.PedidoSiMovilJSon)()
   End Sub

   Private Sub CargaGrillaDetalle()
      If chbRuta.Checked AndAlso cmbRuta.SelectedIndex < 0 Then
         cmbRuta.Select()
         Throw New Exception("ATENCION: NO seleccionó una Ruta aunque activó ese Filtro.")
      End If
      If chbCliente.Checked AndAlso (Not bscCodigoCliente.Selecciono And Not bscNombreCliente.Selecciono) Then 'AndAlso Not IsNumeric(bscCodigoCliente.Tag) Then
         bscCodigoCliente.Select()
         Throw New Exception("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
      End If
      If cmbProcesado.SelectedIndex < 0 Then
         cmbProcesado.Select()
         Throw New Exception("ATENCION: Debe seleccionar el filtro de Procesado.")
      End If

      _tit = GetColumnasVisiblesGrilla(ugDetalle)

      Dim fechaPedidosDesde As Date? = Nothing
      If chbFechaPedido.Checked Then fechaPedidosDesde = dtpDesdeFechaPedidos.Value
      Dim fechaPedidosHasta As Date? = Nothing
      If chbFechaPedido.Checked Then fechaPedidosHasta = dtpHastaFechaPedidos.Value
      Dim fechaProcesoDesde As Date? = Nothing
      If chbFechaProceso.Checked Then fechaProcesoDesde = dtpDesdeFechaProceso.Value
      Dim fechaProcesoHasta As Date? = Nothing
      If chbFechaProceso.Checked Then fechaProcesoHasta = dtpHastaFechaProceso.Value

      Dim rPedidosWeb = New Reglas.ServiciosRest.Pedidos.PedidosSiMovilPedidos()
      Dim pedidos = rPedidosWeb.GetPedidosConFK(fechaPedidosDesde, fechaPedidosHasta,
                                                fechaProcesoDesde, fechaProcesoHasta,
                                                If(chbRuta.Checked, Integer.Parse(cmbRuta.SelectedValue.ToString()), 0),
                                                If(chbCliente.Checked, bscCodigoCliente.Text.ValorNumericoPorDefecto(0L), 0L),
                                                DirectCast(cmbProcesado.SelectedValue, Entidades.Publicos.SiNoTodos))
      ugDetalle.DataSource = pedidos
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      AjustarColumnasGrilla(ugDetalle, _tit)
      FormatearGrillaBanda1()
   End Sub

   Private Sub FormatearGrillaBanda1()
      With ugDetalle.DisplayLayout.Bands(1)
         Dim pos As Integer = 0
         .Columns("IdEmpresa").FormatearColumna("Código Empresa", pos, 100, HAlign.Right, True)
         .Columns("IdDispositivo").FormatearColumna("Id Dispositivo", pos, 100, , True)
         .Columns("IdPedido").FormatearColumna("Id Pedido", pos, 100, HAlign.Right, True)
         .Columns("Orden").FormatearColumna("Órden", pos, 50, HAlign.Right)
         .Columns("IdProducto").FormatearColumna("Código Producto", pos, 110)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 250)
         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 75, HAlign.Right, , "N2")
         .Columns("Precio").FormatearColumna("Precio", pos, 75, HAlign.Right, , "N2")
         .Columns("Descuento").FormatearColumna("Descuento", pos, 75, HAlign.Right, , "N2")
         .Columns("IdPlazoEntrega").FormatearColumna("Id Plazo Entrega", pos, 100, HAlign.Right, True)
         .Columns("CantidadCambio").FormatearColumna("Cantidad Cambio", pos, 75, HAlign.Right, , "N2")
         .Columns("CantidadBonif").FormatearColumna("Cantidad Bonificación", pos, 75, HAlign.Right, , "N2")
         .Columns("NotaCambio").FormatearColumna("Nota Cambio", pos, 100, HAlign.Right)
         .Columns("NotaBonif").FormatearColumna("Nota Bonificación", pos, 100, HAlign.Right)
         .Columns("IdListaPrecios").FormatearColumna("Id Lista Precios", pos, 60, HAlign.Right)
         .Columns("NombreListaPrecios").FormatearColumna("Lista Precios", pos, 150)
      End With
   End Sub

   Protected Overridable Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Procesado: {0}", cmbProcesado.Text)
         If chbFechaPedido.Checked Then
            .AppendFormat(" - Fecha Pedido: {0:dd/MM/yyyy HH:mm} a {1:dd/MM/yyyy HH:mm}", dtpDesdeFechaPedidos.Value, dtpHastaFechaPedidos.Value)
         End If
         If chbFechaProceso.Checked Then
            .AppendFormat(" - Fecha Proceso: {0:dd/MM/yyyy HH:mm} a {1:dd/MM/yyyy HH:mm}", dtpDesdeFechaProceso.Value, dtpHastaFechaProceso.Value)
         End If

         If chbRuta.Checked Then
            .AppendFormat(" - Ruta : {0}", cmbRuta.Text)
         End If

         If bscCodigoCliente.Text.Length > 0 Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscNombreCliente.Text.Trim())
         End If

      End With
      Return filtro.ToString()
   End Function

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _modo = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

End Class