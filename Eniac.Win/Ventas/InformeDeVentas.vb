Public Class InformeDeVentas

#Region "Campos"

   Private _publicos As Publicos
   Private _idUsuario As String = actual.Nombre
   Private _vieneDeOnLoad As Boolean = False
   Private _numeroComprobanteDesdeAnterior As Long = 0
   Private _utilizaCentroCostos As Boolean = False
   Private _tit As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Friend WithEvents tsbFiltros As ToolStripButton
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      tsbFiltros = New ToolStripButton()
      '
      'tsbFiltros
      '
      tsbFiltros.Image = My.Resources.filter_data_24
      tsbFiltros.ImageTransparentColor = Color.Magenta
      tsbFiltros.Name = "tsbFiltros"
      tsbFiltros.Size = New Size(65, 26)
      tsbFiltros.Text = "Filtros"

      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbPreferencias) + 1, tsbFiltros)
   End Sub
   Private Sub tsbFiltros_Click(sender As Object, e As EventArgs) Handles tsbFiltros.Click
      TryCatched(Sub() FiltersManager1.SeleccionarFiltro())
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _vieneDeOnLoad = True
            cmbTiposComprobantes.Initializar(False, "VENTAS")
            cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            _vieneDeOnLoad = False

            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(_idUsuario).Rows.Count = 0 Then
               _idUsuario = String.Empty
            End If

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
            If String.IsNullOrWhiteSpace(_idUsuario) Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = cmbVendedor.Items.Count = 1

            _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
            cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
            cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
            cmbFormaPago.SelectedIndex = -1
            _publicos.CargaComboUsuarios(cmbUsuario)

            _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
            cmbZonaGeografica.SelectedIndex = -1

            _publicos.CargaComboCategorias(cmbCategoria)

            _publicos.CargaComboTransportistas(cmbTransportista)

            _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboDesdeEnum(cmbAfectaCaja, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboDesdeEnum(cmbMercDespachada, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboDesdeEnum(cmbEsComercial, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboDesdeEnum(cmbCorreoEnviado, GetType(Entidades.Publicos.SiNoTodos))

            Dim aCantidad = New ArrayList()
            aCantidad.Insert(0, "Negativo ( < 0 )")
            aCantidad.Insert(1, "Igual a Cero ( = 0 )")
            aCantidad.Insert(2, "Mayor a Cero ( > 0 )")

            With cboLetra
               .DisplayMember = "LetraFiscal"
               .ValueMember = "LetraFiscal"
               .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
               .SelectedIndex = -1
            End With

            With cmbEmisor
               .DisplayMember = "CentroEmisor"
               .ValueMember = "CentroEmisor"
               .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
               .SelectedIndex = -1
            End With

            _publicos.CargaComboProvincias(Me.cmbProvincia)

            Dim permiteMostrarTotalesImpresionExportacion = New Reglas.Usuarios().TienePermisos("InfDeVts-Totales+Toolbar")

            If permiteMostrarTotalesImpresionExportacion Then
               ugDetalle.AgregarTotalesSuma({"ImporteTotal", "IVA", "TotalImpuestoInterno", "NetoNoGravado", "NetoGravado", "Subtotal", "ImportePesos", "ImporteDolares", "ImporteTickets", "ImporteTarjetas", "ImporteCheques", "ImporteTransfBancaria", "Percepciones"})
            Else
               tsbImprimir.Visible = False
               tsbImprimirPrediseñado.Visible = False
               tsddExportar.Visible = False
               ToolStripSeparator1.Visible = False
               ToolStripSeparator2.Visible = False
               ToolStripSeparator4.Visible = False
            End If

            '# Datos Clínicos
            If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
               Me.pnlHistoriaClinica.Visible = True
            End If

            ugDetalle.DisplayLayout.Bands(0).Columns("Percepciones").Hidden = Not Reglas.Publicos.RetieneIIBB

            If Not Reglas.Publicos.TieneModuloContabilidad Then
               ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
               ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
            End If
            ugDetalle.DisplayLayout.Bands(0).Columns("NombresCentrosCosto").Hidden = Not Reglas.ContabilidadPublicos.UtilizaCentroCostos

            ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestoInterno").Hidden = True

            ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreClienteVinculado", "Observacion"}, {"Ver", "VerEstandar", "Imprimir"})

            'Hay que colocarlo del CargarColumnasASumar porque sino da error.
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            If Not permiteMostrarTotalesImpresionExportacion Then
               ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()
            End If

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not cmbSucursal.Enabled

            _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

            If _utilizaCentroCostos Then
               _publicos.CargaComboCentroCostos(cmbCentroCosto)
               cmbCentroCosto.Visible = True
               chbCentroCosto.Visible = True
            Else
               cmbCentroCosto.Visible = False
               chbCentroCosto.Visible = False
            End If

            Me.tsbImprimirFicha.Visible = Eniac.Reglas.Publicos.TieneModuloFichas
            Me.tsbImpFichaCliente.Visible = Eniac.Reglas.Publicos.TieneModuloFichas

            RefrescarDatosGrilla()

            _tit = GetColumnasVisiblesGrilla(ugDetalle)
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
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
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim filtros = CargarFiltrosImpresion()
         Dim parm = New ReportParameterCollection(filtros)

         Dim dt = ugDetalle.DataSource(Of DataTable)

         Dim frmImprime = New VisorReportes("Eniac.Win.InformeDeVentas.rdlc", "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsbImprimirFicha_Click(sender As Object, e As EventArgs) Handles tsbImprimirFicha.Click
      TryCatched(Sub() ImprimirFicha())
   End Sub
   Private Sub tsbImpFichaCliente_Click(sender As Object, e As EventArgs) Handles tsbImpFichaCliente.Click
      TryCatched(Sub() ImprimirFichaCliente())
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Filtros"
   'Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
   '   TryCatched(
   '   Sub()
   '      If Not chbTipoComprobante.Checked Then
   '         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
   '      Else
   '         cmbTiposComprobantes.SelectedIndex = -1
   '         cmbTiposComprobantes.Focus()
   '      End If
   '   End Sub)
   'End Sub
   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cboLetra))
   End Sub
   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      TryCatched(Sub() chbEmisor.FiltroCheckedChanged(cmbEmisor))
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumeroCompHasta))
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumeroCompDesde))
   End Sub
   Private Sub txtNumeroCompDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Enter
      TryCatched(Sub() _numeroComprobanteDesdeAnterior = If(IsNumeric(txtNumeroCompDesde.Text), Long.Parse(txtNumeroCompDesde.Text), 0))
   End Sub
   Private Sub txtNumeroCompDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Leave
      TryCatched(
      Sub()
         Dim desde As Long = If(IsNumeric(txtNumeroCompDesde.Text), Long.Parse(txtNumeroCompDesde.Text), 0)
         Dim hasta As Long = If(IsNumeric(txtNumeroCompHasta.Text), Long.Parse(txtNumeroCompHasta.Text), 0)
         Dim delta As Long = desde - _numeroComprobanteDesdeAnterior
         txtNumeroCompHasta.Text = (hasta + delta).ToString()
      End Sub)
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbNumeroRep_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroReparto.CheckedChanged
      TryCatched(Sub() chbNroReparto.FiltroCheckedChanged(txtNroRepartoHasta))
      TryCatched(Sub() chbNroReparto.FiltroCheckedChanged(txtNroRepartoDesde))
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbCentroCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroCosto.CheckedChanged
      TryCatched(Sub() chbCentroCosto.FiltroCheckedChanged(cmbCentroCosto))
   End Sub
   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      TryCatched(Sub() chbTransportista.FiltroCheckedChanged(cmbTransportista))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente))
   End Sub
