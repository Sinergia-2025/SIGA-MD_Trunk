Imports Eniac.Reglas.CuentasCorrientes

Public Class EstadoSituacionCrediticia

#Region "Campos"
   Private _publicos As Publicos
   Private _titPedidos As Dictionary(Of String, String)
   Private _fechaCobroDesdeDefault As Date
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         tbcDetalle.SelectedTab = tbpPedidos
         _titPedidos = GetColumnasVisiblesGrilla(ugPedidos)
         tbcDetalle.SelectedTab = tbpTotales

         cmbSucursal.Initializar(actual.Sucursal.IdEmpresa, permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion, Entidades.Sucursal.ValoresFijosIdSucursal.Todos)

         _fechaCobroDesdeDefault = Date.Today.AddDays(Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoDiasSumarFechaCobro).UltimoSegundoDelDia()

         '-- Inicializa los Controles.- --------------------------------------------------------
         RefrescarGrillaDetalle()
         '--------------------------------------------------------------------------------------
         bscCodigoCliente.Focus()
      End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() bscCodigoCliente.Focus())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAplicaSaldoLimiteDeCredito.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarGrillaDetalle())
      '--------------------------------------------------------------------------------------
   End Sub
   Private Sub tsbImprimir_Click_1(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
      Sub()
         If ugTotales.Rows.Count = 0 Then Exit Sub

         If tbcDetalle.SelectedTab.Equals(tbpTotales) Then
            UltraGridPrintDocument1.Grid = ugTotales
         ElseIf tbcDetalle.SelectedTab.Equals(tbpCuentasCorrientes) Then
            UltraGridPrintDocument1.Grid = ugCuentaCorriente
         ElseIf tbcDetalle.SelectedTab.Equals(tbpAnticipos) Then
            UltraGridPrintDocument1.Grid = ugAnticipos
         ElseIf tbcDetalle.SelectedTab.Equals(tbpCheques) Then
            UltraGridPrintDocument1.Grid = ugCheques
         Else
            Exit Sub
         End If

         Dim titulo = String.Format("{1}{0}{0}{2} - {3}{0}{0}{0}{4}", Environment.NewLine(), Reglas.Publicos.NombreEmpresaImpresion, Text, tbcDetalle.SelectedTab.Text, CargarFiltrosImpresion())

         Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components) With {
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .Name = "UltraPrintPreviewDialog1",
            .Document = UltraGridPrintDocument1
         }
         UltraPrintPreviewD.Name = Text

         UltraPrintPreviewDialog1.Name = Text
         UltraGridPrintDocument1.Header.TextCenter = titulo
         UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()
      End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
      Sub()
         If ugTotales.Rows.Count = 0 Then Exit Sub
         Dim ugdetalle = GetGrillaSeleccionadaAExporta()
         If ugdetalle IsNot Nothing Then
            ugdetalle.Exportar(String.Format("{0}_{1}.xls", Name, tbcDetalle.SelectedTab.Text), String.Format("{0} - {1}", Text, tbcDetalle.SelectedTab.Text), UltraGridExcelExporter1, CargarFiltrosImpresion())
         End If
      End Sub)
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
      Sub()
         If ugTotales.Rows.Count = 0 Then Exit Sub
         Dim ugdetalle = GetGrillaSeleccionadaAExporta()
         If ugdetalle IsNot Nothing Then
            ugdetalle.Exportar(String.Format("{0}_{1}.pdf", Name, tbcDetalle.SelectedTab.Text), String.Format("{0} - {1}", Text, tbcDetalle.SelectedTab.Text), UltraGridDocumentExporter1, CargarFiltrosImpresion())
         End If
      End Sub)
   End Sub
   Private Sub tsmiAExcelUnificado_Click(sender As Object, e As EventArgs) Handles tsmiAExcelUnificado.Click
      TryCatched(
      Sub()
         If ugTotales.Rows.Count = 0 Then Exit Sub
         Dim exporter = New UltraGridExportarExcel(UltraGridExcelExporter1, Reglas.Publicos.NombreEmpresaImpresion)
         exporter.Exportar(String.Format("{0}.xls", Name), GetGrillasExportar(), CargarFiltrosImpresion())
      End Sub)
   End Sub
   Private Sub tsmiAPDFUnificado_Click(sender As Object, e As EventArgs) Handles tsmiAPDFUnificado.Click
      TryCatched(
      Sub()
         If ugTotales.Rows.Count = 0 Then Exit Sub
         Dim exporter = New UltraGridExportarPDF(UltraGridDocumentExporter1, Reglas.Publicos.NombreEmpresaImpresion)
         exporter.Exportar(String.Format("{0}.pdf", Name), GetGrillasExportar(), CargarFiltrosImpresion())
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
#Region "Eventos Búsqueda Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
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
         bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosCliente(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region
   Private Sub chbFechaVencimientoHastaCtaCte_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaVencimientoHastaCtaCte.CheckedChanged
      TryCatched(Sub() chbFechaVencimientoHastaCtaCte.FiltroCheckedChanged(dtpFechaVencimientoHastaCtaCte, dtpFechaVencimientoHastaCtaCte))
   End Sub
   Private Sub chbFechaCobroDesdeCheques_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCobroDesdeCheques.CheckedChanged
      TryCatched(
      Sub()
         chbFechaCobroDesdeCheques.FiltroCheckedChanged(dtpFechaCobroDesdeCheques, dtpFechaCobroDesdeCheques, _fechaCobroDesdeDefault, _fechaCobroDesdeDefault)
      End Sub)
   End Sub
   Private Sub chbFechaEmisionCtaCte_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEmision.CheckedChanged
      TryCatched(Sub() chbFechaEmision.FiltroCheckedChanged(chbMesCompletoFechaEmision, dtpDesde, dtpHasta))
   End Sub
   Private Sub chbMesCompletoFechaEmision_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoFechaEmision.CheckedChanged
      TryCatched(Sub() chbMesCompletoFechaEmision.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbFechaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPedido.CheckedChanged
      TryCatched(Sub() chbFechaPedido.FiltroCheckedChanged(chbMesCompletoFechaPedido, dtpFechaPedidoDesde, dtpFechaPedidoHasta))
   End Sub

   Private Sub chbMesCompletoFechaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoFechaPedido.CheckedChanged
      TryCatched(Sub() chbMesCompletoFechaPedido.FiltroCheckedChangedMesCompleto(dtpFechaPedidoDesde, dtpFechaPedidoHasta))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbFechaEmision.Checked And dtpDesde.Value.Date > dtpHasta.Value.Date Then
            ShowMessage("ATENCION: La fecha de emisión 'Desde' NO puede ser mayor la la fecha 'Hasta'.")
            dtpDesde.Focus()
            Exit Sub
         End If
         If chbFechaPedido.Checked And dtpFechaPedidoDesde.Value.Date > dtpFechaPedidoHasta.Value.Date Then
            ShowMessage("ATENCION: La fecha de pedido 'Desde' NO puede ser mayor la la fecha 'Hasta'.")
            dtpDesde.Focus()
            Exit Sub
         End If
         If Not bscCodigoCliente.Selecciono And Not bscNombreCliente.Selecciono Then
            ShowMessage("ATENCION: Debe Seleccionar un Cliente.")
            dtpDesde.Focus()
            Exit Sub
         End If

         CargaGrillasEstadoSituacion()

         If ugTotales.Rows.Count = 0 And ugCuentaCorriente.Rows.Count = 0 And ugAnticipos.Rows.Count = 0 And ugCheques.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

   Private Sub ugCuentaCorriente_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugCuentaCorriente.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = ugCuentaCorriente.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               ClickCellButton(ugCuentaCorriente.FilaSeleccionada(Of DataRow)())
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugAnticipos_ClickCellButton(sender As Object, e As CellEventArgs)
      TryCatched(
      Sub()
         Dim dr = ugAnticipos.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               ClickCellButton(ugAnticipos.FilaSeleccionada(Of DataRow)())
            End If
         End If
      End Sub)
   End Sub

   Private Sub txtNuevoLimiteDeCredito_TextChanged(sender As Object, e As EventArgs) Handles txtLimiteDeCreditoNuevo.TextChanged
      TryCatched(
      Sub()
         If TypeOf (btnAplicaSaldoLimiteDeCredito.Tag) Is Entidades.CalculoSaldoLimiteCreditoResultado Then
            Dim estadoSituacionResult = DirectCast(btnAplicaSaldoLimiteDeCredito.Tag, Entidades.CalculoSaldoLimiteCreditoResultado)
            estadoSituacionResult.LimiteDeCreditoNuevo = txtLimiteDeCreditoNuevo.ValorNumericoPorDefecto(0D)
            txtSaldoLimiteDeCreditoNuevo.SetValor(estadoSituacionResult.SaldoLimiteDeCreditoNuevo)
            EvaluaHabilitaControlesAplicar(estadoSituacionResult)
         End If
      End Sub)
   End Sub

   Private Sub btnAplicaSaldoLimiteDeCredito_Click(sender As Object, e As EventArgs) Handles btnAplicaSaldoLimiteDeCredito.Click
      TryCatched(
      Sub()
         If btnAplicaSaldoLimiteDeCredito.Tag IsNot Nothing And TypeOf btnAplicaSaldoLimiteDeCredito.Tag Is Entidades.CalculoSaldoLimiteCreditoResultado Then
            Dim estadoSituacionResult = DirectCast(btnAplicaSaldoLimiteDeCredito.Tag, Entidades.CalculoSaldoLimiteCreditoResultado)
            If estadoSituacionResult.IdCliente.HasValue Then
               Dim rClientes = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Cliente)
               rClientes.ActualizaSaldoLimiteDeCredito(estadoSituacionResult.IdCliente.Value, estadoSituacionResult)
               btnConsultar.PerformClick()
            End If
         End If
      End Sub)
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      TryCatched(
      Sub()
         tssRegistrosTotales.Visible = tbcDetalle.SelectedTab.Equals(tbpTotales)
         tssRegistrosCuentasCorrientes.Visible = tbcDetalle.SelectedTab.Equals(tbpCuentasCorrientes)
         tssRegistrosAnticipos.Visible = tbcDetalle.SelectedTab.Equals(tbpAnticipos)
         tssRegistrosCheques.Visible = tbcDetalle.SelectedTab.Equals(tbpCheques)
         tssRegistrosPedidos.Visible = tbcDetalle.SelectedTab.Equals(tbpPedidos)
      End Sub)
   End Sub


#End Region

#Region "Metodos"
   ''' <summary>
   ''' Procedimiento de Inicializacion.-
   ''' </summary>
   Private Sub RefrescarGrillaDetalle()
      '-- Controles Cliente.- ------------  
      bscCodigoCliente.Text = String.Empty
      bscNombreCliente.Text = String.Empty

      chbFechaVencimientoHastaCtaCte.Checked = False     '-- Fecha Vencimiento.- ------------
      chbFechaCobroDesdeCheques.Checked = True           '-- Fecha Cobro.- ------------------
      chbFechaEmision.Checked = False                    '-- Fecha Emision.- ----------------
      chbFechaPedido.Checked = False                     '-- Fecha Pedido.- -----------------
      chbTotalesSumaCtaCte.Checked = True
      chbTotalesSumaAnticipos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaAnticipos
      chbTotalesSumaCheques.Checked = True
      chbTotalesSumaPedidosPendientes.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaPedidos

      '-----------------------------------
      ugTotales.ClearFilas()
      ugCuentaCorriente.ClearFilas()
      ugAnticipos.ClearFilas()
      ugCheques.ClearFilas()
      ugPedidos.ClearFilas()

      txtLimiteDeCredito.SetValor(0D)
      txtSituacionCrediticia.SetValor(0D)
      txtSaldoLimiteDeCredito.SetValor(0D)
      txtLimiteDeCreditoNuevo.SetValor(0D)
      txtSaldoLimiteDeCreditoNuevo.SetValor(0D)

      chbSaldoLimiteCreditoContemplaCtaCte.Checked = True
      chbSaldoLimiteCreditoContemplaAnticipos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaAnticipos
      chbSaldoLimiteCreditoContemplaCheques.Checked = True
      chbSaldoLimiteCreditoContemplaPedidos.Checked = Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoContemplaPedidos
      btnAplicaSaldoLimiteDeCredito.Enabled = False
      btnAplicaSaldoLimiteDeCredito.Tag = Nothing

      cmbSucursal.Refrescar()

      '-- Posiciona el Cursor.- ----------
      bscCodigoCliente.Focus()
   End Sub

   ''' <summary>
   ''' Carga los Datos del Cliente.- 
   ''' </summary>
   ''' <param name="dr"></param>
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
   End Sub
   ''' <summary>
   ''' Procedimiento de Carga de Estado de Situacion.- --
   ''' </summary>
   Private Sub CargaGrillasEstadoSituacion()

      '-- Carga Id de Cliente.- --
      Dim idCliente = Long.Parse(bscCodigoCliente.Tag.ToString())

      '-- Inicializa Fecha de Vencimiento.- --
      Dim fechaVencimiento = dtpFechaVencimientoHastaCtaCte.Valor(chbFechaVencimientoHastaCtaCte)

      '-- Inicializa Fecha de Cobro.- --
      Dim fechaCobro = dtpFechaCobroDesdeCheques.Valor(chbFechaCobroDesdeCheques)

      '-- Inicializa Fechas desde-hasta de Emision.- --
      Dim desdeEmision = dtpDesde.Valor(chbFechaEmision)
      Dim hastaEmision = dtpHasta.Valor(chbFechaEmision)

      '-- Inicializa Fechas desde-hasta de Emision.- --
      Dim desdePedido = dtpFechaPedidoDesde.Valor(chbFechaPedido)
      Dim hastaPedido = dtpFechaPedidoHasta.Valor(chbFechaPedido)

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      Dim totalesSuma = New EstadoSituacionCrediticia_TotalesSuma(chbTotalesSumaCtaCte.Checked, chbTotalesSumaAnticipos.Checked,
                                                                  chbTotalesSumaCheques.Checked, chbTotalesSumaPedidosPendientes.Checked)
      Dim dsEstadosituacion = rCtaCte.EstadoSituacionCrediticia(cmbSucursal.GetSucursales(), idCliente,
                                                                fechaVencimiento, fechaCobro, desdeEmision, hastaEmision,
                                                                desdePedido, hastaPedido,
                                                                totalesSuma)

      With dsEstadosituacion
         '-- Carga Grilla Totales y SubTotales.- ------
         ugTotales.DataSource = .Tables("Totales")
         AgregarTotalesSuma(ugTotales, {"Importe"})
         ugTotales.ColapsarExpandir(AccionColapsarExpandir.Expandir)

         '-- Carga Grilla CuentasCorrientes y SubTotales.- ------
         ugCuentaCorriente.DataSource = .Tables(EstadoSituacionCrediticia_Totales.CtasCtes.ToString())
         CargarColumnasASumar(ugCuentaCorriente)
         '-- Carga Grilla Anticipos y SubTotales.- ------
         ugAnticipos.DataSource = .Tables(EstadoSituacionCrediticia_Totales.Anticipos.ToString())
         CargarColumnasASumar(ugAnticipos)

         '-- Carga Grilla Cheques y SubTotales.- ------
         ugCheques.DataSource = .Tables(EstadoSituacionCrediticia_Totales.Cheques.ToString())
         '---------------------------------------------
         ''''Dim pos As Integer = 0
         ''''With ugCheques.DisplayLayout.Bands(0)
         ''''   .OcultaTodasLasColumnas()
         ''''   FormatearColumna(.Columns("NombreBanco"), "Nombre Banco", pos, 150, HAlign.Left)
         ''''   FormatearColumna(.Columns("NumeroCheque"), "Numero Cheque", pos, 100, HAlign.Right)
         ''''   FormatearColumna(.Columns("FechaEmision"), "Emision", pos, 100, HAlign.Center)
         ''''   FormatearColumna(.Columns("FechaCobro"), "Cobro", pos, 100, HAlign.Center)
         ''''   FormatearColumna(.Columns("Titular"), "Titular", pos, 200, HAlign.Left)
         ''''   FormatearColumna(.Columns("Importe"), "Importe", pos, 100, HAlign.Right)
         ''''   FormatearColumna(.Columns("NombreProveedor"), "Proveedor", pos, 200, HAlign.Left)
         ''''   FormatearColumna(.Columns("NombresituacionCheque"), "Situacion Cheque", pos, 200, HAlign.Left)
         ''''   FormatearColumna(.Columns("ChequeDeAnticipo"), "Anticipo", pos, 60, HAlign.Center)
         ''''End With
         AgregarTotalesSuma(ugCheques, {"Importe"})
         AgregarFiltroEnLinea(ugCheques, {"NombreBanco", "Titular", "NombreProveedor"})
         ugCheques.ColapsarExpandir(AccionColapsarExpandir.Expandir)

         '-- Carga Grilla Pedidos y SubTotales.- ------
         ugPedidos.DataSource = .Tables(EstadoSituacionCrediticia_Totales.Pedidos.ToString())
         ugPedidos.AgregarTotalesSuma({"ImportePendiente", "ImporteTotal"})
         AjustarColumnasGrilla(ugPedidos, _titPedidos)

      End With

      Dim estadoSituacionResult = rCtaCte.CalculoSaldoLimiteCredito(idCliente, dsEstadosituacion)

      txtLimiteDeCredito.SetValor(estadoSituacionResult.LimiteDeCredito)
      txtSituacionCrediticia.SetValor(estadoSituacionResult.SituacionCrediticia)
      txtSaldoLimiteDeCredito.SetValor(estadoSituacionResult.SaldoLimiteDeCreditoActual)

      txtLimiteDeCreditoNuevo.SetValor(estadoSituacionResult.LimiteDeCreditoNuevo)
      txtSaldoLimiteDeCreditoNuevo.SetValor(estadoSituacionResult.SaldoLimiteDeCreditoNuevo)

      chbSaldoLimiteCreditoContemplaPedidos.Checked = estadoSituacionResult.SaldoLimiteCreditoContemplaPedidos
      chbSaldoLimiteCreditoContemplaAnticipos.Checked = estadoSituacionResult.SaldoLimiteCreditoContemplaAnticipos

      'Habilito el boton de aplicar solo si no aplica filtro que limite la cantidad de registros y el saldo es diferente
      EvaluaHabilitaControlesAplicar(estadoSituacionResult)
      btnAplicaSaldoLimiteDeCredito.Tag = estadoSituacionResult

      '-- Posicional el Tab's.- ---
      tbcDetalle.SelectedTab = tbpTotales
   End Sub

   Private Sub EvaluaHabilitaControlesAplicar(estadoSituacionResult As Entidades.CalculoSaldoLimiteCreditoResultado)
      txtLimiteDeCreditoNuevo.ReadOnly = Not (Not chbFechaVencimientoHastaCtaCte.Checked AndAlso
                                              chbFechaCobroDesdeCheques.Checked AndAlso dtpFechaCobroDesdeCheques.Value = _fechaCobroDesdeDefault AndAlso
                                              Not chbFechaEmision.Checked AndAlso
                                              Not chbFechaPedido.Checked AndAlso
                                              cmbSucursal.TodosSelected)
      btnAplicaSaldoLimiteDeCredito.Enabled = Not chbFechaVencimientoHastaCtaCte.Checked AndAlso
                                              chbFechaCobroDesdeCheques.Checked AndAlso dtpFechaCobroDesdeCheques.Value = _fechaCobroDesdeDefault AndAlso
                                              Not chbFechaEmision.Checked AndAlso
                                              Not chbFechaPedido.Checked AndAlso
                                              cmbSucursal.TodosSelected AndAlso
                                              estadoSituacionResult.SaldoLimiteDeCreditoNuevo <> estadoSituacionResult.SaldoLimiteDeCreditoActual
   End Sub

   Private Sub CargarColumnasASumar(oGrilla As UltraGrid)
      AgregarFiltroEnLinea(oGrilla, {"TipoComprobante", "FormaPago", "Observaciones"}, {"Ver"})
      AgregarTotalesSuma(oGrilla, {"ImporteCuota", "SaldoCuota"})
      oGrilla.ColapsarExpandir(AccionColapsarExpandir.Expandir)
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Cliente: {0} ({1})", bscNombreCliente.Text, bscCodigoCliente.Text)
         If chbFechaCobroDesdeCheques.Checked Then
            filtro.AppendFormat(" - Fecha Cobro: {0:dd/MM/yyyy}", dtpFechaCobroDesdeCheques.Value)
         End If
         If chbFechaVencimientoHastaCtaCte.Checked Then
            filtro.AppendFormat(" - Fecha Vencimiento: {0:dd/MM/yyyy}", dtpFechaVencimientoHastaCtaCte.Value)
         End If
         If chbFechaEmision.Checked Then
            filtro.AppendFormat(" - Fecha Emisión: Desde {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbFechaPedido.Checked Then
            filtro.AppendFormat(" - Fecha Pedido: Desde {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpFechaPedidoDesde.Value, dtpFechaPedidoHasta.Value)
         End If
         If Not cmbSucursal.TodosSelected Then
            cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False, "Sucursal Pedidos", "Sucursales Pedidos", String.Empty, String.Empty)
         End If
      End With
      Return filtro.ToString()
   End Function

   Private Function GetGrillasExportar() As UltraGridExportTituloGrilla()
      Return {New UltraGridExportTituloGrilla() With {.Grilla = ugTotales, .Titulo = String.Format("{0} - {1}", Text, tbpTotales.Text), .NombreHoja = tbpTotales.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugCuentaCorriente, .Titulo = String.Format("{0} - {1}", Text, tbpCuentasCorrientes.Text), .NombreHoja = tbpCuentasCorrientes.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugAnticipos, .Titulo = String.Format("{0} - {1}", Text, tbpAnticipos.Text), .NombreHoja = tbpAnticipos.Text},
              New UltraGridExportTituloGrilla() With {.Grilla = ugCheques, .Titulo = String.Format("{0} - {1}", Text, tbpCheques.Text), .NombreHoja = tbpCheques.Text}}
   End Function
   Private Function GetGrillaSeleccionadaAExporta() As UltraGrid
      If tbcDetalle.SelectedTab.Equals(tbpTotales) Then
         Return ugTotales
      ElseIf tbcDetalle.SelectedTab.Equals(tbpCuentasCorrientes) Then
         Return ugCuentaCorriente
      ElseIf tbcDetalle.SelectedTab.Equals(tbpAnticipos) Then
         Return ugAnticipos
      ElseIf tbcDetalle.SelectedTab.Equals(tbpCheques) Then
         Return ugCheques
      Else
         Return Nothing
      End If
   End Function

   Private Sub ClickCellButton(dr As DataRow)
      Try
         Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
         oTipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())

         If oTipoComprobante.EsRecibo Or oTipoComprobante.EsAnticipo Then
            Dim IdTipoComprobante As String = IIf(oTipoComprobante.EsRecibo, oTipoComprobante.IdTipoComprobante, oTipoComprobante.IdTipoComprobanteSecundario).ToString()
            Dim reg = New Reglas.CuentasCorrientes()

            Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                       IdTipoComprobante, 'dr("IdTipoComprobante").ToString(),
                                                                       dr("Letra").ToString(),
                                                                       Integer.Parse(dr("CentroEmisor").ToString()),
                                                                       Long.Parse(dr("NumeroComprobante").ToString()))
            Dim imp = New RecibosImprimir()
            imp.ImprimirRecibo(ctacte, True)
         Else
            'imprime los comprobantes que no son recibos
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                            dr("IdTipoComprobante").ToString(),
                                                            dr("Letra").ToString(),
                                                            Short.Parse(dr("CentroEmisor").ToString()),
                                                            Long.Parse(dr("NumeroComprobante").ToString()))
            Dim oImpr As Impresion = New Impresion(venta)

            If Not oTipoComprobante.EsFiscal Then
               oImpr.ImprimirComprobanteNoFiscal(True)
            Else
               oImpr.ReImprimirComprobanteFiscal()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

End Class