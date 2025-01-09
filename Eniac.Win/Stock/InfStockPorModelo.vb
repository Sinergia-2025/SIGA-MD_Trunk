#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class InfStockPorModelo

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         cmbSucursales.Initializar(False, True, True, IdFuncion)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         ugDetalle.AgregarFiltroEnLinea({"NombreSucursal", "NombreRubro"})
         ugDetalle.InicializaTotales()

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If chbProducto.Checked AndAlso (Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbMarca.Checked AndAlso cmbMarca.SelectedIndex < 0 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.")
            cmbMarca.Focus()
            Exit Sub
         End If

         If chbRubro.Checked AndAlso cmbRubro.SelectedIndex < 0 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.")
            cmbRubro.Focus()
            Exit Sub
         End If

         If chbSubRubro.Checked AndAlso cmbSubRubro.SelectedIndex < 0 Then
            ShowMessage("ATENCION: NO seleccionó un SubRubro aunque activó ese Filtro.")
            cmbSubRubro.Focus()
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

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If
   End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
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
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub RefrescarGrilla()
      cmbSucursales.Refrescar()

      Me.chbProducto.Checked = False
      Me.bscProducto2.Text = String.Empty
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = "0 Registros"

      Me.btnConsultar.Focus()
   End Sub

   Private Sub CargarGrillaDetalle()

      Dim pivotResult As Reglas.ProductosSucursales.GetStockPorModeloPivotInfo

      pivotResult = New Reglas.ProductosSucursales().GetStockPorModelo(cmbSucursales.GetSucursales(),
                                                                       If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                                                       If(chbMarca.Checked, Integer.Parse(cmbMarca.SelectedValue.ToString()), 0),
                                                                       If(chbRubro.Checked, Integer.Parse(cmbRubro.SelectedValue.ToString()), 0),
                                                                       If(chbSubRubro.Checked, Integer.Parse(cmbSubRubro.SelectedValue.ToString()), 0))

      ugDetalle.DataSource = pivotResult.dtResult

      Dim pos As Integer = AjustarColumnasGrilla(ugDetalle, _tit)
      With ugDetalle.DisplayLayout.Bands(0)
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            pos += 1
            .Columns(drColumnas("NombreColumma").ToString()).FormatearColumna(drColumnas("NombreModelo").ToString(), pos, 80, HAlign.Right, , "N2")
            ugDetalle.AgregarTotalSumaColumna(.Columns(drColumnas("NombreColumma").ToString()))
         Next
      End With

      If pivotResult.dtResult.Rows.Count > 0 Then
         Me.btnConsultar.Focus()
      Else
         Me.Cursor = Cursors.Default
         ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         Exit Sub
      End If

      Me.tssRegistros.Text = pivotResult.dtResult.Rows.Count.ToString() & " Registros"

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

         cmbSucursales.CargarFiltrosImpresionSucursales(filtro, True, False)

         If Me.chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            filtro.AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            filtro.AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            filtro.AppendFormat(" - SubRubro: {0}", cmbSubRubro.Text)
         End If

      End With
      Return filtro.ToString()
   End Function
#End Region

End Class