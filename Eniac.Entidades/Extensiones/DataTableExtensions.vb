Namespace Extensiones
   Public Module DataTableExtensions

      <Extension()>
      Public Sub ImportRowRange(dt As DataTable, drs() As DataRow)
         For Each dr As DataRow In drs
            dt.ImportRow(dr)
         Next
      End Sub
      <Extension()>
      Public Sub RemoveRowRange(dt As DataTable, drs() As DataRow)
         dt.Rows.RemoveRowRange(drs)
      End Sub
      <Extension()>
      Public Sub RemoveRowRange(drCol As DataRowCollection, drs() As DataRow)
         drs.All(Function(dr)
                    drCol.Remove(dr)
                    Return True
                 End Function)
      End Sub

      <Extension()>
      Public Function AddCopy(Of T As DataRow, dT As DataTable)(dtDestino As dT, drOrigen As T) As T
         Dim drDestino = dtDestino.NewRow()
         Copy(drOrigen, drDestino, accion:=Nothing)
         dtDestino.Rows.Add(drDestino)
         Return DirectCast(drDestino, T)
      End Function
      <Extension()>
      Public Function Copy(Of T As DataRow)(drOrigen As T, drDestino As T) As T
         Return Copy(drOrigen, drDestino, accion:=Nothing)
      End Function

      <Extension()>
      Public Function Copy(Of T As DataRow)(drOrigen As T, drDestino As T, accion As Action(Of T)) As T
         drDestino.ItemArray = DirectCast(drOrigen.ItemArray.Clone(), Object())
         If accion IsNot Nothing Then
            accion(drDestino)
         End If
         Return drDestino
      End Function

      <Extension()>
      Public Function CopyAdd(Of T As DataRow)(dr As T, accion As Action(Of T)) As T
         Dim drNuevo = DirectCast(dr.Table.NewRow(), T)
         drNuevo.ItemArray = DirectCast(dr.ItemArray.Clone(), Object())
         accion(drNuevo)
         dr.Table.Rows.Add(drNuevo)
         Return drNuevo
      End Function

      <Extension()>
      Public Function Add(ds As DataSet, tableName As String, dt As DataTable) As DataSet
         ds.Tables.Add(tableName, dt)
         Return ds
      End Function

      <Extension()>
      Public Sub Add(dtCol As System.Data.DataTableCollection, tableName As String, dt As System.Data.DataTable)
         dt.TableName = tableName
         dtCol.Add(dt)
      End Sub

      <Extension()>
      Public Function ValorNumericoPorDefecto(Of T)(dr As DataRow, key As String, porDefecto As T) As T
         Return Entidades.Extensiones.ObjectExtensions.ValorNumericoPorDefecto(dr(key), porDefecto)
      End Function
      <Extension()>
      Public Function ValorDateTimePorDefecto(dr As DataRow, key As String, porDefecto As DateTime) As DateTime
         Return Entidades.Extensiones.ObjectExtensions.ValorDateTimePorDefecto(dr(key), porDefecto)
      End Function

      <Extension>
      Public Function CountSecure(dt As DataTable) As Integer
         If dt IsNot Nothing Then
            Return dt.AsEnumerable().CountSecure()
         End If
         Return 0I
      End Function
      <Extension()>
      Public Function Count(dt As DataTable) As Integer
         If dt Is Nothing Then Return 0
         Return dt.Rows.Count
      End Function
      <Extension()>
      Public Function Count(dt As DataTable, predicate As Func(Of DataRow, Boolean)) As Integer
         If dt Is Nothing Then
            Return 0
         End If
         Return dt.AsEnumerable.Count(predicate)
      End Function
      <Extension()>
      Public Function Sum(dt As DataTable, predicate As Func(Of DataRow, Decimal)) As Decimal
         If dt Is Nothing Then
            Return 0
         End If
         Return dt.AsEnumerable().Sum(predicate)
      End Function
      <Extension()>
      Public Function Sum(dt As DataTable, predicate As Func(Of DataRow, Integer)) As Integer
         If dt Is Nothing Then
            Return 0
         End If
         Return dt.AsEnumerable().Sum(predicate)
      End Function

      <Extension>
      Public Function CopyToDataTable(source As IEnumerable(Of DataRow), whenEmpty As Func(Of DataTable)) As DataTable
         If source.Count = 0 AndAlso whenEmpty IsNot Nothing Then
            Return whenEmpty()
         End If
         Return source.CopyToDataTable()
      End Function

      <Extension>
      Public Function SingleOrDefault(source As DataTable) As DataRow
         Return source.AsEnumerable.SingleOrDefault()
      End Function
      <Extension>
      Public Function SingleOrDefault(source As DataTable, predicate As Func(Of DataRow, Boolean)) As DataRow
         Return source.AsEnumerable.SingleOrDefault(predicate)
      End Function

      <Extension>
      Public Function FirstOrDefault(source As DataTable) As DataRow
         Return source.AsEnumerable.FirstOrDefault()
      End Function
      <Extension>
      Public Function FirstOrDefault(source As DataTable, predicate As Func(Of DataRow, Boolean)) As DataRow
         Return source.AsEnumerable.FirstOrDefault(predicate)
      End Function
      <Extension>
      Public Sub ForEach(source As DataTable, predicate As Action(Of DataRow))
         source.AsEnumerable.ToList().ForEach(predicate)
      End Sub
      ''''<Extension>
      ''''Public Function Where(source As DataTable, predicate As Func(Of DataRow, Boolean)) As IEnumerable(Of DataRow)
      ''''   Return source.AsEnumerable.Where(predicate)
      ''''End Function
      ''''<Extension>
      ''''Public Sub ForEach(source As IEnumerable(Of T), predicate As Func(Of T, Boolean))
      ''''   source
      ''''End Sub

      <Extension>
      Public Function First(source As DataTable, predicate As Func(Of DataRow, Boolean)) As DataRow
         Return source.AsEnumerable.First(predicate)
      End Function
      <Extension>
      Public Function First(source As DataTable) As DataRow
         Return source.AsEnumerable.First()
      End Function
      <Extension>
      Public Function Any(source As DataTable) As Boolean
         Return source IsNot Nothing AndAlso source.AsEnumerable.Any()
      End Function
      <Extension>
      Public Function Empty(source As DataTable) As Boolean
         Return Not source.Any()
      End Function
      <Extension>
      Public Function Any(source As DataTable, predicate As Func(Of DataRow, Boolean)) As Boolean
         Return source IsNot Nothing AndAlso source.AsEnumerable.Any(predicate)
      End Function
      <Extension>
      Public Function Where(source As DataTable, predicate As Func(Of DataRow, Boolean)) As IEnumerable(Of DataRow)
         If source Is Nothing Then
            Return {}
         End If
         Return source.AsEnumerable.Where(predicate)
      End Function

      <Extension>
      Public Function SumField(row As DataRow, column As String, value As Decimal) As Decimal
         Dim sum = row.Field(Of Decimal?)(column).IfNull() + value
         row.SetField(column, sum)
         Return sum
      End Function

      <Extension>
      Public Function AddRelation(ds As DataSet, name As String, parentColumns As IEnumerable(Of String)) As DataRelation
         Return ds.AddRelation(name, ds.Tables(0), ds.Tables(1), parentColumns, parentColumns)
      End Function
      <Extension>
      Public Function AddRelation(ds As DataSet, name As String,
                          dt1 As DataTable, dt2 As DataTable,
                          parentColumns As IEnumerable(Of String)) As DataRelation
         Return ds.AddRelation(name, dt1, dt2, parentColumns, parentColumns)
      End Function
      <Extension>
      Public Function AddRelation(ds As DataSet, name As String,
                          dt1 As DataTable, dt2 As DataTable,
                          parentColumns As IEnumerable(Of String), childColumns As IEnumerable(Of String)) As DataRelation
         Return ds.Relations.Add(name,
                                 parentColumns.ToList().ConvertAll(Function(c) dt1.Columns(c)).ToArray(),
                                 childColumns.ToList().ConvertAll(Function(c) dt2.Columns(c)).ToArray())
      End Function

      <Extension>
      Public Sub CopiarValores(drDestino As DataRow, drOrigen As DataRow)
         drDestino.CopiarValores(drOrigen, drOrigen.Table.Columns.OfType(Of DataColumn))
      End Sub
      <Extension>
      Public Sub CopiarValores(drDestino As DataRow, drOrigen As DataRow, columnas As IEnumerable(Of DataColumn))
         drDestino.CopiarValores(drOrigen, columnas.ToList().ConvertAll(Function(dc) dc.ColumnName))
      End Sub
      <Extension>
      Public Sub CopiarValores(drDestino As DataRow, drOrigen As DataRow, columnas As IEnumerable(Of String))
         columnas.ToList().ForEach(Sub(col) drDestino(col) = drOrigen(col))
      End Sub

      <Extension>
      Public Function Delete(drCol As IEnumerable(Of DataRow)) As IEnumerable(Of DataRow)
         drCol.ToList().ForEach(Sub(dr) dr.Delete())
         Return drCol
      End Function
      <Extension>
      Public Function AcceptChanges(drCol As IEnumerable(Of DataRow)) As IEnumerable(Of DataRow)
         Dim tables = From dr In drCol
                      Select dr.Table
                      Distinct
         tables.ToList().ForEach(Sub(dt) dt.AcceptChanges())
         Return drCol
      End Function

      <Extension>
      Public Function CopyToDataTable(Of T As DataRow)(source As IEnumerable(Of T), copiarExpresiones As Boolean) As DataTable
         Dim dt = source.CopyToDataTable()
         If copiarExpresiones And source.AnySecure() Then
            For Each dc In source(0).Table.Columns.OfType(Of DataColumn).Where(Function(c) Not String.IsNullOrWhiteSpace(c.Expression))
               dt.Columns(dc.ColumnName).Expression = dc.Expression
            Next
         End If
         Return dt
      End Function

   End Module
End Namespace