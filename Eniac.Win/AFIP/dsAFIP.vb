Partial Class dsAFIP
   Partial Class CitiComprasDataTable

      Private Sub CitiComprasDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
         If (e.Column.ColumnName = Me.EsDespachoImportacionColumn.ColumnName) Then
            'Add user code here
         End If

      End Sub

   End Class

   Partial Class CitiVentasAlicuotasDataTable


   End Class

   Partial Class CitiVentasDataTable


   End Class

End Class
