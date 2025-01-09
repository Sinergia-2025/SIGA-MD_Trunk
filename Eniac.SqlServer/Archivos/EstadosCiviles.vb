Public Class EstadosCiviles
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosCiviles_I(ByVal idEstadoCivil As Integer,
                            ByVal nombreEstadoCivil As String)

      Dim myQuery = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EstadosCiviles ")
         .AppendLine("   (IdEstadoCivil")
         .AppendLine("   ,NombreEstadoCivil")
         .AppendLine(" ) VALUES (")
         .AppendLine(idEstadoCivil.ToString())
         .AppendLine("  ,'" & nombreEstadoCivil & "'")
         .AppendLine(")")
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "EstadosCiviles")
   End Sub

   Public Sub EstadosCiviles_U(ByVal idEstadoCivil As Integer,
                               ByVal nombreEstadoCivil As String)

      Dim myQuery = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE EstadosCiviles ")
         .AppendLine("   SET NombreEstadoCivil = '" & nombreEstadoCivil & "'")
         .AppendLine(" WHERE idEstadoCivil = " & idEstadoCivil)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EstadosCiviles")

   End Sub

   Public Sub EstadosCiviles_D(ByVal idEstadoCivil As Integer)

      Dim myQuery = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EstadosCiviles")
         .AppendLine(" WHERE idEstadoCivil = " & idEstadoCivil.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EstadosCiviles")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT E.IdEstadoCivil")
         .AppendLine("      ,E.NombreEstadoCivil")
         .AppendLine("  FROM EstadosCiviles E")
      End With
   End Sub

   Public Function EstadosCiviles_GA() As DataTable
      Dim myQuery = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY E.NombreEstadoCivil")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function EstadosCiviles_G1(ByVal IdEstadoCivil As Integer) As DataTable
      Dim stb = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE E.IdEstadoCivil = " & IdEstadoCivil.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "E." + columna
      Dim stb = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
