Public Class ConsultarCtaCteClientesDH

#Region "Campos"

    Private _publicos As Publicos
    Private _tit As Dictionary(Of String, String)
    Public ConsultarAutomaticamenteDesdeRecibos As Boolean = False

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        Try

            Me._publicos = New Publicos()

            Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
            Me.cmbGrabanLibro.Items.Insert(1, "SI")
            Me.cmbGrabanLibro.Items.Insert(2, "NO")
            Me.cmbGrabanLibro.SelectedIndex = 0

            Me._publicos.CargaComboGrupos(Me.cmbGrupos)
            Me.cmbGrupos.SelectedIndex = -1

            ugDetalle.AgregarFiltroEnLinea({"Observacion"})

            PreferenciasLeer(ugDetalle)

            _tit = GetColumnasVisiblesGrilla(ugDetalle)

            Me._publicos.CargaComboMonedas(Me.cmbMoneda)
            Me.cmbMoneda.SelectedIndex = 1

            _publicos.CargaComboDesdeEnum(cmbTipoConversion, GetType(Entidades.Moneda_TipoConversion))
            Me.cmbTipoConversion.SelectedIndex = 0

            Me.cmbSucursal.Initializar(False, IdFuncion)
            Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            If ConsultarAutomaticamenteDesdeRecibos Then
                Me.bscCodigoCliente.PresionarBoton()
                Me.btnConsultar.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Private Sub ConsultarCtaCteClientesDH_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.bscCliente.Focus()
    End Sub
#End Region

