Public Class MRPPlanificacionNecesidadesProduccion
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         _publicos.CargaComboEstadosOrdenesProduccion(cmbEstados, True, True, False, False, "PENDIENTE")
         cmbEstados.SelectedIndex = 0  'SOLO PENDIENTES

         dtpDesde.Value = Date.Today
         dtpDesdeEntrega.Value = Date.Today
         dtpHasta.Value = Date.Today.Date.UltimoSegundoDelDia()
         dtpHastaEntrega.Value = Date.Today.Date.UltimoSegundoDelDia()

         FormateaGrillaProductos()

      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbCalcularNecesidades.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      TryCatched(Sub() chbFechaEntrega.FiltroCheckedChanged(chkMesCompletoEntrega, dtpDesdeEntrega, dtpHastaEntrega))
   End Sub
   Private Sub chkMesCompletoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompletoEntrega.FiltroCheckedChangedMesCompleto(dtpDesdeEntrega, dtpHastaEntrega))
   End Sub

#Region "Eventos Búsqueda Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscNombreCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscNombreCliente)
         bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub

#End Region
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscNombreCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         '---------------------------------------------------------------------------------------------------------------------------------------------
         CargaGrillaDetalle()
         '---------------------------------------------------------------------------------------------------------------------------------------------
         If ugDetalle.Rows.Count > 0 Then
            ugDetalle.ActiveRow = ugDetalle.Rows.GetAllNonGroupByRows()(0)
            If ugDetalle.ActiveRow.Cells.Contains("IdEstado") Then
               ugDetalle.ActiveCell = ugDetalle.ActiveRow.Cells("IdEstado")
            End If
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
      End Sub)
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(
      Sub()
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then
            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos
               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos
               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())
               Case Else
            End Select
         End If
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargaGrillaDetalle()
      Dim fechaDesde = dtpDesde.Valor(chbFecha)
      Dim fechaHasta = dtpHasta.Valor(chbFecha)
      Dim fechaDesdeEntrega = dtpDesdeEntrega.Valor(chbFechaEntrega)
      Dim fechaHastaEntrega = dtpHastaEntrega.Valor(chbFechaEntrega)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim rOrdenProd = New Reglas.OrdenesProduccionEstados()
      Dim dtDetalle = rOrdenProd.GetOrdenesProduccionMRP(cmbEstados.Text, IdCliente, FechaDesde, FechaHasta, FechaDesdeEntrega, FechaHastaEntrega)
      ugDetalle.DataSource = dtDetalle
      FormateaGrillaProductos()
      tssRegistros.Text = (Me.ugDetalle.Rows.Count).ToString() & " Registros"
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

         bscNombreCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Public Sub FormateaGrillaProductos()
      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto", "DescripcionProceso", "NombreMarca", "NombreRubro", "NombreSubRubro"})
         '-- Setea las Columnas.- 
         .Columns("Masivo").Hidden = False
         .Columns("Masivo").Style = UltraWinGrid.ColumnStyle.CheckBox
         .Columns("Masivo").Header.VisiblePosition = pos
         .Columns("Masivo").Width = 50
         pos += 1

         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 150, HAlign.Left)

         .Columns("Letra").FormatearColumna("L", pos, 30, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero", pos, 80, HAlign.Right)

         .Columns("FechaEstado").FormatearColumna("Fecha/Hora Estado", pos, 80, HAlign.Center, True)
         .Columns("FechaEstado_Fecha").FormatearColumna("Fecha Estado", pos, 80, HAlign.Center)
         .Columns("FechaEstado_Hora").FormatearColumna("Hora Estado", pos, 80, HAlign.Center, True)
         .Columns("IdProducto").FormatearColumna("Codigo", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 150)

         .Columns("FechaEntrega").FormatearColumna("Fecha Entrega", pos, 80, HAlign.Center, True)
         .Columns("Orden").FormatearColumna("Orden", pos, 50, HAlign.Right)

         .Columns("CantEstado").FormatearColumna("Cantidad", pos, 100, HAlign.Right)
         .Columns("IdEstado").FormatearColumna("Estado", pos, 100, HAlign.Left)
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150, HAlign.Left)

         .Columns("NumeroPedido").FormatearColumna("Pedido Nro", pos, 90, HAlign.Right)
         .Columns("OrdenPedido").FormatearColumna("Pedido Orden", pos, 90, HAlign.Right)

         .Columns("NombreMarca").FormatearColumna("Marca", pos, 150, HAlign.Left)
         .Columns("NombreRubro").FormatearColumna("Rubro", pos, 150, HAlign.Left)
         .Columns("NombreSubRubro").FormatearColumna("Sub Rubro", pos, 150, HAlign.Left)

         .Columns("CodigoProcesoProductivo").FormatearColumna("Proceso", pos, 100, HAlign.Right)
         .Columns("DescripcionProceso").FormatearColumna("Descripcion", pos, 200, HAlign.Left)

      End With
   End Sub

   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If marcar.HasValue Then
            dr.Cells("Masivo").Value = marcar.Value
         Else
            dr.Cells("Masivo").Value = Not CBool(dr.Cells("Masivo").Value)
         End If
      Next
   End Sub

   Private Sub tsbCalcularNecesidades_Click(sender As Object, e As EventArgs) Handles tsbCalcularNecesidades.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.UpdateData()
            If DirectCast(ugDetalle.DataSource, DataTable).Select("Masivo").Count > 0 Then
               '-- Valida Parametros de Procesamiento.- --
               If String.IsNullOrEmpty(Reglas.Publicos.TipoComprobanteOrdenProduccionPlanificacion) Then
                  MessageBox.Show("No se puede generar la orden de produccion porque no se configuró el tipo de comprobante con el que se debe generar la misma. Por favor configure este dato en Configuraraciones\Parametros del sistema solapa MRP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               If String.IsNullOrEmpty(Reglas.Publicos.EstadoOrdenProduccionPlanificacion) Then
                  MessageBox.Show("No se puede generar la orden de produccion porque no se configuró el estado con el que se debe generar la misma. Por favor configure este dato en Configuraraciones\Parametros del sistema solapa MRP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Using oFrmCN = New MRPPlanificacionNecesidadesCalculos(DirectCast(ugDetalle.DataSource, DataTable).Select("Masivo"))
                  oFrmCN.ShowDialog()
               End Using
               btnConsultar.PerformClick()
            End If
         End Sub)

   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub RefrescarDatosGrilla()
      'Limpio la Grilla.
      ugDetalle.ClearFilas()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
#End Region

End Class