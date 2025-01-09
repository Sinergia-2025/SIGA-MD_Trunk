Public Class InfMovimientosBancarios

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboGruposDeCuentas(cmbGrupos)
            _publicos.CargaComboMonedas(cmbMonedas)
            _publicos.CargaComboDesdeEnum(cmbTipoFechaFiltro, GetType(Entidades.LibroBanco.TiposFechasLibrosBancos))
            cmbTipoFechaFiltro.SelectedValue = Entidades.LibroBanco.TiposFechasLibrosBancos.FechaAplicacion

            cmbMonedas.SelectedValue = 1  'Pesos

            ugDetalle.AgregarFiltroEnLinea({"NombreCuentaBanco", "DescCheque", "Observacion"})
            ugDetalle.AgregarTotalesSuma({"Importe"})

            _publicos.CargaComboDesdeEnum(cmbConciliado, GetType(Entidades.Publicos.SiNoTodos))
            cmbConciliado.SelectedIndex = 0

            'CargarColumnasASumar()
            RefrescarFiltros()

            PreferenciasLeer(ugDetalle, tsbPreferencias)
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

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarFiltros())
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         If Me.chbCuentaBancaria.Checked Then
            .AppendFormat(" Cuenta Bancaria: {0} ", Me.bscCuentaBancaria.Text)
         Else
            .AppendFormat(" Moneda: {0} ", Me.cmbMonedas.Text)
         End If

         .AppendFormat(" - Desde: {0} Hasta: {1} - {2} ", Me.dtpDesde.Value.ToString("dd/MM/yyyy"), Me.dtpHasta.Value.ToString("dd/MM/yyyy"), Me.cmbTipoFechaFiltro.Text)

         If Me.chbCuentaBancaria.Checked Then
            .AppendFormat(" - Cuenta: {0}  ", Me.bscCuentaBancaria.Text)
         End If

         If Me.chbCuentaDeCaja.Checked Then
            .AppendFormat(" - Cuenta Movimineto: {0} - {1} ", Me.bscCodigoCuenta.Text, Me.bscNombreCuenta.Text)
         End If

         If Me.chbGrupo.Checked Then
            .AppendFormat(" - Grupo: {0} ", Me.cmbGrupos.SelectedValue.ToString())
         End If

         .AppendFormat(" - Conciliados: {0}", DirectCast(Me.cmbConciliado.SelectedValue, Entidades.Publicos.SiNoTodos))


         If Me.optPosdatados.Checked Then
            .AppendFormat(" - Posdatados: Si")
         ElseIf Me.optNoPosdatados.Checked Then
            .AppendFormat(" - Posdatados: No")
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(Me.components)
            UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Text

            UltraGridPrintDocument1.Header.TextCenter = Titulo
            UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
            UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
            UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
            UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewD.MdiParent = Me.MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Focus()
         End Sub)

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      TryCatched(Sub() chbCuentaBancaria.FiltroCheckedChanged(bscCuentaBancaria, bscCuentaBancaria))
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancaria)
            bscCuentaBancaria.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancaria.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscCuentaBancaria.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            End If
         End Sub)
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCuentaDeCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaDeCaja.CheckedChanged
      TryCatched(Sub() chbCuentaDeCaja.FiltroCheckedChanged(bscCodigoCuenta, bscNombreCuenta))
   End Sub

   Private Sub bscCodigoCuenta_BuscadorClick() Handles bscCodigoCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCodigoCuenta)
            bscCodigoCuenta.Datos = New Reglas.CuentasBancos().GetTodosPorCodigo(bscCodigoCuenta.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscNombreCuenta_BuscadorClick() Handles bscNombreCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscNombreCuenta)
            bscNombreCuenta.Datos = New Reglas.CuentasBancos().GetTodosPorNombre(bscNombreCuenta.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCuenta.BuscadorSeleccion, bscNombreCuenta.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCuenta(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCuentaBancaria.Checked And Not bscCuentaBancaria.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó una Cuenta Bancaria aunque activó ese Filtro")
               bscCuentaBancaria.Focus()
               Exit Sub
            End If
            If chbCuentaDeCaja.Checked And Not bscCodigoCuenta.Selecciono And Not bscNombreCuenta.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó una Cuenta aunque activó ese Filtro")
               bscCodigoCuenta.Focus()
               Exit Sub
            End If
            If chbGrupo.Checked AndAlso cmbGrupos.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Grupo de Cuenta aunque activó ese Filtro")
               cmbGrupos.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("NO hay registros que cumplan con la selección !!!")
               Exit Sub
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      TryCatched(Sub() chbGrupo.FiltroCheckedChanged(cmbGrupos))
   End Sub
#End Region

#Region "Metodos"

   Private Sub RefrescarFiltros()

      cmbMonedas.SelectedValue = 1  'Pesos
      cmbConciliado.SelectedIndex = 0
      optPosTodos.Checked = True
      chbCuentaBancaria.Checked = False
      chbGrupo.Checked = False
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now.AddDays(-Reglas.Publicos.DiasVisualizacionLibroBanco)
      dtpHasta.Value = Date.Now

      cmbTipoFechaFiltro.SelectedValue = Entidades.LibroBanco.TiposFechasLibrosBancos.FechaAplicacion

      chbCuentaDeCaja.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      btnConsultar.Focus()
   End Sub

   Private Sub CargarDatosCuenta(dr As DataGridViewRow)
      bscCodigoCuenta.Text = dr.Cells("idCuentaBanco").Value.ToString()
      bscNombreCuenta.Text = dr.Cells("NombreCuentaBanco").Value.ToString()
      bscCodigoCuenta.Enabled = False
      bscNombreCuenta.Enabled = False
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idMoneda = cmbMonedas.ValorSeleccionado(Of Integer)()
      Dim posdatado = If(optPosdatados.Checked, "SI", If(optNoPosdatados.Checked, "NO", "Todos"))
      Dim idCuentaBancaria = If(chbCuentaBancaria.Checked, Integer.Parse(bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()), 0I)
      Dim idCuentaDeBanco = If(chbCuentaDeCaja.Checked, bscCodigoCuenta.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idGrupoCuenta = cmbGrupos.ValorSeleccionado(chbGrupo, String.Empty)

      Dim rLibroBancos = New Reglas.LibroBancos()

      Dim dt = rLibroBancos.GetMovimientos(actual.Sucursal.Id,
                                           idMoneda, idCuentaBancaria,
                                           dtpDesde.Value, dtpHasta.Value,
                                           cmbTipoFechaFiltro.ValorSeleccionado(Of Entidades.LibroBanco.TiposFechasLibrosBancos),
                                           cmbConciliado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                           posdatado, idCuentaDeBanco, idGrupoCuenta)

      ugDetalle.DataSource = dt

      ugDetalle.DisplayLayout.Bands(0).Columns("NombreCuenta").Hidden = chbCuentaBancaria.Checked

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub
#End Region

End Class