Public Class EmpleadosComisionesSubRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesSubRubros_I(IdEmpleado As Integer,
                                             IdRubro As Integer,
                                             IdSubRubro As Integer,
                                             comision As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpleadosComisionesSubRubros")
         .AppendLine("           (IdEmpleado")
         .AppendLine("           ,IdRubro")
         .AppendLine("           ,IdSubRubro")
         .AppendLine("           ,Comision)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2},{3})", IdEmpleado, IdRubro, IdSubRubro, comision)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesSubRubros")

   End Sub

   Public Sub EmpleadosComisionesSubRubros_D(IdEmpleado As Integer, ByVal IdRubro As Integer, ByVal IdSubRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EmpleadosComisionesSubRubros ")
         .AppendFormat(" WHERE IdEmpleado = {0}", IdEmpleado).AppendLine()
         If IdRubro <> 0 Then
            .AppendFormat("   AND IdRubro = {0}", IdRubro).AppendLine()
         End If
         If IdSubRubro <> 0 Then
            .AppendFormat("   AND IdSubRubro = {0}", IdSubRubro).AppendLine()
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesSubRubros")

   End Sub

   Public Function GetEmpleadosComisionesSubRubros(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = Me.GetDataTable(Query(IdEmpleado, 0, 0))
      dtResult.TableName = Entidades.Empleado.ComisionesSubRubrosTableName
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, ByVal IdRubro As Integer, ByVal IdSubRubro As Integer) As DataTable
      Return Me.GetDataTable(Query(IdEmpleado, IdRubro, IdSubRubro))
   End Function

   Private Function Query(IdEmpleado As Integer, ByVal IdRubro As Integer, ByVal IdSubRubro As Integer) As String
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT CS.IdRubro")
         .AppendLine("      , R.NombreRubro")
         .AppendLine("      ,CS.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,CS.Comision")
         .AppendLine("      ,CS.IdEmpleado")
         .AppendLine("  FROM EmpleadosComisionesSubRubros CS")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = CS.IdRubro")
         .AppendLine(" INNER JOIN SubRubros SR ON SR.IdRubro = CS.IdRubro AND SR.IdSubRubro = CS.IdSubRubro")
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdEmpleado > 0 Then
            .AppendFormat("   AND CS.IdEmpleado = {0}", IdEmpleado).AppendLine()
         End If
         If IdRubro <> 0 Then
            .AppendFormat("   AND CS.IdRubro = {0}", IdRubro).AppendLine()
         End If
         If IdSubRubro <> 0 Then
            .AppendFormat("   AND CS.IdSubRubro = {0}", IdSubRubro).AppendLine()
         End If
      End With
      Return myQuery.ToString()
   End Function
End Class
