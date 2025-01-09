#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ConsultarCtaCteDetClientesDH

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _utilizaIntereses As Boolean
   Public ConsultarAutomaticamenteDesdeRecibos As Boolean = False
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         _utilizaIntereses = New Reglas.Categorias().CategoriasConInteres().Count > 0
         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1


         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         ugDetalle.AgregarFiltroEnLinea({"Observacion"})


         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         PreferenciasLeer(ugDetalle)

         Me._publicos.CargaComboMonedas(Me.cmbMoneda)
         Me.cmbMoneda.SelectedIndex = 1

         _publicos.CargaComboDesdeEnum(cmbTipoConversion, GetType(Entidades.Moneda_TipoConversion))
         Me.cmbTipoConversion.SelectedIndex = 0

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Interes").Hidden = Not _utilizaIntereses

         Me.chbFechaInteres.Visible = _utilizaIntereses
         Me.dtpFechaInteres.Visible = _utilizaIntereses

         '-- REQ-36325.- ----------------------------------------------------------------
         If Reglas.Publicos.CtaCteEmbarcacion Then
            chbEmbarcacionCama.Text = "Embarcacion"
            grbEmbarcacionCama.Visible = True
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreEmbarcacion").Hidden = False
         End If
         If Reglas.Publicos.CtaCteCama Then
            chbEmbarcacionCama.Text = "Cama"
            grbEmbarcacionCama.Visible = True
            bscNombreEmbarcacion.Visible = False
            ugDetalle.DisplayLayout.Bands(0).Columns("IdCama").Hidden = False
         End If
         '-- REQ-33040.- ------------------------------------------------
         If ConsultarAutomaticamenteDesdeRecibos Then
            Me.bscCodigoCliente.PresionarBoton()
            Me.btnConsultar.PerformClick()
         End If
         '---------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub ConsultarCtaCteDetClientesDH_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Me.bscCliente.Focus()
   End Sub
#End Region

