Public Class BaseABM2

#Region "Campos"

   Protected dtDatos As DataTable
   Protected _entidad As Entidades.Entidad
   Private _preservaUltimaColumna As String
   Private _ultimaFila As Integer
   Private _preservaUltimoFiltro As String
   Private _estaCargandoPantalla As Boolean = False
   Private _lyNombre As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      If Not DesignMode Then
         Try
            _estaCargandoPantalla = True

            _lyNombre = String.Format("ly_{0}", Name)

            PreferenciasLeer(Me.dgvDatos, tsbPreferencias)

            Cursor = Cursors.WaitCursor
            ExecuteRefreshGrid()

            Traducciones.SetearControles(Me)

            dgvDatos.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

         Catch ex As Exception
            ShowError(ex)
         Finally
            _estaCargandoPantalla = False
            Cursor = Cursors.Default
         End Try
      End If
   End Sub

#End Region

#Region "Overridable"

   Protected Overridable Sub Buscar()
      TryCatched(Sub() ExecuteRefreshGrid())
      'Try
      '   Me.RefreshGrid()
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overridable Function GetDetalle(estado As StateForm) As BaseDetalle
      Return New BaseDetalle()
   End Function

   Protected Overridable Function GetReglas() As Reglas.Base
      Return New Reglas.Base()
   End Function

   Public Event BeforeRefreshGrid As EventHandler(Of CancelableEventArgs)
   Public Event AfterRefreshGrid As EventHandler

   Protected Sub ExecuteRefreshGrid()
      Dim e = New CancelableEventArgs()
      OnBeforeRefreshGrid(e)
      If Not e.Cancel Then
         RefreshGrid()
         OnAfterRefreshGrid()
      End If
   End Sub
   Protected Overridable Sub OnBeforeRefreshGrid(e As CancelableEventArgs)
      RaiseEvent BeforeRefreshGrid(Me, e)
   End Sub
   Protected Overridable Sub OnAfterRefreshGrid()
      RaiseEvent AfterRefreshGrid(Me, Nothing)
   End Sub



   Protected Overridable Sub RefreshGrid()
      Try
         Dim ordCol As String = ""
         Dim desc As Boolean = False
         ' ''reviso si tiene alguna columna con orden 
         ''If Me.dgvDatos.DisplayLayout.Bands(0).HasSortedColumns Then
         ''   ordCol = Me.dgvDatos.DisplayLayout.Bands(0).SortedColumns(0).Key
         ''   If Me.dgvDatos.DisplayLayout.Bands(0).SortedColumns(0).SortIndicator = UltraWinGrid.SortIndicator.Descending Then
         ''      desc = True
         ''   End If
         ''End If

         If Not Me._estaCargandoPantalla Then
            'grabo el layout de la grilla
            Me.dgvDatos.DisplayLayout.Save(Me._lyNombre)
         End If

         Me.dgvDatos.DisplayLayout.Bands(0).Reset()
         Dim rg As Reglas.Base = Me.GetReglas()

         Dim bus As Entidades.Buscar = GetBuscar()
         If bus IsNot Nothing Then
            Me.dtDatos = ProcesarDataTable(Buscar(rg, bus)) ' rg.Buscar(bus)
         Else
            Me.dtDatos = ProcesarDataTable(GetAll(rg)) ' rg.GetAll()
         End If

         Dim objToDispose As IDisposable = Nothing
         If TypeOf (dgvDatos.DataSource) Is IDisposable Then
            objToDispose = DirectCast(dgvDatos.DataSource, IDisposable)
         End If
         Me.dgvDatos.DataSource = Me.dtDatos
         If objToDispose IsNot Nothing Then
            objToDispose.Dispose()
         End If

         If Not Me.dtDatos Is Nothing Then
            Me.FormatearGrilla()
            If Me._estaCargandoPantalla Then
               Me.dgvDatos.DisplayLayout.Save(Me._lyNombre)
            End If
         End If
         Me.CargarComboColumnas()
         Me.ActualizarInfoRegistros()

         'leo siempre el layout para dejarlo igual
         If System.IO.File.Exists(Me._lyNombre) Then
            Me.dgvDatos.DisplayLayout.Load(Me._lyNombre)
         End If

         Me.PreferenciasLeer(Me.dgvDatos, tsbPreferencias)

         If Me.dgvDatos.Rows.Count > 0 Then
            If Me.dgvDatos.Rows.Count - 1 >= Me._ultimaFila Then
               Me.dgvDatos.ActiveRow = Me.dgvDatos.Rows.GetRowWithListIndex(Me._ultimaFila) '' Me.dgvDatos.Rows(Me._ultimaFila)
            Else
               Me.dgvDatos.ActiveRow = Me.dgvDatos.Rows(Me.dgvDatos.Rows.Count - 1)
            End If
            If Me.dgvDatos.ActiveRow IsNot Nothing AndAlso dgvDatos.ActiveRow.Cells IsNot Nothing AndAlso tstColumnas.ComboBox.SelectedValue IsNot Nothing Then
               Me.dgvDatos.ActiveRow.Cells(Me.tstColumnas.ComboBox.SelectedValue.ToString()).Selected = True
               ''Me.dgvDatos.ActiveRow.Selected = True
            End If

            '' ''codigo nuevo!
            ''If Not String.IsNullOrEmpty(ordCol) Then
            ''   Me.dgvDatos.DisplayLayout.Bands(0).SortedColumns.Add(ordCol, desc, False)
            ''End If
            ''If Me.dgvDatos.ActiveRow IsNot Nothing Then
            ''   Me.dgvDatos.ActiveRow.Activate()
            ''End If
         End If


         For Each dr As UltraWinGrid.UltraGridRow In Me.dgvDatos.Rows
            dr.Activation = UltraWinGrid.Activation.NoEdit
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Function GetBuscar() As Entidades.Buscar
      Dim bus As Entidades.Buscar = Nothing
      If Not String.IsNullOrEmpty(Me.tstBuscar.Text.Trim()) Then
         If tstColumnas.ComboBox.SelectedValue Is Nothing Then
            If tstColumnas.ComboBox.Items.Count = 0 Then
               Me.CargarComboColumnas()
            End If
            If tstColumnas.ComboBox.Items.Count = 0 Then
               Throw New Exception("No se ha podido recuperar la información para el filtro. Por favor cierre y vuelva a abrir la pantalla.")
            End If
            tstColumnas.ComboBox.SelectedIndex = 0
         End If
         bus = New Entidades.Buscar()
         Me._preservaUltimoFiltro = Me.tstColumnas.ComboBox.SelectedValue.ToString()
         bus.Columna = Me.tstColumnas.ComboBox.SelectedValue.ToString()
         bus.Valor = Me.tstBuscar.Text.Trim()
      End If
      Return bus
   End Function

   Protected Overridable Function GetAll(rg As Reglas.Base) As DataTable
      Return rg.GetAll()
   End Function

   Protected Overridable Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return rg.Buscar(bus)
   End Function

   Protected Overridable Function ProcesarDataTable(dt As DataTable) As DataTable
      Return dt
   End Function

   Protected Overridable Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            Me._entidad = Me.GetEntidad()
            If Not ValidaBorrado(_entidad) Then Exit Sub
            If ConfirmarBorrado() = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = Me.GetReglas()
               If Not String.IsNullOrEmpty(Me._preservaUltimoFiltro) Then
                  Me.tstColumnas.ComboBox.SelectedValue = Me._preservaUltimoFiltro
               End If
               cl.Borrar(Me._entidad)
               If Not String.IsNullOrEmpty(Me._preservaUltimoFiltro) Then
                  Me.tstColumnas.ComboBox.SelectedValue = Me._preservaUltimaColumna
               End If

               ExecuteRefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overridable Function ConfirmarBorrado() As DialogResult
      Return ShowPregunta("¿Está seguro de eliminar el registro seleccionado?")
   End Function

   Protected Overridable Function GetEntidad() As Entidades.Entidad
      If Me.dgvDatos.ActiveCell Is Nothing Then
         If Me.dgvDatos.ActiveRow IsNot Nothing Then
            Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
         End If
      End If
      If Me.dgvDatos.ActiveCell IsNot Nothing Then
         Me._ultimaFila = Me.dgvDatos.ActiveCell.Row.ListIndex
      End If
      Return GetEntidad(dgvDatos.ActiveRow)
   End Function
   Protected Overridable Function GetEntidad(filaGrilla As UltraGridRow) As Entidades.Entidad
      Return GetEntidad(filaGrilla.FilaSeleccionada(Of DataRow))
   End Function
   Protected Overridable Function GetEntidad(drFilaGrilla As DataRow) As Entidades.Entidad
      Return New Entidades.Entidad()
   End Function

   Protected Overridable Sub Copiar()
      Try
         'If Me.dgvDatos.Rows.Count = 0 Then Exit Sub
         If dgvDatos.ActiveRow Is Nothing OrElse dgvDatos.ActiveRow.ListObject Is Nothing Then Exit Sub

         Using frm As BaseDetalle = Me.GetDetalle(StateForm.Actualizar)
            frm.StateForm = StateForm.Insertar
            If TypeOf (frm) Is IConIdFuncion Then
               DirectCast(frm, IConIdFuncion).IdFuncion = IdFuncion
            End If
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrEmpty(Me._preservaUltimoFiltro) Then
                  Me.tstColumnas.ComboBox.SelectedValue = Me._preservaUltimoFiltro
               End If
               ExecuteRefreshGrid()
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overridable Sub Editar()
      Try
         If Me.dgvDatos.Rows.Count = 0 Then Exit Sub
         If dgvDatos.ActiveRow Is Nothing OrElse dgvDatos.ActiveRow.ListObject Is Nothing Then Exit Sub
         Dim frm As BaseDetalle = Me.GetDetalle(StateForm.Actualizar)
         frm.StateForm = StateForm.Actualizar
         If TypeOf (frm) Is IConIdFuncion Then
            DirectCast(frm, IConIdFuncion).IdFuncion = IdFuncion
         End If
         If Not tsbEditar.Enabled Or Not tsbEditar.Visible Then
            frm.StateForm = StateForm.Consultar
         End If
         Dim dResult = AbrirFormularioEditar(frm)
         If dResult = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me._preservaUltimoFiltro) Then
               Me.tstColumnas.ComboBox.SelectedValue = Me._preservaUltimoFiltro
            End If
            ExecuteRefreshGrid()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Function AbrirFormularioEditar(detalle As BaseDetalle) As Windows.Forms.DialogResult
      Return detalle.ShowDialog()
   End Function

   Protected Overridable Sub AbrirFormularioNuevo(detalle As BaseDetalle)
      detalle.ShowDialog()
   End Sub

   Protected Overridable Sub Nuevo()
      Dim detalle As BaseDetalle = Me.GetDetalle(StateForm.Insertar)
      detalle.StateForm = StateForm.Insertar
      If TypeOf (detalle) Is IConIdFuncion Then
         DirectCast(detalle, IConIdFuncion).IdFuncion = IdFuncion
      End If
      AbrirFormularioNuevo(detalle)
      If Not String.IsNullOrEmpty(Me._preservaUltimoFiltro) Then
         Me.tstColumnas.ComboBox.SelectedValue = Me._preservaUltimoFiltro
      End If
      ExecuteRefreshGrid()
   End Sub

   Protected Overridable Sub Imprimir()
   End Sub

   Protected Overridable Sub FormatearGrilla()
   End Sub

