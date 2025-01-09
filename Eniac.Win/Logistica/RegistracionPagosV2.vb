Public Class RegistracionPagosV2

#Region "Campos / Constantes"
   Private Const tbcComprobantesTabName As String = "tbcComprobantes"
   Private Const tbcDetallePagoTabName As String = "tbcDetallePago"
   Private Const tbcResumenTabName As String = "tbcResumen"

   '-- REQ-30946.- --
   Private _dsProductosSinDescargo As DataSet
   Private _dtProductosSinDescargo As DataTable
   Private _dtProductosSinDescargoComprobante As DataTable
   Private _titArticulosSinDescargo0 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titArticulosSinDescargo1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   '-----------------

   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      TryCatched(
         Sub()
            bdsComprobantes.Filter = String.Format("Not {0}", DtsRegistracionPagosV2.Comprobantes.SeleccionadoColumn.ColumnName)
            bdsComprobantesSeleccionados.Filter = String.Format("{0}", DtsRegistracionPagosV2.Comprobantes.SeleccionadoColumn.ColumnName)
            EfectivoBindingSource.Filter = String.Format("{0} <> 0", DtsRegistracionPagosV2.Comprobantes.TotalEfectivoColumn.ColumnName)
            CtaCteBindingSource.Filter = String.Format("{0} <> 0", DtsRegistracionPagosV2.Comprobantes.TotalCuentaCorrienteColumn.ColumnName)
            NCBindingSource.Filter = String.Format("{0} <> 0", DtsRegistracionPagosV2.Comprobantes.TotalNCColumn.ColumnName)
            ChequesBindingSource.Filter = String.Format("{0} <> 0", DtsRegistracionPagosV2.Comprobantes.TotalChequesColumn.ColumnName)
            ReenviosBindingSource.Filter = String.Format("{0} <> 0", DtsRegistracionPagosV2.Comprobantes.TotalReenvioColumn.ColumnName)
         End Sub)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            InicializarControles()
            InicializaGrillas()
            RefrescarDatosGrilla()

            '-- REQ-30946.- --
            CrearDtProductosSinDescargo()
            _titArticulosSinDescargo0 = GetColumnasVisiblesGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(0))
            _titArticulosSinDescargo1 = GetColumnasVisiblesGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(1))
            '-----------------
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         If utcPreventa.SelectedTab.Key = tbcResumenTabName Then
            btnGrabar.PerformClick()
         Else
            utcPreventa.Tabs(tbcResumenTabName).Selected = True
         End If
      ElseIf keyData = Keys.F9 Then
         utcPreventa.Tabs(tbcComprobantesTabName).Selected = True
      ElseIf keyData = Keys.F10 Then
         utcPreventa.Tabs(tbcDetallePagoTabName).Selected = True
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar Principal"
   Private Sub tsbRefrescar_Click(sender As System.Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         '-- REQ-30946.- --
         If _dsProductosSinDescargo IsNot Nothing Then
            _dsProductosSinDescargo.Clear()
         End If
         If _dtProductosSinDescargo IsNot Nothing Then _dtProductosSinDescargo.Clear()
         If _dtProductosSinDescargoComprobante IsNot Nothing Then _dtProductosSinDescargo.Clear()

         RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   ''   Private Sub tsbGrabar_Click(sender As System.Object, e As EventArgs) Handles tsbGrabar.Click

   ''      Try
   ''         If MessageBox.Show(String.Format("Los pagos se imputarán a la caja: {0} - {1}. ¿Desea continuar?",
   ''                                          Me.cmbCajas.SelectedValue.ToString, Me.cmbCajas.Text), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
   ''            Me.Cursor = Cursors.WaitCursor
   ''            Me.GrabarComprobante()
   ''            Me.tsbRefrescar.PerformClick()
   ''         End If
   ''      Catch ex As Exception
   ''         ShowError(ex, recursivo:=True)
   ''      Finally
   ''         Me.Cursor = Cursors.Default
   ''      End Try
   ''   End Sub
   Private Sub tsbPagarTodo_Click(sender As System.Object, e As EventArgs) Handles tsbPagarTodo.Click
      TryCatched(Sub() PagarTodo())
   End Sub
   Private Sub tsbGrabarBorrador_Click(sender As Object, e As EventArgs) Handles tsbGrabarBorrador.Click
      Me.TryCatched(tsbGrabarBorrador, Sub()
                                          GrabarBorrador()
                                          ShowMessage("Borrador guardado exitosamente!")
                                       End Sub)
   End Sub
   Private Sub tsbImprimirGrilla_Click(sender As Object, e As EventArgs) Handles tsbImprimirGrilla.Click
      TryCatched(
         Sub()
            If DtsRegistracionPagosV2.Tables(0).Rows.Count = 0 Then Exit Sub

            Dim grid = GridFromSelectedTab()
            If grid Is Nothing Then Exit Sub
            UltraGridPrintDocument1.Grid = grid

            Dim filtro = String.Empty
            Dim titulo = String.Format("{1}{0}{0}{2} - {3}{0}{0}{0}{4}", Environment.NewLine(), Reglas.Publicos.NombreEmpresa, Text, utcPreventa.SelectedTab.Text, filtro)

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
            UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Text

            UltraPrintPreviewDialog1.Name = Text
            UltraGridPrintDocument1.Header.TextCenter = titulo
            UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
            UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
            UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
            UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewD.MdiParent = MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Focus()
         End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If DtsRegistracionPagosV2.Tables.Count = 0 OrElse DtsRegistracionPagosV2.Tables(0).Rows.Count = 0 Then Exit Sub

         Dim ugDetalle As UltraGrid = GridFromSelectedTab()
         If ugDetalle Is Nothing Then Exit Sub

         Dim nameTab As String = utcPreventa.SelectedTab.Text
         Dim filtro = "" 'Me.CargarFiltrosImpresion()
         ugDetalle.Exportar(String.Format("{0}_{1}.xls", Me.Name, nameTab), String.Format("{0} - {1}", Me.Text, nameTab), UltraGridExcelExporter1, filtro)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try

         If DtsRegistracionPagosV2.Tables.Count = 0 OrElse DtsRegistracionPagosV2.Tables(0).Rows.Count = 0 Then Exit Sub

         Dim ugDetalle As UltraGrid = GridFromSelectedTab()
         If ugDetalle Is Nothing Then Exit Sub

         Dim nameTab As String = utcPreventa.SelectedTab.Text
         Dim filtro = "" 'Me.CargarFiltrosImpresion()

         ugDetalle.Exportar(String.Format("{0}_{1}.pdf", Me.Name, nameTab), String.Format("{0} - {1}", Me.Text, nameTab), UltraGridDocumentExporter1, filtro)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbCerrar_Click(sender As System.Object, e As EventArgs) Handles tsbCerrar.Click
      If ShowPregunta("Perderá los cambios al salir. ¿Desea Continuar?") = Windows.Forms.DialogResult.Yes Then
         Me.Close()
      End If
      ''Me.tsbGrabar.Enabled = True
   End Sub
#End Region

#Region "Eventos Toolbar Secundario"
   Private Sub tsbEfectivo_Click(sender As System.Object, e As EventArgs) Handles tsbEfectivo.Click
      Try
         SeteaFormaPago(Reglas.RegistracionPagosMedioPago.Efectivo)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbVarias_Click(sender As System.Object, e As EventArgs) Handles tsbVarias.Click
      Try
         SeteaFormaPago(Reglas.RegistracionPagosMedioPago.OtrasFormasPago)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbCC_Click(sender As System.Object, e As EventArgs) Handles tsbCC.Click
      Try
         SeteaFormaPago(Reglas.RegistracionPagosMedioPago.CuentaCorriente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbNC_Click(sender As System.Object, e As EventArgs) Handles tsbNC.Click
      Try
         SeteaFormaPago(Reglas.RegistracionPagosMedioPago.NotaCredito)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbReenvio_Click(sender As System.Object, e As EventArgs) Handles tsbReenvio.Click
      Try
         SeteaFormaPago(Reglas.RegistracionPagosMedioPago.ReEnviar)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbNoRendir_Click(sender As Object, e As EventArgs) Handles tsbNoRendir.Click
      Try
         SeteaFormaPago(Reglas.RegistracionPagosMedioPago.SinSeleccionar)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            UltraPrintPreviewDialog1.Document = UltraGridPrintDocument1
            UltraGridPrintDocument1.Header.TextCenter = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + "Listado de Clientes"
            UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
            UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
            UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewDialog1.ShowDialog()
         End Sub)
   End Sub

#End Region

#Region "Eventos Buscadores Reparto"
   Private Sub bscReparto2_BuscadorClick() Handles bscReparto2.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaRepartos(Me.bscReparto2)

         Dim NumeroReparto As Integer = 0
         If IsNumeric(bscReparto2.Text) Then NumeroReparto = Integer.Parse(bscReparto2.Text)

         Dim oVenta As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
         Dim dt As DataTable = oVenta.GetRepartos({actual.Sucursal},
                                                  fechaEnvioDesde:=Nothing,
                                                  fechaEnvioHasta:=Nothing,
                                                  IdVendedor:=0,
                                                  idCliente:=0,
                                                  idTipoComprobante:=String.Empty,
                                                  numeroReparto:=NumeroReparto,
                                                  idFormasPago:=0,
                                                  idUsuario:=String.Empty,
                                                  idEstadoComprobante:=String.Empty,
                                                  porcUtilidadDesde:=Nothing,
                                                  porcUtilidadHasta:=Nothing,
                                                  esComercial:=Entidades.Publicos.SiNoTodos.TODOS,
                                                  idCategoria:=0,
                                                  idTransportista:=0)
         Me.bscReparto2.Datos = dt
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscReparto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscReparto2.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarReparto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region

   Private Sub btnBuscar_Click(sender As System.Object, e As EventArgs) Handles btnBuscar.Click
      Try

         If String.IsNullOrWhiteSpace(bscReparto2.Text) OrElse Long.Parse(Me.bscReparto2.Text) = 0 Then
            ShowMessage("El número de Reparto es requerido.")
            Me.bscReparto2.Focus()
            Exit Sub
         End If

         If New Reglas.Repartos().Get1(actual.Sucursal.Id, Integer.Parse(Me.bscReparto2.Text)).Rows.Count = 0 Then
            ShowMessage("El número de Reparto ingresado no fue registrado con Organizar Entrega.")
            Me.bscReparto2.Focus()
            Exit Sub
         End If
         If Me.chbRuta.Checked And Me.cmbRuta.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Ruta aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbRuta.Focus()
            Exit Sub
         End If
         If Me.chbDias.Checked And Me.cmbDias.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Dia aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbDias.Focus()
            Exit Sub
         End If

         Me.CargaGrillaDetalle()

         utcPreventa.SelectedTab = utcPreventa.Tabs(tbcComprobantesTabName)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
      TryCatched(Sub() GrabarRegistracionPagos())
   End Sub
   Private Sub btnImprimirResumen_Click(sender As Object, e As EventArgs) Handles btnImprimirResumen.Click
      TryCatched(Sub() ImprimirResumen(tentativo:=True))
   End Sub


   Private Sub utcPreventa_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcPreventa.SelectedTabChanged
      Try
         HabilitaToolbarSecundarioSegunSolapaRegistro()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugComprobante_AfterRowActivate(sender As Object, e As EventArgs) Handles ugComprobante.AfterRowActivate, ugvDetallePedidos.AfterRowActivate
      Try
         HabilitaToolbarSecundarioSegunSolapaRegistro()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()
      Me.utcPreventa.SelectedTab = utcPreventa.Tabs(tbcComprobantesTabName)
      Me.cmbModoConsultarComprobantes.SelectedValue = Reglas.Publicos.RegistracionPagosModoConsultarComprobantes
      Me.bscReparto2.Text = "0"

      Me.chbLocalidad.Checked = False
      Me.cmbLocalidad.SelectedIndex = -1

      Me.chbRespDistribucion.Checked = False
      Me.cmbRespDistribucion.SelectedIndex = -1

      Me.chbFechaDesde.Checked = False
      Me.dtpFechaDesde.Value = DateTime.Today
      Me.chbFechaHasta.Checked = True
      Me.dtpFechaHasta.Value = DateTime.Today
      Me.dtpFechaRend.Value = DateTime.Now

      Me.chbRuta.Checked = False
      Me.cmbDias.SelectedIndex = -1

      Me.chbVendedor.Checked = False
      Me.cmbVendedor.SelectedIndex = -1

      DtsRegistracionPagosV2.Clear()

      Dim ceroText = "0.00"
      txtTotalCC.Text = ceroText
      txtTotalCheque.Text = ceroText
      txtTotalComprobantes.Text = ceroText
      txtTotalEfectivo.Text = ceroText
      txtTotalTransferencia.Text = ceroText
      txtTotalNC.Text = ceroText
      txtTotalReenvios.Text = ceroText
      txtSubTotal.Text = ceroText
      txtSaldoGeneral.Text = ceroText

      bscReparto2.Focus()

      ''Me.btnBuscar.Enabled = True
      ''Me.tsbGrabar.Enabled = True
      ''tsbPagarTodo.Enabled = True
      ''If _dsProductosSinDescargo IsNot Nothing Then
      ''   _dsProductosSinDescargo.Clear()
      ''End If
      ''If _dtProductosSinDescargo IsNot Nothing Then _dtProductosSinDescargo.Clear()
      ''If _dtProductosSinDescargoComprobante IsNot Nothing Then _dtProductosSinDescargo.Clear()
   End Sub
   Private Sub InicializarControles()
      Me._publicos.CargaComboDesdeEnum(cmbModoConsultarComprobantes, GetType(Entidades.RegistracionPagos.ModoConsultarComprobantes))
      Me._publicos.CargaComboLocalidades(Me.cmbLocalidad)
      Me._publicos.CargaComboTransportistas(Me.cmbRespDistribucion)
      Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
      Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, MiraUsuario:=True, MiraPC:=Not Publicos.FacturacionIgnorarPCdeCaja, CajasModificables:=True)
      Me._publicos.CargaComboRutas(cmbRuta, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)
      Me._publicos.CargaComboDesdeEnum(cmbDias, GetType(Entidades.Publicos.Dias))

   End Sub
   Private Sub InicializaGrillas()
      ugComprobante.AgregarTotalesSuma({"ImporteTotal", "SaldoComprobante", "TotalRendido"})
      ugvDetallePedidos.AgregarTotalesSuma({"ImporteTotal", "SaldoComprobante", "TotalRendido"})


      ugComprobante.AgregarFiltroEnLinea({"NombreCliente", "Direccion"})
      ugvDetallePedidos.AgregarFiltroEnLinea({"NombreCliente", "Direccion"})

   End Sub

   Private Sub MostrarCantidadRegistrosSegunSolapa()
      Dim count = Me.DtsRegistracionPagosV2.Comprobantes.Count
      Dim plural = count <> 1
      Me.tssRegistros.Text = String.Format("{0} Registro{1}", count, If(plural, "s", ""))
   End Sub
   Private Sub HabilitaToolbarSecundarioSegunSolapaRegistro()
      Dim dr = GetFilaSeleccionada()
      Dim tabKey = utcPreventa.SelectedTab.Key

      If dr Is Nothing Then
         tsbEfectivo.Enabled = False
         tsbVarias.Enabled = False
         tsbCC.Enabled = False
         tsbNC.Enabled = False
         tsbReenvio.Enabled = False
         tsbNoRendir.Enabled = False
         tslNCSeleccionada.Visible = False
         tsbEfectivo.Visible = True
         tsbVarias.Visible = True
         tsbCC.Visible = True
         tsbNC.Visible = True
         tsbReenvio.Visible = True
         tsbNoRendir.Visible = True

      Else
         tsbEfectivo.Enabled = tabKey = tbcComprobantesTabName Or (tabKey = tbcDetallePagoTabName And dr.ImporteTotal > 0)
         tsbVarias.Enabled = tabKey = tbcComprobantesTabName Or (tabKey = tbcDetallePagoTabName And dr.ImporteTotal > 0)
         tsbCC.Enabled = tabKey = tbcComprobantesTabName Or (tabKey = tbcDetallePagoTabName And dr.ImporteTotal > 0)
         tsbNC.Enabled = tabKey = tbcComprobantesTabName Or (tabKey = tbcDetallePagoTabName And dr.ImporteTotal > 0)
         tsbReenvio.Enabled = tabKey = tbcComprobantesTabName Or (tabKey = tbcDetallePagoTabName And dr.ImporteTotal > 0)
         tsbNoRendir.Enabled = tabKey = tbcDetallePagoTabName

         tslNCSeleccionada.Visible = tabKey = tbcComprobantesTabName And dr.ImporteTotal < 0
         tsbEfectivo.Visible = tabKey = tbcDetallePagoTabName Or dr.ImporteTotal > 0
         tsbVarias.Visible = tabKey = tbcDetallePagoTabName Or dr.ImporteTotal > 0
         tsbCC.Visible = tabKey = tbcDetallePagoTabName Or dr.ImporteTotal > 0
         tsbNC.Visible = tabKey = tbcDetallePagoTabName Or dr.ImporteTotal > 0
         tsbReenvio.Visible = tabKey = tbcDetallePagoTabName Or dr.ImporteTotal > 0
         tsbNoRendir.Visible = tabKey = tbcDetallePagoTabName Or dr.ImporteTotal > 0

      End If

      tsbImprimir.Enabled = True

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim regla = New Reglas.RegistracionPagos()

      regla.CargarRegistracionPagos(Me.DtsRegistracionPagosV2,
                                    actual.Sucursal.IdSucursal, bscReparto2.Text.ToInt32().IfNull(), cmbModoConsultarComprobantes.ValorSeleccionado(Of Entidades.RegistracionPagos.ModoConsultarComprobantes),
                                    dtpFechaDesde.Valor(chbFechaDesde), dtpFechaHasta.Valor(chbFechaHasta),
                                    If(chbRespDistribucion.Checked, cmbRespDistribucion.ValorSeleccionado(Of Integer), 0),
                                    If(chbLocalidad.Checked, cmbLocalidad.ValorSeleccionado(Of Integer), 0),
                                    If(chbVendedor.Checked, cmbVendedor.ValorSeleccionado(Of Integer), 0),
                                    If(chbRuta.Checked, cmbRuta.ValorSeleccionado(Of Integer), 0),
                                    Nothing)

      Dim borrador As Entidades.RepartoCobranza = regla.GetBorrador(actual.Sucursal.IdSucursal, bscReparto2.Text.ToInt32().IfNull(), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If borrador IsNot Nothing Then
         For Each comp In borrador.Comprobantes
            Dim drComp = DtsRegistracionPagosV2.Comprobantes.Where(Function(dr)
                                                                      Return dr.IdSucursal = comp.IdSucursalComp And
                                                                         dr.IdTipoComprobante = comp.IdTipoComprobanteComp And
                                                                         dr.Letra = comp.LetraComp And
                                                                         dr.CentroEmisor = comp.CentroEmisorComp And
                                                                         dr.NumeroComprobante = comp.NumeroComprobanteComp
                                                                   End Function).FirstOrDefault()
            Dim medio = comp.MedioPagoSeleccionado.StringToEnum(Reglas.RegistracionPagosMedioPago.Efectivo)
            If drComp IsNot Nothing Then
               Dim prod = comp.Productos.FirstOrDefault()
               Dim idMotivo = If(prod IsNot Nothing, prod.IdEstadoVenta, 0)
               Dim motivo = If(prod IsNot Nothing, prod.NombreEstadoNovedad, String.Empty)
               regla.SeteaFormaPago(medio, drComp, idMotivo, motivo, comp)
            End If
         Next
      End If

      MostrarCantidadRegistrosSegunSolapa()

      _dsProductosSinDescargo.Clear()
      _dtProductosSinDescargoComprobante.Clear()

      'bscReparto2.Tag = False

      CalcularTotales()
   End Sub
   Private Sub CargarReparto(dr As DataGridViewRow)
      Me.bscReparto2.Text = dr.Cells("NumeroReparto").Value.ToString()

      Dim rBorrador = New Reglas.RepartosCobranzas()
      Dim borrador = rBorrador.GetBorrador(actual.Sucursal.Id, Me.bscReparto2.Text.ToInt32().IfNull(), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If borrador IsNot Nothing Then
         If ShowPregunta("Existe un borrador de rendición creado el {1:dd/MM/yyyy} por {2}.{0}{0}¿Desea cargar el borrador?",
                         MessageBoxDefaultButton.Button1, Environment.NewLine, borrador.FechaAlta, borrador.IdUsuarioAlta) = Windows.Forms.DialogResult.No Then
            rBorrador.Borrar(borrador)
         End If
      End If
      Me.btnBuscar.Focus()
      Me.btnBuscar.PerformClick()
   End Sub


   Private Sub GrabarRegistracionPagos()
      If ShowPregunta(String.Format("Los pagos se imputarán a la caja: {0} - {1}. ¿Desea continuar?",
                                    Me.cmbCajas.SelectedValue.ToString(), Me.cmbCajas.Text)) = Windows.Forms.DialogResult.Yes Then
         Dim regla = New Reglas.RegistracionPagos()
         Dim eRepartoTotalesResumen As Entidades.Reparto = New Entidades.Reparto With {.TotalResumenComprobante = CDec(Me.txtTotalComprobantes.Text),
                                                                                       .TotalResumenSaldoGeneral = CDec(Me.txtSaldoGeneral.Text),
                                                                                       .TotalResumenEfectivo = CDec(Me.txtTotalEfectivo.Text),
                                                                                       .TotalResumenTransferencia = CDec(txtTotalTransferencia.Text),
                                                                                       .TotalResumenCheques = CDec(Me.txtTotalCheque.Text),
                                                                                       .TotalResumenCtaCte = CDec(Me.txtTotalCC.Text),
                                                                                       .TotalResumenNCred = CDec(Me.txtTotalNC.Text),
                                                                                       .TotalResumenReenvio = CDec(Me.txtTotalReenvios.Text)}

         regla.GrabarRegistracionPagos(DtsRegistracionPagosV2, dtpFechaRend.Value, cmbCajas.ValorSeleccionado(Of Integer?).IfNull(), bscReparto2.Text.ToInt32(), IdFuncion, eRepartoTotalesResumen)


         Dim SolicitarCaePantalla As Boolean = False
         Dim Comprobantes As DataTable = New Reglas.Ventas().GetConsolidadoComprobantePorReparto(actual.Sucursal.IdSucursal, Integer.Parse(bscReparto2.Text.ToString()), 0)
         Dim TipoComp As Entidades.TipoComprobante
         For Each dr As DataRow In Comprobantes.Rows
            TipoComp = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())
            If TipoComp.EsPreElectronico Then
               SolicitarCaePantalla = True
            End If
         Next

         Using frmConfirmacion As RegistracionPagosConfirmacion = New RegistracionPagosConfirmacion(SolicitarCae:=SolicitarCaePantalla)
            frmConfirmacion.chbSolicitarCae.Checked = SolicitarCaePantalla

            If frmConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

               If frmConfirmacion.SolicitarCae Then
                  Using frmSolicitarCae As SolicitarCAE = New SolicitarCAE(CInt(bscReparto2.Text.ToString()), CInt(bscReparto2.Text.ToString()))
                     frmSolicitarCae.ConsultarAutomaticamente = True
                     frmSolicitarCae.ShowDialog()
                  End Using
               End If

               '# Resumen
               If frmConfirmacion.ImprimeResumen Then
                  ImprimirResumen(tentativo:=False)
               End If

               '# Resumen Detallado
               If frmConfirmacion.ImprimeResumenDetallado Then
                  ImprimirResumenDetallado(DtsRegistracionPagosV2.Recibos)
               End If

            End If
         End Using

         Me.tsbRefrescar.PerformClick()
      End If
   End Sub

   Private Function GridFromSelectedTab() As UltraGrid
      If utcPreventa.Tabs("tbcComprobantes").Selected Then
         Return ugComprobante
      ElseIf utcPreventa.Tabs("tbcDetallePago").Selected Then
         Return ugvDetallePedidos
      ElseIf utcPreventa.Tabs("tbcSaldoCliente").Selected Then
         Return ugEfectivo
      ElseIf utcPreventa.Tabs("tbcCuentaCorriente").Selected Then
         Return ugCtaCte
      ElseIf utcPreventa.Tabs("tbcCheque").Selected Then
         Return ugCheque
      ElseIf utcPreventa.Tabs("tbcArticulosNC").Selected Then
         Return ugNc
      ElseIf utcPreventa.Tabs("tbcReenvios").Selected Then
         Return ugReenvios
      ElseIf utcPreventa.Tabs("tbcProductosSinDescargar").Selected Then
         Return ugvProductosSinDescargar
      End If
      Return Nothing
   End Function
   Private Function GetFilaSeleccionada() As Entidades.dtsRegistracionPagosV2.ComprobantesRow
      Dim drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow = Nothing

      Dim ug = GridFromSelectedTab()
      If ug IsNot Nothing Then
         drPedido = ug.FilaSeleccionada(Of Entidades.dtsRegistracionPagosV2.ComprobantesRow)()
      End If

      Return drPedido
   End Function

   Private Sub SeteaFormaPago(medioPago As Reglas.RegistracionPagosMedioPago)
      SeteaFormaPago(medioPago, GetFilaSeleccionada())
   End Sub

   Private Sub PagarTodo()
      If ShowPregunta("¿Desea marcar todos los comprobantes como rendidos en EFECTIVO?") = Windows.Forms.DialogResult.Yes Then
         Dim regla = New Reglas.RegistracionPagos()
         regla.PagarTodo(DtsRegistracionPagosV2)

         If ugvDetallePedidos.ActiveCell IsNot Nothing Then ugvDetallePedidos.ActiveCell.CancelUpdate()

         CalcularTotales()

         GrabarBorrador()
      End If
   End Sub

   Private Sub SeteaFormaPago(medioPago As Reglas.RegistracionPagosMedioPago, drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow)
      'Dim drPedido = GetFilaSeleccionada()

      If drPedido Is Nothing Then
         ShowMessage("¡Debe seleccionar un comprobante!")
         Exit Sub
      End If

      If Not medioPago.Equals(drPedido.MedioPagoSeleccionado) Then
         If medioPago = Reglas.RegistracionPagosMedioPago.SinSeleccionar AndAlso drPedido.MedioPagoSeleccionado.Equals(Reglas.RegistracionPagosMedioPago.Aplicado) Then

            Dim drNC = DtsRegistracionPagosV2.NCAplicadas.Where(Function(x) x.IdSucursalNC = drPedido.IdSucursal And
                                                                         x.IdTipoComprobanteNC = drPedido.IdTipoComprobante And
                                                                         x.LetraNC = drPedido.Letra And
                                                                         x.CentroEmisorNC = drPedido.CentroEmisor And
                                                                         x.NumeroComprobanteNC = drPedido.NumeroComprobante).FirstOrDefault()
            If drNC IsNot Nothing Then
               Dim stb = New StringBuilder()

               stb.AppendFormatLine("La {0} {1} {2:0000}-{3:00000000} fue aplicada a la {4} {5} {6:0000}-{7:00000000}. Se cancelará la Rendición de esta última.",
                                    drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroComprobante,
                                    drNC.IdTipoComprobante, drNC.Letra, drNC.CentroEmisor, drNC.NumeroComprobante)
               stb.AppendLine()
               stb.AppendFormatLine("¿Desea continuar?")
               If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.No Then
                  Exit Sub
               End If

               drPedido = drNC.ComprobantesRowParent

               QuitarFormaPago(drPedido)
            Else
               ShowMessage(String.Format("No se encontró el comprobante aplicado a la {0}", drPedido.IdTipoComprobante))
               Exit Sub
            End If

         Else
            If Not drPedido.IsMedioPagoSeleccionadoNull() AndAlso Not drPedido.MedioPagoSeleccionado.Equals(Reglas.RegistracionPagosMedioPago.SinSeleccionar) Then
               If ShowPregunta(String.Format("La {0} {1} {2:0000}-{3:00000000} tiene asiganada el medio de pago {4}, ¿desea cambiarla?",
                                                drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroComprobante,
                                                drPedido.NombreMedioPagoSeleccionado.ToUpper())) = Windows.Forms.DialogResult.No Then
                  Exit Sub
               Else ' cambia forma de pago, elimino de todas las grillas las formas de pago
                  QuitarFormaPago(drPedido)
               End If
            End If
         End If
      End If

      Dim regla = New Reglas.RegistracionPagos()


      If medioPago = Reglas.RegistracionPagosMedioPago.OtrasFormasPago Then
         Using frmOtraForma = New RegistracionPagosV2OtrasFormasPago(drPedido)
            If frmOtraForma.ShowDialog() = Windows.Forms.DialogResult.OK Then

               For Each drNC In drPedido.GetNCAplicadasRows()
                  For Each drComp In DtsRegistracionPagosV2.Comprobantes.Where(Function(dr) dr.IdSucursal = drNC.IdSucursalNC And
                                                                                  dr.IdTipoComprobante = drNC.IdTipoComprobanteNC And
                                                                                  dr.Letra = drNC.LetraNC And
                                                                                  dr.CentroEmisor = drNC.CentroEmisorNC And
                                                                                  dr.NumeroComprobante = drNC.NumeroComprobanteNC)
                     drComp.Seleccionado = True
                     drComp.MedioPagoSeleccionado = Reglas.RegistracionPagosMedioPago.Aplicado
                     drComp.NombreMedioPagoSeleccionado = Publicos.GetEnumString(Reglas.RegistracionPagosMedioPago.Aplicado)
                  Next
               Next
            Else
               Exit Sub
            End If
         End Using
         drPedido.MedioPagoSeleccionado = medioPago
         drPedido.NombreMedioPagoSeleccionado = Publicos.GetEnumString(medioPago)
         drPedido.Seleccionado = medioPago <> Reglas.RegistracionPagosMedioPago.SinSeleccionar

      ElseIf medioPago = Reglas.RegistracionPagosMedioPago.NotaCredito Then
         Using frm As frmMotivoNC = New frmMotivoNC(drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroComprobante)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               regla.SeteaFormaPago(medioPago, drPedido, frm.IdMotivo, frm.Motivo, borradorComp:=Nothing)
            Else
               Exit Sub
            End If
         End Using

      Else
         regla.SeteaFormaPago(medioPago, drPedido, 0, String.Empty, borradorComp:=Nothing)

      End If

      '-- REQ-30946.- --
      AgregarProductoSinDescargo(drPedido)
      '-----------------

      'If medioPago = Reglas.RegistracionPagosMedioPago.Efectivo Then
      '   drPedido.TotalEfectivo = drPedido.SaldoComprobante

      'ElseIf medioPago = Reglas.RegistracionPagosMedioPago.CuentaCorriente Then
      '   drPedido.TotalCuentaCorriente = drPedido.SaldoComprobante

      'ElseIf medioPago = Reglas.RegistracionPagosMedioPago.NotaCredito Then
      '   Using frm As frmMotivoNC = New frmMotivoNC(drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroComprobante)
      '      If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
      '         drPedido.TotalNC = drPedido.SaldoComprobante
      '         drPedido.GetProductosRows().All(Function(dr)
      '                                            dr.IdMotivo = frm.IdMotivo
      '                                            dr.Motivo = frm.Motivo
      '                                            dr.Devuelve = dr.Cantidad
      '                                            dr.ImporteDevuelve = dr.ImporteTotal
      '                                            Return True
      '                                         End Function)
      '      Else
      '         Exit Sub
      '      End If
      '   End Using

      'ElseIf medioPago = Reglas.RegistracionPagosMedioPago.ReEnviar Then
      '   drPedido.TotalReenvio = drPedido.SaldoComprobante
      'AgregarProductoSinDescargo(drPedido)
      'ElseIf medioPago = Reglas.RegistracionPagosMedioPago.OtrasFormasPago Then

      '   Using frmOtraForma = New RegistracionPagosV2OtrasFormasPago(drPedido)
      '      If frmOtraForma.ShowDialog() = Windows.Forms.DialogResult.OK Then

      '         For Each drNC In drPedido.GetNCAplicadasRows()
      '            For Each drComp In DtsRegistracionPagosV2.Comprobantes.Where(Function(dr) dr.IdSucursal = drNC.IdSucursalNC And
      '                                                                            dr.IdTipoComprobante = drNC.IdTipoComprobanteNC And
      '                                                                            dr.Letra = drNC.LetraNC And
      '                                                                            dr.CentroEmisor = drNC.CentroEmisorNC And
      '                                                                            dr.NumeroComprobante = drNC.NumeroComprobanteNC)
      '               drComp.Seleccionado = True
      '               drComp.MedioPagoSeleccionado = Reglas.RegistracionPagosMedioPago.Aplicado
      '               drComp.NombreMedioPagoSeleccionado = Publicos.GetEnumString(Reglas.RegistracionPagosMedioPago.Aplicado)
      '            Next
      '         Next
      '      Else
      '         Exit Sub
      '      End If
      '   End Using
      'End If

      'drPedido.MedioPagoSeleccionado = medioPago
      'drPedido.NombreMedioPagoSeleccionado = Publicos.GetEnumString(medioPago)
      'drPedido.Seleccionado = medioPago <> Reglas.RegistracionPagosMedioPago.SinSeleccionar



      DtsRegistracionPagosV2.AcceptChanges()

      drPedido.TotalRendido = drPedido.TotalEfectivo + drPedido.TotalCheques

      CalcularTotales()

      GrabarBorrador()

   End Sub
   Private Sub QuitarFormaPago(drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow)
      If drPedido IsNot Nothing Then
         drPedido.TotalEfectivo = 0
         drPedido.TotalCuentaCorriente = 0
         drPedido.TotalNC = 0
         drPedido.TotalAplicado = 0

         drPedido.TotalCheques = 0
         drPedido.TotalReenvio = 0
         drPedido.TotalRendido = 0

         drPedido.Seleccionado = False
         drPedido.NombreMedioPagoSeleccionado = String.Empty
         drPedido.SetMedioPagoSeleccionadoNull()

         For Each drProducto In drPedido.GetProductosRows
            drProducto.Motivo = String.Empty
            drProducto.Devuelve = 0
            drProducto.ImporteDevuelve = 0
         Next

         drPedido.GetChequesRows().All(Function(x)
                                          x.Delete()
                                          Return True
                                       End Function)

         drPedido.GetNCAplicadasRows().All(Function(x)
                                              DtsRegistracionPagosV2.Comprobantes.Where(Function(dr) dr.IdSucursal = x.IdSucursalNC And
                                                                                           dr.IdTipoComprobante = x.IdTipoComprobanteNC And
                                                                                           dr.Letra = x.LetraNC And
                                                                                           dr.CentroEmisor = x.CentroEmisorNC And
                                                                                           dr.NumeroComprobante = x.NumeroComprobanteNC).All(Function(dr1)
                                                                                                                                                dr1.Seleccionado = False
                                                                                                                                                dr1.SetMedioPagoSeleccionadoNull()
                                                                                                                                                dr1.NombreMedioPagoSeleccionado = String.Empty
                                                                                                                                                Return True
                                                                                                                                             End Function)
                                              x.Delete()
                                              Return True
                                           End Function)

         DtsRegistracionPagosV2.AcceptChanges()
      End If
   End Sub


   Private Sub CalcularTotales()

      Dim totalComprobantes As Decimal = 0
      Dim totalEfectivo As Decimal = 0
      Dim totalTransferencia As Decimal = 0
      Dim totalCheque As Decimal = 0
      Dim totalCC As Decimal = 0
      Dim totalNC As Decimal = 0
      Dim totalNCAplicadas As Decimal = 0
      Dim totalReenvios As Decimal = 0


      For Each drPedido In DtsRegistracionPagosV2.Comprobantes '.Where(Function(x) x.Seleccionado)
         totalComprobantes += drPedido.ImporteTotal
         totalEfectivo += drPedido.TotalEfectivo
         totalTransferencia += drPedido.TotalTransferencia
         totalCheque += drPedido.TotalCheques
         totalCC += drPedido.TotalCuentaCorriente
         totalNC += drPedido.TotalNC
         totalNCAplicadas += drPedido.TotalAplicado
         totalReenvios += drPedido.TotalReenvio
      Next

      txtTotalComprobantes.Text = totalComprobantes.ToString("N2")

      txtTotalEfectivo.Text = totalEfectivo.ToString("N2")
      txtTotalTransferencia.Text = totalTransferencia.ToString("N2")
      txtTotalCheque.Text = totalCheque.ToString("N2")
      txtTotalCC.Text = totalCC.ToString("N2")
      txtTotalNC.Text = totalNC.ToString("N2")
      txtNCAplicadas.Text = totalNCAplicadas.ToString("N2")
      txtTotalReenvios.Text = totalReenvios.ToString("N2")

      Dim subTotales = totalEfectivo + totalCheque + totalCC + totalNC + totalNCAplicadas + totalReenvios + totalTransferencia

      txtSubTotal.Text = subTotales.ToString("N2")
      txtSaldoGeneral.Text = (totalComprobantes - subTotales).ToString("N2")

      If (totalComprobantes - subTotales) = 0 Then
         txtSaldoGeneral.ForeColor = Color.Green
      Else
         txtSaldoGeneral.ForeColor = Color.Red
      End If

      'ugNc.DisplayLayout.Bands(1).ColumnFilters.ClearAllFilters()
      'ugNc.DisplayLayout.Bands(1).ColumnFilters("Devuelve").FilterConditions.Add(FilterComparisionOperator.NotEquals, 0D)


   End Sub

   Private Sub ImprimirResumen(tentativo As Boolean)
      Dim filtro As StringBuilder = New StringBuilder()
      Dim idTransportista As Integer = 0
      If Me.cmbRespDistribucion.Enabled Then
         Dim transportista As Entidades.Transportista = cmbRespDistribucion.ItemSeleccionado(Of Entidades.Transportista)()
         idTransportista = transportista.idTransportista
         filtro.AppendFormat(" Resp. de Distribución: {0} - ", transportista.NombreTransportista)
      End If

      If Me.cmbLocalidad.Enabled Then
         Dim localidad As String = String.Empty
         localidad = DirectCast(Me.cmbLocalidad.SelectedItem, Eniac.Entidades.Localidad).NombreLocalidad
         filtro.AppendFormat("Localidad: {0} - ", cmbLocalidad.ItemSeleccionado(Of Entidades.Localidad)().NombreLocalidad)
      End If

      Dim nroReparto As Integer = bscReparto2.Text.ToInt32().IfNull()
      filtro.AppendFormat("Nro. Reparto: {0} - ", nroReparto)

      filtro.AppendFormat("Fecha Hasta: {0} - ", Me.dtpFechaHasta.Text)

      If tentativo Then
         filtro.Insert(0, "*** TENTATIVO ***  ")
         filtro.Append("  *** TENTATIVO ***")
      End If


      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtro.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EFECTIVO", txtTotalEfectivo.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TRANSFERENCIA", txtTotalTransferencia.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CTACTE", txtTotalCC.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CHEQUES", txtTotalCheque.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NC", txtTotalNC.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("REENVIOS", txtTotalReenvios.Text))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TOTAL", (CDec(txtTotalEfectivo.Text) +
                                                                          CDec(txtTotalTransferencia.Text) +
                                                                          CDec(txtTotalCC.Text) +
                                                                          CDec(txtTotalCheque.Text) +
                                                                          CDec(txtTotalNC.Text) +
                                                                          CDec(txtTotalReenvios.Text)).ToString("N2")))


      'Dim reglas As Reglas.OrganizarEntregas = New Reglas.OrganizarEntregas()
      Dim dt As New DataTable
      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Resumen.rdlc", "", dt, parm, True, 1) '# 1 = Cantidad Copias

      frmImprime.Text = Me.Text
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.ShowDialog()
   End Sub
   Private Sub ImprimirResumenDetallado(ds As Entidades.dtsRegistracionPagosV2.RecibosDataTable)
      Try

         ' # Parámetros del RDLC
         Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         '# Resolver Informe Personalizado
         Dim reporte As Entidades.InformePersonalizadoResuelto
         Dim strReporte As String = String.Empty
         Dim frmImprime As VisorReportes

         ' Resolver si el cliente tiene informe personalizado
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.RegistracionPagosResumenDetallado, "Eniac.Win.ResumenDetallado.rdlc")

         '# Ordeno los datos de Recibos por Nombre del Cliente
         Dim dv As DataView = ds.DefaultView
         dv.Sort = "NombreCliente ASC"
         'ds = DirectCast(dv.ToTable(), Entidades.dtsRegistracionPagosV2.RecibosDataTable)

         Dim dt As DataTable = dv.ToTable() 'ds.Copy() '# Si no se crea un dt aparte, no resuelve la impresión del dtsRegistracionPagosV2. El reporte espera la tabla Recibos pero del DS v1.
         frmImprime = New VisorReportes(reporte.NombreArchivo, "dtsRecibos", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.ShowDialog()

         Me.Cursor = Cursors.Default
      Catch ex As Exception

         ShowError(ex)

      End Try



   End Sub

   '-- REQ-30946.- --
   Private Sub AgregarProductoSinDescargo(drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow)

      For Each drProducto As Entidades.dtsRegistracionPagosV2.ProductosRow In drPedido.GetProductosRows()
         Dim existe As Boolean = False
         For Each dr As DataRow In Me._dtProductosSinDescargo.Rows
            If dr("IdProducto").ToString() = drProducto.IdProducto Then
               existe = True
            End If
         Next
         If existe = False Then
            If drProducto.Devuelve > 0 Then
               Dim drSinDescargo As DataRow = Me._dtProductosSinDescargo.NewRow()
               drSinDescargo("IdProducto") = drProducto.IdProducto
               drSinDescargo("NombreProducto") = drProducto.NombreProducto
               drSinDescargo("Cantidad") = drProducto.Devuelve
               drSinDescargo("Precio") = drProducto.Precio
               Me._dtProductosSinDescargo.Rows.Add(drSinDescargo)
               Dim drComprobante As DataRow = Me._dtProductosSinDescargoComprobante.NewRow()
               drComprobante("IdProducto") = drProducto.IdProducto
               drComprobante("IdSucursal") = drPedido.IdSucursal
               drComprobante("IdTipoComprobante") = drPedido.IdTipoComprobante
               drComprobante("Letra") = drPedido.Letra
               drComprobante("CentroEmisor") = drPedido.CentroEmisor
               drComprobante("NumeroPedido") = drPedido.NumeroComprobante
               If Not drPedido.IsNumeroRepartoNull Then
                  drComprobante("IdReparto") = drPedido.NumeroReparto
               End If
               drComprobante("NombreProducto") = drProducto.NombreProducto
               drComprobante("Cantidad") = drProducto.Devuelve
               drComprobante("Precio") = drProducto.Precio
               drComprobante("TipoOperacion") = drProducto.TipoOperacion
               drComprobante("CodigoCliente") = drPedido.CodigoCliente
               drComprobante("NombreCliente") = drPedido.NombreCliente
               Me._dtProductosSinDescargoComprobante.Rows.Add(drComprobante)
            End If
         Else
            For Each drProd As DataRow In Me._dtProductosSinDescargo.Rows
               If drProd("IdProducto").ToString() = drProducto.IdProducto Then
                  drProd("Cantidad") = Decimal.Parse(drProd("Cantidad").ToString()) + drProducto.Devuelve
                  Me._dtProductosSinDescargo.AcceptChanges()
                  For Each drComp As DataRow In Me._dtProductosSinDescargoComprobante.Rows
                     If drProducto.Devuelve > 0 Then
                        Dim drComprobante As DataRow = Me._dtProductosSinDescargoComprobante.NewRow()
                        If Not (Integer.Parse(drComp("IdSucursal").ToString()) = drProducto.IdSucursal And
                           drComp("IdTipoComprobante").ToString() = drProducto.IdTipoComprobante And
                           drComp("Letra").ToString() = drProducto.Letra And
                           Integer.Parse(drComp("CentroEmisor").ToString()) = drProducto.CentroEmisor And
                           Long.Parse(drComp("NumeroPedido").ToString()) = drProducto.NumeroComprobante) And
                           drComp("IdProducto").ToString() = drProducto.IdProducto Then
                           drComprobante("IdProducto") = drProducto.IdProducto
                           drComprobante("IdSucursal") = drPedido.IdSucursal
                           drComprobante("IdTipoComprobante") = drPedido.IdTipoComprobante
                           drComprobante("Letra") = drPedido.Letra
                           drComprobante("CentroEmisor") = drPedido.CentroEmisor
                           drComprobante("NumeroPedido") = drPedido.NumeroComprobante
                           drComprobante("IdReparto") = drPedido.NumeroReparto
                           drComprobante("NombreProducto") = drProducto.NombreProducto
                           drComprobante("Cantidad") = drProducto.Devuelve
                           drComprobante("Precio") = drProducto.Precio
                           drComprobante("TipoOperacion") = drProducto.TipoOperacion
                           drComprobante("CodigoCliente") = drPedido.CodigoCliente
                           drComprobante("NombreCliente") = drPedido.NombreCliente
                           Me._dtProductosSinDescargoComprobante.Rows.Add(drComprobante)
                           Me._dtProductosSinDescargoComprobante.AcceptChanges()
                           Exit For
                        End If
                     End If
                  Next
               End If
            Next
         End If
      Next

      Me.ugvProductosSinDescargar.DataSource = Me._dsProductosSinDescargo.Tables("ProductosSinDescargo")
      AjustarColumnasGrillaProductosSinDescargo()

   End Sub

   '-- REQ-30946.- --
   Private Sub AjustarColumnasGrillaProductosSinDescargo()

      AjustarColumnasGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(0), _titArticulosSinDescargo0)
      AjustarColumnasGrilla(ugvProductosSinDescargar.DisplayLayout.Bands(1), _titArticulosSinDescargo1)

      With ugvProductosSinDescargar.DisplayLayout.Bands(1)
         Dim col As Integer = 0
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdTipoComprobante"), "Tipo", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Letra"), "L.", col, 30)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CentroEmisor"), "Emisor", col, 50)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NumeroPedido"), "Pedido", col, 70, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdReparto"), "Reparto", col, 70, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Número", col, 150, HAlign.Left)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Cantidad"), "Cantidad", col, 70, HAlign.Right, False, "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Precio"), "Precio", col, 70, HAlign.Right, False, "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CodigoCliente"), "Código", col, 80, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreCliente"), "Cliente", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("TipoOperacion"), "Tipo de Operación", col, 120)
      End With
   End Sub

   '-- REQ-30946.- --
   Private Sub CrearDtProductosSinDescargo()

      _dtProductosSinDescargo = New DataTable()
      _dtProductosSinDescargo.Columns.Add("IdProducto", GetType(String))
      _dtProductosSinDescargo.Columns.Add("NombreProducto", GetType(String))
      _dtProductosSinDescargo.Columns.Add("Cantidad", GetType(Decimal))
      _dtProductosSinDescargo.Columns.Add("Precio", GetType(Decimal))
      _dtProductosSinDescargoComprobante = New DataTable()
      _dtProductosSinDescargoComprobante.Columns.Add("IdProducto", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("IdSucursal", GetType(Integer))
      _dtProductosSinDescargoComprobante.Columns.Add("IdTipoComprobante", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("Letra", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("CentroEmisor", GetType(Short))
      _dtProductosSinDescargoComprobante.Columns.Add("NumeroPedido", GetType(Integer))
      _dtProductosSinDescargoComprobante.Columns.Add("IdReparto", GetType(Integer))
      _dtProductosSinDescargoComprobante.Columns.Add("NombreProducto", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("Cantidad", GetType(Decimal))
      _dtProductosSinDescargoComprobante.Columns.Add("Precio", GetType(Decimal))
      _dtProductosSinDescargoComprobante.Columns.Add("CodigoCliente", GetType(Long))
      _dtProductosSinDescargoComprobante.Columns.Add("NombreCliente", GetType(String))
      _dtProductosSinDescargoComprobante.Columns.Add("TipoOperacion", GetType(String))
      _dsProductosSinDescargo = New DataSet()

      Dim Relacion As DataRelation
      _dsProductosSinDescargo.Tables.Add("ProductosSinDescargo", _dtProductosSinDescargo)
      _dsProductosSinDescargo.Tables.Add("ProductosSinDescargoComprobante", _dtProductosSinDescargoComprobante)
      Relacion = New DataRelation("ProductosSinDescargo",
                                  {_dtProductosSinDescargo.Columns("IdProducto")},
                                  {_dtProductosSinDescargoComprobante.Columns("IdProducto")})
      _dsProductosSinDescargo.Relations.Add(Relacion)
   End Sub
#End Region

   Private Function ValidaGrabarBorrador() As Boolean
      If Not bscReparto2.Selecciono OrElse bscReparto2.Text.ToInt32().IfNull() = 0 Then
         ShowMessage("Debe seleccionar un reparto")
         bscReparto2.Focus()
         Return False
      End If
      If cmbCajas.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar una caja")
         cmbCajas.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub GrabarBorrador()
      If ValidaGrabarBorrador() Then
         Dim regla = New Reglas.RegistracionPagos()
         regla.GrabarBorradorRegistracionPagos(bscReparto2.Text.ToInt32().IfNull(), dtpFechaRend.Value, cmbCajas.ValorSeleccionado(Of Integer), DtsRegistracionPagosV2)
      End If
   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGrabaDataSetXML.Click
      TryCatched(Sub()
                    DtsRegistracionPagosV2.WriteXml(String.Format("d:\Temp\_xml_RegPagov2\DtsRegistracionPagosV2_{0:yyyyMMdd_HHmmss}.xml", Now))
                 End Sub)
   End Sub

   Private Sub chbRespDistribucion_CheckedChanged(sender As Object, e As EventArgs) Handles chbRespDistribucion.CheckedChanged
      TryCatched(Sub() chbRespDistribucion.FiltroCheckedChanged(cmbRespDistribucion))
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      TryCatched(Sub() chbRuta.FiltroCheckedChanged(cmbRuta))
   End Sub

   Private Sub chbDias_CheckedChanged(sender As Object, e As EventArgs) Handles chbDias.CheckedChanged
      TryCatched(Sub() chbDias.FiltroCheckedChanged(cmbDias))
   End Sub

   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(cmbLocalidad))
   End Sub

   Private Sub chbFechaDesde_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaDesde.CheckedChanged
      TryCatched(Sub() dtpFechaDesde.Enabled = chbFechaDesde.Checked)
   End Sub

   Private Sub chbFechaHasta_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaHasta.CheckedChanged
      TryCatched(Sub() dtpFechaHasta.Enabled = chbFechaHasta.Checked)
   End Sub
End Class