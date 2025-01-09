Imports System.Runtime.CompilerServices
Imports Infragistics.Win.UltraWinGrid.DocumentExport
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Namespace Extensiones
   Public Module UltraGridExtensions
      <Extension()>
      Public Function FilaSeleccionada(Of T)(ug As UltraGrid) As T
         Return FilaSeleccionada(Of T)(ug, ug.ActiveRow)
      End Function
      <Extension()>
      Public Function FilaSeleccionada(Of T)(ug As UltraGridBase, row As UltraGridRow) As T
         If row IsNot Nothing AndAlso
            row.ListObject IsNot Nothing Then
            If TypeOf (row.ListObject) Is T Then
               Return DirectCast(row.ListObject, T)
            End If
            If TypeOf (row.ListObject) Is DataRowView AndAlso
               DirectCast(row.ListObject, DataRowView).Row IsNot Nothing AndAlso
               TypeOf (DirectCast(row.ListObject, DataRowView).Row) Is T Then
               Return DirectCast(Convert.ChangeType(DirectCast(row.ListObject, DataRowView).Row, GetType(T)), T)
            End If
         End If
         Return Nothing
      End Function
      <Extension()>
      Public Function FilaSeleccionada(Of T)(row As UltraGridRow) As T
         Return row.Band.Layout.Grid.FilaSeleccionada(Of T)(row)
      End Function



      <Extension()>
      Public Function TodasLasFilas(Of T)(ug As UltraGrid) As IEnumerable(Of T)
         Dim rows = ug.Rows.GetAllNonGroupByRows()
         Return rows.ToList().ConvertAll(Function(r) r.FilaSeleccionada(Of T)).Where(Function(r) r IsNot Nothing)
      End Function
      <Extension()>
      Public Function FilasSeleccionadas(Of T)(ug As UltraGrid) As IEnumerable(Of T)
         Dim rows = ug.Selected.Rows.OfType(Of UltraGridRow)
         If rows.Count = 0 Then
            rows = ug.Selected.Cells.OfType(Of UltraGridCell).ToList().ConvertAll(Function(ugc) ugc.Row).Distinct().Where(Function(ugr) ugr IsNot Nothing)
         End If
         If rows.Count = 0 Then
            If ug.ActiveRow IsNot Nothing Then
               rows = {ug.ActiveRow}
            End If
         End If
         Return rows.ToList().ConvertAll(Function(r) r.FilaSeleccionada(Of T)).Where(Function(r) r IsNot Nothing)
      End Function
      <Extension()>
      Public Function FilasSeleccionadasOActiva(Of T)(ug As UltraGrid) As IEnumerable(Of T)
         Dim rows = ug.FilasSeleccionadas(Of T)
         If rows.Count = 0 Then
            rows = {ug.FilaSeleccionada(Of T)} '.ToList()
         End If
         Return rows.Where(Function(dr) dr IsNot Nothing).ToArray()
      End Function
      <Extension()>
      Public Function SelectIfEmpty(ug As UltraGrid) As UltraGrid
         If ug.Selected.Rows.Count = 0 Then
            ug.ActiveRow.Selected = True
         End If
         Return ug
      End Function


      <Extension()>
      Public Function Exportar(ug As IUserControlConUltraGrid, defaultFileName As String, titulo As String, ultraGridDocumentExporter As UltraGridDocumentExporter, filtro As String) As UltraGrid
         Return Exportar(ug.Grilla, defaultFileName, titulo, ultraGridDocumentExporter, filtro)
      End Function

      <Extension()>
      Public Function Exportar(ug As UltraGrid, ultraGridDocumentExporter As UltraGridDocumentExporter, filtro As String) As UltraGrid
         Dim frm = ug.FindForm()
         Return ug.Exportar(String.Format("{0}.pdf", frm.Name), frm.Text, ultraGridDocumentExporter, filtro)
      End Function
      <Extension()>
      Public Function Exportar(ug As UltraGrid, ultraGridDocumentExporter As UltraGridDocumentExporter, filtro As String, titulo As String) As UltraGrid
         Dim frm = ug.FindForm()
         Return ug.Exportar(String.Format("{0}.pdf", frm.Name), titulo, ultraGridDocumentExporter, filtro)
      End Function

      <Extension()>
      Public Function Exportar(ug As UltraGrid, defaultFileName As String, titulo As String, ultraGridDocumentExporter As UltraGridDocumentExporter, filtro As String) As UltraGrid
         Dim exp As UltraGridExportarPDF = New UltraGridExportarPDF(ultraGridDocumentExporter, Reglas.Publicos.NombreEmpresa)
         exp.Exportar(defaultFileName, titulo, ug, filtro)
         Return ug
      End Function

      <Extension()>
      Public Function Exportar(ug As IUserControlConUltraGrid, defaultFileName As String, titulo As String, ultraGridDocumentExporter As UltraGridExcelExporter, filtro As String) As UltraGrid
         Return Exportar(ug.Grilla, defaultFileName, titulo, ultraGridDocumentExporter, filtro)
      End Function

      <Extension()>
      Public Function Exportar(ug As UltraGrid, ultraGridDocumentExporter As UltraGridExcelExporter, filtro As String) As UltraGrid
         Dim frm = ug.FindForm()
         Return ug.Exportar(String.Format("{0}.xls", frm.Name), frm.Text, ultraGridDocumentExporter, filtro)
      End Function
      <Extension()>
      Public Function Exportar(ug As UltraGrid, ultraGridDocumentExporter As UltraGridExcelExporter, titulo As String, filtro As String) As UltraGrid
         Dim frm = ug.FindForm()
         Return ug.Exportar(String.Format("{0}.xls", frm.Name), titulo, ultraGridDocumentExporter, filtro)
      End Function

      <Extension()>
      Public Function Exportar(ug As UltraGrid, defaultFileName As String, titulo As String, ultraGridDocumentExporter As UltraGridExcelExporter, filtro As String) As UltraGrid
         Dim exp As UltraGridExportarExcel = New UltraGridExportarExcel(ultraGridDocumentExporter, Reglas.Publicos.NombreEmpresa)
         exp.Exportar(defaultFileName, titulo, ug, filtro)
         Return ug
      End Function

      <Extension()>
      Public Function Imprimir(ug As UltraGrid, titulo As String, filtro As String) As UltraGrid
         Return ug.Imprimir(titulo, filtro, New ImprimirUltraGridParams())
      End Function

      <Extension()>
      Public Function Imprimir(ug As UltraGrid, filtro As String, params As ImprimirUltraGridParams) As UltraGrid
         Return ug.Imprimir(ug.FindForm().Text, filtro, params)
      End Function
      <Extension()>
      Public Function Imprimir(ug As UltraGrid, titulo As String, filtro As String, params As ImprimirUltraGridParams) As UltraGrid
         If params Is Nothing Then params = New ImprimirUltraGridParams()
         If ug.Rows.Count > 0 Then

            Using ultraGridPrintDocument = New UltraGridPrintDocument()
               ultraGridPrintDocument.Grid = ug
               ultraGridPrintDocument.DocumentName = "Informe"

               ultraGridPrintDocument.Header.TextCenter = String.Format("{1}{0}{0}{2}{0}{0}{3}", Environment.NewLine, Reglas.Publicos.NombreEmpresa, titulo, filtro)

               ultraGridPrintDocument.Header.BorderSides = Border3DSide.Bottom
               ultraGridPrintDocument.Header.BorderStyle = UIElementBorderStyle.None
               ultraGridPrintDocument.Header.Appearance.FontData.Bold = DefaultableBoolean.True
               ultraGridPrintDocument.Header.Appearance.FontData.SizeInPoints = 12
               ultraGridPrintDocument.Header.Appearance.BackColor = Drawing.Color.FromArgb(224, 224, 224)
               ultraGridPrintDocument.Header.Appearance.BackGradientAlignment = GradientAlignment.Element
               ultraGridPrintDocument.Header.Appearance.BackGradientStyle = GradientStyle.VerticalBump


               ultraGridPrintDocument.Page.BorderStyle = UIElementBorderStyle.None
               ultraGridPrintDocument.Page.Margins.Bottom = 2
               ultraGridPrintDocument.Page.Margins.Left = 2
               ultraGridPrintDocument.Page.Margins.Right = 2
               ultraGridPrintDocument.Page.Margins.Top = 2

               ultraGridPrintDocument.PageBody.BorderStyle = UIElementBorderStyle.None
               ultraGridPrintDocument.PageBody.Margins.Bottom = 2
               ultraGridPrintDocument.PageBody.Margins.Left = 2
               ultraGridPrintDocument.PageBody.Margins.Right = 2
               ultraGridPrintDocument.PageBody.Margins.Top = 2


               ultraGridPrintDocument.DefaultPageSettings.Margins = params.Margins
               ultraGridPrintDocument.DefaultPageSettings.Landscape = params.Landscape

               ultraGridPrintDocument.FitWidthToPages = params.FitWidthToPages

               ultraGridPrintDocument.Footer.TextLeft = String.Format("Sucursal: {0}", actual.Sucursal.Nombre)
               ultraGridPrintDocument.Footer.TextCenter = String.Format("Impreso: {0:dd/MM/yyyy}", Date.Today)

               Using ultraPrintPreviewDialog = New Infragistics.Win.Printing.UltraPrintPreviewDialog()
                  ultraPrintPreviewDialog.Document = ultraGridPrintDocument

                  ultraPrintPreviewDialog.Name = titulo
                  ultraPrintPreviewDialog.AutoSizeMode = AutoSizeMode.GrowAndShrink

                  ultraPrintPreviewDialog.Size = ug.FindForm().Size
                  ultraPrintPreviewDialog.StartPosition = FormStartPosition.CenterScreen

                  ultraPrintPreviewDialog.ShowDialog()
                  ultraPrintPreviewDialog.Focus()
               End Using
            End Using
         End If

         Return ug
      End Function

      <Extension>
      Public Function Count(grilla As UltraGrid) As Integer
         Return DirectCast(grilla.Rows, Infragistics.Win.UltraWinGrid.RowsCollection).FilteredInRowCount
      End Function

      <Extension>
      Public Function CantidadRegistrosParaStatusbar(grilla As UltraGrid) As String
         Dim cantidadRegistros As Integer = grilla.Count
         'If grilla.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow Then
         '   cantidadRegistros -= 1
         'End If
         'grilla.DisplayLayout.Bands(0).Summaries
         Return String.Format("{0} Registro{1}", cantidadRegistros, If(cantidadRegistros <> 1, "s", ""))
      End Function

      <Extension>
      Public Function ClearFilas(grilla As UltraGrid) As UltraGrid
         If TypeOf (grilla.DataSource) Is DataTable Then
            DirectCast(grilla.DataSource, DataTable).Rows.Clear()
         ElseIf TypeOf (grilla.DataSource) Is DataSet Then
            DirectCast(grilla.DataSource, DataSet).Clear()
         ElseIf TypeOf (grilla.DataSource) Is IList Then
            DirectCast(grilla.DataSource, IList).Clear()
         End If
         Return grilla
      End Function
      <Extension>
      Public Function ClearFilas(Of T)(grilla As UltraGrid) As UltraGrid
         If TypeOf (grilla.DataSource) Is List(Of T) Then
            DirectCast(grilla.DataSource, List(Of T)).Clear()
            grilla.Rows.Refresh(RefreshRow.ReloadData)
         End If
         Return grilla
      End Function

      <Extension()>
      Public Function ValorAs(Of T)(celda As UltraGridCell) As T
         Return ValorAs(Of T)(celda, valorPorDefecto:=Nothing)
      End Function

      <Extension()>
      Public Function ValorAs(Of T)(celda As UltraGridCell, valorPorDefecto As T) As T
         If TypeOf (celda.Value) Is T Then
            Return DirectCast(celda.Value, T)
         End If
         Return valorPorDefecto
      End Function

      <Extension()>
      Public Function NewValueAs(Of T)(e As UltraWinGrid.BeforeCellUpdateEventArgs) As T
         Return NewValueAs(Of T)(e, valorPorDefecto:=Nothing)
      End Function

      <Extension()>
      Public Function NewValueAs(Of T)(e As UltraWinGrid.BeforeCellUpdateEventArgs, valorPorDefecto As T) As T
         If TypeOf (e.NewValue) Is T Then
            Return DirectCast(e.NewValue, T)
         End If
         Return valorPorDefecto
      End Function

      <Extension()>
      Public Function ColorFromInteger(celda As UltraGridCell, foreColor As Integer?, backColor As Integer?) As UltraGridCell
         Dim backColor1 = If(backColor.HasValue, Drawing.Color.FromArgb(backColor.Value), Nothing)
         Dim foreColor1 = If(foreColor.HasValue, Drawing.Color.FromArgb(foreColor.Value), Nothing)
         Return celda.Color(foreColor1, backColor1)
      End Function

      <Extension()>
      Public Function UpdateData(celda As UltraGridCell) As UltraGridCell
         celda.Row.Band.Layout.Grid.UpdateData()
         Return celda
      End Function

      <Extension()>
      Public Function Color(celda As UltraGridCell, foreColor As Color, backColor As Color) As UltraGridCell
         celda.Appearance.BackColor = backColor
         celda.ActiveAppearance.BackColor = backColor
         celda.Appearance.ForeColor = foreColor
         celda.ActiveAppearance.ForeColor = foreColor

         Return celda
      End Function
      <Extension()>
      Public Function Color2(celda As UltraGridCell, backColor As Color) As UltraGridCell
         celda.Appearance.BackColor2 = backColor
         celda.ActiveAppearance.BackColor2 = backColor
         'celda.Appearance.ForeColor2 = foreColor
         'celda.ActiveAppearance.ForeColor2 = foreColor

         Return celda
      End Function
      <Extension()>
      Public Function Color(columna As UltraGridColumn, foreColor As Color, backColor As Color) As UltraGridColumn
         columna.CellAppearance.BackColor = backColor
         columna.CellAppearance.ForeColor = foreColor
         'celda.CellActiveAppearance.BackColor = backColor
         'celda.CellActiveAppearance.ForeColor = foreColor

         Return columna
      End Function
      <Extension()>
      Public Function ColorClear(celda As UltraGridCell) As UltraGridCell
         Return celda.Color(Nothing, Nothing)
      End Function

      <Extension()>
      Public Function Color(celda As UltraGridCell, colors As ColorPair) As UltraGridCell
         Return celda.Color(colors.ForeColor, colors.BackColor)
      End Function

      Public Structure ColorPair
         Public ReadOnly Property BackColor As Color
         Public ReadOnly Property ForeColor As Color
         Public Sub New(foreColor As Color, backColor As Color)
            _BackColor = backColor
            _ForeColor = foreColor
         End Sub
         Public Shared Function ColorCleaner() As ColorPair
            Return New ColorPair(Nothing, Nothing)
         End Function
         Public Shared Function FromInteger(foreColor As Integer?, backColor As Integer?) As ColorPair
            Return New ColorPair(foreColor.ToArgbColor(), backColor.ToArgbColor())
         End Function

      End Structure

      <Extension()>
      Public Function PuedeEditar(celda As UltraGridCell) As Boolean
         Return celda IsNot Nothing AndAlso
                celda.IsInEditMode AndAlso
                celda.Activation = Activation.AllowEdit AndAlso
                (celda.Row.Band.Override.AllowUpdate = DefaultableBoolean.True Or celda.Row.Band.Override.AllowUpdate = DefaultableBoolean.Default) AndAlso
                (celda.Row.Band.Layout.Override.AllowUpdate = DefaultableBoolean.True Or celda.Row.Band.Layout.Override.AllowUpdate = DefaultableBoolean.Default)
      End Function
      <Extension()>
      Public Function TextoSeleccionadoVacio(celda As UltraGridCell) As Boolean
         If celda Is Nothing Then Return False
         Dim selText = String.Empty
         Try
            selText = celda.SelText
         Catch
         End Try
         Return celda IsNot Nothing AndAlso celda.IsInEditMode AndAlso String.IsNullOrWhiteSpace(selText)
      End Function
      <Extension()>
      Public Sub Cortar(celda As UltraGridCell)
         If celda IsNot Nothing Then
            Clipboard.SetText(celda.SelText)
            If celda.PuedeEditar() Then
               celda.SelText = String.Empty
            End If
         End If
      End Sub
      <Extension()>
      Public Sub Copiar(celda As UltraGridCell)
         If celda IsNot Nothing Then
            Clipboard.SetText(celda.SelText)
         End If
      End Sub
      <Extension()>
      Public Sub Pegar(celda As UltraGridCell)
         If celda IsNot Nothing Then
            If celda.PuedeEditar() Then
               celda.SelText = Clipboard.GetText()
            End If
         End If
      End Sub
      <Extension()>
      Public Sub Eliminar(celda As UltraGridCell)
         If celda IsNot Nothing Then
            If celda.PuedeEditar() Then
               celda.SelText = String.Empty
            End If
         End If
      End Sub
      <Extension()>
      Public Sub SeleccionarTodo(celda As UltraGridCell)
         If celda IsNot Nothing Then
            celda.SelStart = 0
            celda.SelLength = celda.Text.Length
         End If
      End Sub


      <Extension()>
      Public Function ActualizarInfoRegistros(grilla As UltraGrid, tssRegistros As ToolStripStatusLabel) As UltraGrid
         Dim cant = grilla.Rows.FilteredInRowCount
         tssRegistros.Text = String.Format("{0} Registro{1}", cant, If(cant <> 1, "s", ""))
         Return grilla
      End Function


      <Extension()>
      Public Function MarcarDesmarcar(grilla As UltraGrid, cmbTodos As Controles.ComboBox, selectedColumnName As String, accionAdicional As Action(Of Boolean?, UltraGridRow)) As UltraGrid
         Return grilla.MarcarDesmarcar(cmbTodos, selectedColumnName, Function(dr) True, accionAdicional)
      End Function
      <Extension()>
      Public Function MarcarDesmarcar(grilla As UltraGrid, cmbTodos As Controles.ComboBox, selectedColumnName As String) As UltraGrid
         Return grilla.MarcarDesmarcar(cmbTodos, selectedColumnName, Function(dr) True)
      End Function
      <Extension()>
      Public Function MarcarDesmarcar(grilla As UltraGrid, cmbTodos As Controles.ComboBox, selectedColumnName As String, condicion As Func(Of UltraGridRow, Boolean)) As UltraGrid
         Return grilla.MarcarDesmarcar(cmbTodos, selectedColumnName, condicion, accionAdicional:=Nothing)
      End Function
      <Extension()>
      Public Function MarcarDesmarcar(grilla As UltraGrid, cmbTodos As Controles.ComboBox, selectedColumnName As String, condicion As Func(Of UltraGridRow, Boolean),
                                      accionAdicional As Action(Of Boolean?, UltraGridRow)) As UltraGrid
         Dim accion = cmbTodos.ValorSeleccionado(Of Reglas.Publicos.TodosEnum)
         cmbTodos.SelectedValue = grilla.MarcarDesmarcar(accion, selectedColumnName, condicion, accionAdicional)
         Return grilla
      End Function
      <Extension()>
      Private Function MarcarDesmarcar(grilla As UltraGrid, accion As Reglas.Publicos.TodosEnum, selectedColumnName As String, condicion As Func(Of UltraGridRow, Boolean),
                                       accionAdicional As Action(Of Boolean?, UltraGridRow)) As Reglas.Publicos.TodosEnum
         Try
            Select Case accion
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, grilla.Rows.GetAllNonGroupByRows(), selectedColumnName, condicion, accionAdicional)
                  Return Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, grilla.Rows.GetAllNonGroupByRows(), selectedColumnName, condicion, accionAdicional)
                  Return Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, grilla.Rows.GetFilteredInNonGroupByRows(), selectedColumnName, condicion, accionAdicional)
                  Return Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, grilla.Rows.GetFilteredInNonGroupByRows(), selectedColumnName, condicion, accionAdicional)
                  Return Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, grilla.Rows.GetAllNonGroupByRows(), selectedColumnName, condicion, accionAdicional)
                  Return Reglas.Publicos.TodosEnum.InvertirMarcasTodos

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, grilla.Rows.GetFilteredInNonGroupByRows(), selectedColumnName, condicion, accionAdicional)
                  Return Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados

               Case Else
                  Return Reglas.Publicos.TodosEnum.MararTodos

            End Select
         Finally
            grilla.UpdateData()
         End Try
      End Function
      Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow(), selectedColumnName As String, condicion As Func(Of UltraGridRow, Boolean),
                                  accionAdicional As Action(Of Boolean?, UltraGridRow))
         For Each dr As UltraGridRow In rows
            If condicion(dr) Then
               If marcar.HasValue Then
                  dr.Cells(selectedColumnName).Value = marcar.Value
               Else
                  dr.Cells(selectedColumnName).Value = Not CBool(dr.Cells(selectedColumnName).Value)
               End If
            End If
            If accionAdicional IsNot Nothing Then
               accionAdicional(marcar, dr)
            End If
         Next
      End Sub

      Public Enum AccionColapsarExpandir
         Colapsar
         Expandir
      End Enum

      <Extension()>
      Public Function ColapsarExpandir(grilla As UltraGrid, expandir As CheckBox) As UltraGrid
         Return grilla.ColapsarExpandir(expandir.Checked)
      End Function
      <Extension()>
      Public Function ColapsarExpandir(grilla As UltraGrid, expandir As Boolean) As UltraGrid
         Return grilla.ColapsarExpandir(If(expandir, AccionColapsarExpandir.Expandir, AccionColapsarExpandir.Colapsar))
      End Function

      <Extension()>
      Public Function ColapsarExpandir(grilla As UltraGrid, accion As AccionColapsarExpandir) As UltraGrid
         If accion = AccionColapsarExpandir.Expandir Then
            grilla.Rows.ExpandAll(True)
         Else
            grilla.Rows.CollapseAll(True)
         End If
         Return grilla
      End Function

      <Extension()>
      Public Function DataSource(Of T)(grilla As UltraGrid) As T
         If TypeOf (grilla.DataSource) Is T Then
            Return DirectCast(grilla.DataSource, T)
         End If
         Return Nothing
      End Function

      <Extension()>
      Public Function ToHAlign(align As DataGridViewContentAlignment) As HAlign
         Select Case align
            Case DataGridViewContentAlignment.BottomLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.TopLeft
               Return HAlign.Left
            Case DataGridViewContentAlignment.BottomRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.TopRight
               Return HAlign.Right
            Case DataGridViewContentAlignment.BottomCenter, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.TopCenter
               Return HAlign.Center
            Case Else
               Return HAlign.Default
         End Select
      End Function
      <Extension()>
      Public Function ToVAlign(align As DataGridViewContentAlignment) As VAlign
         Select Case align
            Case DataGridViewContentAlignment.TopLeft Or DataGridViewContentAlignment.TopRight Or DataGridViewContentAlignment.TopCenter
               Return VAlign.Top
            Case DataGridViewContentAlignment.MiddleLeft Or DataGridViewContentAlignment.MiddleRight Or DataGridViewContentAlignment.MiddleCenter
               Return VAlign.Middle
            Case DataGridViewContentAlignment.BottomLeft Or DataGridViewContentAlignment.BottomRight Or DataGridViewContentAlignment.BottomCenter
               Return VAlign.Bottom
            Case Else
               Return VAlign.Default
         End Select
      End Function

      <Extension()>
      Public Function Column(grilla As UltraGrid, columnaName As String) As UltraGridColumn
         Return grilla.Column(band:=0, columnaName)
      End Function
      <Extension()>
      Public Function Column(grilla As UltraGrid, band As Integer, columnaName As String) As UltraGridColumn
         Return grilla.DisplayLayout.Bands(band).Columns(columnaName)
      End Function
   End Module

   Public Class ImprimirUltraGridParams
      Public Property FitWidthToPages As Integer
      Public Property Margins As Printing.Margins = New Printing.Margins(20, 20, 20, 40)
      Public Property Landscape As Boolean = False
   End Class

End Namespace