#End Region

#Region "Propiedades"

   Public ReadOnly Property BotonImprimir() As ToolStripButton
      Get
         Return Me.tsbImprimir
      End Get
   End Property

#End Region

#Region "Metodos"

   Private Sub CargarComboColumnas()
      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Nombre", System.Type.GetType("System.String"))
      dt.Columns.Add("Key", System.Type.GetType("System.String"))
      Dim dr As DataRow
      For Each cl As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.dgvDatos.DisplayLayout.Bands(0).Columns
         'Si la columna no esta ocula la agrego como filtro (para evitar los IDs).
         If Not cl.Hidden Then
            dr = dt.NewRow()
            dr("Nombre") = cl.Header.Caption  'Columna
            dr("Key") = cl.Key         'Key
            dt.Rows.Add(dr)
         End If
         cl.CellActivation = UltraWinGrid.Activation.ActivateOnly
      Next
      Me.tstColumnas.ComboBox.DataSource = dt
      Me.tstColumnas.ComboBox.DisplayMember = "Nombre"
      Me.tstColumnas.ComboBox.ValueMember = "Key"
      If Not String.IsNullOrEmpty(Me._preservaUltimaColumna) Then
         Me.tstColumnas.ComboBox.SelectedValue = Me._preservaUltimaColumna
      End If
   End Sub

   Private Sub ActualizarInfoRegistros()
      tssRegistros.Text = dgvDatos.CantidadRegistrosParaStatusbar()
   End Sub

   Protected Sub MuestraExportacionImpresion(visible As Boolean)
      Me.tsddExportar.Visible = visible
      Me.tsbImprimir.Visible = visible
      Me.tsbPrePrint.Visible = visible
      Me.tsbImprimirDirecto.Visible = visible
   End Sub

   Protected Sub SetCopiarVisible(visible As Boolean)
      tsbCopiar.Visible = visible
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbVistaEspecial_Click(sender As Object, e As EventArgs) Handles tsbVistaEspecial.Click
      Me.dgvDatos.DisplayLayout.Bands(0).CardView = Not Me.dgvDatos.DisplayLayout.Bands(0).CardView
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Me.PreferenciasCargar(Me.dgvDatos, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPrePrint_Click(sender As Object, e As EventArgs) Handles tsbPrePrint.Click
      Try
         Dim pre As PreGridPrint = New PreGridPrint(Me.dgvDatos, Me.dtDatos, Me.Text, "")
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      Try
         Me.Nuevo()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbBorrar_Click(sender As Object, e As EventArgs) Handles tsbBorrar.Click
      Me.Borrar()
   End Sub

   Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
      TryCatched(Sub() Editar())
   End Sub

   Private Sub tsbCopiar_Click(sender As Object, e As EventArgs) Handles tsbCopiar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Copiar()
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub


   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Me.Cursor = Cursors.WaitCursor
      Me.Imprimir()
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub tsbBuscar_Click(sender As Object, e As EventArgs)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Buscar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbRefresh_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         LimpiarFiltros()
         Me._preservaUltimaColumna = ""
         Me._ultimaFila = 0
         ExecuteRefreshGrid()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Protected Overridable Sub LimpiarFiltros()
      Me.tstBuscar.Text = String.Empty
      Me.tstBuscar.Tag = Nothing
   End Sub

   'Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs)
   '   If Me.dgvDatos.ActiveCell IsNot Nothing Then
   '      Me.Cursor = Cursors.WaitCursor
   '      Me.Editar()
   '      Me.Cursor = Cursors.Default
   '   End If
   'End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   'Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
   '   Me.Editar()
   'End Sub

   Private Sub BaseABM_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefresh_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub dgvDatos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles dgvDatos.DoubleClickCell
      tsbEditar.PerformClick()
   End Sub

   Private Sub tsbFiltrar_Click(sender As Object, e As EventArgs) Handles tsbFiltrar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.tstColumnas.ComboBox.SelectedValue IsNot Nothing Then
            Me._preservaUltimaColumna = Me.tstColumnas.ComboBox.SelectedValue.ToString()
         Else
            Me._preservaUltimaColumna = ""
         End If
         Me.Buscar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tstBuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles tstBuscar.KeyUp
      If e.KeyCode = Keys.Enter Then
         Me.tsbFiltrar.PerformClick()
      End If
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         dgvDatos.Exportar(String.Format("{0}.xls", Me.Name), Me.Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
         'Dim nombreWS As String = Me.Text
         'Me.sfdExportar.FileName = Me.Name & ".xls"
         'Me.sfdExportar.Filter = "Archivos excel|*.xls"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Dim wb As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook(Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
         '      wb.Worksheets.Add(nombreWS)
         '      wb.Worksheets(nombreWS).Rows(0).Cells(0).Value = Me.Text
         '      Me.UltraGridExcelExporter1.Export(Me.dgvDatos, wb.Worksheets(nombreWS), 2, 0)
         '      wb.Save(Me.sfdExportar.FileName)
         '   End If
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overridable Function CargarFiltrosImpresion() As String
      If Not String.IsNullOrWhiteSpace(tstBuscar.Text) And tstColumnas.SelectedIndex > -1 Then
         Return String.Format("{0}: {1}", tstColumnas.Text, tstBuscar.Text)
      End If
      Return String.Empty
   End Function

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         dgvDatos.Exportar(String.Format("{0}.pdf", Me.Name), Me.Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
         'Me.sfdExportar.FileName = Me.Name & ".pdf"
         'Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridDocumentExporter1.Export(Me.dgvDatos, Me.sfdExportar.FileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF)
         '   End If
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dgvDatos_AfterCellActivate(sender As Object, e As EventArgs) Handles dgvDatos.AfterCellActivate
      Try
         Me.tstColumnas.ComboBox.SelectedValue = Me.dgvDatos.ActiveCell.Column.Key
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDatos_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles dgvDatos.AfterRowFilterChanged
      Try
         Me.ActualizarInfoRegistros()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   Private Sub tsbImprimirDirecto_Click(sender As Object, e As EventArgs) Handles tsbImprimirDirecto.Click
      Try
         Me.uppPrint.Document = Me.ugpDocumento
         Me.ugpDocumento.Header.TextLeft = Me.Text
         Me.ugpDocumento.Header.TextRight = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
         Me.ugpDocumento.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
         Me.ugpDocumento.Header.Appearance.FontData.SizeInPoints = 8
         ugpDocumento.InicializaDocumento()

         Me.uppPrint.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Function ValidaBorrado(entidad As Entidades.Entidad) As Boolean
      Return True
   End Function


End Class