#Region "Option/Imports"
'Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class InformeAuditoriaListasControl

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _dtDetalle As DataTable
   Private _dtListasDetalle As DataTable
   Private _dtItemsDetalle As DataTable
   Private _dtsMaster_detalle As DataSet
   Private _dtItemsListasControlAuditoria As DataTable
   Private _PermisoEjecucion As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         '_tit = GetColumnasVisiblesGrilla(ugDetalle)
         '_tit1 = GetColumnasVisiblesGrilla(ugDetalle)

         Me._publicos = New Publicos()

         _publicos.CargaComboListasControl(cmbListasControl)
         Me.cmbListasControl.SelectedIndex = -1

         _publicos.CargaComboEstadosCalidad(cmbEstadoCalidad)
         Me.dtpDesde.Value = DateTime.Today

         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "NombreCliente", "NombreListaControl", "NombreListaControlItem"})

         ugDetalle.ContextMenuStrip = MenuContext

         PreferenciasLeer(ugDetalle, tsbPreferencias)

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

   Private Sub chbExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbExpandAll.CheckedChanged
      If Me.chbExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

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

#End Region

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp
         Else
            Me.dtpDesde.Value = DateTime.Today

            Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Me.ListasControlPorProducto()
   End Sub

   Private Sub MenuContext_Click(sender As Object, e As EventArgs) Handles MenuContext.Click
      Me.ListasControlPorProducto()
   End Sub

   Private Sub ChbListasControl_CheckedChanged(sender As Object, e As EventArgs) Handles ChbListasControl.CheckedChanged
      Try
         Me.cmbListasControl.Enabled = Me.ChbListasControl.Checked
         If Not Me.ChbListasControl.Checked Then
            Me.cmbListasControl.SelectedIndex = -1
         Else
            If Me.cmbListasControl.Items.Count > 0 Then
               Me.cmbListasControl.SelectedIndex = 0
            End If
            Me.cmbListasControl.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
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

