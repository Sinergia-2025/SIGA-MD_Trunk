Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfFormulas

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         Me.ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto", "IdProductoComponente", "NombreComponente", "Nombremarca", "NombreRubro", "NombreMarcaComponente", "NombreRubroComponente"})

         Me.PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfFormulas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtro:"

         If Me.chbProducto.Checked Then
                Filtros = Filtros & " Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
            End If

            Dim Titulo As String

            Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

            Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
            UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
            UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Me.Text

            Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
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
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
        Try
            Me.sfdExportar.FileName = Me.Name & ".xls"
            Me.sfdExportar.Filter = "Archivos excel|*.xls"
            If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                    Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
        Try
            Me.sfdExportar.FileName = Me.Name & ".pdf"
            Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
            If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                    Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
        Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

        Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked

        Me.bscProducto2.Enabled = Me.chbProducto.Checked

        'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
        If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
        Else
            Me.bscCodigoProducto2.Focus()
        End If

    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarDatosProducto(e.FilaDevuelta)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
            Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarDatosProducto(e.FilaDevuelta)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

            If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
                MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoProducto2.Focus()
                Exit Sub
            End If

         If Me.chbComponente.Checked And Not Me.bscCodigoComponente.Selecciono And Not Me.bscComponente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Componente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoComponente.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
            Me.chkExpandAll.Checked = False

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
                Me.btnConsultar.Focus()
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
            Me.tssRegistros.Text = "0 Registros"
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
        If chkExpandAll.Checked Then
            Me.ugDetalle.Rows.ExpandAll(True)
        Else
            Me.ugDetalle.Rows.CollapseAll(True)
        End If
    End Sub

#End Region

#Region "Metodos"

    Private Sub Refrescar()

        Me.chbProducto.Checked = False

        Me.chkExpandAll.Checked = False
        Me.chkExpandAll.Enabled = False

        If Not Me.ugDetalle.DataSource Is Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
        End If
      chbComponente.Checked = False
      rbtProducto.Checked = True
      cmbMarcas.Refrescar()
      cmbRubros.Refrescar()

      Me.btnConsultar.Focus()

    End Sub

    Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)

        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False

    End Sub

    Private Sub CargaGrillaDetalle()

        Try

         Dim IdProducto As String = String.Empty
         Dim IdProductoComponente As String = String.Empty

         If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text.Trim()
         End If

         If Me.chbComponente.Checked Then
            IdProductoComponente = Me.bscCodigoComponente.Text.Trim()
         End If

         Dim reg As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

            Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = reg.GetInforme(actual.Sucursal.IdSucursal, IdProducto, 0, 0, IdProductoComponente, rbtProducto.Checked, cmbMarcas.GetMarcas(True),
                                    cmbRubros.GetRubros(True))

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("NombreMarca") = dr("NombreMarca").ToString()
            drCl("NombreRubro") = dr("NombreRubro").ToString()
            drCl("IdFormula") = Integer.Parse(dr("IdFormula").ToString())
            drCl("NombreFormula") = dr("NombreFormula").ToString()
            drCl("IdProductoComponente") = dr("IdProductoComponente").ToString()
            drCl("NombreComponente") = dr("NombreComponente").ToString()
            drCl("NombreMarcaComponente") = dr("NombreMarcaComponente").ToString()
            drCl("NombreRubroComponente") = dr("NombreRubroComponente").ToString()
            drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

            'Me.tsbImprimir.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function CrearDT() As DataTable

        Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("IdFormula", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreFormula", System.Type.GetType("System.String"))
         .Columns.Add("IdProductoComponente", System.Type.GetType("System.String"))
         .Columns.Add("NombreComponente", System.Type.GetType("System.String"))
         .Columns.Add("NombreMarcaComponente", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubroComponente", System.Type.GetType("System.String"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

    End Function

   Private Sub chbComponente_CheckedChanged(sender As Object, e As EventArgs) Handles chbComponente.CheckedChanged
      Me.bscCodigoComponente.Enabled = Me.chbComponente.Checked

      Me.bscComponente.Enabled = Me.chbComponente.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbComponente.Checked Then
         Me.bscCodigoComponente.Text = String.Empty
         Me.bscComponente.Text = String.Empty
      Else
         Me.bscCodigoComponente.Focus()
      End If
   End Sub

   Private Sub bscCodigoComponente_BuscadorClick() Handles bscCodigoComponente.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoComponente)
         Me.bscCodigoComponente.Datos = oProductos.GetPorCodigo(Me.bscCodigoComponente.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoComponente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoComponente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosComponente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscComponente_BuscadorClick() Handles bscComponente.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscComponente)
         Me.bscComponente.Datos = oProductos.GetPorNombre(Me.bscComponente.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscComponente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscComponente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosComponente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatosComponente(ByVal dr As DataGridViewRow)

      Me.bscComponente.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoComponente.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscComponente.Enabled = False
      Me.bscCodigoComponente.Enabled = False

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class