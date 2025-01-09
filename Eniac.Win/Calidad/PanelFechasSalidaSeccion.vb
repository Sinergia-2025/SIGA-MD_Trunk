Imports Infragistics.Documents.Excel
Public Class PanelFechasSalidaSeccion
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
   Private _TotalesMes As DataTable = New DataTable()
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
         If Me.ugeSoloCantidades.Rows.Count = 0 Then Exit Sub
         ugeSoloCantidades.Exportar(Me.Name & "_Resumen.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDFInforme.Click
      Try
         If Me.ugeSoloCantidades.Rows.Count = 0 Then Exit Sub
         ugeSoloCantidades.Exportar(Me.Name & "_Resumen.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
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


   Private Sub chbOcultarFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chbOcultarFiltros.CheckedChanged
      Try
         Me.SplitContainer1.Panel1Collapsed = Not Me.chbOcultarFiltros.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugeResumen_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugeResumen.AfterCellUpdate
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

         ' Me.ResumenTotales(pivotResult, ugeTotales)

         Me.ResumenDiasHabilesNoHabiles(pivotResult, ugeDiasHabiles)

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
      End If
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

      Me.UltraChart3.Visible = False
      Me.grpRangoG3.Visible = False
      Me.grpRangoG4.Visible = False
      Me.grbFechasUnidad.Visible = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugeResumen.DataSource Is Nothing Then
         DirectCast(Me.ugeResumen.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugeTotales.DataSource Is Nothing Then
         DirectCast(Me.ugeTotales.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugeTotalesMes.DataSource Is Nothing Then
         DirectCast(Me.ugeTotalesMes.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugeDiasHabiles.DataSource Is Nothing Then
         DirectCast(Me.ugeDiasHabiles.DataSource, DataTable).Rows.Clear()
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



      Me.MoverFechasSalida(pivotResult, ugDetalle)
      Me.MoverFechasSalida(pivotResultMyL, ugDetalleMyL)
      Me.MoverFechasSalida(pivotResultUrbano, ugDetalleURBANO)

      Me.FiltroFechaSalida(pivotResult, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalle)
      Me.FiltroFechaSalida(pivotResultMyL, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalleMyL)
      Me.FiltroFechaSalida(pivotResultUrbano, dtpDesdeSalida.Value, dtpHastaSalida.Value, ugDetalleURBANO)


      Me.ResumenCantidades(pivotResult, ugDetalle, ugeSoloCantidades)
      Me.ResumenCantidades(pivotResultMyL, ugDetalleMyL, ugeSoloCantidadesMyL)
      Me.ResumenCantidades(pivotResultUrbano, ugDetalleURBANO, ugeSoloCantidadesURBANO)

      Me.ResumenFechaSalida(pivotResult, ugDetalle, ugeResumen, ugeTotales, ugeTotalesMes, ugeDiasHabiles, IdProductoModeloTipo:=0)
      Me.ResumenFechaSalida(pivotResultMyL, ugDetalleMyL, ugeResumenMyL, ugeTotalesMyL, ugeTotalesMesMyL, ugeDiasHabilesMyL, IdProductoModeloTipo:=2)
      Me.ResumenFechaSalida(pivotResultUrbano, ugDetalleURBANO, ugeResumenURBANO, ugeTotalesURBANO, ugeTotalesMesURBANO, ugeDiasHabilesURBANO, IdProductoModeloTipo:=1)

      Me.FormatearGrilla(ugDetalle)
      Me.FormatearGrilla(ugDetalleMyL)
      Me.FormatearGrilla(ugDetalleURBANO)

      If pivotResult.dtResult.Rows.Count > 0 Then
         Me.btnConsultar.Focus()
         Me.Graficar(pivotResult)
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
            If not chbMostrarColumnasExtras.Checked Then
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
      ugeTotales.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False
      ugeDiasHabiles.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False
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

      Dim Datos As DataTable = DirectCast(Grilla.DataSource, DataTable)

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

         For Each dr2 As UltraGridRow In Grilla.Rows
            For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
               If Not String.IsNullOrEmpty(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
                  If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()).ToString("dd/MM/yyyy") Then
                     dr(drColumnas("NombreListaControlTipo").ToString()) = Integer.Parse(dr(drColumnas("NombreListaControlTipo").ToString()).ToString()) + 1
                  End If
               End If
            Next
         Next
      Next

      Dim oMetas As Reglas.TiposListasMetas = New Reglas.TiposListasMetas()
      Dim Metas As DataTable = oMetas.GetMetas(starting, ending)

      GrillaSoloCantidades.DataSource = Resumen

      Dim pos As Integer = AjustarColumnasGrilla(GrillaSoloCantidades, _tit)

      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 80, HAlign.Center, , "dd/MM/yyyy")
      GrillaSoloCantidades.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaSoloCantidades.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("Día H/NH", pos, 60, HAlign.Center)
      GrillaSoloCantidades.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaSoloCantidades.InicializaTotales()
      GrillaSoloCantidades.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
      GrillaSoloCantidades.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
      GrillaSoloCantidades.DisplayLayout.Bands(0).Summaries.Clear()

      Dim AnchoColumna As Integer = 0
      With GrillaSoloCantidades.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            AnchoColumna = 80
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Right)

            'Totales
            GrillaSoloCantidades.AgregarTotalSumaColumna(colName, "{0:N0}")

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If

         Next
      End With

   End Sub

   Private Sub ResumenFechaSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                  grilla As UltraGrid, GrillaResumen As UltraGridEditable, GrillaTotales As UltraGrid,
                                  grillaTotalesMes As UltraGrid, GrillaDiasHabiles As UltraGrid, IdProductoModeloTipo As Integer)

      Dim Datos As DataTable = DirectCast(grilla.DataSource, DataTable)

      Dim Resumen As DataTable = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName1 As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty
      Dim colName4 As String = String.Empty

      Resumen.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      Resumen.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
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
      GrillaResumen.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(128, 128, 128)
      GrillaResumen.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White
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
               AnchoColumna = 70
            Else
               AnchoColumna = 60
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If

            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("Meta", pos, 55, HAlign.Center)
            .Columns(colName2).CellAppearance.BackColor = Color.Wheat
            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer
            If _IngresaMetas Then
               .Columns(colName2).CellActivation = Activation.AllowEdit
            Else
               .Columns(colName2).CellActivation = Activation.NoEdit
            End If


            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName2).Hidden = True
               End If
            End If

            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("Dif", pos, 55, HAlign.Center)
            ' .Columns(colName3).CellAppearance.ForeColor = Color.Red

            colName4 = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            .Columns(colName4).FormatearColumna("", pos, 10, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName3).Hidden = True
                  .Columns(colName4).Hidden = True

               End If
            End If

            'Totales
            GrillaResumen.AgregarTotalSumaColumna(colName, "{0:N0}")
            GrillaResumen.AgregarTotalSumaColumna(colName2, "{0:N0}")
            GrillaResumen.AgregarTotalSumaColumna(colName3, "{0:N0}")
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName3).Appearance.ForeColor = Color.Red
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName).Appearance.TextHAlign = HAlign.Center
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName2).Appearance.TextHAlign = HAlign.Center
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName3).Appearance.TextHAlign = HAlign.Center

            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName).Appearance.BackColor = Color.FromArgb(216, 228, 188)
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName2).Appearance.BackColor = Color.FromArgb(216, 228, 188)
            GrillaResumen.DisplayLayout.Bands(0).Summaries.Item(colName3).Appearance.BackColor = Color.FromArgb(216, 228, 188)
         Next

      End With

      For Each dr As UltraGridRow In GrillaResumen.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            colName1 = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            If Integer.Parse(dr.Cells(colName).Value.ToString()) < 0 Then
               dr.Cells(colName).Appearance.ForeColor = Color.Red
            End If
            dr.Cells(colName1).Appearance.BackColor = Color.Gray
         Next
      Next

      Me.ResumenTotales(pivotResult, GrillaResumen, GrillaTotales, IdProductoModeloTipo)

      Me.ResumenTotalesMensual(pivotResult, GrillaResumen, grillaTotalesMes, IdProductoModeloTipo)

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
      Dim colName4 As String = String.Empty

      _Totales.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      _Totales.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         _Totales.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         _Totales.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         _Totales.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
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
      dr2("DiasLabNoLab") = "UNIDADES PROYECTADAS "
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

      Dim dr4 As DataRow
      dr4 = _Totales.NewRow()
      dr4("DiasLabNoLab") = "UNIDADES REALES "


      Dim CantidadReal As Integer = 0
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         '  MetaMensual = New Reglas.TiposListasMetas().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()), FechaDesde, FechaHasta)
         MetaMensual = New Reglas.TiposListasProductosProgramacion().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()),
                                                                                         FechaDesde, FechaHasta, IdProductoModeloTipo)

         CantidadReal = Integer.Parse(GrillaResumen.Rows.SummaryValues(drColumnas("NombreListaControlTipo").ToString()).Value.ToString())
         dr4(drColumnas("NombreListaControlTipo").ToString()) = CantidadReal
         dr3(drColumnas("NombreListaControlTipo").ToString()) = CantidadReal - MetaMensual
      Next

      _Totales.Rows.Add(dr4)
      _Totales.Rows.Add(dr3)

      GrillaTotales.DataSource = _Totales

      Dim pos As Integer = AjustarColumnasGrilla(GrillaTotales, _tit)


      GrillaTotales.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 94, HAlign.Center, True)
      GrillaTotales.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("AL " & FechaHasta.ToString("dd/MM/yyyy"), pos, 140, HAlign.Left)
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellAppearance.FontData.SizeInPoints = 6.5
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellMultiLine = DefaultableBoolean.True

      GrillaTotales.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaTotales.DisplayLayout.Override.DefaultRowHeight = 25
      GrillaTotales.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(128, 128, 128)
      GrillaTotales.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White

      Dim AnchoColumna As Integer = 0

      With GrillaTotales.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If pos >= 17 And pos <= 27 Then
               AnchoColumna = 52
            ElseIf pos > 27 Then
               AnchoColumna = 70
            Else
               AnchoColumna = 60
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)
            '  .Columns(colName).CellAppearance.BackColor = Color.DarkSeaGreen

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If

            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("", pos, 55, HAlign.Center)

            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer

            'If _IngresaMetas Then
            '   .Columns(colName2).CellActivation = Activation.AllowEdit
            'Else
            '   .Columns(colName2).CellActivation = Activation.NoEdit
            'End If
            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName2).Hidden = True
               End If
            End If

            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("", pos, 55, HAlign.Center)

            colName4 = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            .Columns(colName4).FormatearColumna("", pos, 10, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName3).Hidden = True
                  .Columns(colName4).Hidden = True

               End If
            End If
            '   .Columns(colName3).CellAppearance.ForeColor = Color.Red
         Next
      End With

      For Each dr As UltraGridRow In GrillaTotales.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            If Integer.Parse(dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Value.ToString()) < 0 Then
               dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Appearance.ForeColor = Color.Red
            End If
            dr.Cells(colName).Appearance.BackColor = Color.Gray
         Next
      Next

   End Sub

   Private Sub ResumenTotalesMensual(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                              GrillaResumen As UltraGrid, GrillaTotales As UltraGrid, IdProductoModeloTipo As Integer)

      Dim Resumen As DataTable = New DataTable()
      _TotalesMes = New DataTable()
      Dim dr1 As DataRow
      Dim colName As String = String.Empty
      Dim colName2 As String = String.Empty
      Dim colName3 As String = String.Empty
      Dim colName4 As String = String.Empty

      _TotalesMes.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      _TotalesMes.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))

      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         _TotalesMes.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         _TotalesMes.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         _TotalesMes.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
         _TotalesMes.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy"))

      Dim FechaDesde As Date
      FechaDesde = New Date(dtpDesdeSalida.Value.Year, dtpDesdeSalida.Value.Month, 1)
      Dim FechaHasta As Date
      ' FechaHasta = dtpHastaSalida.Value
      FechaHasta = FechaDesde.AddMonths(1).AddSeconds(-1)


      Dim dr2 As DataRow
      dr2 = _TotalesMes.NewRow()
      dr2("DiasLabNoLab") = "UNIDADES PROYECTADAS MES "
      Dim MetaMensual As Integer = 0
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

         'MetaMensual = New Reglas.TiposListasMetas().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()), FechaDesde, FechaHasta)
         MetaMensual = New Reglas.TiposListasProductosProgramacion().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()),
                                                                                         FechaDesde, FechaHasta, IdProductoModeloTipo)


         dr2(drColumnas("NombreListaControlTipo").ToString()) = MetaMensual
      Next
      _TotalesMes.Rows.Add(dr2)

      Dim dr3 As DataRow
      dr3 = _TotalesMes.NewRow()
      dr3("DiasLabNoLab") = "UNIDADES PARA ALCANZAR LA META MES "

      Dim dr4 As DataRow
      dr4 = _TotalesMes.NewRow()
      dr4("DiasLabNoLab") = "UNIDADES REALES MES "


      Dim CantidadReal As Integer = 0
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         '  MetaMensual = New Reglas.TiposListasMetas().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()), FechaDesde, FechaHasta)
         MetaMensual = New Reglas.TiposListasProductosProgramacion().GetTotalMetasPorMes(Integer.Parse(drColumnas("IdListaControlTipo").ToString()),
                                                                                         FechaDesde, FechaHasta, IdProductoModeloTipo)

         CantidadReal = Integer.Parse(GrillaResumen.Rows.SummaryValues(drColumnas("NombreListaControlTipo").ToString()).Value.ToString())
         dr4(drColumnas("NombreListaControlTipo").ToString()) = CantidadReal
         dr3(drColumnas("NombreListaControlTipo").ToString()) = CantidadReal - MetaMensual
      Next

      _TotalesMes.Rows.Add(dr4)
      _TotalesMes.Rows.Add(dr3)

      GrillaTotales.DataSource = _TotalesMes

      Dim pos As Integer = AjustarColumnasGrilla(GrillaTotales, _tit)


      GrillaTotales.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 94, HAlign.Center, True)
      GrillaTotales.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("AL " & FechaHasta.ToString("dd/MM/yyyy"), pos, 140, HAlign.Left)
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellAppearance.FontData.SizeInPoints = 6.5
      GrillaTotales.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellMultiLine = DefaultableBoolean.True

      GrillaTotales.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaTotales.DisplayLayout.Override.DefaultRowHeight = 25
      GrillaTotales.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(128, 128, 128)
      GrillaTotales.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White

      Dim AnchoColumna As Integer = 0

      With GrillaTotales.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If pos >= 17 And pos <= 27 Then
               AnchoColumna = 52
            ElseIf pos > 27 Then
               AnchoColumna = 70
            Else
               AnchoColumna = 60
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)
            '  .Columns(colName).CellAppearance.BackColor = Color.DarkSeaGreen

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If

            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("", pos, 55, HAlign.Center)

            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer
            'If _IngresaMetas Then
            '   .Columns(colName2).CellActivation = Activation.AllowEdit
            'Else
            '   .Columns(colName2).CellActivation = Activation.NoEdit
            'End If
            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName2).Hidden = True
               End If
            End If

            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("", pos, 55, HAlign.Center)

            colName4 = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            .Columns(colName4).FormatearColumna("", pos, 10, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName3).Hidden = True
                  .Columns(colName4).Hidden = True
               End If
            End If
            '   .Columns(colName3).CellAppearance.ForeColor = Color.Red
         Next
      End With

      For Each dr As UltraGridRow In GrillaTotales.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            If Integer.Parse(dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Value.ToString()) < 0 Then
               dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Appearance.ForeColor = Color.Red
            End If
            dr.Cells(colName).Appearance.BackColor = Color.Gray
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
      Dim colName4 As String = String.Empty

      Resumen.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      Resumen.Columns.Add("DiasLabNoLab", System.Type.GetType("System.String"))
      Resumen.Columns.Add("Esp1", System.Type.GetType("System.String"))


      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         colName = drColumnas("NombreListaControlTipo").ToString()
         Resumen.Columns.Add(colName, System.Type.GetType("System.Decimal"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
         colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
         Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(dtpDesdeSalida.Value.ToString("dd/MM/yyyy"))
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(dtpHastaSalida.Value.ToString("dd/MM/yyyy")).AddDays(1)

      Dim FechaDesde As Date
      FechaDesde = New Date(dtpDesdeSalida.Value.Year, dtpDesdeSalida.Value.Month, 1)
      Dim FechaHasta As Date
      FechaHasta = FechaDesde.AddMonths(1).AddSeconds(-1)



      Dim dr2 As DataRow
      dr2 = Resumen.NewRow()
      dr2("DiasLabNoLab") = "DIAS HABILES RESTANTES (SIN SABADOS) "
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
         CantidadFalta = Math.Abs(Integer.Parse(_TotalesMes.Rows(2).Item(drColumnas("NombreListaControlTipo").ToString()).ToString()))
         If DiasHabiles <> 0 Then
            dr3(drColumnas("NombreListaControlTipo").ToString()) = CantidadFalta / DiasHabiles
         Else
            dr3(drColumnas("NombreListaControlTipo").ToString()) = 0
         End If
      Next
      Resumen.Rows.Add(dr3)

      'dr1 = Resumen.NewRow()
      'dr1("Esp1") = ""
      'Resumen.Rows.Add(dr1)


      GrillaDiasHabiles.DataSource = Resumen

      Dim pos As Integer = AjustarColumnasGrilla(GrillaDiasHabiles, _tit)

      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("FechaSalida").FormatearColumna("Fecha Salida", pos, 94, HAlign.Center, True)
      GrillaDiasHabiles.DisplayLayout.Bands(0).ColHeaderLines = 2
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("DiasLabNoLab").FormatearColumna("AL " & FechaHasta.ToString("dd/MM/yyyy"), pos, 140, HAlign.Left)
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellAppearance.FontData.SizeInPoints = 6.5
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("DiasLabNoLab").CellMultiLine = DefaultableBoolean.True

      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("Esp1").FormatearColumna("Fecha Salida", pos, 10, HAlign.Center, True)
      GrillaDiasHabiles.DisplayLayout.Bands(0).Columns("Esp1").CellAppearance.BackColor = Color.Gray

      GrillaDiasHabiles.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
      GrillaDiasHabiles.DisplayLayout.Override.DefaultRowHeight = 25
      GrillaDiasHabiles.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(128, 128, 128)
      GrillaDiasHabiles.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White

      Dim AnchoColumna As Integer = 0

      With GrillaDiasHabiles.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            If pos >= 17 And pos <= 27 Then
               AnchoColumna = 52
            ElseIf pos > 27 Then
               AnchoColumna = 70
            Else
               AnchoColumna = 60
            End If
            colName = drColumnas("NombreListaControlTipo").ToString()
            .Columns(colName).FormatearColumna(drColumnas("NombreListaControlTipo").ToString(), pos, AnchoColumna, HAlign.Center)
            .Columns(colName).Style = UltraWinGrid.ColumnStyle.Double

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName).Hidden = True
               End If
            End If

            ' .Columns(colName).CellAppearance.BackColor = Color.Yellow
            colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
            .Columns(colName2).FormatearColumna("", pos, 55, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName2).Hidden = True
               End If
            End If

            .Columns(colName2).Style = UltraWinGrid.ColumnStyle.Integer
            colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
            .Columns(colName3).FormatearColumna("", pos, 55, HAlign.Center)
            ' .Columns(colName3).CellAppearance.ForeColor = Color.Red

            colName4 = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            .Columns(colName4).FormatearColumna("", pos, 10, HAlign.Center)

            If Not chbMostrarColumnasExtras.Checked Then
               If Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 1 Or Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 10 Or
                          Integer.Parse(drColumnas("IdListaControlTipo").ToString()) = 8 Then
                  .Columns(colName3).Hidden = True
                  .Columns(colName4).Hidden = True
               End If
            End If

         Next

      End With

      For Each dr As UltraGridRow In GrillaDiasHabiles.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            colName = drColumnas("NombreListaControlTipo").ToString() + "-Esp"
            If Double.Parse(dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Value.ToString()) < 0 Then
               dr.Cells(drColumnas("NombreListaControlTipo").ToString()).Appearance.ForeColor = Color.Red
            End If
            dr.Cells(colName).Appearance.BackColor = Color.Gray
         Next
      Next
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         GrillaDiasHabiles.Rows(0).Cells.Item(drColumnas("NombreListaControlTipo").ToString()).Style = UltraWinGrid.ColumnStyle.Integer
      Next

   End Sub


   Private Sub Graficar(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)

      Me.ChartsPorFecha(pivotResult)

   End Sub

   Private Sub ChartsPorFecha(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)

      Dim Resumen As DataTable = DirectCast(ugeResumen.DataSource, DataTable)

      Dim datos As DataTable = Resumen.Copy()
      Dim table As DataTable = New DataTable
      Dim ColumnasRemove As List(Of String) = New List(Of String)

      Me.UltraChart3.Visible = True
      Me.grpRangoG3.Visible = True
      Me.grpRangoG4.Visible = True
      Me.grbFechasUnidad.Visible = True

      If rbtDias.Checked Then

         'For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         '   Dim colName = drColumnas("NombreListaControlTipo").ToString()
         '   Dim colName2 = drColumnas("NombreListaControlTipo").ToString() + "-Meta"
         '   Dim colName3 = drColumnas("NombreListaControlTipo").ToString() + "-Dif"
         '   If Not colName = "Terminación Final" Or Not colName2 = "Terminación Final-Meta" And Not colName3 = "Terminación Final-Dif" Then
         '      datos.Columns.Remove(colName)
         '   End If

         'Next

         For Each col As DataColumn In datos.Columns
            If Not col.Caption = "Terminación Final" And Not col.Caption = "FechaSalida" Then
               ColumnasRemove.Add(col.Caption)
            End If
         Next

         For Each col As String In ColumnasRemove
            If Not col = "Terminación Final" Or Not col = "FechaSalida" Then
               datos.Columns.Remove(col)
            End If
         Next


      Else

         Dim MesIngreso As List(Of String) = (From d_row In datos.AsEnumerable()
                                              Select Date.Parse(d_row.Field(Of Date)("FechaSalida").ToString()).ToString("yyyy/MM")
                                              Distinct).ToList

         MesIngreso.Sort()

         table.Columns.Add("Mes", System.Type.GetType("System.String"))
         table.Columns.Add("TerminacionF", System.Type.GetType("System.Int32"))

         Dim dr As DataRow
         For Each fec As String In MesIngreso
            dr = table.NewRow
            dr("Mes") = fec
            dr("TerminacionF") = 0
            table.Rows.Add(dr)
         Next

         For Each fec As DataRow In table.Rows
            For Each dr1 As UltraGridRow In ugeResumen.Rows
               If Date.Parse(dr1.Cells("FechaSalida").Value.ToString()).ToString("yyyy/MM") = fec("Mes").ToString() Then
                  fec("TerminacionF") = CInt(fec("TerminacionF").ToString()) + Decimal.Parse(dr1.Cells("Terminación Final").Value.ToString())
               End If
            Next
         Next

      End If

      Dim ValorMaximo As Integer = 0
      If rbtDias.Checked Then
         ValorMaximo = Integer.Parse(datos.Compute("Max([Terminación Final])", "").ToString())
      Else
         ValorMaximo = Integer.Parse(table.Compute("Max(TerminacionF)", "").ToString())
      End If


      If rbtAutomaticoG3.Checked Then
         Me.UltraChart3.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Automatic
      Else

         If ValorMaximo > Integer.Parse(Me.txtManualMaximoG3.Text.ToString()) Then
            MessageBox.Show("El máximo es menor que los datos, reingrese valor máximo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


      'table.Columns("Cant").ColumnName = "Cantidad de Coches"

      If rbtDias.Checked Then
         Me.UltraChart3.DataSource = datos
      Else
         table.Columns("TerminacionF").ColumnName = "Terminación Final"
         Me.UltraChart3.DataSource = table
      End If

      Me.UltraChart3.DataBind()

   End Sub

   Private Sub ColumnasASumar(grilla As UltraGrid)

      Dim columnToSummarize2 As UltraGridColumn = grilla.DisplayLayout.Bands(0).Columns("LeadTimeLiberado")
      Dim summary2 As SummarySettings = grilla.DisplayLayout.Bands(0).Summaries.Add("LeadTimeLiberado", SummaryType.Average, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Center

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

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _ocultarFiltros = parametros = "ocultarfiltros"
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function


#End Region

#Region "Exportaciones"
   Private Sub tsmiAExcelResumen_Click(sender As Object, e As EventArgs) Handles tsmiAExcelCompleto.Click
      Try
         If Me.ugeResumen.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Me.Text

         Me.sfdExportar.FileName = Me.Name & "_Completo.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim AltoGrilla As Integer = 5 + ugeResumen.Rows.Count
               Me.UltraGridExcelExporter1.Export(ugeResumen, myWorksheet, 2, 0)
               Me.UltraGridExcelExporter1.Export(ugeTotales, myWorksheet, AltoGrilla, 1) '37
               Me.UltraGridExcelExporter1.Export(ugeTotalesMes, myWorksheet, AltoGrilla + 5, 1) '42
               Me.UltraGridExcelExporter1.Export(ugeDiasHabiles, myWorksheet, AltoGrilla + 10, 1) '47

               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
         '  ugeResumen.Exportar(Me.Name & "_Resumen.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFResumen_Click(sender As Object, e As EventArgs) Handles tsmiAPDFCompleto.Click
      Try
         If Me.ugeResumen.Rows.Count = 0 Then Exit Sub
         ugeResumen.Exportar(Me.Name & "_Completo.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
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
         If Me.ugeSoloCantidadesMyL.Rows.Count = 0 Then Exit Sub
         ugeSoloCantidadesMyL.Exportar(Me.Name & "_ResumenMyL.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFInformeMyL_Click(sender As Object, e As EventArgs) Handles tsmiAPDFInformeMyL.Click
      Try
         If Me.ugeSoloCantidadesMyL.Rows.Count = 0 Then Exit Sub
         ugeSoloCantidadesMyL.Exportar(Me.Name & "_ResumenMyL.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcelCompletoMyL_Click(sender As Object, e As EventArgs) Handles tsmiAExcelCompletoMyL.Click
      Try
         If Me.ugeResumenMyL.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Me.Text

         Me.sfdExportar.FileName = Me.Name & "_CompletoMyL.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim AltoGrilla As Integer = 5 + ugeResumenMyL.Rows.Count
               Me.UltraGridExcelExporter1.Export(ugeResumenMyL, myWorksheet, 2, 0)
               Me.UltraGridExcelExporter1.Export(ugeTotalesMyL, myWorksheet, AltoGrilla, 1)
               Me.UltraGridExcelExporter1.Export(ugeTotalesMesMyL, myWorksheet, AltoGrilla + 5, 1)
               Me.UltraGridExcelExporter1.Export(ugeDiasHabilesMyL, myWorksheet, AltoGrilla + 10, 1)

               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
         '  ugeResumen.Exportar(Me.Name & "_Resumen.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFCompletoMyL_Click(sender As Object, e As EventArgs) Handles tsmiAPDFCompletoMyL.Click
      Try
         If Me.ugeResumenMyL.Rows.Count = 0 Then Exit Sub
         ugeResumen.Exportar(Me.Name & "_CompletoMyL.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
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
         If Me.ugeSoloCantidadesURBANO.Rows.Count = 0 Then Exit Sub
         ugeSoloCantidadesURBANO.Exportar(Me.Name & "_ResumenUrbano.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFInformeUrbano_Click(sender As Object, e As EventArgs) Handles tsmiAPDFInformeUrbano.Click
      Try
         If Me.ugeSoloCantidadesURBANO.Rows.Count = 0 Then Exit Sub
         ugeSoloCantidadesURBANO.Exportar(Me.Name & "_ResumenUrbano.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcelCompletoUrbano_Click(sender As Object, e As EventArgs) Handles tsmiAExcelCompletoUrbano.Click
      Try
         If Me.ugeResumen.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Me.Text

         Me.sfdExportar.FileName = Me.Name & "_CompletoUrbano.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim AltoGrilla As Integer = 5 + ugeResumenURBANO.Rows.Count
               Me.UltraGridExcelExporter1.Export(ugeResumenURBANO, myWorksheet, 2, 0)
               Me.UltraGridExcelExporter1.Export(ugeTotalesURBANO, myWorksheet, AltoGrilla, 1)
               Me.UltraGridExcelExporter1.Export(ugeTotalesMesURBANO, myWorksheet, AltoGrilla + 5, 1)
               Me.UltraGridExcelExporter1.Export(ugeDiasHabilesURBANO, myWorksheet, AltoGrilla + 10, 1)

               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
         '  ugeResumen.Exportar(Me.Name & "_Resumen.xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDFCompletoUrbano_Click(sender As Object, e As EventArgs) Handles tsmiAPDFCompletoUrbano.Click
      Try
         If Me.ugeResumenURBANO.Rows.Count = 0 Then Exit Sub
         ugeResumenURBANO.Exportar(Me.Name & "_CompletoUrbano.pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

End Class