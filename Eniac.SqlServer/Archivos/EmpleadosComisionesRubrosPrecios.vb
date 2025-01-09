Public Class EmpleadosComisionesRubrosPrecios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesRubrosPrecios_I(en As Entidades.EmpleadoComisionRubroPrecio)
      EmpleadosComisionesRubrosPrecios_I(en.IdEmpleado, en.IdRubro, en.IdListaPrecios, en.Comision)
   End Sub
   Public Sub EmpleadosComisionesRubrosPrecios_I(idEmpleado As Integer, idRubro As Integer, idListaPrecios As Integer,
                                                 comision As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO EmpleadosComisionesRubrosPrecios ({0}, {1}, {2}, {3})",
                       Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString(),
                       Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(),
                       Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString(),
                       Entidades.EmpleadoComisionRubroPrecio.Columnas.Comision.ToString())
         .AppendFormat(" VALUES ({0},{1},{2},{3})", idEmpleado, idRubro, idListaPrecios, comision)
      End With
      Execute(myQuery)
   End Sub

   Public Sub EmpleadosComisionesRubrosPrecios_D(en As Entidades.EmpleadoComisionRubroPrecio)
      EmpleadosComisionesRubrosPrecios_D(en.IdEmpleado, en.IdRubro, en.IdListaPrecios)
   End Sub
   Public Sub EmpleadosComisionesRubrosPrecios_D(IdEmpleado As Integer)
      EmpleadosComisionesRubrosPrecios_D(IdEmpleado, 0, 0)
   End Sub

   Public Sub EmpleadosComisionesRubrosPrecios_D(idEmpleado As Integer, idRubro As Integer, idListaPrecios As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM EmpleadosComisionesRubrosPrecios ")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString(), idEmpleado)
         If idRubro <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(), idRubro)
         End If
         If idListaPrecios <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Function GetEmpleadosComisionesRubrosPrecios(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = GetDataTable(Query(IdEmpleado, 0, -1))
      dtResult.TableName = Entidades.EmpleadoComisionRubroPrecio.NombreTabla
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, IdRubro As Integer, IdListaPrecios As Integer) As DataTable
      Return GetDataTable(Query(IdEmpleado, IdRubro, IdListaPrecios))
   End Function

   Private Function Query(idEmpleado As Integer, idRubro As Integer, idListaPrecios As Integer) As String
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT CM.{0}, CM.{1}, CM.{2}, CM.{3}, E.{4}, R.{5}, L.{6}",
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString(),
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(),
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString(),
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.Comision.ToString(),
                           "NombreEmpleado",
                           Entidades.Rubro.Columnas.NombreRubro.ToString(),
                           "NombreListaPrecios")
         .AppendFormatLine("  FROM EmpleadosComisionesRubrosPrecios CM")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = CM.{0} ",
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString())
         .AppendFormatLine(" INNER JOIN Rubros R ON R.{0} = CM.{1}",
                           Entidades.Rubro.Columnas.IdRubro.ToString(),
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString())
         .AppendFormatLine(" INNER JOIN ListasDePrecios L ON L.IdListaPrecios = CM.{0}",
                           Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString())
         .AppendFormatLine(" WHERE 1 = 1")
         If idEmpleado > 0 Then
            .AppendFormatLine("   AND CM.{0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString(), idEmpleado)
         End If
         If idRubro <> 0 Then
            .AppendFormatLine("   AND CM.{0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(), idRubro)
         End If
         If idListaPrecios >= 0 Then
            .AppendFormatLine("   AND CM.{0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         End If
      End With
      Return myQuery.ToString()
   End Function
   Public Function EmpleadosComisionesRubrosPrecios_G1(idEmpleado As Integer, idRubro As Integer, idListaPrecios As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM EmpleadosComisionesRubrosPrecios")
         .AppendFormatLine(" WHERE IdEmpleado = {0}", idEmpleado)
         .AppendFormatLine("   AND IdRubro = {0}", idRubro)
         .AppendFormatLine("   AND IdListaPrecios = {0}", idListaPrecios)
      End With
      Return GetDataTable(myQuery)
   End Function
End Class