#End Region

#Region "Eventos Buscador Localidades"
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
         bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
         bscNombreLocalidad.Datos = New Reglas.Localidades().GetPorNombre(bscNombreLocalidad.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      TryCatched(Sub() CargarLocalidad(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Filtros Clinica"
   Private Sub chbFechaCirugia_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCirugia.CheckedChanged
      TryCatched(Sub() chbFechaCirugia.FiltroCheckedChanged(dtpFechaCirugia, dtpFechaCirugia))
   End Sub


#Region "Eventos Buscador Pacientes"
   Private Sub chbPaciente_CheckedChanged(sender As Object, e As EventArgs) Handles chbPaciente.CheckedChanged
      TryCatched(Sub() chbPaciente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoPaciente, bscPaciente))
   End Sub
   Private Sub bscCodigoPaciente_BuscadorClick() Handles bscCodigoPaciente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoPaciente)
         Dim codigoPaciente = bscCodigoPaciente.Text.ValorNumericoPorDefecto(-1L)
         '# Valido que esté configurado la categoria para los Pacientes
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
            Exit Sub
         End If
         bscCodigoPaciente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoPaciente, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      End Sub)
   End Sub
   Private Sub bscPaciente_BuscadorClick() Handles bscPaciente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscPaciente)
         '# Valido que esté configurado la categoria para los Pacientes
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
            Exit Sub
         End If
         bscPaciente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscPaciente.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      End Sub)
   End Sub
   Private Sub bscCodigoPaciente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoPaciente.BuscadorSeleccion, bscPaciente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoPaciente, bscPaciente))
   End Sub
