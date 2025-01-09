Public Class PanelDeControlPorTipo
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _PermisoEjecucion As Boolean = False
   Private _PermisoCalidadFinal As Boolean = False
   Private _Totales As DataTable
   Private _ocultarFiltros As Boolean = False
#End Region

#Region "Propiedades"

   Private _intervalo As Integer
   Public Property Intervalo() As Integer
      Get
         Return _intervalo
      End Get
      Set(ByVal value As Integer)
         Me.Timer1.Enabled = False
         Me.Timer1.Interval = value
         _intervalo = value

         Me.Timer1.Enabled = Automatico
      End Set
   End Property

   Private _automatico As Boolean
   Public Property Automatico() As Boolean
      Get
         Return _automatico
      End Get
      Set(ByVal value As Boolean)
         If Not _automatico Then Me.Timer1.Stop()
         _automatico = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _publicos.CargaComboEstadosCalidad(cmbEstadoCalidad)

         _publicos.CargaComboDesdeEnum(cmbLiberado, GetType(Entidades.Publicos.SiNoTodos))
         cmbLiberado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbLiberadoPDI, GetType(Entidades.Publicos.SiNoTodos))
         cmbLiberadoPDI.SelectedValue = Entidades.Publicos.SiNoTodos.NO

         _publicos.CargaComboDesdeEnum(cmbEntregados, GetType(Entidades.Publicos.SiNoTodos))

         _publicos.CargaComboUbicacionCalidad(cmbUbicacion)
         Me.cmbUbicacion.SelectedIndex = -1

         Me.dtpDesde.Value = DateTime.Today

         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         _PermisoCalidadFinal = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-CF")


         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})

         ugDetalle.ContextMenuStrip = MenuContext
         ugDetalle.DisplayLayout.Override.ActiveRowAppearance.Reset()
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         If _ocultarFiltros Then
            Me.Text = "Panel de Control Gerencia"
            grbFiltros.Visible = False
            TryCatched(Sub() CargarGrillaDetalle())
         End If

         '# Refresco automático
         Dim tiempoRefresco As Integer = Reglas.Publicos.CalidadPanelDeControlTiempoRefresco

         Me.txtMinutos.Value = tiempoRefresco
         Me.Automatico = Me.chbActualizacionAutomatica.Checked
         Me.Timer1.Interval = tiempoRefresco * 60 * 1000
         Me.Timer1.Enabled = Automatico

         Me.tsbFInalizarListas.Visible = _PermisoCalidadFinal
         Me.tssFinalizarListas.Visible = _PermisoCalidadFinal

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Buscadores"

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

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCliente.Text = String.Empty
      End If
   End Sub

