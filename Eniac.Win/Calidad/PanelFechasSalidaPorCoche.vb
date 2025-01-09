Imports Infragistics.Documents.Excel
Public Class PanelFechasSalidaPorCoche
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _PermisoEjecucion As Boolean = False

   Private _ocultarFiltros As Boolean = False

   Private _TablaFechas As DataTable = New DataTable()
   Private _oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
   Private _IngresaMetas As Boolean = False
   Private _Totales As DataTable = New DataTable()
   Private pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo
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

         cmbTipoModelo.Initializar(False, True, True)
         ' Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         ' Me._publicos.CargaComboTiposModelos(Me.cmbTipoModelo)
         Me.cmbTipoModelo.SelectedValue = Convert.ToInt32(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.Todos).ToString()
         ' Me.cmbTipoModelo.SelectedIndex = 0

         ' _IngresaMetas = _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "PanelFechasSalida_IngresaMetas")

         Me.dtpDesde.Value = DateTime.Today

         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me.dtpDesdeLiberado.Value = DateTime.Today

         Me.dtpHastaLiberado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me.dtpDesdeSalida.Value = New Date(Me.dtpDesdeSalida.Value.Year, Me.dtpDesdeSalida.Value.Month, 1)
         'Me.dtpDesdeSalida.Value = DateTime.Today

         Me.dtpHastaSalida.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})
         ugDetalleMyL.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})
         ugDetalleURBANO.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente"})

         ugDetalle.ContextMenuStrip = MenuContext
         ugDetalle.DisplayLayout.Override.ActiveRowAppearance.Reset()
         ugDetalleMyL.ContextMenuStrip = MenuContext
         ugDetalleMyL.DisplayLayout.Override.ActiveRowAppearance.Reset()
         ugDetalleURBANO.ContextMenuStrip = MenuContext
         ugDetalleURBANO.DisplayLayout.Override.ActiveRowAppearance.Reset()

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

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

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcelInforme.Click
      Try
         If Me.ugSalidaPorCoche1.Rows.Count = 0 Then Exit Sub
         ugSalidaPorCoche1.Exportar(Me.Name & "_FechasSalidaPorCoche.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDFInforme.Click
      Try
         If Me.ugSalidaPorCoche1.Rows.Count = 0 Then Exit Sub
         ugSalidaPorCoche1.Exportar(Me.Name & "_FechasSalidaPorCoche.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
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
         DirectCast(Me.ugDetalleURBANO.DataSource, DataTable).Rows.Clear()
         DirectCast(Me.ugDetalleMyL.DataSource, DataTable).Rows.Clear()
         DirectCast(Me.ugSalidaPorCoche1.DataSource, DataTable).Rows.Clear()
         DirectCast(Me.ugSalidaPorCocheUrb1.DataSource, DataTable).Rows.Clear()
         DirectCast(Me.ugSalidaPorCocheMyL1.DataSource, DataTable).Rows.Clear()

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

      Dim regla = New Reglas.ListasControlProductos()

      pivotResult = regla.GetLeadTimeListasControlTipo(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                0,
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                String.Empty,
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                0)

      ugDetalle.DataSource = pivotResult.dtResult

      pivotResultMyL = regla.GetLeadTimeListasControlTipo(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                0,
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                String.Empty,
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                2)

      ugDetalleMyL.DataSource = pivotResultMyL.dtResult

      pivotResultUrbano = regla.GetLeadTimeListasControlTipo(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                 dtpDesdeLiberado.Valor(chbLiberado), dtpHastaLiberado.Valor(chbLiberado),
                                                                0,
                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                String.Empty,
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbEntregados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                cmbLiberado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                                1)

      ugDetalleURBANO.DataSource = pivotResultUrbano.dtResult

      '  Me.Programacion(pivotResult, ugDetalle, ugSalidaPorCoche)

      Me.MoverFechasSalida(pivotResult, ugDetalle)
      Me.MoverFechasSalida(pivotResultMyL, ugDetalleMyL)
      Me.MoverFechasSalida(pivotResultUrbano, ugDetalleURBANO)

      Me.FiltroFechaSalida(pivotResult, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalle)
      Me.FiltroFechaSalida(pivotResultMyL, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalleMyL)
      Me.FiltroFechaSalida(pivotResultUrbano, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalleURBANO)

      Me.ResumenCantidades(pivotResult, ugDetalle, ugeSoloCantidades)
      Me.ResumenCantidades(pivotResultMyL, ugDetalleMyL, ugeSoloCantidadesMyL)
      Me.ResumenCantidades(pivotResultUrbano, ugDetalleURBANO, ugeSoloCantidadesURBANO)


      Me.SalidaPorCoche(pivotResult, ugeSoloCantidades, ugSalidaPorCoche1)
      Me.SalidaPorCoche(pivotResultUrbano, ugeSoloCantidadesURBANO, ugSalidaPorCocheUrb1)
      Me.SalidaPorCoche(pivotResultMyL, ugeSoloCantidadesMyL, ugSalidaPorCocheMyL1)

      Me.FormatearGrilla(ugDetalle)
      Me.FormatearGrilla(ugDetalleMyL)
      Me.FormatearGrilla(ugDetalleURBANO)

      If pivotResult.dtResult.Rows.Count > 0 Then
         Me.btnConsultar.Focus()
      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub FormatearGrilla(Grilla As UltraGrid)
      Dim pos As Integer = AjustarColumnasGrilla(Grilla, _tit)
      Grilla.InicializaTotales()
      Grilla.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed
      Grilla.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
      Grilla.DisplayLayout.Bands(0).Summaries.Clear()

      With Grilla.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            Dim colName = drColumnas("NombreColumma").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
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

      If Me.chbFechaEntrega.Checked Then
         Grilla.DisplayLayout.Bands(0).Columns("CalidadFechaEntregado").FormatearColumna("Fecha Entregado", pos, 94, HAlign.Center, , "dd/MM/yyyy HH:mm")
      End If

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

   Private Sub ResumenCantidades(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                 Grilla As UltraGrid, GrillaSoloCantidades As UltraGrid)

      Dim Datos As DataTable = DirectCast(ugDetalle.DataSource, DataTable)

      Dim Resumen As DataTable = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty

      Resumen.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      Resumen.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      Resumen.Columns.Add("NombreProductoModeloTipo", System.Type.GetType("System.String"))
      Resumen.Columns.Add("NombreCliente", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         Resumen.Columns.Add(colName, System.Type.GetType("System.String"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      'For Each fec As Date In dates
      '   dr1 = Resumen.NewRow()
      '   dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
      '   For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
      '      dr1(drColumnas("NombreListaControlTipo").ToString()) = ""
      '   Next
      '   Resumen.Rows.Add(dr1)
      'Next

      'Dim oDiaLabNoLab As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables()
      'Dim DiaLabNoLab As Entidades.DiaLaborableNoLaborable = New Entidades.DiaLaborableNoLaborable()

      '  For Each dr As DataRow In Resumen.Rows

      '    DiaLabNoLab = oDiaLabNoLab.GetUno(Date.Parse(dr("FechaSalida").ToString()))
      'If DiaLabNoLab IsNot Nothing Then
      '   dr("DiasLabNoLab") = IIf(DiaLabNoLab.Laborable, "H", "NH")
      'Else
      '   dr("DiasLabNoLab") = String.Empty
      'End If  


      For Each dr2 As UltraGridRow In Grilla.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

            If Not String.IsNullOrEmpty(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then

               dr1 = Resumen.NewRow()
               dr1("FechaSalida") = Date.Parse(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).ToString("dd/MM/yyyy")
               dr1("NombreProducto") = dr2.Cells("NombreProducto").Value.ToString()
               dr1("NombreProductoModeloTipo") = dr2.Cells("NombreProductoModeloTipo").Value.ToString()
               dr1("NombreCliente") = dr2.Cells("NombreCliente").Value.ToString()
               dr1(drColumnas("NombreListaControlTipo").ToString()) = dr2.Cells("IdProducto").Value.ToString()
               Resumen.Rows.Add(dr1)
            End If
            'If Not String.IsNullOrEmpty(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
            '   If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).ToString("dd/MM/yyyy") Then
            '      dr(drColumnas("NombreListaControlTipo").ToString()) = Integer.Parse(dr(drColumnas("NombreListaControlTipo").ToString()).ToString()) + 1
            '   End If

         Next
      Next
      '  Next

      GrillaSoloCantidades.DataSource = Resumen

      Dim pos As Integer = AjustarColumnasGrilla(GrillaSoloCantidades, _tit)

      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 98, HAlign.Center, , "dd/MM/yyyy")
      GrillaSoloCantidades.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("NombreProducto").FormatearColumna("Modelo", pos, 192)
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("NombreProductoModeloTipo").FormatearColumna("Tipo Modelo", pos, 189)
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("NombreCliente").FormatearColumna("CLiente", pos, 164)

      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").SortIndicator = SortIndicator.Ascending

      GrillaSoloCantidades.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaSoloCantidades.InicializaTotales()
      GrillaSoloCantidades.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
      GrillaSoloCantidades.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
      GrillaSoloCantidades.DisplayLayout.Bands(0).Summaries.Clear()
      GrillaSoloCantidades.AgregarFiltroEnLinea({"NombreProducto", "NombreProductoModeloTipo", "NombreCliente"})

      Dim AnchoColumna As Integer = 0
      With GrillaSoloCantidades.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            AnchoColumna = 80
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If
            'Totales
            '  GrillaSoloCantidades.AgregarTotalSumaColumna(colName, "{0:N0}")
         Next
      End With

   End Sub


   Private Sub ResumenFechaSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                  grilla As UltraGrid, GrillaResumen As UltraGridEditable, GrillaTotales As UltraGrid,
                                  GrillaDiasHabiles As UltraGrid, IdProductoModeloTipo As Integer)

      Dim Datos As DataTable = DirectCast(grilla.DataSource, DataTable)

      Dim Resumen As DataTable = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty

      Resumen.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      Resumen.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      For Each fec As Date In dates
         dr1 = Resumen.NewRow()
         dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            dr1(drColumnas("NombreListaControlTipo").ToString()) = 0
            dr1(drColumnas("NombreListaControlTipo").ToString() + "-Meta") = 0
            dr1(drColumnas("NombreListaControlTipo").ToString() + "-Dif") = 0

         Next
         Resumen.Rows.Add(dr1)
      Next

      Dim oDiaLabNoLab As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables()
      Dim DiaLabNoLab As Entidades.DiaLaborableNoLaborable = New Entidades.DiaLaborableNoLaborable()


      For Each dr As DataRow In Resumen.Rows

         DiaLabNoLab = oDiaLabNoLab.GetUno(Date.Parse(dr("FechaSalida").ToString()))
         If DiaLabNoLab IsNot Nothing Then
            dr("DiasLabNoLab") = IIf(DiaLabNoLab.Laborable, "H", "NH")
         Else
            dr("DiasLabNoLab") = String.Empty
         End If

         For Each dr2 As UltraGridRow In grilla.Rows

            For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
               If Not String.IsNullOrEmpty(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then

                  If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).ToString("dd/MM/yyyy") Then
                     dr(drColumnas("NombreListaControlTipo").ToString()) = Integer.Parse(dr(drColumnas("NombreListaControlTipo").ToString()).ToString()) + 1
                  End If

               End If
            Next
         Next

         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

            'Dim Meta As Entidades.TipoListaMeta = New Reglas.TiposListasMetas().GetUno(Integer.Parse(drColumnas("IdListaControlTipo").ToString()), Date.Parse(dr("FechaSalida").ToString()))
            'If Meta IsNot Nothing Then
            '   dr(drColumnas("NombreListaControlTipo").ToString() + "-Meta") = Meta.MetaCoches
            'End If

            Dim Meta As DataTable = New Reglas.TiposListasProductosProgramacion().GetTotalMetasPorDia(Integer.Parse(drColumnas("IdListaControlTipo").ToString()),
                                                                                                    Date.Parse(dr("FechaSalida").ToString()),
                                                                                                    IdProductoModeloTipo)

            If Meta.Rows.Count > 0 Then
               dr(drColumnas("NombreListaControlTipo").ToString() + "-Meta") = Meta.Rows.Count
            End If


            dr(drColumnas("NombreListaControlTipo").ToString() + "-Dif") = Integer.Parse(dr(drColumnas("NombreListaControlTipo").ToString()).ToString()) - Integer.Parse(dr(drColumnas("NombreListaControlTipo").ToString() + "-Meta").ToString())
         Next

      Next

      'Dim oMetas As Reglas.TiposListasMetas = New Reglas.TiposListasMetas()
      'Dim Metas As DataTable = oMetas.GetMetas(starting, ending)

      GrillaResumen.DataSource = Resumen

      Dim pos As Integer = AjustarColumnasGrilla(GrillaResumen, _tit)

      GrillaResumen.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 80, HAlign.Center, , "dd/MM/yyyy")
      GrillaResumen.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaResumen.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("Día H/NH", pos, 60, HAlign.Center)
      GrillaResumen.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center
      GrillaResumen.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaResumen.InicializaTotales()
      GrillaResumen.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
      GrillaResumen.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
      GrillaResumen.DisplayLayout.Bands(0).Summaries.Clear()
      GrillaResumen.EnterMueveACeldaDeAbajo = True

      Dim AnchoColumna As Integer = 0
      With GrillaResumen.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If pos >= 17 And pos <= 27 Then
               AnchoColumna = 52
            ElseIf pos > 27 Then
               AnchoColumna = 65
            Else
               AnchoColumna = 60
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Right)
            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("Meta", pos, 55, HAlign.Right)
            .Columns(colName2).CellAppearance.BackColor = Color.LightBlue
            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer
            If _IngresaMetas Then
               .Columns(colName2).CellActivation = Activation.AllowEdit
            Else
               .Columns(colName2).CellActivation = Activation.NoEdit
            End If
            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("Dif", pos, 55, HAlign.Right)
            ' .Columns(colName3).CellAppearance.ForeColor = Color.Red

            'Totales
            GrillaResumen.AgregarTotalSumaColumna(colName, "{0:N0}")
            GrillaResumen.AgregarTotalSumaColumna(colName2, "{0:N0}")
            GrillaResumen.AgregarTotalSumaColumna(colName3, "{0:N0}")
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName3).Appearance.ForeColor = Color.Red
         Next

      End With

      For Each dr As UltraGridRow In GrillaResumen.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            If Integer.Parse(dr.Cells(colName).Value.ToString()) < 0 Then
               dr.Cells(colName).Appearance.ForeColor = Color.Red
            End If
         Next
      Next

      Me.ResumenTotales(pivotResult, GrillaResumen, GrillaTotales, IdProductoModeloTipo)

      Me.ResumenDiasHabilesNoHabiles(pivotResult, GrillaDiasHabiles)


   End Sub
   Private Sub ResumenTotales(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                              GrillaResumen As UltraGrid, GrillaTotales As UltraGrid, IdProductoModeloTipo As Integer)

      Dim Resumen As DataTable = New DataTable()
      _Totales = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty

      _Totales.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      _Totales.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         _Totales.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         _Totales.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         _Totales.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      Dim FechaDesde As Date
      FechaDesde = New Date(dtpDesdeSalida.Value.Year, dtpDesdeSalida.Value.Month, 1)
      Dim FechaHasta As Date
      FechaHasta = dtpHastaSalida.Value
      'FechaHasta = FechaDesde.AddMonths(1).AddSeconds(-1)


      Dim dr2 As DataRow
      dr2 = _Totales.NewRow()
      dr2("DiasLabNoLab") = "CANTIDAD UNIDADES PROYECTADAS "
      Dim MetaMensual As Integer = 0
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

         'MetaMensual = New Reglas.TiposListasMetas().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()), FechaDesde, FechaHasta)
         MetaMensual = New Reglas.TiposListasProductosProgramacion().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()),
                                                                                         FechaDesde, FechaHasta, IdProductoModeloTipo)


         dr2(drColumnas("NombreListaControlTipo").ToString()) = MetaMensual
      Next
      _Totales.Rows.Add(dr2)

      Dim dr3 As DataRow
      dr3 = _Totales.NewRow()
      dr3("DiasLabNoLab") = "UNIDADES PARA ALCANZAR LA META "
      Dim CantidadReal As Integer = 0
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         MetaMensual = New Reglas.TiposListasMetas().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()), FechaDesde, FechaHasta)
         CantidadReal = Integer.Parse(GrillaResumen.Rows.SummaryValues(drColumnas("NombreListaControlTipo").ToString()).Value.ToString())
         dr3(drColumnas("NombreListaControlTipo").ToString()) = CantidadReal - MetaMensual
      Next
      _Totales.Rows.Add(dr3)

      GrillaTotales.DataSource = _Totales

      Dim pos As Integer = AjustarColumnasGrilla(GrillaTotales, _tit)


      GrillaTotales.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 94, HAlign.Center, True)
      GrillaTotales.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("", pos, 140, HAlign.Left)
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellAppearance.FontData.SizeInPoints = 6.5
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellMultiLine = DefaultableBoolean.True

      GrillaTotales.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaTotales.DisplayLayout.Override.DefaultRowHeight = 25
      Dim AnchoColumna As Integer = 0

      With GrillaTotales.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If pos > 17 Then
               AnchoColumna = 56
            Else
               AnchoColumna = 59
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Right)
            '  .Columns(colName).CellAppearance.BackColor = Color.DarkSeaGreen
            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("", pos, 55, HAlign.Center)

            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer
            'If _IngresaMetas Then
            '   .Columns(colName2).CellActivation = Activation.AllowEdit
            'Else
            '   .Columns(colName2).CellActivation = Activation.NoEdit
            'End If
            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("", pos, 55, HAlign.Center)
            '   .Columns(colName3).CellAppearance.ForeColor = Color.Red
         Next
      End With

      For Each dr As UltraGridRow In GrillaTotales.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Integer.Parse(dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Value.ToString()) < 0 Then
               dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Appearance.ForeColor = Color.Red
            End If
         Next
      Next

   End Sub

   Private Sub ResumenDiasHabilesNoHabiles(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                           GrillaDiasHabiles As UltraGrid)
      Dim Resumen As DataTable = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty

      Resumen.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      Resumen.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         Resumen.Columns.Add(colName, System.Type.GetType("System.Decimal"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      Dim FechaDesde As Date
      FechaDesde = New Date(dtpDesdeSalida.Value.Year, dtpDesdeSalida.Value.Month, 1)
      Dim FechaHasta As Date
      FechaHasta = FechaDesde.AddMonths(1).AddSeconds(-1)



      Dim dr2 As DataRow
      dr2 = Resumen.NewRow()
      dr2("DiasLabNoLab") = "DIAS HABILES RESTANTES (SIN SABADOS) INCLUIDO HOY "
      Dim dates As DateTime() = GetDatesBetween(ending, FechaHasta).ToArray()
      Dim DiasHabiles As Integer = 0

      Dim oDiaLabNoLab As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables()
      Dim DiaLabNoLab As Entidades.DiaLaborableNoLaborable = New Entidades.DiaLaborableNoLaborable()

      For Each fec As Date In dates
         DiaLabNoLab = oDiaLabNoLab.GetUno(fec)
         If DiaLabNoLab IsNot Nothing Then
            If DiaLabNoLab.Laborable Then
               DiasHabiles += 1
            End If
         Else
            ShowMessage("ATENCION: Faltan generar dias Laborables y no Laborables!!!")
            Exit Sub
         End If
      Next

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         dr2(drColumnas("NombreListaControlTipo").ToString()) = DiasHabiles
      Next
      Resumen.Rows.Add(dr2)

      Dim dr3 As DataRow
      dr3 = Resumen.NewRow()
      dr3("DiasLabNoLab") = "COCHES POR DIA P/ ALCANZAR LA META"
      Dim CantidadFalta As Integer = 0
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         CantidadFalta = Math.Abs(Integer.Parse(_Totales.Rows(1).Item(drColumnas("NombreListaControlTipo").ToString()).ToString()))
         If DiasHabiles <> 0 Then
            dr3(drColumnas("NombreListaControlTipo").ToString()) = CantidadFalta / DiasHabiles
         Else
            dr3(drColumnas("NombreListaControlTipo").ToString()) = 0
         End If
      Next
      Resumen.Rows.Add(dr3)

      GrillaDiasHabiles.DataSource = Resumen

      Dim pos As Integer = AjustarColumnasGrilla(GrillaDiasHabiles, _tit)

      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 94, HAlign.Center, True)
      GrillaDiasHabiles.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("", pos, 140, HAlign.Left)
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellAppearance.FontData.SizeInPoints = 6.5
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellMultiLine = DefaultableBoolean.True

      GrillaDiasHabiles.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaDiasHabiles.DisplayLayout.Override.DefaultRowHeight = 25
      Dim AnchoColumna As Integer = 0

      With GrillaDiasHabiles.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If pos > 17 Then
               AnchoColumna = 56
            Else
               AnchoColumna = 59
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Right)
            .Columns(colName).Style = UltraWinGrid.ColumnStyle.Double

            ' .Columns(colName).CellAppearance.BackColor = Color.Yellow
            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("", pos, 55, HAlign.Center)

            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer
            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("", pos, 55, HAlign.Center)
            ' .Columns(colName3).CellAppearance.ForeColor = Color.Red
         Next

      End With

      For Each dr As UltraGridRow In GrillaDiasHabiles.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Double.Parse(dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Value.ToString()) < 0 Then
               dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Appearance.ForeColor = Color.Red
            End If

         Next
      Next
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         GrillaDiasHabiles.Rows(0).Cells.Item(drColumnas("NombreListaControlTipo").ToString()).Style = UltraWinGrid.ColumnStyle.Integer
      Next

   End Sub


   Private Sub ColumnasASumar(grilla As UltraGrid)

      Dim columnToSummarize2 As UltraGridColumn = grilla.DisplayLayout.Bands(0).Columns("LeadTimeLiberado")
      Dim summary2 As SummarySettings = grilla.DisplayLayout.Bands(0).Summaries.Add("LeadTimeLiberado", SummaryType.Average, columnToSummarize2)
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

   Private Sub SalidaPorCoche(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                 Grilla As UltraGrid, GrillaSoloCantidades As UltraGrid)

      Dim Datos As DataTable = DirectCast(Grilla.DataSource, DataTable)

      Dim SalidaPorCoche As DataTable = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty
      Dim colName4 As String = String.Empty


      SalidaPorCoche.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      '  Resumen.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

         colName = drColumnas("NombreListaControlTipo").ToString()
         SalidaPorCoche.Columns.Add(colName, System.Type.GetType("System.String"))
         colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Modelo"
         SalidaPorCoche.Columns.Add(colName2, System.Type.GetType("System.String"))
         colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Cliente"
         SalidaPorCoche.Columns.Add(colName3, System.Type.GetType("System.String"))
         colName4 = drColumnas("NombreListaControlTipo").ToString() + "-Espacio"
         SalidaPorCoche.Columns.Add(colName4, System.Type.GetType("System.String"))
      Next

      '  Programacion.Columns.Add("FechaLiberado", System.Type.GetType("System.DateTime"))

      'Dim starting As DateTime = New DateTime()
      'starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      'Dim ending As DateTime = New DateTime()
      'ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      'Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      'For Each fec As Date In dates
      '   'dr1 = Resumen.NewRow()
      '   'dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
      '   'For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
      '   '   dr1(drColumnas("NombreListaControlTipo").ToString()) = 0
      '   'Next
      '   'Resumen.Rows.Add(dr1)
      'Next

      'Dim oDiaLabNoLab As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables()
      'Dim DiaLabNoLab As Entidades.DiaLaborableNoLaborable = New Entidades.DiaLaborableNoLaborable()
      Dim DatosOrdenados As DataTable

      If Datos.Rows.Count <> 0 Then
         DatosOrdenados = (From row In Datos.Select Order By Convert.ToDateTime(row("FechaSalida")) Select row).ToArray.CopyToDataTable()
      Else
         Exit Sub
      End If

      '  Datos.DefaultView.Sort = "FechaSalida"

      For Each dr2 As DataRow In DatosOrdenados.Rows

         dr1 = SalidaPorCoche.NewRow()
         dr1("FechaSalida") = Date.Parse(dr2("FechaSalida").ToString()).ToString("dd/MM/yyyy")
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            dr1(drColumnas("NombreListaControlTipo").ToString()) = String.Empty
         Next
         '  dr1("FechaLiberado") = DBNull.Value
         SalidaPorCoche.Rows.Add(dr1)
      Next

      'DiaLabNoLab = oDiaLabNoLab.GetUno(Date.Parse(dr("FechaSalida").ToString()))
      'If DiaLabNoLab IsNot Nothing Then
      '   dr("DiasLabNoLab") = IIf(DiaLabNoLab.Laborable, "H", "NH")
      'Else
      '   dr("DiasLabNoLab") = String.Empty
      'End If
      Dim Bajar As Boolean = False

      For Each dr2 As DataRow In DatosOrdenados.Rows

         For Each dr As DataRow In SalidaPorCoche.Rows

            If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2("FechaSalida").ToString()).ToString("dd/MM/yyyy") Then

               For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

                  colName = drColumnas("NombreListaControlTipo").ToString()
                  colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Modelo"
                  colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Cliente"

                  If Not String.IsNullOrEmpty(dr2(drColumnas("NombreListaControlTipo").ToString()).ToString()) Then

                     If String.IsNullOrEmpty(dr(drColumnas("NombreListaControlTipo").ToString()).ToString()) Then

                        dr(colName) = dr2(drColumnas("NombreListaControlTipo").ToString()).ToString()
                        dr(colName2) = dr2("NombreProductoModeloTipo").ToString()
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

      SalidaPorCoche.AcceptChanges()

      Dim Borra As Boolean = False
      For Each dr As DataRow In SalidaPorCoche.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr(drColumnas("NombreListaControlTipo").ToString()).ToString()) Then
               Borra = True
               Exit For
            End If
         Next
         If Not Borra Then
            dr.Delete()
         End If
         Borra = False

      Next

      GrillaSoloCantidades.DataSource = SalidaPorCoche

      Dim pos As Integer = AjustarColumnasGrilla(GrillaSoloCantidades, _tit)

      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha", pos, 80, HAlign.Center, , "dd/MM/yyyy")
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").Header.Appearance.TextHAlign = HAlign.Center
      GrillaSoloCantidades.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").MergedCellStyle = MergedCellStyle.Always
      GrillaSoloCantidades.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True

      GrillaSoloCantidades.InicializaTotales()
      GrillaSoloCantidades.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
      GrillaSoloCantidades.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False


      GrillaSoloCantidades.DisplayLayout.Bands(0).Summaries.Clear()

      Dim AnchoColumna As Integer = 0
      With GrillaSoloCantidades.DisplayLayout.Bands(0)

         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            AnchoColumna = 90
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)
            .Columns(colName).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns(colName).Header.Appearance.FontData.SizeInPoints = 10
            .Columns(colName).Header.Appearance.TextHAlign = HAlign.Center
            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Modelo"
            .Columns(colName2).FormatearColumna("Modelo", pos, 70, HAlign.Left)
            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Cliente"
            .Columns(colName3).FormatearColumna("Cliente", pos, 120, HAlign.Left)
            colName4 = drColumnas("NombreListaControlTipo").ToString() + "-Espacio"
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
         '   .Columns("FechaLiberado").FormatearColumna("Liberado", pos, 80, HAlign.Center, , "dd/MM/yyyy")

      End With

      'For Each dr As UltraGridRow In GrillaSoloCantidades.Rows
      '   If Date.Parse(dr.Cells("FechaSalida").Value.ToString()).ToString("dd/MM/yyyy") = Me.dtpFechaCorte.Value.ToString("dd/MM/yyyy") Then
      '      dr.Appearance.BorderColor = Color.Red
      '   End If
      'Next

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
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & "_Informe.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmPdfInforme_Click(sender As Object, e As EventArgs) Handles tsmPdfInforme.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & "_Informe.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
      If TabControl1.SelectedTab Is tbpInforme Then
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      ElseIf TabControl1.SelectedTab Is tbpInformeMyL Then
         Me.tssRegistros.Text = Me.ugDetalleMyL.Rows.Count.ToString() & " Registros"
      ElseIf TabControl1.SelectedTab Is tbpInformeUrbano Then
         Me.tssRegistros.Text = Me.ugDetalleURBANO.Rows.Count.ToString() & " Registros"
      ElseIf TabControl1.SelectedTab Is tbpFechasSalidaPorCoche Then
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      ElseIf TabControl1.SelectedTab Is tbpFechasSalidaPorCocheUrb Then
         Me.tssRegistros.Text = Me.ugDetalleURBANO.Rows.Count.ToString() & " Registros"
      ElseIf TabControl1.SelectedTab Is tbpFechasSalidaPorCocheMyL Then
         Me.tssRegistros.Text = Me.ugDetalleMyL.Rows.Count.ToString() & " Registros"
      End If
   End Sub

   Private Sub tsmExcelInformeMyL_Click(sender As Object, e As EventArgs) Handles tsmExcelInformeMyL.Click
      Try
         If Me.ugDetalleMyL.Rows.Count = 0 Then Exit Sub
         ugDetalleMyL.Exportar(Me.Name & "_InformeMyL.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmPdfInformeMyL_Click(sender As Object, e As EventArgs) Handles tsmPdfInformeMyL.Click
      Try
         If Me.ugDetalleMyL.Rows.Count = 0 Then Exit Sub
         ugDetalleMyL.Exportar(Me.Name & "_InformeMyL.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcelInformeMyL_Click(sender As Object, e As EventArgs) Handles tsmiAExcelInformeMyL.Click
      Try
         If Me.ugSalidaPorCocheMyL1.Rows.Count = 0 Then Exit Sub
         ugSalidaPorCocheMyL1.Exportar(Me.Name & "_FechasSalidaPorCocheMyL.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFInformeMyL_Click(sender As Object, e As EventArgs) Handles tsmiAPDFInformeMyL.Click
      Try
         If Me.ugSalidaPorCocheMyL1.Rows.Count = 0 Then Exit Sub
         ugSalidaPorCocheMyL1.Exportar(Me.Name & "_FechasSalidaPorCocheMyL.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmExcelInformeUrbano_Click(sender As Object, e As EventArgs) Handles tsmExcelInformeUrbano.Click
      Try
         If Me.ugDetalleURBANO.Rows.Count = 0 Then Exit Sub
         ugDetalleURBANO.Exportar(Me.Name & "_InformeUrbano.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmPdfInformeUrbano_Click(sender As Object, e As EventArgs) Handles tsmPdfInformeUrbano.Click
      Try
         If Me.ugDetalleURBANO.Rows.Count = 0 Then Exit Sub
         ugDetalleURBANO.Exportar(Me.Name & "_InformeUrbano.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcelInformeUrbano_Click(sender As Object, e As EventArgs) Handles tsmiAExcelInformeUrbano.Click
      Try
         If Me.ugSalidaPorCocheUrb1.Rows.Count = 0 Then Exit Sub
         ugSalidaPorCocheUrb1.Exportar(Me.Name & "_FechasSalidaPorCocheUrb.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFInformeUrbano_Click(sender As Object, e As EventArgs) Handles tsmiAPDFInformeUrbano.Click
      Try
         If Me.ugSalidaPorCocheUrb1.Rows.Count = 0 Then Exit Sub
         ugSalidaPorCocheUrb1.Exportar(Me.Name & "_FechasSalidaPorCocheUrb.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


End Class