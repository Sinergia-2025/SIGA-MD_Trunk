Imports Eniac.Entidades
Public Class EmpleadosComisionesMarcasPrecios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesMarcasPrecios_I(en As EmpleadoComisionMarcaPrecio)
      EmpleadosComisionesMarcasPrecios_I(en.IdEmpleado, en.IdMarca, en.IdListaPrecios, en.Comision)
   End Sub
   Public Sub EmpleadosComisionesMarcasPrecios_I(IdEmpleado As Integer, _
                                                 IdMarca As Integer, IdListaPrecios As Integer,
                                                 comision As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO EmpleadosComisionesMarcasPrecios ({0}, {1}, {2}, {3})",
                       EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString(),
                       EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(),
                       EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString(),
                       EmpleadoComisionMarcaPrecio.Columnas.Comision.ToString())
         .AppendFormat(" VALUES ({0},{1},{2},{3})", IdEmpleado, IdMarca, IdListaPrecios, comision)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EmpleadosComisionesMarcasPrecios_D(en As EmpleadoComisionMarcaPrecio)
      EmpleadosComisionesMarcasPrecios_D(en.IdEmpleado, en.IdMarca, en.IdListaPrecios)
   End Sub
   Public Sub EmpleadosComisionesMarcasPrecios_D(IdEmpleado As Integer)
      EmpleadosComisionesMarcasPrecios_D(IdEmpleado, 0, 0)
   End Sub

   Public Sub EmpleadosComisionesMarcasPrecios_D(IdEmpleado As Integer,
                                                 IdMarca As Integer, IdListaPrecios As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("DELETE FROM EmpleadosComisionesMarcasPrecios ")
         .AppendFormat(" WHERE {0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString(), IdEmpleado).AppendLine()
             If IdMarca <> 0 Then
            .AppendFormat("   AND {0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(), IdMarca).AppendLine()
         End If
         If IdListaPrecios <> 0 Then
            .AppendFormat("   AND {0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString(), IdListaPrecios).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function GetEmpleadosComisionesMarcasPrecios(idEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = Me.GetDataTable(Query(idEmpleado, 0, -1))
      dtResult.TableName = Entidades.EmpleadoComisionMarcaPrecio.NombreTabla
      Return dtResult
   End Function

   Public Function GetUna(IdEmpleado As Integer, IdMarca As Integer, IdListaPrecios As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("SELECT IdEmpleado ")
         .AppendLine(" ,IdMarca ")
         .AppendLine(" ,IdListaPrecios ")
         .AppendLine(" ,Comision ")
         .AppendLine(" FROM EmpleadosComisionesMarcasPrecios ")
         .AppendLine(" WHERE IdEmpleado = " & IdEmpleado)
         .AppendLine(" AND IdMArca = " & IdMarca)
         .AppendLine(" AND IdListaPrecios = " & IdListaPrecios)
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Get1(IdEmpleado As Integer, IdMarca As Integer, IdListaPrecios As Integer) As DataTable
      Return Me.GetDataTable(Query(IdEmpleado, IdMarca, IdListaPrecios))
   End Function

   Private Function Query(IdEmpleado As Integer, IdMarca As Integer, IdListaPrecios As Integer) As String
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("SELECT CM.{0}, CM.{1}, CM.{2}, CM.{3}, E.{4}, M.{5}, L.{6}",
                       EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString(),
                       EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(),
                       EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString(),
                       EmpleadoComisionMarcaPrecio.Columnas.Comision.ToString(),
                       "NombreEmpleado",
                       Marca.Columnas.NombreMarca.ToString(),
                       "NombreListaPrecios").AppendLine()
         .AppendFormat("  FROM EmpleadosComisionesMarcasPrecios CM").AppendLine()
         .AppendFormat(" INNER JOIN Empleados E ON E.IdEmpleado = CM.{0} ",
                                          EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString())
         .AppendFormat(" INNER JOIN Marcas M ON M.{0} = CM.{1}",
                                           Marca.Columnas.IdMarca.ToString(),
                                           EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString()).AppendLine()
         .AppendFormat(" INNER JOIN ListasDePrecios L ON L.IdListaPrecios = CM.{0}",
                                          EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString()).AppendLine()
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdEmpleado > 0 Then
            .AppendFormat("   AND CM.{0} = '{1}'", EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString(), IdEmpleado).AppendLine()
         End If
         If IdMarca <> 0 Then
            .AppendFormat("   AND CM.{0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(), IdMarca).AppendLine()
         End If
         If IdListaPrecios >= 0 Then
            .AppendFormat("   AND CM.{0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString(), IdListaPrecios).AppendLine()
         End If
      End With
      Return myQuery.ToString()
   End Function

End Class
