#Region "Option/Imports"
Option Strict On
Option Explicit On

#End Region
Public Class InfPedidosFacturados

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         '_publicos.CargaComboDesdeEnum(cmbProcesado, GetType(Entidades.Publicos.SiNoTodos))
         '_publicos.CargaComboRutas(cmbRuta, True, False, False)

         _publicos.CargaComboDesdeEnum(cmbEvaluar, GetType(Evaluar))
         cmbEvaluar.SelectedValue = Evaluar.Negativos

         RefrescarDatosGrilla()

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "Observaciones"})
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalleDetallado, {"NombreCliente", "Observaciones"})

         ''LeerPreferencias()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If

      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

#Region "Eventos ToolBar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
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

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = CargarFiltrosImpresion()
         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         ugDetalle.Exportar(String.Format("{0}.xls", Me.Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         ugDetalle.Exportar(String.Format("{0}.pdf", Me.Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
   Private Sub chbFechaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPedido.CheckedChanged
      Try
         chbFechaPedido.FiltroCheckedChanged(chbMesCompletoFechaPedidos, dtpDesdeFechaPedidos, dtpHastaFechaPedidos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub chbFechaProceso_CheckedChanged(sender As Object, e As EventArgs)
   '   Try
   '      chbFechaProceso.FiltroCheckedChanged(chbMesCompletoFechaProceso, dtpDesdeFechaProceso, dtpHastaFechaProceso)
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompletoFechaPedidos.CheckedChanged
      Try
         chbMesCompletoFechaPedidos.FiltroCheckedChangedMesCompleto(dtpDesdeFechaPedidos, dtpHastaFechaPedidos)
      Catch ex As Exception
         chbMesCompletoFechaPedidos.Checked = False
         ShowError(ex)
      End Try
   End Sub

   'Private Sub chbMesCompletoFechaProceso_CheckedChanged(sender As Object, e As EventArgs)
   '   Try
   '      chbMesCompletoFechaProceso.FiltroCheckedChangedMesCompleto(dtpDesdeFechaProceso, dtpHastaFechaProceso)
   '   Catch ex As Exception
   '      chbMesCompletoFechaProceso.Checked = False
   '      ShowError(ex)
   '   End Try
   'End Sub

   'Private Sub chbRuta_CheckedChanged(sender As System.Object, e As System.EventArgs)
   '   Try
   '      chbRuta.FiltroCheckedChanged(cmbRuta)
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Private Sub chbCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscNombreCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos Buscadores"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Dim reglas As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim idCliente As Long = If(IsNumeric(bscCodigoCliente.Text), Long.Parse(bscCodigoCliente.Text), -1)

         Me.bscCodigoCliente.Datos = reglas.GetFiltradoPorCodigo(idCliente, False, False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Dim reglas As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes2(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = reglas.GetFiltradoPorNombre(Me.bscNombreCliente.Text, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscNombreCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Public Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         'If Me.chbRuta.Checked And Me.cmbRuta.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó un Calendario aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbRuta.Focus()
         '   Exit Sub
         'End If

         If Me.chbCliente.Checked And Me.bscCodigoCliente.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarCliente(ByVal dr As DataGridViewRow)
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()

      Me.bscCodigoCliente.Enabled = False
      Me.bscNombreCliente.Enabled = False
   End Sub

   Protected Overridable Sub RefrescarDatosGrilla()
      chbFechaPedido.Checked = True
      chbMesCompletoFechaPedidos.Checked = False
      dtpDesdeFechaPedidos.Value = Date.Today
      dtpHastaFechaPedidos.Value = Date.Today.UltimoSegundoDelDia()

      'chbFechaProceso.Checked = True
      'chbMesCompletoFechaProceso.Checked = False
      'dtpDesdeFechaProceso.Value = Date.Today
      'dtpHastaFechaProceso.Value = Date.Today.UltimoSegundoDelDia()

      chbCliente.Checked = False
      'chbRuta.Checked = False
      'cmbProcesado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      ugDetalle.ClearFilas(Of Entidades.JSonEntidades.SiMovilPedidos.PedidoSiMovilJSon)()
   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         'If chbRuta.Checked AndAlso cmbRuta.SelectedIndex < 0 Then
         '   ShowMessage("ATENCION: NO seleccionó una Ruta aunque activó ese Filtro.")
         '   cmbRuta.Focus()
         'End If
         'If chbCliente.Checked AndAlso (bscCodigoCliente.Selecciono Or bscNombreCliente.Selecciono) AndAlso IsNumeric(bscCodigoCliente.Tag) Then
         '   ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
         '   bscCodigoCliente.Focus()
         'End If
         'If cmbProcesado.SelectedIndex < 0 Then
         '   ShowMessage("ATENCION: Debe seleccionar el filtro de Procesado.")
         '   cmbProcesado.Focus()
         'End If

         '_tit = GetColumnasVisiblesGrilla(ugDetalle)

         Dim fechaPedidosDesde As DateTime? = Nothing
         If chbFechaPedido.Checked Then fechaPedidosDesde = dtpDesdeFechaPedidos.Value
         Dim fechaPedidosHasta As DateTime? = Nothing
         If chbFechaPedido.Checked Then fechaPedidosHasta = dtpHastaFechaPedidos.Value
         'Dim fechaProcesoDesde As DateTime? = Nothing
         'If chbFechaProceso.Checked Then fechaProcesoDesde = dtpDesdeFechaProceso.Value
         'Dim fechaProcesoHasta As DateTime? = Nothing
         'If chbFechaProceso.Checked Then fechaProcesoHasta = dtpHastaFechaProceso.Value

         'Dim rPedidosWeb As Reglas.ServiciosRest.Pedidos.PedidosSiMovilPedidos = New Reglas.ServiciosRest.Pedidos.PedidosSiMovilPedidos()
         'Dim pedidos As List(Of Entidades.JSonEntidades.SiMovilPedidos.PedidoSiMovilJSon)
         'pedidos = rPedidosWeb.GetPedidosConFK(fechaPedidosDesde, fechaPedidosHasta,
         '                                      fechaProcesoDesde, fechaProcesoHasta,
         '                                      If(chbRuta.Checked, Integer.Parse(cmbRuta.SelectedValue.ToString()), 0),
         '                                      If(chbCliente.Checked, Long.Parse(chbCliente.Tag.ToString()), 0),
         '                                      DirectCast(cmbProcesado.SelectedValue, Entidades.Publicos.SiNoTodos))



         Dim pedidos As Entidades.DsInfPedidosFacturados = New Reglas.Pedidos().GetInfPedidosFacturados(fechaPedidosDesde, fechaPedidosHasta,
                                                                                                        If(chbCliente.Checked, Long.Parse(chbCliente.Tag.ToString()), 0),
                                                                                                        If(chbCliente.Checked, Long.Parse(chbCliente.Text.ToString()), 0),
                                                                                                        If(IsNumeric(txtTolerancia.Text), Decimal.Parse(txtTolerancia.Text), 0))

         Me.ugDetalle.DataSource = pedidos
         Me.ugDetalleDetallado.DataSource = pedidos.Detalle

         Me.tssRegistros.Text = String.Format("{0} Registros", pedidos.Cabecera.Rows.Count)

         'AjustarColumnasGrilla(ugDetalle, _tit)
         'FormatearGrillaBanda1()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrillaBanda1()
      'With ugDetalle.DisplayLayout.Bands(1)
      '   'For Each col As UltraGridColumn In .Columns
      '   '   .Hidden = True
      '   'Next
      '   Dim pos As Integer = 0
      '   .Columns("IdEmpresa").FormatearColumna("Código Empresa", pos, 100, HAlign.Right, True)
      '   .Columns("IdDispositivo").FormatearColumna("Id Dispositivo", pos, 100, , True)
      '   .Columns("IdPedido").FormatearColumna("Id Pedido", pos, 100, HAlign.Right, True)
      '   .Columns("Orden").FormatearColumna("Órden", pos, 50, HAlign.Right)
      '   .Columns("IdProducto").FormatearColumna("Código Producto", pos, 110)
      '   .Columns("NombreProducto").FormatearColumna("Producto", pos, 250)
      '   .Columns("Cantidad").FormatearColumna("Cantidad", pos, 75, HAlign.Right, , "N2")
      '   .Columns("Precio").FormatearColumna("Precio", pos, 75, HAlign.Right, , "N2")
      '   .Columns("Descuento").FormatearColumna("Descuento", pos, 75, HAlign.Right, , "N2")
      '   .Columns("IdPlazoEntrega").FormatearColumna("Id Plazo Entrega", pos, 100, HAlign.Right, True)
      '   .Columns("CantidadCambio").FormatearColumna("Cantidad Cambio", pos, 75, HAlign.Right, , "N2")
      '   .Columns("CantidadBonif").FormatearColumna("Cantidad Bonificación", pos, 75, HAlign.Right, , "N2")
      '   .Columns("NotaCambio").FormatearColumna("Nota Cambio", pos, 100, HAlign.Right)
      '   .Columns("NotaBonif").FormatearColumna("Nota Bonificación", pos, 100, HAlign.Right)
      '   .Columns("IdListaPrecios").FormatearColumna("Id Lista Precios", pos, 60, HAlign.Right)
      '   .Columns("NombreListaPrecios").FormatearColumna("Lista Precios", pos, 150)
      'End With
   End Sub

   Protected Overridable Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro
         '.AppendFormat("Procesado: {0}", cmbProcesado.Text)
         If chbFechaPedido.Checked Then
            .AppendFormat(" - Fecha Pedido: {0:dd/MM/yyyy HH:mm} a {1:dd/MM/yyyy HH:mm}", Me.dtpDesdeFechaPedidos.Value, dtpHastaFechaPedidos.Value)
         End If
         'If chbFechaProceso.Checked Then
         '   .AppendFormat(" - Fecha Proceso: {0:dd/MM/yyyy HH:mm} a {1:dd/MM/yyyy HH:mm}", Me.dtpDesdeFechaProceso.Value, dtpHastaFechaProceso.Value)
         'End If

         'If chbRuta.Checked Then
         '   .AppendFormat(" - Ruta : {0}", cmbRuta.Text)
         'End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            .AppendFormat(" - Cliente: {0} - {1}", Me.bscCodigoCliente.Text.Trim(), Me.bscNombreCliente.Text.Trim())
         End If

      End With
      Return filtro.ToString()
   End Function

#End Region

   'Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
   '   Try
   '      Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
   '      pre.ShowDialog()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub
   'Protected Overridable Sub LeerPreferencias()
   '   Try
   '      Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

   '      If System.IO.File.Exists(nameGrid) Then
   '         Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         Dim evalua As Evaluar = cmbEvaluar.ValorSeleccionado(Of Evaluar)()
         Dim dr As Entidades.DsInfPedidosFacturados.DetalleRow = ugDetalle.FilaSeleccionada(Of Entidades.DsInfPedidosFacturados.DetalleRow)(e.Row)
         If dr IsNot Nothing Then
            If (evalua = Evaluar.Positivos Or evalua = Evaluar.Ambos) And dr.Diferencia_PedidoVenta_tolerancia > 0 Then
               e.Row.Cells("Diferencia_PedidoVenta_Imagen").Value = My.Resources.navigate_up
            End If
            If (evalua = Evaluar.Negativos Or evalua = Evaluar.Ambos) And dr.Diferencia_PedidoVenta_tolerancia < 0 Then
               e.Row.Cells("Diferencia_PedidoVenta_Imagen").Value = My.Resources.navigate_down
            End If
            If (evalua = Evaluar.Positivos Or evalua = Evaluar.Ambos) And dr.Diferencia_PedidoWebPedido_tolerancia > 0 Then
               e.Row.Cells("Diferencia_PedidoWebPedido_Imagen").Value = My.Resources.navigate_up
            End If
            If (evalua = Evaluar.Negativos Or evalua = Evaluar.Ambos) And dr.Diferencia_PedidoWebPedido_tolerancia < 0 Then
               e.Row.Cells("Diferencia_PedidoWebPedido_Imagen").Value = My.Resources.navigate_down
            End If
         End If
         Dim drCabecera As Entidades.DsInfPedidosFacturados.CabeceraRow = ugDetalle.FilaSeleccionada(Of Entidades.DsInfPedidosFacturados.CabeceraRow)(e.Row)
         If drCabecera IsNot Nothing Then
            Dim count As Integer = 0
            If evalua = Evaluar.Ambos Then
               count = drCabecera.GetDetalleRows().Where(Function(x) x.Diferencia_PedidoVenta_tolerancia <> 0 Or x.Diferencia_PedidoWebPedido_tolerancia <> 0).Count
            ElseIf evalua = Evaluar.Positivos Then
               count = drCabecera.GetDetalleRows().Where(Function(x) x.Diferencia_PedidoVenta_tolerancia > 0 Or x.Diferencia_PedidoWebPedido_tolerancia > 0).Count()
            ElseIf evalua = Evaluar.Negativos Then
               count = drCabecera.GetDetalleRows().Where(Function(x) x.Diferencia_PedidoVenta_tolerancia < 0 Or x.Diferencia_PedidoWebPedido_tolerancia < 0).Count()
            End If
            If count > 0 Then
               e.Row.Cells("Diferencia").Value = "SI"
            Else
               e.Row.Cells("Diferencia").Value = "no"
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Enum Evaluar
      Ambos
      Positivos
      Negativos
   End Enum

End Class