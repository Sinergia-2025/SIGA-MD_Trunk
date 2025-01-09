Public Class ConsultarFacturables

#Region "Campos"

   Private _publicos As Publicos
   Private _mostrarImportes As Boolean
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         PreferenciasLeer(ugDetalle, tsbPreferencias)
         _publicos = New Publicos()

         cmbEstadoComprobante.Items.Insert(0, "PENDIENTE")
         cmbEstadoComprobante.Items.Insert(1, "FACTURADO")
         cmbEstadoComprobante.Items.Insert(2, "ANULADO")
         cmbEstadoComprobante.Items.Insert(3, "NO ANULADO")
         cmbEstadoComprobante.SelectedIndex = -1

         _publicos.CargaComboUsuarios(cmbUsuario)
         _publicos.CargaComboCategorias(cmbCategorias)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1
         _publicos.CargaComboCategoriasFiscales(cmbCategoriaFiscal)

         _publicos.CargaComboTiposComprobantesFacturables(cmbTiposComprobantes, comprobantesAsociados:=String.Empty, miraPC:=False)
         cmbTiposComprobantes.SelectedIndex = -1

         'Seguridad del campo Precio de Costo
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         _mostrarImportes = oUsuario.TienePermisos("ConsultarFact-MostrarImp")

         If Not _mostrarImportes Then
            ugDetalle.DisplayLayout.Bands(0).Columns("SubTotal").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestos").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = True
         End If

         RefrescarDatosGrilla()

         FiltersManager1.Refrescar()

         ugDetalle.AgregarTotalesSuma({"SubTotal", "TotalImpuestos", "ImporteTotal"})
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "Observacion"})

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion()))
      'Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
      'Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
      'Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
      'Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = String.Format("Página: {0}", UltraGridPrintDocument1.PageNumber)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbFiltros_Click(sender As Object, e As EventArgs) Handles tsbFiltros.Click
      TryCatched(Sub() FiltersManager1.SeleccionarFiltro())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

