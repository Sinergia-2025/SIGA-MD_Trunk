Public Class InfCtaCteClientes

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _utilizaIntereses As Boolean
   Private _vieneDeOnLoad As Boolean = False
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _utilizaIntereses = New Reglas.Categorias().CategoriasConInteres().Count > 0

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         '# Rutas
         Me._publicos.CargaComboRutas(Me.cmbRutas, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)
         Me.cmbRutas.SelectedIndex = -1

         '# Días de Semana
         Me._publicos.CargaComboDesdeEnum(cmbDiaSemana, GetType(Entidades.Publicos.Dias))
         Me.cmbDiaSemana.SelectedIndex = -1

         _vieneDeOnLoad = True
         'Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , , , True)
         cmbTiposComprobantes.Initializar(False, "VENTAS", "CTACTECLIE")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         _vieneDeOnLoad = False

         cmbGrupos.Inicializar()
         Me.cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)


         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Hidden = (Me.cmbZonaGeografica.Items.Count = 1)

         Me.CargarColumnasASumar()

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreVendedor", "NombreCliente", "CUIT", "Telefonos", "Observacion", "NombreClienteCtaCte"}, {"Ver"})

         Me.LeerPreferencias()

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         If Not Publicos.TieneModuloContabilidad Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
         End If

         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("Interes").Hidden = Not _utilizaIntereses

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      Try
         Me.cmbRutas.Enabled = Me.chbRuta.Checked

         If Not Me.chbRuta.Checked Then
            Me.cmbRutas.SelectedIndex = -1
         End If

         Me.cmbRutas.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbDia_CheckedChanged(sender As Object, e As EventArgs) Handles chbDia.CheckedChanged
      Try
         Me.cmbDiaSemana.Enabled = Me.chbDia.Checked

         If Not Me.chbDia.Checked Then
            Me.cmbDiaSemana.SelectedIndex = -1
         End If

         Me.cmbDiaSemana.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 And e.Cell.Column.Header.Caption = "Ver" Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString())

            If oTipoComprobante.EsRecibo = True Then
               'imprime los recibos
               Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
               Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                             Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                             Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                             Int32.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                             Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))
               Dim imp As RecibosImprimir = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            Else
               Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                           Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                           Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

               Dim oImpr As Impresion = New Impresion(venta)

               If Not oTipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If

            End If

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub InfCtaCteClientes_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion

         'Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         Dim comunes As CtasCtesClientesComunes = New CtasCtesClientesComunes()

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


         comunes.ImprimirInformeCtaCteClientes(DirectCast(Me.ugDetalle.DataSource, DataTable),
                                               Filtros,
                                               False,
                                             (Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0),
                                               "",
                                               Me.rbtImpresionNormal.Checked,
                                               Me.Text,
                                               True, Correo)

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
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

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Permitido = Me.chbCliente.Checked
      Me.bscCodigoCliente.Permitido = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
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

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
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

         If Me.chbRuta.Checked AndAlso Me.cmbRutas.SelectedIndex = -1 Then
            ShowMessage("ATENCIÓN: Se activó filtro por Ruta pero no seleccionó ninguna.")
            Me.cmbRutas.Focus()
            Exit Sub
         End If

         If Me.chbDia.Checked AndAlso Me.cmbDiaSemana.SelectedIndex = -1 Then
            ShowMessage("ATENCIÓN: Se activó filtro por Dia pero no seleccionó ninguno.")
            Me.cmbDiaSemana.Focus()
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   '-.PE-32388.-
   Private Sub bscCodReserva_BuscadorClick() Handles bscCodReserva.BuscadorClick
      Dim nroReserva As Integer = 0
      Try
         Me._publicos.PreparaGrillaReservas(Me.bscCodReserva)
         Dim oReservas As Reglas.ReservasTurismo = New Reglas.ReservasTurismo
         If Me.bscCodReserva.Text.Trim.Length > 0 Then
            nroReserva = Integer.Parse(Me.bscCodReserva.Text.Trim())
         End If
         Me.bscCodReserva.Datos = oReservas.GetFiltradoPorCodigo(nroReserva)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodReserva_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodReserva.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosReserva(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscReserva_BuscadorClick() Handles bscReserva.BuscadorClick
      Try
         Me._publicos.PreparaGrillaReservas(Me.bscReserva)
         Dim oReservas As Reglas.ReservasTurismo = New Reglas.ReservasTurismo
         Me.bscReserva.Datos = oReservas.GetFiltradoPorNombre(Me.bscReserva.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscReserva_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscReserva.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosReserva(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbReserva_CheckedChanged(sender As Object, e As EventArgs) Handles chbReserva.CheckedChanged
      Me.bscReserva.Permitido = Me.chbReserva.Checked
      Me.bscCodReserva.Permitido = Me.chbReserva.Checked

      If Not Me.chbReserva.Checked Then
         Me.bscCodReserva.Text = ""
         Me.bscCodReserva.Tag = Nothing
         Me.bscReserva.Text = ""
      Else
         Me.bscCodReserva.Focus()
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Saldo")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Saldo", SummaryType.Sum, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

      'With Me.ugDetalle.DisplayLayout.Bands(0)
      '   'summary2 = .Summaries.Add("Interes", SummaryType.Sum, .Columns("Interes"))
      '   summary2.DisplayFormat = "{0:N2}"
      '   summary2.Appearance.TextHAlign = HAlign.Right
      'End With

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

   End Sub

   '-.PE-32388.-
   Private Sub CargarDatosReserva(dr As DataGridViewRow)

      Me.bscReserva.Text = dr.Cells("NombreEstablecimiento").Value.ToString()
      Me.bscCodReserva.Text = dr.Cells("NumeroReserva").Value.ToString()
      Me.bscReserva.Permitido = False
      Me.bscCodReserva.Permitido = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If
      Me.rbtVenActual.Checked = False

      Me.chbCliente.Checked = False
      Me.chbFecha.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.optConSaldo.Checked = True
      Me.chbExcluirSaldosNegativos.Checked = False
      Me.chbExcluirAnticipos.Checked = False
      Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False
      Me.chbRuta.Checked = False
      Me.chbDia.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      Me.cmbGrupos.Refrescar()
      Me.rbtCatActual.Checked = True

      Me.chbExcluirMinutas.Checked = True
      Me.rbtImpresionNormal.Checked = True

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbAgruparIdClienteCtaCte.Checked = False

      cmbSucursal.Refrescar()

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Me.ugDetalle.Update()

      Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

      Dim idVendedor As Integer = 0

      Dim idCliente As Long = 0
      Dim idZonaGeografica As String = String.Empty
      Dim desde As Date = Nothing
      Dim hasta As Date = Nothing
      'Dim tipoComprobante As String = String.Empty
      Dim tipoSaldo As String = String.Empty
      Dim idCategoria As Integer = 0
      Dim excluirSaldosNegativos As String = "NO"
      Dim excluirAnticipos As String = "NO"
      Dim excluirPreComprobantes As String = "NO"
      Dim idProvincia As String = String.Empty
      Dim tipoCategoria As String = String.Empty
      Dim tipoVendedor As String = String.Empty
      Dim excluirMinutas As String = "NO"
      Dim idReserva As Integer = 0

      Dim total As Decimal = 0

      Try

         '---------------------------------------------------------------------------------------------

         If Me.cmbVendedor.Enabled Then
            idVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbFecha.Checked Then
            desde = Me.dtpDesde.Value
            hasta = Me.dtpHasta.Value
         End If

         If Me.cmbCategoria.Enabled Then
            idCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            excluirSaldosNegativos = "SI"
         End If

         If Me.chbExcluirAnticipos.Checked Then
            excluirAnticipos = "SI"
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            excluirPreComprobantes = "SI"
         End If

         If Me.chbProvincia.Checked Then
            idProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         tipoSaldo = IIf(Me.optTodos.Checked, "TODOS", "SOLOSALDO").ToString()

         tipoCategoria = IIf(Me.rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()

         tipoVendedor = IIf(Me.rbtVenMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()

         If Me.chbExcluirMinutas.Checked Then
            excluirMinutas = "SI"
         End If

         '# Ruta
         Dim idRuta As Integer = 0
         If Me.chbRuta.Checked Then
            idRuta = Me.cmbRutas.ValorSeleccionado(Of Integer)
         End If

         '# Dia
         Dim dia As Entidades.Publicos.Dias? = Nothing
         If Me.chbDia.Checked Then
            dia = Me.cmbDiaSemana.ValorSeleccionado(Of Entidades.Publicos.Dias)()
         End If

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         'Dim drCl As DataRow

         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()

         If Me.chbTipoComprobante.Checked Then
            tiposComprobantes.AddRange(cmbTiposComprobantes.GetTiposComprobantes())
         Else
            tiposComprobantes = Nothing
         End If

         If Me.bscCodReserva.Text.Length > 0 Then
            idReserva = Integer.Parse(Me.bscCodReserva.Text.ToString())
         End If

         dtDetalle = oCtaCte.GetCtaCte(actual.Sucursal.Id,
                                       desde, hasta,
                                       idVendedor,
                                       idCliente,
                                       tiposComprobantes,
                                       tipoSaldo,
                                       idZonaGeografica,
                                       idCategoria,
                                       Me.cmbGrabanLibro.Text,
                                       cmbGrupos.GetGruposTiposComprobantes(),
                                       excluirSaldosNegativos,
                                       excluirAnticipos,
                                       excluirPreComprobantes,
                                       idProvincia, tipoCategoria, tipoVendedor, excluirMinutas, Me.cmbSucursal.GetSucursales(),
                                       Me.chbAgruparIdClienteCtaCte.Checked,
                                       idRuta, dia, idReserva)

         Dim com As CtasCtesClientesComunes = New CtasCtesClientesComunes()
         dt = com.GetDataTableParaClientes(dtDetalle, tipoSaldo)

         'If TipoSaldo = "TODOS" Then
         '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = True
         'Else
         '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = False
         'End If

         Me.ugDetalle.DataSource = dt

         With ugDetalle.DisplayLayout.Bands(0)
            If chbAgruparIdClienteCtaCte.Checked Then
               .Columns("CodigoClienteCtaCte").Header.Caption = "Código Original"
               .Columns("NombreClienteCtaCte").Header.Caption = "Cliente Original"
            Else
               .Columns("CodigoClienteCtaCte").Header.Caption = "Código Cta.Cte."
               .Columns("NombreClienteCtaCte").Header.Caption = "Cliente Cta.Cte."
            End If
         End With

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} ({1}) - ", Me.cmbVendedor.Text, IIf(rbtVenActual.Checked, "Actual", "Movimiento").ToString() & ")")
         End If

         If Me.chbFecha.Checked Then
            .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If


         Me.cmbGrupos.CargarFiltrosImpresionTiposComprobantes(filtro, False, True)


         If Me.cmbGrabanLibro.Text <> "TODOS" Then
            .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.chbExcluirAnticipos.Checked Then
            .AppendFormat("Excluir Anticipos - ")
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            .AppendFormat("Excluir Saldos Negativos - ")
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            .AppendFormat("Excluir Pre-Comprobantes - ")
         End If

         If Me.chbAgruparIdClienteCtaCte.Checked Then
            .AppendFormat("Agrupados por Cliente de Cta. Cte. - ")
         End If

         'Minuta nunca tendria saldo solo.
         If Me.chbExcluirMinutas.Checked And Me.optTodos.Checked Then
            .AppendFormat("Excluir Minutas - ")
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoría: {0} ({1}) - ", Me.cmbCategoria.Text, IIf(rbtCatActual.Checked, "Actual", "Movimiento"))
         End If

         If Me.chbProvincia.Checked Then
            .AppendFormat(" Provincia: {0} - ", Me.cmbProvincia.Text)
         End If

         If Me.optTodos.Checked Then
            .AppendFormat("Saldo: Todos - ")
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

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

#End Region

End Class