#Region "Metodos"
   Private Sub CargarItemsListasControlAuditoria(tablaVacia As Boolean)
      ' If Not Me._cargandoPantalla Then
      _dtItemsListasControlAuditoria = New Reglas.ListasControlProductosItems().GetListasControlxProducto_Auditoria("")
      bdItemsListasControlAuditoria.DataSource = _dtItemsListasControlAuditoria
      ' End If
   End Sub
   Private Sub RefrescarGrilla()

      Me.chbProducto.Checked = False
      Me.chbCliente.Checked = False
      Me.chbEstado.Checked = False

      Me.dtpDesde.Value = DateTime.Today

      Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chkMesCompleto.Checked = False

      Me.chbFechaEntregado.Checked = False
      Me.chbFechaLiberado.Checked = False
      Me.ChbListasControl.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Me._dtItemsDetalle IsNot Nothing Then
         If Me._dtItemsListasControlAuditoria.Rows.Count <> 0 Then
            Me._dtItemsListasControlAuditoria.Clear()
         End If
      End If

      Me.tssRegistros.Text = "0 Registros"

      Me.btnConsultar.Focus()
   End Sub

   Private Sub CargarGrillaDetalle()


      Dim ListaControl As Integer = 0
      Dim IdEstado As Integer = 0
      Dim Ubicacion As String = String.Empty

      If ChbListasControl.Checked Then
         ListaControl = Integer.Parse(cmbListasControl.SelectedValue.ToString())
      End If

      If chbEstado.Checked Then
         IdEstado = Integer.Parse(cmbEstadoCalidad.SelectedValue.ToString())
      End If


      _dtItemsDetalle = New Reglas.ListasControlProductos().GetListasControlxProductoPendientesAuditoria(If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                                               dtpDesde.Value, dtpHasta.Value, ListaControl,
                                                                                                chbFechaLiberado.Checked, chbFechaEntregado.Checked,
                                                                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L),
                                                                                                IdEstado)

      Me.ugDetalle.DataSource = _dtItemsDetalle


      Dim color As Color = SystemColors.Control
      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         If IsNumeric(dr.Cells("Color").Value) Then
            color = Drawing.Color.FromArgb(Integer.Parse(dr.Cells("Color").Value.ToString()))
            dr.Cells("NombreEstadoCalidad").Appearance.BackColor = color
            dr.Cells("NombreEstadoCalidad").ActiveAppearance.BackColor = color
            dr.Cells("NombreEstadoCalidad").ActiveAppearance.ForeColor = Drawing.Color.Black
         End If
      Next

      If ugDetalle.Rows.Count > 0 Then
         Me.btnConsultar.Focus()

      Else
         Me.Cursor = Cursors.Default

         'If Me._dtItemsDetalle IsNot Nothing Then
         '   If Me._dtItemsListasControlAuditoria.Rows.Count <> 0 Then
         '      Me._dtItemsListasControlAuditoria.Clear()
         '   End If
         'End If

         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")

         Exit Sub
      End If

      Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

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

         If Me.cmbListasControl.SelectedIndex >= 0 Then
            .AppendFormat(" Lista de Control: {0} - ", Me.cmbListasControl.Text.ToString())
         End If

         If Me.cmbEstadoCalidad.SelectedIndex >= 0 Then
            .AppendFormat(" Estado: {0}", Me.cmbEstadoCalidad.Text.ToString())
         End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub ColorEstados(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)
      Dim ColorEstado As Integer
      Dim color As Color = SystemColors.Control
      For Each dr As UltraGridRow In ugDetalle.Rows

         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString()) Then
               ColorEstado = New Reglas.EstadosListasControl().GetEstadoColorPorNombre(dr.Cells(drColumnas("NombreColumma").ToString()).Value.ToString())
               color = Drawing.Color.FromArgb(ColorEstado)
               dr.Cells(drColumnas("NombreColumma").ToString()).Appearance.BackColor = color
            End If
         Next
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

   'Public Sub CargaAuditoriasItems()
   '   ugDetalle.Enabled = ugDetalle.ActiveRow.ListObject IsNot Nothing

   '   If ugDetalle.ActiveRow IsNot Nothing AndAlso ugDetalle.ActiveRow IsNot Nothing AndAlso
   '       TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView Then
   '      Dim drLista As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row


   '      ugDetalle.DataSource = New DataView(_dtItemsListasControlAuditoria,
   '                                                  String.Format("{0} = {1}", Entidades.ListaControlProductoItem.Columnas.IdListaControlItem.ToString(), drLista(Entidades.ListaControlProductoItem.Columnas.IdListaControlItem.ToString())),
   '                                                                "", DataViewRowState.CurrentRows)

   '      Me.FormateaGrillaListasControlItemsAuditoria()

   '   End If

   'End Sub

   'Private Sub FormateaGrillaListasControlItemsAuditoria()
   '   FormateaGrillaListasControlItemsAuditoria(Me.ugDetalle)
   'End Sub

   Private Sub FormateaGrillaListasControlAuditoria(grilla As UltraGrid)
      Dim col As Integer = 0
      '  Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControlItem"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FechaAuditoria"), "Fecha Mod.", col, 100, , , "dd/MM/yyyy HH:mm")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("UsuarioAuditoria"), "Usuario", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("OperacionAuditoria"), "Operación", col, 80)

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreEstadoCalidad"), "Estado", col, 84)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70, , True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Lista de Control", col, 300)
         '   Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 60, HAlign.Right)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Aplica.ToString()), "Aplica", col, 60)
         '.Columns(Entidades.ListaControlProducto.Columnas.Aplica.ToString()).Style = ColumnStyle.CheckBox

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()), "Ingreso", col, 80)
         .Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).CellActivation = Activation.AllowEdit
         .Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).Style = ColumnStyle.DropDownCalendar

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()), "Egreso", col, 80)
         .Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).CellActivation = Activation.AllowEdit
         .Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).Style = ColumnStyle.DropDownCalendar

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoS.ToString()), "5S Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSUsr.ToString()), "5S Usuario Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString()), "5S Fecha Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSC.ToString()), "5S Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString()), "5S Usuario Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString()), "5S Fecha Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSCommentC.ToString()), "5S Comentario Calidad", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSComment.ToString()), "5S Comentario Producción", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Observacion.ToString()), "Observación", col, 300)

      End With
   End Sub


#End Region


   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate

      Me.CargaAuditoriasListas()
   End Sub

   Public Sub CargaAuditoriasListas()

      Dim drLista As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()

      If drLista IsNot Nothing Then

         _dtItemsListasControlAuditoria = New Reglas.ListasControlProductos().GetListasControlxProducto_Auditoria(drLista.Field(Of String)(Entidades.ListaControlProducto.Columnas.IdProducto.ToString()))
         bdItemsListasControlAuditoria.DataSource = _dtItemsListasControlAuditoria


         ' Me.ugdItemsListasControlAuditoria.Enabled = Boolean.Parse(drLista("Hab").ToString())

         Me.ugdItemsListasControlAuditoria.DataSource = New DataView(_dtItemsListasControlAuditoria,
                                                     String.Format("{0} = {1} AND {2} = '{3}' AND {4} = {5}", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), drLista(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()),
                                                     Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), drLista(Entidades.ListaControlProducto.Columnas.IdProducto.ToString()), Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                                     drLista(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString())),
                                                                    "", DataViewRowState.CurrentRows)

         Me.FormateaGrillaListasControlAuditoria()

      End If

   End Sub
   Private Sub FormateaGrillaListasControlAuditoria()
      FormateaGrillaListasControlAuditoria(Me.ugdItemsListasControlAuditoria)
   End Sub

   Public Enum ListasControlItems
      Ok
      NoOk
      Obs
      Mat
      NA
   End Enum

End Class