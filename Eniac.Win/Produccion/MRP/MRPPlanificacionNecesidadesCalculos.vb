Imports Eniac.Entidades

Public Class MRPPlanificacionNecesidadesCalculos
#Region "Campos"
   Private _publicos As Publicos
   Public Property dtDetalle As DataTable
   Public Property dtNecesidades As List(Of Entidades.MRPProductosNecesarios)
#End Region
   Private Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(detalle As DataRow())
      Me.New()
      dtDetalle = detalle.CopyToDataTable()
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))
         _publicos.CargaComboDepositos(cmbDeposito, actual.Sucursal.IdSucursal, False, False, Entidades.Publicos.SiNoTodos.TODOS)
         cmbDeposito.SelectedIndex = -1
         Me.ugDetalle.DataSource = dtDetalle
         FormateaGrillaProductos()

         chbDepositoDefecto.Checked = True
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbCalcularNecesidades.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#End Region

#Region "Metodos"
   Public Sub FormateaGrillaOrdenes()
      ugDetalleFinal.Rows.Refresh(RefreshRow.ReloadData)
      ugDetalleFinal.DisplayLayout.Bands(0).SortedColumns.RefreshSort(True)

      With ugDetalleFinal.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         Grilla.AgregarFiltroEnLinea(ugDetalle, {"IdProductoProceso", "NombreProductoProceso"})

         .Columns("IdTipoComprobante").FormatearColumna("Comprobante Origen", pos, 150, HAlign.Left)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero Origen", pos, 80, HAlign.Right)
         .Columns("IdProductoProceso").FormatearColumna("Producto", pos, 80, HAlign.Right)
         .Columns("NombreProductoProceso").FormatearColumna("Nombre Producto", pos, 200, HAlign.Left)

         .Columns("FechaEntrega").FormatearColumna("Fecha Entrega", pos, 80, HAlign.Center)
         .Columns("FechaFinaliza").FormatearColumna("Fecha Finalizacion", pos, 80, HAlign.Center)

         .Columns("CantidadStock").FormatearColumna("Stock", pos, 80, HAlign.Right, , "N2")
         .Columns("CantidadSolicitada").FormatearColumna("Cantidad Demandada", pos, 80, HAlign.Right, , "N2")
         .Columns("CantidadFabricar").FormatearColumna("Cantidad Producir", pos, 80, HAlign.Right, , "N2")

      End With
      Me.tssRegistros.Text = (Me.ugDetalleFinal.Rows.Count).ToString() & " Registros"

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
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 150)

         .Columns("FechaEntrega").FormatearColumna("Entrega", pos, 80, HAlign.Center)
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
      Me.tssRegistros.Text = (Me.ugDetalle.Rows.Count).ToString() & " Registros"

   End Sub

   Private Sub chbDepositoDefecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbDepositoDefecto.CheckedChanged
      If chbDepositoDefecto.Checked Then
         chbDepositoStock.Checked = Not chbDepositoDefecto.Checked
      End If
   End Sub

   Private Sub chbDepositoStock_CheckedChanged(sender As Object, e As EventArgs) Handles chbDepositoStock.CheckedChanged
      If chbDepositoStock.Checked Then
         chbDepositoDefecto.Checked = Not chbDepositoStock.Checked
      End If
      cmbDeposito.Enabled = chbDepositoStock.Checked
      cmbDeposito.SelectedIndex = -1
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub MarcaGrilla()
      If ugDetalleFinal.ActiveRow IsNot Nothing AndAlso ugDetalleFinal.ActiveRow.Cells("CantidadFabricar").Value IsNot Nothing Then
         If Decimal.Parse(ugDetalleFinal.ActiveRow.Cells("CantidadFabricar").Value.ToString()) > 0 Then
            ugDetalleFinal.ActiveRow.Cells("CantidadFabricar").Color(Nothing, Color.Red)
         End If
      End If
   End Sub

   Private Sub btnCalcularOrdenes_Click(sender As Object, e As EventArgs) Handles btnCalcularOrdenes.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If chbDepositoStock.Checked And cmbDeposito.SelectedIndex = -1 Then
            MessageBox.Show("Debe Seleccionar un Depósito.-", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()
         Dim rPN As New Reglas.OrdenesProduccionMRPProductos()
         Dim eNs As New List(Of Entidades.MRPProductosNecesarios)
         Dim nodoPadre = 0
         For Each dr In DirectCast(ugDetalle.DataSource, DataTable).Select("Masivo")
            '--------------------------------------------
            Dim OP = New Reglas.OrdenesProduccion().GetUno(dr.Field(Of Integer)("IdSucursal"),
                                                           dr.Field(Of String)("IdTipoComprobante"),
                                                           dr.Field(Of String)("Letra"),
                                                           dr.Field(Of Integer)("CentroEmisor"),
                                                           dr.Field(Of Integer)("NumeroOrdenProduccion"))
            '--------------------------------------------
            rPN.ObtieneListaNecesarios(dr.Field(Of Integer)("IdSucursal"),
                                       dr.Field(Of String)("IdTipoComprobante"),
                                       dr.Field(Of String)("Letra"),
                                       dr.Field(Of Integer)("CentroEmisor"),
                                       dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                       dr.Field(Of Long)(OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString()), eNs, dr.Field(Of Decimal)("CantEstado"), dr, nodoPadre,
                                       dr.Field(Of String)("IdProducto"), OP)
         Next
         '--
         Dim eDepNro As Integer = 0
         Dim eDepDef As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.TODOS
         If chbDepositoDefecto.Checked Then
            eDepDef = Entidades.Publicos.SiNoTodos.SI
            eDepNro = 0
         End If
         If chbDepositoStock.Checked Then
            eDepDef = Entidades.Publicos.SiNoTodos.NO
            eDepNro = Integer.Parse(cmbDeposito.SelectedValue.ToString())
         End If
         '-- Adjunta Datos al Datasource.-
         dtNecesidades = rPN.CalculaNecesidadesGrilla(eNs, eDepDef, eDepNro, chbInformeCompleto.Checked)
         '-- REQ-42263.- -------------------------------------------------------------------------------
         Dim activosNecesarios = dtNecesidades.Where(Function(x) x.ProcesoActivo = False).ToList()
         If activosNecesarios.Count > 0 Then
            Dim respuesta As DialogResult
            Dim myString = New StringBuilder()
            myString.AppendLine("Posee Productos con Procesos Productivos Inactivos!!!")
            myString.AppendLine("Desea continuar de igual forma???")
            For Each aNec As MRPProductosNecesarios In activosNecesarios
               myString.AppendFormat(" {0}-{1}", aNec.IdProductoProceso, aNec.NombreProductoProceso)
            Next
            respuesta = ShowPregunta(myString.ToString())
            If respuesta = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If
         '-------------------------------------------------------------------------
         CargaGrillaNecesidades()
         '-------------------------------------------------------------------------
         tsbCalcularNecesidades.Visible = False
         tsbOrdenesProduccion.Visible = True

         tbcOrdenProduccionCostos.SelectedTab = tbpOrdenes
         btnConfirmar.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargaGrillaNecesidades()
      ugDetalleFinal.DataSource = dtNecesidades
      FormateaGrillaOrdenes()
      If ugDetalleFinal.Rows.Count > 0 Then
         '-- Valida el estado de las operaciones.- --
         For Ind = 0 To (ugDetalleFinal.Rows.Count - 1)
            ugDetalleFinal.ActiveRow = ugDetalleFinal.Rows(Ind)
            MarcaGrilla()
         Next
         ugDetalleFinal.ActiveRow = ugDetalleFinal.Rows(0)
         MarcaGrilla()
      End If
   End Sub
   Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
      Dim respuesta As DialogResult
      Dim nPlanMaster = New Reglas.OrdenesProduccionEstados().GetPlanMaestroMaximo() + 1
      respuesta = ShowPregunta(String.Format("¿Confirma la Generación de Ordenes de Produccion para el Plan Maestro Nro {0}?", nPlanMaster))
      If respuesta = Windows.Forms.DialogResult.Yes Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Me.GrabarOrdenesProduccion(nPlanMaster)
            MessageBox.Show(String.Format("Generacion Exitosa del Plan Maestro Nro {0}", nPlanMaster), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub
   Private Sub GrabarOrdenesProduccion(nPlanMaster As Integer)
      If String.IsNullOrEmpty(Reglas.Publicos.EstadoOrdenProduccionPlanificacion) Then
         MessageBox.Show("No se ha definido un Estado de Orden de Produccion por Defecto. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Exit Sub
      End If

      Dim rOPN = New Reglas.OrdenesProduccion()
      rOPN.GrabaOrdenProduccionNecesidad(nPlanMaster, DirectCast(ugDetalleFinal.DataSource, List(Of Entidades.MRPProductosNecesarios)), DirectCast(ugDetalle.DataSource, DataTable), IdFuncion)

   End Sub
#End Region
End Class