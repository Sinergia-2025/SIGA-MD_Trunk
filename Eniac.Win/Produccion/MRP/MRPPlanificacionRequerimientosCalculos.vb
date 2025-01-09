Public Class MRPPlanificacionRequerimientosCalculos

#Region "Campos"
   Private _publicos As Publicos
   Public Property dtDetalle As DataTable
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
         ugDetalle.DataSource = dtDetalle

         tbcOrdenProduccionCostos.SelectedTab = tbpOrdenes
         tbcOrdenProduccionCostos.SelectedTab = tbpProductos

         FormateaGrillaOrdenes()

         chbDepositoDefecto.Checked = True
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

      If String.IsNullOrEmpty(Reglas.Publicos.EstadoOrdenProduccionPlanificacionRQ) Then
         MessageBox.Show("No se ha definido un Estado Final en la Planificacion de Requerimientos.-", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Exit Sub
      End If

      Dim respuesta As DialogResult
      Dim nRequerimiento = New Reglas.RequerimientosCompras().GetCodigoMaximo() + 1

      respuesta = ShowPregunta(String.Format("¿Confirma la Generación del Requerimiento Nro {0}?", nRequerimiento))
      If respuesta = Windows.Forms.DialogResult.Yes Then
         Try
            Me.Cursor = Cursors.WaitCursor
            '------------------------------
            Me.GrabarRequerimientoProduccion()
            '------------------------------
            MessageBox.Show("Generacion Exitosa del Requerimiento", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub
   Private Sub btnCalcularRequerimientos_Click(sender As Object, e As EventArgs) Handles btnCalcularRequerimientos.Click
      Try
         If Not chbDepositoDefecto.Checked And Not chbDepositoStock.Checked Then
            MessageBox.Show("Debe Seleccionar un de los tipo de Depósito.-", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If
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
            rPN.ObtieneListaNecesariosRequerimento(dr.Field(Of Integer)("IdSucursal"),
                                                   dr.Field(Of String)("IdTipoComprobante"),
                                                   dr.Field(Of String)("Letra"),
                                                   dr.Field(Of Integer)("CentroEmisor"),
                                                   dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                                   dr.Field(Of Long)("IdCliente"),
                                                   dr.Field(Of String)("NombreCliente"),
                                                   dr.Field(Of Long)(Entidades.MRPProcesoProductivoProducto.Columnas.IdProcesoProductivo.ToString()), eNs, dr.Field(Of Decimal)("CantEstado"), dr, nodoPadre)
         Next

         Dim gOP = From Rows In eNs
                   Group Rows By Rows.IdProductoProceso, Rows.DepositoDefecto Into Group

         Dim cache = New Reglas.BusquedasCacheadas()

         For Each eOP In gOP

            Dim eCant = GetStock(eOP.IdProductoProceso.ToString(), eOP.DepositoDefecto)

            Dim producto = cache.BuscaProductoEntidadPorId(eOP.IdProductoProceso)
            Dim eCantMax = producto.StockMaximo

            For Each ePN In eNs.OrderBy(Function(x) x.IdProductoProceso).ThenBy(Function(x) x.CantidadSolicitada).Where(Function(x) x.IdProductoProceso = eOP.IdProductoProceso.ToString()).ToList()
               Dim productoNecesario = cache.BuscaProductoEntidadPorId(ePN.IdProductoProceso)

               ePN.FactorConversionCompra = productoNecesario.FactorConversionCompra
               ePN.CantidadStock = eCant
               Dim CantComprar As Decimal

               If eCantMax > 0 AndAlso chkStockMaximo.Checked Then
                  If ePN.CantidadSolicitada > eCantMax Then
                     CantComprar = (eCantMax - eCant)
                  Else
                     CantComprar = (ePN.CantidadSolicitada - eCant)
                  End If
                  eCant -= ePN.CantidadFabricar
                  If CantComprar <= 0 Then
                     ePN.CantidadFabricar = 0
                  Else
                     ePN.CantidadFabricar = CantComprar
                  End If
               Else
                  If (ePN.CantidadStock - ePN.CantidadSolicitada) > 0 Then
                     ePN.CantidadFabricar = 0
                     eCant -= ePN.CantidadSolicitada
                  Else
                     '-- Se suma la evaluacion de Stock Maximo.-
                     ePN.CantidadFabricar = (ePN.CantidadStock - ePN.CantidadSolicitada) * -1
                     eCant = 0
                  End If
               End If
            Next
         Next
         ugDetalleFinal.DataSource = eNs.OrderBy(Function(x) x.IdProductoProceso).ThenBy(Function(x) x.CantidadSolicitada).ToList()
         FormateaGrillaProductos()
         tbcOrdenProduccionCostos.SelectedTab = tbpOrdenes
         btnConfirmar.Enabled = True
         '--
         tsbImprimir.Visible = True
         tsddExportar.Visible = True
         '--
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalleFinal_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalleFinal.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.MRPProductosNecesarios)
         If dr IsNot Nothing Then
            If dr.CantidadFabricar > 0 Then
               e.Row.Cells("CantidadFabricar").Color(Color.White, Color.Red)
               e.Row.Cells("CantidadUMCompraFabricar").Color(Color.White, Color.Red)
            End If
         End If
      End Sub)
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
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub()
                    '-- Impresion de Requerimientos.-
                    ugDetalleFinal.Imprimir(Text, String.Empty)
                 End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalleFinal.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, String.Empty))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalleFinal.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, String.Empty))
   End Sub

   Private Sub tbcOrdenProduccionCostos_Selected(sender As Object, e As TabControlEventArgs) Handles tbcOrdenProduccionCostos.Selected
      TryCatched(Sub()
                    tsbImprimir.Visible = (tbcOrdenProduccionCostos.SelectedTab Is tbpOrdenes)
                    tsddExportar.Visible = (tbcOrdenProduccionCostos.SelectedTab Is tbpOrdenes)
                 End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub GrabarRequerimientoProduccion()
      Dim rOPN = New Reglas.OrdenesProduccion()
      rOPN.GrabaOrdenProduccionNecesidadRQ(DirectCast(ugDetalleFinal.DataSource, List(Of Entidades.MRPProductosNecesarios)), DirectCast(ugDetalle.DataSource, DataTable), IdFuncion)
   End Sub
   Private Function GetStock(eProd As String, eDepD As Integer) As Decimal

      If chbDepositoDefecto.Checked Then
         Return New Reglas.ProductosSucursales().GetSucursalesDepositoStock(actual.Sucursal.IdSucursal, eDepD, eProd.ToString())
      End If
      If chbDepositoStock.Checked Then
         Return New Reglas.ProductosSucursales().GetSucursalesDepositoStock(actual.Sucursal.IdSucursal, Integer.Parse(cmbDeposito.SelectedValue.ToString()), eProd.ToString())
      End If

      Return New Reglas.ProductosSucursales().GetSucursalProductosStock(actual.Sucursal.IdSucursal, eProd.ToString())
   End Function
   Public Sub FormateaGrillaOrdenes()
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

      End With
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub
   Public Sub FormateaGrillaProductos()
      ugDetalleFinal.Rows.Refresh(RefreshRow.ReloadData)
      ugDetalleFinal.DisplayLayout.Bands(0).SortedColumns.RefreshSort(True)

      With ugDetalleFinal.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         ugDetalle.AgregarFiltroEnLinea({"IdProductoProceso", "NombreProductoProceso"})

         .Columns("IdProductoProceso").FormatearColumna("Producto", pos, 80, HAlign.Right)
         .Columns("NombreProductoProceso").FormatearColumna("Nombre Producto", pos, 150, HAlign.Left)

         .Columns("FechaEntrega").FormatearColumna("Fecha Entrega", pos, 75, HAlign.Center)
         .Columns("FechaFinaliza").FormatearColumna("Fecha Finalizacion", pos, 75, HAlign.Center)

         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150, HAlign.Left)

         .Columns("CantidadStock").FormatearColumna("Stock", pos, 75, HAlign.Right, , "N2")

         .Columns("StockMaximo").FormatearColumna("Stock Maximo", pos, 75, HAlign.Right, , "N2")
         .Columns("StockMinimo").FormatearColumna("Stock Minimo", pos, 75, HAlign.Right, , "N2")

         .Columns("CantidadSolicitada").FormatearColumna("Cantidad Demandada", pos, 75, HAlign.Right, , "N2")
         .Columns("CantidadFabricar").FormatearColumna("Cantidad Comprar", pos, 75, HAlign.Right, , "N2")
         .Columns("CantidadUMCompraFabricar").FormatearColumna("Cantidad UMC Comprar", pos, 75, HAlign.Right, , "N2")

         If ugDetalleFinal.DataSource(Of List(Of Entidades.MRPProductosNecesarios)).AnySecure(Function(dr) dr.CantidadUMCompraFabricar <> 0) Then
            .Columns("CantidadUMCompraFabricar").Hidden = False
         Else
            .Columns("CantidadUMCompraFabricar").Hidden = True
         End If
         .Columns("IdProductoOrigen").FormatearColumna("Producto Principal", pos, 75, HAlign.Right)
         .Columns("UnidadMedidaDestino").FormatearColumna("UMS", pos, 80, HAlign.Center)

         .Columns("UnidadMedidaCompra").FormatearColumna("UMC", pos, 80, HAlign.Center)

         '.Columns("IdTipoComprobante").FormatearColumna("Comprobante Origen", pos, 150, HAlign.Left)
         '.Columns("NumeroOrdenProduccion").FormatearColumna("Numero Origen", pos, 80, HAlign.Right)

      End With
      ugDetalleFinal.AgregarFiltroEnLinea({"NombreProductoProceso"})
      tssRegistros.Text = ugDetalleFinal.CantidadRegistrosParaStatusbar
   End Sub

#End Region
End Class