#End Region

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If chbProducto.Checked AndAlso (Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbCliente.Checked AndAlso (Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.CargarGrillaDetalle()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#Region "Eventos Filtros"
   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub()
                    chbMesCompleto.Enabled = chbFecha.Checked
                    dtpDesde.Enabled = chbFecha.Checked
                    dtpHasta.Enabled = chbFecha.Checked
                 End Sub)
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp
         Else
            Me.dtpDesde.Value = DateTime.Today

            Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception

         chbMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      Try
         Me.cmbEstadoCalidad.Enabled = Me.chbEstado.Checked
         If Not Me.chbEstado.Checked Then
            Me.cmbEstadoCalidad.SelectedIndex = -1
         Else
            If Me.cmbEstadoCalidad.Items.Count > 0 Then
               Me.cmbEstadoCalidad.SelectedIndex = 0
            End If
            Me.cmbEstadoCalidad.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region


   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Me.ListasControlPorProducto()
   End Sub

   Private Sub MenuContext_Click(sender As Object, e As EventArgs) Handles MenuContext.Click
      Me.ListasControlPorProducto()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbUbicacion.CheckedChanged
      Try
         Me.cmbUbicacion.Enabled = Me.chbUbicacion.Checked
         If Not Me.chbUbicacion.Checked Then
            Me.cmbUbicacion.SelectedIndex = -1
         Else
            If Me.cmbUbicacion.Items.Count > 0 Then
               Me.cmbUbicacion.SelectedIndex = 0
            End If
            Me.cmbUbicacion.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarGrilla()

      Me.chbFecha.Checked = False
      Me.chbProducto.Checked = False
      Me.chbCliente.Checked = False

      Me.dtpDesde.Value = DateTime.Today

      Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompleto.Checked = False

      Me.chbEstado.Checked = False
      Me.chbUbicacion.Checked = False

      Me.cmbLiberado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbLiberadoPDI.SelectedValue = Entidades.Publicos.SiNoTodos.NO
      Me.cmbEntregados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS


      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = "0 Registros"

      Me.btnConsultar.Focus()

      If _ocultarFiltros Then
         grbFiltros.Visible = False
         TryCatched(Sub() CargarGrillaDetalle())
      End If

      Me.chbActualizacionAutomatica.Checked = True
      Me.txtMinutos.Value = Reglas.Publicos.CalidadPanelDeControlTiempoRefresco()

   End Sub

   Private Sub CargarGrillaDetalle()

      Dim regla = New Reglas.ListasControlProductos()

      Dim pivotResult = regla.GetProductosPorListasControlTipos(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha), If(chbEstado.Checked, cmbEstadoCalidad.ValorSeleccionado(Of Integer), 0),
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                If(chbUbicacion.Checked, Me.cmbUbicacion.Text, String.Empty),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberadoPDI.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                _ocultarFiltros, Me.chbMostrarReparaciones.Checked)

      ugDetalle.DataSource = pivotResult.dtResult

      Dim pos As Integer = AjustarColumnasGrilla(ugDetalle, _tit)
      ugDetalle.InicializaTotales()
      ugDetalle.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed
      ugDetalle.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False

      With ugDetalle.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            Dim colName = drColumnas("NombreColumma").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")

            '   ugDetalle.AgregarTotalCustomColumna(colName, New CustomSummaries.SummaryCalidadPanelControlTotalPorTipo(pivotResult.dtColumnas))
         Next
      End With

      ugDetalle.DisplayLayout.Bands(0).Columns("CalidadFechaLiberado").FormatearColumna("Fecha Liberado", pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")
      ugDetalle.DisplayLayout.Bands(0).Columns("CalidadFechaLiberadoPDI").FormatearColumna("Fecha Liberado PDI", pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreProductoModelo").FormatearColumna("Modelo", pos, 94,, True)
      '  ugDetalle.DisplayLayout.Bands(0).Columns("NombreProductoModeloTipo").FormatearColumna("Tipo Modelo", pos, 80)


      Me.ColorEstados(pivotResult)

      With ugDetalle.DisplayLayout.Bands(0)

         _Totales = pivotResult.dtColumnas

         For Each dr As DataRow In _Totales.Rows
            If Integer.Parse(dr("IdListaControlTipo").ToString()) = 8 Then
               dr.Delete()
            End If
         Next
         _Totales.AcceptChanges()

         Dim dr1 As DataRow = _Totales.NewRow()
         dr1("NombreColumma") = "CalidadFechaLiberado"
         dr1("Rangohasta") = 6000
         _Totales.Rows.Add(dr1)


         Dim TotalCochesEnLinea As Integer = 0

         For Each drColumnas As DataRow In _Totales.Rows
            pos += 1
            Dim colName = drColumnas("NombreColumma").ToString()
            If Not colName = "CalidadFechaLiberado" Then
               ugDetalle.AgregarTotalCustomColumna(colName, New CustomSummaries.SummaryCalidadPanelControlTotalPorTipo(_Totales))


            End If
         Next

         For Each drColumnas As DataRow In _Totales.Rows
            Dim colName = drColumnas("NombreColumma").ToString()
            If Not colName = "CalidadFechaLiberado" Then
               TotalCochesEnLinea += Integer.Parse(ugDetalle.Rows.SummaryValues(colName).Value.ToString())
            End If
         Next

         Me.lblCantidadCochesEnLinea.Text = "Cantidad de coches en línea: " + TotalCochesEnLinea.ToString()

      End With




      If pivotResult.dtResult.Rows.Count > 0 Then
         Me.btnConsultar.Focus()

      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"

      '  Me.tssRegistros.Text = pivotResult.dtResult.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbProducto.Checked Then
            .AppendFormat(" Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbEstadoCalidad.SelectedIndex >= 0 Then
            .AppendFormat(" Estado: {0}", Me.cmbEstadoCalidad.Text.ToString())
         End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub ColorEstados(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      'Dim ColorEstado As Integer
      Dim color As Color = SystemColors.Control

      Dim colorPendiente = Drawing.Color.FromArgb(New Reglas.EstadosListasControl().GetEstadoColorPorId(Reglas.Publicos.EstadoListaControlPendiente.ValorNumericoPorDefecto(0I)))
      Dim colorEnProceso = Drawing.Color.FromArgb(New Reglas.EstadosListasControl().GetEstadoColorPorId(Reglas.Publicos.EstadoListaControlEnProceso))
      Dim colorFinalizado = Drawing.Color.FromArgb(New Reglas.EstadosListasControl().GetEstadoColorPorId(Reglas.Publicos.EstadoListaControlTerminado))

      For Each dr As UltraGridRow In ugDetalle.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr.Cells("E" + drColumnas("NombreColumma").ToString()).Value.ToString()) Then
               If Integer.Parse(dr.Cells("E" + drColumnas("NombreColumma").ToString()).Value.ToString()) = Reglas.Publicos.EstadoListaControlPendiente.ValorNumericoPorDefecto(0I) Then
                  dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, colorPendiente)
               ElseIf Integer.Parse(dr.Cells("E" + drColumnas("NombreColumma").ToString()).Value.ToString()) = Reglas.Publicos.EstadoListaControlTerminado Then
                  dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, colorFinalizado)
               Else
                  dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, colorEnProceso)
               End If
               'ColorEstado = New Reglas.EstadosListasControl().GetEstadoColorPorId(Integer.Parse(dr.Cells("E" + drColumnas("NombreColumma").ToString()).Value.ToString()))
               'color = Drawing.Color.FromArgb(ColorEstado)
               'dr.Cells(drColumnas("NombreColumma").ToString()).Appearance.BackColor = color
            End If
         Next
         If Not IsDBNull(dr.Cells("CalidadFechaLiberado").Value) Then
            dr.Cells("CalidadFechaLiberado").Color(Nothing, colorFinalizado)
         End If
         If Not IsDBNull(dr.Cells("CalidadFechaLiberadoPDI").Value) Then
            dr.Cells("CalidadFechaLiberadoPDI").Color(Nothing, colorFinalizado)
         End If
      Next
   End Sub

   Private Sub ListasControlPorProducto()
      Try
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         _PermisoEjecucion = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos")
         If _PermisoEjecucion Then
            'si no seleccionó una fila no le deja continuar
            If Me.ugDetalle.ActiveRow Is Nothing Then
               Exit Sub
            End If
            '----------
            Me.Cursor = Cursors.WaitCursor
            Dim fr As ListasControlProductos = New ListasControlProductos(Me.ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim(), IdFuncion)
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Else
            MessageBox.Show("No tiene acceso a la pantalla de Ejecución de Listas de Control.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
   End Sub

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _ocultarFiltros = parametros = "ocultarfiltros"
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      Try
         If Automatico Then
            Me.CargarGrillaDetalle()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtMinutos_ValueChanged(sender As Object, e As EventArgs) Handles txtMinutos.ValueChanged
      Try
         Me.Intervalo = CInt(Me.txtMinutos.Value) * 60 * 1000
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbActualizacionAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles chbActualizacionAutomatica.CheckedChanged
      Try

         Me.Automatico = Me.chbActualizacionAutomatica.Checked
         Me.Timer1.Enabled = Automatico

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDetalle.AfterRowFilterChanged
      Try
         Me.tssRegistros.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"

         Dim TotalCochesEnLinea As Integer = 0

         For Each drColumnas As DataRow In _Totales.Rows
            Dim colName = drColumnas("NombreColumma").ToString()
            If Not colName = "CalidadFechaLiberado" Then
               TotalCochesEnLinea += Integer.Parse(ugDetalle.Rows.SummaryValues(colName).Value.ToString())
            End If
         Next

         Me.lblCantidadCochesEnLinea.Text = "Cantidad de coches en línea: " + TotalCochesEnLinea.ToString()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbFInalizarListas_Click(sender As Object, e As EventArgs) Handles tsbFInalizarListas.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim CantidadListas As Integer = 0
         Dim oListasControlProductos As Reglas.ListasControlProductos = New Reglas.ListasControlProductos

         CantidadListas = oListasControlProductos.FinalizarListas()

         MessageBox.Show("Se actualizaron " & CantidadListas & " Listas exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbMostrarReparaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarReparaciones.CheckedChanged
      Try
         TryCatched(Sub() CargarGrillaDetalle())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


End Class