Public Class InfRetencionesEmitidas

#Region "Campos"

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False
   Private _sicore As SICORE
   Private _siprib As SIPRIBArchivo
   Private _sircar As SIRCARArchivo
   Private _dragma As DRAGMA

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today

         Me._publicos.CargaComboTiposImpuestos(Me.cmbTipoImpuesto, "RETENCION")
         Me._publicos.CargaComboAplicativoAfip(Me.cmbAplicativoAfip)

         'If ConsultarAutomaticamente Then
         '   Me.chbFechaEmision.Checked = True
         '   Me.dtpDesde.Value = Date.Today.AddMonths(-1)
         '   Me.chbEstado.Checked = True
         '   Me.cmbEstado.SelectedValue = "ENCARTERA"
         '   Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())
         'End If

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal
         Me.cmbSucursal.Text = "(Todos)"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfRetencionesCompras_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.dgvDetalle.RowCount = 0 Then Exit Sub

      Try

         Dim Filtros As String = String.Empty

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Filtros.Length > 0 Then
            Filtros = "Filtros: " & Filtros
         End If

         If Me.cmbTipoImpuesto.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Impuesto: " & Me.cmbTipoImpuesto.Text
         End If

         If Me.cmbAplicativoAfip.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Aplicativo Afip: " & Me.cmbAplicativoAfip.Text
         End If

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfRetencionesEmitidas.rdlc", "dsAFIP_RetencionesCompras", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(dtpDesde.Value.Year, dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 segundo.
            FechaTemp = dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
            Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() + " Registros"
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If Me.chbAplicativoAfip.Checked Then
            If Me.cmbAplicativoAfip.Text = "SICORE" Or cmbAplicativoAfip.Text = "SIPRIB" Or cmbAplicativoAfip.Text = "DRAGMA" Then
               Me.tsbExportarSICORE.Visible = True
               tsbExportarSICORE.Text = "Exportar para " & Me.cmbAplicativoAfip.Text
            ElseIf Me.cmbAplicativoAfip.Text = "SIRCAR" Then
               Me.tsbExportarSICORE.Visible = False
               Me.tsbGenerarArchivo.Visible = True
            Else
               Me.tsbExportarSICORE.Visible = False
            End If
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      Try
         If e.ColumnIndex = 0 And e.RowIndex <> -1 Then

            Try

               Me.Cursor = Cursors.WaitCursor

               'Visualiza el Bomprobante.
               Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
               Dim ccp As Entidades.CuentaCorrienteProv

               ccp = reg.GetPorRetencion(actual.Sucursal.Id,
                                          Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()),
                                          Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoImpuesto").Value.ToString(),
                                          Integer.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("EmisorRetencion").Value.ToString()),
                                          Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroRetencion").Value.ToString()))


               For i As Integer = ccp.Retenciones.Count - 1 To 0 Step -1
                  If ccp.Retenciones(i).TipoImpuesto.IdTipoImpuesto.ToString() <> Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoImpuesto").Value.ToString() Then
                     ccp.Retenciones.RemoveAt(i)
                  End If
               Next


               Dim ret As RetencionImprimir = New RetencionImprimir()
               ret.ImprimirRetencion(ccp)

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

   Private Sub chbAplicativoAfip_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicativoAfip.CheckedChanged
      Me.cmbAplicativoAfip.Enabled = Me.chbAplicativoAfip.Checked
      If Not Me.chbAplicativoAfip.Checked Then
         Me.cmbAplicativoAfip.SelectedIndex = -1
      Else
         Me.cmbAplicativoAfip.SelectedIndex = 0
         Me.cmbAplicativoAfip.Focus()
      End If
      If dgvDetalle.DataSource IsNot Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
         tsbExportarSICORE.Visible = False
      End If
   End Sub

   Private Sub tsbExportarSICORE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportarSICORE.Click
      Try
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         If Me.cmbAplicativoAfip.Text = "SICORE" Then
            stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._sicore.CantidadDeLineasaProcesar)
         ElseIf Me.cmbAplicativoAfip.Text = "SIPRIB" Then
            stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._siprib.CantidadDeLineasaProcesar)
         ElseIf Me.cmbAplicativoAfip.Text = "DRAGMA" Then
            stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._dragma.CantidadDeLineasaProcesar)
         End If

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim ar As ArchivoDestinoExportacion = New ArchivoDestinoExportacion()
            Dim destino As String = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + Reglas.Publicos.CuitEmpresa + "_"
            If Me.cmbAplicativoAfip.Text = "SICORE" Then
               ar.txtArchivoDestino.Text = destino + Me.cmbAplicativoAfip.Text _
                                    + "_" + Me.dtpDesde.Value.ToString("ddMMyyyy") + "_" + Me.dtpHasta.Value.ToString("ddMMyyyy") + ".txt"
            ElseIf Me.cmbAplicativoAfip.Text = "SIPRIB" Then
               ar.txtArchivoDestino.Text = destino + Me.cmbAplicativoAfip.Text _
                                    + "_" + Me.dtpDesde.Value.ToString("ddMMyyyy") + "_" + Me.dtpHasta.Value.ToString("ddMMyyyy") + ".txt"
            ElseIf Me.cmbAplicativoAfip.Text = "DRAGMA" Then
               ar.txtArchivoDestino.Text = destino + Me.cmbAplicativoAfip.Text _
                                    + "_" + Me.dtpDesde.Value.ToString("ddMMyyyy") + "_" + Me.dtpHasta.Value.ToString("ddMMyyyy") + ".csv"
            End If

            If ar.ShowDialog() = Windows.Forms.DialogResult.Yes Then
               If Not String.IsNullOrEmpty(ar.txtArchivoDestino.Text) Then
                  If Me.cmbAplicativoAfip.Text = "SICORE" Then
                     Me._sicore.GrabarArchivo(ar.txtArchivoDestino.Text)
                     MessageBox.Show("Se Exportaron " & Me._sicore.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  ElseIf Me.cmbAplicativoAfip.Text = "SIPRIB" Then
                     Me._siprib.GrabarArchivo(ar.txtArchivoDestino.Text)
                     MessageBox.Show("Se Exportaron " & Me._siprib.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  ElseIf Me.cmbAplicativoAfip.Text = "DRAGMA" Then
                     Me._dragma.GrabarArchivo(ar.txtArchivoDestino.Text)
                     MessageBox.Show("Se Exportaron " & Me._dragma.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  End If
               End If
            End If
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbAplicativoAfip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicativoAfip.SelectedIndexChanged
      Try
         If dgvDetalle.DataSource IsNot Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
            tsbExportarSICORE.Visible = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGenerarArchivo_Click(sender As Object, e As EventArgs) Handles tsbGenerarArchivo.Click
      Try
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         If Me.cmbAplicativoAfip.Text = "SIRCAR" Then
            stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._sircar.CantidadDeLineasaProcesar)
         End If

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim ar As ArchivoDestinoExportacion = New ArchivoDestinoExportacion()
            Dim destino As String = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + Reglas.Publicos.CuitEmpresa + "_"
            If Me.cmbAplicativoAfip.Text = "SIRCAR" Then
               ar.txtArchivoDestino.Text = destino + Me.cmbAplicativoAfip.Text _
                                    + "_" + Me.dtpDesde.Value.ToString("ddMMyyyy") + "_" + Me.dtpHasta.Value.ToString("ddMMyyyy") + ".txt"
            End If

            If ar.ShowDialog() = Windows.Forms.DialogResult.Yes Then
               If Not String.IsNullOrEmpty(ar.txtArchivoDestino.Text) Then

                  If Me.cmbAplicativoAfip.Text = "SIRCAR" Then
                     Me._sircar.GrabarArchivo(ar.txtArchivoDestino.Text, Entidades.TipoImpuesto.Tipos.RIIBB)
                     MessageBox.Show("Se Exportaron " & Me._sircar.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  End If

               End If
            End If
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today

      Me.chbTipoImpuesto.Checked = False
      Me.chbAplicativoAfip.Checked = False
      Me.tsbExportarSICORE.Visible = False

      Me.txtTotal.Text = "0.00"

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.cmbSucursal.Text = "(Todos)"
   End Sub

   Private Sub CargaGrillaDetalle()

      Try


         Dim IdTipoRetencion As String = String.Empty
         Dim IdTipoImpuesto As String = String.Empty
         Dim AplicativoAfip As String = String.Empty
         Dim Total As Decimal = 0

         If Me.cmbTipoImpuesto.Enabled Then
            IdTipoImpuesto = Me.cmbTipoImpuesto.SelectedValue.ToString()
         End If

         If Me.cmbAplicativoAfip.Enabled Then
            AplicativoAfip = Me.cmbAplicativoAfip.SelectedValue.ToString()
         End If

         Dim oRetenciones As Reglas.RetencionesCompras = New Reglas.RetencionesCompras()

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oRetenciones.GetTodos(cmbSucursal.GetSucursales(),
                                             Me.dtpDesde.Value, Me.dtpHasta.Value,
                                             IdTipoRetencion,
                                             IdTipoImpuesto, AplicativoAfip)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Ver") = "..."

            drCl("IdTipoImpuesto") = dr("IdTipoImpuesto")
            drCl("FechaEmision") = Date.Parse(dr("FechaEmision").ToString())
            drCl("NombreTipoImpuesto") = dr("NombreTipoImpuesto").ToString()
            drCl("EmisorRetencion") = Integer.Parse(dr("EmisorRetencion").ToString())
            drCl("NumeroRetencion") = Long.Parse(dr("NumeroRetencion").ToString())
            drCl("IdProveedor") = Long.Parse(dr("IdProveedor").ToString())
            drCl("CodigoProveedor") = Long.Parse(dr("CodigoProveedor").ToString())
            drCl("NombreProveedor") = dr("NombreProveedor").ToString()

            If Not String.IsNullOrEmpty(dr("NroPlanillaEgreso").ToString()) Then
               drCl("IdCajaEgreso") = Integer.Parse(dr("IdCajaEgreso").ToString())
               drCl("NroPlanillaEgreso") = Integer.Parse(dr("NroPlanillaEgreso").ToString())
               drCl("NroMovimientoEgreso") = Integer.Parse(dr("NroMovimientoEgreso").ToString())
               drCl("Egreso") = "C: " + dr("IdCajaEgreso").ToString() + " - P: " + dr("NroPlanillaEgreso").ToString() + " - M: " & dr("NroMovimientoEgreso").ToString()
            End If

            drCl("BaseImponible") = Decimal.Parse(dr("BaseImponible").ToString())
            drCl("Alicuota") = Decimal.Parse(dr("Alicuota").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            Total = Total + Decimal.Parse(dr("ImporteTotal").ToString())

            dt.Rows.Add(drCl)

         Next

         txtTotal.Text = Total.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dt

         If Me.cmbAplicativoAfip.Text = "SICORE" Then
            Me.CrearSICORE(dtDetalle)
         ElseIf Me.cmbAplicativoAfip.Text = "SIPRIB" Then
            Me.CrearSIPRIB(dtDetalle)
         ElseIf Me.cmbAplicativoAfip.Text = "SIRCAR" Then
            Me.CrearSIRCAR(dtDetalle)
         ElseIf Me.cmbAplicativoAfip.Text = "DRAGMA" Then
            Me.CrearDRAGMA(dtDetalle)
         End If

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdTipoImpuesto", System.Type.GetType("System.String"))
         .Columns.Add("FechaEmision", System.Type.GetType("System.DateTime"))
         .Columns.Add("NombreTipoImpuesto", System.Type.GetType("System.String"))
         .Columns.Add("EmisorRetencion", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroRetencion", System.Type.GetType("System.Int64"))
         .Columns.Add("IdProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("IdCajaEgreso", System.Type.GetType("System.Int32"))
         .Columns.Add("NroPlanillaEgreso", System.Type.GetType("System.Int32"))
         .Columns.Add("NroMovimientoEgreso", System.Type.GetType("System.Int32"))
         .Columns.Add("Egreso", System.Type.GetType("System.String"))
         .Columns.Add("BaseImponible", System.Type.GetType("System.Decimal"))
         .Columns.Add("Alicuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Sub CrearSICORE(ByVal dt As DataTable)
      Try
         Me._sicore = New SICORE()

         Dim linea As SICORELinea

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Value = 0

         Dim i As Integer = 0
         Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
         Dim cctt As Entidades.CuentaCorrienteProv

         For Each dr As DataRow In dt.Rows
            Me.tspBarra.Value = i
            'AR: Esto porque esta? Puede ser que venga vacio???
            If String.IsNullOrEmpty(dr("IdProveedor").ToString()) Or String.IsNullOrEmpty(dr("NumeroComprobante").ToString()) Then
               Continue For
            End If
            'si esta anulada paso al proximo registro y no lo genero
            cctt = reg.GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                              Long.Parse(dr("IdProveedor").ToString()),
                              dr("IdTipoComprobante").ToString(),
                              dr("Letra").ToString(),
                              Int32.Parse(dr("CentroEmisor").ToString()),
                              Long.Parse(dr("NumeroComprobante").ToString()))

            For ii As Integer = cctt.Retenciones.Count - 1 To 0 Step -1
               If cctt.Retenciones(ii).TipoImpuesto.IdTipoImpuesto.ToString() <> dr("IdTipoImpuesto").ToString() Then
                  cctt.Retenciones.RemoveAt(ii)
               End If
            Next

            linea = New SICORELinea()

            'Código de comprobante / Entero / Desde 1 Hasta 2 / Longitud 2
            Select Case cctt.TipoComprobante.IdTipoComprobante
               Case Entidades.TipoComprobante.Tipos.COMPRAS.ToString()
                  linea.CodigoDeComprobante = 1 'Factura
               Case Entidades.TipoComprobante.Tipos.PAGO.ToString()
                  linea.CodigoDeComprobante = 6 'Orden de Pago
            End Select
            'Fecha de emisión del comprobante (DD/MM/YYYY) / Fecha / Desde 3 Hasta 12 / Longitud 10
            linea.FechaEmisionDelComprobante = cctt.Fecha
            'Número del comprobante / Texto / Desde 13 Hasta 28 / Longitud 16
            linea.NroDeComprobante = cctt.NumeroComprobante.ToString().Trim()
            'Importe del comprobante / Decimal / Desde 29 Hasta 44 / Longitud 16
            linea.ImporteDelComprobante = cctt.ImporteTotal
            Select Case cctt.Retenciones(0).TipoImpuesto.IdTipoImpuesto
               Case Entidades.TipoImpuesto.Tipos.RGANA
                  'Código de impuesto / Entero / Desde 45 Hasta 47 / Longitud 3
                  linea.CodigoDeImpuesto = 217 'Impuesto a las Ganancias
                  'Código de operación / Entero / Desde 51 Hasta 51 / Longitud 1
                  linea.CodigoDeOperacion = 1 ' Retencion
               Case Entidades.TipoImpuesto.Tipos.RIVA    'SPC: Parametrizar en TipoImpuesto
                  'Código de impuesto / Entero / Desde 45 Hasta 47 / Longitud 3
                  linea.CodigoDeImpuesto = 767 'Impuesto a las Ganancias
                  'Código de operación / Entero / Desde 51 Hasta 51 / Longitud 1
                  linea.CodigoDeOperacion = 1 ' Retencion
            End Select
            'Código de régimen / Entero / Desde 48 Hasta 50 / Longitud 3
            linea.CodigoDeRegimen = cctt.Retenciones(0).Regimen.CodigoAfip
            'Base de cálculo / Decimal / Desde 52 Hasta 65 / Longitud 14
            linea.BaseDeCalculo = cctt.Retenciones(0).BaseImponible
            'Fecha de emisión de la retención (DD/MM/YYYY) / Fecha / Desde 66 Hasta 75 / Longitud 10
            linea.FechaEmisionRetencion = cctt.Retenciones(0).FechaEmision
            'Código de condición / Entero / Desde 76 Hasta 77 / Longitud 2
            linea.CodigoDeCondicion = 1 'Inscripto
            'Retención practicada a sujetos suspendidos según: / Entero / Desde 78 Hasta 78 / Longitud 1
            linea.RetencionPracticadaASuspendidos = 0 'Ninguno
            'Importe de la retención / Decimal / Desde 79 Hasta 92 / Longitud 14
            linea.ImporteDeLaRetencion = cctt.Retenciones(0).ImporteTotal
            'Porcentaje de exclusión / Decimal / Desde 93 Hasta 98 / Longitud 6
            linea.PorcentajeDeExclusion = 0 ' cctt.Retenciones(0).Alicuota
            'Fecha de emisión del boletín / Fecha / Desde 99 Hasta 108 / Longitud 10
            linea.FechaEmisionDelBoletin = cctt.Retenciones(0).FechaEmision
            'Tipo de documento del retenido / Entero / Desde 109 Hasta 110 / Longitud 2

            'Aunque podria no tener el CUIT, por la categoria fiscal deben reportarlo. Es preferible que haya problemas y que corrijan el dato.
            'If Not String.IsNullOrEmpty(cctt.Proveedor.CuitProveedor) Then

            If cctt.Proveedor.CategoriaFiscal.SolicitaCUIT Then
               linea.TipoDocumentoDelRetenido = New Reglas.AFIPTiposDocumentos().GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
               'Número de documento del retenido / Texto / Desde 111 Hasta 130 / Longitud 20
               linea.NumeroDocumentoDelRetenido = cctt.Proveedor.CuitProveedor
            Else
               linea.TipoDocumentoDelRetenido = 87 'C.D.I.
               'Número de documento del retenido / Texto / Desde 111 Hasta 130 / Longitud 20
               linea.NumeroDocumentoDelRetenido = cctt.Proveedor.NroDocProveedor.ToString()
            End If

            ''estos son datos para el certificado del exterior -----------------------------------------
            'Número certificado original / Entero / Desde 131 Hasta 144 / Longitud 14
            'Denominación del ordenante / Texto / Desde 145 Hasta 174 / Longitud 30
            'Acrecentamiento / Entero / Desde 175 Hasta 175 / Longitud 1
            'Cuit del país del retenido / Texto / Desde 176 Hasta 186 / Longitud 11
            'Cuit del ordenante / Texto / Desde 187 Hasta 197 / Longitud 11

            'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
            linea.Procesar = True

            Me._sicore.Lineas.Add(linea)

            'If linea.TieneError Then
            'Me.tsbVerRegistrosConErrores.Enabled = True
            'Me.dgvDetalle.Rows(linea.Linea - 1).DefaultCellStyle.BackColor = Color.LightSalmon
            'Me.dgvDetalle.Rows(linea.Linea - 1).Cells("colError").Value = linea.TipoError
            'dr.Proceso = False
            'Me.dgvDetalle.Rows(linea.Linea - 1).Cells("ProcesoDataGridViewCheckBoxColumn").ReadOnly = True
            'End If
            i += 1
         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub CrearSIPRIB(ByVal dt As DataTable)
      Dim i As Integer = 0

      Try
         Me._siprib = New SIPRIBArchivo()

         Dim linea As SIPRIBArchivoLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows

            Me.tspBarra.Value = i

            i += 1

            linea = New SIPRIBArchivoLinea()

            With linea
               'Se pone fijo el 1 porque es una Retencion.
               .CodigoOperacion = 1
               .FechaDeLaRetencion = DateTime.Parse(dr("FechaEmision").ToString())
               'queda fijo por el momento con el valor:
               '029 Art.10 - inciso J - (Res. Gral. 15/97 y Modif.)
               .CodigoArticulo = Integer.Parse(dr("CodigoArticuloInciso").ToString())

               .IdTipoComprobante = dr("IdTipoComprobante").ToString()

               'Letra de comprobante
               .LetraComprobante = dr("Letra").ToString()

               'Nro. del comprobante
               .NroComprobante = Decimal.Parse(dr("NumeroComprobante").ToString())

               'Fecha de emisión comprobante (menor o igual a la fecha de la retención/percepción).
               .FechaEmisionComprobante = DateTime.Parse(dr("FechaEmision").ToString())

               'Importe comprobante (debe ser mayor a 0). Numérico 9 enteros 2 decimales separados por comas.
               If New Reglas.CategoriasFiscales().GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString())).IvaDiscriminado Then
                  .ImporteComprobante = Decimal.Parse(dr("ImporteComprobante").ToString())
               Else
                  .ImporteComprobante = Decimal.Parse(dr("ImporteComprobante").ToString())
               End If


               'Tipo documento retenido/percibido. Numérico de 1 posición
               'va fijo el 3 porque es el CUIT
               .TipoDocPercibido = 3

               'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
               If Not String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
                  .NroDocPercibido = Long.Parse(dr("CuitProveedor").ToString())
               Else
                  stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
                  Continue For
               End If

               'Condición frente a Ingresos Brutos: Numérico de 1 posición 
               If Boolean.Parse(dr("EsPasibleRetencionIIBB").ToString()) Then
                  .CondicionFrenteAIIBB = 1 'Inscripto 
               Else
                  .CondicionFrenteAIIBB = 3 'No inscripto, no obligado a inscribirse.
               End If

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

               'Situación frente a IVA: Numérico de 1 posición.
               .IdCategoriaFiscal = Short.Parse(dr("IdCategoriaFiscal").ToString())

               'Marca inscripción en otros gravámenes (Artículo 138 Código Fiscal): Numérico de 1 posición
               'lo puse fijo a No inscripto en otros gravámenes
               .MarcaInscripcionEnOtrosGravamenes = 0

               'Marca inscripción en Derecho de Registro e Inspección: Numérico de 1 posición
               'lo puse fijo a No inscripto en derecho de registro e inspección
               .MarcaInscDerechoRegistroInspeccion = 0

               'Importe Otros Gravámenes 
               If .MarcaInscDerechoRegistroInspeccion = 1 Then
                  .ImporteOtrosGravamenes = 0
               End If

               'Importe I.V.A. 
               If .SituacionFrenteAIVA = 1 Then
                  .ImporteIVA = 0
               End If

               'Monto imponible
               .MontoImponible = Decimal.Parse(dr("BaseImponible").ToString())

               'Alícuota
               .Alicuota = Decimal.Parse(dr("Alicuota").ToString())

               'Impuesto determinado
               .ImpuestoDeterminado = Decimal.Parse(dr("ImporteTotal").ToString())

               'Monto deducible derecho de registro e inspección
               If .MarcaInscDerechoRegistroInspeccion = 1 Then
                  .MontoDeducible = 0
               End If

               'Monto retenido
               .MontoRetenido = .ImpuestoDeterminado - .MontoDeducible

               'Artículo/Inciso para el cálculo del monto de la retención/percepción
               'fijo por 003	Art. 5° inciso 2)(Res. Gral. 15/97 y Modif.)
               .ArticuloParaPercepcion = Integer.Parse(dr("ArticuloInciso").ToString())

               'If .CondicionFrenteAIIBB = 1 Then

               '   'Tipo de exención: numérico de 1 posición
               '   .TipoDeExension = Short.Parse(dr("IdTipoDeExension").ToString())

               '   'Año de exención:  numérico de 4 posiciones
               '   If .TipoDeExension = 0 Or .TipoDeExension = 4 Then
               '      .AñoDeExension = 0
               '   Else
               '      .AñoDeExension = Integer.Parse(dr("AnioExension").ToString())
               '   End If

               '   'Número de certificado de exención: alfanumérico de 6 posiciones
               '   .NumeroCertificadoExencion = dr("NroCertExension").ToString()

               '   'Número de certificado propio:  alfanumérico de 12 posiciones
               '   .NumeroCertificadoPropio = dr("NroCertPropio").ToString()

               'Else

               .TipoDeExension = 0
               .AñoDeExension = 0
               .NumeroCertificadoExencion = ""
               .NumeroCertificadoPropio = ""

               'End If

               linea.Procesar = True

            End With

            Me._siprib.Lineas.Add(linea)

         Next

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub CrearSIRCAR(ByVal dt As DataTable)
      Dim i As Integer = 0

      Try
         Me._sircar = New SIRCARArchivo()

         Dim linea As SIRCARArchivoLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows

            Me.tspBarra.Value = i

            i += 1

            linea = New SIRCARArchivoLinea()

            With linea
               'Número de Renglón (único por archivo)
               .NumeroRenglon = i

               'Origen del Comprobante 
               .OrigenComprobante = 1

               '.IdTipoComprobante = dr("IdTipoComprobante").ToString()
               .TipoComprobante = 1

               'Nro. del comprobante
               .NroComprobante = Decimal.Parse(dr("NumeroComprobante").ToString())

               'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
               If Not String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
                  .CuitProveedor = Long.Parse(dr("CuitProveedor").ToString())
               Else
                  stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
                  Continue For
               End If

               .FechaDeLaRetencion = DateTime.Parse(dr("FechaEmision").ToString())

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
               .MontoImponible = Math.Round(Decimal.Parse(dr("BaseImponible").ToString()), 2)

               'Alícuota (porcentaje sin separador de miles)
               .Alicuota = Decimal.Parse(dr("Alicuota").ToString())

               'Impuesto determinado
               .ImpuestoDeterminado = Decimal.Parse(dr("ImporteTotal").ToString())

               'Monto Retenido (numérico sin separador de miles, se obtiene de multiplicar el campo 7 por el campo 8 y dividirlo por 100) 
               .MontoRetenido = Math.Round(.ImpuestoDeterminado, 2)

               .TipoRegimen = New Reglas.Regimenes().GetUno(Integer.Parse(dr("IdRegimen").ToString())).CodigoAfip

               Dim Localidad As Entidades.Localidad = New Reglas.Localidades().GetUna(actual.Sucursal.Localidad.IdLocalidad)

               .Jurisdiccion = New Reglas.Provincias().GetUno(Localidad.IdProvincia).Jurisdiccion

               linea.Procesar = True

            End With

            Me._sircar.Lineas.Add(linea)

         Next

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub CrearDRAGMA(ByVal dt As DataTable)
      Dim i As Integer = 0

      Try
         Me._dragma = New DRAGMA()

         Dim linea As DRAGMALinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows

            Me.tspBarra.Value = i

            i += 1

            linea = New DRAGMALinea()

            With linea
               .TipoRetencionPercepcion = "R"
               If Not String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
                  .CuitContribuyenteRetencion = Long.Parse(dr("CuitProveedor").ToString())
               Else
                  stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
                  Continue For
               End If
               .AplicacionDeRetencion = 1
               .NroSecuenciaComprobante = Integer.Parse(dr("SecuenciaRetencion").ToString())
               .FechaEmisionDelComprobante = DateTime.Parse(dr("FechaEmision").ToString())
               .CodigoImpuestoRetencion = 3
               Select Case dr("IdTipoComprobante2").ToString()
                  Case "FACTCOM"
                     .TipoComprobanteRetencion = "F"
                  Case "NCREDCOM"
                     .TipoComprobanteRetencion = "C"
                  Case "NDEBCOM"
                     .TipoComprobanteRetencion = "D"
                  Case Else
                     .TipoComprobanteRetencion = "O"
               End Select
               .NroDeComprobanteRetencion = dr("NumeroComprobante2").ToString()
               .LetraComprobanteRetencion = dr("Letra2").ToString()
               .AlicuotaDelComprobante = Decimal.Parse(dr("Alicuota").ToString())
               .MontoDelComprobante = Math.Round(Decimal.Parse(dr("BaseImponible").ToString()), 2)
               .MontoRetenidoComprobante = Math.Round(Decimal.Parse(dr("ImporteTotal").ToString()), 2)

               linea.Procesar = True
            End With
            _dragma.Lineas.Add(linea)
         Next

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try
   End Sub

#End Region

End Class