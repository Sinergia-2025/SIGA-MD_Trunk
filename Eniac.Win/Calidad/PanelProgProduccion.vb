Imports Infragistics.Documents.Excel
Public Class PanelProgProduccion
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _tit2 As Dictionary(Of String, String)
   Private _tit3 As Dictionary(Of String, String)
   Private _PermisoEjecucion As Boolean = False

   Private _ocultarFiltros As Boolean = False

   Private _TablaFechas As DataTable = New DataTable()
   Private _oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
   Private _IngresaMetas As Boolean = False
   Private _Totales As DataTable = New DataTable()
   Private pivotResult2 As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo
   Private pivotResult As Reglas.TiposListasProductosProgramacion.GetPanelProgramacionProduccionPivotInfo
   Private pivotResultMyL As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo
   Private pivotResultUrbano As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo

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

         _publicos.CargaComboDesdeEnum(cmbLiberado, GetType(Entidades.Publicos.SiNoTodos))
         cmbLiberado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         _publicos.CargaComboDesdeEnum(cmbEntregados, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbEntregados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         _publicos.CargaComboDesdeEnum(cmbLiberadoPDI, GetType(Entidades.Publicos.SiNoTodos))
         cmbLiberadoPDI.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         ' cmbTipoModelo.Initializar(False, True, True)
         ' Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         '  Me.cmbTipoModelo.SelectedValue = Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.Todos

         Me._publicos.CargaComboTiposModelos(Me.cmbTipoModelo)
         Me.cmbTipoModelo.SelectedIndex = 0

         _IngresaMetas = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "PanelFechasSalida_IngresaMetas")

         Me.dtpDesde.Value = DateTime.Today

         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me.dtpDesdeLiberado.Value = DateTime.Today

         Me.dtpHastaLiberado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me.dtpDesdeSalida.Value = New Date(Me.dtpDesdeSalida.Value.Year, Me.dtpDesdeSalida.Value.Month, 1)
         'Me.dtpDesdeSalida.Value = DateTime.Today

         Me.dtpHastaSalida.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})
         ugDetalle2.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})
         ugDetalle21.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})

         ugDetalle.ContextMenuStrip = MenuContext
         ugDetalle.DisplayLayout.Override.ActiveRowAppearance.Reset()

         Me.TabControl1.SelectedTab = Me.tbpFechasSalida
         _tit3 = GetColumnasVisiblesGrilla(ugDetalle21)

         Me.TabControl1.SelectedTab = Me.tbpInformeFechas
         _tit2 = GetColumnasVisiblesGrilla(ugDetalle2)

         Me.TabControl1.SelectedTab = Me.tbpInforme
         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         'If _ocultarFiltros Then
         '   Me.Text = "Panel de Control Gerencia"
         '   grbFiltros.Visible = False
         '   TryCatched(Sub() CargarGrillaDetalle())
         'End If

         '# Refresco automático
         Dim tiempoRefresco As Integer = Reglas.Publicos.CalidadPanelDeControlTiempoRefresco

         Me.Automatico = Me.chbActualizacionAutomatica.Checked
         Me.txtMinutos.Value = tiempoRefresco
         Me.Timer1.Interval = tiempoRefresco * 60 * 1000
         Me.Timer1.Enabled = Automatico

         Me.TabControl1.TabPages.Remove(tbpInforme)

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
         If Me.ugProgramacion.Rows.Count = 0 Then Exit Sub

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
      Me.chbTipoModelo.Checked = False

      Me.dtpDesdeLiberado.Value = DateTime.Today
      Me.dtpHastaLiberado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompletoLiberado.Checked = False

      Me.dtpDesdeSalida.Value = New Date(DateTime.Today.Year, DateTime.Today.Month, 1)
      Me.dtpHastaSalida.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompletoSalida.Checked = False

      Me.cmbLiberado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbEntregados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbLiberadoPDI.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugProgramacion.DataSource Is Nothing Then
         DirectCast(Me.ugProgramacion.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = "0 Registros"

      Me.btnConsultar.Focus()

      'If _ocultarFiltros Then
      '   grbFiltros.Visible = False
      '   TryCatched(Sub() CargarGrillaDetalle())
      'End If

      'Me.chbActualizacionAutomatica.Checked = True
      'Me.txtMinutos.Value = Reglas.Publicos.CalidadPanelDeControlTiempoRefresco()

   End Sub

   Private Sub CargarGrillaDetalle()

      Dim regla = New Reglas.TiposListasProductosProgramacion()

      pivotResult = regla.GetPanelProgramacionProduccion(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesdeSalida.Value, dtpHastaSalida.Value,
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                0,
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                String.Empty,
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                If(chbTipoModelo.Checked, Integer.Parse(cmbTipoModelo.SelectedValue.ToString()), 0I))

      ugDetalle.DataSource = pivotResult.dtResult

      pivotResult = regla.GetPanelProgramacionProduccionxFechas(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesdeSalida.Value, dtpHastaSalida.Value,
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                0,
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                String.Empty,
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                If(chbTipoModelo.Checked, Integer.Parse(cmbTipoModelo.SelectedValue.ToString()), 0I))

      ugDetalle2.DataSource = pivotResult.dtResult

      'Me.MoverFechasSalida(pivotResult, ugDetalle)

      'Me.FiltroFechaSalida(pivotResult, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalle)

      Me.Programacion(pivotResult, ugDetalle, ugProgramacion)

      'Me.ResumenFechaSalida(pivotResult, ugDetalle, ugeResumen, ugeTotales, ugeDiasHabiles)

      'Me.FormatearGrilla(ugDetalle, _tit)
      Me.FormatearGrilla(ugDetalle2, _tit2)


      Dim regla2 = New Reglas.ListasControlProductos()

      pivotResult2 = regla2.GetLeadTimeListasControlTipo(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                0,
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                String.Empty,
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                0)

      ugDetalle21.DataSource = pivotResult2.dtResult

      Me.MoverFechasSalida2(pivotResult2, ugDetalle21)
      Me.FiltroFechaSalida(pivotResult2, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalle21)
      Me.FormatearGrilla(ugDetalle21, _tit2)
      Me.ColorProgramacion(pivotResult2)
      Me.ColorProgramacion2(pivotResult)

      If pivotResult.dtResult.Rows.Count > 0 Then
         Me.btnConsultar.Focus()
      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub ColorProgramacion(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      For Each dr As UltraGridRow In ugDetalle2.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
               For Each dr2 As UltraGridRow In ugDetalle21.Rows
                  If dr.Cells("IdProducto").Value.ToString() = dr2.Cells("IdProducto").Value.ToString() Then
                     If Not String.IsNullOrEmpty(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
                        If Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).Date.AddHours(23).AddMinutes(59).AddSeconds(59) <
                                               Date.Parse(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
                           dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                           'ElseIf Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).ToShortDateString =
                           '                       Date.Parse(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).ToShortDateString Then
                           '   dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, Color.Khaki)
                        Else
                           dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightGreen)
                        End If
                     Else

                        dr.Cells(drColumnas("NombreColumma").ToString()).Color(Nothing, Color.LightCoral)
                     End If

                  End If
               Next
            End If
         Next
      Next
   End Sub

   Private Sub ColorProgramacion2(pivotResult As Reglas.TiposListasProductosProgramacion.GetPanelProgramacionProduccionPivotInfo)

      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty

      For Each dr As UltraGridRow In ugProgramacion.Rows
         For Each dr2 As UltraGridRow In ugDetalle21.Rows
            For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

               colName = drColumnas("NombreColumma").ToString()
               colName2 = drColumnas("NombreColumma").ToString() + "-Modelo"
               colName3 = drColumnas("NombreColumma").ToString() + "-Cliente"

               If Not String.IsNullOrEmpty(dr.Cells(colName).Value.ToString()) Then

                  If dr.Cells(colName).Value.ToString() = dr2.Cells("IdProducto").Value.ToString() Then
                     If Not String.IsNullOrEmpty(dr2.Cells(colName).Value.ToString()) Then
                        If Date.Parse(dr.Cells("FechaSalida").Value.ToString()).Date <
                                               Date.Parse(dr2.Cells(colName).Value.ToString()).Date Then

                           'dr.Cells(colName).Color(Nothing, Color.LightCoral)
                           'dr.Cells(colName2).Color(Nothing, Color.LightCoral)
                           'dr.Cells(colName3).Color(Nothing, Color.LightCoral)
                           dr.Cells(colName).Color(Nothing, Color.Khaki)
                           dr.Cells(colName2).Color(Nothing, Color.Khaki)
                           dr.Cells(colName3).Color(Nothing, Color.Khaki)

                        Else
                           'dr.Cells(colName).Color(Nothing, Color.LightGreen)
                           'dr.Cells(colName2).Color(Nothing, Color.LightGreen)
                           'dr.Cells(colName3).Color(Nothing, Color.LightGreen)
                           dr.Cells(colName).Color(Nothing, Color.Khaki)
                           dr.Cells(colName2).Color(Nothing, Color.Khaki)
                           dr.Cells(colName3).Color(Nothing, Color.Khaki)

                        End If
                     Else
                        'dr.Cells(colName).Color(Nothing, Color.LightCoral)
                        'dr.Cells(colName2).Color(Nothing, Color.LightCoral)
                        'dr.Cells(colName3).Color(Nothing, Color.LightCoral)
                        'dr.Cells(colName).Color(Nothing, Color.Khaki)
                        'dr.Cells(colName2).Color(Nothing, Color.Khaki)
                        'dr.Cells(colName3).Color(Nothing, Color.Khaki)
                     End If

                  End If

               End If
            Next
         Next
      Next
   End Sub

   Private Sub FormatearGrilla(Grilla As UltraGrid, Tit As Dictionary(Of String, String))
      Dim pos As Integer = AjustarColumnasGrilla(Grilla, Tit)
      Grilla.InicializaTotales()
      Grilla.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed
      Grilla.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
      Grilla.DisplayLayout.Bands(0).Summaries.Clear()

      With Grilla.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            Dim colName = drColumnas("NombreColumma").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, 100, HAlign.Center, , "dd/MM/yyyy")
            .Columns(colName).Color(Nothing, Color.LightBlue)
            .Columns(colName).Header.Appearance.BackColor = Color.LightBlue

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If
         Next
      End With

      'ugDetalle.DisplayLayout.Bands(0).Columns("CalidadFechaLiberado").FormatearColumna("Fecha Liberado", pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")
      'ugDetalle.DisplayLayout.Bands(0).Columns("CalidadFechaLiberadoPDI").FormatearColumna("Fecha Liberado PDI", pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")

      'If Me.chbFechaEntrega.Checked Then
      '   Grilla.DisplayLayout.Bands(0).Columns("CalidadFechaEntregado").FormatearColumna("Fecha Entregado", pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")
      'End If

      ' Me.ColumnasASumar(ugDetalle)

      Grilla.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False

   End Sub
   Private Sub MoverFechasSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo, Grilla As UltraGrid)

      Dim SigColumna As Integer
      Dim FechaInicio As DateTime
      Dim Entro As Boolean = False
      Dim FechasSalida As DataTable = New DataTable()
      Dim dr2 As DataRow

      For Each dr As UltraGridRow In Grilla.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

            Dim colName = drColumnas("NombreColumma").ToString()

            If Not String.IsNullOrEmpty(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then

               If Not Entro Then
                  FechaInicio = Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString())
                  Entro = True
               End If

               SigColumna = dr.Cells(drColumnas("NombreColumma").ToString()).Column.Index + 1

               If colName = "IdListaControlTipo__11" Then
                  If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberado").Value.ToString()) Then
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells("CalidadFechaLiberado").Value
                  Else
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                  End If
                  Continue For
               End If

               If colName = "IdListaControlTipo__8" Then
                  If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()) Then
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells("CalidadFechaLiberadoPDI").Value
                  Else
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                  End If
                  Continue For
               End If

               If IsDate(dr.Cells(SigColumna).Value.ToString()) Then
                  dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells(SigColumna).Value
               Else
                  If IsNumeric(dr.Cells(SigColumna).Value.ToString()) Then
                     If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()) Then
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells("CalidadFechaLiberadoPDI").Value
                     Else
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                     End If
                     Exit For
                  Else
                     Dim SigSigColumna As Integer = SigColumna + 1
                     If Not IsNumeric(dr.Cells(SigSigColumna).Value.ToString()) Then
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells(SigSigColumna).Value
                     Else
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                     End If
                     Continue For
                  End If
               End If
            End If
         Next
         Entro = False
      Next
   End Sub

   Private Sub MoverFechasSalida2(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo, Grilla As UltraGrid)

      Dim SigColumna As Integer
      Dim FechaInicio As DateTime
      Dim Entro As Boolean = False
      Dim FechasSalida As DataTable = New DataTable()
      Dim dr2 As DataRow

      For Each dr As UltraGridRow In Grilla.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

            Dim colName = drColumnas("NombreColumma").ToString()

            If Not String.IsNullOrEmpty(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then

               If Not Entro Then
                  FechaInicio = Date.Parse(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString())
                  Entro = True
               End If

               SigColumna = dr.Cells(drColumnas("NombreColumma").ToString()).Column.Index + 1

               If colName = "IdListaControlTipo__11" Then
                  If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberado").Value.ToString()) Then
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells("CalidadFechaLiberado").Value
                  Else
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                  End If
                  Continue For
               End If

               If colName = "IdListaControlTipo__8" Then
                  If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()) Then
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells("CalidadFechaLiberadoPDI").Value
                  Else
                     dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                  End If
                  Continue For
               End If

               If IsDate(dr.Cells(SigColumna).Value.ToString()) Then
                  dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells(SigColumna).Value
               Else
                  If IsNumeric(dr.Cells(SigColumna).Value.ToString()) Then
                     If Not String.IsNullOrEmpty(dr.Cells("CalidadFechaLiberadoPDI").Value.ToString()) Then
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells("CalidadFechaLiberadoPDI").Value
                     Else
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                     End If
                     Exit For
                  Else
                     Dim SigSigColumna As Integer = SigColumna + 1
                     If Not IsNumeric(dr.Cells(SigSigColumna).Value.ToString()) Then
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = dr.Cells(SigSigColumna).Value
                     Else
                        dr.Cells(drColumnas("NombreColumma").ToString()).Value = DBNull.Value
                     End If
                     Continue For
                  End If
               End If
            End If
         Next
         Entro = False
      Next
   End Sub

   Private Sub FiltroFechaSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                  FechaSalidaDesde As Date?, FechaSalidahasta As Date?, Grilla As UltraGrid)


      Dim Datos As DataTable = DirectCast(Grilla.DataSource, DataTable)


      'Dim query As EnumerableRowCollection(Of DataRow) = From order In Datos.AsEnumerable() Where order.Field(Of DateTime)("Mecanica") > FechaSalidaDesde _
      '                                                                                      And order.Field(Of DateTime)("Mecanica") < FechaSalidahasta Select order

      'Dim view As DataView = query.AsDataView()

      'ugDetalle.DataSource = view

      'view.RowFilter = Nothing



      Dim entroFecha As Boolean = False
      Dim cont As Integer = 0
      '' _TablaFechas = Datos.Copy()

      For Each dr As DataRow In Datos.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
               If IsDate(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
                  If FechaSalidaDesde < Date.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) And
                     FechaSalidahasta > Date.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
                     entroFecha = True
                  Else
                     dr(drColumnas("NombreColumma").ToString()) = DBNull.Value
                  End If

               End If
            End If
         Next
         If Not entroFecha Then
            dr.Delete()
         End If
         entroFecha = False
      Next

      Grilla.DataSource = Datos

   End Sub
   Private Function GetDatesBetween(FechaDesde As Date, fechaHasta As Date) As Date()

      Dim allDates As List(Of DateTime) = New List(Of DateTime)()
      Dim fecha As DateTime = FechaDesde
      While fecha <= fechaHasta
         allDates.Add(fecha)
         fecha = fecha.AddDays(1)
      End While

      Return allDates.ToArray()

   End Function

   Private Sub Programacion(pivotResult As Reglas.TiposListasProductosProgramacion.GetPanelProgramacionProduccionPivotInfo,
                                 Grilla As UltraGrid, GrillaSoloCantidades As UltraGrid)

      Dim Datos As DataTable = DirectCast(Grilla.DataSource, DataTable)

      Dim Programacion As DataTable = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty
      Dim colName4 As String = String.Empty


      Programacion.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      '  Resumen.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

         colName = drColumnas("NombreColumma").ToString()
         Programacion.Columns.Add(colName, System.Type.GetType("System.String"))
         colName2 = drColumnas("NombreColumma").ToString() + "-Modelo"
         Programacion.Columns.Add(colName2, System.Type.GetType("System.String"))
         colName3 = drColumnas("NombreColumma").ToString() + "-Cliente"
         Programacion.Columns.Add(colName3, System.Type.GetType("System.String"))
         colName4 = drColumnas("NombreColumma").ToString() + "-Espacio"
         Programacion.Columns.Add(colName4, System.Type.GetType("System.String"))
      Next
      Programacion.Columns.Add("FechaLiberado", System.Type.GetType("System.DateTime"))

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      For Each fec As Date In dates
         'dr1 = Resumen.NewRow()
         'dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
         'For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         '   dr1(drColumnas("NombreListaControlTipo").ToString()) = 0
         'Next
         'Resumen.Rows.Add(dr1)
      Next

      Dim oDiaLabNoLab As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables()
      Dim DiaLabNoLab As Entidades.DiaLaborableNoLaborable = New Entidades.DiaLaborableNoLaborable()

      For Each dr2 As DataRow In Datos.Rows

         dr1 = Programacion.NewRow()
         dr1("FechaSalida") = Date.Parse(dr2("Dia").ToString()).ToString("dd/MM/yyyy")
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            dr1(drColumnas("NombreColumma").ToString()) = String.Empty
         Next
         dr1("FechaLiberado") = DBNull.Value
         Programacion.Rows.Add(dr1)
      Next

      'DiaLabNoLab = oDiaLabNoLab.GetUno(Date.Parse(dr("FechaSalida").ToString()))
      'If DiaLabNoLab IsNot Nothing Then
      '   dr("DiasLabNoLab") = IIf(DiaLabNoLab.Laborable, "H", "NH")
      'Else
      '   dr("DiasLabNoLab") = String.Empty
      'End If
      Dim Bajar As Boolean = False

      For Each dr2 As DataRow In Datos.Rows

         For Each dr As DataRow In Programacion.Rows

            If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2("Dia").ToString()).ToString("dd/MM/yyyy") Then

               For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

                  colName = drColumnas("NombreColumma").ToString()
                  colName2 = drColumnas("NombreColumma").ToString() + "-Modelo"
                  colName3 = drColumnas("NombreColumma").ToString() + "-Cliente"

                  If Not String.IsNullOrEmpty(dr2(drColumnas("NombreColumma").ToString()).ToString()) Then

                     If String.IsNullOrEmpty(dr(drColumnas("NombreColumma").ToString()).ToString()) Then

                        dr(colName) = dr2(drColumnas("NombreColumma").ToString()).ToString()
                        dr(colName2) = dr2("NombreProductoModelo").ToString()
                        dr(colName3) = dr2("NombreCliente").ToString()

                        Bajar = False
                        Exit For
                     Else

                        Bajar = True
                        Exit For
                     End If

                  End If
               Next

               'If Not String.IsNullOrEmpty(dr2("CalidadFechaLiberado").ToString()) Then
               '   dr("FechaLiberado") = DateTime.Parse(dr2("CalidadFechaLiberado").ToString())
               'End If

            Else
               Continue For
            End If
            If Bajar Then
               Continue For
            Else
               Exit For
            End If

         Next

      Next

      Programacion.AcceptChanges()

      Dim Borra As Boolean = False
      For Each dr As DataRow In Programacion.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
               Borra = True
               Exit For
            End If
         Next
         If Not Borra Then
            dr.Delete()
         End If
         Borra = False

      Next

      GrillaSoloCantidades.DataSource = Programacion

      Dim pos As Integer = AjustarColumnasGrilla(GrillaSoloCantidades, _tit)

      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha", pos, 60, HAlign.Center, , "dd/MM/yyyy")
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").Header.Appearance.TextHAlign = HAlign.Center
      GrillaSoloCantidades.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").MergedCellStyle = MergedCellStyle.Always
      '   GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("Día H/NH", pos, 60, HAlign.Center, True)
      GrillaSoloCantidades.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True

      GrillaSoloCantidades.InicializaTotales()
      GrillaSoloCantidades.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
      GrillaSoloCantidades.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False


      GrillaSoloCantidades.DisplayLayout.Bands(0).Summaries.Clear()

      Dim AnchoColumna As Integer = 0
      With GrillaSoloCantidades.DisplayLayout.Bands(0)

         'For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         '   colName = drColumnas("NombreListaControlTipo").ToString()
         '   .Groups.Add(colName, colName)
         'Next

         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            AnchoColumna = 90
            colName = drColumnas("NombreColumma").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)
            .Columns(colName).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns(colName).Header.Appearance.FontData.SizeInPoints = 10
            .Columns(colName).Header.Appearance.TextHAlign = HAlign.Center
            colName2 = drColumnas("NombreColumma").ToString() + "-Modelo"
            .Columns(colName2).FormatearColumna("Modelo", pos, 70, HAlign.Left)
            colName3 = drColumnas("NombreColumma").ToString() + "-Cliente"
            .Columns(colName3).FormatearColumna("Cliente", pos, 120, HAlign.Left)
            colName4 = drColumnas("NombreColumma").ToString() + "-Espacio"
            .Columns(colName4).FormatearColumna("", pos, 8, HAlign.Right)

            GrillaSoloCantidades.AgregarTotalCustomColumna(colName, New CustomSummaries.SummaryCalidadPanelProgramacionProduccion(pivotResult.dtColumnas))

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 11 Then
                  .Columns(colName).Hidden = True
                  .Columns(colName2).Hidden = True
                  .Columns(colName3).Hidden = True
                  .Columns(colName4).Hidden = True

               End If
            End If

            .Summaries.Item(colName).DisplayFormat = "{0}"
            .Summaries.Item(colName).Appearance.TextHAlign = HAlign.Center

         Next
         .Columns("FechaLiberado").FormatearColumna("Liberado", pos, 80, HAlign.Center, , "dd/MM/yyyy")

      End With

      For Each dr As UltraGridRow In GrillaSoloCantidades.Rows
         If Date.Parse(dr.Cells("FechaSalida").Value.ToString()).ToString("dd/MM/yyyy") = Me.dtpFechaCorte.Value.ToString("dd/MM/yyyy") Then
            dr.Appearance.BorderColor = Color.Red
         End If
      Next

   End Sub


   Private Sub ColumnasASumar(grilla As UltraGrid)

      Dim columnToSummarize2 As UltraGridColumn = grilla.DisplayLayout.Bands(0).Columns("LeadTimeLiberado")
      Dim summary2 As SummarySettings = grilla.DisplayLayout.Bands(0).Summaries.Add("LeadTimeLiberado", SummaryType.Count, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

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

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesdeSalida.Value, dtpHastaSalida.Value)

         If Me.chbProducto.Checked Then
            .AppendFormat(" Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If


      End With
      Return filtro.ToString()
   End Function

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

   Private Sub chbActualizacionAutomatica_CheckedChanged(sender As Object, e As EventArgs)

   End Sub

   Private Sub chbLiberado_CheckedChanged(sender As Object, e As EventArgs) Handles chbLiberado.CheckedChanged

      TryCatched(Sub()
                    chbMesCompletoLiberado.Enabled = chbLiberado.Checked
                    dtpDesdeLiberado.Enabled = chbLiberado.Checked
                    dtpHastaLiberado.Enabled = chbLiberado.Checked
                 End Sub)

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

   Private Sub chbFechaSalida_CheckedChanged(sender As Object, e As EventArgs)
      'TryCatched(Sub()
      '              chbMesCompletoSalida.Enabled = chbFechaSalida.Checked
      '              dtpDesdeSalida.Enabled = chbFechaSalida.Checked
      '              dtpHastaSalida.Enabled = chbFechaSalida.Checked
      '           End Sub)

   End Sub

   Private Sub chbMesCompletoSalida_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoSalida.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chbMesCompletoSalida.Checked Then

            FechaTemp = New Date(Me.dtpDesdeSalida.Value.Year, Me.dtpDesdeSalida.Value.Month, 1)
            Me.dtpDesdeSalida.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesdeSalida.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHastaSalida.Value = FechaTemp
         Else
            Me.dtpDesdeSalida.Value = DateTime.Today

            Me.dtpHastaSalida.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If

         Me.dtpDesdeSalida.Enabled = Not Me.chbMesCompletoSalida.Checked
         Me.dtpHastaSalida.Enabled = Not Me.chbMesCompletoSalida.Checked

      Catch ex As Exception

         chbMesCompletoSalida.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub

   Private Sub chbOcultarFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chbOcultarFiltros.CheckedChanged
      Try
         Me.SplitContainer1.Panel1Collapsed = Not Me.chbOcultarFiltros.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugeResumen_AfterCellUpdate(sender As Object, e As CellEventArgs)
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim MetaCoche As Integer = 0
         If IsNumeric(e.Cell.Value) Then
            MetaCoche = Integer.Parse(e.Cell.Value.ToString())
         Else
            MessageBox.Show("Ingrese valor numérico", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         ' Dim dr As DataRow = ugeResumen.FilaSeleccionada(Of DataRow)()
         Dim dr1 As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
         Dim TipoLista As Integer = New Reglas.ListasControlTipos().GetUnoxNombre(e.Cell.Column.Key.ToString().Replace("-Meta", "").ToString()).IdListaControlTipo
         Dim Dia As Date = Date.Parse(dr1("FechaSalida").ToString())
         Dim oMetas As Reglas.TiposListasMetas = New Reglas.TiposListasMetas()
         Dim Meta As Entidades.TipoListaMeta = New Entidades.TipoListaMeta

         Meta = oMetas.GetUno(TipoLista, Dia)

         If Meta Is Nothing Then
            Meta = New Entidades.TipoListaMeta
            With Meta
               .IdListaControlTipo = TipoLista
               .Dia = Dia
               .MetaCoches = MetaCoche
               .IdUsuario = actual.Nombre
               .FechaModificacion = Date.Now
            End With
            oMetas.Insertar(Meta)
         Else
            Meta.MetaCoches = MetaCoche
            Meta.IdUsuario = actual.Nombre
            Meta.FechaModificacion = Date.Now
            oMetas.Actualizar(Meta)
         End If

         Dim resta1 As Integer = e.Cell.Column.Index - 1
         Dim dif As Integer = e.Cell.Column.Index + 1
         If e.Cell.Row.ListObject IsNot Nothing Then
            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
            dr(dif) = Integer.Parse(dr(resta1).ToString()) - Integer.Parse(dr(e.Cell.Column.Index).ToString())
         End If

         'Me.ResumenTotales(pivotResult, ugeTotales)

         'Me.ResumenDiasHabilesNoHabiles(pivotResult, ugeDiasHabiles)

         ' Me.CargarGrillaDetalle()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbActualizacionAutomatica_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbActualizacionAutomatica.CheckedChanged
      Try

         Me.Automatico = Me.chbActualizacionAutomatica.Checked
         Me.Timer1.Enabled = Automatico

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
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

   Private Sub tsmExcelInforme_Click(sender As Object, e As EventArgs) Handles tsmExcelInforme.Click
      Try
         If Me.ugDetalle2.Rows.Count = 0 Then Exit Sub
         ugDetalle2.Exportar(Me.Name & "_InformeFechasProgramacion.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmPdfInforme_Click(sender As Object, e As EventArgs) Handles tsmPdfInforme.Click
      Try
         If Me.ugDetalle2.Rows.Count = 0 Then Exit Sub
         ugDetalle2.Exportar(Me.Name & "_InformeFechasProgramacion.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
   '   If TabControl1.SelectedTab Is tbpInforme Then
   '      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
   '   End If
   'End Sub

   Private Sub chbTipoModelo_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoModelo.CheckedChanged
      Me.cmbTipoModelo.Enabled = Me.chbTipoModelo.Checked
      If Not Me.chbTipoModelo.Checked Then
         Me.cmbTipoModelo.SelectedIndex = 0
      End If
   End Sub

   Private Sub tsmExcelResumen_Click(sender As Object, e As EventArgs) Handles tsmExcelResumen.Click
      '  Try
      Try
         If Me.ugProgramacion.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
            myWorksheet.Rows(0).Cells(0).Value = Me.Text

         Me.sfdExportar.FileName = Me.Name & "__Resumen.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
            If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               ' Dim AltoGrilla As Integer = 5 + ugeResumen.Rows.Count
               Me.UltraGridExcelExporter1.Export(ugProgramacion, myWorksheet, 2, 0)
               'Me.UltraGridExcelExporter1.Export(ugeTotales, myWorksheet, AltoGrilla, 1) '37
               'Me.UltraGridExcelExporter1.Export(ugeTotalesMes, myWorksheet, AltoGrilla + 5, 1) '42
               'Me.UltraGridExcelExporter1.Export(ugeDiasHabiles, myWorksheet, AltoGrilla + 10, 1) '47

               myWorkbook.Save(Me.sfdExportar.FileName)
               End If
            End If
            '  ugeResumen.Exportar(Me.Name & "_Resumen.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
         Catch ex As Exception
            ShowError(ex)
         End Try
         'If Me.ugProgramacion.Rows.Count = 0 Then Exit Sub
      'ugProgramacion.Exportar(Me.Name & "_Programacion.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      'Catch ex As Exception
      '   ShowError(ex)
      'End Try
   End Sub

   Private Sub tsmPdfResumen_Click(sender As Object, e As EventArgs) Handles tsmPdfResumen.Click
      Try
         If Me.ugProgramacion.Rows.Count = 0 Then Exit Sub
         ugProgramacion.Exportar(Me.Name & "_Programacion.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ultraGridExcelExporter1_CellExported(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs) Handles UltraGridExcelExporter1.CellExported
      Dim cell As UltraGridCell = e.GridRow.Cells(e.GridColumn)
      Dim mergedCells As UltraGridCell() = cell.GetMergedCells()

      If mergedCells IsNot Nothing Then
         Dim isLastCell As Boolean = True

         For Each mergedCell As UltraGridCell In mergedCells

            If cell.Row.Index < mergedCell.Row.Index Then
               isLastCell = False
               Exit For
            End If
         Next

         If isLastCell Then
            Dim rowIndex As Integer = e.CurrentRowIndex
            Dim colIndex As Integer = e.CurrentColumnIndex
            e.CurrentWorksheet.MergedCellsRegions.Add(rowIndex - (mergedCells.Length - 1), colIndex, rowIndex, colIndex)
         End If
      End If
   End Sub


End Class