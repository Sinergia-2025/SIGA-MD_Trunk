Public Class EmpleadosComisionesProductos
    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

   Public Sub EmpleadosComisionesProductos_I(IdEmpleado As Integer, _
                                           ByVal IdProducto As String, ByVal comision As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpleadosComisionesProductos")
         .AppendLine("           (IdEmpleado")
         .AppendLine("           ,IdProducto")
         .AppendLine("           ,Comision)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},'{1}',{2})", IdEmpleado, IdProducto, comision)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesProductos")

   End Sub

   Public Sub EmpleadosComisionesProductos_D(IdEmpleado As Integer, ByVal IdProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EmpleadosComisionesProductos ")
         .AppendFormat(" WHERE IdEmpleado = '{0}'", IdEmpleado).AppendLine()

         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND IdProducto = '{0}'", IdProducto).AppendLine()
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpleadosComisionesProductos")

   End Sub

   Public Function GetEmpleadosComisionesProductos(IdEmpleado As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = Me.GetDataTable(Query(IdEmpleado, ""))
      dtResult.TableName = Entidades.Empleado.ComisionesProductosTableName
      Return dtResult
   End Function

   Public Function Get1(IdEmpleado As Integer, ByVal IdProducto As String) As DataTable
      Return Me.GetDataTable(Query(IdEmpleado, IdProducto))
   End Function

   Private Function Query(IdEmpleado As Integer, ByVal IdProducto As String) As String
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT CP.IdProducto")
         .AppendLine("      , P.NombreProducto")
         .AppendLine("      ,CP.Comision")
         .AppendLine("      ,CP.IdEmpleado")
         .AppendLine("  FROM EmpleadosComisionesProductos CP")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = CP.IdProducto")
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdEmpleado > 0 Then
            .AppendFormat("   AND CP.IdEmpleado = '{0}'", IdEmpleado).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND CP.IdProducto = '{0}'", IdProducto).AppendLine()
         End If
      End With
      Return myQuery.ToString()
   End Function

End Class
