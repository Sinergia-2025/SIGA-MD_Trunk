Public Class EmpleadosComisionesProductosPrecios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesProductosPrecios_I(en As Entidades.EmpleadoComisionProductoPrecio)
      EmpleadosComisionesProductosPrecios_I(en.IdEmpleado, en.IdProducto, en.IdListaPrecios, en.Comision)
   End Sub
   Public Sub EmpleadosComisionesProductosPrecios_I(idEmpleado As Integer, idProducto As String, idListaPrecios As Integer,
                                                 comision As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO EmpleadosComisionesProductosPrecios ({0}, {1}, {2}, {3})",
                       Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString(),
                       Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString(),
                       Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString(),
                       Entidades.EmpleadoComisionProductoPrecio.Columnas.Comision.ToString())
         .AppendFormat(" VALUES ({0},'{1}',{2},{3})", idEmpleado, idProducto, idListaPrecios, comision)
      End With
      Execute(myQuery)
   End Sub

   Public Sub EmpleadosComisionesProductosPrecios_D(en As Entidades.EmpleadoComisionProductoPrecio)
      EmpleadosComisionesProductosPrecios_D(en.IdEmpleado, en.IdProducto, en.IdListaPrecios)
   End Sub
   Public Sub EmpleadosComisionesProductosPrecios_D(IdEmpleado As Integer)
      EmpleadosComisionesProductosPrecios_D(IdEmpleado, "", 0)
   End Sub

   Public Sub EmpleadosComisionesProductosPrecios_D(idEmpleado As Integer, idProducto As String, idListaPrecios As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM EmpleadosComisionesProductosPrecios ")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString(), idEmpleado)
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString(), idProducto)
         End If
         If idListaPrecios <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Function GetEmpleadosComisionesProductosPrecios(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = GetDataTable(Query(IdEmpleado, "", -1))
      dtResult.TableName = Entidades.EmpleadoComisionProductoPrecio.NombreTabla
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, IdProducto As String, IdListaPrecios As Integer) As DataTable
      Return GetDataTable(Query(IdEmpleado, IdProducto, IdListaPrecios))
   End Function

   Private Function Query(idEmpleado As Integer, idProducto As String, idListaPrecios As Integer) As String
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT CM.{0}, CM.{1}, CM.{2}, CM.{3}, E.{4}, P.{5}, L.{6}",
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString(),
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString(),
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString(),
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.Comision.ToString(),
                           "NombreEmpleado",
                           Entidades.Producto.Columnas.NombreProducto.ToString(),
                           "NombreListaPrecios")
         .AppendFormatLine("  FROM EmpleadosComisionesProductosPrecios CM")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = CM.{0} ",
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString())
         .AppendFormatLine(" INNER JOIN Productos P ON P.{0} = CM.{1}",
                           Entidades.Producto.Columnas.IdProducto.ToString(),
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString())
         .AppendFormatLine(" INNER JOIN ListasDePrecios L ON L.IdListaPrecios = CM.{0}",
                           Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString())
         .AppendFormatLine(" WHERE 1 = 1")
         If idEmpleado > 0 Then
            .AppendFormatLine("   AND CM.{0} = {1}", Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString(), idEmpleado)
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND CM.{0} = '{1}'", Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString(), idProducto)
         End If
         If idListaPrecios >= 0 Then
            .AppendFormatLine("   AND CM.{0} = {1}", Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         End If
      End With
      Return myQuery.ToString()
   End Function
   Public Function EmpleadosComisionesProductosPrecios_G1(idEmpleado As Integer, idProducto As String, idListaPrecios As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM EmpleadosComisionesProductosPrecios")
         .AppendFormatLine(" WHERE IdEmpleado = {0}", idEmpleado)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdListaPrecios = {0}", idListaPrecios)
      End With
      Return GetDataTable(myQuery)
   End Function

End Class
