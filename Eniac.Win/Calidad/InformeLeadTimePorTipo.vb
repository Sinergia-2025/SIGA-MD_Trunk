Public Class InformeLeadTimePorTipo
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _PermisoEjecucion As Boolean = False

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
         _publicos.CargaComboDesdeEnum(cmbEntregados, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbEntregados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         _publicos.CargaComboDesdeEnum(cmbLiberadoPDI, GetType(Entidades.Publicos.SiNoTodos))
         cmbLiberadoPDI.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboUbicacionCalidad(cmbUbicacion)
         Me.cmbUbicacion.SelectedIndex = -1

         Me.dtpDesde.Value = DateTime.Today

         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me.dtpDesdeLiberado.Value = DateTime.Today

         Me.dtpHastaLiberado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

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

         '# Refresco autom�tico
         Dim tiempoRefresco As Integer = Reglas.Publicos.CalidadPanelDeControlTiempoRefresco

         Me.txtMinutos.Value = tiempoRefresco
         Me.Automatico = Me.chbActualizacionAutomatica.Checked
         Me.Timer1.Interval = tiempoRefresco * 60 * 1000
         Me.Timer1.Enabled = Automatico



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
      Me.UltraGridPrintDocument1.Footer.TextRight = "P�gina: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If chbProducto.Checked AndAlso (Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccion� un Producto aunque activ� ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbCliente.Checked AndAlso (Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccion� un Cliente aunque activ� ese Filtro.")
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

      Me.rbtIngreso.Enabled = Me.chbFecha.Checked
      Me.rbtIngreso.Checked = Me.chbFecha.Checked

      If Not chbFecha.Checked And Me.chbLiberado.Checked Then
         Me.rbtLiberado.Checked = True
      End If
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
      Me.chbLiberado.Checked = False

      Me.chbProducto.Checked = False
      Me.chbCliente.Checked = False

      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompleto.Checked = False


      Me.dtpDesdeLiberado.Value = DateTime.Today
      Me.dtpHastaLiberado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompletoLiberado.Checked = False

      Me.chbEstado.Checked = False
      Me.chbUbicacion.Checked = False

      Me.cmbLiberado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbEntregados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbLiberadoPDI.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

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

      Me.UltraChart1.Visible = False
      Me.grpRangoG1.Visible = False
      Me.UltraChart2.Visible = False
      Me.grpRangoG2.Visible = False
      Me.UltraChart3.Visible = False
      Me.grpRangoG3.Visible = False
      Me.grpRangoG4.Visible = False

      Me.chbMostrarFechas.Checked = False

   End Sub

   Private Sub CargarGrillaDetalle()

      Dim regla = New Reglas.ListasControlProductos()

      Dim pivotResult = regla.GetLeadTimeListasControlTipo(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                If(chbEstado.Checked, cmbEstadoCalidad.ValorSeleccionado(Of Integer), 0),
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                If(chbUbicacion.Checked, Me.cmbUbicacion.Text, String.Empty),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberadoPDI.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), 0)

      ugDetalle.DataSource = pivotResult.dtResult

      Dim pos As Integer = AjustarColumnasGrilla(ugDetalle, _tit)
      ugDetalle.InicializaTotales()
      ugDetalle.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed
      ugDetalle.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
      Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()

      ' ugDetalle.DisplayLayout.Bands(0).Columns("CalidadFechaLiberado").FormatearColumna("Fecha Liberado", pos, 85, HAlign.Center, , "dd/MM/yyyy")

      With ugDetalle.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If chbMostrarFechas.Checked Then
               Dim colName = drColumnas("NombreColumma").ToString()
               .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")
            End If
            Dim colName2 = "F" + drColumnas("NombreColumma").ToString()
            .Columns(colName2).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, 72, HAlign.Right, , "N2")

            Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(colName2)
            Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(colName2, SummaryType.Average, columnToSummarize1)
            summary1.DisplayFormat = "{0:N2}"
            summary1.Appearance.TextHAlign = HAlign.Right
         Next
      End With

      ' If chbMostrarFechas.Checked Then
      ' End If

      Me.ColumnasASumar()

      Me.CalcularLeadTime(pivotResult)

      ugDetalle.DisplayLayout.Bands(0).Columns("LeadTimeLiberado").FormatearColumna("Lead Time", pos, 72, HAlign.Right, , "{0:N}")
      ugDetalle.DisplayLayout.Bands(0).Columns("LeadTimeLiberadoPDI").FormatearColumna("Lead Time PDI", pos, 72, HAlign.Right, , "{0:N}")
      ugDetalle.DisplayLayout.Bands(0).Columns("DifLeadTimeLeadTimePDI").FormatearColumna("Diferencia Lead Time / Lead Time PDI", pos, 72, HAlign.Right, , "{0:N}")


      Me.ColorEstados(pivotResult)

      If pivotResult.dtResult.Rows.Count > 0 Then
         Me.btnConsultar.Focus()
         Me.Graficar(pivotResult)
      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = pivotResult.dtResult.Rows.Count.ToString() & " Registros"

   End Sub
   Private Sub CalcularLeadTime(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      'Calculo Fechas Lead Time
      Dim Resta As Long
      Dim Resta1 As Long

      Dim SigColumna As Integer
      Dim FechaInicio As DateTime
      Dim Entro As Boolean = False
      Dim Unidad As DateInterval
      If Me.rbtLeadTimeDias.Checked Then
         Unidad = DateInterval.Day
      Else
         Unidad = DateInterval.Hour
      End If

      For Each dr As UltraGridRow In ugDetalle.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
               If Not Entro Then
                  FechaInicio = Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString())
                  Entro = True
               End If
               SigColumna = dr.Cells(drColumnas("NombreColumma").ToString()).Column.Index + 1

               If IsDate(dr.Cells(SigColumna).Value.ToString()) Then
                  Resta = DateDiff(DateInterval.Minute, Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()), Date.Parse(dr.Cells(SigColumna).Value.ToString()))
                  If Unidad = DateInterval.Day Then
                     dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round((Resta / 60) / 24, 2)
                  Else
                     dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round(Resta / 60, 2)
                  End If

               Else
                  If IsNumeric(dr.Cells(SigColumna).Value.ToString()) Then
                     If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberado").Value.ToString()) Then
                        Resta = DateDiff(DateInterval.Minute, Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()), Date.Parse(dr.Cells("CalidadFechaLiberado").Value.ToString()))
                        If Unidad = DateInterval.Day Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round((Resta / 60) / 24, 2)
                        Else
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round(Resta / 60, 2)
                        End If

                        Resta1 = DateDiff(DateInterval.Minute, FechaInicio, Date.Parse(dr.Cells("CalidadFechaLiberado").Value.ToString()))

                        If Unidad = DateInterval.Day Then
                           dr.Cells("LeadTimeLiberado").Value = Math.Round((Resta1 / 60) / 24, 2)
                        Else
                           dr.Cells("LeadTimeLiberado").Value = Math.Round(Resta1 / 60, 2)
                        End If

                        If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()) Then
                           Resta = DateDiff(DateInterval.Minute, Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()), Date.Parse(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()))
                           If Unidad = DateInterval.Day Then
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round((Resta / 60) / 24, 2)
                           Else
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round(Resta / 60, 2)
                           End If

                           Resta1 = DateDiff(DateInterval.Minute, FechaInicio, Date.Parse(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()))

                           If Unidad = DateInterval.Day Then
                              dr.Cells("LeadTimeLiberadoPDI").Value = Math.Round((Resta1 / 60) / 24, 2)
                           Else
                              dr.Cells("LeadTimeLiberadoPDI").Value = Math.Round(Resta1 / 60, 2)
                           End If
                        End If

                        Exit For

                     End If

                  Else
                     Dim SigSigColumna As Integer = SigColumna + 1
                     If Not IsNumeric(dr.Cells(SigSigColumna).Value.ToString()) Then
                        If Not String.IsNullOrEmpty(dr.Cells(SigSigColumna).Value.ToString()) Then
                           Resta = DateDiff(DateInterval.Minute, Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()), Date.Parse(dr.Cells(SigSigColumna).Value.ToString()))
                           If Unidad = DateInterval.Day Then
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round((Resta / 60) / 24, 2)
                           Else
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round(Resta / 60, 2)
                           End If
                        End If
                     Else
                        If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberado").Value.ToString()) Then
                           Resta = DateDiff(DateInterval.Minute, Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()), Date.Parse(dr.Cells("CalidadFechaLiberado").Value.ToString()))
                           If Unidad = DateInterval.Day Then
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round((Resta / 60) / 24, 2)
                           Else
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round(Resta / 60, 2)
                           End If

                           Resta1 = DateDiff(DateInterval.Minute, FechaInicio, Date.Parse(dr.Cells("CalidadFechaLiberado").Value.ToString()))

                           If Unidad = DateInterval.Day Then
                              dr.Cells("LeadTimeLiberado").Value = Math.Round((Resta1 / 60) / 24, 2)
                           Else
                              dr.Cells("LeadTimeLiberado").Value = Math.Round(Resta1 / 60, 2)
                           End If

                        End If
                        If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()) Then
                           Resta = DateDiff(DateInterval.Minute, Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()), Date.Parse(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()))
                           If Unidad = DateInterval.Day Then
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round((Resta / 60) / 24, 2)
                           Else
                              dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value = Math.Round(Resta / 60, 2)
                           End If

                           Resta1 = DateDiff(DateInterval.Minute, FechaInicio, Date.Parse(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()))

                           If Unidad = DateInterval.Day Then
                              dr.Cells("LeadTimeLiberadoPDI").Value = Math.Round((Resta1 / 60) / 24, 2)
                           Else
                              dr.Cells("LeadTimeLiberadoPDI").Value = Math.Round(Resta1 / 60, 2)
                           End If

                        End If
                        Exit For

                     End If
                     '  Continue For

                  End If
               End If
            End If
         Next
         ' diferencia entre lead time y lead time PDI
         If IsNumeric(dr.Cells("LeadTimeLiberado").Value.ToString()) And IsNumeric(dr.Cells("LeadTimeLiberadoPDI").Value.ToString()) Then

            dr.Cells("DifLeadTimeLeadTimePDI").Value = Decimal.Parse(dr.Cells("LeadTimeLiberadoPDI").Value.ToString()) - Decimal.Parse(dr.Cells("LeadTimeLiberado").Value.ToString())

            'If Unidad = DateInterval.Day Then
            '   dr.Cells("DifLeadTimeLeadTimePDI").Value = Math.Round((Resta1 / 60) / 24, 2)
            'Else
            '   dr.Cells("DifLeadTimeLeadTimePDI").Value = Math.Round(Resta1 / 60, 2)
            'End If

         End If
         Entro = False
      Next



   End Sub

   Private Sub Graficar(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)

      Me.ChartPorTipo(pivotResult)

      Me.ChartPorModelo(pivotResult)

      If chbFecha.Checked Or chbLiberado.Checked Then
         Me.ChartsPorFecha(pivotResult)
      End If

   End Sub

   Private Sub ChartPorTipo(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      Dim Disponibles As Integer = 0
      Dim Liberados As Integer = 0
      Dim NoLiberados As Integer = 0
      Dim cant As Integer = 0

      Me.UltraChart1.Visible = True
      Me.grpRangoG1.Visible = True

      Dim table As DataTable = New DataTable()

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         Dim colName = drColumnas("NombreListaControlTipo").ToString()
         table.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next
      table.Columns.Add("LeadTimeTotal", System.Type.GetType("System.Int32"))

      Dim dr As DataRow = table.NewRow
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         Dim colName = drColumnas("NombreListaControlTipo").ToString()
         Dim colName2 = "F" + drColumnas("NombreColumma").ToString()
         dr(colName) = CInt(Me.ugDetalle.Rows.SummaryValues(colName2).Value)
      Next
      dr("LeadTimeTotal") = CInt(Me.ugDetalle.Rows.SummaryValues("LeadTimeLiberado").Value)
      table.Rows.Add(dr)

      'Controla tope de eje y del grafico
      Dim ValorMaximo As Integer = Integer.Parse(table.Compute("Max(LeadTimeTotal)", "").ToString())

      If rbtAutomaticoG1.Checked Then
         Me.UltraChart1.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Automatic
      Else

         If ValorMaximo > Integer.Parse(Me.txtManualMaximoG1.Text.ToString()) Then
            MessageBox.Show("El m�ximo es menor que los datos, reingrese valor m�ximo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtManualMaximoG1.Focus()
            Exit Sub
         Else
            Me.UltraChart1.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom
            Me.UltraChart1.Axis.Y.RangeMin = Double.Parse(Me.txtManualMinimoG1.Text.ToString())
            Me.UltraChart1.Axis.Y.RangeMax = Double.Parse(Me.txtManualMaximoG1.Text.ToString())
         End If

      End If

      If Me.rbtLeadTimeDias.Checked Then
         Me.UltraChart1.TitleTop.Text = "Lead Time por Secci�n (D�as)"
      Else
         Me.UltraChart1.TitleTop.Text = "Lead Time por Secci�n (Horas)"
      End If

      Me.UltraChart1.DataSource = table

      Me.UltraChart1.DataBind()
   End Sub

   Private Sub ChartPorModelo(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      Me.UltraChart2.Visible = True
      Me.grpRangoG2.Visible = True

      Dim Modelo As List(Of String) = (From d_row In pivotResult.dtResult.AsEnumerable()
                                       Select d_row.Field(Of String)("NombreProductoModelo")
                                       Distinct).ToList

      Dim table As DataTable = New DataTable()
      table.Columns.Add("Modelo", System.Type.GetType("System.String"))
      table.Columns.Add("Cant", System.Type.GetType("System.Int32"))
      table.Columns.Add("Valor", System.Type.GetType("System.Decimal"))

      Dim dr As DataRow
      For Each mo As String In Modelo
         dr = table.NewRow
         dr("Modelo") = mo
         dr("Cant") = 0
         dr("Valor") = 0
         table.Rows.Add(dr)
      Next

      For Each mo As DataRow In table.Rows
         For Each dr1 As UltraGridRow In ugDetalle.Rows
            If dr1.Cells("NombreProductoModelo").Value.ToString() = mo("Modelo").ToString() _
               And Not String.IsNullOrEmpty(dr1.Cells("LeadTimeLiberado").Value.ToString()) Then
               mo("Cant") = Integer.Parse(mo("Cant").ToString()) + 1
               mo("Valor") = Decimal.Parse(mo("Valor").ToString()) + Decimal.Parse(dr1.Cells("LeadTimeLiberado").Value.ToString())
            End If
         Next
      Next

      For Each mo As DataRow In table.Rows
         If Integer.Parse(mo("Cant").ToString()) <> 0 Then
            mo("Valor") = Math.Round(Decimal.Parse(mo("Valor").ToString()) / Decimal.Parse(mo("Cant").ToString()), 2)
         End If
      Next

      table.Columns.Remove("Cant")

      'Controla tope de eje y del grafico
      Dim ValorMaximo As Integer = CInt(table.Compute("Max(Valor)", "").ToString())

      If rbtAutomaticoG2.Checked Then
         Me.UltraChart2.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Automatic
      Else

         If ValorMaximo > Integer.Parse(Me.txtManualMaximoG2.Text.ToString()) Then
            MessageBox.Show("El m�ximo es menor que los datos, reingrese valor m�ximo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtManualMaximoG2.Focus()
            Exit Sub
         Else
            Me.UltraChart2.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom
            Me.UltraChart2.Axis.Y.RangeMin = Double.Parse(Me.txtManualMinimoG2.Text.ToString())
            Me.UltraChart2.Axis.Y.RangeMax = Double.Parse(Me.txtManualMaximoG2.Text.ToString())
         End If

      End If

      Me.UltraChart2.DataSource = table

      Me.UltraChart2.DataBind()

   End Sub

   Private Sub ChartsPorFecha(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)

      Me.UltraChart3.Visible = True
      Me.grpRangoG3.Visible = True
      Me.grpRangoG4.Visible = True

      Dim Datos As DataTable = DirectCast(ugDetalle.DataSource, DataTable)
      Dim table As DataTable = New DataTable()
      Dim Fecha As List(Of String)
      Dim TipoFecha As String

      If rbtIngreso.Checked Then
         TipoFecha = "CalidadFechaIngreso"
      Else
         TipoFecha = "CalidadFechaLiberado"
      End If


      If rbtDias.Checked Then

         Fecha = (From d_row In Datos.AsEnumerable()
                  Select Date.Parse(d_row.Field(Of Date)(TipoFecha).ToString()).ToString("yyyy/MM/dd")
                  Distinct).ToList

         Fecha.Sort()

         table.Columns.Add("Fecha", System.Type.GetType("System.String"))
         table.Columns.Add("Cant", System.Type.GetType("System.Int32"))
         table.Columns.Add("LeadTime", System.Type.GetType("System.Int32"))

         Dim dr As DataRow
         For Each fec As String In Fecha
            dr = table.NewRow
            dr("Fecha") = fec
            dr("Cant") = 0
            dr("LeadTime") = 0
            table.Rows.Add(dr)
         Next

         For Each fec As DataRow In table.Rows
            For Each dr1 As UltraGridRow In ugDetalle.Rows
               If Date.Parse(dr1.Cells(TipoFecha).Value.ToString()).ToString("yyyy/MM/dd") = fec("Fecha").ToString() _
                  And Not String.IsNullOrEmpty(dr1.Cells("LeadTimeLiberado").Value.ToString()) Then
                  fec("Cant") = Integer.Parse(fec("Cant").ToString()) + 1
                  fec("LeadTime") = CInt(fec("LeadTime").ToString()) + Decimal.Parse(dr1.Cells("LeadTimeLiberado").Value.ToString())
               End If
            Next
         Next

      Else
         Dim MesIngreso As List(Of String) = (From d_row In Datos.AsEnumerable()
                                              Select Date.Parse(d_row.Field(Of Date)(TipoFecha).ToString()).ToString("yyyy/MM")
                                              Distinct).ToList

         MesIngreso.Sort()

         table.Columns.Add("Mes", System.Type.GetType("System.String"))
         table.Columns.Add("Cant", System.Type.GetType("System.Int32"))
         table.Columns.Add("LeadTime", System.Type.GetType("System.Int32"))

         Dim dr As DataRow
         For Each fec As String In MesIngreso
            dr = table.NewRow
            dr("Mes") = fec
            dr("Cant") = 0
            dr("LeadTime") = 0
            table.Rows.Add(dr)
         Next

         For Each fec As DataRow In table.Rows
            For Each dr1 As UltraGridRow In ugDetalle.Rows
               If Date.Parse(dr1.Cells(TipoFecha).Value.ToString()).ToString("yyyy/MM") = fec("Mes").ToString() _
                  And Not String.IsNullOrEmpty(dr1.Cells("LeadTimeLiberado").Value.ToString()) Then
                  fec("Cant") = Integer.Parse(fec("Cant").ToString()) + 1
                  fec("LeadTime") = CInt(fec("LeadTime").ToString()) + Decimal.Parse(dr1.Cells("LeadTimeLiberado").Value.ToString())
               End If
            Next
         Next

      End If

      For Each mo As DataRow In table.Rows
         If Integer.Parse(mo("Cant").ToString()) <> 0 Then
            mo("LeadTime") = CInt(Decimal.Parse(mo("LeadTime").ToString()) / Decimal.Parse(mo("Cant").ToString()))
         End If
      Next

      table.Columns.Remove("Cant")

      Dim ValorMaximo As Integer = Integer.Parse(table.Compute("Max(LeadTime)", "").ToString())

      If Me.rbtIngreso.Checked Then
         Me.UltraChart3.TitleTop.Text = "Lead Time por Fecha de Ingreso"
      Else
         Me.UltraChart3.TitleTop.Text = "Lead Time por Fecha de Liberado"
      End If

      If rbtAutomaticoG3.Checked Then
         Me.UltraChart3.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Automatic
      Else

         If ValorMaximo > Integer.Parse(Me.txtManualMaximoG3.Text.ToString()) Then
            MessageBox.Show("El m�ximo es menor que los datos, reingrese valor m�ximo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtManualMaximoG3.Focus()
            Exit Sub
         Else
            Me.UltraChart3.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom
            Me.UltraChart3.Axis.Y.RangeMin = Double.Parse(Me.txtManualMinimoG3.Text.ToString())
            Me.UltraChart3.Axis.Y.RangeMax = Double.Parse(Me.txtManualMaximoG3.Text.ToString())
         End If

      End If

      If rbtAutomaticoG4.Checked Then
         Me.UltraChart3.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart
      Else
         Me.UltraChart3.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.DataInterval
         Me.UltraChart3.Axis.Y.TickmarkInterval = Double.Parse(Me.txtManualG4.Text.ToString())
      End If

      If rbtMeses.Checked Then
         Me.UltraChart3.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal
      Else
         Me.UltraChart3.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing
      End If

      table.Columns("LeadTime").ColumnName = "Lead Time"
      ' table.Columns("Cant").ColumnName = "Cantidad de Coches"

      Me.UltraChart3.DataSource = table

      Me.UltraChart3.DataBind()

   End Sub

   Private Sub ColumnasASumar()

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("LeadTimeLiberado")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("LeadTimeLiberado", SummaryType.Average, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("LeadTimeLiberadoPDI")
      Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("LeadTimeLiberadoPDI", SummaryType.Average, columnToSummarize3)
      summary3.DisplayFormat = "{0:N2}"
      summary3.Appearance.TextHAlign = HAlign.Right


      Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("DifLeadTimeLeadTimePDI")
      Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("DifLeadTimeLeadTimePDI", SummaryType.Average, columnToSummarize4)
      summary4.DisplayFormat = "{0:N2}"
      summary4.Appearance.TextHAlign = HAlign.Right

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

      Dim ListacontrolTipo As Entidades.ListaControlTipo = New Entidades.ListaControlTipo()

      For Each dr As UltraGridRow In ugDetalle.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) Then
               ListacontrolTipo = New Reglas.ListasControlTipos().GetUno(Integer.Parse(drColumnas("IdListaControlTipo").ToString()))

               If ListacontrolTipo.LeadTimeMenosDe <> 0 Then
                  If rbtLeadTimeDias.Checked Then
                     If ListacontrolTipo.DiasLeadTimeMenosDe Then
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) < ListacontrolTipo.LeadTimeMenosDe Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     Else
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) < (ListacontrolTipo.LeadTimeMenosDe / 24) Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     End If
                  Else
                     If ListacontrolTipo.DiasLeadTimeMenosDe Then
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) < (ListacontrolTipo.LeadTimeMenosDe * 24) Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     Else
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) < (ListacontrolTipo.LeadTimeMenosDe) Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     End If
                  End If
               End If

               If ListacontrolTipo.LeadTimeMasDe <> 0 Then
                  If rbtLeadTimeDias.Checked Then
                     If ListacontrolTipo.DiasLeadTimeMasDe Then
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) > ListacontrolTipo.LeadTimeMasDe Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     Else
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) > (ListacontrolTipo.LeadTimeMasDe / 24) Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     End If
                  Else
                     If ListacontrolTipo.DiasLeadTimeMasDe Then
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) > (ListacontrolTipo.LeadTimeMasDe * 24) Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     Else
                        If Decimal.Parse(dr.Cells("F" + drColumnas("NombreColumma").ToString()).Value.ToString()) > (ListacontrolTipo.LeadTimeMasDe) Then
                           dr.Cells("F" + drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                        End If
                     End If
                  End If
               End If

            End If
         Next
      Next
   End Sub

   Private Sub ListasControlPorProducto()
      Try
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         _PermisoEjecucion = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos")
         If _PermisoEjecucion Then
            'si no seleccion� una fila no le deja continuar
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
            MessageBox.Show("No tiene acceso a la pantalla de Ejecuci�n de Listas de Control.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

   'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
   '   Try
   '      Me.CargarGrillaDetalle()
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

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
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbLiberado_CheckedChanged(sender As Object, e As EventArgs) Handles chbLiberado.CheckedChanged

      TryCatched(Sub()
                    chbMesCompletoLiberado.Enabled = chbLiberado.Checked
                    dtpDesdeLiberado.Enabled = chbLiberado.Checked
                    dtpHastaLiberado.Enabled = chbLiberado.Checked
                 End Sub)

      Me.rbtLiberado.Enabled = Me.chbLiberado.Checked
      Me.rbtLiberado.Checked = Me.chbLiberado.Checked

      If Not chbLiberado.Checked And Me.chbFecha.Checked Then
         Me.rbtIngreso.Checked = True
      End If
   End Sub

   Private Sub chbMesCompletoLiberado_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoLiberado.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chbMesCompletoLiberado.Checked Then

            FechaTemp = New Date(Me.dtpDesdeLiberado.Value.Year, Me.dtpDesdeLiberado.Value.Month, 1)
            Me.dtpDesdeLiberado.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesdeLiberado.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHastaLiberado.Value = FechaTemp
         Else
            Me.dtpDesdeLiberado.Value = DateTime.Today

            Me.dtpHastaLiberado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If

         Me.dtpDesdeLiberado.Enabled = Not Me.chbMesCompletoLiberado.Checked
         Me.dtpHastaLiberado.Enabled = Not Me.chbMesCompletoLiberado.Checked

      Catch ex As Exception

         chbMesCompletoLiberado.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub rbtManualG1_CheckedChanged(sender As Object, e As EventArgs) Handles rbtManualG1.CheckedChanged
      Try
         Me.txtManualMinimoG1.Enabled = rbtManualG1.Checked
         Me.lblMinimoG1.Enabled = rbtManualG1.Checked
         Me.txtManualMaximoG1.Enabled = rbtManualG1.Checked
         Me.lblMaximoG1.Enabled = rbtManualG1.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtManualG2_CheckedChanged(sender As Object, e As EventArgs) Handles rbtManualG2.CheckedChanged
      Try
         Me.txtManualMinimoG2.Enabled = rbtManualG2.Checked
         Me.lblMinimoG2.Enabled = rbtManualG2.Checked
         Me.txtManualMaximoG2.Enabled = rbtManualG2.Checked
         Me.lblMaximoG2.Enabled = rbtManualG2.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtManualG3_CheckedChanged(sender As Object, e As EventArgs) Handles rbtManualG3.CheckedChanged
      Try
         Me.txtManualMinimoG3.Enabled = rbtManualG3.Checked
         Me.lblMinimoG3.Enabled = rbtManualG3.Checked
         Me.txtManualMaximoG3.Enabled = rbtManualG3.Checked
         Me.lblMaximoG3.Enabled = rbtManualG3.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtManualG4_CheckedChanged(sender As Object, e As EventArgs) Handles rbtManualG4.CheckedChanged
      Try
         Me.txtManualG4.Enabled = rbtManualG4.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class