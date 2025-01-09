Public Class ConsultarCtaCteProveedoresDH

#Region "Campos"

   Private _publicos As Publicos

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

         chbVistaContable.Checked = Reglas.Publicos.CtaCteProv.CtaCteProveedoresDHVistaContable

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         dgvDetalle.AgregarFiltroEnLinea({})

         Me.PreferenciasLeer(dgvDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub ConsultarCtaCteProveedoresDH_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Me.bscProveedor.Focus()
   End Sub
#End Region

#Region "Eventos"

   Private Sub ConsultarCtaCteProveedoresDH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: Debe seleccionar un Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscProveedor.Focus()
            Exit Sub
         End If

         If Me.chbFechas.Checked And Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("ATENCION: La fecha 'Desde' NO puede ser mayor la la fecha 'Hasta'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
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

   Private Sub dgvDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dgvDetalle.ClickCellButton
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim dr As DataRow = dgvDetalle.FilaSeleccionada(Of DataRow)()

         If dr IsNot Nothing Then


            Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())

            If oTipoComprobante.EsRecibo = True Then

               '  If dr("IdTipoComprobante").ToString() = "PAGO" Or dr("IdTipoComprobante").ToString() = "PAGOPROV" Then

               Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
               Dim ctacte As Entidades.CuentaCorrienteProv = reg.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                  Long.Parse(Me.bscCodigoProveedor.Tag.ToString()),
                                                                  dr("IdTipoComprobante").ToString(),
                                                                  dr("Letra").ToString(),
                                                                  Integer.Parse(dr("CentroEmisor").ToString()),
                                                                  Long.Parse(dr("NumeroComprobante").ToString()))
               Dim imp As PagosImprimir = New PagosImprimir()
               imp.ImprimirPago(ctacte, True)
            Else

               Dim oCompras As Reglas.Compras = New Reglas.Compras()
               Dim Compra As Entidades.Compra = oCompras.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                          dr("IdTipoComprobante").ToString(),
                                                          dr("Letra").ToString(),
                                                          Integer.Parse(dr("CentroEmisor").ToString()),
                                                          Long.Parse(dr("NumeroComprobante").ToString()),
                                                          Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

               Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

               oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
            End If
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
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

   Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechas.CheckedChanged


      Me.dtpDesde.Enabled = Me.chbFechas.Checked
      Me.dtpHasta.Enabled = Me.chbFechas.Checked

      Me.lblSaldoActual.Visible = Me.chbFechas.Checked
      Me.txtSaldoActual.Visible = Me.chbFechas.Checked

      Me.lblSaldoInicial.Visible = Me.chbFechas.Checked
      Me.txtSaldoInicial.Visible = Me.chbFechas.Checked

      If Me.chbFechas.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
         Me.txtSaldoActual.Text = "0.00"
         Me.txtSaldoInicial.Text = "0.00"
         Me.txtSaldoFinal.Text = "0.00"
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Proveedor: " & Me.bscCodigoProveedor.Text & " - " & Me.bscProveedor.Text

         If Me.chbFechas.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & " Fechas: desde " & dtpDesde.Text & " hasta " & dtpHasta.Text
         End If

         '0 Es TODOS
         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicial", Me.txtSaldoInicial.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", Me.txtSaldoActual.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinal", Me.txtSaldoFin.Text))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteProveedoresDH.rdlc", "SistemaDataSet_CuentasCorrientesDH", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized

         If bscCodigoProveedor.Selecciono Then
            If Not String.IsNullOrWhiteSpace(bscCodigoProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
               frmImprime.Destinatarios = bscCodigoProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
            End If
         ElseIf bscProveedor.Selecciono Then
            If Not String.IsNullOrWhiteSpace(bscProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
               frmImprime.Destinatarios = bscProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
            End If
         End If

         frmImprime.Show()
         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(dgvDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub
         dgvDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub
         dgvDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

      Me.cmbGrabanLibro.SelectedIndex = 0

      Me.bscCodigoProveedor.Enabled = True
      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Enabled = True
      Me.bscProveedor.Text = String.Empty

      Me.chbFechas.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtSaldoActual.Text = "0.00"
      Me.txtSaldoInicial.Text = "0.00"
      Me.txtSaldoFin.Text = "0.00"

      cmbSucursal.Refrescar()

      Me.bscProveedor.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         Dim coe As Decimal = 1
         Dim columnaDebe As String = "Debe"
         Dim columnaHaber As String = "Haber"

         If chbVistaContable.Checked Then
            coe = -1
            columnaDebe = "Haber"
            columnaHaber = "Debe"
         End If

         Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()

         Dim Saldo As Decimal = 0

         Dim proveedor As Entidades.Proveedor

         Dim oProveedor As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()
         proveedor = oProveedor.GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

         Dim Desde As Date = Nothing
         Dim Hasta As Date = Nothing

         Dim FechaUtilizada As String = String.Empty

         Me.txtSaldoActual.Text = (oCtaCte.GetSaldoProveedor(cmbSucursal.GetSucursales(), proveedor, Nothing, False, Nothing, "TODOS") * coe).ToString("N2")

         If Me.chbFechas.Checked Then
            Desde = Me.dtpDesde.Value
            Hasta = Me.dtpHasta.Value

            Me.txtSaldoInicial.Text = (oCtaCte.GetSaldoProveedor(cmbSucursal.GetSucursales(), proveedor, Desde.AddDays(-1), False, Nothing, "TODOS") * coe).ToString("N2")
         Else
            Me.txtSaldoInicial.Text = "0.00"
         End If

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oCtaCte.GetPorProveedor(cmbSucursal.GetSucursales(), proveedor, Desde, Hasta, Me.cmbGrabanLibro.Text)

         dt = Me.CrearDT()

         Saldo = Decimal.Parse(Me.txtSaldoInicial.Text)

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Ver") = "..."
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            '-- REQ-35958.- ------------------------------------------------------
            drCl("PeriodoFiscal") = If(Not String.IsNullOrEmpty(dr("PeriodoFiscal").ToString()), Integer.Parse(dr("PeriodoFiscal").ToString()).ToString("####/##"), String.Empty)
            '---------------------------------------------------------------------
            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())

            If Decimal.Parse(dr("ImporteTotal").ToString()) > 0 Then
               drCl(columnaDebe) = Decimal.Parse(dr("ImporteTotal").ToString())
            Else
               drCl(columnaHaber) = Decimal.Parse(dr("ImporteTotal").ToString()) * (-1)
            End If

            Saldo = Saldo + (Decimal.Parse(dr("ImporteTotal").ToString()) * coe)

            drCl("Saldo") = Saldo

            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)

         Next

         Me.txtSaldoFin.Text = Saldo.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registro/s"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver", System.Type.GetType("System.String"))
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         '-- REQ-35958.- ------------------------------------------------------
         .Columns.Add("PeriodoFiscal", System.Type.GetType("System.String"))
         '---------------------------------------------------------------------
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("Debe", System.Type.GetType("System.Decimal"))
         .Columns.Add("Haber", System.Type.GetType("System.Decimal"))
         .Columns.Add("Saldo", System.Type.GetType("System.Decimal"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If


         If Me.bscCodigoProveedor.Selecciono And Me.bscProveedor.Selecciono Then
            .AppendFormat(" Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chbFechas.Checked Then
            .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         End If

         If Me.cmbGrabanLibro.Text <> "TODOS" Then
            .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.chbVistaContable.Checked Then
            .AppendFormat(" Vista Contable: SI")
         End If


      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
#End Region


End Class