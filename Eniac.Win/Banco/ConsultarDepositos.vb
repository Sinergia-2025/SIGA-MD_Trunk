Public Class ConsultarDepositos

#Region "Constantes"
   Private Const funcionActual As String = "ConsultarDepositos"
   'Private Const funcionAnularComprobante As String = "AnularComprobante"
#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _puedeAnularComprobantes As Boolean
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Me.dtpDesde.Value = Date.Now
         'Me.dtpHasta.Value = Date.Now
         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "BANCO", "", "", "")

         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         Me.cmbCajas.SelectedIndex = -1

         If Not Publicos.TieneModuloContabilidad Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
         End If

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"IdTipoComprobante", "NombreCaja", "NombreCuenta"}, {"Ver"})

         Me.CargarColumnasASumar()

         PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarDepositos_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbCuentaBancaria.Checked Then
            Filtros = Filtros & " / Cuenta Bancaria: " & Me.bscCuentaBancaria.Text
         End If

         'If Me.cmbUsuario.Enabled Then
         '   Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
         'End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         'Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         'Me.UltraPrintPreviewDialog1.Name = Me.Text
         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text


         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         ' Me.UltraPrintPreviewDialog1.ShowDialog()
         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprobante.CheckedChanged
      Me.cmbTiposComprobantes.Enabled = chbComprobante.Checked
      If chbComprobante.Checked = False Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      Try
         Me.bscCuentaBancaria.Enabled = Me.chbCuentaBancaria.Checked

         If Not Me.chbCuentaBancaria.Checked Then
            Me.bscCuentaBancaria.Text = ""
         Else
            Me.bscCuentaBancaria.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancaria)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancaria.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancaria.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion

      Try

         If Not Me.bscCuentaBancaria.FilaDevuelta Is Nothing Then
            Me.bscCuentaBancaria.Text = Me.bscCuentaBancaria.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancaria.Enabled = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCuentaBancaria.Checked And Not Me.bscCuentaBancaria.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una Cuenta Bancaria aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaBancaria.Focus()
            Exit Sub
         End If
         If Me.chbComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaBancaria.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

      If e.Cell.Column.Key = "Ver" And e.Cell.Row.ListObject IsNot Nothing Then

         Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDepositos As Reglas.Depositos = New Reglas.Depositos()

            Dim Deposito As Entidades.Deposito

            Deposito = oDepositos.GetUna(actual.Sucursal.Id,
                                         Long.Parse(e.Cell.Row.Cells("NumeroDeposito").Value.ToString()),
                                         e.Cell.Row.Cells("IdTipoComprobante").Value.ToString())

            Dim di As DepositosImprimir = New DepositosImprimir()

            di.ImprimirDeposito(Deposito)

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      Try
         Me.cmbCajas.Enabled = chbCaja.Checked
         If chbCaja.Checked = False Then
            Me.cmbCajas.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.chbCuentaBancaria.Checked = False
      Me.chbCaja.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'Me.txtSubtotal.Text = "0.00"
      'Me.txtImpuestos.Text = "0.00"
      'Me.txtTotal.Text = "0.00"

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oDeposito As Reglas.Depositos = New Reglas.Depositos()

      Try

         Dim IdCuentaBancaria As Integer = 0

         If Me.bscCuentaBancaria.Selecciono Then
            IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
         End If
         Dim IdEstado As String = "TODOS"

         Dim _tipoComprobante As String
         If (Me.chbComprobante.Checked) Then
            _tipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         Else
            _tipoComprobante = "TODOS"
         End If

         Dim IdCaja As Integer = 0
         If Me.chbCaja.Checked Then
            IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
         End If

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oDeposito.GetPorRangoFechas(actual.Sucursal.Id,
                                                 Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                 IdCuentaBancaria,
                                                 IdEstado, IdCaja, _tipoComprobante)

         dt = Me.CrearDT()

         ''Tengo que hacerlo porque por algun motivo se reacomodan.
         'Me.SetColumnIndexes()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Ver") = "..."

            drCl("NumeroDeposito") = Long.Parse(dr("NumeroDeposito").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("NombreCuenta") = dr("NombreCuenta").ToString()
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("FechaAplicado") = Date.Parse(dr("FechaAplicado").ToString())
            drCl("ImportePesos") = Decimal.Parse(dr("ImportePesos").ToString())
            drCl("ImporteDolares") = Decimal.Parse(dr("ImporteDolares").ToString())
            drCl("ImporteTickets") = Decimal.Parse(dr("ImporteTickets").ToString())
            drCl("ImporteTarjetas") = Decimal.Parse(dr("ImporteTarjetas").ToString())
            drCl("ImporteCheques") = Decimal.Parse(dr("ImporteCheques").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("UsoFechaCheque") = Boolean.Parse(dr("UsoFechaCheque").ToString())
            drCl("Observacion") = dr("Observacion").ToString()
            drCl("Descripcion") = dr("Descripcion").ToString()
            If dr("IdCuentaBancariaDestino").ToString() <> "" Then
               drCl("IdCuentaBancariaDestino") = Integer.Parse(dr("IdCuentaBancariaDestino").ToString())
            End If
            If dr("NombreCuentaDestino").ToString() <> "" Then
               drCl("NombreCuentaDestino") = dr("NombreCuentaDestino").ToString()
            End If

            drCl("IdPlanCuenta") = dr("IdPlanCuenta")
            drCl("IdAsiento") = dr("IdAsiento")
            drCl("NombreCaja") = dr("NombreCaja")
            dt.Rows.Add(drCl)

            'TotalNeto = TotalNeto + Decimal.Parse(drCl("SubTotal").ToString())
            'TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("TotalImpuestos").ToString())
            'Total = Total + Decimal.Parse(drCl("ImporteTotal").ToString())

         Next

         'Me.txtSubtotal.Text = TotalNeto.ToString("#,##0.00")
         'Me.txtImpuestos.Text = TotalImpuestos.ToString("#,##0.00")
         'Me.txtTotal.Text = Total.ToString("#,##0.00")

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub SetColumnIndexes()

      'With Me.ugDetalle
      '   .DisplayLayout.Bands(0).Columns("Ver").Index = 0
      '   .DisplayLayout.Bands(0).Columns("NumeroDeposito").Index = 1
      '   .DisplayLayout.Bands(0).Columns("Fecha").Index = 2
      '   .DisplayLayout.Bands(0).Columns("FechaAplicado").Index = 3
      '   .DisplayLayout.Bands(0).Columns("ImportePesos").Index = 4
      '   .DisplayLayout.Bands(0).Columns("ImporteDolares").Index = 5
      '   .DisplayLayout.Bands(0).Columns("ImporteTickets").Index = 6
      '   .DisplayLayout.Bands(0).Columns("ImporteTarjetas").Index = 7
      '   .DisplayLayout.Bands(0).Columns("ImporteCheques").Index = 8
      '   .DisplayLayout.Bands(0).Columns("ImporteTotal").Index = 9
      '   .DisplayLayout.Bands(0).Columns("UsoFechaCheque").Index = 10
      '   .DisplayLayout.Bands(0).Columns("Observacion").Index = 11

      '   'Ocultas
      '   .DisplayLayout.Bands(0).Columns("IdSucursal").Index = 12
      '   .DisplayLayout.Bands(0).Columns("ImporteEuros").Index = 13
      '   .DisplayLayout.Bands(0).Columns("IdCuentaBancaria").Index = 14

      '   .DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = True
      'End With

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         '.Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("NumeroDeposito", GetType(Long))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("NombreCuenta", GetType(String))
         .Columns.Add("IdCuentaBancariaDestino", GetType(Integer))
         .Columns.Add("NombreCuentaDestino", GetType(String))
         .Columns.Add("Fecha", GetType(DateTime))
         .Columns.Add("FechaAplicado", GetType(DateTime))
         .Columns.Add("ImportePesos", GetType(Decimal))
         .Columns.Add("ImporteDolares", GetType(Decimal))
         .Columns.Add("ImporteTickets", GetType(Decimal))
         .Columns.Add("ImporteTarjetas", GetType(Decimal))
         .Columns.Add("ImporteCheques", GetType(Decimal))
         '.Columns.Add("ImporteEuros", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("UsoFechaCheque", GetType(Boolean))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Integer))
         .Columns.Add("Descripcion", GetType(String))
         .Columns.Add("NombreCaja", GetType(String))

      End With

      Return dtTemp

   End Function

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImportePesos")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImportePesos", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDolares")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteDolares", SummaryType.Sum, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTickets")
      Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTickets", SummaryType.Sum, columnToSummarize3)
      summary3.DisplayFormat = "{0:N2}"
      summary3.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTarjetas")
      Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTarjetas", SummaryType.Sum, columnToSummarize4)
      summary4.DisplayFormat = "{0:N2}"
      summary4.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize5 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteCheques")
      Dim summary5 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteCheques", SummaryType.Sum, columnToSummarize5)
      summary5.DisplayFormat = "{0:N2}"
      summary5.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize6 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
      Dim summary6 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize6)
      summary6.DisplayFormat = "{0:N2}"
      summary6.Appearance.TextHAlign = HAlign.Right


      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub


#End Region

End Class