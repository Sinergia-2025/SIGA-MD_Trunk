Public Class InfCtaCteDetalleClientes

#Region "Campos"

   Private _publicos As Publicos
   Private _idUsuario As String = actual.Nombre
   Private _utilizaIntereses As Boolean
   Private _vieneDeOnLoad As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         _publicos = New Publicos()

         _utilizaIntereses = New Reglas.Categorias().CategoriasConInteres().Count > 0

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

         _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1

         _publicos.CargaComboCategorias(Me.cmbCategoria)
         _publicos.CargaComboMonedas(Me.cmbMoneda)
         cmbMoneda.SelectedIndex = 1

         _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         cmbFormaPago.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbTipoConversion, GetType(Entidades.Moneda_TipoConversion))
         'Me.cmbTipoConversion.Items.Insert(0, "Cotización Comp.")
         'Me.cmbTipoConversion.Items.Insert(1, "Actual")
         cmbTipoConversion.SelectedIndex = 0

         '-.PE-32017.-
         _publicos.CargaComboDesdeEnum(cmbTipoCliente, GetType(Entidades.Cliente.ClienteVinculado))

         _publicos.CargaComboDesdeEnum(cmbTipoCategoria, GetType(Entidades.OrigenFK))
         cmbTipoCategoria.SelectedValue = Entidades.OrigenFK.Actual
         _publicos.CargaComboDesdeEnum(cmbTipoVendedor, GetType(Entidades.OrigenFK))
         cmbTipoVendedor.SelectedValue = Entidades.OrigenFK.Actual


         cmbTipoVendedor.SelectedIndex = 0
         cmbTipoCategoria.SelectedIndex = 0
         cmbTipoCliente.SelectedIndex = 0

         _vieneDeOnLoad = True
         'Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , , , True)
         'Me.cmbTiposComprobantes.SelectedIndex = -1
         cmbTiposComprobantes.Initializar(False, "VENTAS", "CTACTECLIE")
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         _vieneDeOnLoad = False


         cmbGrabanLibro.Items.Insert(0, "TODOS")
         cmbGrabanLibro.Items.Insert(1, "SI")
         cmbGrabanLibro.Items.Insert(2, "NO")
         cmbGrabanLibro.SelectedIndex = 0
         _publicos.CargaComboProvincias(Me.cmbProvincia)

         cmbGrupos.Inicializar()
         cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

         _publicos.CargaComboGrupoCategoria(Me.cmbGrupoCategoria)

         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         _publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
         cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Hidden = (Me.cmbZonaGeografica.Items.Count = 1)

         CargarColumnasASumar()

         ugDetalle.AgregarFiltroEnLinea({"NombreVendedor", "NombreCliente", "CUIT", "Telefonos", "Observacion", "NombreClienteCtaCte", "DetalleProducto"}, {"Ver"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         chbFechaInteres.Visible = _utilizaIntereses
         dtpFechaInteres.Visible = _utilizaIntereses

         If Reglas.Publicos.CtaCte.PintaColumaCuotaCtaCteCliente Then
            ugDetalle.DisplayLayout.Bands(0).Columns("CuotaNumero").CellAppearance.BackColor = Color.LightCyan
         End If

         '-- REQ-36324.- ----------------------------------------------------------------
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
         '-------------------------------------------------------------------------------
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      '--
      bscCodigoLocalidad.Text = String.Empty
      bscCodigoLocalidad.Enabled = chbLocalidad.Checked
      bscNombreLocalidad.Text = String.Empty
      bscNombreLocalidad.Enabled = chbLocalidad.Checked
      bscCodigoLocalidad.Focus()
      '--
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNombreLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               If e.Cell.Column.Header.Caption = "Ver" Then
                  Dim oTipoComprobante = New Entidades.TipoComprobante()
                  oTipoComprobante = New Reglas.TiposComprobantes().GetUno(dr.Field(Of String)("IdTipoComprobante"))

            If oTipoComprobante.EsRecibo Or oTipoComprobante.EsAnticipo Then
                     Dim idTipoComprobante = If(oTipoComprobante.EsRecibo, oTipoComprobante.IdTipoComprobante, oTipoComprobante.IdTipoComprobanteSecundario)
                     Dim rCtaCte = New Reglas.CuentasCorrientes()
                     Dim ctacte = rCtaCte.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                 idTipoComprobante,
                                                 dr.Field(Of String)("Letra"),
                                                 dr.Field(Of Integer)("CentroEmisor"),
                                                 dr.Field(Of Long)("NumeroComprobante"))
                     Dim imp = New RecibosImprimir()
                     imp.ImprimirRecibo(ctacte, visualizar:=True)
            Else
                     Dim rVentas = New Reglas.Ventas()
                     Dim venta = rVentas.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                dr.Field(Of String)("IdTipoComprobante"),
                                                dr.Field(Of String)("Letra"),
                                                dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                                dr.Field(Of Long)("NumeroComprobante"))

                     Dim oImpr = New Impresion(venta)

               If Not oTipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If
            End If
      End If
            End If

         End Sub)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub()
                    RefrescarDatosGrilla()
                    tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
                 End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
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
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewD.MdiParent = MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

         End Sub)

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      UltraGridPrintDocument1.Footer.TextRight = String.Format("Página: {0}", UltraGridPrintDocument1.PageNumber)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged

      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         Me.cmbCobrador.Focus()

      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCodigoCliente.Text = ""
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            '_listaTipoComprobante = New List(Of Entidades.TipoComprobante)()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
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
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged

      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Me.chbFecha.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked
      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try
         If chbLocalidad.Checked And Not bscCodigoLocalidad.Selecciono And Not bscNombreLocalidad.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Localidad, Debe seleccionar una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbEmbarcacionCama.Checked And Not Me.bscCodigoEmbarcacionCama.Selecciono And Not Me.bscNombreEmbarcacion.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Embarcacion, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoEmbarcacionCama.Focus()
            Exit Sub
         End If

         If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un Vendedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If


         If Me.chbGrupoCategoria.Checked And Me.cmbGrupoCategoria.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un grupo de categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbGrupoCategoria.Focus()
            Exit Sub
         End If

         If Me.chbCategoria.Checked And Me.cmbCategoria.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbCategoria.Focus()
            Exit Sub
         End If

         If Me.chbProvincia.Checked And Me.cmbProvincia.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó una Provincia aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbProvincia.Focus()
            Exit Sub
         End If

         If Me.chbCobrador.Checked And Me.cmbCobrador.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Cobrador aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbCobrador.Focus()
            Exit Sub
         End If


         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Filtros = CargarFiltrosImpresion()

            Me.Cursor = Cursors.WaitCursor

            Dim comunes = New CtasCtesClientesComunes()

            Dim Correo As String = ""
            If chbCliente.Checked Then
               If bscCodigoCliente.Selecciono Then
                  If Not String.IsNullOrWhiteSpace(bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                     Correo = bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
                  End If
               ElseIf bscCliente.Selecciono Then
                  If Not String.IsNullOrWhiteSpace(bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                     Correo = bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
                  End If
               End If
            End If

            comunes.ImprimirInformeCtaCteDetalleClientes(DirectCast(Me.ugDetalle.DataSource, DataTable).Copy(),
                                                         Filtros, (Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0),
                                                         "", rbtImpresionNormal.Checked, Text, True, Correo)

            Me.Cursor = Cursors.Default

         End Sub)
   End Sub

   Private Sub chbFechaInteres_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaInteres.CheckedChanged
      dtpFechaInteres.Enabled = chbFechaInteres.Checked
      If chbFechaInteres.Checked Then
         dtpFechaInteres.Value = Date.Now
      End If

      dtpFechaInteres.Focus()
   End Sub

   Private Sub cmbTipoConversión_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoConversion.SelectedIndexChanged
      Try
         If cmbTipoConversion.SelectedIndex = 1 Then
            txtCotizacionDolar.Visible = True
            lblCotizacionDolar.Visible = True
            txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
         Else
            txtCotizacionDolar.Visible = False
            lblCotizacionDolar.Visible = False
            txtCotizacionDolar.Text = "1.00"
         End If
      Catch ex As Exception
         ShowError(ex)
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
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbGrupoCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupoCategoria.CheckedChanged
      Try
         Me.cmbGrupoCategoria.Enabled = Me.chbGrupoCategoria.Checked

         If Not Me.chbGrupoCategoria.Checked Then
            Me.cmbGrupoCategoria.SelectedIndex = -1
         Else
            If Me.cmbGrupoCategoria.Items.Count > 0 Then
               Me.cmbGrupoCategoria.SelectedIndex = 0
            End If
            Me.cmbGrupoCategoria.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
   End Sub
   Private Sub CargarColumnasASumar()
      ugDetalle.AgregarTotalesSuma({"ImporteCuota", "SaldoCuota", "Interes", "SaldoVencido"})
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False

   End Sub


   Private Sub RefrescarDatosGrilla()

      If String.IsNullOrWhiteSpace(_idUsuario) Then
         chbVendedor.Checked = False
      End If

      chbCliente.Checked = False
      chbFecha.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      chbZonaGeografica.Checked = False
      chbCategoria.Checked = False
      chbTipoComprobante.Checked = False
      cmbGrabanLibro.SelectedIndex = 0
      optConSaldo.Checked = True
      optVencTodos.Checked = True
      cmbGrupos.Refrescar()
      chbGrupoCategoria.Checked = False
      cmbGrabanLibro.SelectedIndex = 0
      chbExcluirSaldosNegativos.Checked = False
      chbExcluirAnticipos.Checked = False
      chbExcluirPreComprobantes.Checked = False
      chbProvincia.Checked = False
      chbEmbarcacionCama.Checked = False
      bscCodigoEmbarcacionCama.Text = ""
      bscNombreEmbarcacion.Text = ""

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbExcluirMinutas.Checked = True
      rbtImpresionNormal.Checked = True
      chbFormaPago.Checked = False

      ugDetalle.ClearFilas()

      chbAgruparIdClienteCtaCte.Checked = False

      chbCobrador.Checked = False
      cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual

      cmbSucursal.Refrescar()
      '-.PE-32017.-
      cmbTipoCategoria.SelectedIndex = 0
      cmbTipoVendedor.SelectedIndex = 0
      cmbTipoCliente.SelectedIndex = 0

      btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      '---------------------------------------------------------------------------------------------
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCliente = If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim desde = If(chbFecha.Checked, dtpDesde.Value, Nothing)
      Dim hasta = If(chbFecha.Checked, dtpHasta.Value, Nothing)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim grupoCategoria = If(chbGrupoCategoria.Checked, cmbGrupoCategoria.Text, String.Empty)
      Dim excluirSaldosNegativos = If(chbExcluirSaldosNegativos.Checked, "SI", "NO")
      Dim excluirAnticipos = If(chbExcluirAnticipos.Checked, "SI", "NO")
      Dim excluirPreComprobantes = If(chbExcluirPreComprobantes.Checked, "SI", "NO")
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim tipoSaldo = If(optTodos.Checked, "TODOS", "SOLOSALDO")
      Dim vencimiento = If(Me.optVencTodos.Checked, "TODOS", "SOLOVENCIDOS")
      Dim tipoCategoria = cmbTipoCategoria.ValorSeleccionado(Of Entidades.OrigenFK)()
      Dim tipoVendedor = cmbTipoVendedor.ValorSeleccionado(Of Entidades.OrigenFK)()
      Dim tipoCliente = cmbTipoCliente.ValorSeleccionado(Of Entidades.Cliente.ClienteVinculado)()
      Dim excluirMinutas = If(chbExcluirMinutas.Checked, "SI", "NO")
      Dim cobrador = cmbOrigenCobrador.ValorSeleccionado(Of Entidades.OrigenFK)()
      Dim idCobrador = cmbCobrador.ValorSeleccionado(chbCobrador, 0I)
      Dim tipoConversion = If(cmbTipoConversion.Visible,
                              cmbTipoConversion.ValorSeleccionado(Of Entidades.Moneda_TipoConversion)(),
                              Entidades.Moneda_TipoConversion.Comprobante)
      Dim idFormaDePago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)

      Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = Nothing
      Dim IdEmbarcacion = If(chbEmbarcacionCama.Checked And Reglas.Publicos.CtaCteEmbarcacion, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoEmbarcacionCama.Tag, 0L), 0L)
      '-- 36324.- ---------------------------------------------------------------------------------------------------------
      Dim IdCama = If(chbEmbarcacionCama.Checked And Reglas.Publicos.CtaCteCama, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoEmbarcacionCama.Tag, 0L), 0L)
      '-- 36217.- ---------------------------------------------------------------------------------------------------------
      Dim idLocalidad = If(chbLocalidad.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoLocalidad.Text, 0I), 0I)
      Dim muestraDetalle = chbMostrarDetalleProducto.Checked
      '--------------------------------------------------------------------------------------------------------------------
      If chbTipoComprobante.Checked Then
         tiposComprobantes = cmbTiposComprobantes.GetTiposComprobantes().ToList()
      End If


      Dim rCtaCteDet = New Reglas.CuentasCorrientesPagos()
      Dim dtDetalle = rCtaCteDet.GetDetalle(cmbSucursal.GetSucursales(),
                                            desde, hasta,
                                            idVendedor,
                                            idCliente,
                                            tiposComprobantes,
                                            tipoSaldo,
                                            vencimiento,
                                            idZonaGeografica,
                                            idCategoria,
                                            cmbGrabanLibro.Text,
                                            cmbGrupos.GetGruposTiposComprobantes(),
                                            excluirSaldosNegativos,
                                            excluirAnticipos,
                                            excluirPreComprobantes,
                                            idProvincia, tipoCategoria, tipoVendedor, tipoCliente, excluirMinutas,
                                            chbAgruparIdClienteCtaCte.Checked,
                                            idCobrador,
                                            cobrador,
                                            dtpFechaInteres.Value,
                                            Integer.Parse(cmbMoneda.SelectedValue.ToString()),
                                            tipoConversion,
                                            Decimal.Parse(txtCotizacionDolar.Text.ToString()),
                                            grupoCategoria,
                                            idFormaDePago,
                                            IdEmbarcacion,
                                            idLocalidad, muestraDetalle, IdCama)

      Dim dt = CrearDT()
      If dtDetalle.Rows.Count > 0 Then
         Dim montoMinimoInteresPermitido = Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido
         Dim idCliente2 = Long.Parse(dtDetalle.Rows(0)("IdCliente").ToString())
         Dim CtaCteEmbarcacion = Reglas.Publicos.CtaCteEmbarcacion

         Dim Total = 0D
         For Each dr As DataRow In dtDetalle.Rows
            Dim drCl = dt.NewRow()

            'If dr("TipoImpresora").ToString() = "NORMAL" Then
            '   drCl("Ver") = "..."
            'ElseIf dr("TipoImpresora").ToString() = "FISCAL" Then
            '   drCl("Ver") = "( F )"
            'ElseIf String.IsNullOrEmpty(dr("TipoImpresora").ToString()) Then
            '   drCl("Ver") = "CC"
            'End If
            drCl("Ver") = "..."

            'drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdVendedor") = dr("IdVendedor").ToString()
            'drCl("NroDocVendedor") = dr("NroDocVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            '-.PE-32017.-
            If tipoCliente = Entidades.Cliente.ClienteVinculado.Vinculado Then
               drCl("CodVin") = Long.Parse(dr("CodVin").ToString())
               drCl("NombreVin") = dr("NombreVin").ToString()
               ugDetalle.DisplayLayout.Bands(0).Columns("CodVin").Hidden = False
               ugDetalle.DisplayLayout.Bands(0).Columns("NombreVin").Hidden = False
            Else
               ugDetalle.DisplayLayout.Bands(0).Columns("CodVin").Hidden = True
               ugDetalle.DisplayLayout.Bands(0).Columns("NombreVin").Hidden = True
            End If
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCliente2") = dr("NombreCliente2").ToString()
            drCl("NombreDeFantasia") = dr("NombreDeFantasia")
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            'drCl("DescripcionTipoComprobante") = dr("DescripcionTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("CuotaNumero") = Integer.Parse(dr("CuotaNumero").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())

            If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then   '' DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today) > 0 And 
               Dim diasFactura As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today)), 0)
               drCl("DiasFactura") = diasFactura
            End If

            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())

            'drCl("CantDias") = Integer.Parse(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()), Date.Today).ToString()) + 1

            If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then  '' DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today) > 0 And 
               Dim diasVencido As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today)), 0)
               drCl("DiasVencido") = diasVencido
               If diasVencido > 0 Then
                  drCl("SaldoVencido") = dr("SaldoCuota")
               End If
            End If

            drCl("IdFormasPago") = dr("IdFormasPago")
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago")
            drCl("ImporteCuota") = Decimal.Parse(dr("ImporteCuota").ToString())
            drCl("SaldoCuota") = Decimal.Parse(dr("SaldoCuota").ToString())

            If idCliente2 <> Long.Parse(dr("IdCliente").ToString()) Then
               Total = 0
            End If

            If tipoSaldo = "TODOS" Then
               If montoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
                  Total += Decimal.Parse(dr("ImporteCuota").ToString()) + Decimal.Parse(dr("Interes").ToString())
                  drCl("Interes") = dr("Interes")
               Else
                  Total += Decimal.Parse(dr("ImporteCuota").ToString())
                  drCl("Interes") = 0
               End If
            Else
               If montoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
                  Total += Decimal.Parse(dr("SaldoCuota").ToString()) + Decimal.Parse(dr("Interes").ToString())
                  drCl("Interes") = dr("Interes")
               Else
                  Total += Decimal.Parse(dr("SaldoCuota").ToString())
                  drCl("Interes") = 0
               End If
            End If

            drCl("Total") = Total

            drCl("Observacion") = dr("Observacion").ToString()
            drCl("NombreCategoria") = dr("NombreCategoria").ToString()
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica")

            drCl("NombreEstadoCliente") = dr("NombreEstadoCliente")


            drCl("NumeroOrdenCompra") = dr("NumeroOrdenCompra")
            drCl("IdProveedor") = dr("IdProveedor")
            drCl("CodigoProveedor") = dr("CodigoProveedor")
            drCl("NombreProveedor") = dr("NombreProveedor")

            drCl("IdCobrador") = dr("IdCobrador")
            drCl("NombreCobrador") = dr("NombreCobrador")
            drCl("CotizacionDolar") = dr("CotizacionDolar")
            'drCl("Interes") = dr("Interes")

            idCliente2 = Long.Parse(dr("IdCliente").ToString())

            drCl("Direccion") = dr("Direccion")

            If CtaCteEmbarcacion = True Then
               drCl("NombreEmbarcacion") = dr("NombreEmbarcacion")
            End If
            '-- REQ-36217.- ------------------------------------------
            drCl("idLocalidad") = Integer.Parse(dr("IdLocalidad").ToString())
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
            drCl("DetalleProducto") = dr("DetalleProducto").ToString()
            '-- REQ-36324.- ------------------------------------------
            drCl("IdCama") = dr("IdCama")
            '---------------------------------------------------------
            dt.Rows.Add(drCl)

         Next
      End If

      'If TipoSaldo = "TODOS" Then
      '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = True
      'Else
      '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = False
      'End If

      ugDetalle.DisplayLayout.Bands(0).Columns("DetalleProducto").Hidden = Not chbMostrarDetalleProducto.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreLocalidad").Hidden = Not chbLocalidad.Checked

      ugDetalle.DataSource = dt

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         '.Columns.Add("Ver", GetType(String))
         '.Columns.Add("TipoImpresora", GetType(String))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdVendedor", GetType(Integer))
         '.Columns.Add("NroDocVendedor", GetType(String))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("IdCliente", GetType(Long))
         '-.PE-32017.-
         .Columns.Add("CodVin", GetType(Long))
         .Columns.Add("NombreVin", GetType(String))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCliente2", GetType(String))
         .Columns.Add("NombreDeFantasia", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         '.Columns.Add("DescripcionTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         '--REQ-36217.- ---------------------------------
         .Columns.Add("DetalleProducto", GetType(String))
         '-----------------------------------------------
         .Columns.Add("CuotaNumero", GetType(Integer))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("DiasFactura", GetType(Integer))
         .Columns.Add("FechaVencimiento", GetType(Date))
         .Columns.Add("DiasVencido", GetType(Integer))
         .Columns.Add("IdFormasPago", GetType(Integer))
         .Columns.Add("DescripcionFormasPago", GetType(String))
         .Columns.Add("ImporteCuota", GetType(Decimal))
         .Columns.Add("SaldoCuota", GetType(Decimal))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("SaldoVencido", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("NombreCategoria", GetType(String))

         .Columns.Add("NombreZonaGeografica", GetType(String))

         .Columns.Add("Interes", GetType(Decimal))
         .Columns.Add("NombreEstadoCliente", GetType(String))

         .Columns.Add("NumeroOrdenCompra", GetType(Long))
         .Columns.Add("IdProveedor", GetType(Long))
         .Columns.Add("CodigoProveedor", GetType(Long))
         .Columns.Add("NombreProveedor", GetType(String))

         .Columns.Add("IdCobrador", GetType(Integer))
         .Columns.Add("NombreCobrador", GetType(String))
         .Columns.Add("CotizacionDolar", GetType(Decimal))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("NombreEmbarcacion", GetType(String))
         '--REQ-36217.- ---------------------------------
         .Columns.Add("IdLocalidad", GetType(Integer))
         .Columns.Add("NombreLocalidad", GetType(String))
         '--REQ-36324.- ---------------------------------
         .Columns.Add("IdCama", GetType(Long))
         '-----------------------------------------------
      End With

      Return dtTemp

   End Function

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      Dim primero = True

      With filtro

         If cmbSucursal.Enabled Then
            cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         If chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} ({1}) - ", cmbVendedor.Text, cmbTipoVendedor.Text) '-.PE-32017.-
         End If

         If chbCobrador.Checked Then
            .AppendFormat(" Cobradorr: {0} ({1}) - ", cmbCobrador.Text, cmbOrigenCobrador.Text)
         End If

         If chbFecha.Checked Then
            .AppendFormat("Fecha: Desde {0} Hasta {1} - ", dtpDesde.Text, dtpHasta.Text)
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ({2}) - ", bscCodigoCliente.Text, bscCliente.Text, cmbTipoCliente.Text) '-.PE-32017.-
         End If

         If chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", cmbZonaGeografica.Text)
         End If

         cmbGrupos.CargarFiltrosImpresionTiposComprobantes(filtro, False, True)

         If cmbGrabanLibro.Text <> "TODOS" Then
            .AppendFormat(" Graban Libro: {0} - ", cmbGrabanLibro.Text)
         End If

         If chbExcluirAnticipos.Checked Then
            .AppendFormat("Excluir Anticipos - ")
         End If

         If chbExcluirSaldosNegativos.Checked Then
            .AppendFormat("Excluir Saldos Negativos - ")
         End If

         If chbExcluirPreComprobantes.Checked Then
            .AppendFormat("Excluir Pre-Comprobantes - ")
         End If

         If chbAgruparIdClienteCtaCte.Checked Then
            .AppendFormat("Agrupados por Cliente de Cta. Cte. - ")
         End If

         'Minuta nunca tendria saldo solo.
         If chbExcluirMinutas.Checked And optTodos.Checked Then
            .AppendFormat("Excluir Minutas - ")
         End If

         If chbCategoria.Checked Then
            .AppendFormat(" Categoría: {0} ({1}) - ", cmbCategoria.Text, cmbTipoCategoria) '-.PE-32017.-
         End If

         If chbProvincia.Checked Then
            .AppendFormat(" Provincia: {0} - ", cmbProvincia.Text)
         End If

         If optTodos.Checked Then
            .AppendFormat("Saldo: Todos - ")
         End If

         If Me.chbEmbarcacionCama.Checked Then
            .AppendFormat("Por Embarcacion", bscNombreEmbarcacion.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub chbEmbarcacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmbarcacionCama.CheckedChanged
      '-- REQ-36324.- ----------------------------------------------------------------
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
   End Sub
   Private Function ConsultaEmbarcacionCama() As DataTable
      '-- REQ-36324.- ----------------------------------------------------------------
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

#End Region
End Class