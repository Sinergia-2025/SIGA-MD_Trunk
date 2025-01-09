Public Class ConsultarRecibosAClientes
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private idUsuario As String = actual.Nombre
   Private _modalidadPantalla As Entidades.ModalidadPantalla = Entidades.ModalidadPantalla.Consultar
   Private _tit As Dictionary(Of String, String)
   Private _numeroComprobanteDesdeAnterior As Long = 0
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(idUsuario).Rows.Count = 0 Then
            idUsuario = String.Empty
         End If

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, idUsuario)

         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

         If idUsuario = "" Then
            cmbVendedor.SelectedIndex = -1
         Else
            chbVendedor.Checked = True
            chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            cmbOrigenVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

         _publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
         cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

         _publicos.CargaComboEstadosClientes(cmbEstadoCliente)
         _publicos.CargaComboDesdeEnum(cmbOrigenEstadoCliente, GetType(Entidades.OrigenFK))
         cmbOrigenEstadoCliente.SelectedValue = Entidades.OrigenFK.Movimiento

         _publicos.CargaComboCategorias(cmbCategoria)
         _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Movimiento

         _publicos.CargaComboTiposComprobantesRecibo(cmbTiposComprobantesRec, True, "CTACTECLIE", esReciboClienteVinculado:=Nothing)

         _publicos.CargaComboUsuarios(cmbUsuario)

         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=False, cajasModificables:=False)
         cmbCajas.SelectedIndex = -1

         With cboLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1

         ugDetalle.AgregarTotalesSuma({"ImportePesos", "ImporteTickets", "ImporteCheques", "ImporteTarjetas",
                                       "ImporteTransfBancaria", "ImporteRetenciones", "ImporteTotal"})

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
         End If

         If _modalidadPantalla = Entidades.ModalidadPantalla.Modificar Then
            tsbModificar.Visible = True
            tssModificar.Visible = tsbModificar.Visible
            Text = "Modificar Recibos a Clientes"
         End If

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreDeFantasia", "Observacion"}, {"Ver", "VerEstandar", "Imprimir"})
         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal
      End Sub)
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
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Cliente pero NO selecciono")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbCaja.Checked And cmbCajas.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Caja aunque activó ese Filtro")
            cmbCajas.Focus()
            Exit Sub
         End If

         If chbNumero.Checked And txtNumeroCompDesde.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Numero aunque activó ese Filtro")
            txtNumeroCompDesde.Focus()
            Exit Sub
         End If

         If chbReparto.Checked And txtReparto.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Reparto aunque activó ese Filtro")
            txtReparto.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
      TryCatched(
      Sub()
         If _modalidadPantalla <> Entidades.ModalidadPantalla.Modificar Then Exit Sub
         Dim recibo As Entidades.CuentaCorriente = GetReciboSeleccionado()
         If recibo IsNot Nothing Then
            Using frmAnular As New AnularRecibos()
               If frmAnular.ShowDialog(Me, recibo, _modalidadPantalla) = Windows.Forms.DialogResult.OK Then
                  btnConsultar.PerformClick()
               End If         'If frmAnular.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            End Using         'Using frmAnular As New AnularRecibos()
         End If               'If recibo IsNot Nothing Then
      End Sub)
   End Sub
   Private Sub tsbImprimirPreDiseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPreDiseñado.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count() = 0 Then Exit Sub

         Dim dt = ugDetalle.DataSource(Of DataTable)
         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Using frmImprime = New VisorReportes("Eniac.Win.ConsultarRecibosAClientes.rdlc", "DataSetCtaCteClientes_DetalleRecibosAClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Text
            frmImprime.WindowState = FormWindowState.Maximized
            If chbCliente.Checked Then
               If bscCodigoCliente.Selecciono Then
                  If Not String.IsNullOrWhiteSpace(bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                     frmImprime.Destinatarios = bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
                  End If
               ElseIf bscCliente.Selecciono Then
                  If Not String.IsNullOrWhiteSpace(bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                     frmImprime.Destinatarios = bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
                  End If
               End If
            End If
            frmImprime.ShowDialog()
         End Using
      End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
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

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbRecibo_CheckedChanged(sender As Object, e As EventArgs) Handles chbRecibo.CheckedChanged
      TryCatched(Sub() chbRecibo.FiltroCheckedChanged(cmbTiposComprobantesRec))
   End Sub

#Region "Eventos Buscadores Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cboLetra))
   End Sub
   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      TryCatched(Sub() chbEmisor.FiltroCheckedChanged(cmbEmisor))
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
      Sub()
         txtNumeroCompDesde.Enabled = chbNumero.Checked
         txtNumeroCompHasta.Enabled = txtNumeroCompDesde.Enabled
         If Not chbNumero.Checked Then
            txtNumeroCompDesde.Clear()
            txtNumeroCompHasta.Clear()
         Else
            txtNumeroCompDesde.Focus()
         End If
      End Sub)
   End Sub
   Private Sub txtNumeroCompDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Enter
      TryCatched(Sub() _numeroComprobanteDesdeAnterior = txtNumeroCompDesde.Text.ValorNumericoPorDefecto(0L))
   End Sub
   Private Sub txtNumeroCompDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Leave
      TryCatched(
      Sub()
         Dim desde = txtNumeroCompDesde.ValorNumericoPorDefecto(0L)
         Dim hasta = txtNumeroCompHasta.ValorNumericoPorDefecto(0L)
         Dim delta = desde - _numeroComprobanteDesdeAnterior
         txtNumeroCompHasta.Text = (hasta + delta).ToString()
      End Sub)
   End Sub
   Private Sub chbReparto_CheckedChanged(sender As Object, e As EventArgs) Handles chbReparto.CheckedChanged
      TryCatched(
      Sub()
         txtReparto.Enabled = chbReparto.Checked
         If Not chbReparto.Checked Then
            txtReparto.Clear()
         End If
      End Sub)
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(Sub() chbCobrador.FiltroCheckedChanged(cmbCobrador))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCajas))
   End Sub
   Private Sub chbEstadoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoCliente.CheckedChanged
      TryCatched(Sub() chbEstadoCliente.FiltroCheckedChanged(cmbEstadoCliente))
   End Sub
