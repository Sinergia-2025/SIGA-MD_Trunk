Public Class ImportarPreciosExcel
   Public Const TableName As String = "PreciosImportados"
   Public Const IdProductoColumnName As String = "IdProducto"
   Public Const NombreProductoColumnName As String = "NombreProducto"
   Public Const PrecioCostoColumnName As String = "PrecioCosto"
   Public Const PrecioCostoCalculadoColumnName As String = "PrecioCostoCalculado"
   Public Const PrecioVentaColumnName As String = "PrecioVenta"
   Public Const PrecioVentaCalculadoColumnName As String = "PrecioVentaCalculado"

   Private Const columnaIdProducto As Integer = 0
   Private Const columnaNombreProducto As Integer = 1
   Private Const columnaPrecioCosto As Integer = 2
   Private Const columnaPrecioVenta As Integer = 3

   Public Function LeerPreciosDesdeExcel(archivoOrigen As String,
                                         rangoColDesde As String, rangoFilaDesde As Integer,
                                         rangoColHasta As String, rangoFilaHasta As Integer,
                                         prefIdProducto As String,
                                         leeCosto As Boolean, incrementoCosto As Decimal,
                                         leeVenta As Boolean, incrementoVenta As Decimal) As DataTable
      Return LeerPreciosDesdeExcel(archivoOrigen,
                                   String.Format("[{0}{1}:{2}{3}]", rangoColDesde, rangoFilaDesde, rangoColHasta, rangoFilaHasta),
                                   prefIdProducto, leeCosto, incrementoCosto, leeVenta, incrementoVenta)
   End Function

   Public Function LeerPreciosDesdeExcel(archivoOrigen As String, rango As String, prefIdProducto As String,
                                         leeCosto As Boolean, incrementoCosto As Decimal, leeVenta As Boolean, incrementoVenta As Decimal) As DataTable
      Dim dtResult = CreaDT()
      Using conexionExcel = CreaConexionExcel.AbrirExcel(archivoOrigen)
         Using da = CreaConexionExcel.CreaDataAdapter(rango, conexionExcel)
            Using ds = New DataSet()
               da.Fill(ds)
               For Each dr In ds.Tables(0).AsEnumerable()

                  Dim idProducto = dr(columnaIdProducto).ToString().IfNull()
                  If Not String.IsNullOrWhiteSpace(prefIdProducto) Then
                     idProducto = String.Concat(prefIdProducto, idProducto)
                  End If

                  Dim drResult = dtResult.NewRow()
                  drResult(IdProductoColumnName) = idProducto
                  drResult(NombreProductoColumnName) = dr.Field(Of String)(columnaNombreProducto).IfNull()


                  If leeCosto Then
                     Dim drCostoLeido = ValorDecimal(dr, columnaPrecioCosto)
                     If drCostoLeido.HasValue Then
                        Dim costo = drCostoLeido.Value
                        Dim costoCalculado = costo + (costo * incrementoCosto / 100)

                        drResult(PrecioCostoColumnName) = costo
                        drResult(PrecioCostoCalculadoColumnName) = costoCalculado
                     End If
                  End If

                  If leeVenta Then
                     Dim drVentaLeido = ValorDecimal(dr, columnaPrecioVenta)
                     If drVentaLeido.HasValue Then
                        Dim venta = drVentaLeido.Value
                        Dim ventaCalculado = venta + (venta * incrementoVenta / 100)

                        drResult(PrecioVentaColumnName) = venta
                        drResult(PrecioVentaCalculadoColumnName) = ventaCalculado
                     End If
                  End If

                  dtResult.Rows.Add(drResult)
               Next
            End Using
         End Using
         conexionExcel.Close()
      End Using
      Return dtResult
   End Function
   Private Function ValorDecimal(dr As DataRow, columnIndex As Integer) As Decimal?
      If dr.Table.Columns(columnIndex).DataType.Equals(GetType(Decimal)) Then
         Return dr.Field(Of Decimal?)(columnIndex)
      ElseIf dr.Table.Columns(columnIndex).DataType.Equals(GetType(Double)) Then
         Dim value = dr.Field(Of Double?)(columnIndex)
         If value.HasValue Then
            Return value.Value.ToDecimal()
         End If
      End If
      Return Nothing
   End Function
   Private Function CreaDT() As DataTable
      Dim dtResult = New DataTable() '("PreciosImportados")
      dtResult.Columns.AddRange({New DataColumn(IdProductoColumnName, GetType(String)),
                                 New DataColumn(NombreProductoColumnName, GetType(String)),
                                 New DataColumn(PrecioCostoColumnName, GetType(Decimal)),
                                 New DataColumn(PrecioCostoCalculadoColumnName, GetType(Decimal)),
                                 New DataColumn(PrecioVentaColumnName, GetType(Decimal)),
                                 New DataColumn(PrecioVentaCalculadoColumnName, GetType(Decimal))})
      Return dtResult
   End Function

End Class