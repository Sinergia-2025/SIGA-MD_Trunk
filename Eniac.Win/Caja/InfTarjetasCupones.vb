Public Class InfTarjetasCupones

#Region "Campos"

   Private _publicos As Publicos
   Private _IdActualCuentaBancaria As Integer = 0
   Public ConsultarAutomaticamente As Boolean = False

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=False, cajasModificables:=True)
         cmbCajas.SelectedIndex = -1

         _publicos.CargaComboBancos(cmbBanco)

         _publicos.CargaComboTarjetas(cmbTarjetas, True)
         cmbTarjetas.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbEstado, GetType(Entidades.TarjetaCupon.Estados))
         cmbEstado.SelectedIndex = -1

         ugDetalle.AgregarTotalesSuma({"Monto"})

         ugDetalle.AgregarFiltroEnLinea({""})

         '-.PE-32098.-
         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

         PreferenciasLeer(ugDetalle, tsbPreferencias)
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
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, Me.CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, Me.CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFechaIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaIngreso.CheckedChanged
      TryCatched(Sub() chbFechaIngreso.FiltroCheckedChanged(dtpIngresoDesde, dtpIngresoHasta))
   End Sub
   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      TryCatched(Sub() chbEstado.FiltroCheckedChanged(cmbEstado))
   End Sub
   Private Sub chbFechaLiquidacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaLiquidacion.CheckedChanged
      TryCatched(Sub() chbFechaLiquidacion.FiltroCheckedChanged(dtpLiquidacionDesde, dtpLiquidacionHasta))
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroCupon.CheckedChanged
      TryCatched(Sub() chbNumeroCupon.FiltroCheckedChanged(txtNumeroCupon))
   End Sub
   Private Sub chbNumeroLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroLote.CheckedChanged
      TryCatched(Sub() chbNumeroLote.FiltroCheckedChanged(txtNumeroLote))
   End Sub
   Private Sub chbFechaEnCarteraAl_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnCarteraAl.CheckedChanged
      TryCatched(Sub() chbFechaEnCarteraAl.FiltroCheckedChanged(dtpFechaEnCarteraAl, dtpFechaEnCarteraAl))
   End Sub
   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCajas))
   End Sub
   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      TryCatched(Sub() chbBanco.FiltroCheckedChanged(cmbBanco))
   End Sub
   Private Sub chbTarjetas_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarjetas.CheckedChanged
      TryCatched(Sub() chbTarjetas.FiltroCheckedChanged(cmbTarjetas))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
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

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCaja.Checked And cmbCajas.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Caja aunque activó ese Filtro")
            cmbCajas.Focus()
            Exit Sub
         End If
         If chbBanco.Checked And cmbBanco.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Banco aunque activó ese Filtro")
            cmbBanco.Focus()
            Exit Sub
         End If
         If chbNumeroCupon.Checked And (txtNumeroCupon.Text = "" OrElse Long.Parse(txtNumeroCupon.Text) = 0) Then
            ShowMessage("ATENCION: NO seleccionó un Numero aunque activó ese Filtro")
            txtNumeroCupon.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbEstado.Checked And cmbEstado.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Estado aunque activó ese Filtro")
            cmbEstado.Focus()
            Exit Sub
         End If
         If chbNumeroCupon.Checked And txtNumeroCupon.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Numero de Cupon aunque activó ese Filtro")
            txtNumeroCupon.Focus()
            Exit Sub
         End If
         If chbNumeroLote.Checked And txtNumeroLote.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Numero de Lote aunque activó ese Filtro")
            txtNumeroLote.Focus()
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

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chbCaja.Checked = False
      chbNumeroCupon.Checked = False
      chbBanco.Checked = False
      chbEstado.Checked = False
      chbFechaIngreso.Checked = True
      chbFechaLiquidacion.Checked = False
      chbFechaEnCarteraAl.Checked = False
      chbNumeroCupon.Checked = False
      chbNumeroLote.Checked = False
      chbBanco.Checked = False
      chbTarjetas.Checked = False
      chbCliente.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      cmbSucursal.Refrescar()

      ugDetalle.ClearFilas()

      btnConsultar.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim numeroCupon = txtNumeroCupon.ValorSeleccionado(chbNumeroCupon, 0I)
      Dim numeroLote = txtNumeroLote.ValorSeleccionado(chbNumeroLote, 0I)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idBanco = cmbBanco.ValorSeleccionado(chbBanco, 0I)
      Dim idTarjeta = cmbTarjetas.ValorSeleccionado(chbTarjetas, 0I)
      Dim estadoCupon = cmbEstado.ValorSeleccionado(chbEstado, Entidades.TarjetaCupon.Estados.NINGUNO)

      Dim rCupones = New Reglas.TarjetasCupones()
      Dim dtDetalle = rCupones.GetInformeCupones(cmbSucursal.GetSucursales(), idTarjetaCupon:=0,
                                                 dtpIngresoDesde.Valor(chbFechaIngreso), dtpIngresoHasta.Valor(chbFechaIngreso),
                                                 estadoCupon.ToString(),
                                                 dtpLiquidacionDesde.Valor(chbFechaLiquidacion), dtpLiquidacionHasta.Valor(chbFechaLiquidacion),
                                                 numeroCupon, numeroLote,
                                                 dtpFechaEnCarteraAl.Valor(chbFechaEnCarteraAl),
                                                 cmbCajas.ValorSeleccionado(chbCaja, 0I), idBanco,
                                                 idCliente, idTarjeta, idSituacion:=0)
      ugDetalle.DataSource = dtDetalle
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False) '-.PE-32098.-
         If chbFechaIngreso.Checked Then
            .AppendFormat(" - Fecha Ingreso: Desde {0} Hasta {1}", dtpIngresoHasta.Text, dtpIngresoHasta.Text)
         End If
         If chbEstado.Checked Then
            .AppendFormat(" - Estado: {0}", cmbEstado.Text)
         End If
         If chbFechaLiquidacion.Checked Then
            .AppendFormat(" - Fecha Liquidacion: Desde {0} Hasta {1}", dtpLiquidacionDesde.Text, dtpLiquidacionHasta.Text)
         End If
         If chbNumeroCupon.Checked Then
            .AppendFormat(" - Cupón: {0}", txtNumeroCupon.Text)
         End If
         If chbNumeroLote.Checked Then
            .AppendFormat(" - Lote: {0}", txtNumeroLote.Text)
         End If
         If chbFechaEnCarteraAl.Checked Then
            .AppendFormat(" - En Cartera Al: {0}", dtpFechaEnCarteraAl.Text)
         End If
         If chbCaja.Checked Then
            .AppendFormat(" - Caja: {0}", cmbCajas.Text)
         End If
         If chbBanco.Checked Then
            .AppendFormat(" - Banco: {0}", cmbBanco.Text)
         End If
         If bscCodigoCliente.Text.Length > 0 And bscCliente.Text.Length > 0 Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region
End Class