#Region "Eventos Filtros"

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCategoriaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaCliente.CheckedChanged
      TryCatched(Sub() chbCategoriaCliente.FiltroCheckedChanged(cmbCategorias))
   End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoComprobante.CheckedChanged
      TryCatched(Sub() chbEstadoComprobante.FiltroCheckedChanged(cmbEstadoComprobante))
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCodigoCliente)
            Dim rClientes = New Reglas.Clientes()
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = rClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCliente)
            Dim rClientes = New Reglas.Clientes()
            bscCliente.Datos = rClientes.GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
         End Sub)
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbCategoriaFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaFiscal.CheckedChanged
      TryCatched(Sub() chbCategoriaFiscal.FiltroCheckedChanged(cmbCategoriaFiscal))
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
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

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("No hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(
         Sub()
            If chkExpandAll.Checked Then
               ugDetalle.Rows.ExpandAll(True)
            Else
               ugDetalle.Rows.CollapseAll(True)
            End If
         End Sub)
   End Sub

   ''Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

   ''   e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

   ''   e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

   ''   e.Layout.Override.SpecialRowSeparatorHeight = 6

   ''   e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

   ''   e.Layout.ViewStyle = ViewStyle.SingleBand

   ''   e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   ''End Sub

   Private Sub ugdDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               Select Case e.Cell.Column.Key
                  Case "Ver"
                     Dim rVentas = New Reglas.Ventas()
                     Dim venta = rVentas.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                dr.Field(Of String)("IdTipoComprobante"),
                                                dr.Field(Of String)("Letra"),
                                                dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                                dr.Field(Of Long)("NumeroComprobante"))
                     Dim oImpr = New Impresion(venta)
                     If dr.Field(Of String)("TipoImpresora") = "NORMAL" Then
                        oImpr.ImprimirComprobanteNoFiscal(True)
                     Else
                        oImpr.ReImprimirComprobanteFiscal()
                     End If
                  Case "Imprimir"
                     Dim rVentas = New Reglas.Ventas()
                     Dim venta = rVentas.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                dr.Field(Of String)("IdTipoComprobante"),
                                                dr.Field(Of String)("Letra"),
                                                dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                                dr.Field(Of Long)("NumeroComprobante"))
                     Dim oImpr = New Impresion(venta)
                     If dr.Field(Of String)("TipoImpresora") = "NORMAL" Then
                        oImpr.ImprimirComprobanteNoFiscal(False)
                     Else
                        ShowMessage("No es posible Reimprimir en la Impresora Fiscal un Comprobante FISCAL.")
                     End If
                  Case Else
               End Select
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Permitido = False
      bscCodigoCliente.Permitido = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbEstadoComprobante.Checked = False
      chbUsuario.Checked = False
      chbCliente.Checked = False
      chbVendedor.Checked = False
      chbTipoComprobante.Checked = False
      chbCategoriaCliente.Checked = False
      chbCategoriaFiscal.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      dtpDesde.Focus()
      FiltersManager1.Refrescar()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Sub CargaGrillaDetalle()
      Try

         Dim idCliente = If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L)
         Dim idEstadoComprobante = If(chbEstadoComprobante.Checked, cmbEstadoComprobante.Text, String.Empty)
         Dim idUsuario = If(chbUsuario.Checked, cmbUsuario.ValorSeleccionado(Of String), String.Empty)
         Dim idVendedor = If(chbVendedor.Checked, cmbVendedor.ValorSeleccionado(Of Integer), 0)
         Dim idCategoriaFiscal As Integer = If(chbCategoriaFiscal.Checked, cmbCategoriaFiscal.ValorSeleccionado(Of Integer), 0)
         Dim idTipoComprobante = If(chbTipoComprobante.Checked, cmbTiposComprobantes.ValorSeleccionado(Of String), String.Empty)
         Dim idCategoria = If(chbCategoriaCliente.Checked, cmbCategorias.ValorSeleccionado(Of Integer), 0)

         Dim rVenta = New Reglas.Ventas()
         Dim dtDetalle = rVenta.GetInfFacturables(actual.Sucursal.Id,
                                                  dtpDesde.Value, dtpHasta.Value,
                                                  idCliente,
                                                  idEstadoComprobante,
                                                  idUsuario,
                                                  idVendedor,
                                                  idTipoComprobante,
                                                  idCategoria,
                                                  idCategoriaFiscal)

         If Not _mostrarImportes Then
            dtDetalle.Tables("Cabecera").Columns.Remove("SubTotal")
            dtDetalle.Tables("Cabecera").Columns.Remove("TotalImpuestos")
            dtDetalle.Tables("Cabecera").Columns.Remove("ImporteTotal")
         End If

         ugDetalle.DataSource = dtDetalle

         AjustarColumnasGrilla(ugDetalle, _tit)

         FormatearBandaDetalle()

         tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearBandaDetalle()
      With ugDetalle.DisplayLayout.Bands("Cabecera_Detalle")
         For Each col In .Columns
            col.Hidden = True
         Next
         Dim pos = 0I
         .Columns(Entidades.VentaInvocado.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Tipo", pos, 80, , True)
         .Columns("DescripcionAbrevInvocador").FormatearColumna("Comprobante Invocador", pos, 120)
         .Columns(Entidades.VentaInvocado.Columnas.Letra.ToString()).FormatearColumna("Letra", pos, 40, HAlign.Center)
         .Columns(Entidades.VentaInvocado.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns(Entidades.VentaInvocado.Columnas.NumeroComprobante.ToString()).FormatearColumna("Número", pos, 80, HAlign.Right)
      End With
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", dtpDesde.Text, dtpHasta.Text)

         If chbEstadoComprobante.Checked Then
            .AppendFormat(" - {0}: {1}", chbEstadoComprobante.Text, cmbEstadoComprobante.Text)
         End If

         If chbUsuario.Checked Then
            .AppendFormat(" - {0}: {1}", chbUsuario.Text, cmbUsuario.Text)
         End If

         If chbCliente.Checked Then
            .AppendFormat(" - {0}: {1} - {2}", chbCliente.Text, bscCodigoCliente.Text, bscCliente.Text)
         End If

         If chbCategoriaFiscal.Checked Then
            .AppendFormat(" - {0}: {1}", chbCategoriaFiscal.Text, cmbCategoriaFiscal.Text)
         End If

         If chbCategoriaCliente.Checked Then
            .AppendFormat(" - {0}: {1}", chbCategoriaCliente.Text, cmbCategorias.Text)
         End If

         If chbTipoComprobante.Checked Then
            .AppendFormat(" - {0}: {1}", chbTipoComprobante.Text, cmbTiposComprobantes.Text)
         End If

         If chbVendedor.Checked Then
            .AppendFormat(" - {0}: {1}", chbVendedor.Text, cmbVendedor.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class