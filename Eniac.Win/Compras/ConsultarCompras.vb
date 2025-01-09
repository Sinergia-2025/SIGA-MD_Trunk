Public Class ConsultarCompras

#Region "Constantes"
   Private Const funcionActual As String = "ConsultarCompras"
   Private Const funcionAnularComprobante As String = "AnularComprobanteCompra"
#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _puedeAnularComprobantes As Boolean
   Private _utilizaCentroCostos As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            tsbExpensas.Visible = Not Reglas.Publicos.TieneModuloExpensas
            tssExpensas.Visible = tsbExpensas.Visible

            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "COMPRAS")
            cmbTiposComprobantes.SelectedIndex = -1

            cmbGrabanLibro.Items.Insert(0, "TODOS")
            cmbGrabanLibro.Items.Insert(1, "SI")
            cmbGrabanLibro.Items.Insert(2, "NO")
            cmbGrabanLibro.SelectedIndex = 0

            cmbAfectaCaja.Items.Insert(0, "TODOS")
            cmbAfectaCaja.Items.Insert(1, "SI")
            cmbAfectaCaja.Items.Insert(2, "NO")
            cmbAfectaCaja.SelectedIndex = 0

            cmbEsComercial.Items.Insert(0, "TODOS")
            cmbEsComercial.Items.Insert(1, "SI")
            cmbEsComercial.Items.Insert(2, "NO")
            cmbEsComercial.SelectedIndex = 0

            _publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)
            _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "COMPRAS")
            _publicos.CargaComboRubrosCompras(Me.cboRubro)

            cmbEstados.Items.Insert(0, "PENDIENTE")
            cmbEstados.Items.Insert(1, "INVOCO")
            cmbEstados.Items.Insert(2, "FACTURADO")
            cmbEstados.Items.Insert(3, "ANULADO")
            cmbEstados.SelectedIndex = -1

            _publicos.CargaComboCategoriasProveedores(Me.cmbCategoria)
            _publicos.CargaComboUsuarios(Me.cmbUsuario)

            _publicos.CargaComboMonedas(cmbMoneda)
            cmbMoneda.SelectedValue = Entidades.Moneda.Peso

            _publicos.CargaComboDesdeEnum(cmbTipoConversion, Entidades.Moneda_TipoConversion.Comprobante)

            dtpPeriodoFiscal.Value = Today.PrimerDiaMes()

            _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

            If _utilizaCentroCostos Then
               _publicos.CargaComboCentroCostos(cmbCentroCosto)
               cmbCentroCosto.Visible = True
               chbCentroCosto.Visible = True
            Else
               cmbCentroCosto.Visible = False
               chbCentroCosto.Visible = False
            End If

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            'Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
            'Me._puedeAnularComprobantes = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, funcionActual, funcionAnularComprobante)
            'Me.tsbAnularComprobante.Enabled = Me._puedeAnularComprobantes
            dtpDesde.Focus()
         End Sub)

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

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbImprimir_Click_1(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugvDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(Me.components)
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
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewD.MdiParent = MdiParent
            UltraPrintPreviewD.Show()

            UltraPrintPreviewD.Focus()
         End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugvDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugvDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click
      TryCatched(
         Sub()
            If ugvDetalle.Rows.Count = 0 Then Exit Sub

            Dim dt = DirectCast(ugvDetalle.DataSource, DataTable)
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion))

            Dim frmImprime = New VisorReportes("Eniac.Win.ConsultarCompras.rdlc", "SistemaDataSet_Compras", dt, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Show()
         End Sub)
   End Sub

   Private Sub tsbExpensas_Click(sender As Object, e As EventArgs) Handles tsbExpensas.Click
      TryCatched(
         Sub()
            Dim dr As DataRow = ugvDetalle.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Dim reglaCompras = New Reglas.Compras()
               Dim dt = reglaCompras.GetExpensas(dr.Field(Of Integer)("IdSucursal"),
                                                 dr.Field(Of String)("IdTipoComprobante"),
                                                 dr.Field(Of String)("Letra"),
                                                 dr.Field(Of Integer)("CentroEmisor"),
                                                 dr.Field(Of Long)("NumeroComprobante"),
                                                 dr.Field(Of Long)("IdProveedor"))

               Dim total = DirectCast(dr("ImporteTotal"), Decimal)
               If Not Reglas.Publicos.PasajeComprasIncluyeImpuestos Then
                  total = DirectCast(dr("Neto"), Decimal) + DirectCast(dr("NetoNoGravado"), Decimal)
               End If

               If Reglas.Publicos.ExpensasRegistraComprasPor = Reglas.Publicos.ExpensasRegistraComprasPorEnum.AreaComun.ToString() Then
                  Using frm = New MovimientosDeCompraExpensas(total, dt, MovimientosDeCompraExpensas.Modo.Consultar)
                     frm.ShowDialog(Me)
                  End Using
               ElseIf Reglas.Publicos.ExpensasRegistraComprasPor = Reglas.Publicos.ExpensasRegistraComprasPorEnum.GrupoCama.ToString() Then
                  Using frm = New MovimientosDeCompraPorGrupo(total, dt, MovimientosDeCompraPorGrupo.Modo.Consultar)
                     frm.ShowDialog(Me)
                  End Using
               End If
            End If
         End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugvDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub

   Private Sub rdbPorPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPorPeriodoFiscal.CheckedChanged
      TryCatched(
         Sub()
            HabilitarFiltrosFecha(True, False)
            dtpPeriodoFiscal.Focus()
         End Sub)
   End Sub

   Private Sub rdbPorFechas_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPorFechas.CheckedChanged
      TryCatched(
         Sub()
            HabilitarFiltrosFecha(False, True)
            dtpDesde.Focus()
         End Sub)
   End Sub

   Private Sub rdbAmbos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAmbos.CheckedChanged
      TryCatched(
         Sub()
            HabilitarFiltrosFecha(True, True)
            dtpPeriodoFiscal.Focus()
         End Sub)
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
         Sub()
            txtNumero.Enabled = chbNumero.Checked
            If Not chbNumero.Checked Then
               txtNumero.Text = String.Empty
            Else
               txtNumero.Select()
            End If
         End Sub)
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(bscCodigoProveedor, bscProveedor))
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
            _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProveedor(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbComprador_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprador.CheckedChanged
      TryCatched(Sub() chbComprador.FiltroCheckedChanged(cmbComprador))
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cboRubro))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbNumero.Checked And (txtNumero.Text = "" OrElse Long.Parse(txtNumero.Text) = 0) Then
               MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               txtNumero.Focus()
               Exit Sub
            End If
            If chbProveedor.Checked And bscCodigoProveedor.Text.Length = 0 Then
               MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               bscCodigoProveedor.Focus()
               Exit Sub
            End If
            If chbCentroCosto.Checked Then
               If Not IsNumeric(cmbCentroCosto.SelectedValue) Then
                  MessageBox.Show("Ha seleccionado el filtro por Centro de Costos pero no ha seleccionado uno. Por favor reintente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
            End If

            CargaGrillaDetalle()

            If ugvDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
               Exit Sub
            End If
         End Sub)

   End Sub

   Private Sub ugvDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugvDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugvDetalle.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               If e.Cell.Column.Key = "Ver" Then
                  Dim rCompras = New Reglas.Compras()
                  Dim Compra = rCompras.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                               dr.Field(Of String)("IdTipoComprobante"),
                                               dr.Field(Of String)("Letra"),
                                               dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                               dr.Field(Of Long)("NumeroComprobante"),
                                               dr.Field(Of Long)("IdProveedor"))

                  Dim oImpr = New ImpresionCompra(Compra)
                  oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
               Else
                  'Cada vez que se agregan columnas (antes del boton) se cambia el valor del index.
                  If e.Cell.Column.Key = "CantidadInvocados" Then

                     If String.IsNullOrEmpty(e.Cell.Row.Cells("CantidadInvocados").Value.ToString()) Then Exit Sub
                     Using oComprobantesInvocados = New FacturablesInvocadosCom(
                                               dr.Field(Of String)("IdTipoComprobante"),
                                               dr.Field(Of String)("Letra"),
                                               dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                               dr.Field(Of Long)("NumeroComprobante"),
                                               dr.Field(Of Long)("IdProveedor"))
                        oComprobantesInvocados.ShowDialog()
                     End Using
                  End If
               End If
            End If
         End Sub)

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.rdbPorPeriodoFiscal.Checked Or Me.rdbAmbos.Checked Then
            filtro.AppendFormat(" - Periodo: {0}", Me.dtpPeriodoFiscal.Value.ToString("MMMMM") & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy"))
         End If

         If Me.chkMesCompleto.Checked Then
            filtro.AppendFormat(" - Fechas: Desde {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If

         If Me.chbComprador.Checked Then
            Dim IdComprador As Integer
            IdComprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado).IdEmpleado
            filtro.AppendFormat(" - Comprador: " & IdComprador & " - " & Me.cmbComprador.Text)
         End If

         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", Me.cmbTiposComprobantes.Text)
         End If

         If Me.chbNumero.Checked Then
            filtro.AppendFormat(" - Número: {0}", Me.txtNumero.Text)
         End If

         If Me.cmbGrabanLibro.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Graba Libro: {0}", Me.cmbGrabanLibro.Text)
         End If

         If Me.cmbAfectaCaja.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Afecta Caja: {0}", Me.cmbAfectaCaja.Text)
         End If

         If Me.chbFormaPago.Checked Then
            filtro.AppendFormat(" - Forma de Pago: {0}", Me.cmbFormaPago.Text)
         End If

         If Me.chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", Me.cmbCategoria.Text)
         End If

         If Me.cmbEsComercial.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Comercial: {0}", Me.cmbEsComercial.Text)
         End If

         If Me.chbRubro.Checked Then
            filtro.AppendFormat(" - Rubro: {0}", Me.cboRubro.Text)
         End If

         If Me.chbEstado.Checked Then
            filtro.AppendFormat(" - Estado: {0}", Me.cmbEstados.Text)
         End If

         If Me.chbUsuario.Checked Then
            filtro.AppendFormat(" - Usuario: {0}", Me.cmbUsuario.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      TryCatched(Sub() chbEstado.FiltroCheckedChanged(cmbEstados))
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub

   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      TryCatched(Sub() dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes())
   End Sub

   Private Sub cmbTipoConversión_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoConversion.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbTipoConversion.ValorSeleccionado(Of Entidades.Moneda_TipoConversion) = Entidades.Moneda_TipoConversion.Actual Then
            txtCotizacionDolar.Visible = True
            lblCotizacionDolar.Visible = True
            txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)
         Else
            txtCotizacionDolar.Visible = False
            lblCotizacionDolar.Visible = False
            txtCotizacionDolar.Text = "1.00"
         End If
      End Sub)
   End Sub
   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbMoneda.ValorSeleccionado(0I) = Entidades.Moneda.Dolar Then
            cmbTipoConversion.Visible = True
            txtCotizacionDolar.Visible = cmbTipoConversion.ValorSeleccionado(Of Entidades.Moneda_TipoConversion) = Entidades.Moneda_TipoConversion.Actual
            lblCotizacionDolar.Visible = txtCotizacionDolar.Visible
            txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)
         Else
            cmbTipoConversion.Visible = False
            txtCotizacionDolar.Visible = False
            lblCotizacionDolar.Visible = False
            txtCotizacionDolar.SetValor(1D)
         End If
      End Sub)
   End Sub


