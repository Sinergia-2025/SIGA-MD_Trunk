Public Class ComprobantesPendientesAyuda

#Region "Campos"

   Private _publicos As Publicos

   Private _tipoComprobanteFacturador As Entidades.TipoComprobante
   Private _idListaPrecios As Integer
   Private _idTipoComprob As String    'No puede tener el nombre _idTipoComprobante porque coincide con el parametro.
   Private _idCliente As Long
   Private _idCategoria As Integer

   Private _embarcacion As Long
   Private _Cama As Long

#End Region

#Region "Propiedades"
   Public ReadOnly Property ComprobantesSeleccionados() As List(Of Entidades.CuentaCorrientePago)
#End Region

#Region "Constructores"
   Public Sub New(tipoComprobanteFacturador As Entidades.TipoComprobante, idTipoComprobante As String, idCliente As Long,
                  comprobantesSeleccionados As List(Of Entidades.CuentaCorrientePago), idCategoria As Integer, idEmbarcacion As Long, idCama As Long)
      InitializeComponent()

      _tipoComprobanteFacturador = tipoComprobanteFacturador 'New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)

      _idTipoComprob = idTipoComprobante
      _idCliente = idCliente
      _idCategoria = idCategoria
      '--- REQ-33207.- -----------
      _embarcacion = idEmbarcacion
      '---------------------------
      _Cama = idCama

      _ComprobantesSeleccionados = comprobantesSeleccionados
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() CargarValoresIniciales())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         ugDetalle.UpdateData()

         For Each dr In ugDetalle.DataSource(Of DataTable).Where(Function(drw) drw.Field(Of Boolean)("SELEC"))
            If ComprobantesSeleccionados.Exists(Function(c) c.IdSucursal = dr.Field(Of Integer)("Sucursal") And
                                                            c.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante") And
                                                            c.Letra = dr.Field(Of String)("Letra") And
                                                            c.CentroEmisor = dr.Field(Of Integer)("Emisor") And
                                                            c.NumeroComprobante = dr.Field(Of Long)("Numero") And
                                                            c.Cuota = dr.Field(Of Integer)("Cuota")) Then
               ShowMessage(String.Format("La Cuota {1} del comprobante {0} fue ingresada anteriormente",
                                         String.Format(Entidades.Venta.FormatoPKStandard,
                                                       dr.Field(Of String)("IdTipoComprobante"),
                                                       dr.Field(Of String)("Letra"),
                                                       dr.Field(Of Integer)("CentroEmisor"),
                                                       dr.Field(Of Long)("NumeroComprobante")),
                                         dr.Field(Of Integer)("Cuota")))
               Exit Sub
            End If
         Next
         For Each dr1 In ugDetalle.DataSource(Of DataTable).Where(Function(drw) drw.Field(Of Boolean)("SELEC"))
            Dim ctaCtePago = New Entidades.CuentaCorrientePago()
            With ctaCtePago
               Dim otipocomp = New Reglas.TiposComprobantes()
               .IdSucursal = dr1.Field(Of Integer)("Sucursal")
               .TipoComprobante = otipocomp.GetUno(dr1.Field(Of String)("IdTipoComprobante"))
               .Letra = dr1.Field(Of String)("Letra")
               .CentroEmisor = dr1.Field(Of Integer)("Emisor")
               .NumeroComprobante = dr1.Field(Of Long)("Numero")
               .Cuota = dr1.Field(Of Integer)("Cuota")
               .FechaEmision = dr1.Field(Of Date)("Fecha")
               .FechaVencimiento = dr1.Field(Of Date)("FechaVencimiento")
               .ImporteCuota = dr1.Field(Of Decimal)("Importe")
               .NombreMoneda = dr1.Field(Of String)("NombreMoneda")
               .ImporteInteres = dr1.Field(Of Decimal)("Interes")
               .SaldoCuota = dr1.Field(Of Decimal)("Saldo")
               .Paga = dr1.Field(Of Decimal)("Saldo")
               .FormaPago = New Reglas.VentasFormasPago().GetUna(dr1.Field(Of Integer)("IdFormasPago"))
               .CuentaCorriente.IdCategoria = dr1.Field(Of Integer)("IdCategoria")
               '.DescuentoRecargoPorc = Decimal.Parse(dr1("DescuentoRecargoPorc").ToString())
               '.DescuentoRecargo = Decimal.Parse(dr1("DescuentoRecargo").ToString())
               .CuentaCorriente.Cliente = New Entidades.Cliente() With {.IdCliente = dr1.Field(Of Long)("IdCliente"),
                                                                        .CodigoCliente = dr1.Field(Of Long)("CodigoCliente"),
                                                                        .NombreCliente = dr1.Field(Of String)("NombreCliente")}
               .NumeroOrdenCompra = dr1.Field(Of Long?)("NumeroOrdenCompra")
               .Usuario = actual.Nombre

               .Direccion = dr1.Field(Of String)("Direccion")
               .Observacion = dr1.Field(Of String)("Observacion")
               .IdEmbarcacion = dr1.Field(Of Long?)("IdEmbarcacion").IfNull()
               .IdCama = dr1.Field(Of Long?)("IdCama").IfNull()

               .CodigoEmbarcacion = dr1.Field(Of Long?)("CodigoEmbarcacion").IfNull()
               .NombreEmbarcacion = dr1.Field(Of String)("NombreEmbarcacion").IfNull()
               .CodigoCama = dr1.Field(Of String)("CodigoCama").ValorNumericoPorDefecto(0L)

               .IdEmbarcacionCama = dr1.Field(Of Long?)("IdEmbarcacionCama").IfNull()
               .CodigoEmbarcacionCama = dr1.Field(Of Long?)("CodigoEmbarcacionCama").IfNull()
               .NombreEmbarcacionCama = dr1.Field(Of String)("NombreEmbarcacionCama").IfNull()
               '-- REQ-42455.- ----------------------------------------------------------------------------------------------
               If dr1.Field(Of Date?)("FechaPromedioCobro").HasValue Then
                  .FechaPromedioCobro = dr1.Field(Of Date?)("FechaPromedioCobro").IfNull()
               Else
                  .FechaPromedioCobro = Nothing
               End If
               If dr1.Field(Of Decimal?)("PromedioDiasCobro").HasValue Then
                  .PromedioDiasCobro = dr1.Field(Of Decimal?)("PromedioDiasCobro").IfNull()
               Else
                  .PromedioDiasCobro = Nothing
               End If
               If dr1.Field(Of Decimal?)("CantidadDiasCobro").HasValue Then
                  .CantidadDiasCobro = dr1.Field(Of Decimal?)("CantidadDiasCobro").IfNull()
               Else
                  .CantidadDiasCobro = Nothing
               End If
               '-------------------------------------------------------------------------------------------------------------

            End With
            ComprobantesSeleccionados.Add(ctaCtePago)
         Next
         Close(DialogResult.OK)
      End Sub)
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "SELEC"))
   End Sub

