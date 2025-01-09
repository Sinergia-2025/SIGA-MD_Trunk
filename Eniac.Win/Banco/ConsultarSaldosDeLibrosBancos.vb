Public Class ConsultarSaldosDeLibrosBancos

#Region "Propiedades"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(Sub()

                    _publicos = New Publicos()
                    _publicos.CargaComboMonedas(Me.cmbMonedas)

                    _publicos.CargaComboCuentasBancariasClase(cmbClaseCuenta)

                    _publicos.CargaComboDesdeEnum(Me.cmbActiva, GetType(Entidades.Publicos.SiNoTodos))
                    _publicos.CargaComboDesdeEnum(Me.cmbConSaldo, GetType(Entidades.Publicos.SiNoTodos))
                    cmbActiva.SelectedValue = Entidades.Publicos.SiNoTodos.SI
                    cmbConSaldo.SelectedValue = Entidades.Publicos.SiNoTodos.SI

                    ugDetalle.AgregarFiltroEnLinea({"NombreCuenta"})
                    ugDetalle.AgregarTotalesSuma({"Saldo", "SaldoConciliado", "SaldoDolares", "SaldoConciliadoDolares"})

                    PreferenciasLeer(ugDetalle, tsbPreferencias)

                    RefrescarDatosGrilla()
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

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() CargaGrillaDetalle())
   End Sub

   Private Sub chbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles chbMoneda.CheckedChanged
      TryCatched(Sub() chbMoneda.FiltroCheckedChanged(cmbMonedas))
   End Sub
   Private Sub chbClase_CheckedChanged(sender As Object, e As EventArgs) Handles chbClase.CheckedChanged
      TryCatched(Sub() chbClase.FiltroCheckedChanged(cmbClaseCuenta))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.Exportar(Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
         End Sub)
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.Exportar(Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()
      ugDetalle.ClearFilas()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      dpFechaHasta.Value = Date.Today

      'cmbMonedas.SelectedIndex = -1
      chbMoneda.Checked = False
      chbClase.Checked = False

      cmbActiva.SelectedValue = Entidades.Publicos.SiNoTodos.SI
      cmbConSaldo.SelectedValue = Entidades.Publicos.SiNoTodos.SI

      dpFechaHasta.Select()
      'dpFechaSaldo.Focus()

   End Sub

   Public Sub CargaGrillaDetalle()
      Dim rLibroBancos = New Reglas.LibroBancos()
      Dim dt = rLibroBancos.GetSaldosCuentasBancarias(actual.Sucursal.Id,
                                                      cmbMonedas.ValorSeleccionado(chbMoneda, -1),
                                                      dpFechaHasta.Value,
                                                      cmbActiva.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                      cmbConSaldo.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                      cmbClaseCuenta.ValorSeleccionado(chbClase, -1))

      ugDetalle.DataSource = dt
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub


   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         .AppendFormat("Fecha Hasta: {0:dd/MM/yyyy}", Me.dpFechaHasta.Value)

         If Me.cmbActiva.Text <> "TODOS" Then
            .AppendFormat(" - Activas: {0} ", Me.cmbActiva.SelectedValue)
         End If
         If Me.chbMoneda.Checked Then
            .AppendFormat(" - Moneda: {0}", Me.cmbMonedas.Text)
         End If
         If Me.chbClase.Checked Then
            .AppendFormat(" - Clase: {0}", Me.cmbClaseCuenta.Text)
         End If
         If Me.cmbConSaldo.Text <> "TODOS" Then
            .AppendFormat(" - Con Saldo: {0}", Me.cmbConSaldo.Text)
         End If

      End With
      Return filtro.ToString().Trim()
   End Function
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo As String

            Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

            'Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
            'Me.UltraPrintPreviewDialog1.Name = Me.Text
            Dim UltraPrintPreviewD As Printing.UltraPrintPreviewDialog
            UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
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
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

            ' Me.UltraPrintPreviewDialog1.ShowDialog()
            UltraPrintPreviewD.MdiParent = Me.MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Focus()
         End Sub)
   End Sub

#End Region

End Class