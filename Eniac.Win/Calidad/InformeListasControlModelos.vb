#Region "Option/Imports"
'Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class InformeListasControlModelos

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _dtListasModelos As DataTable
   Private _PermisoEjecucion As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _publicos.CargaComboListasControl(cmbListasControl)
         Me.cmbListasControl.SelectedIndex = -1

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
   Private Sub bscModelo2_BuscadorClick() Handles bscModelo2.BuscadorClick
      Try
         Dim oModelos As Reglas.ProductosModelos = New Reglas.ProductosModelos
         Me._publicos.PreparaGrillaModelosProductos(Me.bscModelo2)
         Me.bscModelo2.Datos = oModelos.GetPorNombre(Me.bscModelo2.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscModelo2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscModelo2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosModelo(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

         If chbModelo.Checked AndAlso (Not bscModelo2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Modelo aunque activó ese Filtro.")
            bscModelo2.Focus()
            Exit Sub
         End If

         'If chbCliente.Checked AndAlso (Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono) Then
         '   ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
         '   bscCodigoCliente.Focus()
         '   Exit Sub
         'End If

         Me.CargarGrillaDetalle()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#Region "Eventos Filtros"


#End Region

#Region "Eventos Busquedas Foraneas"

#End Region


   Private Sub chbListasControl_CheckedChanged(sender As Object, e As EventArgs) Handles chbListasControl.CheckedChanged
      Try
         Me.cmbListasControl.Enabled = Me.chbListasControl.Checked
         If Not Me.chbListasControl.Checked Then
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


#End Region

#Region "Metodos"

   Private Sub RefrescarGrilla()

      Me.chbListasControl.Checked = False

      Me.chbModelo.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = "0 Registros"

      Me.btnConsultar.Focus()
   End Sub

   Private Sub CargarGrillaDetalle()

      Dim ListaControl As Integer = 0
      Dim IdModelo As Integer = 0

      If chbListasControl.Checked Then
         ListaControl = Integer.Parse(cmbListasControl.SelectedValue.ToString())
      End If

      If chbModelo.Checked Then
         IdModelo = Integer.Parse(bscModelo2.Tag.ToString())
      End If


      _dtListasModelos = New Reglas.ListasControlModelos().GetListasControlInforme(IdModelo, ListaControl)

      Me.ugDetalle.DataSource = _dtListasModelos


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

         If Me.cmbListasControl.SelectedIndex >= 0 Then
            .AppendFormat(" Lista de Control: {0} - ", Me.cmbListasControl.Text.ToString())
         End If

         'If Me.cmbEstadoCalidad.SelectedIndex >= 0 Then
         '   .AppendFormat(" Estado: {0}", Me.cmbEstadoCalidad.Text.ToString())
         'End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub CargarDatosModelo(ByVal dr As DataGridViewRow)
      Me.bscModelo2.Text = dr.Cells("NombreProductoModelo").Value.ToString()
      Me.bscModelo2.Tag = dr.Cells("IdProductoModelo").Value.ToString.Trim()
   End Sub

   Private Sub chbModelo_CheckedChanged(sender As Object, e As EventArgs) Handles chbModelo.CheckedChanged
      Try
         Me.bscModelo2.Enabled = Me.chbModelo.Checked
         If Not Me.chbModelo.Checked Then
            Me.bscModelo2.Text = String.Empty
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub




#End Region

End Class