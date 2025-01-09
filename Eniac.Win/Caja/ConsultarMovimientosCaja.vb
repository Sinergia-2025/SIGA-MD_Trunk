Public Class ConsultarMovimientosCaja

#Region "Campos"
   Private _publicos As Publicos
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = False
   Private _blnCajasModificables As Boolean = False
   Private _entro As Boolean = True
   Private _tit As Dictionary(Of String, String)
   Private Const _saldoInicialNombreCuentaCaja As String = "          SALDO INICIAL"
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboGruposDeCuentas(cmbGrupos)

            _publicos.CargaComboDesdeEnum(cmbTipoFecha, GetType(Entidades.CajaDetalles.FechaConsulta))
            cmbTipoFecha.SelectedValue = Entidades.CajaDetalles.FechaConsulta.Movimiento

            _publicos.CargaComboDesdeEnum(cmbEsModificable, GetType(Entidades.Publicos.SiNoTodos))
            cmbEsModificable.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

            If Not Reglas.Publicos.TieneModuloContabilidad Then
               ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
               ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
               ugDetalle.DisplayLayout.Bands(0).Columns("GeneraContabilidad").Hidden = True
            End If

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            InicializaCajas()

            ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not cmbSucursal.Enabled
            ugDetalle.AgregarFiltroEnLinea({"Observacion"})
            ugDetalle.AgregarTotalesSuma({"ImportePesos", "ImporteCheques", "ImporteTarjetas", "ImporteTickets",
                                          "ImporteDolares", "ImporteBancos", "ImporteRetenciones"})

            PreferenciasLeer(ugDetalle, tsbPreferencias)
            _tit = GetColumnasVisiblesGrilla(ugDetalle)
            dtpDesde.Focus()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
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
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(Sub() InicializaCajas())
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbNroPlanilla_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroPlanilla.CheckedChanged
      TryCatched(
         Sub()
            txtNroPlanilla.Enabled = chbNroPlanilla.Checked
            If Not chbNroPlanilla.Checked Then
               txtNroPlanilla.Text = ""
            Else
               txtNroPlanilla.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbCuentaDeCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaDeCaja.CheckedChanged
      TryCatched(Sub() chbCuentaDeCaja.FiltroCheckedChanged(bscCuentaCaja, bscNombreCuentaCaja))
   End Sub
   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeCajas2(bscCuentaCaja)
            bscCuentaCaja.Datos = New Reglas.CuentasDeCajas().GetTodas(bscCuentaCaja.Text)
         End Sub)
   End Sub
   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeCajas2(bscNombreCuentaCaja)
            bscNombreCuentaCaja.Datos = New Reglas.CuentasDeCajas().GetPorNombre(bscNombreCuentaCaja.Text)
         End Sub)
   End Sub
   Private Sub bscCuentaCaja_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion, bscNombreCuentaCaja.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCuentaDeCaja(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub
   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      TryCatched(Sub() chbGrupo.FiltroCheckedChanged(cmbGrupos))
   End Sub

#End Region

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      TryCatched(Sub() UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString())
   End Sub
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Select Case e.Cell.Column.Key
                  Case "Ver", "Imp"
                     If e.Cell.Row.Fixed Then Exit Sub
                     Using frmDetalle = New CajaDetalles()

                        frmDetalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta

                        frmDetalle.IdSucursalMovimiento = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString())
                        frmDetalle.CajaNombre.IdCaja = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdCaja").Value.ToString())
                        frmDetalle.CajaNombre.NombreCaja = Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NombreCaja").Value.ToString()

                        frmDetalle.NumeroPlanilla = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroPlanilla").Value.ToString())
                        frmDetalle.NroDeMovimiento = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroMovimiento").Value.ToString())

                        frmDetalle.btnAceptar.Visible = False

                        If e.Cell.Column.Key = "Ver" Then
                           frmDetalle.ShowDialog()
                        Else
                           Dim numeroPlanilla = frmDetalle.NumeroPlanilla
                           Dim numeroMovimiento = frmDetalle.NroDeMovimiento

                           Dim imp = New ImprimirMovimientoCaja()
                           imp.Imprimir(actual.Sucursal.IdSucursal, frmDetalle.CajaNombre.IdCaja, numeroPlanilla, numeroMovimiento, visualiza:=True)
                        End If
                     End Using

                  Case Else
               End Select
            End If
         End Sub)
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
         Sub()
            If e.Row.Fixed Then
               e.Row.Cells("ImportePesos").Color(Color.Black, Color.DarkSeaGreen)
               e.Row.Cells("ImporteCheques").Color(Color.Black, Color.DarkSeaGreen)
               e.Row.Cells("ImporteTarjetas").Color(Color.Black, Color.DarkSeaGreen)
               e.Row.Cells("ImporteDolares").Color(Color.Black, Color.DarkSeaGreen)
               e.Row.Cells("ImporteBancos").Color(Color.Black, Color.DarkSeaGreen)
               e.Row.Cells("ImporteRetenciones").Color(Color.Black, Color.DarkSeaGreen)
               e.Row.Cells("ImporteTickets").Color(Color.Black, Color.DarkSeaGreen)
            End If
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCuentaDeCaja.Checked And Not bscCuentaCaja.Selecciono And Not bscNombreCuentaCaja.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó una Cuenta aunque activó ese Filtro")
               bscCuentaCaja.Focus()
               Exit Sub
            End If

            If chbGrupo.Checked And cmbGrupos.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Grupo aunque activó ese Filtro")
               cmbGrupos.Focus()
               Exit Sub
            End If

            If cmbCajas.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó una Caja")
               cmbCajas.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
               Exit Sub
            End If
         End Sub)
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now

      cmbTipoFecha.SelectedValue = Entidades.CajaDetalles.FechaConsulta.Movimiento

      chbCuentaDeCaja.Checked = False
      chbGrupo.Checked = False
      chbNroPlanilla.Checked = False
      cmbEsModificable.SelectedIndex = 0

      txtBuscar.Text = ""
      txtBuscar.Tag = ""

      cmbCajas.Refrescar()
      _entro = False
      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      chbVerSaldos.Checked = True
      'Limpio la Grilla.
      ugDetalle.ClearFilas()

      'Se puede resetear el control de Sucursal de dos formas
      '1.- Seleccionando el valor         - Si tenemos que llevarlo a un valor que no sea el default
      'cmbSucursal.SelectedValue = actual.Sucursal.IdSucursal
      '2.- Ejecutando el método Refrescar - Si tenemos que llevarlo al valor default
      cmbSucursal.Refrescar()

      dtpDesde.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub
   Private Sub CargaGrillaDetalle()
      Dim idCuentaDeCaja = If(chbCuentaDeCaja.Checked, bscCuentaCaja.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idGrupoDeCuenta = If(chbGrupo.Checked, cmbGrupos.SelectedValue.ToString(), String.Empty)
      Dim nroPlanilla = If(chbNroPlanilla.Checked, txtNroPlanilla.ValorNumericoPorDefecto(0I), 0I)

      If ugDetalle.ActiveCell IsNot Nothing Then
         txtBuscar.Tag = ugDetalle.ActiveCell.Column.Key
      End If
      Dim bus As Entidades.Buscar = Nothing
      If txtBuscar.Tag IsNot Nothing And Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
         bus = New Entidades.Buscar(txtBuscar.Tag.ToString(), txtBuscar.Text.Trim())
      End If

      Dim rCajaDet = New Reglas.CajaDetalles()
      Dim dtDetalle = rCajaDet.GetPorRangoFechas(bus,
                                                 cmbSucursal.GetSucursales(),
                                                 cmbCajas.GetCajas(),
                                                 dtpDesde.Value, dtpHasta.Value, cmbTipoFecha.ValorSeleccionado(Of Entidades.CajaDetalles.FechaConsulta)(),
                                                 idCuentaDeCaja, idGrupoDeCuenta,
                                                 cmbEsModificable.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(), nroPlanilla)
      dtDetalle.Columns.Add("Ver", GetType(String), "'...'")
      dtDetalle.Columns.Add("Imp", GetType(String), "'...'")

      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)

      If chbVerSaldos.Checked Then
         Using dtSaldosIniciales =
               rCajaDet.GetSaldosIniciales(bus,
                                           cmbSucursal.GetSucursales(),
                                           cmbCajas.GetCajas(),
                                           dtpDesde.Value, cmbTipoFecha.ValorSeleccionado(Of Entidades.CajaDetalles.FechaConsulta)(),
                                           idCuentaDeCaja, idGrupoDeCuenta,
                                           cmbEsModificable.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(), nroPlanilla)
            Dim drCl = dtDetalle.NewRow()
            drCl("NombreCuentaCaja") = _saldoInicialNombreCuentaCaja
            If dtSaldosIniciales.Any() Then
               Dim drSaldosIniciales = dtSaldosIniciales.First()
               drCl("ImportePesos") = drSaldosIniciales.Field(Of Decimal?)("SIImportePesos").IfNull()
               drCl("ImporteCheques") = drSaldosIniciales.Field(Of Decimal?)("SIImporteCheques").IfNull()
               drCl("ImporteTarjetas") = drSaldosIniciales.Field(Of Decimal?)("SIImporteTarjetas").IfNull()
               drCl("ImporteDolares") = drSaldosIniciales.Field(Of Decimal?)("SIImporteDolares").IfNull()
               drCl("ImporteBancos") = drSaldosIniciales.Field(Of Decimal?)("SIImporteBancos").IfNull()
               drCl("ImporteRetenciones") = drSaldosIniciales.Field(Of Decimal?)("SIImporteRetenciones").IfNull()
               drCl("ImporteTickets") = 0D

            End If
            dtDetalle.Rows.InsertAt(drCl, pos:=0)
         End Using

      End If

      If chbVerSaldos.Checked AndAlso ugDetalle.Rows.Count > 0 Then
         ugDetalle.Rows.GetRowWithListIndex(0).Fixed = True
      End If
      ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat(" - Fecha {2}: Desde {0} Hasta {1} - ", dtpDesde.Text, dtpHasta.Text, cmbTipoFecha.Text)

         cmbCajas.CargarFiltrosImpresionCajaNombres(filtro, False, True)

         If chbNroPlanilla.Checked Then .AppendFormat(" - Planilla: {0}", txtNroPlanilla.Text)
         If chbCuentaDeCaja.Checked Then .AppendFormat(" - Cuenta: {0} - {1}", bscCuentaCaja.Text, bscNombreCuentaCaja.Text)
         If chbGrupo.Checked Then .AppendFormat(" - Grupo: {0}", cmbGrupos.Text)
         If cmbEsModificable.SelectedIndex > 0 Then .AppendFormat(" - Es Modif.: {0}", cmbEsModificable.Text)
         If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then .AppendFormat(" - Buscar: {0}", txtBuscar.Text)
         .AppendFormat(" - Ver Saldos: {0}", If(chbVerSaldos.Checked, "Si", "No").ToString())

      End With

      Return filtro.ToString()

   End Function

   Private Sub CargarDatosCuentaDeCaja(dr As DataGridViewRow)
      bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
      bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      bscNombreCuentaCaja.Enabled = False
      bscCuentaCaja.Enabled = False
   End Sub

   Private Sub InicializaCajas()
      cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False, permiteSinSeleccion:=False)
   End Sub

#End Region

End Class