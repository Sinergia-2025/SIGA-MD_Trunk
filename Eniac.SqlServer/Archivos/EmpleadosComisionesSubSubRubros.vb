Public Class EmpleadosComisionesSubSubRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosComisionesSubSubRubros_I(IdEmpleado As Integer,
                                             IdRubro As Integer,
                                             IdSubRubro As Integer,
                                             IdSubSubRubro As Integer,
                                             comision As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpleadosComisionesSubSubRubros")
         .AppendLine("           (IdEmpleado")
         .AppendLine("           ,IdRubro")
         .AppendLine("           ,IdSubRubro")
         .AppendLine("           ,IdSubSubRubro")
         .AppendLine("           ,Comision)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2},{3},{4})", IdEmpleado, IdRubro, IdSubRubro, IdSubSubRubro, comision)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesSubSubRubros")

   End Sub

   Public Sub EmpleadosComisionesSubSubRubros_D(IdEmpleado As Integer, ByVal IdRubro As Integer, ByVal IdSubRubro As Integer, ByVal IdSubSubRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EmpleadosComisionesSubSubRubros ")
         .AppendFormat(" WHERE IdEmpleado = {0}", IdEmpleado).AppendLine()
         If IdRubro <> 0 Then
            .AppendFormat("   AND IdRubro = {0}", IdRubro).AppendLine()
         End If
         If IdSubRubro <> 0 Then
            .AppendFormat("   AND IdSubRubro = {0}", IdSubRubro).AppendLine()
         End If
         If IdSubSubRubro <> 0 Then
            .AppendFormat("   AND IdSubSubRubro = {0}", IdSubSubRubro).AppendLine()
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesSubSubRubros")

   End Sub

   Public Function GetEmpleadosComisionesSubSubRubros(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = Me.GetDataTable(Query(IdEmpleado, 0, 0, 0))
      dtResult.TableName = Entidades.Empleado.ComisionesSubSubRubrosTableName
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, ByVal IdRubro As Integer, ByVal IdSubRubro As Integer, ByVal IdSubSubRubro As Integer) As DataTable
      Return Me.GetDataTable(Query(IdEmpleado, IdRubro, IdSubRubro, IdSubSubRubro))
   End Function

   Private Function Query(IdEmpleado As Integer, ByVal IdRubro As Integer, ByVal IdSubRubro As Integer, ByVal IdSubSubRubro As Integer) As String
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT CS.IdRubro")
         .AppendLine("      , R.NombreRubro")
         .AppendLine("      ,CS.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,CS.IdSubSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")
         .AppendLine("      ,CS.Comision")
         .AppendLine("      ,CS.IdEmpleado")
         .AppendLine("  FROM EmpleadosComisionesSubSubRubros CS")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = CS.IdRubro")
         .AppendLine(" INNER JOIN SubRubros SR ON SR.IdRubro = CS.IdRubro AND SR.IdSubRubro = CS.IdSubRubro")
         .AppendLine(" INNER JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = CS.IdSubSubRubro AND SSR.IdSubRubro = CS.IdSubRubro")
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
         If IdSubSubRubro <> 0 Then
            .AppendFormat("   AND CS.IdSubSubRubro = {0}", IdSubSubRubro).AppendLine()
         End If
      End With
      Return myQuery.ToString()
   End Function
End Class
