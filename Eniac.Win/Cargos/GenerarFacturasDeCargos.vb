Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class GenerarFacturasDeCargos

#Region "Campos"

   Private _publicos As Publicos
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = True
   Private _blnCajasModificables As Boolean = True
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()


         Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
         Me.cmbTiposLiquidacion.SelectedIndex = 0

         Me.PeriodoLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         Me.CargarColumnasASumar()

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub GenerarFacturasDeLiquidacionCargos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbEliminarFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminarFacturas.Click
      Try
         If MessageBox.Show("¿Está Seguro de Eliminar las FACTURAS?", Me.Text, MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.EliminarFacturas()

         Me.Cursor = Cursors.Default

         MessageBox.Show("La eliminación se realizó con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         'Al Cargar los datos se nota que Facturas existen.
         Me.btnConsultar.PerformClick()
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Periodo: " & Me.dtpPeriodo.Value.ToString("MM/yyyy")

         'If Me.chbCliente.Checked Then
         '   Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscNombreCliente.Text
         'End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         'Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbGenerarFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGenerarFacturas.Click
      Dim inicio As DateTime = Now

      Try
         Me.Cursor = Cursors.WaitCursor
         Me.tsbGenerarFacturas.Enabled = False

         Me.GenerarFacturas()

         Me.Cursor = Cursors.Default

         Dim ts As TimeSpan = Now.Subtract(inicio)
         MessageBox.Show("La Generación de FACTURAS se Realizó con EXITO!!" + Environment.NewLine + Environment.NewLine +
                         "Tiempo de proceso: " + ts.ToString("hh\:mm\:ss"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         Dim ts As TimeSpan = Now.Subtract(inicio)
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
                         "Tiempo de proceso: " + ts.ToString("hh\:mm\:ss"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         'Al Cargar los datos se nota que Facturas existen.
         Me.btnConsultar.PerformClick()
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
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

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
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

   'Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
   '   Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   'End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub txtTotalGastosNoGravados_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         Me.CalcularTotalGastos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then

            Me.tsbImprimir.Enabled = True
            Me.tsddExportar.Enabled = True

            Me.chkExpandAll.Enabled = True
            Me.chkExpandAll.Checked = False

            Me.ugDetalle.Focus()

         Else

            Me.tsbImprimir.Enabled = False
            Me.tsddExportar.Enabled = False

            Me.chkExpandAll.Enabled = False
            Me.chkExpandAll.Checked = False

            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.CalcularFechaVencimiento()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpFechaComprobantes_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaComprobantes.ValueChanged
      Try
         If Not Me._estaCargando Then
            Me.CalcularFechaVencimiento()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub PeriodoLiquidacion(ByVal IdTipoLiquidacion As Integer)

      Dim oliq As Reglas.Liquidaciones = New Reglas.Liquidaciones()
      Dim UltimaLiquidacion As Integer

      UltimaLiquidacion = oliq.GetUltimoPeriodoLiquidacion(IdTipoLiquidacion)

      Dim Fecha As Date
      If UltimaLiquidacion > 1 Then
         Fecha = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")
      Else
         Fecha = Date.Now.AddMonths(-1)
      End If

      Me.dtpPeriodo.Value = Fecha
      'Me.dtpPeriodo.Enabled = Not (UltimaLiquidacion > 1)

   End Sub

   Private Sub CargarColumnasASumar()

      If Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Count = 0 Then
         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed

         'Dim columnToSummarize0 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteExpensas")
         'Dim summary0 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteExpensas", SummaryType.Sum, columnToSummarize0)
         'summary0.DisplayFormat = "{0:N2}"
         'summary0.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteVarios")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteVarios", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         'Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteAlquiler")
         'Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteAlquiler", SummaryType.Sum, columnToSummarize2)
         'summary2.DisplayFormat = "{0:N2}"
         'summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalAdicionales")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalAdicionales", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         'Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalExpensas")
         'Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalExpensas", SummaryType.Sum, columnToSummarize4)
         'summary4.DisplayFormat = "{0:N2}"
         'summary4.Appearance.TextHAlign = HAlign.Right

         'Dim columnToSummarize5 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalAlquiler")
         'Dim summary5 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalAlquiler", SummaryType.Sum, columnToSummarize5)
         'summary5.DisplayFormat = "{0:N2}"
         'summary5.Appearance.TextHAlign = HAlign.Right

         'Dim columnToSummarize6 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalInversionista")
         'Dim summary6 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalInversionista", SummaryType.Sum, columnToSummarize6)
         'summary6.DisplayFormat = "{0:N2}"
         'summary6.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.PeriodoLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      Me.tsbGenerarFacturas.Enabled = False
      Me.tsbImprimir.Enabled = False
      Me.tsddExportar.Enabled = False
      grpFactura.Visible = tsbGenerarFacturas.Enabled

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oclLiq As Reglas.Liquidaciones = New Reglas.Liquidaciones()

      Dim Periodo As Integer = Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM"))

      Dim UltimaLiquidacion As Integer
      UltimaLiquidacion = oclLiq.GetUltimoPeriodoLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      If UltimaLiquidacion <= 1 Then
         Me.txtTotalGastosOperativos.Text = ""
         Me.tsbGenerarFacturas.Enabled = False
         Me.tsbEliminarFacturas.Enabled = False
         Me.ugDetalle.DataSource = Nothing

         Throw New Exception("Nunca se Liquido por Primera Vez.")

      Else

         Dim oLiq As Entidades.Liquidacion = New Entidades.Liquidacion()

         oLiq = oclLiq.GetUno(Periodo, actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         Me.txtTotalGastosOperativos.Text = oLiq.TotalGastosOperativos.ToString("N2")

         Dim pendienteFacturarAlquiler As Boolean = False
         Dim pendienteFacturarExpensas As Boolean = False

         If oLiq.FechaFacturado > Date.Parse("1900-01-01") Then
            Me.tsbGenerarFacturas.Enabled = False
            Me.tsbEliminarFacturas.Enabled = True
         Else
            Me.tsbGenerarFacturas.Enabled = True
            Me.tsbEliminarFacturas.Enabled = False
         End If

         Me.ugDetalle.DataSource = oclLiq.GetLiquidacionParaFacturar(Periodo, actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      End If

      dtpFechaComprobantes.Value = oclLiq.GetFechaFactura(Periodo, Reglas.Publicos.ExpensasFechaFactura)
      Dim PeriodoFactura As Integer = oclLiq.GetPeriodoFactura(Periodo, Reglas.Publicos.ExpensasPeriodoFactura)
      Dim FechaPeriodoFactura As DateTime = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00")
      txtObservaciones.Text = String.Format("Periodo: {0:yyyy/MM}", FechaPeriodoFactura)
      cmbFormaPago.SelectedValue = Reglas.Publicos.ExpensasFormaPago

      Me.CalcularTotalGastos()

      Me.AjustarColumnasGrilla()

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      grpFactura.Visible = tsbGenerarFacturas.Enabled

   End Sub

   Private Sub AjustarColumnasGrilla()

      Dim tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
      tit.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), "")

      If Reglas.Publicos.ClienteMuestraCodigoClienteLetras Then
         tit.Add(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString(), "")
      End If

      tit.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), "")
      tit.Add(Entidades.Categoria.Columnas.NombreCategoria.ToString(), "")
      'tit.Add(Entidades.Embarcacion.Columnas.NombreEmbarcacion.ToString(), "")
      ' tit.Add(Entidades.CategoriaEmbarcacion.Columnas.NombreCategoriaEmbarcacion.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.ImporteExpensas.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.ImporteVarios.ToString(), "")
      ' tit.Add(Entidades.LiquidacionCargo.Columnas.SegundoVto.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.ImporteTotal.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.IdTipoComprobante.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.Letra.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.CentroEmisor.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.NumeroComprobante.ToString(), "")
      tit.Add("ImporteTotalAdicionales", "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.IdTipoComprobanteAlquiler.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.LetraAlquiler.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.CentroEmisorAlquiler.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.NumeroComprobanteAlquiler.ToString(), "")
      'tit.Add("ImporteTotalAlquiler", "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.IdTipoComprobanteInversionista.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.LetraInversionista.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.CentroEmisorInversionista.ToString(), "")
      'tit.Add(Entidades.LiquidacionCargo.Columnas.NumeroComprobanteInversionista.ToString(), "")
      'tit.Add("ImporteTotalInversionista", "")

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
         If Not tit.ContainsKey(col.Key) Then
            col.Hidden = True
         End If
      Next

   End Sub

   Private Sub CalcularTotalGastos()
      Me.tsbGenerarFacturas.Enabled = Not Me.tsbEliminarFacturas.Enabled And Decimal.Parse(Me.txtTotalGastosOperativos.Text) >= 0
   End Sub

   Private Sub GenerarFacturas()

      Try

         If Me.ValidarGrabacion() Then

            Dim liquid As Reglas.Liquidaciones = New Reglas.Liquidaciones()

            Dim Periodo As Integer
            Periodo = Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM"))

            Dim oLiq As Reglas.Liquidaciones = New Reglas.Liquidaciones()


            oLiq.GrabarFacturasDeCargos(actual.Sucursal.IdSucursal, Periodo,
                                        Me.dtpFechaComprobantes.Value, Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()),
                                        Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), txtObservaciones.Text,
                                        0,
                                        0, 0,
                                        0, 0,
                                        0, 0,
                                        DirectCast(Me.ugDetalle.DataSource, DataTable),
                                        Entidades.Entidad.MetodoGrabacion.Automatico,
                                        Me.IdFuncion, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         End If

         'Catch ex As Exception
         '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function ValidarGrabacion() As Boolean

      'Dim sistema As Eniac.Entidades.Sistema = Publicos.GetSistema()

      'If sistema.FechaVencimiento.Subtract(Me.dtpFecha.Value).Days < 0 Then
      '   MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.dtpFecha.Focus()
      '   Return False
      'End If

      'If Decimal.Parse(Me.txtTotalGastosOperativos.Text) <> Decimal.Parse(Me.txtTotalGastosNoGravados.Text) + Decimal.Parse(Me.txtTotalGastosIVA105.Text) + Decimal.Parse(Me.txtTotalGastosIVA210.Text) + Decimal.Parse(Me.txtTotalGastosIVA270.Text) Then
      '   MessageBox.Show("ATENCION: No coincide la apertura por IVA con el Total de Gastos Operativos !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.txtTotalGastosIVA210.Focus()
      '   Return False
      'End If

      'Dim totalRecupero As Decimal = Decimal.Parse(txtTotalRecupero.Text)
      'Dim totalGastosOperativos As Decimal = Decimal.Parse(txtTotalGastosOperativos.Text)

      'If totalRecupero <> totalGastosOperativos Then
      '   If MessageBox.Show(String.Format("El total de Gastos Operativos ({0:N2}) difiere del total a Recuperar ({1:N2})." + Environment.NewLine + Environment.NewLine +
      '                                    "¿Desea continuar con la generación de las facturas?", totalGastosOperativos, totalRecupero),
      '                      Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      '      Return False
      '   End If
      'End If

      Return True

   End Function

   Private Sub EliminarFacturas()

      Try

         Dim Periodo As Integer
         Periodo = Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM"))

         Dim oLiq As New Reglas.Liquidaciones
         oLiq.EliminarFacturasDeCargos(Periodo, actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()),
                                       Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

      Catch ex As Exception
         Throw
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   'Private Sub GrabarComprobantes()

   '   Try

   '      Dim oclLiquidacionCargos As Cliente.LiquidacionCargos = New Cliente.LiquidacionCargos()
   '      Dim oReglaVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

   '      Dim PeriodoExpensa As Integer = Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM"))
   '      Dim FechaExpensa As Date = CDate(Me.dtpPeriodo.Value.ToString("01/MM/yyyy")).AddMonths(1).AddDays(-1) 'Ultimo dia del Periodo Liquidado.

   '      Dim PeriodoAlquiler As Integer = Integer.Parse(Me.dtpPeriodo.Value.AddMonths(1).ToString("yyyyMM"))
   '      Dim FechaAlquiler As Date = CDate(Me.dtpPeriodo.Value.ToString("01/MM/yyyy")).AddMonths(1) 'Primer dia del Periodo Liquidado (Periodo +1 del Periodo Expensa)

   '      Dim Comprobante As Eniac.Entidades.Venta
   '      Dim IdTipoComprobanteExpensa As String = "FACT"
   '      Dim IdTipoComprobanteAlquiler As String = "FACT-CYO"


   '      Dim IdCliente As Long
   '      Dim IdEmbarcacion As Long
   '      Dim tipoDocVen As String = "COD"
   '      Dim nroDocVen As String = "1"
   '      Dim idFormaDePagoCtaCte As Integer = New Eniac.Reglas.VentasFormasPago().GetUna("VENTAS", False).IdFormasPago
   '      Dim Observacion As String

   '      Dim ImporteExpensas As Decimal
   '      Dim ImporteExpensaAdicionalEslora As Decimal
   '      Dim ImporteExpensaAdicionalAlturaTotal As Decimal
   '      Dim ImporteServicios As Decimal
   '      Dim ImporteGastosAdmin As Decimal
   '      Dim ImporteVarios As Decimal

   '      Dim ImporteAlquiler As Decimal
   '      Dim ImporteGastosIntermAlq As Decimal
   '      Dim ImporteTotal As Decimal

   '      Dim blnGeneroFactExpensa As Boolean
   '      Dim blnGeneroFactAlquiler As Boolean


   '      Dim colVentasProducto As List(Of Eniac.Entidades.VentaProducto)
   '      Dim oLineaVP As Eniac.Entidades.VentaProducto


   '      For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugDetalle.Rows

   '         IdCliente = Long.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.IdCliente.ToString()).Value.ToString)
   '         IdEmbarcacion = Long.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.IdEmbarcacion.ToString()).Value.ToString)

   '         ImporteExpensas = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteExpensas.ToString()).Value.ToString)
   '         ImporteExpensaAdicionalEslora = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteExpensaAdicionalEslora.ToString()).Value.ToString)
   '         ImporteExpensaAdicionalAlturaTotal = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteExpensaAdicionalAlturaTotal.ToString()).Value.ToString)
   '         ImporteServicios = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteServicios.ToString()).Value.ToString)
   '         ImporteGastosAdmin = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteGastosAdmin.ToString()).Value.ToString)
   '         ImporteVarios = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteVarios.ToString()).Value.ToString)
   '         ImporteAlquiler = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteAlquiler.ToString()).Value.ToString)
   '         ImporteGastosIntermAlq = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteGastosIntermAlq.ToString()).Value.ToString)
   '         ImporteTotal = Decimal.Parse(dr.Cells(Entidades.LiquidacionCargo.Columnas.ImporteTotal.ToString()).Value.ToString)

   '         blnGeneroFactExpensa = Not String.IsNullOrEmpty(dr.Cells(Entidades.LiquidacionCargo.Columnas.IdTipoComprobanteExpensa.ToString()).Value.ToString)
   '         blnGeneroFactAlquiler = Not String.IsNullOrEmpty(dr.Cells(Entidades.LiquidacionCargo.Columnas.IdTipoComprobanteAlquiler.ToString()).Value.ToString)

   '         'Primero se Genera la factura de Expensa o lo adicional que no es por alquiler que va con otro comprobante.

   '         'Siempre deberia entrar, pero por las dudas pregunto.
   '         If ImporteVarios > 0 And ImporteAlquiler = 0 And Not blnGeneroFactExpensa Then

   '            colVentasProducto = New List(Of Eniac.Entidades.VentaProducto)

   '            If ImporteExpensas > 0 Then

   '               oLineaVP = New Eniac.Entidades.VentaProducto()
   '               With oLineaVP
   '                  .Orden = colVentasProducto.Count + 1
   '                  .Producto = New Eniac.Reglas.Productos().GetUno("21")
   '                  .Cantidad = 1
   '                  .PrecioLista = ImporteExpensas
   '                  .Precio = .PrecioLista
   '               End With

   '               colVentasProducto.Add(oLineaVP)
   '            End If


   '            If ImporteExpensaAdicionalEslora > 0 Then
   '               oLineaVP = New Eniac.Entidades.VentaProducto()
   '               With oLineaVP
   '                  .Orden = colVentasProducto.Count + 1
   '                  .Producto = New Eniac.Reglas.Productos().GetUno("22")
   '                  .Cantidad = 1
   '                  .PrecioLista = ImporteExpensaAdicionalEslora
   '                  .Precio = .PrecioLista
   '               End With
   '               colVentasProducto.Add(oLineaVP)
   '            End If

   '            If ImporteExpensaAdicionalAlturaTotal > 0 Then
   '               oLineaVP = New Eniac.Entidades.VentaProducto()
   '               With oLineaVP
   '                  .Orden = colVentasProducto.Count + 1
   '                  .Producto = New Eniac.Reglas.Productos().GetUno("23")
   '                  .Cantidad = 1
   '                  .PrecioLista = ImporteExpensaAdicionalAlturaTotal
   '                  .Precio = .PrecioLista
   '               End With
   '               colVentasProducto.Add(oLineaVP)
   '            End If


   '            If ImporteServicios > 0 Then
   '               oLineaVP = New Eniac.Entidades.VentaProducto()
   '               With oLineaVP
   '                  .Orden = colVentasProducto.Count + 1
   '                  .Producto = New Eniac.Reglas.Productos().GetUno("41")
   '                  .Cantidad = 1
   '                  .PrecioLista = ImporteServicios
   '                  .Precio = .PrecioLista
   '               End With
   '               colVentasProducto.Add(oLineaVP)
   '            End If

   '            If ImporteGastosAdmin > 0 Then
   '               oLineaVP = New Eniac.Entidades.VentaProducto()
   '               With oLineaVP
   '                  .Orden = colVentasProducto.Count + 1
   '                  .Producto = New Eniac.Reglas.Productos().GetUno("51")
   '                  .Cantidad = 1
   '                  .PrecioLista = ImporteGastosAdmin
   '                  .Precio = .PrecioLista
   '               End With
   '               colVentasProducto.Add(oLineaVP)
   '            End If


   '            Observacion = "Periodo: " & PeriodoExpensa.ToString("0000/00") & ", Embarcacion: " & dr.Cells(Entidades.Embarcacion.Columnas.NombreEmbarcacion.ToString()).Value.ToString

   '            Comprobante = oReglaVentas.GrabarComprobante2(actual.Sucursal.Id, _
   '                                                         IdTipoComprobanteExpensa, _
   '                                                         IdCliente, _
   '                                                         FechaExpensa, _
   '                                                         tipoDocVen, nroDocVen, _
   '                                                         idFormaDePagoCtaCte, _
   '                                                         Observacion, _
   '                                                         PeriodoExpensa, _
   '                                                         colVentasProducto, _
   '                                                         Nothing)


   '            oclLiquidacionCargos.ActualizarComprobante(PeriodoExpensa, IdEmbarcacion, "Expensa", _
   '                                            Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante, Comprobante.CentroEmisor, Comprobante.NumeroComprobante)

   '         End If


   '         If ImporteAlquiler <> 0 And Not blnGeneroFactAlquiler Then
   '            colVentasProducto = New List(Of Eniac.Entidades.VentaProducto)
   '            oLineaVP = New Eniac.Entidades.VentaProducto()
   '            With oLineaVP
   '               .Orden = colVentasProducto.Count + 1
   '               .Producto = New Eniac.Reglas.Productos().GetUno("51")
   '               .Cantidad = 1
   '               .PrecioLista = ImporteExpensas + ImporteAlquiler
   '               .Precio = .PrecioLista
   '            End With
   '            colVentasProducto.Add(oLineaVP)

   '            Observacion = "Periodo: " & PeriodoAlquiler.ToString("0000/00") & ", Embarcacion: " & dr.Cells(Entidades.Embarcacion.Columnas.NombreEmbarcacion.ToString()).Value.ToString

   '            Comprobante = oReglaVentas.GrabarComprobante2(actual.Sucursal.Id, _
   '                                                         IdTipoComprobanteAlquiler, _
   '                                                         IdCliente, _
   '                                                         FechaAlquiler, _
   '                                                         tipoDocVen, nroDocVen, _
   '                                                         idFormaDePagoCtaCte, _
   '                                                         Observacion, _
   '                                                         PeriodoAlquiler, _
   '                                                         colVentasProducto, _
   '                                                         Nothing)

   '            oclLiquidacionCargos.ActualizarComprobante(PeriodoExpensa, IdEmbarcacion, "Alquiler", _
   '                                            Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante, Comprobante.CentroEmisor, Comprobante.NumeroComprobante)

   '         End If

   '      Next


   '   Catch ex As Exception
   '      Me.Cursor = Cursors.Default
   '      Throw ex
   '      'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub CalcularFechaVencimiento()
      Me.dtpVencimiento.Value = Me.dtpFechaComprobantes.Value.AddDays(DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias)
   End Sub

#End Region

   Private Sub cmbTiposLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposLiquidacion.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.tsbGenerarFacturas.Enabled = False
            Me.tsbEliminarFacturas.Enabled = False
            Me.PeriodoLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class