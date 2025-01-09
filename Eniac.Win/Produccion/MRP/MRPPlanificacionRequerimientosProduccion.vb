Public Class MRPPlanificacionRequerimientosProduccion
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

         dtpDesde.Value = Date.Today
         dtpDesdeEntrega.Value = Date.Today
         dtpDesdePM.Value = Date.Today
         dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         dtpHastaEntrega.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         dtpHastaPM.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

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
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscNombreCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If
         '---------------------------------------------------------------------------------------------------------------------------------------------
         Me.Cursor = Cursors.WaitCursor
         CargaGrillaDetalle()
         '---------------------------------------------------------------------------------------------------------------------------------------------
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

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim oClientes = New Reglas.Clientes
         If bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(bscCodigoCliente.Text.Trim())
         End If
         bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(bscNombreCliente)
         Dim oClientes = New Reglas.Clientes
         Me.bscNombreCliente.Datos = oClientes.GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosCliente(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      bscCodigoCliente.Enabled = Me.chbCliente.Checked
      bscNombreCliente.Enabled = Me.chbCliente.Checked
      bscCodigoCliente.Text = String.Empty
      bscCodigoCliente.Tag = Nothing
      bscNombreCliente.Text = String.Empty
      bscCodigoCliente.Focus()
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then
            Me.Cursor = Cursors.WaitCursor
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
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub

   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged
      chkMesCompleto.Enabled = chbFecha.Checked
      dtpDesde.Enabled = chbFecha.Checked
      dtpHasta.Enabled = chbFecha.Checked
      If Not chbFecha.Checked Then
         chkMesCompleto.Checked = False
         dtpDesde.Value = DateTime.Today
         dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         dtpDesde.Focus()
      End If
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Dim FechaTemp As Date
      Try
         If chkMesCompleto.Checked Then
            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp
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

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      chkMesCompletoEntrega.Enabled = chbFechaEntrega.Checked
      dtpDesdeEntrega.Enabled = chbFechaEntrega.Checked
      dtpHastaEntrega.Enabled = chbFechaEntrega.Checked
      If Not chbFechaEntrega.Checked Then
         chkMesCompletoEntrega.Checked = False
         dtpDesdeEntrega.Value = DateTime.Today
         dtpHastaEntrega.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         dtpDesdeEntrega.Focus()
      End If
   End Sub
   Private Sub chkMesCompletoEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      Dim FechaTemp As Date
      Try
         If chkMesCompletoEntrega.Checked Then
            FechaTemp = New Date(dtpDesdeEntrega.Value.Year, dtpDesdeEntrega.Value.Month, 1)
            dtpDesdeEntrega.Value = FechaTemp
            FechaTemp = dtpDesdeEntrega.Value.AddMonths(1).AddSeconds(-1)
            dtpHastaEntrega.Value = FechaTemp
         End If
         Me.dtpDesdeEntrega.Enabled = Not chkMesCompletoEntrega.Checked
         Me.dtpHastaEntrega.Enabled = Not chkMesCompletoEntrega.Checked
      Catch ex As Exception
         chkMesCompletoEntrega.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPlanMaestro.CheckedChanged
      dtpDesdePM.Enabled = chbFechaPlanMaestro.Checked
      dtpHastaPM.Enabled = chbFechaPlanMaestro.Checked
      If Not chbFechaPlanMaestro.Checked Then
         dtpDesdePM.Value = Date.Today
         dtpHastaPM.Value = Date.Today.UltimoSegundoDelDia()
      Else
         dtpDesdePM.Focus()
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbCalcularNecesidades_Click(sender As Object, e As EventArgs) Handles tsbCalcularNecesidades.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.UpdateData()
            If DirectCast(ugDetalle.DataSource, DataTable).Select("Masivo").Count > 0 Then
               '-- Valida Parametros de Procesamiento.- --
               If String.IsNullOrEmpty(Reglas.Publicos.TipoComprobanteOrdenProduccionRequerimiento) Then
                  MessageBox.Show("No se puede generar los requerimientos de produccion porque no se configuró el tipo de comprobante con el que se debe generar los mismas. Por favor configure este dato en Configuraraciones\Parametros del sistema solapa MRP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Using oFrmCN = New MRPPlanificacionRequerimientosCalculos(DirectCast(ugDetalle.DataSource, DataTable).Select("Masivo"))
                  oFrmCN.ShowDialog()
               End Using
               btnConsultar.PerformClick()
            End If
         End Sub)
   End Sub

   Private Sub chbPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestro.CheckedChanged
      txtPlanMaestro.Text = "0"
      txtPlanMaestro.Enabled = chbPlanMaestro.Checked
      txtPlanMaestro.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaGrillaDetalle()
      Dim oOrdenProd = New Reglas.OrdenesProduccionEstados
      Dim dtDetalle As DataTable
      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing
      Dim FechaDesdeEntrega As Date = Nothing
      Dim FechaHastaEntrega As Date = Nothing
      Dim FechaDesdePM As Date = Nothing
      Dim FechaHastaPM As Date = Nothing
      Dim IdCliente As Long = 0
      Dim IdPlanMaestro As Integer = 0

      If chbFecha.Checked Then
         FechaDesde = dtpDesde.Value
         FechaHasta = dtpHasta.Value
      End If
      If chbFechaEntrega.Checked Then
         FechaDesdeEntrega = dtpDesdeEntrega.Value
         FechaHastaEntrega = dtpHastaEntrega.Value
      End If
      If chbFechaPlanMaestro.Checked Then
         FechaDesdePM = dtpDesdePM.Value
         FechaHastaPM = dtpHastaPM.Value
      End If

      If Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbPlanMaestro.Checked Then
         IdPlanMaestro = Integer.Parse(txtPlanMaestro.Text)
      End If

      dtDetalle = oOrdenProd.GetOrdenesProduccionREQ(IdCliente, FechaDesde, FechaHasta, FechaDesdeEntrega, FechaHastaEntrega, IdPlanMaestro, FechaDesdePM, FechaHastaPM)
      Me.ugDetalle.DataSource = dtDetalle
      FormateaGrillaProductos()
      Me.tssRegistros.Text = (Me.ugDetalle.Rows.Count).ToString() & " Registros"
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      Me.bscNombreCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
   End Sub

   Public Sub FormateaGrillaProductos()
      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         Grilla.AgregarFiltroEnLinea(ugDetalle, {"IdProducto", "NombreProducto", "DescripcionProceso", "NombreMarca", "NombreRubro", "NombreSubRubro"})
         '-- Setea las Columnas.- 
         .Columns("Masivo").Hidden = False
         .Columns("Masivo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         .Columns("Masivo").Header.VisiblePosition = pos
         .Columns("Masivo").Width = 50
         pos += 1

         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 150, HAlign.Left)

         .Columns("Letra").FormatearColumna("L", pos, 30, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero", pos, 80, HAlign.Right)
         .Columns("FechaEstado").FormatearColumna("Fecha", pos, 80, HAlign.Center)

         .Columns("PlanMaestroNumero").FormatearColumna("Plan Maestro", pos, 80, HAlign.Right)
         .Columns("PlanMaestroFecha").FormatearColumna("Fecha Plan", pos, 80, HAlign.Center)

         .Columns("IdProducto").FormatearColumna("Codigo", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 150)

         .Columns("FechaEntrega").FormatearColumna("Entrega", pos, 80, HAlign.Center)
         .Columns("Orden").FormatearColumna("Orden", pos, 50, HAlign.Right)

         .Columns("CantEstado").FormatearColumna("Cantidad", pos, 100, HAlign.Right)
         .Columns("IdEstado").FormatearColumna("Estado", pos, 100, HAlign.Left)
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150, HAlign.Left)

         .Columns("NombreMarca").FormatearColumna("Marca", pos, 150, HAlign.Left)
         .Columns("NombreRubro").FormatearColumna("Rubro", pos, 150, HAlign.Left)
         .Columns("NombreSubRubro").FormatearColumna("Sub Rubro", pos, 150, HAlign.Left)

         .Columns("CodigoProcesoProductivo").FormatearColumna("Proceso", pos, 100, HAlign.Right)
         .Columns("DescripcionProceso").FormatearColumna("Descripcion", pos, 200, HAlign.Left)

         .Columns("NumeroPedido").FormatearColumna("Pedido Vta", pos, 80)
         .Columns("OrdenPedido").FormatearColumna("Linea Vta", pos, 80)

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

   Private Sub RefrescarDatosGrilla()
      'Limpio la Grilla.
      ugDetalle.ClearFilas()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub


#End Region
End Class