#End Region

#Region "Metodos"

   Private Sub HabilitarFiltrosFecha(ActivaPeriodoFiscal As Boolean, ActivaFechas As Boolean)
      dtpPeriodoFiscal.Enabled = ActivaPeriodoFiscal
      chkMesCompleto.Enabled = ActivaFechas
      dtpDesde.Enabled = ActivaFechas
      dtpHasta.Enabled = ActivaFechas
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      bscProveedor.Enabled = False
      bscCodigoProveedor.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()
      rdbPorFechas.Checked = True
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      chbProveedor.Checked = False
      chbTipoComprobante.Checked = False
      chbEstado.Checked = False
      chbNumero.Checked = False
      cmbGrabanLibro.SelectedIndex = 0
      cmbAfectaCaja.SelectedIndex = 0
      cmbEsComercial.SelectedIndex = 0
      chbComprador.Checked = False
      chbFormaPago.Checked = False
      chbRubro.Checked = False
      chbCategoria.Checked = False
      chbUsuario.Checked = False
      dtpPeriodoFiscal.Value = Today.PrimerDiaMes()
      cmbSucursal.Refrescar()
      'Limpio la Grilla.

      cmbMoneda.SelectedValue = Entidades.Moneda.Peso

      'Metodo 2
      ugvDetalle.ClearFilas()

      dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idEmpresa = actual.Sucursal.IdEmpresa

      Dim PeriodoFiscal As Integer = 0
      If rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked Then
         PeriodoFiscal = Integer.Parse(dtpPeriodoFiscal.Value.ToString("yyyyMM"))
      End If

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing
      If rdbPorFechas.Checked Or rdbAmbos.Checked Then
         FechaDesde = dtpDesde.Value
         FechaHasta = dtpHasta.Value
      End If

      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim numeroComprobante = If(chbNumero.Checked, txtNumero.ValorNumericoPorDefecto(0L), 0L)
      Dim idComprador = cmbComprador.ValorSeleccionado(chbComprador, 0I)
      Dim idFormasPago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)
      Dim idRubro = cboRubro.ValorSeleccionado(chbRubro, 0I)
      Dim estado = cmbEstados.ValorSeleccionado(chbEstado, String.Empty)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim idCentroCosto = cmbCentroCosto.ValorSeleccionado(chbCentroCosto, 0I)

      Dim oCompra = New Reglas.Compras()
      Dim dtDetalle = oCompra.GetPorRangoFechas(cmbSucursal.GetSucursales,
                                                idEmpresa, PeriodoFiscal,
                                                FechaDesde, FechaHasta,
                                                idProveedor, idComprador,
                                                cmbGrabanLibro.Text, cmbAfectaCaja.Text, cmbEsComercial.Text,
                                                idTipoComprobante, numeroComprobante,
                                                idFormasPago, idRubro,
                                                estado, idCategoria, idUsuario, idCentroCosto,
                                                cmbMoneda.ValorSeleccionado(0I),
                                                cmbTipoConversion.ValorSeleccionado(cmbTipoConversion.Visible, Entidades.Moneda_TipoConversion.Comprobante),
                                                txtCotizacionDolar.ValorNumericoPorDefecto(0D))

      Dim dt As DataTable = CrearDT()
      ugvDetalle.DataSource = CopiarDt(dtDetalle, dt)
      'Me.ugvDetalle.DataSource = dt
      FormatearGrilla()

   End Sub

   Public Shared Function CopiarDt(dtDetalle As DataTable, dt As DataTable) As DataTable
      Dim drCl As DataRow

      For Each dr As DataRow In dtDetalle.Rows

         drCl = dt.NewRow()

         'If dr("TipoImpresora").ToString() = "NORMAL" Then
         drCl("Ver") = "..."
         'Else
         '   drCl("Ver") = "( F )"
         'End If

         If Not String.IsNullOrEmpty(dr("PeriodoFiscal").ToString()) Then
            drCl("PeriodoFiscal") = Integer.Parse(dr("PeriodoFiscal").ToString())
         End If
         drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
         drCl("NombreTipoComprobante") = dr("NombreTipoComprobante").ToString()
         drCl("Letra") = dr("Letra").ToString()
         drCl("IdSucursal") = dr("IdSucursal")
         drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
         drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
         drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
         drCl("Fecha_FECHA") = dr("Fecha_FECHA")
         drCl("Fecha_HORA") = dr("Fecha_HORA")

         drCl("IdProveedor") = dr("IdProveedor").ToString()
         drCl("CodigoProveedor") = dr("CodigoProveedor").ToString()

         drCl("NombreProveedor") = dr("NombreProveedor").ToString()
         drCl("Cuit") = dr("Cuit")
         drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
         drCl("FormaDePago") = dr("FormaDePago").ToString()

         If Integer.Parse(dr("CantidadInvocados").ToString()) > 0 Then
            drCl("CantidadInvocados") = Integer.Parse(dr("CantidadInvocados").ToString())
         End If

         drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

         drCl("ImportePesos") = dr("ImportePesos")
         drCl("ImporteTarjetas") = dr("ImporteTarjetas")
         drCl("ImporteCheques") = dr("ImporteCheques")
         drCl("ImporteTransfBancaria") = dr("ImporteTransfBancaria")
         drCl("IdCuentaBancaria") = dr("IdCuentaBancaria")
         drCl("NombreCuenta") = dr("NombreCuenta")
         drCl("NombreBanco") = dr("NombreBanco")

         drCl("DerechoAduanero") = dr("DerechoAduanero")

         drCl("Observacion") = dr("Observacion").ToString()
         drCl(Entidades.Compra.Columnas.IdRubro.ToString()) = dr.Field(Of Integer)("IdRubro") '# Rubro de la compra
         drCl("NombreRubro") = dr.Field(Of String)("NombreRubro") '# Rubro de la compra
         drCl("FechaActualizacion") = Date.Parse(dr("FechaActualizacion").ToString())
         drCl("Usuario") = dr("Usuario").ToString()

         drCl("IdPlanCuenta") = dr("IdPlanCuenta")
         drCl("IdAsiento") = dr("IdAsiento")

         drCl("TotalBruto") = dr("TotalBruto")
         drCl("TotalNeto") = dr("TotalNeto")
         drCl("TotalIVA") = dr("TotalIVA")
         drCl("TotalPercepciones") = dr("TotalPercepciones")
         drCl("CotizacionDolar") = dr("CotizacionDolar")
         drCl("NombresCentrosCosto") = dr("NombresCentrosCosto")

         drCl(Entidades.Compra.Columnas.MetodoGrabacion.ToString()) = dr(Entidades.Compra.Columnas.MetodoGrabacion.ToString())
         drCl(Entidades.Compra.Columnas.IdFuncion.ToString()) = dr(Entidades.Compra.Columnas.IdFuncion.ToString())

         drCl("NombreCaja") = dr("NombreCaja")
         drCl("NumeroPlanilla") = dr("NumeroPlanilla")
         drCl("NumeroMovimiento") = dr("NumeroMovimiento")

         drCl("IdConceptoCM05") = dr("IdConceptoCM05")
         drCl("DescripcionConceptoCM05") = dr("DescripcionConceptoCM05")
         drCl("TipoConceptoCM05") = dr("TipoConceptoCM05")

         dt.Rows.Add(drCl)

      Next
      Return dt
   End Function


   Public Shared Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("PeriodoFiscal", GetType(Integer))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("NombreTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("Fecha", GetType(DateTime))
         .Columns.Add("Fecha_FECHA", GetType(DateTime))
         .Columns.Add("Fecha_HORA", GetType(TimeSpan))
         .Columns.Add("IdProveedor", GetType(Long))
         .Columns.Add("CodigoProveedor", GetType(Long))
         .Columns.Add("NombreProveedor", GetType(String))
         .Columns.Add("Cuit", GetType(String))
         .Columns.Add("NombreCategoriaFiscal", GetType(String))
         .Columns.Add("FormaDePago", GetType(String))
         .Columns.Add("CantidadInvocados", GetType(Integer))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("FechaActualizacion", GetType(DateTime))
         .Columns.Add("Usuario", GetType(String))

         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Integer))

         .Columns.Add("ImportePesos", GetType(Decimal))
         .Columns.Add("ImporteTarjetas", GetType(Decimal))
         .Columns.Add("ImporteCheques", GetType(Decimal))
         .Columns.Add("ImporteTransfBancaria", GetType(Decimal))
         .Columns.Add("IdCuentaBancaria", GetType(Integer))
         .Columns.Add("NombreBanco", GetType(String))
         .Columns.Add("NombreCuenta", GetType(String))
         .Columns.Add("DerechoAduanero", GetType(Decimal))

         .Columns.Add("TotalBruto", GetType(Decimal))
         .Columns.Add("TotalNeto", GetType(Decimal))
         .Columns.Add("TotalIVA", GetType(Decimal))
         .Columns.Add("TotalPercepciones", GetType(Decimal))
         .Columns.Add("CotizacionDolar", GetType(Decimal))
         .Columns.Add("NombresCentrosCosto", GetType(String))

         .Columns.Add(Entidades.Compra.Columnas.MetodoGrabacion.ToString(), GetType(String))
         .Columns.Add(Entidades.Compra.Columnas.IdFuncion.ToString(), GetType(String))

         .Columns.Add("NombreCaja", GetType(String))
         .Columns.Add("NumeroPlanilla", GetType(Integer))
         .Columns.Add("NumeroMovimiento", GetType(Integer))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdRubro", GetType(Integer))
         .Columns.Add("NombreRubro", GetType(String))

         .Columns.Add("IdConceptoCM05", GetType(Integer))
         .Columns.Add("DescripcionConceptoCM05", GetType(String))
         .Columns.Add("TipoConceptoCM05", GetType(String))
      End With

      Return dtTemp

   End Function

   Private Sub FormatearGrilla()
      FormatearGrilla(ugvDetalle)
   End Sub

   Public Shared Sub FormatearGrilla(ugvDetalle As UltraGrid)

      ugvDetalle.DisplayLayout.Bands(0).Reset()

      With ugvDetalle.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns("Ver").FormatearColumna("Ver", col, 30, HAlign.Center).Style = UltraWinGrid.ColumnStyle.Button
         .Columns("PeriodoFiscal").FormatearColumna("Periodo", col, 50, HAlign.Center, , "0000/00")
         .Columns("Fecha").FormatearColumna("Fecha/Hora", col, 100, HAlign.Center, True, "dd/MM/yyyy HH:mm")
         .Columns("Fecha_FECHA").FormatearColumna("Fecha", col, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Fecha_HORA").FormatearColumna("Hora", col, 70, HAlign.Center, , "HH:mm")



         .Columns("IdTipoComprobante").Hidden = True

         .Columns("NombreTipoComprobante").FormatearColumna("Comprobante", col, 80)
         .Columns("Letra").FormatearColumna("Let.", col, 30, HAlign.Center)
         .Columns("IdSucursal").FormatearColumna("Suc.", col, 35, HAlign.Right)
         .Columns("CentroEmisor").FormatearColumna("Emis.", col, 40, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Número", col, 60, HAlign.Right)

         .Columns("IdProveedor").Hidden = True
         .Columns("CodigoProveedor").FormatearColumna("Código Proveedor", col, 75, HAlign.Right, True)
         .Columns("NombreProveedor").FormatearColumna("Proveedor", col, 170)
         .Columns("Cuit").FormatearColumna("Cuit", col, 80, , True)
         .Columns("NombreCategoriaFiscal").FormatearColumna("Categoria Fiscal", col, 170, , True)

         .Columns("FormaDePago").FormatearColumna("F. de Pago", col, 60)

         .Columns("CantidadInvocados").FormatearColumna("Inv", col, 30, HAlign.Center).Style = UltraWinGrid.ColumnStyle.Button

         .Columns("TotalBruto").FormatearColumna("Total Bruto", col, 70, HAlign.Right, , "N2")
         .Columns("TotalNeto").FormatearColumna("Total Neto", col, 70, HAlign.Right, , "N2")
         .Columns("TotalIVA").FormatearColumna("Total IVA", col, 70, HAlign.Right, , "N2")
         .Columns("TotalPercepciones").FormatearColumna("Total Perc.", col, 70, HAlign.Right, , "N2")

         '.Columns("NetoNoGravado").FormatearColumna("No Gravado", col, 70, HAlign.Right, , "N2")
         '.Columns("Neto").FormatearColumna("Neto", col, 70, HAlign.Right, , "N2")
         '.Columns("Iva105").FormatearColumna("Iva 10.5%", col, 65, HAlign.Right, , "N2")
         '.Columns("Iva210").FormatearColumna("Iva 21%", col, 65, HAlign.Right, , "N2")
         '.Columns("IVA270").FormatearColumna("Iva 27%", col, 65, HAlign.Right, , "N2")
         .Columns("ImporteTotal").FormatearColumna("Total", col, 75, HAlign.Right, , "N2")
         '.Columns("PercepcionIVA").FormatearColumna("Perc. IVA", col, 65, HAlign.Right, , "N2")
         '.Columns("PercepcionIB").FormatearColumna("Perc. IIBB", col, 65, HAlign.Right, , "N2")
         '.Columns("PercepcionGanancias").FormatearColumna("Perc. Ganancias", col, 65, HAlign.Right, , "N2")
         '.Columns("PercepcionVarias").FormatearColumna("Perc. Varias", col, 65, HAlign.Right, , "N2")

         .Columns("CotizacionDolar").FormatearColumna("Cotización Dolar", col, 75, HAlign.Right, , "N2")

         .Columns("ImportePesos").FormatearColumna("Imp. Pesos", col, 75, HAlign.Right, , "N2")
         .Columns("ImporteTarjetas").FormatearColumna("Imp. Tarjetas", col, 75, HAlign.Right, , "N2")
         .Columns("ImporteCheques").FormatearColumna("Imp. Cheques", col, 75, HAlign.Right, , "N2")
         .Columns("ImporteTransfBancaria").FormatearColumna("Imp. Tr. Banc", col, 75, HAlign.Right, , "N2")
         .Columns("IdCuentaBancaria").Hidden = True
         .Columns("NombreBanco").FormatearColumna("Banco", col, 150, , True)
         .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", col, 150)

         .Columns("DerechoAduanero").FormatearColumna("Derecho de Aduana", col, 75, HAlign.Right, , "N2")

         .Columns("Observacion").FormatearColumna("Observación", col, 250)
         .Columns("IdRubro").FormatearColumna("IdRubro", col, 60, HAlign.Right, True)
         .Columns("NombreRubro").FormatearColumna("Rubro", col, 120, HAlign.Left)

         .Columns("FechaActualizacion").FormatearColumna("Fecha Act.", col, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         .Columns("Usuario").FormatearColumna("Usuario", col, 100)

         .Columns("IdPlanCuenta").FormatearColumna("P.", col, 25, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 54, HAlign.Right)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns("IdPlanCuenta").Hidden = True
            .Columns("IdAsiento").Hidden = True
         End If
         .Columns("NombresCentrosCosto").FormatearColumna("Centros de Costo", col, 150, , Not Reglas.ContabilidadPublicos.UtilizaCentroCostos)

         .Columns("IdConceptoCM05").FormatearColumna("Código CM05", col, 70, HAlign.Right, hidden:=True)
         .Columns("DescripcionConceptoCM05").FormatearColumna("Concepto CM05", col, 150,, Not Reglas.Publicos.AFIPUtilizaCM05)
         .Columns("TipoConceptoCM05").FormatearColumna("Tipo CM05", col, 70, HAlign.Center, Not Reglas.Publicos.AFIPUtilizaCM05)

         .Columns(Entidades.Compra.Columnas.MetodoGrabacion.ToString()).FormatearColumna("Met.", col, 40, HAlign.Center)
         .Columns(Entidades.Compra.Columnas.IdFuncion.ToString()).FormatearColumna("Pantalla", col, 200)

         .Columns("NombreCaja").FormatearColumna("Caja", col, 100, HAlign.Left)
         .Columns("NumeroPlanilla").FormatearColumna("Planilla", col, 75, HAlign.Right)
         .Columns("NumeroMovimiento").FormatearColumna("Movimiento", col, 75, HAlign.Right)
      End With

      'ugvDetalle.AgregarTotalesSuma({"NetoNoGravado", "Neto", "Iva105", "Iva210", "Iva270", "ImporteTotal",
      '                               "PercepcionIVA", "PercepcionIB", "PercepcionGanancias", "PercepcionVarias",
      '                               "ImportePesos", "ImporteTarjetas", "ImporteCheques", "ImporteTransfBancaria",
      '                               "DerechoAduanero"})
      ugvDetalle.AgregarTotalesSuma({"TotalBruto", "TotalNeto", "TotalIVA", "TotalPercepciones", "ImporteTotal",
                                     "ImportePesos", "ImporteTarjetas", "ImporteCheques", "ImporteTransfBancaria",
                                     "DerechoAduanero"})

      ugvDetalle.AgregarFiltroEnLinea({"NombreProveedor", "Observacion", Entidades.Compra.Columnas.IdFuncion.ToString()})

      'For Each cl As UltraWinGrid.UltraGridColumn In Me.ugvDetalle.DisplayLayout.Bands(0).Columns
      '   cl.CellActivation = Activation.NoEdit
      'Next

#Disable Warning BC40000 ' Type or member is obsolete
      DirectCast(ugvDetalle.FindForm(), BaseForm).PreferenciasLeer(ugvDetalle)
#Enable Warning BC40000 ' Type or member is obsolete

   End Sub

#End Region

   Private Sub chbCentroCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroCosto.CheckedChanged
      Try
         If chbCentroCosto.Checked Then
            cmbCentroCosto.SelectedIndex = 0
            cmbCentroCosto.Enabled = True
            cmbCentroCosto.Focus()
         Else
            cmbCentroCosto.SelectedIndex = -1
            cmbCentroCosto.Enabled = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

End Class