Public Class ConsultarCtaCteDetProveedorDH

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
            cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            chbVistaContable.Checked = Reglas.Publicos.CtaCteProv.CtaCteProveedoresDHVistaContable

            dgvDetalle.AgregarFiltroEnLinea({})

            PreferenciasLeer(dgvDetalle, tsbPreferencias)
         End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      bscProveedor.Focus()
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

#Region "Eventos ToolBar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If dgvDetalle.Rows.Count = 0 Then Exit Sub

            Dim dt = DirectCast(dgvDetalle.DataSource, DataTable)

            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicial", txtSaldoInicial.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", txtSaldoActual.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinal", txtSaldoFinal.Text))

            Dim frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleProveedoresDH.rdlc", "SistemaDataSet_CuentasCorrientesPagosDH",
                                               dt, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Text
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
         End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() dgvDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() dgvDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(dgvDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Buscador Proveedor"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProveedor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

#End Region

   Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechas.CheckedChanged
      dtpDesde.Enabled = chbFechas.Checked
      dtpHasta.Enabled = chbFechas.Checked

      lblSaldoActual.Visible = chbFechas.Checked
      txtSaldoActual.Visible = chbFechas.Checked

      lblSaldoInicial.Visible = chbFechas.Checked
      txtSaldoInicial.Visible = chbFechas.Checked

      If chbFechas.Checked Then
         dtpDesde.Value = Date.Now
         dtpHasta.Value = Date.Now
         txtSaldoActual.SetValor(0D)
         txtSaldoInicial.SetValor(0D)
         txtSaldoFinal.SetValor(0D)
      End If

      dtpDesde.Focus()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
               ShowMessage("ATENCION: Debe seleccionar un Proveedor.")
               bscProveedor.Focus()
               Exit Sub
            End If

            If chbFechas.Checked And dtpDesde.Value.Date > dtpHasta.Value.Date Then
               ShowMessage("ATENCION: La fecha 'Desde' NO puede ser mayor la la fecha 'Hasta'.")
               dtpDesde.Focus()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If dgvDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End Sub)

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      cmbGrabanLibro.SelectedIndex = 0
      cmbSucursal.Refrescar()

      bscCodigoProveedor.Permitido = True
      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing
      bscProveedor.Permitido = True
      bscProveedor.Text = String.Empty

      chbFechas.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      optFechaEmision.Checked = True

      dgvDetalle.ClearFilas()

      txtSaldoFinal.SetValor(0D)

      bscProveedor.Select()

      tssRegistros.Text = dgvDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim coe As Decimal = 1
      Dim columnaDebe As String = "Debe"
      Dim columnaHaber As String = "Haber"

      If chbVistaContable.Checked Then
         coe = -1
         columnaDebe = "Haber"
         columnaHaber = "Debe"
      End If

      Dim rProveedor = New Reglas.Proveedores()
      Dim proveedor = rProveedor._GetUno(Long.Parse(bscCodigoProveedor.Tag.ToString()))

      Dim desde As Date? = Nothing
      Dim hasta As Date? = Nothing

      Dim rCtaCte = New Reglas.CuentasCorrientesProv()
      txtSaldoActual.SetValor(rCtaCte.GetSaldoProveedor(cmbSucursal.GetSucursales(), proveedor, Nothing, False, Nothing, "TODOS") * coe)

      If chbFechas.Checked Then
         desde = dtpDesde.Value
         hasta = dtpHasta.Value
         txtSaldoInicial.SetValor(rCtaCte.GetSaldoProveedor(cmbSucursal.GetSucursales(), proveedor, desde.Value.AddDays(-1), False, Nothing, "TODOS") * coe)
      Else
         txtSaldoInicial.SetValor(0D)
      End If

      Dim FechaUtilizada = If(optFechaEmision.Checked, "EMISION", "VENCIMIENTO")

      'Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      Dim oCtaCteDet As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos()
      Using dtDetalle = oCtaCteDet.GetPorProveedor(cmbSucursal.GetSucursales(), proveedor, FechaUtilizada, desde, hasta,
                                                   cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)())
         Dim Saldo = txtSaldoInicial.ValorNumericoPorDefecto(0D)
         Dim dt = CrearDT()
         For Each dr As DataRow In dtDetalle.Rows
            Dim drCl = dt.NewRow()

            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("CuotaNumero") = Integer.Parse(dr("CuotaNumero").ToString())
            drCl("Fecha") = DateTime.Parse(dr("Fecha").ToString())
            drCl("FechaVencimiento") = DateTime.Parse(dr("FechaVencimiento").ToString())

            If Decimal.Parse(dr("ImporteCuota").ToString()) > 0 Then
               drCl(columnaDebe) = Decimal.Parse(dr("ImporteCuota").ToString())
            Else
               drCl(columnaHaber) = Decimal.Parse(dr("ImporteCuota").ToString()) * (-1)
            End If

            Saldo = Saldo + (Decimal.Parse(dr("ImporteCuota").ToString()) * coe)
            drCl("Saldo") = Saldo
            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)
         Next

         txtSaldoFinal.SetValor(Saldo)

         dgvDetalle.DataSource = dt
      End Using

      tssRegistros.Text = dgvDetalle.CantidadRegistrosParaStatusbar()
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("CuotaNumero", GetType(Integer))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("FechaVencimiento", GetType(Date))
         .Columns.Add("Debe", GetType(Decimal))
         .Columns.Add("Haber", GetType(Decimal))
         .Columns.Add("Saldo", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))
      End With
      Return dtTemp
   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)

         If bscCodigoProveedor.Selecciono And bscProveedor.Selecciono Then
            .AppendFormat(" - Proveedor: {0} - {1} - Teléfono: {2}", bscCodigoProveedor.Text, bscProveedor.Text, txtTelefono.Text)
         End If

         If chbFechas.Checked Then
            .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         End If

         If cmbGrabanLibro.Text <> "TODOS" Then
            .AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         End If

         If chbVistaContable.Checked Then
            .AppendFormat(" - Vista Contable: SI")
         End If

         If optFechaEmision.Checked Then
            .AppendFormat(" - Filtro y Orden: Fecha Emisión")
         Else
            .AppendFormat(" - Filtro y Orden: Fecha Vencimiento")
         End If
      End With
      Return filtro.ToString()
   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      bscProveedor.Permitido = False
      bscCodigoProveedor.Permitido = False
      txtTelefono.Text = dr.Cells("TelefonoProveedor").Value.ToString()

      btnConsultar.Focus()
   End Sub

#End Region

End Class