#Region "Eventos"

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               Me.Cursor = Cursors.WaitCursor

               Dim oTipoComprobante = New Entidades.TipoComprobante()
               oTipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())

               If oTipoComprobante.EsRecibo Or oTipoComprobante.EsAnticipo Then
                  Dim IdTipoComprobante As String = IIf(oTipoComprobante.EsRecibo, oTipoComprobante.IdTipoComprobante, oTipoComprobante.IdTipoComprobanteSecundario).ToString()
                  Dim reg = New Reglas.CuentasCorrientes()

                  Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                       IdTipoComprobante, 'dr("IdTipoComprobante").ToString(),
                                                                       dr("Letra").ToString(),
                                                                       Integer.Parse(dr("CentroEmisor").ToString()),
                                                                       Long.Parse(dr("NumeroComprobante").ToString()))
                  Dim imp = New RecibosImprimir()
                  imp.ImprimirRecibo(ctacte, True)
               Else
                  'imprime los comprobantes que no son recibos
                  Dim oVentas = New Reglas.Ventas()
                  Dim venta = oVentas.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                dr("IdTipoComprobante").ToString(),
                                                                dr("Letra").ToString(),
                                                                Short.Parse(dr("CentroEmisor").ToString()),
                                                                Long.Parse(dr("NumeroComprobante").ToString()))

                  Dim oImpr = New Impresion(venta)

                  oImpr.ImprimirComprobanteNoFiscal(True)
               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

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
         If Me.chbEmbarcacionCama.Checked And Not Me.bscCodigoEmbarcacionCama.Selecciono And Not Me.bscNombreEmbarcacion.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Embarcacion, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoEmbarcacionCama.Focus()
            Exit Sub
         End If
         Me.tsbAsignarComprobanteAplicado.Visible = Reglas.Publicos.CtaCte.CtaCtePermitirModificarComprobanteAsociado AndAlso Not Me.chbExcluirMinutas.Checked AndAlso Me.chbMostrarComprobanteAplicado.Checked
         Me.tss6.Visible = Me.tsbAsignarComprobanteAplicado.Visible

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
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

   Private Sub ConsultarCtaCteDetClientesDH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

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

         Dim Filtros = CargarFiltrosImpresion()

         Me.Cursor = Cursors.WaitCursor

         Dim comunes = New CtasCtesClientesComunes()

         Dim Cliente As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text.ToString()))

         comunes.ImprimirInformeCtaCteDetalleClientesDH(DirectCast(Me.ugDetalle.DataSource, DataTable).Copy(),
                                                        Filtros, "", Text, True, Cliente.CorreoElectronico,
                                                        Decimal.Parse(Me.txtSaldoInicial.Text),
                                                        Decimal.Parse(Me.txtSaldoActual.Text),
                                                        Decimal.Parse(Me.txtSaldoFinal.Text))

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

   Private Sub chbComprobanteAplicado_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarComprobanteAplicado.CheckedChanged
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdTipoComprobante2").Hidden = Not Me.chbMostrarComprobanteAplicado.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Letra2").Hidden = Not Me.chbMostrarComprobanteAplicado.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("CentroEmisor2").Hidden = Not Me.chbMostrarComprobanteAplicado.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("NumeroComprobante2").Hidden = Not Me.chbMostrarComprobanteAplicado.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("CuotaNumero2").Hidden = Not Me.chbMostrarComprobanteAplicado.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("ExisteCtaCte").Hidden = Not Me.chbMostrarComprobanteAplicado.Checked
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      '-- REQ-36325.- ----------------------------------------------------------------
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      '-------------------------------------------------------------------------------
   End Sub
   Private Sub chbEmbarcacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmbarcacionCama.CheckedChanged

      '-- REQ-36325.- ----------------------------------------------------------------
      If Reglas.Publicos.CtaCteEmbarcacion Then
         Me.bscCodigoEmbarcacionCama.Enabled = Me.chbEmbarcacionCama.Checked
         Me.bscNombreEmbarcacion.Enabled = Me.chbEmbarcacionCama.Checked

         If Not Me.chbEmbarcacionCama.Checked Then
            Me.bscCodigoEmbarcacionCama.Tag = Nothing
            Me.bscCodigoEmbarcacionCama.Text = ""
            Me.bscNombreEmbarcacion.Text = ""
         Else
            Me.bscCodigoEmbarcacionCama.Focus()
         End If
      End If
      If Reglas.Publicos.CtaCteCama Then
         Me.bscCodigoEmbarcacionCama.Enabled = Me.chbEmbarcacionCama.Checked
         If Not Me.chbEmbarcacionCama.Checked Then
            Me.bscCodigoEmbarcacionCama.Tag = Nothing
            Me.bscCodigoEmbarcacionCama.Text = ""
            Me.bscNombreEmbarcacion.Text = ""
            Me.bscNombreEmbarcacion.Visible = False
         Else
            Me.bscCodigoEmbarcacionCama.Focus()
         End If
      End If
      '-------------------------------------------------------------------------------

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbGrabanLibro.SelectedIndex = 0

      Me.bscCodigoCliente.Enabled = True
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Enabled = True
      Me.bscCliente.Text = String.Empty

      Me.chbFechas.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbExcluirMinutas.Checked = False

      Me.chbGrupo.Checked = False

      Me.optFechaEmision.Checked = True
      Me.chbExcluirMinutas.Checked = True
      chbEmbarcacionCama.Checked = False
      bscCodigoEmbarcacionCama.Text = ""
      bscNombreEmbarcacion.Text = ""
      Me.tsbAsignarComprobanteAplicado.Visible = False
      Me.tss6.Visible = False
      chbEmbarcacionCama.Checked = False
      bscCodigoEmbarcacionCama.Text = ""
      bscNombreEmbarcacion.Text = ""

      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Clear()
      End If

      KardexComprobCtaCteClientesUC1.RefrescarDatosGrilla()

      Me.txtSaldoFinal.Text = "0.00"

      Me.cmbSucursal.Refrescar()

      Me.cmbMoneda.SelectedIndex = 1

      Me.bscCliente.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()

      Dim Saldo As Decimal = 0

      Dim IdCliente As Long = 0

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing
      Dim ExcluirMinutas As String = "NO"
      Dim excluirPreComprobantes As Boolean = Me.chbExcluirPreComprobantes.Checked

      Dim FechaUtilizada As String = String.Empty

      Dim Grupo As String = String.Empty
      Dim tipoConversion As Entidades.Moneda_TipoConversion = Entidades.Moneda_TipoConversion.Comprobante
      Dim IdEmbarcacion = If(chbEmbarcacionCama.Checked And Reglas.Publicos.CtaCteEmbarcacion, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoEmbarcacionCama.Tag, 0L), 0L)
      '-- 36325.- ---------------------------------------------------------------------------------------------------------
      Dim IdCama = If(chbEmbarcacionCama.Checked And Reglas.Publicos.CtaCteCama, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoEmbarcacionCama.Tag, 0L), 0L)

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
            Me.txtSaldoInicial.Text = oCtaCte.GetSaldoCliente(cmbSucursal.GetSucursales(), IdCliente, Desde.AddDays(-1), False, "TODOS", graba, Nothing, "", excluirPreComprobantes, 0, 0).ToString("#,##0.00")
         Else
            Me.txtSaldoInicial.Text = "0.00"
         End If

         If Me.cmbGrupos.Enabled Then
            Grupo = Me.cmbGrupos.SelectedValue.ToString()
         End If

         If Me.chbExcluirMinutas.Checked Then
            ExcluirMinutas = "SI"
         End If

         FechaUtilizada = IIf(Me.optFechaEmision.Checked, "EMISION", "VENCIMIENTO").ToString()

         If Me.cmbTipoConversion.Visible Then
            tipoConversion = DirectCast(Me.cmbTipoConversion.SelectedValue, Entidades.Moneda_TipoConversion)
         End If

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oCtaCteDet.GetPorCliente(cmbSucursal.GetSucursales(),
                                                  IdCliente,
                                                   FechaUtilizada,
                                                   Desde, Hasta,
                                                   Me.cmbGrabanLibro.Text,
                                                   Grupo,
                                                   ExcluirMinutas,
                                                   False,
                                                   dtpFechaInteres.Value,
                                                   Integer.Parse(cmbMoneda.SelectedValue.ToString()),
                                                   tipoConversion,
                                                   Decimal.Parse(Me.txtCotizacionDolar.Text.ToString()),
                                                   excluirPreComprobantes,
                                                   IdEmbarcacion, IdCama)

         dtDetalle.Columns.Add("Ver", GetType(String))
         dtDetalle.Columns.Add("Debe", GetType(Decimal))
         dtDetalle.Columns.Add("Haber", GetType(Decimal))
         dtDetalle.Columns.Add("Saldo", GetType(Decimal))

         Saldo = Decimal.Parse(Me.txtSaldoInicial.Text)

         For Each dr As DataRow In dtDetalle.Rows
            dr("Ver") = "..."
            Dim importeTotal As Decimal = If(IsNumeric(dr("ImporteCuota")), Decimal.Parse(dr("ImporteCuota").ToString()), 0)
            Dim Interes As Decimal = If(IsNumeric(dr("Interes")), Decimal.Parse(dr("Interes").ToString()), 0)
            If importeTotal > 0 Then
               dr("Debe") = importeTotal
            Else
               dr("Haber") = importeTotal * -1
            End If
            If _utilizaIntereses = True Then
               Saldo = Saldo + Interes + importeTotal
            Else
               Saldo = Saldo + importeTotal
            End If
            'Saldo = Saldo + importeTotal

            'If _utilizaIntereses = True Then
            '   dr("Saldo") = Saldo + Interes
            'Else
            '   dr("Saldo") = Saldo
            'End If
            dr("Saldo") = Saldo
         Next

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.DataSource = dtDetalle
         AjustarColumnasGrilla(ugDetalle, _tit)

         Me.txtSaldoFinal.Text = Saldo.ToString("N2")

         Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registro/s"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)


         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat("Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbFechas.Checked Then
            .AppendFormat("Fecha: desde {0} - hasta {1} - ", Me.dtpDesde, Me.dtpHasta.Text)
         End If

         If Me.cmbGrabanLibro.SelectedIndex > 0 Then     '0 Es TODOS
            .AppendFormat("Graban Libro {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.chbGrupo.Checked And cmbGrupos.SelectedIndex <> -1 Then
            .AppendFormat("Grupo: {0} - ", Me.cmbGrupos.Text)
         End If

         If Me.chbExcluirMinutas.Checked Then
            .AppendFormat("Excluir Minutas - ")
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            .AppendFormat("Excluir PreComprobantes - ")
         End If

         If Me.chbEmbarcacionCama.Checked Then
            .AppendFormat("Embarcacion:  {0} - ", bscNombreEmbarcacion.Text)
         End If


         .AppendFormat("Filtro y Orden: Fecha  " & IIf(Me.optFechaEmision.Checked, "Emisión", "Vencimiento").ToString())

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region
   '-- REQ-33040.- ------------------------------------------------
   Public Sub InicializarPublicos()
      Me._publicos = New Publicos
   End Sub

   Private Sub tsbAsignarComprobanteAplicado_Click(sender As Object, e As EventArgs) Handles tsbAsignarComprobanteAplicado.Click
      Try
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            'If Not Boolean.Parse(dr("ExisteCtaCte").ToString()) Then
            Using frmCtaCteModificar As CtaCteModificarComprobanteAplicado = New CtaCteModificarComprobanteAplicado(dr)

               If frmCtaCteModificar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                  Me.btnConsultar.PerformClick()
               End If
            End Using
            'End If
            Me.Focus()
         Else
            MessageBox.Show("Debe seleccionar un comprobante valido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'GAR: 20/07/2019 - Por el momento lo habilitamos, luego le metemos seguridad.
   'Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
   '   Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
   '   If dr IsNot Nothing Then
   '      Me.tsbAsignarComprobanteAplicado.Visible = Not Boolean.Parse(dr("ExisteCtaCte").ToString())
   '   End If
   'End Sub

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

   Private Sub bscCodigoEmbarcacion_BuscadorClick() Handles bscCodigoEmbarcacionCama.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.bscCodigoEmbarcacionCama.Datos = ConsultaEmbarcacionCama()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreEmbarcacion_BuscadorClick() Handles bscNombreEmbarcacion.BuscadorClick
      Try
         Me._publicos.PreparaGrillaEmbarcaciones(Me.bscNombreEmbarcacion)
         Dim oEmbarca As Reglas.Embarcaciones = New Reglas.Embarcaciones
         Me.bscNombreEmbarcacion.Datos = oEmbarca.GetFiltradoPorNombre(Me.bscNombreEmbarcacion.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscCodigoEmbarcacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoEmbarcacionCama.BuscadorSeleccion, bscNombreEmbarcacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosEmbarcacion(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosEmbarcacion(dr As DataGridViewRow)
      If Reglas.Publicos.CtaCteEmbarcacion Then
         bscCodigoEmbarcacionCama.Text = dr.Cells("CodigoEmbarcacion").Value.ToString()
         bscNombreEmbarcacion.Text = dr.Cells("NombreEmbarcacion").Value.ToString()
         bscCodigoEmbarcacionCama.Tag = Long.Parse(dr.Cells("IdEmbarcacion").Value.ToString())
      End If
      If Reglas.Publicos.CtaCteCama Then
         bscCodigoEmbarcacionCama.Text = dr.Cells("CodigoCama").Value.ToString()
         bscCodigoEmbarcacionCama.Tag = Long.Parse(dr.Cells("IdCama").Value.ToString())
      End If
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.bscCliente.Selecciono = True
   End Sub
   Private Function ConsultaEmbarcacionCama() As DataTable
      '-- REQ-36325.- ----------------------------------------------------------------
      Dim CodEmbarcacionCama As Long = 0
      If Reglas.Publicos.CtaCteEmbarcacion Then
         Me._publicos.PreparaGrillaEmbarcaciones(Me.bscCodigoEmbarcacionCama)
         Dim oEmbarca As Reglas.Embarcaciones = New Reglas.Embarcaciones
         If Me.bscCodigoEmbarcacionCama.Text.Trim.Length > 0 Then
            CodEmbarcacionCama = Long.Parse(bscCodigoEmbarcacionCama.Text.Trim())
         End If
         Return oEmbarca.GetPorCodigoEmbarcacion(CodEmbarcacionCama)
      End If

      If Reglas.Publicos.CtaCteCama Then
         _publicos.PreparaGrillaCamas(bscCodigoEmbarcacionCama)
         Dim oCamas As Reglas.Camas = New Reglas.Camas
         Return oCamas.GetCamaPorCodigo(bscCodigoEmbarcacionCama.Text.Trim())
      End If
      '-------------------------------------------------------------------------------
      Return Nothing
   End Function
End Class