#End Region

#Region "Eventos Buscador Doctor"
   Private Sub chbDoctor_CheckedChanged(sender As Object, e As EventArgs) Handles chbDoctor.CheckedChanged
      TryCatched(Sub() chbDoctor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoDoctor, bscDoctor))
   End Sub
   Private Sub bscCodigoDoctor_BuscadorClick() Handles bscCodigoDoctor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoDoctor)
         Dim codigoDoctor = bscCodigoDoctor.Text.ValorNumericoPorDefecto(-1L)
         '# Valido que esté configurado la categoria para los Doctores
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
            Exit Sub
         End If
         bscCodigoDoctor.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoDoctor, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
      End Sub)
   End Sub
   Private Sub bscDoctor_BuscadorClick() Handles bscDoctor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscDoctor)
         '# Valido que esté configurado la categoria para los Doctores
         If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
            ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
            Exit Sub
         End If
         bscDoctor.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscDoctor.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
      End Sub)
   End Sub
   Private Sub bscCodigoDoctor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoDoctor.BuscadorSeleccion, bscDoctor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoDoctor, bscDoctor))
   End Sub

#End Region
#End Region
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbLocalidad.Checked And Not bscCodigoLocalidad.Selecciono And Not bscNombreLocalidad.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó una Localidad aunque activó ese Filtro.")
            bscCodigoLocalidad.Focus()
            Exit Sub
         End If
         If chbNroReparto.Checked And txtNroRepartoDesde.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Informó un Numero Reparto Desde aunque activó ese Filtro.")
            txtNroRepartoDesde.Focus()
            Exit Sub
         End If
         If chbNroReparto.Checked And txtNroRepartoHasta.ValorNumericoPorDefecto(0L) = 0 Then
            MessageBox.Show("ATENCION: NO Informó un Numero Reparto Hasta aunque activó ese Filtro.")
            txtNroRepartoHasta.Focus()
            Exit Sub
         End If
         If chbNroReparto.Checked And txtNroRepartoDesde.ValorNumericoPorDefecto(0L) > txtNroRepartoHasta.ValorNumericoPorDefecto(0L) Then
            ShowMessage("ATENCION: Rango Invalido de Repartos.")
            txtNroRepartoHasta.Focus()
            Exit Sub
         End If
         If chbNumero.Checked And txtNumeroCompDesde.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Informó un Numero Comprobante Desde aunque activó ese Filtro.")
            txtNumeroCompDesde.Focus()
            Exit Sub
         End If
         If chbNumero.Checked And txtNumeroCompHasta.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Informó un Numero Comprobante Hasta aunque activó ese Filtro.")
            txtNumeroCompHasta.Focus()
            Exit Sub
         End If
         'If chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
         '   ShowMessage("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.")
         '   cmbTiposComprobantes.Focus()
         '   Exit Sub
         'End If
         If chbCentroCosto.Checked Then
            If Not IsNumeric(cmbCentroCosto.SelectedValue) Then
               ShowMessage("Ha seleccionado el filtro por Centro de Costos pero no ha seleccionado uno. Por favor reintente.")
               cmbCentroCosto.Focus()
               Exit Sub
            End If
         End If
         If chbPaciente.Checked AndAlso Not bscCodigoPaciente.Selecciono AndAlso Not bscPaciente.Selecciono Then
            ShowMessage("ATENCION: NO ingresó un Paciente aunque activó ese Filtro.")
            bscCodigoPaciente.Focus()
            Exit Sub
         End If
         If chbDoctor.Checked AndAlso Not bscCodigoDoctor.Selecciono AndAlso Not bscDoctor.Selecciono Then
            ShowMessage("ATENCION: NO ingresó un Doctor aunque activó ese Filtro.")
            bscCodigoDoctor.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim drVenta As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
         If drVenta IsNot Nothing Then
            Select Case e.Cell.Column.Key

               Case Is = "btnVer", "btnVerEstandar"
                  Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
                  Dim venta = rVentas.GetUna(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                             drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                             drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                             drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToShort(),
                                             drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))

                  Dim oImpr = New Impresion(venta)

                  If venta.Impresora.TipoImpresora = "NORMAL" Then
                     Dim ReporteEstandar = e.Cell.Column.Key = "btnVerEstandar"
                     oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

                     'If venta.Percepciones IsNot Nothing Then
                     '   For Each perc As Entidades.PercepcionVenta In venta.Percepciones
                     '      If perc.ImporteTotal <> 0 Then
                     '         Dim ret = New PercepcionImprimir()
                     '         ret.ImprimirPercepcion(venta, perc)
                     '      End If
                     '   Next
                     'End If

                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If

               Case "btnImprimir"
                  Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
                  Dim venta = rVentas.GetUna(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                             drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                             drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                             drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToShort(),
                                             drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))

                  If venta.Impresora.TipoImpresora = "NORMAL" Then
                     Dim oImpr = New Impresion(venta)
                     oImpr.ImprimirComprobanteNoFiscal(False)

                  ElseIf Not venta.TipoComprobante.GrabaLibro Then
                     Dim fc = New FacturacionComunes()
                     fc.ImprimirComprobante(venta, venta.TipoComprobante.EsFiscal)

                  Else
                     ShowMessage("No es posible Reimprimir en la Impresora Fiscal un Comprobante FISCAL.")
                  End If

               Case "CantidadInvocadosInvocadores"
                  Using oComprobantesInvocados =
                     New FacturablesInvocados(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                              drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                              drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                              drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                              drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
                     oComprobantesInvocados.ShowDialog()
                  End Using

               Case "CantidadLotes"
                  If drVenta.Field(Of Integer?)(Entidades.Venta.Columnas.CantidadLotes.ToString()).IfNull() > 0 Then
                     Using cl = New ConsultarLotes(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                                   drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                   drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                   drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                   drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()),
                                                   orden:=0)
                        cl.ShowDialog()
                     End Using
                  End If

               Case "CantidadContactos"
                  If drVenta.Field(Of Integer?)("CantidadContactos").IfNull() > 0 Then
                     Using cl = New ConsultarContactos(drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                       drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                       drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                       drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()),
                                                       orden:=0)
                        cl.ShowDialog()
                     End Using
                  End If
               Case Else

            End Select
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbCliente.Checked = False
      chbLocalidad.Checked = False
      chbProvincia.Checked = False

      If _idUsuario = "" Then
         chbVendedor.Checked = False
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

      End If

      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      If Publicos.FacturacionInformeVentasAfectaCajaSI Then
         cmbAfectaCaja.SelectedValue = Entidades.Publicos.SiNoTodos.SI
         'Me.cmbAfectaCaja.SelectedIndex = 1  'Para Comprobantes de Ventas
      Else
         cmbAfectaCaja.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         'Me.cmbAfectaCaja.SelectedIndex = 0
      End If

      cmbEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbMercDespachada.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbCorreoEnviado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      chbFormaPago.Checked = False
      chbUsuario.Checked = False

      chbCategoria.Checked = False
      'Me.rbtCatActual.Checked = True
      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual


      chbZonaGeografica.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbNumero.Checked = False
      chbLetra.Checked = False
      chbEmisor.Checked = False
      chbCentroCosto.Checked = False

      chbNroReparto.Checked = False

      If Not ugDetalle.DataSource Is Nothing Then
         DirectCast(ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'Se puede resetear el control de Sucursal de dos formas
      '1.- Seleccionando el valor         - Si tenemos que llevarlo a un valor que no sea el default
      'cmbSucursal.SelectedValue = actual.Sucursal.IdSucursal
      '2.- Ejecutando el método Refrescar - Si tenemos que llevarlo al valor default
      cmbSucursal.Refrescar()

      dtpDesde.Select()

      chbPaciente.Checked = False
      chbDoctor.Checked = False
      chbFechaCirugia.Checked = False

      FiltersManager1.Refrescar()

   End Sub
   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L)
      Dim idVendedor = If(chbVendedor.Checked, cmbVendedor.ItemSeleccionado(Of Entidades.Empleado).IdEmpleado, 0)
      Dim idZonaGeografica = If(cmbZonaGeografica.Enabled, cmbZonaGeografica.ItemSeleccionado(Of Entidades.ZonaGeografica).IdZonaGeografica, String.Empty)
      Dim idFormaDePago = If(cmbFormaPago.Enabled, cmbFormaPago.ValorSeleccionado(Of Integer), 0)
      Dim idUsuario = If(cmbUsuario.Enabled, cmbUsuario.ValorSeleccionado(Of String), String.Empty)
      Dim idCategoria = If(cmbCategoria.Enabled, cmbCategoria.ValorSeleccionado(Of Integer), 0)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0)
      Dim idProvincia As String = If(chbProvincia.Checked, cmbProvincia.ValorSeleccionado(Of String), String.Empty)
      Dim idTransportista = cmbTransportista.ValorSeleccionado(chbTransportista, 0I)

      Dim letra = If(cboLetra.Enabled, cboLetra.ValorSeleccionado(Of String), String.Empty)
      Dim emisor = If(cmbEmisor.Enabled, Integer.Parse(cmbEmisor.SelectedValue.ToString()), 0I)
      Dim numeroComprobanteDesde = If(chbNumero.Checked, txtNumeroCompDesde.ValorNumericoPorDefecto(0L), 0L)
      Dim numeroComprobanteHasta = If(chbNumero.Checked, txtNumeroCompHasta.ValorNumericoPorDefecto(0L), 0L)

      Dim numeroRepartoDesde As Integer? = Nothing
      Dim numeroRepartoHasta As Integer? = Nothing
      If Me.chbNroReparto.Checked Then
         numeroRepartoDesde = txtNroRepartoDesde.ValorNumericoPorDefecto(0I)
         numeroRepartoHasta = txtNroRepartoHasta.ValorNumericoPorDefecto(0I)
      End If

      Dim idCentroCosto As Integer = If(chbCentroCosto.Checked, cmbCentroCosto.ValorSeleccionado(Of Integer), 0I)

      '# Datos Clínicos
      Dim idPaciente As Long?
      Dim idDoctor As Long?
      Dim fechaCirugia As Date?

      If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
         If chbPaciente.Checked AndAlso bscPaciente.Selecciono AndAlso bscCodigoPaciente.Selecciono Then
            idPaciente = Long.Parse(Me.bscCodigoPaciente.Tag.ToString())
         End If
         If chbDoctor.Checked AndAlso bscDoctor.Selecciono AndAlso bscCodigoDoctor.Selecciono Then
            idDoctor = Long.Parse(Me.bscCodigoDoctor.Tag.ToString())
         End If
         If chbFechaCirugia.Checked Then
            fechaCirugia = Me.dtpFechaCirugia.Value
         End If
      End If

      Dim rVentas = New Reglas.Ventas()
      Dim dtDetalle = rVentas.GetInformeDeVentas(cmbSucursal.GetSucursales(),
                                                 dtpDesde.Value, dtpHasta.Value,
                                                 idZonaGeografica,
                                                 idVendedor, cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK),
                                                 idCliente,
                                                 cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                                 cmbAfectaCaja.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                                 idFormaDePago,
                                                 idUsuario,
                                                 idLocalidad,
                                                 idProvincia,
                                                 numeroComprobanteDesde, numeroComprobanteHasta,
                                                 letra, emisor,
                                                 cmbMercDespachada.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                 cmbEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                 idCategoria, cmbOrigenCategoria.ValorSeleccionado(Of Entidades.OrigenFK),
                                                 numeroRepartoDesde, numeroRepartoHasta,
                                                 cmbTiposComprobantes.GetTiposComprobantes().ToList(),
                                                 coeficienteStock:=Nothing,
                                                 esRemitoTransportista:=Nothing,
                                                 incluirAnulados:=True,
                                                 idCentroCosto:=idCentroCosto,
                                                 correoEnviado:=cmbCorreoEnviado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                 idPaciente:=idPaciente,
                                                 idDoctor:=idDoctor,
                                                 fechaCirugia:=fechaCirugia,
                                                 idTransportista)

      dtDetalle.Columns.Add("btnVer", GetType(String), "'...'")
      dtDetalle.Columns.Add("btnImprimir", GetType(String), "'...'")
      dtDetalle.Columns.Add("btnVerEstandar", GetType(String), "'...'")

      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)

      'Muestro la columna si algun registro tiene valor.
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("TotalImpuestoInterno").Hidden = dtDetalle.Select("TotalImpuestoInterno <> 0").Length = 0
         .Columns("DescripcionConceptoCM05").Hidden = Not Reglas.Publicos.AFIPUtilizaCM05
         .Columns("TipoConceptoCM05").Hidden = Not Reglas.Publicos.AFIPUtilizaCM05
      End With

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If Me.cboLetra.SelectedIndex >= 0 Then
            .AppendFormat(" Letra: {0} - ", Me.cboLetra.SelectedText)
         End If

         If Me.cmbEmisor.SelectedIndex >= 0 Then
            .AppendFormat(" Emisor: {0} -", Me.cmbEmisor.SelectedText)
         End If

         If Me.chbNumero.Checked Then
            .AppendFormat(" Número Desde: {0} -", Me.txtNumeroCompDesde.Text)
            .AppendFormat(" Hasta: {0} -", Me.txtNumeroCompHasta.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.SelectedText)
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            .AppendFormat(" Zona G.: {0} - ", Me.cmbZonaGeografica.SelectedText)
         End If

         If Me.cmbUsuario.SelectedIndex >= 0 Then
            .AppendFormat(" Usuario: {0}", Me.cmbUsuario.SelectedText)
         End If

         If Me.cmbFormaPago.SelectedIndex >= 0 Then
            .AppendFormat(" Forma de Pago: {0} -", Me.cmbFormaPago.SelectedText)
         End If

         If Me.cmbGrabanLibro.SelectedIndex >= 0 Then     '0 Es TODOS
            .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.cmbEsComercial.SelectedIndex >= 0 Then
            .AppendFormat(" Es Comercial: {0} - ", Me.cmbEsComercial.Text)
         End If

         If Me.cmbAfectaCaja.SelectedIndex >= 0 Then
            .AppendFormat(" Afecta Caja: {0} -", Me.cmbAfectaCaja.Text)
         End If

         If Me.cmbMercDespachada.SelectedIndex >= 0 Then
            .AppendFormat(" Mercaderia Despachada: {0} -", cmbMercDespachada.Text)
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoría {0} - ", Me.cmbCategoria.SelectedText)
         End If

         If Me.bscCodigoLocalidad.Text.Length > 0 And Me.bscNombreLocalidad.Text.Length > 0 Then
            .AppendFormat(" Localidad: {0} - {1} - ", Me.bscCodigoLocalidad.Text, Me.bscNombreLocalidad.Text)
         End If

         If Me.chbProvincia.Checked Then
            .AppendFormat(" Provincia {0} - ", Me.cmbProvincia.SelectedText)
         End If

         If Me.chbNroReparto.Checked Then
            .AppendFormat(" Numero de Reparto de {0} a {1} -", txtNroRepartoDesde, txtNroRepartoHasta)
         End If

         If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
            If Me.chbPaciente.Checked Then
               .AppendFormat(" Paciente: {0} - ", Me.bscPaciente.Text)
            End If
            If Me.chbDoctor.Checked Then
               .AppendFormat(" Doctor: {0} - ", Me.bscDoctor.Text)
            End If
            If Me.chbFechaCirugia.Checked Then
               .AppendFormat(" Fecha de Cirugía: {0} - ", Me.dtpFechaCirugia.Value.ToString())
            End If
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2)
      If dr IsNot Nothing Then
         controlNombre.Text = dr.Cells("NombreCliente").Value.ToString()
         controlCodigo.Text = dr.Cells("CodigoCliente").Value.ToString()
         controlCodigo.Tag = dr.Cells("IdCliente").Value.ToString()
         controlNombre.Permitido = False
         controlCodigo.Permitido = False
         controlNombre.Selecciono = True
         controlCodigo.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
         bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
         bscNombreLocalidad.Permitido = False
         bscCodigoLocalidad.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub ImprimirFicha()
      TryCatched(
      Sub()
         Dim drVenta As DataRow = ugDetalle.ActiveRow.FilaSeleccionada(Of DataRow)
         If drVenta IsNot Nothing Then
            Dim impresionFichas = New ImpresionFichas()
            Dim Comprobante = New Reglas.TiposComprobantes().GetUno(drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()))
            If Comprobante.CoeficienteValores > 0 Then
               impresionFichas.ImprimirFicha(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                             drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                             drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                             drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToShort(),
                                             drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
            End If
         End If
      End Sub)
   End Sub
   Private Sub ImprimirFichaCliente()
      TryCatched(
      Sub()
         Dim drVenta = ugDetalle.ActiveRow.FilaSeleccionada(Of DataRow)
         If drVenta IsNot Nothing Then
            Dim impresionFichas = New ImpresionFichas()
            Dim Comprobante = New Reglas.TiposComprobantes().GetUno(drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()))
            If Comprobante.CoeficienteValores > 0 Then
               impresionFichas.ImprimirFichaCliente(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                                    drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                    drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                    drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToShort(),
                                                    drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
            End If
         End If
      End Sub)
   End Sub
#End Region

End Class