#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim clickedBtn = e.Cell.Column.Key
            If clickedBtn = "Ver" Or clickedBtn = "Imprimir" Or clickedBtn = "VerEstandar" Then
               Dim ctacte = GetReciboSeleccionado(dr)
               Dim imp = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, visualizar:=clickedBtn <> "Imprimir", verEstandar:=clickedBtn = "VerEstandar")
            End If
         End If

      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbCategoria.Checked = False
      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Movimiento

      chbCliente.Checked = False
      If idUsuario = "" Then
         chbVendedor.Checked = False
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento
      End If

      chbRecibo.Checked = False
      chbCaja.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbLetra.Checked = False
      chbEmisor.Checked = False
      chbNumero.Checked = False
      chbZonaGeografica.Checked = False
      chbReparto.Checked = False

      chbCobrador.Checked = False
      cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

      chbEstadoCliente.Checked = False
      cmbOrigenEstadoCliente.SelectedValue = Entidades.OrigenFK.Movimiento

      ugDetalle.ClearFilas()
      cmbSucursal.Refrescar()

      btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked AndAlso (bscCodigoCliente.Selecciono Or bscCliente.Selecciono), Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim idCategoria = If(cmbCategoria.Enabled, cmbCategoria.ValorSeleccionado(Of Integer), 0I)
      Dim origenCategoria = cmbOrigenCategoria.ValorSeleccionado(Of Entidades.OrigenFK)()

      Dim idVendedor = If(cmbVendedor.Enabled, cmbVendedor.ValorSeleccionado(Of Integer), 0I)
      Dim origenVendedor = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)

      Dim idCobrador = If(cmbCobrador.Enabled, cmbCobrador.ValorSeleccionado(Of Integer), 0I)
      Dim origenCobrador = DirectCast(cmbOrigenCobrador.SelectedValue, Entidades.OrigenFK)

      Dim idTipoComprobante = If(cmbTiposComprobantesRec.Enabled, cmbTiposComprobantesRec.SelectedValue.ToString(), String.Empty)

      Dim idUsuario = If(cmbUsuario.Enabled, cmbUsuario.ItemSeleccionado(Of Entidades.Usuario).Usuario, String.Empty)

      Dim idCaja = If(chbCaja.Checked, cmbCajas.ValorSeleccionado(Of Integer), 0I)
      Dim letra = If(cboLetra.Enabled, cboLetra.ValorSeleccionado(Of String), String.Empty)
      Dim emisor = If(cmbEmisor.Enabled, cmbEmisor.ValorSeleccionado(Of Integer), 0I)

      Dim numeroComprobanteDesde = txtNumeroCompDesde.ValorSeleccionado(chbNumero, 0L)
      Dim numeroComprobanteHasta = txtNumeroCompHasta.ValorSeleccionado(chbNumero, 0L)

      Dim idZonaGeografica = If(cmbZonaGeografica.Enabled, cmbZonaGeografica.ValorSeleccionado(Of String), String.Empty)

      Dim idEstadoCliente = If(cmbEstadoCliente.Enabled, cmbEstadoCliente.ValorSeleccionado(Of Integer), 0I)
      Dim origenEstadoCliente = DirectCast(cmbOrigenEstadoCliente.SelectedValue, Entidades.OrigenFK)

      '# Numero de Reparto
      Dim numeroReparto As Integer? = If(Not String.IsNullOrEmpty(txtReparto.Text), Integer.Parse(txtReparto.Text), Nothing)

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      Dim dtDetalle = rCtaCte.GetRecibosPorRangoFechas(cmbSucursal.GetSucursales(),
                                                       dtpDesde.Value, dtpHasta.Value,
                                                       idCliente,
                                                       idCategoria, origenCategoria,
                                                       idVendedor, origenVendedor,
                                                       idTipoComprobante,
                                                       idUsuario,
                                                       idCaja, letra, emisor, numeroComprobanteDesde, numeroComprobanteHasta,
                                                       idZonaGeografica,
                                                       idCobrador, origenCobrador,
                                                       idEstadoCliente, origenEstadoCliente,
                                                       numeroReparto)
      dtDetalle.Columns.Add("Ver")
      dtDetalle.Columns.Add("Imprimir")
      dtDetalle.Columns.Add("VerEstandar")

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

      PreferenciasLeer(ugDetalle, tsbPreferencias)
   End Sub

   Private Function GetReciboSeleccionado() As Entidades.CuentaCorriente
      Return GetReciboSeleccionado(ugDetalle.FilaSeleccionada(Of DataRow)())
   End Function
   Private Function GetReciboSeleccionado(dr As DataRow) As Entidades.CuentaCorriente
      If dr IsNot Nothing Then
         Dim reg = New Reglas.CuentasCorrientes()
         Return reg.GetUna(dr.Field(Of Integer)("IdSucursal"),
                           dr.Field(Of String)("IdTipoComprobante"),
                           dr.Field(Of String)("Letra"),
                           dr.Field(Of Integer)("CentroEmisor"),
                           dr.Field(Of Long)("NumeroComprobante"))
      End If
      Return Nothing
   End Function
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)
         filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         If chbRecibo.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", cmbTiposComprobantesRec.Text)
         End If
         If chbCliente.Checked Then
            filtro.AppendFormat("Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbLetra.Checked Then
            filtro.AppendFormat(" - Letra: {0}", cboLetra.Text)
         End If
         If chbEmisor.Checked Then
            filtro.AppendFormat(" - Emisor: {0}", cmbEmisor.Text)
         End If
         If chbNumero.Checked Then
            filtro.AppendFormat(" - Número Desde: {0} Hasta:{1}", txtNumeroCompDesde.Text, txtNumeroCompHasta.Text)
         End If
         If chbVendedor.Checked Then
            filtro.AppendFormat(" - Vendedor: {0}", cmbVendedor.Text)
         End If
         If chbCobrador.Checked Then
            filtro.AppendFormat(" - Cobrador: {0}", cmbCobrador.Text)
         End If
         If chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", cmbCategoria.Text)
         End If
         If chbUsuario.Checked Then
            filtro.AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         If chbZonaGeografica.Checked Then
            filtro.AppendFormat(" - Zona Geografica: {0}", cmbZonaGeografica.Text)
         End If
         If chbCaja.Checked Then
            filtro.AppendFormat(" - Caja: {0}", cmbCajas.Text)
         End If
         If chbEstadoCliente.Checked Then
            filtro.AppendFormat(" - Estado Cliente: {0}", cmbEstadoCliente.Text)
         End If
         If chbReparto.Checked Then
            filtro.AppendFormat(" - Reparto: {0}", txtReparto.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If parametros = "MODIFICAR" Then
         _modalidadPantalla = Entidades.ModalidadPantalla.Modificar
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
End Class