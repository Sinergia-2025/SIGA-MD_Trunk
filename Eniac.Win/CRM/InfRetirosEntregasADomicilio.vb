Public Class InfRetirosEntregasADomicilio

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            PreferenciasLeer(ugDetalle, tsbPreferencias)
            _publicos = New Publicos()

            dtpDesde.Value = dtpDesde.MaxDate
            CargaGrillaDetalle()

            RefrescarGrillaDetalle()
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

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarGrillaDetalle(),
                 onFinallyAction:=Sub(owner) tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Filtros = "Desde el  " & dtpDesde.Value.ToString("dd/MM/yyyy") & "  Hasta el " & dtpHasta.Value.ToString("dd/MM/yyyy")

            Dim Titulo As String

            If radEnviadas.Checked Then
               Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + "HOJA DE RUTA" + Environment.NewLine + Filtros
            Else
               Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + "HOJA DE RETIROS" + Environment.NewLine + Filtros
            End If

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
            UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Text

            UltraPrintPreviewDialog1.Name = Text
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

            UltraPrintPreviewD.MdiParent = MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Select()
         End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, ""))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, ""))
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            CargaGrillaDetalle()
            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Select()
            Else
               ShowMessage("¡¡¡NO hay registros que cumplan con la seleccion !!!")
               Exit Sub
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarGrillaDetalle()

      chbMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      radEnviadas.Checked = True

      ugDetalle.ClearFilas()
      dtpDesde.Select()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idSucursal As Integer = 0
      Dim tipoFechaFiltro = If(radEnviadas.Checked, Entidades.CRMNovedad.TipoFechaFiltro.FechaHoraEntrega, Entidades.CRMNovedad.TipoFechaFiltro.FechaHoraRetiro)

      Dim desdeFechaNovedad As Date?, hastaFechaNovedad As Date?, nullFechaNovedad As Boolean
      Dim desdeFechaHoraEnvioGarantia As Date?, hastaFechaHoraEnvioGarantia As Date?, nullFechaHoraEnvioGarantia As Boolean
      Dim desdeFechaHoraRetiroGarantia As Date?, hastaFechaHoraRetiroGarantia As Date?, nullFechaHoraRetiroGarantia As Boolean
      Dim desdeFechaHoraRetiro As Date?, hastaFechaHoraRetiro As Date?, nullFechaHoraRetiro As Boolean
      Dim desdeFechaHoraEntrega As Date?, hastaFechaHoraEntrega As Date?, nullFechaHoraEntrega As Boolean

      If radEnviadas.Checked Then
         desdeFechaHoraEntrega = dtpDesde.Value
         hastaFechaHoraEntrega = dtpHasta.Value
      ElseIf radRetiradas.Checked Then
         desdeFechaHoraRetiro = dtpDesde.Value
         hastaFechaHoraRetiro = dtpHasta.Value
      End If

      Dim rCRM = New Reglas.CRMNovedades()
      Dim dtDetalle = rCRM.GetInfCRMService(idSucursal,
                                            desdeFechaNovedad, hastaFechaNovedad, nullFechaNovedad,
                                            desdeFechaHoraEnvioGarantia, hastaFechaHoraEnvioGarantia, nullFechaHoraEnvioGarantia,
                                            desdeFechaHoraRetiroGarantia, hastaFechaHoraRetiroGarantia, nullFechaHoraRetiroGarantia,
                                            desdeFechaHoraRetiro, hastaFechaHoraRetiro, nullFechaHoraRetiro,
                                            desdeFechaHoraEntrega, hastaFechaHoraEntrega, nullFechaHoraEntrega,
                                            String.Empty, 0, 0, 0) 'idProducto, idEstadoNovedad, idProveedorService, idCliente

      ugDetalle.DataSource = dtDetalle

      FormatearGrilla()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Public Sub FormatearGrilla()
      TryCatched(
         Sub()
            ugDetalle.DisplayLayout.Bands(0).Columns("FechaEntregado_Fecha").Hidden = Not radEnviadas.Checked
            ugDetalle.DisplayLayout.Bands(0).Columns("FechaEntregado_Hora").Hidden = Not radEnviadas.Checked
            ugDetalle.DisplayLayout.Bands(0).Columns("FechaRetiro_Fecha").Hidden = radEnviadas.Checked
            ugDetalle.DisplayLayout.Bands(0).Columns("FechaRetiro_Hora").Hidden = radEnviadas.Checked
         End Sub)
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception

         chbMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub

#End Region

End Class