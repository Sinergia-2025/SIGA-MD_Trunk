Public Class ConsultarPlanillas

#Region "Constantes"
   Private Const funcionActual As String = "ConsultarPlanillas"
#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _puedeAnularComprobantes As Boolean
   Private _utilizaCentroCostos As Boolean
   Private _planillaActual As Entidades.Caja

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            _utilizaCentroCostos = Reglas.ContabilidadPublicos.UtilizaCentroCostos

            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=False, cajasModificables:=False)

            Dim TodasLasCajas = New Reglas.CajasNombres().GetAll(actual.Sucursal.IdSucursal).Rows.Count
            If TodasLasCajas <> cmbCajas.Items.Count Then
               chbCaja.Checked = True
               chbCaja.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            chbCajaUtilizaSaldosDigitados.Checked = Reglas.Publicos.CajaUtilizaSaldosDigitados

            CargarMovimientosCajas(-1, -1)
            ugDetalle.AgregarFiltroEnLinea({"NombreCaja"})
            ugDetalle.AgregarTotalesSuma({"PesosSaldoFinal", "PesosSaldoFinalDigit", "PesosSaldoFinalDif",
                                          "ChequesSaldoFinal", "ChequesSaldoFinalDigit", "ChequesSaldoFinalDif",
                                          "TarjetasSaldoFinal", "TarjetasSaldoFinalDigit", "TarjetasSaldoFinalDif",
                                          "TicketsSaldoFinal", "TicketsSaldoFinalDigit", "TicketsSaldoFinalDif",
                                          "DolaresSaldoFinal", "DolaresSaldoFinalDigit", "DolaresSaldoFinalDif",
                                          "BancosSaldoFinal", "BancosSaldoFinalDigit", "BancosSaldoFinalDif",
                                          "BancosDolaresSaldoFinal", "BancosDolaresSaldoFinalDigit", "BancosDolaresSaldoFinalDif"})
            ugMovimientos.InicializaGrilla()
            ugMovimientos.AgregarFiltroEnLinea({"NombreCuentaCaja", "Observacion"})

            PreferenciasLeer(ugDetalle, tsbPreferencias)
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion, New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click_1(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
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


   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCajas))
   End Sub

   Private Sub chbNroPlanilla_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroPlanilla.CheckedChanged
      TryCatched(
         Sub()
            txtNroPlanilla.Enabled = chbNroPlanilla.Checked
            If Not chbNroPlanilla.Checked Then
               txtNroPlanilla.Text = String.Empty
            Else
               txtNroPlanilla.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbCajaUtilizaSaldosDigitados_CheckedChanged(sender As Object, e As EventArgs) Handles chbCajaUtilizaSaldosDigitados.CheckedChanged
      TryCatched(
         Sub()
            ugDetalle.DisplayLayout.Bands(0).Columns.All().
                        Where(Function(c) DirectCast(c, UltraGridColumn).Key.EndsWith("Digit") Or DirectCast(c, UltraGridColumn).Key.EndsWith("Dif")).ToList().
                        ForEach(Sub(c) DirectCast(c, UltraGridColumn).Hidden = Not chbCajaUtilizaSaldosDigitados.Checked)
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCaja.Checked And cmbCajas.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó una Caja aunque activó ese Filtro")
               cmbCajas.Focus()
               Exit Sub
            End If

            If chbNroPlanilla.Checked And txtNroPlanilla.ValorNumericoPorDefecto(0I) = 0 Then
               ShowMessage("ATENCION: NO seleccionó una Planilla aunque activó ese Filtro")
               txtNroPlanilla.Focus()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            Using frm = New ImprimirPlanilla(actual.Sucursal.IdSucursal, dr.Field(Of Integer)("IdCaja"), dr.Field(Of Integer)("NumeroPlanilla"))
               frm.ShowDialog()
            End Using
         End Sub)
   End Sub
   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      TryCatched(
         Sub()
            If tbcPlanailla.SelectedTab Is tbpPlanilla Then
               tbcPlanailla.SelectedTab = tbpMovimientos
            Else
               tbcPlanailla.SelectedTab = tbpPlanilla
            End If
         End Sub)
   End Sub
   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Dim idCaja = dr.Field(Of Integer)("IdCaja")
               Dim nroPlanilla = dr.Field(Of Integer)("NumeroPlanilla")

               CargarPlanillaAnterior(idCaja, nroPlanilla)
               CargarPlanillaActual(idCaja, nroPlanilla)
               CargarSaldosActuales(idCaja, nroPlanilla)

               CargarMovimientosCajas(idCaja, nroPlanilla)
            End If
         End Sub)
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
            dr.Table.Columns.OfType(Of DataColumn).Where(Function(dc) dc.ColumnName.EndsWith("Dif")).ToList().
                  ForEach(Sub(dc)
                             If dr.Field(Of Decimal)(dc) = 0 Then
                                e.Row.Cells(dc.ColumnName).Color(Nothing, Nothing)
                             Else
                                e.Row.Cells(dc.ColumnName).Color(Nothing, Color.OrangeRed)
                             End If
                          End Sub)
         End Sub)
   End Sub


   Private Sub tbcPlanailla_Selected(sender As Object, e As TabControlEventArgs) Handles tbcPlanailla.Selected
      If tbcPlanailla.SelectedTab Is tbpPlanilla Then
         tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
      Else
         tssRegistros.Text = ugMovimientos.CantidadRegistrosParaStatusbar
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now

      If chbCaja.Enabled Then chbCaja.Checked = False

      chbNroPlanilla.Checked = False

      ugMovimientos.ClearFilas()
      ugDetalle.ClearFilas()

      txtNroPlanillaAnterior.Text = "0"
      txtPAFecha.Text = ""
      txtPAEfectivo.Text = "0"
      txtPADolares.Text = "0"
      txtPATickets.Text = "0"
      txtPARetenciones.Text = "0"
      txtPACheques.Text = "0"
      txtPATarjetas.Text = "0"
      txtPABancos.Text = "0"

      txtNroPlanillaActual.Text = "0"
      txtPACFecha.Text = "0"
      txtPACEfectivo.Text = "0"
      txtPACDolares.Text = "0"
      txtPACTickets.Text = "0"
      txtPACRetenciones.Text = "0"
      txtPACCheques.Text = "0"
      txtPACTarjetas.Text = "0"
      txtPACBancos.Text = "0"

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCaja = cmbCajas.ValorSeleccionado(chbCaja, 0I)
      Dim nroPlanilla = txtNroPlanilla.ValorSeleccionado(chbNroPlanilla, 0I)

      Dim oCaja = New Reglas.Cajas()
      ugDetalle.DataSource = oCaja.GetPorRangoFechas(actual.Sucursal.IdSucursal, idCaja, dtpDesde.Value, dtpHasta.Value, nroPlanilla)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargarMovimientosCajas(IdCaja As Integer, NroPlanilla As Integer)
      TryCatched(
         Sub()
            Dim rCajaDetalles = New Reglas.CajaDetalles()
            ugMovimientos.DataSource = rCajaDetalles.GetTodas(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla, "FECHA")
            PlanillaDeCaja.SetearColumnasMovimientos(ugMovimientos, _utilizaCentroCostos)
         End Sub)
   End Sub
   Private Sub CargarSaldosActuales(IdCaja As Integer, NroPlanilla As Integer)

      Dim oCaja = New Reglas.Cajas()
      Dim sPesos = oCaja.GetSaldoPesos(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)
      Dim sDolares = oCaja.GetSaldoDolares(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)
      Dim sTickets = oCaja.GetSaldoTickets(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)
      Dim sCheques = oCaja.GetSaldoCheques(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)
      Dim sTarjetas = oCaja.GetSaldoTarjetas(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)
      Dim sBancos = oCaja.GetSaldoBancos(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)
      Dim sRetenciones = oCaja.GetSaldoRetenciones(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)

      _planillaActual.PesosSaldoFinal = _planillaActual.PesosSaldoInicial + sPesos
      _planillaActual.DolaresSaldoFinal = _planillaActual.DolaresSaldoInicial + sDolares
      _planillaActual.TicketsSaldoFinal = _planillaActual.TicketsSaldoInicial + sTickets
      _planillaActual.ChequesSaldoFinal = _planillaActual.ChequesSaldoInicial + sCheques
      _planillaActual.TarjetasSaldoFinal = _planillaActual.TarjetasSaldoInicial + sTarjetas
      _planillaActual.BancosSaldoInicial = _planillaActual.BancosSaldoInicial + sBancos
      _planillaActual.RetencionesSaldoInicial = _planillaActual.RetencionesSaldoInicial + sRetenciones

   End Sub
   Private Sub CargarPlanillaAnterior(IdCaja As Integer, NroPlanilla As Integer)

      Dim oCaja = New Reglas.Cajas()
      Dim oPlanilla = oCaja.GetPlanilla(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla - 1)

      If oPlanilla IsNot Nothing Then

         With oPlanilla
            txtNroPlanillaAnterior.Text = .NumeroPlanilla.ToString()
            txtPAFecha.Text = .FechaPlanilla.ToString("dd/MM/yyyy")
            txtPAEfectivo.Text = .PesosSaldoFinal.ToString("N2")
            txtPADolares.Text = .DolaresSaldoFinal.ToString("N2")
            txtPATickets.Text = .TicketsSaldoFinal.ToString("N2")
            txtPARetenciones.Text = .RetencionesSaldoFinal.ToString("N2")
            txtPACheques.Text = .ChequesSaldoFinal.ToString("N2")
            txtPATarjetas.Text = .TarjetasSaldoFinal.ToString("N2")
            txtPABancos.Text = .BancosSaldoFinal.ToString("N2")
         End With

      Else
         txtNroPlanillaAnterior.Text = "0"
         txtPAFecha.Text = ""
         txtPAEfectivo.Text = "0"
         txtPADolares.Text = "0"
         txtPATickets.Text = "0"
         txtPARetenciones.Text = "0"
         txtPACheques.Text = "0"
         txtPATarjetas.Text = "0"
         txtPABancos.Text = "0"

      End If

   End Sub

   Private Sub CargarPlanillaActual(IdCaja As Integer, NroPlanilla As Integer)

      Dim oCaja = New Reglas.Cajas()
      Dim oPlanilla = oCaja.GetPlanilla(actual.Sucursal.IdSucursal, IdCaja, NroPlanilla)

      If oPlanilla IsNot Nothing Then

         With oPlanilla

            _planillaActual = oPlanilla

            Dim sPesos As Decimal = oCaja.GetSaldoPesos(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)
            Dim sDolares As Decimal = oCaja.GetSaldoDolares(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)
            Dim sTickets As Decimal = oCaja.GetSaldoTickets(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)
            Dim sCheques As Decimal = oCaja.GetSaldoCheques(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)
            Dim sTarjetas As Decimal = oCaja.GetSaldoTarjetas(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)
            Dim sRetenciones As Decimal = oCaja.GetSaldoRetenciones(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)
            Dim sBancos As Decimal = oCaja.GetSaldoBancos(actual.Sucursal.IdSucursal, IdCaja, Me._planillaActual.NumeroPlanilla)

            txtNroPlanillaActual.Text = _planillaActual.NumeroPlanilla.ToString()
            txtPACFecha.Text = _planillaActual.FechaPlanilla.ToString("dd/MM/yyyy ")

            txtPACEfectivo.Text = (_planillaActual.PesosSaldoInicial + sPesos).ToString("N2")
            txtPACDolares.Text = (_planillaActual.DolaresSaldoInicial + sDolares).ToString("N2")
            txtPACTickets.Text = (_planillaActual.TicketsSaldoInicial + sTickets).ToString("N2")
            txtPACRetenciones.Text = (_planillaActual.RetencionesSaldoInicial + sRetenciones).ToString("N2")
            txtPACCheques.Text = (_planillaActual.ChequesSaldoInicial + sCheques).ToString("N2")
            txtPACTarjetas.Text = (_planillaActual.TarjetasSaldoInicial + sTarjetas).ToString("N2")
            txtPACBancos.Text = (_planillaActual.BancosSaldoInicial + sBancos).ToString("N2")


            _planillaActual.PesosSaldoFinal = _planillaActual.PesosSaldoInicial + sPesos
            _planillaActual.DolaresSaldoFinal = _planillaActual.DolaresSaldoInicial + sDolares
            _planillaActual.TicketsSaldoFinal = _planillaActual.TicketsSaldoInicial + sTickets
            _planillaActual.ChequesSaldoFinal = _planillaActual.ChequesSaldoInicial + sCheques
            _planillaActual.TarjetasSaldoFinal = _planillaActual.TarjetasSaldoInicial + sTarjetas
            _planillaActual.BancosSaldoFinal = _planillaActual.BancosSaldoInicial + sBancos
            _planillaActual.RetencionesSaldoFinal = _planillaActual.RetencionesSaldoInicial + sRetenciones

         End With
      End If

   End Sub

   Public Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)

         If chbCaja.Checked Then
            .AppendFormat(" - Caja: {0}", cmbCajas.Text)
         End If
         If chbNroPlanilla.Checked Then
            .AppendFormat(" - Nro. Planilla: {0}", txtNroPlanilla.Text)
         End If
         If chbCajaUtilizaSaldosDigitados.Checked Then
            .AppendFormat(" - {0}", chbCajaUtilizaSaldosDigitados.Text)
         End If
      End With

      Return filtro.ToString()
   End Function

#End Region

End Class