#Region "Eventos"

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.RefrescarDatosGrilla()

            Me.tssRegistros.Text = "0 Registros"

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

            If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
                MessageBox.Show("ATENCION: Debe seleccionar un Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCliente.Focus()
                Exit Sub
            End If

            If Me.chbFechas.Checked And Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
                MessageBox.Show("ATENCION: La fecha 'Desde' NO puede ser mayor la la fecha 'Hasta'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpDesde.Focus()
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
                Me.btnConsultar.Focus()
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
            Me.tssRegistros.Text = "0 Registros"
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
        Try
            Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
                If e.Cell.Column.Key = "Ver" Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
                    oTipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())

                    If oTipoComprobante.EsRecibo = True Then
                        'imprime los recibos
                        Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
                        Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                             dr("IdTipoComprobante").ToString(),
                                                                             dr("Letra").ToString(),
                                                                             Integer.Parse(dr("CentroEmisor").ToString()),
                                                                             Long.Parse(dr("NumeroComprobante").ToString()))
                        Dim imp As RecibosImprimir = New RecibosImprimir()
                        imp.ImprimirRecibo(ctacte, True)
                    Else
                        'imprime los comprobantes que no son recibos
                        Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
                        Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                      dr("IdTipoComprobante").ToString(),
                                                                      dr("Letra").ToString(),
                                                                      Short.Parse(dr("CentroEmisor").ToString()),
                                                                      Long.Parse(dr("NumeroComprobante").ToString()))
                        Dim oImpr As Impresion = New Impresion(venta)

                        If Not oTipoComprobante.EsFiscal Then
                            oImpr.ImprimirComprobanteNoFiscal(True)
                        Else
                            oImpr.ReImprimirComprobanteFiscal()
                        End If
                    End If
                ElseIf e.Cell.Column.Key = "CantidadInvocadosInvocadores" Then
                    Using oComprobantesInvocados =
                     New FacturablesInvocados(dr.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                              dr.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                              dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                              dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                              dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
                        oComprobantesInvocados.ShowDialog()
                    End Using

                End If
            End If
        Catch ex As Exception
            ShowError(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
        Try
            Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
            KardexComprobCtaCteClientesUC1.RefrescarDatosGrilla()
            If dr IsNot Nothing Then
                If Not Boolean.Parse(dr("EsRecibo").ToString()) Then
                    KardexComprobCtaCteClientesUC1.CargaGrillaDetalle(Integer.Parse(dr("IdSucursal").ToString()),
                                                                 dr("IdTipoComprobante").ToString(),
                                                                 dr("Letra").ToString(),
                                                                 Short.Parse(dr("CentroEmisor").ToString()),
                                                                 Long.Parse(dr("NumeroComprobante").ToString()))
                End If
            End If
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub
    Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
        Dim codigoCliente As Long = -1
        Try
            Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes
            If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
                codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
            End If
            Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarDatosCliente(e.FilaDevuelta)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
        Try
            Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes
            Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarDatosCliente(e.FilaDevuelta)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechas.CheckedChanged

        Me.dtpDesde.Enabled = Me.chbFechas.Checked
        Me.dtpHasta.Enabled = Me.chbFechas.Checked

        Me.lblSaldoActual.Visible = Me.chbFechas.Checked
        Me.txtSaldoActual.Visible = Me.chbFechas.Checked

        Me.lblSaldoInicial.Visible = Me.chbFechas.Checked
        Me.txtSaldoInicial.Visible = Me.chbFechas.Checked

        pnlSaldoInicial.Visible = chbFechas.Checked

        If Me.chbFechas.Checked Then
            Me.dtpDesde.Value = Date.Now
            Me.dtpHasta.Value = Date.Now
            Me.txtSaldoActual.Text = "0.00"
            Me.txtSaldoInicial.Text = "0.00"
            Me.txtSaldoFinal.Text = "0.00"
        End If

        Me.dtpDesde.Focus()

    End Sub

    Private Sub ConsultarCtaCteClientesDH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        '-- REQ-33040.- --
        Select Case e.KeyCode
            Case Keys.F5
                tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
            Case Keys.Escape
                If ConsultarAutomaticamenteDesdeRecibos Then
                    Close()
                End If
        End Select
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

        Try

            If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo As String

            Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

            Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
            Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
            Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
            Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
            Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
            Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
            Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
            Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")


            Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
            UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
            UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"
            UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Me.Text
            UltraPrintPreviewD.MdiParent = Me.MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
        Try
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim excelExport As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Publicos.NombreEmpresaImpresion)
            excelExport.Exportar(String.Format("{0}.xls", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
        Try
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim excelExport As UltraGridExportarPDF = New UltraGridExportarPDF(UltraGridDocumentExporter1, Publicos.NombreEmpresaImpresion)
            excelExport.Exportar(String.Format("{0}.pdf", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
        Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
    End Sub

    Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
        Try
            PreferenciasCargar(ugDetalle)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
        Try

            If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Filtros As String = String.Empty

            Dim dt As DataTable
            Dim Cliente As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text.ToString()))

            Me.Cursor = Cursors.WaitCursor

            Filtros = CargarFiltrosImpresion()

            dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)


         If Me.cmbGrabanLibro.Text = "TODOS" Or Me.cmbGrabanLibro.Text = "SI" Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         Else
            If Reglas.Publicos.CuentasCorrientes.Informes.NombreFantasia Then
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            Else
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", ""))
            End If
         End If

         ' End If


         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicial", Me.txtSaldoInicial.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", Me.txtSaldoActual.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinal", Me.txtSaldoFinal.Text))

            Dim frmImprime As VisorReportes
            Dim reporte As Entidades.InformePersonalizadoResuelto

            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfConsultarCtaCteClientesDH, "Eniac.Win.ConsultarCtaCteClientesDH.rdlc")

            frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesDH", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias

            frmImprime.Text = Me.Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Destinatarios = Cliente.CorreoElectronico
            frmImprime.Show()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
        Try
            Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

            If Not Me.chbGrupo.Checked Then
                Me.cmbGrupos.SelectedIndex = -1
            Else
                If Me.cmbGrupos.Items.Count > 0 Then
                    Me.cmbGrupos.SelectedIndex = 0
                End If
            End If

            Me.cmbGrupos.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbTipoConversión_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoConversion.SelectedIndexChanged
        Try
            If Me.cmbTipoConversion.SelectedIndex = 1 Then
                Me.txtCotizacionDolar.Visible = True
                Me.lblCotizacionDolar.Visible = True
                txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
            Else
                Me.txtCotizacionDolar.Visible = False
                Me.lblCotizacionDolar.Visible = False
                txtCotizacionDolar.Text = "1.00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
        Try
            If Me.cmbMoneda.SelectedIndex = 0 Then
                Me.cmbTipoConversion.Visible = True
                Me.txtCotizacionDolar.Visible = cmbTipoConversion.SelectedIndex = 1
                Me.lblCotizacionDolar.Visible = txtCotizacionDolar.Visible
                txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
            Else
                Me.cmbTipoConversion.Visible = False
                Me.txtCotizacionDolar.Visible = False
                Me.lblCotizacionDolar.Visible = False
                txtCotizacionDolar.Text = "1.00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#End Region

#Region "Metodos"
    Public Sub InicializarPublicos()
        Me._publicos = New Publicos
    End Sub

    Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

        Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
        Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
        Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
        Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString()
        Me.bscCliente.Enabled = False
        Me.bscCodigoCliente.Enabled = False

    End Sub

    Private Sub RefrescarDatosGrilla()

        Me.cmbGrabanLibro.SelectedIndex = 0

        Me.bscCodigoCliente.Enabled = True
        Me.bscCodigoCliente.Text = String.Empty
        Me.bscCliente.Enabled = True
        Me.bscCliente.Text = String.Empty
        Me.chbExcluirMinutas.Checked = False
        Me.chbFechas.Checked = False
        Me.dtpDesde.Value = Date.Now
        Me.dtpHasta.Value = Date.Now
        Me.chbGrupo.Checked = False
        Me.txtTelefono.Text = String.Empty

        Me.chbExcluirMinutas.Checked = True

        If TypeOf (ugDetalle.DataSource) Is DataTable Then
            DirectCast(ugDetalle.DataSource, DataTable).Clear()
        End If

        KardexComprobCtaCteClientesUC1.RefrescarDatosGrilla()

        Me.txtSaldoFinal.Text = "0.00"

        cmbSucursal.Refrescar()

        Me.cmbMoneda.SelectedIndex = 1

        Me.bscCliente.Focus()

    End Sub

    Private Sub CargaGrillaDetalle()

        Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

        Dim Saldo As Decimal = 0

        Dim IdCliente As Long = 0

        Dim Desde As Date? = Nothing
        Dim Hasta As Date? = Nothing
        Dim ExcluirMinutas As String = "NO"
        Dim excluirPreComprobantes As Boolean = Me.chbExcluirPreComprobantes.Checked

        Dim FechaUtilizada As String = String.Empty
        Dim Grupo As String = String.Empty
        Dim tipoConversion As Entidades.Moneda_TipoConversion = Entidades.Moneda_TipoConversion.Comprobante

        Try

            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         Dim graba As Boolean? = Nothing
         If Me.cmbGrabanLibro.Text <> "TODOS" Then
            graba = Me.cmbGrabanLibro.Text = "SI"
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
                excluirPreComprobantes = True
            End If

         Me.txtSaldoActual.Text = oCtaCte.GetSaldoCliente(cmbSucursal.GetSucursales(), IdCliente, Nothing, False, "TODOS", graba, Nothing, "", excluirPreComprobantes, 0, 0).ToString("#,##0.00")

         If Me.chbFechas.Checked Then
                Desde = Me.dtpDesde.Value
                Hasta = Me.dtpHasta.Value
            Me.txtSaldoInicial.Text = oCtaCte.GetSaldoCliente(cmbSucursal.GetSucursales(), IdCliente, Desde.Value.AddDays(-1), False, "TODOS", graba, Nothing, "", excluirPreComprobantes, 0, 0).ToString("#,##0.00")
         Else
                Me.txtSaldoInicial.Text = "0.00"
            End If

            If Me.cmbGrupos.Enabled Then
                Grupo = Me.cmbGrupos.SelectedValue.ToString()
            End If

            If Me.chbExcluirMinutas.Checked Then
                ExcluirMinutas = "SI"
            End If

            FechaUtilizada = "EMISION"

            If Me.cmbTipoConversion.Visible Then
                tipoConversion = DirectCast(Me.cmbTipoConversion.SelectedValue, Entidades.Moneda_TipoConversion)
            End If

            Dim dtDetalle As DataTable ', dt As DataTable, drCl As DataRow


            dtDetalle = oCtaCte.GetPorCliente(cmbSucursal.GetSucursales(),
                                           IdCliente,
                                           FechaUtilizada,
                                           Desde, Hasta,
                                           Me.cmbGrabanLibro.Text,
                                           Grupo,
                                           ExcluirMinutas,
                                            Integer.Parse(cmbMoneda.SelectedValue.ToString()),
                                                   tipoConversion,
                                                   Decimal.Parse(Me.txtCotizacionDolar.Text.ToString()),
                                                   excluirPreComprobantes)

            dtDetalle.Columns.Add("Ver", GetType(String))
            dtDetalle.Columns.Add("Debe", GetType(Decimal))
            dtDetalle.Columns.Add("Haber", GetType(Decimal))

            Saldo = Decimal.Parse(Me.txtSaldoInicial.Text)

            For Each dr As DataRow In dtDetalle.Rows
                dr("Ver") = "..."
                Dim importeTotal As Decimal = If(IsNumeric(dr("ImporteTotal")), Decimal.Parse(dr("ImporteTotal").ToString()), 0)
                If importeTotal > 0 Then
                    dr("Debe") = importeTotal
                Else
                    dr("Haber") = importeTotal * -1
                End If

                Saldo = Saldo + importeTotal

            dr("Saldo") = Saldo


         Next

         ugDetalle.DataSource = dtDetalle
            AjustarColumnasGrilla(ugDetalle, _tit)

            Me.txtSaldoFinal.Text = Saldo.ToString("N2")

            Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registro/s"

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Function CargarFiltrosImpresion() As String
        Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

        With filtro
            filtro.AppendFormat("Cliente: {0} - {1}", Me.bscCodigoCliente.Text, Me.bscCliente.Text)

            If Me.chbFechas.Checked Then
                filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
            End If

            '0 Es TODOS
            If Me.cmbGrabanLibro.SelectedIndex > 0 Then
                filtro.AppendFormat(" - Graban Libro: {0}", Me.cmbGrabanLibro.Text)
            End If

            If Me.chbGrupo.Checked Then
                filtro.AppendFormat(" - Grupo: {0}", Me.cmbGrupos.Text)
            End If

            If chbExcluirMinutas.Checked Then
                filtro.AppendFormat(" - Excluir Minutas")
            End If

            If chbExcluirPreComprobantes.Checked Then
                filtro.AppendFormat(" - Excluir PreComprobantes")
            End If
        End With
        Return filtro.ToString.Trim().Trim("-"c)
    End Function


#End Region

End Class