Imports System.Runtime.CompilerServices
Namespace Extensiones
   Module DataGridViewExtensions
      <Extension()>
      Public Function ValorNumericoPorDefecto(Of T)(dr As DataGridViewRow, key As String, porDefecto As T) As T
         Return ObjectExtensions.ValorNumericoPorDefecto(dr.Cells(key).Value, porDefecto)
      End Function

      <Extension()>
      Public Function FilaSeleccionada(Of T)(ug As DataGridView) As T
         If ug.SelectedRows.Count = 1 Then
            Return FilaSeleccionada(Of T)(ug, ug.SelectedRows(0))
         End If
         Return FilaSeleccionada(Of T)(ug, ug.CurrentRow)
      End Function
      <Extension()>
      Public Function FilaSeleccionada(Of T)(ug As DataGridView, rowIndex As Integer) As T
         Dim row = ug.Rows(rowIndex)
         Return ug.FilaSeleccionada(Of T)(row)
      End Function

      <Extension()>
      Public Function FilaSeleccionada(Of T)(ug As DataGridView, row As DataGridViewRow) As T
         If row IsNot Nothing AndAlso
            row.DataBoundItem IsNot Nothing Then
            If TypeOf (row.DataBoundItem) Is T Then
               Return DirectCast(row.DataBoundItem, T)
            End If
            If TypeOf (row.DataBoundItem) Is DataRowView AndAlso
               DirectCast(row.DataBoundItem, DataRowView).Row IsNot Nothing AndAlso
               TypeOf (DirectCast(row.DataBoundItem, DataRowView).Row) Is T Then
               Return DirectCast(Convert.ChangeType(DirectCast(row.DataBoundItem, DataRowView).Row, GetType(T)), T)
            End If
         End If
         Return Nothing
      End Function


      ''' <summary>
      ''' Oculta todas las columnas de una banda
      ''' </summary>
      ''' <param name="grilla">Banda a la que se le ocultaran las columnas</param>
      ''' <returns>La instancia de la banda que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function OcultaTodasLasColumnas(grilla As DataGridView) As DataGridView
         For Each columna In grilla.Columns.OfType(Of DataGridViewColumn)
            columna.Visible = False
         Next
         Return grilla
      End Function

      <Extension()>
      Public Function ValorAs(Of T)(celda As DataGridViewCell) As T
         Return ValorAs(Of T)(celda, valorPorDefecto:=Nothing)
      End Function

      <Extension()>
      Public Function ValorAs(Of T)(celda As DataGridViewCell, valorPorDefecto As T) As T
         If TypeOf (celda.Value) Is T Then
            Return DirectCast(celda.Value, T)
         End If
         Return valorPorDefecto
      End Function

      <Extension()>
      Public Function DataSource(Of T)(grilla As DataGridView) As T
         If TypeOf (grilla.DataSource) Is T Then
            Return DirectCast(grilla.DataSource, T)
         End If
         Return Nothing
      End Function

   End Module
End Namespace