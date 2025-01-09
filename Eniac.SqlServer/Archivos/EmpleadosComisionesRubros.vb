Public Class EmpleadosComisionesRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesRubros_I(IdEmpleado As Integer, _
                                          ByVal IdRubro As Integer, ByVal comision As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpleadosComisionesRubros")
         .AppendLine("           (IdEmpleado")
         .AppendLine("           ,IdRubro")
         .AppendLine("           ,Comision)")
         .AppendLine("         VALUES")
         .AppendFormat("           ('{0}',{1},{2})", IdEmpleado, IdRubro, comision)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesRubros")

   End Sub

   Public Sub EmpleadosComisionesRubros_D(IdEmpleado As Integer, ByVal IdRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EmpleadosComisionesRubros ")
         .AppendFormat(" WHERE IdEmpleado = {0}", IdEmpleado).AppendLine()
         If IdRubro <> 0 Then
            .AppendFormat("   AND IdRubro = {0}", IdRubro).AppendLine()
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesRubros")

   End Sub

   Public Function GetEmpleadosComisionesRubros(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = Me.GetDataTable(Query(IdEmpleado, 0))
      dtResult.TableName = Entidades.Empleado.ComisionesRubrosTableName
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, ByVal IdRubro As Integer) As DataTable
      Return Me.GetDataTable(Query(IdEmpleado, IdRubro))
   End Function

   Private Function Query(IdEmpleado As Integer, ByVal IdRubro As Integer) As String
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT CR.IdRubro")
         .AppendLine("      , R.NombreRubro")
         .AppendLine("      ,CR.Comision")
         .AppendLine("      ,CR.IdEmpleado")
         .AppendLine("  FROM EmpleadosComisionesRubros CR")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = CR.IdRubro")
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdEmpleado > 0 Then
            .AppendFormat("   AND CR.IdEmpleado = {0}", IdEmpleado).AppendLine()
         End If
         If IdRubro <> 0 Then
            .AppendFormat("   AND CR.IdRubro = {0}", IdRubro).AppendLine()
         End If
      End With
      Return myQuery.ToString()
   End Function

End Class
