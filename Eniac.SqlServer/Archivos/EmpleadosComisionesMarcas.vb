Public Class EmpleadosComisionesMarcas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesMarcas_I(IdEmpleado As Integer, _
                                          ByVal IdMarca As Integer, ByVal comision As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpleadosComisionesMarcas")
         .AppendLine("           (IdEmpleado")
         .AppendLine("           ,IdMarca")
         .AppendLine("           ,Comision)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2})", IdEmpleado, IdMarca, comision)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesMarcas")

   End Sub

   Public Sub EmpleadosComisionesMarcas_D(IdEmpleado As Integer, ByVal IdMarca As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EmpleadosComisionesMarcas ")
         .AppendFormat(" WHERE IdEmpleado = {0}", IdEmpleado).AppendLine()
         If IdMarca <> 0 Then
            .AppendFormat("   AND IdMarca = {0}", IdMarca).AppendLine()
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesMarcas")

   End Sub

   Public Function GetEmpleadosComisionesMarcas(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = Me.GetDataTable(Query(IdEmpleado, 0))
      dtResult.TableName = Entidades.Empleado.ComisionesMarcasTableName
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, ByVal IdMarca As Integer) As DataTable
      Return Me.GetDataTable(Query(IdEmpleado, IdMarca))
   End Function

   Private Function Query(IdEmpleado As Integer, ByVal IdMarca As Integer) As String
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT CM.IdMarca")
         .AppendLine("      , M.NombreMarca")
         .AppendLine("      ,CM.Comision")
         .AppendLine("      ,CM.IdEmpleado")
         .AppendLine("  FROM EmpleadosComisionesMarcas CM")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = CM.IdMarca")
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdEmpleado > 0 Then
            .AppendFormat("   AND CM.IdEmpleado = {0}", IdEmpleado).AppendLine()
         End If
         If IdMarca <> 0 Then
            .AppendFormat("   AND CM.IdMarca = {0}", IdMarca).AppendLine()
         End If
      End With
      Return myQuery.ToString()
   End Function

End Class
