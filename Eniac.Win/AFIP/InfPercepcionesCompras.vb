Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class InfPercepcionesCompras

#Region "Campos"

   Private _publicos As Publicos
   Private _siprib As SIPRIBArchivo
   Private _dtDetalle As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()
         Me._publicos.CargaComboTiposImpuestos(Me.cmbTipoImpuesto, "PERCEPCION")
         Me._publicos.CargaComboAplicativoAfip(Me.cmbAplicativoAfip, "PERCEPCION")

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         RefrescarDatosGrilla()

         Me.LeerPreferencias()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfRetenciones_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = "0 Registros"
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Try
         If chkMesCompleto.Checked Then
            dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
            dtpHasta.Value = dtpDesde.Value.UltimoDiaMes(True)
         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked
      Catch ex As Exception
         chkMesCompleto.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTipoImpuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoImpuesto.CheckedChanged
      Me.cmbTipoImpuesto.Enabled = Me.chbTipoImpuesto.Checked
      If Not Me.chbTipoImpuesto.Checked Then
         Me.cmbTipoImpuesto.SelectedIndex = -1
      Else
         Me.cmbTipoImpuesto.SelectedIndex = 0
         Me.cmbTipoImpuesto.Focus()
      End If
   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()
   End Sub

#Region "Eventos Buscador Proveedores"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
         Me.tsbExportar.Visible = chbAplicativoAfip.Checked AndAlso ugDetalle.Rows.Count > 0

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

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
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook()
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Reglas.Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Reglas.Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If e.Cell.Column.Key = "Ver" And e.Cell.Row.Index <> -1 Then

            Try

               Me.Cursor = Cursors.WaitCursor
               Dim oCompras As Reglas.Compras = New Reglas.Compras()

               Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                           e.Cell.Row.Cells("IdTipoComprobante").Value.ToString(), _
                           e.Cell.Row.Cells("Letra").Value.ToString(), _
                           Short.Parse(e.Cell.Row.Cells("EmisorPercepcion").Value.ToString()), _
                           Long.Parse(e.Cell.Row.Cells("NumeroPercepcion").Value.ToString()), _
                           Long.Parse(e.Cell.Row.Cells("IdProveedor").Value.ToString()))

               Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

               oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)


            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
               Me.Cursor = Cursors.Default
            End Try

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub tsbExportar_Click(sender As System.Object, e As System.EventArgs) Handles tsbExportar.Click
      Try
         If Not chbAplicativoAfip.Checked OrElse cmbAplicativoAfip.SelectedValue Is Nothing Then
            ShowMessage("Debe seleccionar un aplicativo para poder exportar.")
            Exit Sub
         End If

         If ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataTable Then
            Dim dt As DataTable = DirectCast(ugDetalle.DataSource, DataTable)
            'Dim tipoImpuesto As TipoImpuesto = New Reglas.TiposImpuestos().GetxTipo(cmbTipoImpuesto.SelectedValue.ToString())
            Dim aplicativo As String = cmbAplicativoAfip.SelectedValue.ToString()

            If ShowPregunta(String.Format("¿Realmente desea generar el archivo para los {0} comprobantes con formato para el aplicativo '{1}'?",
                                          dt.Rows.Count, aplicativo)) = Windows.Forms.DialogResult.Yes Then

               Dim ar As ArchivoDestinoExportacion = New ArchivoDestinoExportacion()

               Dim nombreArchivo As String = String.Format("{0}_{1}_{2:ddMMyyyy}_{3:ddMMyyyy}.txt",
                                                           Reglas.Publicos.CuitEmpresa, aplicativo, dtpDesde.Value, dtpHasta.Value)
               ar.txtArchivoDestino.Text = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, nombreArchivo)
               If ar.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                  If Not String.IsNullOrEmpty(ar.txtArchivoDestino.Text) Then

                     Select Case aplicativo
                        Case "SIFERE"
                           Dim sifere As SIFEREPercArchivo = CreaSIFEREPerc(Me._dtDetalle)
                           If sifere IsNot Nothing Then
                              sifere.GrabarArchivo(ar.txtArchivoDestino.Text)
                              ShowMessage("Se Exportaron " & sifere.Lineas.Count.ToString() & " comprobantes EXITOSAMENTE !!!")
                           Else
                              ShowMessage("Exportación cancelada por el usuario")
                           End If

                        Case "SIRCAR"
                           Dim sircar As SIRCARArchivo = CreaSIRCARPerc(Me._dtDetalle)
                           If sircar IsNot Nothing Then
                              sircar.GrabarArchivo(ar.txtArchivoDestino.Text, TipoImpuesto.Tipos.PIIBB)
                              ShowMessage("Se Exportaron " & sircar.Lineas.Count.ToString() & " comprobantes EXITOSAMENTE !!!")
                           Else
                              ShowMessage("Exportación cancelada por el usuario")
                           End If
                        Case Else
                           ShowMessage(String.Format("Formato para el aplicativo '{0}' no soportado.", aplicativo))
                           Exit Sub
                     End Select
                  End If
               End If

            Else
               ShowMessage("Ha cancelado la exportación.")
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.rdbPorFechas.Checked = True
      Me.chkMesCompleto.Checked = False
      Me.chbProveedor.Checked = False

      dtpPeriodoFiscal.Value = Today.PrimerDiaMes()


      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

      Me.chbTipoImpuesto.Checked = False

      Me.chbProveedor.Checked = False

      Me.tsbExportar.Visible = False

      If Not ugDetalle.DataSource Is Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataTable Then
         DirectCast(ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.cmbSucursal.Text = "(Todos)"

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         Dim IdTipoRetencion As String = String.Empty
         Dim IdTipoImpuesto As String = String.Empty
         Dim aplicativoAFIP As String = String.Empty

         Dim IdProveedor As Long = 0
         Dim Total As Decimal = 0

         Dim PeriodoFiscal As Integer = 0
         Dim FechaDesde As Date = Nothing
         Dim FechaHasta As Date = Nothing

         If Me.rdbPorPeriodoFiscal.Checked Or Me.rdbAmbos.Checked Then
            PeriodoFiscal = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))
         End If

         If Me.rdbPorFechas.Checked Or Me.rdbAmbos.Checked Then
            FechaDesde = Me.dtpDesde.Value
            FechaHasta = Me.dtpHasta.Value
         End If


         If Me.cmbTipoImpuesto.Enabled Then
            IdTipoImpuesto = DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), Me.cmbTipoImpuesto.SelectedValue.ToString()), Entidades.TipoImpuesto.Tipos).ToString()
         End If

         If Me.chbProveedor.Checked Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If chbAplicativoAfip.Checked Then
            If cmbAplicativoAfip.SelectedIndex < 0 Then
               Throw New Exception("ATENCION: NO seleccionó un Aplicativo de AFIP aunque activó ese Filtro.")
            End If
            aplicativoAFIP = cmbAplicativoAfip.SelectedValue.ToString()
         End If

         Dim rCompImp As Reglas.ComprasImpuestos = New Reglas.ComprasImpuestos()
         _dtDetalle = rCompImp.GetPercepcionesParaInforme(cmbSucursal.GetSucursales(), FechaDesde, FechaHasta, IdTipoImpuesto, IdProveedor, aplicativoAFIP, PeriodoFiscal)

         Dim dt As DataTable
         Dim drCl As DataRow

         dt = Me.CrearDT()

         For Each dr As DataRow In _dtDetalle.Rows

            drCl = dt.NewRow()

            Dim importe As Decimal = Decimal.Parse(dr("Importe").ToString())

            drCl("Ver") = "..."
            drCl("IdTipoImpuesto") = dr("IdTipoImpuesto")
            drCl("FechaEmision") = dr("Fecha")
            drCl("NombreTipoImpuesto") = dr("NombreTipoImpuesto")
            drCl("IdProveedor") = dr("IdProveedor")
            drCl("CodigoProveedor") = dr("CodigoProveedor")
            drCl("NombreProveedor") = dr("NombreProveedor")
            drCl("CuitProveedor") = dr("CuitProveedor")
            drCl("EmisorPercepcion") = dr("Emisor")
            drCl("NumeroPercepcion") = dr("Numero")
            drCl("BaseImponible") = dr("BaseImponible")
            drCl("Alicuota") = dr("Alicuota")
            drCl("ImporteTotal") = importe
            drCl("IdProvincia") = dr("IdProvincia")
            drCl("NombreProvincia") = dr("NombreProvincia")
            drCl("Jurisdiccion") = dr("Jurisdiccion")
            drCl("CodigoComprobanteSifere") = dr("CodigoComprobanteSifere")
            drCl("IdTipoComprobante") = dr("IdTipoComprobante")
            drCl("Letra") = dr("Letra")

            Total = Total + importe

            dt.Rows.Add(drCl)
         Next

         ugDetalle.DataSource = dt

         Me.tssRegistros.Text = dt.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdTipoImpuesto", GetType(String))
         .Columns.Add("FechaEmision", GetType(DateTime))
         .Columns.Add("NombreTipoImpuesto", GetType(String))
         .Columns.Add("IdProveedor", GetType(Long))
         .Columns.Add("CodigoProveedor", GetType(Long))
         .Columns.Add("NombreProveedor", GetType(String))
         .Columns.Add("CuitProveedor", GetType(Long))
         .Columns.Add("EmisorPercepcion", GetType(Integer))
         .Columns.Add("NumeroPercepcion", GetType(Long))
         .Columns.Add("BaseImponible", GetType(Decimal))
         .Columns.Add("Alicuota", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("IdProvincia", GetType(String))
         .Columns.Add("NombreProvincia", GetType(String))
         .Columns.Add("Jurisdiccion", GetType(Integer))
         .Columns.Add("CodigoComprobanteSifere", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
      End With

      Return dtTemp
   End Function


#End Region

   Private Function CreaSIFEREPerc(dt As DataTable) As SIFEREPercArchivo
      Dim i As Integer = 0
      Dim sifere As SIFEREPercArchivo = New SIFEREPercArchivo()
      Try
         Dim linea As SIFEREPercLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Step = 1
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows
            Me.tspBarra.PerformStep()
            i += 1
            linea = New SIFEREPercLinea()
            With linea
               .Procesar = True

               .Jurisdiccion = Integer.Parse(dr("Jurisdiccion").ToString())

               If Not String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
                  .Cuit = Long.Parse(dr("CuitProveedor").ToString())
               Else
                  stb.AppendFormat("El Proveedor {0}, No tiene Cargado el CUIT, la Linea queda invalida.",
                                   dr("NombreProveedor").ToString()).AppendLine()
                  .Procesar = False
               End If

               .Fecha = DateTime.Parse(dr("Fecha").ToString())
               If Not String.IsNullOrWhiteSpace(dr("Emisor").ToString()) Then
                  .EmisorPercepcion = Integer.Parse(dr("Emisor").ToString())
               Else
                  .EmisorPercepcion = 0
               End If
               .NumeroPercepcion = Long.Parse(dr("Numero").ToString())
               .IdTipoComprobante = dr("IdTipoComprobante").ToString()

               '# Valido que el comprobante tenga seteado el Código de Comprobante SIFERE
               If String.IsNullOrEmpty(dr("CodigoComprobanteSifere").ToString()) Then
                  Throw New Exception(String.Format("El comprobante {0} {1} {2} {3} no tiene configurado el Cód. Comprobante SIFERE.",
                                                      dr("IdTipoComprobante").ToString(), dr("Letra").ToString(),
                                                      CInt(dr("Emisor")).ToString("0000"),
                                                      CInt(dr("NumeroComprobante")).ToString("00000000")))
               Else
                  .CodigoComprobante = dr("CodigoComprobanteSifere").ToString()
               End If
               .Letra = (dr("Letra").ToString())
               .Importe = Decimal.Parse(dr("Importe").ToString())
            End With
            sifere.Lineas.Add(linea)
         Next

         If stb.Length > 0 Then
            stb.Append("¿Desea continuar?")
            If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.No Then
               Return Nothing
            End If
         End If

         Return sifere
      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString() & ".", ex)
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try

   End Function

   Private Function CreaSIRCARPerc(dt As DataTable) As SIRCARArchivo
      Dim i As Integer = 0
      Dim sircar As SIRCARArchivo = New SIRCARArchivo()
      Try
         Dim linea As SIRCARArchivoLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Step = 1
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows
            Me.tspBarra.PerformStep()
            i += 1
            linea = New SIRCARArchivoLinea()
            If Not String.IsNullOrEmpty(dr("IdRegimenIIBB").ToString()) Then
               With linea
                  .Procesar = True

                  'Número de Renglón (único por archivo)
                  .NumeroRenglon = i

                  'Tipo de Comprobante 
                  .IdTipoComprobante = dr("IdtipoComprobante").ToString()

                  'Letra del Comprobante (A, B ó C, según tipo de Comprobante) Z si no existe identificación del Comprobante 
                  .LetraComprobante = dr("NumeroComprobante").ToString()

                  'Número de Comprobante (incluye el punto de venta)
                  .NroComprobante = Decimal.Parse(dr("CentroEmisor").ToString() & dr("NumeroComprobante").ToString())

                  'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
                  If Not String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
                     .CuitProveedor = Long.Parse(dr("CuitProveedor").ToString())
                  Else
                     stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
                     Continue For
                  End If

                  .FechaDeLaRetencion = DateTime.Parse(dr("Fecha").ToString())

                  'Nro de inscripción en Ingresos Brutos: será exigido si condición frente a ingresos brutos es 1, 
                  'de lo contrario deberá ingresar ceros.  Numérico de 10 posiciones.
                  If .CondicionFrenteAIIBB = 1 Then
                     If Not String.IsNullOrEmpty(dr("IngresosBrutos").ToString()) Then
                        .NroInscripcionIIBB = Long.Parse(dr("IngresosBrutos").ToString().Replace("-", ""))
                        If .NroInscripcionIIBB = Long.Parse(Reglas.Publicos.IngresosBrutos.ToString().Replace("-", "")) Then
                           stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", tiene el mismo Numero de IIBB que la Empresa, la Linea queda invalida.").AppendLine()
                           Continue For
                        End If
                     Else
                        stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", No tiene Cargado el Numero de IIBB, la Linea queda invalida.").AppendLine()
                        Continue For
                     End If
                  End If

                  'Monto Sujeto a Retención (numérico sin separador de miles)
                  .MontoImponible = Decimal.Parse(dr("BaseImponible").ToString())

                  'Alícuota (porcentaje sin separador de miles)
                  .Alicuota = Decimal.Parse(dr("Alicuota").ToString())

                  'Impuesto determinado
                  .ImpuestoDeterminado = Decimal.Parse(dr("Importe").ToString())

                  'Monto Retenido (numérico sin separador de miles, se obtiene de multiplicar el campo 7 por el campo 8 y dividirlo por 100) 
                  .MontoRetenido = .ImpuestoDeterminado


                  .TipoRegimen = New Reglas.Regimenes().GetUno(Integer.Parse(dr("IdRegimenIIBB").ToString())).CodigoAfip

                  .Jurisdiccion = Integer.Parse(dr("Jurisdiccion").ToString())

               End With
               sircar.Lineas.Add(linea)
            End If

         Next

         If stb.Length > 0 Then
            stb.Append("¿Desea continuar?")
            If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.No Then
               Return Nothing
            End If
         End If

         Return sircar
      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString(), ex)
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try

   End Function

   'Private Sub CrearSIPRIB(ByVal dt As DataTable)

   '   Dim i As Integer = 0

   '   Try
   '      Me._siprib = New SIPRIBArchivo()

   '      Dim linea As SIPRIBArchivoLinea
   '      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

   '      Me.tspBarra.Visible = True
   '      Me.tspBarra.Minimum = 0
   '      Me.tspBarra.Maximum = dt.Rows.Count
   '      Me.tspBarra.Value = 0

   '      For Each dr As DataRow In dt.Rows

   '         Me.tspBarra.Value = i

   '         i += 1

   '         linea = New SIPRIBArchivoLinea()

   '         With linea
   '            'Se pone fijo el 2 porque es una Percepcion.
   '            .CodigoOperacion = 2
   '            .FechaDeLaRetencion = DateTime.Parse(dr("FechaEmision").ToString())
   '            'queda fijo por el momento con el valor:
   '            '029 Art.10 - inciso J - (Res. Gral. 15/97 y Modif.)
   '            .CodigoArticulo = 29

   '            .IdTipoComprobante = dr("IdTipoComprobante").ToString()

   '            'Letra de comprobante
   '            .LetraComprobante = dr("Letra").ToString()

   '            'Nro. del comprobante
   '            .NroComprobante = Decimal.Parse(dr("NumeroComprobante").ToString())

   '            'Fecha de emisión comprobante (menor o igual a la fecha de la retención/percepción).
   '            .FechaEmisionComprobante = DateTime.Parse(dr("FechaEmision").ToString())

   '            'Importe comprobante (debe ser mayor a 0). Numérico 9 enteros 2 decimales separados por comas.
   '            If New Reglas.CategoriasFiscales().GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString())).IvaDiscriminado Then
   '               .ImporteComprobante = Decimal.Parse(dr("ImporteComprobante").ToString())
   '            Else
   '               .ImporteComprobante = Decimal.Parse(dr("ImporteSubTotalComprobante").ToString())
   '            End If


   '            'Tipo documento retenido/percibido. Numérico de 1 posición
   '            'va fijo el 3 porque es el CUIT
   '            .TipoDocPercibido = 3

   '            'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
   '            If Not String.IsNullOrEmpty(dr("Cuit").ToString()) Then
   '               .NroDocPercibido = Long.Parse(dr("Cuit").ToString())
   '            Else
   '               stb.Append("El Proveedor " & dr("NombreProveedor").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
   '               Continue For
   '            End If

   '            'Condición frente a Ingresos Brutos: Numérico de 1 posición 
   '            If Boolean.Parse(dr("InscriptoIBStaFe").ToString()) Then
   '               .CondicionFrenteAIIBB = 1 'Inscripto 
   '            Else
   '               .CondicionFrenteAIIBB = 3 'No inscripto, no obligado a inscribirse.
   '            End If

   '            'Nro de inscripción en Ingresos Brutos: será exigido si condición frente a ingresos brutos es 1, 
   '            'de lo contrario deberá ingresar ceros.  Numérico de 10 posiciones.
   '            If .CondicionFrenteAIIBB = 1 Then
   '               If Not String.IsNullOrEmpty(dr("IngresosBrutos").ToString()) Then
   '                  .NroInscripcionIIBB = Long.Parse(dr("IngresosBrutos").ToString().Replace("-", ""))
   '               Else
   '                  stb.Append("El Proveedor " & dr("NombreProveedor").ToString() & ", No tiene Cargado el Numero de IIBB, la Linea queda invalida.").AppendLine()
   '                  Continue For
   '               End If
   '            End If

   '            'Situación frente a IVA: Numérico de 1 posición.
   '            .IdCategoriaFiscal = Short.Parse(dr("IdCategoriaFiscal").ToString())

   '            'Marca inscripción en otros gravámenes (Artículo 138 Código Fiscal): Numérico de 1 posición
   '            'lo puse fijo a No inscripto en otros gravámenes
   '            .MarcaInscripcionEnOtrosGravamenes = 0

   '            'Marca inscripción en Derecho de Registro e Inspección: Numérico de 1 posición
   '            'lo puse fijo a No inscripto en derecho de registro e inspección
   '            .MarcaInscDerechoRegistroInspeccion = 0

   '            'Importe Otros Gravámenes 
   '            If .MarcaInscDerechoRegistroInspeccion = 1 Then
   '               .ImporteOtrosGravamenes = 0
   '            End If

   '            'Importe I.V.A. 
   '            If .SituacionFrenteAIVA = 1 Then
   '               .ImporteIVA = 0
   '            End If

   '            'Monto imponible
   '            .MontoImponible = Decimal.Parse(dr("BaseImponible").ToString())

   '            'Alícuota
   '            .Alicuota = Decimal.Parse(dr("Alicuota").ToString())

   '            'Impuesto determinado
   '            .ImpuestoDeterminado = Decimal.Parse(dr("ImporteTotal").ToString())

   '            'Monto deducible derecho de registro e inspección
   '            If .MarcaInscDerechoRegistroInspeccion = 1 Then
   '               .MontoDeducible = 0
   '            End If

   '            'Monto retenido
   '            .MontoRetenido = .ImpuestoDeterminado - .MontoDeducible

   '            'Artículo/Inciso para el cálculo del monto de la retención/percepción
   '            'fijo por 003	Art. 5° inciso 2)(Res. Gral. 15/97 y Modif.)
   '            .ArticuloParaPercepcion = 3

   '            If .CondicionFrenteAIIBB = 1 Then

   '               'Tipo de exención: numérico de 1 posición
   '               .TipoDeExension = Short.Parse(dr("IdTipoDeExension").ToString())

   '               'Año de exención:  numérico de 4 posiciones
   '               If .TipoDeExension = 0 Or .TipoDeExension = 4 Then
   '                  .AñoDeExension = 0
   '               Else
   '                  .AñoDeExension = Integer.Parse(dr("AnioExension").ToString())
   '               End If

   '               'Número de certificado de exención: alfanumérico de 6 posiciones
   '               .NumeroCertificadoExencion = dr("NroCertExension").ToString()

   '               'Número de certificado propio:  alfanumérico de 12 posiciones
   '               .NumeroCertificadoPropio = dr("NroCertPropio").ToString()

   '            Else

   '               .TipoDeExension = 0
   '               .AñoDeExension = 0
   '               .NumeroCertificadoExencion = ""
   '               .NumeroCertificadoPropio = ""

   '            End If


   '         End With

   '         Me._siprib.Lineas.Add(linea)

   '      Next

   '      If stb.Length > 0 Then
   '         MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   '      End If

   '   Catch ex As Exception
   '      Throw New Exception(ex.Message & " Linea " & i.ToString())
   '   Finally
   '      Me.tspBarra.Value = 0
   '      Me.tspBarra.Visible = False
   '   End Try


   'End Sub


   'Private Sub ExportarDatos()

   '   Try
   '      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

   '      'For Each li As CitiVentasLinea In Me._citi.Lineas
   '      '   If li.TieneError Then
   '      '      stb.AppendFormat("La linea {0} tiene el/los errores:  ", li.Linea)
   '      '      stb.Append(li.TipoError).AppendLine()
   '      '      Me.dgvDetalle.Rows(li.Linea - 1).DefaultCellStyle.BackColor = Color.LightSalmon
   '      '   End If
   '      'Next

   '      'stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._citi.CantidadDeLineasaProcesar)

   '      'If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
   '      '   Me._siprib.GrabarArchivo(Me.txtArchivoDestino.Text)
   '      '   MessageBox.Show("Se Exportaron " & Me._siprib.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   '      'Else
   '      '   MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      'End If
   '   Catch ex As Exception
   '      Throw
   '   End Try

   'End Sub


   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro
         .AppendFormat("Rango de Fechas: desde el {0:dd/MM/yyyy HH:mm:ss} hasta el {1:dd/MM/yyyy HH:mm:ss}", Me.dtpDesde.Text, Me.dtpHasta.Text)

         If Me.cmbTipoImpuesto.Enabled Then
            .AppendFormat(" - Impuesto: {0}", cmbTipoImpuesto.Text)
         End If

         If Me.chbProveedor.Checked And Me.bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text.Trim(), bscProveedor.Text.Trim())
         End If
      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub chbAplicativoAfip_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicativoAfip.CheckedChanged
      Try
         Me.cmbAplicativoAfip.Enabled = Me.chbAplicativoAfip.Checked
         If Not Me.chbAplicativoAfip.Checked Then
            Me.cmbAplicativoAfip.SelectedIndex = -1
         Else
            Me.cmbAplicativoAfip.SelectedIndex = 0
            Me.cmbAplicativoAfip.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rdbPorPeriodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPorPeriodoFiscal.CheckedChanged
      Me.HabilitarFiltrosFecha(True, False)
      Me.dtpPeriodoFiscal.Focus()
   End Sub

   Private Sub rdbPorFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPorFechas.CheckedChanged
      Me.HabilitarFiltrosFecha(False, True)
      Me.dtpDesde.Focus()
   End Sub

   Private Sub rdbAmbos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAmbos.CheckedChanged
      Me.HabilitarFiltrosFecha(True, True)
      Me.dtpPeriodoFiscal.Focus()
   End Sub

   Private Sub HabilitarFiltrosFecha(ByVal ActivaPeriodoFiscal As Boolean, ByVal ActivaFechas As Boolean)
      Me.dtpPeriodoFiscal.Enabled = ActivaPeriodoFiscal
      Me.chkMesCompleto.Enabled = ActivaFechas
      Me.dtpDesde.Enabled = ActivaFechas
      Me.dtpHasta.Enabled = ActivaFechas
   End Sub
   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub
End Class