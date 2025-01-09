Public Class AnularRequerimientosCompras

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String = Entidades.TipoComprobante.Tipos.REQCOMPRAS.ToString()

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         RefrescarDatosGrilla()

         PreferenciasLeer(ugDetalle, tsbPreferencias)

      End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      CargaGrillaDetalle(onLoad:=True)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscProducto.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto.Focus()
            Exit Sub
         End If

         If chbIdRequerimiento.Checked AndAlso txtIdRequerimiento.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número de Requerimiento aunque activó ese Filtro.")
            txtIdRequerimiento.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle(onLoad:=False)

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)

   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(Sub() AnularRequerimiento())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      TryCatched(Sub() chbFechaEntrega.FiltroCheckedChanged(chkMesCompletoEntrega, dtpEntregaDesde, dtpEntregaHasta))
   End Sub
   Private Sub chkMesCompletoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompletoEntrega.FiltroCheckedChangedMesCompleto(dtpEntregaDesde, dtpEntregaHasta))
   End Sub

   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdRequerimiento.CheckedChanged
      TryCatched(Sub() chbIdRequerimiento.FiltroCheckedChanged(txtIdRequerimiento))
   End Sub

#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscProducto))
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto)
         bscProducto.Datos = New Reglas.Productos().GetPorNombre(bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region

#End Region

#Region "Eventos Grilla"

   '   'Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
   '   '   TryCatched(
   '   '   Sub()
   '   '      Dim row = e.Row.FilaSeleccionada(Of DataRow)
   '   '      If row IsNot Nothing Then
   '   '         If row.Table.Columns.Contains("UrlPlano") Then
   '   '            If Not String.IsNullOrWhiteSpace(row.Field(Of String)("UrlPlano")) Then
   '   '               e.Row.Cells("ClipArchivoAdjunto").Style = UltraWinGrid.ColumnStyle.EditButton
   '   '               e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
   '   '            Else
   '   '               e.Row.Cells("ClipArchivoAdjunto").Activation = Activation.Disabled
   '   '            End If
   '   '         End If
   '   '         If row.Table.Columns.Contains("Color") AndAlso IsNumeric(e.Row.Cells("Color").Value) Then
   '   '            e.Row.Cells("IdEstado").Appearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
   '   '            e.Row.Cells("IdEstado").Appearance.AlphaLevel = 128
   '   '            e.Row.Cells("IdEstado").Appearance.ForegroundAlpha = Alpha.Opaque

   '   '            e.Row.Cells("IdEstado").ActiveAppearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
   '   '            e.Row.Cells("IdEstado").ActiveAppearance.BackColorAlpha = Alpha.Opaque
   '   '            e.Row.Cells("IdEstado").ActiveAppearance.ForegroundAlpha = Alpha.Opaque
   '   '         End If
   '   '      End If
   '   '   End Sub)
   '   'End Sub

#End Region

#End Region

#Region "Metodos"

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         bscProducto.Selecciono = True
         bscCodigoProducto.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chbFecha.Checked = False
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbFechaEntrega.Checked = False
      chkMesCompletoEntrega.Checked = False
      dtpEntregaDesde.Value = Date.Today
      dtpEntregaHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbIdRequerimiento.Checked = False

      chbProducto.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      chbFecha.Focus()

   End Sub

   Private Sub CargaGrillaDetalle(onLoad As Boolean)

      Dim dtsMaster_detalle = New DataSet()

      Dim rPedidos = New Reglas.RequerimientosCompras()

      Dim desde = If(onLoad, Date.Today.AddDays(3), dtpDesde.Valor(chbFecha))
      Dim hasta = If(onLoad, Date.Today.AddDays(2), dtpHasta.Valor(chbFecha))

      Dim dsDetalle = rPedidos.GetRequerimietosParaAnular(desde.Date(), hasta.UltimoSegundoDelDia(), dtpEntregaDesde.Valor(chbFechaEntrega), dtpEntregaHasta.Valor(chbFechaEntrega),
                                                          cmbTiposComprobantes.GetTiposComprobantes(), txtIdRequerimiento.ValorSeleccionado(chbIdRequerimiento, -0I),
                                                          If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty))

      ugDetalle.DataSource = dsDetalle

      FormateaGrillas()

   End Sub
   Private Sub AnularRequerimiento()
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
      If dr IsNot Nothing Then
         Dim rq = New Reglas.RequerimientosCompras().GetUno(dr.Field(Of Long)(Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString()))
         Using frmConfirmar = New AnularRequerimientosComprasConfirmar(rq)
            If frmConfirmar.ShowDialog(Me) = DialogResult.OK Then
               btnConsultar.PerformClick()
            End If
         End Using
      End If
   End Sub

   Public Sub FormateaGrillas()
      FormateaGrillaRequerimientos()
   End Sub

   Public Sub FormateaGrillaRequerimientos()
      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         .Columns("IdRequerimientoCompra").FormatearColumna("Id Requerimiento", pos, 70, HAlign.Right, True)
         .Columns("IdSucursal").FormatearColumna("S.", pos, 30, HAlign.Right)
         .Columns("IdTipoComprobante").FormatearColumna("Id Tipo", pos, 70,, True)
         .Columns("DescripcionTipoComprobante").FormatearColumna("Tipo", pos, 120)
         .Columns("Letra").FormatearColumna("L.", pos, 30, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns("NumeroRequerimiento").FormatearColumna("Número", pos, 80, HAlign.Right)

         .Columns("Fecha").FormatearColumna("Fecha/Hora", pos, 100, HAlign.Center, True, "dd/MM/yyyy HH:mm")
         .Columns("Fecha_Fecha").FormatearColumna("Fecha", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Fecha_Hora").FormatearColumna("Hora", pos, 70, HAlign.Center, True, "HH:mm:ss")

         .Columns("FechaAlta").FormatearColumna("Fecha/Hora Alta", pos, 100, HAlign.Center, True, "dd/MM/yyyy HH:mm")
         .Columns("FechaAlta_Fecha").FormatearColumna("Fecha Alta", pos, 70, HAlign.Center,, "dd/MM/yyyy")
         .Columns("FechaAlta_Hora").FormatearColumna("Hora Alta", pos, 70, HAlign.Center, True, "HH:mm:ss")
         .Columns("IdUsuarioAlta").FormatearColumna("Usuario Alta", pos, 100)

         .Columns("Observacion").FormatearColumna("Observación", pos, 300)
      End With
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=True, muestraNombre:=False)

         If chbFecha.Checked Then
            .AppendFormat(" - Fechas: Desde {0} Hasta {1}", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbFechaEntrega.Checked Then
            .AppendFormat(" - F. Entrega: Desde {0} Hasta {1}", dtpEntregaDesde.Value, dtpEntregaHasta.Value)
         End If

         If chbIdRequerimiento.Checked Then
            .AppendFormat(" - Número {0}", txtIdRequerimiento.Text)
         End If

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto.Text, bscProducto.Text)
         End If

      End With

      Return filtro.ToString()
   End Function

#End Region

End Class