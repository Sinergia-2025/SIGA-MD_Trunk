#Region "Option/Imports"
'Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class InformeProductosExcepciones

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _dtProductosExcepciones As DataTable
   Private _PermisoEjecucion As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _publicos.CargaComboTiposListasControl(cmbTipoListaControl)
         'cmbTipoListaControl.SelectedIndex = -1

         _publicos.CargaComboTiposExcepciones(cmbTiposExcepciones)

         _publicos.CargaComboUsuarios(cmbSolicitante)

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "IdProducto", "CodigoCliente", "NombreCliente", "NombreListaControl", "NombreEstadoCalidad"})

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

#Region "Eventos Buscadores"

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

         If chbDesvio.Checked AndAlso (Not bscExcepcion2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Desvío aunque activó ese Filtro.")
            bscExcepcion2.Focus()
            Exit Sub
         End If

         If chbDpto.Checked AndAlso cmbDpto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Departamento aunque activó ese Filtro.")
            cmbDpto.Focus()
            Exit Sub
         End If

         If chbSeccion.Checked AndAlso cmbTipoListaControl.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Sección aunque activó ese Filtro.")
            cmbTipoListaControl.Focus()
            Exit Sub
         End If

         If ChbTipo.Checked AndAlso cmbTiposExcepciones.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Tipo aunque activó ese Filtro.")
            cmbTiposExcepciones.Focus()
            Exit Sub
         End If

         If chbSolicitante.Checked AndAlso cmbSolicitante.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Solicitante aunque activó ese Filtro.")
            cmbSolicitante.Focus()
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


   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscExcepcion2_BuscadorClick() Handles bscExcepcion2.BuscadorClick
      Try
         Dim oExecepciones As Reglas.Excepciones = New Reglas.Excepciones
         Me._publicos.PreparaGrillaExcepciones(Me.bscExcepcion2)
         Dim Seccion As Integer = 0
         Dim TipoExcepcion As Integer = 0
         If Me.cmbTipoListaControl.SelectedIndex <> -1 Then
            Seccion = Integer.Parse(Me.cmbTipoListaControl.SelectedValue.ToString())
         End If
         If Me.cmbTiposExcepciones.SelectedIndex <> -1 Then
            TipoExcepcion = Integer.Parse(Me.cmbTiposExcepciones.SelectedValue.ToString())
         End If
         Me.bscExcepcion2.Datos = oExecepciones.GetExcepciones(Seccion, TipoExcepcion)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscExcepcion2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscExcepcion2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosExcepcion(e.FilaDevuelta, Me.bscExcepcion2)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbSeccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbSeccion.CheckedChanged
      Try
         Me.cmbTipoListaControl.Enabled = Me.chbSeccion.Checked
         If Not Me.chbSeccion.Checked Then
            Me.cmbTipoListaControl.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarGrilla()

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbDesvio.Checked = False
      Me.chbDpto.Checked = False
      Me.chbProducto.Checked = False
      Me.chbSeccion.Checked = False
      Me.chbSolicitante.Checked = False
      Me.ChbTipo.Checked = False

      Me.tssRegistros.Text = "0 Registros"

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargarGrillaDetalle()

      Dim Excepcion As Integer = 0
      Dim Seccion As Integer = 0
      Dim Tipo As Integer = 0
      Dim Responsable As String = String.Empty

      If bscExcepcion2.Selecciono Then
         Excepcion = Integer.Parse(bscExcepcion2.Text.ToString())
      End If

      If chbSeccion.Checked Then
         Seccion = Integer.Parse(cmbTipoListaControl.SelectedValue.ToString())
      End If

      If ChbTipo.Checked Then
         Tipo = Integer.Parse(cmbTiposExcepciones.SelectedValue.ToString())
      End If

      If chbSolicitante.Checked Then
         Responsable = cmbSolicitante.SelectedValue.ToString()
      End If


      _dtProductosExcepciones = New Reglas.ProductosExcepciones().GetListasControlInforme(Me.bscCodigoProducto2.Text, Responsable,
                                                                        dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha), Excepcion,
                                                                        Seccion, Tipo, cmbDpto.Text.ToString())

      Me.ugDetalle.DataSource = _dtProductosExcepciones


      If ugDetalle.Rows.Count > 0 Then
         Me.btnConsultar.Focus()

      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub


   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         '.AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         'If Me.chbProducto.Checked Then
         '   .AppendFormat(" Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         'End If

         'If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
         '   .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         'End If


         'If Me.cmbEstadoCalidad.SelectedIndex >= 0 Then
         '   .AppendFormat(" Estado: {0}", Me.cmbEstadoCalidad.Text.ToString())
         'End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub chbModelo_CheckedChanged(sender As Object, e As EventArgs)

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub
   Private Sub CargarDatosExcepcion(ByVal dr As DataGridViewRow, buscador As Eniac.Controles.Buscador2)
      buscador.Text = dr.Cells("IdExcepcion").Value.ToString()
      buscador.Tag = dr.Cells("IdExcepcion").Value.ToString.Trim()
      Me.cmbTipoListaControl.SelectedValue = Integer.Parse(dr.Cells("IdListaControlTipo").Value.ToString())
      Me.cmbTiposExcepciones.SelectedValue = Integer.Parse(dr.Cells("IdExcepcionTipo").Value.ToString())

   End Sub

   Private Sub chbDpto_CheckedChanged(sender As Object, e As EventArgs) Handles chbDpto.CheckedChanged
      Try
         Me.cmbDpto.Enabled = Me.chbDpto.Checked
         If Not Me.chbDpto.Checked Then
            Me.cmbDpto.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ChbTipo_CheckedChanged(sender As Object, e As EventArgs) Handles ChbTipo.CheckedChanged
      Try
         Me.cmbTiposExcepciones.Enabled = Me.ChbTipo.Checked
         If Not Me.ChbTipo.Checked Then
            Me.cmbTiposExcepciones.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbSolicitante_CheckedChanged(sender As Object, e As EventArgs) Handles chbSolicitante.CheckedChanged
      Try
         Me.cmbSolicitante.Enabled = Me.chbSolicitante.Checked
         If Not Me.chbSolicitante.Checked Then
            Me.cmbSolicitante.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbDesvio_CheckedChanged(sender As Object, e As EventArgs) Handles chbDesvio.CheckedChanged
      Try
         Me.bscExcepcion2.Enabled = Me.chbDesvio.Checked
         If Not Me.chbDesvio.Checked Then
            Me.bscExcepcion2.Text = String.Empty
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub()
                    chbMesCompleto.Enabled = chbFecha.Checked
                    dtpDesde.Enabled = chbFecha.Checked
                    dtpHasta.Enabled = chbFecha.Checked
                 End Sub)
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
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

End Class