#Region "Eventos Grilla"
   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(Sub() ugDetalle.UpdateData())
   End Sub
   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(Sub() CalcularTotal())
   End Sub
   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            dr("SELEC") = True
            btnAceptar.PerformClick()
         End If
      End Sub)
   End Sub
#End Region

#Region "Eventos Lote"
   Private Sub txtLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLote.KeyDown
      TryCatched(Sub() If e.KeyCode = Keys.Enter Then btnLote.PerformClick())
   End Sub
   Private Sub btnLote_Click(sender As Object, e As EventArgs) Handles btnLote.Click
      TryCatched(Sub() CargaGrillaDetalle())
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      pnlLote.Visible = actual.Sistema = "SiCAP"
      _publicos = New Publicos()
      _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos)
      CargaGrillaDetalle()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim lote = If(txtLote.ValorNumericoPorDefecto(0L) > 0, txtLote.Text, String.Empty)

      Dim rComprobantes = New Reglas.CuentasCorrientes()
      Dim dt = rComprobantes.BuscarPendientes(actual.Sucursal.Id, _idCliente, _idCategoria, _tipoComprobanteFacturador.EsReciboClienteVinculado,
                                              _tipoComprobanteFacturador.ComprobantesAsociados, idTipoComprobante:="", letra:="", emisor:=0, numeroComprobante:=0, numeroComprobanteFinalizaCon:=lote,
                                              idTipoLiquidacion:=Nothing, incluirPreElectronicos:=False, idEmbarcacion:=_embarcacion, idCama:=_Cama, crmNovedad:=Nothing, seleccionMultiple:=True)


      Dim rows_a_remover = New List(Of DataRow)()
      For Each row1 As DataRow In dt.Rows
         For Each row2 As Eniac.Entidades.CuentaCorrientePago In _ComprobantesSeleccionados
            If row1("Sucursal").ToString() = row2.IdSucursal.ToString() AndAlso row1("IdTipoComprobante").ToString() = row2.IdTipoComprobante.ToString() AndAlso
               row1("Letra").ToString() = row2.Letra AndAlso row1("Emisor").ToString() = row2.CentroEmisor.ToString() AndAlso
               row1("Numero").ToString() = row2.NumeroComprobante.ToString() Then
               rows_a_remover.Add(row1)
            End If
         Next
      Next

      For Each row As DataRow In rows_a_remover
         dt.Rows.Remove(row)
         dt.AcceptChanges()
      Next

      ugDetalle.DataSource = dt

      Publicos.PreparaGrillaAutomatico(ugDetalle, Entidades.Buscador.Buscadores.ComprobantesVentaPendientes)
      ugDetalle.ActivationTodasLasColumnas(Activation.ActivateOnly)
      ugDetalle.DisplayLayout.Bands(0).Columns("SELEC").FormatearColumna("", 0, 50, HAlign.Center, cellActivation:=Activation.AllowEdit).Style = UltraWinGrid.ColumnStyle.CheckBox

      If Reglas.Publicos.CtaCte.PintaColumaCuotaCtaCteCliente Then
         ugDetalle.DisplayLayout.Bands(0).Columns("Cuota").CellAppearance.BackColor = Color.LightCyan
      End If

      ugDetalle.AgregarFiltroEnLinea({"Observacion", "NombreCliente", "Direccion", "NombreEmbarcacion", "NombreEmbarcacionCama"})
      ugDetalle.AgregarTotalesSuma({"Importe", "Saldo"})

      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

   End Sub
   Private Sub CalcularTotal()
      ugDetalle.UpdateData()
      Dim importeTotal = ugDetalle.DataSource(Of DataTable).Where(Function(dr) dr.Field(Of Boolean)("SELEC")).Sum(Function(dr) dr.Field(Of Decimal)("Saldo"))
      txtTotal.SetValor(importeTotal)
   End Sub

#End Region

End Class